using System;
using System.Net;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Policy;

namespace Minecraft_Sparkling_Server_Hosting_Tool
{
    public partial class WhitelistForm : Form
    {
        static string URL = @"https://api.mojang.com/users/profiles/minecraft/";


        public WhitelistForm(string data)
        {
            InitializeComponent();
            serverPathLabel.Text = data;
            


        }

        private void button2_Click(object sender, EventArgs e)
        {
            statusLabel.Text = "Saving...";
            System.IO.File.WriteAllText(serverPathLabel.Text + @"\whitelist.json", whitelistedPlayersTextBox.Text);
            System.IO.File.WriteAllLines(serverPathLabel.Text + @"\tempwhitelist.json", listBox1.Items.Cast<string>().ToArray());
            statusLabel.Text = "Saved!";
        }

        //Added dictionary to keep track of people in whitelist file
        Dictionary<string, User> whitelistedUsers = new Dictionary<string, User>();

        private async void button1_Click(object sender, EventArgs e)
        {
            var username = usernameTextBox.Text;
            statusLabel.Text = "Getting minecraft uuid from " + username + "'s mojang account...";
            if (System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable() == true)
            {
                bool status = await CheckUrlStatus(@"https://api.mojang.com/users/profiles/minecraft/" + usernameTextBox.Text);
                if (status)
                {
                    User user = await GetUser(username);

                    //listBox2.Items.Add("  {");
                    //listBox2.Items.Add("    \"name\" : \"" + textBox1.Text + "\"");
                    //listBox2.Items.Add("    \"id\" : \"" + uuid + "\"");
                    //listBox2.Items.Add("  }");
                    //listBox1.Items.Add(textBox1.Text);

                    whitelistedUsers.Add(username, user);

                    usernameTextBox.Text = "";
                    statusLabel.Text = "Idle";
                }
                else
                {
                    MessageBox.Show("The entered mojang account does not exist. Make sure this account is a premium account.", "Account error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    statusLabel.Text = "Idle";
                }
            }
            else
            {
                MessageBox.Show("You are not connected to the internet, and so you can't add items to your whitelist.", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                statusLabel.Text = "Idle";
            }

            RedrawWhitelistedUsersBoxes();
        }

        private void RedrawWhitelistedUsersBoxes()
        {
            StringBuilder sb = new StringBuilder();
            listBox1.Items.Clear();

            foreach (var kvp in whitelistedUsers)
            {
                User user = kvp.Value;
                sb.AppendLine("\t{");
                sb.AppendLine($"\t\t\"name\" : \"{user.name}\",");
                sb.AppendLine($"\t\t\"id\" : \"{user.uuid}\"");
                sb.AppendLine($"\t{"}"}{(whitelistedUsers.Count > 1 ? "," : "")}");
                listBox1.Items.Add(user.name);
            }

            whitelistedPlayersTextBox.Text = sb.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                string username = (string)listBox1.Items[listBox1.SelectedIndex];
                User userToRemove = whitelistedUsers.FirstOrDefault(x => x.Key == username).Value;
                if (userToRemove != null)
                {
                    whitelistedUsers.Remove(username);
                    listBox1.Items.RemoveAt(listBox1.SelectedIndex);
                    RedrawWhitelistedUsersBoxes();
                }
            }
        }
        public static async Task<User> GetUser(string username)
        {
            WebClient webClient = new WebClient();
            var result = await webClient.DownloadStringTaskAsync(new Uri(URL + username));

            var user = JsonConvert.DeserializeObject<User>(result);
            user.uuid = user.uuid.Insert(8, "-").Insert(13, "-").Insert(18, "-").Insert(23, "-");
            return user;

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
        protected async Task<bool> CheckUrlStatus(string Website)
        {
            try
            {
                var request = WebRequest.Create(Website) as HttpWebRequest;
                request.Method = "HEAD";
                using (var response = (HttpWebResponse)await request.GetResponseAsync())
                {
                    return response.StatusCode == HttpStatusCode.OK;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}