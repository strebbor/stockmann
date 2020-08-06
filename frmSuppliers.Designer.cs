namespace Stockman
{
    partial class frmSuppliers
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
            this.gridSuppliers = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showActiveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showInactiveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtSupplierName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblSupplierID = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.cbActive = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtUniqueKey = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtAgencyMargin = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDiscount = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtGrossMargin = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblSpecialsDate = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblLastUpdate = new System.Windows.Forms.Label();
            this.cbSpecialsActive = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNotes = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.gridSuppliers)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridSuppliers
            // 
            this.gridSuppliers.AllowUserToAddRows = false;
            this.gridSuppliers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridSuppliers.CausesValidation = false;
            this.gridSuppliers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridSuppliers.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gridSuppliers.Location = new System.Drawing.Point(0, 242);
            this.gridSuppliers.Name = "gridSuppliers";
            this.gridSuppliers.Size = new System.Drawing.Size(1084, 418);
            this.gridSuppliers.TabIndex = 0;
            this.gridSuppliers.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridSuppliers_CellClick);
            this.gridSuppliers.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridSuppliers_RowEnter);
            this.gridSuppliers.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.gridSuppliers_UserDeletingRow);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showAllToolStripMenuItem,
            this.showActiveToolStripMenuItem,
            this.showInactiveToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(193, 70);
            // 
            // showAllToolStripMenuItem
            // 
            this.showAllToolStripMenuItem.Name = "showAllToolStripMenuItem";
            this.showAllToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.showAllToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.showAllToolStripMenuItem.Text = "Show all";
            this.showAllToolStripMenuItem.Click += new System.EventHandler(this.showAllToolStripMenuItem_Click);
            // 
            // showActiveToolStripMenuItem
            // 
            this.showActiveToolStripMenuItem.Name = "showActiveToolStripMenuItem";
            this.showActiveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.showActiveToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.showActiveToolStripMenuItem.Text = "Show active";
            this.showActiveToolStripMenuItem.Click += new System.EventHandler(this.showActiveToolStripMenuItem_Click);
            // 
            // showInactiveToolStripMenuItem
            // 
            this.showInactiveToolStripMenuItem.Name = "showInactiveToolStripMenuItem";
            this.showInactiveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this.showInactiveToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.showInactiveToolStripMenuItem.Text = "Show disabled";
            this.showInactiveToolStripMenuItem.Click += new System.EventHandler(this.showInactiveToolStripMenuItem_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(820, 184);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(117, 35);
            this.btnAdd.TabIndex = 6;
            this.btnAdd.Text = "Update";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtSupplierName
            // 
            this.txtSupplierName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSupplierName.Location = new System.Drawing.Point(133, 25);
            this.txtSupplierName.Name = "txtSupplierName";
            this.txtSupplierName.Size = new System.Drawing.Size(500, 23);
            this.txtSupplierName.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(16, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Supplier name";
            // 
            // lblSupplierID
            // 
            this.lblSupplierID.AutoSize = true;
            this.lblSupplierID.Location = new System.Drawing.Point(919, 7);
            this.lblSupplierID.Name = "lblSupplierID";
            this.lblSupplierID.Size = new System.Drawing.Size(0, 17);
            this.lblSupplierID.TabIndex = 5;
            this.lblSupplierID.Visible = false;
            // 
            // button1
            // 
            this.button1.CausesValidation = false;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(943, 184);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(117, 35);
            this.button1.TabIndex = 6;
            this.button1.Text = "New";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cbActive
            // 
            this.cbActive.AutoSize = true;
            this.cbActive.Checked = true;
            this.cbActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbActive.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbActive.Location = new System.Drawing.Point(548, 69);
            this.cbActive.Name = "cbActive";
            this.cbActive.Size = new System.Drawing.Size(65, 21);
            this.cbActive.TabIndex = 7;
            this.cbActive.Text = "Active";
            this.cbActive.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(16, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 17);
            this.label3.TabIndex = 10;
            this.label3.Text = "Unique Key";
            // 
            // txtUniqueKey
            // 
            this.txtUniqueKey.Enabled = false;
            this.txtUniqueKey.Location = new System.Drawing.Point(133, 70);
            this.txtUniqueKey.Name = "txtUniqueKey";
            this.txtUniqueKey.Size = new System.Drawing.Size(100, 23);
            this.txtUniqueKey.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(16, 120);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 17);
            this.label4.TabIndex = 12;
            this.label4.Text = "Agency Margin";
            // 
            // txtAgencyMargin
            // 
            this.txtAgencyMargin.Location = new System.Drawing.Point(133, 117);
            this.txtAgencyMargin.Name = "txtAgencyMargin";
            this.txtAgencyMargin.Size = new System.Drawing.Size(100, 23);
            this.txtAgencyMargin.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(16, 162);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 17);
            this.label5.TabIndex = 14;
            this.label5.Text = "Discount";
            // 
            // txtDiscount
            // 
            this.txtDiscount.Location = new System.Drawing.Point(133, 156);
            this.txtDiscount.Name = "txtDiscount";
            this.txtDiscount.Size = new System.Drawing.Size(100, 23);
            this.txtDiscount.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(16, 205);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 17);
            this.label6.TabIndex = 16;
            this.label6.Text = "Gross Margin";
            // 
            // txtGrossMargin
            // 
            this.txtGrossMargin.Location = new System.Drawing.Point(133, 199);
            this.txtGrossMargin.Name = "txtGrossMargin";
            this.txtGrossMargin.Size = new System.Drawing.Size(100, 23);
            this.txtGrossMargin.TabIndex = 5;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.CausesValidation = false;
            this.panel1.Controls.Add(this.lblSpecialsDate);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.lblLastUpdate);
            this.panel1.Controls.Add(this.cbSpecialsActive);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtNotes);
            this.panel1.Controls.Add(this.txtGrossMargin);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txtDiscount);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtAgencyMargin);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtUniqueKey);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.cbActive);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.lblSupplierID);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtSupplierName);
            this.panel1.Controls.Add(this.btnAdd);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1084, 236);
            this.panel1.TabIndex = 7;
            // 
            // lblSpecialsDate
            // 
            this.lblSpecialsDate.AutoSize = true;
            this.lblSpecialsDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSpecialsDate.Location = new System.Drawing.Point(417, 175);
            this.lblSpecialsDate.Name = "lblSpecialsDate";
            this.lblSpecialsDate.Size = new System.Drawing.Size(117, 17);
            this.lblSpecialsDate.TabIndex = 23;
            this.lblSpecialsDate.Text = "specials date text";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(265, 175);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(146, 17);
            this.label8.TabIndex = 22;
            this.label8.Text = "Last Specials Update:";
            // 
            // lblLastUpdate
            // 
            this.lblLastUpdate.AutoSize = true;
            this.lblLastUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLastUpdate.Location = new System.Drawing.Point(417, 205);
            this.lblLastUpdate.Name = "lblLastUpdate";
            this.lblLastUpdate.Size = new System.Drawing.Size(109, 17);
            this.lblLastUpdate.TabIndex = 19;
            this.lblLastUpdate.Text = "Last update text";
            // 
            // cbSpecialsActive
            // 
            this.cbSpecialsActive.AutoSize = true;
            this.cbSpecialsActive.Location = new System.Drawing.Point(548, 96);
            this.cbSpecialsActive.Name = "cbSpecialsActive";
            this.cbSpecialsActive.Size = new System.Drawing.Size(121, 21);
            this.cbSpecialsActive.TabIndex = 21;
            this.cbSpecialsActive.Text = "Specials active";
            this.cbSpecialsActive.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(265, 205);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 17);
            this.label1.TabIndex = 18;
            this.label1.Text = "Last Update:";
            // 
            // txtNotes
            // 
            this.txtNotes.CausesValidation = false;
            this.txtNotes.Location = new System.Drawing.Point(681, 24);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(379, 143);
            this.txtNotes.TabIndex = 17;
            // 
            // frmSuppliers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 762);
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.gridSuppliers);
            this.Controls.Add(this.panel1);
            this.form = this;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmSuppliers";
            this.Text = "Supplier Management";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmSuppliers_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridSuppliers)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gridSuppliers;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem showAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showActiveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showInactiveToolStripMenuItem;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox txtSupplierName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblSupplierID;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox cbActive;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtUniqueKey;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtAgencyMargin;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDiscount;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtGrossMargin;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.Label lblLastUpdate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblSpecialsDate;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox cbSpecialsActive;
    }
}