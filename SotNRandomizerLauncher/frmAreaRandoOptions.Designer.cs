namespace SotNRandomizerLauncher
{
    partial class frmAreaRandoOptions
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.cbRandomStartingPoint = new System.Windows.Forms.CheckBox();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbRelic = new System.Windows.Forms.ComboBox();
            this.cb2Castle = new System.Windows.Forms.CheckBox();
            this.cbBlockCaverns = new System.Windows.Forms.CheckBox();
            this.cbDisableFlash = new System.Windows.Forms.CheckBox();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cbRandomStartingPoint
            // 
            this.cbRandomStartingPoint.AutoSize = true;
            this.cbRandomStartingPoint.BackColor = System.Drawing.Color.Transparent;
            this.cbRandomStartingPoint.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbRandomStartingPoint.Location = new System.Drawing.Point(58, 103);
            this.cbRandomStartingPoint.Name = "cbRandomStartingPoint";
            this.cbRandomStartingPoint.Size = new System.Drawing.Size(152, 19);
            this.cbRandomStartingPoint.TabIndex = 0;
            this.cbRandomStartingPoint.Text = "Random Starting Point";
            this.toolTip.SetToolTip(this.cbRandomStartingPoint, "Randomizes where you first spawn.");
            this.cbRandomStartingPoint.UseVisualStyleBackColor = false;
            this.cbRandomStartingPoint.CheckedChanged += new System.EventHandler(this.cbRandomStartingPoint_CheckedChanged);
            // 
            // toolTip
            // 
            this.toolTip.AutoPopDelay = 10000;
            this.toolTip.InitialDelay = 100;
            this.toolTip.ReshowDelay = 100;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(55, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Starting Relic:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(96, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(215, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Area Randomizer - Advanced Options";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(12, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(394, 32);
            this.label3.TabIndex = 4;
            this.label3.Text = "The options set by default are the recommended ones, which are used in Tournament" +
    "s and Ranked Races, but feel free to choose any from the list!";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbRelic
            // 
            this.cbRelic.BackColor = System.Drawing.SystemColors.InfoText;
            this.cbRelic.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRelic.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.cbRelic.FormattingEnabled = true;
            this.cbRelic.Items.AddRange(new object[] {
            "Leap Stone",
            "Gravity Boots",
            "Soul of Bat",
            "Spirit Orb",
            "Faerie Scroll"});
            this.cbRelic.Location = new System.Drawing.Point(146, 72);
            this.cbRelic.Name = "cbRelic";
            this.cbRelic.Size = new System.Drawing.Size(226, 23);
            this.cbRelic.TabIndex = 6;
            // 
            // cb2Castle
            // 
            this.cb2Castle.AutoSize = true;
            this.cb2Castle.BackColor = System.Drawing.Color.Transparent;
            this.cb2Castle.Enabled = false;
            this.cb2Castle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb2Castle.Location = new System.Drawing.Point(216, 103);
            this.cb2Castle.Name = "cb2Castle";
            this.cb2Castle.Size = new System.Drawing.Size(127, 19);
            this.cb2Castle.TabIndex = 7;
            this.cb2Castle.Text = "Include 2nd Castle";
            this.toolTip.SetToolTip(this.cb2Castle, "Includes the 2nd Castle for Starting Point Randomization");
            this.cb2Castle.UseVisualStyleBackColor = false;
            // 
            // cbBlockCaverns
            // 
            this.cbBlockCaverns.AutoSize = true;
            this.cbBlockCaverns.BackColor = System.Drawing.Color.Transparent;
            this.cbBlockCaverns.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbBlockCaverns.Location = new System.Drawing.Point(58, 128);
            this.cbBlockCaverns.Name = "cbBlockCaverns";
            this.cbBlockCaverns.Size = new System.Drawing.Size(174, 19);
            this.cbBlockCaverns.TabIndex = 8;
            this.cbBlockCaverns.Text = "Block Caverns on First visit";
            this.toolTip.SetToolTip(this.cbBlockCaverns, "Block going to the caverns in Area Randomizer mode on the 1st trip through the En" +
        "trance.");
            this.cbBlockCaverns.UseVisualStyleBackColor = false;
            // 
            // cbDisableFlash
            // 
            this.cbDisableFlash.AutoSize = true;
            this.cbDisableFlash.BackColor = System.Drawing.Color.Transparent;
            this.cbDisableFlash.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbDisableFlash.Location = new System.Drawing.Point(58, 153);
            this.cbDisableFlash.Name = "cbDisableFlash";
            this.cbDisableFlash.Size = new System.Drawing.Size(138, 19);
            this.cbDisableFlash.TabIndex = 9;
            this.cbDisableFlash.Text = "Disable Flash Effects";
            this.toolTip.SetToolTip(this.cbDisableFlash, "Removes screen flashing effects.");
            this.cbDisableFlash.UseVisualStyleBackColor = false;
            // 
            // btnConfirm
            // 
            this.btnConfirm.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnConfirm.Location = new System.Drawing.Point(86, 191);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(244, 31);
            this.btnConfirm.TabIndex = 10;
            this.btnConfirm.Text = "Confirm";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // frmAreaRandoOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::SotNRandomizerLauncher.Properties.Resources.gradient;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(413, 242);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.cbDisableFlash);
            this.Controls.Add(this.cbBlockCaverns);
            this.Controls.Add(this.cb2Castle);
            this.Controls.Add(this.cbRelic);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbRandomStartingPoint);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.Control;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.Name = "frmAreaRandoOptions";
            this.ShowIcon = false;
            this.Text = "Area Randomizer Options";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox cbRandomStartingPoint;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbRelic;
        private System.Windows.Forms.CheckBox cb2Castle;
        private System.Windows.Forms.CheckBox cbBlockCaverns;
        private System.Windows.Forms.CheckBox cbDisableFlash;
        private System.Windows.Forms.Button btnConfirm;
    }
}