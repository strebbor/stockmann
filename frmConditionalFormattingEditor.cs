using System;
using System.Windows.Forms;
using Stockman.Entities;
using Stockman.Classes;

namespace Stockman
{
    public partial class frmConditionalFormattingEditor : FormBase
    {
        #region startup and initialize
        public frmConditionalFormattingEditor(frmTemplates_editImport parentForm)
        {
            frmParent = parentForm;
            InitializeComponent();
        }
        private void frmConditionalFormattingEditor_Load(object sender, EventArgs e)
        {
            loadFormats();
        }

        #endregion

        #region initialize classes
        public TemplateColumns selectedColumn { get; set; }
        frmTemplates_editImport frmParent;
        templateMethods tempMethods = new templateMethods();
        #endregion

        #region properties
        int selectedGridRow = 0;
        #endregion

        #region events
        private void textBox2_MouseDown(object sender, MouseEventArgs e)
        {
            if (colorDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtColor.BackColor = colorDialog1.Color;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!validateInputs(panel1))
            {
                return;
            }

            TemplateConditionalFormatting condFormat = new TemplateConditionalFormatting();
            condFormat.highlightColor = txtColor.BackColor;
            condFormat.number = decimal.Parse(txtNumber.Text);
            condFormat.op = bOperator.Text;

            tempMethods.insertFormatting(selectedColumn, bOperator.Text, decimal.Parse(txtNumber.Text), txtColor.BackColor);

            loadFormats();
        }

        private void gvFormatting_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                selectedGridRow = e.RowIndex;
            }
        }

        #endregion

        #region methods
        public void loadFormats()
        {
            tempMethods.loadTemplateConditionalFormatting(selectedColumn);
            gvFormatting.DataSource = selectedColumn.templateConditionalFormatting;
           
            gvFormatting.Columns.Clear();
            gvFormatting.AutoGenerateColumns = false;

            DataGridViewTextBoxColumn col1 = new DataGridViewTextBoxColumn();
            col1.DataPropertyName = "op";
            col1.HeaderText = "Operation";
            col1.Name = "Operation";
            gvFormatting.Columns.Add(col1);

            DataGridViewTextBoxColumn col2 = new DataGridViewTextBoxColumn();
            col2.DataPropertyName = "number";
            col2.HeaderText = "Limit";
            col2.Name = "Limit";
            gvFormatting.Columns.Add(col2);

            DataGridViewTextBoxColumn col3 = new DataGridViewTextBoxColumn();
            col3.DataPropertyName = "color";
            col3.HeaderText = "Color";
            col3.Name = "Color";
            gvFormatting.Columns.Add(col3);

            gvFormatting.ClearSelection();


            //color cell backgrounds
            for (int i = 0; i < gvFormatting.Rows.Count; i++)
            {
                DataGridViewCellStyle dc = new DataGridViewCellStyle();
                dc.BackColor = ((TemplateConditionalFormatting)gvFormatting.Rows[i].DataBoundItem).highlightColor;
                gvFormatting.Rows[i].Cells["Color"].Style = dc;
            }

            gvFormatting.Refresh();
        }
        #endregion

        #region menus
        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you wish to delete this item?", "Delete confirmation", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                tempMethods.removeFormatting(((TemplateConditionalFormatting)gvFormatting.Rows[selectedGridRow].DataBoundItem).formattingID);
            }

            loadFormats();
        }
        #endregion
    }
}
