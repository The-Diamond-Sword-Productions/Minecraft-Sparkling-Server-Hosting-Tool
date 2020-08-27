namespace Minecraft_Sparkling_Server_Hosting_Tool
{
    partial class ServerCompatibleForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ServerCompatibleForm));
            this.label1 = new System.Windows.Forms.Label();
            this.Client = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.StatusLabel = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.ServerLocationLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Version = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(30, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(235, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Is your server Vanilla, or Spigot?";
            // 
            // Client
            // 
            this.Client.BackColor = System.Drawing.Color.LightGray;
            this.Client.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Client.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Client.FormattingEnabled = true;
            this.Client.Items.AddRange(new object[] {
            "Vanilla (Normal Minecraft)",
            "Spigot (Plugins)"});
            this.Client.Location = new System.Drawing.Point(321, 58);
            this.Client.Name = "Client";
            this.Client.Size = new System.Drawing.Size(168, 21);
            this.Client.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 228);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Status: ";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(205, 161);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Ok";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // StatusLabel
            // 
            this.StatusLabel.AutoSize = true;
            this.StatusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StatusLabel.Location = new System.Drawing.Point(61, 226);
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(30, 16);
            this.StatusLabel.TabIndex = 4;
            this.StatusLabel.Text = "Idle";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(330, 161);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 294);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Server location: ";
            // 
            // ServerLocationLabel
            // 
            this.ServerLocationLabel.AutoSize = true;
            this.ServerLocationLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ServerLocationLabel.Location = new System.Drawing.Point(90, 294);
            this.ServerLocationLabel.Name = "ServerLocationLabel";
            this.ServerLocationLabel.Size = new System.Drawing.Size(41, 13);
            this.ServerLocationLabel.TabIndex = 7;
            this.ServerLocationLabel.Text = "label4";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(30, 95);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(285, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "What version is your server running on?";
            // 
            // Version
            // 
            this.Version.BackColor = System.Drawing.Color.LightGray;
            this.Version.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Version.Location = new System.Drawing.Point(321, 95);
            this.Version.Name = "Version";
            this.Version.Size = new System.Drawing.Size(168, 20);
            this.Version.TabIndex = 9;
            // 
            // ServerCompatibleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(584, 316);
            this.Controls.Add(this.Version);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ServerLocationLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.StatusLabel);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Client);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ServerCompatibleForm";
            this.Text = "Make your server compatible with our tool";
            this.Load += new System.EventHandler(this.ServerCompatibleForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox Client;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label StatusLabel;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label ServerLocationLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox Version;
    }
}