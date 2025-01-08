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
    public partial class frmUploadPlayerId : Form
    {
        public frmUploadPlayerId()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            dynamic result = LauncherClient.CallDataAPI($"user/{txtDiscordUsername.Text}");
            try
            {
                LauncherClient.SetAppConfig("PlayerDiscordId", (string)result.user_id);
                LauncherClient.SetAppConfig("PlayerDiscordUsername", (string)result.username);
                this.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("User not found. Make sure the Discord username is correct and that you have at least 1 match played", "User not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }
    }
}
