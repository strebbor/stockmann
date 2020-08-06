using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Stockman.Classes;
using Stockman.Entities;


namespace Stockman
{
    public partial class frmSpecialsCalculationEditor : FormBase
    {
        #region initialize classes
        templateMethods tempMethods = new templateMethods();
        #endregion

        #region properties
        frmTemplates_editExport frmParent;
        public string calculation { get; set; }
        #endregion

        public frmSpecialsCalculationEditor(frmTemplates_editExport parentForm)
        {
            InitializeComponent();
            frmParent = parentForm;
        }

        private void loadDBColumns()
        {
            DataTable dt = tempMethods.getDBColumns("stockItems", null);

            ArrayList colsToRemove = stockMetaColumns;
            colsToRemove.Add("lastUpdate");
            colsToRemove.Add("d_grossMargin");
            colsToRemove.Add("d_agencyMargin");
            colsToRemove.Add("d_discount");

            foreach (DataRow dr in dt.Rows)
            {
                if (colsToRemove.Contains(dr["COLUMN_NAME"].ToString()))
                {
                    dr.Delete();
                }
            }

            cbTableOneColumn.DataSource = dt;
            cbTableOneColumn.ValueMember = "COLUMN_NAME";
            cbTableOneColumn.DisplayMember = "COLUMN_NAME";

            cbTableTwoColumn.DataSource = dt.Copy();
            cbTableTwoColumn.ValueMember = "COLUMN_NAME";
            cbTableTwoColumn.DisplayMember = "COLUMN_NAME";
        }

        private void frmSpecialsCalculationEditor_Load(object sender, EventArgs e)
        {
            loadDBColumns();

            if (string.IsNullOrWhiteSpace(calculation)) { return; }

            SpecialsCalculation sc = tempMethods.getSpecialsCalculation(calculation);

            cbTableOne.Text = sc.tableOne.ToString();
            cbTableOneColumn.Text = sc.tableOneColumn;
            cbOperator.Text = sc.operation;
            cbTableTwo.Text = sc.tableTwo.ToString();
            cbTableTwoColumn.Text = sc.tableTwoColumn;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //build the calculation string
            string calcString = "TABLE1:" + cbTableOne.Text + "#COL1:" + cbTableOneColumn.Text + "#OPERATOR:" + cbOperator.Text + "#TABLE2:" + cbTableTwo.Text + "#COL2:" + cbTableTwoColumn.Text;
            frmParent.calculation = calcString;

            this.Close();
        }
    }
}
