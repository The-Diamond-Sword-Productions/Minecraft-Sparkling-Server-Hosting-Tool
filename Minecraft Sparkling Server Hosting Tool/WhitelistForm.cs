using System;
using System.Net;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Policy;

namespace Minecraft_Sparkling_Server_Hosting_Tool
{
    public partial class WhitelistForm : Form
    {
        static string URL = @"https://api.mojang.com/users/profiles/minecraft/";
        List<User> whitelistedUsers = new List<User>();
        private MainForm main;

        public WhitelistForm(MainForm main)
        {
            InitializeComponent();

            this.main = main;

            string data = File.ReadAllText(main.ServerDirectory + "whitelist.json");

            if (!string.IsNullOrWhiteSpace(data))
            {
                whitelistedUsers = JsonConvert.DeserializeObject<List<User>>(data);
            }
        }

        private void OnSaveButtonClick(object sender, EventArgs e)
        {
            statusLabel.Text = "Saving...";
            string data = JsonConvert.SerializeObject(whitelistedUsers);
            File.WriteAllText(main.ServerDirectory + @"\whitelist.json", data);
            statusLabel.Text = "Saved!";
        }

        private async void OnGetUserButtonClick(object sender, EventArgs e)
        {
            var username = usernameTextBox.Text;
            statusLabel.Text = "Getting minecraft UUID from " + username + "'s Mojang account...";

            if (!NetworkInterface.GetIsNetworkAvailable())
            {
                MessageBox.Show("You are not connected to the internet, and so you can't add items to your whitelist.", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                statusLabel.Text = "Idle";
            }
            
            var tuple = await GetUser(username);
            if (!tuple.Item1)
            {
                MessageBox.Show("Error reaching Mojang server. Please try again.", "Web Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (tuple.Item2 == null)
            {
                MessageBox.Show("A player with that name cannot be found.", "Invalid User", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (whitelistedUsers.Contains(tuple.Item2))
            {
                MessageBox.Show("That player is already whitelisted.", "Whitelist Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            whitelistedUsers.Add(tuple.Item2);

            usernameTextBox.Text = "";
            statusLabel.Text = "Idle";

            RedrawWhitelistedUsersBox();
        }

        private void RedrawWhitelistedUsersBox()
        {
            whitelistedPlayerListBox.Items.Clear();
            whitelistTextBox.Text = "";

            foreach (var user in whitelistedUsers)
            {
                whitelistedPlayerListBox.Items.Add(user.name);
                whitelistTextBox.Text += $"({user.name}) - [{user.uuid}]\n";
            }
        }

        private void OnRemoveUserButtonClick(object sender, EventArgs e)
        {
            if (whitelistedPlayerListBox.SelectedItem != null)
            {
                string username = (string)whitelistedPlayerListBox.Items[whitelistedPlayerListBox.SelectedIndex];
                User userToRemove = whitelistedUsers.FirstOrDefault(x => x.name == username);
                if (userToRemove != null)
                {
                    whitelistedUsers.Remove(userToRemove);
                    RedrawWhitelistedUsersBox();
                }
            }
            else
            {
                MessageBox.Show("Please select a user from the whitelist.", "No selected item.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public async Task<Tuple<bool, User>> GetUser(string username)
        {
            WebClient webClient = new WebClient();
            try
            {
                var result = await webClient.DownloadStringTaskAsync(new Uri(URL + username));
                
                if (string.IsNullOrWhiteSpace(result)) return new Tuple<bool, User>(true, null);

                var user = JsonConvert.DeserializeObject<User>(result);
                user.uuid = user.uuid.Insert(8, "-").Insert(13, "-").Insert(18, "-").Insert(23, "-");
                return new Tuple<bool, User>(true, user);
            }
            catch (WebException)
            {
                return new Tuple<bool, User>(false, null);
            }
        }
        public class User
        {
            [JsonProperty("name")]
            public string name;

            [JsonProperty("id")]
            public string id { set { uuid = value; } }

            [JsonProperty("uuid")]
            public string uuid;
        }
    }
}