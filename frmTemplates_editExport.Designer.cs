namespace Stockman
{
    partial class frmTemplates_editExport
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
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.insertNewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moveUpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moveDownToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showSpecialsExportColumnsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlEditor = new System.Windows.Forms.Panel();
            this.gvTemplates = new System.Windows.Forms.DataGridView();
            this.pnlEditColumn = new System.Windows.Forms.Panel();
            this.cbKeepOriginalData = new System.Windows.Forms.CheckBox();
            this.pnlSpecialsCalculation = new System.Windows.Forms.Panel();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.txtSpecialsCalculation = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cbFormatting = new System.Windows.Forms.ComboBox();
            this.cbSpecialsExportColumn = new System.Windows.Forms.CheckBox();
            this.pnlRegularOptions = new System.Windows.Forms.Panel();
            this.lblSpecialsOverrideColumn = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.cbIncludeAttributes = new System.Windows.Forms.CheckBox();
            this.txtCalculation = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtExportDefault = new System.Windows.Forms.TextBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label9 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.cbColumnNames = new System.Windows.Forms.ComboBox();
            this.lblTemplateColumnID = new System.Windows.Forms.Label();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.txtCSVHeader = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pnlMakeCopy = new System.Windows.Forms.Panel();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.cbCopyToSupplier = new System.Windows.Forms.ComboBox();
            this.pnlSelect = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button7 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.cbTemplates = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbSuppliers = new System.Windows.Forms.ComboBox();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.bindingTemplates)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.pnlEditor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvTemplates)).BeginInit();
            this.pnlEditColumn.SuspendLayout();
            this.pnlSpecialsCalculation.SuspendLayout();
            this.pnlRegularOptions.SuspendLayout();
            this.panel2.SuspendLayout();
            this.pnlMakeCopy.SuspendLayout();
            this.pnlSelect.SuspendLayout();
            this.SuspendLayout();
            // 
            // bindingTemplates
            // 
            this.bindingTemplates.AllowNew = false;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.insertNewToolStripMenuItem,
            this.removeToolStripMenuItem,
            this.moveUpToolStripMenuItem,
            this.moveDownToolStripMenuItem,
            this.showSpecialsExportColumnsToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(266, 114);
            // 
            // insertNewToolStripMenuItem
            // 
            this.insertNewToolStripMenuItem.Name = "insertNewToolStripMenuItem";
            this.insertNewToolStripMenuItem.Size = new System.Drawing.Size(265, 22);
            this.insertNewToolStripMenuItem.Text = "Insert Column";
            this.insertNewToolStripMenuItem.Click += new System.EventHandler(this.insertNewToolStripMenuItem_Click);
            // 
            // removeToolStripMenuItem
            // 
            this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            this.removeToolStripMenuItem.Size = new System.Drawing.Size(265, 22);
            this.removeToolStripMenuItem.Text = "Remove";
            this.removeToolStripMenuItem.Click += new System.EventHandler(this.removeToolStripMenuItem_Click);
            // 
            // moveUpToolStripMenuItem
            // 
            this.moveUpToolStripMenuItem.Name = "moveUpToolStripMenuItem";
            this.moveUpToolStripMenuItem.Size = new System.Drawing.Size(265, 22);
            this.moveUpToolStripMenuItem.Text = "Move Up";
            this.moveUpToolStripMenuItem.Click += new System.EventHandler(this.moveUpToolStripMenuItem_Click);
            // 
            // moveDownToolStripMenuItem
            // 
            this.moveDownToolStripMenuItem.Name = "moveDownToolStripMenuItem";
            this.moveDownToolStripMenuItem.Size = new System.Drawing.Size(265, 22);
            this.moveDownToolStripMenuItem.Text = "Move Down";
            this.moveDownToolStripMenuItem.Click += new System.EventHandler(this.moveDownToolStripMenuItem_Click);
            // 
            // showSpecialsExportColumnsToolStripMenuItem
            // 
            this.showSpecialsExportColumnsToolStripMenuItem.Name = "showSpecialsExportColumnsToolStripMenuItem";
            this.showSpecialsExportColumnsToolStripMenuItem.Size = new System.Drawing.Size(265, 22);
            this.showSpecialsExportColumnsToolStripMenuItem.Text = "Show/Hide Specials Export Columns";
            this.showSpecialsExportColumnsToolStripMenuItem.Click += new System.EventHandler(this.showSpecialsExportColumnsToolStripMenuItem_Click);
            // 
            // pnlEditor
            // 
            this.pnlEditor.Controls.Add(this.gvTemplates);
            this.pnlEditor.Controls.Add(this.pnlEditColumn);
            this.pnlEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlEditor.Location = new System.Drawing.Point(0, 160);
            this.pnlEditor.Name = "pnlEditor";
            this.pnlEditor.Size = new System.Drawing.Size(1074, 502);
            this.pnlEditor.TabIndex = 8;
            this.pnlEditor.Visible = false;
            // 
            // gvTemplates
            // 
            this.gvTemplates.AllowUserToAddRows = false;
            this.gvTemplates.AllowUserToDeleteRows = false;
            this.gvTemplates.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gvTemplates.BackgroundColor = System.Drawing.SystemColors.InactiveCaption;
            this.gvTemplates.CausesValidation = false;
            this.gvTemplates.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvTemplates.Location = new System.Drawing.Point(0, 0);
            this.gvTemplates.Name = "gvTemplates";
            this.gvTemplates.ReadOnly = true;
            this.gvTemplates.Size = new System.Drawing.Size(600, 502);
            this.gvTemplates.TabIndex = 3;
            this.gvTemplates.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvTemplates_CellEnter);
            this.gvTemplates.MouseDown += new System.Windows.Forms.MouseEventHandler(this.gvTemplates_MouseDown);
            // 
            // pnlEditColumn
            // 
            this.pnlEditColumn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlEditColumn.Controls.Add(this.cbKeepOriginalData);
            this.pnlEditColumn.Controls.Add(this.pnlSpecialsCalculation);
            this.pnlEditColumn.Controls.Add(this.label7);
            this.pnlEditColumn.Controls.Add(this.cbFormatting);
            this.pnlEditColumn.Controls.Add(this.cbSpecialsExportColumn);
            this.pnlEditColumn.Controls.Add(this.pnlRegularOptions);
            this.pnlEditColumn.Controls.Add(this.label6);
            this.pnlEditColumn.Controls.Add(this.label11);
            this.pnlEditColumn.Controls.Add(this.cbColumnNames);
            this.pnlEditColumn.Controls.Add(this.lblTemplateColumnID);
            this.pnlEditColumn.Controls.Add(this.btnUpdate);
            this.pnlEditColumn.Controls.Add(this.txtCSVHeader);
            this.pnlEditColumn.Controls.Add(this.label4);
            this.pnlEditColumn.Controls.Add(this.label3);
            this.pnlEditColumn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlEditColumn.Location = new System.Drawing.Point(600, 0);
            this.pnlEditColumn.Name = "pnlEditColumn";
            this.pnlEditColumn.Size = new System.Drawing.Size(474, 502);
            this.pnlEditColumn.TabIndex = 5;
            // 
            // cbKeepOriginalData
            // 
            this.cbKeepOriginalData.AutoSize = true;
            this.cbKeepOriginalData.Location = new System.Drawing.Point(310, 60);
            this.cbKeepOriginalData.Name = "cbKeepOriginalData";
            this.cbKeepOriginalData.Size = new System.Drawing.Size(142, 21);
            this.cbKeepOriginalData.TabIndex = 28;
            this.cbKeepOriginalData.Text = "Keep original data";
            this.cbKeepOriginalData.UseVisualStyleBackColor = true;
            // 
            // pnlSpecialsCalculation
            // 
            this.pnlSpecialsCalculation.Controls.Add(this.linkLabel2);
            this.pnlSpecialsCalculation.Controls.Add(this.txtSpecialsCalculation);
            this.pnlSpecialsCalculation.Controls.Add(this.label13);
            this.pnlSpecialsCalculation.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlSpecialsCalculation.Location = new System.Drawing.Point(14, 225);
            this.pnlSpecialsCalculation.Name = "pnlSpecialsCalculation";
            this.pnlSpecialsCalculation.Size = new System.Drawing.Size(452, 35);
            this.pnlSpecialsCalculation.TabIndex = 6;
            this.pnlSpecialsCalculation.Visible = false;
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Location = new System.Drawing.Point(417, 6);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(32, 17);
            this.linkLabel2.TabIndex = 30;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "Edit";
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // txtSpecialsCalculation
            // 
            this.txtSpecialsCalculation.Enabled = false;
            this.txtSpecialsCalculation.Location = new System.Drawing.Point(152, 3);
            this.txtSpecialsCalculation.Name = "txtSpecialsCalculation";
            this.txtSpecialsCalculation.ReadOnly = true;
            this.txtSpecialsCalculation.Size = new System.Drawing.Size(260, 23);
            this.txtSpecialsCalculation.TabIndex = 29;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(7, 6);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(134, 17);
            this.label13.TabIndex = 28;
            this.label13.Text = "Specials Calculation";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(18, 196);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(126, 17);
            this.label7.TabIndex = 26;
            this.label7.Text = "Column Formatting";
            // 
            // cbFormatting
            // 
            this.cbFormatting.FormattingEnabled = true;
            this.cbFormatting.Items.AddRange(new object[] {
            "STRING",
            "DECIMAL 0.00",
            "DECIMAL 0.000",
            "DECIMAL 0.0000",
            "DECIMAL 0.00000"});
            this.cbFormatting.Location = new System.Drawing.Point(164, 193);
            this.cbFormatting.Name = "cbFormatting";
            this.cbFormatting.Size = new System.Drawing.Size(292, 24);
            this.cbFormatting.TabIndex = 27;
            // 
            // cbSpecialsExportColumn
            // 
            this.cbSpecialsExportColumn.AutoSize = true;
            this.cbSpecialsExportColumn.Enabled = false;
            this.cbSpecialsExportColumn.Location = new System.Drawing.Point(21, 60);
            this.cbSpecialsExportColumn.Name = "cbSpecialsExportColumn";
            this.cbSpecialsExportColumn.Size = new System.Drawing.Size(175, 21);
            this.cbSpecialsExportColumn.TabIndex = 25;
            this.cbSpecialsExportColumn.Text = "Specials Export Column";
            this.cbSpecialsExportColumn.UseVisualStyleBackColor = true;
            this.cbSpecialsExportColumn.Visible = false;
            this.cbSpecialsExportColumn.CheckedChanged += new System.EventHandler(this.cbSpecialsExportColumn_CheckedChanged);
            // 
            // pnlRegularOptions
            // 
            this.pnlRegularOptions.Controls.Add(this.lblSpecialsOverrideColumn);
            this.pnlRegularOptions.Controls.Add(this.label12);
            this.pnlRegularOptions.Controls.Add(this.cbIncludeAttributes);
            this.pnlRegularOptions.Controls.Add(this.txtCalculation);
            this.pnlRegularOptions.Controls.Add(this.label10);
            this.pnlRegularOptions.Controls.Add(this.label8);
            this.pnlRegularOptions.Controls.Add(this.txtExportDefault);
            this.pnlRegularOptions.Controls.Add(this.linkLabel1);
            this.pnlRegularOptions.Controls.Add(this.label9);
            this.pnlRegularOptions.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlRegularOptions.Location = new System.Drawing.Point(14, 259);
            this.pnlRegularOptions.Name = "pnlRegularOptions";
            this.pnlRegularOptions.Size = new System.Drawing.Size(456, 180);
            this.pnlRegularOptions.TabIndex = 6;
            // 
            // lblSpecialsOverrideColumn
            // 
            this.lblSpecialsOverrideColumn.AutoSize = true;
            this.lblSpecialsOverrideColumn.Location = new System.Drawing.Point(188, 147);
            this.lblSpecialsOverrideColumn.Name = "lblSpecialsOverrideColumn";
            this.lblSpecialsOverrideColumn.Size = new System.Drawing.Size(189, 17);
            this.lblSpecialsOverrideColumn.TabIndex = 30;
            this.lblSpecialsOverrideColumn.Text = "txt Specials Override Column";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 147);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(176, 17);
            this.label12.TabIndex = 29;
            this.label12.Text = "(Specials) Is overridden by";
            // 
            // cbIncludeAttributes
            // 
            this.cbIncludeAttributes.AutoSize = true;
            this.cbIncludeAttributes.Location = new System.Drawing.Point(149, 102);
            this.cbIncludeAttributes.Name = "cbIncludeAttributes";
            this.cbIncludeAttributes.Size = new System.Drawing.Size(15, 14);
            this.cbIncludeAttributes.TabIndex = 28;
            this.cbIncludeAttributes.UseVisualStyleBackColor = true;
            // 
            // txtCalculation
            // 
            this.txtCalculation.CausesValidation = false;
            this.txtCalculation.Enabled = false;
            this.txtCalculation.Location = new System.Drawing.Point(149, 7);
            this.txtCalculation.Name = "txtCalculation";
            this.txtCalculation.Size = new System.Drawing.Size(262, 23);
            this.txtCalculation.TabIndex = 21;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(5, 102);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(116, 17);
            this.label10.TabIndex = 27;
            this.label10.Text = "Include attributes";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 10);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(99, 17);
            this.label8.TabIndex = 22;
            this.label8.Text = "Column Merge";
            // 
            // txtExportDefault
            // 
            this.txtExportDefault.CausesValidation = false;
            this.txtExportDefault.Location = new System.Drawing.Point(149, 54);
            this.txtExportDefault.Name = "txtExportDefault";
            this.txtExportDefault.Size = new System.Drawing.Size(289, 23);
            this.txtExportDefault.TabIndex = 26;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(417, 13);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(32, 17);
            this.linkLabel1.TabIndex = 23;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Edit";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 57);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(97, 17);
            this.label9.TabIndex = 25;
            this.label9.Text = "Export Default";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(216, 96);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(237, 13);
            this.label6.TabIndex = 24;
            this.label6.Text = "(Reminder:  Add a hash # for exclamation mark !)";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(18, 14);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(108, 17);
            this.label11.TabIndex = 17;
            this.label11.Text = "Column Setup";
            // 
            // cbColumnNames
            // 
            this.cbColumnNames.FormattingEnabled = true;
            this.cbColumnNames.Location = new System.Drawing.Point(164, 153);
            this.cbColumnNames.Name = "cbColumnNames";
            this.cbColumnNames.Size = new System.Drawing.Size(289, 24);
            this.cbColumnNames.TabIndex = 7;
            // 
            // lblTemplateColumnID
            // 
            this.lblTemplateColumnID.AutoSize = true;
            this.lblTemplateColumnID.Location = new System.Drawing.Point(440, 2);
            this.lblTemplateColumnID.Name = "lblTemplateColumnID";
            this.lblTemplateColumnID.Size = new System.Drawing.Size(16, 17);
            this.lblTemplateColumnID.TabIndex = 6;
            this.lblTemplateColumnID.Text = "#";
            this.lblTemplateColumnID.Visible = false;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(344, 454);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(117, 35);
            this.btnUpdate.TabIndex = 4;
            this.btnUpdate.Text = "Save";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // txtCSVHeader
            // 
            this.txtCSVHeader.Location = new System.Drawing.Point(164, 112);
            this.txtCSVHeader.Name = "txtCSVHeader";
            this.txtCSVHeader.Size = new System.Drawing.Size(289, 23);
            this.txtCSVHeader.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 156);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 17);
            this.label4.TabIndex = 1;
            this.label4.Text = "Database Column";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "CSV Header";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.panel2.Controls.Add(this.pnlMakeCopy);
            this.panel2.Controls.Add(this.pnlSelect);
            this.panel2.Controls.Add(this.button3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1074, 160);
            this.panel2.TabIndex = 7;
            // 
            // pnlMakeCopy
            // 
            this.pnlMakeCopy.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.pnlMakeCopy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMakeCopy.Controls.Add(this.button6);
            this.pnlMakeCopy.Controls.Add(this.button5);
            this.pnlMakeCopy.Controls.Add(this.label5);
            this.pnlMakeCopy.Controls.Add(this.cbCopyToSupplier);
            this.pnlMakeCopy.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlMakeCopy.Location = new System.Drawing.Point(0, 100);
            this.pnlMakeCopy.Name = "pnlMakeCopy";
            this.pnlMakeCopy.Size = new System.Drawing.Size(1074, 60);
            this.pnlMakeCopy.TabIndex = 8;
            this.pnlMakeCopy.Visible = false;
            // 
            // button6
            // 
            this.button6.CausesValidation = false;
            this.button6.Location = new System.Drawing.Point(855, 13);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(117, 35);
            this.button6.TabIndex = 9;
            this.button6.Text = "Cancel";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(732, 13);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(117, 35);
            this.button5.TabIndex = 8;
            this.button5.Text = "Save template";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(110, 17);
            this.label5.TabIndex = 6;
            this.label5.Text = "Copy to supplier";
            // 
            // cbCopyToSupplier
            // 
            this.cbCopyToSupplier.FormattingEnabled = true;
            this.cbCopyToSupplier.Location = new System.Drawing.Point(144, 19);
            this.cbCopyToSupplier.Name = "cbCopyToSupplier";
            this.cbCopyToSupplier.Size = new System.Drawing.Size(500, 24);
            this.cbCopyToSupplier.TabIndex = 7;
            // 
            // pnlSelect
            // 
            this.pnlSelect.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.pnlSelect.Controls.Add(this.panel1);
            this.pnlSelect.Controls.Add(this.button7);
            this.pnlSelect.Controls.Add(this.button2);
            this.pnlSelect.Controls.Add(this.button1);
            this.pnlSelect.Controls.Add(this.button4);
            this.pnlSelect.Controls.Add(this.cbTemplates);
            this.pnlSelect.Controls.Add(this.label2);
            this.pnlSelect.Controls.Add(this.label1);
            this.pnlSelect.Controls.Add(this.cbSuppliers);
            this.pnlSelect.Location = new System.Drawing.Point(0, 0);
            this.pnlSelect.Name = "pnlSelect";
            this.pnlSelect.Size = new System.Drawing.Size(930, 160);
            this.pnlSelect.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(921, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(153, 100);
            this.panel1.TabIndex = 9;
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(675, 9);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(117, 35);
            this.button7.TabIndex = 8;
            this.button7.Text = "Rename";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(798, 9);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(117, 35);
            this.button2.TabIndex = 7;
            this.button2.Text = "Delete";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(675, 59);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(117, 35);
            this.button1.TabIndex = 6;
            this.button1.Text = "Load";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(798, 59);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(117, 35);
            this.button4.TabIndex = 5;
            this.button4.Text = "Copy";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // cbTemplates
            // 
            this.cbTemplates.FormattingEnabled = true;
            this.cbTemplates.Location = new System.Drawing.Point(144, 65);
            this.cbTemplates.Name = "cbTemplates";
            this.cbTemplates.Size = new System.Drawing.Size(500, 24);
            this.cbTemplates.TabIndex = 3;
            this.cbTemplates.SelectedIndexChanged += new System.EventHandler(this.cbTemplates_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Select Template";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select Supplier";
            // 
            // cbSuppliers
            // 
            this.cbSuppliers.FormattingEnabled = true;
            this.cbSuppliers.Location = new System.Drawing.Point(144, 20);
            this.cbSuppliers.Name = "cbSuppliers";
            this.cbSuppliers.Size = new System.Drawing.Size(500, 24);
            this.cbSuppliers.TabIndex = 1;
            this.cbSuppliers.SelectionChangeCommitted += new System.EventHandler(this.cbSuppliers_SelectionChangeCommitted);
            // 
            // button3
            // 
            this.button3.CausesValidation = false;
            this.button3.Location = new System.Drawing.Point(937, 59);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(117, 35);
            this.button3.TabIndex = 5;
            this.button3.Text = "Close Template";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // frmTemplates_editExport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1074, 662);
            this.Controls.Add(this.pnlEditor);
            this.Controls.Add(this.panel2);
            this.Name = "frmTemplates_editExport";
            this.Text = "Edit Export Templates";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmTemplates_editExport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingTemplates)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.pnlEditor.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvTemplates)).EndInit();
            this.pnlEditColumn.ResumeLayout(false);
            this.pnlEditColumn.PerformLayout();
            this.pnlSpecialsCalculation.ResumeLayout(false);
            this.pnlSpecialsCalculation.PerformLayout();
            this.pnlRegularOptions.ResumeLayout(false);
            this.pnlRegularOptions.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.pnlMakeCopy.ResumeLayout(false);
            this.pnlMakeCopy.PerformLayout();
            this.pnlSelect.ResumeLayout(false);
            this.pnlSelect.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource bindingTemplates;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem insertNewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;
        private System.Windows.Forms.Panel pnlEditColumn;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cbColumnNames;
        private System.Windows.Forms.Label lblTemplateColumnID;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.TextBox txtCSVHeader;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView gvTemplates;
        private System.Windows.Forms.Panel pnlEditor;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Panel pnlSelect;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ComboBox cbTemplates;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbSuppliers;
        private System.Windows.Forms.Panel pnlMakeCopy;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbCopyToSupplier;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtCalculation;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ToolStripMenuItem moveUpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moveDownToolStripMenuItem;
        private System.Windows.Forms.TextBox txtExportDefault;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox cbIncludeAttributes;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblSpecialsOverrideColumn;
        private System.Windows.Forms.CheckBox cbSpecialsExportColumn;
        private System.Windows.Forms.Panel pnlRegularOptions;
        private System.Windows.Forms.ToolStripMenuItem showSpecialsExportColumnsToolStripMenuItem;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbFormatting;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.TextBox txtSpecialsCalculation;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Panel pnlSpecialsCalculation;
        private System.Windows.Forms.CheckBox cbKeepOriginalData;
    }
}