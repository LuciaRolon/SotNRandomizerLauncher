using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SotNRandomizerLauncher
{
    public partial class cntProfile : UserControl
    {
        public cntProfile()
        {
            InitializeComponent();
        }

        string GetPlayerIcon(string playerId)
        {
            // Until profiles are implemented, the icon is random.
            int randIcon = new Random(playerId.GetHashCode()).Next(1, 13);
            return $"https://storage.googleapis.com/sotn-rando-bucket/icons/sotn-ico-{randIcon}.png";
        }

        private async void LoadImageAsync(string url)
        {
            if (string.IsNullOrEmpty(url))
                return;

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    byte[] imageBytes = await client.GetByteArrayAsync(url);
                    using (var stream = new System.IO.MemoryStream(imageBytes))
                    {
                        pbUserIcon.Image = Image.FromStream(stream);
                    }
                }
            }
            catch (Exception)
            {

            }
        }

        private void cntProfile_Load(object sender, EventArgs e)
        {
            
        }
        public static string CapitalizeFirstLetter(string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;

            return char.ToUpper(input[0]) + input.Substring(1);
        }

        private void CaptureFormToClipboard()
        {
            btnShareProfile.Hide();
            // Create a Bitmap object to capture the form
            Rectangle rect = this.ClientRectangle;
            
            using (Bitmap bmp = new Bitmap(rect.Width, rect.Height))
            {
                this.DrawToBitmap(bmp, rect);
                Clipboard.SetImage(bmp);
            }
            btnShareProfile.Show();
            MessageBox.Show("Screenshot saved to clipboard!");
        }

        private void pbUserIcon_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                string playerId = LauncherClient.GetConfigValue("PlayerDiscordId");
                lblUsername.Text = CapitalizeFirstLetter(LauncherClient.GetConfigValue("PlayerDiscordUsername"));
                if (playerId == null || playerId == "") return;
                LoadImageAsync(GetPlayerIcon(playerId));
                dynamic result = LauncherClient.CallDataAPI($"user_by_id/{playerId}");
                if (result.twitch == null)
                {
                    lblTwitch.Hide();
                }
                else
                {
                    lblTwitch.Text = $"Twitch: {(string)result.twitch}";
                }                
                string bestPreset = "";
                int bestPresetRank = 0;
                int totalMatches = 0;
                string presetsPlayed = "Presets Played:\n";
                foreach(dynamic elo in result.ranked_elos)
                {
                    if(bestPreset == "" || (int)elo.rank < bestPresetRank)
                    {
                        bestPreset = (string)elo.preset;
                        bestPresetRank = (int)elo.rank;
                    }
                    totalMatches += (int)elo.matches;
                    presetsPlayed += $"- {CapitalizeFirstLetter((string)elo.preset)}: {(int)elo.elo} Elo. Rank #{(int)elo.rank}\n";
                }
                lblPresetsPlayed.Text = presetsPlayed;
                lblBestPreset.Text = $"Best Preset: {CapitalizeFirstLetter(bestPreset)} - #{bestPresetRank}";
                lblTotalMatches.Text = $"Total Matches: {totalMatches}";
                LoadMatchHistory();
            }
        }

        string StrDatetimeToDate(string datetime)
        {
            string input = datetime;

            // Extract the first 10 characters
            string dateOnly = input.Substring(0, 10);
            return dateOnly;
        }

        void LoadMatchHistory()
        {
            string playerUser = LauncherClient.GetConfigValue("PlayerDiscordUsername");
            dynamic result = LauncherClient.CallDataAPI($"player_match_history/{playerUser}?number_of_matches=5");
            int matchIdx = 0;
            foreach(ctnSmallMatchHistory matchHistory in this.Controls.OfType<ctnSmallMatchHistory>().OrderBy(c => c.Location.Y))
            {
                if (matchIdx >= result.match_history.Count) break;
                dynamic history = result.match_history[matchIdx];
                matchHistory.PresetPlace = (int)history.placement;
                matchHistory.Preset = CapitalizeFirstLetter((string)history.preset);
                if(history.time == null)
                {
                    matchHistory.Time = "Forfeited";
                }
                else
                {
                    matchHistory.Time = (string)history.time;
                }                
                matchHistory.EloChange = (int)history.elo_change;
                matchHistory.MatchType = CapitalizeFirstLetter((string)history.match_type);
                matchHistory.MatchDate = StrDatetimeToDate((string)history.finished_at);
                matchHistory.Show();
                matchIdx++;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CaptureFormToClipboard();
        }
    }
}
