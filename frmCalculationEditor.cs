using System;
using System.Data;
using System.Windows.Forms;
using Stockman.Classes;
using Stockman.Entities;

namespace Stockman
{
    public partial class frmCalculationEditor : FormBase
    {
        #region startup and initialize
        public frmCalculationEditor(frmTemplates_editImport parentForm)
        {
            frmParent = parentForm;
            InitializeComponent();
        }

        private void frmCalculationEditor_Load(object sender, EventArgs e)
        {
            loadDBColumns();
        }
        #endregion

        #region initialize classes
        templateMethods tempMethods = new templateMethods();
        #endregion

        #region properties
        frmTemplates_editImport frmParent;
        public string databaseColumnName { get; set; }
        public Templates selectedTemplate { get; set; }
        public string calculation
        {
            set
            {
                txtCalculation.Text = value;
            }
        }
        #endregion

        #region events
        private void button1_Click(object sender, EventArgs e)
        {
            frmParent.calculation = txtCalculation.Text;
            this.Close();
        }

        private void lbColumns_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            txtCalculation.Text += "[" + lbColumns.Text + "] ";
            txtCalculation.SelectionStart = txtCalculation.Text.Length;
            txtCalculation.Focus();
        }
        #endregion

        #region methods
        private void loadDBColumns()
        {
            DataTable dt = new DataTable();
            try
            {
                dt = tempMethods.getDBColumns("stockItems", "decimal");
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
                return;
            }

            //remove selected item to prevent circular calculations
            int toRemove = -1;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["COLUMN_NAME"].ToString().ToUpper() == databaseColumnName.ToUpper())
                {
                    toRemove = i;
                }
            }
            if (toRemove > -1)
            {
                dt.Rows.RemoveAt(toRemove);
            }

            //bind data to selection box
            lbColumns.DataSource = dt;
            lbColumns.ValueMember = "COLUMN_NAME";
            lbColumns.DisplayMember = "COLUMN_NAME";
        }
        #endregion

        private void button2_Click(object sender, EventArgs e)
        {
            txtCalculation.Text = "";
        }
    }
}
