using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SotNRandomizerLauncher
{
    public partial class frmTutorials : Form
    {
        public frmTutorials()
        {
            InitializeComponent();
        }

        private void lblTutorialDescription_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ChangeTutorialTab(lblRandoTutorial);
        }

        void ChangeTutorialTab(Label tutorialLabel)
        {
            foreach (Label label in this.Controls.OfType<Label>())
            {
                if (label is LinkLabel || label.Tag != null) continue;
                if(label != tutorialLabel)
                {
                    label.Hide();                    
                }
                else
                {
                    label.Show();
                }
            }
        }

        void SetTutorialColor(Button btnLabel)
        {
            foreach (Button btn in this.Controls.OfType<Button>())
            {
                if (btn.Tag == null || btn.Tag.ToString() != "btn") continue;
                if (btn != btnLabel)
                {
                    btn.BackColor = Color.Transparent;
                }
                else
                {
                    btn.BackColor = Color.IndianRed;
                }
            }
        }

        private void lblSymphonyRando_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://www.symphonyrando.fun/");
        }

        private void btnLauncher_Click(object sender, EventArgs e)
        {
            ChangeTutorialTab(lblTutorialDescription);
        }

        private void btnPresetsTutorial_Click(object sender, EventArgs e)
        {
            ChangeTutorialTab(lblPresetsTutorial);
        }

        private void btnLongLibraryDiscord_Click(object sender, EventArgs e)
        {
            Process.Start("https://discord.gg/mNQ5Ye9juf");        
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblRandomizer_Click(object sender, EventArgs e)
        {
            ChangeTutorialTab(lblRandoTutorial);
            SetTutorialColor(lblRandomizer);
        }

        private void lblLauncher_Click(object sender, EventArgs e)
        {
            ChangeTutorialTab(lblTutorialDescription);
            SetTutorialColor(lblLauncher);
        }

        private void lblPresets_Click(object sender, EventArgs e)
        {
            ChangeTutorialTab(lblPresetsTutorial);
            SetTutorialColor(lblPresets);
        }
    }
}
