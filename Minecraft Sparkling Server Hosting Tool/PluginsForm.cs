using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minecraft_Sparkling_Server_Hosting_Tool
{
    public partial class PluginsForm : Form
    {
        private MainForm main;
        public PluginsForm(MainForm main)
        {
            InitializeComponent();

            this.main = main;
            serverPath.Text = main.ServerDirectory;
        }

        private void PluginsForm_Load(object sender, EventArgs e)
        {
            pluginPath.Text = "None";
            drag_drop.DragEnter += drag_drop_DragEnter;
            drag_drop.DragDrop += drag_drop_DragDrop;
        }
        private void drag_drop_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] filePaths = (string[])e.Data.GetData(DataFormats.FileDrop, false);
                pluginPath.Text = filePaths[0];
                FileAttributes attr = File.GetAttributes(pluginPath.Text);
                if ((attr & FileAttributes.Directory) == FileAttributes.Directory)
                {
                    pluginPath.Text = "";
                    MessageBox.Show("The Draged item is not a file. It's a folder. Please drag a folder, not a file.", "Error: Wrong item", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (Directory.Exists(serverPath.Text + @"\Plugins"))
                    {
                        File.Move(pluginPath.Text, serverPath.Text + @"\Plugins");
                    }
                    else
                    {
                        Directory.CreateDirectory(serverPath.Text + @"\Plugins");
                        File.Move(pluginPath.Text, serverPath.Text + @"\Plugins");
                    }
                }
            }
        }
        private void drag_drop_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }
    }
}
