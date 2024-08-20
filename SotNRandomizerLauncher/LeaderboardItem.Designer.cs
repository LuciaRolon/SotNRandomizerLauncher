namespace SotNRandomizerLauncher
{
    partial class LeaderboardItem
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
            this.pbUserIcon = new System.Windows.Forms.PictureBox();
            this.lblPosition = new System.Windows.Forms.Label();
            this.lblPlayerName = new System.Windows.Forms.Label();
            this.lblPlayerTitle = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.lblSeed = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbUserIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // pbUserIcon
            // 
            this.pbUserIcon.Location = new System.Drawing.Point(77, 0);
            this.pbUserIcon.Name = "pbUserIcon";
            this.pbUserIcon.Size = new System.Drawing.Size(47, 47);
            this.pbUserIcon.TabIndex = 0;
            this.pbUserIcon.TabStop = false;
            // 
            // lblPosition
            // 
            this.lblPosition.Font = new System.Drawing.Font("Segoe UI Black", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPosition.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblPosition.Location = new System.Drawing.Point(3, 8);
            this.lblPosition.Name = "lblPosition";
            this.lblPosition.Size = new System.Drawing.Size(36, 31);
            this.lblPosition.TabIndex = 4;
            this.lblPosition.Text = "#1";
            this.lblPosition.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPlayerName
            // 
            this.lblPlayerName.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlayerName.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblPlayerName.Location = new System.Drawing.Point(130, 0);
            this.lblPlayerName.Name = "lblPlayerName";
            this.lblPlayerName.Size = new System.Drawing.Size(257, 23);
            this.lblPlayerName.TabIndex = 5;
            this.lblPlayerName.Text = "Player Name";
            this.lblPlayerName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPlayerTitle
            // 
            this.lblPlayerTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlayerTitle.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblPlayerTitle.Location = new System.Drawing.Point(132, 25);
            this.lblPlayerTitle.Name = "lblPlayerTitle";
            this.lblPlayerTitle.Size = new System.Drawing.Size(257, 22);
            this.lblPlayerTitle.TabIndex = 6;
            this.lblPlayerTitle.Text = "Player Title";
            this.lblPlayerTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTime
            // 
            this.lblTime.Font = new System.Drawing.Font("Segoe UI Black", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblTime.Location = new System.Drawing.Point(392, 9);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(172, 31);
            this.lblTime.TabIndex = 7;
            this.lblTime.Text = "HH:MM:SS";
            this.lblTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSeed
            // 
            this.lblSeed.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSeed.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblSeed.Location = new System.Drawing.Point(570, 12);
            this.lblSeed.Name = "lblSeed";
            this.lblSeed.Size = new System.Drawing.Size(257, 22);
            this.lblSeed.TabIndex = 8;
            this.lblSeed.Text = "Seed: Preset-Seed";
            this.lblSeed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSeed.Click += new System.EventHandler(this.lblSeed_Click);
            // 
            // LeaderboardItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.lblSeed);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.lblPlayerTitle);
            this.Controls.Add(this.lblPlayerName);
            this.Controls.Add(this.lblPosition);
            this.Controls.Add(this.pbUserIcon);
            this.Name = "LeaderboardItem";
            this.Size = new System.Drawing.Size(828, 47);
            this.Load += new System.EventHandler(this.LeaderboardItem_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbUserIcon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbUserIcon;
        private System.Windows.Forms.Label lblPosition;
        private System.Windows.Forms.Label lblPlayerName;
        private System.Windows.Forms.Label lblPlayerTitle;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label lblSeed;
    }
}
