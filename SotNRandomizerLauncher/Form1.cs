using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SotNRandomizerLauncher
{
    public partial class frmMain : Form
    {
        string ppfFile;
        string seedUrl;
        public frmMain()
        {
            InitializeComponent();
            string lastSeed = LauncherClient.GetConfigValue("LastSeed");
            if (lastSeed != null)
            {
                lblPlayLastSeed.Text = $"Play Last Seed: \n{lastSeed}";
            }
            else
            {
                lblPlayLastSeed.Hide();
            }
            if (LauncherClient.GetConfigValue("ImportedUser") != null)
            {
                ImportedVisuals();
            }
            else
            {
                NormalVisuals();
                if (!LauncherClient.IsInitialSetup())
                {
                    try
                    {
                        CheckForUpdates();
                    }catch(Exception ex)
                    {
                        MessageBox.Show($"Error reaching latest version: {ex.Message}. Check your internet connection.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    
                }                
            }
            LoadEvents();
        }

        void LoadEvents()
        {
            try
            {
                Dictionary<string, string> eventDict = LauncherClient.LoadCurrentEvent();
                lblNextEvent.Text = $"Next Event: {eventDict["EventTitle"]}";
                lblEventSubtext.Text = eventDict["EventSubtitle"];

                Dictionary<string, string> seedDict = LauncherClient.LoadSeedOfTheWeek();
                lblWeekSeed.Text = seedDict["PresetName"];
                seedUrl = seedDict["SeedURL"];
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error obtaining current events: {ex.Message}. Check your internet connection.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void CheckForUpdates()
        {
            if(LauncherClient.GetLatestVersion("TASEmulators/BizHawk") != LauncherClient.GetConfigValue("BizHawkVersion"))
            {
                pbBizhawk.Image = Properties.Resources.x_update;
                btnUpdateBizhawk.Enabled = true;
                btnUpdateBizhawk.Text = "Update";
            }
            if (LauncherClient.GetLatestVersion("LiveSplit/LiveSplit") != LauncherClient.GetConfigValue("LiveSplitVersion"))
            {
                pbLiveSplit.Image = Properties.Resources.x_update;
                btnUpdateLiveSplit.Enabled = true;
                btnUpdateLiveSplit.Text = "Update";
            }
            if (LauncherClient.GetLatestVersion("TalicZealot/SotnRandoTools") != LauncherClient.GetConfigValue("RandoToolsVersion"))
            {
                pbRandoTools.Image = Properties.Resources.x_update;
                btnUpdateRandoTools.Enabled = true;
                btnUpdateRandoTools.Text = "Update";
            }
            UpdateHandler.UpdateLauncher();
        }

        void NormalVisuals()
        {
            lblBizhawk.Text = $"BizHawk v{LauncherClient.GetConfigValue("BizHawkVersion")}";
            lblLivesplit.Text = $"LiveSplit v{LauncherClient.GetConfigValue("LiveSplitVersion")}";
            lblRandoTools.Text = $"SotN Rando Tools v{LauncherClient.GetConfigValue("RandoToolsVersion")}";
            if (LauncherClient.GetConfigValue("LastSeed") != null)
            {
                btnPlay.Enabled = true;
            }
        }

        void ImportedVisuals()
        {
            pbRandoTools.Image = Properties.Resources.min_icon;
            pbBizhawk.Image = Properties.Resources.min_icon;
            pbLiveSplit.Image = Properties.Resources.min_icon;
            lblRandoTools.Text = "SotN Rando Tools";
            lblBizhawk.Text = "BizHawk";
            lblLivesplit.Text = "LiveSplit";
            btnUpdateBizhawk.Text = "Updates disabled.";
            btnUpdateLiveSplit.Text = "Updates disabled.";
            btnUpdateRandoTools.Text = "Updates disabled.";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmConfigure configForm = new frmConfigure();
            configForm.ShowDialog();
        }
    

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnPpfFile_Click(object sender, EventArgs e)
        {
            string ppfFileChosen = LauncherClient.RequestFile("Select your Randomizer Preset file (.ppf)", "ppf");
            if(ppfFileChosen == "") return;
            SetPPF(ppfFileChosen);            
        }

        void SetPPF(string ppfFile)
        {
            string ppfFileName = Path.GetFileName(ppfFile).Split('.')[0];
            this.ppfFile = ppfFile;
            lblSelectedSeed.Text = $"Seed Selected: {ppfFileName}";
            btnPlay.Enabled = true;
            RandomizeGame();
            btnPlay.BackColor = Color.PaleGreen;
        }

        private void btnRandomize_Click(object sender, EventArgs e)
        {
            RandomizeGame();
        }

        void RandomizeGame()
        {
            try
            {
                lblStatus.Text = "Randomizing Game...";
                LauncherClient.RandomizeGame(ppfFile, pgbRandomizing, lblStatus);
                string ppfFileName = Path.GetFileName(ppfFile).Split('.')[0];
                LauncherClient.SetAppConfig("LastSeed", ppfFileName);
                lblPlayLastSeed.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error randomizing: {ex.Message}", "Error during Randomization", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {       
            Configuration configs = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            string appPath = configs.AppSettings.Settings["BizHawkPath"].Value;
            Process process = new Process();
            process.StartInfo.FileName = "cmd.exe"; // Specify the command interpreter
            process.StartInfo.Arguments = $"/c cd {appPath} && start /b EmuHawk.exe"; // Could probably use a batch file ins
            process.StartInfo.CreateNoWindow = true;
            process.Start(); // Start the BizHawk process
            process.Close();
            // Wait before running LiveSplit
            Thread.Sleep(10000);
            Process.Start(Path.Combine(configs.AppSettings.Settings["LiveSplitPath"].Value, "LiveSplit.exe")); // Start the LiveSplit process
        }

        private void btnLaunchLiveSplit_Click(object sender, EventArgs e)
        {
            Configuration configs = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            Process.Start(Path.Combine(configs.AppSettings.Settings["LiveSplitPath"].Value, "LiveSplit.exe")); // Start the LiveSplit process
        }

        private async void btnUpdateLiveSplit_Click(object sender, EventArgs e)
        {
            try
            {
                await LauncherClient.UpdateLiveSplit();
                pbLiveSplit.Image = Properties.Resources.v_update;
                btnUpdateLiveSplit.Enabled = true;
                btnUpdateLiveSplit.Text = "Up to Date";
            }catch (Exception ex)
            {
                MessageBox.Show($"Error reaching updating LiveSplit: {ex.Message}. Check your internet connection.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }

        private void btnLaunchBizhawk_Click(object sender, EventArgs e)
        {
            Configuration configs = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            string appPath = configs.AppSettings.Settings["BizHawkPath"].Value;
            Process process = new Process();
            process.StartInfo.FileName = "cmd.exe"; // Specify the command interpreter
            process.StartInfo.Arguments = $"/c cd {appPath} && EmuHawk.exe"; // Pass the command as an argument
            process.StartInfo.CreateNoWindow = true;
            process.Start(); // Start the BizHawk process
            process.Close();
        }

        private async void btnUpdateRandoTools_Click(object sender, EventArgs e)
        {
            try
            {
                await LauncherClient.UpdateRandoTools();
                pbRandoTools.Image = Properties.Resources.v_update;
                btnUpdateRandoTools.Enabled = true;
                btnUpdateRandoTools.Text = "Up to Date";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error reaching updating RandoTools: {ex.Message}. Check your internet connection.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }

        private void frmMain_Activated(object sender, EventArgs e)
        {
            bool initialSetup = LauncherClient.IsInitialSetup();
            if (initialSetup)
            {
                frmConfigure configForm = new frmConfigure();
                configForm.ShowDialog();
            }    
            if (LauncherClient.GetConfigValue("ImportedUser") != null)
            {
                ImportedVisuals();                
            }
            else
            {
                NormalVisuals();
            }
        }

        private void btnTutorials_Click(object sender, EventArgs e)
        {
            frmTutorials frmTutorials = new frmTutorials();
            frmTutorials.ShowDialog();
        }

        private void lblSelectedSeed_Click(object sender, EventArgs e)
        {

        }

        private async void btnUpdateBizhawk_Click(object sender, EventArgs e)
        {
            try
            {
                await LauncherClient.UpdateBizHawk();
                pbBizhawk.Image = Properties.Resources.v_update;
                btnUpdateBizhawk.Enabled = true;
                btnUpdateBizhawk.Text = "Up to Date";
            }catch(Exception ex)
            {
                MessageBox.Show($"Error reaching updating BizHawk: {ex.Message}. Check your internet connection.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if(seedUrl != "" && seedUrl != null) Process.Start(seedUrl);
        }

        private void frmMain_DragEnter(object sender, DragEventArgs e)
        {
            btnPpfFile.Text = "Drop your PPF file here!";
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                // Allow copying of the data
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void frmMain_DragDrop(object sender, DragEventArgs e)
        {
            // Get the array of file paths from the dropped data
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            // Check if any files were dropped
            if (files != null && files.Length > 0)
            {
                // Get the first file path (assuming only one file is dropped)
                if (Path.GetExtension(files[0]) != ".ppf")
                {
                    MessageBox.Show("The selected file is not a Randomizer Seed File (.ppf). Please, choose the correct file.", "Wrong File", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                string filePath = files[0];
                SetPPF(filePath);
            }
            btnPpfFile.Text = "Select your Randomizer\r\nPreset file (.ppf)";
        }

        private void frmMain_DragLeave(object sender, EventArgs e)
        {
            btnPpfFile.Text = "Select your Randomizer\r\nPreset file (.ppf)";
        }

        private void btnPpfFile_DragDrop(object sender, DragEventArgs e)
        {
            
        }

        private void btnShow_MouseHover(object sender, EventArgs e)
        {
            toolTip.Show("Show specific options to open LiveSplit and BizHawk manually.\nThis is intended for testing or troubleshooting purposes.", btnShow);
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            btnLaunchLiveSplit.Show();
            btnLaunchBizhawk.Show();
        }
    }
}
