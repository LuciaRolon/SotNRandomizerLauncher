using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SotNRandomizerLauncher
{
    public partial class LeaderboardItem : UserControl
    {
        private string imageUrl;
        private Color textColor;
        private string seedUrl;

        [Category("Data")]
        [Description("Sets the player name of the control.")]
        [DefaultValue("Player Name")]
        public string PlayerName
        {
            get { return lblPlayerName.Text; }
            set
            {
                lblPlayerName.Text = value;
            }
        }

        [Category("Data")]
        [Description("Sets the player title of the control.")]
        [DefaultValue("Player Title")]
        public string PlayerTitle
        {
            get { return lblPlayerTitle.Text; }
            set
            {
                lblPlayerTitle.Text = value;
            }
        }

        [Category("Data")]
        [Description("Sets the leaderboard position of the player.")]
        [DefaultValue("#1")]
        public string PlayerPosition
        {
            get { return lblPosition.Text; }
            set
            {
                lblPosition.Text = value;
            }
        }

        [Category("Data")]
        [Description("Sets the player time.")]
        [DefaultValue("HH:MM:SS")]
        public string PlayerTime
        {
            get { return lblTime.Text; }
            set
            {
                lblTime.Text = value;
            }
        }

        [Category("Data")]
        [Description("Sets the seed for the position.")]
        public string Seed
        {
            get { return lblSeed.Text; }
            set
            {
                if (value != null && value.Length != 0)
                {
                    lblSeed.Show();
                }
                else
                {
                    lblSeed.Hide();
                }
                lblSeed.Text = value;
            }
        }

        [Category("Data")]
        [Description("Sets the seed url.")]
        public string SeedUrl
        {
            get { return this.seedUrl; }
            set
            {
                this.seedUrl = value;
            }
        }

        [Category("Data")]
        [Description("Sets the URL of the image to display.")]
        public string ImageUrl
        {
            get { return imageUrl; }
            set
            {
                if (imageUrl != value)
                {
                    imageUrl = value;
                }
            }
        }

        [Category("Data")]
        [Description("Sets the text color.")]
        public Color TextColor
        {
            get { return textColor; }
            set
            {
                if (textColor != value)
                {
                    textColor = value;
                }
            }
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

        public LeaderboardItem()
        {
            InitializeComponent();
        }

        private void lblSeed_Click(object sender, EventArgs e)
        {

        }

        void LoadColors()
        {
            lblPlayerName.ForeColor = this.textColor;
            lblPlayerTitle.ForeColor = this.textColor;
            lblPosition.ForeColor = this.textColor;
            lblSeed.ForeColor = this.textColor;
            lblTime.ForeColor = this.textColor;
        }


        public void LoadItem()
        {
            LoadImageAsync(this.imageUrl);
            if (this.textColor == null)
            {
                this.TextColor = Color.White;
            }
            LoadColors();
        }

        private void lblPlayerTitle_Click(object sender, EventArgs e)
        {

        }

        private void LeaderboardItem_Load(object sender, EventArgs e)
        {

        }

        private void lblSeed_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(this.seedUrl);
        }
    }
}
