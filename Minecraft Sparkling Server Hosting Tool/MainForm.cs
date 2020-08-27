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

namespace Minecraft_Sparkling_Server_Hosting_Tool
{
    public partial class MainForm : Form
    {

        private bool init = false;
        private string serverDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\MinecraftServer\\";
        public string ServerDirectory
        {
            get => serverDirectory;
            set
            {
                serverDirectory = value;
                if (init)
                    ServerDirectoryChanged();
            }
        }
        public string actualClient;
        public string actualVersion;

        public MainForm()
        {
            InitializeComponent();

            serverRunPathTextBox.Text = ServerDirectory;
            serverInstallPathTextBox.Text = ServerDirectory;

            init = true;
        }

        private async void Button2_Click(object sender, EventArgs e)
        {
            if (startStopServerButton.Text == "Start Server")
            {
                startStopServerButton.Text = "Starting...";
                if (File.Exists(ServerDirectory + @"\Run.bat") == false)
                {
                    label7.Text = "Cannot find a server run file.\n\nMake sure there is a 'Run.bat' file in the directory: \n\n" + ServerDirectory;
                    groupBox2.Visible = true;
                    startStopServerButton.Text = "Start Server";
                }
                else
                {
                    if (File.Exists(ServerDirectory + @"\eula.txt") == false)
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
                        string path = ServerDirectory + @"\";
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
                if (File.Exists(ServerDirectory + @"\Stop.bat") == false)
                {
                    label7.Text = "Cannot find a server stop file. You can alternatively close the console window.\n\nMake sure there is a 'Stop.bat' file in the directory: \n\n" + ServerDirectory;
                    groupBox2.Visible = true;
                    startStopServerButton.Text = "Stop Server";
                }
                else
                {
                    label17.Text = "Stopping...";
                    label17.ForeColor = System.Drawing.Color.Red;
                    Status_.Text = "Stopping server...";
                    Status.Text = "Stopping server...";
                    string path = ServerDirectory + @"\";
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

        private void OnInstallBrowseClick(object sender, EventArgs e)
        {
            var dialog = new CommonOpenFileDialog() { IsFolderPicker = true };
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                ServerDirectory = dialog.FileName;
            }
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            var dialog = new CommonOpenFileDialog() { IsFolderPicker = true };
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                ServerDirectory = dialog.FileName;
            }
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            MessageBox.Show("MIT License\n\nCopyright (c) 2020 The-Diamond-Sword-Productions\n\nPermission is hereby granted, free of charge, to any person obtaining a copy\nof this software and associated documentation files (the 'Software'), to deal\nin the Software without restriction, including without limitation the rights\nto use, copy, modify, merge, publish, distribute, sublicense, and/or sell\ncopies of the Software, and to permit persons to whom the Software is\nfurnished to do so, subject to the following conditions:\n\nThe above copyright notice and this permission notice shall be included in all\ncopies or substantial portions of the Software.\n\nTHE SOFTWARE IS PROVIDED 'AS IS', WITHOUT WARRANTY OF ANY KIND, EXPRESS OR\nIMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,\nFITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE\nAUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER\nLIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,\nOUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE\nSOFTWARE.", "Licence");
        }

        private async void OnInstallServerButtonClick(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(ServerDirectory) &&
                !Directory.Exists(ServerDirectory))
            {
                MessageBox.Show("The current directory is invalid. Please select a valid directory", "Invalid Install Directory", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }


            DialogResult result = MessageBox.Show("You are about to install Minecraft Server " + versionDropdown.Text + " at " + serverInstallPathTextBox.Text + ". \n\nAre you sure?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result != DialogResult.Yes) return;

            label12.Text = "Checking given directory...";
            label12.Text = "Idle";
            versionDropdown.Enabled = false;
            serverInstallPathTextBox.Enabled = false;
            serverPathBrowseButton.Enabled = false;
            serverInstallButton.Enabled = false;
            generateBatCheckbox.Enabled = false;
            noguiCheckbox.Enabled = false;
            memoryDropdown.Enabled = false;
            clientDropdown.Enabled = false;
            memoryMBRadio.Enabled = false;
            memoryGBRadio.Enabled = false;
            string subdir = serverInstallPathTextBox.Text;

            if (!Directory.Exists(subdir))
            {
                label12.Text = "Idle";
                versionDropdown.Enabled = true;
                serverInstallPathTextBox.Enabled = true;
                serverPathBrowseButton.Enabled = true;
                serverInstallButton.Enabled = true;
                generateBatCheckbox.Enabled = true;
                noguiCheckbox.Enabled = true;
                memoryDropdown.Enabled = true;
                clientDropdown.Enabled = true;
                memoryMBRadio.Enabled = true;
                memoryGBRadio.Enabled = true;
                MessageBox.Show("This directory (" + subdir + ") does not exist.\n\nPlease select a folder again.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (Directory.EnumerateFileSystemEntries(subdir).Any())
            {
                label12.Text = "Idle";
                versionDropdown.Enabled = true;
                serverInstallPathTextBox.Enabled = true;
                serverPathBrowseButton.Enabled = true;
                serverInstallButton.Enabled = true;
                generateBatCheckbox.Enabled = true;
                noguiCheckbox.Enabled = true;
                memoryDropdown.Enabled = true;
                clientDropdown.Enabled = true;
                memoryMBRadio.Enabled = true;
                memoryGBRadio.Enabled = true;
                MessageBox.Show("This directory (" + subdir + ") is not empty!\n\nPlease delete all the contents of the folder.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(memoryDropdown.Text, out int parsedValue))
            {
                label12.Text = "Idle";
                versionDropdown.Enabled = true;
                serverInstallPathTextBox.Enabled = true;
                serverPathBrowseButton.Enabled = true;
                serverInstallButton.Enabled = true;
                generateBatCheckbox.Enabled = true;
                noguiCheckbox.Enabled = true;
                memoryDropdown.Enabled = true;
                clientDropdown.Enabled = true;
                memoryMBRadio.Enabled = true;
                memoryGBRadio.Enabled = true;
                MessageBox.Show("This is not a valid number! (" + memoryDropdown.Text + ")\n\nPlease put the number of MB / GB you want for your server!\n\nDefault: 1024 MB", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int memoryAmount = int.Parse(memoryDropdown.Text);
            bool useMegabytes = memoryMBRadio.Checked;

            if (useMegabytes && memoryAmount <= 1000)
            {
                DialogResult warn = MessageBox.Show("Attention: You gave " + memoryDropdown.Text + "MB to java. A value under 1000MB is not recommened.\n\nDo you want to continue?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (warn == DialogResult.No)
                {
                    label12.Text = "Idle";
                    versionDropdown.Enabled = true;
                    serverInstallPathTextBox.Enabled = true;
                    serverPathBrowseButton.Enabled = true;
                    serverInstallButton.Enabled = true;
                    generateBatCheckbox.Enabled = true;
                    noguiCheckbox.Enabled = true;
                    memoryDropdown.Enabled = true;
                    clientDropdown.Enabled = true;
                    memoryMBRadio.Enabled = true;
                    memoryGBRadio.Enabled = true;
                    return;
                }
            }

            if (useMegabytes && memoryAmount >= 10000)
            {
                DialogResult MBOverload = MessageBox.Show("Whoa! " + memoryDropdown.Text + "MB is a lot and is not recommended! \n\nDo you want to continue?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (MBOverload == DialogResult.No)
                {
                    label12.Text = "Idle";
                    versionDropdown.Enabled = true;
                    serverInstallPathTextBox.Enabled = true;
                    serverPathBrowseButton.Enabled = true;
                    serverInstallButton.Enabled = true;
                    generateBatCheckbox.Enabled = true;
                    noguiCheckbox.Enabled = true;
                    memoryDropdown.Enabled = true;
                    clientDropdown.Enabled = true;
                    memoryMBRadio.Enabled = true;
                    memoryGBRadio.Enabled = true;
                    return;
                }
            }

            if (!useMegabytes && memoryAmount <= 1)
            {
                DialogResult warn = MessageBox.Show("Attention: You gave " + memoryDropdown.Text + "GB to java. A value under 1GB is not recommened.\n\nDo you want to continue?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (warn == DialogResult.No)
                {
                    label12.Text = "Idle";
                    versionDropdown.Enabled = true;
                    serverInstallPathTextBox.Enabled = true;
                    serverPathBrowseButton.Enabled = true;
                    serverInstallButton.Enabled = true;
                    generateBatCheckbox.Enabled = true;
                    noguiCheckbox.Enabled = true;
                    memoryDropdown.Enabled = true;
                    clientDropdown.Enabled = true;
                    memoryMBRadio.Enabled = true;
                    memoryGBRadio.Enabled = true;
                    return;
                }
            }
            if (!useMegabytes && memoryAmount >= 10)
            {
                DialogResult MBOverload = MessageBox.Show("Whoa! " + memoryDropdown.Text + "GB is a lot! We recommend 1<GB<10\n\nDo you want to continue?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (MBOverload == DialogResult.No)
                {
                    label12.Text = "Idle";
                    versionDropdown.Enabled = true;
                    serverInstallPathTextBox.Enabled = true;
                    serverPathBrowseButton.Enabled = true;
                    serverInstallButton.Enabled = true;
                    generateBatCheckbox.Enabled = true;
                    noguiCheckbox.Enabled = true;
                    memoryDropdown.Enabled = true;
                    clientDropdown.Enabled = true;
                    memoryMBRadio.Enabled = true;
                    memoryGBRadio.Enabled = true;
                    return;
                }
            }

            string JarFileName = ServerDirectory + @"\ServerRunner_" + versionDropdown.Text + ".jar";

            if (!NetworkInterface.GetIsNetworkAvailable())
            {
                MessageBox.Show("You are not connected to the internet. Please check you connection and try again.", "Network Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }



            WebClient client = new WebClient();
            client.DownloadProgressChanged += (o, args) =>
            {
                label12.Text = "Downloading: " + versionDropdown.Text + " server file , please wait..." + args.ProgressPercentage + "%";
                progressBar.Value = args.ProgressPercentage;
            };

            if (clientDropdown.Text == "Vanilla (Normal Minecraft)")
            {
                using (StreamWriter sw = File.CreateText(serverInstallPathTextBox.Text + @"\" + "data.mssht"))
                {
                    await sw.WriteLineAsync("Vanilla");
                    await sw.WriteLineAsync(versionDropdown.Text);
                    await sw.WriteLineAsync("Please do not edit this file, or MSSHT could give you an error.");
                }
                switch (versionDropdown.Text)
                {
                    case "1.16.1":
                        await client.DownloadFileTaskAsync(MinecraftVersion.SixteenOne.URL, JarFileName);
                        break;

                    case "1.16":
                        await client.DownloadFileTaskAsync(MinecraftVersion.Sixteen.URL, JarFileName);
                        break;

                    case "1.15.2":
                        await client.DownloadFileTaskAsync(MinecraftVersion.FifteenTwo.URL, JarFileName);
                        break;

                    case "1.15.1":
                        await client.DownloadFileTaskAsync(MinecraftVersion.FifteenOne.URL, JarFileName);
                        break;

                    case "1.15":
                        await client.DownloadFileTaskAsync(MinecraftVersion.Fifteen.URL, JarFileName);
                        break;

                    case "1.14.4":
                        await client.DownloadFileTaskAsync(MinecraftVersion.FourteenFour.URL, JarFileName);
                        break;

                    case "1.14.3":
                        await client.DownloadFileTaskAsync(MinecraftVersion.FourteenThree.URL, JarFileName);
                        break;

                    case "1.14.2":
                        await client.DownloadFileTaskAsync(MinecraftVersion.FourteenTwo.URL, JarFileName);
                        break;

                    case "1.14.1":
                        await client.DownloadFileTaskAsync(MinecraftVersion.FourteenOne.URL, JarFileName);
                        break;

                    case "1.14":
                        await client.DownloadFileTaskAsync(MinecraftVersion.Fourteen.URL, JarFileName);
                        break;

                    case "1.13.2":
                        await client.DownloadFileTaskAsync(MinecraftVersion.ThirteenTwo.URL, JarFileName);
                        break;

                    case "1.13.1":
                        await client.DownloadFileTaskAsync(MinecraftVersion.ThirteenOne.URL, JarFileName);
                        break;

                    case "1.13":
                        await client.DownloadFileTaskAsync(MinecraftVersion.Thirteen.URL, JarFileName);
                        break;

                    case "1.12.2":
                        await client.DownloadFileTaskAsync(MinecraftVersion.TwelveTwo.URL, JarFileName);
                        break;

                    case "1.12.1":
                        await client.DownloadFileTaskAsync(MinecraftVersion.Twelve.URL, JarFileName);
                        break;

                    case "1.12":
                        await client.DownloadFileTaskAsync(MinecraftVersion.Twelve.URL, JarFileName);
                        break;

                    case "1.11.2":
                        await client.DownloadFileTaskAsync(MinecraftVersion.ElevenTwo.URL, JarFileName);
                        break;

                    case "1.11.1":
                        await client.DownloadFileTaskAsync(MinecraftVersion.ElevenOne.URL, JarFileName);
                        break;

                    case "1.11":
                        await client.DownloadFileTaskAsync(MinecraftVersion.Eleven.URL, JarFileName);
                        break;

                    case "1.10.2":
                        await client.DownloadFileTaskAsync(MinecraftVersion.TenTwo.URL, JarFileName);
                        break;

                    case "1.10.1":
                        await client.DownloadFileTaskAsync(MinecraftVersion.TenOne.URL, JarFileName);
                        break;

                    case "1.10":
                        await client.DownloadFileTaskAsync(MinecraftVersion.Ten.URL, JarFileName);
                        break;

                    case "1.9.4":
                        await client.DownloadFileTaskAsync(MinecraftVersion.NineFour.URL, JarFileName);
                        break;

                    case "1.9.3":
                        await client.DownloadFileTaskAsync(MinecraftVersion.NineThree.URL, JarFileName);
                        break;

                    case "1.9.2":
                        await client.DownloadFileTaskAsync(MinecraftVersion.NineTwo.URL, JarFileName);
                        break;

                    case "1.9.1":
                        await client.DownloadFileTaskAsync(MinecraftVersion.NineOne.URL, JarFileName);
                        break;

                    case "1.9":
                        await client.DownloadFileTaskAsync(MinecraftVersion.Nine.URL, JarFileName);
                        break;

                    case "1.8.9":
                        await client.DownloadFileTaskAsync(MinecraftVersion.EightNine.URL, JarFileName);
                        break;

                    case "1.8":
                        await client.DownloadFileTaskAsync(MinecraftVersion.Eight.URL, JarFileName);
                        break;

                    case "1.7":
                        await client.DownloadFileTaskAsync(MinecraftVersion.Seven.URL, JarFileName);
                        break;

                    default:
                        label12.Text = "Minecraft Version is Unavailable";
                        break;
                }
            }
            if (clientDropdown.Text == "Spigot (Plugins)")
            {
                using (StreamWriter sw = File.CreateText(serverInstallPathTextBox.Text + @"\" + "data.mssht"))
                {
                    await sw.WriteLineAsync("Spigot");
                    await sw.WriteLineAsync(versionDropdown.Text);
                    await sw.WriteLineAsync("Please do not edit this file, or MSSHT could give you an error.");
                }
                switch (versionDropdown.Text)
                {
                    case "1.16.1":
                        await client.DownloadFileTaskAsync(SpigotVersion.SixteenOne.URL, JarFileName);
                        break;

                    case "1.15.2":
                        await client.DownloadFileTaskAsync(SpigotVersion.FifteenTwo.URL, JarFileName);
                        break;

                    case "1.15.1":
                        await client.DownloadFileTaskAsync(SpigotVersion.FifteenOne.URL, JarFileName);
                        break;

                    case "1.15":
                        await client.DownloadFileTaskAsync(SpigotVersion.Fifteen.URL, JarFileName);
                        break;

                    case "1.14.4":
                        await client.DownloadFileTaskAsync(SpigotVersion.FourteenFour.URL, JarFileName);
                        break;

                    case "1.14.3":
                        await client.DownloadFileTaskAsync(SpigotVersion.FourteenThree.URL, JarFileName);
                        break;

                    case "1.14.2":
                        await client.DownloadFileTaskAsync(SpigotVersion.FourteenTwo.URL, JarFileName);
                        break;

                    case "1.14.1":
                        await client.DownloadFileTaskAsync(SpigotVersion.FourteenOne.URL, JarFileName);
                        break;

                    case "1.14":
                        await client.DownloadFileTaskAsync(SpigotVersion.Fourteen.URL, JarFileName);
                        break;

                    case "1.13.2":
                        await client.DownloadFileTaskAsync(SpigotVersion.ThirteenTwo.URL, JarFileName);
                        break;

                    case "1.13.1":
                        await client.DownloadFileTaskAsync(SpigotVersion.ThirteenOne.URL, JarFileName);
                        break;

                    case "1.13":
                        await client.DownloadFileTaskAsync(SpigotVersion.Thirteen.URL, JarFileName);
                        break;

                    case "1.12.2":
                        await client.DownloadFileTaskAsync(SpigotVersion.TwelveTwo.URL, JarFileName);
                        break;

                    case "1.12.1":
                        await client.DownloadFileTaskAsync(SpigotVersion.TwelveOne.URL, JarFileName);
                        break;

                    case "1.12":
                        await client.DownloadFileTaskAsync(SpigotVersion.Twelve.URL, JarFileName);
                        break;

                    case "1.11.2":
                        await client.DownloadFileTaskAsync(SpigotVersion.ElevenTwo.URL, JarFileName);
                        break;

                    case "1.11.1":
                        await client.DownloadFileTaskAsync(SpigotVersion.ElevenOne.URL, JarFileName);
                        break;

                    case "1.11":
                        await client.DownloadFileTaskAsync(SpigotVersion.Eleven.URL, JarFileName);
                        break;

                    case "1.10.2":
                        await client.DownloadFileTaskAsync(SpigotVersion.TenTwo.URL, JarFileName);
                        break;

                    case "1.10.1":
                        await client.DownloadFileTaskAsync(SpigotVersion.TenOne.URL, JarFileName);
                        break;

                    case "1.9.4":
                        await client.DownloadFileTaskAsync(SpigotVersion.NineFour.URL, JarFileName);
                        break;

                    case "1.9.2":
                        await client.DownloadFileTaskAsync(SpigotVersion.NineTwo.URL, JarFileName);
                        break;

                    case "1.9":
                        await client.DownloadFileTaskAsync(SpigotVersion.Nine.URL, JarFileName);
                        break;

                    case "1.8.9":
                        await client.DownloadFileTaskAsync(SpigotVersion.EightEight.URL, JarFileName);
                        break;

                    case "1.8":
                        await client.DownloadFileTaskAsync(SpigotVersion.Eight.URL, JarFileName);
                        break;

                    case "1.7":
                        await client.DownloadFileTaskAsync(SpigotVersion.SevenTen.URL, JarFileName);
                        break;

                    default:
                        label12.Text = "Spigot Version is Unavailable";
                        break;
                }
            }
            using (StreamWriter sw = File.CreateText(serverInstallPathTextBox.Text + @"\" + "server.properties"))
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
            File.Create(ServerDirectory + @"\" + "server.properties");
            using (StreamWriter sw = File.CreateText(serverInstallPathTextBox.Text + @"\" + "tempserver.properties"))
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
            File.Create(ServerDirectory + @"\" + "whitelist.json");
            File.Create(ServerDirectory + @"\" + "ops.json");

            // THIS IS SEPERATOR -- THIS IS SEPERATOR -- THIS IS SEPERATOR -- THIS IS SEPERATOR -- THIS IS SEPERATOR -- THIS IS SEPERATOR -- THIS IS SEPERATOR -- 

            if (label12.Text == "Error")
            {
                MessageBox.Show("Please open up an issue on GitHub (https://github.com/The-Diamond-Sword-Productions/Minecraft-Sparkling-Server-Hosting-Tool) with\nthe error code 'InvalidServerVersion'.\n\nPlease try choosing another version.", "Critical error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                label12.Text = "Idle";
            }
            if (generateBatCheckbox.Checked == true)
            {
                using (StreamWriter sw = File.CreateText(serverInstallPathTextBox.Text + @"\" + "Run.bat"))
                {

                    await sw.WriteLineAsync($"java -Xmx{memoryDropdown.Text}{(memoryMBRadio.Checked ? "M" : "G")} -Xms{memoryDropdown.Text}{(memoryMBRadio.Checked ? "M" : "G")} -jar ServerRunner_{versionDropdown.Text}.jar {(noguiCheckbox.Checked ? "nogui" : "")}");

                    if (pause.Checked) await sw.WriteLineAsync("PAUSE");
                }

                using (StreamWriter sw = File.CreateText(serverInstallPathTextBox.Text + @"\" + "Stop.bat"))
                {
                    await sw.WriteLineAsync("taskkill /IM \"Java.exe\" /F");
                }
            }
            // 1.15 / 1.14 / 1.13 / 1.12 / 1.11 / 1.10 / 1.8.9 / 1.8 / 1.7.10
            progressBar.Value = 100;
            versionDropdown.Enabled = true;
            serverInstallPathTextBox.Enabled = true;
            serverPathBrowseButton.Enabled = true;
            serverInstallButton.Enabled = true;
            generateBatCheckbox.Enabled = true;
            noguiCheckbox.Enabled = true;
            memoryDropdown.Enabled = true;
            clientDropdown.Enabled = true;
            memoryMBRadio.Enabled = true;
            memoryGBRadio.Enabled = true;
            label12.Text = "Installing done!";
            // 1.15 / 1.14 / 1.13 / 1.12 / 1.11 / 1.10 / 1.8.9 / 1.8 / 1.7.10
            // THIS IS SEPERATOR -- THIS IS SEPERATOR -- THIS IS SEPERATOR -- THIS IS SEPERATOR -- THIS IS SEPERATOR -- THIS IS SEPERATOR -- THIS IS SEPERATOR -- 
            // THIS IS SEPERATOR -- THIS IS SEPERATOR -- THIS IS SEPERATOR -- THIS IS SEPERATOR -- THIS IS SEPERATOR -- THIS IS SEPERATOR -- THIS IS SEPERATOR -- 
        }

        private void Button5_Click_1(object sender, EventArgs e)
        {
            var dialog = new CommonOpenFileDialog() { IsFolderPicker = true };
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                ServerDirectory = dialog.FileName;
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
            clientDropdown.SelectedItem = "Vanilla (Normal Minecraft)";
            versionDropdown.SelectedItem = "1.16.1";
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
            using (StreamWriter sw = File.CreateText(ServerDirectory + @"\" + "eula.txt"))
            {
                sw.WriteLine("eula = true");
            }
            Status_.Text = "Starting server...";
            Status.Text = "Starting server...";
            string path = ServerDirectory + @"\";
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
            if (!File.Exists(ServerDirectory + @"\tempserver.properties"))
            {
                File.Create(ServerDirectory + @"\" + "tempserver.properties").Close();
            }

            if (File.Exists(ServerDirectory + @"\server.properties"))
            {
                Status.Text = "Opening server.properties file...";
                Status_.Text = "Opening server.properties file...";
                ServerPropertiesForm frm = new ServerPropertiesForm(ServerDirectory);
                frm.ShowDialog();
                Status.Text = "Idle";
                Status_.Text = "Idle";
            }

            if (!File.Exists(ServerDirectory + @"\server.properties"))
            {
                if (File.Exists(ServerDirectory + @"\Run.bat") != true) return;

                Status.Text = "Generating server.properties file...";
                Status_.Text = "Generating server.properties file...";

                using (StreamWriter sw = File.CreateText(ServerDirectory + @"\" + "server.properties"))
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
                ServerPropertiesForm frm = new ServerPropertiesForm(ServerDirectory);
                frm.ShowDialog();
                Status.Text = "Idle";
                Status_.Text = "Idle";
            }
            else
            {
                label7.Text = "Cannot find a Server Properties File. \n\nMake sure that there is a server.properties file \n\nin the directory:" + ServerDirectory;
                groupBox2.Visible = true;
            }
        }

        public string latest;
        private void client_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (versionDropdown.SelectedItem != null)
                latest = versionDropdown.SelectedItem.ToString();
            if (clientDropdown.Text == "Vanilla (Normal Minecraft)")
            {
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
                noguiCheckbox.Enabled = true;
                noguiCheckbox.Checked = false;
                noguiWarningLabel.Text = "ATTENTION: We would not change this value! The recommended option is  unchecked.";
                versionDropdown.SelectedItem = latest;
                if (versionDropdown.Text == "1.8.8")
                {
                    MessageBox.Show("The 1.8.8 version is not available for Vanilla, so we switched your version to 1.8.9", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    versionDropdown.SelectedItem = "1.8.9";
                }
            }
            else if (clientDropdown.Text == "Spigot (Plugins)")
            {
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
                noguiCheckbox.Enabled = false;
                noguiCheckbox.Checked = true;
                noguiWarningLabel.Text = "Sadly, this feature doesn't work with spigot, unless the developpers of spigot decide to add it.";
                versionDropdown.SelectedItem = latest;
                if (versionDropdown.Text == "1.16")
                {
                    MessageBox.Show("The 1.16 version is sadly not available for Spigot, so we switched your version to 1.16.1.", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    versionDropdown.SelectedItem = "1.16.1";
                }
                else if (versionDropdown.Text == "1.10.1")
                {
                    MessageBox.Show("The 1.10.1 version is sadly not available for Spigot, so we switched your version to 1.10.2", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    versionDropdown.SelectedItem = "1.10.2";
                }
                else if (versionDropdown.Text == "1.9.3")
                {
                    MessageBox.Show("The 1.9.3 version is sadly not available for Spigot, so we switched your version to 1.9.4", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    versionDropdown.SelectedItem = "1.9.4";
                }
                else if (versionDropdown.Text == "1.9.1")
                {
                    MessageBox.Show("The 1.9.1 version is sadly not available for Spigot, so we switched your version to 1.9.2", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    versionDropdown.SelectedItem = "1.9.2";
                }
                else if (versionDropdown.Text == "1.8.9")
                {
                    MessageBox.Show("The 1.8.9 version is sadly not available for Spigot, so we switched your version to 1.8.8", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    versionDropdown.SelectedItem = "1.8.8";
                }
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

        private void button14_Click(object sender, EventArgs e)
        {
            if (File.Exists(ServerDirectory + @"\Spigot.txt") == true)
            {
                if (Directory.Exists(ServerDirectory + @"\plugins") == false)
                {
                    Status.Text = "Generating plugins folder...";
                    Status_.Text = "Generating plugins folder...";
                    System.IO.Directory.CreateDirectory(ServerDirectory + @"\plugins");
                    Status.Text = "Opening plugins folder...";
                    Status_.Text = "Opening plugins folder...";
                    PluginsForm frm = new PluginsForm(this);
                    frm.Show();
                    Status.Text = "Idle";
                    Status_.Text = "Idle";
                }
                else
                {
                    Status.Text = "Opening plugins folder...";
                    Status_.Text = "Opening plugins folder...";
                    PluginsForm frm = new PluginsForm(this);
                    frm.Show();
                    Status.Text = "Idle";
                    Status_.Text = "Idle";
                }

            }
            else
            {
                label7.Text = "There is not any server in this path.\n\nMake sure there is a 'server' file in the directory: \n\n" + ServerDirectory;
                groupBox2.Visible = true;
            }
        }
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ServerDirectory = serverRunPathTextBox.Text;
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (File.Exists(ServerDirectory + @"\Vanilla.txt") == true)
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
            if (File.Exists(ServerDirectory + @"\whitelist.json") == true)
            {
                Status.Text = "Opening whitelist file...";
                Status_.Text = "Opening whitelist file...";
                WhitelistForm frm = new WhitelistForm(this);
                frm.ShowDialog();
                Status.Text = "Idle";
                Status_.Text = "Idle";
            }
            else if (File.Exists(ServerDirectory + @"\whitelist.json") == false)
            {
                if (File.Exists(ServerDirectory + @"\Run.bat"))
                {
                    Status.Text = "Generating whitelist file...";
                    Status_.Text = "Generating whitelist file...";
                    File.Create(ServerDirectory + @"\" + "whitelist.json");
                    Status.Text = "Opening whitelist file...";
                    Status_.Text = "Opening whitelist file...";
                    WhitelistForm frm = new WhitelistForm(this);
                    frm.ShowDialog();
                    Status.Text = "Idle";
                    Status_.Text = "Idle";
                }
            }
            else
            {
                label7.Text = "Cannot find a Server whitelist File. \n\nMake sure that there is a whitelist.json file \n\nin the directory:" + ServerDirectory;
                groupBox2.Visible = true;
            }
        }

        private void ServerDirectoryChanged()
        {
            if (File.Exists(serverDirectory + "\\data.mssht"))
            {
                actualClient = File.ReadLines(serverDirectory + "\\data.mssht").Skip(0).Take(1).First();
                actualVersion = File.ReadLines(serverDirectory + "\\data.mssht").Skip(1).Take(1).First();
            }
            serverRunPathTextBox.Text = ServerDirectory;
            serverInstallPathTextBox.Text = ServerDirectory;

            if (string.IsNullOrWhiteSpace(ServerDirectory))
            {
                button14.Enabled = false;
                button3.Enabled = false;
                button15.Enabled = false;
                button1.Enabled = false;
                button3.Text = "Open Server properties";
                label13.Text = "Please enter a server path to start your server...";
                label15.Text = "No server found...";
            }
            else
            {
                label15.Text = "Server client: " + actualClient + "\nServer version :" + actualVersion;
                if (File.Exists(serverDirectory + "\\data.mssht"))
                {
                    label13.Text = "Server Found!";
                    button14.Enabled = true;
                    button3.Enabled = true;
                    button15.Enabled = true;
                }
                if (actualClient == "Spigot")
                {
                    button1.Enabled = true;
                    button3.Text = "Open Server properties";
                    button14.Text = "Open Server Plugins File";
                }

                else if (actualClient == "Vanilla")
                {
                    button14.Text = "Open Server Plugins File (This server is not a Spigot server.)";
                    button14.Enabled = false;
                    button3.Text = "Open Server properties";
                }
                else if (File.Exists(ServerDirectory + @"\Run.bat"))
                {
                    label13.Text = "Server Found!";
                    button14.Enabled = true;
                    button3.Enabled = true;
                    button15.Enabled = true;
                    button1.Enabled = true;
                    button3.Text = "Open Server properties";
                    label15.Text = "Server Found";
                    button3.Text = "Open Server properties (Unregistered Server)";
                    button3.Enabled = false;
                    button14.Text = "Open Server Plugins File (Unregistered Server)";
                }
                else
                {
                    label13.Text = "This path doesn't contain any minecraft server.";
                    button14.Enabled = false;
                    button3.Enabled = false;
                    button15.Enabled = false;
                    button1.Enabled = false;
                    button3.Text = "Open Server properties";
                    label15.Text = "No server found...";
                }
            }
        }

        private void OnInstallPathChanged(object sender, EventArgs e)
        {
            ServerDirectory = serverInstallPathTextBox.Text;
        }

        private void OnRunPathChanged(object sender, EventArgs e)
        {
            ServerDirectory = serverRunPathTextBox.Text;
            if (File.Exists(ServerDirectory + @"\Run.bat"))
            {
                if (File.Exists(ServerDirectory + @"\Vanilla.txt"))
                {}
                else if (File.Exists(ServerDirectory + @"\Spigot.txt"))
                {}
                else
                {
                    DialogResult Result = MessageBox.Show("This server has not been created with Minecraft Sparkling Server Hosting Tool. Would you like to make it compatible with our tool? If not, you might not have all the features we offer in this tool.", "Invalid Server", MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
                    if (Result == DialogResult.Yes)
                    {
                        ServerCompatibleForm frm = new ServerCompatibleForm(this);
                        frm.ShowDialog();
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (File.Exists(ServerDirectory + @"\ops.json") == true)
            {
                Status.Text = "Opening ops file...";
                Status_.Text = "Opening ops file...";
                OpsForm frm = new OpsForm(this);
                frm.ShowDialog();
                Status.Text = "Idle";
                Status_.Text = "Idle";
            }
            else if (File.Exists(ServerDirectory + @"\ops.json") == false)
            {
                if (File.Exists(ServerDirectory + @"\Run.bat"))
                {
                    Status.Text = "Generating ops file...";
                    Status_.Text = "Generating ops file...";
                    File.Create(ServerDirectory + @"\" + "ops.json");
                    Status.Text = "Opening ops file...";
                    Status_.Text = "Opening ops file...";
                    OpsForm frm = new OpsForm(this);
                    frm.ShowDialog();
                    Status.Text = "Idle";
                    Status_.Text = "Idle";
                }
            }
            else
            {
                label7.Text = "Cannot find a Server ops File. \n\nMake sure that there is a ops.json file \n\nin the directory:" + ServerDirectory;
                groupBox2.Visible = true;
            }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
            