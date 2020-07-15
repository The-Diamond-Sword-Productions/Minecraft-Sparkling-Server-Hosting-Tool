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

        private async void button1_Click(object sender, EventArgs e)
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
            StatusLabel.Text = "Generating Vanilla.txt file... \n\n Generating tempserver.properties file...";
            using (StreamWriter sw = File.CreateText(main.ServerDirectory + @"\" + "tempserver.properties"))
            {
                await sw.WriteLineAsync("#Minecraft server properties");
                await sw.WriteLineAsync("#Fri Jul 01 00:00:00 CEST 2020");
                await sw.WriteLineAsync("generator-settings=");
                await sw.WriteLineAsync("op-permission-level=4");
                await sw.WriteLineAsync("allow-nether=true");
                await sw.WriteLineAsync("level-name=world");
                await sw.WriteLineAsync("enable-query=false");
                await sw.WriteLineAsync("allow-flight=false");
                await sw.WriteLineAsync("announce-player-achievements=true");
                await sw.WriteLineAsync("server-port=25565");
                await sw.WriteLineAsync("max-world-size=29999984");
                await sw.WriteLineAsync("level-type=DEFAULT");
                await sw.WriteLineAsync("enable-rcon=false");
                await sw.WriteLineAsync("level-seed=");
                await sw.WriteLineAsync("force-gamemode=false");
                await sw.WriteLineAsync("server-ip=");
                await sw.WriteLineAsync("network-compression-threshold=256");
                await sw.WriteLineAsync("max-build-height=256");
                await sw.WriteLineAsync("spawn-npcs=true");
                await sw.WriteLineAsync("white-list=false");
                await sw.WriteLineAsync("spawn-animals=true");
                await sw.WriteLineAsync("hardcore=false");
                await sw.WriteLineAsync("snooper-enabled=true");
                await sw.WriteLineAsync("resource-pack-sha1=");
                await sw.WriteLineAsync("online-mode=true");
                await sw.WriteLineAsync("resource-pack=");
                await sw.WriteLineAsync("pvp=true");
                await sw.WriteLineAsync("difficulty=1");
                await sw.WriteLineAsync("enable-command-block=true");
                await sw.WriteLineAsync("gamemode=0");
                await sw.WriteLineAsync("player-idle-timeout=0");
                await sw.WriteLineAsync("max-players=20");
                await sw.WriteLineAsync("spawn-monsters=true");
                await sw.WriteLineAsync("generate-structures=true");
                await sw.WriteLineAsync("view-distance=10");
                await sw.WriteLineAsync("motd=A Minecraft Server");
            }
            StatusLabel.Text = "Generating Vanilla.txt file... \n\n Generating tempserver.properties file... \n\n Done!";
            MessageBox.Show("Your server is now compatible with our tool!", "Done", MessageBoxButtons.OK, MessageBoxIcon.None);
            this.Close();
        }
    }
}
