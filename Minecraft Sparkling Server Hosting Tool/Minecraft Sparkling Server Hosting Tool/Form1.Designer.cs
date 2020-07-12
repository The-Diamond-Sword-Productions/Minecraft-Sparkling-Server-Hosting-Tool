namespace Minecraft_Sparkling_Server_Hosting_Tool
{
    partial class Menu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menu));
            this.checkUpdates = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.nogui = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.memory = new System.Windows.Forms.Label();
            this.memo = new System.Windows.Forms.TextBox();
            this.bat = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.version = new System.Windows.Forms.ComboBox();
            this.button5 = new System.Windows.Forms.Button();
            this.serverinstallpath = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.progress = new System.Windows.Forms.GroupBox();
            this.pbar = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.button7 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.serverpath = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.Client_Version = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pause = new System.Windows.Forms.CheckBox();
            this.button6 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.progress.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // checkUpdates
            // 
            this.checkUpdates.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.checkUpdates.Location = new System.Drawing.Point(6, 6);
            this.checkUpdates.Name = "checkUpdates";
            this.checkUpdates.Size = new System.Drawing.Size(515, 38);
            this.checkUpdates.TabIndex = 0;
            this.checkUpdates.Text = "Check for updates";
            this.checkUpdates.UseVisualStyleBackColor = true;
            this.checkUpdates.Click += new System.EventHandler(this.CheckUpdates_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(535, 267);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.comboBox1);
            this.tabPage1.Controls.Add(this.label10);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.nogui);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.memory);
            this.tabPage1.Controls.Add(this.memo);
            this.tabPage1.Controls.Add(this.bat);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.version);
            this.tabPage1.Controls.Add(this.button5);
            this.tabPage1.Controls.Add(this.serverinstallpath);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.progress);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(527, 241);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Installation";
            this.tabPage1.ToolTipText = "Install your server here.";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Vanilla",
            "Spigot"});
            this.comboBox1.Location = new System.Drawing.Point(172, 81);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(70, 21);
            this.comboBox1.TabIndex = 22;
            this.comboBox1.Text = "Vanilla";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(130, 84);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 15);
            this.label10.TabIndex = 21;
            this.label10.Text = "Client:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label8.Location = new System.Drawing.Point(74, 135);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(480, 15);
            this.label8.TabIndex = 20;
            this.label8.Text = "ATTENTION: We would not change this value! The recommended option is  unchecked.";
            // 
            // nogui
            // 
            this.nogui.AutoSize = true;
            this.nogui.Location = new System.Drawing.Point(6, 134);
            this.nogui.Name = "nogui";
            this.nogui.Size = new System.Drawing.Size(69, 19);
            this.nogui.TabIndex = 19;
            this.nogui.Text = "No GUI";
            this.nogui.UseVisualStyleBackColor = true;
            this.nogui.CheckedChanged += new System.EventHandler(this.Nogui_CheckedChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(492, 109);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(26, 15);
            this.label7.TabIndex = 18;
            this.label7.Text = "MB";
            // 
            // memory
            // 
            this.memory.AutoSize = true;
            this.memory.Location = new System.Drawing.Point(235, 109);
            this.memory.Name = "memory";
            this.memory.Size = new System.Drawing.Size(103, 15);
            this.memory.TabIndex = 17;
            this.memory.Text = "Memory for Java :";
            // 
            // memo
            // 
            this.memo.Location = new System.Drawing.Point(332, 105);
            this.memo.Name = "memo";
            this.memo.Size = new System.Drawing.Size(154, 20);
            this.memo.TabIndex = 16;
            this.memo.Text = "1024\r\n";
            // 
            // bat
            // 
            this.bat.AutoSize = true;
            this.bat.Checked = true;
            this.bat.CheckState = System.Windows.Forms.CheckState.Checked;
            this.bat.Location = new System.Drawing.Point(6, 108);
            this.bat.Name = "bat";
            this.bat.Size = new System.Drawing.Size(122, 19);
            this.bat.TabIndex = 15;
            this.bat.Text = "Generate .bat file";
            this.bat.UseVisualStyleBackColor = true;
            this.bat.CheckedChanged += new System.EventHandler(this.Bat_CheckedChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 84);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 15);
            this.label6.TabIndex = 14;
            this.label6.Text = "Version:";
            // 
            // version
            // 
            this.version.FormattingEnabled = true;
            this.version.Items.AddRange(new object[] {
            "1.16.1",
            "1.16",
            "1.15.2",
            "1.15.1",
            "1.15",
            "1.14.4",
            "1.14.3",
            "1.14.2",
            "1.14.1",
            "1.14",
            "1.13.2",
            "1.13.1",
            "1.13",
            "1.12.2",
            "1.12.1",
            "1.12",
            "1.11.2",
            "1.11.1",
            "1.11",
            "1.10.2",
            "1.10.1",
            "1.10",
            "1.9.4",
            "1.9.3",
            "1.9.2",
            "1.9.1",
            "1.9",
            "1.8.9",
            "1.8",
            "1.7.10"});
            this.version.Location = new System.Drawing.Point(54, 81);
            this.version.Name = "version";
            this.version.Size = new System.Drawing.Size(70, 21);
            this.version.TabIndex = 13;
            this.version.Text = "1.16.1";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(438, 55);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(83, 20);
            this.button5.TabIndex = 12;
            this.button5.Text = "Browse...";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.Button5_Click_1);
            // 
            // serverinstallpath
            // 
            this.serverinstallpath.Location = new System.Drawing.Point(3, 55);
            this.serverinstallpath.Name = "serverinstallpath";
            this.serverinstallpath.Size = new System.Drawing.Size(429, 20);
            this.serverinstallpath.TabIndex = 11;
            this.serverinstallpath.Text = "C:/Documents/MinecraftServer";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(0, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(134, 15);
            this.label4.TabIndex = 10;
            this.label4.Text = "Server installation path:";
            // 
            // progress
            // 
            this.progress.Controls.Add(this.pbar);
            this.progress.Controls.Add(this.label1);
            this.progress.Controls.Add(this.label12);
            this.progress.Location = new System.Drawing.Point(6, 164);
            this.progress.Name = "progress";
            this.progress.Size = new System.Drawing.Size(515, 71);
            this.progress.TabIndex = 3;
            this.progress.TabStop = false;
            this.progress.Text = "Progress";
            // 
            // pbar
            // 
            this.pbar.Location = new System.Drawing.Point(9, 19);
            this.pbar.Name = "pbar";
            this.pbar.Size = new System.Drawing.Size(500, 23);
            this.pbar.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "Status:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(45, 45);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(27, 15);
            this.label12.TabIndex = 3;
            this.label12.Text = "Idle";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button1.Location = new System.Drawing.Point(3, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(518, 28);
            this.button1.TabIndex = 1;
            this.button1.Text = "Click here to  install a server on your computer";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.button7);
            this.tabPage2.Controls.Add(this.button4);
            this.tabPage2.Controls.Add(this.serverpath);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.button3);
            this.tabPage2.Controls.Add(this.button2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(527, 241);
            this.tabPage2.TabIndex = 2;
            this.tabPage2.Text = "Server run";
            this.tabPage2.ToolTipText = "Only availible if you have your server installed!";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(6, 100);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(121, 23);
            this.button7.TabIndex = 7;
            this.button7.Text = "Find Installed Server";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(441, 74);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(83, 20);
            this.button4.TabIndex = 6;
            this.button4.Text = "Browse...";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.Button4_Click);
            // 
            // serverpath
            // 
            this.serverpath.Location = new System.Drawing.Point(6, 74);
            this.serverpath.Name = "serverpath";
            this.serverpath.Size = new System.Drawing.Size(429, 20);
            this.serverpath.TabIndex = 5;
            this.serverpath.Text = "C:/Documents/MinecraftServer";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "Server path:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Maroon;
            this.label2.Location = new System.Drawing.Point(66, 218);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(438, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Warning: If you can\'t press the buttons, make sure you have your server installed" +
    "";
            // 
            // button3
            // 
            this.button3.Enabled = false;
            this.button3.Location = new System.Drawing.Point(3, 32);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(521, 23);
            this.button3.TabIndex = 1;
            this.button3.Text = "Open server properties";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(3, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(521, 23);
            this.button2.TabIndex = 0;
            this.button2.Text = "Run server";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.Client_Version);
            this.tabPage3.Controls.Add(this.label9);
            this.tabPage3.Controls.Add(this.groupBox1);
            this.tabPage3.Controls.Add(this.button6);
            this.tabPage3.Controls.Add(this.label5);
            this.tabPage3.Controls.Add(this.linkLabel1);
            this.tabPage3.Controls.Add(this.checkUpdates);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(527, 241);
            this.tabPage3.TabIndex = 1;
            this.tabPage3.Text = "Settings";
            this.tabPage3.ToolTipText = "Change installation point and other.";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // Client_Version
            // 
            this.Client_Version.AutoSize = true;
            this.Client_Version.Location = new System.Drawing.Point(87, 47);
            this.Client_Version.Name = "Client_Version";
            this.Client_Version.Size = new System.Drawing.Size(34, 15);
            this.Client_Version.TabIndex = 15;
            this.Client_Version.Text = "0.3.3";
            this.Client_Version.Click += new System.EventHandler(this.Client_Version_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 47);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(92, 15);
            this.label9.TabIndex = 14;
            this.label9.Text = "Current version:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pause);
            this.groupBox1.Location = new System.Drawing.Point(9, 148);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(512, 48);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Debug";
            // 
            // pause
            // 
            this.pause.AutoSize = true;
            this.pause.Checked = true;
            this.pause.CheckState = System.Windows.Forms.CheckState.Checked;
            this.pause.Location = new System.Drawing.Point(7, 20);
            this.pause.Name = "pause";
            this.pause.Size = new System.Drawing.Size(153, 19);
            this.pause.TabIndex = 0;
            this.pause.Text = "PAUSE on jar exeption";
            this.pause.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            this.button6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button6.Location = new System.Drawing.Point(432, 202);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(89, 32);
            this.button6.TabIndex = 12;
            this.button6.Text = "Licence";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.Button6_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 202);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(162, 15);
            this.label5.TabIndex = 11;
            this.label5.Text = "Got a question? Ask us here:";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(6, 215);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(185, 15);
            this.linkLabel1.TabIndex = 10;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "www.discord.me/tds-productions";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabel1_LinkClicked);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.InitialDirectory = "C:/";
            this.openFileDialog1.ValidateNames = false;
            // 
            // Menu
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(559, 291);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Menu";
            this.Text = "Minecraft Sparkling Server Hosting Tool";
            this.Load += new System.EventHandler(this.Menu_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.progress.ResumeLayout(false);
            this.progress.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button checkUpdates;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox progress;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox serverpath;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.TextBox serverinstallpath;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox version;
        private System.Windows.Forms.Label label1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ProgressBar pbar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox pause;
        private System.Windows.Forms.CheckBox bat;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label memory;
        private System.Windows.Forms.TextBox memo;
        private System.Windows.Forms.CheckBox nogui;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label Client_Version;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label10;
    }
}

