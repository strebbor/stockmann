using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Stockman.Classes;
using System.Configuration;
using System.IO;

namespace Stockman
{
    public partial class frmSystem : Form
    {
        string StartupPath
        {
            get
            {
                string paht = Application.StartupPath;
                return paht;
            }
        }
        databaseMethods db = new databaseMethods();

        public frmSystem()
        {
            InitializeComponent();

            loadSettings();
        }

        private void loadSettings()
        {
            string connString = "";
            string makeBackups = "";
            string tolerance = "";

            try
            {
                connString = db.readAppSetting("StockmannConfig");
                makeBackups = db.readAppSetting("makeOnStartBackups");
                tolerance = db.readAppSetting("levensteinTolerance");
            }
            catch (Exception ee)
            {
            }

            txtConnectionString.Text = connString;
            if (makeBackups == "1")
            {
                cbBackups.Checked = true;
            }
            txtTolerance.Text = tolerance;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (db.testConnection(txtConnectionString.Text))
            {
                MessageBox.Show("Connection successful");
            }
            else
            {
                MessageBox.Show("Connection failed");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you wish to save these settings?", "Save Confirmation", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                int res;
                if (int.TryParse(txtTolerance.Text, out res))
                {
                    db.writeAppSetting("levensteinTolerance", txtTolerance.Text);
                }
                else
                {
                    MessageBox.Show("Unable to save Levensthein Tolerance, must be a number");
                    return;
                }

                db.writeAppSetting("StockmannConfig", txtConnectionString.Text);
                if (cbBackups.Checked)
                {
                    db.writeAppSetting("makeOnStartBackups", "1");
                }
                else
                {
                    db.writeAppSetting("makeOnStartBackups", "0");
                }

                MessageBox.Show("Settings saved");
                Close();
            }
        }
    }
}
