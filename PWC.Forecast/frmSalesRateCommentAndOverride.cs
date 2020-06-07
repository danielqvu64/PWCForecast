using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using PWC.BusinessObject;

namespace PWC.Forecast
{
    public partial class frmSalesRateCommentAndOverride : Form
    {
        private readonly Customer _customer;
        private readonly ForecastSalesRate _salesRate;
        private readonly bool _isNewSalesRate;

        public frmSalesRateCommentAndOverride(Customer customer, ForecastSalesRate saleRate, bool isNewSalesRate)
        {
            InitializeComponent();
            _customer = customer;
            _salesRate = saleRate;
            _isNewSalesRate = isNewSalesRate;
        }

        private void frmSalesRateCommentAndOverride_Load(object sender, EventArgs e)
        {
            lblForecastItemDescription.Text = _salesRate.ItemNumber.ToString();
            lbComments.DisplayMember = "CommentDisplay";
            RefreshCommentList();
            chkManual.Checked = _salesRate.GetOverride();
        }

        private void btnRemoveComment_Click(object sender, EventArgs e)
        {
            foreach (ForecastSalesRateCommentAndOverride item in lbComments.SelectedItems)
                _salesRate.ForecastSalesRateCommentAndOverrideCollection.Delete((ForecastSalesRateCommentAndOverrideKey)item.ObjectKey);
            RefreshCommentList();
        }

        private void btnAddComment_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbCommentAdd.Text)) 
                return;

            var commentAndOverrideKey = new ForecastSalesRateCommentAndOverrideKey((ForecastSalesRateKey)_salesRate.ObjectKey, DateTime.Now);
            var commentAndOverride = _salesRate.ForecastSalesRateCommentAndOverrideCollection.Create(commentAndOverrideKey);
            commentAndOverride.Comment = tbCommentAdd.Text;
            if (_customer.ForecastSalesRateAction == ForecastSalesRateAction.Get)
                _salesRate.ForecastSalesRateCommentAndOverrideCollection.Save(commentAndOverride);
            else
                _salesRate.ForecastSalesRateCommentAndOverrideCollection.Add(commentAndOverride);
            _salesRate.HasComment = true;

            RefreshCommentList();

            tbCommentAdd.Text = string.Empty;
            tbCommentAdd.Focus();
        }

        private void lbComments_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            if (e.Index == -1)
                return;

            var itemText = ((ForecastSalesRateCommentAndOverride)lbComments.Items[e.Index]).CommentDisplay;
            var textSize = e.Graphics.MeasureString(itemText, lbComments.Font,
            lbComments.ClientSize.Width);
            e.ItemHeight = (int)Math.Round(textSize.Height);
        }

        private void lbComments_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index == -1)
                return;

            var itemText = ((ForecastSalesRateCommentAndOverride)lbComments.Items[e.Index]).CommentDisplay;

            var bgColor = (e.State & DrawItemState.Selected) != 0 ? SystemColors.Highlight : lbComments.BackColor;
            var fgColor = (e.State & DrawItemState.Selected) != 0 ? SystemColors.HighlightText : lbComments.ForeColor;

            using (Brush bgBrush = new SolidBrush(bgColor))
            {
                e.Graphics.FillRectangle(bgBrush, e.Bounds);
            }
            using (Brush fgBrush = new SolidBrush(fgColor))
            {
                e.Graphics.DrawString(itemText, this.Font, fgBrush, new
                RectangleF(e.Bounds.Left, e.Bounds.Top, e.Bounds.Width, e.Bounds.Height));
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (_salesRate.GetOverride() == chkManual.Checked)
                return;

            _customer.UpdateSalesRateOverride(_salesRate, chkManual.Checked, _isNewSalesRate);
        }

        private void RefreshCommentList()
        {
            bindingSourceSalesRateComment.DataSource = _salesRate.GetComments();
        }
    }
}
