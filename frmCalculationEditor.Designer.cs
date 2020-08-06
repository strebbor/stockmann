namespace Stockman
{
    partial class frmCalculationEditor
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
            this.dgvParseResults = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lbColumns = new System.Windows.Forms.ListBox();
            this.lblColumnName = new System.Windows.Forms.Label();
            this.txtCalculation = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvParseResults)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvParseResults
            // 
            this.dgvParseResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvParseResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvParseResults.Location = new System.Drawing.Point(0, 254);
            this.dgvParseResults.Name = "dgvParseResults";
            this.dgvParseResults.Size = new System.Drawing.Size(719, 179);
            this.dgvParseResults.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightBlue;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.lbColumns);
            this.panel1.Controls.Add(this.lblColumnName);
            this.panel1.Controls.Add(this.txtCalculation);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(719, 254);
            this.panel1.TabIndex = 0;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(410, 166);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(140, 35);
            this.button2.TabIndex = 6;
            this.button2.Text = "Clear Input";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(476, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(230, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "** Remember to add M at the end of numbers **";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(566, 166);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(140, 35);
            this.button1.TabIndex = 2;
            this.button1.Text = "Save Calculation";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(365, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "=";
            // 
            // lbColumns
            // 
            this.lbColumns.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbColumns.FormattingEnabled = true;
            this.lbColumns.ItemHeight = 16;
            this.lbColumns.Location = new System.Drawing.Point(0, 0);
            this.lbColumns.Name = "lbColumns";
            this.lbColumns.Size = new System.Drawing.Size(246, 252);
            this.lbColumns.TabIndex = 1;
            this.lbColumns.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lbColumns_MouseDoubleClick);
            // 
            // lblColumnName
            // 
            this.lblColumnName.AutoSize = true;
            this.lblColumnName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblColumnName.Location = new System.Drawing.Point(252, 74);
            this.lblColumnName.Name = "lblColumnName";
            this.lblColumnName.Size = new System.Drawing.Size(107, 17);
            this.lblColumnName.TabIndex = 2;
            this.lblColumnName.Text = "Column Name";
            // 
            // txtCalculation
            // 
            this.txtCalculation.Location = new System.Drawing.Point(252, 107);
            this.txtCalculation.Name = "txtCalculation";
            this.txtCalculation.Size = new System.Drawing.Size(454, 23);
            this.txtCalculation.TabIndex = 3;
            // 
            // frmCalculationEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(719, 433);
            this.Controls.Add(this.dgvParseResults);
            this.Controls.Add(this.panel1);
            this.Name = "frmCalculationEditor";
            this.Text = "Calculation Editor";
            this.Load += new System.EventHandler(this.frmCalculationEditor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvParseResults)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListBox lbColumns;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblColumnName;
        private System.Windows.Forms.TextBox txtCalculation;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvParseResults;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
    }
}