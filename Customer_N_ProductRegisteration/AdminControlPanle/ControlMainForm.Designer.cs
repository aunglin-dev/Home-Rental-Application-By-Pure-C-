namespace Customer_N_ProductRegisteration.AdminControlPanle
{
    partial class ControlMainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlMainForm));
            this.panel3 = new System.Windows.Forms.Panel();
            this.pictureBoxClose = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label19 = new System.Windows.Forms.Label();
            this.CboType = new System.Windows.Forms.ComboBox();
            this.dgvAppliances = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnClear = new System.Windows.Forms.Button();
            this.label18 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAnnCost = new System.Windows.Forms.TextBox();
            this.txtMonthlyFee = new System.Windows.Forms.TextBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtDimension = new System.Windows.Forms.TextBox();
            this.txtEnergyConsumption = new System.Windows.Forms.TextBox();
            this.txtModel = new System.Windows.Forms.TextBox();
            this.txtType = new System.Windows.Forms.TextBox();
            this.txtColor = new System.Windows.Forms.TextBox();
            this.txtApplianceName = new System.Windows.Forms.TextBox();
            this.NUDQuantity = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureLink = new System.Windows.Forms.PictureBox();
            this.txtBrand = new System.Windows.Forms.TextBox();
            this.txtPowerUsage = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtappId = new System.Windows.Forms.TextBox();
            this.txtdescription = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.btnAdminName = new System.Windows.Forms.Button();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxClose)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAppliances)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUDQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureLink)).BeginInit();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(12)))), ((int)(((byte)(12)))));
            this.panel3.Controls.Add(this.pictureBoxClose);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1240, 56);
            this.panel3.TabIndex = 3;
            // 
            // pictureBoxClose
            // 
            this.pictureBoxClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxClose.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxClose.Image")));
            this.pictureBoxClose.Location = new System.Drawing.Point(1209, 0);
            this.pictureBoxClose.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBoxClose.Name = "pictureBoxClose";
            this.pictureBoxClose.Size = new System.Drawing.Size(31, 29);
            this.pictureBoxClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxClose.TabIndex = 88;
            this.pictureBoxClose.TabStop = false;
            this.pictureBoxClose.Click += new System.EventHandler(this.pictureBoxClose_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Century Gothic", 16F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(90)))), ((int)(((byte)(34)))));
            this.label1.Location = new System.Drawing.Point(17, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(376, 39);
            this.label1.TabIndex = 8;
            this.label1.Text = "Admin Control Panel \r\n";
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.label19);
            this.panel1.Controls.Add(this.CboType);
            this.panel1.Controls.Add(this.dgvAppliances);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(0, 78);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1240, 723);
            this.panel1.TabIndex = 4;
            // 
            // label19
            // 
            this.label19.Location = new System.Drawing.Point(56, 33);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(64, 26);
            this.label19.TabIndex = 91;
            this.label19.Text = "Type :";
            // 
            // CboType
            // 
            this.CboType.FormattingEnabled = true;
            this.CboType.Location = new System.Drawing.Point(145, 33);
            this.CboType.Name = "CboType";
            this.CboType.Size = new System.Drawing.Size(172, 28);
            this.CboType.TabIndex = 90;
            this.CboType.SelectedIndexChanged += new System.EventHandler(this.CboType_SelectedIndexChanged);
            // 
            // dgvAppliances
            // 
            this.dgvAppliances.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAppliances.Location = new System.Drawing.Point(12, 74);
            this.dgvAppliances.Name = "dgvAppliances";
            this.dgvAppliances.RowTemplate.Height = 28;
            this.dgvAppliances.Size = new System.Drawing.Size(1192, 190);
            this.dgvAppliances.TabIndex = 87;
            this.dgvAppliances.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvAppliances_CellMouseClick);
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.Controls.Add(this.btnClear);
            this.panel2.Controls.Add(this.label18);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.txtAnnCost);
            this.panel2.Controls.Add(this.txtMonthlyFee);
            this.panel2.Controls.Add(this.btnDelete);
            this.panel2.Controls.Add(this.btnUpdate);
            this.panel2.Controls.Add(this.btnSave);
            this.panel2.Controls.Add(this.txtDimension);
            this.panel2.Controls.Add(this.txtEnergyConsumption);
            this.panel2.Controls.Add(this.txtModel);
            this.panel2.Controls.Add(this.txtType);
            this.panel2.Controls.Add(this.txtColor);
            this.panel2.Controls.Add(this.txtApplianceName);
            this.panel2.Controls.Add(this.NUDQuantity);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.pictureLink);
            this.panel2.Controls.Add(this.txtBrand);
            this.panel2.Controls.Add(this.txtPowerUsage);
            this.panel2.Controls.Add(this.label14);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.txtappId);
            this.panel2.Controls.Add(this.txtdescription);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.label15);
            this.panel2.Controls.Add(this.label16);
            this.panel2.Location = new System.Drawing.Point(12, 293);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1192, 427);
            this.panel2.TabIndex = 34;
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(90)))), ((int)(((byte)(34)))));
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(355, 359);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(137, 45);
            this.btnClear.TabIndex = 93;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // label18
            // 
            this.label18.Location = new System.Drawing.Point(1148, 186);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(30, 26);
            this.label18.TabIndex = 92;
            this.label18.Text = "$";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(326, 181);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 26);
            this.label2.TabIndex = 91;
            this.label2.Text = "$";
            // 
            // txtAnnCost
            // 
            this.txtAnnCost.Location = new System.Drawing.Point(185, 183);
            this.txtAnnCost.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtAnnCost.Name = "txtAnnCost";
            this.txtAnnCost.Size = new System.Drawing.Size(120, 26);
            this.txtAnnCost.TabIndex = 90;
            // 
            // txtMonthlyFee
            // 
            this.txtMonthlyFee.Location = new System.Drawing.Point(1007, 182);
            this.txtMonthlyFee.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtMonthlyFee.Name = "txtMonthlyFee";
            this.txtMonthlyFee.Size = new System.Drawing.Size(120, 26);
            this.txtMonthlyFee.TabIndex = 88;
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(90)))), ((int)(((byte)(34)))));
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(961, 362);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(137, 45);
            this.btnDelete.TabIndex = 86;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(90)))), ((int)(((byte)(34)))));
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.Location = new System.Drawing.Point(585, 362);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(137, 45);
            this.btnUpdate.TabIndex = 85;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(90)))), ((int)(((byte)(34)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(106, 359);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(137, 45);
            this.btnSave.TabIndex = 82;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtDimension
            // 
            this.txtDimension.Location = new System.Drawing.Point(1007, 12);
            this.txtDimension.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtDimension.Name = "txtDimension";
            this.txtDimension.Size = new System.Drawing.Size(171, 26);
            this.txtDimension.TabIndex = 80;
            // 
            // txtEnergyConsumption
            // 
            this.txtEnergyConsumption.Location = new System.Drawing.Point(1007, 93);
            this.txtEnergyConsumption.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtEnergyConsumption.Name = "txtEnergyConsumption";
            this.txtEnergyConsumption.Size = new System.Drawing.Size(171, 26);
            this.txtEnergyConsumption.TabIndex = 79;
            // 
            // txtModel
            // 
            this.txtModel.Location = new System.Drawing.Point(567, 285);
            this.txtModel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtModel.Name = "txtModel";
            this.txtModel.Size = new System.Drawing.Size(171, 26);
            this.txtModel.TabIndex = 78;
            // 
            // txtType
            // 
            this.txtType.Location = new System.Drawing.Point(567, 233);
            this.txtType.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtType.Name = "txtType";
            this.txtType.Size = new System.Drawing.Size(171, 26);
            this.txtType.TabIndex = 77;
            // 
            // txtColor
            // 
            this.txtColor.Location = new System.Drawing.Point(567, 178);
            this.txtColor.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtColor.Name = "txtColor";
            this.txtColor.Size = new System.Drawing.Size(171, 26);
            this.txtColor.TabIndex = 76;
            // 
            // txtApplianceName
            // 
            this.txtApplianceName.Location = new System.Drawing.Point(567, 9);
            this.txtApplianceName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtApplianceName.Name = "txtApplianceName";
            this.txtApplianceName.Size = new System.Drawing.Size(172, 26);
            this.txtApplianceName.TabIndex = 75;
            // 
            // NUDQuantity
            // 
            this.NUDQuantity.Location = new System.Drawing.Point(1007, 234);
            this.NUDQuantity.Name = "NUDQuantity";
            this.NUDQuantity.Size = new System.Drawing.Size(120, 26);
            this.NUDQuantity.TabIndex = 70;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(788, 91);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(189, 22);
            this.label7.TabIndex = 66;
            this.label7.Text = "EnergyConsumption";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(788, 238);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(85, 22);
            this.label13.TabIndex = 68;
            this.label13.Text = "Quantity";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(416, 183);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 22);
            this.label6.TabIndex = 65;
            this.label6.Text = "Color";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(788, 181);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(123, 22);
            this.label11.TabIndex = 67;
            this.label11.Text = "MonthlyFees";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(419, 231);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 22);
            this.label5.TabIndex = 64;
            this.label5.Text = "Type";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(788, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 22);
            this.label4.TabIndex = 63;
            this.label4.Text = "Dimension";
            // 
            // pictureLink
            // 
            this.pictureLink.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureLink.Location = new System.Drawing.Point(567, 65);
            this.pictureLink.Name = "pictureLink";
            this.pictureLink.Size = new System.Drawing.Size(155, 77);
            this.pictureLink.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureLink.TabIndex = 55;
            this.pictureLink.TabStop = false;
            this.pictureLink.Click += new System.EventHandler(this.pictureLink_Click);
            // 
            // txtBrand
            // 
            this.txtBrand.Location = new System.Drawing.Point(185, 287);
            this.txtBrand.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtBrand.Name = "txtBrand";
            this.txtBrand.Size = new System.Drawing.Size(172, 26);
            this.txtBrand.TabIndex = 53;
            // 
            // txtPowerUsage
            // 
            this.txtPowerUsage.Location = new System.Drawing.Point(185, 231);
            this.txtPowerUsage.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtPowerUsage.Name = "txtPowerUsage";
            this.txtPowerUsage.Size = new System.Drawing.Size(172, 26);
            this.txtPowerUsage.TabIndex = 52;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(419, 97);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(73, 22);
            this.label14.TabIndex = 51;
            this.label14.Text = "Picture";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(419, 285);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 22);
            this.label3.TabIndex = 44;
            this.label3.Text = "Model";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(13, 287);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 22);
            this.label8.TabIndex = 43;
            this.label8.Text = "Brand";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(13, 231);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(123, 22);
            this.label9.TabIndex = 42;
            this.label9.Text = "PowerUsage";
            // 
            // txtappId
            // 
            this.txtappId.Enabled = false;
            this.txtappId.Location = new System.Drawing.Point(185, 9);
            this.txtappId.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtappId.Name = "txtappId";
            this.txtappId.Size = new System.Drawing.Size(172, 26);
            this.txtappId.TabIndex = 41;
            // 
            // txtdescription
            // 
            this.txtdescription.Location = new System.Drawing.Point(185, 65);
            this.txtdescription.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtdescription.Multiline = true;
            this.txtdescription.Name = "txtdescription";
            this.txtdescription.Size = new System.Drawing.Size(171, 85);
            this.txtdescription.TabIndex = 39;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(13, 182);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(163, 22);
            this.label10.TabIndex = 33;
            this.label10.Text = "EstimateAnnCost";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(13, 91);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(111, 22);
            this.label12.TabIndex = 34;
            this.label12.Text = "Description";
            // 
            // label15
            // 
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(382, 9);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(166, 29);
            this.label15.TabIndex = 36;
            this.label15.Text = "ApplianceName";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(13, 9);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(117, 22);
            this.label16.TabIndex = 35;
            this.label16.Text = "ApplianceID";
            // 
            // btnAdminName
            // 
            this.btnAdminName.Location = new System.Drawing.Point(859, 45);
            this.btnAdminName.Name = "btnAdminName";
            this.btnAdminName.Size = new System.Drawing.Size(141, 41);
            this.btnAdminName.TabIndex = 89;
            this.btnAdminName.UseVisualStyleBackColor = true;
            this.btnAdminName.Click += new System.EventHandler(this.btnAdminName_Click);
            // 
            // ControlMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1240, 835);
            this.Controls.Add(this.btnAdminName);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ControlMainForm";
            this.Text = "ControlMainForm";
            this.Load += new System.EventHandler(this.ControlMainForm_Load);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxClose)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAppliances)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUDQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureLink)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtDimension;
        private System.Windows.Forms.TextBox txtEnergyConsumption;
        private System.Windows.Forms.TextBox txtModel;
        private System.Windows.Forms.TextBox txtType;
        private System.Windows.Forms.TextBox txtColor;
        private System.Windows.Forms.TextBox txtApplianceName;
        private System.Windows.Forms.NumericUpDown NUDQuantity;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureLink;
        private System.Windows.Forms.TextBox txtBrand;
        private System.Windows.Forms.TextBox txtPowerUsage;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtappId;
        private System.Windows.Forms.TextBox txtdescription;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.DataGridView dgvAppliances;
        private System.Windows.Forms.PictureBox pictureBoxClose;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAnnCost;
        private System.Windows.Forms.TextBox txtMonthlyFee;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.ComboBox CboType;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Button btnAdminName;
    }
}