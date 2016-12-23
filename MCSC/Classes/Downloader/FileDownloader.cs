using System;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Net;
using System.Timers;
using Microsoft.WindowsAPICodePack.Taskbar;
using MCSC.Classes.Forms;
using MCSC.Properties;
using Timer = System.Timers.Timer;

namespace MCSC.Classes.Downloader
{
    public class FileDownloader
    {
        private readonly Download _download;
        private double _averageSpeed, _previousDownloadAmount, _bytesRecieved, _totalBytes;
        private readonly AsyncCompletedEventHandler _callback;
        private bool _hasStartedDownloading;
        private readonly Timer _calculationTimer = new Timer
        {
            AutoReset = true,
            Enabled = true
        };

        public FileDownloader(Uri uri, string path, string fileName, AsyncCompletedEventHandler callback)
        {
            _callback = callback;

            _calculationTimer.Elapsed += Timer_Elapsed;

            Directory.CreateDirectory(path);
            var client = new WebClient();

            client.DownloadProgressChanged += Client_DownloadProgressChanged;
            client.DownloadFileCompleted += Client_DownloadFileCompleted;
            client.DownloadFileAsync(uri, Path.Combine(path, fileName));

            _download = new Download();
            _download.ShowDialog();
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (_totalBytes <= 0) return;
            if (_download.TimeLeft.InvokeRequired)
            {
                _download.TimeLeft.Invoke(new UpdateDownloadTextTimer(Timer_Elapsed), sender, e);
                return;
            }

            var lastSpeed = _bytesRecieved - _previousDownloadAmount;


            //_averageSpeed = 0.1 * lastSpeed + (1 - 0.1) * _averageSpeed;
            _averageSpeed = (_averageSpeed + lastSpeed * 2) / 3;
            _download.TimeLeft.Text = Math.Round((_totalBytes-_bytesRecieved) / _averageSpeed).ToString(CultureInfo.InvariantCulture) + Resources.timeLeftText;

            _previousDownloadAmount = _bytesRecieved;
        }

        private delegate void UpdateDownloadTextTimer(object sender, ElapsedEventArgs e);

        private void Client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            var bytesIn = double.Parse(e.BytesReceived.ToString());
            _bytesRecieved = bytesIn;
            var totalBytes = double.Parse(e.TotalBytesToReceive.ToString());
            _totalBytes = totalBytes;
            if (!_hasStartedDownloading)
            {
                _calculationTimer.Interval = totalBytes/1024/50;
                _calculationTimer.Start();
                _hasStartedDownloading = true;
            }
            var percentage = bytesIn/totalBytes*100;
            _download.downloadAmount.Text = Resources.amountDownloadedText + ' ' + Math.Truncate(percentage) + Resources.percentSymbol;
            _download.downloadProgress.Value =
                int.Parse(Math.Truncate(percentage).ToString(CultureInfo.InvariantCulture));

            var prog = TaskbarManager.Instance;
            prog.SetProgressState(TaskbarProgressBarState.Normal);
            prog.SetProgressValue(e.ProgressPercentage, 100);

        }

        private void Client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            _download.Close();
            TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.NoProgress);
            _callback(sender, e);
        }
    }
}