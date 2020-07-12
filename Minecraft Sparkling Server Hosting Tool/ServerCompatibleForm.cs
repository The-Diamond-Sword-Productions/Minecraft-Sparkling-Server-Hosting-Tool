using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minecraft_Sparkling_Server_Hosting_Tool
{
    public partial class ServerCompatibleForm : Form
    {
        private MainForm main;
        public ServerCompatibleForm(MainForm main)
        {
            InitializeComponent();

            this.main = main;
            ServerLocationLabel.Text = main.ServerDirectory;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Client.Text == "Vanilla (Normal Minecraft)")
            {
                StatusLabel.Text = "Generating Vanilla.txt file...";
                File.Create(main.ServerDirectory + @"\Vanilla.txt");
            }
            else if (Client.Text == "Spigot (Plugins)")
            {
                StatusLabel.Text = "Generating Spigot.txt file...";
                File.Create(main.ServerDirectory + @"\Spigot.txt");
            }
            else
            {
                MessageBox.Show("Unvalid Argument.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            File.Create(main.ServerDirectory + @"\tempserver.properties");
            MessageBox.Show("Your server is now compatible with our tool!", "Done", MessageBoxButtons.OK, MessageBoxIcon.None);
            this.Close();
        }
    }
}
