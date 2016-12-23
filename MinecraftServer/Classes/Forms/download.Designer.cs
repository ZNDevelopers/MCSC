﻿namespace MCSC.Classes.Forms
{
    partial class Download
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.downloadProgress = new System.Windows.Forms.ProgressBar();
            this.downloadAmount = new System.Windows.Forms.Label();
            this.TimeLeft = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // downloadProgress
            // 
            this.downloadProgress.Location = new System.Drawing.Point(13, 13);
            this.downloadProgress.Name = "downloadProgress";
            this.downloadProgress.Size = new System.Drawing.Size(373, 44);
            this.downloadProgress.TabIndex = 0;
            this.downloadProgress.UseWaitCursor = true;
            // 
            // downloadAmount
            // 
            this.downloadAmount.AutoSize = true;
            this.downloadAmount.Location = new System.Drawing.Point(13, 64);
            this.downloadAmount.Name = "downloadAmount";
            this.downloadAmount.Size = new System.Drawing.Size(78, 13);
            this.downloadAmount.TabIndex = 1;
            this.downloadAmount.Text = "Downloading...";
            this.downloadAmount.UseWaitCursor = true;
            // 
            // TimeLeft
            // 
            this.TimeLeft.AutoSize = true;
            this.TimeLeft.Location = new System.Drawing.Point(13, 80);
            this.TimeLeft.Name = "TimeLeft";
            this.TimeLeft.Size = new System.Drawing.Size(138, 13);
            this.TimeLeft.TabIndex = 2;
            this.TimeLeft.Text = "Calculating time remaining...";
            this.TimeLeft.UseWaitCursor = true;
            // 
            // download
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(398, 101);
            this.ControlBox = false;
            this.Controls.Add(this.TimeLeft);
            this.Controls.Add(this.downloadAmount);
            this.Controls.Add(this.downloadProgress);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Download";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Download Progress";
            this.TopMost = true;
            this.UseWaitCursor = true;
            this.Load += new System.EventHandler(this.download_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.ProgressBar downloadProgress;
        public System.Windows.Forms.Label downloadAmount;
        public System.Windows.Forms.Label TimeLeft;
    }
}