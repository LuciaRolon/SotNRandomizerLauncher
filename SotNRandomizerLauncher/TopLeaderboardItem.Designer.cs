namespace SotNRandomizerLauncher
{
    partial class TopLeaderboardItem
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblTime = new System.Windows.Forms.Label();
            this.lblPosition = new System.Windows.Forms.Label();
            this.lblPlayerTitle = new System.Windows.Forms.Label();
            this.lblPlayerName = new System.Windows.Forms.Label();
            this.pbUserIcon = new System.Windows.Forms.PictureBox();
            this.lblSeed = new System.Windows.Forms.LinkLabel();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbUserIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblSeed);
            this.groupBox1.Controls.Add(this.lblTime);
            this.groupBox1.Controls.Add(this.lblPosition);
            this.groupBox1.Controls.Add(this.lblPlayerTitle);
            this.groupBox1.Controls.Add(this.lblPlayerName);
            this.groupBox1.Controls.Add(this.pbUserIcon);
            this.groupBox1.Location = new System.Drawing.Point(2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(269, 207);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // lblTime
            // 
            this.lblTime.Font = new System.Drawing.Font("Segoe UI Black", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblTime.Location = new System.Drawing.Point(6, 150);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(257, 31);
            this.lblTime.TabIndex = 4;
            this.lblTime.Text = "HH:MM:SS";
            this.lblTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPosition
            // 
            this.lblPosition.Font = new System.Drawing.Font("Segoe UI Black", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPosition.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblPosition.Location = new System.Drawing.Point(6, 119);
            this.lblPosition.Name = "lblPosition";
            this.lblPosition.Size = new System.Drawing.Size(257, 31);
            this.lblPosition.TabIndex = 3;
            this.lblPosition.Text = "#1";
            this.lblPosition.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblPosition.Click += new System.EventHandler(this.lblPosition_Click);
            // 
            // lblPlayerTitle
            // 
            this.lblPlayerTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlayerTitle.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblPlayerTitle.Location = new System.Drawing.Point(6, 97);
            this.lblPlayerTitle.Name = "lblPlayerTitle";
            this.lblPlayerTitle.Size = new System.Drawing.Size(257, 22);
            this.lblPlayerTitle.TabIndex = 2;
            this.lblPlayerTitle.Text = "Player Title";
            this.lblPlayerTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblPlayerTitle.Click += new System.EventHandler(this.label2_Click);
            // 
            // lblPlayerName
            // 
            this.lblPlayerName.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlayerName.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblPlayerName.Location = new System.Drawing.Point(6, 72);
            this.lblPlayerName.Name = "lblPlayerName";
            this.lblPlayerName.Size = new System.Drawing.Size(257, 23);
            this.lblPlayerName.TabIndex = 1;
            this.lblPlayerName.Text = "Player Name";
            this.lblPlayerName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pbUserIcon
            // 
            this.pbUserIcon.Location = new System.Drawing.Point(107, 19);
            this.pbUserIcon.Name = "pbUserIcon";
            this.pbUserIcon.Size = new System.Drawing.Size(56, 50);
            this.pbUserIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbUserIcon.TabIndex = 0;
            this.pbUserIcon.TabStop = false;
            this.pbUserIcon.Click += new System.EventHandler(this.pbUserIcon_Click);
            // 
            // lblSeed
            // 
            this.lblSeed.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSeed.LinkColor = System.Drawing.Color.IndianRed;
            this.lblSeed.Location = new System.Drawing.Point(1, 181);
            this.lblSeed.Name = "lblSeed";
            this.lblSeed.Size = new System.Drawing.Size(269, 23);
            this.lblSeed.TabIndex = 5;
            this.lblSeed.TabStop = true;
            this.lblSeed.Text = "Seed: preset-seed";
            this.lblSeed.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblSeed.Visible = false;
            this.lblSeed.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblSeed_LinkClicked);
            // 
            // TopLeaderboardItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.groupBox1);
            this.Name = "TopLeaderboardItem";
            this.Size = new System.Drawing.Size(272, 213);
            this.Load += new System.EventHandler(this.TopLeaderboardItem_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbUserIcon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pbUserIcon;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label lblPosition;
        private System.Windows.Forms.Label lblPlayerTitle;
        private System.Windows.Forms.Label lblPlayerName;
        private System.Windows.Forms.LinkLabel lblSeed;
    }
}
