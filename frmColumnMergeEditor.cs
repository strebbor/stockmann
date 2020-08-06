using System;
using System.Data;
using System.Windows.Forms;
using Stockman.Classes;
using Stockman.Entities;

namespace Stockman
{
    public partial class frmColumnMergeEditor : Form
    {
        #region startup and initialize
        public frmColumnMergeEditor(frmTemplates_editExport parentForm)
        {
            frmParent = parentForm;
            InitializeComponent();
        }

        #endregion

        #region initialize classes
        templateMethods tempMethods = new templateMethods();
        #endregion

        #region properties
        frmTemplates_editExport frmParent;
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
            txtCalculation.Text += "+ [" + lbColumns.Text + "] ";
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
                dt = tempMethods.getDBColumns("stockItems", "");
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
                return;
            }

            //bind data to column selector
            lbColumns.DataSource = dt;
            lbColumns.ValueMember = "COLUMN_NAME";
            lbColumns.DisplayMember = "COLUMN_NAME";
        }
        #endregion

        #region events
        private void frmCalculationEditor_Load(object sender, EventArgs e)
        {
            loadDBColumns();
        }

        private void frmColumnMergeEditor_Load(object sender, EventArgs e)
        {
            loadDBColumns();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            txtCalculation.Text = txtCalculation.Text + " + [space] ";
        }
        #endregion
    }
}
