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
        public frmRandomizer()
        {
            InitializeComponent();
            GetPresets();
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
            this.Invoke(new Action(() =>
            {
                pgbRandomizingProgress.Value = progress;
            }));
        }

        void UpdateSeed(string seed)
        {
            this.Invoke(new Action(() =>
            {
                lblSeed.Text = seed;
            }));
        }

        void UpdateEquipment(string equipment)
        {
            this.Invoke(new Action(() =>
            {
                lblStartingEquipment.Text = equipment;
            }));
        }


        private async void btnConfigure_Click(object sender, EventArgs e)
        {
            secondsGenerating = 0;
            randomizerTimer.Start();
            lblTimeGenerating.Show();
            btnGeneratePPF.Enabled = false;            
            await Randomizer.StartRandomization(UpdateProgressBar, UpdateSeed, UpdateEquipment, GetRandomizerOptions());
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
                AreaRando = cbAreaRandomizer.Checked
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
                MessageBox.Show("Careful! These values may break a seed or make it impossible to complete.", "High Complexity", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
    }
}
