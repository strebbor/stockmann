using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Stockman.Classes;
using Stockman.Entities;
using RKLib.ExportData;
using Roslyn.Scripting;
using Roslyn.Scripting.CSharp;
using System.ComponentModel;
using Excel = Microsoft.Office.Interop.Excel;
using System.Collections;
using System.IO;
using System.Linq;
using System.Text;

namespace Stockman
{
    public partial class frmExportData : FormBase
    {
        #region startup and initialize
        public frmExportData()
        {
            InitializeComponent();
            loadSuppliers();
        }
        #endregion

        #region initialize classes
        supplierMethods supMethods = new supplierMethods();
        templateMethods tempMethods = new templateMethods();
        stockItemMethods stockMethods = new stockItemMethods();
        attributeMethods attrMethods = new attributeMethods();

        #endregion

        #region properties
        private string cal = "";
        private DataTable dtStock = null;
        private DataTable dtStockSpecials = null;
        private DataTable dtStockOriginal = null;
        frmStatus fStatusUpdate;
        private DataTable dtExport = new DataTable();
        Templates selectedTemplate { get; set; }
        private string _exportName = "";
        public string exportName
        {
            get
            {
                return _exportName;
            }
            set
            {
                _exportName = value;
                if (!string.IsNullOrEmpty(_exportName))
                {
                    pnlExportedOptions.Visible = true;
                }
                else
                {
                    pnlExportedOptions.Visible = false;
                }
            }
        }
        #endregion

        #region events
        private void cbSuppliers_SelectionChangeCommitted(object sender, EventArgs e)
        {
            loadTemplates();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            #region enable control validation and validate
            cbExportFormat.CausesValidation = true;
            txtFilePath.CausesValidation = true;

            if (!validateInputs(panel1)) { return; }
            #endregion

            #region get the export data
            try
            {
                loadExportData();
            }
            catch (Exception ee)
            {
                fStatusUpdate.error = ee.Message;
                MessageBox.Show(ee.Message);
                return;
            }

            gvImportData.DataSource = dtExport;


            //only get the items that must be exported
            DataTable dtFinalExport = dtExport.Copy();
            dtFinalExport.Clear();

            for (int i = 0; i < dtExport.Rows.Count; i++)
            {
                if (dtExport.Rows[i]["export"].ToString() == "True")
                {
                    dtFinalExport.ImportRow(dtExport.Rows[i]);
                }
            }

            //hides the "export" column
            dtFinalExport.Columns.Remove("EXPORT");
            #endregion

            #region applies column formatting
            try
            {
                formatColumns(dtFinalExport);
            }
            catch (Exception ee)
            {
                fStatusUpdate.error = ee.Message;
                MessageBox.Show(ee.Message);
                return;
            }
            #endregion

            #region apply defaults
            try
            {
                applyExportDefaults(dtFinalExport);
            }
            catch (Exception ee)
            {
                fStatusUpdate.error = ee.Message;
                MessageBox.Show(ee.Message);
                return;
            }
            #endregion

            #region generate unique filename
            string fileName = cbTemplates.Text;
            fileName += " " + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString();
            #endregion

            #region export data sheet
            Export objExport = new Export("Win");
            try
            {
                switch (cbExportFormat.Text)
                {
                    case "IIF":
                        {
                            exportName = txtFilePath.Text + "\\" + fileName + ".IIF";
                            objExport.ExportDetails(dtFinalExport, Export.ExportFormat.Excel, exportName);
                        } break;
                    case "CSV":
                        {
                            exportName = txtFilePath.Text + "\\" + fileName + ".csv";
                            objExport.ExportDetails(dtFinalExport, Export.ExportFormat.CSV, exportName);
                        } break;
                    case "XLSX":
                        {
                            exportName = txtFilePath.Text + "\\" + fileName + ".xls";
                            objExport.ExportDetails(dtFinalExport, Export.ExportFormat.Excel, exportName);
                        } break;
                }
            }
            catch (Exception ee)
            {
                fStatusUpdate.error = ee.Message;
                MessageBox.Show(ee.Message);
                return;
            }
            #endregion

            MessageBox.Show(dtFinalExport.Rows.Count + " row(s) have been exported to " + txtFilePath.Text + "\\" + fileName + "." + cbExportFormat.Text);
            fStatusUpdate.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //disable some control validation and validate
            cbExportFormat.CausesValidation = false;
            txtFilePath.CausesValidation = false;

            if (!validateInputs(panel1)) { return; }

            //loads the export data
            try
            {
                loadExportData();
            }
            catch (Exception ee)
            {
                fStatusUpdate.error = ee.Message;
                MessageBox.Show(ee.Message);
                return;
            }

            //format export datatable
            try
            {
                formatColumns(dtExport);
            }
            catch (Exception ee)
            {
                fStatusUpdate.error = ee.Message;
                MessageBox.Show(ee.Message);
                return;
            }

            //apply defaults
            try
            {
                applyExportDefaults(dtExport);
            }
            catch (Exception ee)
            {
                fStatusUpdate.error = ee.Message;
                MessageBox.Show(ee.Message);
                return;
            }

            //shows data on gridview
            gvImportData.DataSource = dtExport;
        }

        private void txtFilePath_Click(object sender, EventArgs e)
        {
            selectedTemplate = (Templates)cbTemplates.SelectedItem;
            if (!string.IsNullOrEmpty(selectedTemplate.lastFileLocation))
            {
                folderBrowserDialog1.SelectedPath = selectedTemplate.lastFileLocation;
            }

            if (folderBrowserDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtFilePath.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            //performs the import
            BackgroundWorker worker = sender as BackgroundWorker;
        }

        private void linkLabel1_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
        {
            pnlExportedOptions.Visible = false;

            try
            {
                resolveHeaders();

                xlWorkbook.Save();
                xlWorkbook.Close(true, exportName, false);
            }
            catch (Exception ee)
            {
                pnlExportedOptions.Visible = false;
                MessageBox.Show(ee.Message);
                return;
            }
        }

        private void linkLabel3_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
        {
            pnlExportedOptions.Visible = false;
            try
            {
                resolveHeaders();
                xlWorkbook.Save();
                xlWorkbook.Close(true, exportName, false);
                xlApp.Quit();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
                return;
            }

            openExcelFile();
        }

        private void frmExportData_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            //release Excel objects
            try
            {
                xlApp.Quit();

            }
            catch (Exception ee)
            {
                //ignore
            }
            finally
            {
                releaseObject(xlApp);
            }
        }
        private void frmExportData_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        #endregion

        #region methods
        private void loadExportData()
        {
            if (backgroundWorker1.IsBusy != true)
            {
                // create a new instance of the status form
                fStatusUpdate = new frmStatus();
                fStatusUpdate.Show();
                fStatusUpdate.showClose = true;
                backgroundWorker1.RunWorkerAsync();
            }

            try
            {
                doSetExportData();
            }
            catch (Exception ee)
            {
                fStatusUpdate.error = ee.Message;
                return;
            }

            fStatusUpdate.Close();

            //stores the file location
            try
            {
                if (string.IsNullOrEmpty(folderBrowserDialog1.SelectedPath)) { return; }

                Supplier s = new Supplier();
                s.supplierID = cbSuppliers.SelectedValue.ToString();

                tempMethods.storeLastFileLocation(selectedTemplate, s, folderBrowserDialog1.SelectedPath);
                selectedTemplate.lastFileLocation = folderBrowserDialog1.SelectedPath;
            }
            catch (Exception ee)
            {
                MessageBox.Show("Unable to store last file location.  Non fatal error, you may continue working.  Error: " + ee.Message);
            }
        }
        private void formatColumns(DataTable dtToFormat)
        {
            foreach (TemplateColumns tc in selectedTemplate.templateColumns)
            {
                string currentValue = "";
                try
                {
                    for (int i = 0; i < dtToFormat.Rows.Count; i++)
                    {
                        fStatusUpdate.status = "Applying formatting (" + tc.columnType + ") to rows " + (i + 1).ToString() + " of " + dtToFormat.Rows.Count.ToString();

                        currentValue = dtToFormat.Rows[i][tc.csvHeader].ToString();
                        if (string.IsNullOrEmpty(currentValue))
                        {
                            return;
                        }

                        //apply column formatting to the new table
                        switch (tc.columnType)
                        {
                            case Entities.columnTypes.DECIMAL_18_2:
                                {
                                    decimal formatted = decimal.Parse(currentValue);
                                    currentValue = formatted.ToString("0.00");

                                } break;
                            case Entities.columnTypes.DECIMAL_18_3:
                                {
                                    decimal formatted = decimal.Parse(currentValue);
                                    currentValue = formatted.ToString("0.000");

                                } break;

                            case Entities.columnTypes.DECIMAL_18_4:
                                {
                                    decimal formatted = decimal.Parse(currentValue);
                                    currentValue = formatted.ToString("0.0000");

                                } break;

                            case Entities.columnTypes.DECIMAL_18_5:
                                {
                                    decimal formatted = decimal.Parse(currentValue);
                                    currentValue = formatted.ToString("0.00000");

                                } break;


                        }

                        dtToFormat.Rows[i][tc.csvHeader] = currentValue;
                    }
                }
                catch (System.FormatException sf)
                {
                    throw new Exception("Unable to format data column [" + tc.databaseColumn + "]'s value '" + currentValue + "' to " + tc.columnType + ".  Technical Detail (FormatException): " + sf.Message);
                }
                catch (Exception ee)
                {
                    throw new Exception("Unable to format data column [" + tc.databaseColumn + "]'s value  '" + currentValue + "' to " + tc.columnType + ".  Technical Detail (Exception): " + ee.Message);
                }
            }
        }

        AttributePropertyParent parentProperty = new AttributePropertyParent();

        private void doSetExportData()
        {
            if (InvokeRequired)
            {
                Invoke(new MethodInvoker(doSetExportData));
                return;
            }

            fStatusUpdate.status = "Preparing export data";

            //get template parts
            selectedTemplate = (Templates)cbTemplates.SelectedItem;

            Supplier s = new Supplier();
            s.supplierID = cbSuppliers.SelectedValue.ToString();

            try
            {
                dtStockSpecials = stockMethods.getTemplateStockItems(s, selectedTemplate, true);
                int primaryKeyColID = dtStockSpecials.Columns.IndexOf("productCode_orig");
                DataColumn[] keys = new DataColumn[1];
                keys[0] = dtStockSpecials.Columns[primaryKeyColID];
                dtStockSpecials.PrimaryKey = keys;

                dtStock = stockMethods.getTemplateStockItems(s, selectedTemplate, false);
                primaryKeyColID = dtStock.Columns.IndexOf("productCode_orig");
                DataColumn[] keys2 = new DataColumn[1];
                keys2[0] = dtStock.Columns[primaryKeyColID];
                dtStock.PrimaryKey = keys2;

                dtStockOriginal = dtStock.Copy();
                primaryKeyColID = dtStockOriginal.Columns.IndexOf("productCode_orig");
                DataColumn[] keys3 = new DataColumn[1];
                keys3[0] = dtStockOriginal.Columns[primaryKeyColID];
                dtStockOriginal.PrimaryKey = keys3;
            }
            catch (Exception ee)
            {
                throw;
            }

            DataTable dtReturn = new DataTable();

            //create column mappings
            fStatusUpdate.status = "Mapping Columns";
            foreach (TemplateColumns tc in selectedTemplate.templateColumns)
            {
                try
                {
                    if (!tc.isSpecialsExportColumn)
                    {
                        DataColumn dc = new DataColumn(tc.csvHeader);
                        dtReturn.Columns.Add(dc);
                    }
                }
                catch (Exception ee)
                {
                    //ignore, most likely the calculated column
                }
            }

            //do specials overrides
            DataTable dtNew = dtStock.Clone();
            bool match = false;
            DataRow drNew = dtStock.NewRow();
            foreach (DataRow dr in dtStock.Rows)
            {
                foreach (DataRow drSpecial in dtStockSpecials.Rows)
                {
                    if (dr["productCode_orig"].ToString() == drSpecial["productCode_orig"].ToString())
                    {
                        match = true;
                        drNew = drSpecial;
                    }
                }

                if (match && cbExportSpecials.Checked)
                {
                    //ensures that the export flag is carried
                    drNew["mustExport"] = dr["mustExport"];
                    drNew["overrideMargins"] = dr["overrideMargins"];
                    dtNew.ImportRow(drNew);
                }
                else
                {
                    dtNew.ImportRow(dr);
                }

                match = false;
            }

            dtStock = dtNew;

            DataColumn colCanExport = new DataColumn("Export", typeof(bool));
            dtReturn.Columns.Add(colCanExport);

            //setup rosslyn
            setup();
            int rowIndex = 0;
            int testCounter = 0;

            #region load the data into the export table - initial population
            foreach (DataRow dr in dtStock.Rows)
            {
                fStatusUpdate.status = "Preparing data " + (rowIndex + 1) + " : " + dtStock.Rows.Count;

                //grabs a new row
                DataRow newRow = dtReturn.NewRow();

                //loads the data into the new row
                foreach (TemplateColumns tc in selectedTemplate.templateColumns)
                {
                    if (!tc.isSpecialsExportColumn)
                    {
                        #region apply calculations if applicable
                        if (!string.IsNullOrWhiteSpace(tc.databaseColumn))
                        {
                            newRow[tc.csvHeader] = dr[tc.databaseColumn];
                        }
                        else
                        {
                            //this is a concatenated column
                            if (tc.calculationType == columnCalculationType.MERGE)
                            {
                                //merge column values according to formula
                                cal = tc.calculation;

                                //gets the database columns that must be concatted
                                string[] parts = cal.Split(new char[] { '+' });
                                for (int i = 0; i < parts.Length; i++)
                                {
                                    string newPart = parts[i].Trim();

                                    if (newPart != "[space]" & newPart != "")
                                    {
                                        newPart = newPart.Replace("]", "\"].ToString()");
                                        newPart = newPart.Replace("[", "dtStock.Rows[" + rowIndex + "][\"");
                                    }
                                    else
                                    {
                                        newPart = "\" \"";
                                    }

                                    parts[i] = newPart;
                                }

                                //generates the merge code
                                string code = "string s = \"\"; ";
                                for (int i = parts.Length - 1; i >= 0; i--)
                                {
                                    if (!string.IsNullOrEmpty(parts[i]))
                                    {
                                        code += "s = s.Insert(0, " + parts[i] + "); ";
                                    }
                                }
                                code += "s = s";

                                //runs the merge code
                                hostObject.rowIndex = rowIndex;
                                hostObject.calculation = code;
                                hostObject.dtStock = dtStock;
                                string mergeResults = dynamicCalculation();

                                newRow[tc.csvHeader] = mergeResults;
                            }
                        }
                        #endregion
                    }
                }

                //adds the row to the export table
                if (dtReturn.Columns.IndexOf("productCode_orig") == -1)
                {
                    dtReturn.Columns.Add("productCode_orig");
                }

                newRow["productCode_orig"] = dr["productCode_orig"];
                newRow["Export"] = dr["mustExport"];
                dtReturn.Rows.Add(newRow);

                rowIndex++;

                //to speed up Roslyn processing, refresh the objects after every 50 rows
                testCounter++;
                if (testCounter == 50)
                {
                    testCounter = 0;
                    setup();
                }
            }
            #endregion

            #region do post calculations
            ArrayList attrNames = attrMethods.getAttributeNames();

            string productCodeColumnName = "";
            bool runAttributesForThisColumn = false;
            foreach (TemplateColumns tc in selectedTemplate.templateColumns)
            {
                if (tc.databaseColumn.ToUpper() == "PRODUCTCODE" || tc.databaseColumn.ToUpper() == "SKUCODE")
                {
                    productCodeColumnName = tc.csvHeader;
                    runAttributesForThisColumn = tc.includeAttributes;
                }
            }
            #endregion

            #region do the attribute set calculations
            if (runAttributesForThisColumn)
            {
                foreach (string attributeName in attrNames)
                {
                    //get the parent items
                    List<AttributePropertyParent> parentProperties = attrMethods.getFullAttributeSet(s, attributeName);

                    foreach (AttributePropertyParent parentProperty in parentProperties)
                    {
                        DataRow parentRow = null;
                        string parentAttributeString = "";

                        //get the items in this attribute set
                        ArrayList properties = attrMethods.getAttributeSetProperties(s, parentProperty);

                        DataRow childRow = null;

                        foreach (AttributeProperty prop in properties)
                        {
                            foreach (DataRow dr in dtReturn.Rows)
                            {
                                string prodCode = dr[productCodeColumnName].ToString();

                                rowIndex = 0;
                                fStatusUpdate.status = "Doing post calculations " + (rowIndex + 1) + " : " + dtStock.Rows.Count;

                                if (prodCode == prop.stockCode || prodCode == prop.skuCode)
                                {
                                    childRow = dr;

                                    //find the parent row
                                    for (int k = 0; k < dtReturn.Rows.Count; k++)
                                    {
                                        if (dtReturn.Rows[k][productCodeColumnName].ToString() == parentProperty.stockCode || dtReturn.Rows[k][productCodeColumnName].ToString() == parentProperty.skuCode)
                                        {
                                            parentRow = dtReturn.Rows[k];
                                        }
                                    }

                                    //found a child match, add the attribute column to the export row if not there yet                        
                                    if (!dtReturn.Columns.Contains("attribute"))
                                    {
                                        dtReturn.Columns.Add(new DataColumn("attribute"));
                                    }

                                    //do the calculation on the child now
                                    string basePriceColumn = "";
                                    foreach (TemplateColumns tc in selectedTemplate.templateColumns)
                                    {
                                        if (tc.databaseColumn == parentProperty.basePriceColumn)
                                        {
                                            basePriceColumn = tc.csvHeader;
                                        }
                                    }

                                    //can the selected columns be parsed as a decimal? and other validations
                                    if (string.IsNullOrWhiteSpace(basePriceColumn)) { MessageBox.Show("Unable to complete export.  The selected base column (" + parentProperty.basePriceColumn + ") is not part of the export template.  Add this column to the export template, or change the base price column of the attribute set (" + attributeName + ")"); return; }

                                    decimal parseResult = 0;
                                    decimal.TryParse(childRow[basePriceColumn].ToString(), out parseResult);
                                    if (!decimal.TryParse(childRow[basePriceColumn].ToString(), out parseResult)) { MessageBox.Show("Unable to complete export.  The selected child attribute base column is not a decimal: Row: " + rowIndex.ToString() + " Column Name: " + basePriceColumn); return; };

                                    if (!decimal.TryParse(parentRow[basePriceColumn].ToString(), out parseResult)) { MessageBox.Show("Unable to complete export.  The selected parent sattribute base column is not a decimal: Row: " + rowIndex.ToString() + " Column Name: " + basePriceColumn); return; };

                                    #region generate the attribute string
                                    if (string.IsNullOrWhiteSpace(parentRow["attribute"].ToString()))
                                    {
                                        parentRow["attribute"] = attributeName + "," + parentProperty.propertyName;
                                    }

                                    decimal attributeValue = (decimal.Parse(childRow[basePriceColumn].ToString()) - decimal.Parse(parentRow[basePriceColumn].ToString()));
                                    string additionalConcat = "";
                                    if (attributeValue > 0) { additionalConcat = "+"; }
                                    parentAttributeString = prop.propertyName + "[" + additionalConcat + attributeValue.ToString() + "]";
                                    parentRow["attribute"] = parentRow["attribute"] + "," + parentAttributeString; ;
                                    #endregion
                                }
                            }
                        }
                    }
                }

                rowIndex++;
            }
            #endregion

            # region if inline specials export was selected, add the selected columns (if keep original data flag is false, add the original data)
            if (cbExportSpecials.Checked)
            {
                int primaryKeyColIDReturn = dtReturn.Columns.IndexOf("productCode_orig");
                DataColumn[] keys4 = new DataColumn[1];
                keys4[0] = dtReturn.Columns[primaryKeyColIDReturn];
                dtReturn.PrimaryKey = keys4;
                
                foreach (DataRow dr in dtStockSpecials.Rows)
                {
                    rowIndex = 0;
                    foreach (TemplateColumns tc in selectedTemplate.templateColumns)
                    {
                        rowIndex++;

                        fStatusUpdate.status = "Preparing specials data " + (rowIndex) + " : " + dtStockSpecials.Rows.Count;

                        DataRow drFoundStockRow = dtReturn.Rows.Find(dr["productCode_orig"].ToString());
                        int indexOfFoundRow = dtReturn.Rows.IndexOf(drFoundStockRow);

                        if (tc.isSpecialsExportColumn)
                        {
                            //add the specials export column to the datatable
                            if (dtReturn.Columns.IndexOf(tc.csvHeader) == -1)
                            {
                                dtReturn.Columns.Add(tc.csvHeader);
                            }

                            if (string.IsNullOrWhiteSpace(tc.calculation))
                            {
                                dtReturn.Rows[indexOfFoundRow][tc.csvHeader] = dr[tc.databaseColumn].ToString();
                            }
                            else
                            {
                                //do the calculation for this row
                                string productCode = drFoundStockRow["productCode_orig"].ToString();
                                SpecialsCalculation sc = tempMethods.getSpecialsCalculation(tc.calculation);
                                dtReturn.Rows[indexOfFoundRow][tc.csvHeader] = tempMethods.doSpecialsCalculation(sc, dr["productCode_orig"].ToString());
                            }
                        }

                        //replace with the original data
                        if (tc.calculationType == columnCalculationType.NONE)
                        {
                            if (tc.keepOriginalData)
                            {
                                DataRow drFound = dtStockOriginal.Rows.Find(drFoundStockRow["productCode_orig"].ToString());
                                if (drFound != null)
                                {
                                    dtReturn.Rows[indexOfFoundRow][tc.csvHeader] = drFound[tc.databaseColumn].ToString();
                                }
                            }
                            else
                            {

                                if (!string.IsNullOrWhiteSpace(dr[tc.databaseColumn].ToString()))
                                {
                                    dtReturn.Rows[indexOfFoundRow][tc.csvHeader] = dr[tc.databaseColumn].ToString();
                                }
                                else
                                {
                                    DataRow drFound = dtStockOriginal.Rows.Find(drFoundStockRow["productCode_orig"].ToString());
                                    dtReturn.Rows[indexOfFoundRow][tc.csvHeader] = drFound[tc.databaseColumn].ToString();
                                }
                            }
                        }
                    }
                }
            }
            #endregion

            dtExport = dtReturn.Copy();
            //remove the product code link from the return table
            dtExport.PrimaryKey = null;
            dtExport.Columns.Remove("productCode_orig");
        }

        private void applyExportDefaults(DataTable dtToFormat)
        {
            int rowIndex = 1;

            DataTable dtReturn = new DataTable();

            for (int i = 0; i < dtToFormat.Rows.Count; i++)
            {
                fStatusUpdate.status = "Applying defaults " + (rowIndex + 1) + " : " + dtStock.Rows.Count;

                foreach (TemplateColumns tc in selectedTemplate.templateColumns)
                {
                    if (!tc.isSpecialsExportColumn)
                    {
                        //if a default is set, and the column does not have data, apply default value
                        if (!string.IsNullOrEmpty(tc.exportDefault) & string.IsNullOrEmpty(dtToFormat.Rows[i][tc.csvHeader].ToString()))
                        {
                            dtToFormat.Rows[i][tc.csvHeader] = tc.exportDefault;
                        }
                    }
                }
                rowIndex++;
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

            List<Templates> templates = tempMethods.getSupplierTemplates(cbSuppliers.SelectedValue.ToString(), "EXPORT", true);
            if (templates.Count <= 0)
            {
                return;
            }

            bindingTemplates.DataSource = templates;
            cbTemplates.DataSource = bindingTemplates.DataSource;
            cbTemplates.DisplayMember = "templateName";
            cbTemplates.ValueMember = "templateID";
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
            engine = new ScriptEngine(new[] { hostObject.GetType().Assembly.Location, "System.Data", "System.Xml" });
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
            public DataTable dtStock
            {
                get;
                set;
            }
        }
        public string dynamicCalculation()
        {
            var code = hostObject.calculation + @";";
            return engine.Execute<string>(code, session);
        }
        #endregion

        #region excel stuff
        Excel.Application xlApp = new Excel.Application();
        Excel.Workbook xlWorkbook;
        private void openExcelFile()
        {
            object misValue = System.Reflection.Missing.Value;
            xlApp.Workbooks.Open(exportName);
            xlApp.Visible = true;
            xlApp.WorkbookBeforeClose += new Excel.AppEvents_WorkbookBeforeCloseEventHandler(xlApp_WorkbookBeforeClose);
        }

        void xlApp_WorkbookBeforeClose(Excel.Workbook Wb, ref bool Cancel)
        {
            //close excel
            try
            {
                xlApp.Quit();
            }
            catch (Exception ee)
            {
                //unable to quit xlApp, ignore and just release
            }

            releaseObject(xlApp);
        }

        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Unable to release the Object " + ex.ToString() + ". Not worry though, after a restart, all objects will be released.  So for now, you can ignore this warning :)");
            }
            finally
            {
                GC.Collect();
            }
        }

        public virtual Object ActiveSheet { get; set; }
        private void resolveHeaders()
        {
            try
            {
                int totalColumns = dtExport.Columns.Count;

                object misValue = System.Reflection.Missing.Value;

                xlWorkbook = xlApp.Workbooks.Open(exportName);

                Excel.Sheets sheets = xlWorkbook.Worksheets;
                Excel.Worksheet worksheet = (Excel.Worksheet)sheets.get_Item(1);

                //resolve @ sign to exclamation marks
                for (int i = 1; i < totalColumns + 1; i++)
                {
                    try
                    {
                        int asciiForA = 64;
                        char columnNumber = (char)(asciiForA + i);
                        Excel.Range range = worksheet.get_Range(columnNumber.ToString() + "1");
                        object v = range.Value;
                        string value = v.ToString().Replace("#", "!");
                        range.set_Value(misValue, value);
                    }
                    catch (Exception ee)
                    {
                        //ignore
                    }

                }
            }
            catch (Exception ee)
            {
                throw new Exception("Unable to resolve headers.  Either:  Ensure export file is closed, and retry, or Close this screen and retry if the excel file is closed: " + ee.Message);
            }
        }
        #endregion

        private void cbExportSpecials_CheckedChanged(object sender, EventArgs e)
        {
            if (!cbExportSpecials.Checked) { return; }

            //check if the supplier has specials active
            Supplier s = supMethods.getSupplier(cbSuppliers.SelectedValue.ToString());
            if (!s.specialsActive)
            {
                MessageBox.Show("This supplier does not have any specials active");
                return;
            }
        }
    }
}
