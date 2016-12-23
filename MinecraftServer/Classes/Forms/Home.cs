using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using MCSC.Classes.Downloader;
using MCSC.Properties;
using MinecraftServer;

namespace MCSC.Classes.Forms
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private bool _stopOnServerStart;
        private Rcon.Rcon _rcon;

        private void updateBungee_Click(object sender, EventArgs e)
        {
            var fileDownloader = new FileDownloader(
                new Uri("http://ci.md-5.net/job/BungeeCord/lastSuccessfulBuild/artifact/bootstrap/target/BungeeCord.jar"),
                Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"MinecraftServer\Servers\Bungee"),
                "server.jar",
                (dl1Sender, dl1EventArgs) =>
                {
                    _stopOnServerStart = true;
                    if (updateBungee.Text == Resources.scWord_download + @" Bungee")
                    {
                        AddToServerList("Bungee");
                        updateBungee.Text = Resources.scWord_update + @" Bungee";
                        addServer.Enabled = true;
                        startStopBungee.Enabled = true;
                        optionsBox.Enabled = true;
                    }
                    startStopBungee.PerformClick();
                }
            );
        }

        private void ServerDeleted(object source, FileSystemEventArgs e)
        {
            MessageBox.Show(Resources.serverFolderDeleted1 + e.FullPath.Split('\\')[e.FullPath.Split('\\').Length - 1] + Resources.serverFolderDeleted2, Resources.longName + Resources.errName);
            Invoke(new MethodInvoker(CheckServers));
        }

        private void addServer_Click(object sender, EventArgs e)
        {
            var choose = new newServer();
            choose.ShowDialog();
            CheckServers();
        }

        private void home_Load(object sender, EventArgs e)
        {
            Directory.CreateDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"MinecraftServer\Servers"));
            if (File.Exists(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"MinecraftServer\Servers\Bungee\server.jar")))
            {
                startStopBungee.Enabled = true;
                optionsBox.Enabled = true;
            } else
            {
                updateBungee.Text = Resources.scWord_download + @"Bungee";
                addServer.Enabled = false;
            }
            CheckServers();
        }
        
        public string AddToServerList(string name)
        {
            serverList.Items.Add(name);
            return name;
        }

        public void ClearServerList()
        {
            serverList.Items.Clear();
        }

        public void CheckServers()
        {
            var dirs = Directory.GetDirectories(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"MinecraftServer\Servers"));
            ClearServerList();
            foreach(var dir in dirs)
            {
                AddToServerList(dir.Split('\\')[dir.Split('\\').Length - 1].Replace('_', ' '));
            }
            var watch = new FileSystemWatcher
            {
                Path =
                    Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                        @"MinecraftServer\Servers"),
                NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite
                               | NotifyFilters.FileName | NotifyFilters.DirectoryName,
                Filter = "*"
            };
            watch.Deleted -= ServerDeleted;
            watch.Deleted += ServerDeleted;
            watch.EnableRaisingEvents = true;
        }

        public Process Bungee = new Process();

        private void startStopBungee_Click(object sender, EventArgs e)
        {
            if (startStopBungee.Text == Resources.scWord_start)
            {
                bungeeOutput.Text = "";
                bungeeOutput.AppendText("[" + Resources.shortName + "] Starting server..." + Environment.NewLine, Color.Black, Color.Transparent);
                var info = new ProcessStartInfo
                {
                    CreateNoWindow = true,
                    RedirectStandardInput = true,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    WorkingDirectory =
                        Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                            @"MinecraftServer\Servers\Bungee"),
                    FileName = "java",
                    Arguments = "-Xmx" + bungeeRAM.Text + "M -jar server.jar --nojline --port " + bungeePort.Text
                };


                Bungee.StartInfo = info;

                Bungee.OutputDataReceived += bungee_update;
                Bungee.ErrorDataReceived += bungee_error;

                var bungeeExitThread = new Thread(() =>
                {
                    Bungee.WaitForExit();
                    
                    bungeeOutput.Invoke(new MethodInvoker(() =>
                    {
                        bungeeOutput.AppendText("[" + Resources.shortName + "] Bungeecord has exited", Color.Black);
                        startStopBungee.Text = Resources.scWord_start;

                        Bungee.OutputDataReceived -= bungee_update;
                        Bungee.ErrorDataReceived -= bungee_update;
                        Bungee = new Process();
                    }));
                });

                Bungee.Start();
                bungeeExitThread.Start();

                Bungee.BeginOutputReadLine();

                startStopBungee.Enabled = false;
            } else if (startStopBungee.Text == Resources.scWord_stop)
            {
                _rcon.SendCommand("end");
                startStopBungee.Text = Resources.scWord_kill;
            }
            else
            {
                Bungee.Kill();
            }
        }

        private void bungee_update(object sendingProcess, DataReceivedEventArgs d)
        {
            bungeeOutput.Invoke(new MethodInvoker(() =>
            {
                if (string.IsNullOrEmpty(d.Data)) return;
                if (d.Data.Length <= 9) return;
                
                var data = d.Data;
                var time = data.Substring(0, 9);
                var info = data.Substring(9);
                var color = Color.Black;
                if (info.IndexOf("[INFO]", StringComparison.Ordinal) == 0)
                {
                    color = Color.DarkGreen;
                }
                if (info.IndexOf("[WARNING]", StringComparison.Ordinal) == 0)
                {
                    color = Color.DarkOrange;
                }
                if (info.IndexOf("[ERROR]", StringComparison.Ordinal) == 0)
                {
                    color = Color.DarkRed;
                }
                if (info.IndexOf("[SEVERE]", StringComparison.Ordinal) == 0)
                {
                    color = Color.DarkRed;
                }

                bungeeOutput.AppendText(time, Color.Goldenrod, Color.Azure).SetBackColor(Color.Transparent).AppendText(info + Environment.NewLine, color);
                bungeeOutput.SelectionStart = bungeeOutput.TextLength;
                bungeeOutput.ScrollToCaret();

                if (info.IndexOf("[INFO] Listening on ", StringComparison.Ordinal) == 0)
                {
                    startStopBungee.Text = Resources.scWord_stop;
                    startStopBungee.Enabled = true;
                    if (_stopOnServerStart)
                    {
                        startStopBungee.PerformClick();
                        _stopOnServerStart = false;
                    }
                }

                if (info.IndexOf("[INFO] Thank you and goodbye", StringComparison.Ordinal) == 0)
                {
                    Bungee.Kill();
                }

                if (info.IndexOf("[INFO] MCSC_BUNGEE_PASSWORD=", StringComparison.Ordinal) == 0)
                {
                    var rconPassword = info.Substring(28);
                    bungeeOutput.SetBackColor(Color.Transparent).AppendText("[" + Resources.shortName + "] Connecting to RCON using password **** on port 10001" + Environment.NewLine);
                    _rcon = new Rcon.Rcon(rconPassword, 10001);
                }
            }));
        }

        private void bungee_error(object sendingProcess, DataReceivedEventArgs d)
        {
            MessageBox.Show(Resources.errorOccuredTitle + Environment.NewLine + d.Data, Resources.longName);
        }

        private void options_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bungeeRunCMD_Click(object sender, EventArgs e)
        {
            _rcon.SendCommand("/" + command.Text);
            command.Text = "";
        }

        private void home_Close(object sender, FormClosingEventArgs e)
        {
            var text = startStopBungee.Text;
            if (startStopBungee.Text != Resources.scWord_start || !startStopBungee.Enabled)
            {
                if (startStopBungee.Text != Resources.scWord_kill) e.Cancel = true;
                startStopBungee.Enabled = true;
                if (text == Resources.scWord_start) startStopBungee.Text = Resources.scWord_stop;
                startStopBungee.PerformClick();
            }
        }

        private void command_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                bungeeRunCMD.PerformClick();
            }
        }
    }
}
