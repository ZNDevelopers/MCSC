using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;
using MCSC.Classes.Downloader;
using MCSC.Classes.Forms;
using MinecraftServer;

namespace MinecraftServer
{
    public partial class newServer : Form
    {
        public newServer()
        {
            InitializeComponent();
        }

        Download DlBox;
        private int averageSpeed = 0;

        private void okButton_Click(object sender, EventArgs e)
        {
            if (serverType.Text != "Spigot/BuildCraft") return;
            var oldText = serverName.Text;
            serverName.Text = serverName.Text.Replace(' ', '_').Replace('\\', '_').Replace('/', '_');
            // https://hub.spigotmc.org/jenkins/job/BuildTools/lastSuccessfulBuild/artifact/target/BuildTools.jar

            var fileDownloader = new FileDownloader(new Uri("https://hub.spigotmc.org/jenkins/job/BuildTools/lastSuccessfulBuild/artifact/target/BuildTools.jar"), Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"MinecraftServer\Servers\" + serverName.Text), "server.jar",
                (o, args) =>
                {
                    Close();
                });

            /*WebClient Client = new WebClient();
            Client.DownloadProgressChanged += client_DownloadProgressChanged;
            Client.DownloadFileCompleted += client_DownloadFileCompleted;
            Directory.CreateDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"MinecraftServer\Servers\" + serverName.Text + @"\"));
            Client.DownloadFileAsync(new Uri("https://hub.spigotmc.org/jenkins/job/BuildTools/lastSuccessfulBuild/artifact/target/BuildTools.jar"), Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"MinecraftServer\Servers\" + serverName.Text + @"\server.jar"));
            DlBox = new download();
            serverName.Text = oldText;
            DlBox.ShowDialog();*/
        }

        private void serverName_TextChanged(object sender, EventArgs e)
        {
            if (serverName.Text.Length < 5 || serverName.Text.ToLower() == "bungee")
            {
                willBeSavedAs.Text = "Please enter a server name.";
                okButton.Enabled = false;
            } else
            {
                willBeSavedAs.Text = "(Will be saved as '" + serverName.Text.Replace(' ', '_').Replace('\\', '_').Replace('/', '_') + "')";
                okButton.Enabled = true;
            }
        }

        void client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            double bytesIn = double.Parse(e.BytesReceived.ToString());
            double totalBytes = double.Parse(e.TotalBytesToReceive.ToString());
            double percentage = bytesIn / totalBytes * 100;
            DlBox.downloadAmount.Text = "Downloaded " + Math.Truncate(percentage) + "%";
            DlBox.TimeLeft.Text = averageSpeed.ToString();
            DlBox.downloadProgress.Value = int.Parse(Math.Truncate(percentage).ToString());
            Globals.newServerName = serverName.Text;
        }

        void client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            DlBox.downloadAmount.Text = "Completed";
            DlBox.Close();
            Close();
        }

        private void newServer_Close(object sender, FormClosingEventArgs e)
        {
            //e.Cancel = true;
            //Globals.FadeOut(this, 10, true);
        }
    }
}
