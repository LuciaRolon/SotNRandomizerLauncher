using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SotNRandomizerLauncher
{
    public partial class frmRandomizer : Form
    {
        int secondsGenerating = 0;
        private Dictionary<string, PresetInfo> presetDictionary;
        AreaRandoOptions randoOptions;
        bool isRandomizing = false;
        CancellationTokenSource cts;  // Cancellation token to cancel randomization
        public frmRandomizer()
        {
            InitializeComponent();
            GetPresets();
            string closeOnSeedGeneration = LauncherClient.GetConfigValue("CloseOnSeedGeneration");
            cbCloseOnGeneration.Checked = closeOnSeedGeneration != null && closeOnSeedGeneration == "Yes";
        }

        void GetPresets()
        {           
            cbPreset.Items.Clear();
            string jsonFilePath = Path.Combine(LauncherClient.GetConfigValue("RandomizerPath"), "Randomizer", "preset-data.json");
            string jsonString = File.ReadAllText(jsonFilePath);
            var presets = JsonConvert.DeserializeObject<List<PresetInfo>>(jsonString);

            // Store presets in a dictionary for quick lookup
            presetDictionary = presets.ToDictionary(p => p.Name, p => p);
            // Sort presets by Name
            presets.Sort((preset1, preset2) => string.Compare(preset1.Name, preset2.Name));

            // Populate ComboBox with names
            cbPreset.DataSource = presets;
            cbPreset.DisplayMember = "Name";        
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
                if (finished && cbCloseOnGeneration.Checked) this.Close();
            }));
        }


        private async void btnConfigure_Click(object sender, EventArgs e)
        {
            secondsGenerating = 0;
            randomizerTimer.Start();
            lblTimeGenerating.Show();
            btnGeneratePPF.Enabled = false;
            isRandomizing = true;
            cts = new CancellationTokenSource();
            await Randomizer.StartRandomization(UpdateProgressBar, UpdateSeed, UpdateEquipment, GetRandomizerOptions(), cts.Token, FinishRandomize);
            isRandomizing = false;
            randomizerTimer.Stop();
            btnGeneratePPF.Enabled = true;
        }        

        RandomizerOptions GetRandomizerOptions()
        {
            MapColor mapColor = MapColor.Default;
            if (cbMapColor.Checked)
            {
                mapColor = (MapColor)Enum.Parse(typeof(MapColor), cbColor.Text);
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
                FastWarpMode = cbFastWarp.Checked
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
                string author = presetDictionary[cbPreset.Text].Author;
                toolTip.SetToolTip(lblDescription, $"{description}\nAuthor: {author}");
            }
            catch (Exception)
            {
                toolTip.SetToolTip(lblDescription, "No preset selected");
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
    }
}
