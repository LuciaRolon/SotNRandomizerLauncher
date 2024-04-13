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
    public partial class frmDownload : Form
    {
        public frmDownload()
        {
            InitializeComponent();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void UpdateDownload(int percent, string status)
        {
            if (pgbDownloadProgress.InvokeRequired)
            {
                pgbDownloadProgress.Invoke(new Action<int, string>(UpdateDownload), percent, status);
            }
            else
            {
                pgbDownloadProgress.Value = percent;
                lblPercent.Text = $"{percent}%";
                lblStatus.Text = status;
                if(percent == 100)
                {
                    this.Close();
                }
            }            
        }
    }
}
