using System;
using System.IO;

namespace Minecraft_Sparkling_Server_Hosting_Tool
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.checkUpdates = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.memoryMBRadio = new System.Windows.Forms.RadioButton();
            this.memoryGBRadio = new System.Windows.Forms.RadioButton();
            this.memoryDropdown = new System.Windows.Forms.ComboBox();
            this.clientDropdown = new System.Windows.Forms.ComboBox();
            this.clientLabel = new System.Windows.Forms.Label();
            this.noguiWarningLabel = new System.Windows.Forms.Label();
            this.noguiCheckbox = new System.Windows.Forms.CheckBox();
            this.memoryLabel = new System.Windows.Forms.Label();
            this.generateBatCheckbox = new System.Windows.Forms.CheckBox();
            this.versionLabel = new System.Windows.Forms.Label();
            this.versionDropdown = new System.Windows.Forms.ComboBox();
            this.serverPathBrowseButton = new System.Windows.Forms.Button();
            this.serverInstallPathTextBox = new System.Windows.Forms.TextBox();
            this.serverInstallPathLabel = new System.Windows.Forms.Label();
            this.progressGroupBox = new System.Windows.Forms.GroupBox();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.serverInstallButton = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label13 = new System.Windows.Forms.Label();
            this.Status_ = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.eulaRejectButton = new System.Windows.Forms.Button();
            this.eulaAcceptButton = new System.Windows.Forms.Button();
            this.eulaOkButton = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.serverRunPathTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.startStopServerButton = new System.Windows.Forms.Button();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.label18 = new System.Windows.Forms.Label();
            this.button15 = new System.Windows.Forms.Button();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.Status = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.linkLabel4 = new System.Windows.Forms.LinkLabel();
            this.button14 = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.linkLabel3 = new System.Windows.Forms.LinkLabel();
            this.button13 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.Client_Version = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pause = new System.Windows.Forms.CheckBox();
            this.button6 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.progressGroupBox.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // checkUpdates
            // 
            this.checkUpdates.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.checkUpdates.Location = new System.Drawing.Point(6, 6);
            this.checkUpdates.Name = "checkUpdates";
            this.checkUpdates.Size = new System.Drawing.Size(559, 38);
            this.checkUpdates.TabIndex = 0;
            this.checkUpdates.Text = "Check for updates";
            this.checkUpdates.UseVisualStyleBackColor = true;
            this.checkUpdates.Click += new System.EventHandler(this.CheckUpdates_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tabControl1.Location = new System.Drawing.Point(3, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(579, 313);
            this.tabControl1.TabIndex = 3;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.memoryMBRadio);
            this.tabPage1.Controls.Add(this.memoryGBRadio);
            this.tabPage1.Controls.Add(this.memoryDropdown);
            this.tabPage1.Controls.Add(this.clientDropdown);
            this.tabPage1.Controls.Add(this.clientLabel);
            this.tabPage1.Controls.Add(this.noguiWarningLabel);
            this.tabPage1.Controls.Add(this.noguiCheckbox);
            this.tabPage1.Controls.Add(this.memoryLabel);
            this.tabPage1.Controls.Add(this.generateBatCheckbox);
            this.tabPage1.Controls.Add(this.versionLabel);
            this.tabPage1.Controls.Add(this.versionDropdown);
            this.tabPage1.Controls.Add(this.serverPathBrowseButton);
            this.tabPage1.Controls.Add(this.serverInstallPathTextBox);
            this.tabPage1.Controls.Add(this.serverInstallPathLabel);
            this.tabPage1.Controls.Add(this.progressGroupBox);
            this.tabPage1.Controls.Add(this.serverInstallButton);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(571, 287);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Installation";
            this.tabPage1.ToolTipText = "Install your server here.";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // memoryMBRadio
            // 
            this.memoryMBRadio.AutoSize = true;
            this.memoryMBRadio.Checked = true;
            this.memoryMBRadio.Location = new System.Drawing.Point(522, 121);
            this.memoryMBRadio.Name = "memoryMBRadio";
            this.memoryMBRadio.Size = new System.Drawing.Size(41, 17);
            this.memoryMBRadio.TabIndex = 26;
            this.memoryMBRadio.TabStop = true;
            this.memoryMBRadio.Text = "MB";
            this.memoryMBRadio.UseVisualStyleBackColor = true;
            this.memoryMBRadio.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // memoryGBRadio
            // 
            this.memoryGBRadio.AutoSize = true;
            this.memoryGBRadio.Location = new System.Drawing.Point(522, 142);
            this.memoryGBRadio.Name = "memoryGBRadio";
            this.memoryGBRadio.Size = new System.Drawing.Size(40, 17);
            this.memoryGBRadio.TabIndex = 25;
            this.memoryGBRadio.Text = "GB";
            this.memoryGBRadio.UseVisualStyleBackColor = true;
            // 
            // memoryDropdown
            // 
            this.memoryDropdown.FormattingEnabled = true;
            this.memoryDropdown.Items.AddRange(new object[] {
            "512",
            "1024",
            "2048",
            "3072",
            "4096",
            "5120",
            "6144",
            "7168",
            "8192",
            "9216",
            "10240",
            "11264",
            "12288",
            "13312",
            "14336",
            "15360",
            "16384",
            "17408",
            "18432",
            "19456",
            "20480"});
            this.memoryDropdown.Location = new System.Drawing.Point(361, 130);
            this.memoryDropdown.Name = "memoryDropdown";
            this.memoryDropdown.Size = new System.Drawing.Size(154, 21);
            this.memoryDropdown.TabIndex = 23;
            this.memoryDropdown.Text = "1024";
            // 
            // clientDropdown
            // 
            this.clientDropdown.FormattingEnabled = true;
            this.clientDropdown.Items.AddRange(new object[] {
            "Vanilla (Normal Minecraft)",
            "Spigot (Plugins)"});
            this.clientDropdown.Location = new System.Drawing.Point(172, 93);
            this.clientDropdown.Name = "clientDropdown";
            this.clientDropdown.Size = new System.Drawing.Size(144, 21);
            this.clientDropdown.TabIndex = 22;
            this.clientDropdown.Text = "Vanilla (Normal Minecraft)";
            this.clientDropdown.SelectedIndexChanged += new System.EventHandler(this.client_SelectedIndexChanged);
            // 
            // clientLabel
            // 
            this.clientLabel.AutoSize = true;
            this.clientLabel.Location = new System.Drawing.Point(130, 96);
            this.clientLabel.Name = "clientLabel";
            this.clientLabel.Size = new System.Drawing.Size(36, 13);
            this.clientLabel.TabIndex = 21;
            this.clientLabel.Text = "Client:";
            // 
            // noguiWarningLabel
            // 
            this.noguiWarningLabel.AutoSize = true;
            this.noguiWarningLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.noguiWarningLabel.Location = new System.Drawing.Point(70, 168);
            this.noguiWarningLabel.Name = "noguiWarningLabel";
            this.noguiWarningLabel.Size = new System.Drawing.Size(428, 13);
            this.noguiWarningLabel.TabIndex = 20;
            this.noguiWarningLabel.Text = "ATTENTION: We would not change this value! The recommended option is  unchecked.";
            // 
            // noguiCheckbox
            // 
            this.noguiCheckbox.AutoSize = true;
            this.noguiCheckbox.Location = new System.Drawing.Point(6, 167);
            this.noguiCheckbox.Name = "noguiCheckbox";
            this.noguiCheckbox.Size = new System.Drawing.Size(62, 17);
            this.noguiCheckbox.TabIndex = 19;
            this.noguiCheckbox.Text = "No GUI";
            this.noguiCheckbox.UseVisualStyleBackColor = true;
            this.noguiCheckbox.CheckedChanged += new System.EventHandler(this.Nogui_CheckedChanged);
            // 
            // memoryLabel
            // 
            this.memoryLabel.AutoSize = true;
            this.memoryLabel.Location = new System.Drawing.Point(267, 134);
            this.memoryLabel.Name = "memoryLabel";
            this.memoryLabel.Size = new System.Drawing.Size(91, 13);
            this.memoryLabel.TabIndex = 17;
            this.memoryLabel.Text = "Memory for Java :";
            // 
            // generateBatCheckbox
            // 
            this.generateBatCheckbox.AutoSize = true;
            this.generateBatCheckbox.Checked = true;
            this.generateBatCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.generateBatCheckbox.Location = new System.Drawing.Point(6, 130);
            this.generateBatCheckbox.Name = "generateBatCheckbox";
            this.generateBatCheckbox.Size = new System.Drawing.Size(107, 17);
            this.generateBatCheckbox.TabIndex = 15;
            this.generateBatCheckbox.Text = "Generate .bat file";
            this.generateBatCheckbox.UseVisualStyleBackColor = true;
            this.generateBatCheckbox.CheckedChanged += new System.EventHandler(this.Bat_CheckedChanged);
            // 
            // versionLabel
            // 
            this.versionLabel.AutoSize = true;
            this.versionLabel.Location = new System.Drawing.Point(3, 97);
            this.versionLabel.Name = "versionLabel";
            this.versionLabel.Size = new System.Drawing.Size(45, 13);
            this.versionLabel.TabIndex = 14;
            this.versionLabel.Text = "Version:";
            // 
            // versionDropdown
            // 
            this.versionDropdown.FormattingEnabled = true;
            this.versionDropdown.Items.AddRange(new object[] {
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
            this.versionDropdown.Location = new System.Drawing.Point(54, 93);
            this.versionDropdown.Name = "versionDropdown";
            this.versionDropdown.Size = new System.Drawing.Size(70, 21);
            this.versionDropdown.TabIndex = 13;
            this.versionDropdown.Text = "1.16.1";
            // 
            // serverPathBrowseButton
            // 
            this.serverPathBrowseButton.Location = new System.Drawing.Point(477, 62);
            this.serverPathBrowseButton.Name = "serverPathBrowseButton";
            this.serverPathBrowseButton.Size = new System.Drawing.Size(83, 20);
            this.serverPathBrowseButton.TabIndex = 12;
            this.serverPathBrowseButton.Text = "Browse...";
            this.serverPathBrowseButton.UseVisualStyleBackColor = true;
            this.serverPathBrowseButton.Click += new System.EventHandler(this.Button5_Click_1);
            // 
            // serverInstallPathTextBox
            // 
            this.serverInstallPathTextBox.Location = new System.Drawing.Point(3, 61);
            this.serverInstallPathTextBox.Name = "serverInstallPathTextBox";
            this.serverInstallPathTextBox.Size = new System.Drawing.Size(468, 20);
            this.serverInstallPathTextBox.TabIndex = 11;
            this.serverInstallPathTextBox.TextChanged += new System.EventHandler(this.OnInstallPathChanged);
            // 
            // serverInstallPathLabel
            // 
            this.serverInstallPathLabel.AutoSize = true;
            this.serverInstallPathLabel.Location = new System.Drawing.Point(0, 45);
            this.serverInstallPathLabel.Name = "serverInstallPathLabel";
            this.serverInstallPathLabel.Size = new System.Drawing.Size(117, 13);
            this.serverInstallPathLabel.TabIndex = 10;
            this.serverInstallPathLabel.Text = "Server installation path:";
            // 
            // progressGroupBox
            // 
            this.progressGroupBox.Controls.Add(this.progressBar);
            this.progressGroupBox.Controls.Add(this.label1);
            this.progressGroupBox.Controls.Add(this.label12);
            this.progressGroupBox.Location = new System.Drawing.Point(6, 210);
            this.progressGroupBox.Name = "progressGroupBox";
            this.progressGroupBox.Size = new System.Drawing.Size(559, 71);
            this.progressGroupBox.TabIndex = 3;
            this.progressGroupBox.TabStop = false;
            this.progressGroupBox.Text = "Progress";
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(9, 19);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(544, 23);
            this.progressBar.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Status:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(45, 45);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(24, 13);
            this.label12.TabIndex = 3;
            this.label12.Text = "Idle";
            // 
            // serverInstallButton
            // 
            this.serverInstallButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.serverInstallButton.Location = new System.Drawing.Point(6, 7);
            this.serverInstallButton.Name = "serverInstallButton";
            this.serverInstallButton.Size = new System.Drawing.Size(557, 28);
            this.serverInstallButton.TabIndex = 1;
            this.serverInstallButton.Text = "Click here to  install a server on your computer";
            this.serverInstallButton.UseVisualStyleBackColor = true;
            this.serverInstallButton.Click += new System.EventHandler(this.OnInstallServerButtonClick);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label13);
            this.tabPage2.Controls.Add(this.Status_);
            this.tabPage2.Controls.Add(this.label14);
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Controls.Add(this.button4);
            this.tabPage2.Controls.Add(this.serverRunPathTextBox);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.startStopServerButton);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(571, 287);
            this.tabPage2.TabIndex = 2;
            this.tabPage2.Text = "Server Run";
            this.tabPage2.ToolTipText = "Only availible if you have your server installed!";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(5, 6);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(230, 13);
            this.label13.TabIndex = 18;
            this.label13.Text = "Please enter a server path to start your server...";
            // 
            // Status_
            // 
            this.Status_.AutoSize = true;
            this.Status_.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Status_.Location = new System.Drawing.Point(40, 269);
            this.Status_.Name = "Status_";
            this.Status_.Size = new System.Drawing.Size(24, 13);
            this.Status_.TabIndex = 17;
            this.Status_.Text = "Idle";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(3, 269);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(40, 13);
            this.label14.TabIndex = 16;
            this.label14.Text = "Status:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.linkLabel2);
            this.groupBox2.Controls.Add(this.eulaRejectButton);
            this.groupBox2.Controls.Add(this.eulaAcceptButton);
            this.groupBox2.Controls.Add(this.eulaOkButton);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Location = new System.Drawing.Point(25, 131);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(515, 112);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Location = new System.Drawing.Point(171, 39);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(161, 13);
            this.linkLabel2.TabIndex = 12;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "https://www.minecraft.net/eula/";
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // eulaRejectButton
            // 
            this.eulaRejectButton.Location = new System.Drawing.Point(372, 84);
            this.eulaRejectButton.Name = "eulaRejectButton";
            this.eulaRejectButton.Size = new System.Drawing.Size(75, 23);
            this.eulaRejectButton.TabIndex = 11;
            this.eulaRejectButton.Text = "Reject";
            this.eulaRejectButton.UseVisualStyleBackColor = true;
            this.eulaRejectButton.Click += new System.EventHandler(this.button10_Click);
            // 
            // eulaAcceptButton
            // 
            this.eulaAcceptButton.Location = new System.Drawing.Point(63, 84);
            this.eulaAcceptButton.Name = "eulaAcceptButton";
            this.eulaAcceptButton.Size = new System.Drawing.Size(75, 23);
            this.eulaAcceptButton.TabIndex = 10;
            this.eulaAcceptButton.Text = "Accept";
            this.eulaAcceptButton.UseVisualStyleBackColor = true;
            this.eulaAcceptButton.Click += new System.EventHandler(this.button9_Click);
            // 
            // eulaOkButton
            // 
            this.eulaOkButton.ForeColor = System.Drawing.Color.Black;
            this.eulaOkButton.Location = new System.Drawing.Point(212, 84);
            this.eulaOkButton.Name = "eulaOkButton";
            this.eulaOkButton.Size = new System.Drawing.Size(75, 23);
            this.eulaOkButton.TabIndex = 9;
            this.eulaOkButton.Text = "Ok";
            this.eulaOkButton.UseVisualStyleBackColor = true;
            this.eulaOkButton.Click += new System.EventHandler(this.button8_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(6, 12);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "MessageBox 2.0";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(481, 63);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(83, 20);
            this.button4.TabIndex = 6;
            this.button4.Text = "Browse...";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.OnInstallBrowseClick);
            // 
            // serverRunPathTextBox
            // 
            this.serverRunPathTextBox.Location = new System.Drawing.Point(6, 63);
            this.serverRunPathTextBox.Name = "serverRunPathTextBox";
            this.serverRunPathTextBox.Size = new System.Drawing.Size(466, 20);
            this.serverRunPathTextBox.TabIndex = 5;
            this.serverRunPathTextBox.TextChanged += new System.EventHandler(this.OnRunPathChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Server path:";
            // 
            // startStopServerButton
            // 
            this.startStopServerButton.ForeColor = System.Drawing.Color.Green;
            this.startStopServerButton.Location = new System.Drawing.Point(2, 22);
            this.startStopServerButton.Name = "startStopServerButton";
            this.startStopServerButton.Size = new System.Drawing.Size(561, 23);
            this.startStopServerButton.TabIndex = 0;
            this.startStopServerButton.Text = "Start Server";
            this.startStopServerButton.UseVisualStyleBackColor = true;
            this.startStopServerButton.Click += new System.EventHandler(this.Button2_Click);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.button1);
            this.tabPage4.Controls.Add(this.label18);
            this.tabPage4.Controls.Add(this.button15);
            this.tabPage4.Controls.Add(this.label17);
            this.tabPage4.Controls.Add(this.label16);
            this.tabPage4.Controls.Add(this.label15);
            this.tabPage4.Controls.Add(this.button3);
            this.tabPage4.Controls.Add(this.Status);
            this.tabPage4.Controls.Add(this.label11);
            this.tabPage4.Controls.Add(this.groupBox3);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(571, 287);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Server Options";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.ForeColor = System.Drawing.Color.Maroon;
            this.label18.Location = new System.Drawing.Point(92, 152);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(393, 26);
            this.label18.TabIndex = 22;
            this.label18.Text = "Warning: If you can\'t press the buttons, make sure you have your server installed" +
    ", \r\n         and that you have entered the right serverpath in the \"Server Run\" " +
    "tab";
            // 
            // button15
            // 
            this.button15.Enabled = false;
            this.button15.Location = new System.Drawing.Point(5, 82);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(561, 23);
            this.button15.TabIndex = 20;
            this.button15.Text = "Open Server whitelist";
            this.button15.UseVisualStyleBackColor = true;
            this.button15.Click += new System.EventHandler(this.button15_Click);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.Red;
            this.label17.Location = new System.Drawing.Point(403, 10);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(47, 13);
            this.label17.TabIndex = 19;
            this.label17.Text = "Stopped";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(330, 10);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(74, 13);
            this.label16.TabIndex = 18;
            this.label16.Text = "Server Status:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(9, 10);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(110, 13);
            this.label15.TabIndex = 17;
            this.label15.Text = "No server found...";
            // 
            // button3
            // 
            this.button3.Enabled = false;
            this.button3.Location = new System.Drawing.Point(6, 48);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(561, 23);
            this.button3.TabIndex = 16;
            this.button3.Text = "Open Server properties";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // Status
            // 
            this.Status.AutoSize = true;
            this.Status.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Status.Location = new System.Drawing.Point(40, 269);
            this.Status.Name = "Status";
            this.Status.Size = new System.Drawing.Size(24, 13);
            this.Status.TabIndex = 15;
            this.Status.Text = "Idle";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(3, 269);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(40, 13);
            this.label11.TabIndex = 14;
            this.label11.Text = "Status:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.linkLabel4);
            this.groupBox3.Controls.Add(this.button14);
            this.groupBox3.Location = new System.Drawing.Point(6, 185);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(559, 81);
            this.groupBox3.TabIndex = 13;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "For Spigot Servers";
            // 
            // linkLabel4
            // 
            this.linkLabel4.AutoSize = true;
            this.linkLabel4.Location = new System.Drawing.Point(208, 49);
            this.linkLabel4.Name = "linkLabel4";
            this.linkLabel4.Size = new System.Drawing.Size(138, 13);
            this.linkLabel4.TabIndex = 13;
            this.linkLabel4.TabStop = true;
            this.linkLabel4.Text = "Click here to install a plugin!";
            this.linkLabel4.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel4_LinkClicked);
            // 
            // button14
            // 
            this.button14.Enabled = false;
            this.button14.Location = new System.Drawing.Point(6, 23);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(547, 23);
            this.button14.TabIndex = 12;
            this.button14.Text = "Open Server Plugins File";
            this.button14.UseVisualStyleBackColor = true;
            this.button14.Click += new System.EventHandler(this.button14_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.linkLabel3);
            this.tabPage3.Controls.Add(this.button13);
            this.tabPage3.Controls.Add(this.button12);
            this.tabPage3.Controls.Add(this.button11);
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
            this.tabPage3.Size = new System.Drawing.Size(571, 287);
            this.tabPage3.TabIndex = 1;
            this.tabPage3.Text = "Settings";
            this.tabPage3.ToolTipText = "Change installation point and other.";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // linkLabel3
            // 
            this.linkLabel3.AutoSize = true;
            this.linkLabel3.Location = new System.Drawing.Point(128, 177);
            this.linkLabel3.Name = "linkLabel3";
            this.linkLabel3.Size = new System.Drawing.Size(307, 13);
            this.linkLabel3.TabIndex = 19;
            this.linkLabel3.TabStop = true;
            this.linkLabel3.Text = "Click here to access the official website: http://mssht.sytes.net/";
            this.linkLabel3.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel3_LinkClicked);
            // 
            // button13
            // 
            this.button13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button13.Location = new System.Drawing.Point(162, 107);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(244, 24);
            this.button13.TabIndex = 18;
            this.button13.Text = "Read our wiki! (maybe you can find help here)";
            this.button13.UseVisualStyleBackColor = true;
            this.button13.Click += new System.EventHandler(this.button13_Click);
            // 
            // button12
            // 
            this.button12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button12.Location = new System.Drawing.Point(375, 77);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(190, 24);
            this.button12.TabIndex = 17;
            this.button12.Text = "I need help / Report a bug";
            this.button12.UseVisualStyleBackColor = true;
            this.button12.Click += new System.EventHandler(this.button12_Click);
            // 
            // button11
            // 
            this.button11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button11.Location = new System.Drawing.Point(6, 77);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(190, 24);
            this.button11.TabIndex = 16;
            this.button11.Text = "Open Minecraft Server Tool GitHub";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // Client_Version
            // 
            this.Client_Version.AutoSize = true;
            this.Client_Version.Location = new System.Drawing.Point(307, 47);
            this.Client_Version.Name = "Client_Version";
            this.Client_Version.Size = new System.Drawing.Size(22, 13);
            this.Client_Version.TabIndex = 15;
            this.Client_Version.Text = "0.5";
            this.Client_Version.Click += new System.EventHandler(this.Client_Version_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(229, 47);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(81, 13);
            this.label9.TabIndex = 14;
            this.label9.Text = "Current version:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pause);
            this.groupBox1.Location = new System.Drawing.Point(9, 193);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(556, 48);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Debug";
            // 
            // pause
            // 
            this.pause.AutoSize = true;
            this.pause.Location = new System.Drawing.Point(7, 20);
            this.pause.Name = "pause";
            this.pause.Size = new System.Drawing.Size(134, 17);
            this.pause.TabIndex = 0;
            this.pause.Text = "PAUSE on jar exeption";
            this.pause.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            this.button6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button6.Location = new System.Drawing.Point(476, 247);
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
            this.label5.Location = new System.Drawing.Point(6, 253);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(144, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Got a question? Ask us here:";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(6, 267);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(162, 13);
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
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(5, 117);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(561, 23);
            this.button1.TabIndex = 23;
            this.button1.Text = "Open Server ops";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // MainForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 316);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Minecraft Sparkling Server Hosting Tool";
            this.Load += new System.EventHandler(this.Menu_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.progressGroupBox.ResumeLayout(false);
            this.progressGroupBox.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
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
        private System.Windows.Forms.GroupBox progressGroupBox;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button serverInstallButton;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button startStopServerButton;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox serverRunPathTextBox;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Button serverPathBrowseButton;
        private System.Windows.Forms.TextBox serverInstallPathTextBox;
        private System.Windows.Forms.Label serverInstallPathLabel;
        private System.Windows.Forms.Label versionLabel;
        private System.Windows.Forms.ComboBox versionDropdown;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox pause;
        private System.Windows.Forms.CheckBox generateBatCheckbox;
        private System.Windows.Forms.Label memoryLabel;
        private System.Windows.Forms.CheckBox noguiCheckbox;
        private System.Windows.Forms.Label noguiWarningLabel;
        private System.Windows.Forms.Label Client_Version;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox clientDropdown;
        private System.Windows.Forms.Label clientLabel;
        private System.Windows.Forms.RadioButton memoryMBRadio;
        private System.Windows.Forms.RadioButton memoryGBRadio;
        private System.Windows.Forms.ComboBox memoryDropdown;
        private System.Windows.Forms.Button eulaOkButton;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button eulaAcceptButton;
        private System.Windows.Forms.Button eulaRejectButton;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.LinkLabel linkLabel3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Label Status;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label Status_;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.LinkLabel linkLabel4;
        private System.Windows.Forms.Button button15;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Button button1;
    }
}

