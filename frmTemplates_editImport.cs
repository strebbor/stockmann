using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Stockman.Entities;
using Stockman.Classes;
using System.Collections;
using System.Drawing;

namespace Stockman
{
    public partial class frmTemplates_editImport : FormBase
    {
        #region startup and shutdown
        public frmTemplates_editImport()
        {
            InitializeComponent();
        }
        private void frmTemplates_Load(object sender, EventArgs e)
        {
            loadDBColumns();

            //get suppliers
            DataTable dt = supMethods.getSuppliers();
            DataRow dr = dt.NewRow();
            dt.DefaultView.Sort = "supplierName";

            cbSuppliers.DataSource = dt;
            cbSuppliers.ValueMember = "supplierID";
            cbSuppliers.DisplayMember = "supplierName";

            cbCopyToSupplier.DataSource = dt.Copy();
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
        public string templateID { get; set; }
        public string supplierID { get; set; }
        frmDatabaseEditor frmDB;
        private int highlightColumn = -1;
        public bool refreshDBColumns
        {
            set
            {
                loadDBColumns();
            }
        }

        public string calculation
        {
            set
            {
                txtCalculation.Text = value;
            }
        }

        private Templates selectedTemplate { get; set; }
        private TemplateColumns selectedColumn { get; set; }
        int _selectedGridRow = -1;
        private int selectedGridRow
        {
            get
            { return _selectedGridRow; }
            set { _selectedGridRow = value; }
        }
        #endregion

        #region events
        private void button2_Click(object sender, EventArgs e)
        {
            if (!validateInputs(pnlEditColumn)) { return; }

            //can you apply dontOverride on this column
            if (!string.IsNullOrWhiteSpace(txtCalculation.Text) & cbDontOverride.Checked)
            {
                MessageBox.Show("Cannot apply dontOverride on a calculated column");
                cbDontOverride.Checked = false;
                return;
            }

            //can you copy this column (cannot copy column with calculation)
            if (cbCopyColumn.Checked & !string.IsNullOrEmpty(txtCalculation.Text))
            {
                MessageBox.Show("You cannot copy a column with a calculation");
                return;
            }

            //can you apply conditional formatting on this column
            if (cbFormatting.Text == "STRING" & cbApplyRounding.Checked)
            {
                MessageBox.Show("You can only apply rounding on decimal columns");
                cbApplyRounding.Checked = false;
                return;
            }

            //prepares the specials override columns
            string overrides = "";
            foreach (string s in cbSpecialsOverrideColumns.Items)
            {
                overrides += s + "#";
            }

            if (lblTemplateColumnID.Text != "#")
            {
                if (MessageBox.Show("Are you sure you wish to UPDATE this column?", "Update", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    //update column
                    if (!string.IsNullOrEmpty(txtCalculation.Text))
                    {
                        tempMethods.updateColumn(selectedTemplate, lblTemplateColumnID.Text, txtCSVHeader.Text, cbColumnNames.Text, cbFormatting.Text, txtCalculation.Text, cbApplyRounding.Checked, cbDontOverride.Checked, (cbCopyColumn.Checked ? templateMethods.ColumnCalculationEntities.COPY : templateMethods.ColumnCalculationEntities.CALCULATE), selectedColumn.position, null, true, overrides, txtSpecialPriceCSVHeader.Text, false, false);
                    }
                    else
                    {
                        tempMethods.updateColumn(selectedTemplate, lblTemplateColumnID.Text, txtCSVHeader.Text, cbColumnNames.Text, cbFormatting.Text, txtCalculation.Text, cbApplyRounding.Checked, cbDontOverride.Checked, (cbCopyColumn.Checked ? templateMethods.ColumnCalculationEntities.COPY : templateMethods.ColumnCalculationEntities.NONE), selectedColumn.position, null, true, overrides, txtSpecialPriceCSVHeader.Text, false, false);
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
                        if (!string.IsNullOrEmpty(txtCalculation.Text))
                        {
                            tempMethods.insertColumn(selectedTemplate, txtCSVHeader.Text, cbColumnNames.Text, cbFormatting.Text, txtCalculation.Text, cbApplyRounding.Checked, cbDontOverride.Checked, (cbCopyColumn.Checked ? templateMethods.ColumnCalculationEntities.COPY : templateMethods.ColumnCalculationEntities.CALCULATE), null, overrides, txtSpecialPriceCSVHeader.Text, false, false);
                        }
                        else
                        {
                            tempMethods.insertColumn(selectedTemplate, txtCSVHeader.Text, cbColumnNames.Text, cbFormatting.Text, txtCalculation.Text, cbApplyRounding.Checked, cbDontOverride.Checked, (cbCopyColumn.Checked ? templateMethods.ColumnCalculationEntities.COPY : templateMethods.ColumnCalculationEntities.NONE), null, overrides, txtSpecialPriceCSVHeader.Text, false, false);
                        }
                    }
                    catch (DuplicateNameException dup)
                    {
                        MessageBox.Show(dup.Message);
                        return;
                    }
                }
            }

            loadTemplates();
            clearColumnEditor();
            loadColumnsIntoGrid(selectedTemplate);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            tempMethods.copyTemplate(cbTemplates.SelectedValue.ToString(), cbCopyToSupplier.SelectedValue.ToString());
            pnlMakeCopy.Hide();
            loadTemplates();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            pnlMakeCopy.Hide();
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

        private void cbSuppliers_SelectionChangeCommitted(object sender, EventArgs e)
        {
            loadTemplates();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //does the template have a product code link            
            if (!selectedTemplate.containsDbColumn("productCode") && gvTemplates.Rows.Count > 0)
            {
                if (MessageBox.Show("No PRODUCTCODE link found.  If you are sure you want to continue, press OK", "Warning", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                {
                    return;
                }
            }

            txtCSVHeader.Text = "";
            cbColumnNames.SelectedIndex = 0;

            pnlEditor.Visible = false;
            pnlSelect.Enabled = true;
        }

        private void cbTemplates_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedTemplate = (Templates)cbTemplates.SelectedItem;
        }

        private void gvTemplates_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) { return; }

            selectedColumn = (TemplateColumns)gvTemplates.Rows[e.RowIndex].DataBoundItem;
            loadColumnDetails(e.RowIndex);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (!validateInputs(pnlSelect))
            {
                return;
            }

            loadEditor();

            pnlSelect.Enabled = false;
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

            if (gvTemplates.Rows.Count > 0)
            {
                loadColumnDetails(hit.RowIndex);
                btnUpdate.Text = "Update";
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (!validateInputs(pnlSelect))
            {
                return;
            }

            if (MessageBox.Show("Are you sure you wish to delete the whole template?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Stop) == System.Windows.Forms.DialogResult.Yes)
            {
                tempMethods.removeTemplate(selectedTemplate);
                loadTemplates();
                pnlMakeCopy.Visible = false;
                clearColumnEditor();
                pnlEditor.Visible = false;
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

        private void button8_Click(object sender, EventArgs e)
        {
            txtDBColumnName.CausesValidation = true;
            cbColumnType.CausesValidation = true;

            if (!validateInputs(panel1)) { return; }

            columnTypes selectedType = columnTypes.STRING;
            switch (cbColumnType.Text)
            {
                case "DECIMAL 0.00": { selectedType = columnTypes.DECIMAL_18_2; } break;
                case "DECIMAL 0.000": { selectedType = columnTypes.DECIMAL_18_3; } break;
                case "DECIMAL 0.0000": { selectedType = columnTypes.DECIMAL_18_4; } break;
                case "DECIMAL 0.00000": { selectedType = columnTypes.DECIMAL_18_5; } break;
            }

            tempMethods.createDBColumn(txtDBColumnName.Text, selectedType);
            cbColumnNames.SelectedValue = txtDBColumnName.Text;
            txtDBColumnName.Text = "";
            loadDBColumns();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            resetValidations(panel1);
            txtDBColumnName.Text = "";
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmCalculationEditor frmCal = new frmCalculationEditor(this);
            frmCal.calculation = txtCalculation.Text;
            frmCal.selectedTemplate = selectedTemplate;
            if (!string.IsNullOrWhiteSpace(cbColumnNames.Text))
            {
                frmCal.databaseColumnName = cbColumnNames.Text;
            }
            frmCal.StartPosition = FormStartPosition.CenterParent;
            frmCal.ShowDialog(this);
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (lblTemplateColumnID.Text == "#")
            {
                MessageBox.Show("Please select a column"); return;
            }

            frmConditionalFormattingEditor frmCal = new frmConditionalFormattingEditor(this);
            frmCal.selectedColumn = selectedColumn;
            frmCal.StartPosition = FormStartPosition.CenterParent;
            frmCal.ShowDialog(this);
        }
        private void gvTemplates_KeyDown(object sender, KeyEventArgs e)
        {
            /*  if (e.Alt && e.KeyCode == Keys.Up)
              {
                  swopColumns(templateMethods.DIRECTION.UP);
              }
              if (e.Alt && e.KeyCode == Keys.Down)
              {
                  swopColumns(templateMethods.DIRECTION.DOWN);
              }*/
            // FUTURE - add keys up and down for highlight columns
        }

        private void gvTemplates_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            selectedColumn = (TemplateColumns)gvTemplates.Rows[e.RowIndex].DataBoundItem;
            loadColumnDetails(e.RowIndex);

            btnUpdate.Text = "Update";
        }
        private void cbFormatting_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //can you apply conditional formatting on this column
            if (cbFormatting.SelectedItem.ToString() == "STRING" & cbApplyRounding.Checked)
            {
                MessageBox.Show("You can only apply rounding on decimal columns");
                cbApplyRounding.Checked = false;
                return;
            }
        }

        private void cbDontOverride_CheckedChanged(object sender, EventArgs e)
        {
            if (cbDontOverride.Checked)
            {
                if (!string.IsNullOrWhiteSpace(txtCalculation.Text))
                {
                    MessageBox.Show("Cannot apply dontOverride on a calculated column");
                    cbDontOverride.Checked = false;
                    return;
                }
            }
        }

        private void cbApplyRounding_CheckedChanged(object sender, EventArgs e)
        {
            if (cbApplyRounding.Checked)
            {
                if (cbFormatting.Text.ToString() == "STRING")
                {
                    MessageBox.Show("You can only apply rounding to decimal columns");
                    cbApplyRounding.Checked = false;
                    return;
                }
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            resetValidations(panel1);

            frmDB = new frmDatabaseEditor(this);
            frmDB.Show();
        }
        private void moveUpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            swopColumns(templateMethods.DIRECTION.UP);
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
            btnUpdate.Text = "Update";
            int selectedRow = rowIndex;
            txtCSVHeader.Text = selectedColumn.csvHeader;
            cbColumnNames.SelectedValue = selectedColumn.databaseColumn;
            string selectedFormatting = "STRING";
            switch (selectedColumn.columnType.ToString())
            {
                case "DECIMAL_18_2": { selectedFormatting = "DECIMAL 0.00"; } break;
                case "DECIMAL_18_3": { selectedFormatting = "DECIMAL 0.000"; } break;
                case "DECIMAL_18_4": { selectedFormatting = "DECIMAL 0.0000"; } break;
                case "DECIMAL_18_5": { selectedFormatting = "DECIMAL 0.00000"; } break;

            }

            cbFormatting.SelectedIndex = cbFormatting.FindStringExact(selectedFormatting);
            lblTemplateColumnID.Text = selectedColumn.templateColumnID;
            txtCalculation.Text = selectedColumn.calculation;
            cbApplyRounding.Checked = selectedColumn.applyRounding;
            cbDontOverride.Checked = selectedColumn.dontOverride;
            txtSpecialPriceCSVHeader.Text = selectedColumn.specialsBasePriceCSVColumn;

            //load the specials overrides
            cbSpecialsOverrideColumns.Items.Clear();
            pnlDelSpecialsOverride.Visible = false;
            foreach (SpecialsOverrideColumns tc in selectedTemplate.specialsOverrideColumns)
            {
                if (selectedColumn.databaseColumn == tc.baseColumn)
                {
                    foreach (string s in tc.overridesColumns)
                    {
                        if (!string.IsNullOrWhiteSpace(s))
                        {
                            cbSpecialsOverrideColumns.Items.Add(s);
                            pnlDelSpecialsOverride.Visible = true;
                        }
                    }
                }
            }

            if (selectedColumn.calculationType == columnCalculationType.COPY)
            {
                cbCopyColumn.Checked = true;
            }
            else
            {
                cbCopyColumn.Checked = false;
            }

            cbSpecialsOverride.Text = "";
            cbSpecialsOverrideColumns.Text = "";

            pnlEditColumn.Visible = true;
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

        private void loadTemplates()
        {
            object selectedTemplateID = cbTemplates.SelectedValue;

            cbTemplates.DataSource = null;

            if (cbSuppliers.Items.Count < 1) { return; }

            List<Templates> templates = tempMethods.getSupplierTemplates(cbSuppliers.SelectedValue.ToString(), "IMPORT", false);
            if (templates.Count <= 0)
            {
                pnlEditor.Hide();
                return;
            }

            bindingTemplates.DataSource = templates;
            cbTemplates.DataSource = bindingTemplates.DataSource;
            cbTemplates.DisplayMember = "templateName";
            cbTemplates.ValueMember = "templateID";

            //reset the selected template if one was selected
            if (selectedTemplateID != null)
            {
                cbTemplates.SelectedValue = selectedTemplateID;
            }
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

            cbColumnNames.DataSource = dt;
            cbColumnNames.ValueMember = "COLUMN_NAME";
            cbColumnNames.DisplayMember = "COLUMN_NAME";

            cbSpecialsOverride.DataSource = dt.Copy();
            cbSpecialsOverride.ValueMember = "COLUMN_NAME";
            cbSpecialsOverride.DisplayMember = "COLUMN_NAME";
        }

        private void loadColumnsIntoGrid(Templates templateItem)
        {
            gvTemplates.DataSource = null;
            gvTemplates.Rows.Clear();
            gvTemplates.Columns.Clear();

            if (templateItem != null)
            {
                gvTemplates.AutoGenerateColumns = false;
                gvTemplates.DataSource = templateItem.templateColumns;

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

            //colour the rows that have special overrides active
            for (int i = 0; i < gvTemplates.Rows.Count; i++)
            {
                foreach (SpecialsOverrideColumns tc in selectedTemplate.specialsOverrideColumns)
                {
                    if (gvTemplates.Rows[i].Cells[1].Value.ToString() == tc.baseColumn)
                    {
                        gvTemplates.Rows[i].DefaultCellStyle.BackColor = Color.BlanchedAlmond;
                    }
                }
            }

            if (gvTemplates.Rows.Count < 1)
            {
                pnlEditColumn.Show();
            }
        }

        private void clearColumnEditor()
        {
            pnlEditColumn.Show();
            cbColumnNames.SelectedIndex = 0;
            cbFormatting.SelectedIndex = 0;
            txtCSVHeader.Text = "";
            lblTemplateColumnID.Text = "#";
            txtCalculation.Text = "";
            pnlEditColumn.Visible = false;
            cbApplyRounding.Checked = false;
            txtSpecialPriceCSVHeader.Text = ""; ;
        }
        #endregion

        #region menus
        private void insertNewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gvTemplates.ClearSelection();

            clearColumnEditor();

            pnlEditColumn.Visible = true;

            btnUpdate.Text = "Save";
        }
        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnUpdate.Text = "Update";

            if (MessageBox.Show("Are you sure you wish to delete this mapping?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Stop) == System.Windows.Forms.DialogResult.Yes)
            {
                tempMethods.removeColumn(selectedTemplate, selectedColumn.templateColumnID);

                clearColumnEditor();
                pnlEditColumn.Visible = false;

                loadColumnsIntoGrid(selectedTemplate);
            }
        }
        private void moveDownToolStripMenuItem_Click(object sender, EventArgs e)
        {
            swopColumns(templateMethods.DIRECTION.DOWN);
        }
        #endregion

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (cbSpecialsOverrideColumns.FindString(cbSpecialsOverride.Text) < 0)
            {
                cbSpecialsOverrideColumns.Items.Add(cbSpecialsOverride.Text);
            }

            cbSpecialsOverride.Text = "";

            pnlDelSpecialsOverride.Visible = cbSpecialsOverrideColumns.Items.Count > 0;
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (MessageBox.Show("Are you sure you wish to delete this item?", "Confirmation", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                cbSpecialsOverrideColumns.Items.Remove(cbSpecialsOverrideColumns.Text);
                cbSpecialsOverrideColumns.Text = "";
            }
        }
    }
}
