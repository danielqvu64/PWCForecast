namespace PWC.Forecast
{
    partial class frmForecastComment
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
            this.label1 = new System.Windows.Forms.Label();
            this.tbCommentAdd = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblForecastItemDescription = new System.Windows.Forms.Label();
            this.lbComments = new System.Windows.Forms.ListBox();
            this.bindingSourceComment = new System.Windows.Forms.BindingSource(this.components);
            this.btnRemoveComment = new System.Windows.Forms.Button();
            this.btnAddComment = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceComment)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Comments:";
            // 
            // tbCommentAdd
            // 
            this.tbCommentAdd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbCommentAdd.Location = new System.Drawing.Point(11, 197);
            this.tbCommentAdd.Multiline = true;
            this.tbCommentAdd.Name = "tbCommentAdd";
            this.tbCommentAdd.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbCommentAdd.Size = new System.Drawing.Size(404, 64);
            this.tbCommentAdd.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(189, 307);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(63, 23);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // lblForecastItemDescription
            // 
            this.lblForecastItemDescription.AutoSize = true;
            this.lblForecastItemDescription.Location = new System.Drawing.Point(186, 13);
            this.lblForecastItemDescription.Name = "lblForecastItemDescription";
            this.lblForecastItemDescription.Size = new System.Drawing.Size(0, 13);
            this.lblForecastItemDescription.TabIndex = 6;
            // 
            // lbComments
            // 
            this.lbComments.DataSource = this.bindingSourceComment;
            this.lbComments.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.lbComments.FormattingEnabled = true;
            this.lbComments.ItemHeight = 26;
            this.lbComments.Location = new System.Drawing.Point(12, 29);
            this.lbComments.Name = "lbComments";
            this.lbComments.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbComments.Size = new System.Drawing.Size(403, 121);
            this.lbComments.TabIndex = 3;
            this.lbComments.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.lbComments_DrawItem);
            this.lbComments.MeasureItem += new System.Windows.Forms.MeasureItemEventHandler(this.lbComments_MeasureItem);
            // 
            // bindingSourceComment
            // 
            this.bindingSourceComment.DataSource = typeof(PWC.BusinessObject.ForecastCommentAndOverride.WithForecastParentCollection);
            // 
            // btnRemoveComment
            // 
            this.btnRemoveComment.Location = new System.Drawing.Point(352, 156);
            this.btnRemoveComment.Name = "btnRemoveComment";
            this.btnRemoveComment.Size = new System.Drawing.Size(63, 23);
            this.btnRemoveComment.TabIndex = 4;
            this.btnRemoveComment.Text = "Remove";
            this.btnRemoveComment.UseVisualStyleBackColor = true;
            this.btnRemoveComment.Click += new System.EventHandler(this.btnRemoveComment_Click);
            // 
            // btnAddComment
            // 
            this.btnAddComment.Location = new System.Drawing.Point(352, 267);
            this.btnAddComment.Name = "btnAddComment";
            this.btnAddComment.Size = new System.Drawing.Size(63, 23);
            this.btnAddComment.TabIndex = 1;
            this.btnAddComment.Text = "Add";
            this.btnAddComment.UseVisualStyleBackColor = true;
            this.btnAddComment.Click += new System.EventHandler(this.btnAddComment_Click);
            // 
            // FrmForecastComment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(428, 351);
            this.Controls.Add(this.btnAddComment);
            this.Controls.Add(this.btnRemoveComment);
            this.Controls.Add(this.lbComments);
            this.Controls.Add(this.lblForecastItemDescription);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.tbCommentAdd);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmForecastComment";
            this.Text = "Forecast Comments";
            this.Load += new System.EventHandler(this.frmForecastComment_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceComment)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbCommentAdd;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblForecastItemDescription;
        private System.Windows.Forms.ListBox lbComments;
        private System.Windows.Forms.BindingSource bindingSourceComment;
        private System.Windows.Forms.Button btnRemoveComment;
        private System.Windows.Forms.Button btnAddComment;
    }
}