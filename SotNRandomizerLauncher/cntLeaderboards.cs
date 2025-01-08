using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;

namespace SotNRandomizerLauncher
{
    public partial class cntLeaderboards : UserControl
    {
        Dictionary<int, dynamic> places = new Dictionary<int, dynamic>();
        Dictionary<string, PresetInfo> presetDictionary;
        bool loaded = false;
        public cntLeaderboards()
        {
            InitializeComponent();
        }

        void LoadPlaces()
        {
            places[1] = topLeaderboardItem1;
            places[2] = topLeaderboardItem2;
            places[3] = topLeaderboardItem3;
            places[4] = leaderboardItem1;
            places[5] = leaderboardItem2;
            places[6] = leaderboardItem3;
            places[7] = leaderboardItem4;
            places[8] = leaderboardItem5;
        }

        void GetPresets()
        {
            cbPreset.Items.Clear();
            string currentAppDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string jsonFilePath = Path.Combine(currentAppDirectory, "baseFiles", "preset-data.json");
            string jsonString = System.IO.File.ReadAllText(jsonFilePath);
            var presets = JsonConvert.DeserializeObject<List<PresetInfo>>(jsonString);
            dynamic result = LauncherClient.CallDataAPI($"ranked/presets");
            List<string> presetNames = result.presets.ToObject<List<string>>();
            presets = presets.Where(p => presetNames.Contains(p.Id)).ToList();

            // Sort presets by Name
            presets.Sort((preset1, preset2) => string.Compare(preset1.Name, preset2.Name));

            // Store presets in a dictionary for quick lookup
            presetDictionary = presets.ToDictionary(p => p.Name, p => p);

            // Populate ComboBox with names
            cbPreset.DataSource = presets;
            cbPreset.DisplayMember = "Name";            
        }

        private void cntLeaderboards_Load(object sender, EventArgs e)
        {
            if (this.DesignMode) return;
            LoadPlaces();
            GetPresets();
            HideAllItems();
            lblDefaultMessage.Show();            
            cbBestBy.SelectedItem = "Time";
            this.loaded = true;
            cbPreset.SelectedIndex = cbPreset.FindStringExact("Safe");
        }

        string GetPlayerIcon(string playerId)
        {
            // Until profiles are implemented, the icon is random.
            int randIcon = new Random(playerId.GetHashCode()).Next(1, 13);
            return $"https://storage.googleapis.com/sotn-rando-bucket/icons/sotn-ico-{randIcon}.png";
        }

        private void HideAllItems()
        {
            lblTitle.Hide();
            foreach (Control control in this.Controls)
            {
                if (control is TopLeaderboardItem || control is LeaderboardItem)
                {
                    control.Hide();
                }
            }
        }

        void AddPlayerData(int place, string userId, string username, string timeElo, string seed, string seedUrl)
        {
            places[place].ImageUrl = GetPlayerIcon(userId);
            places[place].PlayerName = username;
            places[place].PlayerPosition = $"#{place}";
            places[place].PlayerTime = timeElo;
            if (seed != null && seedUrl != null)
            {
                places[place].Seed = $"Seed: {seed}";
                places[place].SeedUrl = seedUrl;
            }
            else
            {
                places[place].Seed = "";
            }
            places[place].PlayerTitle = "";
            switch (place)
            {
                case 1:
                    places[place].TextColor = Color.Orange;
                    places[place].PlayerTitle = "First Place";
                    break;
                case 2:
                    places[place].TextColor = Color.Violet;
                    places[place].PlayerTitle = "Second Place";
                    break;
                case 3:
                    places[place].TextColor = Color.Salmon;
                    places[place].PlayerTitle = "Third Place";
                    break;
                case 4:
                    places[place].TextColor = Color.LightGreen;
                    places[place].PlayerTitle = "Fourth Place";
                    break;
                default:
                    string placeTitle = "Fifth Place";
                    switch (place)
                    {
                        case 6:
                            placeTitle = "Sixth Place";
                            break;
                        case 7:
                            placeTitle = "Seventh Place";
                            break;
                        case 8:
                            placeTitle = "Eighth Place";
                            break;
                    }
                    places[place].TextColor = Color.White;
                    places[place].PlayerTitle = placeTitle;
                    break;
            }
            places[place].LoadItem();
            places[place].Show();
        }

        void LoadNewPresetLeaderboards()
        {
            HideAllItems();
            var selectedPreset = cbPreset.SelectedItem as PresetInfo;
            if (selectedPreset == null)
            {
                return;
            }
            string preset = selectedPreset.Id;
            if ((string)cbBestBy.SelectedItem == "Elo")
            {
                dynamic result = LauncherClient.CallDataAPI($"leaderboards/elo/{preset}?player_limit=8");
                int place = 1;
                if (result.leaderboards.Count == 0)
                {
                    lblDefaultMessage.Text = "No data found for the selected preset.";
                    return;
                }
                lblDefaultMessage.Hide();                
                lblTitle.Text = $"{selectedPreset.Name} (by Elo)";
                lblTitle.Show();
                foreach (dynamic player in result.leaderboards)
                {
                    AddPlayerData(place, (string)player.user_id, (string)player.username, (string)player.elo, null, null);
                    place++;
                }
            }
            else
            {
                dynamic result = LauncherClient.CallDataAPI($"leaderboards/time/{preset}?result_limit=8");
                int place = 1;
                if (result.leaderboards.Count == 0)
                {
                    lblDefaultMessage.Text = "No data found for the selected preset.";
                    return;
                }
                lblDefaultMessage.Hide();
                lblTitle.Text = $"{selectedPreset.Name} (by Time)";
                lblTitle.Show();
                foreach (dynamic player in result.leaderboards)
                {
                    string seed = null;
                    string seedUrl = null;
                    if(player.ContainsKey("seed_name") && player.ContainsKey("seed_url") && player["seed_name"] != null && player["seed_url"] != null)
                    {
                        seed = (string)player.seed_name;
                        seedUrl = (string)player.seed_url;
                    }
                    AddPlayerData(place, (string)player.user_id, (string)player.username, (string)player.time, seed, seedUrl);
                    place++;
                }
            }
        }

        private void cbPreset_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.loaded) return;
            LoadNewPresetLeaderboards();
        }

        private void topLeaderboardItem1_Load(object sender, EventArgs e)
        {

        }

        private void cbBestBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.loaded) return;
            LoadNewPresetLeaderboards();
        }

        private void cntLeaderboards_VisibleChanged(object sender, EventArgs e)
        {
            if (this.DesignMode) return;
        }
    }
}
