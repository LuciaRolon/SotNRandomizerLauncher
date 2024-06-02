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
        public frmRandomizer()
        {
            InitializeComponent();
            GetPresets();
        }

        void GetPresets()
        {
            string randoFolder = Path.Combine(LauncherClient.GetConfigValue("RandomizerPath"), "Randomizer");
            string presetsFolder = Path.Combine(randoFolder, "build", "presets");
            string[] files = Directory.GetFiles(presetsFolder);
            cbPreset.Items.Clear();
            // Extract file names without extensions
            for (int i = 0; i < files.Length; i++)
            {
                string presetName = Path.GetFileNameWithoutExtension(files[i]);
                if (presetName.ToLower() == "index") continue;
                cbPreset.Items.Add(presetName);
            }            
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
            return new RandomizerOptions
            {
                TournamentMode = cbTournamentMode.Checked,
                VanillaMusic = cbVanillaMusic.Checked,
                ShowEquipment = cbShowEquipment.Checked,
                AntiFreezeMode = cbAntiFreeze.Checked,
                MagicMaxMode = cbMagicMax.Checked,
                Seed = txtSeed.Text,
                Preset = cbPreset.Text,
                RelicExtension = (cbRelicExtension.Checked) ? cbExtension.Text : ""
            };
        }

        private void cbPreset_SelectedValueChanged(object sender, EventArgs e)
        {
            btnGeneratePPF.Enabled = true;
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
            cbExtension.Enabled = cbRelicExtension.Checked;
        }

        private void cbExtension_EnabledChanged(object sender, EventArgs e)
        {
            if (cbExtension.Enabled)
            {
                cbExtension.SelectedIndex = 0;
            }
        }
    }
}
