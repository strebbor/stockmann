namespace Stockman
{
    partial class frmImportData
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.aLLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sAMEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dIFFERENTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nEWToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showNotImportedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.acceptAllChangesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deselectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bindingTemplates = new System.Windows.Forms.BindingSource(this.components);
            this.bindingImportData = new System.Windows.Forms.BindingSource(this.components);
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.pnlImported = new System.Windows.Forms.Panel();
            this.dgvDatabase = new System.Windows.Forms.DataGridView();
            this.pnlLevenstein = new System.Windows.Forms.Panel();
            this.lblLevenSteinCode = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.lbPossibleDuplicates = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.lblCalculation = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.gvImportData = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.cbCsvColumn = new System.Windows.Forms.ComboBox();
            this.cbImportType = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cboDelimeter = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.cbTemplates = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbSuppliers = new System.Windows.Forms.ComboBox();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingTemplates)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingImportData)).BeginInit();
            this.pnlImported.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatabase)).BeginInit();
            this.pnlLevenstein.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvImportData)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aLLToolStripMenuItem,
            this.sAMEToolStripMenuItem,
            this.dIFFERENTToolStripMenuItem,
            this.nEWToolStripMenuItem,
            this.showNotImportedToolStripMenuItem,
            this.acceptAllChangesToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(177, 136);
            // 
            // aLLToolStripMenuItem
            // 
            this.aLLToolStripMenuItem.Name = "aLLToolStripMenuItem";
            this.aLLToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.aLLToolStripMenuItem.Text = "Show all";
            this.aLLToolStripMenuItem.Click += new System.EventHandler(this.aLLToolStripMenuItem_Click);
            // 
            // sAMEToolStripMenuItem
            // 
            this.sAMEToolStripMenuItem.Name = "sAMEToolStripMenuItem";
            this.sAMEToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.sAMEToolStripMenuItem.Text = "Show same";
            this.sAMEToolStripMenuItem.Click += new System.EventHandler(this.sAMEToolStripMenuItem_Click);
            // 
            // dIFFERENTToolStripMenuItem
            // 
            this.dIFFERENTToolStripMenuItem.Name = "dIFFERENTToolStripMenuItem";
            this.dIFFERENTToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.dIFFERENTToolStripMenuItem.Text = "Show update";
            this.dIFFERENTToolStripMenuItem.Click += new System.EventHandler(this.dIFFERENTToolStripMenuItem_Click);
            // 
            // nEWToolStripMenuItem
            // 
            this.nEWToolStripMenuItem.Name = "nEWToolStripMenuItem";
            this.nEWToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.nEWToolStripMenuItem.Text = "Show new";
            this.nEWToolStripMenuItem.Click += new System.EventHandler(this.nEWToolStripMenuItem_Click);
            // 
            // showNotImportedToolStripMenuItem
            // 
            this.showNotImportedToolStripMenuItem.Name = "showNotImportedToolStripMenuItem";
            this.showNotImportedToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.showNotImportedToolStripMenuItem.Text = "Show not imported";
            this.showNotImportedToolStripMenuItem.Click += new System.EventHandler(this.showNotImportedToolStripMenuItem_Click);
            // 
            // acceptAllChangesToolStripMenuItem
            // 
            this.acceptAllChangesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectAllToolStripMenuItem,
            this.deselectAllToolStripMenuItem});
            this.acceptAllChangesToolStripMenuItem.Name = "acceptAllChangesToolStripMenuItem";
            this.acceptAllChangesToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.acceptAllChangesToolStripMenuItem.Text = "Changes";
            // 
            // selectAllToolStripMenuItem
            // 
            this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
            this.selectAllToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.selectAllToolStripMenuItem.Text = "Select All";
            this.selectAllToolStripMenuItem.Click += new System.EventHandler(this.selectAllToolStripMenuItem_Click);
            // 
            // deselectAllToolStripMenuItem
            // 
            this.deselectAllToolStripMenuItem.Name = "deselectAllToolStripMenuItem";
            this.deselectAllToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.deselectAllToolStripMenuItem.Text = "Deselect All";
            this.deselectAllToolStripMenuItem.Click += new System.EventHandler(this.deselectAllToolStripMenuItem_Click);
            // 
            // bindingTemplates
            // 
            this.bindingTemplates.AllowNew = false;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoImport);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // pnlImported
            // 
            this.pnlImported.Controls.Add(this.dgvDatabase);
            this.pnlImported.Controls.Add(this.pnlLevenstein);
            this.pnlImported.Controls.Add(this.button1);
            this.pnlImported.Controls.Add(this.button3);
            this.pnlImported.Controls.Add(this.lblCalculation);
            this.pnlImported.Controls.Add(this.button4);
            this.pnlImported.Controls.Add(this.gvImportData);
            this.pnlImported.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlImported.Location = new System.Drawing.Point(0, 133);
            this.pnlImported.Margin = new System.Windows.Forms.Padding(4);
            this.pnlImported.Name = "pnlImported";
            this.pnlImported.Size = new System.Drawing.Size(1074, 529);
            this.pnlImported.TabIndex = 6;
            this.pnlImported.Visible = false;
            // 
            // dgvDatabase
            // 
            this.dgvDatabase.AllowUserToAddRows = false;
            this.dgvDatabase.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatabase.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvDatabase.Location = new System.Drawing.Point(1, 44);
            this.dgvDatabase.Margin = new System.Windows.Forms.Padding(4);
            this.dgvDatabase.Name = "dgvDatabase";
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvDatabase.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDatabase.Size = new System.Drawing.Size(1074, 464);
            this.dgvDatabase.TabIndex = 2;
            this.dgvDatabase.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDatabase_CellClick);
            this.dgvDatabase.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDatabase_CellDoubleClick);
            this.dgvDatabase.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDatabase_CellEndEdit);
            this.dgvDatabase.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvDatabase_ColumnHeaderMouseClick);
            this.dgvDatabase.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvDatabase_DataError);
            // 
            // pnlLevenstein
            // 
            this.pnlLevenstein.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pnlLevenstein.Controls.Add(this.lblLevenSteinCode);
            this.pnlLevenstein.Controls.Add(this.button5);
            this.pnlLevenstein.Controls.Add(this.lbPossibleDuplicates);
            this.pnlLevenstein.Controls.Add(this.label4);
            this.pnlLevenstein.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlLevenstein.Location = new System.Drawing.Point(0, 457);
            this.pnlLevenstein.Name = "pnlLevenstein";
            this.pnlLevenstein.Size = new System.Drawing.Size(1074, 72);
            this.pnlLevenstein.TabIndex = 7;
            this.pnlLevenstein.Visible = false;
            // 
            // lblLevenSteinCode
            // 
            this.lblLevenSteinCode.AutoSize = true;
            this.lblLevenSteinCode.Location = new System.Drawing.Point(500, 15);
            this.lblLevenSteinCode.Name = "lblLevenSteinCode";
            this.lblLevenSteinCode.Size = new System.Drawing.Size(46, 17);
            this.lblLevenSteinCode.TabIndex = 3;
            this.lblLevenSteinCode.Text = "label5";
            this.lblLevenSteinCode.DoubleClick += new System.EventHandler(this.lblLevenSteinCode_DoubleClick);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(928, 15);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(117, 35);
            this.button5.TabIndex = 2;
            this.button5.Text = "Close";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // lbPossibleDuplicates
            // 
            this.lbPossibleDuplicates.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbPossibleDuplicates.FormattingEnabled = true;
            this.lbPossibleDuplicates.ItemHeight = 16;
            this.lbPossibleDuplicates.Location = new System.Drawing.Point(0, 0);
            this.lbPossibleDuplicates.Name = "lbPossibleDuplicates";
            this.lbPossibleDuplicates.Size = new System.Drawing.Size(276, 72);
            this.lbPossibleDuplicates.TabIndex = 1;
            this.lbPossibleDuplicates.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lbPossibleDuplicates_MouseDoubleClick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(302, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(175, 17);
            this.label4.TabIndex = 0;
            this.label4.Text = "Possible Duplicates for";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(928, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(117, 35);
            this.button1.TabIndex = 6;
            this.button1.Text = "Cancel";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(788, 5);
            this.button3.Margin = new System.Windows.Forms.Padding(4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(133, 35);
            this.button3.TabIndex = 3;
            this.button3.Text = "Save to database";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // lblCalculation
            // 
            this.lblCalculation.AutoSize = true;
            this.lblCalculation.Location = new System.Drawing.Point(4, 23);
            this.lblCalculation.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCalculation.Name = "lblCalculation";
            this.lblCalculation.Size = new System.Drawing.Size(20, 17);
            this.lblCalculation.TabIndex = 5;
            this.lblCalculation.Text = "...";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(663, 5);
            this.button4.Margin = new System.Windows.Forms.Padding(4);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(117, 35);
            this.button4.TabIndex = 4;
            this.button4.Text = "Recalc";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Visible = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // gvImportData
            // 
            this.gvImportData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvImportData.Dock = System.Windows.Forms.DockStyle.Top;
            this.gvImportData.Location = new System.Drawing.Point(0, 0);
            this.gvImportData.Margin = new System.Windows.Forms.Padding(4);
            this.gvImportData.Name = "gvImportData";
            this.gvImportData.Size = new System.Drawing.Size(1074, 10);
            this.gvImportData.TabIndex = 1;
            this.gvImportData.Visible = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.cbCsvColumn);
            this.panel1.Controls.Add(this.cbImportType);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.cboDelimeter);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.cbTemplates);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cbSuppliers);
            this.panel1.Controls.Add(this.txtFilePath);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1074, 133);
            this.panel1.TabIndex = 0;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(17, 78);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(128, 17);
            this.label8.TabIndex = 20;
            this.label8.Text = "CSV Match Column";
            // 
            // cbCsvColumn
            // 
            this.cbCsvColumn.FormattingEnabled = true;
            this.cbCsvColumn.Location = new System.Drawing.Point(145, 75);
            this.cbCsvColumn.Name = "cbCsvColumn";
            this.cbCsvColumn.Size = new System.Drawing.Size(372, 24);
            this.cbCsvColumn.TabIndex = 19;
            this.cbCsvColumn.SelectedIndexChanged += new System.EventHandler(this.cbCsvColumn_SelectedIndexChanged);
            // 
            // cbImportType
            // 
            this.cbImportType.FormattingEnabled = true;
            this.cbImportType.Items.AddRange(new object[] {
            "Regular",
            "Regular + Specials Column"});
            this.cbImportType.Location = new System.Drawing.Point(663, 13);
            this.cbImportType.Name = "cbImportType";
            this.cbImportType.Size = new System.Drawing.Size(372, 24);
            this.cbImportType.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(535, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 17);
            this.label6.TabIndex = 12;
            this.label6.Text = "Import Type";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(767, 91);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 17);
            this.label5.TabIndex = 11;
            this.label5.Text = "Delimeter";
            // 
            // cboDelimeter
            // 
            this.cboDelimeter.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboDelimeter.FormattingEnabled = true;
            this.cboDelimeter.Items.AddRange(new object[] {
            ",",
            ";",
            "|",
            ":",
            "\""});
            this.cboDelimeter.Location = new System.Drawing.Point(841, 75);
            this.cboDelimeter.Name = "cboDelimeter";
            this.cboDelimeter.Size = new System.Drawing.Size(43, 39);
            this.cboDelimeter.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 19);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 17);
            this.label3.TabIndex = 9;
            this.label3.Text = "Select File";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(918, 82);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(117, 35);
            this.button2.TabIndex = 8;
            this.button2.Text = "Load";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // cbTemplates
            // 
            this.cbTemplates.DisplayMember = "templateID";
            this.cbTemplates.FormattingEnabled = true;
            this.cbTemplates.Location = new System.Drawing.Point(663, 44);
            this.cbTemplates.Margin = new System.Windows.Forms.Padding(4);
            this.cbTemplates.Name = "cbTemplates";
            this.cbTemplates.Size = new System.Drawing.Size(372, 24);
            this.cbTemplates.TabIndex = 7;
            this.cbTemplates.SelectionChangeCommitted += new System.EventHandler(this.cbTemplates_SelectionChangeCommitted);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(535, 51);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "Select Template";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 51);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Select Supplier";
            // 
            // cbSuppliers
            // 
            this.cbSuppliers.FormattingEnabled = true;
            this.cbSuppliers.Location = new System.Drawing.Point(145, 44);
            this.cbSuppliers.Margin = new System.Windows.Forms.Padding(4);
            this.cbSuppliers.Name = "cbSuppliers";
            this.cbSuppliers.Size = new System.Drawing.Size(372, 24);
            this.cbSuppliers.TabIndex = 5;
            this.cbSuppliers.SelectionChangeCommitted += new System.EventHandler(this.cbSuppliers_SelectionChangeCommitted);
            // 
            // txtFilePath
            // 
            this.txtFilePath.Location = new System.Drawing.Point(145, 13);
            this.txtFilePath.Margin = new System.Windows.Forms.Padding(4);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.Size = new System.Drawing.Size(372, 23);
            this.txtFilePath.TabIndex = 1;
            this.txtFilePath.Click += new System.EventHandler(this.txtFilePath_Click);
            // 
            // frmImportData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1074, 662);
            this.Controls.Add(this.pnlImported);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmImportData";
            this.Text = "Import Data";
            this.Load += new System.EventHandler(this.frmImportData_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindingTemplates)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingImportData)).EndInit();
            this.pnlImported.ResumeLayout(false);
            this.pnlImported.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatabase)).EndInit();
            this.pnlLevenstein.ResumeLayout(false);
            this.pnlLevenstein.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvImportData)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gvImportData;
        private System.Windows.Forms.TextBox txtFilePath;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox cbTemplates;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbSuppliers;
        private System.Windows.Forms.BindingSource bindingTemplates;
        private System.Windows.Forms.BindingSource bindingImportData;
        private System.Windows.Forms.DataGridView dgvDatabase;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem sAMEToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dIFFERENTToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nEWToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aLLToolStripMenuItem;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label lblCalculation;
        private System.Windows.Forms.Panel pnlImported;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStripMenuItem acceptAllChangesToolStripMenuItem;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Panel pnlLevenstein;
        private System.Windows.Forms.ListBox lbPossibleDuplicates;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label lblLevenSteinCode;
        private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deselectAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showNotImportedToolStripMenuItem;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboDelimeter;
        private System.Windows.Forms.ComboBox cbImportType;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbCsvColumn;
    }
}