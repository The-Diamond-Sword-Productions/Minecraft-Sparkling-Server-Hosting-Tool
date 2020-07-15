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
    public partial class OpsForm : Form
    {
        static string URL = @"https://api.mojang.com/users/profiles/minecraft/";
        List<User> oppedUsers = new List<User>();
        private MainForm main;

        public OpsForm(MainForm main)
        {
            InitializeComponent();

            this.main = main;
            serverPathLabel.Text = main.ServerDirectory;

            string data = File.ReadAllText(main.ServerDirectory + @"\ops.json");

            if (!string.IsNullOrWhiteSpace(data))
            {
                oppedUsers = JsonConvert.DeserializeObject<List<User>>(data);
            }
            RedrawOppedUsersBox();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            statusLabel.Text = "Saving...";
            string data = JsonConvert.SerializeObject(oppedUsers);
            File.WriteAllText(main.ServerDirectory + @"\ops.json", data);
            statusLabel.Text = "Saved!";
        }

        private async void addPlayerButton_Click(object sender, EventArgs e)
        {
            var username = usernameTextBox.Text;
            statusLabel.Text = "Getting minecraft UUID from " + username + "'s Mojang account...";

            if (!NetworkInterface.GetIsNetworkAvailable())
            {
                MessageBox.Show("You are not connected to the internet, and so you can't add items to your op list.", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            if (oppedUsers.Contains(tuple.Item2))
            {
                MessageBox.Show("That player is already opped.", "Op list Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            oppedUsers.Add(tuple.Item2);

            usernameTextBox.Text = "";
            statusLabel.Text = "Idle";

            RedrawOppedUsersBox();
        }
        private void RedrawOppedUsersBox()
        {
            oppedPlayerListBox.Items.Clear();
            opTextBox.Text = "";

            foreach (var user in oppedUsers)
            {
                oppedPlayerListBox.Items.Add(user.name);
                opTextBox.Text += $"({user.name}) - [{user.uuid}]\n";
            }
        }

        private void deletePlayerButton_Click(object sender, EventArgs e)
        {
            if (oppedPlayerListBox.SelectedItem != null)
            {
                string username = (string)oppedPlayerListBox.Items[oppedPlayerListBox.SelectedIndex];
                User userToRemove = oppedUsers.FirstOrDefault(x => x.name == username);
                if (userToRemove != null)
                {
                    oppedUsers.Remove(userToRemove);
                    RedrawOppedUsersBox();
                }
            }
            else
            {
                MessageBox.Show("Please select a user from the op list.", "No selected item.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
