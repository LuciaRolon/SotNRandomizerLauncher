namespace SotNRandomizerLauncher
{
    partial class frmProfile
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProfile));
            this.cntLeaderboards1 = new SotNRandomizerLauncher.cntLeaderboards();
            this.btnReturn = new System.Windows.Forms.Button();
            this.btnPlayerProfile = new System.Windows.Forms.Button();
            this.btnLeaderboards = new System.Windows.Forms.Button();
            this.cntProfile1 = new SotNRandomizerLauncher.cntProfile();
            this.SuspendLayout();
            // 
            // cntLeaderboards1
            // 
            this.cntLeaderboards1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cntLeaderboards1.BackgroundImage")));
            this.cntLeaderboards1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cntLeaderboards1.Location = new System.Drawing.Point(0, 32);
            this.cntLeaderboards1.Name = "cntLeaderboards1";
            this.cntLeaderboards1.Size = new System.Drawing.Size(1007, 532);
            this.cntLeaderboards1.TabIndex = 0;
            this.cntLeaderboards1.Visible = false;
            this.cntLeaderboards1.Load += new System.EventHandler(this.cntLeaderboards1_Load);
            // 
            // btnReturn
            // 
            this.btnReturn.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReturn.Location = new System.Drawing.Point(873, 2);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(126, 27);
            this.btnReturn.TabIndex = 1;
            this.btnReturn.Text = "Back to Launcher";
            this.btnReturn.UseVisualStyleBackColor = true;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // btnPlayerProfile
            // 
            this.btnPlayerProfile.BackColor = System.Drawing.Color.Transparent;
            this.btnPlayerProfile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnPlayerProfile.FlatAppearance.BorderSize = 0;
            this.btnPlayerProfile.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Brown;
            this.btnPlayerProfile.FlatAppearance.MouseOverBackColor = System.Drawing.Color.IndianRed;
            this.btnPlayerProfile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlayerProfile.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPlayerProfile.ForeColor = System.Drawing.Color.Transparent;
            this.btnPlayerProfile.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.btnPlayerProfile.Location = new System.Drawing.Point(12, 1);
            this.btnPlayerProfile.Name = "btnPlayerProfile";
            this.btnPlayerProfile.Size = new System.Drawing.Size(158, 27);
            this.btnPlayerProfile.TabIndex = 3;
            this.btnPlayerProfile.Text = "Player Profile";
            this.btnPlayerProfile.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnPlayerProfile.UseVisualStyleBackColor = false;
            this.btnPlayerProfile.Click += new System.EventHandler(this.btnPpfFile_Click);
            // 
            // btnLeaderboards
            // 
            this.btnLeaderboards.BackColor = System.Drawing.Color.Transparent;
            this.btnLeaderboards.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnLeaderboards.FlatAppearance.BorderSize = 0;
            this.btnLeaderboards.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Brown;
            this.btnLeaderboards.FlatAppearance.MouseOverBackColor = System.Drawing.Color.IndianRed;
            this.btnLeaderboards.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLeaderboards.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLeaderboards.ForeColor = System.Drawing.Color.Transparent;
            this.btnLeaderboards.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.btnLeaderboards.Location = new System.Drawing.Point(176, 1);
            this.btnLeaderboards.Name = "btnLeaderboards";
            this.btnLeaderboards.Size = new System.Drawing.Size(158, 27);
            this.btnLeaderboards.TabIndex = 4;
            this.btnLeaderboards.Text = "Racing Leaderboards";
            this.btnLeaderboards.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnLeaderboards.UseVisualStyleBackColor = false;
            this.btnLeaderboards.Click += new System.EventHandler(this.button1_Click);
            // 
            // cntProfile1
            // 
            this.cntProfile1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cntProfile1.BackgroundImage")));
            this.cntProfile1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cntProfile1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cntProfile1.Location = new System.Drawing.Point(0, 32);
            this.cntProfile1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cntProfile1.Name = "cntProfile1";
            this.cntProfile1.Size = new System.Drawing.Size(1007, 532);
            this.cntProfile1.TabIndex = 5;
            this.cntProfile1.Visible = false;
            // 
            // frmProfile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1006, 564);
            this.Controls.Add(this.btnLeaderboards);
            this.Controls.Add(this.btnPlayerProfile);
            this.Controls.Add(this.btnReturn);
            this.Controls.Add(this.cntLeaderboards1);
            this.Controls.Add(this.cntProfile1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmProfile";
            this.Text = "Profile - Racing Leaderboards";
            this.Load += new System.EventHandler(this.frmProfile_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private cntLeaderboards cntLeaderboards1;
        private System.Windows.Forms.Button btnReturn;
        private System.Windows.Forms.Button btnPlayerProfile;
        private System.Windows.Forms.Button btnLeaderboards;
        private cntProfile cntProfile1;
    }
}