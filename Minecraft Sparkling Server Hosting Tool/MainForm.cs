using System;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace Minecraft_Sparkling_Server_Hosting_Tool
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }
        private async void Button2_Click(object sender, EventArgs e)
        {
            if (button2.Text == "Start Server")
            {
                button2.Text = "Starting...";
                if (File.Exists(serverpath.Text + @"\Run.bat") == false)
                {
                    label7.Text = "Cannot find a server run file.\n\nMake sure there is a 'Run.bat' file in the directory: \n\n" + serverpath.Text;
                    groupBox2.Visible = true;
                    button2.Text = "Start Server";
                }
                else
                {
                    if (File.Exists(serverpath.Text + @"\eula.txt") == false)
                    {
                        Status_.Text = "Asking to accept the eula...";
                        Status.Text = "Asking to accept the eula...";
                        button8.Visible = false;
                        button9.Visible = true;
                        button10.Visible = true;
                        linkLabel2.Visible = true;
                        label7.Text = "To first Run your Minecraft server, you need to accept the EULA. \n\nFor more info, click this link:                                 . \n\nIf you don't accept the eula, you cannot run your minecraft server.";
                        groupBox2.Visible = true;
                    }
                    else
                    {
                        label17.Text = "Starting...";
                        label17.ForeColor = System.Drawing.Color.Green;
                        Status_.Text = "Starting server...";
                        Status.Text = "Starting server...";
                        string path = serverpath.Text + @"\";
                        var process = new System.Diagnostics.Process();
                        process.StartInfo.FileName = path + "Run.bat";
                        process.StartInfo.WorkingDirectory = path;
                        process.StartInfo.UseShellExecute = true;
                        process.Start();
                        //process.WaitForExit();
                        await Task.Delay(10000);
                        label17.Text = "Started";
                        button2.ForeColor = System.Drawing.Color.Red;
                        button2.Text = "Stop Server";
                        Status_.Text = "Idle";
                        Status.Text = "Idle";
                    }
                }
            }
            else if (button2.Text == "Stop Server")
            {
                if (File.Exists(serverpath.Text + @"\Stop.bat") == false)
                {
                    label7.Text = "Cannot find a server stop file. You can alternatively close the console window.\n\nMake sure there is a 'Stop.bat' file in the directory: \n\n" + serverpath.Text;
                    groupBox2.Visible = true;
                    button2.Text = "Stop Server";
                }
                else
                {
                    label17.Text = "Stopping...";
                    label17.ForeColor = System.Drawing.Color.Red;
                    Status_.Text = "Stopping server...";
                    Status.Text = "Stopping server...";
                    string path = serverpath.Text + @"\";
                    var process = new System.Diagnostics.Process();
                    process.StartInfo.FileName = path + "Stop.bat";
                    process.StartInfo.WorkingDirectory = path;
                    process.StartInfo.UseShellExecute = true;
                    process.Start();
                    //process.WaitForExit();
                    button2.Text = "Stopping...";
                    await Task.Delay(2000);
                    label17.Text = "Stopped";
                    button2.ForeColor = System.Drawing.Color.Green;
                    button2.Text = "Start Server";
                    Status_.Text = "Idle";
                    Status.Text = "Idle";
                }
            }
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
            label12.Text = "Downloading: " + serverinstallpath.Text + @"\ServerRunner_" + version.Text + ".jar Please wait...";
            DialogResult result = MessageBox.Show("You are about to install Minecraft Server " + version.Text + " at " + serverinstallpath.Text + ". \n\nAre you sure?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                label12.Text = "Idle";
            }
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
                            MessageBox.Show("This is not a valid number! (" + memo.Text + ")\n\nPlease put the number of MB / GB you want for your server!\n\nDefault: 1024 MB", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        if (radioButton1.Checked == true)
                        {
                            if (int.Parse(memo.Text) <= 1000)
                            {
                                DialogResult warn = MessageBox.Show("Attention: You gave " + memo.Text + "MB to java. A value under 1000MB is not recommened.\n\nDo you want to continue?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                                if (warn == DialogResult.No)
                                {
                                    label12.Text = "Idle";
                                    version.Enabled = true;
                                    serverinstallpath.Enabled = true;
                                    button5.Enabled = true;
                                    button1.Enabled = true;
                                    return;
                                }
                            }
                            else if (int.Parse(memo.Text) >= 10000)
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
                        }
                        else
                        {
                            if (int.Parse(memo.Text) <= 1)
                            {
                                DialogResult warn = MessageBox.Show("Attention: You gave " + memo.Text + "GB to java. A value under 1GB is not recommened.\n\nDo you want to continue?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                                if (warn == DialogResult.No)
                                {
                                    label12.Text = "Idle";
                                    version.Enabled = true;
                                    serverinstallpath.Enabled = true;
                                    button5.Enabled = true;
                                    button1.Enabled = true;
                                    return;
                                }
                            }
                            else if (int.Parse(memo.Text) >= 10)
                            {
                                DialogResult MBOverload = MessageBox.Show("Whoa! " + memo.Text + "GB is a lot! We recommend 1<GB<10\n\nDo you want to continue?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
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
                        }
                        string FileName = serverinstallpath.Text + @"\ServerRunner_" + version.Text + ".jar";
                        if (System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable() == false)
                        {

                            MessageBox.Show("You are not connected to the internet.\n\nWe will not download the jar files but we will generate a Run.bat and a Stop.bat file.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            if (bat.Checked == true)
                            {
                                using (StreamWriter sw = File.CreateText(serverinstallpath.Text + @"\" + "Run.bat"))
                                {
                                    if (radioButton1.Checked == true)
                                    {
                                        if (nogui.Checked == true)
                                        {

                                            sw.WriteLine("java -Xmx" + memo.Text + "M -Xms" + memo.Text + "M -jar " + "ServerRunner_" + version.Text + ".jar" + " nogui");
                                        }
                                        else
                                        {
                                            sw.WriteLine("java -Xmx" + memo.Text + "M -Xms" + memo.Text + "M -jar " + "ServerRunner_" + version.Text + ".jar");
                                        }
                                        if (pause.Checked == true)
                                        {
                                            sw.WriteLine("PAUSE");
                                        }
                                    }
                                    else
                                    {
                                        if (nogui.Checked == true)
                                        {

                                            sw.WriteLine("java -Xmx" + memo.Text + "G -Xms" + memo.Text + "G -jar " + "ServerRunner_" + version.Text + ".jar" + " nogui");
                                        }
                                        else
                                        {
                                            sw.WriteLine("java -Xmx" + memo.Text + "G -Xms" + memo.Text + "G -jar " + "ServerRunner_" + version.Text + ".jar");
                                        }
                                        if (pause.Checked == true)
                                        {
                                            sw.WriteLine("PAUSE");
                                        }
                                    }
                                }
                                using (StreamWriter sw = File.CreateText(serverinstallpath.Text + @"\" + "Stop.bat"))
                                {
                                    sw.WriteLine("taskkill /IM \"Java.exe\" /F");
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
                        label12.Text = "Downloading: " + serverinstallpath.Text + "/ServerRunner_" + version.Text + ".jar , please wait a few seconds...";
                        pbar.Value = 40;
                        if (client.Text == "Vanilla (Normal Minecraft)")
                        {
                            using (StreamWriter sw = File.CreateText(serverinstallpath.Text + @"\" + "Vanilla.txt"))
                            {

                            }
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
                            string ThirteenTwo = "https://launcher.mojang.com/v1/objects/3737db93722a9e39eeada7c27e7aca28b144ffa7/server.jar";
                            string ThirteenOne = "https://launcher.mojang.com/v1/objects/fe123682e9cb30031eae351764f653500b7396c9/server.jar";
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
                            if (version.Text == "1.16.1") //  DONE -----
                            {
                                WebClient client = new WebClient();
                                client.DownloadFile(SixteenOne, FileName);
                            }
                            else if (version.Text == "1.16") //  DONE -----
                            {
                                WebClient client = new WebClient();
                                client.DownloadFile(Sixteen, FileName);
                            }
                            else if (version.Text == "1.15.2") //  DONE -----
                            {
                                WebClient client = new WebClient();
                                client.DownloadFile(FifteenTwo, FileName);
                            }
                            else if (version.Text == "1.15.1") //  DONE -----
                            {
                                WebClient client = new WebClient();
                                client.DownloadFile(FifteenOne, FileName);
                            }
                            else if (version.Text == "1.15") //  DONE -----
                            {
                                WebClient client = new WebClient();
                                client.DownloadFile(Fifteen, FileName);
                            }
                            else if (version.Text == "1.14.4")//  DONE -----
                            {
                                WebClient client = new WebClient();
                                client.DownloadFile(FourteenFour, FileName);
                            }
                            else if (version.Text == "1.14.3")//  DONE -----
                            {
                                WebClient client = new WebClient();
                                client.DownloadFile(FourteenThree, FileName);
                            }
                            else if (version.Text == "1.14.2")//  DONE -----
                            {
                                WebClient client = new WebClient();
                                client.DownloadFile(FourteenTwo, FileName);
                            }
                            else if (version.Text == "1.14.1")//  DONE -----
                            {
                                WebClient client = new WebClient();
                                client.DownloadFile(FourteenOne, FileName);
                            }
                            else if (version.Text == "1.14")//  DONE -----
                            {
                                WebClient client = new WebClient();
                                client.DownloadFile(Fourteen, FileName);
                            }
                            else if (version.Text == "1.13.2")//  DONE -----
                            {
                                WebClient client = new WebClient();
                                client.DownloadFile(ThirteenTwo, FileName);
                            }
                            else if (version.Text == "1.13.1")//  DONE -----
                            {
                                WebClient client = new WebClient();
                                client.DownloadFile(ThirteenOne, FileName);
                            }
                            else if (version.Text == "1.13")//  DONE -----
                            {
                                WebClient client = new WebClient();
                                client.DownloadFile(Thirteen, FileName);
                            }
                            else if (version.Text == "1.12.2")//  DONE -----
                            {
                                WebClient client = new WebClient();
                                client.DownloadFile(TwelveTwo, FileName);
                            }
                            else if (version.Text == "1.12.1")//  DONE -----
                            {
                                WebClient client = new WebClient();
                                client.DownloadFile(TwelveOne, FileName);
                            }
                            else if (version.Text == "1.12")//  DONE -----
                            {
                                WebClient client = new WebClient();
                                client.DownloadFile(Twelve, FileName);
                            }
                            else if (version.Text == "1.11")
                            {
                                WebClient client = new WebClient();
                                client.DownloadFile(Elveven, FileName);
                            }
                            else if (version.Text == "1.11.2")
                            {
                                WebClient client = new WebClient();
                                client.DownloadFile(ElvevenTwo, FileName);
                            }
                            else if (version.Text == "1.11.1")
                            {
                                WebClient client = new WebClient();
                                client.DownloadFile(ElvevenOne, FileName);
                            }
                            else if (version.Text == "1.10.2")
                            {
                                WebClient client = new WebClient();
                                client.DownloadFile(TenTwo, FileName);
                            }
                            else if (version.Text == "1.10.1")
                            {
                                WebClient client = new WebClient();
                                client.DownloadFile(TenOne, FileName);
                            }
                            else if (version.Text == "1.10")
                            {
                                WebClient client = new WebClient();
                                client.DownloadFile(Ten, FileName);
                            }
                            else if (version.Text == "1.9.4")
                            {
                                WebClient client = new WebClient();
                                client.DownloadFile(NineFour, FileName);
                            }
                            else if (version.Text == "1.9.3")
                            {
                                WebClient client = new WebClient();
                                client.DownloadFile(NineThree, FileName);
                            }
                            else if (version.Text == "1.9.2")
                            {
                                WebClient client = new WebClient();
                                client.DownloadFile(NineTwo, FileName);
                            }
                            else if (version.Text == "1.9.1")
                            {
                                WebClient client = new WebClient();
                                client.DownloadFile(NineOne, FileName);
                            }
                            else if (version.Text == "1.9")
                            {
                                WebClient client = new WebClient();
                                client.DownloadFile(Nine, FileName);
                            }
                            else if (version.Text == "1.8.9")
                            {
                                WebClient client = new WebClient();
                                client.DownloadFile(EightNine, FileName);
                            }
                            else if (version.Text == "1.8")
                            {
                                WebClient client = new WebClient();
                                client.DownloadFile(Eight, FileName);
                            }
                            else if (version.Text == "1.7.10")
                            {
                                WebClient client = new WebClient();
                                client.DownloadFile(Seven, FileName);
                            }
                            else
                            {
                                label12.Text = "Error";
                            }
                        }
                        if (client.Text == "Spigot (Plugins)")
                        {
                            using (StreamWriter sw = File.CreateText(serverinstallpath.Text + @"\" + "Spigot.txt"))
                            {

                            }
                            string SixteenOne = "https://cdn.getbukkit.org/spigot/spigot-1.16.1.jar";
                            string FifteenTwo = "https://cdn.getbukkit.org/spigot/spigot-1.15.2.jar";
                            string FifteenOne = "https://cdn.getbukkit.org/spigot/spigot-1.15.1.jar";
                            string Fifteen = "https://cdn.getbukkit.org/spigot/spigot-1.15.jar";
                            string FourteenFour = "https://cdn.getbukkit.org/spigot/spigot-1.14.4.jar";
                            string FourteenThree = "https://cdn.getbukkit.org/spigot/spigot-1.14.3.jar";
                            string FourteenTwo = "https://cdn.getbukkit.org/spigot/spigot-1.14.2.jar";
                            string FourteenOne = "https://cdn.getbukkit.org/spigot/spigot-1.14.1.jar";
                            string Fourteen = "https://cdn.getbukkit.org/spigot/spigot-1.14.jar";
                            string ThirteenTwo = "https://cdn.getbukkit.org/spigot/spigot-1.13.2.jar";
                            string ThirteenOne = "https://cdn.getbukkit.org/spigot/spigot-1.13.1.jar";
                            string Thirteen = "https://cdn.getbukkit.org/spigot/spigot-1.13.jar";
                            string TwelveTwo = "https://cdn.getbukkit.org/spigot/spigot-1.12.2.jar";
                            string TwelveOne = "https://cdn.getbukkit.org/spigot/spigot-1.12.1.jar";
                            string Twelve = "https://cdn.getbukkit.org/spigot/spigot-1.12.jar";
                            string ElvevenTwo = "https://cdn.getbukkit.org/spigot/spigot-1.11.2.jar";
                            string ElvevenOne = "https://cdn.getbukkit.org/spigot/spigot-1.11.1.jar";
                            string Elveven = "https://cdn.getbukkit.org/spigot/spigot-1.11.jar";
                            string TenTwo = "https://cdn.getbukkit.org/spigot/spigot-1.10.2-R0.1-SNAPSHOT-latest.jar";
                            string Ten = "https://cdn.getbukkit.org/spigot/spigot-1.10-R0.1-SNAPSHOT-latest.jar";
                            string NineFour = "https://cdn.getbukkit.org/spigot/spigot-1.9.4-R0.1-SNAPSHOT-latest.jar";
                            string NineTwo = "https://cdn.getbukkit.org/spigot/spigot-1.9.2-R0.1-SNAPSHOT-latest.jar";
                            string Nine = "https://cdn.getbukkit.org/spigot/spigot-1.9-R0.1-SNAPSHOT-latest.jar";
                            string EightEight = "https://cdn.getbukkit.org/spigot/spigot-1.8.8-R0.1-SNAPSHOT-latest.jar";
                            string Eight = "https://cdn.getbukkit.org/spigot/spigot-1.8-R0.1-SNAPSHOT-latest.jar";
                            string Seven = "https://cdn.getbukkit.org/spigot/spigot-1.7.10-SNAPSHOT-b1657.jar";
                            if (version.Text == "1.16.1") //  DONE -----
                            {
                                WebClient client = new WebClient();
                                client.DownloadFile(SixteenOne, FileName);
                            }
                            else if (version.Text == "1.15.2") //  DONE -----
                            {
                                WebClient client = new WebClient();
                                client.DownloadFile(FifteenTwo, FileName);
                            }
                            else if (version.Text == "1.15.1") //  DONE -----
                            {
                                WebClient client = new WebClient();
                                client.DownloadFile(FifteenOne, FileName);
                            }
                            else if (version.Text == "1.15") //  DONE -----
                            {
                                WebClient client = new WebClient();
                                client.DownloadFile(Fifteen, FileName);
                            }
                            else if (version.Text == "1.14.4")//  DONE -----
                            {
                                WebClient client = new WebClient();
                                client.DownloadFile(FourteenFour, FileName);
                            }
                            else if (version.Text == "1.14.3")//  DONE -----
                            {
                                WebClient client = new WebClient();
                                client.DownloadFile(FourteenThree, FileName);
                            }
                            else if (version.Text == "1.14.2")//  DONE -----
                            {
                                WebClient client = new WebClient();
                                client.DownloadFile(FourteenTwo, FileName);
                            }
                            else if (version.Text == "1.14.1")//  DONE -----
                            {
                                WebClient client = new WebClient();
                                client.DownloadFile(FourteenOne, FileName);
                            }
                            else if (version.Text == "1.14")//  DONE -----
                            {
                                WebClient client = new WebClient();
                                client.DownloadFile(Fourteen, FileName);
                            }
                            else if (version.Text == "1.13.2")//  DONE -----
                            {
                                WebClient client = new WebClient();
                                client.DownloadFile(ThirteenTwo, FileName);
                            }
                            else if (version.Text == "1.13.1")//  DONE -----
                            {
                                WebClient client = new WebClient();
                                client.DownloadFile(Thirteen, FileName);
                            }
                            else if (version.Text == "1.13")//  DONE -----
                            {
                                WebClient client = new WebClient();
                                client.DownloadFile(ThirteenOne, FileName);
                            }
                            else if (version.Text == "1.12.2")//  DONE -----
                            {
                                WebClient client = new WebClient();
                                client.DownloadFile(TwelveTwo, FileName);
                            }
                            else if (version.Text == "1.12.1")//  DONE -----
                            {
                                WebClient client = new WebClient();
                                client.DownloadFile(TwelveOne, FileName);
                            }
                            else if (version.Text == "1.12")//  DONE -----
                            {
                                WebClient client = new WebClient();
                                client.DownloadFile(Twelve, FileName);
                            }
                            else if (version.Text == "1.11")
                            {
                                WebClient client = new WebClient();
                                client.DownloadFile(Elveven, FileName);
                            }
                            else if (version.Text == "1.11.2")
                            {
                                WebClient client = new WebClient();
                                client.DownloadFile(ElvevenTwo, FileName);
                            }
                            else if (version.Text == "1.11.1")
                            {
                                WebClient client = new WebClient();
                                client.DownloadFile(ElvevenOne, FileName);
                            }
                            else if (version.Text == "1.10.2")
                            {
                                WebClient client = new WebClient();
                                client.DownloadFile(TenTwo, FileName);
                            }
                            else if (version.Text == "1.10")
                            {
                                WebClient client = new WebClient();
                                client.DownloadFile(Ten, FileName);
                            }
                            else if (version.Text == "1.9.4")
                            {
                                WebClient client = new WebClient();
                                client.DownloadFile(NineFour, FileName);
                            }
                            else if (version.Text == "1.9.2")
                            {
                                WebClient client = new WebClient();
                                client.DownloadFile(NineTwo, FileName);
                            }
                            else if (version.Text == "1.9")
                            {
                                WebClient client = new WebClient();
                                client.DownloadFile(Nine, FileName);
                            }
                            else if (version.Text == "1.8.8")
                            {
                                WebClient client = new WebClient();
                                client.DownloadFile(EightEight, FileName);
                            }
                            else if (version.Text == "1.8")
                            {
                                WebClient client = new WebClient();
                                client.DownloadFile(Eight, FileName);
                            }
                            else if (version.Text == "1.7.10")
                            {
                                WebClient client = new WebClient();
                                client.DownloadFile(Seven, FileName);
                            }
                            else
                            {
                                label12.Text = "Error";
                            }
                        }
                        using (StreamWriter sw = File.CreateText(serverinstallpath.Text + @"\" + "server.properties"))
                        {
                            sw.WriteLine("#Minecraft server properties");
                            sw.WriteLine("#Fri Jul 01 00:00:00 CEST 2020");
                            sw.WriteLine("generator-settings=");
                            sw.WriteLine("op-permission-level=4");
                            sw.WriteLine("allow-nether=true");
                            sw.WriteLine("level-name=world");
                            sw.WriteLine("enable-query=false");
                            sw.WriteLine("allow-flight=false");
                            sw.WriteLine("announce-player-achievements=true");
                            sw.WriteLine("server-port=25565");
                            sw.WriteLine("max-world-size=29999984");
                            sw.WriteLine("level-type=DEFAULT");
                            sw.WriteLine("enable-rcon=false");
                            sw.WriteLine("level-seed=");
                            sw.WriteLine("force-gamemode=false");
                            sw.WriteLine("server-ip=");
                            sw.WriteLine("network-compression-threshold=256");
                            sw.WriteLine("max-build-height=256");
                            sw.WriteLine("spawn-npcs=true");
                            sw.WriteLine("white-list=false");
                            sw.WriteLine("spawn-animals=true");
                            sw.WriteLine("hardcore=false");
                            sw.WriteLine("snooper-enabled=true");
                            sw.WriteLine("resource-pack-sha1=");
                            sw.WriteLine("online-mode=true");
                            sw.WriteLine("resource-pack=");
                            sw.WriteLine("pvp=true");
                            sw.WriteLine("difficulty=1");
                            sw.WriteLine("enable-command-block=true");
                            sw.WriteLine("gamemode=0");
                            sw.WriteLine("player-idle-timeout=0");
                            sw.WriteLine("max-players=20");
                            sw.WriteLine("spawn-monsters=true");
                            sw.WriteLine("generate-structures=true");
                            sw.WriteLine("view-distance=10");
                            sw.WriteLine("motd=A Minecraft Server");
                        }
                        using (StreamWriter sw = File.CreateText(serverinstallpath.Text + @"\" + "whitelist.json"))
                        { }
                        using (StreamWriter sw = File.CreateText(serverinstallpath.Text + @"\" + "tempserver.properties"))
                        { }
                        using (StreamWriter sw = File.CreateText(serverinstallpath.Text + @"\" + "tempwhitelist.json"))
                        { }

                            // THIS IS SEPERATOR -- THIS IS SEPERATOR -- THIS IS SEPERATOR -- THIS IS SEPERATOR -- THIS IS SEPERATOR -- THIS IS SEPERATOR -- THIS IS SEPERATOR -- 

                            if (label12.Text == "Error")
                        {
                            MessageBox.Show("Please open up an issue on GitHub (https://github.com/The-Diamond-Sword-Productions/Minecraft-Sparkling-Server-Hosting-Tool) with\nthe error code 'ConditionNotMet'.\n\nPlease try choosing another version.", "Critical error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            label12.Text = "Idle";
                        }
                        if (bat.Checked == true)
                        {
                            using (StreamWriter sw = File.CreateText(serverinstallpath.Text + @"\" + "Run.bat"))
                            {
                                if (radioButton1.Checked == true)
                                {
                                    if (nogui.Checked == true)
                                    {

                                        sw.WriteLine("java -Xmx" + memo.Text + "M -Xms" + memo.Text + "M -jar " + "ServerRunner_" + version.Text + ".jar" + " nogui");
                                    }
                                    else
                                    {
                                        sw.WriteLine("java -Xmx" + memo.Text + "M -Xms" + memo.Text + "M -jar " + "ServerRunner_" + version.Text + ".jar");
                                    }
                                    if (pause.Checked == true)
                                    {
                                        sw.WriteLine("PAUSE");
                                    }
                                }
                                else
                                {
                                    if (nogui.Checked == true)
                                    {

                                        sw.WriteLine("java -Xmx" + memo.Text + "G -Xms" + memo.Text + "G -jar " + "ServerRunner_" + version.Text + ".jar" + " nogui");
                                    }
                                    else
                                    {
                                        sw.WriteLine("java -Xmx" + memo.Text + "G -Xms" + memo.Text + "G -jar " + "ServerRunner_" + version.Text + ".jar");
                                    }
                                    if (pause.Checked == true)
                                    {
                                        sw.WriteLine("PAUSE");
                                    }
                                }

                            }
                            using (StreamWriter sw = File.CreateText(serverinstallpath.Text + @"\" + "Stop.bat"))
                            {
                                sw.WriteLine("taskkill /IM \"Java.exe\" /F");
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
            if (nogui.Checked == true)
            {
                if (client.Text == "Vanilla (Normal Minecraft)")
                {
                    DialogResult noguiI = MessageBox.Show("Attention: When enabling this option, you will not see any\nerrors or any output. \n\nAre you sure?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (noguiI == DialogResult.No)
                    {
                        nogui.Checked = false;
                    }
                }
            }
        }
        private void Menu_Load(object sender, EventArgs e)
        {
            groupBox2.Visible = false;
            button9.Visible = false;
            button10.Visible = false;
            linkLabel2.Visible = false;
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
            }
            else
            {
                checkUpdates.Enabled = false;
                button2.Enabled = false;
                MessageBox.Show("You are not connected to the internet. \n\nSome buttons and functions will be disabled.", "No internet.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                MessageBox.Show("Please check your connection and try again.", "No Internet Connection", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (memo.Text == "1")
            {
                memo.Text = "1024";
            }
            memo.Items.Clear();
            memo.Items.Add("512");
            memo.Items.Add("1024");
            memo.Items.Add("2048");
            memo.Items.Add("3072");
            memo.Items.Add("4096");
            memo.Items.Add("5120");
            memo.Items.Add("6144");
            memo.Items.Add("7168");
            memo.Items.Add("8192");
            memo.Items.Add("9216");
            memo.Items.Add("10240");
            memo.Items.Add("11264");
            memo.Items.Add("12288");
            memo.Items.Add("13312");
            memo.Items.Add("14336");
            memo.Items.Add("15360");
            memo.Items.Add("16384");
            memo.Items.Add("17408");
            memo.Items.Add("18432");
            memo.Items.Add("19456");
            memo.Items.Add("20480");
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (memo.Text == "1024")
            {
                memo.Text = "1";
            }
            memo.Items.Clear();
            memo.Items.Add("0.5");
            memo.Items.Add("1");
            memo.Items.Add("2");
            memo.Items.Add("3");
            memo.Items.Add("4");
            memo.Items.Add("5");
            memo.Items.Add("6");
            memo.Items.Add("7");
            memo.Items.Add("8");
            memo.Items.Add("9");
            memo.Items.Add("10");
            memo.Items.Add("11");
            memo.Items.Add("12");
            memo.Items.Add("13");
            memo.Items.Add("14");
            memo.Items.Add("15");
            memo.Items.Add("16");
            memo.Items.Add("17");
            memo.Items.Add("18");
            memo.Items.Add("19");
            memo.Items.Add("20");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            groupBox2.Visible = false;
        }

        private async void button9_Click(object sender, EventArgs e)
        {
            label17.Text = "Starting...";
            label17.ForeColor = System.Drawing.Color.Green;
            Status_.Text = "Generating eula=true file...";
            Status.Text = "Generating eula=true file...";
            groupBox2.Visible = false;
            button9.Visible = false;
            button10.Visible = false;
            button8.Visible = true;
            linkLabel2.Visible = false;
            button2.Text = "Starting...";
            using (StreamWriter sw = File.CreateText(serverpath.Text + @"\" + "eula.txt"))
            {
                sw.WriteLine("eula = true");
            }
            Status_.Text = "Starting server...";
            Status.Text = "Starting server...";
            string path = serverpath.Text + @"\";
            var process = new System.Diagnostics.Process();
            process.StartInfo.FileName = path + "Run.bat";
            process.StartInfo.WorkingDirectory = path;
            process.StartInfo.UseShellExecute = true;
            process.Start();
            //process.WaitForExit();
            await Task.Delay(10000);
            label17.Text = "Started";
            button2.ForeColor = System.Drawing.Color.Red;
            button2.Text = "Stop Server";
            Status_.Text = "Idle";
            Status.Text = "Idle";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Status_.Text = "Idle";
            Status.Text = "Idle";
            groupBox2.Visible = false;
            button9.Visible = false;
            button10.Visible = false;
            button8.Visible = true;
            linkLabel2.Visible = false;
            button2.Text = "Start Server";
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(linkLabel2.Text);
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            if (File.Exists(serverpath.Text + @"\tempserver.properties") == false)
            {
                using (StreamWriter sw = File.CreateText(serverinstallpath.Text + @"\" + "tempserver.properties"))
                { }
            }
            if (File.Exists(serverpath.Text + @"\server.properties") == true)
            {
                Status.Text = "Opening server.properties file...";
                Status_.Text = "Opening server.properties file...";
                ServerPropertiesForm frm = new ServerPropertiesForm(serverpath.Text);
                frm.Show();
                Status.Text = "Idle";
                Status_.Text = "Idle";
            }
            else if (File.Exists(serverpath.Text + @"\server.properties") == false)
            {
                if (File.Exists(serverpath.Text + @"\Run.bat") == true)
                {
                    Status.Text = "Generating server.properties file...";
                    Status_.Text = "Generating server.properties file...";
                    using (StreamWriter sw = File.CreateText(serverpath.Text + @"\" + "server.properties"))
                    {
                        sw.WriteLine("#Minecraft server properties");
                        sw.WriteLine("#Fri Jul 01 00:00:00 CEST 2020");
                        sw.WriteLine("generator-settings=");
                        sw.WriteLine("op-permission-level=4");
                        sw.WriteLine("allow-nether=true");
                        sw.WriteLine("level-name=world");
                        sw.WriteLine("enable-query=false");
                        sw.WriteLine("allow-flight=false");
                        sw.WriteLine("announce-player-achievements=true");
                        sw.WriteLine("server-port=25565");
                        sw.WriteLine("max-world-size=29999984");
                        sw.WriteLine("level-type=DEFAULT");
                        sw.WriteLine("enable-rcon=false");
                        sw.WriteLine("level-seed=");
                        sw.WriteLine("force-gamemode=false");
                        sw.WriteLine("server-ip=");
                        sw.WriteLine("network-compression-threshold=256");
                        sw.WriteLine("max-build-height=256");
                        sw.WriteLine("spawn-npcs=true");
                        sw.WriteLine("white-list=false");
                        sw.WriteLine("spawn-animals=true");
                        sw.WriteLine("hardcore=false");
                        sw.WriteLine("snooper-enabled=true");
                        sw.WriteLine("resource-pack-sha1=");
                        sw.WriteLine("online-mode=true");
                        sw.WriteLine("resource-pack=");
                        sw.WriteLine("pvp=true");
                        sw.WriteLine("difficulty=1");
                        sw.WriteLine("enable-command-block=true");
                        sw.WriteLine("gamemode=0");
                        sw.WriteLine("player-idle-timeout=0");
                        sw.WriteLine("max-players=20");
                        sw.WriteLine("spawn-monsters=true");
                        sw.WriteLine("generate-structures=true");
                        sw.WriteLine("view-distance=10");
                        sw.WriteLine("motd=A Minecraft Server");
                    }
                    Status.Text = "Opening server.properties file...";
                    Status_.Text = "Opening server.properties file...";
                    ServerPropertiesForm frm = new ServerPropertiesForm(serverpath.Text);
                    frm.Show();
                    Status.Text = "Idle";
                    Status_.Text = "Idle";
                }
            }
            else
            {
                label7.Text = "Cannot find a Server Properties File. \n\nMake sure that there is a server.properties file \n\nin the directory:" + serverpath.Text;
                groupBox2.Visible = true;
            }
        }

        private void client_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (client.Text == "Vanilla (Normal Minecraft)")
            {
                nogui.Enabled = true;
                nogui.Checked = false;
                label8.Text = "ATTENTION: We would not change this value! The recommended option is  unchecked.";
                if (version.Text == "1.8.8")
                {
                    MessageBox.Show("The 1.8.8 version is not available for Vanilla, so we switched your version to 1.8.9", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    version.Text = "1.8.9";
                }
                version.Items.Clear();
                version.Items.Add("1.16.1");
                version.Items.Add("1.16");
                version.Items.Add("1.15.2");
                version.Items.Add("1.15.1");
                version.Items.Add("1.15");
                version.Items.Add("1.14.4");
                version.Items.Add("1.14.3");
                version.Items.Add("1.14.2");
                version.Items.Add("1.14.1");
                version.Items.Add("1.14");
                version.Items.Add("1.13.2");
                version.Items.Add("1.13.1");
                version.Items.Add("1.13");
                version.Items.Add("1.12.2");
                version.Items.Add("1.12.1");
                version.Items.Add("1.12");
                version.Items.Add("1.11.2");
                version.Items.Add("1.11.1");
                version.Items.Add("1.11");
                version.Items.Add("1.10.2");
                version.Items.Add("1.10.1");
                version.Items.Add("1.10");
                version.Items.Add("1.9.4");
                version.Items.Add("1.9.3");
                version.Items.Add("1.9.2");
                version.Items.Add("1.9.1");
                version.Items.Add("1.9");
                version.Items.Add("1.8.9");
                version.Items.Add("1.8");
                version.Items.Add("1.7.10");
            }
            else if (client.Text == "Spigot (Plugins)")
            {
                nogui.Enabled = false;
                nogui.Checked = true;
                label8.Text = "Sadly, this feature doesn't work with spigot, unless the developpers of spigot decide to add it.";
                if (version.Text == "1.16")
                {
                    MessageBox.Show("The 1.16 version is sadly not available for Spigot, so we switched your version to 1.16.1.", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    version.Text = "1.16.1";
                }
                else if (version.Text == "1.10.1")
                {
                    MessageBox.Show("The 1.10.1 version is sadly not available for Spigot, so we switched your version to 1.10.2", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    version.Text = "1.10.2";
                }
                else if (version.Text == "1.9.3")
                {
                    MessageBox.Show("The 1.9.3 version is sadly not available for Spigot, so we switched your version to 1.9.4", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    version.Text = "1.9.4";
                }
                else if (version.Text == "1.9.1")
                {
                    MessageBox.Show("The 1.9.1 version is sadly not available for Spigot, so we switched your version to 1.9.2", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    version.Text = "1.9.2";
                }
                else if (version.Text == "1.8.9")
                {
                    MessageBox.Show("The 1.8.9 version is sadly not available for Spigot, so we switched your version to 1.8.8", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    version.Text = "1.8.8";
                }
                version.Items.Clear();
                version.Items.Add("1.16.1");
                version.Items.Add("1.15.2");
                version.Items.Add("1.15.1");
                version.Items.Add("1.15");
                version.Items.Add("1.14.4");
                version.Items.Add("1.14.3");
                version.Items.Add("1.14.2");
                version.Items.Add("1.14.1");
                version.Items.Add("1.14");
                version.Items.Add("1.13.2");
                version.Items.Add("1.13.1");
                version.Items.Add("1.13");
                version.Items.Add("1.12.2");
                version.Items.Add("1.12.1");
                version.Items.Add("1.12");
                version.Items.Add("1.11.2");
                version.Items.Add("1.11.1");
                version.Items.Add("1.11");
                version.Items.Add("1.10.2");
                version.Items.Add("1.10");
                version.Items.Add("1.9.4");
                version.Items.Add("1.9.2");
                version.Items.Add("1.9");
                version.Items.Add("1.8.8");
                version.Items.Add("1.8");
                version.Items.Add("1.7.10");
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/The-Diamond-Sword-Productions/Minecraft-Sparkling-Server-Hosting-Tool");
        }

        private void button12_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("You are going to go to our GitHub issue page, where you can ask for help, or report a bug.", "Are you sure?", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (result == DialogResult.OK)
            {
                System.Diagnostics.Process.Start("https://github.com/The-Diamond-Sword-Productions/Minecraft-Sparkling-Server-Hosting-Tool/issues");
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/The-Diamond-Sword-Productions/Minecraft-Sparkling-Server-Hosting-Tool/wiki");
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://mssht.sytes.net/");
        }

        private void serverpath_TextChanged(object sender, EventArgs e)
        {
            if (serverpath.Text == "")
            {
                button14.Enabled = false;
                button3.Enabled = false;
                button15.Enabled = false;
                label13.Text = "Please enter a server path to start your server...";
                label15.Text = "No server found...";
            }
            if (serverpath.Text != "")
            {
                if (File.Exists(serverpath.Text + @"\Spigot.txt") == true)
                {
                    button14.Enabled = true;
                    button3.Enabled = true;
                    button15.Enabled = true;
                    label13.Text = "Found a Spigot server.";
                    button14.Text = "Open Server Plugins File";
                    label15.Text = "Running Server On Spigot.";
                }
                else
                {
                    button14.Enabled = false;
                    if (File.Exists(serverpath.Text + @"\Vanilla.txt") == true)
                    {
                        button14.Text = "Open Server Plugins File (This server is not a Spigot server.)";
                        button3.Enabled = true;
                        button15.Enabled = true;
                        label13.Text = "Found a Vanilla server.";
                        label15.Text = "Running Server On Vanilla.";
                    }
                    else if (File.Exists(serverpath.Text + @"\Run.bat") == false)
                    {
                        label13.Text = "This path doesn't contain any minecraft server.";
                        button14.Enabled = false;
                        button3.Enabled = false;
                        button15.Enabled = false;
                        label15.Text = "No server found...";
                    }
                }
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (File.Exists(serverpath.Text + @"\Spigot.txt") == true)
            {
                if (Directory.Exists(serverpath.Text + @"\plugins") == false)
                {
                    Status.Text = "Generating plugins folder...";
                    Status_.Text = "Generating plugins folder...";
                    System.IO.Directory.CreateDirectory(serverpath.Text + @"\plugins");
                    Status.Text = "Opening plugins folder...";
                    Status_.Text = "Opening plugins folder...";
                    System.Diagnostics.Process.Start("explorer.exe", serverpath.Text + @"\plugins");
                    Status.Text = "Idle";
                    Status_.Text = "Idle";
                }
                else
                {
                    Status.Text = "Opening plugins folder...";
                    Status_.Text = "Opening plugins folder...";
                    System.Diagnostics.Process.Start("explorer.exe", serverpath.Text + @"\plugins");
                    Status.Text = "Idle";
                    Status_.Text = "Idle";
                }

            }
            else
            {
                label7.Text = "There is not any server in this path.\n\nMake sure there is a 'server' file in the directory: \n\n" + serverpath.Text;
                groupBox2.Visible = true;
            }
        }
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (serverpath.Text == "")
            {
                button14.Enabled = false;
                button3.Enabled = false;
                label13.Text = "Please enter a server path to start your server...";
            }
            if (serverpath.Text != "")
            {
                if (File.Exists(serverpath.Text + @"\Spigot.txt") == true)
                {
                    button14.Enabled = true;
                    button3.Enabled = true;
                    label13.Text = "Found a Spigot server.";
                    button14.Text = "Open Server Plugins File";
                }
                else
                {
                    button14.Enabled = false;
                    if (File.Exists(serverpath.Text + @"\Vanilla.txt") == true)
                    {
                        button14.Text = "Open Server Plugins File (This server is not a Spigot server.)";
                        button3.Enabled = true;
                        label13.Text = "Found a Vanilla server.";
                    }
                    else if (File.Exists(serverpath.Text + @"\Run.bat") == false)
                    {
                        label13.Text = "This path doesn't contain any minecraft server.";
                        button14.Enabled = false;
                        button3.Enabled = false;
                    }
                }
            }
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (File.Exists(serverpath.Text + @"\Vanilla.txt") == true)
            {
                DialogResult result = MessageBox.Show("You can download plugins, but the server you are running on is a Vanilla server, so you will not be able to install theese downloaded plugins on this server.", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
                if (result == DialogResult.Yes)
                {
                    System.Diagnostics.Process.Start("https://dev.bukkit.org/bukkit-plugins");
                }
            }
            else
            {
                System.Diagnostics.Process.Start("https://dev.bukkit.org/bukkit-plugins");
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (File.Exists(serverpath.Text + @"\tempwhitelist.json") == false)
            {
                using (StreamWriter sw = File.CreateText(serverpath.Text + @"\" + "tempwhitelist.json"))
                { }
            }
                if (File.Exists(serverpath.Text + @"\whitelist.json") == true)
            {
                Status.Text = "Opening whitelist file...";
                Status_.Text = "Opening whitelist file...";
                WhitelistForm frm = new WhitelistForm(serverpath.Text);
                frm.Show();
                Status.Text = "Idle";
                Status_.Text = "Idle";
            }
            else if (File.Exists(serverpath.Text + @"\whitelist.json") == false)
            {
                if (File.Exists(serverpath.Text + @"\Run.bat") == true)
                {
                    Status.Text = "Generating whitelist file...";
                    Status_.Text = "Generating whitelist file...";
                    using (StreamWriter sw = File.CreateText(serverpath.Text + @"\" + "whitelist.json"))
                    { }
                    Status.Text = "Opening whitelist file...";
                    Status_.Text = "Opening whitelist file...";
                    WhitelistForm frm = new WhitelistForm(serverpath.Text);
                    frm.Show();
                    Status.Text = "Idle";
                    Status_.Text = "Idle";
                }
            }
            else
            {
                label7.Text = "Cannot find a Server whitelist File. \n\nMake sure that there is a whitelist.json file \n\nin the directory:" + serverpath.Text;
                groupBox2.Visible = true;
            }
        }
    }
}
            