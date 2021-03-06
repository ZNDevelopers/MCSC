﻿namespace MCSC.Classes.Forms
{
    partial class Home
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Home));
            this.currentServers = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.serverList = new System.Windows.Forms.ListBox();
            this.updateBungee = new System.Windows.Forms.Button();
            this.addServer = new System.Windows.Forms.Button();
            this.bungeeGroup = new System.Windows.Forms.GroupBox();
            this.bungeeOutput = new System.Windows.Forms.RichTextBox();
            this.bungeeRunCMD = new System.Windows.Forms.Button();
            this.command = new System.Windows.Forms.TextBox();
            this.optionsBox = new System.Windows.Forms.GroupBox();
            this.options = new System.Windows.Forms.Panel();
            this.bungeeRAM = new System.Windows.Forms.NumericUpDown();
            this.bungeePort = new System.Windows.Forms.NumericUpDown();
            this.serverPort = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.startStopBungee = new System.Windows.Forms.Button();
            this.currentServers.SuspendLayout();
            this.bungeeGroup.SuspendLayout();
            this.optionsBox.SuspendLayout();
            this.options.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bungeeRAM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bungeePort)).BeginInit();
            this.SuspendLayout();
            // 
            // currentServers
            // 
            this.currentServers.Controls.Add(this.label1);
            this.currentServers.Controls.Add(this.serverList);
            this.currentServers.Controls.Add(this.updateBungee);
            this.currentServers.Controls.Add(this.addServer);
            this.currentServers.Location = new System.Drawing.Point(13, 13);
            this.currentServers.Name = "currentServers";
            this.currentServers.Size = new System.Drawing.Size(183, 413);
            this.currentServers.TabIndex = 0;
            this.currentServers.TabStop = false;
            this.currentServers.Text = "Current Servers";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Servers:";
            // 
            // serverList
            // 
            this.serverList.FormattingEnabled = true;
            this.serverList.Location = new System.Drawing.Point(7, 78);
            this.serverList.Name = "serverList";
            this.serverList.Size = new System.Drawing.Size(170, 303);
            this.serverList.TabIndex = 3;
            // 
            // updateBungee
            // 
            this.updateBungee.Location = new System.Drawing.Point(7, 20);
            this.updateBungee.Name = "updateBungee";
            this.updateBungee.Size = new System.Drawing.Size(170, 23);
            this.updateBungee.TabIndex = 1;
            this.updateBungee.Text = "Update Bungee";
            this.updateBungee.UseVisualStyleBackColor = true;
            this.updateBungee.Click += new System.EventHandler(this.updateBungee_Click);
            // 
            // addServer
            // 
            this.addServer.Location = new System.Drawing.Point(7, 384);
            this.addServer.Name = "addServer";
            this.addServer.Size = new System.Drawing.Size(170, 23);
            this.addServer.TabIndex = 0;
            this.addServer.Text = "Add Server";
            this.addServer.UseVisualStyleBackColor = true;
            this.addServer.Click += new System.EventHandler(this.addServer_Click);
            // 
            // bungeeGroup
            // 
            this.bungeeGroup.Controls.Add(this.bungeeOutput);
            this.bungeeGroup.Controls.Add(this.bungeeRunCMD);
            this.bungeeGroup.Controls.Add(this.command);
            this.bungeeGroup.Controls.Add(this.optionsBox);
            this.bungeeGroup.Controls.Add(this.startStopBungee);
            this.bungeeGroup.Location = new System.Drawing.Point(203, 13);
            this.bungeeGroup.Name = "bungeeGroup";
            this.bungeeGroup.Size = new System.Drawing.Size(758, 413);
            this.bungeeGroup.TabIndex = 1;
            this.bungeeGroup.TabStop = false;
            this.bungeeGroup.Text = "Bungee";
            // 
            // bungeeOutput
            // 
            this.bungeeOutput.BackColor = System.Drawing.Color.White;
            this.bungeeOutput.Font = new System.Drawing.Font("Courier New", 9F);
            this.bungeeOutput.Location = new System.Drawing.Point(7, 78);
            this.bungeeOutput.Name = "bungeeOutput";
            this.bungeeOutput.ReadOnly = true;
            this.bungeeOutput.Size = new System.Drawing.Size(542, 303);
            this.bungeeOutput.TabIndex = 5;
            this.bungeeOutput.Text = "";
            // 
            // bungeeRunCMD
            // 
            this.bungeeRunCMD.Location = new System.Drawing.Point(412, 387);
            this.bungeeRunCMD.Name = "bungeeRunCMD";
            this.bungeeRunCMD.Size = new System.Drawing.Size(137, 20);
            this.bungeeRunCMD.TabIndex = 4;
            this.bungeeRunCMD.Text = "Send";
            this.bungeeRunCMD.UseVisualStyleBackColor = true;
            this.bungeeRunCMD.Click += new System.EventHandler(this.bungeeRunCMD_Click);
            // 
            // command
            // 
            this.command.Location = new System.Drawing.Point(6, 387);
            this.command.Name = "command";
            this.command.Size = new System.Drawing.Size(400, 20);
            this.command.TabIndex = 3;
            this.command.KeyDown += new System.Windows.Forms.KeyEventHandler(this.command_KeyDown);
            // 
            // optionsBox
            // 
            this.optionsBox.Controls.Add(this.options);
            this.optionsBox.Enabled = false;
            this.optionsBox.Location = new System.Drawing.Point(556, 20);
            this.optionsBox.Name = "optionsBox";
            this.optionsBox.Size = new System.Drawing.Size(196, 387);
            this.optionsBox.TabIndex = 2;
            this.optionsBox.TabStop = false;
            this.optionsBox.Text = "Options";
            // 
            // options
            // 
            this.options.AutoScroll = true;
            this.options.Controls.Add(this.bungeeRAM);
            this.options.Controls.Add(this.bungeePort);
            this.options.Controls.Add(this.serverPort);
            this.options.Controls.Add(this.label2);
            this.options.Location = new System.Drawing.Point(7, 20);
            this.options.Name = "options";
            this.options.Size = new System.Drawing.Size(183, 361);
            this.options.TabIndex = 0;
            this.options.Paint += new System.Windows.Forms.PaintEventHandler(this.options_Paint);
            // 
            // bungeeRAM
            // 
            this.bungeeRAM.Location = new System.Drawing.Point(3, 20);
            this.bungeeRAM.Maximum = new decimal(new int[] {
            8192,
            0,
            0,
            0});
            this.bungeeRAM.Minimum = new decimal(new int[] {
            512,
            0,
            0,
            0});
            this.bungeeRAM.Name = "bungeeRAM";
            this.bungeeRAM.Size = new System.Drawing.Size(177, 20);
            this.bungeeRAM.TabIndex = 4;
            this.bungeeRAM.Value = new decimal(new int[] {
            512,
            0,
            0,
            0});
            // 
            // bungeePort
            // 
            this.bungeePort.Location = new System.Drawing.Point(3, 60);
            this.bungeePort.Maximum = new decimal(new int[] {
            29999,
            0,
            0,
            0});
            this.bungeePort.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.bungeePort.Name = "bungeePort";
            this.bungeePort.Size = new System.Drawing.Size(177, 20);
            this.bungeePort.TabIndex = 3;
            this.bungeePort.Value = new decimal(new int[] {
            25577,
            0,
            0,
            0});
            // 
            // serverPort
            // 
            this.serverPort.AutoSize = true;
            this.serverPort.Location = new System.Drawing.Point(4, 44);
            this.serverPort.Name = "serverPort";
            this.serverPort.Size = new System.Drawing.Size(136, 13);
            this.serverPort.TabIndex = 2;
            this.serverPort.Text = "Server Port (Default 25577)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Server RAM (in Megabytes)";
            // 
            // startStopBungee
            // 
            this.startStopBungee.Enabled = false;
            this.startStopBungee.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startStopBungee.Location = new System.Drawing.Point(7, 20);
            this.startStopBungee.Name = "startStopBungee";
            this.startStopBungee.Size = new System.Drawing.Size(542, 55);
            this.startStopBungee.TabIndex = 0;
            this.startStopBungee.Text = "Start";
            this.startStopBungee.UseVisualStyleBackColor = true;
            this.startStopBungee.Click += new System.EventHandler(this.startStopBungee_Click);
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(973, 438);
            this.Controls.Add(this.bungeeGroup);
            this.Controls.Add(this.currentServers);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(989, 477);
            this.Name = "Home";
            this.Text = "Minecraft Server";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.home_Close);
            this.Load += new System.EventHandler(this.home_Load);
            this.currentServers.ResumeLayout(false);
            this.currentServers.PerformLayout();
            this.bungeeGroup.ResumeLayout(false);
            this.bungeeGroup.PerformLayout();
            this.optionsBox.ResumeLayout(false);
            this.options.ResumeLayout(false);
            this.options.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bungeeRAM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bungeePort)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox currentServers;
        private System.Windows.Forms.Button addServer;
        private System.Windows.Forms.Button updateBungee;
        private System.Windows.Forms.ListBox serverList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox bungeeGroup;
        private System.Windows.Forms.Button startStopBungee;
        private System.Windows.Forms.GroupBox optionsBox;
        private System.Windows.Forms.Panel options;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label serverPort;
        private System.Windows.Forms.NumericUpDown bungeePort;
        private System.Windows.Forms.NumericUpDown bungeeRAM;
        private System.Windows.Forms.Button bungeeRunCMD;
        private System.Windows.Forms.TextBox command;
        private System.Windows.Forms.RichTextBox bungeeOutput;
    }
}

