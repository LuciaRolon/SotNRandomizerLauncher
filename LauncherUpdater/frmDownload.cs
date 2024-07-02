using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LauncherUpdater
{
    public partial class frmDownload : Form
    {
        public frmDownload()
        {
            InitializeComponent();            
        }

        public async Task UpdateLauncher()
        {
            await Task.Run(() => LauncherUpdater.UpdateLauncherApp(this));
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public static void OpenLauncher()
        {
            string currentAppDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string launcherPath = Path.Combine(currentAppDirectory, "SotNRandomizerLauncher.exe");
            Process.Start(launcherPath);
            Application.Exit();
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
            }            
        }

        private async void frmDownload_Load(object sender, EventArgs e)
        {
            await UpdateLauncher();
            OpenLauncher();
        }
    }
}
