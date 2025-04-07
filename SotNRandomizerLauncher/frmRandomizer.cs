using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.UI;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using ComboBox = System.Windows.Forms.ComboBox;

namespace SotNRandomizerLauncher
{
    public partial class frmRandomizer : Form
    {
        bool isOfflineMode = false;
        int secondsGenerating = 0;
        private Dictionary<string, PresetInfo> presetDictionary;
        AreaRandoOptions randoOptions;
        bool isRandomizing = false;
        CancellationTokenSource cts;  // Cancellation token to cancel randomization
        public frmRandomizer(bool isOfflineMode)
        {
            InitializeComponent();
            GetPresets();
            this.isOfflineMode = isOfflineMode;
        }

        void LoadLastSettings()
        {
            Configuration configs = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            foreach (TabPage tabPage in tabOptions.TabPages)
            {
                foreach (CheckBox checkbox in tabPage.Controls.OfType<CheckBox>())
                {
                    if ((checkbox.Tag != null && checkbox.Tag.ToString() == "NoInclude") || checkbox.ThreeState) continue;
                    string isChecked = LauncherClient.GetConfigValue(configs, checkbox.Name);
                    checkbox.Checked = isChecked != null && isChecked.ToLower() == "true";                    
                }
            }
            
            
            string closeOnSeedGeneration = LauncherClient.GetConfigValue(configs, "CloseOnSeedGeneration");
            cbCloseOnGeneration.Checked = closeOnSeedGeneration != null && closeOnSeedGeneration == "Yes";
            if (cbMapColor.Checked)
            {
                string mapColor = LauncherClient.GetConfigValue(configs, "MapColor");
                if(mapColor != null) cbColor.SelectedIndex = int.Parse(mapColor);
            }
            bool isFirstLaunch = LauncherClient.GetConfigValue("LastPreset") == null;
            if (isFirstLaunch)
            {
                cbPreset.SelectedIndex = cbPreset.FindStringExact("Guarded O.G.");
            }
            else
            {
                cbPreset.SelectedIndex = cbPreset.FindStringExact(LauncherClient.GetConfigValue("LastPreset"));
            }
        }

        void GetPresets()
        {           
            cbPreset.Items.Clear();
            string jsonFilePath = Path.Combine(LauncherClient.GetConfigValue("RandomizerPath"), "Randomizer", "preset-data.json");
            string jsonString = File.ReadAllText(jsonFilePath);
            var presets = JsonConvert.DeserializeObject<List<PresetInfo>>(jsonString);
            
            // Sort presets by Name
            if(DateTime.Now.Month == 4 && DateTime.Now.Day == 1)
            {
                foreach(PresetInfo preset in presets)
                {
                    if (preset.Id == "april-fools") 
                    {
                        preset.Name = "Magically Sealed Preset";
                        preset.Description = "A unique and special and super magical preset you'll love <3";
                    }
                }
            }
            presets.Sort((preset1, preset2) => string.Compare(preset1.Name, preset2.Name));
            // We add the Custom Presets to the end of the list
            List<PresetInfo> customPresets = GetCustomPresets();
            if(customPresets != null)
            {
                presets.AddRange(customPresets);
            }
            
            // Store presets in a dictionary for quick lookup
            presetDictionary = presets.ToDictionary(p => p.Name, p => p);

            // Populate ComboBox with names
            cbPreset.DataSource = presets;
            cbPreset.DisplayMember = "Name";        
        }

        List<PresetInfo> GetCustomPresets()
        {
            string customPresets = LauncherClient.GetConfigValue("CustomPresets");
            if (customPresets == null || customPresets == "") return null;
            string currentAppDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string customPresetsPath = Path.Combine(currentAppDirectory, "files", "customPresets");

            string[] presetList = customPresets.Split(',');
            List<PresetInfo> customPresetList = new List<PresetInfo>();
            foreach(string presetFile in presetList)
            {
                string presetFilePath = Path.Combine(customPresetsPath, presetFile);
                string jsonString = File.ReadAllText(presetFilePath);
                // Parse the JSON to get the metadata object
                JObject jsonObject = JObject.Parse(jsonString);
                JObject metadata = (JObject)jsonObject["metadata"];

                // Deserialize the metadata into a PresetInfo object
                PresetInfo presetInfo = metadata.ToObject<PresetInfo>();
                presetInfo.Name = $"Custom - {presetInfo.Name}";
                customPresetList.Add(presetInfo);
            }
            return customPresetList;
        }

        private void txtSeed_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtSeed.Text == "(Optional)") txtSeed.Text = "";
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void lblSeed_Click(object sender, EventArgs e)
        {

        }

        void UpdateProgressBar(int progress)
        {
            if (this.cts.IsCancellationRequested) return;
            this.Invoke(new Action(() =>
            {
                pgbRandomizingProgress.Value = progress;
            }));
        }

        void UpdateSeed(string seed)
        {
            if (this.cts.IsCancellationRequested) return;
            this.Invoke(new Action(() =>
            {
                lblSeed.Text = seed;
            }));
        }

        void UpdateEquipment(string equipment)
        {
            if(this.cts.IsCancellationRequested) return;
            this.Invoke(new Action(() =>
            {
                lblStartingEquipment.Text = equipment;
            }));
        }

        void FinishRandomize(bool finished)
        {
            if (this.cts.IsCancellationRequested) return;
            this.Invoke(new Action(() =>
            {
                btnCopySeed.Show();
                if (finished && cbCloseOnGeneration.Checked && presetDictionary[cbPreset.Text].Id != "bingo") this.Close();  // We don't want to close the window for bingo runs.
            }));
        }

        void UpdateBingoData(BingoData bingoData)
        {
            this.Invoke(new Action(() =>
            {
                btnCopySeed.Show();
                this.rtbBingoInformation.Text = $"Join at: {bingoData.bingoUrl}\nPassword: {bingoData.password}";
            }));
        }

        void UpdateBatchSeedNumber(int seedsGenerated)
        {
            this.Invoke(new Action(() =>
            {
                lblBatchSeeds.Text = $"Seeds Generated: {seedsGenerated} of {(int)numBatchSeeds.Value}";
            }));
        }

        void AprilFoolsJoke(string chosenPreset)
        {
            int jokeLevel = 0;
            try
            {
                ShowJokeMessage($"Not sure about that...", $"It seems like you're trying to generate {chosenPreset}. Are you sure about that?", DialogResult.Yes, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                ShowJokeMessage("I disagree.", $"I don't know. It doesn't seem like a good fit for you. Maybe you can try our shiny Magically Sealed Preset?", DialogResult.No, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                ShowJokeMessage($"Don't resist...", $"You can't just say no to our suggestions! I'll give you some time while you make up your mind, okay?", DialogResult.OK, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Thread.Sleep(5000);
                jokeLevel++;
                ShowJokeMessage($"Thinking is good for you", "Okay, now that you thought about it. Are you sure you don't want to play our Preset?", DialogResult.Cancel, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                jokeLevel++;
                ShowJokeMessage($"No Escape", "You really thought that a new button would save you? Just press Yes and let's get this over with.", DialogResult.No, MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                ShowJokeMessage($"Persistant much huh?", "Okay, we'll stay here then. You won't play. I'll just go rest in that window there while you just look.", DialogResult.OK, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Thread.Sleep(10000);
                jokeLevel++;
                ShowJokeMessage($"I got you!", "Psst. Seems like she's asleep. Come here. I'll help you generate your preset. Press OK and I'll help you.", DialogResult.Cancel, MessageBoxButtons.OKCancel, MessageBoxIcon.Hand);
                ShowJokeMessage($"You got me!", "Okay. It's over. You win. Stop bothering me and bye.", DialogResult.OK, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch (Exception)
            {
                if (jokeLevel == 0)
                {
                    MessageBox.Show("Good idea! One Magically Sealed Preset coming your way!", "Nice!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (jokeLevel == 1)
                {
                    MessageBox.Show("You see? Thinking is good for you. Thank you. Now let's get to play.", ":D", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (jokeLevel == 2)
                {
                    MessageBox.Show("Finally we can agree on something! I was starting to think you didn't like me :(", "Ok", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (jokeLevel == 3)
                {
                    MessageBox.Show("LMAO you really thought I would help you xd. Just go play the new preset and don't bother me anymore.", ">:c", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
                cbPreset.SelectedIndex = cbPreset.FindStringExact("Magically Sealed Preset");
            }
        }

        void ShowJokeMessage(string title, string message, DialogResult expectedResult, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            DialogResult result = MessageBox.Show(message, title, buttons, icon);
            if(result != expectedResult)
            {
                throw new Exception("Nope!");
            }
        }

        private async void btnConfigure_Click(object sender, EventArgs e)
        {
            if(DateTime.Now.Month == 4 && DateTime.Now.Day == 1 && presetDictionary[cbPreset.Text].Id != "april-fools")
            {
                AprilFoolsJoke(cbPreset.Text);
            }
            if(cbExcludeSongs.Checked && LauncherClient.GetConfigValue("ExcludedSongs") == null)
            {
                MessageBox.Show("Please, select which songs to exclude before generating the PPF.", "Excluded Songs Missing", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            secondsGenerating = 0;
            randomizerTimer.Start();
            lblTimeGenerating.Show();
            btnGeneratePPF.Enabled = false;
            isRandomizing = true;
            cts = new CancellationTokenSource();
            int batchSeeds = 1;
            if (cbBatchGenerate.Checked)
            {
                batchSeeds = (int)numBatchSeeds.Value;
                lblBatchSeeds.Text = $"Seeds Generated: 0 of {batchSeeds}";
            }
            lblBatchSeeds.Visible = cbBatchGenerate.Checked;
            await Randomizer.StartRandomization(UpdateProgressBar, UpdateSeed, UpdateEquipment, GetRandomizerOptions(), cts.Token, FinishRandomize, UpdateBatchSeedNumber, batchSeeds);
            string presetId = presetDictionary[cbPreset.Text].Id;
            if (presetId == "bingo")
            {
                rtbBingoInformation.Text = "Generating Bingo Room...";
                rtbBingoInformation.Show();
                lblStartingEquipment.Hide();
                BingoSpecialSetup();
            }
            await Task.Run(() => SendPresetGenerationData(
                    isOfflineMode,
                    presetId,
                    secondsGenerating * 1000,
                    cbTournamentMode.Checked,
                    cbColorRando.Checked,
                    cbMagicMax.Checked,
                    cbAntiFreeze.Checked,
                    cbMyPurse.Checked,
                    cbWingSmashMode.Checked,
                    cbFastWarp.Checked,
                    cbNoPrologue.Checked,
                    cbUnlockedMode.Checked,
                    cbMisteryMode.Checked,
                    cbEnemyStatRando.Checked
                )
            );
            isRandomizing = false;
            randomizerTimer.Stop();
            btnGeneratePPF.Enabled = true;
        }     
        
        async Task<bool> SendPresetGenerationData(bool offlineMode, string presetId, int generationTime, bool tournament, bool colorRando, bool magicMax, bool antiFreeze, bool purseMode, bool iws, bool fastWarp, bool noPrologue, bool unlocked, bool surprise, bool enemyStat)
        {
            if (!offlineMode)
            {                
                var settingsDict = new Dictionary<string, object>
                {
                    { "tournament", tournament },
                    { "color_rando", colorRando },
                    { "magic_max", magicMax },
                    { "anti_freeze", antiFreeze },
                    { "purse_mode", purseMode },
                    { "infinite_wing_smash", iws },
                    { "fast_warp", fastWarp },
                    { "no_prologue", noPrologue },
                    { "unlocked", unlocked },
                    { "surprise", surprise },
                    { "enemy_stat", enemyStat },
                    { "relic_extension", "" }             
                };
                var postDict = new Dictionary<string, object>
                {
                    { "preset", presetId },
                    { "generation_time", generationTime },
                    { "app", "Launcher" },
                    { "settings", settingsDict }
                };
                await ApiClient.Instance.PostAsync("/data/presets", postDict);                
            }
            return true;
        }

        async void BingoSpecialSetup()
        {
            await LauncherClient.CreateBingosyncRoom(UpdateBingoData);
        }

        void SaveLastRandomizingOptions()
        {
            Dictionary<string, string> cbValues = new Dictionary<string, string>();
            foreach (TabPage tabPage in tabOptions.TabPages)
            {
                foreach (CheckBox control in tabPage.Controls.OfType<CheckBox>())
                {
                    if ((control.Tag != null && control.Tag.ToString() == "NoInclude") || control.ThreeState) continue;
                    cbValues[control.Name] = control.Checked.ToString();
                }
            }
            LauncherClient.SetAppConfig(cbValues);
            LauncherClient.SetAppConfig("LastPreset", cbPreset.Text);
        }

        RandomizerOptions GetRandomizerOptions()
        {
            MapColor mapColor = MapColor.Default;
            if (cbMapColor.Checked)
            {
                mapColor = (MapColor)Enum.Parse(typeof(MapColor), cbColor.Text);
            }
            Goal customGoal = Goal.Default;            
            if (cbCustomGoals.Checked)
            {
                string cleanedGoal = cbGoalsList.Text.Replace(" ", "").Replace("&", "");
                customGoal = (Goal)Enum.Parse(typeof(Goal), cleanedGoal);
            }
            if (cbAreaRandomizer.Checked && randoOptions == null)
            {
                randoOptions = new AreaRandoOptions();
            }


            return new RandomizerOptions
            {
                TournamentMode = cbTournamentMode.Checked,
                VanillaMusic = cbVanillaMusic.Checked,
                ShowEquipment = cbShowEquipment.Checked,
                AntiFreezeMode = cbAntiFreeze.Checked,
                MagicMaxMode = cbMagicMax.Checked,
                ColorRando = cbColorRando.Checked,
                MyPurseMode = cbMyPurse.Checked,
                MapColor = mapColor,
                Complexity = (cbCustomComplexity.Checked) ? int.Parse(cbComplexity.Text) : 0,
                Seed = txtSeed.Text,
                Preset = presetDictionary[cbPreset.Text].Id,
                RelicExtension = (cbRelicExtension.Checked) ? cbExtension.Text : "",
                BHSeed = IsBHSeed(presetDictionary[cbPreset.Text].Id),
                AreaRandoOptions = randoOptions,
                AreaRando = cbAreaRandomizer.Checked,
                IWBMode = cbWingSmashMode.Checked,
                FastWarpMode = cbFastWarp.Checked,
                UnlockedMode = cbUnlockedMode.Checked,
                ExcludeSongs = cbExcludeSongs.Checked,
                IsCustom = cbPreset.Text.Contains("Custom"),
                MisteryMode = cbMisteryMode.Checked,
                EnemyStatRando = cbEnemyStatRando.Checked,
                ShopPrices = cbRandoShop.Checked,
                StartingZone = cbStartingZoneRando.Checked,
                StartingZone2 = cbStartingZoneRando2.Checked,
                NoPrologue = cbNoPrologue.Checked,
                EnemyDrops = cbEnemyDrops.CheckState,
                ItemLocations = cbItemLocations.CheckState,
                ItemStats = cbItemStats.CheckState,
                PrologueRewards = cbPrologueRewards.CheckState,
                RelicLocations = cbRelicLocations.CheckState,
                StartingEquipment = cbStartingEquipment.CheckState,
                TurkeyMode = cbTurkeyMode.CheckState,
                ItemNameRando = cbItemNames.Checked,
                AlucardPalette = cbAlucardPalette.Checked,
                CustomGoal = customGoal,
                ReverseLibraryCard = cbReverseLibraryCard.Checked
            };
        }

        bool IsBHSeed(string preset)
        {
            string[] bhSeeds = { "bountyhunter", "bountyhuntertc", "hitman", "chaos-lite"};
            return bhSeeds.Contains(preset);
        }

        private void cbPreset_SelectedValueChanged(object sender, EventArgs e)
        {
            btnGeneratePPF.Enabled = true;
            try
            {
                string description = presetDictionary[cbPreset.Text].Description;
                string[] authors = presetDictionary[cbPreset.Text].Author;
                string knowledgeCheck = presetDictionary[cbPreset.Text].KnowledgeCheck;
                string timeFrame = presetDictionary[cbPreset.Text].TimeFrame;
                string modLevel = presetDictionary[cbPreset.Text].ModdedLevel;
                string castleType = presetDictionary[cbPreset.Text].CastleType;
                string transformEarly = presetDictionary[cbPreset.Text].TransformEarly;
                string transformFocus = presetDictionary[cbPreset.Text].TransformFocus;
                string winCondition = presetDictionary[cbPreset.Text].WinCondition;
                string extension = presetDictionary[cbPreset.Text].MetaExtension;
                string complexity = presetDictionary[cbPreset.Text].MetaComplexity;
                string randoStats = presetDictionary[cbPreset.Text].ItemStats;
                lblPresetDescription.Text = description;
                lblAuthors.Text = $"Authors: {string.Join(",", authors)}";
                lblKnowledge.Text = $"Knowledge Required: {knowledgeCheck}";
                lblExtension.Text = $"Relic Extension: {extension}";
                lblComplexity.Text = $"Minimum Complexity: {complexity}";
                lblItemStats.Text = $"Randomized Item Stats: {randoStats}";
                lblModLevel.Text = $"Modification Level: {modLevel}";
                lblCastleType.Text = $"Castle Type: {castleType}";
                lblEarlyTransformation.Text = $"Early Transformations: {transformEarly}";
                lblWinCondition.Text = $"Win Condition: {winCondition}";
                lblTransformationFocus.Text = $"Transformation Focus: {transformFocus}";
                lblCompletionPace.Text = $"Completion Pace: {timeFrame}";
            }
            catch (Exception)
            {
                lblPresetDescription.Text = "Preset failed to load.";
            }            
        }

        private void frmRandomizer_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.isRandomizing)
            {
                DialogResult result = MessageBox.Show("There's a Randomization in progress. Cancelling it could cause unexpected behaviour. Only do this if the Randomization is stuck. Proceed with the cancellation?", "Cancel Randomization", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No) return;
                cts.Cancel();
                this.isRandomizing = false;                
            }            
            this.Close();
        }

        private void txtSeed_Leave(object sender, EventArgs e)
        {
            if(txtSeed.Text == "")
            {
                txtSeed.Text = "(Optional)";
            }
        }

        private void randomizerTimer_Tick(object sender, EventArgs e)
        {
            secondsGenerating++;
            TimeSpan timeSpan = TimeSpan.FromSeconds(secondsGenerating);
            lblTimeGenerating.Text = $"Time Generating: {timeSpan.Minutes:D2}:{timeSpan.Seconds:D2}";
        }

        private void cbRelicExtension_CheckedChanged(object sender, EventArgs e)
        {
            cbExtension.SelectedIndex = -1;
            cbExtension.Enabled = cbRelicExtension.Checked;            
        }

        private void cbExtension_EnabledChanged(object sender, EventArgs e)
        {
            if (cbExtension.Enabled)
            {
                cbExtension.SelectedIndex = 0;
            }
        }

        private void cbPreset_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void cbComplexity_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbComplexity.Text == "9" || cbComplexity.Text == "10")
            {
                MessageBox.Show("Please be warned that increasing complexity increases generation time exponentially and eventually makes seeds impossible to generate.", "High Complexity", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void cbMapColor_CheckedChanged(object sender, EventArgs e)
        {
            cbColor.SelectedIndex = -1;
            cbColor.Enabled = cbMapColor.Checked;            
        }

        private void cbCustomComplexity_CheckedChanged(object sender, EventArgs e)
        {
            cbComplexity.SelectedIndex = -1;
            cbComplexity.Enabled = cbCustomComplexity.Checked;            
        }

        private void cbColor_EnabledChanged(object sender, EventArgs e)
        {
            if (cbColor.Enabled)
            {
                cbColor.SelectedIndex = 0;
            }
        }

        private void cbComplexity_EnabledChanged(object sender, EventArgs e)
        {
            if (cbExtension.Enabled)
            {
                cbExtension.SelectedIndex = 0;
            }
        }

        private void btnAROptions_Click(object sender, EventArgs e)
        {
            frmAreaRandoOptions randoOptions = new frmAreaRandoOptions();
            randoOptions.FormClosing += (s, args) => { this.randoOptions = randoOptions.areaRando; };  // This makes it so I can import the generated settings.
            randoOptions.ShowDialog();
        }

        private void cbAreaRandomizer_CheckedChanged(object sender, EventArgs e)
        {
            btnAROptions.Enabled = cbAreaRandomizer.Checked;
        }

        private void cbCloseOnGeneration_CheckedChanged(object sender, EventArgs e)
        {
            string closeOnGeneration = (cbCloseOnGeneration.Checked) ? "Yes" : "No";
            LauncherClient.SetAppConfig("CloseOnSeedGeneration", closeOnGeneration);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnCopySeed_Click(object sender, EventArgs e)
        {
            Clipboard.SetText($"{lblSeed.Text}\n{lblStartingEquipment.Text}");
            lblTimeGenerating.Text = "Seed and Equipment copied to clipboard!";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmExcludeSongs frmExclude = new frmExcludeSongs();
            frmExclude.ShowDialog();
        }

        private void cbExcludeSongs_CheckedChanged(object sender, EventArgs e)
        {
            button1.Enabled = cbExcludeSongs.Checked;
        }

        private void frmRandomizer_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveLastRandomizingOptions();
        }

        private void frmRandomizer_Shown(object sender, EventArgs e)
        {
            LoadLastSettings();
        }

        private void cbColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            LauncherClient.SetAppConfig("MapColor", cbColor.SelectedIndex.ToString());
        }

        private void rtbBingoInformation_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            Process.Start(e.LinkText);
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void cbPreset_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void lnkLocations_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://www.symphonyrando.fun/locations");
        }

        private void btnPresetList_Click(object sender, EventArgs e)
        {
            frmPresetList frmPresetList = new frmPresetList();
            frmPresetList.Show();
        }


        void SpecialPresetLocks(string presetId)
        {
            ResetLockableOptions();

            string[] glitchPresets = { "glitch", "glitchmaster", "any-percent" };
            string[] secondCastleLocked = { "dog-life", "magic-mirror", "mobility", "lookingglass", "boss-rush", "beyond" };
            string[] firstCastleLocked = { "boss-rush", "beyond" };
            string[] unlockedModeLocked = { "boss-rush" };
            string[] enemyStatRandoLocked = { "big-toss" };

            if (glitchPresets.Contains(presetId))
            {
                cbAntiFreeze.Checked = false;
                cbAntiFreeze.Enabled = false;                
            }
            if (secondCastleLocked.Contains(presetId))
            {
                cbStartingZoneRando2.Checked = false;
                cbStartingZoneRando2.Enabled = false;
            }
            if (firstCastleLocked.Contains(presetId))
            {
                cbStartingZoneRando.Checked = false;
                cbStartingZoneRando.Enabled = false;
            }
            if (unlockedModeLocked.Contains(presetId))
            {
                cbUnlockedMode.Checked = false;
                cbUnlockedMode.Enabled = false;
            }
            if (enemyStatRandoLocked.Contains(presetId))
            {
                cbEnemyStatRando.Checked = false;
                cbEnemyStatRando.Enabled = false;
            }
            if (presetId == "bingo")
            {
                cbBatchGenerate.Checked = false;
                cbBatchGenerate.Enabled = false;
            }
        }

        void ResetLockableOptions()
        {
            cbAntiFreeze.Enabled = true;
            cbStartingZoneRando.Enabled = true;
            cbEnemyStatRando.Enabled = true;
            cbStartingZoneRando2.Enabled = true;
            cbUnlockedMode.Enabled = true;
            cbBatchGenerate.Enabled = true;
        }

        private void cbBatchGenerate_CheckedChanged(object sender, EventArgs e)
        {
            numBatchSeeds.Enabled = cbBatchGenerate.Checked;            
        }

        private void cbStartingZoneRando2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Enhancements_Click(object sender, EventArgs e)
        {

        }

        private void cbCustomGoals_CheckedChanged(object sender, EventArgs e)
        {
            cbGoalsList.SelectedIndex = -1;
            cbGoalsList.Enabled = cbCustomGoals.Checked;
        }
    }
}
