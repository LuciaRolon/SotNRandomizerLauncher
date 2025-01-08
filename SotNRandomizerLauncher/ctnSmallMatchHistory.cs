using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SotNRandomizerLauncher
{
    public partial class ctnSmallMatchHistory : UserControl
    {
        public static string NumberToPlace(int number)
        {
            // Check for special cases: 11th, 12th, 13th
            if (number % 100 >= 11 && number % 100 <= 13)
                return $"{number}th";

            // Determine the suffix based on the last digit
            string suffix;
            switch (number % 10)
            {
                case 1:
                    suffix = "st";
                    break;
                case 2:
                    suffix = "nd";
                    break;
                case 3:
                    suffix = "rd";
                    break;
                default:
                    suffix = "th";
                    break;
            }

            return $"{number}{suffix}";
        }

        [Category("Data")]
        [Description("Preset Place")]
        public int PresetPlace
        {
            set
            {
                lblPlace.Text = $"{NumberToPlace(value)} Place";
            }
        }

        [Category("Data")]
        [Description("Preset")]
        public string Preset
        {
            set
            {
                lblPreset.Text = $"Preset: {value}";
            }
        }

        [Category("Data")]
        [Description("Time")]
        public string Time
        {
            set
            {
                lblTime.Text = $"Time: {value}";
            }
        }

        [Category("Data")]
        [Description("Elo Change")]
        public int EloChange
        {
            set
            {
                if(value > 0)
                {
                    lblPlace.ForeColor = Color.Green;
                }else if(value < 0){
                    lblPlace.ForeColor = Color.Red;
                }
                else
                {
                    lblPlace.ForeColor = Color.SandyBrown;
                }
                lblEloChange.Text = $"Elo Change: {value}";
            }
        }

        [Category("Data")]
        [Description("Match Type")]
        public string MatchType
        {
            set
            {
                lblMatchType.Text = $"{value} Race";
            }
        }

        [Category("Data")]
        [Description("Match Date")]
        public string MatchDate
        {
            set
            {
                lblDate.Text = $"{value}";
            }
        }

        public ctnSmallMatchHistory()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        async private void ctnSmallMatchHistory_Load(object sender, EventArgs e)
        {
            using (HttpClient client = new HttpClient())
            {
                byte[] imageBytes = await client.GetByteArrayAsync("https://storage.googleapis.com/sotn-rando-bucket/icons/sotn-ico-3.png");
                using (var stream = new System.IO.MemoryStream(imageBytes))
                {
                    pbPresetImage.Image = Image.FromStream(stream);
                }
            }
        }

        private void pbPresetImage_Click(object sender, EventArgs e)
        {

        }
    }
}
