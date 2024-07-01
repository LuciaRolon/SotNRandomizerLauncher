using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SotNRandomizerLauncher
{
    public partial class frmAreaRandoOptions : Form
    {
        public AreaRandoOptions areaRando;
        public frmAreaRandoOptions()
        {
            InitializeComponent();
            cbRelic.SelectedIndex = 0;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void cbRandomStartingPoint_CheckedChanged(object sender, EventArgs e)
        {
            cb2Castle.Enabled = cbRandomStartingPoint.Checked;
            if (!cbRandomStartingPoint.Checked) cb2Castle.Checked = false;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            areaRando = new AreaRandoOptions
            {
                BlockCavernsOnFirstVisit = cbBlockCaverns.Checked,
                DisableFlash = cbDisableFlash.Checked,
                RandomStartingPoint = cbRandomStartingPoint.Checked,
                SPIncludeSecondCastle = cb2Castle.Checked,
                StartingRelic = ConvertRelicToID(cbRelic.Text)
            };
            this.Close();
        }

        string ConvertRelicToID(string relic)
        {
            string tmpRelic = relic.ToLower();
            tmpRelic.Replace(" ", "");
            return tmpRelic;
        }
    }
}
