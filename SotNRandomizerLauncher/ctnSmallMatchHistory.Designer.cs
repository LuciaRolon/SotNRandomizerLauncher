namespace SotNRandomizerLauncher
{
    partial class ctnSmallMatchHistory
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
            this.lblPlace = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.lblEloChange = new System.Windows.Forms.Label();
            this.lblPreset = new System.Windows.Forms.Label();
            this.lblMatchType = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.pbPresetImage = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbPresetImage)).BeginInit();
            this.SuspendLayout();
            // 
            // lblPlace
            // 
            this.lblPlace.AutoSize = true;
            this.lblPlace.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlace.ForeColor = System.Drawing.Color.SandyBrown;
            this.lblPlace.Location = new System.Drawing.Point(78, 3);
            this.lblPlace.Name = "lblPlace";
            this.lblPlace.Size = new System.Drawing.Size(89, 25);
            this.lblPlace.TabIndex = 1;
            this.lblPlace.Text = "1st Place";
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblTime.Location = new System.Drawing.Point(80, 47);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(89, 15);
            this.lblTime.TabIndex = 2;
            this.lblTime.Text = "Time: 00:49:00";
            // 
            // lblEloChange
            // 
            this.lblEloChange.AutoSize = true;
            this.lblEloChange.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEloChange.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblEloChange.Location = new System.Drawing.Point(80, 62);
            this.lblEloChange.Name = "lblEloChange";
            this.lblEloChange.Size = new System.Drawing.Size(92, 15);
            this.lblEloChange.TabIndex = 3;
            this.lblEloChange.Text = "Elo Change: -60";
            // 
            // lblPreset
            // 
            this.lblPreset.AutoSize = true;
            this.lblPreset.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPreset.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblPreset.Location = new System.Drawing.Point(80, 32);
            this.lblPreset.Name = "lblPreset";
            this.lblPreset.Size = new System.Drawing.Size(132, 15);
            this.lblPreset.TabIndex = 4;
            this.lblPreset.Text = "Preset: Bounty Hunter";
            // 
            // lblMatchType
            // 
            this.lblMatchType.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMatchType.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblMatchType.Location = new System.Drawing.Point(225, 47);
            this.lblMatchType.Name = "lblMatchType";
            this.lblMatchType.Size = new System.Drawing.Size(89, 15);
            this.lblMatchType.TabIndex = 5;
            this.lblMatchType.Text = "Ranked Race";
            this.lblMatchType.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblDate.Location = new System.Drawing.Point(233, 62);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(73, 15);
            this.lblDate.TabIndex = 6;
            this.lblDate.Text = "2024-12-26";
            this.lblDate.Click += new System.EventHandler(this.label6_Click);
            // 
            // pbPresetImage
            // 
            this.pbPresetImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbPresetImage.Location = new System.Drawing.Point(3, 3);
            this.pbPresetImage.Name = "pbPresetImage";
            this.pbPresetImage.Size = new System.Drawing.Size(69, 74);
            this.pbPresetImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbPresetImage.TabIndex = 0;
            this.pbPresetImage.TabStop = false;
            this.pbPresetImage.Click += new System.EventHandler(this.pbPresetImage_Click);
            // 
            // ctnSmallMatchHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.lblMatchType);
            this.Controls.Add(this.lblPreset);
            this.Controls.Add(this.lblEloChange);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.lblPlace);
            this.Controls.Add(this.pbPresetImage);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "ctnSmallMatchHistory";
            this.Size = new System.Drawing.Size(314, 80);
            this.Load += new System.EventHandler(this.ctnSmallMatchHistory_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbPresetImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbPresetImage;
        private System.Windows.Forms.Label lblPlace;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label lblEloChange;
        private System.Windows.Forms.Label lblPreset;
        private System.Windows.Forms.Label lblMatchType;
        private System.Windows.Forms.Label lblDate;
    }
}
