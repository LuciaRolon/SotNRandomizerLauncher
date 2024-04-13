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
                if (label is LinkLabel) continue;
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
    }
}
