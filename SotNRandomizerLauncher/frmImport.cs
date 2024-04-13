using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SotNRandomizerLauncher
{
    public partial class frmImport : Form
    {
        frmConfigure frmConfigure;
        public frmImport(frmConfigure configure)
        {
            InitializeComponent();
            this.frmConfigure = configure;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LauncherClient.SetAppConfig("BizHawkPath", txtBizHawkPath.Text);
            LauncherClient.SetAppConfig("LiveSplitPath", txtLiveSplitPath.Text);
            LauncherClient.SetAppConfig("ImportedUser", "true");
            frmConfigure.importConfirmed = true;
            this.Close();
        }

        string GetAppFolder(string appName)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();

            // Set properties if needed
            folderBrowserDialog.Description = $"Select your {appName} root folder.";
            folderBrowserDialog.RootFolder = Environment.SpecialFolder.Desktop;

            // Show the dialog and get the result
            DialogResult result = folderBrowserDialog.ShowDialog();

            // Check if the user clicked OK
            if (result == DialogResult.OK)
            {
                // Get the selected folder path
                string selectedFolderPath = folderBrowserDialog.SelectedPath;
                Console.WriteLine($"Selected folder: {selectedFolderPath}");

                // Check if a specific file exists within the selected folder
                string expectedExe = (appName == "BizHawk") ? "EmuHawk.exe" : "LiveSplit.exe";
                string filePathToCheck = Path.Combine(selectedFolderPath, expectedExe);

                if (!File.Exists(filePathToCheck))
                {
                    MessageBox.Show($"{expectedExe} not found within the given folder. Please, select the root folder for {appName}.", "Wrong Folder", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
                return selectedFolderPath;
            }
            return null;
        }

        private void btnUploadBios_Click(object sender, EventArgs e)
        {
            txtLiveSplitPath.Text = GetAppFolder("LiveSplit");
            CheckFields();
        }

        private void btnUploadBizHawk_Click(object sender, EventArgs e)
        {
            txtBizHawkPath.Text = GetAppFolder("BizHawk");
            CheckFields();
        }

        private void btnCancelImport_Click(object sender, EventArgs e)
        {
            frmConfigure.importConfirmed = false;
            this.Close();
        }

        void CheckFields()
        {
            if (txtBizHawkPath.Text != "" && txtLiveSplitPath.Text != "")
            {
                btnContinue.Enabled = true;
            }
        }
    }
}
