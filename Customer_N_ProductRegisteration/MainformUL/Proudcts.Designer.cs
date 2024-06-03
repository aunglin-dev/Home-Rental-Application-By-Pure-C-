namespace Customer_N_ProductRegisteration.MainformUL
{
    partial class Proudcts
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.CboType = new System.Windows.Forms.ComboBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.customersTableAdapter1 = new Customer_N_ProductRegisteration.RentalTableAdapters.CustomersTableAdapter();
            this.CboSearchBy = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // CboType
            // 
            this.CboType.FormattingEnabled = true;
            this.CboType.Location = new System.Drawing.Point(46, 47);
            this.CboType.Name = "CboType";
            this.CboType.Size = new System.Drawing.Size(172, 28);
            this.CboType.TabIndex = 7;
            this.CboType.SelectedIndexChanged += new System.EventHandler(this.CboType_SelectedIndexChanged);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(46, 81);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(986, 458);
            this.flowLayoutPanel1.TabIndex = 8;
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(562, 47);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(285, 26);
            this.txtSearch.TabIndex = 9;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(283, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 26);
            this.label1.TabIndex = 10;
            this.label1.Text = "Search By :";
            // 
            // customersTableAdapter1
            // 
            this.customersTableAdapter1.ClearBeforeFill = true;
            // 
            // CboSearchBy
            // 
            this.CboSearchBy.FormattingEnabled = true;
            this.CboSearchBy.Location = new System.Drawing.Point(287, 47);
            this.CboSearchBy.Name = "CboSearchBy";
            this.CboSearchBy.Size = new System.Drawing.Size(172, 28);
            this.CboSearchBy.TabIndex = 11;
            this.CboSearchBy.SelectedIndexChanged += new System.EventHandler(this.CboSearchBy_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(42, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 26);
            this.label2.TabIndex = 12;
            this.label2.Text = "Type   :   ";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(558, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(134, 26);
            this.label3.TabIndex = 13;
            this.label3.Text = "Search Bar :";
            // 
            // Proudcts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CboSearchBy);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.CboType);
            this.Name = "Proudcts";
            this.Size = new System.Drawing.Size(1035, 611);
            this.Load += new System.EventHandler(this.Proudcts_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox CboType;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label1;
        private RentalTableAdapters.CustomersTableAdapter customersTableAdapter1;
        private System.Windows.Forms.ComboBox CboSearchBy;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;



    }
}
