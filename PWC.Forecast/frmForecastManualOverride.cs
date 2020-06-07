using System;
using System.Windows.Forms;
using PWC.BusinessObject;
using bo = PWC.BusinessObject;

namespace PWC.Forecast
{
    public partial class frmForecastManualOverride : Form
    {
        private readonly Customer _customer;
        private readonly DataGridView _dgvForecast ;
        private readonly DataGridViewSelectedCellCollection _selectedCellCollection;

        public frmForecastManualOverride(DataGridViewSelectedCellCollection selectedCellCollection, DataGridView dgvForecast, Customer customer)
        {
            InitializeComponent();
            _selectedCellCollection = selectedCellCollection;
            _dgvForecast = dgvForecast;
            _customer = customer;
        }

        private void frmForecastManualOverride_Load(object sender, EventArgs e)
        {
            short falseCount = 0;
            short trueCount = 0;
            foreach (DataGridViewCell selectedCell in _selectedCellCollection)
            {
                var forecast = (bo.Forecast) _dgvForecast.Rows[selectedCell.RowIndex].DataBoundItem;
                var columnName = _dgvForecast.Columns[selectedCell.ColumnIndex].HeaderText;
                if (forecast.GetOverride(columnName))
                    trueCount++;
                else
                    falseCount++;

                lbSelected.Items.Add(string.Format("{0} {1} {2}", forecast.ItemNumber, forecast.ForecastMethod, columnName));
            }
            if (trueCount == _selectedCellCollection.Count)
                chkManualOverride.CheckState = CheckState.Checked;
            else if (falseCount == _selectedCellCollection.Count)
                chkManualOverride.CheckState = CheckState.Unchecked;
            else
                chkManualOverride.CheckState = CheckState.Indeterminate;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewCell selectedCell in _selectedCellCollection)
            {
                var forecast = (bo.Forecast)_dgvForecast.Rows[selectedCell.RowIndex].DataBoundItem;
                var columnName = _dgvForecast.Columns[selectedCell.ColumnIndex].HeaderText;
                if (forecast.GetOverride(columnName) == chkManualOverride.Checked)
                    continue;

                _customer.UpdateForecastOverride(forecast, columnName, chkManualOverride.Checked, selectedCell.RowIndex >= _customer.ForecastCollection.Count);
            }
        }
    }
}
