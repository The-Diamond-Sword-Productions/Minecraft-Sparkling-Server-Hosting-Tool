using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Minecraft_Sparkling_Server_Hosting_Tool
{
    public partial class ServerPropertiesForm : Form
    {
        public ServerPropertiesForm(string data)
        {
            InitializeComponent();
            label2.Text = data;
            if (File.Exists(label2.Text + @"\tempserver.properties") == true)
            {
                label6.Text = "Reading server.properties file...";
                string nether = File.ReadLines(label2.Text + @"\tempserver.properties").Skip(4).Take(1).First();
                if (nether == "allow-nether=true")
                {
                    NetherT.Checked = true;
                }
                else
                {
                    NetherF.Checked = true;
                }
                string worldstr = File.ReadLines(label2.Text + @"\tempserver.properties").Skip(5).Take(1).First();
                worldstr = worldstr.Remove(0, 11);
                world.Text = worldstr;
                string flight = File.ReadLines(label2.Text + @"\tempserver.properties").Skip(7).Take(1).First();
                if (flight == "allow-flight=true")
                {
                    AllowFlightT.Checked = true;
                }
                else
                {
                    AllowFlightF.Checked = true;
                }
                string achievements = File.ReadLines(label2.Text + @"\tempserver.properties").Skip(8).Take(1).First();
                if (achievements == "announce-player-achievements=true")
                {
                    AchievementsT.Checked = true;
                }
                else
                {
                    AchievementsF.Checked = true;
                }
                string levelType_ = File.ReadLines(label2.Text + @"\tempserver.properties").Skip(11).Take(1).First();
                levelType_ = levelType_.Remove(0, 11);
                LevelType.Text = levelType_;
                string levelSeed_ = File.ReadLines(label2.Text + @"\tempserver.properties").Skip(13).Take(1).First();
                levelSeed_ = levelSeed_.Remove(0, 11);
                LevelSeed.Text = levelSeed_;
                string NPC = File.ReadLines(label2.Text + @"\tempserver.properties").Skip(18).Take(1).First();
                if (NPC == "spawn-npcs=true")
                {
                    SpawnNPCt.Checked = true;
                }
                else
                {
                    SpawnNPCf.Checked = true;
                }
                string WT = File.ReadLines(label2.Text + @"\tempserver.properties").Skip(19).Take(1).First();
                if (WT == "white-list=true")
                {
                    wtT.Checked = true;
                }
                else
                {
                    wtF.Checked = true;
                }
                string Animals = File.ReadLines(label2.Text + @"\tempserver.properties").Skip(20).Take(1).First();
                if (Animals == "spawn-animals=true")
                {
                    AnimalsT.Checked = true;
                }
                else
                {
                    AnimalsF.Checked = true;
                }
                string HT = File.ReadLines(label2.Text + @"\tempserver.properties").Skip(21).Take(1).First();
                if (HT == "hardcore=true")
                {
                    hcT.Checked = true;
                }
                else
                {
                    hcF.Checked = true;
                }
                string Online = File.ReadLines(label2.Text + @"\tempserver.properties").Skip(24).Take(1).First();
                if (Online == "online-mode=true")
                {
                    OnlineT.Checked = true;
                }
                else
                {
                    OnlineF.Checked = true;
                }
                string PVP = File.ReadLines(label2.Text + @"\tempserver.properties").Skip(26).Take(1).First();
                if (PVP == "pvp=true")
                {
                    PVPt.Checked = true;
                }
                else
                {
                    PVPf.Checked = true;
                }
                string Difficulty_ = File.ReadLines(label2.Text + @"\tempserver.properties").Skip(27).Take(1).First();
                if (Difficulty_ == "difficulty=0")
                {
                    Difficulty.Text = "Peaceful";
                }
                else if (Difficulty_ == "difficulty=1")
                {
                    Difficulty.Text = "Easy";
                }
                else if (Difficulty_ == "difficulty=2")
                {
                    Difficulty.Text = "Normal";
                }
                else if (Difficulty_ == "difficulty=3")
                {
                    Difficulty.Text = "Hard";
                }
                string CommandBlocks = File.ReadLines(label2.Text + @"\tempserver.properties").Skip(28).Take(1).First();
                if (CommandBlocks == "enable-command-block=true")
                {
                    CommandBlockT.Checked = true;
                }
                else
                {
                    CommandBlockF.Checked = true;
                }
                string Gamemode_ = File.ReadLines(label2.Text + @"\tempserver.properties").Skip(29).Take(1).First();
                if (Gamemode_ == "gamemode=0")
                {
                    Gamemode.Text = "Survival";
                }
                else if (Gamemode_ == "gamemode=1")
                {
                    Gamemode.Text = "Creative";
                }
                else if (Gamemode_ == "gamemode=2")
                {
                    Gamemode.Text = "Adventure";
                }
                else if (Gamemode_ == "gamemode=3")
                {
                    Gamemode.Text = "Spectator";
                }
                string MaxPlayer_ = File.ReadLines(label2.Text + @"\tempserver.properties").Skip(31).Take(1).First();
                MaxPlayer_ = MaxPlayer_.Remove(0, 12);
                MaxPlayer.Text = MaxPlayer_;
                string SpawnMonster = File.ReadLines(label2.Text + @"\tempserver.properties").Skip(32).Take(1).First();
                if (SpawnMonster == "spawn-monsters=true")
                {
                    MonsterT.Checked = true;
                }
                else
                {
                    MonsterF.Checked = true;
                }
                string Structures = File.ReadLines(label2.Text + @"\tempserver.properties").Skip(33).Take(1).First();
                if (Structures == "generate-structures=true")
                {
                    GenerateT.Checked = true;
                }
                else
                {
                    GenerateF.Checked = true;
                }
                string View = File.ReadLines(label2.Text + @"\tempserver.properties").Skip(34).Take(1).First();
                View = View.Remove(0, 14);
                ViewDistance.Text = View;
                string motd_ = File.ReadLines(label2.Text + @"\tempserver.properties").Skip(35).Take(1).First();
                motd_ = motd_.Remove(0, 5);
                motd.Text = motd_;
                label6.Text = "Idle";
            }
        }

            private void button1_Click(object sender, EventArgs e)
        {
            label6.Text = "Saving...";
            using (StreamWriter sw = File.CreateText(label2.Text + @"\" + "server.properties"))
            {
                sw.WriteLine("#Minecraft server properties");
                sw.WriteLine("#Fri Jul 01 00:00:00 CEST 2020");
                sw.WriteLine("generator-settings=");
                sw.WriteLine("op-permission-level=4");
                if (NetherT.Checked == true)
                {
                sw.WriteLine("allow-nether=true");
                }
                else
                {
                    sw.WriteLine("allow-nether=false");
                }
                sw.WriteLine("level-name=" + world.Text);
                sw.WriteLine("enable-query=false");
                if (AllowFlightT.Checked == true)
                {
                    sw.WriteLine("allow-flight=true");
                }
                else
                {
                    sw.WriteLine("allow-flight=false");
                }
                if (AchievementsT.Checked == true)
                { 
                    sw.WriteLine("announce-player-achievements=true");
                }
                else
                {
                    sw.WriteLine("announce-player-achievements=false");
                }
                sw.WriteLine("server-port=25565");
                sw.WriteLine("max-world-size=29999984");
                sw.WriteLine("level-type=" + LevelType.Text);
                sw.WriteLine("enable-rcon=false");
                sw.WriteLine("level-seed=" + LevelSeed.Text);
                sw.WriteLine("force-gamemode=false");
                sw.WriteLine("server-ip=");
                sw.WriteLine("network-compression-threshold=256");
                sw.WriteLine("max-build-height=256");
                if (SpawnNPCt.Checked == true)
                {
                    sw.WriteLine("spawn-npcs=true");
                }
                else
                {
                    sw.WriteLine("spawn-npcs=false");
                }
                if (wtT.Checked == true)
                {
                    sw.WriteLine("white-list=true");
                }
                else
                {
                    sw.WriteLine("white-list=false");
                }
                if (AnimalsT.Checked == true)
                {
                    sw.WriteLine("spawn-animals=true");
                }
                else
                {
                    sw.WriteLine("spawn-animals=false");
                }
                if (hcT.Checked == true)
                {
                    sw.WriteLine("hardcore=true");
                }
                else
                {
                    sw.WriteLine("hardcore=false");
                }
                sw.WriteLine("snooper-enabled=true");
                sw.WriteLine("resource-pack-sha1=");
                if (OnlineT.Checked == true)
                {
                sw.WriteLine("online-mode=true");
                }
                else
                {
                    sw.WriteLine("online-mode=false");
                }
                sw.WriteLine("resource-pack=");
                if (PVPt.Checked == true)
                {
                    sw.WriteLine("pvp=true");
                }
                else
                {
                    sw.WriteLine("pvp=false");
                }
                if (Difficulty.Text == "Peaceful")
                {
                    sw.WriteLine("difficulty=0");
                }
                else if (Difficulty.Text == "Easy")
                {
                    sw.WriteLine("difficulty=1");
                }
                else if (Difficulty.Text == "Normal")
                {
                    sw.WriteLine("difficulty=2");
                }
                else if (Difficulty.Text == "Hard")
                {
                    sw.WriteLine("difficulty=3");
                }
                if (CommandBlockT.Checked == true)
                {
                    sw.WriteLine("enable-command-block=true");
                }
                else
                {
                    sw.WriteLine("enable-command-block=false");
                }
                if (Gamemode.Text == "Survival")
                {
                    sw.WriteLine("gamemode=0");
                }
                else if (Gamemode.Text == "Creative")
                {
                    sw.WriteLine("gamemode=1");
                }
                else if (Gamemode.Text == "Adventure")
                {
                    sw.WriteLine("gamemode=2");
                }
                else if (Gamemode.Text == "Spectator")
                {
                    sw.WriteLine("gamemode=3");
                }
                sw.WriteLine("player-idle-timeout=0");
                sw.WriteLine("max-players=" + MaxPlayer.Text);
                if (MonsterT.Checked == true)
                {
                    sw.WriteLine("spawn-monsters=true");
                }
                else
                {
                    sw.WriteLine("spawn-monsters=false");
                }
                if (GenerateT.Checked == true)
                {
                    sw.WriteLine("generate-structures=true");
                }
                else
                {
                    sw.WriteLine("generate-structures=false");
                }
                sw.WriteLine("view-distance=" + ViewDistance.Text);
                sw.WriteLine("motd=" + motd.Text);
            }
            using (StreamWriter sw = File.CreateText(label2.Text + @"\" + "tempserver.properties"))
            {
                sw.WriteLine("#Minecraft server properties");
                sw.WriteLine("#Fri Jul 01 00:00:00 CEST 2020");
                sw.WriteLine("generator-settings=");
                sw.WriteLine("op-permission-level=4");
                if (NetherT.Checked == true)
                {
                    sw.WriteLine("allow-nether=true");
                }
                else
                {
                    sw.WriteLine("allow-nether=false");
                }
                sw.WriteLine("level-name=" + world.Text);
                sw.WriteLine("enable-query=false");
                if (AllowFlightT.Checked == true)
                {
                    sw.WriteLine("allow-flight=true");
                }
                else
                {
                    sw.WriteLine("allow-flight=false");
                }
                if (AchievementsT.Checked == true)
                {
                    sw.WriteLine("announce-player-achievements=true");
                }
                else
                {
                    sw.WriteLine("announce-player-achievements=false");
                }
                sw.WriteLine("server-port=25565");
                sw.WriteLine("max-world-size=29999984");
                sw.WriteLine("level-type=" + LevelType.Text);
                sw.WriteLine("enable-rcon=false");
                sw.WriteLine("level-seed=" + LevelSeed.Text);
                sw.WriteLine("force-gamemode=false");
                sw.WriteLine("server-ip=");
                sw.WriteLine("network-compression-threshold=256");
                sw.WriteLine("max-build-height=256");
                if (SpawnNPCt.Checked == true)
                {
                    sw.WriteLine("spawn-npcs=true");
                }
                else
                {
                    sw.WriteLine("spawn-npcs=false");
                }
                if (wtT.Checked == true)
                {
                    sw.WriteLine("white-list=true");
                }
                else
                {
                    sw.WriteLine("white-list=false");
                }
                if (AnimalsT.Checked == true)
                {
                    sw.WriteLine("spawn-animals=true");
                }
                else
                {
                    sw.WriteLine("spawn-animals=false");
                }
                if (hcT.Checked == true)
                {
                    sw.WriteLine("hardcore=true");
                }
                else
                {
                    sw.WriteLine("hardcore=false");
                }
                sw.WriteLine("snooper-enabled=true");
                sw.WriteLine("resource-pack-sha1=");
                if (OnlineT.Checked == true)
                {
                    sw.WriteLine("online-mode=true");
                }
                else
                {
                    sw.WriteLine("online-mode=false");
                }
                sw.WriteLine("resource-pack=");
                if (PVPt.Checked == true)
                {
                    sw.WriteLine("pvp=true");
                }
                else
                {
                    sw.WriteLine("pvp=false");
                }
                if (Difficulty.Text == "Peaceful")
                {
                    sw.WriteLine("difficulty=0");
                }
                else if (Difficulty.Text == "Easy")
                {
                    sw.WriteLine("difficulty=1");
                }
                else if (Difficulty.Text == "Normal")
                {
                    sw.WriteLine("difficulty=2");
                }
                else if (Difficulty.Text == "Hard")
                {
                    sw.WriteLine("difficulty=3");
                }
                if (CommandBlockT.Checked == true)
                {
                    sw.WriteLine("enable-command-block=true");
                }
                else
                {
                    sw.WriteLine("enable-command-block=false");
                }
                if (Gamemode.Text == "Survival")
                {
                    sw.WriteLine("gamemode=0");
                }
                else if (Gamemode.Text == "Creative")
                {
                    sw.WriteLine("gamemode=1");
                }
                else if (Gamemode.Text == "Adventure")
                {
                    sw.WriteLine("gamemode=2");
                }
                else if (Gamemode.Text == "Spectator")
                {
                    sw.WriteLine("gamemode=3");
                }
                sw.WriteLine("player-idle-timeout=0");
                sw.WriteLine("max-players=" + MaxPlayer.Text);
                if (MonsterT.Checked == true)
                {
                    sw.WriteLine("spawn-monsters=true");
                }
                else
                {
                    sw.WriteLine("spawn-monsters=false");
                }
                if (GenerateT.Checked == true)
                {
                    sw.WriteLine("generate-structures=true");
                }
                else
                {
                    sw.WriteLine("generate-structures=false");
                }
                sw.WriteLine("view-distance=" + ViewDistance.Text);
                sw.WriteLine("motd=" + motd.Text);
                label6.Text = "Saved!";
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://minecraft.tools/motd.php");
        }
    }
}
