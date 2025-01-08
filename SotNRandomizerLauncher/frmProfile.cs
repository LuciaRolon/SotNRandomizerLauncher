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
    public partial class frmProfile : Form
    {
        public frmProfile()
        {
            InitializeComponent();
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }        

        private void frmProfile_Load(object sender, EventArgs e)
        {
            string playerId = LauncherClient.GetConfigValue("PlayerDiscordId");
            if (playerId != null && playerId != "")
            {
                cntProfile1.Show();
            }
            else
            {
                cntLeaderboards1.Show();
            }
        }

        private void cntLeaderboards1_Load(object sender, EventArgs e)
        {

        }

        private void btnPpfFile_Click(object sender, EventArgs e)
        {
            string playerId = LauncherClient.GetConfigValue("PlayerDiscordId");
            if (playerId == null || playerId == "")
            {
                frmUploadPlayerId frmUploadPlayerId = new frmUploadPlayerId();
                frmUploadPlayerId.ShowDialog();
            }
            if (LauncherClient.GetConfigValue("PlayerDiscordId") == null || LauncherClient.GetConfigValue("PlayerDiscordId") == "") return;
            cntLeaderboards1.Hide();
            cntProfile1.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cntLeaderboards1.Show();
            cntProfile1.Hide();
        }
    }
}
