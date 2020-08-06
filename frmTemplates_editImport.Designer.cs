namespace Stockman
{
    partial class frmTemplates_editImport
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
            this.label1 = new System.Windows.Forms.Label();
            this.pnlSelect = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.button7 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.cbTemplates = new System.Windows.Forms.ComboBox();
            this.bindingTemplates = new System.Windows.Forms.BindingSource(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.cbSuppliers = new System.Windows.Forms.ComboBox();
            this.button3 = new System.Windows.Forms.Button();
            this.gvTemplates = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.insertNewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moveUpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moveDownToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label5 = new System.Windows.Forms.Label();
            this.cbCopyToSupplier = new System.Windows.Forms.ComboBox();
            this.pnlMakeCopy = new System.Windows.Forms.Panel();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pnlEditor = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button10 = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.cbColumnType = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.button9 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.txtDBColumnName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.pnlEditColumn = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.txtSpecialPriceCSVHeader = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.pnlDelSpecialsOverride = new System.Windows.Forms.Panel();
            this.cbSpecialsOverrideColumns = new System.Windows.Forms.ComboBox();
            this.linkLabel3 = new System.Windows.Forms.LinkLabel();
            this.label12 = new System.Windows.Forms.Label();
            this.linkLabel4 = new System.Windows.Forms.LinkLabel();
            this.cbSpecialsOverride = new System.Windows.Forms.ComboBox();
            this.cbCopyColumn = new System.Windows.Forms.CheckBox();
            this.cbDontOverride = new System.Windows.Forms.CheckBox();
            this.cbApplyRounding = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label8 = new System.Windows.Forms.Label();
            this.txtCalculation = new System.Windows.Forms.TextBox();
            this.cbFormatting = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cbColumnNames = new System.Windows.Forms.ComboBox();
            this.lblTemplateColumnID = new System.Windows.Forms.Label();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.txtCSVHeader = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pageSetupDialog1 = new System.Windows.Forms.PageSetupDialog();
            this.lblTemplateID = new System.Windows.Forms.Label();
            this.pnlSelect.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingTemplates)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvTemplates)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.pnlMakeCopy.SuspendLayout();
            this.panel2.SuspendLayout();
            this.pnlEditor.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnlEditColumn.SuspendLayout();
            this.panel4.SuspendLayout();
            this.pnlDelSpecialsOverride.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select Supplier";
            // 
            // pnlSelect
            // 
            this.pnlSelect.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.pnlSelect.Controls.Add(this.panel3);
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
            this.pnlSelect.Size = new System.Drawing.Size(949, 103);
            this.pnlSelect.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.Location = new System.Drawing.Point(955, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(129, 82);
            this.panel3.TabIndex = 9;
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(669, 9);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(117, 35);
            this.button7.TabIndex = 8;
            this.button7.Text = "Rename";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(809, 9);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(117, 35);
            this.button2.TabIndex = 7;
            this.button2.Text = "Delete";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(669, 50);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(117, 35);
            this.button1.TabIndex = 6;
            this.button1.Text = "Load";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(809, 50);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(117, 35);
            this.button4.TabIndex = 5;
            this.button4.Text = "Copy";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // cbTemplates
            // 
            this.cbTemplates.DataSource = this.bindingTemplates;
            this.cbTemplates.FormattingEnabled = true;
            this.cbTemplates.Location = new System.Drawing.Point(139, 56);
            this.cbTemplates.Name = "cbTemplates";
            this.cbTemplates.Size = new System.Drawing.Size(500, 24);
            this.cbTemplates.TabIndex = 3;
            this.cbTemplates.SelectedIndexChanged += new System.EventHandler(this.cbTemplates_SelectedIndexChanged);
            // 
            // bindingTemplates
            // 
            this.bindingTemplates.AllowNew = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Select Template";
            // 
            // cbSuppliers
            // 
            this.cbSuppliers.FormattingEnabled = true;
            this.cbSuppliers.Location = new System.Drawing.Point(139, 15);
            this.cbSuppliers.Name = "cbSuppliers";
            this.cbSuppliers.Size = new System.Drawing.Size(500, 24);
            this.cbSuppliers.TabIndex = 1;
            this.cbSuppliers.SelectionChangeCommitted += new System.EventHandler(this.cbSuppliers_SelectionChangeCommitted);
            // 
            // button3
            // 
            this.button3.CausesValidation = false;
            this.button3.Location = new System.Drawing.Point(955, 50);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(117, 35);
            this.button3.TabIndex = 5;
            this.button3.Text = "Close Template";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // gvTemplates
            // 
            this.gvTemplates.AllowUserToAddRows = false;
            this.gvTemplates.AllowUserToDeleteRows = false;
            this.gvTemplates.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gvTemplates.BackgroundColor = System.Drawing.SystemColors.InactiveCaption;
            this.gvTemplates.CausesValidation = false;
            this.gvTemplates.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvTemplates.Location = new System.Drawing.Point(1, 149);
            this.gvTemplates.Name = "gvTemplates";
            this.gvTemplates.ReadOnly = true;
            this.gvTemplates.Size = new System.Drawing.Size(590, 523);
            this.gvTemplates.TabIndex = 3;
            this.gvTemplates.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvTemplates_CellEnter);
            this.gvTemplates.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gvTemplates_KeyDown);
            this.gvTemplates.MouseDown += new System.Windows.Forms.MouseEventHandler(this.gvTemplates_MouseDown);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.insertNewToolStripMenuItem,
            this.removeToolStripMenuItem,
            this.moveUpToolStripMenuItem,
            this.moveDownToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(150, 92);
            // 
            // insertNewToolStripMenuItem
            // 
            this.insertNewToolStripMenuItem.Name = "insertNewToolStripMenuItem";
            this.insertNewToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.insertNewToolStripMenuItem.Text = "Insert Column";
            this.insertNewToolStripMenuItem.Click += new System.EventHandler(this.insertNewToolStripMenuItem_Click);
            // 
            // removeToolStripMenuItem
            // 
            this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            this.removeToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.removeToolStripMenuItem.Text = "Remove";
            this.removeToolStripMenuItem.Click += new System.EventHandler(this.removeToolStripMenuItem_Click);
            // 
            // moveUpToolStripMenuItem
            // 
            this.moveUpToolStripMenuItem.Name = "moveUpToolStripMenuItem";
            this.moveUpToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.moveUpToolStripMenuItem.Text = "Move Up";
            this.moveUpToolStripMenuItem.Click += new System.EventHandler(this.moveUpToolStripMenuItem_Click);
            // 
            // moveDownToolStripMenuItem
            // 
            this.moveDownToolStripMenuItem.Name = "moveDownToolStripMenuItem";
            this.moveDownToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.moveDownToolStripMenuItem.Text = "Move Down";
            this.moveDownToolStripMenuItem.Click += new System.EventHandler(this.moveDownToolStripMenuItem_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(103, 17);
            this.label5.TabIndex = 6;
            this.label5.Text = "Select Supplier";
            // 
            // cbCopyToSupplier
            // 
            this.cbCopyToSupplier.FormattingEnabled = true;
            this.cbCopyToSupplier.Location = new System.Drawing.Point(140, 17);
            this.cbCopyToSupplier.Name = "cbCopyToSupplier";
            this.cbCopyToSupplier.Size = new System.Drawing.Size(500, 24);
            this.cbCopyToSupplier.TabIndex = 7;
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
            this.pnlMakeCopy.Location = new System.Drawing.Point(0, 91);
            this.pnlMakeCopy.Name = "pnlMakeCopy";
            this.pnlMakeCopy.Size = new System.Drawing.Size(1084, 59);
            this.pnlMakeCopy.TabIndex = 8;
            this.pnlMakeCopy.Visible = false;
            // 
            // button6
            // 
            this.button6.CausesValidation = false;
            this.button6.Location = new System.Drawing.Point(808, 11);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(117, 35);
            this.button6.TabIndex = 9;
            this.button6.Text = "Cancel";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(668, 12);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(117, 35);
            this.button5.TabIndex = 8;
            this.button5.Text = "Save template";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.panel2.Controls.Add(this.lblTemplateID);
            this.panel2.Controls.Add(this.pnlMakeCopy);
            this.panel2.Controls.Add(this.pnlSelect);
            this.panel2.Controls.Add(this.button3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1084, 150);
            this.panel2.TabIndex = 6;
            // 
            // pnlEditor
            // 
            this.pnlEditor.Controls.Add(this.gvTemplates);
            this.pnlEditor.Controls.Add(this.panel1);
            this.pnlEditor.Controls.Add(this.pnlEditColumn);
            this.pnlEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlEditor.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlEditor.Location = new System.Drawing.Point(0, 0);
            this.pnlEditor.Name = "pnlEditor";
            this.pnlEditor.Size = new System.Drawing.Size(1084, 672);
            this.pnlEditor.TabIndex = 7;
            this.pnlEditor.Visible = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.button10);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.cbColumnType);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.button9);
            this.panel1.Controls.Add(this.button8);
            this.panel1.Controls.Add(this.txtDBColumnName);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Location = new System.Drawing.Point(588, 533);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(496, 139);
            this.panel1.TabIndex = 7;
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(239, 15);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(77, 26);
            this.button10.TabIndex = 8;
            this.button10.Text = "Delete";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(20, 15);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(143, 17);
            this.label10.TabIndex = 7;
            this.label10.Text = "Database Columns";
            // 
            // cbColumnType
            // 
            this.cbColumnType.FormattingEnabled = true;
            this.cbColumnType.Items.AddRange(new object[] {
            "STRING",
            "DECIMAL 0.00",
            "DECIMAL 0.000",
            "DECIMAL 0.0000",
            "DECIMAL 0.00000"});
            this.cbColumnType.Location = new System.Drawing.Point(144, 99);
            this.cbColumnType.Name = "cbColumnType";
            this.cbColumnType.Size = new System.Drawing.Size(323, 24);
            this.cbColumnType.TabIndex = 6;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(21, 102);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(91, 17);
            this.label9.TabIndex = 5;
            this.label9.Text = "Column Type";
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(405, 15);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(77, 26);
            this.button9.TabIndex = 4;
            this.button9.Text = "Cancel";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(322, 15);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(77, 26);
            this.button8.TabIndex = 3;
            this.button8.Text = "Create";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // txtDBColumnName
            // 
            this.txtDBColumnName.Location = new System.Drawing.Point(144, 63);
            this.txtDBColumnName.Name = "txtDBColumnName";
            this.txtDBColumnName.Size = new System.Drawing.Size(323, 23);
            this.txtDBColumnName.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(21, 63);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(96, 17);
            this.label6.TabIndex = 1;
            this.label6.Text = "Column Name";
            // 
            // pnlEditColumn
            // 
            this.pnlEditColumn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlEditColumn.Controls.Add(this.panel4);
            this.pnlEditColumn.Controls.Add(this.cbCopyColumn);
            this.pnlEditColumn.Controls.Add(this.cbDontOverride);
            this.pnlEditColumn.Controls.Add(this.cbApplyRounding);
            this.pnlEditColumn.Controls.Add(this.label11);
            this.pnlEditColumn.Controls.Add(this.linkLabel2);
            this.pnlEditColumn.Controls.Add(this.linkLabel1);
            this.pnlEditColumn.Controls.Add(this.label8);
            this.pnlEditColumn.Controls.Add(this.txtCalculation);
            this.pnlEditColumn.Controls.Add(this.cbFormatting);
            this.pnlEditColumn.Controls.Add(this.label7);
            this.pnlEditColumn.Controls.Add(this.cbColumnNames);
            this.pnlEditColumn.Controls.Add(this.lblTemplateColumnID);
            this.pnlEditColumn.Controls.Add(this.btnUpdate);
            this.pnlEditColumn.Controls.Add(this.txtCSVHeader);
            this.pnlEditColumn.Controls.Add(this.label4);
            this.pnlEditColumn.Controls.Add(this.label3);
            this.pnlEditColumn.Location = new System.Drawing.Point(588, 149);
            this.pnlEditColumn.Name = "pnlEditColumn";
            this.pnlEditColumn.Size = new System.Drawing.Size(496, 393);
            this.pnlEditColumn.TabIndex = 5;
            this.pnlEditColumn.Visible = false;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.txtSpecialPriceCSVHeader);
            this.panel4.Controls.Add(this.label13);
            this.panel4.Controls.Add(this.pnlDelSpecialsOverride);
            this.panel4.Controls.Add(this.label12);
            this.panel4.Controls.Add(this.linkLabel4);
            this.panel4.Controls.Add(this.cbSpecialsOverride);
            this.panel4.Location = new System.Drawing.Point(17, 182);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(473, 123);
            this.panel4.TabIndex = 8;
            // 
            // txtSpecialPriceCSVHeader
            // 
            this.txtSpecialPriceCSVHeader.Location = new System.Drawing.Point(168, 6);
            this.txtSpecialPriceCSVHeader.Name = "txtSpecialPriceCSVHeader";
            this.txtSpecialPriceCSVHeader.Size = new System.Drawing.Size(261, 23);
            this.txtSpecialPriceCSVHeader.TabIndex = 31;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(4, 12);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(136, 17);
            this.label13.TabIndex = 30;
            this.label13.Text = "Special CSV Header";
            // 
            // pnlDelSpecialsOverride
            // 
            this.pnlDelSpecialsOverride.Controls.Add(this.cbSpecialsOverrideColumns);
            this.pnlDelSpecialsOverride.Controls.Add(this.linkLabel3);
            this.pnlDelSpecialsOverride.Location = new System.Drawing.Point(167, 70);
            this.pnlDelSpecialsOverride.Name = "pnlDelSpecialsOverride";
            this.pnlDelSpecialsOverride.Size = new System.Drawing.Size(303, 36);
            this.pnlDelSpecialsOverride.TabIndex = 28;
            this.pnlDelSpecialsOverride.Visible = false;
            // 
            // cbSpecialsOverrideColumns
            // 
            this.cbSpecialsOverrideColumns.CausesValidation = false;
            this.cbSpecialsOverrideColumns.FormattingEnabled = true;
            this.cbSpecialsOverrideColumns.Location = new System.Drawing.Point(3, 3);
            this.cbSpecialsOverrideColumns.Name = "cbSpecialsOverrideColumns";
            this.cbSpecialsOverrideColumns.Size = new System.Drawing.Size(262, 24);
            this.cbSpecialsOverrideColumns.TabIndex = 25;
            // 
            // linkLabel3
            // 
            this.linkLabel3.AutoSize = true;
            this.linkLabel3.Location = new System.Drawing.Point(271, 6);
            this.linkLabel3.Name = "linkLabel3";
            this.linkLabel3.Size = new System.Drawing.Size(29, 17);
            this.linkLabel3.TabIndex = 26;
            this.linkLabel3.TabStop = true;
            this.linkLabel3.Text = "Del";
            this.linkLabel3.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel3_LinkClicked);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(4, 40);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(153, 17);
            this.label12.TabIndex = 22;
            this.label12.Text = "(Specials) Will override";
            // 
            // linkLabel4
            // 
            this.linkLabel4.AutoSize = true;
            this.linkLabel4.Location = new System.Drawing.Point(438, 47);
            this.linkLabel4.Name = "linkLabel4";
            this.linkLabel4.Size = new System.Drawing.Size(33, 17);
            this.linkLabel4.TabIndex = 27;
            this.linkLabel4.TabStop = true;
            this.linkLabel4.Text = "Add";
            this.linkLabel4.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel4_LinkClicked);
            // 
            // cbSpecialsOverride
            // 
            this.cbSpecialsOverride.CausesValidation = false;
            this.cbSpecialsOverride.FormattingEnabled = true;
            this.cbSpecialsOverride.Location = new System.Drawing.Point(169, 40);
            this.cbSpecialsOverride.Name = "cbSpecialsOverride";
            this.cbSpecialsOverride.Size = new System.Drawing.Size(262, 24);
            this.cbSpecialsOverride.TabIndex = 24;
            // 
            // cbCopyColumn
            // 
            this.cbCopyColumn.AutoSize = true;
            this.cbCopyColumn.Location = new System.Drawing.Point(159, 331);
            this.cbCopyColumn.Name = "cbCopyColumn";
            this.cbCopyColumn.Size = new System.Drawing.Size(110, 21);
            this.cbCopyColumn.TabIndex = 21;
            this.cbCopyColumn.Text = "Copy Column";
            this.cbCopyColumn.UseVisualStyleBackColor = true;
            // 
            // cbDontOverride
            // 
            this.cbDontOverride.AutoSize = true;
            this.cbDontOverride.Location = new System.Drawing.Point(8, 354);
            this.cbDontOverride.Name = "cbDontOverride";
            this.cbDontOverride.Size = new System.Drawing.Size(119, 21);
            this.cbDontOverride.TabIndex = 20;
            this.cbDontOverride.Text = "Don\'t Override";
            this.cbDontOverride.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cbDontOverride.UseVisualStyleBackColor = true;
            this.cbDontOverride.CheckedChanged += new System.EventHandler(this.cbDontOverride_CheckedChanged);
            // 
            // cbApplyRounding
            // 
            this.cbApplyRounding.AutoSize = true;
            this.cbApplyRounding.Location = new System.Drawing.Point(8, 334);
            this.cbApplyRounding.Name = "cbApplyRounding";
            this.cbApplyRounding.Size = new System.Drawing.Size(127, 21);
            this.cbApplyRounding.TabIndex = 17;
            this.cbApplyRounding.Text = "Apply Rounding";
            this.cbApplyRounding.UseVisualStyleBackColor = true;
            this.cbApplyRounding.CheckedChanged += new System.EventHandler(this.cbApplyRounding_CheckedChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(20, 11);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(108, 17);
            this.label11.TabIndex = 16;
            this.label11.Text = "Column Setup";
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Location = new System.Drawing.Point(156, 355);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(149, 17);
            this.linkLabel2.TabIndex = 15;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "Conditional Formatting";
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(453, 156);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(32, 17);
            this.linkLabel1.TabIndex = 12;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Edit";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(20, 150);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(128, 17);
            this.label8.TabIndex = 11;
            this.label8.Text = "Column Calculation";
            // 
            // txtCalculation
            // 
            this.txtCalculation.CausesValidation = false;
            this.txtCalculation.Enabled = false;
            this.txtCalculation.Location = new System.Drawing.Point(185, 150);
            this.txtCalculation.Name = "txtCalculation";
            this.txtCalculation.Size = new System.Drawing.Size(262, 23);
            this.txtCalculation.TabIndex = 4;
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
            this.cbFormatting.Location = new System.Drawing.Point(185, 77);
            this.cbFormatting.Name = "cbFormatting";
            this.cbFormatting.Size = new System.Drawing.Size(292, 24);
            this.cbFormatting.TabIndex = 2;
            this.cbFormatting.SelectionChangeCommitted += new System.EventHandler(this.cbFormatting_SelectionChangeCommitted);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(20, 77);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(126, 17);
            this.label7.TabIndex = 8;
            this.label7.Text = "Column Formatting";
            // 
            // cbColumnNames
            // 
            this.cbColumnNames.FormattingEnabled = true;
            this.cbColumnNames.Location = new System.Drawing.Point(185, 40);
            this.cbColumnNames.Name = "cbColumnNames";
            this.cbColumnNames.Size = new System.Drawing.Size(289, 24);
            this.cbColumnNames.TabIndex = 3;
            // 
            // lblTemplateColumnID
            // 
            this.lblTemplateColumnID.AutoSize = true;
            this.lblTemplateColumnID.Location = new System.Drawing.Point(451, 11);
            this.lblTemplateColumnID.Name = "lblTemplateColumnID";
            this.lblTemplateColumnID.Size = new System.Drawing.Size(16, 17);
            this.lblTemplateColumnID.TabIndex = 6;
            this.lblTemplateColumnID.Text = "#";
            this.lblTemplateColumnID.Visible = false;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(365, 334);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(117, 35);
            this.btnUpdate.TabIndex = 5;
            this.btnUpdate.Text = "Save";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtCSVHeader
            // 
            this.txtCSVHeader.CausesValidation = false;
            this.txtCSVHeader.Location = new System.Drawing.Point(185, 114);
            this.txtCSVHeader.Name = "txtCSVHeader";
            this.txtCSVHeader.Size = new System.Drawing.Size(292, 23);
            this.txtCSVHeader.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 17);
            this.label4.TabIndex = 1;
            this.label4.Text = "Database Column";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "CSV Header";
            // 
            // lblTemplateID
            // 
            this.lblTemplateID.AutoSize = true;
            this.lblTemplateID.Location = new System.Drawing.Point(959, 15);
            this.lblTemplateID.Name = "lblTemplateID";
            this.lblTemplateID.Size = new System.Drawing.Size(54, 17);
            this.lblTemplateID.TabIndex = 9;
            this.lblTemplateID.Text = "";
            // 
            // frmTemplates_editImport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 672);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pnlEditor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmTemplates_editImport";
            this.Text = "Edit Import Templates";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmTemplates_Load);
            this.pnlSelect.ResumeLayout(false);
            this.pnlSelect.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingTemplates)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvTemplates)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.pnlMakeCopy.ResumeLayout(false);
            this.pnlMakeCopy.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.pnlEditor.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlEditColumn.ResumeLayout(false);
            this.pnlEditColumn.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.pnlDelSpecialsOverride.ResumeLayout(false);
            this.pnlDelSpecialsOverride.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlSelect;
        private System.Windows.Forms.ComboBox cbTemplates;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView gvTemplates;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem insertNewToolStripMenuItem;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel pnlMakeCopy;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbCopyToSupplier;
        private System.Windows.Forms.ComboBox cbSuppliers;
        private System.Windows.Forms.Panel pnlEditor;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.BindingSource bindingTemplates;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.TextBox txtDBColumnName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbColumnType;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel pnlEditColumn;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtCalculation;
        private System.Windows.Forms.ComboBox cbFormatting;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbColumnNames;
        private System.Windows.Forms.Label lblTemplateColumnID;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.TextBox txtCSVHeader;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.CheckBox cbApplyRounding;
        private System.Windows.Forms.CheckBox cbDontOverride;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.ToolStripMenuItem moveUpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moveDownToolStripMenuItem;
        private System.Windows.Forms.CheckBox cbCopyColumn;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cbSpecialsOverride;
        private System.Windows.Forms.LinkLabel linkLabel4;
        private System.Windows.Forms.LinkLabel linkLabel3;
        private System.Windows.Forms.ComboBox cbSpecialsOverrideColumns;
        private System.Windows.Forms.Panel pnlDelSpecialsOverride;
        private System.Windows.Forms.PageSetupDialog pageSetupDialog1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox txtSpecialPriceCSVHeader;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lblTemplateID;
    }
}