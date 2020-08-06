using System;
using System.Data;
using System.Windows.Forms;
using Stockman.Classes;

namespace Stockman
{
    public partial class frmTemplates_Create : FormBase
    {
        #region initialize classes
        supplierMethods supMethods = new supplierMethods();
        templateMethods tempMethods = new templateMethods();
        #endregion

        #region startup and shutdown
        public frmTemplates_Create()
        {
            InitializeComponent();
        }
        private void frmTemplatesCreate_Load(object sender, EventArgs e)
        {           
            //get suppliers
            DataTable dt = new DataTable();
            try
            {
                dt = supMethods.getSuppliers();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
                return;
            }
            //load suppliers
            cbSuppliers.DataSource = dt;
            cbSuppliers.ValueMember = "supplierID";
            cbSuppliers.DisplayMember = "supplierName";
        }
        #endregion

        #region events
        private void button2_Click(object sender, EventArgs e)
        {
            if (!validateInputs(panel1))
            {
                return;
            }

            //create the template
            string templateID = string.Empty;
            try
            {
                templateID = tempMethods.createTemplate(cbSuppliers.SelectedValue.ToString(), txtTemplateName.Text, cbDirection.Text);
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
                return;
            }

            //open the template editor child form
            switch (cbDirection.Text)
            {
                case "IMPORT":
                    {
                        frmTemplates_editImport f = new frmTemplates_editImport();
                        f.supplierID = cbSuppliers.SelectedValue.ToString();
                        f.templateID = templateID;
                        START._parent.loadChildForm(f);
                    } break;
                case "EXPORT":
                    {
                        frmTemplates_editExport f = new frmTemplates_editExport();
                        f.supplierID = cbSuppliers.SelectedValue.ToString();
                        f.templateID = templateID;
                        START._parent.loadChildForm(f);
                    } break;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //reset inputs
            txtTemplateName.Text = "";
            cbSuppliers.SelectedIndex = 0;
        }
        #endregion

        #region methods
        #endregion

        #region menus
        #endregion
    }
}
