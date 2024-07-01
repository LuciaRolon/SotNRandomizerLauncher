namespace SotNRandomizerLauncher
{
    partial class frmTutorials
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTutorials));
            this.lblTutorialDescription = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.lblRandoTutorial = new System.Windows.Forms.Label();
            this.lblSymphonyRando = new System.Windows.Forms.LinkLabel();
            this.lblPresetsTutorial = new System.Windows.Forms.Label();
            this.btnLongLibraryDiscord = new System.Windows.Forms.Button();
            this.lblRandomizer = new System.Windows.Forms.Button();
            this.lblLauncher = new System.Windows.Forms.Button();
            this.lblPresets = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTutorialDescription
            // 
            this.lblTutorialDescription.BackColor = System.Drawing.Color.Transparent;
            this.lblTutorialDescription.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTutorialDescription.Location = new System.Drawing.Point(167, 22);
            this.lblTutorialDescription.Name = "lblTutorialDescription";
            this.lblTutorialDescription.Size = new System.Drawing.Size(461, 470);
            this.lblTutorialDescription.TabIndex = 0;
            this.lblTutorialDescription.Text = resources.GetString("lblTutorialDescription.Text");
            this.lblTutorialDescription.Visible = false;
            this.lblTutorialDescription.Click += new System.EventHandler(this.lblTutorialDescription_Click);
            // 
            // btnBack
            // 
            this.btnBack.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnBack.Location = new System.Drawing.Point(12, 459);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(149, 33);
            this.btnBack.TabIndex = 1;
            this.btnBack.Text = "Back to Launcher";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // lblRandoTutorial
            // 
            this.lblRandoTutorial.BackColor = System.Drawing.Color.Transparent;
            this.lblRandoTutorial.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRandoTutorial.Location = new System.Drawing.Point(167, 22);
            this.lblRandoTutorial.Name = "lblRandoTutorial";
            this.lblRandoTutorial.Size = new System.Drawing.Size(461, 470);
            this.lblRandoTutorial.TabIndex = 4;
            this.lblRandoTutorial.Text = resources.GetString("lblRandoTutorial.Text");
            // 
            // lblSymphonyRando
            // 
            this.lblSymphonyRando.ActiveLinkColor = System.Drawing.Color.LightCoral;
            this.lblSymphonyRando.AutoSize = true;
            this.lblSymphonyRando.BackColor = System.Drawing.Color.Transparent;
            this.lblSymphonyRando.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSymphonyRando.LinkColor = System.Drawing.Color.IndianRed;
            this.lblSymphonyRando.Location = new System.Drawing.Point(296, 481);
            this.lblSymphonyRando.Name = "lblSymphonyRando";
            this.lblSymphonyRando.Size = new System.Drawing.Size(339, 13);
            this.lblSymphonyRando.TabIndex = 6;
            this.lblSymphonyRando.TabStop = true;
            this.lblSymphonyRando.Text = "Find more Randomizer info at https://www.symphonyrando.fun/";
            this.lblSymphonyRando.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblSymphonyRando_LinkClicked);
            // 
            // lblPresetsTutorial
            // 
            this.lblPresetsTutorial.BackColor = System.Drawing.Color.Transparent;
            this.lblPresetsTutorial.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPresetsTutorial.Location = new System.Drawing.Point(167, 22);
            this.lblPresetsTutorial.Name = "lblPresetsTutorial";
            this.lblPresetsTutorial.Size = new System.Drawing.Size(461, 470);
            this.lblPresetsTutorial.TabIndex = 7;
            this.lblPresetsTutorial.Text = resources.GetString("lblPresetsTutorial.Text");
            this.lblPresetsTutorial.Visible = false;
            // 
            // btnLongLibraryDiscord
            // 
            this.btnLongLibraryDiscord.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLongLibraryDiscord.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnLongLibraryDiscord.Location = new System.Drawing.Point(12, 408);
            this.btnLongLibraryDiscord.Name = "btnLongLibraryDiscord";
            this.btnLongLibraryDiscord.Size = new System.Drawing.Size(149, 33);
            this.btnLongLibraryDiscord.TabIndex = 8;
            this.btnLongLibraryDiscord.Text = "Long Library Discord";
            this.btnLongLibraryDiscord.UseVisualStyleBackColor = true;
            this.btnLongLibraryDiscord.Click += new System.EventHandler(this.btnLongLibraryDiscord_Click);
            // 
            // lblRandomizer
            // 
            this.lblRandomizer.BackColor = System.Drawing.Color.IndianRed;
            this.lblRandomizer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.lblRandomizer.FlatAppearance.BorderSize = 0;
            this.lblRandomizer.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Brown;
            this.lblRandomizer.FlatAppearance.MouseOverBackColor = System.Drawing.Color.IndianRed;
            this.lblRandomizer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblRandomizer.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRandomizer.ForeColor = System.Drawing.Color.Transparent;
            this.lblRandomizer.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.lblRandomizer.Location = new System.Drawing.Point(12, 23);
            this.lblRandomizer.Name = "lblRandomizer";
            this.lblRandomizer.Size = new System.Drawing.Size(149, 32);
            this.lblRandomizer.TabIndex = 9;
            this.lblRandomizer.Tag = "btn";
            this.lblRandomizer.Text = "Randomizer Tutorial";
            this.lblRandomizer.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.lblRandomizer.UseVisualStyleBackColor = false;
            this.lblRandomizer.Click += new System.EventHandler(this.lblRandomizer_Click);
            // 
            // lblLauncher
            // 
            this.lblLauncher.BackColor = System.Drawing.Color.Transparent;
            this.lblLauncher.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.lblLauncher.FlatAppearance.BorderSize = 0;
            this.lblLauncher.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Brown;
            this.lblLauncher.FlatAppearance.MouseOverBackColor = System.Drawing.Color.IndianRed;
            this.lblLauncher.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblLauncher.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLauncher.ForeColor = System.Drawing.Color.Transparent;
            this.lblLauncher.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.lblLauncher.Location = new System.Drawing.Point(12, 70);
            this.lblLauncher.Name = "lblLauncher";
            this.lblLauncher.Size = new System.Drawing.Size(149, 32);
            this.lblLauncher.TabIndex = 10;
            this.lblLauncher.Tag = "btn";
            this.lblLauncher.Text = "Launcher Tutorial";
            this.lblLauncher.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.lblLauncher.UseVisualStyleBackColor = false;
            this.lblLauncher.Click += new System.EventHandler(this.lblLauncher_Click);
            // 
            // lblPresets
            // 
            this.lblPresets.BackColor = System.Drawing.Color.Transparent;
            this.lblPresets.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.lblPresets.FlatAppearance.BorderSize = 0;
            this.lblPresets.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Brown;
            this.lblPresets.FlatAppearance.MouseOverBackColor = System.Drawing.Color.IndianRed;
            this.lblPresets.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblPresets.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPresets.ForeColor = System.Drawing.Color.Transparent;
            this.lblPresets.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.lblPresets.Location = new System.Drawing.Point(12, 119);
            this.lblPresets.Name = "lblPresets";
            this.lblPresets.Size = new System.Drawing.Size(149, 32);
            this.lblPresets.TabIndex = 11;
            this.lblPresets.Tag = "btn";
            this.lblPresets.Text = "Presets Tutorial";
            this.lblPresets.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.lblPresets.UseVisualStyleBackColor = false;
            this.lblPresets.Click += new System.EventHandler(this.lblPresets_Click);
            // 
            // frmTutorials
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::SotNRandomizerLauncher.Properties.Resources.gradient;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(647, 504);
            this.Controls.Add(this.btnLongLibraryDiscord);
            this.Controls.Add(this.lblSymphonyRando);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.lblRandomizer);
            this.Controls.Add(this.lblLauncher);
            this.Controls.Add(this.lblPresets);
            this.Controls.Add(this.lblPresetsTutorial);
            this.Controls.Add(this.lblRandoTutorial);
            this.Controls.Add(this.lblTutorialDescription);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmTutorials";
            this.Text = "Symphony of the Night Randomizer Launcher - Tutorials";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTutorialDescription;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label lblRandoTutorial;
        private System.Windows.Forms.LinkLabel lblSymphonyRando;
        private System.Windows.Forms.Label lblPresetsTutorial;
        private System.Windows.Forms.Button btnLongLibraryDiscord;
        private System.Windows.Forms.Button lblRandomizer;
        private System.Windows.Forms.Button lblLauncher;
        private System.Windows.Forms.Button lblPresets;
    }
}