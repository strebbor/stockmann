using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Stockman.Entities;
using Stockman.Classes;
using System.Drawing;

namespace Stockman
{
    public partial class frmTemplates_editExport : FormBase
    {
        #region startup and initialize
        public frmTemplates_editExport()
        {
            InitializeComponent();
        }
        private void frmTemplates_editExport_Load(object sender, EventArgs e)
        {
            loadDBColumns();

            //get suppliers
            DataTable dt = supMethods.getSuppliers();
            DataRow dr = dt.NewRow();
            dt.DefaultView.Sort = "supplierName";

            cbSuppliers.DataSource = dt;
            cbSuppliers.ValueMember = "supplierID";
            cbSuppliers.DisplayMember = "supplierName";

            DataTable dt2 = supMethods.getSuppliers();
            cbCopyToSupplier.DataSource = dt2;
            cbCopyToSupplier.ValueMember = "supplierID";
            cbCopyToSupplier.DisplayMember = "supplierName";

            //preload items if available
            if (!string.IsNullOrWhiteSpace(supplierID))
            {
                cbSuppliers.SelectedValue = supplierID;
                loadTemplates();

                if (!string.IsNullOrWhiteSpace(templateID))
                {
                    cbTemplates.SelectedValue = templateID;

                    pnlEditor.Visible = true;
                    Templates selectedTemplate = (Templates)cbTemplates.SelectedItem;
                    loadColumnsIntoGrid(selectedTemplate);
                }
            }
            else
            {
                loadTemplates();
            }
        }
        #endregion

        #region initialize classes
        supplierMethods supMethods = new supplierMethods();
        templateMethods tempMethods = new templateMethods();
        #endregion

        #region properties
        private int highlightColumn = -1;
        public string templateID { get; set; }
        public string supplierID { get; set; }
        private Templates selectedTemplate { get; set; }
        private int selectedGridRow = -1;
        private TemplateColumns selectedColumn { get; set; }
        public string calculation
        {
            set
            {
                if (cbSpecialsExportColumn.Checked)
                {
                    txtSpecialsCalculation.Text = value;

                    if (string.IsNullOrWhiteSpace(txtSpecialsCalculation.Text))
                    {
                        cbColumnNames.CausesValidation = true;
                    }
                    else
                    {
                        cbColumnNames.CausesValidation = false;
                        cbColumnNames.Text = "";
                    }
                }
                else
                {
                    txtCalculation.Text = value;

                    if (string.IsNullOrWhiteSpace(txtCalculation.Text))
                    {
                        cbColumnNames.CausesValidation = true;
                    }
                    else
                    {
                        cbColumnNames.CausesValidation = false;
                        cbColumnNames.Text = "";
                    }
                }
            }
        }
        #endregion

        #region events
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmColumnMergeEditor frmCal = new frmColumnMergeEditor(this);
            frmCal.calculation = txtCalculation.Text;
            frmCal.selectedTemplate = selectedTemplate;
            if (!string.IsNullOrWhiteSpace(cbColumnNames.Text))
            {
                frmCal.databaseColumnName = cbColumnNames.Text;
            }
            frmCal.StartPosition = FormStartPosition.CenterParent;
            frmCal.ShowDialog(this);
        }
        private void gvTemplates_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            btnUpdate.Text = "Update";

            selectedColumn = (TemplateColumns)gvTemplates.Rows[e.RowIndex].DataBoundItem;
            loadColumnDetails(e.RowIndex);
        }
        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                tempMethods.copyTemplate(cbTemplates.SelectedValue.ToString(), cbCopyToSupplier.SelectedValue.ToString());
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
                return;
            }

            pnlMakeCopy.Hide();
            loadTemplates();
        }

        private void cbSuppliers_SelectionChangeCommitted(object sender, EventArgs e)
        {
            loadTemplates();
        }

        private void cbTemplates_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedTemplate = (Templates)cbTemplates.SelectedItem;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!validateInputs(pnlEditColumn)) { return; }

            if (lblTemplateColumnID.Text != "#")
            {
                //update column
                tempMethods.updateColumn(selectedTemplate, lblTemplateColumnID.Text, txtCSVHeader.Text, cbColumnNames.Text, "", "", false, false, templateMethods.ColumnCalculationEntities.NONE, selectedColumn.position, txtExportDefault.Text, cbIncludeAttributes.Checked, null, "", cbSpecialsExportColumn.Checked, cbKeepOriginalData.Checked);
                lblTemplateColumnID.Text = "#";
                cbColumnNames.SelectedIndex = 0;
                txtCSVHeader.Text = "";
            }
            else
            {
                //add column to templates
                try
                {
                    tempMethods.insertColumn(selectedTemplate, txtCSVHeader.Text, cbColumnNames.Text, "", "", false, false, templateMethods.ColumnCalculationEntities.NONE, txtExportDefault.Text, null, "", cbSpecialsExportColumn.Checked, cbKeepOriginalData.Checked);

                    lblTemplateColumnID.Text = "#";
                    cbColumnNames.SelectedIndex = 0;
                    txtCSVHeader.Text = "";
                }
                catch (DuplicateNameException dup)
                {
                    MessageBox.Show(dup.Message);
                    return;
                }
            }

            loadColumnsIntoGrid(selectedTemplate);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!validateInputs(pnlSelect))
            {
                return;
            }

            loadEditor();

            pnlSelect.Enabled = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            pnlEditor.Hide();

            if (!validateInputs(pnlSelect))
            {
                return;
            }

            pnlMakeCopy.Show();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (!validateInputs(pnlSelect))
            {
                return;
            }

            if (MessageBox.Show("Are you sure you wish to delete the whole template?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Stop) == System.Windows.Forms.DialogResult.Yes)
            {
                try
                {
                    tempMethods.removeTemplate(selectedTemplate);
                }
                catch (Exception ee)
                {
                    MessageBox.Show(ee.Message);
                    return;
                }
                loadTemplates();
                pnlMakeCopy.Visible = false;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (!validateInputs(pnlSelect))
            {
                return;
            }

            string tempIndex = selectedTemplate.templateID;
            string newName = InputBox.ShowDialog("Enter new template name", "Template Rename");
            if (!string.IsNullOrWhiteSpace(newName))
            {
                tempMethods.renameTemplate(selectedTemplate, newName);
                loadTemplates();
                cbTemplates.SelectedValue = tempIndex;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            pnlMakeCopy.Hide();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //set validation and validate
            cbColumnNames.CausesValidation = string.IsNullOrEmpty(txtCalculation.Text);
            if (!validateInputs(pnlEditColumn)) { return; }

            //determine which field to use for the calculation
            string calculationValue = txtCalculation.Text;
            if (cbSpecialsExportColumn.Checked)
            {
                calculationValue = txtSpecialsCalculation.Text;
            }

            //update/insert column
            if (lblTemplateColumnID.Text != "#")
            {
                if (MessageBox.Show("Are you sure you wish to UPDATE this column?", "Update", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    //update column
                    //if this is a calculated column, remove db colum
                    if (!string.IsNullOrEmpty(txtCalculation.Text) || !string.IsNullOrEmpty(txtSpecialsCalculation.Text))
                    {
                        if (!cbSpecialsExportColumn.Checked)
                        {
                            //can a calculation be used on this column?
                            if (cbFormatting.Text != "STRING")
                            {
                                MessageBox.Show("Merge can only be performed on STRING columns");
                                return;
                            }
                            tempMethods.updateColumn(selectedTemplate, lblTemplateColumnID.Text, txtCSVHeader.Text, null, cbFormatting.Text, calculationValue, false, false, templateMethods.ColumnCalculationEntities.MERGE, selectedColumn.position, txtExportDefault.Text, cbIncludeAttributes.Checked, null, "", cbSpecialsExportColumn.Checked, cbKeepOriginalData.Checked);
                        }
                        else
                        {
                            tempMethods.updateColumn(selectedTemplate, lblTemplateColumnID.Text, txtCSVHeader.Text, null, cbFormatting.Text, calculationValue, false, false, templateMethods.ColumnCalculationEntities.CALCULATE, selectedColumn.position, txtExportDefault.Text, cbIncludeAttributes.Checked, null, "", cbSpecialsExportColumn.Checked, cbKeepOriginalData.Checked);
                        }
                    }
                    else
                    {
                        tempMethods.updateColumn(selectedTemplate, lblTemplateColumnID.Text, txtCSVHeader.Text, cbColumnNames.Text, cbFormatting.Text, calculationValue, false, false, templateMethods.ColumnCalculationEntities.NONE, selectedColumn.position, txtExportDefault.Text, cbIncludeAttributes.Checked, null, "", cbSpecialsExportColumn.Checked, cbKeepOriginalData.Checked);
                    }

                    lblTemplateColumnID.Text = "#";
                    cbColumnNames.SelectedIndex = 0;
                    txtCSVHeader.Text = "";
                }
            }
            else
            {
                if (MessageBox.Show("Are you sure you wish to INSERT this column?", "Update", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    //add column to templates
                    try
                    {
                        //update column

                        //if this is a calculated column, remove db colum
                        if (!string.IsNullOrEmpty(txtCalculation.Text))
                        {
                            //can a calculation be used on this column?
                            if (cbFormatting.Text != "STRING")
                            {
                                MessageBox.Show("Merge can only be performed on STRING columns");
                                return;
                            }

                            tempMethods.insertColumn(selectedTemplate, txtCSVHeader.Text, null, cbFormatting.Text, calculationValue, false, false, templateMethods.ColumnCalculationEntities.MERGE, txtExportDefault.Text, null, "", cbSpecialsExportColumn.Checked, cbKeepOriginalData.Checked);
                        }
                        else
                        {
                            tempMethods.insertColumn(selectedTemplate, txtCSVHeader.Text, cbColumnNames.Text, cbFormatting.Text, calculationValue, false, false, templateMethods.ColumnCalculationEntities.NONE, txtExportDefault.Text, null, "", cbSpecialsExportColumn.Checked, cbKeepOriginalData.Checked);
                        }

                        lblTemplateColumnID.Text = "#";
                        cbColumnNames.SelectedIndex = 0;
                        txtCSVHeader.Text = "";
                    }
                    catch (DuplicateNameException dup)
                    {
                        MessageBox.Show(dup.Message);
                        return;
                    }
                }
            }

            loadColumnsIntoGrid(selectedTemplate);
            clearColumnEditor();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            txtCSVHeader.Text = "";
            cbColumnNames.SelectedIndex = 0;

            pnlEditor.Visible = false;
            pnlSelect.Enabled = true;
        }

        private void gvTemplates_MouseDown(object sender, MouseEventArgs e)
        {
            DataGridView.HitTestInfo hit = gvTemplates.HitTest(e.X, e.Y);

            if (hit.Type == DataGridViewHitTestType.Cell)
            {
                selectedGridRow = gvTemplates.CurrentCell.RowIndex;
                gvTemplates.CurrentCell = gvTemplates[hit.ColumnIndex, hit.RowIndex];
            }

            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show(gvTemplates, e.X, e.Y);
            }

            loadColumnDetails(hit.RowIndex);
            btnUpdate.Text = "Update";
        }
        #endregion

        #region methods
        private void swopColumns(templateMethods.DIRECTION direction)
        {
            if (selectedColumn == null)
            {
                return;
            }
            gvTemplates.DataSource = null;
            highlightColumn = selectedColumn.position;
            try
            {
                tempMethods.swopColumns(selectedTemplate, selectedColumn, direction);
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
            finally
            {
                loadColumnsIntoGrid(selectedTemplate);
                //highlight the swopped column   
                try
                {
                    if (direction == templateMethods.DIRECTION.UP)
                    {
                        highlightColumn = highlightColumn - 2;
                    }

                    pnlEditColumn.Visible = false;
                    //   gvTemplates.Rows[highlightColumn].Cells[0].Selected = true;
                    //   selectedColumn = (TemplateColumns)gvTemplates.Rows[highlightColumn].DataBoundItem;
                }
                catch (Exception ee)
                {
                    //ignore
                }
            }
        }
        private void loadColumnDetails(int rowIndex)
        {
            if (rowIndex < 0) { return; }

            btnUpdate.Text = "Update";
            txtCalculation.Text = selectedColumn.calculation;
            cbIncludeAttributes.Checked = selectedColumn.includeAttributes;
            int selectedRow = rowIndex;
            txtCSVHeader.Text = selectedColumn.csvHeader;
            string selectedFormatting = "STRING";
            switch (selectedColumn.columnType.ToString())
            {
                case "DECIMAL_18_2": { selectedFormatting = "DECIMAL 0.00"; } break;
                case "DECIMAL_18_3": { selectedFormatting = "DECIMAL 0.000"; } break;
                case "DECIMAL_18_4": { selectedFormatting = "DECIMAL 0.0000"; } break;
                case "DECIMAL_18_5": { selectedFormatting = "DECIMAL 0.00000"; } break;

            }
            cbFormatting.SelectedIndex = cbFormatting.FindStringExact(selectedFormatting);
            cbColumnNames.SelectedValue = selectedColumn.databaseColumn;

            lblTemplateColumnID.Text = selectedColumn.templateColumnID;
            txtExportDefault.Text = selectedColumn.exportDefault;

            bool match = false;
            string colName = "";
            foreach (SpecialsOverrideColumns col in selectedTemplate.specialsOverrideColumns)
            {
                foreach (string s in col.overridesColumns)
                {
                    if (s == selectedColumn.databaseColumn)
                    {
                        match = true;
                        colName = col.baseColumn;
                    }
                }
            }

            if (match)
            {
                lblSpecialsOverrideColumn.Text = colName;
            }
            else
            {
                lblSpecialsOverrideColumn.Text = "NONE";
            }

            cbSpecialsExportColumn.Checked = selectedColumn.isSpecialsExportColumn;
            if (selectedColumn.isSpecialsExportColumn) { txtSpecialsCalculation.Text = selectedColumn.calculation; }

            cbKeepOriginalData.Checked = selectedColumn.keepOriginalData;

            pnlEditColumn.Visible = true;
        }
        private void clearColumnEditor()
        {
            pnlEditColumn.Show();
            cbColumnNames.SelectedIndex = 0;
            txtCSVHeader.Text = "";
            lblTemplateColumnID.Text = "#";
            pnlEditColumn.Visible = false;
            txtCalculation.Text = "";
            txtSpecialsCalculation.Text = "";
            cbIncludeAttributes.Checked = false;
            cbSpecialsExportColumn.Checked = showSpecialsExportColumns;
            pnlRegularOptions.Visible = !showSpecialsExportColumns;
            cbKeepOriginalData.Checked = true;

            if (showSpecialsExportColumns)
            {
                cbKeepOriginalData.Checked = false;
            }
        }

        private void loadTemplates()
        {
            cbTemplates.DataSource = null;

            if (cbSuppliers.Items.Count < 1) { return; }

            List<Templates> templates = tempMethods.getSupplierTemplates(cbSuppliers.SelectedValue.ToString(), "EXPORT", true);
            if (templates.Count <= 0)
            {
                pnlEditor.Hide();
                return;
            }

            bindingTemplates.DataSource = templates;
            cbTemplates.DataSource = bindingTemplates.DataSource;
            cbTemplates.DisplayMember = "templateName";
            cbTemplates.ValueMember = "templateID";
        }
        private void loadDBColumns()
        {
            DataTable dt = tempMethods.getDBColumns("stockItems", null);
            cbColumnNames.DataSource = dt;
            cbColumnNames.ValueMember = "COLUMN_NAME";
            cbColumnNames.DisplayMember = "COLUMN_NAME";
        }
        private void loadColumnsIntoGrid(Templates templateItem)
        {
            gvTemplates.DataSource = null;
            gvTemplates.Rows.Clear();
            gvTemplates.Columns.Clear();

            List<TemplateColumns> columnsToShow = new List<TemplateColumns>();
            //prepare the columns to show
            foreach (TemplateColumns tc in templateItem.templateColumns)
            {
                if (tc.isSpecialsExportColumn == showSpecialsExportColumns)
                {
                    columnsToShow.Add(tc);
                }
            }

            if (templateItem != null)
            {
                gvTemplates.AutoGenerateColumns = false;
                gvTemplates.DataSource = columnsToShow;

                DataGridViewTextBoxColumn col1 = new DataGridViewTextBoxColumn();
                col1.DataPropertyName = "csvHeader";
                col1.HeaderText = "CSV Header";
                col1.Name = "CSV Header";
                gvTemplates.Columns.Add(col1);

                DataGridViewTextBoxColumn col2 = new DataGridViewTextBoxColumn();
                col2.DataPropertyName = "databaseColumn";
                col2.HeaderText = "DB Column";
                col2.Name = "DB Column";
                gvTemplates.Columns.Add(col2);
            }

            gvTemplates.ClearSelection();

            //colour the rows that have special overrides active (only for regular columns)
            if (!showSpecialsExportColumns)
            {
                for (int i = 0; i < gvTemplates.Rows.Count; i++)
                {
                    foreach (SpecialsOverrideColumns tc in selectedTemplate.specialsOverrideColumns)
                    {
                        foreach (string s in tc.overridesColumns)
                        {
                            if (s == gvTemplates.Rows[i].Cells[1].Value.ToString())
                            {
                                gvTemplates.Rows[i].DefaultCellStyle.BackColor = Color.BlanchedAlmond;
                            }
                        }
                    }
                }
            }

            if (gvTemplates.Rows.Count < 1)
            {
                pnlEditColumn.Show();
            }
        }
        private void loadEditor()
        {
            if (!validateInputs(pnlSelect)) { return; }

            pnlMakeCopy.Visible = false;
            pnlEditor.Show();
            clearColumnEditor();
            loadColumnsIntoGrid(selectedTemplate);

            cbColumnNames.SelectedIndex = 0;
            txtCSVHeader.Text = "";
        }
        #endregion

        #region menus
        private void insertNewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnUpdate.Text = "Save";

            clearColumnEditor();

            pnlEditColumn.Visible = true;
        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnUpdate.Text = "Update";

            if (MessageBox.Show("Are you sure you wish to delete this mapping?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Stop) == System.Windows.Forms.DialogResult.Yes)
            {
                tempMethods.removeColumn(selectedTemplate, selectedColumn.templateColumnID);

                loadColumnsIntoGrid(selectedTemplate);

                clearColumnEditor();
            }
        }
        private void moveUpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            swopColumns(templateMethods.DIRECTION.UP);
        }

        private void moveDownToolStripMenuItem_Click(object sender, EventArgs e)
        {
            swopColumns(templateMethods.DIRECTION.DOWN);
        }
        #endregion

        private void cbSpecialsExportColumn_CheckedChanged(object sender, EventArgs e)
        {
            pnlRegularOptions.Visible = !cbSpecialsExportColumn.Checked;
        }

        bool showSpecialsExportColumns = false;
        private void showSpecialsExportColumnsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showSpecialsExportColumns = !showSpecialsExportColumns;
            loadColumnsIntoGrid(selectedTemplate);
            cbSpecialsExportColumn.Visible = showSpecialsExportColumns;
            cbSpecialsExportColumn.Checked = showSpecialsExportColumns;
            pnlSpecialsCalculation.Visible = showSpecialsExportColumns;
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmSpecialsCalculationEditor frmSpecials = new frmSpecialsCalculationEditor(this);
            frmSpecials.calculation = txtSpecialsCalculation.Text;
            frmSpecials.StartPosition = FormStartPosition.CenterParent;
            frmSpecials.ShowDialog(this);
        }
    }
}
