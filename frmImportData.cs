using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using LumenWorks.Framework.IO.Csv;
using Stockman.Classes;
using Stockman.Entities;
using Roslyn.Scripting;
using Roslyn.Scripting.CSharp;
using System.Configuration;
using System.Collections;

namespace Stockman
{
    public partial class frmImportData : FormBase
    {
        #region startup and initialize
        public frmImportData()
        {
            InitializeComponent();
        }
        private void frmImportData_Load(object sender, EventArgs e)
        {
            hostForm = this;
            loadSuppliers();
            showFilePicker();
            loadCsvColumns();

            cboDelimeter.SelectedIndex = 0;
            cbImportType.SelectedIndex = 0;
        }
        #endregion

        #region initialize classes
        supplierMethods supMethods = new supplierMethods();
        templateMethods tempMethods = new templateMethods();
        stockItemMethods stockMethods = new stockItemMethods();
        attributeMethods attrMethods = new attributeMethods();
        Stockman.Classes.Levenshtein levensthein = new Levenshtein();
        #endregion

        #region properties
        frmStatus fStatusUpdate;
        private static frmImportData _thisForm;
        public static frmImportData hostForm
        {
            get
            {
                return _thisForm;
            }
            set { _thisForm = value; }
        }
        public static string cal { get; set; }
        string[] code = new string[1];
        Templates supplierTemplate { get; set; }
        Templates selectedTemplate { get; set; }
        TemplateColumns matchingColumn { get; set; }
        Supplier selectedSupplier { get; set; }
        DataTable dtImportData { get; set; }
        DataTable dtDatabaseItems { get; set; }
        DataTable dtFinal { get; set; }
        bool loading = true;
        private string tempValue { get; set; }
        OpenFileDialog pickFile = new OpenFileDialog();
        #endregion

        #region threads
        private void backgroundWorker1_DoImport(object sender, DoWorkEventArgs e)
        {
            //performs the import
            BackgroundWorker worker = sender as BackgroundWorker;
        }
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!string.IsNullOrEmpty(fStatusUpdate.error))
            {
                fStatusUpdate.showClose = true;
            }
            else
            {
                fStatusUpdate.Close();
            }
        }
        #endregion

        #region events
        private void dgvDatabase_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //is this a levenstein duplicate row
            if (e.RowIndex < 0) { return; }

            if (dgvDatabase.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Contains("duplicate"))
            {
                string levensteinValue = dgvDatabase.Rows[e.RowIndex].Cells["levenstein"].Value.ToString();
                //convert to levenstein object
                if (!string.IsNullOrWhiteSpace(levensteinValue))
                {
                    pnlLevenstein.Visible = true;
                    lblLevenSteinCode.Text = dgvDatabase.Rows[e.RowIndex].Cells["PRODUCTCODE"].Value.ToString();

                    string[] levensteinmatches = levensteinValue.Split(new string[] { "; " }, StringSplitOptions.RemoveEmptyEntries);
                    lbPossibleDuplicates.DataSource = levensteinmatches;
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            pnlLevenstein.Visible = false;
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvDatabase.Rows)
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells["accept"];
                chk.Value = true;
            }
        }

        private void deselectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvDatabase.Rows)
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells["accept"];
                chk.Value = false;
            }
        }

        private void cbSuppliers_SelectionChangeCommitted(object sender, EventArgs e)
        {
            loadTemplates();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!validateInputs(panel1)) { return; }

            if (backgroundWorker1.IsBusy != true)
            {
                // create a new instance of the status form
                fStatusUpdate = new frmStatus();
                fStatusUpdate.Show();
                backgroundWorker1.RunWorkerAsync();
            }

            try
            {
                doImport();
            }
            catch (Exception ee)
            {
                if (ee.Message.Contains("with the same key"))
                {
                    fStatusUpdate.error = ee.Message + " : Please ensure that you have not duplicate column names";
                }
                else
                {
                    fStatusUpdate.error = ee.Message;
                }
            }
        }

        private void dgvDatabase_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                tempValue = dgvDatabase.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            }
            catch (Exception ee)
            {
                tempValue = "";
            }


            lblCalculation.Text = "";

            foreach (TemplateColumns tc in selectedTemplate.templateColumns)
            {
                if (tc.databaseColumn.ToUpper() == dgvDatabase.Columns[e.ColumnIndex].Name.ToUpper())
                {
                    lblCalculation.Text = tc.calculation;
                    if (tc.applyRounding)
                    {
                        lblCalculation.Text += " (rounding applied)";
                    }
                }
            }

            if (string.IsNullOrWhiteSpace(lblCalculation.Text))
            {
                lblCalculation.Text = "No calculation defined";
            }
        }

        private void dgvDatabase_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (!loading)
            {
                //cannot change product code
                string header = dgvDatabase.Columns[e.ColumnIndex].Name.ToUpper();

                if (header == "PRODUCTCODE")
                {
                    MessageBox.Show("Cannot update product code");
                    dgvDatabase.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = tempValue;
                    return;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //hack to ensure that the first row is selected properly
            DataGridViewCellEventArgs dgve = new DataGridViewCellEventArgs(0, 0);
            dgvDatabase_CellClick(dgvDatabase.Rows[dgvDatabase.Rows.Count - 1].Cells["accept"], dgve);

            if (cbImportType.Text.ToUpper() != "REGULAR")
            {
                if (MessageBox.Show("Are you sure you wish to save to database?  This will also remove existing specials", "Confirmation", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No)
                {
                    return;
                }
            }
            else
            {
                if (MessageBox.Show("Are you sure you want to save to database?", "Save", MessageBoxButtons.YesNo) != System.Windows.Forms.DialogResult.Yes) { return; }
            }

            if (backgroundWorker1.IsBusy != true)
            {
                // create a new instance of the status form
                fStatusUpdate = new frmStatus();
                fStatusUpdate.Show();
                backgroundWorker1.RunWorkerAsync();
            }

            //split out the specials so th at we do not override the originals
            DataTable dtRegularData = dtFinal.Clone();
            DataTable dtSpecialsData = dtFinal.Clone();
            foreach (DataGridViewRow dr in dgvDatabase.Rows)
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)dr.Cells["Accept"];
                DataRow importRow = ((DataRowView)(dr.DataBoundItem)).Row;
                importRow["ACCEPT"] = chk.Value.ToString();

                bool match = false;
                foreach (DataRow drS in dtSpecials.Rows)
                {
                    if (drS["productCode"].ToString() == dr.Cells["productCode"].Value.ToString())
                    {
                        dtSpecialsData.LoadDataRow(importRow.ItemArray, true);
                        match = true;
                    }
                }

                if (!match)
                {
                    dtRegularData.LoadDataRow(importRow.ItemArray, true);
                }
            }

            //determine what to save where
            switch (cbImportType.Text.ToUpper())
            {
                case "SPECIALS SHEET":
                    {
                        stockMethods = new stockItemMethods(true);
                        doSave(dtSpecialsData);
                    }
                    break;
                case "REGULAR":
                    {
                        stockMethods = new stockItemMethods(false);
                        doSave(dtRegularData);
                    };
                    break;
                case "REGULAR + SPECIALS COLUMN":
                    {
                        //import regular data
                        stockMethods = new stockItemMethods(false);
                        doSave(dtRegularData);

                        //import special data
                        stockMethods = new stockItemMethods(true);
                        //delete current specials
                        stockMethods.deleteAllStockItems(selectedSupplier);
                        doSave(dtSpecialsData);
                    }
                    break;
            }
        }

        private void button4_Click(object sender, System.EventArgs e)
        {
            if (backgroundWorker1.IsBusy != true)
            {
                // create a new instance of the status form
                fStatusUpdate = new frmStatus();
                fStatusUpdate.Show();
                backgroundWorker1.RunWorkerAsync();
            }

            doRecalc();
        }

        private void dgvDatabase_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show(e.Exception.Message);
        }

        private void dgvDatabase_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            highlightChanges();
        }

        private void txtFilePath_Click(object sender, EventArgs e)
        {
            showFilePicker();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pnlImported.Visible = false;
            gvImportData.DataSource = null;
            dgvDatabase.DataSource = null;
        }
        #endregion

        #region methods
        private void doRecalc()
        {
            //runCalculations();
            //highlightChanges();
        }
        private void doSave(DataTable tableToSave)
        {
            int savedCount = 0;

            //gets the current disabled total
            int disabledTotal = stockMethods.getDisabledCount(selectedSupplier);

            //disable all items
            //stockMethods.disableAllStockItems(selectedSupplier);

            foreach (DataRow row in tableToSave.Rows)
            {
                if (row["accept"].ToString().ToUpper() == "TRUE")
                {
                    fStatusUpdate.status = "Saving to database: " + (savedCount + 1);

                    try
                    {
                        stockMethods.updateStockItem(row, selectedTemplate, selectedSupplier);
                    }
                    catch (Exception ee)
                    {
                        fStatusUpdate.error = ee.Message;
                        return;
                    }
                    savedCount++;
                }
            }

            selectedSupplier.lastImportDate = DateTime.Now.ToString();

            //update the specials import date
            if (cbImportType.Text.ToUpper() != "REGULAR")
            {
                selectedSupplier.specialsActive = true;
                selectedSupplier.specialsImportDate = DateTime.Now.ToString();
            }
            supMethods.updateSupplier(selectedSupplier);

            //show a summary message and hide panel if applicable   
            string message = savedCount + " items updated in database";
            fStatusUpdate.error = message;
        }

        DataTable dtSpecials = new DataTable();
        private void doImport()
        {
            if (InvokeRequired)
            {
                Invoke(new MethodInvoker(doImport));
                return;
            }

            //get parts
            selectedTemplate = (Templates)cbTemplates.SelectedItem;
            selectedSupplier = supMethods.getSupplier(cbSuppliers.SelectedValue.ToString());

            //clear current data
            gvImportData.DataSource = null;
            dgvDatabase.DataSource = null;

            //disable editing
            loading = true;

            fStatusUpdate.status = "Importing data";

            #region get datatables
            //get imported data          
            dtImportData = getCSVDataTable();
            dtImportData.Columns.Add("productCode_orig");

            //start prepping for special imports
            dtSpecials = dtImportData.Clone();
            string specialBaseCSVColumn = "";
            if (cbImportType.Text.ToUpper() != "REGULAR")
            {
                foreach (TemplateColumns col in selectedTemplate.templateColumns)
                {
                    if (!string.IsNullOrWhiteSpace(col.specialsBasePriceCSVColumn))
                    {
                        specialBaseCSVColumn = col.specialsBasePriceCSVColumn;
                    }
                }

                if (string.IsNullOrWhiteSpace(specialBaseCSVColumn))
                {
                    MessageBox.Show("No specials base price CSV column found.  Are you sure you added one on the template?");
                    return;
                }
            }

            //fixes product code - remove special characters & compare for duplicates
            ArrayList pCodes = new ArrayList();
            foreach (DataRow dr in dtImportData.Rows)
            {
                try
                {
                    dr["productCode_orig"] = dr["productCode"].ToString();
                    string prodCode = fixProductCode(dr["productCode"].ToString());
                    dr["productCode"] = prodCode;
                    if (pCodes.Contains(prodCode) & !string.IsNullOrWhiteSpace(prodCode))
                    {
                        fStatusUpdate.error = "Duplicate found!: " + prodCode;
                        return;
                    }
                    pCodes.Add(prodCode);
                }
                catch (Exception ee)
                {
                    fStatusUpdate.error = ee.Message + ".  " + System.Environment.NewLine + "First header found looks like this: [" + dtImportData.Rows[0][0].ToString() + "].  " + System.Environment.NewLine + "Are you sure you picked the correct delimeter?";
                    return;
                }

                //create the rows for special imports
                if (cbImportType.Text.ToUpper() == "REGULAR + SPECIALS COLUMN" && !string.IsNullOrWhiteSpace(specialBaseCSVColumn) && !string.IsNullOrWhiteSpace(dr[specialBaseCSVColumn].ToString()))
                {
                    DataRow specialsRow = dr;
                    if (!string.IsNullOrWhiteSpace(specialsRow[specialBaseCSVColumn].ToString()) && specialsRow[specialBaseCSVColumn].ToString() != "0")
                    {
                        specialsRow["productBasePrice"] = specialsRow[specialBaseCSVColumn].ToString();
                        dtSpecials.ImportRow(specialsRow);
                    }
                }
            }

            //detemine which data types to work with
            switch (cbImportType.Text.ToUpper())
            {
                case "SPECIALS SHEET":
                    {
                        stockMethods = new stockItemMethods(true);
                        doImportCalculations(true);
                    }
                    break;
                case "REGULAR":
                    {
                        stockMethods = new stockItemMethods(false);
                        doImportCalculations(false);
                    };
                    break;
                case "REGULAR + SPECIALS COLUMN":
                    {
                        //import regular data
                        doImportCalculations(false);

                        //import special data
                        dtImportData = dtSpecials;
                        doImportCalculations(true);
                    }
                    break;
            }
        }

        private void doImportCalculations(bool isSpecialsImport)
        {
            fStatusUpdate.status = "Retrieving database items";
            //get stock items in db        
            try
            {
                var searchTemplate = selectedTemplate;
                if (matchingColumn.databaseColumn.ToUpper() != "PRODUCTCODE")
                {
                    //temporarily add productCode column
                    TemplateColumns productCodeColumn = new TemplateColumns();
                    productCodeColumn.databaseColumn = "PRODUCTCODE";
                    productCodeColumn.csvHeader = "productCode";
                    searchTemplate.templateColumns.Add(productCodeColumn);
                }
                dtDatabaseItems = stockMethods.getTemplateStockItems(selectedSupplier, searchTemplate);
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
                return;
            }

            dtDatabaseItems.Columns.Add("accept", typeof(bool));

            //uppercase column headings
            foreach (DataColumn dc in dtDatabaseItems.Columns)
            {
                dc.ColumnName = dc.ColumnName.ToUpper();
            }

            //removes the product code supplier prefix
            foreach (DataRow dr in dtDatabaseItems.Rows)
            {
                //should the overridden margins load
                if (dr["overrideMargins"].ToString() == "False")
                {
                    //add supplier defaults
                    dr["d_agencyMargin"] = selectedSupplier.agencyMargin;
                    dr["d_grossMargin"] = selectedSupplier.grossMargin;
                    dr["d_discount"] = selectedSupplier.discount;
                    dr["accept"] = bool.TrueString;
                }
            }

            dtFinal = dtDatabaseItems.Clone();
            dtFinal.Clear(); //prepares the datatable that will become the source of dgvDatabaseItems                        
            #endregion

            //run comparison and put on screen           
            compareToDB();

            dgvDatabase.DataSource = dtFinal;

            //hide meta columns
            dgvDatabase.Columns["overrideMargins"].Visible = false;
            dgvDatabase.Columns["mustExport"].Visible = false;

            //enable editing
            loading = false;

            runCalculations(isSpecialsImport);

            pnlImported.Visible = true;
            dgvDatabase.ClearSelection();

            highlightChanges();

            //stores the file location
            FileInfo file = new FileInfo(pickFile.FileName);
            try
            {
                tempMethods.storeLastFileLocation(selectedTemplate, selectedSupplier, file.DirectoryName);
                selectedTemplate.lastFileLocation = file.DirectoryName;
            }
            catch (Exception ee)
            {
                MessageBox.Show("Unable to store last file location.  Non fatal error, you may continue working.  Error: " + ee.Message);
            }
        }

        private string fixProductCode(string input)
        {
            input = input.Replace("-", "");
            input = input.Replace("/", "");
            input = input.Replace(" ", "");
            input = input.Replace(".", "");
            input = input.ToUpper();
            return input;
        }
        public string ReplaceFirst(string text, string search, string replace)
        {
            int pos = text.IndexOf(search);
            if (pos < 0)
            {
                return text;
            }
            return text.Substring(0, pos) + replace + text.Substring(pos + search.Length);
        }

        private void showFilePicker()
        {
            //defaults to lastFilePath
            selectedTemplate = (Templates)cbTemplates.SelectedItem;

            if (selectedTemplate != null)
            {
                if (!string.IsNullOrEmpty(selectedTemplate.lastFileLocation))
                {
                    pickFile.InitialDirectory = selectedTemplate.lastFileLocation;
                }
            }

            pickFile.Filter = "CSV files (*.csv)|*.csv|All Files (*.*)|*.*";
            pickFile.Title = "Select a file to import";
            if (pickFile.ShowDialog() == DialogResult.OK)
            {
                if (pickFile.CheckFileExists)
                {
                    txtFilePath.Text = pickFile.FileName;
                }
            }
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

            loadTemplates();
        }
        private void loadTemplates()
        {
            cbTemplates.DataSource = null;

            if (cbSuppliers.Items.Count < 1) { return; }

            List<Templates> templates = tempMethods.getSupplierTemplates(cbSuppliers.SelectedValue.ToString(), "IMPORT", false);
            if (templates.Count <= 0)
            {
                return;
            }

            bindingTemplates.DataSource = templates;
            cbTemplates.DataSource = bindingTemplates.DataSource;
            cbTemplates.DisplayMember = "templateName";
            cbTemplates.ValueMember = "templateID";
        }

        private DataTable getCSVDataTable()
        {
            //create temporary datagridview            
            using (CachedCsvReader csv = new CachedCsvReader(new StreamReader(txtFilePath.Text), true, cboDelimeter.Text[0]))
            {
                int fieldCount = csv.FieldCount;
                gvImportData.DataSource = csv;
            }

            //convert to dt
            if (gvImportData.ColumnCount == 0) return null;

            DataTable dtSource = new DataTable();
            //create columns
            foreach (DataGridViewColumn col in gvImportData.Columns)
            {
                if (col.Name == string.Empty) continue;
                dtSource.Columns.Add(col.Name.ToUpper(), col.ValueType);
                dtSource.Columns[col.Name].Caption = col.HeaderText.ToUpper();
            }
            if (dtSource.Columns.Count == 0) return null;
            //create data
            foreach (DataGridViewRow row in gvImportData.Rows)
            {
                DataRow drNewRow = dtSource.NewRow();
                foreach (DataColumn col in dtSource.Columns)
                {
                    drNewRow[col.ColumnName] = row.Cells[col.ColumnName].Value;
                }

                if (!string.IsNullOrWhiteSpace(drNewRow[0].ToString()))
                {
                    dtSource.Rows.Add(drNewRow);
                }
            }

            //update the column headers according to the map
            for (int i = 0; i < dtSource.Columns.Count; i++)
            {
                for (int j = 0; j < selectedTemplate.templateColumns.Count; j++)
                {
                    if (selectedTemplate.templateColumns[j].calculationType != columnCalculationType.COPY)
                    {
                        if (dtSource.Columns[i].ColumnName.ToUpper() == selectedTemplate.templateColumns[j].csvHeader.ToUpper())
                        {
                            dtSource.Columns[i].ColumnName = selectedTemplate.templateColumns[j].databaseColumn;
                        }
                    }
                }
            }

            //if the matching column is not product code, see if we can find the item's actual product code and add to the table
            if (matchingColumn.databaseColumn.ToUpper() != "PRODUCTCODE")
            {
                dtSource.Columns.Add("PRODUCTCODE");

                for (int i = 0; i < dtSource.Rows.Count; i++)
                {
                    var searchColumnIndex = dtSource.Columns.IndexOf(matchingColumn.databaseColumn);
                    var foundItem = stockMethods.findStockItem(matchingColumn.databaseColumn, dtSource.Rows[i][searchColumnIndex].ToString());

                    string productCode = "";
                    if (foundItem.Rows.Count < 1)
                    {
                        productCode = dtSource.Rows[i][searchColumnIndex].ToString();
                    }
                    else
                    {
                        productCode = foundItem.Rows[0]["productCode"].ToString();
                    }

                    dtSource.Rows[i]["PRODUCTCODE"] = productCode;
                }
            }

            return dtSource;
        }

        private void compareRowData(DataRow drCSV, DataRow drDB, int rowIndex)
        {
            string match = "true";

            try
            {
                string csvCol = formatStringAsDecimal(decimal.Parse(drCSV["productBasePrice"].ToString()).ToString());
                string dbCol = formatStringAsDecimal(decimal.Parse(drDB["productBasePrice"].ToString()).ToString());

                if (csvCol != dbCol)
                {
                    match = "false";
                }
            }
            catch (Exception ee)
            {
                //if either of these two columns cannot be found, update the data
                match = "baseless";
            }


            //run column overrides if required
            foreach (TemplateColumns tc in selectedTemplate.templateColumns)
            {
                try
                {
                    string databaseColumn = tc.databaseColumn;

                    if (tc.dontOverride)
                    {
                        drCSV[databaseColumn] = drDB[databaseColumn].ToString();
                    }

                    //adds the product short code as default
                    drCSV["shortCode"] = drDB["shortCode"].ToString();

                }
                catch (Exception ee)
                {
                    //this is most likely a calculated field, skip it                    
                }
            }

            //determine how status messages are handled
            string statusMessage = "";
            switch (match)
            {
                case "true":
                    {
                        statusMessage = "SAME";
                    }
                    break;
                case "false":
                    {
                        statusMessage = "UPDATE";
                    }
                    break;
                case "baseless":
                    {
                        statusMessage = "BASELESS";
                    }
                    break;
            }

            drCSV["STATUS"] = statusMessage;
            drCSV["d_agencyMargin"] = drDB["d_agencyMargin"].ToString();
            drCSV["d_grossMargin"] = drDB["d_grossMargin"].ToString();
            drCSV["d_discount"] = drDB["d_discount"].ToString();
            drCSV["active"] = drDB["active"].ToString();
            dtFinal.ImportRow(drCSV);
        }

        private string formatStringAsDecimal(string input)
        {
            string number = "";
            int indexOfDot = input.IndexOf(".");
            if (indexOfDot == -1)
            {
                number = input + ".00";
            }
            else
            {
                number = input.Substring(0, indexOfDot);
                string decimalPart = input.Substring(indexOfDot);
                if (decimalPart.Length == 2)
                {
                    decimalPart = decimalPart + "0";
                }
                if (decimalPart.Length == 0)
                {
                    decimalPart = "00";
                }

                number = number + decimalPart;
            }

            return number;
        }

        private void compareToDB()
        {
            //add status column  
            dtFinal.Columns.Add("STATUS");
            dtFinal.Columns.Add("levenstein");

            dtImportData.Columns.Add("d_discount");
            dtImportData.Columns.Add("d_grossMargin");
            dtImportData.Columns.Add("d_agencyMargin");
            dtImportData.Columns.Add("shortCode");
            dtImportData.Columns.Add("STATUS");
            dtImportData.Columns.Add("active");

            dtDatabaseItems.Columns.Add("STATUS");
            dtDatabaseItems.Columns.Add("levenstein");

            //adds the copy columns and fill with data
            foreach (TemplateColumns tc in selectedTemplate.templateColumns)
            {
                if (tc.calculationType == columnCalculationType.COPY)
                {
                    //adds the column name
                    dtImportData.Columns.Add(tc.databaseColumn);

                    //adds the copyColumn value
                    for (int i = 0; i < dtImportData.Rows.Count; i++)
                    {
                        dtImportData.Rows[i][tc.databaseColumn] = dtImportData.Rows[i][tc.csvHeader];
                    }
                }
            }


            //runs the import rows
            DataRow drMatchingDBRow = null;
            bool gotMatchInDB = false;
            int rowIndex = 0;

            int rowCount = dtImportData.Rows.Count;
            //check if there are changes to the data, when comparing the csv to the database
            foreach (DataRow dr in dtImportData.Rows)
            {
                fStatusUpdate.status = "Comparing to DB " + (rowIndex + 1) + ":" + rowCount;
                gotMatchInDB = false;

                foreach (DataRow drDB in dtDatabaseItems.Rows)
                {
                    //get the appropriate database row to match
                    if (drDB["PRODUCTCODE"].ToString() == dr["PRODUCTCODE"].ToString())
                    {
                        drMatchingDBRow = drDB;
                        compareRowData(dr, drMatchingDBRow, rowIndex);
                        gotMatchInDB = true;
                    }
                }

                if (!gotMatchInDB)
                {
                    //this csv item is new
                    DataRow newRow = dr;
                    newRow["STATUS"] = "NEW";
                    newRow["d_agencyMargin"] = selectedSupplier.agencyMargin;
                    newRow["d_grossMargin"] = selectedSupplier.grossMargin;
                    newRow["d_discount"] = selectedSupplier.discount;
                    newRow["active"] = "1";
                    dtFinal.ImportRow(newRow);
                }

                rowIndex++;
            }


            //check for items not imported, db comparing to csv
            foreach (DataRow drDB in dtDatabaseItems.Rows)
            {
                fStatusUpdate.status = "Comparing to CSV " + (rowIndex + 1) + ":" + rowCount;
                gotMatchInDB = false;

                foreach (DataRow dr in dtImportData.Rows)
                {
                    //get the appropriate database row to match
                    if (dr["PRODUCTCODE"].ToString() == drDB["PRODUCTCODE"].ToString())
                    {
                        drMatchingDBRow = dr;
                        gotMatchInDB = true;
                    }
                }

                if (!gotMatchInDB)
                {
                    //this csv item is new
                    DataRow newRow = drDB;
                    newRow["STATUS"] = "NOT IMPORTED";
                    newRow["d_agencyMargin"] = selectedSupplier.agencyMargin;
                    newRow["d_grossMargin"] = selectedSupplier.grossMargin;
                    newRow["d_discount"] = selectedSupplier.discount;
                    dtFinal.ImportRow(newRow);
                }

                rowIndex++;
            }
        }

        private void setCheckboxState()
        {
            foreach (DataGridViewRow row in dgvDatabase.Rows)
            {
                if (row.Cells["STATUS"].Value != null)
                {
                    switch (row.Cells["STATUS"].Value.ToString())
                    {
                        case "BASELESS":
                        case "UPDATE":
                        case "SAME":
                            {
                                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells["accept"];
                                chk.Value = true;
                            }
                            break;
                        case "NEW":
                        default:
                            {
                                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells["accept"];
                                chk.Value = false;
                            }
                            break;
                    }
                }
            }
        }

        private void highlightChanges()
        {
            foreach (DataGridViewRow row in dgvDatabase.Rows)
            {
                if (row.Cells["STATUS"].Value != null)
                {
                    switch (row.Cells["STATUS"].Value.ToString())
                    {
                        case "NEW":
                            {
                                //run levensthein matching
                                /*  List<LevenSteinMatches> ldMatches = levenstheinMatching(row.Cells["PRODUCTCODE"].Value.ToString());
                                  if (ldMatches.Count > 0)
                                  {
                                      //adds the levenstein carrying column      
                                      string m = "";
                                      foreach (LevenSteinMatches ls in ldMatches)
                                      {
                                          m += ls.matchingCode + "; ";
                                      }
                                      row.Cells["levenstein"].Value = m;
                                      row.Cells["STATUS"].Value = "NEW (" + ldMatches.Count + " possible duplicate(s))";
                                      row.DefaultCellStyle.BackColor = Color.Aquamarine;
                                  }
                                  else
                                  {
                                      row.DefaultCellStyle.BackColor = Color.PowderBlue;
                                  }*/
                                row.DefaultCellStyle.BackColor = Color.PowderBlue;
                            }
                            break;
                        case "UPDATE": { row.DefaultCellStyle.BackColor = Color.Coral; } break;
                        case "SAME": case "BASELESS": { row.DefaultCellStyle.BackColor = Color.CadetBlue; } break;
                    }
                }
            }

            //hide and sort columns
            dgvDatabase.Columns["levenstein"].Visible = false;
            dgvDatabase.Columns["productCode_orig"].Visible = false;

            dgvDatabase.Columns["accept"].DisplayIndex = 0;
            dgvDatabase.Columns["status"].HeaderText = "ITEM STATUS";
            dgvDatabase.Columns["status"].DisplayIndex = 1;
            dgvDatabase.Columns["active"].HeaderText = "ACTIVE";
            dgvDatabase.Columns["active"].DisplayIndex = 2;
            dgvDatabase.Columns["productCode"].DisplayIndex = 3;
            dgvDatabase.Columns["shortCode"].DisplayIndex = 4;

            setCheckboxState();

            applyConditionalFormatting();
        }

        private void applyConditionalFormatting()
        {
            foreach (DataGridViewRow row in dgvDatabase.Rows)
            {
                foreach (TemplateColumns tc in selectedTemplate.templateColumns)
                {
                    if (tc.templateConditionalFormatting == null) { return; }

                    if (tc.templateConditionalFormatting.Count > 0)
                    {
                        decimal testNumber = decimal.Parse(row.Cells[tc.databaseColumn].Value.ToString());
                        for (int i = 0; i < tc.templateConditionalFormatting.Count; i++)
                        {
                            switch (tc.templateConditionalFormatting[i].op)
                            {
                                case ">":
                                    {
                                        if (testNumber > tc.templateConditionalFormatting[i].number)
                                        {
                                            DataGridViewCellStyle dc = new DataGridViewCellStyle();
                                            dc.BackColor = tc.templateConditionalFormatting[i].highlightColor;
                                            row.Cells[tc.databaseColumn].Style = dc;
                                        }
                                    }
                                    break;
                                case "<":
                                    {
                                        if (testNumber < tc.templateConditionalFormatting[i].number)
                                        {
                                            DataGridViewCellStyle dc = new DataGridViewCellStyle();
                                            dc.BackColor = tc.templateConditionalFormatting[i].highlightColor;
                                            row.Cells[tc.databaseColumn].Style = dc;
                                        }
                                    }
                                    break;
                                case "=":
                                    {
                                        if (testNumber == tc.templateConditionalFormatting[i].number)
                                        {
                                            DataGridViewCellStyle dc = new DataGridViewCellStyle();
                                            dc.BackColor = tc.templateConditionalFormatting[i].highlightColor;
                                            row.Cells[tc.databaseColumn].Style = dc;
                                        }
                                    }
                                    break;
                            }

                        }
                    }
                }
            }
        }

        private bool applySpecialOverride(bool isSpecialsImport, DataGridViewRow row, string databaseColumn)
        {
            if (!isSpecialsImport) { return false; }

            bool hasOverride = false;
            foreach (SpecialsOverrideColumns tc in selectedTemplate.specialsOverrideColumns)
            {
                foreach (string s in tc.overridesColumns)
                {
                    if (s == databaseColumn)
                    {
                        try
                        {
                            string columnValue = row.Cells[tc.baseColumn].Value.ToString();
                            row.Cells[s].Value = columnValue;
                            hasOverride = true;
                        }
                        catch (Exception ee)
                        {
                            //temp fix
                        }
                    }
                }
            }

            return hasOverride;
        }

        private void runCalculations(bool isSpecialsImport)
        {
            int rowIndex = 0;
            setup();

            decimal calculationValue = 0;
            int rowCount = dgvDatabase.Rows.Count;
            int testCounter = 0;

            foreach (DataGridViewRow row in dgvDatabase.Rows)
            {
                fStatusUpdate.status = "Doing calculations " + (row.Index + 1) + ":" + rowCount;

                foreach (TemplateColumns tc in selectedTemplate.templateColumns)
                {
                    //check if this database column has a override active.  If so, do not do any calculations
                    if (!applySpecialOverride(isSpecialsImport, row, tc.databaseColumn))
                    {
                        if (!string.IsNullOrWhiteSpace(tc.calculation))
                        {
                            if (tc.calculationType == columnCalculationType.CALCULATE)
                            {
                                cal = "";

                                //are there a calculation on this column
                                if (!string.IsNullOrWhiteSpace(tc.calculation))
                                {
                                    cal = tc.calculation;
                                    cal = cal.Replace("[", "decimal.Parse(row.Cells[\"");
                                    cal = cal.Replace("]", "\"].Value.ToString())");
                                    cal = "(" + cal + ").ToString()";

                                    hostObject.rowIndex = row.Index;
                                    hostObject.calculation = cal;
                                    calculationValue = decimal.Parse(dynamicCalculation());
                                    row.Cells[tc.databaseColumn].Value = calculationValue;
                                }

                                if (tc.applyRounding)
                                {
                                    //apply rounding calculation
                                    row.Cells[tc.databaseColumn].Value = applyRounding(calculationValue);
                                }
                            }
                        }
                    }
                }

                rowIndex++;

                //to speed up Roslyn processing, refresh the objects after every 50 rows
                testCounter++;
                if (testCounter == 100)
                {
                    testCounter = 0;
                    setup();
                }
            }
        }

        private decimal applyRounding(decimal input)
        {
            decimal output = 0;

            //which ceiling value to use

            decimal ceiling = 0;

            if (input < 1000) { ceiling = 1; }
            else
                if (input < 10000) { ceiling = 10; }
            else
                    if (input < 100000) { ceiling = 100; }
            else
                        if (input < 1000000) { ceiling = 1000; }
            else
                            if (input < 10000000) { ceiling = 10000; }

            output = Math.Ceiling(input / ceiling) * ceiling;


            //round up to nearest big number

            //which minus to apply 
            int posOfPoint = output.ToString().IndexOf(".");
            string sub = output.ToString();
            if (posOfPoint > -1)
            {
                sub = output.ToString().Substring(0, posOfPoint);
            }

            decimal minus = 0;
            switch (sub.Length)
            {
                case 1: { minus = 0.01M; } break;
                case 2: { minus = 0.01M; } break;
                case 3: { minus = 0.1M; } break;
                case 4: { minus = 1M; } break;
                case 5: { minus = 10M; } break;
                case 6: { minus = 100M; } break;
                case 7: { minus = 1000M; } break;
                case 8: { minus = 10000M; } break;
            }

            output = output - minus;

            return output;
        }

        private void showHideGVColumns(string criteria)
        {
            foreach (DataGridViewRow row in dgvDatabase.Rows)
            {
                dgvDatabase.CurrentCell = null;
                row.Visible = false;

                if (criteria == "ALL")
                {
                    row.Visible = true;
                }
                else
                {
                    if (row.Cells["STATUS"].Value.ToString().Contains(criteria))
                    {
                        row.Visible = true;
                    }
                }
            }
        }

        private void scrollToProductCode(string productCode)
        {
            foreach (DataGridViewRow dr in dgvDatabase.Rows)
            {
                //set all rows to visible again
                dr.Visible = true;

                if (dr.Cells["PRODUCTCODE"].Value.ToString() == productCode)
                {
                    dgvDatabase.FirstDisplayedScrollingRowIndex = dr.Index;
                    return;
                }
            }
        }
        #endregion

        #region menus
        private void sAMEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showHideGVColumns("SAME");
        }

        private void dIFFERENTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showHideGVColumns("UPDATE");
        }

        private void aLLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showHideGVColumns("ALL");
        }

        private void nEWToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showHideGVColumns("NEW");
        }

        private void showNotImportedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showHideGVColumns("NOT IMPORTED");
        }
        #endregion

        #region Roslyn
        public HostObject hostObject;
        public ScriptEngine engine;
        public Roslyn.Scripting.Session session;
        public void setup()
        {
            hostObject = null;
            hostObject = new HostObject();
            engine = null;
            engine = new ScriptEngine(new[] { hostObject.GetType().Assembly.Location });
            session = null;
            session = Session.Create(hostObject);
            session.AddReference("System.Windows.Forms.dll");
            session.AddReference("System.dll");
        }

        public class HostObject : frmImportData
        {
            public string calculation
            {
                get;
                set;
            }
            public int rowIndex
            {
                get;
                set;
            }
            public DataGridViewRow row
            {
                get
                {
                    return dgv.Rows[rowIndex];
                }
            }
            public DataGridView dgv
            {
                get
                {
                    Control[] c = hostForm.Controls.Find("dgvDatabase", true);

                    DataGridView l2 = (DataGridView)c[0];
                    return l2;
                }
            }
        }

        public string dynamicCalculation()
        {
            string code = hostObject.calculation + @";";
            return engine.Execute<string>(code, session);
        }
        #endregion

        #region levenstein
        private void lbPossibleDuplicates_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            string code = lbPossibleDuplicates.Text;
            scrollToProductCode(code);
        }
        public class LevenSteinMatches
        {
            public string matchingCode
            {
                get;
                set;
            }
        }

        private List<LevenSteinMatches> levenstheinMatching(string newProdCode)
        {
            List<LevenSteinMatches> ldMatches = new List<LevenSteinMatches>();

            foreach (DataGridViewRow dr in dgvDatabase.Rows)
            {
                string prodCode = dr.Cells["PRODUCTCODE"].Value.ToString();

                if (prodCode != newProdCode)
                {
                    int tolerance = int.Parse(ConfigurationSettings.AppSettings["levensteinTolerance"]);
                    if (levensthein.iLD(newProdCode, prodCode) == tolerance)
                    {
                        LevenSteinMatches ldMatch = new LevenSteinMatches();
                        ldMatch.matchingCode = prodCode;
                        ldMatches.Add(ldMatch);
                    }
                }
            }
            return ldMatches;
        }

        private void lblLevenSteinCode_DoubleClick(object sender, EventArgs e)
        {
            scrollToProductCode(lblLevenSteinCode.Text);
        }
        #endregion

        private void loadCsvColumns()
        {
            matchingColumn = null;

            if (selectedTemplate == null)
            {
                return;
            }

            cbCsvColumn.DataSource = selectedTemplate.templateColumns;
            cbCsvColumn.DisplayMember = "csvHeader";

            var productCodeColumn = selectedTemplate.templateColumns.Find(x => x.databaseColumn.ToUpper() == "PRODUCTCODE");
            cbCsvColumn.SelectedItem = productCodeColumn;
            matchingColumn = productCodeColumn;
        }

        private void cbTemplates_SelectionChangeCommitted(object sender, EventArgs e)
        {
            selectedTemplate = (Templates)cbTemplates.SelectedItem;
            loadCsvColumns();
        }
        private void cbCsvColumn_SelectedIndexChanged(object sender, EventArgs e)
        {
            matchingColumn = (TemplateColumns)cbCsvColumn.SelectedItem;
        }
    }
}