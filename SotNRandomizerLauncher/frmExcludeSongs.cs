using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SotNRandomizerLauncher
{
    public partial class frmExcludeSongs : Form
    {
        public frmExcludeSongs()
        {
            InitializeComponent();
        }

        private void btnExclude_Click(object sender, EventArgs e)
        {
            int selectedIndex = lstSongsAvailable.SelectedIndex;
            if(selectedIndex >= 0)
            {
                lstSongsExcluded.Items.Add(lstSongsAvailable.SelectedItem);
                lstSongsAvailable.Items.RemoveAt(selectedIndex);
            }
        }

        private void btnInclude_Click(object sender, EventArgs e)
        {
            int selectedIndex = lstSongsExcluded.SelectedIndex;
            if (selectedIndex >= 0)
            {
                lstSongsAvailable.Items.Add(lstSongsExcluded.SelectedItem);
                lstSongsExcluded.Items.RemoveAt(selectedIndex);
            }
        }

        void ExcludeSong()
        {

        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if(lstSongsAvailable.Items.Count == 0)
            {
                MessageBox.Show("You must at least select one song.", "Missing Songs", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string songStringByComma = "";
            foreach(string item in lstSongsExcluded.Items)
            {
                string songCode = item.ToUpper();
                songCode = songCode.Replace(" ", "_");
                songStringByComma += $"{songCode},";
            }
            songStringByComma = songStringByComma.Remove(songStringByComma.Length - 1);
            LauncherClient.SetAppConfig("ExcludedSongs", songStringByComma);
            this.Close();
        }

        private void frmExcludeSongs_Activated(object sender, EventArgs e)
        {
            // Load the previously chosen songs.
            string songsByComma = LauncherClient.GetConfigValue("ExcludedSongs");           
            if(songsByComma == null)
            {
                return;
            }

            string[] songsBackToArray = songsByComma.Split(',');
            List<string> itemList = new List<string>();
            foreach (string item in lstSongsAvailable.Items)
            {
                string convertedName = item.ToUpper();
                convertedName = convertedName.Replace(" ", "_");
                bool exists = Array.Exists(songsBackToArray, element => element == convertedName);                
                if (exists)
                {
                    itemList.Add(item);                    
                }
            }

            foreach(string item in itemList)
            {
                lstSongsExcluded.Items.Add(item);
                lstSongsAvailable.Items.Remove(item);
            }
    }
    }
}
