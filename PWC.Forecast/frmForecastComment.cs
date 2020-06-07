using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using PWC.BusinessObject;
using bo = PWC.BusinessObject;

namespace PWC.Forecast
{
    public partial class frmForecastComment : Form
    {
        private readonly Customer _customer;
        private readonly bo.Forecast _forecast;
        private readonly string _columnName;

        public frmForecastComment(Customer customer, bo.Forecast forecast, string columnName)
        {
            InitializeComponent();
            _customer = customer;
            _forecast = forecast;
            _columnName = columnName;
        }

        private void frmForecastComment_Load(object sender, EventArgs e)
        {
            lblForecastItemDescription.Text = string.Format("{0}  {1}  {2}", _forecast.ItemNumber, _forecast.ForecastMethod, _columnName);

            lbComments.DisplayMember = "CommentDisplay";
            RefreshCommentList();
        }

        private void btnRemoveComment_Click(object sender, EventArgs e)
        {
            foreach (ForecastCommentAndOverride item in lbComments.SelectedItems)
                _forecast.ForecastCommentAndOverrideCollection.Delete((ForecastCommentAndOverrideKey) item.ObjectKey);
            RefreshCommentList();
        }

        private void btnAddComment_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbCommentAdd.Text)) 
                return;

            var commentAndManualOverrideKey = new bo.ForecastCommentAndOverrideKey((bo.ForecastKey)_forecast.ObjectKey, _columnName, DateTime.Now);
            var commentAndManualOverride = _forecast.ForecastCommentAndOverrideCollection.Create(commentAndManualOverrideKey);
            commentAndManualOverride.Comment = tbCommentAdd.Text;
            if (_customer.ForecastAction == ForecastAction.Get)
                _forecast.ForecastCommentAndOverrideCollection.Save(commentAndManualOverride);
            else
                _forecast.ForecastCommentAndOverrideCollection.Add(commentAndManualOverride);
            _forecast.HasComment = true;

            RefreshCommentList();

            tbCommentAdd.Text = string.Empty;
            tbCommentAdd.Focus();
        }

        private void lbComments_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            if (e.Index == -1)
                return;

            var itemText = ((ForecastCommentAndOverride)lbComments.Items[e.Index]).CommentDisplay;
            var textSize = e.Graphics.MeasureString(itemText, lbComments.Font,
            lbComments.ClientSize.Width);
            e.ItemHeight = (int)Math.Round(textSize.Height);
        }

        private void lbComments_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index == -1)
                return;

            var itemText = ((ForecastCommentAndOverride)lbComments.Items[e.Index]).CommentDisplay;
            
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

        private void RefreshCommentList()
        {
            bindingSourceComment.DataSource = _forecast.GetComments(_columnName);
        }
    }
}
