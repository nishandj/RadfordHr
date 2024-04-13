namespace RadfordHr
{
    partial class StaffView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StaffView));
            groupBox1 = new GroupBox();
            cbManager = new ComboBox();
            panel3 = new Panel();
            rbActive = new RadioButton();
            rbInactive = new RadioButton();
            rbPending = new RadioButton();
            txtIRDNumber = new TextBox();
            txtOfficeExtension = new TextBox();
            txtCellPhone = new TextBox();
            txtHomePhone = new TextBox();
            txtMiddleInitial = new TextBox();
            txtLastName = new TextBox();
            txtFirstName = new TextBox();
            panel2 = new Panel();
            rbMr = new RadioButton();
            rbMrs = new RadioButton();
            rbSir = new RadioButton();
            rbMiss = new RadioButton();
            panel1 = new Panel();
            rbManager = new RadioButton();
            rbEmployee = new RadioButton();
            label20 = new Label();
            label19 = new Label();
            lblManager = new Label();
            label9 = new Label();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label1 = new Label();
            groupBox2 = new GroupBox();
            btnCancel = new Button();
            btnSave = new Button();
            btnAddNewRecord = new Button();
            groupBox3 = new GroupBox();
            btnExportExcel = new Button();
            btnExportToPdf = new Button();
            label2 = new Label();
            cmbFilter = new ComboBox();
            dgvStaff = new DataGridView();
            groupBox1.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvStaff).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(cbManager);
            groupBox1.Controls.Add(panel3);
            groupBox1.Controls.Add(txtIRDNumber);
            groupBox1.Controls.Add(txtOfficeExtension);
            groupBox1.Controls.Add(txtCellPhone);
            groupBox1.Controls.Add(txtHomePhone);
            groupBox1.Controls.Add(txtMiddleInitial);
            groupBox1.Controls.Add(txtLastName);
            groupBox1.Controls.Add(txtFirstName);
            groupBox1.Controls.Add(panel2);
            groupBox1.Controls.Add(panel1);
            groupBox1.Controls.Add(label20);
            groupBox1.Controls.Add(label19);
            groupBox1.Controls.Add(lblManager);
            groupBox1.Controls.Add(label9);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(882, 233);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Staff Details";
            // 
            // cbManager
            // 
            cbManager.DropDownStyle = ComboBoxStyle.DropDownList;
            cbManager.FormattingEnabled = true;
            cbManager.Location = new Point(541, 152);
            cbManager.Name = "cbManager";
            cbManager.Size = new Size(317, 23);
            cbManager.TabIndex = 36;
            cbManager.SelectedIndexChanged += cbManager_SelectedIndexChanged;
            // 
            // panel3
            // 
            panel3.Controls.Add(rbActive);
            panel3.Controls.Add(rbInactive);
            panel3.Controls.Add(rbPending);
            panel3.Location = new Point(539, 121);
            panel3.Name = "panel3";
            panel3.Size = new Size(319, 29);
            panel3.TabIndex = 35;
            // 
            // rbActive
            // 
            rbActive.AutoSize = true;
            rbActive.Location = new Point(4, 4);
            rbActive.Name = "rbActive";
            rbActive.Size = new Size(58, 19);
            rbActive.TabIndex = 22;
            rbActive.TabStop = true;
            rbActive.Text = "Active";
            rbActive.UseVisualStyleBackColor = true;
            // 
            // rbInactive
            // 
            rbInactive.AutoSize = true;
            rbInactive.Location = new Point(66, 4);
            rbInactive.Name = "rbInactive";
            rbInactive.Size = new Size(66, 19);
            rbInactive.TabIndex = 23;
            rbInactive.TabStop = true;
            rbInactive.Text = "Inactive";
            rbInactive.UseVisualStyleBackColor = true;
            // 
            // rbPending
            // 
            rbPending.AutoSize = true;
            rbPending.Location = new Point(138, 4);
            rbPending.Name = "rbPending";
            rbPending.Size = new Size(69, 19);
            rbPending.TabIndex = 24;
            rbPending.TabStop = true;
            rbPending.Text = "Pending";
            rbPending.UseVisualStyleBackColor = true;
            // 
            // txtIRDNumber
            // 
            txtIRDNumber.Location = new Point(541, 97);
            txtIRDNumber.Name = "txtIRDNumber";
            txtIRDNumber.Size = new Size(317, 23);
            txtIRDNumber.TabIndex = 34;
            // 
            // txtOfficeExtension
            // 
            txtOfficeExtension.Location = new Point(541, 67);
            txtOfficeExtension.Name = "txtOfficeExtension";
            txtOfficeExtension.Size = new Size(317, 23);
            txtOfficeExtension.TabIndex = 33;
            // 
            // txtCellPhone
            // 
            txtCellPhone.Location = new Point(541, 36);
            txtCellPhone.Name = "txtCellPhone";
            txtCellPhone.Size = new Size(317, 23);
            txtCellPhone.TabIndex = 32;
            // 
            // txtHomePhone
            // 
            txtHomePhone.Location = new Point(108, 187);
            txtHomePhone.Name = "txtHomePhone";
            txtHomePhone.Size = new Size(317, 23);
            txtHomePhone.TabIndex = 31;
            // 
            // txtMiddleInitial
            // 
            txtMiddleInitial.Location = new Point(108, 154);
            txtMiddleInitial.Name = "txtMiddleInitial";
            txtMiddleInitial.Size = new Size(317, 23);
            txtMiddleInitial.TabIndex = 30;
            // 
            // txtLastName
            // 
            txtLastName.Location = new Point(108, 119);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(317, 23);
            txtLastName.TabIndex = 29;
            // 
            // txtFirstName
            // 
            txtFirstName.Location = new Point(108, 89);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(317, 23);
            txtFirstName.TabIndex = 28;
            // 
            // panel2
            // 
            panel2.Controls.Add(rbMr);
            panel2.Controls.Add(rbMrs);
            panel2.Controls.Add(rbSir);
            panel2.Controls.Add(rbMiss);
            panel2.Location = new Point(104, 59);
            panel2.Name = "panel2";
            panel2.Size = new Size(202, 29);
            panel2.TabIndex = 27;
            // 
            // rbMr
            // 
            rbMr.AutoSize = true;
            rbMr.Location = new Point(4, 4);
            rbMr.Name = "rbMr";
            rbMr.Size = new Size(40, 19);
            rbMr.TabIndex = 22;
            rbMr.TabStop = true;
            rbMr.Text = "Mr";
            rbMr.UseVisualStyleBackColor = true;
            // 
            // rbMrs
            // 
            rbMrs.AutoSize = true;
            rbMrs.Location = new Point(50, 4);
            rbMrs.Name = "rbMrs";
            rbMrs.Size = new Size(45, 19);
            rbMrs.TabIndex = 23;
            rbMrs.TabStop = true;
            rbMrs.Text = "Mrs";
            rbMrs.UseVisualStyleBackColor = true;
            // 
            // rbSir
            // 
            rbSir.AutoSize = true;
            rbSir.Location = new Point(156, 4);
            rbSir.Name = "rbSir";
            rbSir.Size = new Size(38, 19);
            rbSir.TabIndex = 25;
            rbSir.TabStop = true;
            rbSir.Text = "Sir";
            rbSir.UseVisualStyleBackColor = true;
            // 
            // rbMiss
            // 
            rbMiss.AutoSize = true;
            rbMiss.Location = new Point(101, 4);
            rbMiss.Name = "rbMiss";
            rbMiss.Size = new Size(49, 19);
            rbMiss.TabIndex = 24;
            rbMiss.TabStop = true;
            rbMiss.Text = "Miss";
            rbMiss.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.Controls.Add(rbManager);
            panel1.Controls.Add(rbEmployee);
            panel1.Location = new Point(104, 31);
            panel1.Name = "panel1";
            panel1.Size = new Size(167, 28);
            panel1.TabIndex = 26;
            // 
            // rbManager
            // 
            rbManager.AutoSize = true;
            rbManager.Location = new Point(87, 4);
            rbManager.Name = "rbManager";
            rbManager.Size = new Size(72, 19);
            rbManager.TabIndex = 23;
            rbManager.TabStop = true;
            rbManager.Text = "Manager";
            rbManager.UseVisualStyleBackColor = true;
            rbManager.CheckedChanged += rbManager_CheckedChanged;
            // 
            // rbEmployee
            // 
            rbEmployee.AutoSize = true;
            rbEmployee.Location = new Point(4, 4);
            rbEmployee.Name = "rbEmployee";
            rbEmployee.Size = new Size(77, 19);
            rbEmployee.TabIndex = 22;
            rbEmployee.TabStop = true;
            rbEmployee.Text = "Employee";
            rbEmployee.UseVisualStyleBackColor = true;
            rbEmployee.CheckedChanged += rbEmployee_CheckedChanged;
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Location = new Point(431, 97);
            label20.Name = "label20";
            label20.Size = new Size(100, 15);
            label20.TabIndex = 19;
            label20.Text = "IRD (Tax) Number";
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Location = new Point(431, 127);
            label19.Name = "label19";
            label19.Size = new Size(39, 15);
            label19.TabIndex = 18;
            label19.Text = "Status";
            // 
            // lblManager
            // 
            lblManager.AutoSize = true;
            lblManager.Location = new Point(431, 157);
            lblManager.Name = "lblManager";
            lblManager.Size = new Size(54, 15);
            lblManager.TabIndex = 17;
            lblManager.Text = "Manager";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(6, 67);
            label9.Name = "label9";
            label9.Size = new Size(29, 15);
            label9.TabIndex = 8;
            label9.Text = "Title";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(6, 97);
            label8.Name = "label8";
            label8.Size = new Size(64, 15);
            label8.TabIndex = 7;
            label8.Text = "First Name";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(6, 127);
            label7.Name = "label7";
            label7.Size = new Size(63, 15);
            label7.TabIndex = 6;
            label7.Text = "Last Name";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(6, 157);
            label6.Name = "label6";
            label6.Size = new Size(76, 15);
            label6.TabIndex = 5;
            label6.Text = "Middle Initial";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(6, 187);
            label5.Name = "label5";
            label5.Size = new Size(77, 15);
            label5.TabIndex = 4;
            label5.Text = "Home Phone";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(431, 37);
            label4.Name = "label4";
            label4.Size = new Size(64, 15);
            label4.TabIndex = 3;
            label4.Text = "Cell Phone";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(431, 67);
            label3.Name = "label3";
            label3.Size = new Size(93, 15);
            label3.TabIndex = 2;
            label3.Text = "Office Extension";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 37);
            label1.Name = "label1";
            label1.Size = new Size(31, 15);
            label1.TabIndex = 0;
            label1.Text = "Type";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btnCancel);
            groupBox2.Controls.Add(btnSave);
            groupBox2.Controls.Add(btnAddNewRecord);
            groupBox2.Location = new Point(900, 12);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(152, 233);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Manage";
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(6, 169);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(140, 51);
            btnCancel.TabIndex = 2;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(6, 97);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(140, 51);
            btnSave.TabIndex = 1;
            btnSave.Text = "Save Staff Details";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnAddNewRecord
            // 
            btnAddNewRecord.Location = new Point(6, 29);
            btnAddNewRecord.Name = "btnAddNewRecord";
            btnAddNewRecord.Size = new Size(140, 59);
            btnAddNewRecord.TabIndex = 0;
            btnAddNewRecord.Text = "Add New Record";
            btnAddNewRecord.UseVisualStyleBackColor = true;
            btnAddNewRecord.Click += btnAddNewRecord_Click;
            // 
            // groupBox3
            // 
            groupBox3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox3.Controls.Add(btnExportExcel);
            groupBox3.Controls.Add(btnExportToPdf);
            groupBox3.Controls.Add(label2);
            groupBox3.Controls.Add(cmbFilter);
            groupBox3.Controls.Add(dgvStaff);
            groupBox3.Location = new Point(12, 251);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(1040, 455);
            groupBox3.TabIndex = 2;
            groupBox3.TabStop = false;
            groupBox3.Text = "List of Staff";
            // 
            // btnExportExcel
            // 
            btnExportExcel.Location = new Point(904, 22);
            btnExportExcel.Name = "btnExportExcel";
            btnExportExcel.Size = new Size(130, 23);
            btnExportExcel.TabIndex = 41;
            btnExportExcel.Text = "Export to EXCEL";
            btnExportExcel.UseVisualStyleBackColor = true;
            btnExportExcel.Click += btnExportExcel_Click;
            // 
            // btnExportToPdf
            // 
            btnExportToPdf.Location = new Point(768, 22);
            btnExportToPdf.Name = "btnExportToPdf";
            btnExportToPdf.Size = new Size(130, 23);
            btnExportToPdf.TabIndex = 40;
            btnExportToPdf.Text = "Export to PDF";
            btnExportToPdf.UseVisualStyleBackColor = true;
            btnExportToPdf.Click += btnExportToPdf_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 25);
            label2.Name = "label2";
            label2.Size = new Size(90, 15);
            label2.TabIndex = 38;
            label2.Text = "Show Records : ";
            // 
            // cmbFilter
            // 
            cmbFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFilter.FormattingEnabled = true;
            cmbFilter.Items.AddRange(new object[] { "All", "Active", "Inactive", "Pending" });
            cmbFilter.Location = new Point(108, 22);
            cmbFilter.Name = "cmbFilter";
            cmbFilter.Size = new Size(127, 23);
            cmbFilter.TabIndex = 37;
            cmbFilter.SelectedIndexChanged += cmbFilter_SelectedIndexChanged;
            // 
            // dgvStaff
            // 
            dgvStaff.AllowUserToAddRows = false;
            dgvStaff.AllowUserToDeleteRows = false;
            dgvStaff.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvStaff.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvStaff.Location = new Point(6, 51);
            dgvStaff.Name = "dgvStaff";
            dgvStaff.ReadOnly = true;
            dgvStaff.Size = new Size(1028, 398);
            dgvStaff.TabIndex = 0;
            dgvStaff.CellClick += dgvStaff_CellClick;
            // 
            // StaffView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1064, 718);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "StaffView";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Staff";
            Load += StaffView_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvStaff).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private Label label9;
        private Label label8;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label1;
        private Label label20;
        private Label label19;
        private Label lblManager;
        private RadioButton rbSir;
        private RadioButton rbMiss;
        private RadioButton rbMrs;
        private RadioButton rbMr;
        private Panel panel1;
        private Panel panel2;
        private TextBox txtIRDNumber;
        private TextBox txtOfficeExtension;
        private TextBox txtCellPhone;
        private TextBox txtHomePhone;
        private TextBox txtMiddleInitial;
        private TextBox txtLastName;
        private TextBox txtFirstName;
        private Panel panel3;
        private RadioButton rbActive;
        private RadioButton rbInactive;
        private RadioButton rbPending;
        private ComboBox cbManager;
        private Button btnSave;
        private Button btnAddNewRecord;
        private RadioButton rbEmployee;
        private RadioButton rbManager;
        private Button btnCancel;
        private DataGridView dgvStaff;
        private ComboBox cmbFilter;
        private Label label2;
        private Button btnExportExcel;
        private Button btnExportToPdf;
    }
}