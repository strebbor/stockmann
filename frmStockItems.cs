using System;
using System.Data;
using System.Windows.Forms;
using Stockman.Classes;
using System.Collections;
using Stockman.Entities;
using System.Linq;
using System.Drawing;
using System.Collections.Generic;

namespace Stockman
{
    public partial class frmStockItems : FormBase
    {
        #region startup and initialize
        public frmStockItems()
        {
            InitializeComponent();
            loadSuppliers();
            loadAttributes();

            //temporary hidding fields
            checkBox2.Visible = false;
        }
        #endregion

        #region initialize classes
        supplierMethods supMethods = new supplierMethods();
        stockItemMethods stockMethods = new stockItemMethods();
        supplierMethods supplierMethods = new supplierMethods();
        attributeMethods attrMethods = new attributeMethods();
        templateMethods tempMethods = new templateMethods();
        #endregion

        #region properties
        Supplier selectedSupplier = new Supplier();
        DataTable dtStockItems = new DataTable();
        DataTable dtDetails = new DataTable();
        string tempValue { get; set; }
        const int startOfDetailColumns = 13;
        int selectedColumnIndex = -1;
        int selectedRowIndex = -1;
        #endregion

        #region events
        private void dgvItems_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            DataRowView dv = (DataRowView)dgvItems.Rows[e.RowIndex].DataBoundItem;
            DataRow row = dv.Row;

            tempValue = dgvItems.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();

            bindDetails(row);
        }

        private void dgvItems_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string productCode = dgvItems.Rows[e.RowIndex].Cells["code"].Value.ToString();

                for (int i = 0; i < dtStockItems.Rows.Count; i++)
                {
                    if (dtStockItems.Rows[i]["productCode"].ToString() == productCode)
                    {
                        string workingColumnDataProperty = dgvItems.Columns[e.ColumnIndex].DataPropertyName;
                        string workingColumnHeader = dgvItems.Columns[e.ColumnIndex].Name;

                        dtStockItems.Rows[i][workingColumnDataProperty] = dgvItems.Rows[e.RowIndex].Cells[workingColumnHeader].Value.ToString();
                        //recalc skuCode if applicable
                        string columnValue = dgvItems.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().ToUpper();
                        if (dgvItems.Columns[workingColumnHeader].Name.ToUpper().Replace(" ", "") == "NAME")
                        {
                            if (columnValue.Length < 4)
                            {
                                dgvItems.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = tempValue;
                                MessageBox.Show("Product name must be at least 3 characters long to auto generate SKUCode");
                                return;
                            }
                            //generate new short code
                            string newShort = columnValue.Replace(" ", "").Substring(0, 3);
                            dtStockItems.Rows[i]["shortCode"] = newShort;

                            string newSKUCode = stockMethods.generateSKUCode(dtStockItems.Rows[i], selectedSupplier);
                            dtStockItems.Rows[i]["skucode"] = newSKUCode;
                        }

                        break;
                    }
                }
            }
            catch (Exception ee2)
            {
                //ignore, possibly calculated fields
            }

            dgvItems.DataSource = dtStockItems;
            if (!string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                filterOnSearch();
            }
        }

        private void cbSuppliers_SelectionChangeCommitted(object sender, EventArgs e)
        {
            selectedSupplier = supplierMethods.getSupplier(cbSuppliers.SelectedValue.ToString());
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            clearAttributeSet();

            selectedSupplier = supplierMethods.getSupplier(cbSuppliers.SelectedValue.ToString());

            loadStockItemsBase();
            dgvDetails.DataSource = null;

            changeMiniMaxiColumnView(false);

            setFormTitleWithStockItemsCount();
        }

        private void setFormTitleWithStockItemsCount()
        {
            this.Text = "Manage Stock Items (" + dgvItems.Rows.Count.ToString() + " items in current view)";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            loadStockItemsBase();
        }

        private void dgvItems_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0) { return; }

                DataRowView dv = (DataRowView)dgvItems.Rows[e.RowIndex].DataBoundItem;
                DataRow row = dv.Row;

                tempValue = dgvItems.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();

                bindDetails(row);
            }
            catch (Exception ee)
            {
                //do nothing, this is most likely a header or so
            }
        }

        private void dgvDetails_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //send the change back to the main datatable
            string productCode = dgvDetails.Rows[0].Cells["productCode"].Value.ToString();

            for (int i = 0; i < dtStockItems.Rows.Count; i++)
            {
                if (dtStockItems.Rows[i]["productCode"].ToString() == productCode)
                {
                    foreach (DataColumn dc in dtDetails.Columns)
                    {
                        try
                        {
                            dtStockItems.Rows[i][dc.ColumnName] = dgvDetails.Rows[e.RowIndex].Cells[dc.ColumnName].Value.ToString();
                        }
                        catch (Exception ee)
                        {
                            //ignore, possibly calculated fields
                        }
                    }
                }
            }

            dgvItems.DataSource = dtStockItems;
            if (!string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                filterOnSearch();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dtStockItems.Columns.Remove("stockID");
            stockMethods.updateAllStockItems(selectedSupplier, dtStockItems);

            MessageBox.Show("All items updated");

            loadStockItemsBase();
            dgvDetails.DataSource = null;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            doSearch();
        }

        private void doSearch()
        {
            filterOnSearch();
            dgvDetails.DataSource = null;

            setFormTitleWithStockItemsCount();
        }

        private void dgvItems_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show(e.Exception.Message);
        }

        private void dgvDetails_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                tempValue = dgvDetails.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            }
            catch (Exception ee)
            {
                //do nothing, most likely a header click
            }
        }
        private void dgvItems_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (MessageBox.Show("Are you sure you wish to delete this row?  This action CANNOT be undone", "Delete row", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                string deleteProductCode = e.Row.Cells[0].Value.ToString();

                var l = dtStockItems.AsEnumerable().Where(dr => dr.Field<string>("productCode") == deleteProductCode).First();

                //prep the new row
                DataRow row = dtStockItems.NewRow();
                row = (DataRow)l;

                //delete this row out of the db
                stockMethods.deleteStockItem(row, selectedSupplier);
            }
        }

        private void dgvItems_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            dtStockItems.AcceptChanges();
        }
        #endregion

        #region methods
        private void loadAttributes()
        {
            ArrayList attrNames = attrMethods.getAttributeNames();
            foreach (string name in attrNames)
            {
                selectToolStripMenuItem.DropDownItems.Add(name);
            }

            DataTable dt = tempMethods.getDBColumns("stockItems", null);

            //adds a blank row
            DataRow dr = dt.NewRow();
            dt.Rows.InsertAt(dr, 0);

            cbColumnNames.DataSource = dt;
            cbColumnNames.ValueMember = "COLUMN_NAME";
            cbColumnNames.DisplayMember = "COLUMN_NAME";

        }

        private void loadSuppliers()
        {
            //get suppliers
            DataTable dt = supMethods.getSuppliers();
            DataRow dr = dt.NewRow();
            dt.DefaultView.Sort = "supplierName";

            cbSuppliers.DataSource = dt;
            cbSuppliers.ValueMember = "supplierID";
            cbSuppliers.DisplayMember = "supplierName";
        }

        private void loadStockItemsBase()
        {
            dgvItems.DataSource = null;
            dgvItems.Rows.Clear();
            dgvItems.Columns.Clear();

            dgvItems.AutoGenerateColumns = false;
            dtStockItems = stockMethods.getAllStockItems(selectedSupplier);

            dgvItems.DataSource = dtStockItems;

            DataGridViewTextBoxColumn col1 = new DataGridViewTextBoxColumn();
            col1.DataPropertyName = "productCode";
            col1.HeaderText = "Code";
            col1.ReadOnly = true;
            col1.Name = "Code";
            dgvItems.Columns.Add(col1);

            DataGridViewTextBoxColumn col194 = new DataGridViewTextBoxColumn();
            col194.DataPropertyName = "skuCode";
            col194.HeaderText = "SKUCode";
            col194.ReadOnly = true;
            col194.Name = "SKUCode";
            dgvItems.Columns.Add(col194);

            DataGridViewTextBoxColumn col2 = new DataGridViewTextBoxColumn();
            col2.DataPropertyName = "productName";
            col2.HeaderText = "Name";
            col2.Name = "Name";
            dgvItems.Columns.Add(col2);

            DataGridViewTextBoxColumn col3 = new DataGridViewTextBoxColumn();
            col3.DataPropertyName = "uniqueKey";
            col3.HeaderText = "UNI";
            col3.ReadOnly = true;
            col3.Name = "Uni";
            dgvItems.Columns.Add(col3);

            DataGridViewTextBoxColumn col9 = new DataGridViewTextBoxColumn();
            col9.DataPropertyName = "shortCode";
            col9.HeaderText = "Short Code";
            col9.ReadOnly = true;
            col9.Name = "Short Code";
            dgvItems.Columns.Add(col9);

            DataGridViewTextBoxColumn col4 = new DataGridViewTextBoxColumn();
            col4.DataPropertyName = "productBasePrice";
            col4.HeaderText = "Base Price";
            col4.Name = "Base Price";
            dgvItems.Columns.Add(col4);

            DataGridViewTextBoxColumn col7 = new DataGridViewTextBoxColumn();
            col7.DataPropertyName = "d_agencyMargin";
            col7.HeaderText = "D_Agency Margin";
            col7.Name = "D_Agency Margin";
            dgvItems.Columns.Add(col7);

            DataGridViewTextBoxColumn col8 = new DataGridViewTextBoxColumn();
            col8.DataPropertyName = "d_grossMargin";
            col8.HeaderText = "D_Gross Margin";
            col8.Name = "D_Gross Margin";
            dgvItems.Columns.Add(col8);

            DataGridViewTextBoxColumn col19 = new DataGridViewTextBoxColumn();
            col19.DataPropertyName = "d_discount";
            col19.HeaderText = "D_Discount";
            col19.Name = "D_Discount";
            dgvItems.Columns.Add(col19);

            DataGridViewCheckBoxCell col5 = new DataGridViewCheckBoxCell();
            DataGridViewColumn dc = new DataGridViewColumn(col5);
            dc.DataPropertyName = "overrideMargins";
            dc.HeaderText = "Override Margins";
            dc.Name = "Override Margins";
            dc.Width = 50;
            dgvItems.Columns.Add(dc);

            DataGridViewCheckBoxCell col6 = new DataGridViewCheckBoxCell();
            DataGridViewColumn dc2 = new DataGridViewColumn(col6);
            dc2.DataPropertyName = "mustExport";
            dc2.HeaderText = "Export";
            dc2.Name = "Export";
            dc2.Width = 50;
            dgvItems.Columns.Add(dc2);

            DataGridViewTextBoxColumn col119 = new DataGridViewTextBoxColumn();
            col119.DataPropertyName = "lastUpdate";
            col119.HeaderText = "Last Update";
            col119.Name = "Last Update";
            col119.ReadOnly = true;
            dgvItems.Columns.Add(col119);

            DataGridViewTextBoxColumn col28 = new DataGridViewTextBoxColumn();
            col28.DataPropertyName = "active";
            col28.HeaderText = "A";
            col28.Name = "A";
            col28.Width = 20;
            dgvItems.Columns.Add(col28);

            //adds the detail columns
            ArrayList detailColumns = getBaseColumns();
            detailColumns.Add("productCode"); //dont show product code twice

            foreach (DataColumn dataCol in dtStockItems.Columns)
            {
                if (!detailColumns.Contains(dataCol.ColumnName))
                {
                    string dataProperty = dataCol.ColumnName;
                    DataGridViewTextBoxColumn detailColumn = new DataGridViewTextBoxColumn();
                    detailColumn.DataPropertyName = dataProperty;
                    detailColumn.HeaderText = dataProperty;
                    detailColumn.Name = dataProperty;
                    detailColumn.Visible = false;
                    dgvItems.Columns.Add(detailColumn);
                }
            }

            dgvItems.ClearSelection();

            //assign the column order if available
            ArrayList columnOrder = stockMethods.getColumnOrder(selectedSupplier);
            foreach (Hashtable hash in columnOrder)
            {
                for (int i = 0; i < dgvItems.Columns.Count; i++)
                {
                    if (dgvItems.Columns[i].DataPropertyName == hash["property"].ToString())
                    {
                        dgvItems.Columns[i].DisplayIndex = int.Parse(hash["index"].ToString());
                        if (hash["visible"] != null)
                        {
                            dgvItems.Columns[i].Visible = bool.Parse(hash["visible"].ToString());
                        }
                    }
                }
            }
        }

        private ArrayList getBaseColumns()
        {
            ArrayList detailColumns = stockMetaColumns;
            detailColumns.Add("productBasePrice");
            detailColumns.Add("d_agencyMargin");
            detailColumns.Add("d_grossMargin");
            detailColumns.Add("d_discount");
            detailColumns.Add("lastUpdate");
            detailColumns.Add("shortCode");
            detailColumns.Add("productName");
            detailColumns.Add("skuCode");

            return detailColumns;
        }

        private void bindDetails(DataRow row)
        {
            //remove base columns
            ArrayList colsToRemove = getBaseColumns();
            dtDetails = dtStockItems.Copy();
            dtDetails.Clear();

            if (showSpecials)
            {
                //find the row in the datagridview
                foreach (DataRow dr in dtSpecialsData.Rows)
                {
                    if (dr["productCode"].ToString() == row["productCode"].ToString())
                    {
                        row = dr;
                    }
                }
            }
           
            dtDetails.ImportRow(row);
            dgvDetails.DataSource = dtDetails;

            foreach (DataColumn dc in dtDetails.Columns)
            {
                if (colsToRemove.Contains(dc.ColumnName))
                {
                    dgvDetails.Columns[dc.ColumnName].Visible = false;
                }
            }

            //does special formatting where applicable
            //foreach (DataRow dr in dtDetails.Rows)
            //{
            //    string lastUpdated = dr["lastUpdate"].ToString();
            //    DateTime lu = DateTime.Parse(lastUpdated);

            //    string newluDate = lu.Day + "/" + lu.Month + "/" + lu.Year + " " + lu.TimeOfDay;
            //    dr["lastUpdate"] = newluDate;
            //}
        }

        private void filterOnSearch()
        {
            DataTable dtResults = dtStockItems.Copy();
            dtResults.Clear();

            //if (cbSearchAll.Checked)
            //{
            //    //load all the stock items into the stock view, and then search through them
            //    dtStockItems = stockMethods.getAllStockItems();
            //}
            //else
            //{
            //    //load only the stock items for this supplier
            //    dtStockItems = stockMethods.getAllStockItems(selectedSupplier);
            //    dgvItems.DataSource = dtStockItems;
            //}

            for (int i = 0; i < dtStockItems.Rows.Count; i++)
            {
                bool match = false;
                foreach (DataColumn dc in dtStockItems.Columns)
                {
                    if (!match)
                    {
                        string value = dtStockItems.Rows[i][dc.ColumnName].ToString();
                        if (value.ToUpper().Contains(txtSearch.Text.ToUpper()))
                        {
                            dtResults.ImportRow(dtStockItems.Rows[i]);
                            match = true;
                        }
                    }
                }
            }

            dgvItems.DataSource = dtResults;
        }

        private void showHideGVColumns(string criteria)
        {
            foreach (DataGridViewRow row in dgvItems.Rows)
            {
                dgvItems.CurrentCell = null;
                row.Visible = false;

                dtDetails.Clear();

                if (criteria == "ALL")
                {
                    row.Visible = true;
                }
                else
                {
                    if (row.Cells["A"].Value.ToString() == criteria)
                    {
                        row.Visible = true;
                    }
                }
            }
        }

        private void changeMiniMaxiColumnView(bool showMaxi)
        {
            if (showMaxi)
            {
                for (int i = startOfDetailColumns; i < dgvItems.Columns.Count; i++)
                {
                    dgvItems.Columns[i].Visible = true;
                }
            }
            else
            {
                for (int i = startOfDetailColumns; i < dgvItems.Columns.Count; i++)
                {
                    dgvItems.Columns[i].Visible = false;
                }
            }
        }
        #endregion

        #region menus
        private void showActiveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showHideGVColumns("1");
        }

        private void showInactiveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showHideGVColumns("0");
        }

        private void showAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showHideGVColumns("ALL");
        }
        #endregion

        private void btnSaveColumnOrder_Click(object sender, EventArgs e)
        {
            //remove the row numbers column, otherwise all the counts are out            
            for (int i = 0; i < dgvItems.Columns.Count; i++)
            {
                if (dgvItems.Columns[i].Name == "number")
                {
                    dgvItems.Columns.RemoveAt(i);
                }
            }

            ArrayList newColumnOrder = new ArrayList();

            foreach (DataGridViewColumn col in dgvItems.Columns)
            {
                Hashtable newOrder = new Hashtable();
                newOrder.Add("index", col.DisplayIndex.ToString());
                newOrder.Add("property", col.DataPropertyName);
                newOrder.Add("visible", col.Visible);
                newColumnOrder.Add(newOrder);
            }

            try
            {
                stockMethods.updateColumnOrder(selectedSupplier, newColumnOrder);
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
                return;
            }

            MessageBox.Show("Column order successfully updated");
        }

        private void dgvItems_MouseDown(object sender, MouseEventArgs e)
        {
            DataGridView.HitTestInfo hit = dgvItems.HitTest(e.X, e.Y);

            if (e.Button == MouseButtons.Right)
            {
                switch (hit.Type)
                {
                    case DataGridViewHitTestType.ColumnHeader:
                        {
                            selectedColumnIndex = hit.ColumnIndex;
                            contextMenuColumn.Show(dgvItems, e.X, e.Y);
                        } break;
                    case DataGridViewHitTestType.Cell:
                        {
                            dgvItems.ClearSelection();
                            dgvItems.Rows[hit.RowIndex].Cells[hit.ColumnIndex].Selected = true;
                            selectedRowIndex = hit.RowIndex;
                            contextMenuRow.Show(dgvItems, e.X, e.Y);
                        } break;
                    case DataGridViewHitTestType.TopLeftHeader:
                        {
                            contextMenuAll.Show(dgvItems, e.X, e.Y);
                        } break;
                }

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvItems.Columns.Count; i++)
            {
                dgvItems.Columns[i].Visible = true;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBox2.Checked)
            {
                pnlTop.Height = 181;
                pnlItems.Location = new System.Drawing.Point(0, 185);
                pnlItems.Height = pnlItems.Height - 200;
            }
            else
            {
                pnlTop.Height = 22;
                pnlItems.Location = new System.Drawing.Point(0, 22);
                pnlItems.Height = pnlItems.Height + 170;
            }
        }

        private void frmStockItems_SizeChanged(object sender, EventArgs e)
        {
            pnlBottom.Width = this.Width;
            pnlItems.Width = this.Width - 16;
            pnlItems.Height = this.Height - 270;
        }

        private void hideColumnToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            if (selectedColumnIndex != -1)
            {
                dgvItems.Columns[selectedColumnIndex].Visible = false;
            }
        }

        private void setParentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //remove the current colouring
            foreach (DataGridViewRow row in dgvItems.Rows)
            {
                row.DefaultCellStyle.BackColor = Color.White;
            }

            AttributePropertyParent newParent = new AttributePropertyParent();

            newParent.attributeSetName = lblAttributeSet.Text;
            newParent.stockCode = dgvItems.Rows[selectedRowIndex].Cells["code"].Value.ToString();
            newParent.propertyName = InputBox.ShowDialog("Property Name", "Property Name", newParent.propertyName);
            newParent.skuCode = dgvItems.Rows[selectedRowIndex].Cells["skuCode"].Value.ToString();
            newParent.basePriceColumn = cbColumnNames.Text;

            fullAttributeSets.Add(newParent);

            lblParentStockCode.Text = newParent.stockCode;
            selectedAttributeSet = newParent;
            dgvItems.Rows[selectedRowIndex].DefaultCellStyle.BackColor = Color.SkyBlue;
        }

        public int childPositionCounter = 1;
        private void createChildToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string childSKU = dgvItems.Rows[selectedRowIndex].Cells["code"].Value.ToString();
            selectedAttributeSet = findParentAttribute(lblParentStockCode.Text);
            if (childSKU == selectedAttributeSet.stockCode)
            {
                MessageBox.Show("Invalid link:  Child and Parent cannot be the same");
                return;
            }

            AttributeProperty prop = new AttributeProperty();
            prop.stockCode = childSKU;
            prop.skuCode = dgvItems.Rows[selectedRowIndex].Cells["SKUCode"].Value.ToString();

            dgvItems.Rows[selectedRowIndex].DefaultCellStyle.BackColor = Color.Aquamarine;

            prop.propertyName = InputBox.ShowDialog("Property Name", "Property Name", prop.propertyName);
            if (prop.position == 0) { prop.position = childPositionCounter; }

            string positionTemp = InputBox.ShowDialog("Property Position", "Property Position", prop.position.ToString());
            if (positionTemp == null)
            {
                positionTemp = (childPositionCounter + 1).ToString();
            }

            prop.position = int.Parse(positionTemp);


            if (selectedAttributeSet.childrenProperties == null) { selectedAttributeSet.childrenProperties = new List<AttributeProperty>(); }
            selectedAttributeSet.childrenProperties.Add(prop);
            childPositionCounter++;
        }

        private void removeChildToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            selectedAttributeSet = findParentAttribute(lblParentStockCode.Text);

            if (selectedAttributeSet == null)
            {
                MessageBox.Show("Please select a parent first");
                return;
            }

            string sku = dgvItems.Rows[selectedRowIndex].Cells["code"].Value.ToString();

            if (sku == selectedAttributeSet.stockCode)
            {
                //this is a parent - get confirmation as this action is destructive
                if (MessageBox.Show("Are you sure you wish to delete this parent and all child properties?  This action cannot be undone", "Confirmation", MessageBoxButtons.YesNo) != System.Windows.Forms.DialogResult.Yes)
                {
                    return;
                }

                try
                {
                    attrMethods.deleteFullAttributeSet(selectedAttributeSet);
                }
                catch (Exception ee)
                {
                    MessageBox.Show(ee.Message);
                    return;
                }

                //clears the currently highlighted children
                foreach (AttributeProperty props in selectedAttributeSet.childrenProperties)
                {
                    foreach (DataGridViewRow row in dgvItems.Rows)
                    {
                        if ((row.Cells["code"].Value.ToString() == props.stockCode && row.DefaultCellStyle.BackColor == Color.Aquamarine) || row.Cells["code"].Value.ToString() == selectedAttributeSet.stockCode)
                        {
                            row.DefaultCellStyle.BackColor = Color.White;
                        }
                    }
                }

                //remove the parent out of the collection
                fullAttributeSets.Remove(selectedAttributeSet);
                selectedAttributeSet = new AttributePropertyParent();
            }
            else
            {
                //this is a parent - get confirmation as this action is destructive
                if (MessageBox.Show("Are you sure you wish to delete this child properties?  This action cannot be undone", "Confirmation", MessageBoxButtons.YesNo) != System.Windows.Forms.DialogResult.Yes)
                {
                    return;
                }

                AttributeProperty childProperty = findChildAttribute(sku);
                selectedAttributeSet.childrenProperties.Remove(childProperty);
                if (childProperty.propertyID != null)
                {
                    attrMethods.deleteChildProperties(childProperty);
                }
                dgvItems.Rows[selectedRowIndex].DefaultCellStyle.BackColor = Color.White;
            }
        }

        private void createToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clearAttributeSet();

            string input = InputBox.ShowDialog("Enter attribute name", "Create Attribute");

            if (!string.IsNullOrWhiteSpace(input))
            {
                //save to the database
                try
                {
                    attrMethods.createAttribute(input);
                }
                catch (Exception ee)
                {
                    MessageBox.Show("Unable to create attribute: " + ee.Message);
                    return;
                }
            }

            lblAttributeSet.Text = input;
            pnlAttributeSetEditor.Visible = true;

            selectToolStripMenuItem.DropDownItems.Add(input);

            //clears the currently highlighted items
            foreach (DataGridViewRow row in dgvItems.Rows)
            {
                row.DefaultCellStyle.BackColor = Color.White;
            }
        }

        AttributePropertyParent selectedAttributeSet = new AttributePropertyParent();

        List<AttributePropertyParent> fullAttributeSets = new List<AttributePropertyParent>();
        private void selectToolStripMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            clearAttributeSet();

            lblAttributeSet.Text = e.ClickedItem.Text;

            //display the parents
            fullAttributeSets = attrMethods.getFullAttributeSet(selectedSupplier, lblAttributeSet.Text);
            if (fullAttributeSets != null)
            {
                foreach (AttributePropertyParent parent in fullAttributeSets)
                {
                    foreach (DataGridViewRow row in dgvItems.Rows)
                    {
                        if (row.Cells["code"].Value.ToString() == parent.stockCode)
                        {
                            row.DefaultCellStyle.BackColor = Color.SkyBlue;
                        }
                    }
                }
            }

            pnlAttributeSetEditor.Visible = true;
        }

        private void cancelAttributeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clearAttributeSet();
        }

        private void clearAttributeSet()
        {
            lblAttributeSet.Text = "No set selected";
            pnlAttributeSetEditor.Visible = false;
            lblParentStockCode.Text = "";

            fullAttributeSets = new List<AttributePropertyParent>();

            foreach (DataGridViewRow row in dgvItems.Rows)
            {
                row.DefaultCellStyle.BackColor = Color.White;
            }
        }
        private bool saveAttributeSets()
        {
            //ensure that all required items are present
            if (fullAttributeSets.Count < 1)
            {
                MessageBox.Show("Please ensure that a Base price column, Parent, Children and Attribute name has been selected");
                return false;
            }

            foreach (AttributePropertyParent parent in fullAttributeSets)
            {
                if (string.IsNullOrWhiteSpace(parent.stockCode))
                {
                    MessageBox.Show("Please ensure that Parent has been selected for all attribute sets");
                    return false;
                }

                if (string.IsNullOrWhiteSpace(parent.attributeSetName))
                {
                    MessageBox.Show("Please ensure that a Attribute set has been selected");
                    return false;
                }

                if (parent.childrenProperties != null)
                {
                    if (parent.childrenProperties.Count < 1)
                    {
                        MessageBox.Show("Please ensure that all parents have children properties");
                        return false;
                    }
                }

                if (string.IsNullOrWhiteSpace(parent.basePriceColumn))
                {
                    MessageBox.Show("Please ensure that a Base price column has been selected for all attribute sets");
                    return false;
                }
            }

            //save the set to the database
            attrMethods.saveSet(selectedSupplier, fullAttributeSets);

            return true;
        }
        private void saveAttributeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!saveAttributeSets())
            {
                return;
            }

            childPositionCounter = 1;
            clearAttributeSet();
            MessageBox.Show("Attribute set successfully saved");
        }

        private void lblAttributeSet_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(lblAttributeSet.Text))
            {
                //enable the properties menu on the attribute set editor
                propertiesToolStripMenuItem.Visible = true;
            }
            else
            {
                propertiesToolStripMenuItem.Visible = false;
            }
        }

        private void pnlAttributeSetEditor_VisibleChanged(object sender, EventArgs e)
        {
            if (pnlAttributeSetEditor.Visible)
            {
                //select the base column
            }
        }

        private void cbSearchAll_CheckedChanged(object sender, EventArgs e)
        {
            cbSuppliers.Enabled = !cbSearchAll.Checked;
            btnLoad.Visible = !cbSearchAll.Checked;

            if (!cbSearchAll.Checked) { dgvItems.DataSource = stockMethods.getAllStockItems(selectedSupplier); }
        }

        private void frmStockItems_Load(object sender, EventArgs e)
        {
            selectedSupplier = supplierMethods.getSupplier(cbSuppliers.SelectedValue.ToString());
        }

        private void setNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string productSKU = dgvItems.Rows[selectedRowIndex].Cells["code"].Value.ToString();

            //is this the child or the parent?
            if (productSKU == selectedAttributeSet.stockCode)
            {
                selectedAttributeSet.propertyName = InputBox.ShowDialog("Parent Property Name", "Parent Property Name", selectedAttributeSet.propertyName);
            }
            else
            {
                AttributeProperty prop = findChildAttribute(productSKU);
                prop.propertyName = InputBox.ShowDialog("Property Name", "Property Name", prop.propertyName);
            }
        }

        private void setPositionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string childSKU = dgvItems.Rows[selectedRowIndex].Cells["code"].Value.ToString();

            AttributeProperty prop = findChildAttribute(childSKU);

            if (childSKU == selectedAttributeSet.stockCode)
            {
                MessageBox.Show("You cannot give positions to parent items");
                return;
            }

            string val = InputBox.ShowDialog("Property Position", "Property Position", prop.position.ToString());
            if (!string.IsNullOrWhiteSpace(val))
            {
                prop.position = int.Parse(val);
            }
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                doSearch();
            }
        }

        private void cbColumnNames_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (selectedAttributeSet == null) { selectedAttributeSet = new AttributePropertyParent(); }
            selectedAttributeSet.basePriceColumn = cbColumnNames.Text;
        }

        private void showRowNumbersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvItems.Columns[0].Name == "number") { dgvItems.Columns.RemoveAt(0); }
            else
            {
                DataGridViewTextBoxColumn col28 = new DataGridViewTextBoxColumn();
                col28.HeaderText = "#";
                col28.Name = "number";
                col28.Width = 20;
                col28.ReadOnly = true;
                dgvItems.Columns.Insert(0, col28);

                for (int i = 0; i < dgvItems.Rows.Count; i++)
                {
                    dgvItems.Rows[i].Cells["number"].Value = (i + 1).ToString();
                }
            }
        }

        private void switchRowNumbersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvItems.Columns[0].Name == "number") { dgvItems.Columns.RemoveAt(0); }
            else
            {
                DataGridViewTextBoxColumn col28 = new DataGridViewTextBoxColumn();
                col28.HeaderText = "#";
                col28.Name = "number";
                col28.Width = 20;
                col28.ReadOnly = true;
                dgvItems.Columns.Insert(0, col28);

                for (int i = 0; i < dgvItems.Rows.Count; i++)
                {
                    dgvItems.Rows[i].Cells["number"].Value = (i + 1).ToString();
                }
            }
        }

        bool switchView = false;
        private void switchViewToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (switchView)
            {
                //show minimized - only standard columns
                changeMiniMaxiColumnView(false);
                switchView = false;
            }
            else
            {
                //show maximized - all columns
                changeMiniMaxiColumnView(true);
                switchView = true;
            }
        }

        private void dgvItems_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                //check if this row is a parent attribute, and display the child properties
                string sku = dgvItems.Rows[e.RowIndex].Cells["code"].Value.ToString();
                selectedAttributeSet = findParentAttribute(sku);

                if (selectedAttributeSet != null)
                {
                    //sets the parent stock code
                    lblParentStockCode.Text = selectedAttributeSet.stockCode;

                    //clears the currently highlighted children
                    foreach (DataGridViewRow row in dgvItems.Rows)
                    {
                        if (row.DefaultCellStyle.BackColor == Color.Aquamarine)
                        {
                            row.DefaultCellStyle.BackColor = Color.White;
                        }
                    }

                    //sets the base price column                    
                    string basePriceColumn = selectedAttributeSet.basePriceColumn;
                    cbColumnNames.SelectedValue = basePriceColumn;

                    //get the items in this attribute set
                    ArrayList properties = attrMethods.getAttributeSetProperties(selectedSupplier, selectedAttributeSet);

                    foreach (AttributeProperty prop in properties)
                    {
                        //find the child items and change the color                        
                        foreach (DataGridViewRow row in dgvItems.Rows)
                        {
                            if (row.Cells["code"].Value.ToString() == prop.stockCode)
                            {
                                row.DefaultCellStyle.BackColor = Color.Aquamarine;
                            }
                        }
                    }
                }
            }
        }

        private AttributeProperty findChildAttribute(string stockCode)
        {
            foreach (AttributeProperty p in selectedAttributeSet.childrenProperties)
            {
                if (p.stockCode == stockCode)
                {
                    return p;
                }
            }

            return null;
        }

        private AttributePropertyParent findParentAttribute(string stockCode)
        {
            foreach (AttributePropertyParent p in fullAttributeSets)
            {
                if (p.stockCode == stockCode)
                {
                    return p;
                }
            }

            return null;
        }

        bool showSpecials = false;
        DataTable dtSpecialsData = new DataTable();
        private void highlightSpecialsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dtSpecialsData.Rows.Count < 1)
            {
                stockMethods = new stockItemMethods(true);
                dtSpecialsData = stockMethods.getAllStockItems(selectedSupplier);
                stockMethods = new stockItemMethods(false);
            }

            showSpecials = true;

            //highlight the specials
            foreach (DataRow dr in dtStockItems.Rows)
            {
                foreach (DataRow drSpecials in dtSpecialsData.Rows)
                {
                    if (dr["productCode"].ToString() == drSpecials["productCode"].ToString())
                    {
                        //find the row in the datagridview
                        foreach (DataGridViewRow drGridRow in dgvItems.Rows)
                        {                            
                            if (drGridRow.Cells["code"].Value.ToString() == drSpecials["productCode"].ToString())
                            {
                                drGridRow.DefaultCellStyle.BackColor = Color.Orange;                               
                            }
                        }
                    }
                }
            }
        }
    }
}