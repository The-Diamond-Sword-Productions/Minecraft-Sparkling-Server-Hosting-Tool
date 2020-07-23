namespace Minecraft_Sparkling_Server_Hosting_Tool
{
    partial class OpsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OpsForm));
            this.label1 = new System.Windows.Forms.Label();
            this.usernameTextBox = new System.Windows.Forms.TextBox();
            this.addPlayerButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.oppedPlayerListBox = new System.Windows.Forms.ListBox();
            this.deletePlayerButton = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.opTextBox = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.statusLabel = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            this.serverPathLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(57, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(437, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "To add an opped player on your server, type his username here and click the \"Add\"" +
    " button:";
            // 
            // usernameTextBox
            // 
            this.usernameTextBox.Location = new System.Drawing.Point(60, 42);
            this.usernameTextBox.Name = "usernameTextBox";
            this.usernameTextBox.Size = new System.Drawing.Size(388, 20);
            this.usernameTextBox.TabIndex = 3;
            // 
            // addPlayerButton
            // 
            this.addPlayerButton.Location = new System.Drawing.Point(454, 40);
            this.addPlayerButton.Name = "addPlayerButton";
            this.addPlayerButton.Size = new System.Drawing.Size(75, 23);
            this.addPlayerButton.TabIndex = 4;
            this.addPlayerButton.Text = "Add";
            this.addPlayerButton.UseVisualStyleBackColor = true;
            this.addPlayerButton.Click += new System.EventHandler(this.addPlayerButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(57, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Server op list:";
            // 
            // oppedPlayerListBox
            // 
            this.oppedPlayerListBox.FormattingEnabled = true;
            this.oppedPlayerListBox.Location = new System.Drawing.Point(60, 107);
            this.oppedPlayerListBox.Name = "oppedPlayerListBox";
            this.oppedPlayerListBox.Size = new System.Drawing.Size(469, 69);
            this.oppedPlayerListBox.TabIndex = 6;
            // 
            // deletePlayerButton
            // 
            this.deletePlayerButton.Location = new System.Drawing.Point(535, 127);
            this.deletePlayerButton.Name = "deletePlayerButton";
            this.deletePlayerButton.Size = new System.Drawing.Size(48, 23);
            this.deletePlayerButton.TabIndex = 29;
            this.deletePlayerButton.Text = "Delete";
            this.deletePlayerButton.UseVisualStyleBackColor = true;
            this.deletePlayerButton.Click += new System.EventHandler(this.deletePlayerButton_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(56, 185);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 13);
            this.label7.TabIndex = 31;
            this.label7.Text = "Server ops text file :";
            // 
            // opTextBox
            // 
            this.opTextBox.Location = new System.Drawing.Point(59, 211);
            this.opTextBox.Name = "opTextBox";
            this.opTextBox.Size = new System.Drawing.Size(469, 55);
            this.opTextBox.TabIndex = 32;
            this.opTextBox.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 281);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 13);
            this.label3.TabIndex = 33;
            this.label3.Text = "Server location:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 303);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 34;
            this.label5.Text = "Status:";
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusLabel.Location = new System.Drawing.Point(58, 303);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(24, 13);
            this.statusLabel.TabIndex = 35;
            this.statusLabel.Text = "Idle";
            // 
            // saveButton
            // 
            this.saveButton.ForeColor = System.Drawing.Color.Red;
            this.saveButton.Location = new System.Drawing.Point(454, 281);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 36;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // serverPathLabel
            // 
            this.serverPathLabel.AutoSize = true;
            this.serverPathLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.serverPathLabel.Location = new System.Drawing.Point(94, 282);
            this.serverPathLabel.Name = "serverPathLabel";
            this.serverPathLabel.Size = new System.Drawing.Size(41, 13);
            this.serverPathLabel.TabIndex = 37;
            this.serverPathLabel.Text = "label4";
            // 
            // OpsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 328);
            this.Controls.Add(this.serverPathLabel);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.opTextBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.deletePlayerButton);
            this.Controls.Add(this.oppedPlayerListBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.addPlayerButton);
            this.Controls.Add(this.usernameTextBox);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "OpsForm";
            this.Text = "Server Ops";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox usernameTextBox;
        private System.Windows.Forms.Button addPlayerButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox oppedPlayerListBox;
        private System.Windows.Forms.Button deletePlayerButton;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RichTextBox opTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Label serverPathLabel;
    }
}