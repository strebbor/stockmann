namespace Stockman
{
    partial class frmExportData
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.bindingTemplates = new System.Windows.Forms.BindingSource(this.components);
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.gvImportData = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbExportSpecials = new System.Windows.Forms.CheckBox();
            this.pnlExportedOptions = new System.Windows.Forms.Panel();
            this.linkLabel3 = new System.Windows.Forms.LinkLabel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.cbExportFormat = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.cbTemplates = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbSuppliers = new System.Windows.Forms.ComboBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.bindingTemplates)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvImportData)).BeginInit();
            this.panel1.SuspendLayout();
            this.pnlExportedOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // bindingTemplates
            // 
            this.bindingTemplates.AllowNew = false;
            // 
            // gvImportData
            // 
            this.gvImportData.AllowUserToAddRows = false;
            this.gvImportData.AllowUserToDeleteRows = false;
            this.gvImportData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvImportData.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gvImportData.Location = new System.Drawing.Point(0, 230);
            this.gvImportData.Margin = new System.Windows.Forms.Padding(4);
            this.gvImportData.Name = "gvImportData";
            this.gvImportData.Size = new System.Drawing.Size(1074, 432);
            this.gvImportData.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.cbExportSpecials);
            this.panel1.Controls.Add(this.pnlExportedOptions);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.txtFilePath);
            this.panel1.Controls.Add(this.cbExportFormat);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.cbTemplates);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cbSuppliers);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1074, 222);
            this.panel1.TabIndex = 1;
            // 
            // cbExportSpecials
            // 
            this.cbExportSpecials.AutoSize = true;
            this.cbExportSpecials.Location = new System.Drawing.Point(690, 28);
            this.cbExportSpecials.Name = "cbExportSpecials";
            this.cbExportSpecials.Size = new System.Drawing.Size(139, 21);
            this.cbExportSpecials.TabIndex = 19;
            this.cbExportSpecials.Text = "Specials Override";
            this.cbExportSpecials.UseVisualStyleBackColor = true;
            this.cbExportSpecials.CheckedChanged += new System.EventHandler(this.cbExportSpecials_CheckedChanged);
            // 
            // pnlExportedOptions
            // 
            this.pnlExportedOptions.Controls.Add(this.linkLabel3);
            this.pnlExportedOptions.Controls.Add(this.linkLabel1);
            this.pnlExportedOptions.Location = new System.Drawing.Point(900, 120);
            this.pnlExportedOptions.Name = "pnlExportedOptions";
            this.pnlExportedOptions.Size = new System.Drawing.Size(169, 97);
            this.pnlExportedOptions.TabIndex = 18;
            this.pnlExportedOptions.Visible = false;
            // 
            // linkLabel3
            // 
            this.linkLabel3.AutoSize = true;
            this.linkLabel3.Location = new System.Drawing.Point(28, 14);
            this.linkLabel3.Name = "linkLabel3";
            this.linkLabel3.Size = new System.Drawing.Size(126, 17);
            this.linkLabel3.TabIndex = 18;
            this.linkLabel3.TabStop = true;
            this.linkLabel3.Text = "Resolve and Open";
            this.linkLabel3.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel3_LinkClicked);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(28, 51);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(123, 17);
            this.linkLabel1.TabIndex = 16;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Resolve and Save";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 168);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 17);
            this.label4.TabIndex = 15;
            this.label4.Text = "Export Location";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(943, 25);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(117, 35);
            this.button1.TabIndex = 14;
            this.button1.Text = "Preview";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtFilePath
            // 
            this.txtFilePath.Location = new System.Drawing.Point(164, 165);
            this.txtFilePath.Margin = new System.Windows.Forms.Padding(4);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.Size = new System.Drawing.Size(508, 23);
            this.txtFilePath.TabIndex = 11;
            this.txtFilePath.Click += new System.EventHandler(this.txtFilePath_Click);
            // 
            // cbExportFormat
            // 
            this.cbExportFormat.FormattingEnabled = true;
            this.cbExportFormat.Items.AddRange(new object[] {
            "XLSX",
            "CSV",
            "IIF"});
            this.cbExportFormat.Location = new System.Drawing.Point(164, 117);
            this.cbExportFormat.Margin = new System.Windows.Forms.Padding(4);
            this.cbExportFormat.Name = "cbExportFormat";
            this.cbExportFormat.Size = new System.Drawing.Size(508, 24);
            this.cbExportFormat.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 120);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 17);
            this.label3.TabIndex = 9;
            this.label3.Text = "Export Format";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(943, 74);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(117, 35);
            this.button2.TabIndex = 8;
            this.button2.Text = "Export Data";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // cbTemplates
            // 
            this.cbTemplates.DisplayMember = "templateID";
            this.cbTemplates.FormattingEnabled = true;
            this.cbTemplates.Location = new System.Drawing.Point(164, 71);
            this.cbTemplates.Margin = new System.Windows.Forms.Padding(4);
            this.cbTemplates.Name = "cbTemplates";
            this.cbTemplates.Size = new System.Drawing.Size(508, 24);
            this.cbTemplates.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 74);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "Select Template";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 28);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Select Supplier";
            // 
            // cbSuppliers
            // 
            this.cbSuppliers.FormattingEnabled = true;
            this.cbSuppliers.Location = new System.Drawing.Point(164, 25);
            this.cbSuppliers.Margin = new System.Windows.Forms.Padding(4);
            this.cbSuppliers.Name = "cbSuppliers";
            this.cbSuppliers.Size = new System.Drawing.Size(508, 24);
            this.cbSuppliers.TabIndex = 5;
            this.cbSuppliers.SelectionChangeCommitted += new System.EventHandler(this.cbSuppliers_SelectionChangeCommitted);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // frmExportData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1074, 662);
            this.Controls.Add(this.gvImportData);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmExportData";
            this.Text = "Export Data";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmExportData_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmExportData_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.bindingTemplates)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvImportData)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlExportedOptions.ResumeLayout(false);
            this.pnlExportedOptions.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox cbTemplates;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbSuppliers;
        private System.Windows.Forms.BindingSource bindingTemplates;
        private System.Windows.Forms.ComboBox cbExportFormat;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView gvImportData;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtFilePath;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Panel pnlExportedOptions;
        private System.Windows.Forms.LinkLabel linkLabel3;
        private System.Windows.Forms.CheckBox cbExportSpecials;
    }
}