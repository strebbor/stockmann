using System;
using System.Windows.Forms;
using System.Data;
using System.IO;
using System.Diagnostics;
using System.Configuration;

namespace Stockman
{
    public partial class START : Form
    {
        #region form initializers
        frmSuppliers fSuppliers = null;
        frmTemplates_editImport fTemplates = null;
        frmTemplates_Create fTemplatesCreate = null;
        frmImportData fLoadData = null;
        frmTemplates_editExport fExportTemplates = null;
        frmExportData fExport = null;
        frmStockItems fStock = null;
        frmSystem fSystem = null;
        Stockman.Classes.databaseMethods db = new Classes.databaseMethods();
        #endregion

        #region properties
        string DBBackup_Directory
        {
            get
            {
                return Application.StartupPath + "\\DBBackup";
            }
        }
        string DBBackup_SavePath
        {
            get
            {
                return DBBackup_Directory + "\\" + DateTime.Now.ToLongDateString();
            }
        }
        string DBBackup_TempLocation
        {
            get
            {
                string path = AppFolder + "\\DBBackup\\" + DateTime.Now.ToLongDateString();

                return path;
            }
        }
        string AppFolder
        {
            get
            {
                string paht = Application.UserAppDataPath + "\\StockMann";

                if (!Directory.Exists(paht))
                {
                    Directory.CreateDirectory(paht);
                }
                return paht;
            }
        }
        #endregion

        #region startup and shutdown
        public static START _parent;
        public START()
        {
            InitializeComponent();

            _parent = this;
        }
        private void START_Load(object sender, EventArgs e)
        {
        }
        private void START_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = false;
        }
        #endregion

        #region open children
        private void manageSuppliersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild != null) { this.ActiveMdiChild.Close(); }

            fSuppliers = new frmSuppliers();
            fSuppliers.WindowState = FormWindowState.Maximized;
            fSuppliers.MdiParent = this;
            fSuppliers.Show();

            toolStripStatusLabel1.Text = "Supplier Management";
        }

        private void changeTemplatesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild != null) { this.ActiveMdiChild.Close(); }

            fTemplates = new frmTemplates_editImport();
            fTemplates.WindowState = FormWindowState.Maximized;
            fTemplates.MdiParent = this;
            fTemplates.Show();

            toolStripStatusLabel1.Text = "Update Import Templates";
        }

        private void createNewTemplateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild != null) { this.ActiveMdiChild.Close(); }

            fTemplatesCreate = new frmTemplates_Create();
            fTemplatesCreate.WindowState = FormWindowState.Maximized;
            fTemplatesCreate.MdiParent = this;
            fTemplatesCreate.Show();

            toolStripStatusLabel1.Text = "Create Templates";
        }

        private void importDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild != null) { this.ActiveMdiChild.Close(); }
            fLoadData = new frmImportData();
            fLoadData.WindowState = FormWindowState.Maximized;
            fLoadData.MdiParent = this;
            fLoadData.Show();

            toolStripStatusLabel1.Text = "Import Data";
        }

        private void stockItemsOverviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild != null) { this.ActiveMdiChild.Close(); }

            //fReporting = new frmReports();
            //fReporting.WindowState = FormWindowState.Maximized;
            //fReporting.MdiParent = this;
            //fReporting.Show();

            toolStripStatusLabel1.Text = "Stock Items Overview";
        }

        private void changeExportTemplateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild != null) { this.ActiveMdiChild.Close(); }

            fExportTemplates = new frmTemplates_editExport();
            fExportTemplates.WindowState = FormWindowState.Maximized;
            fExportTemplates.MdiParent = this;
            fExportTemplates.Show();

            toolStripStatusLabel1.Text = "Update export templates";

        }

        private void eToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild != null) { this.ActiveMdiChild.Close(); }

            fExport = new frmExportData();
            fExport.WindowState = FormWindowState.Maximized;
            fExport.MdiParent = this;
            fExport.Show();

            toolStripStatusLabel1.Text = "Export Data";
        }
        #endregion

        #region public methods and properties
        public void loadChildForm(Form formToLoad)
        {
            if (this.ActiveMdiChild != null) { this.ActiveMdiChild.Close(); }
            formToLoad.WindowState = FormWindowState.Maximized;
            formToLoad.MdiParent = this;
            formToLoad.Show();
        }
        #endregion

        private void viewStockItemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild != null) { this.ActiveMdiChild.Close(); }

            fStock = new frmStockItems();
            fStock.WindowState = FormWindowState.Maximized;
            fStock.MdiParent = this;
            fStock.Show();

            toolStripStatusLabel1.Text = "View Stock Items";
        }
       
        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild != null) { this.ActiveMdiChild.Close(); }

            fSystem = new frmSystem();
            fSystem.WindowState = FormWindowState.Maximized;
            fSystem.MdiParent = this;
            fSystem.Show();
            toolStripStatusLabel1.Text = "View System Settings";
        }

        private void suppliersToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //fReporting = new frmReports();
            //fReporting.WindowState = FormWindowState.Maximized;
            //fReporting.MdiParent = this;
            //fReporting.Show();
            //toolStripStatusLabel1.Text = "Reporting";
        }

        private void editorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //fReportEditor = new frmReportEditor();
            //fReportEditor.WindowState = FormWindowState.Maximized;
            //fReportEditor.MdiParent = this;
            //fReportEditor.Show();
            //toolStripStatusLabel1.Text = "Report Editor";
        }
    }
}