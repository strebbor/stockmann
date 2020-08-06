namespace Stockman
{
    partial class START
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
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.suppliersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createTemplatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editImportTemplatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editExportTemplatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stockItemsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageSupplierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewStockItemsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.systemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.suppliersToolStripMenuItem,
            this.importToolStripMenuItem,
            this.stockItemsToolStripMenuItem,
            this.systemToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1084, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "MenuStrip";
            // 
            // suppliersToolStripMenuItem
            // 
            this.suppliersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createTemplatesToolStripMenuItem,
            this.editImportTemplatesToolStripMenuItem,
            this.editExportTemplatesToolStripMenuItem});
            this.suppliersToolStripMenuItem.Name = "suppliersToolStripMenuItem";
            this.suppliersToolStripMenuItem.Size = new System.Drawing.Size(74, 20);
            this.suppliersToolStripMenuItem.Text = "Templates";
            // 
            // createTemplatesToolStripMenuItem
            // 
            this.createTemplatesToolStripMenuItem.Name = "createTemplatesToolStripMenuItem";
            this.createTemplatesToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.createTemplatesToolStripMenuItem.Text = "Create Templates";
            this.createTemplatesToolStripMenuItem.Click += new System.EventHandler(this.createNewTemplateToolStripMenuItem_Click);
            // 
            // editImportTemplatesToolStripMenuItem
            // 
            this.editImportTemplatesToolStripMenuItem.Name = "editImportTemplatesToolStripMenuItem";
            this.editImportTemplatesToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.editImportTemplatesToolStripMenuItem.Text = "Edit Import Templates";
            this.editImportTemplatesToolStripMenuItem.Click += new System.EventHandler(this.changeTemplatesToolStripMenuItem_Click);
            // 
            // editExportTemplatesToolStripMenuItem
            // 
            this.editExportTemplatesToolStripMenuItem.Name = "editExportTemplatesToolStripMenuItem";
            this.editExportTemplatesToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.editExportTemplatesToolStripMenuItem.Text = "Edit Export Templates";
            this.editExportTemplatesToolStripMenuItem.Click += new System.EventHandler(this.changeExportTemplateToolStripMenuItem_Click);
            // 
            // importToolStripMenuItem
            // 
            this.importToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importDataToolStripMenuItem,
            this.eToolStripMenuItem});
            this.importToolStripMenuItem.Name = "importToolStripMenuItem";
            this.importToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.importToolStripMenuItem.Text = "Data";
            // 
            // importDataToolStripMenuItem
            // 
            this.importDataToolStripMenuItem.Name = "importDataToolStripMenuItem";
            this.importDataToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.importDataToolStripMenuItem.Text = "Import Data";
            this.importDataToolStripMenuItem.Click += new System.EventHandler(this.importDataToolStripMenuItem_Click);
            // 
            // eToolStripMenuItem
            // 
            this.eToolStripMenuItem.Name = "eToolStripMenuItem";
            this.eToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.eToolStripMenuItem.Text = "Export Data";
            this.eToolStripMenuItem.Click += new System.EventHandler(this.eToolStripMenuItem_Click);
            // 
            // stockItemsToolStripMenuItem
            // 
            this.stockItemsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.manageSupplierToolStripMenuItem,
            this.viewStockItemsToolStripMenuItem});
            this.stockItemsToolStripMenuItem.Name = "stockItemsToolStripMenuItem";
            this.stockItemsToolStripMenuItem.Size = new System.Drawing.Size(80, 20);
            this.stockItemsToolStripMenuItem.Text = "Stock Items";
            // 
            // manageSupplierToolStripMenuItem
            // 
            this.manageSupplierToolStripMenuItem.Name = "manageSupplierToolStripMenuItem";
            this.manageSupplierToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.manageSupplierToolStripMenuItem.Text = "Manage Suppliers";
            this.manageSupplierToolStripMenuItem.Click += new System.EventHandler(this.manageSuppliersToolStripMenuItem_Click);
            // 
            // viewStockItemsToolStripMenuItem
            // 
            this.viewStockItemsToolStripMenuItem.Name = "viewStockItemsToolStripMenuItem";
            this.viewStockItemsToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.viewStockItemsToolStripMenuItem.Text = "Manage Stock Items";
            this.viewStockItemsToolStripMenuItem.Click += new System.EventHandler(this.viewStockItemsToolStripMenuItem_Click);
            // 
            // systemToolStripMenuItem
            // 
            this.systemToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem});
            this.systemToolStripMenuItem.Name = "systemToolStripMenuItem";
            this.systemToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.systemToolStripMenuItem.Text = "System";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 690);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1084, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(127, 17);
            this.toolStripStatusLabel1.Text = "Welcome to Stockman";
            // 
            // START
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1084, 712);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "START";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Stockman v3.2";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.START_FormClosing);
            this.Load += new System.EventHandler(this.START_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion


        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ToolStripMenuItem suppliersToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripMenuItem importToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stockItemsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageSupplierToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createTemplatesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editImportTemplatesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editExportTemplatesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewStockItemsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem systemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
    }
}



