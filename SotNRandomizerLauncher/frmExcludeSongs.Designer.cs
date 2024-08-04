namespace SotNRandomizerLauncher
{
    partial class frmExcludeSongs
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmExcludeSongs));
            this.lstSongsAvailable = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lstSongsExcluded = new System.Windows.Forms.ListBox();
            this.btnExclude = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnInclude = new System.Windows.Forms.Button();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstSongsAvailable
            // 
            this.lstSongsAvailable.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstSongsAvailable.FormattingEnabled = true;
            this.lstSongsAvailable.ItemHeight = 15;
            this.lstSongsAvailable.Items.AddRange(new object[] {
            "Lost Painting",
            "Curse Zone",
            "Requiem For The Gods",
            "Rainbow Cemetary",
            "Wood Carving Partita",
            "Crystal Teardrops",
            "Marble Gallery",
            "Dracula\'s Castle",
            "The Tragic Prince",
            "Tower of Mist",
            "Door of Holy Spirits",
            "Dance of Pales",
            "Abandoned Pit",
            "Heavenly Doorway",
            "Festival of Servants",
            "Wandering Ghosts",
            "The Door to the Abyss",
            "Dance of Gold",
            "Enchanted Banquet",
            "Death Ballad",
            "Final Toccata",
            "Nocturne"});
            this.lstSongsAvailable.Location = new System.Drawing.Point(43, 53);
            this.lstSongsAvailable.Name = "lstSongsAvailable";
            this.lstSongsAvailable.Size = new System.Drawing.Size(171, 139);
            this.lstSongsAvailable.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(56, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 34);
            this.label1.TabIndex = 1;
            this.label1.Text = "Songs available during Randomization";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lstSongsExcluded
            // 
            this.lstSongsExcluded.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstSongsExcluded.FormattingEnabled = true;
            this.lstSongsExcluded.ItemHeight = 15;
            this.lstSongsExcluded.Location = new System.Drawing.Point(276, 53);
            this.lstSongsExcluded.Name = "lstSongsExcluded";
            this.lstSongsExcluded.Size = new System.Drawing.Size(171, 139);
            this.lstSongsExcluded.TabIndex = 2;
            // 
            // btnExclude
            // 
            this.btnExclude.Font = new System.Drawing.Font("Segoe UI Black", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExclude.Location = new System.Drawing.Point(227, 75);
            this.btnExclude.Name = "btnExclude";
            this.btnExclude.Size = new System.Drawing.Size(33, 30);
            this.btnExclude.TabIndex = 3;
            this.btnExclude.Text = "->";
            this.btnExclude.UseVisualStyleBackColor = true;
            this.btnExclude.Click += new System.EventHandler(this.btnExclude_Click);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(296, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(135, 34);
            this.label2.TabIndex = 4;
            this.label2.Text = "Songs excluded from Randomization";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Location = new System.Drawing.Point(124, 195);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(258, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Your choices are saved between Randomizations!";
            // 
            // btnInclude
            // 
            this.btnInclude.Font = new System.Drawing.Font("Segoe UI Black", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInclude.Location = new System.Drawing.Point(227, 130);
            this.btnInclude.Name = "btnInclude";
            this.btnInclude.Size = new System.Drawing.Size(33, 30);
            this.btnInclude.TabIndex = 6;
            this.btnInclude.Text = "<-";
            this.btnInclude.UseVisualStyleBackColor = true;
            this.btnInclude.Click += new System.EventHandler(this.btnInclude_Click);
            // 
            // btnConfirm
            // 
            this.btnConfirm.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirm.Location = new System.Drawing.Point(181, 213);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(131, 30);
            this.btnConfirm.TabIndex = 7;
            this.btnConfirm.Text = "Confirm";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // frmExcludeSongs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::SotNRandomizerLauncher.Properties.Resources.gradient;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(481, 251);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.btnInclude);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnExclude);
            this.Controls.Add(this.lstSongsExcluded);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lstSongsAvailable);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "frmExcludeSongs";
            this.Text = "Choose Songs to Exclude from Randomization";
            this.Activated += new System.EventHandler(this.frmExcludeSongs_Activated);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstSongsAvailable;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lstSongsExcluded;
        private System.Windows.Forms.Button btnExclude;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnInclude;
        private System.Windows.Forms.Button btnConfirm;
    }
}