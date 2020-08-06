using System;
using System.ComponentModel;
using System.Windows.Forms;
using Stockman.Entities;
using Stockman.Classes;
using RKLib.ExportData;
using System.Data;
using Excel = Microsoft.Office.Interop.Excel;

namespace Stockman
{
    public partial class frmReports : FormBase
    {
        #region startup and shutdown
        public frmReports()
        {
            InitializeComponent();
        }
        private void frmReports_Load(object sender, EventArgs e)
        {
        }
        #endregion

        #region initialize classes
        supplierMethods supMethods = new supplierMethods();
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            dtExport = supMethods.getSuppliers();
            dgvReportPreview.DataSource = dtExport;
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtFilePath.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        public DataTable dtExport = new DataTable();
        string exportName = "";
        private void button2_Click(object sender, EventArgs e)
        {
            //validations
            if (!validateInputs(panel1))
            {
                return;
            }
            
            dtExport = supMethods.getSuppliers();
            dgvReportPreview.DataSource = dtExport;

            Export objExport = new Export("Win");
            try
            {
                exportName = txtFilePath.Text + "\\Suppliers List.xls";
                objExport.ExportDetails(dtExport, Export.ExportFormat.Excel, exportName);
                MessageBox.Show("Supplier list exported to:" + exportName);
            }
            catch (Exception ee)
            {               
                MessageBox.Show(ee.Message);
                return;
            }

            lblOpen.Visible = true;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {           
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

        #region events
        #endregion

        #region methods

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
    }
}
