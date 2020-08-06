namespace Stockman
{
    partial class frmStockItems
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.contextMenuAll = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showActiveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showInactiveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.switchViewOptionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.switchViewToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.switchRowNumbersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.highlightSpecialsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuColumn = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.hideColumnToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuRow = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.attributeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAttributeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cancelAttributeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.propertiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setParentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createChildToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.removeChildToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.setNameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setPositionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlItems = new System.Windows.Forms.Panel();
            this.dgvItems = new System.Windows.Forms.DataGridView();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.pnlSearch = new System.Windows.Forms.Panel();
            this.cbSearchAll = new System.Windows.Forms.CheckBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pnlAttributeSetEditor = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.lblParentStockCode = new System.Windows.Forms.Label();
            this.cbColumnNames = new System.Windows.Forms.ComboBox();
            this.lblBasePrice = new System.Windows.Forms.Label();
            this.lblSetName = new System.Windows.Forms.Label();
            this.lblAttributeSet = new System.Windows.Forms.Label();
            this.pnlReorderColumns = new System.Windows.Forms.Panel();
            this.button5 = new System.Windows.Forms.Button();
            this.btnSaveColumnOrder = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlSelect = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.btnLoad = new System.Windows.Forms.Button();
            this.cbSuppliers = new System.Windows.Forms.ComboBox();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.pnlDetails = new System.Windows.Forms.Panel();
            this.dgvDetails = new System.Windows.Forms.DataGridView();
            this.contextMenuAll.SuspendLayout();
            this.contextMenuColumn.SuspendLayout();
            this.contextMenuRow.SuspendLayout();
            this.pnlItems.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).BeginInit();
            this.pnlTop.SuspendLayout();
            this.pnlSearch.SuspendLayout();
            this.panel3.SuspendLayout();
            this.pnlAttributeSetEditor.SuspendLayout();
            this.pnlReorderColumns.SuspendLayout();
            this.pnlSelect.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).BeginInit();
            this.SuspendLayout();
            // 
            // contextMenuAll
            // 
            this.contextMenuAll.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showActiveToolStripMenuItem,
            this.showInactiveToolStripMenuItem,
            this.showAllToolStripMenuItem,
            this.switchViewOptionsToolStripMenuItem});
            this.contextMenuAll.Name = "contextMenuStrip1";
            this.contextMenuAll.Size = new System.Drawing.Size(148, 92);
            // 
            // showActiveToolStripMenuItem
            // 
            this.showActiveToolStripMenuItem.Name = "showActiveToolStripMenuItem";
            this.showActiveToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.showActiveToolStripMenuItem.Text = "Show Active";
            this.showActiveToolStripMenuItem.Click += new System.EventHandler(this.showActiveToolStripMenuItem_Click);
            // 
            // showInactiveToolStripMenuItem
            // 
            this.showInactiveToolStripMenuItem.Name = "showInactiveToolStripMenuItem";
            this.showInactiveToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.showInactiveToolStripMenuItem.Text = "Show Inactive";
            this.showInactiveToolStripMenuItem.Click += new System.EventHandler(this.showInactiveToolStripMenuItem_Click);
            // 
            // showAllToolStripMenuItem
            // 
            this.showAllToolStripMenuItem.Name = "showAllToolStripMenuItem";
            this.showAllToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.showAllToolStripMenuItem.Text = "Show All";
            this.showAllToolStripMenuItem.Click += new System.EventHandler(this.showAllToolStripMenuItem_Click);
            // 
            // switchViewOptionsToolStripMenuItem
            // 
            this.switchViewOptionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.switchViewToolStripMenuItem1,
            this.switchRowNumbersToolStripMenuItem,
            this.highlightSpecialsToolStripMenuItem});
            this.switchViewOptionsToolStripMenuItem.Name = "switchViewOptionsToolStripMenuItem";
            this.switchViewOptionsToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.switchViewOptionsToolStripMenuItem.Text = "View Options";
            // 
            // switchViewToolStripMenuItem1
            // 
            this.switchViewToolStripMenuItem1.Name = "switchViewToolStripMenuItem1";
            this.switchViewToolStripMenuItem1.Size = new System.Drawing.Size(223, 22);
            this.switchViewToolStripMenuItem1.Text = "Switch View Style";
            this.switchViewToolStripMenuItem1.Click += new System.EventHandler(this.switchViewToolStripMenuItem1_Click);
            // 
            // switchRowNumbersToolStripMenuItem
            // 
            this.switchRowNumbersToolStripMenuItem.Name = "switchRowNumbersToolStripMenuItem";
            this.switchRowNumbersToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            this.switchRowNumbersToolStripMenuItem.Text = "Switch Row Number Display";
            this.switchRowNumbersToolStripMenuItem.Click += new System.EventHandler(this.switchRowNumbersToolStripMenuItem_Click);
            // 
            // highlightSpecialsToolStripMenuItem
            // 
            this.highlightSpecialsToolStripMenuItem.Name = "highlightSpecialsToolStripMenuItem";
            this.highlightSpecialsToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            this.highlightSpecialsToolStripMenuItem.Text = "Show Specials";
            this.highlightSpecialsToolStripMenuItem.Click += new System.EventHandler(this.highlightSpecialsToolStripMenuItem_Click);
            // 
            // contextMenuColumn
            // 
            this.contextMenuColumn.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hideColumnToolStripMenuItem1});
            this.contextMenuColumn.Name = "contextMenuColumn";
            this.contextMenuColumn.Size = new System.Drawing.Size(146, 26);
            // 
            // hideColumnToolStripMenuItem1
            // 
            this.hideColumnToolStripMenuItem1.Name = "hideColumnToolStripMenuItem1";
            this.hideColumnToolStripMenuItem1.Size = new System.Drawing.Size(145, 22);
            this.hideColumnToolStripMenuItem1.Text = "Hide Column";
            this.hideColumnToolStripMenuItem1.Click += new System.EventHandler(this.hideColumnToolStripMenuItem1_Click);
            // 
            // contextMenuRow
            // 
            this.contextMenuRow.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.attributeToolStripMenuItem,
            this.propertiesToolStripMenuItem});
            this.contextMenuRow.Name = "contextMenuRow";
            this.contextMenuRow.Size = new System.Drawing.Size(128, 48);
            // 
            // attributeToolStripMenuItem
            // 
            this.attributeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createToolStripMenuItem,
            this.selectToolStripMenuItem,
            this.saveAttributeToolStripMenuItem,
            this.cancelAttributeToolStripMenuItem});
            this.attributeToolStripMenuItem.Name = "attributeToolStripMenuItem";
            this.attributeToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.attributeToolStripMenuItem.Text = "Attribute";
            // 
            // createToolStripMenuItem
            // 
            this.createToolStripMenuItem.Name = "createToolStripMenuItem";
            this.createToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.createToolStripMenuItem.Text = "Create new set";
            this.createToolStripMenuItem.Click += new System.EventHandler(this.createToolStripMenuItem_Click);
            // 
            // selectToolStripMenuItem
            // 
            this.selectToolStripMenuItem.Name = "selectToolStripMenuItem";
            this.selectToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.selectToolStripMenuItem.Text = "Select Attribute Set";
            this.selectToolStripMenuItem.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.selectToolStripMenuItem_DropDownItemClicked);
            // 
            // saveAttributeToolStripMenuItem
            // 
            this.saveAttributeToolStripMenuItem.Name = "saveAttributeToolStripMenuItem";
            this.saveAttributeToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.saveAttributeToolStripMenuItem.Text = "Save Attribute Set";
            this.saveAttributeToolStripMenuItem.Click += new System.EventHandler(this.saveAttributeToolStripMenuItem_Click);
            // 
            // cancelAttributeToolStripMenuItem
            // 
            this.cancelAttributeToolStripMenuItem.Name = "cancelAttributeToolStripMenuItem";
            this.cancelAttributeToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.cancelAttributeToolStripMenuItem.Text = "Cancel";
            this.cancelAttributeToolStripMenuItem.Click += new System.EventHandler(this.cancelAttributeToolStripMenuItem_Click);
            // 
            // propertiesToolStripMenuItem
            // 
            this.propertiesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setParentToolStripMenuItem,
            this.createChildToolStripMenuItem1,
            this.removeChildToolStripMenuItem1,
            this.setNameToolStripMenuItem,
            this.setPositionToolStripMenuItem});
            this.propertiesToolStripMenuItem.Name = "propertiesToolStripMenuItem";
            this.propertiesToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.propertiesToolStripMenuItem.Text = "Properties";
            this.propertiesToolStripMenuItem.Visible = false;
            // 
            // setParentToolStripMenuItem
            // 
            this.setParentToolStripMenuItem.Name = "setParentToolStripMenuItem";
            this.setParentToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.setParentToolStripMenuItem.Text = "Set as Parent";
            this.setParentToolStripMenuItem.Click += new System.EventHandler(this.setParentToolStripMenuItem_Click);
            // 
            // createChildToolStripMenuItem1
            // 
            this.createChildToolStripMenuItem1.Name = "createChildToolStripMenuItem1";
            this.createChildToolStripMenuItem1.Size = new System.Drawing.Size(165, 22);
            this.createChildToolStripMenuItem1.Text = "Set as Child";
            this.createChildToolStripMenuItem1.Click += new System.EventHandler(this.createChildToolStripMenuItem1_Click);
            // 
            // removeChildToolStripMenuItem1
            // 
            this.removeChildToolStripMenuItem1.Name = "removeChildToolStripMenuItem1";
            this.removeChildToolStripMenuItem1.Size = new System.Drawing.Size(165, 22);
            this.removeChildToolStripMenuItem1.Text = "Remove Property";
            this.removeChildToolStripMenuItem1.Click += new System.EventHandler(this.removeChildToolStripMenuItem1_Click);
            // 
            // setNameToolStripMenuItem
            // 
            this.setNameToolStripMenuItem.Name = "setNameToolStripMenuItem";
            this.setNameToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.setNameToolStripMenuItem.Text = "Property Name";
            this.setNameToolStripMenuItem.Click += new System.EventHandler(this.setNameToolStripMenuItem_Click);
            // 
            // setPositionToolStripMenuItem
            // 
            this.setPositionToolStripMenuItem.Name = "setPositionToolStripMenuItem";
            this.setPositionToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.setPositionToolStripMenuItem.Text = "Property Position";
            this.setPositionToolStripMenuItem.Click += new System.EventHandler(this.setPositionToolStripMenuItem_Click);
            // 
            // pnlItems
            // 
            this.pnlItems.BackColor = System.Drawing.Color.DarkGray;
            this.pnlItems.Controls.Add(this.dgvItems);
            this.pnlItems.Location = new System.Drawing.Point(0, 164);
            this.pnlItems.Name = "pnlItems";
            this.pnlItems.Size = new System.Drawing.Size(1074, 428);
            this.pnlItems.TabIndex = 11;
            // 
            // dgvItems
            // 
            this.dgvItems.AllowUserToAddRows = false;
            this.dgvItems.AllowUserToOrderColumns = true;
            this.dgvItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvItems.Location = new System.Drawing.Point(0, 0);
            this.dgvItems.Name = "dgvItems";
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvItems.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvItems.Size = new System.Drawing.Size(1074, 428);
            this.dgvItems.TabIndex = 10;
            this.dgvItems.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvItems_CellClick);
            this.dgvItems.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvItems_CellEndEdit);
            this.dgvItems.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvItems_CellEnter);
            this.dgvItems.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvItems_DataError);
            this.dgvItems.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvItems_RowEnter);
            this.dgvItems.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dgvItems_UserDeletedRow);
            this.dgvItems.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgvItems_UserDeletingRow);
            this.dgvItems.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dgvItems_MouseDown);
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pnlTop.Controls.Add(this.pnlSearch);
            this.pnlTop.Controls.Add(this.pnlSelect);
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1074, 181);
            this.pnlTop.TabIndex = 11;
            // 
            // pnlSearch
            // 
            this.pnlSearch.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.pnlSearch.Controls.Add(this.cbSearchAll);
            this.pnlSearch.Controls.Add(this.txtSearch);
            this.pnlSearch.Controls.Add(this.panel3);
            this.pnlSearch.Controls.Add(this.button2);
            this.pnlSearch.Controls.Add(this.label2);
            this.pnlSearch.Location = new System.Drawing.Point(0, 52);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Size = new System.Drawing.Size(1074, 113);
            this.pnlSearch.TabIndex = 10;
            // 
            // cbSearchAll
            // 
            this.cbSearchAll.AutoSize = true;
            this.cbSearchAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSearchAll.Location = new System.Drawing.Point(837, 15);
            this.cbSearchAll.Name = "cbSearchAll";
            this.cbSearchAll.Size = new System.Drawing.Size(74, 17);
            this.cbSearchAll.TabIndex = 17;
            this.cbSearchAll.Text = "Search All";
            this.cbSearchAll.UseVisualStyleBackColor = true;
            this.cbSearchAll.CheckedChanged += new System.EventHandler(this.cbSearchAll_CheckedChanged);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(166, 11);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(665, 23);
            this.txtSearch.TabIndex = 11;
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel3.Controls.Add(this.pnlAttributeSetEditor);
            this.panel3.Controls.Add(this.pnlReorderColumns);
            this.panel3.Controls.Add(this.button3);
            this.panel3.Controls.Add(this.button4);
            this.panel3.Location = new System.Drawing.Point(0, 46);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1074, 60);
            this.panel3.TabIndex = 16;
            // 
            // pnlAttributeSetEditor
            // 
            this.pnlAttributeSetEditor.Controls.Add(this.label3);
            this.pnlAttributeSetEditor.Controls.Add(this.lblParentStockCode);
            this.pnlAttributeSetEditor.Controls.Add(this.cbColumnNames);
            this.pnlAttributeSetEditor.Controls.Add(this.lblBasePrice);
            this.pnlAttributeSetEditor.Controls.Add(this.lblSetName);
            this.pnlAttributeSetEditor.Controls.Add(this.lblAttributeSet);
            this.pnlAttributeSetEditor.Location = new System.Drawing.Point(33, 6);
            this.pnlAttributeSetEditor.Name = "pnlAttributeSetEditor";
            this.pnlAttributeSetEditor.Size = new System.Drawing.Size(635, 48);
            this.pnlAttributeSetEditor.TabIndex = 17;
            this.pnlAttributeSetEditor.Visible = false;
            this.pnlAttributeSetEditor.VisibleChanged += new System.EventHandler(this.pnlAttributeSetEditor_VisibleChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(436, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Parent:";
            // 
            // lblParentStockCode
            // 
            this.lblParentStockCode.AutoSize = true;
            this.lblParentStockCode.Location = new System.Drawing.Point(436, 24);
            this.lblParentStockCode.Name = "lblParentStockCode";
            this.lblParentStockCode.Size = new System.Drawing.Size(128, 17);
            this.lblParentStockCode.TabIndex = 4;
            this.lblParentStockCode.Text = "No parent selected";
            // 
            // cbColumnNames
            // 
            this.cbColumnNames.FormattingEnabled = true;
            this.cbColumnNames.Location = new System.Drawing.Point(6, 21);
            this.cbColumnNames.Name = "cbColumnNames";
            this.cbColumnNames.Size = new System.Drawing.Size(242, 24);
            this.cbColumnNames.TabIndex = 3;
            this.cbColumnNames.SelectedIndexChanged += new System.EventHandler(this.cbColumnNames_SelectedIndexChanged);
            // 
            // lblBasePrice
            // 
            this.lblBasePrice.AutoSize = true;
            this.lblBasePrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBasePrice.Location = new System.Drawing.Point(3, 1);
            this.lblBasePrice.Name = "lblBasePrice";
            this.lblBasePrice.Size = new System.Drawing.Size(96, 17);
            this.lblBasePrice.TabIndex = 2;
            this.lblBasePrice.Text = "Base Price: ";
            // 
            // lblSetName
            // 
            this.lblSetName.AutoSize = true;
            this.lblSetName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSetName.Location = new System.Drawing.Point(269, 4);
            this.lblSetName.Name = "lblSetName";
            this.lblSetName.Size = new System.Drawing.Size(37, 17);
            this.lblSetName.TabIndex = 1;
            this.lblSetName.Text = "Set:";
            // 
            // lblAttributeSet
            // 
            this.lblAttributeSet.AutoSize = true;
            this.lblAttributeSet.Location = new System.Drawing.Point(269, 24);
            this.lblAttributeSet.Name = "lblAttributeSet";
            this.lblAttributeSet.Size = new System.Drawing.Size(106, 17);
            this.lblAttributeSet.TabIndex = 0;
            this.lblAttributeSet.Text = "No set selected";
            this.lblAttributeSet.TextChanged += new System.EventHandler(this.lblAttributeSet_TextChanged);
            // 
            // pnlReorderColumns
            // 
            this.pnlReorderColumns.Controls.Add(this.button5);
            this.pnlReorderColumns.Controls.Add(this.btnSaveColumnOrder);
            this.pnlReorderColumns.Location = new System.Drawing.Point(674, 0);
            this.pnlReorderColumns.Name = "pnlReorderColumns";
            this.pnlReorderColumns.Size = new System.Drawing.Size(138, 57);
            this.pnlReorderColumns.TabIndex = 16;
            // 
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.Location = new System.Drawing.Point(3, 31);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(127, 23);
            this.button5.TabIndex = 16;
            this.button5.Text = "Show all columns";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // btnSaveColumnOrder
            // 
            this.btnSaveColumnOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveColumnOrder.Location = new System.Drawing.Point(3, 3);
            this.btnSaveColumnOrder.Name = "btnSaveColumnOrder";
            this.btnSaveColumnOrder.Size = new System.Drawing.Size(128, 23);
            this.btnSaveColumnOrder.TabIndex = 15;
            this.btnSaveColumnOrder.Text = "Save column changes";
            this.btnSaveColumnOrder.UseVisualStyleBackColor = true;
            this.btnSaveColumnOrder.Click += new System.EventHandler(this.btnSaveColumnOrder_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(829, 10);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(117, 35);
            this.button3.TabIndex = 12;
            this.button3.Text = "Refresh";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(952, 10);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(117, 35);
            this.button4.TabIndex = 13;
            this.button4.Text = "Save Data";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button2
            // 
            this.button2.Cursor = System.Windows.Forms.Cursors.Help;
            this.button2.Location = new System.Drawing.Point(945, 5);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(117, 35);
            this.button2.TabIndex = 10;
            this.button2.Text = "Search";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 14);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "Keyword";
            // 
            // pnlSelect
            // 
            this.pnlSelect.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.pnlSelect.Controls.Add(this.label1);
            this.pnlSelect.Controls.Add(this.checkBox2);
            this.pnlSelect.Controls.Add(this.btnLoad);
            this.pnlSelect.Controls.Add(this.cbSuppliers);
            this.pnlSelect.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSelect.Location = new System.Drawing.Point(0, 0);
            this.pnlSelect.Name = "pnlSelect";
            this.pnlSelect.Size = new System.Drawing.Size(1074, 56);
            this.pnlSelect.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 21);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "Select Supplier";
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox2.Location = new System.Drawing.Point(3, 3);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(66, 17);
            this.checkBox2.TabIndex = 17;
            this.checkBox2.Text = "Collapse";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(945, 12);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(117, 35);
            this.btnLoad.TabIndex = 8;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.button1_Click);
            // 
            // cbSuppliers
            // 
            this.cbSuppliers.FormattingEnabled = true;
            this.cbSuppliers.Location = new System.Drawing.Point(166, 18);
            this.cbSuppliers.Margin = new System.Windows.Forms.Padding(4);
            this.cbSuppliers.Name = "cbSuppliers";
            this.cbSuppliers.Size = new System.Drawing.Size(457, 24);
            this.cbSuppliers.TabIndex = 7;
            this.cbSuppliers.SelectionChangeCommitted += new System.EventHandler(this.cbSuppliers_SelectionChangeCommitted);
            // 
            // pnlBottom
            // 
            this.pnlBottom.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pnlBottom.Controls.Add(this.pnlDetails);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlBottom.Location = new System.Drawing.Point(0, 185);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(1074, 477);
            this.pnlBottom.TabIndex = 15;
            // 
            // pnlDetails
            // 
            this.pnlDetails.BackColor = System.Drawing.Color.MistyRose;
            this.pnlDetails.Controls.Add(this.dgvDetails);
            this.pnlDetails.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlDetails.Location = new System.Drawing.Point(0, 408);
            this.pnlDetails.Name = "pnlDetails";
            this.pnlDetails.Size = new System.Drawing.Size(1074, 69);
            this.pnlDetails.TabIndex = 17;
            // 
            // dgvDetails
            // 
            this.dgvDetails.AllowUserToAddRows = false;
            this.dgvDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDetails.Location = new System.Drawing.Point(0, 0);
            this.dgvDetails.Name = "dgvDetails";
            this.dgvDetails.Size = new System.Drawing.Size(1074, 69);
            this.dgvDetails.TabIndex = 0;
            this.dgvDetails.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetails_CellClick);
            this.dgvDetails.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetails_CellEndEdit);
            this.dgvDetails.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvItems_DataError);
            // 
            // frmStockItems
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1074, 662);
            this.Controls.Add(this.pnlItems);
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.pnlBottom);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmStockItems";
            this.Text = "Manage Stock Items";
            this.Load += new System.EventHandler(this.frmStockItems_Load);
            this.SizeChanged += new System.EventHandler(this.frmStockItems_SizeChanged);
            this.contextMenuAll.ResumeLayout(false);
            this.contextMenuColumn.ResumeLayout(false);
            this.contextMenuRow.ResumeLayout(false);
            this.pnlItems.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).EndInit();
            this.pnlTop.ResumeLayout(false);
            this.pnlSearch.ResumeLayout(false);
            this.pnlSearch.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.pnlAttributeSetEditor.ResumeLayout(false);
            this.pnlAttributeSetEditor.PerformLayout();
            this.pnlReorderColumns.ResumeLayout(false);
            this.pnlSelect.ResumeLayout(false);
            this.pnlSelect.PerformLayout();
            this.pnlBottom.ResumeLayout(false);
            this.pnlDetails.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbSuppliers;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Panel pnlSelect;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Panel pnlSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ContextMenuStrip contextMenuAll;
        private System.Windows.Forms.ToolStripMenuItem showActiveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showInactiveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showAllToolStripMenuItem;
        private System.Windows.Forms.DataGridView dgvItems;
        private System.Windows.Forms.DataGridView dgvDetails;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Panel pnlReorderColumns;
        private System.Windows.Forms.Button btnSaveColumnOrder;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.Panel pnlDetails;
        private System.Windows.Forms.Panel pnlItems;
        private System.Windows.Forms.ContextMenuStrip contextMenuColumn;
        private System.Windows.Forms.ToolStripMenuItem hideColumnToolStripMenuItem1;
        private System.Windows.Forms.ContextMenuStrip contextMenuRow;
        private System.Windows.Forms.ToolStripMenuItem attributeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem propertiesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setParentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createChildToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem removeChildToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem saveAttributeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cancelAttributeToolStripMenuItem;
        private System.Windows.Forms.Panel pnlAttributeSetEditor;
        private System.Windows.Forms.Label lblAttributeSet;
        private System.Windows.Forms.Label lblSetName;
        private System.Windows.Forms.ComboBox cbColumnNames;
        private System.Windows.Forms.Label lblBasePrice;
        private System.Windows.Forms.ToolStripMenuItem setNameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setPositionToolStripMenuItem;
        private System.Windows.Forms.CheckBox cbSearchAll;
        private System.Windows.Forms.ToolStripMenuItem switchViewOptionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem switchViewToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem switchRowNumbersToolStripMenuItem;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblParentStockCode;
        private System.Windows.Forms.ToolStripMenuItem highlightSpecialsToolStripMenuItem;

    }
}