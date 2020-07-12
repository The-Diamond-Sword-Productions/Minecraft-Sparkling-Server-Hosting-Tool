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
using System.Net;
using System.Threading;
using System.Diagnostics;
using System.Reflection;
namespace Minecraft_Sparkling_Server_Hosting_Tool
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }
        private void Button2_Click(object sender, EventArgs e)
        {
            if (File.Exists(serverpath.Text+"/Run.bat") == false)
            {
                MessageBox.Show("Cannot find a server run file.\n\nMake sure there is a 'Run.bat' file in the directory. ("+serverpath.Text+")","File Missing",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            //here run the file (somehow) DELETE THIS:
            MessageBox.Show("This function is being worked on.","Work In Progress");
            // DELETE THIS WHEN DONE DOING THE RUN FUNCTION /\
        }
        private void Button4_Click(object sender, EventArgs e)
        {
            string folderPath = "";
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                folderPath = folderBrowserDialog1.SelectedPath;
                serverpath.Text = folderPath;
            }

        }
        private void Button5_Click(object sender, EventArgs e)
        {
            string folderPath = "";
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                folderPath = folderBrowserDialog1.SelectedPath;
                serverinstallpath.Text = folderPath;
            }
        }
        private void Button6_Click(object sender, EventArgs e)
        {
            MessageBox.Show("MIT License\n\nCopyright (c) 2020 The-Diamond-Sword-Productions\n\nPermission is hereby granted, free of charge, to any person obtaining a copy\nof this software and associated documentation files (the 'Software'), to deal\nin the Software without restriction, including without limitation the rights\nto use, copy, modify, merge, publish, distribute, sublicense, and/or sell\ncopies of the Software, and to permit persons to whom the Software is\nfurnished to do so, subject to the following conditions:\n\nThe above copyright notice and this permission notice shall be included in all\ncopies or substantial portions of the Software.\n\nTHE SOFTWARE IS PROVIDED 'AS IS', WITHOUT WARRANTY OF ANY KIND, EXPRESS OR\nIMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,\nFITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE\nAUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER\nLIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,\nOUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE\nSOFTWARE.", "Licence");
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("You are about to install Minecraft Server " + version.Text + " at " + serverinstallpath.Text + ". \n\nAre you sure?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                label12.Text = "Checking given directory...";
                label12.Text = "Idle";
                version.Enabled = false;
                serverinstallpath.Enabled = false;
                button5.Enabled = false;
                button1.Enabled = false;
                string subdir = serverinstallpath.Text;
                if (!Directory.Exists(subdir))
                {
                    label12.Text = "Idle";
                    version.Enabled = true;
                    serverinstallpath.Enabled = true;
                    button5.Enabled = true;
                    button1.Enabled = true;
                    MessageBox.Show("This directory (" + subdir + ") does not exist.\n\nPlease select a folder again.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (Directory.EnumerateFileSystemEntries(subdir).Any())
                    {
                        label12.Text = "Idle";
                        version.Enabled = true;
                        serverinstallpath.Enabled = true;
                        button5.Enabled = true;
                        button1.Enabled = true;
                        MessageBox.Show("This directory (" + subdir + ") is not empty!\n\nPlease delete all the component of the folder again.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        int parsedValue;
                        if (!int.TryParse(memo.Text, out parsedValue))
                        {
                            label12.Text = "Idle";
                            version.Enabled = true;
                            serverinstallpath.Enabled = true;
                            button5.Enabled = true;
                            button1.Enabled = true;
                            MessageBox.Show("This is not a valid number! (" + memo.Text + ")\n\nPlease put the number of MB you want for your server!\n\nDefault: 1024 MB", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        if (int.Parse(memo.Text)<=1000)
                        {
                            DialogResult warn = MessageBox.Show("Attention: You gave "+memo.Text+"MB to java. A value under 1000MB is not recommened.\n\nDo you want to continue?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                            if (warn == DialogResult.No)
                            {
                                label12.Text = "Idle";
                                version.Enabled = true;
                                serverinstallpath.Enabled = true;
                                button5.Enabled = true;
                                button1.Enabled = true;
                                return;
                            }
                        }else if (int.Parse(memo.Text) >= 10000)
                        {
                            DialogResult MBOverload = MessageBox.Show("Whoa! " + memo.Text + "MB is a lot! We recommend 1000<MB<10000\n\nDo you want to continue?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                            if (MBOverload == DialogResult.No)
                            {
                                label12.Text = "Idle";
                                version.Enabled = true;
                                serverinstallpath.Enabled = true;
                                button5.Enabled = true;
                                button1.Enabled = true;
                                return;
                            }
                        }
                        string FileName = serverinstallpath.Text + "/ServerRunner_" + version.Text + ".jar";
                        if (System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable() == false)
                        {
                            
                            MessageBox.Show("You are not connected to the internet.\n\nWe will not download the jar files but we will generate a .bat file.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            if (bat.Checked == true)
                            {
                                using (StreamWriter sw = File.CreateText(serverinstallpath.Text + "/" + "Run.bat"))
                                {
                                    if (nogui.Checked == true)
                                    {

                                        sw.WriteLine("java -Xmx" + memo.Text + "M -Xms" + memo.Text + "M -jar " + FileName + " nogui");
                                    }
                                    else
                                    {
                                        sw.WriteLine("java -Xmx" + memo.Text + "M -Xms" + memo.Text + "M -jar " + FileName);
                                    }
                                    if (pause.Checked == true)
                                    {
                                        sw.WriteLine("PAUSE");
                                    }

                                }
                            }
                            // 1.15 / 1.14 / 1.13 / 1.12 / 1.11 / 1.10 / 1.8.9 / 1.8 / 1.7.10
                            pbar.Value = 100;
                            version.Enabled = true;
                            serverinstallpath.Enabled = true;
                            button5.Enabled = true;
                            button1.Enabled = true;
                            label12.Text = "Installing done!";
                            return;                        
                        }
                            label12.Text = "Downloading: " + serverinstallpath.Text + "/ServerRunner_" + version.Text + ".jar";
                        pbar.Value = 40;
                        string SixteenOne = "https://launcher.mojang.com/v1/objects/a412fd69db1f81db3f511c1463fd304675244077/server.jar";
                        string Sixteen = "https://launcher.mojang.com/v1/objects/a0d03225615ba897619220e256a266cb33a44b6b/server.jar";
                        string FifteenTwo = "https://launcher.mojang.com/v1/objects/bb2b6b1aefcd70dfd1892149ac3a215f6c636b07/server.jar";
                        string FifteenOne = "https://launcher.mojang.com/v1/objects/4d1826eebac84847c71a77f9349cc22afd0cf0a1/server.jar";
                        string Fifteen = "https://launcher.mojang.com/v1/objects/952438ac4e01b4d115c5fc38f891710c4941df29/server.jar";
                        string FourteenFour = "https://launcher.mojang.com/v1/objects/3dc3d84a581f14691199cf6831b71ed1296a9fdf/server.jar";
                        string FourteenThree = "https://launcher.mojang.com/v1/objects/d0d0fe2b1dc6ab4c65554cb734270872b72dadd6/server.jar";
                        string FourteenTwo = "https://launcher.mojang.com/v1/objects/808be3869e2ca6b62378f9f4b33c946621620019/server.jar";
                        string FourteenOne = "https://launcher.mojang.com/v1/objects/ed76d597a44c5266be2a7fcd77a8270f1f0bc118/server.jar";
                        string Fourteen = "https://launcher.mojang.com/v1/objects/f1a0073671057f01aa843443fef34330281333ce/server.jar";
                        string Thirteen = "https://launcher.mojang.com/v1/objects/d0caafb8438ebd206f99930cfaecfa6c9a13dca0/server.jar";
                        string TwelveTwo = "https://launcher.mojang.com/v1/objects/886945bfb2b978778c3a0288fd7fab09d315b25f/server.jar";
                        string TwelveOne = "https://launcher.mojang.com/v1/objects/561c7b2d54bae80cc06b05d950633a9ac95da816/server.jar";
                        string Twelve = "https://launcher.mojang.com/v1/objects/8494e844e911ea0d63878f64da9dcc21f53a3463/server.jar";
                        string ElvevenTwo = "https://launcher.mojang.com/v1/objects/f00c294a1576e03fddcac777c3cf4c7d404c4ba4/server.jar";
                        string ElvevenOne = "https://launcher.mojang.com/v1/objects/1f97bd101e508d7b52b3d6a7879223b000b5eba0/server.jar";
                        string Elveven = "https://launcher.mojang.com/v1/objects/48820c84cb1ed502cb5b2fe23b8153d5e4fa61c0/server.jar";
                        string TenTwo = "https://launcher.mojang.com/v1/objects/3d501b23df53c548254f5e3f66492d178a48db63/server.jar";
                        string TenOne = "https://launcher.mojang.com/v1/objects/cb4c6f9f51a845b09a8861cdbe0eea3ff6996dee/server.jar";
                        string Ten = "https://launcher.mojang.com/v1/objects/a96617ffdf5dabbb718ab11a9a68e50545fc5bee/server.jar";
                        string NineFour = "https://launcher.mojang.com/v1/objects/edbb7b1758af33d365bf835eb9d13de005b1e274/server.jar";
                        string NineThree = "https://launcher.mojang.com/v1/objects/8e897b6b6d784f745332644f4d104f7a6e737ccf/server.jar";
                        string NineTwo = "https://launcher.mojang.com/v1/objects/2b95cc7b136017e064c46d04a5825fe4cfa1be30/server.jar";
                        string NineOne = "https://launcher.mojang.com/v1/objects/bf95d9118d9b4b827f524c878efd275125b56181/server.jar";
                        string Nine = "https://launcher.mojang.com/v1/objects/b4d449cf2918e0f3bd8aa18954b916a4d1880f0d/server.jar";
                        string EightNine = "https://launcher.mojang.com/v1/objects/b58b2ceb36e01bcd8dbf49c8fb66c55a9f0676cd/server.jar";
                        string Eight = "https://launcher.mojang.com/v1/objects/a028f00e678ee5c6aef0e29656dca091b5df11c7/server.jar";
                        string Seven = "https://launcher.mojang.com/v1/objects/952438ac4e01b4d115c5fc38f891710c4941df29/server.jar";
                        // THIS IS SEPERATOR -- THIS IS SEPERATOR -- THIS IS SEPERATOR -- THIS IS SEPERATOR -- THIS IS SEPERATOR -- THIS IS SEPERATOR -- THIS IS SEPERATOR -- 
                        if (version.Text == "1.16.1") //  DONE -----
                        {
                            Thread thread = new Thread(() =>
                            {
                                WebClient client = new WebClient();
                                client.DownloadFile(SixteenOne, FileName);
                            });
                            thread.Start();
                        }
                        else if (version.Text == "1.16") //  DONE -----
                        {
                            Thread thread = new Thread(() =>
                            {
                                WebClient client = new WebClient();
                                client.DownloadFile(Sixteen, FileName);
                            });
                            thread.Start();
                        }
                        else if (version.Text == "1.15.2") //  DONE -----
                        {
                            Thread thread = new Thread(() =>
                            {
                                WebClient client = new WebClient();
                                client.DownloadFile(FifteenTwo, FileName);
                            });
                            thread.Start();
                        }
                        else if (version.Text == "1.15.1") //  DONE -----
                        {
                            Thread thread = new Thread(() =>
                            {
                                WebClient client = new WebClient();
                                client.DownloadFile(FifteenOne, FileName);
                            });
                            thread.Start();
                        }
                        else if (version.Text == "1.15") //  DONE -----
                        {
                            Thread thread = new Thread(() =>
                            {
                                WebClient client = new WebClient();
                                client.DownloadFile(Fifteen, FileName);
                            });
                            thread.Start();
                        }
                        else if (version.Text == "1.14.4")//  DONE -----
                        {
                            Thread thread = new Thread(() =>
                            {
                                WebClient client = new WebClient();
                                client.DownloadFile(FourteenFour, FileName);
                            });
                            thread.Start();
                        }
                        else if (version.Text == "1.14.3")//  DONE -----
                        {
                            Thread thread = new Thread(() =>
                            {
                                WebClient client = new WebClient();
                                client.DownloadFile(FourteenThree, FileName);
                            });
                            thread.Start();
                        }
                        else if (version.Text == "1.14.2")//  DONE -----
                        {
                            Thread thread = new Thread(() =>
                            {
                                WebClient client = new WebClient();
                                client.DownloadFile(FourteenTwo, FileName);
                            });
                            thread.Start();
                        }
                        else if (version.Text == "1.14.1")//  DONE -----
                        {
                            Thread thread = new Thread(() =>
                            {
                                WebClient client = new WebClient();
                                client.DownloadFile(FourteenOne, FileName);
                            });
                            thread.Start();
                        }
                        else if (version.Text == "1.14")//  DONE -----
                        {
                            Thread thread = new Thread(() =>
                            {
                                WebClient client = new WebClient();
                                client.DownloadFile(Fourteen, FileName);
                            });
                            thread.Start();
                        }
                        else if (version.Text == "1.13")//  DONE -----
                        {
                            Thread thread = new Thread(() =>
                            {
                                WebClient client = new WebClient();
                                client.DownloadFile(Thirteen, FileName);
                            });
                            thread.Start();
                        }
                        else if (version.Text == "1.12.2")//  DONE -----
                        {
                            Thread thread = new Thread(() =>
                            {
                                WebClient client = new WebClient();
                                client.DownloadFile(TwelveTwo, FileName);
                            });
                            thread.Start();
                        }
                        else if (version.Text == "1.12.1")//  DONE -----
                        {
                            Thread thread = new Thread(() =>
                            {
                                WebClient client = new WebClient();
                                client.DownloadFile(TwelveOne, FileName);
                            });
                            thread.Start();
                        }
                        else if (version.Text == "1.12")//  DONE -----
                        {
                            Thread thread = new Thread(() =>
                            {
                                WebClient client = new WebClient();
                                client.DownloadFile(Twelve, FileName);
                            });
                            thread.Start();
                        }
                        else if (version.Text == "1.11")
                        {
                            Thread thread = new Thread(() =>
                            {
                                WebClient client = new WebClient();
                                client.DownloadFile(Elveven, FileName);
                            });
                            thread.Start();
                        }
                        else if (version.Text == "1.11.2")
                        {
                            Thread thread = new Thread(() =>
                            {
                                WebClient client = new WebClient();
                                client.DownloadFile(ElvevenTwo, FileName);
                            });
                            thread.Start();
                        }
                        else if (version.Text == "1.11.1")
                        {
                            Thread thread = new Thread(() =>
                            {
                                WebClient client = new WebClient();
                                client.DownloadFile(ElvevenOne, FileName);
                            });
                            thread.Start();
                        }
                        else if (version.Text == "1.10.2")
                        {
                            Thread thread = new Thread(() =>
                            {
                                WebClient client = new WebClient();
                                client.DownloadFile(TenTwo, FileName);
                            });
                            thread.Start();
                        }
                        else if (version.Text == "1.10.1")
                        {
                            Thread thread = new Thread(() =>
                            {
                                WebClient client = new WebClient();
                                client.DownloadFile(TenOne, FileName);
                            });
                            thread.Start();
                        }
                        else if (version.Text == "1.10")
                        {
                            Thread thread = new Thread(() =>
                            {
                                WebClient client = new WebClient();
                                client.DownloadFile(Ten, FileName);
                            });
                            thread.Start();
                        }
                        else if (version.Text == "1.9.4")
                        {
                            Thread thread = new Thread(() =>
                            {
                                WebClient client = new WebClient();
                                client.DownloadFile(NineFour, FileName);
                            });
                            thread.Start();
                        }
                        else if (version.Text == "1.9.3")
                        {
                            Thread thread = new Thread(() =>
                            {
                                WebClient client = new WebClient();
                                client.DownloadFile(NineThree, FileName);
                            });
                            thread.Start();
                        }
                        else if (version.Text == "1.9.2")
                        {
                            Thread thread = new Thread(() =>
                            {
                                WebClient client = new WebClient();
                                client.DownloadFile(NineTwo, FileName);
                            });
                            thread.Start();
                        }
                        else if (version.Text == "1.9.1")
                        {
                            Thread thread = new Thread(() =>
                            {
                                WebClient client = new WebClient();
                                client.DownloadFile(NineOne, FileName);
                            });
                            thread.Start();
                        }
                        else if (version.Text == "1.9")
                        {
                            Thread thread = new Thread(() =>
                            {
                                WebClient client = new WebClient();
                                client.DownloadFile(Nine, FileName);
                            });
                            thread.Start();
                        }
                        else if (version.Text == "1.8.9")
                        {
                            Thread thread = new Thread(() =>
                            {
                                WebClient client = new WebClient();
                                client.DownloadFile(EightNine, FileName);
                            });
                            thread.Start();
                        }
                        else if (version.Text == "1.8")
                        {
                            Thread thread = new Thread(() =>
                            {
                                WebClient client = new WebClient();
                                client.DownloadFile(Eight, FileName);
                            });
                            thread.Start();
                        }
                        else if (version.Text == "1.7.10")
                        {
                            Thread thread = new Thread(() =>
                            {
                                WebClient client = new WebClient();
                                client.DownloadFile(Seven, FileName);
                                Thread.Sleep(2000);
                            });
                            thread.Start();
                        }
                        else
                        {
                            MessageBox.Show("Please open up an issue on GitHub (https://github.com/The-Diamond-Sword-Productions/Minecraft-Sparkling-Server-Hosting-Tool) with\nthe error code 'ConditionNotMet'.\n\nPlease try choosing another version.", "Critical error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        if(bat.Checked == true)
                        {
                            using (StreamWriter sw = File.CreateText(serverinstallpath.Text + "/" + "Run.bat"))
                            {
                                if (nogui.Checked == true)
                                {
                                    sw.WriteLine("java -Xmx" + memo.Text + "M -Xms" + memo.Text + "M -jar " + FileName+" nogui");
                                }
                                else
                                {
                                    sw.WriteLine("java -Xmx" + memo.Text + "M -Xms" + memo.Text + "M -jar " + FileName);
                                }
                                if (pause.Checked == true)
                                {
                                    sw.WriteLine("PAUSE");
                                }
                                
                            }
                        }
                        // 1.15 / 1.14 / 1.13 / 1.12 / 1.11 / 1.10 / 1.8.9 / 1.8 / 1.7.10
                        pbar.Value = 100;
                        version.Enabled = true;
                        serverinstallpath.Enabled = true;
                        button5.Enabled = true;
                        button1.Enabled = true;
                        label12.Text = "Installing done!";
                        // 1.15 / 1.14 / 1.13 / 1.12 / 1.11 / 1.10 / 1.8.9 / 1.8 / 1.7.10
                        // THIS IS SEPERATOR -- THIS IS SEPERATOR -- THIS IS SEPERATOR -- THIS IS SEPERATOR -- THIS IS SEPERATOR -- THIS IS SEPERATOR -- THIS IS SEPERATOR -- 
                        // THIS IS SEPERATOR -- THIS IS SEPERATOR -- THIS IS SEPERATOR -- THIS IS SEPERATOR -- THIS IS SEPERATOR -- THIS IS SEPERATOR -- THIS IS SEPERATOR -- 
                    }
                }
            }
        }
        private void Button5_Click_1(object sender, EventArgs e)
        {
            string folderPath = "";
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                folderPath = folderBrowserDialog1.SelectedPath;
                serverinstallpath.Text = folderPath;
            }
        }

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(linkLabel1.Text);
        }

        private void Bat_CheckedChanged(object sender, EventArgs e)
        {
            if (bat.Checked == true)
            {
                memo.Enabled = true;
                nogui.Enabled = true;
            }
            else
            {
                memo.Enabled = false;
                nogui.Enabled = false;
            }
        }

        private void Nogui_CheckedChanged(object sender, EventArgs e)
        {
            if(nogui.Checked == true)
            {
                DialogResult noguiI = MessageBox.Show("Attention: When enabling this option, you will not see any\nerrors or any output. \n\nAre you sure?","Are you sure?",MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
                if(noguiI == DialogResult.No)
                {
                    nogui.Checked = false;
                }
            }
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            if (System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable() == true)
            {
                DialogResult update = MessageBox.Show("Do you want to check for updates?", "Updates?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (update == DialogResult.Yes)
                {
                    if (System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable() == false)
                    {
                        MessageBox.Show("Please check your connection and try again.", "No Internet Connection", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (GetResponseText("https://pastebin.com/raw/s7pTzDCM") == Client_Version.Text)
                    {
                        MessageBox.Show("You are at the lastest version!","Up-to-date!",MessageBoxButtons.OK);
                    }
                    else
                    {
                        DialogResult gotoUp = MessageBox.Show("An update is available, do you want to go to our GitHub?", "Goto website?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (gotoUp == DialogResult.Yes)
                        {
                           System.Diagnostics.Process.Start("https://github.com/The-Diamond-Sword-Productions/Minecraft-Sparkling-Server-Hosting-Tool");
                        }
                    }
                }
            }
            else
            {
                checkUpdates.Enabled = false;
                button2.Enabled = false;
                MessageBox.Show("You are not connected to the internet. \n\nSome buttons and functions will be disabled.","No internet.",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }
            
        }
        public static string GetResponseText(string address)
        {
            var request = (HttpWebRequest)WebRequest.Create(address);

            using (var response = (HttpWebResponse)request.GetResponse())
            {
                var encoding = Encoding.GetEncoding(response.CharacterSet);

                using (var responseStream = response.GetResponseStream())
                using (var reader = new StreamReader(responseStream, encoding))
                    return reader.ReadToEnd();
            }
        }

        private void CheckUpdates_Click(object sender, EventArgs e)
        {
            if (System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable() == false)
            {
                MessageBox.Show("Please check your connection and try again.","No Internet Connection",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            if (GetResponseText("https://pastebin.com/raw/s7pTzDCM") == Client_Version.Text)
            {
                MessageBox.Show("You are at the lastest version!", "Up-to-date!", MessageBoxButtons.OK);
            }
            else
            {
                DialogResult gotoUp = MessageBox.Show("An update is available, do you want to go to our GitHub?", "Goto website?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (gotoUp == DialogResult.Yes)
                {
                    System.Diagnostics.Process.Start("https://github.com/The-Diamond-Sword-Productions/Minecraft-Sparkling-Server-Hosting-Tool");
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //open server properties
        }

        private void button7_Click(object sender, EventArgs e)
        {
            serverpath.Text = serverinstallpath.Text;
        }

        private void Client_Version_Click(object sender, EventArgs e)
        {

        }
    }
}
