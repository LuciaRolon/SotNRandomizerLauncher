using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SotNRandomizerLauncher
{
    public partial class frmReplays : Form
    {
        private bool isFullScreen = false;
        private Rectangle normalWindowBounds;

        public frmReplays()
        {            
            InitializeComponent();
            InitializeAsync();
            this.KeyPreview = true;
        }

        async void InitializeAsync()
        {
            await wbvReplays.EnsureCoreWebView2Async();            
            wbvReplays.CoreWebView2.Navigate("https://taliczealot.github.io/#/apps/replays");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmReplays_Shown(object sender, EventArgs e)
        {
            // Force the WebView2 control to resize
            wbvReplays.Width = this.ClientSize.Width;
            wbvReplays.Height = this.ClientSize.Height;
            wbvReplays.ZoomFactor = 0.5;
        }

        private void ToggleFullScreen()
        {
            if (!isFullScreen)
            {
                // Save current window size and position
                normalWindowBounds = this.Bounds;

                // Remove the title bar and border
                this.FormBorderStyle = FormBorderStyle.None;

                // Maximize the form to cover the entire screen
                this.WindowState = FormWindowState.Normal; // Reset window state before fullscreen
                this.Bounds = Screen.PrimaryScreen.Bounds;

                isFullScreen = true;
                wbvReplays.ZoomFactor = 1;
            }
            else
            {
                // Restore the window to its previous size and position
                this.FormBorderStyle = FormBorderStyle.Sizable;
                this.Bounds = normalWindowBounds;
                wbvReplays.ZoomFactor = 0.5;
                isFullScreen = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ToggleFullScreen();
        }

        private void frmReplays_Resize(object sender, EventArgs e)
        {
            
        }
        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F11)
            {
                ToggleFullScreen();
            }else if(e.KeyCode == Keys.Escape && this.isFullScreen)
            {
                ToggleFullScreen();
            }

            base.OnKeyDown(e);
        }
    }
}
