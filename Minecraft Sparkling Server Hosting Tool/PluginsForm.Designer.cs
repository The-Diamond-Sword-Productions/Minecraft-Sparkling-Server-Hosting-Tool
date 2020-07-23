namespace Minecraft_Sparkling_Server_Hosting_Tool
{
    partial class PluginsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PluginsForm));
            this.drag_drop = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pluginPath = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.serverPath = new System.Windows.Forms.Label();
            this.drag_drop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // drag_drop
            // 
            this.drag_drop.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.drag_drop.Controls.Add(this.label1);
            this.drag_drop.Controls.Add(this.pictureBox1);
            this.drag_drop.Location = new System.Drawing.Point(12, 159);
            this.drag_drop.Name = "drag_drop";
            this.drag_drop.Size = new System.Drawing.Size(560, 121);
            this.drag_drop.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(196, 98);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(189, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Drag and Drop here or Click to Browse";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pictureBox1.Image = global::Minecraft_Sparkling_Server_Hosting_Tool.Properties.Resources.drag_and_drop;
            this.pictureBox1.Location = new System.Drawing.Point(242, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 76);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 283);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Latest installed plugin:";
            // 
            // pluginPath
            // 
            this.pluginPath.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.pluginPath.AutoSize = true;
            this.pluginPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pluginPath.Location = new System.Drawing.Point(126, 283);
            this.pluginPath.Name = "pluginPath";
            this.pluginPath.Size = new System.Drawing.Size(67, 13);
            this.pluginPath.TabIndex = 2;
            this.pluginPath.Text = "pluginPath";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 300);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Server Path: ";
            // 
            // serverPath
            // 
            this.serverPath.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.serverPath.AutoSize = true;
            this.serverPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.serverPath.Location = new System.Drawing.Point(84, 300);
            this.serverPath.Name = "serverPath";
            this.serverPath.Size = new System.Drawing.Size(68, 13);
            this.serverPath.TabIndex = 4;
            this.serverPath.Text = "serverPath";
            // 
            // PluginsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 316);
            this.Controls.Add(this.serverPath);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pluginPath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.drag_drop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PluginsForm";
            this.Text = "Plugins";
            this.Load += new System.EventHandler(this.PluginsForm_Load);
            this.drag_drop.ResumeLayout(false);
            this.drag_drop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel drag_drop;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label pluginPath;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label serverPath;
    }
}