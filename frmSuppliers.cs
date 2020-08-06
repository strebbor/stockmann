using System;
using System.ComponentModel;
using System.Windows.Forms;
using Stockman.Entities;
using Stockman.Classes;

namespace Stockman
{
    public partial class frmSuppliers : FormBase
    {
        #region startup and shutdown
        public frmSuppliers()
        {
            InitializeComponent();
        }
        private void frmSuppliers_Load(object sender, EventArgs e)
        {
            clearCreationPanel();
            loadSuppliers();
        }
        #endregion

        #region initialize classes
        supplierMethods supMethods = new supplierMethods();
        #endregion

        #region events
        private void btnAdd_Click(object sender, EventArgs e)
        {
            //validations
            if (!validateInputs(panel1))
            {
                return;
            }

            //build supplier object
            Supplier supplier = new Supplier();
            supplier.supplierID = lblSupplierID.Text;
            supplier.supplierName = txtSupplierName.Text;
            supplier.uniqueKey = txtUniqueKey.Text;
            supplier.supplierCode = txtUniqueKey.Text;
            supplier.active = cbActive.Checked;
            supplier.agencyMargin = decimal.Parse(txtAgencyMargin.Text);
            supplier.discount = decimal.Parse(txtDiscount.Text);
            supplier.grossMargin = decimal.Parse(txtGrossMargin.Text);
            supplier.supplierNotes = txtNotes.Text;
            supplier.lastImportDate = lblLastUpdate.Text;
            supplier.specialsActive = cbSpecialsActive.Checked;
            supplier.specialsImportDate = lblSpecialsDate.Text;

            //create/update supplier
            try
            {
                if (string.IsNullOrWhiteSpace(supplier.supplierID))
                {
                    supMethods.createSupplier(supplier);
                }
                else
                {
                    supMethods.updateSupplier(supplier);
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
                return;
            }

            //reload and cleanup
            loadSuppliers();
            clearCreationPanel();

            gridSuppliers.Rows[selectedRow].Selected = true;
            loadSupplier(selectedRow);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            clearCreationPanel();
        }

        private void loadSupplier(int row)
        {
            string supplierID = gridSuppliers.Rows[row].Cells[0].Value.ToString();

            //bind supplier to edit control
            try
            {
                Supplier s = supMethods.getSupplier(supplierID);
                lblSupplierID.Text = s.supplierID;
                txtSupplierName.Text = s.supplierName;
                txtUniqueKey.Text = s.uniqueKey;
                cbActive.Checked = s.active;
                txtGrossMargin.Text = s.grossMargin.ToString();
                txtDiscount.Text = s.discount.ToString();
                txtAgencyMargin.Text = s.agencyMargin.ToString();
                txtNotes.Text = s.supplierNotes;
                lblLastUpdate.Text = s.lastImportDate.ToString();
                lblSpecialsDate.Text = s.specialsImportDate.ToString();
                cbSpecialsActive.Checked = s.specialsActive;

                txtSupplierName.SelectionStart = txtSupplierName.Text.Length;
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
                return;
            }
        }

        int selectedRow = -1;
        private void gridSuppliers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //get row data
            DataGridView dgv = (DataGridView)sender;
            selectedRow = dgv.CurrentRow.Index;
            loadSupplier(selectedRow);
        }

        #endregion

        #region methods
        private void clearCreationPanel()
        {
            txtSupplierName.Text = "";
            lblSupplierID.Text = "";
            txtAgencyMargin.Text = "";
            txtDiscount.Text = "";
            txtGrossMargin.Text = "";
            txtSupplierName.Text = "";
            txtSupplierName.Text = "";
            txtUniqueKey.Text = "";
            txtUniqueKey.Text = supMethods.generateUniqueKey();
            txtNotes.Text = "";
            lblLastUpdate.Text = new DateTime().ToString();
            cbSpecialsActive.Checked = false;
            cbActive.Checked = true;
            lblSpecialsDate.Text = new DateTime().ToString();
        }
        private void loadSuppliers()
        {
            try
            {
                gridSuppliers.DataSource = null;
                gridSuppliers.Rows.Clear();
                gridSuppliers.Columns.Clear();

                gridSuppliers.AutoGenerateColumns = false;
                gridSuppliers.DataSource = supMethods.getSuppliers();

                DataGridViewTextBoxColumn col5 = new DataGridViewTextBoxColumn();
                col5.DataPropertyName = "supplierID";
                col5.HeaderText = "#";
                col5.Name = "#";
                gridSuppliers.Columns.Add(col5);

                DataGridViewTextBoxColumn col4 = new DataGridViewTextBoxColumn();
                col4.DataPropertyName = "uniqueKey";
                col4.HeaderText = "UNI";
                col4.Name = "UNI";
                gridSuppliers.Columns.Add(col4);

                DataGridViewTextBoxColumn col1 = new DataGridViewTextBoxColumn();
                col1.DataPropertyName = "supplierName";
                col1.HeaderText = "Supplier Name";
                col1.Name = "Supplier Name";
                gridSuppliers.Columns.Add(col1);

                DataGridViewTextBoxColumn col2 = new DataGridViewTextBoxColumn();
                col2.DataPropertyName = "active";
                col2.HeaderText = "Active";
                col2.Name = "Active";
                gridSuppliers.Columns.Add(col2);

                gridSuppliers.ClearSelection();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
                return;
            }
        }
        #endregion

        #region context menus
        private void showAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            supMethods.showActive = supplierMethods.activeStates.ALL;
            loadSuppliers();
        }
        private void showActiveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            supMethods.showActive = supplierMethods.activeStates.ACTIVE;
            loadSuppliers();
        }
        private void showInactiveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            supMethods.showActive = supplierMethods.activeStates.DISABLED;
            loadSuppliers();
        }
        #endregion

        private void gridSuppliers_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (MessageBox.Show("Are you sure you wish to delete this supplier?  This action CANNOT be undone", "Delete supplier", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                string supplierID = e.Row.Cells[0].Value.ToString();
                try
                {
                    supMethods.deleteSupplier(supplierID);
                }
                catch (Exception ee)
                {
                    MessageBox.Show(ee.Message);
                    return;
                }
            }
        }

        private void gridSuppliers_RowEnter(object sender, DataGridViewCellEventArgs e)
        {            
            //get row data
            DataGridView dgv = (DataGridView)sender;

            if (dgv.Columns.Count < 4) { return; }

            int selectedRow = e.RowIndex;
            string supplierID = dgv.Rows[selectedRow].Cells[0].Value.ToString();

            //bind supplier to edit control
            try
            {
                Supplier s = supMethods.getSupplier(supplierID);
                lblSupplierID.Text = s.supplierID;
                txtSupplierName.Text = s.supplierName;
                txtUniqueKey.Text = s.uniqueKey;
                cbActive.Checked = s.active;
                txtGrossMargin.Text = s.grossMargin.ToString();
                txtDiscount.Text = s.discount.ToString();
                txtAgencyMargin.Text = s.agencyMargin.ToString();
                txtNotes.Text = s.supplierNotes;
                lblLastUpdate.Text = s.lastImportDate.ToString();
                lblSpecialsDate.Text = s.specialsImportDate.ToString();
                cbSpecialsActive.Checked = s.specialsActive;

                txtSupplierName.SelectionStart = txtSupplierName.Text.Length;
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
                return;
            }
        }
    }
}
