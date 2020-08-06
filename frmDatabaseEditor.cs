using System;
using System.Data;
using System.Windows.Forms;
using Stockman.Classes;
using System.Collections;

namespace Stockman
{
    public partial class frmDatabaseEditor : FormBase
    {
        #region startup and initialize
        public frmDatabaseEditor(frmTemplates_editImport parentForm)
        {
            frmParent = parentForm;
            InitializeComponent();

            loadColumns();
        }
        #endregion

        #region properties
        frmTemplates_editImport frmParent;
        #endregion

        #region initialize classes
        templateMethods tempMethods = new templateMethods();
        #endregion

        #region methods
        private void loadColumns()
        {
            //load all columns
            DataTable dt = null;
            try
            {
                dt = tempMethods.getDBColumns("stockItems", null);
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
                return;
            }

            //remove base and additional columns to remove
            ArrayList colsToRemove = stockMetaColumns;
            colsToRemove.Add("lastUpdate");
            colsToRemove.Add("productBasePrice");

            foreach (DataRow dr in dt.Rows)
            {
                if (colsToRemove.Contains(dr["COLUMN_NAME"].ToString()))
                {
                    dr.Delete();
                }
            }

            //set data source
            cbDBColumns.DataSource = dt;
            cbDBColumns.ValueMember = "COLUMN_NAME";
            cbDBColumns.DisplayMember = "COLUMN_NAME";
        }
        #endregion

        #region events
        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you wish to delete this database column?  All templates currently using this column will be affected", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes)
            {
                try
                {
                    tempMethods.deleteDBColumn(cbDBColumns.Text);
                    MessageBox.Show("Column deleted");
                    loadColumns();
                }
                catch (Exception ee)
                {
                    MessageBox.Show(ee.Message);
                    return;
                }

                frmParent.refreshDBColumns = true;
            }
        }
        #endregion
    }
}
