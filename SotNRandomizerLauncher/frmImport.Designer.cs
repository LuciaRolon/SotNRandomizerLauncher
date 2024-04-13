namespace SotNRandomizerLauncher
{
    partial class frmImport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmImport));
            this.btnUploadBizHawk = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBizHawkPath = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.btnUploadLiveSplit = new System.Windows.Forms.Button();
            this.lblBios = new System.Windows.Forms.Label();
            this.txtLiveSplitPath = new System.Windows.Forms.TextBox();
            this.btnCancelImport = new System.Windows.Forms.Button();
            this.btnContinue = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnUploadBizHawk
            // 
            this.btnUploadBizHawk.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnUploadBizHawk.Location = new System.Drawing.Point(479, 224);
            this.btnUploadBizHawk.Name = "btnUploadBizHawk";
            this.btnUploadBizHawk.Size = new System.Drawing.Size(59, 23);
            this.btnUploadBizHawk.TabIndex = 14;
            this.btnUploadBizHawk.Text = "Select";
            this.btnUploadBizHawk.UseVisualStyleBackColor = true;
            this.btnUploadBizHawk.Click += new System.EventHandler(this.btnUploadBizHawk_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(25, 205);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(178, 17);
            this.label2.TabIndex = 13;
            this.label2.Text = "Select your BizHawk folder:";
            // 
            // txtBizHawkPath
            // 
            this.txtBizHawkPath.Location = new System.Drawing.Point(25, 224);
            this.txtBizHawkPath.Name = "txtBizHawkPath";
            this.txtBizHawkPath.ReadOnly = true;
            this.txtBizHawkPath.Size = new System.Drawing.Size(448, 22);
            this.txtBizHawkPath.TabIndex = 12;
            // 
            // lblDescription
            // 
            this.lblDescription.BackColor = System.Drawing.Color.Transparent;
            this.lblDescription.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescription.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblDescription.Location = new System.Drawing.Point(22, 9);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(516, 127);
            this.lblDescription.TabIndex = 11;
            this.lblDescription.Text = resources.GetString("lblDescription.Text");
            // 
            // btnUploadLiveSplit
            // 
            this.btnUploadLiveSplit.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnUploadLiveSplit.Location = new System.Drawing.Point(479, 168);
            this.btnUploadLiveSplit.Name = "btnUploadLiveSplit";
            this.btnUploadLiveSplit.Size = new System.Drawing.Size(59, 23);
            this.btnUploadLiveSplit.TabIndex = 10;
            this.btnUploadLiveSplit.Text = "Select";
            this.btnUploadLiveSplit.UseVisualStyleBackColor = true;
            this.btnUploadLiveSplit.Click += new System.EventHandler(this.btnUploadBios_Click);
            // 
            // lblBios
            // 
            this.lblBios.AutoSize = true;
            this.lblBios.BackColor = System.Drawing.Color.Transparent;
            this.lblBios.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBios.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblBios.Location = new System.Drawing.Point(25, 149);
            this.lblBios.Name = "lblBios";
            this.lblBios.Size = new System.Drawing.Size(179, 17);
            this.lblBios.TabIndex = 9;
            this.lblBios.Text = "Select your LiveSplit folder:";
            // 
            // txtLiveSplitPath
            // 
            this.txtLiveSplitPath.Location = new System.Drawing.Point(25, 168);
            this.txtLiveSplitPath.Name = "txtLiveSplitPath";
            this.txtLiveSplitPath.ReadOnly = true;
            this.txtLiveSplitPath.Size = new System.Drawing.Size(448, 22);
            this.txtLiveSplitPath.TabIndex = 8;
            // 
            // btnCancelImport
            // 
            this.btnCancelImport.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnCancelImport.Location = new System.Drawing.Point(25, 273);
            this.btnCancelImport.Name = "btnCancelImport";
            this.btnCancelImport.Size = new System.Drawing.Size(134, 35);
            this.btnCancelImport.TabIndex = 15;
            this.btnCancelImport.Text = "Cancel Import";
            this.btnCancelImport.UseVisualStyleBackColor = true;
            this.btnCancelImport.Click += new System.EventHandler(this.btnCancelImport_Click);
            // 
            // btnContinue
            // 
            this.btnContinue.Enabled = false;
            this.btnContinue.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnContinue.Location = new System.Drawing.Point(404, 273);
            this.btnContinue.Name = "btnContinue";
            this.btnContinue.Size = new System.Drawing.Size(134, 35);
            this.btnContinue.TabIndex = 16;
            this.btnContinue.Text = "Continue";
            this.btnContinue.UseVisualStyleBackColor = true;
            this.btnContinue.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmImport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = global::SotNRandomizerLauncher.Properties.Resources.gradient;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(562, 330);
            this.ControlBox = false;
            this.Controls.Add(this.btnContinue);
            this.Controls.Add(this.btnCancelImport);
            this.Controls.Add(this.btnUploadBizHawk);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtBizHawkPath);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.btnUploadLiveSplit);
            this.Controls.Add(this.lblBios);
            this.Controls.Add(this.txtLiveSplitPath);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmImport";
            this.Text = "Import Apps";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnUploadBizHawk;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBizHawkPath;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Button btnUploadLiveSplit;
        private System.Windows.Forms.Label lblBios;
        private System.Windows.Forms.TextBox txtLiveSplitPath;
        private System.Windows.Forms.Button btnCancelImport;
        private System.Windows.Forms.Button btnContinue;
    }
}