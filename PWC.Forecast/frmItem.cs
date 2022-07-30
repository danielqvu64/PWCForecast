using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Text;
using System.Windows.Forms;
using PWC.BusinessObject;
using DVu.Library.PersistenceLayer;

namespace PWC.Forecast
{
    public partial class frmItem : Form
    {
        private Item.ParameteredCollection _itemCollection;
        private readonly List<DropDownItem> _brandDropDownCollection2 = Utility.GetInstance().GetBrandDropDownCollection();
        private readonly List<DropDownItem> _productCategoryDropDownCollection2 = Utility.GetInstance().GetProductCategoryDropDownCollection();
        private readonly List<DropDownItem> _productGroupCollection = Utility.GetInstance().GetProductGroupDropDownCollection();
        private readonly List<DropDownItem> _productGroupCollection2 = Utility.GetInstance().GetProductGroupDropDownCollection();

        public frmItem()
        {
            InitializeComponent();
        }

        private void frmItem_Load(object sender, EventArgs e)
        {
            _itemCollection = new Item.ParameteredCollection();
            bindingSourceItem.DataSource = null;
            bindingSourceItem.DataSource = _itemCollection;
            dgvItem.DefaultCellStyle.NullValue = "Null";
            dgvItem.DefaultCellStyle.DataSourceNullValue = Convert.DBNull;

            cboBrand.ValueMember = "Code";
            cboBrand.DisplayMember = "CodeDescription";
            cboBrand.DataSource = _brandDropDownCollection2;
            cboProductCategory.ValueMember = "Code";
            cboProductCategory.DisplayMember = "CodeDescription";
            cboProductCategory.DataSource = _productCategoryDropDownCollection2;
            cboProductGroup.ValueMember = "Code";
            cboProductGroup.DisplayMember = "CodeDescription";
            cboProductGroup.DataSource = _productGroupCollection2;
            ((DataGridViewComboBoxColumn)dgvItem.Columns["ProductGroup"]).DataSource = _productGroupCollection;
            ((DataGridViewComboBoxColumn)dgvItem.Columns["ProductGroup"]).DisplayMember = "CodeDescription";
            ((DataGridViewComboBoxColumn)dgvItem.Columns["ProductGroup"]).ValueMember = "Code";
        }

        private void txtItemNumber_GotFocus(object sender, System.EventArgs e)
        {
            txtItemNumber.SelectAll();
        }

        private void txtItemDescription_GotFocus(object sender, System.EventArgs e)
        {
            txtItemDescription.SelectAll();
        }

        private void dgvItem_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            try
            {
                if (dgvItem.Columns[e.ColumnIndex].Name != "ItemNumber")
                    return;
                if (e.RowIndex < _itemCollection.Count)
                {
                    e.Cancel = true;
                    return;
                }
                if (!chkUseClipboardDataOnNewRow.Checked)
                    return;
                var values = Clipboard.GetText().Split('\t');
                var newRow = dgvItem.Rows[e.RowIndex];
                if (values.Length != newRow.Cells.Count)
                    return;
                for (var sourceRowIndex = 0; sourceRowIndex < dgvItem.Rows.Count; sourceRowIndex++)
                    if (dgvItem.Rows[sourceRowIndex].Cells["ItemNumber"].Value != null &&
                        values[1].IndexOf(dgvItem.Rows[sourceRowIndex].Cells["ItemNumber"].Value.ToString(), StringComparison.Ordinal) > -1)
                    {
                        var sourceRow = dgvItem.Rows[sourceRowIndex];
                        for (var cellIndex = 0; cellIndex < newRow.Cells.Count; cellIndex++)
                            newRow.Cells[cellIndex].Value = sourceRow.Cells[cellIndex].Value;
                        break;
                    }
            }
            catch (Exception ex)
            {
                Utility.GetInstance().HandleException(this, ex, e);
            }
        }

        private void dgvItem_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Clear the row error in case the user presses ESC.   
                dgvItem.Rows[e.RowIndex].ErrorText = String.Empty;
            }
            catch (Exception ex)
            {
                Utility.GetInstance().HandleException(this, ex, e);
            }
        }

        private void dgvItem_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
        {
            try
            {
                if (e != null && e.Value != null)
                {
                    try
                    {
                        // default parsing fails to convert string to sqlstring
                        // assist it here.
                        if (dgvItem.Columns[e.ColumnIndex].Name == "ItemNumber" |
                            dgvItem.Columns[e.ColumnIndex].Name == "ItemDescription")
                        {
                            e.Value = new SqlString(e.Value.ToString());
                            e.ParsingApplied = true;
                        }
                    }
                    catch (FormatException)
                    {
                        // Set to false in case another CellParsing handler
                        // wants to try to parse this DataGridViewCellParsingEventArgs instance.
                        e.ParsingApplied = false;
                    }
                }
            }
            catch (Exception ex)
            {
                Utility.GetInstance().HandleException(this, ex, e);
            }
        }

        private void dgvItem_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            try
            {
                if (!dgvItem.IsCurrentCellDirty)
                    return;
                if (e.FormattedValue == null)
                {
                    dgvItem.Rows[e.RowIndex].ErrorText = "Entry is required";
                    e.Cancel = true;
                }
                else
                {
                    if (dgvItem.Columns[e.ColumnIndex].Name == "ItemNumber")
                    {
                        var rx = new System.Text.RegularExpressions.Regex(@"^\d{2}-\d{5}-[A-Z0-9]{2}$|^\d{7}$");
                        var formattedValue = e.FormattedValue.ToString();
                        if (!rx.IsMatch(formattedValue))
                        {
                            dgvItem.Rows[e.RowIndex].ErrorText = "Please enter Item Number in ##-#####-AA or #######";
                            e.Cancel = true;
                        }
                        else
                        {
                            var checkItemCollection = new Item.ParameteredCollection(formattedValue, SqlString.Null, SqlString.Null, SqlString.Null, SqlString.Null);
                            checkItemCollection.Load();
                            if (checkItemCollection.Count > 0)
                            {
                                dgvItem.Rows[e.RowIndex].ErrorText = "Item already exists";
                                e.Cancel = true;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Utility.GetInstance().HandleException(this, ex, e);
            }
        }

        private void dgvItem_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.Exception == null)
                return;
            var additionalData = new StringBuilder("Context: ");
            additionalData.Append(e.Context.ToString()).Append("\n");
            additionalData.Append("RowIndex: ").Append(e.RowIndex.ToString()).Append("\n");
            additionalData.Append("ColumnIndex: ").Append(e.ColumnIndex.ToString());
            PersistenceFacade.GetInstance().LogException(e.Exception, Environment.MachineName, additionalData.ToString());
            e.ThrowException = true;
        }

        private void dgvItem_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            try
            {
                if (!dgvItem.IsCurrentRowDirty)
                    return;

                if (dgvItem.CurrentRow.Cells["ItemNumber"].Value != null)
                {
                    SqlString itemNumber = dgvItem.CurrentRow.Cells["ItemNumber"].Value.ToString();
                    if (itemNumber.IsNull)
                    {
                        dgvItem.Rows[e.RowIndex].ErrorText = "Item Number is required";
                        e.Cancel = true;
                        return;
                    }
                    var rx = new System.Text.RegularExpressions.Regex(@"^\d{2}-\d{5}-[A-Z0-9]{2}$|^\d{7}$");
                    if (!rx.IsMatch(itemNumber.Value))
                    {
                        dgvItem.Rows[e.RowIndex].ErrorText = "Please enter Item Number in ##-#####-AA or #######";
                        e.Cancel = true;
                        return;
                    }
                    Item item;
                    // new record
                    if (e.RowIndex >= _itemCollection.Count)
                    {
                        var checkItemCollection = new Item.ParameteredCollection(itemNumber, SqlString.Null, SqlString.Null, SqlString.Null, SqlString.Null);
                        checkItemCollection.Load();
                        if (checkItemCollection.Count > 0)
                        {
                            dgvItem.Rows[e.RowIndex].ErrorText = "Item already exists";
                            e.Cancel = true;
                        }
                        else
                        {
                            item = _itemCollection.Create(new ItemKey(itemNumber));
                            if (dgvItem.CurrentRow.Cells["ItemDescription"].Value != null)
                                item.ItemDescription = (SqlString)dgvItem.CurrentRow.Cells["ItemDescription"].Value;
                            if (dgvItem.CurrentRow.Cells["ProductGroup"].Value != null)
                                item.ProductGroupCodeBinding = (string)dgvItem.CurrentRow.Cells["ProductGroup"].Value;
                            _itemCollection.Save(item);
                            // when the initial collection is empty
                            // 1. item in bindingSource is not set to the correct type, so reset the bindingSource.DataSource below
                            // 2. the data moves above need to check for null
                            if (bindingSourceItem.Count == 1)
                            {
                                bindingSourceItem.DataSource = null;
                                bindingSourceItem.DataSource = _itemCollection;
                            }
                            else
                                bindingSourceItem.List[bindingSourceItem.Count - 1] = item;
                        }
                    }
                    // existing record
                    else
                    {
                        //item = _itemCollection[new ItemKey(itemNumber)];
                        //item.Save();
                        item = (Item)dgvItem.CurrentRow.DataBoundItem;
                        _itemCollection.Save(item);
                        _itemCollection[new ItemKey(itemNumber)] = item;
                    }
                }
            }
            catch (Exception ex)
            {
                Utility.GetInstance().HandleException(this, ex, e);
            }
        }

        private void dgvItem_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            try
            {
                var itemNumber = e.Row.Cells["ItemNumber"].Value.ToString();
                if (MessageBox.Show(string.Format("Please confirm deletion for Item Number: {0}.", itemNumber), "PWC Forecast", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                    e.Cancel = true;
                else
                    _itemCollection.Delete(new ItemKey(itemNumber));
            }
            catch (Exception ex)
            {
                Utility.GetInstance().HandleException(this, ex, e);
            }
        }

        private void dgvItem_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                var tb = e.Control as TextBox;
                if (tb == null)
                    return;
                var keyPressEventHandler = new KeyPressEventHandler(txtUpperCase_KeyPress);
                tb.KeyPress -= keyPressEventHandler;
                if (dgvItem.Columns[dgvItem.CurrentCell.ColumnIndex].Name == "ItemNumber")
                    tb.KeyPress += keyPressEventHandler;
            }
            catch (Exception ex)
            {
                Utility.GetInstance().HandleException(this, ex, e);
            }
        }

        private void txtUpperCase_KeyPress(object sender, KeyPressEventArgs e)
        {
            //char C = e.KeyChar;
            //if (Char.IsLetter(C) == true)
            //{
            //    e.Handled = true;
            //    System.Media.SystemSounds.Beep.Play();
            //}

            // upper case pipeline entry
            e.KeyChar = Char.ToUpper(e.KeyChar);
        }
        
        private void btnSearch_Click(object sender, EventArgs e)
        {
            _itemCollection = new Item.ParameteredCollection(txtItemNumber.Text == string.Empty ? SqlString.Null : txtItemNumber.Text,
                txtItemDescription.Text == string.Empty ? SqlString.Null : txtItemDescription.Text,
                cboProductGroup.SelectedIndex < 1 ? SqlString.Null : cboProductGroup.SelectedValue.ToString(),
                cboBrand.SelectedIndex < 1 ? SqlString.Null : cboBrand.SelectedValue.ToString(),
                cboProductCategory.SelectedIndex < 1 ? SqlString.Null : cboProductCategory.SelectedValue.ToString());
            _itemCollection.Load();
            bindingSourceItem.DataSource = _itemCollection;
        }
    }
}
