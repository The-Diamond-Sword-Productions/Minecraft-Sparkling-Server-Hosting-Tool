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
using Microsoft.WindowsAPICodePack.Dialogs;
using System.Drawing;
using System.Security.Principal;

namespace Minecraft_Sparkling_Server_Hosting_Tool
{
    public partial class Installer : Form
    {
        public Installer()
        {
            InitializeComponent();

            if (!new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator))
            {
                MessageBox.Show("Administrator privileges are required for this application to function correctly. \n\nPlease re-open this program as Administrator.", "Invalid Privileges", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }

            this.Size = normalSize;

            progressLabel.Visible = false;
            progressBar.Visible = false;
        }

        bool installing = false;

        Size normalSize = new Size(483, 362);
        Size installingSize = new Size(483, 409);

        private void Installer_Load(object sender, EventArgs e)
        {
            installPathTextBox.Text = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + "\\MSSHT\\";

            if (!Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + "\\MSSHT\\"))
            {
                DialogResult Installer = MessageBox.Show("Looks like you haven't installed Minecraft Sparkling Server Hosting Tool yet. \n Would you like to install it? \n\n If this is an error, make sure you haven't touched the : " + Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + " \\MSSHT\\  path.", "Installer", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (Installer == DialogResult.Yes)
                {
                    //Open Installer
                    installing = true;
                    return;
                }
                else
                {
                    MessageBox.Show("Closing Minecraft Sparkling Server Hostring Tool", "Closing...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Environment.Exit(0);
                }
            }
            else
            {
                installing = false;
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

        private async void button2_Click(object sender, EventArgs e)//Install
        {
            //Install button clicked

            this.Size = installingSize;

            progressBar.Visible = true;
            progressLabel.Visible = true;

            await Install();

            progressBar.Value = 100;
            progressLabel.Text = "Installationg Complete (100%)";

            InstallBtn.Text = "Close";
            InstallBtn.Click += (s, args) =>
            {
                Environment.Exit(0);
            };
        }

        public async Task Install()
        {
            //Do the actual install here
            // | | | | | | | | | | | | |
            // v v v v v v v v v v v v v


            // Temporary Install Code
            await Task.Run(() =>
            {
                Directory.CreateDirectory(installPathTextBox.Text);
            });

        }

        private void Installer_Shown(object sender, EventArgs e)
        {
            this.Visible = installing;
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            using (var directoryDialog = new CommonOpenFileDialog() { IsFolderPicker = true})
            {
                var result = directoryDialog.ShowDialog();
                if (result == CommonFileDialogResult.Ok)
                {
                    installPathTextBox.Text = directoryDialog.FileName;
                }
            }
        }
    }
}
