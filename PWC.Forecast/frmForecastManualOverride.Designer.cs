namespace PWC.Forecast
{
    partial class frmForecastManualOverride
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
            this.chkManualOverride = new System.Windows.Forms.CheckBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lbSelected = new System.Windows.Forms.ListBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // chkManualOverride
            // 
            this.chkManualOverride.AutoSize = true;
            this.chkManualOverride.Location = new System.Drawing.Point(12, 12);
            this.chkManualOverride.Name = "chkManualOverride";
            this.chkManualOverride.Size = new System.Drawing.Size(104, 17);
            this.chkManualOverride.TabIndex = 0;
            this.chkManualOverride.Text = "Manual Override";
            this.chkManualOverride.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(210, 172);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(63, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // lbSelected
            // 
            this.lbSelected.FormattingEnabled = true;
            this.lbSelected.Location = new System.Drawing.Point(12, 35);
            this.lbSelected.Name = "lbSelected";
            this.lbSelected.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbSelected.Size = new System.Drawing.Size(403, 121);
            this.lbSelected.TabIndex = 1;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(141, 172);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(63, 23);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // frmForecastManualOverride
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(428, 207);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.lbSelected);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.chkManualOverride);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmForecastManualOverride";
            this.Text = "Forecast Manual Override";
            this.Load += new System.EventHandler(this.frmForecastManualOverride_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkManualOverride;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ListBox lbSelected;
        private System.Windows.Forms.Button btnOK;
    }
}