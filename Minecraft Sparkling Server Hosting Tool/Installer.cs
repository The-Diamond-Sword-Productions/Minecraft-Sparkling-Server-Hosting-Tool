using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            label1.Text = label1.Text + (Environment.SpecialFolder.Programs) + "\\MSSHT\\";
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Minecraft Sparkling Server Hosting Tool installer will be closed.", "Closing...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            System.Environment.Exit(0);
        }
    }
}
