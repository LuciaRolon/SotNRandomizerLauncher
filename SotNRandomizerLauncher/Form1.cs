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
        string launcherVersion = "v0.4.3.1";
        bool isOfflineMode = false;
        public frmMain()
        {
            InitializeComponent();
            string lastSeed = LauncherClient.GetConfigValue("LastSeed");
            lblVersion.Text = launcherVersion;
            if (lastSeed != null)
            {
                lblPlayLastSeed.Text = $"Play Last Seed: \n{lastSeed}";
                btnPlay.Enabled = true;
            }
            else
            {
                lblPlayLastSeed.Hide();
                btnPlay.Enabled = false;
            }
            bool importedUser = LauncherClient.GetConfigValue("ImportedUser") != null;
            if (importedUser)
            {
                ImportedVisuals();
            }
            else
            {
                NormalVisuals();                           
            }

            if (!LauncherClient.IsInitialSetup())
            {
                isOfflineMode = !LauncherClient.HasInternetConnection();
                if(isOfflineMode) lblOfflineMode.Show();
                try
                {
                    UpdateHandler.UpdateLauncher();
                    if (this.isOfflineMode) return;
                    if (!importedUser) CheckForUpdates();                               
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error reaching latest version: {ex.Message}. Check your internet connection.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            LoadEvents();
            LauncherClient.CheckForPresetUpdates();
        }

        void CheckForLauncherUpdates()
        {
            if (LauncherClient.GetLatestVersion("LuciaRolon/SotNRandomizerLauncher") != launcherVersion)
            {
                DialogResult result = MessageBox.Show("A new Launcher version is available for download. Want to download the latest update?", "Launcher Version Available", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    OpenAutoUpdater();
                }
            }
        }

        public static void OpenAutoUpdater()
        {
            string currentAppDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string launcherPath = Path.Combine(currentAppDirectory, "LauncherUpdater.exe");
            Process.Start(launcherPath);
            Application.Exit();
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
            if (LauncherClient.GetLatestVersion("TASEmulators/BizHawk") != LauncherClient.GetConfigValue("BizHawkVersion"))
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
        }
        

        void NormalVisuals()
        {
            lblBizhawk.Text = $"BizHawk v{LauncherClient.GetConfigValue("BizHawkVersion")}";
            lblLivesplit.Text = $"LiveSplit v{LauncherClient.GetConfigValue("LiveSplitVersion")}";
            lblRandoTools.Text = $"SotN Rando Tools v{LauncherClient.GetConfigValue("RandoToolsVersion")}";
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

        public void UpdateRandomizeStatus(int progress, string status)
        {
            this.Invoke(new Action(() =>
            {
                pgbRandomizing.Value = progress;
                lblStatus.Text = status;
            }));            
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
            string ppfFileChosen = LauncherClient.RequestFile("Select your Randomizer Seed file (.ppf)", "ppf");
            if(ppfFileChosen == "") return;
            SetPPF(ppfFileChosen);            
        }

        void SetPPF(string ppfFile)
        {
            if (LauncherClient.GetConfigValue("AreaRandoEnabled") == "Yes")
            {
                DialogResult result = MessageBox.Show("The Area Randomizer is enabled. This will open the AR tool after patching the game. Proceed?", "Area Randomizer Enabled", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No) return;
            }
            string ppfFileName = Path.GetFileName(ppfFile).Split('.')[0];
            this.ppfFile = ppfFile;
            lblSelectedSeed.Text = $"Seed Selected: {ppfFileName}";
            RandomizeGame();            
        }

        private void btnRandomize_Click(object sender, EventArgs e)
        {
            RandomizeGame();
        }

        async void RandomizeGame()
        {
            try
            {
                btnPlay.Enabled = false;
                lblPlayLastSeed.Hide();
                lblStatus.Text = "Randomizing Game...";
                await LauncherClient.AsyncRandomizeGame(ppfFile, this);
                string ppfFileName = Path.GetFileName(ppfFile).Split('.')[0];
                LauncherClient.SetAppConfig("LastSeed", ppfFileName);                
                btnPlay.Enabled = true;
                btnPlay.BackColor = Color.PaleGreen;
                if (LauncherClient.GetConfigValue("AreaRandoEnabled") == "Yes") {
                    OpenAreaRandoTool();
                    LauncherClient.SetAppConfig("LastAreaRandoSeed", ppfFileName);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error randomizing: {ex.Message}", "Error during Randomization", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        void OpenAreaRandoTool()
        {
            string appPath = LauncherClient.GetConfigValue("AreaRandoPath");
            Process process = new Process();
            process.StartInfo.FileName = Path.Combine(appPath, "SOTN_AR.exe");
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.WorkingDirectory = appPath;
            process.Start(); // Start the Area Rando Tool process
        }

        void OpenMapTrackerTool()
        {
            string appPath = LauncherClient.GetConfigValue("MapTrackerPath");
            Process process = new Process();
            process.StartInfo.FileName = Path.Combine(appPath, "SOTN_AR_MAPPER.exe");
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.WorkingDirectory = appPath;
            process.Start(); // Start the Area Rando Map Tracker process
        }

        private void LaunchBizhawk()
        {            
            string appPath = LauncherClient.GetConfigValue("BizHawkPath");
            Process process = new Process();
            process.StartInfo.FileName = Path.Combine(appPath, "EmuHawk.exe");
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.WorkingDirectory = appPath;
            process.Start(); // Start the BizHawk process
        }

        private async Task LaunchLiveSplitWithWait()
        {
            // Wait before running LiveSplit to prevent overlapping issues with BizHawk
            await Task.Delay(10000);
            if (LauncherClient.GetConfigValue("OpenLiveSplit") != "No") LaunchLiveSplit();
            btnPlay.Enabled = true;
        }

        private void LaunchLiveSplit()
        {
            string liveSplitPath = Path.Combine(LauncherClient.GetConfigValue("LiveSplitPath"), "LiveSplit.exe");
            Process.Start(liveSplitPath); // Start the LiveSplit process
        }

        private async void btnPlay_Click(object sender, EventArgs e)
        {
            if (LauncherClient.GetConfigValue("CoreInstalled") == "FastCore")
            {
                DialogResult result = MessageBox.Show("You're about to start a run using the Fast Core. Proceed?", "Fast Core Installed", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No) return;
            }
            btnPlay.Enabled = false;
            LaunchBizhawk();         
            await LaunchLiveSplitWithWait();
            if (LauncherClient.GetConfigValue("MapTrackerEnabled") == "Yes") OpenMapTrackerTool();
            
        }

        private void btnLaunchLiveSplit_Click(object sender, EventArgs e)
        {
            LaunchLiveSplit();
        }

        private async void btnUpdateLiveSplit_Click(object sender, EventArgs e)
        {
            try
            {
                await LauncherClient.UpdateLiveSplit();
                pbLiveSplit.Image = Properties.Resources.v_update;
                btnUpdateLiveSplit.Enabled = false;
                btnUpdateLiveSplit.Text = "Up to Date";
                lblLivesplit.Text = $"LiveSplit v{LauncherClient.GetConfigValue("LiveSplitVersion")}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error reaching updating LiveSplit: {ex.Message}. Check your internet connection.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }

        private void btnLaunchBizhawk_Click(object sender, EventArgs e)
        {
            LaunchBizhawk();
        }

        private async void btnUpdateRandoTools_Click(object sender, EventArgs e)
        {
            try
            {
                await LauncherClient.UpdateRandoTools();
                pbRandoTools.Image = Properties.Resources.v_update;
                btnUpdateRandoTools.Enabled = false;
                btnUpdateRandoTools.Text = "Up to Date";
                lblRandoTools.Text = $"SotN Rando Tools v{LauncherClient.GetConfigValue("RandoToolsVersion")}";
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
                ActivateAfterDelay(500);
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

        void ActivateAfterDelay(int miliseconds)
        {
            // Use a timer to ensure the focus operation happens after the dialog closes completely
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = miliseconds; // 100 milliseconds delay
            timer.Tick += (s, args) =>
            {
                timer.Stop();
                this.Activate();
            };
            timer.Start();
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
                btnUpdateBizhawk.Enabled = false;
                btnUpdateBizhawk.Text = "Up to Date";
                lblBizhawk.Text = $"Bizhawk v{LauncherClient.GetConfigValue("BizHawkVersion")}";
            }
            catch(Exception ex)
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

        private async void btnRandomizer_Click(object sender, EventArgs e)
        {            
            bool randomizerInstalled = await CheckForRandomizerUpdates();
            if (!randomizerInstalled)
            {
                if (this.isOfflineMode)
                {
                    MessageBox.Show("The Randomizer is not installed and you're in Offline Mode. Please, restart the Launcher and download the Randomizer when you have connection and try again.", "Randomizer not Installed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return;
            }
            frmRandomizer randoForm = new frmRandomizer();
            randoForm.ShowDialog();
        }

        async Task<bool> CheckForRandomizerUpdates()
        {
            bool randomizerInstalled = LauncherClient.GetConfigValue("RandomizerVersion") != null;
            if (this.isOfflineMode) return randomizerInstalled;
            try
            {                
                bool updateRequired = false;
                if (!randomizerInstalled)
                {
                    DialogResult result = MessageBox.Show("Before we need to install the Randomizer. Do you wish to download it?", "Download Randomizer", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.No) return false;
                    updateRequired = true;
                }else if(LauncherClient.GetLatestVersion("LuciaRolon/CompiledRandomizer") != LauncherClient.GetConfigValue("RandomizerVersion"))
                {
                    DialogResult result = MessageBox.Show("There is an update available for the Randomizer. Download it?", "Update Randomizer", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.No) return true;
                    updateRequired = true;
                }
                if(updateRequired) await LauncherClient.DownloadRandomizer();
                return true;
            }
            catch (Exception ex)
            {
                string error = (randomizerInstalled) ? "updating" : "installing";
                MessageBox.Show($"Error {error} the Randomizer: {ex.Message}. Check your internet connection.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return randomizerInstalled;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            if (this.isOfflineMode) return;
            CheckForLauncherUpdates();
        }

        private void lblVersion_Click(object sender, EventArgs e)
        {

        }
    }
}
