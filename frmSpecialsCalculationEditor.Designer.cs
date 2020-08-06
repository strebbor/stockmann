namespace Stockman
{
    partial class frmSpecialsCalculationEditor
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
            this.cbOperator = new System.Windows.Forms.ComboBox();
            this.cbTableTwoColumn = new System.Windows.Forms.ComboBox();
            this.cbTableOneColumn = new System.Windows.Forms.ComboBox();
            this.cbTableTwo = new System.Windows.Forms.ComboBox();
            this.cbTableOne = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cbOperator
            // 
            this.cbOperator.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbOperator.FormattingEnabled = true;
            this.cbOperator.Items.AddRange(new object[] {
            "PLUS",
            "MINUS",
            "MULTIPLY",
            "DIVIDE"});
            this.cbOperator.Location = new System.Drawing.Point(164, 113);
            this.cbOperator.Name = "cbOperator";
            this.cbOperator.Size = new System.Drawing.Size(266, 24);
            this.cbOperator.TabIndex = 9;
            // 
            // cbTableTwoColumn
            // 
            this.cbTableTwoColumn.FormattingEnabled = true;
            this.cbTableTwoColumn.Location = new System.Drawing.Point(164, 216);
            this.cbTableTwoColumn.Name = "cbTableTwoColumn";
            this.cbTableTwoColumn.Size = new System.Drawing.Size(266, 24);
            this.cbTableTwoColumn.TabIndex = 8;
            // 
            // cbTableOneColumn
            // 
            this.cbTableOneColumn.FormattingEnabled = true;
            this.cbTableOneColumn.Location = new System.Drawing.Point(164, 62);
            this.cbTableOneColumn.Name = "cbTableOneColumn";
            this.cbTableOneColumn.Size = new System.Drawing.Size(266, 24);
            this.cbTableOneColumn.TabIndex = 7;
            // 
            // cbTableTwo
            // 
            this.cbTableTwo.FormattingEnabled = true;
            this.cbTableTwo.Items.AddRange(new object[] {
            "StockItems",
            "StockItems_Specials"});
            this.cbTableTwo.Location = new System.Drawing.Point(164, 183);
            this.cbTableTwo.Name = "cbTableTwo";
            this.cbTableTwo.Size = new System.Drawing.Size(266, 24);
            this.cbTableTwo.TabIndex = 6;
            // 
            // cbTableOne
            // 
            this.cbTableOne.FormattingEnabled = true;
            this.cbTableOne.Items.AddRange(new object[] {
            "StockItems",
            "StockItems_Specials"});
            this.cbTableOne.Location = new System.Drawing.Point(164, 25);
            this.cbTableOne.Name = "cbTableOne";
            this.cbTableOne.Size = new System.Drawing.Size(266, 24);
            this.cbTableOne.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 190);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 17);
            this.label5.TabIndex = 4;
            this.label5.Text = "Select Table";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 25);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "Select Table";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 123);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Select Operator";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 62);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Select Column";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 223);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select Column";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(511, 210);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(117, 35);
            this.button1.TabIndex = 10;
            this.button1.Text = "Update";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmSpecialsCalculationEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(667, 292);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cbOperator);
            this.Controls.Add(this.cbTableTwoColumn);
            this.Controls.Add(this.cbTableOneColumn);
            this.Controls.Add(this.cbTableTwo);
            this.Controls.Add(this.cbTableOne);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmSpecialsCalculationEditor";
            this.Text = "Specials Calculation Editor";
            this.Load += new System.EventHandler(this.frmSpecialsCalculationEditor_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbTableOne;
        private System.Windows.Forms.ComboBox cbTableTwo;
        private System.Windows.Forms.ComboBox cbTableOneColumn;
        private System.Windows.Forms.ComboBox cbTableTwoColumn;
        private System.Windows.Forms.ComboBox cbOperator;
        private System.Windows.Forms.Button button1;
    }
}