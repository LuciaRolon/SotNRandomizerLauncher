namespace SotNRandomizerLauncher
{
    partial class cntLeaderboards
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblPreset = new System.Windows.Forms.Label();
            this.cbPreset = new System.Windows.Forms.ComboBox();
            this.cbBestBy = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblDefaultMessage = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.leaderboardItem5 = new SotNRandomizerLauncher.LeaderboardItem();
            this.leaderboardItem4 = new SotNRandomizerLauncher.LeaderboardItem();
            this.leaderboardItem3 = new SotNRandomizerLauncher.LeaderboardItem();
            this.leaderboardItem2 = new SotNRandomizerLauncher.LeaderboardItem();
            this.leaderboardItem1 = new SotNRandomizerLauncher.LeaderboardItem();
            this.topLeaderboardItem2 = new SotNRandomizerLauncher.TopLeaderboardItem();
            this.topLeaderboardItem3 = new SotNRandomizerLauncher.TopLeaderboardItem();
            this.topLeaderboardItem1 = new SotNRandomizerLauncher.TopLeaderboardItem();
            this.SuspendLayout();
            // 
            // lblPreset
            // 
            this.lblPreset.AutoSize = true;
            this.lblPreset.BackColor = System.Drawing.Color.Transparent;
            this.lblPreset.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPreset.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblPreset.Location = new System.Drawing.Point(58, 11);
            this.lblPreset.Name = "lblPreset";
            this.lblPreset.Size = new System.Drawing.Size(51, 20);
            this.lblPreset.TabIndex = 9;
            this.lblPreset.Text = "Preset";
            this.lblPreset.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbPreset
            // 
            this.cbPreset.BackColor = System.Drawing.SystemColors.InfoText;
            this.cbPreset.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPreset.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.cbPreset.FormattingEnabled = true;
            this.cbPreset.Items.AddRange(new object[] {
            "First Castle"});
            this.cbPreset.Location = new System.Drawing.Point(16, 34);
            this.cbPreset.Name = "cbPreset";
            this.cbPreset.Size = new System.Drawing.Size(138, 21);
            this.cbPreset.TabIndex = 10;
            this.cbPreset.SelectedIndexChanged += new System.EventHandler(this.cbPreset_SelectedIndexChanged);
            // 
            // cbBestBy
            // 
            this.cbBestBy.BackColor = System.Drawing.SystemColors.InfoText;
            this.cbBestBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBestBy.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.cbBestBy.FormattingEnabled = true;
            this.cbBestBy.Items.AddRange(new object[] {
            "Time",
            "Elo"});
            this.cbBestBy.Location = new System.Drawing.Point(16, 97);
            this.cbBestBy.Name = "cbBestBy";
            this.cbBestBy.Size = new System.Drawing.Size(138, 21);
            this.cbBestBy.TabIndex = 12;
            this.cbBestBy.SelectedIndexChanged += new System.EventHandler(this.cbBestBy_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(55, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 20);
            this.label1.TabIndex = 11;
            this.label1.Text = "Best By";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDefaultMessage
            // 
            this.lblDefaultMessage.AutoSize = true;
            this.lblDefaultMessage.BackColor = System.Drawing.Color.Transparent;
            this.lblDefaultMessage.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDefaultMessage.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblDefaultMessage.Location = new System.Drawing.Point(435, 220);
            this.lblDefaultMessage.Name = "lblDefaultMessage";
            this.lblDefaultMessage.Size = new System.Drawing.Size(291, 74);
            this.lblDefaultMessage.TabIndex = 13;
            this.lblDefaultMessage.Text = "Select a Preset to \r\nsee the Leaderboards";
            this.lblDefaultMessage.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblTitle.Location = new System.Drawing.Point(454, 11);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(272, 31);
            this.lblTitle.TabIndex = 14;
            this.lblTitle.Text = "Bounty Hunter (by Time)";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblTitle.Visible = false;
            // 
            // leaderboardItem5
            // 
            this.leaderboardItem5.BackColor = System.Drawing.Color.Transparent;
            this.leaderboardItem5.ImageUrl = null;
            this.leaderboardItem5.Location = new System.Drawing.Point(176, 465);
            this.leaderboardItem5.Name = "leaderboardItem5";
            this.leaderboardItem5.Seed = "";
            this.leaderboardItem5.SeedUrl = null;
            this.leaderboardItem5.Size = new System.Drawing.Size(828, 47);
            this.leaderboardItem5.TabIndex = 7;
            this.leaderboardItem5.TextColor = System.Drawing.Color.Empty;
            // 
            // leaderboardItem4
            // 
            this.leaderboardItem4.BackColor = System.Drawing.Color.Transparent;
            this.leaderboardItem4.ImageUrl = null;
            this.leaderboardItem4.Location = new System.Drawing.Point(176, 412);
            this.leaderboardItem4.Name = "leaderboardItem4";
            this.leaderboardItem4.Seed = "";
            this.leaderboardItem4.SeedUrl = null;
            this.leaderboardItem4.Size = new System.Drawing.Size(828, 47);
            this.leaderboardItem4.TabIndex = 6;
            this.leaderboardItem4.TextColor = System.Drawing.Color.Empty;
            // 
            // leaderboardItem3
            // 
            this.leaderboardItem3.BackColor = System.Drawing.Color.Transparent;
            this.leaderboardItem3.ImageUrl = null;
            this.leaderboardItem3.Location = new System.Drawing.Point(176, 359);
            this.leaderboardItem3.Name = "leaderboardItem3";
            this.leaderboardItem3.Seed = "";
            this.leaderboardItem3.SeedUrl = null;
            this.leaderboardItem3.Size = new System.Drawing.Size(828, 47);
            this.leaderboardItem3.TabIndex = 5;
            this.leaderboardItem3.TextColor = System.Drawing.Color.Empty;
            // 
            // leaderboardItem2
            // 
            this.leaderboardItem2.BackColor = System.Drawing.Color.Transparent;
            this.leaderboardItem2.ImageUrl = null;
            this.leaderboardItem2.Location = new System.Drawing.Point(176, 306);
            this.leaderboardItem2.Name = "leaderboardItem2";
            this.leaderboardItem2.Seed = "";
            this.leaderboardItem2.SeedUrl = null;
            this.leaderboardItem2.Size = new System.Drawing.Size(828, 47);
            this.leaderboardItem2.TabIndex = 4;
            this.leaderboardItem2.TextColor = System.Drawing.Color.Empty;
            // 
            // leaderboardItem1
            // 
            this.leaderboardItem1.BackColor = System.Drawing.Color.Transparent;
            this.leaderboardItem1.ImageUrl = "";
            this.leaderboardItem1.Location = new System.Drawing.Point(176, 253);
            this.leaderboardItem1.Name = "leaderboardItem1";
            this.leaderboardItem1.Seed = "";
            this.leaderboardItem1.SeedUrl = null;
            this.leaderboardItem1.Size = new System.Drawing.Size(828, 47);
            this.leaderboardItem1.TabIndex = 3;
            this.leaderboardItem1.TextColor = System.Drawing.Color.Empty;
            // 
            // topLeaderboardItem2
            // 
            this.topLeaderboardItem2.BackColor = System.Drawing.Color.Transparent;
            this.topLeaderboardItem2.ImageUrl = "";
            this.topLeaderboardItem2.Location = new System.Drawing.Point(176, 4);
            this.topLeaderboardItem2.Name = "topLeaderboardItem2";
            this.topLeaderboardItem2.Seed = "";
            this.topLeaderboardItem2.SeedUrl = null;
            this.topLeaderboardItem2.Size = new System.Drawing.Size(272, 213);
            this.topLeaderboardItem2.TabIndex = 2;
            this.topLeaderboardItem2.TextColor = System.Drawing.Color.Empty;
            // 
            // topLeaderboardItem3
            // 
            this.topLeaderboardItem3.BackColor = System.Drawing.Color.Transparent;
            this.topLeaderboardItem3.ImageUrl = null;
            this.topLeaderboardItem3.Location = new System.Drawing.Point(732, 4);
            this.topLeaderboardItem3.Name = "topLeaderboardItem3";
            this.topLeaderboardItem3.Seed = "";
            this.topLeaderboardItem3.SeedUrl = null;
            this.topLeaderboardItem3.Size = new System.Drawing.Size(272, 213);
            this.topLeaderboardItem3.TabIndex = 1;
            this.topLeaderboardItem3.TextColor = System.Drawing.Color.Empty;
            // 
            // topLeaderboardItem1
            // 
            this.topLeaderboardItem1.BackColor = System.Drawing.Color.Transparent;
            this.topLeaderboardItem1.ImageUrl = null;
            this.topLeaderboardItem1.Location = new System.Drawing.Point(454, 34);
            this.topLeaderboardItem1.Name = "topLeaderboardItem1";
            this.topLeaderboardItem1.Seed = "";
            this.topLeaderboardItem1.SeedUrl = null;
            this.topLeaderboardItem1.Size = new System.Drawing.Size(272, 213);
            this.topLeaderboardItem1.TabIndex = 0;
            this.topLeaderboardItem1.TextColor = System.Drawing.Color.Empty;
            this.topLeaderboardItem1.Load += new System.EventHandler(this.topLeaderboardItem1_Load);
            // 
            // cntLeaderboards
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::SotNRandomizerLauncher.Properties.Resources.gradient;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblDefaultMessage);
            this.Controls.Add(this.cbBestBy);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbPreset);
            this.Controls.Add(this.lblPreset);
            this.Controls.Add(this.leaderboardItem5);
            this.Controls.Add(this.leaderboardItem4);
            this.Controls.Add(this.leaderboardItem3);
            this.Controls.Add(this.leaderboardItem2);
            this.Controls.Add(this.leaderboardItem1);
            this.Controls.Add(this.topLeaderboardItem2);
            this.Controls.Add(this.topLeaderboardItem3);
            this.Controls.Add(this.topLeaderboardItem1);
            this.DoubleBuffered = true;
            this.Name = "cntLeaderboards";
            this.Size = new System.Drawing.Size(1007, 532);
            this.Load += new System.EventHandler(this.cntLeaderboards_Load);
            this.VisibleChanged += new System.EventHandler(this.cntLeaderboards_VisibleChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TopLeaderboardItem topLeaderboardItem1;
        private TopLeaderboardItem topLeaderboardItem3;
        private TopLeaderboardItem topLeaderboardItem2;
        private LeaderboardItem leaderboardItem1;
        private LeaderboardItem leaderboardItem2;
        private LeaderboardItem leaderboardItem3;
        private LeaderboardItem leaderboardItem4;
        private LeaderboardItem leaderboardItem5;
        private System.Windows.Forms.Label lblPreset;
        private System.Windows.Forms.ComboBox cbPreset;
        private System.Windows.Forms.ComboBox cbBestBy;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblDefaultMessage;
        private System.Windows.Forms.Label lblTitle;
    }
}
