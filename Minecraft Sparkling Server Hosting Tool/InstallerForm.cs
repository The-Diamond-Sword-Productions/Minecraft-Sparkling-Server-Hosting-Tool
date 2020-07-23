using System;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Threading;

namespace Minecraft_Sparkling_Server_Hosting_Tool
{
    public partial class Installer : Form
    {
        public Installer()
        {
            InitializeComponent();
        }

        private void Installer_Load(object sender, EventArgs e)
        {
            if (!Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + "\\MSSHT\\"))
            {
                DialogResult Installer = MessageBox.Show("Looks like you haven't installed Minecraft Sparkling Server Hosting Tool yet. \n Would you like to install it? \n\n If this is an error, make sure you haven't touched the : " + Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + " \\MSSHT\\  path.", "Installer", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (Installer == DialogResult.Yes)
                {//Open Installer
                }//--------------
                else
                {
                    MessageBox.Show("Closing Minecraft Sparkling Server Hostring Tool", "Closing...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    System.Environment.Exit(0);
                }
            }
            else
            {
                this.Visible = false;
                MainForm frm = new MainForm();
                frm.Show();
            }
            Info.Text = Info.Text + Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + "\\MSSHT\\ .";
        }

        private void button1_Click(object sender, EventArgs e)//Cancel
        {
            MessageBox.Show("Closing Minecraft Sparkling Server Hostring Tool", "Closing...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            System.Environment.Exit(0);
        }

        private void button2_Click(object sender, EventArgs e)//Install
        {

        }
    }
}
