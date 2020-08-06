using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Stockman
{
    public partial class frmStatus : Form
    {
        public frmStatus()
        {
            InitializeComponent();
        }

        public string status
        {
            set
            {                
                lblStatus.Text = value.ToString();
                lblStatus.Refresh();
            }
        }
        public string error
        {
            set
            {
                lblError.Visible = true;
                lblError.Text = value.ToString();                
            }
            get
            {
                return lblError.Text;
            }
        }
        private bool _show = false;
        public bool showClose
        {
            get
            {
                return _show;
            }
            set
            {
                lblStatus.Refresh();
                linkLabel1.Visible = value;
                _show = value;              
            }
        }

        private void frmStatus_Load(object sender, EventArgs e)
        {
            linkLabel1.Visible = showClose;           
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }
    }
}
