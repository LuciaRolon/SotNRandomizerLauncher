namespace SotNRandomizerLauncher
{
    partial class frmRandomizer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRandomizer));
            this.grpRandomizations = new System.Windows.Forms.GroupBox();
            this.txtSeed = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbPreset = new System.Windows.Forms.ComboBox();
            this.lblNextEvent = new System.Windows.Forms.Label();
            this.grpSettings = new System.Windows.Forms.GroupBox();
            this.cbComplexity = new System.Windows.Forms.ComboBox();
            this.cbCustomComplexity = new System.Windows.Forms.CheckBox();
            this.cbColor = new System.Windows.Forms.ComboBox();
            this.cbMyPurse = new System.Windows.Forms.CheckBox();
            this.cbMapColor = new System.Windows.Forms.CheckBox();
            this.cbColorRando = new System.Windows.Forms.CheckBox();
            this.cbExtension = new System.Windows.Forms.ComboBox();
            this.cbRelicExtension = new System.Windows.Forms.CheckBox();
            this.cbAntiFreeze = new System.Windows.Forms.CheckBox();
            this.cbMagicMax = new System.Windows.Forms.CheckBox();
            this.cbShowEquipment = new System.Windows.Forms.CheckBox();
            this.cbVanillaMusic = new System.Windows.Forms.CheckBox();
            this.cbTournamentMode = new System.Windows.Forms.CheckBox();
            this.btnGeneratePPF = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.lblSeed = new System.Windows.Forms.Label();
            this.lblStartingEquipment = new System.Windows.Forms.Label();
            this.pgbRandomizingProgress = new System.Windows.Forms.ProgressBar();
            this.lblTimeGenerating = new System.Windows.Forms.Label();
            this.randomizerTimer = new System.Windows.Forms.Timer(this.components);
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.lblDescription = new System.Windows.Forms.Label();
            this.grpRandomizations.SuspendLayout();
            this.grpSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpRandomizations
            // 
            this.grpRandomizations.BackColor = System.Drawing.Color.Transparent;
            this.grpRandomizations.Controls.Add(this.lblDescription);
            this.grpRandomizations.Controls.Add(this.txtSeed);
            this.grpRandomizations.Controls.Add(this.label1);
            this.grpRandomizations.Controls.Add(this.cbPreset);
            this.grpRandomizations.Controls.Add(this.lblNextEvent);
            this.grpRandomizations.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpRandomizations.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.grpRandomizations.Location = new System.Drawing.Point(12, 12);
            this.grpRandomizations.Name = "grpRandomizations";
            this.grpRandomizations.Size = new System.Drawing.Size(394, 80);
            this.grpRandomizations.TabIndex = 4;
            this.grpRandomizations.TabStop = false;
            this.grpRandomizations.Text = "Randomizations";
            // 
            // txtSeed
            // 
            this.txtSeed.BackColor = System.Drawing.SystemColors.InfoText;
            this.txtSeed.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtSeed.Location = new System.Drawing.Point(83, 46);
            this.txtSeed.Name = "txtSeed";
            this.txtSeed.Size = new System.Drawing.Size(305, 22);
            this.txtSeed.TabIndex = 7;
            this.txtSeed.Text = "(Optional)";
            this.txtSeed.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtSeed_MouseClick);
            this.txtSeed.Leave += new System.EventHandler(this.txtSeed_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(19, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "Seed:";
            // 
            // cbPreset
            // 
            this.cbPreset.BackColor = System.Drawing.SystemColors.InfoText;
            this.cbPreset.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPreset.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.cbPreset.FormattingEnabled = true;
            this.cbPreset.Items.AddRange(new object[] {
            "Casual",
            "Adventure",
            "Bountyhunter",
            "Legday",
            "Magicmirror"});
            this.cbPreset.Location = new System.Drawing.Point(83, 19);
            this.cbPreset.Name = "cbPreset";
            this.cbPreset.Size = new System.Drawing.Size(281, 21);
            this.cbPreset.TabIndex = 5;
            this.cbPreset.SelectedIndexChanged += new System.EventHandler(this.cbPreset_SelectedIndexChanged);
            this.cbPreset.SelectedValueChanged += new System.EventHandler(this.cbPreset_SelectedValueChanged);
            // 
            // lblNextEvent
            // 
            this.lblNextEvent.AutoSize = true;
            this.lblNextEvent.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNextEvent.Location = new System.Drawing.Point(8, 18);
            this.lblNextEvent.Name = "lblNextEvent";
            this.lblNextEvent.Size = new System.Drawing.Size(57, 20);
            this.lblNextEvent.TabIndex = 1;
            this.lblNextEvent.Text = "Preset:";
            // 
            // grpSettings
            // 
            this.grpSettings.BackColor = System.Drawing.Color.Transparent;
            this.grpSettings.Controls.Add(this.cbComplexity);
            this.grpSettings.Controls.Add(this.cbCustomComplexity);
            this.grpSettings.Controls.Add(this.cbColor);
            this.grpSettings.Controls.Add(this.cbMyPurse);
            this.grpSettings.Controls.Add(this.cbMapColor);
            this.grpSettings.Controls.Add(this.cbColorRando);
            this.grpSettings.Controls.Add(this.cbExtension);
            this.grpSettings.Controls.Add(this.cbRelicExtension);
            this.grpSettings.Controls.Add(this.cbAntiFreeze);
            this.grpSettings.Controls.Add(this.cbMagicMax);
            this.grpSettings.Controls.Add(this.cbShowEquipment);
            this.grpSettings.Controls.Add(this.cbVanillaMusic);
            this.grpSettings.Controls.Add(this.cbTournamentMode);
            this.grpSettings.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpSettings.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.grpSettings.Location = new System.Drawing.Point(12, 107);
            this.grpSettings.Name = "grpSettings";
            this.grpSettings.Size = new System.Drawing.Size(394, 228);
            this.grpSettings.TabIndex = 8;
            this.grpSettings.TabStop = false;
            this.grpSettings.Text = "Settings";
            // 
            // cbComplexity
            // 
            this.cbComplexity.BackColor = System.Drawing.SystemColors.InfoText;
            this.cbComplexity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbComplexity.Enabled = false;
            this.cbComplexity.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.cbComplexity.FormattingEnabled = true;
            this.cbComplexity.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.cbComplexity.Location = new System.Drawing.Point(196, 131);
            this.cbComplexity.Name = "cbComplexity";
            this.cbComplexity.Size = new System.Drawing.Size(160, 21);
            this.cbComplexity.TabIndex = 18;
            this.cbComplexity.SelectedIndexChanged += new System.EventHandler(this.cbComplexity_SelectedIndexChanged);
            this.cbComplexity.EnabledChanged += new System.EventHandler(this.cbComplexity_EnabledChanged);
            // 
            // cbCustomComplexity
            // 
            this.cbCustomComplexity.AutoSize = true;
            this.cbCustomComplexity.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCustomComplexity.Location = new System.Drawing.Point(19, 131);
            this.cbCustomComplexity.Name = "cbCustomComplexity";
            this.cbCustomComplexity.Size = new System.Drawing.Size(152, 21);
            this.cbCustomComplexity.TabIndex = 17;
            this.cbCustomComplexity.Text = "Custom Complexity:";
            this.toolTip.SetToolTip(this.cbCustomComplexity, "Changes the complexity of the preset. CAUTION: This can break a seed.");
            this.cbCustomComplexity.UseVisualStyleBackColor = true;
            this.cbCustomComplexity.CheckedChanged += new System.EventHandler(this.cbCustomComplexity_CheckedChanged);
            // 
            // cbColor
            // 
            this.cbColor.BackColor = System.Drawing.SystemColors.InfoText;
            this.cbColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbColor.Enabled = false;
            this.cbColor.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.cbColor.FormattingEnabled = true;
            this.cbColor.Items.AddRange(new object[] {
            "Blue",
            "Crimson",
            "Brown",
            "Green",
            "Gray",
            "Purple",
            "Pink"});
            this.cbColor.Location = new System.Drawing.Point(196, 158);
            this.cbColor.Name = "cbColor";
            this.cbColor.Size = new System.Drawing.Size(160, 21);
            this.cbColor.TabIndex = 16;
            this.cbColor.EnabledChanged += new System.EventHandler(this.cbColor_EnabledChanged);
            // 
            // cbMyPurse
            // 
            this.cbMyPurse.AutoSize = true;
            this.cbMyPurse.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbMyPurse.Location = new System.Drawing.Point(19, 105);
            this.cbMyPurse.Name = "cbMyPurse";
            this.cbMyPurse.Size = new System.Drawing.Size(168, 21);
            this.cbMyPurse.TabIndex = 15;
            this.cbMyPurse.Text = "That\'s My Purse! Mode";
            this.toolTip.SetToolTip(this.cbMyPurse, "Prevents Death from stealing your gear.");
            this.cbMyPurse.UseVisualStyleBackColor = true;
            // 
            // cbMapColor
            // 
            this.cbMapColor.AutoSize = true;
            this.cbMapColor.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbMapColor.Location = new System.Drawing.Point(19, 158);
            this.cbMapColor.Name = "cbMapColor";
            this.cbMapColor.Size = new System.Drawing.Size(147, 21);
            this.cbMapColor.TabIndex = 14;
            this.cbMapColor.Text = "Custom Map Color:";
            this.toolTip.SetToolTip(this.cbMapColor, "Changes the color of the map ingame");
            this.cbMapColor.UseVisualStyleBackColor = true;
            this.cbMapColor.CheckedChanged += new System.EventHandler(this.cbMapColor_CheckedChanged);
            // 
            // cbColorRando
            // 
            this.cbColorRando.AutoSize = true;
            this.cbColorRando.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbColorRando.Location = new System.Drawing.Point(222, 78);
            this.cbColorRando.Name = "cbColorRando";
            this.cbColorRando.Size = new System.Drawing.Size(142, 21);
            this.cbColorRando.TabIndex = 13;
            this.cbColorRando.Text = "Color Rando Mode";
            this.toolTip.SetToolTip(this.cbColorRando, "Randomizes various color palettes.");
            this.cbColorRando.UseVisualStyleBackColor = true;
            // 
            // cbExtension
            // 
            this.cbExtension.BackColor = System.Drawing.SystemColors.InfoText;
            this.cbExtension.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbExtension.Enabled = false;
            this.cbExtension.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.cbExtension.FormattingEnabled = true;
            this.cbExtension.Items.AddRange(new object[] {
            "Guarded",
            "Equipment",
            "Spread",
            "Tourist",
            "Wanderer"});
            this.cbExtension.Location = new System.Drawing.Point(196, 186);
            this.cbExtension.Name = "cbExtension";
            this.cbExtension.Size = new System.Drawing.Size(160, 21);
            this.cbExtension.TabIndex = 8;
            this.cbExtension.EnabledChanged += new System.EventHandler(this.cbExtension_EnabledChanged);
            // 
            // cbRelicExtension
            // 
            this.cbRelicExtension.AutoSize = true;
            this.cbRelicExtension.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbRelicExtension.Location = new System.Drawing.Point(19, 185);
            this.cbRelicExtension.Name = "cbRelicExtension";
            this.cbRelicExtension.Size = new System.Drawing.Size(175, 21);
            this.cbRelicExtension.TabIndex = 12;
            this.cbRelicExtension.Text = "Custom Relic Extension:";
            this.toolTip.SetToolTip(this.cbRelicExtension, "Modifies the Preset\'s Relic Locations");
            this.cbRelicExtension.UseVisualStyleBackColor = true;
            this.cbRelicExtension.CheckedChanged += new System.EventHandler(this.cbRelicExtension_CheckedChanged);
            // 
            // cbAntiFreeze
            // 
            this.cbAntiFreeze.AutoSize = true;
            this.cbAntiFreeze.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbAntiFreeze.Location = new System.Drawing.Point(222, 51);
            this.cbAntiFreeze.Name = "cbAntiFreeze";
            this.cbAntiFreeze.Size = new System.Drawing.Size(135, 21);
            this.cbAntiFreeze.TabIndex = 11;
            this.cbAntiFreeze.Text = "Anti Freeze Mode";
            this.toolTip.SetToolTip(this.cbAntiFreeze, "Removes screen freezes from Level Ups");
            this.cbAntiFreeze.UseVisualStyleBackColor = true;
            // 
            // cbMagicMax
            // 
            this.cbMagicMax.AutoSize = true;
            this.cbMagicMax.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbMagicMax.Location = new System.Drawing.Point(222, 24);
            this.cbMagicMax.Name = "cbMagicMax";
            this.cbMagicMax.Size = new System.Drawing.Size(133, 21);
            this.cbMagicMax.TabIndex = 10;
            this.cbMagicMax.Text = "Magic Max Mode";
            this.toolTip.SetToolTip(this.cbMagicMax, "Replaces \"Heart Max Ups\" with \"Magic Max Ups\".");
            this.cbMagicMax.UseVisualStyleBackColor = true;
            // 
            // cbShowEquipment
            // 
            this.cbShowEquipment.AutoSize = true;
            this.cbShowEquipment.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbShowEquipment.Location = new System.Drawing.Point(18, 78);
            this.cbShowEquipment.Name = "cbShowEquipment";
            this.cbShowEquipment.Size = new System.Drawing.Size(184, 21);
            this.cbShowEquipment.TabIndex = 9;
            this.cbShowEquipment.Text = "Show Starting Equipment";
            this.cbShowEquipment.UseVisualStyleBackColor = true;
            // 
            // cbVanillaMusic
            // 
            this.cbVanillaMusic.AutoSize = true;
            this.cbVanillaMusic.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbVanillaMusic.Location = new System.Drawing.Point(18, 51);
            this.cbVanillaMusic.Name = "cbVanillaMusic";
            this.cbVanillaMusic.Size = new System.Drawing.Size(109, 21);
            this.cbVanillaMusic.TabIndex = 8;
            this.cbVanillaMusic.Text = "Vanilla Music";
            this.cbVanillaMusic.UseVisualStyleBackColor = true;
            // 
            // cbTournamentMode
            // 
            this.cbTournamentMode.AutoSize = true;
            this.cbTournamentMode.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbTournamentMode.Location = new System.Drawing.Point(18, 24);
            this.cbTournamentMode.Name = "cbTournamentMode";
            this.cbTournamentMode.Size = new System.Drawing.Size(141, 21);
            this.cbTournamentMode.TabIndex = 7;
            this.cbTournamentMode.Text = "Tournament Mode";
            this.toolTip.SetToolTip(this.cbTournamentMode, "Sets library shop relic cost to 0. Clock room is always open.");
            this.cbTournamentMode.UseVisualStyleBackColor = true;
            // 
            // btnGeneratePPF
            // 
            this.btnGeneratePPF.Enabled = false;
            this.btnGeneratePPF.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGeneratePPF.Location = new System.Drawing.Point(12, 335);
            this.btnGeneratePPF.Name = "btnGeneratePPF";
            this.btnGeneratePPF.Size = new System.Drawing.Size(394, 29);
            this.btnGeneratePPF.TabIndex = 9;
            this.btnGeneratePPF.Text = "Generate PPF";
            this.btnGeneratePPF.UseVisualStyleBackColor = true;
            this.btnGeneratePPF.Click += new System.EventHandler(this.btnConfigure_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(9, 497);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(107, 29);
            this.button2.TabIndex = 11;
            this.button2.Text = "Back to Launcher";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // lblSeed
            // 
            this.lblSeed.AutoSize = true;
            this.lblSeed.BackColor = System.Drawing.Color.Transparent;
            this.lblSeed.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSeed.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblSeed.Location = new System.Drawing.Point(10, 367);
            this.lblSeed.Name = "lblSeed";
            this.lblSeed.Size = new System.Drawing.Size(208, 20);
            this.lblSeed.TabIndex = 8;
            this.lblSeed.Text = "Seed: No seed generated yet";
            this.lblSeed.Click += new System.EventHandler(this.lblSeed_Click);
            // 
            // lblStartingEquipment
            // 
            this.lblStartingEquipment.AutoSize = true;
            this.lblStartingEquipment.BackColor = System.Drawing.Color.Transparent;
            this.lblStartingEquipment.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStartingEquipment.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblStartingEquipment.Location = new System.Drawing.Point(11, 387);
            this.lblStartingEquipment.Name = "lblStartingEquipment";
            this.lblStartingEquipment.Size = new System.Drawing.Size(233, 15);
            this.lblStartingEquipment.TabIndex = 12;
            this.lblStartingEquipment.Text = "Starting equipment: No seed generated yet";
            this.lblStartingEquipment.Click += new System.EventHandler(this.label2_Click);
            // 
            // pgbRandomizingProgress
            // 
            this.pgbRandomizingProgress.Location = new System.Drawing.Point(122, 497);
            this.pgbRandomizingProgress.Name = "pgbRandomizingProgress";
            this.pgbRandomizingProgress.Size = new System.Drawing.Size(275, 29);
            this.pgbRandomizingProgress.TabIndex = 13;
            // 
            // lblTimeGenerating
            // 
            this.lblTimeGenerating.BackColor = System.Drawing.Color.Transparent;
            this.lblTimeGenerating.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimeGenerating.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblTimeGenerating.Location = new System.Drawing.Point(252, 473);
            this.lblTimeGenerating.Name = "lblTimeGenerating";
            this.lblTimeGenerating.Size = new System.Drawing.Size(145, 21);
            this.lblTimeGenerating.TabIndex = 14;
            this.lblTimeGenerating.Text = "Time Generating: {time}";
            this.lblTimeGenerating.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblTimeGenerating.Visible = false;
            // 
            // randomizerTimer
            // 
            this.randomizerTimer.Interval = 1000;
            this.randomizerTimer.Tick += new System.EventHandler(this.randomizerTimer_Tick);
            // 
            // toolTip
            // 
            this.toolTip.AutoPopDelay = 10000;
            this.toolTip.InitialDelay = 100;
            this.toolTip.ReshowDelay = 100;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.BackColor = System.Drawing.Color.Transparent;
            this.lblDescription.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescription.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblDescription.Location = new System.Drawing.Point(370, 18);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(17, 21);
            this.lblDescription.TabIndex = 15;
            this.lblDescription.Text = "?";
            // 
            // frmRandomizer
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = global::SotNRandomizerLauncher.Properties.Resources.gradient;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(418, 535);
            this.Controls.Add(this.lblTimeGenerating);
            this.Controls.Add(this.pgbRandomizingProgress);
            this.Controls.Add(this.lblSeed);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnGeneratePPF);
            this.Controls.Add(this.grpSettings);
            this.Controls.Add(this.grpRandomizations);
            this.Controls.Add(this.lblStartingEquipment);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmRandomizer";
            this.Text = "Symphony of the Night Randomizer";
            this.Load += new System.EventHandler(this.frmRandomizer_Load);
            this.grpRandomizations.ResumeLayout(false);
            this.grpRandomizations.PerformLayout();
            this.grpSettings.ResumeLayout(false);
            this.grpSettings.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpRandomizations;
        private System.Windows.Forms.TextBox txtSeed;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbPreset;
        private System.Windows.Forms.Label lblNextEvent;
        private System.Windows.Forms.GroupBox grpSettings;
        private System.Windows.Forms.CheckBox cbVanillaMusic;
        private System.Windows.Forms.CheckBox cbTournamentMode;
        private System.Windows.Forms.CheckBox cbShowEquipment;
        private System.Windows.Forms.Button btnGeneratePPF;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label lblSeed;
        private System.Windows.Forms.Label lblStartingEquipment;
        private System.Windows.Forms.ProgressBar pgbRandomizingProgress;
        private System.Windows.Forms.Label lblTimeGenerating;
        private System.Windows.Forms.Timer randomizerTimer;
        private System.Windows.Forms.ComboBox cbExtension;
        private System.Windows.Forms.CheckBox cbRelicExtension;
        private System.Windows.Forms.CheckBox cbAntiFreeze;
        private System.Windows.Forms.CheckBox cbMagicMax;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ComboBox cbComplexity;
        private System.Windows.Forms.CheckBox cbCustomComplexity;
        private System.Windows.Forms.ComboBox cbColor;
        private System.Windows.Forms.CheckBox cbMyPurse;
        private System.Windows.Forms.CheckBox cbMapColor;
        private System.Windows.Forms.CheckBox cbColorRando;
        private System.Windows.Forms.Label lblDescription;
    }
}