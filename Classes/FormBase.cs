using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;
using System.Reflection;
using System.Collections;

namespace Stockman.Classes
{
    public class FormBase : Form
    {
        //instantiate required child classes
        public Stockman.Classes.InputValidations validations = new Classes.InputValidations();

        #region base items
        private Form _f;
        public Form form
        {
            get
            { return _f; }
            set
            {
                _f = value;
                cols = (System.Windows.Forms.Control.ControlCollection)_f.Controls;
                _f.Width = 1100;
                _f.Height = 800;
            }
        }
        public System.Windows.Forms.Control.ControlCollection cols;
        #endregion


        public FormBase()
        {
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            e.Cancel = false;
        }

        ArrayList _stockMetaColumns = new ArrayList();
        public ArrayList stockMetaColumns
        {
            get
            {
                ArrayList _stockMetaColumns = new ArrayList();
                _stockMetaColumns.Add("stockID");
                _stockMetaColumns.Add("supplierID");
                _stockMetaColumns.Add("uniqueKey");
                _stockMetaColumns.Add("overrideMargins");
                _stockMetaColumns.Add("mustExport");
                _stockMetaColumns.Add("active");
                _stockMetaColumns.Add("productCode_Orig");
                _stockMetaColumns.Add("skuCode");

                return _stockMetaColumns;
            }
        }


        #region startup and initialize
        #endregion

        #region initialize classes
        #endregion

        #region properties
        #endregion

        #region events
        #endregion

        #region methods
        #endregion

        #region menus
        #endregion

        #region validations
        public bool validateInputs(Panel pnl)
        {
            bool valid = true;

            foreach (Control c in pnl.Controls)
            {
                switch (c.GetType().Name)
                {
                    case "TextBox":
                        {
                            TextBox txt = (TextBox)c;
                            if (string.IsNullOrWhiteSpace(txt.Text) & txt.CausesValidation)
                            {
                                txt.BackColor = System.Drawing.Color.Yellow;
                                txt.TextChanged += new EventHandler(textBox_TextChanged);
                                valid = false;
                            }

                        } break;
                    case "ComboBox":
                        {
                            ComboBox cb = (ComboBox)c;
                            if (cb.SelectedItem == null & cb.CausesValidation)
                            {
                                cb.BackColor = System.Drawing.Color.Yellow;
                                cb.TextChanged += new EventHandler(combobox_TextChanged);
                                valid = false;
                            }
                        } break;
                }
            }

            return valid;
        }
        public bool resetValidations(Panel pnl)
        {
            bool valid = true;

            foreach (Control c in pnl.Controls)
            {
                switch (c.GetType().Name)
                {
                    case "TextBox":
                        {
                            TextBox txt = (TextBox)c;

                            txt.BackColor = System.Drawing.Color.Empty;
                            txt.TextChanged += new EventHandler(textBox_TextChanged);
                        }
                        break;
                    case "ComboBox":
                        {
                            ComboBox cb = (ComboBox)c;
                            cb.BackColor = System.Drawing.Color.Empty;
                            cb.TextChanged += new EventHandler(combobox_TextChanged);
                        }
                        break;
                }
            }

            return valid;
        }

        void textBox_TextChanged(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;
            txt.BackColor = System.Drawing.Color.Empty;
        }
        void combobox_TextChanged(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            cb.BackColor = System.Drawing.Color.Empty;
        }
        #endregion
    }
}