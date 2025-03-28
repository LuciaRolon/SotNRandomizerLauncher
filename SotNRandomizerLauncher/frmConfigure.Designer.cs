namespace SotNRandomizerLauncher
{
    partial class frmConfigure
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConfigure));
            this.txtBiosPath = new System.Windows.Forms.TextBox();
            this.lblBios = new System.Windows.Forms.Label();
            this.btnUploadBios = new System.Windows.Forms.Button();
            this.lblDescription = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnUploadTrack1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTrack1Path = new System.Windows.Forms.TextBox();
            this.btnUploadTrack2 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTrack2Path = new System.Windows.Forms.TextBox();
            this.btnUploadCue = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCuePath = new System.Windows.Forms.TextBox();
            this.btnContinue = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.cbImport = new System.Windows.Forms.CheckBox();
            this.grpEmulation = new System.Windows.Forms.GroupBox();
            this.lblCurrentCore = new System.Windows.Forms.Label();
            this.btnChangeCore = new System.Windows.Forms.Button();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.cbMapTracker = new System.Windows.Forms.CheckBox();
            this.btnDeleteUserData = new System.Windows.Forms.Button();
            this.grpLauncherSettings = new System.Windows.Forms.GroupBox();
            this.btnDeleteCustomPresets = new System.Windows.Forms.Button();
            this.btnCustomPreset = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.cbLiveSplit = new System.Windows.Forms.CheckBox();
            this.grpEmulation.SuspendLayout();
            this.grpLauncherSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtBiosPath
            // 
            this.txtBiosPath.Location = new System.Drawing.Point(44, 207);
            this.txtBiosPath.Name = "txtBiosPath";
            this.txtBiosPath.ReadOnly = true;
            this.txtBiosPath.Size = new System.Drawing.Size(448, 20);
            this.txtBiosPath.TabIndex = 0;
            // 
            // lblBios
            // 
            this.lblBios.AutoSize = true;
            this.lblBios.BackColor = System.Drawing.Color.Transparent;
            this.lblBios.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBios.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblBios.Location = new System.Drawing.Point(44, 188);
            this.lblBios.Name = "lblBios";
            this.lblBios.Size = new System.Drawing.Size(231, 17);
            this.lblBios.TabIndex = 1;
            this.lblBios.Text = "Select your BIOS (scph7003.bin) file:";
            // 
            // btnUploadBios
            // 
            this.btnUploadBios.Location = new System.Drawing.Point(498, 205);
            this.btnUploadBios.Name = "btnUploadBios";
            this.btnUploadBios.Size = new System.Drawing.Size(59, 23);
            this.btnUploadBios.TabIndex = 2;
            this.btnUploadBios.Text = "Select";
            this.btnUploadBios.UseVisualStyleBackColor = true;
            this.btnUploadBios.Click += new System.EventHandler(this.btnUploadBios_Click);
            // 
            // lblDescription
            // 
            this.lblDescription.BackColor = System.Drawing.Color.Transparent;
            this.lblDescription.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescription.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblDescription.Location = new System.Drawing.Point(41, 48);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(516, 127);
            this.lblDescription.TabIndex = 3;
            this.lblDescription.Text = resources.GetString("lblDescription.Text");
            this.lblDescription.Click += new System.EventHandler(this.lblDescription_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(101, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(368, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Welcome to Symphony of the Night Randomizer Launcher";
            // 
            // btnUploadTrack1
            // 
            this.btnUploadTrack1.Location = new System.Drawing.Point(498, 260);
            this.btnUploadTrack1.Name = "btnUploadTrack1";
            this.btnUploadTrack1.Size = new System.Drawing.Size(59, 23);
            this.btnUploadTrack1.TabIndex = 7;
            this.btnUploadTrack1.Text = "Select";
            this.btnUploadTrack1.UseVisualStyleBackColor = true;
            this.btnUploadTrack1.Click += new System.EventHandler(this.btnUploadTrack1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(44, 244);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(435, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "Select \"Castlevania - Symphony of the Night (USA) (Track 1).bin\" file:";
            // 
            // txtTrack1Path
            // 
            this.txtTrack1Path.Location = new System.Drawing.Point(44, 263);
            this.txtTrack1Path.Name = "txtTrack1Path";
            this.txtTrack1Path.ReadOnly = true;
            this.txtTrack1Path.Size = new System.Drawing.Size(448, 20);
            this.txtTrack1Path.TabIndex = 5;
            // 
            // btnUploadTrack2
            // 
            this.btnUploadTrack2.Location = new System.Drawing.Point(498, 317);
            this.btnUploadTrack2.Name = "btnUploadTrack2";
            this.btnUploadTrack2.Size = new System.Drawing.Size(59, 23);
            this.btnUploadTrack2.TabIndex = 10;
            this.btnUploadTrack2.Text = "Select";
            this.btnUploadTrack2.UseVisualStyleBackColor = true;
            this.btnUploadTrack2.Click += new System.EventHandler(this.btnUploadTrack2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Location = new System.Drawing.Point(44, 301);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(435, 17);
            this.label3.TabIndex = 9;
            this.label3.Text = "Select \"Castlevania - Symphony of the Night (USA) (Track 2).bin\" file:";
            // 
            // txtTrack2Path
            // 
            this.txtTrack2Path.Location = new System.Drawing.Point(44, 320);
            this.txtTrack2Path.Name = "txtTrack2Path";
            this.txtTrack2Path.ReadOnly = true;
            this.txtTrack2Path.Size = new System.Drawing.Size(448, 20);
            this.txtTrack2Path.TabIndex = 8;
            // 
            // btnUploadCue
            // 
            this.btnUploadCue.Location = new System.Drawing.Point(498, 377);
            this.btnUploadCue.Name = "btnUploadCue";
            this.btnUploadCue.Size = new System.Drawing.Size(59, 23);
            this.btnUploadCue.TabIndex = 13;
            this.btnUploadCue.Text = "Select";
            this.btnUploadCue.UseVisualStyleBackColor = true;
            this.btnUploadCue.Click += new System.EventHandler(this.btnUploadCue_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label4.Location = new System.Drawing.Point(44, 361);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(379, 17);
            this.label4.TabIndex = 12;
            this.label4.Text = "Select \"Castlevania - Symphony of the Night (USA).cue\" file:";
            // 
            // txtCuePath
            // 
            this.txtCuePath.Location = new System.Drawing.Point(44, 380);
            this.txtCuePath.Name = "txtCuePath";
            this.txtCuePath.ReadOnly = true;
            this.txtCuePath.Size = new System.Drawing.Size(448, 20);
            this.txtCuePath.TabIndex = 11;
            // 
            // btnContinue
            // 
            this.btnContinue.Enabled = false;
            this.btnContinue.Location = new System.Drawing.Point(423, 428);
            this.btnContinue.Name = "btnContinue";
            this.btnContinue.Size = new System.Drawing.Size(134, 35);
            this.btnContinue.TabIndex = 14;
            this.btnContinue.Text = "Confirm";
            this.btnContinue.UseVisualStyleBackColor = true;
            this.btnContinue.Click += new System.EventHandler(this.btnContinue_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(44, 440);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(104, 23);
            this.btnExit.TabIndex = 15;
            this.btnExit.Text = "Exit Launcher";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // cbImport
            // 
            this.cbImport.AutoSize = true;
            this.cbImport.BackColor = System.Drawing.Color.Transparent;
            this.cbImport.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbImport.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.cbImport.Location = new System.Drawing.Point(247, 431);
            this.cbImport.Name = "cbImport";
            this.cbImport.Size = new System.Drawing.Size(170, 30);
            this.cbImport.TabIndex = 16;
            this.cbImport.Text = "I want to use my own install\r\n of Bizhawk and LiveSplit";
            this.cbImport.UseVisualStyleBackColor = false;
            // 
            // grpEmulation
            // 
            this.grpEmulation.BackColor = System.Drawing.Color.Transparent;
            this.grpEmulation.Controls.Add(this.lblCurrentCore);
            this.grpEmulation.Controls.Add(this.btnChangeCore);
            this.grpEmulation.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpEmulation.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.grpEmulation.Location = new System.Drawing.Point(44, 40);
            this.grpEmulation.Name = "grpEmulation";
            this.grpEmulation.Size = new System.Drawing.Size(189, 127);
            this.grpEmulation.TabIndex = 18;
            this.grpEmulation.TabStop = false;
            this.grpEmulation.Text = "Emulation Settings";
            this.grpEmulation.Visible = false;
            // 
            // lblCurrentCore
            // 
            this.lblCurrentCore.AutoSize = true;
            this.lblCurrentCore.BackColor = System.Drawing.Color.Transparent;
            this.lblCurrentCore.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentCore.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblCurrentCore.Location = new System.Drawing.Point(11, 18);
            this.lblCurrentCore.Name = "lblCurrentCore";
            this.lblCurrentCore.Size = new System.Drawing.Size(145, 13);
            this.lblCurrentCore.TabIndex = 19;
            this.lblCurrentCore.Text = "Core Installed: Classic Core";
            this.lblCurrentCore.Click += new System.EventHandler(this.label5_Click);
            // 
            // btnChangeCore
            // 
            this.btnChangeCore.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChangeCore.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnChangeCore.Location = new System.Drawing.Point(14, 34);
            this.btnChangeCore.Name = "btnChangeCore";
            this.btnChangeCore.Size = new System.Drawing.Size(164, 29);
            this.btnChangeCore.TabIndex = 7;
            this.btnChangeCore.Text = "Change to Fast Core";
            this.toolTip.SetToolTip(this.btnChangeCore, "Changing to the Fast Core will improve performance and allow you to play the \r\nne" +
        "west presets, but will make it impossible to run other games with the emulator");
            this.btnChangeCore.UseVisualStyleBackColor = true;
            this.btnChangeCore.Click += new System.EventHandler(this.btnChangeCore_Click);
            // 
            // toolTip
            // 
            this.toolTip.AutomaticDelay = 200;
            this.toolTip.AutoPopDelay = 5000;
            this.toolTip.InitialDelay = 200;
            this.toolTip.ReshowDelay = 40;
            // 
            // cbMapTracker
            // 
            this.cbMapTracker.AutoSize = true;
            this.cbMapTracker.Location = new System.Drawing.Point(8, 98);
            this.cbMapTracker.Name = "cbMapTracker";
            this.cbMapTracker.Size = new System.Drawing.Size(226, 17);
            this.cbMapTracker.TabIndex = 2;
            this.cbMapTracker.Text = "Open Area Rando Map Tracker on Play";
            this.toolTip.SetToolTip(this.cbMapTracker, "Enables the Map Tracker used in Area Randomizer Seeds");
            this.cbMapTracker.UseVisualStyleBackColor = true;
            this.cbMapTracker.CheckedChanged += new System.EventHandler(this.cbMapTracker_CheckedChanged);
            // 
            // btnDeleteUserData
            // 
            this.btnDeleteUserData.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteUserData.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnDeleteUserData.Location = new System.Drawing.Point(8, 44);
            this.btnDeleteUserData.Name = "btnDeleteUserData";
            this.btnDeleteUserData.Size = new System.Drawing.Size(145, 22);
            this.btnDeleteUserData.TabIndex = 24;
            this.btnDeleteUserData.Text = "Delete User Data";
            this.toolTip.SetToolTip(this.btnDeleteUserData, "Unlinks this Launcher installation from your Discord Account. \r\nThis means next t" +
        "ime you open the Profile section, you will be\r\nprompted to select your Discord u" +
        "sername again.");
            this.btnDeleteUserData.UseVisualStyleBackColor = true;
            this.btnDeleteUserData.Click += new System.EventHandler(this.button2_Click);
            // 
            // grpLauncherSettings
            // 
            this.grpLauncherSettings.BackColor = System.Drawing.Color.Transparent;
            this.grpLauncherSettings.Controls.Add(this.btnDeleteUserData);
            this.grpLauncherSettings.Controls.Add(this.btnDeleteCustomPresets);
            this.grpLauncherSettings.Controls.Add(this.btnCustomPreset);
            this.grpLauncherSettings.Controls.Add(this.button1);
            this.grpLauncherSettings.Controls.Add(this.cbMapTracker);
            this.grpLauncherSettings.Controls.Add(this.cbLiveSplit);
            this.grpLauncherSettings.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpLauncherSettings.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.grpLauncherSettings.Location = new System.Drawing.Point(239, 40);
            this.grpLauncherSettings.Name = "grpLauncherSettings";
            this.grpLauncherSettings.Size = new System.Drawing.Size(318, 127);
            this.grpLauncherSettings.TabIndex = 20;
            this.grpLauncherSettings.TabStop = false;
            this.grpLauncherSettings.Text = "Launcher Settings";
            this.grpLauncherSettings.Visible = false;
            // 
            // btnDeleteCustomPresets
            // 
            this.btnDeleteCustomPresets.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteCustomPresets.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnDeleteCustomPresets.Location = new System.Drawing.Point(167, 72);
            this.btnDeleteCustomPresets.Name = "btnDeleteCustomPresets";
            this.btnDeleteCustomPresets.Size = new System.Drawing.Size(145, 22);
            this.btnDeleteCustomPresets.TabIndex = 23;
            this.btnDeleteCustomPresets.Text = "Delete all Custom Presets";
            this.btnDeleteCustomPresets.UseVisualStyleBackColor = true;
            this.btnDeleteCustomPresets.Click += new System.EventHandler(this.btnDeleteCustomPresets_Click);
            // 
            // btnCustomPreset
            // 
            this.btnCustomPreset.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCustomPreset.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnCustomPreset.Location = new System.Drawing.Point(167, 44);
            this.btnCustomPreset.Name = "btnCustomPreset";
            this.btnCustomPreset.Size = new System.Drawing.Size(145, 22);
            this.btnCustomPreset.TabIndex = 22;
            this.btnCustomPreset.Text = "Add Custom Preset";
            this.btnCustomPreset.UseVisualStyleBackColor = true;
            this.btnCustomPreset.Click += new System.EventHandler(this.btnCustomPreset_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button1.Location = new System.Drawing.Point(167, 16);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(145, 22);
            this.button1.TabIndex = 21;
            this.button1.Text = "Open ROM Folder";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cbLiveSplit
            // 
            this.cbLiveSplit.AutoSize = true;
            this.cbLiveSplit.Checked = true;
            this.cbLiveSplit.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbLiveSplit.Location = new System.Drawing.Point(8, 21);
            this.cbLiveSplit.Name = "cbLiveSplit";
            this.cbLiveSplit.Size = new System.Drawing.Size(143, 17);
            this.cbLiveSplit.TabIndex = 0;
            this.cbLiveSplit.Text = "Open LiveSplit on Play";
            this.cbLiveSplit.UseVisualStyleBackColor = true;
            this.cbLiveSplit.CheckedChanged += new System.EventHandler(this.cbLiveSplit_CheckedChanged);
            // 
            // frmConfigure
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::SotNRandomizerLauncher.Properties.Resources.gradient;
            this.ClientSize = new System.Drawing.Size(595, 481);
            this.ControlBox = false;
            this.Controls.Add(this.grpLauncherSettings);
            this.Controls.Add(this.grpEmulation);
            this.Controls.Add(this.cbImport);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnContinue);
            this.Controls.Add(this.btnUploadCue);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtCuePath);
            this.Controls.Add(this.btnUploadTrack2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtTrack2Path);
            this.Controls.Add(this.btnUploadTrack1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTrack1Path);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.btnUploadBios);
            this.Controls.Add(this.lblBios);
            this.Controls.Add(this.txtBiosPath);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmConfigure";
            this.Text = "Symphony of the Night Randomizer Launcher - Setup";
            this.grpEmulation.ResumeLayout(false);
            this.grpEmulation.PerformLayout();
            this.grpLauncherSettings.ResumeLayout(false);
            this.grpLauncherSettings.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtBiosPath;
        private System.Windows.Forms.Label lblBios;
        private System.Windows.Forms.Button btnUploadBios;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnUploadTrack1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTrack1Path;
        private System.Windows.Forms.Button btnUploadTrack2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTrack2Path;
        private System.Windows.Forms.Button btnUploadCue;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCuePath;
        private System.Windows.Forms.Button btnContinue;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.CheckBox cbImport;
        private System.Windows.Forms.GroupBox grpEmulation;
        private System.Windows.Forms.Button btnChangeCore;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Label lblCurrentCore;
        private System.Windows.Forms.GroupBox grpLauncherSettings;
        private System.Windows.Forms.CheckBox cbMapTracker;
        private System.Windows.Forms.CheckBox cbLiveSplit;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnDeleteCustomPresets;
        private System.Windows.Forms.Button btnCustomPreset;
        private System.Windows.Forms.Button btnDeleteUserData;
    }
}