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
    public partial class frmReportEditor : FormBase
    {
        #region startup and shutdown
        public frmReportEditor()
        {
            InitializeComponent();
        }
        private void frmReportEditor_Load(object sender, EventArgs e)
        {
            loadTableNames();
        }

        private void loadTableNames()
        {
            var values = Enum.GetValues(typeof(reportMethods.ReportTables));

            foreach (object name in values)
            {
                cboTables.Items.Add(name.ToString());
            }
        }

        #endregion

        #region initialize classes
        reportMethods repMethods = new reportMethods();
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dtColumns = repMethods.getTableColumns(cboTables.Text);

           for (int i = 0; i < dtColumns.Rows.Count; i++)               
            {
                addColumnToolStripMenuItem.DropDownItems.Add((dtColumns.Rows[i]["COLUMN_NAME"].ToString()));
            }
        }

        private void addColumnToolStripMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            string columnName = e.ClickedItem.Text;           
        }

        private void createColumn()
        {

        }

        #region events
        #endregion

        #region methods

        #endregion
    }
}
