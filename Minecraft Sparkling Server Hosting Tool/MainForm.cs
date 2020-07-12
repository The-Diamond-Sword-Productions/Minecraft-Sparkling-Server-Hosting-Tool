using System;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace Minecraft_Sparkling_Server_Hosting_Tool
{
    public partial class MainForm : Form
    {

        public static string ServerDirectory = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\MinecraftServer\\";

        public MainForm()
        {
            InitializeComponent();

            serverPathTextBox.Text = ServerDirectory;
        }

        private async void Button2_Click(object sender, EventArgs e)
        {
            if (startStopServerButton.Text == "Start Server")
            {
                startStopServerButton.Text = "Starting...";
                if (File.Exists(serverPathTextBox.Text + @"\Run.bat") == false)
                {
                    label7.Text = "Cannot find a server run file.\n\nMake sure there is a 'Run.bat' file in the directory: \n\n" + serverPathTextBox.Text;
                    groupBox2.Visible = true;
                    startStopServerButton.Text = "Start Server";
                }
                else
                {
                    if (File.Exists(serverPathTextBox.Text + @"\eula.txt") == false)
                    {
                        Status_.Text = "Asking to accept the eula...";
                        Status.Text = "Asking to accept the eula...";
                        eulaOkButton.Visible = false;
                        eulaAcceptButton.Visible = true;
                        eulaRejectButton.Visible = true;
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
                        string path = serverPathTextBox.Text + @"\";
                        var process = new System.Diagnostics.Process();
                        process.StartInfo.FileName = path + "Run.bat";
                        process.StartInfo.WorkingDirectory = path;
                        process.StartInfo.UseShellExecute = true;
                        process.Start();
                        //process.WaitForExit();
                        await Task.Delay(10000);
                        label17.Text = "Started";
                        startStopServerButton.ForeColor = System.Drawing.Color.Red;
                        startStopServerButton.Text = "Stop Server";
                        Status_.Text = "Idle";
                        Status.Text = "Idle";
                    }
                }
            }
            else if (startStopServerButton.Text == "Stop Server")
            {
                if (File.Exists(serverPathTextBox.Text + @"\Stop.bat") == false)
                {
                    label7.Text = "Cannot find a server stop file. You can alternatively close the console window.\n\nMake sure there is a 'Stop.bat' file in the directory: \n\n" + serverPathTextBox.Text;
                    groupBox2.Visible = true;
                    startStopServerButton.Text = "Stop Server";
                }
                else
                {
                    label17.Text = "Stopping...";
                    label17.ForeColor = System.Drawing.Color.Red;
                    Status_.Text = "Stopping server...";
                    Status.Text = "Stopping server...";
                    string path = serverPathTextBox.Text + @"\";
                    var process = new System.Diagnostics.Process();
                    process.StartInfo.FileName = path + "Stop.bat";
                    process.StartInfo.WorkingDirectory = path;
                    process.StartInfo.UseShellExecute = true;
                    process.Start();
                    //process.WaitForExit();
                    startStopServerButton.Text = "Stopping...";
                    await Task.Delay(2000);
                    label17.Text = "Stopped";
                    startStopServerButton.ForeColor = System.Drawing.Color.Green;
                    startStopServerButton.Text = "Start Server";
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
                serverPathTextBox.Text = folderPath;
            }

        }
        private void Button5_Click(object sender, EventArgs e)
        {
            string folderPath = "";
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                folderPath = folderBrowserDialog1.SelectedPath;
                serverInstallPathTextBox.Text = folderPath;
            }
        }
        private void Button6_Click(object sender, EventArgs e)
        {
            MessageBox.Show("MIT License\n\nCopyright (c) 2020 The-Diamond-Sword-Productions\n\nPermission is hereby granted, free of charge, to any person obtaining a copy\nof this software and associated documentation files (the 'Software'), to deal\nin the Software without restriction, including without limitation the rights\nto use, copy, modify, merge, publish, distribute, sublicense, and/or sell\ncopies of the Software, and to permit persons to whom the Software is\nfurnished to do so, subject to the following conditions:\n\nThe above copyright notice and this permission notice shall be included in all\ncopies or substantial portions of the Software.\n\nTHE SOFTWARE IS PROVIDED 'AS IS', WITHOUT WARRANTY OF ANY KIND, EXPRESS OR\nIMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,\nFITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE\nAUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER\nLIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,\nOUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE\nSOFTWARE.", "Licence");
        }
        private async void OnInstallServerButtonClick(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(serverInstallPathTextBox.Text) &&
                !Directory.Exists(serverInstallPathTextBox.Text))
            {
                MessageBox.Show("The current directory is invalid. Please select a valid directory", "Invalid Install Directory", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult result = MessageBox.Show("You are about to install Minecraft Server " + versionDropdown.Text + " at " + serverInstallPathTextBox.Text + ". \n\nAre you sure?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                label12.Text = "Idle";
            }
            if (result == DialogResult.Yes)
            {
                label12.Text = "Checking given directory...";
                label12.Text = "Idle";
                versionDropdown.Enabled = false;
                serverInstallPathTextBox.Enabled = false;
                serverPathBrowseButton.Enabled = false;
                serverInstallButton.Enabled = false;
                string subdir = serverInstallPathTextBox.Text;
                if (!Directory.Exists(subdir))
                {
                    label12.Text = "Idle";
                    versionDropdown.Enabled = true;
                    serverInstallPathTextBox.Enabled = true;
                    serverPathBrowseButton.Enabled = true;
                    serverInstallButton.Enabled = true;
                    MessageBox.Show("This directory (" + subdir + ") does not exist.\n\nPlease select a folder again.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (Directory.EnumerateFileSystemEntries(subdir).Any())
                    {
                        label12.Text = "Idle";
                        versionDropdown.Enabled = true;
                        serverInstallPathTextBox.Enabled = true;
                        serverPathBrowseButton.Enabled = true;
                        serverInstallButton.Enabled = true;
                        MessageBox.Show("This directory (" + subdir + ") is not empty!\n\nPlease delete all the component of the folder again.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        int parsedValue;
                        if (!int.TryParse(memoryDropdown.Text, out parsedValue))
                        {
                            label12.Text = "Idle";
                            versionDropdown.Enabled = true;
                            serverInstallPathTextBox.Enabled = true;
                            serverPathBrowseButton.Enabled = true;
                            serverInstallButton.Enabled = true;
                            MessageBox.Show("This is not a valid number! (" + memoryDropdown.Text + ")\n\nPlease put the number of MB / GB you want for your server!\n\nDefault: 1024 MB", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        if (memoryMBRadio.Checked == true)
                        {
                            if (int.Parse(memoryDropdown.Text) <= 1000)
                            {
                                DialogResult warn = MessageBox.Show("Attention: You gave " + memoryDropdown.Text + "MB to java. A value under 1000MB is not recommened.\n\nDo you want to continue?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                                if (warn == DialogResult.No)
                                {
                                    label12.Text = "Idle";
                                    versionDropdown.Enabled = true;
                                    serverInstallPathTextBox.Enabled = true;
                                    serverPathBrowseButton.Enabled = true;
                                    serverInstallButton.Enabled = true;
                                    return;
                                }
                            }
                            else if (int.Parse(memoryDropdown.Text) >= 10000)
                            {
                                DialogResult MBOverload = MessageBox.Show("Whoa! " + memoryDropdown.Text + "MB is a lot! We recommend 1000<MB<10000\n\nDo you want to continue?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                                if (MBOverload == DialogResult.No)
                                {
                                    label12.Text = "Idle";
                                    versionDropdown.Enabled = true;
                                    serverInstallPathTextBox.Enabled = true;
                                    serverPathBrowseButton.Enabled = true;
                                    serverInstallButton.Enabled = true;
                                    return;
                                }
                            }
                        }
                        else
                        {
                            if (int.Parse(memoryDropdown.Text) <= 1)
                            {
                                DialogResult warn = MessageBox.Show("Attention: You gave " + memoryDropdown.Text + "GB to java. A value under 1GB is not recommened.\n\nDo you want to continue?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                                if (warn == DialogResult.No)
                                {
                                    label12.Text = "Idle";
                                    versionDropdown.Enabled = true;
                                    serverInstallPathTextBox.Enabled = true;
                                    serverPathBrowseButton.Enabled = true;
                                    serverInstallButton.Enabled = true;
                                    return;
                                }
                            }
                            else if (int.Parse(memoryDropdown.Text) >= 10)
                            {
                                DialogResult MBOverload = MessageBox.Show("Whoa! " + memoryDropdown.Text + "GB is a lot! We recommend 1<GB<10\n\nDo you want to continue?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                                if (MBOverload == DialogResult.No)
                                {
                                    label12.Text = "Idle";
                                    versionDropdown.Enabled = true;
                                    serverInstallPathTextBox.Enabled = true;
                                    serverPathBrowseButton.Enabled = true;
                                    serverInstallButton.Enabled = true;
                                    return;
                                }
                            }
                        }
                        string FileName = serverInstallPathTextBox.Text + @"\ServerRunner_" + versionDropdown.Text + ".jar";
                        if (System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable() == false)
                        {

                            MessageBox.Show("You are not connected to the internet.\n\nWe will not download the jar files but we will generate a Run.bat and a Stop.bat file.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            if (generateBatCheckbox.Checked == true)
                            {
                                using (StreamWriter sw = File.CreateText(serverInstallPathTextBox.Text + @"\" + "Run.bat"))
                                {
                                    if (memoryMBRadio.Checked == true)
                                    {
                                        if (noguiCheckbox.Checked == true)
                                        {

                                            sw.WriteLine("java -Xmx" + memoryDropdown.Text + "M -Xms" + memoryDropdown.Text + "M -jar " + "ServerRunner_" + versionDropdown.Text + ".jar" + " nogui");
                                        }
                                        else
                                        {
                                            sw.WriteLine("java -Xmx" + memoryDropdown.Text + "M -Xms" + memoryDropdown.Text + "M -jar " + "ServerRunner_" + versionDropdown.Text + ".jar");
                                        }
                                        if (pause.Checked == true)
                                        {
                                            sw.WriteLine("PAUSE");
                                        }
                                    }
                                    else
                                    {
                                        if (noguiCheckbox.Checked == true)
                                        {

                                            sw.WriteLine("java -Xmx" + memoryDropdown.Text + "G -Xms" + memoryDropdown.Text + "G -jar " + "ServerRunner_" + versionDropdown.Text + ".jar" + " nogui");
                                        }
                                        else
                                        {
                                            sw.WriteLine("java -Xmx" + memoryDropdown.Text + "G -Xms" + memoryDropdown.Text + "G -jar " + "ServerRunner_" + versionDropdown.Text + ".jar");
                                        }
                                        if (pause.Checked == true)
                                        {
                                            sw.WriteLine("PAUSE");
                                        }
                                    }
                                }
                                using (StreamWriter sw = File.CreateText(serverInstallPathTextBox.Text + @"\" + "Stop.bat"))
                                {
                                    sw.WriteLine("taskkill /IM \"Java.exe\" /F");
                                }
                            }

                            // 1.15 / 1.14 / 1.13 / 1.12 / 1.11 / 1.10 / 1.8.9 / 1.8 / 1.7.10
                            progressBar.Value = 100;
                            versionDropdown.Enabled = true;
                            serverInstallPathTextBox.Enabled = true;
                            serverPathBrowseButton.Enabled = true;
                            serverInstallButton.Enabled = true;
                            label12.Text = "Installing done!";
                            return;
                        }
                        label12.Text = "Downloading: " + serverInstallPathTextBox.Text + "/ServerRunner_" + versionDropdown.Text + ".jar , please wait a few seconds...";
                        progressBar.Value = 40;
                        if (clientDropdown.Text == "Vanilla (Normal Minecraft)")
                        {
                            WebClient client = new WebClient();
                            switch (versionDropdown.Text)
                            {
                                case "1.16.1":
                                    await client.DownloadFileTaskAsync(MinecraftVersion.SixteenOne.URL, FileName);
                                    break;

                                case "1.16":
                                    await client.DownloadFileTaskAsync(MinecraftVersion.Sixteen.URL, FileName);
                                    break;

                                case "1.15.2":
                                    await client.DownloadFileTaskAsync(MinecraftVersion.FifteenTwo.URL, FileName);
                                    break;

                                case "1.15.1":
                                    await client.DownloadFileTaskAsync(MinecraftVersion.FifteenOne.URL, FileName);
                                    break;

                                case "1.15":
                                    await client.DownloadFileTaskAsync(MinecraftVersion.Fifteen.URL, FileName);
                                    break;

                                case "1.14.4":
                                    await client.DownloadFileTaskAsync(MinecraftVersion.FourteenFour.URL, FileName);
                                    break;

                                case "1.14.3":
                                    await client.DownloadFileTaskAsync(MinecraftVersion.FourteenThree.URL, FileName);
                                    break;

                                case "1.14.2":
                                    await client.DownloadFileTaskAsync(MinecraftVersion.FourteenTwo.URL, FileName);
                                    break;

                                case "1.14.1":
                                    await client.DownloadFileTaskAsync(MinecraftVersion.FourteenOne.URL, FileName);
                                    break;

                                case "1.14":
                                    await client.DownloadFileTaskAsync(MinecraftVersion.Fourteen.URL, FileName);
                                    break;

                                case "1.13.2":
                                    await client.DownloadFileTaskAsync(MinecraftVersion.ThirteenTwo.URL, FileName);
                                    break;

                                case "1.13.1":
                                    await client.DownloadFileTaskAsync(MinecraftVersion.ThirteenOne.URL, FileName);
                                    break;

                                case "1.13":
                                    await client.DownloadFileTaskAsync(MinecraftVersion.Thirteen.URL, FileName);
                                    break;

                                case "1.12.2":
                                    await client.DownloadFileTaskAsync(MinecraftVersion.TwelveTwo.URL, FileName);
                                    break;

                                case "1.12.1":
                                    await client.DownloadFileTaskAsync(MinecraftVersion.Twelve.URL, FileName);
                                    break;

                                case "1.12":
                                    await client.DownloadFileTaskAsync(MinecraftVersion.Twelve.URL, FileName);
                                    break;

                                default:
                                    label12.Text = "Error";
                                    break;
                            }
                        }
                        if (clientDropdown.Text == "Spigot (Plugins)")
                        {
                            using (StreamWriter sw = File.CreateText(serverInstallPathTextBox.Text + @"\" + "Spigot.txt"))
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
                            if (versionDropdown.Text == "1.16.1") //  DONE -----
                            {
                                WebClient client = new WebClient();
                                client.DownloadFile(SixteenOne, FileName);
                            }
                            else if (versionDropdown.Text == "1.15.2") //  DONE -----
                            {
                                WebClient client = new WebClient();
                                client.DownloadFile(FifteenTwo, FileName);
                            }
                            else if (versionDropdown.Text == "1.15.1") //  DONE -----
                            {
                                WebClient client = new WebClient();
                                client.DownloadFile(FifteenOne, FileName);
                            }
                            else if (versionDropdown.Text == "1.15") //  DONE -----
                            {
                                WebClient client = new WebClient();
                                client.DownloadFile(Fifteen, FileName);
                            }
                            else if (versionDropdown.Text == "1.14.4")//  DONE -----
                            {
                                WebClient client = new WebClient();
                                client.DownloadFile(FourteenFour, FileName);
                            }
                            else if (versionDropdown.Text == "1.14.3")//  DONE -----
                            {
                                WebClient client = new WebClient();
                                client.DownloadFile(FourteenThree, FileName);
                            }
                            else if (versionDropdown.Text == "1.14.2")//  DONE -----
                            {
                                WebClient client = new WebClient();
                                client.DownloadFile(FourteenTwo, FileName);
                            }
                            else if (versionDropdown.Text == "1.14.1")//  DONE -----
                            {
                                WebClient client = new WebClient();
                                client.DownloadFile(FourteenOne, FileName);
                            }
                            else if (versionDropdown.Text == "1.14")//  DONE -----
                            {
                                WebClient client = new WebClient();
                                client.DownloadFile(Fourteen, FileName);
                            }
                            else if (versionDropdown.Text == "1.13.2")//  DONE -----
                            {
                                WebClient client = new WebClient();
                                client.DownloadFile(ThirteenTwo, FileName);
                            }
                            else if (versionDropdown.Text == "1.13.1")//  DONE -----
                            {
                                WebClient client = new WebClient();
                                client.DownloadFile(Thirteen, FileName);
                            }
                            else if (versionDropdown.Text == "1.13")//  DONE -----
                            {
                                WebClient client = new WebClient();
                                client.DownloadFile(ThirteenOne, FileName);
                            }
                            else if (versionDropdown.Text == "1.12.2")//  DONE -----
                            {
                                WebClient client = new WebClient();
                                client.DownloadFile(TwelveTwo, FileName);
                            }
                            else if (versionDropdown.Text == "1.12.1")//  DONE -----
                            {
                                WebClient client = new WebClient();
                                client.DownloadFile(TwelveOne, FileName);
                            }
                            else if (versionDropdown.Text == "1.12")//  DONE -----
                            {
                                WebClient client = new WebClient();
                                client.DownloadFile(Twelve, FileName);
                            }
                            else if (versionDropdown.Text == "1.11")
                            {
                                WebClient client = new WebClient();
                                client.DownloadFile(Elveven, FileName);
                            }
                            else if (versionDropdown.Text == "1.11.2")
                            {
                                WebClient client = new WebClient();
                                client.DownloadFile(ElvevenTwo, FileName);
                            }
                            else if (versionDropdown.Text == "1.11.1")
                            {
                                WebClient client = new WebClient();
                                client.DownloadFile(ElvevenOne, FileName);
                            }
                            else if (versionDropdown.Text == "1.10.2")
                            {
                                WebClient client = new WebClient();
                                client.DownloadFile(TenTwo, FileName);
                            }
                            else if (versionDropdown.Text == "1.10")
                            {
                                WebClient client = new WebClient();
                                client.DownloadFile(Ten, FileName);
                            }
                            else if (versionDropdown.Text == "1.9.4")
                            {
                                WebClient client = new WebClient();
                                client.DownloadFile(NineFour, FileName);
                            }
                            else if (versionDropdown.Text == "1.9.2")
                            {
                                WebClient client = new WebClient();
                                client.DownloadFile(NineTwo, FileName);
                            }
                            else if (versionDropdown.Text == "1.9")
                            {
                                WebClient client = new WebClient();
                                client.DownloadFile(Nine, FileName);
                            }
                            else if (versionDropdown.Text == "1.8.8")
                            {
                                WebClient client = new WebClient();
                                client.DownloadFile(EightEight, FileName);
                            }
                            else if (versionDropdown.Text == "1.8")
                            {
                                WebClient client = new WebClient();
                                client.DownloadFile(Eight, FileName);
                            }
                            else if (versionDropdown.Text == "1.7.10")
                            {
                                WebClient client = new WebClient();
                                client.DownloadFile(Seven, FileName);
                            }
                            else
                            {
                                label12.Text = "Error";
                            }
                        }
                        using (StreamWriter sw = File.CreateText(serverInstallPathTextBox.Text + @"\" + "server.properties"))
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
                        using (StreamWriter sw = File.CreateText(serverInstallPathTextBox.Text + @"\" + "whitelist.json"))
                        { }
                        using (StreamWriter sw = File.CreateText(serverInstallPathTextBox.Text + @"\" + "tempserver.properties"))
                        { }
                        using (StreamWriter sw = File.CreateText(serverInstallPathTextBox.Text + @"\" + "tempwhitelist.json"))
                        { }

                            // THIS IS SEPERATOR -- THIS IS SEPERATOR -- THIS IS SEPERATOR -- THIS IS SEPERATOR -- THIS IS SEPERATOR -- THIS IS SEPERATOR -- THIS IS SEPERATOR -- 

                            if (label12.Text == "Error")
                        {
                            MessageBox.Show("Please open up an issue on GitHub (https://github.com/The-Diamond-Sword-Productions/Minecraft-Sparkling-Server-Hosting-Tool) with\nthe error code 'ConditionNotMet'.\n\nPlease try choosing another version.", "Critical error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            label12.Text = "Idle";
                        }
                        if (generateBatCheckbox.Checked == true)
                        {
                            using (StreamWriter sw = File.CreateText(serverInstallPathTextBox.Text + @"\" + "Run.bat"))
                            {
                                if (memoryMBRadio.Checked == true)
                                {
                                    if (noguiCheckbox.Checked == true)
                                    {

                                        sw.WriteLine("java -Xmx" + memoryDropdown.Text + "M -Xms" + memoryDropdown.Text + "M -jar " + "ServerRunner_" + versionDropdown.Text + ".jar" + " nogui");
                                    }
                                    else
                                    {
                                        sw.WriteLine("java -Xmx" + memoryDropdown.Text + "M -Xms" + memoryDropdown.Text + "M -jar " + "ServerRunner_" + versionDropdown.Text + ".jar");
                                    }
                                    if (pause.Checked == true)
                                    {
                                        sw.WriteLine("PAUSE");
                                    }
                                }
                                else
                                {
                                    if (noguiCheckbox.Checked == true)
                                    {

                                        sw.WriteLine("java -Xmx" + memoryDropdown.Text + "G -Xms" + memoryDropdown.Text + "G -jar " + "ServerRunner_" + versionDropdown.Text + ".jar" + " nogui");
                                    }
                                    else
                                    {
                                        sw.WriteLine("java -Xmx" + memoryDropdown.Text + "G -Xms" + memoryDropdown.Text + "G -jar " + "ServerRunner_" + versionDropdown.Text + ".jar");
                                    }
                                    if (pause.Checked == true)
                                    {
                                        sw.WriteLine("PAUSE");
                                    }
                                }

                            }
                            using (StreamWriter sw = File.CreateText(serverInstallPathTextBox.Text + @"\" + "Stop.bat"))
                            {
                                sw.WriteLine("taskkill /IM \"Java.exe\" /F");
                            }
                        }
                        // 1.15 / 1.14 / 1.13 / 1.12 / 1.11 / 1.10 / 1.8.9 / 1.8 / 1.7.10
                        progressBar.Value = 100;
                        versionDropdown.Enabled = true;
                        serverInstallPathTextBox.Enabled = true;
                        serverPathBrowseButton.Enabled = true;
                        serverInstallButton.Enabled = true;
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
                serverInstallPathTextBox.Text = folderPath;
            }
        }

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(linkLabel1.Text);
        }

        private void Bat_CheckedChanged(object sender, EventArgs e)
        {
            if (generateBatCheckbox.Checked == true)
            {
                memoryDropdown.Enabled = true;
                noguiCheckbox.Enabled = true;
            }
            else
            {
                memoryDropdown.Enabled = false;
                noguiCheckbox.Enabled = false;
            }
        }

        private void Nogui_CheckedChanged(object sender, EventArgs e)
        {
            if (noguiCheckbox.Checked == true)
            {
                if (clientDropdown.Text == "Vanilla (Normal Minecraft)")
                {
                    DialogResult noguiI = MessageBox.Show("Attention: When enabling this option, you will not see any\nerrors or any output. \n\nAre you sure?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (noguiI == DialogResult.No)
                    {
                        noguiCheckbox.Checked = false;
                    }
                }
            }
        }
        private void Menu_Load(object sender, EventArgs e)
        {
            groupBox2.Visible = false;
            eulaAcceptButton.Visible = false;
            eulaRejectButton.Visible = false;
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
                startStopServerButton.Enabled = false;
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
            serverPathTextBox.Text = serverInstallPathTextBox.Text;
        }

        private void Client_Version_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (memoryGBRadio.Checked == false)
            {
                string Temp = memoryDropdown.Text;
                if (Temp == "0.1")
                {
                    memoryDropdown.Text = "100";
                }
                else if (Temp == "0.2")
                {
                    memoryDropdown.Text = "200";
                }
                else if (Temp == "0.3")
                {
                    memoryDropdown.Text = "300";
                }
                else if (Temp == "0.4")
                {
                    memoryDropdown.Text = "400";
                }
                else if (Temp == "0.5")
                {
                    memoryDropdown.Text = "500";
                }
                else if (Temp == "0.6")
                {
                    memoryDropdown.Text = "600";
                }
                else if (Temp == "0.7")
                {
                    memoryDropdown.Text = "700";
                }
                else if (Temp == "0.8")
                {
                    memoryDropdown.Text = "800";
                }
                else if (Temp == "0.9")
                {
                    memoryDropdown.Text = "900";
                }
                else if (Temp.Length > 0)
                {
                    memoryDropdown.Text = Temp + "000";
                }
                else
                {
                    MessageBox.Show("A conversion error occured.", "Conversion error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                    memoryDropdown.Items.Clear();
                    memoryDropdown.Items.Add("512");
                    memoryDropdown.Items.Add("1024");
                    memoryDropdown.Items.Add("2048");
                    memoryDropdown.Items.Add("3072");
                    memoryDropdown.Items.Add("4096");
                    memoryDropdown.Items.Add("5120");
                    memoryDropdown.Items.Add("6144");
                    memoryDropdown.Items.Add("7168");
                    memoryDropdown.Items.Add("8192");
                    memoryDropdown.Items.Add("9216");
                    memoryDropdown.Items.Add("10240");
                    memoryDropdown.Items.Add("11264");
                    memoryDropdown.Items.Add("12288");
                    memoryDropdown.Items.Add("13312");
                    memoryDropdown.Items.Add("14336");
                    memoryDropdown.Items.Add("15360");
                    memoryDropdown.Items.Add("16384");
                    memoryDropdown.Items.Add("17408");
                    memoryDropdown.Items.Add("18432");
                    memoryDropdown.Items.Add("19456");
                    memoryDropdown.Items.Add("20480");
                }
                else if (memoryMBRadio.Checked == false)
                {
                    string Temp = memoryDropdown.Text;
                if (Temp.Length == 1)
                {
                    Temp = "0.00" + Temp;
                    Temp = Temp.Remove(5);
                }
                else if (Temp.Length == 2)
                {
                    Temp = "0.0" + Temp;
                    Temp = Temp.Remove(4);
                }
                else if (Temp.Length == 3)
                {
                    Temp = "0." + Temp;
                    Temp = Temp.Remove(3);
                }
                else if (Temp.Length == 4)
                {
                    Temp = Temp.Remove(1);
                }
                else if (Temp.Length == 5)
                {
                    Temp = Temp.Remove(2);
                }
                else if (Temp.Length == 6)
                {
                    Temp = Temp.Remove(3);
                }
                else
                {
                    MessageBox.Show("A conversion error occured.", "Conversion error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                    memoryDropdown.Text = Temp;
                    memoryDropdown.Items.Clear();
                    memoryDropdown.Items.Add("0.5");
                    memoryDropdown.Items.Add("1");
                    memoryDropdown.Items.Add("2");
                    memoryDropdown.Items.Add("3");
                    memoryDropdown.Items.Add("4");
                    memoryDropdown.Items.Add("5");
                    memoryDropdown.Items.Add("6");
                    memoryDropdown.Items.Add("7");
                    memoryDropdown.Items.Add("8");
                    memoryDropdown.Items.Add("9");
                    memoryDropdown.Items.Add("10");
                    memoryDropdown.Items.Add("11");
                    memoryDropdown.Items.Add("12");
                    memoryDropdown.Items.Add("13");
                    memoryDropdown.Items.Add("14");
                    memoryDropdown.Items.Add("15");
                    memoryDropdown.Items.Add("16");
                    memoryDropdown.Items.Add("17");
                    memoryDropdown.Items.Add("18");
                    memoryDropdown.Items.Add("19");
                    memoryDropdown.Items.Add("20");
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

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
            eulaAcceptButton.Visible = false;
            eulaRejectButton.Visible = false;
            eulaOkButton.Visible = true;
            linkLabel2.Visible = false;
            startStopServerButton.Text = "Starting...";
            using (StreamWriter sw = File.CreateText(serverPathTextBox.Text + @"\" + "eula.txt"))
            {
                sw.WriteLine("eula = true");
            }
            Status_.Text = "Starting server...";
            Status.Text = "Starting server...";
            string path = serverPathTextBox.Text + @"\";
            var process = new System.Diagnostics.Process();
            process.StartInfo.FileName = path + "Run.bat";
            process.StartInfo.WorkingDirectory = path;
            process.StartInfo.UseShellExecute = true;
            process.Start();
            //process.WaitForExit();
            await Task.Delay(10000);
            label17.Text = "Started";
            startStopServerButton.ForeColor = System.Drawing.Color.Red;
            startStopServerButton.Text = "Stop Server";
            Status_.Text = "Idle";
            Status.Text = "Idle";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Status_.Text = "Idle";
            Status.Text = "Idle";
            groupBox2.Visible = false;
            eulaAcceptButton.Visible = false;
            eulaRejectButton.Visible = false;
            eulaOkButton.Visible = true;
            linkLabel2.Visible = false;
            startStopServerButton.Text = "Start Server";
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(linkLabel2.Text);
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            if (File.Exists(serverPathTextBox.Text + @"\tempserver.properties") == false)
            {
                using (StreamWriter sw = File.CreateText(serverInstallPathTextBox.Text + @"\" + "tempserver.properties"))
                { }
            }
            if (File.Exists(serverPathTextBox.Text + @"\server.properties") == true)
            {
                Status.Text = "Opening server.properties file...";
                Status_.Text = "Opening server.properties file...";
                ServerPropertiesForm frm = new ServerPropertiesForm(serverPathTextBox.Text);
                frm.Show();
                Status.Text = "Idle";
                Status_.Text = "Idle";
            }
            else if (File.Exists(serverPathTextBox.Text + @"\server.properties") == false)
            {
                if (File.Exists(serverPathTextBox.Text + @"\Run.bat") == true)
                {
                    Status.Text = "Generating server.properties file...";
                    Status_.Text = "Generating server.properties file...";
                    using (StreamWriter sw = File.CreateText(serverPathTextBox.Text + @"\" + "server.properties"))
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
                    ServerPropertiesForm frm = new ServerPropertiesForm(serverPathTextBox.Text);
                    frm.Show();
                    Status.Text = "Idle";
                    Status_.Text = "Idle";
                }
            }
            else
            {
                label7.Text = "Cannot find a Server Properties File. \n\nMake sure that there is a server.properties file \n\nin the directory:" + serverPathTextBox.Text;
                groupBox2.Visible = true;
            }
        }

        private void client_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (clientDropdown.Text == "Vanilla (Normal Minecraft)")
            {
                noguiCheckbox.Enabled = true;
                noguiCheckbox.Checked = false;
                noguiWarningLabel.Text = "ATTENTION: We would not change this value! The recommended option is  unchecked.";
                if (versionDropdown.Text == "1.8.8")
                {
                    MessageBox.Show("The 1.8.8 version is not available for Vanilla, so we switched your version to 1.8.9", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    versionDropdown.Text = "1.8.9";
                }
                versionDropdown.Items.Clear();
                versionDropdown.Items.Add("1.16.1");
                versionDropdown.Items.Add("1.16");
                versionDropdown.Items.Add("1.15.2");
                versionDropdown.Items.Add("1.15.1");
                versionDropdown.Items.Add("1.15");
                versionDropdown.Items.Add("1.14.4");
                versionDropdown.Items.Add("1.14.3");
                versionDropdown.Items.Add("1.14.2");
                versionDropdown.Items.Add("1.14.1");
                versionDropdown.Items.Add("1.14");
                versionDropdown.Items.Add("1.13.2");
                versionDropdown.Items.Add("1.13.1");
                versionDropdown.Items.Add("1.13");
                versionDropdown.Items.Add("1.12.2");
                versionDropdown.Items.Add("1.12.1");
                versionDropdown.Items.Add("1.12");
                versionDropdown.Items.Add("1.11.2");
                versionDropdown.Items.Add("1.11.1");
                versionDropdown.Items.Add("1.11");
                versionDropdown.Items.Add("1.10.2");
                versionDropdown.Items.Add("1.10.1");
                versionDropdown.Items.Add("1.10");
                versionDropdown.Items.Add("1.9.4");
                versionDropdown.Items.Add("1.9.3");
                versionDropdown.Items.Add("1.9.2");
                versionDropdown.Items.Add("1.9.1");
                versionDropdown.Items.Add("1.9");
                versionDropdown.Items.Add("1.8.9");
                versionDropdown.Items.Add("1.8");
                versionDropdown.Items.Add("1.7.10");
            }
            else if (clientDropdown.Text == "Spigot (Plugins)")
            {
                noguiCheckbox.Enabled = false;
                noguiCheckbox.Checked = true;
                noguiWarningLabel.Text = "Sadly, this feature doesn't work with spigot, unless the developpers of spigot decide to add it.";
                if (versionDropdown.Text == "1.16")
                {
                    MessageBox.Show("The 1.16 version is sadly not available for Spigot, so we switched your version to 1.16.1.", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    versionDropdown.Text = "1.16.1";
                }
                else if (versionDropdown.Text == "1.10.1")
                {
                    MessageBox.Show("The 1.10.1 version is sadly not available for Spigot, so we switched your version to 1.10.2", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    versionDropdown.Text = "1.10.2";
                }
                else if (versionDropdown.Text == "1.9.3")
                {
                    MessageBox.Show("The 1.9.3 version is sadly not available for Spigot, so we switched your version to 1.9.4", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    versionDropdown.Text = "1.9.4";
                }
                else if (versionDropdown.Text == "1.9.1")
                {
                    MessageBox.Show("The 1.9.1 version is sadly not available for Spigot, so we switched your version to 1.9.2", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    versionDropdown.Text = "1.9.2";
                }
                else if (versionDropdown.Text == "1.8.9")
                {
                    MessageBox.Show("The 1.8.9 version is sadly not available for Spigot, so we switched your version to 1.8.8", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    versionDropdown.Text = "1.8.8";
                }
                versionDropdown.Items.Clear();
                versionDropdown.Items.Add("1.16.1");
                versionDropdown.Items.Add("1.15.2");
                versionDropdown.Items.Add("1.15.1");
                versionDropdown.Items.Add("1.15");
                versionDropdown.Items.Add("1.14.4");
                versionDropdown.Items.Add("1.14.3");
                versionDropdown.Items.Add("1.14.2");
                versionDropdown.Items.Add("1.14.1");
                versionDropdown.Items.Add("1.14");
                versionDropdown.Items.Add("1.13.2");
                versionDropdown.Items.Add("1.13.1");
                versionDropdown.Items.Add("1.13");
                versionDropdown.Items.Add("1.12.2");
                versionDropdown.Items.Add("1.12.1");
                versionDropdown.Items.Add("1.12");
                versionDropdown.Items.Add("1.11.2");
                versionDropdown.Items.Add("1.11.1");
                versionDropdown.Items.Add("1.11");
                versionDropdown.Items.Add("1.10.2");
                versionDropdown.Items.Add("1.10");
                versionDropdown.Items.Add("1.9.4");
                versionDropdown.Items.Add("1.9.2");
                versionDropdown.Items.Add("1.9");
                versionDropdown.Items.Add("1.8.8");
                versionDropdown.Items.Add("1.8");
                versionDropdown.Items.Add("1.7.10");
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
            if (serverPathTextBox.Text == "")
            {
                button14.Enabled = false;
                button3.Enabled = false;
                button15.Enabled = false;
                label13.Text = "Please enter a server path to start your server...";
                label15.Text = "No server found...";
            }
            if (serverPathTextBox.Text != "")
            {
                if (File.Exists(serverPathTextBox.Text + @"\Spigot.txt") == true)
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
                    if (File.Exists(serverPathTextBox.Text + @"\Vanilla.txt") == true)
                    {
                        button14.Text = "Open Server Plugins File (This server is not a Spigot server.)";
                        button3.Enabled = true;
                        button15.Enabled = true;
                        label13.Text = "Found a Vanilla server.";
                        label15.Text = "Running Server On Vanilla.";
                    }
                    else if (File.Exists(serverPathTextBox.Text + @"\Run.bat") == false)
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
            if (File.Exists(serverPathTextBox.Text + @"\Spigot.txt") == true)
            {
                if (Directory.Exists(serverPathTextBox.Text + @"\plugins") == false)
                {
                    Status.Text = "Generating plugins folder...";
                    Status_.Text = "Generating plugins folder...";
                    System.IO.Directory.CreateDirectory(serverPathTextBox.Text + @"\plugins");
                    Status.Text = "Opening plugins folder...";
                    Status_.Text = "Opening plugins folder...";
                    System.Diagnostics.Process.Start("explorer.exe", serverPathTextBox.Text + @"\plugins");
                    Status.Text = "Idle";
                    Status_.Text = "Idle";
                }
                else
                {
                    Status.Text = "Opening plugins folder...";
                    Status_.Text = "Opening plugins folder...";
                    System.Diagnostics.Process.Start("explorer.exe", serverPathTextBox.Text + @"\plugins");
                    Status.Text = "Idle";
                    Status_.Text = "Idle";
                }

            }
            else
            {
                label7.Text = "There is not any server in this path.\n\nMake sure there is a 'server' file in the directory: \n\n" + serverPathTextBox.Text;
                groupBox2.Visible = true;
            }
        }
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (serverPathTextBox.Text == "")
            {
                button14.Enabled = false;
                button3.Enabled = false;
                label13.Text = "Please enter a server path to start your server...";
            }
            if (serverPathTextBox.Text != "")
            {
                if (File.Exists(serverPathTextBox.Text + @"\Spigot.txt") == true)
                {
                    button14.Enabled = true;
                    button3.Enabled = true;
                    label13.Text = "Found a Spigot server.";
                    button14.Text = "Open Server Plugins File";
                }
                else
                {
                    button14.Enabled = false;
                    if (File.Exists(serverPathTextBox.Text + @"\Vanilla.txt") == true)
                    {
                        button14.Text = "Open Server Plugins File (This server is not a Spigot server.)";
                        button3.Enabled = true;
                        label13.Text = "Found a Vanilla server.";
                    }
                    else if (File.Exists(serverPathTextBox.Text + @"\Run.bat") == false)
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
            if (File.Exists(serverPathTextBox.Text + @"\Vanilla.txt") == true)
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
            if (File.Exists(serverPathTextBox.Text + @"\tempwhitelist.json") == false)
            {
                using (StreamWriter sw = File.CreateText(serverPathTextBox.Text + @"\" + "tempwhitelist.json"))
                { }
            }
                if (File.Exists(serverPathTextBox.Text + @"\whitelist.json") == true)
            {
                Status.Text = "Opening whitelist file...";
                Status_.Text = "Opening whitelist file...";
                WhitelistForm frm = new WhitelistForm(serverPathTextBox.Text);
                frm.Show();
                Status.Text = "Idle";
                Status_.Text = "Idle";
            }
            else if (File.Exists(serverPathTextBox.Text + @"\whitelist.json") == false)
            {
                if (File.Exists(serverPathTextBox.Text + @"\Run.bat") == true)
                {
                    Status.Text = "Generating whitelist file...";
                    Status_.Text = "Generating whitelist file...";
                    using (StreamWriter sw = File.CreateText(serverPathTextBox.Text + @"\" + "whitelist.json"))
                    { }
                    Status.Text = "Opening whitelist file...";
                    Status_.Text = "Opening whitelist file...";
                    WhitelistForm frm = new WhitelistForm(serverPathTextBox.Text);
                    frm.Show();
                    Status.Text = "Idle";
                    Status_.Text = "Idle";
                }
            }
            else
            {
                label7.Text = "Cannot find a Server whitelist File. \n\nMake sure that there is a whitelist.json file \n\nin the directory:" + serverPathTextBox.Text;
                groupBox2.Visible = true;
            }
        }

        private void OnPathChanged(object sender, EventArgs e)
        {
            ServerDirectory = serverPathTextBox.Text;
        }
    }
}
            