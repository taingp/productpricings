﻿namespace WinFormProductClient
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dgvProducts = new DataGridView();
            btnRefresh = new Button();
            groupBox1 = new GroupBox();
            txtCreatePrice = new TextBox();
            label7 = new Label();
            btnCreateClear = new Button();
            cboCreateCat = new ComboBox();
            btnCreateSubmit = new Button();
            label3 = new Label();
            txtCreateName = new TextBox();
            label2 = new Label();
            txtCreateCode = new TextBox();
            label1 = new Label();
            groupBox2 = new GroupBox();
            btnPricings = new Button();
            txtUpdatePrice = new TextBox();
            label8 = new Label();
            cboUpdateCat = new ComboBox();
            label4 = new Label();
            txtUpdateName = new TextBox();
            label5 = new Label();
            txtUpdateCode = new TextBox();
            label6 = new Label();
            btnUpdateSubmit = new Button();
            btnDelete = new Button();
            chkInc = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)dgvProducts).BeginInit();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // dgvProducts
            // 
            dgvProducts.AllowUserToAddRows = false;
            dgvProducts.AllowUserToDeleteRows = false;
            dgvProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProducts.Location = new Point(18, 52);
            dgvProducts.Name = "dgvProducts";
            dgvProducts.ReadOnly = true;
            dgvProducts.RowHeadersWidth = 51;
            dgvProducts.RowTemplate.Height = 29;
            dgvProducts.Size = new Size(779, 483);
            dgvProducts.TabIndex = 0;
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(20, 9);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(94, 29);
            btnRefresh.TabIndex = 1;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtCreatePrice);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(btnCreateClear);
            groupBox1.Controls.Add(cboCreateCat);
            groupBox1.Controls.Add(btnCreateSubmit);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(txtCreateName);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(txtCreateCode);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(825, 41);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(297, 230);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Creating Products";
            // 
            // txtCreatePrice
            // 
            txtCreatePrice.Location = new Point(61, 159);
            txtCreatePrice.Name = "txtCreatePrice";
            txtCreatePrice.Size = new Size(111, 27);
            txtCreatePrice.TabIndex = 10;
            txtCreatePrice.TextAlign = HorizontalAlignment.Right;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(13, 162);
            label7.Name = "label7";
            label7.Size = new Size(41, 20);
            label7.TabIndex = 9;
            label7.Text = "Price";
            // 
            // btnCreateClear
            // 
            btnCreateClear.Location = new Point(88, 195);
            btnCreateClear.Name = "btnCreateClear";
            btnCreateClear.Size = new Size(84, 28);
            btnCreateClear.TabIndex = 8;
            btnCreateClear.Text = "Clear";
            btnCreateClear.UseVisualStyleBackColor = true;
            // 
            // cboCreateCat
            // 
            cboCreateCat.DropDownStyle = ComboBoxStyle.DropDownList;
            cboCreateCat.FormattingEnabled = true;
            cboCreateCat.Location = new Point(88, 114);
            cboCreateCat.Name = "cboCreateCat";
            cboCreateCat.Size = new Size(190, 28);
            cboCreateCat.TabIndex = 7;
            // 
            // btnCreateSubmit
            // 
            btnCreateSubmit.Location = new Point(184, 195);
            btnCreateSubmit.Name = "btnCreateSubmit";
            btnCreateSubmit.Size = new Size(94, 29);
            btnCreateSubmit.TabIndex = 6;
            btnCreateSubmit.Text = "Submit";
            btnCreateSubmit.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(13, 116);
            label3.Name = "label3";
            label3.Size = new Size(69, 20);
            label3.TabIndex = 4;
            label3.Text = "Category";
            // 
            // txtCreateName
            // 
            txtCreateName.Location = new Point(61, 69);
            txtCreateName.Name = "txtCreateName";
            txtCreateName.Size = new Size(217, 27);
            txtCreateName.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(13, 72);
            label2.Name = "label2";
            label2.Size = new Size(49, 20);
            label2.TabIndex = 2;
            label2.Text = "Name";
            // 
            // txtCreateCode
            // 
            txtCreateCode.Location = new Point(61, 27);
            txtCreateCode.Name = "txtCreateCode";
            txtCreateCode.Size = new Size(217, 27);
            txtCreateCode.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(13, 30);
            label1.Name = "label1";
            label1.Size = new Size(44, 20);
            label1.TabIndex = 0;
            label1.Text = "Code";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btnPricings);
            groupBox2.Controls.Add(txtUpdatePrice);
            groupBox2.Controls.Add(label8);
            groupBox2.Controls.Add(cboUpdateCat);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(txtUpdateName);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(txtUpdateCode);
            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(btnUpdateSubmit);
            groupBox2.Location = new Point(825, 288);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(297, 247);
            groupBox2.TabIndex = 3;
            groupBox2.TabStop = false;
            groupBox2.Text = "Updating Products";
            // 
            // btnPricings
            // 
            btnPricings.Location = new Point(187, 159);
            btnPricings.Name = "btnPricings";
            btnPricings.Size = new Size(94, 29);
            btnPricings.TabIndex = 16;
            btnPricings.Text = "Pricings";
            btnPricings.UseVisualStyleBackColor = true;
            // 
            // txtUpdatePrice
            // 
            txtUpdatePrice.Location = new Point(64, 161);
            txtUpdatePrice.Name = "txtUpdatePrice";
            txtUpdatePrice.Size = new Size(111, 27);
            txtUpdatePrice.TabIndex = 15;
            txtUpdatePrice.TextAlign = HorizontalAlignment.Right;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(16, 164);
            label8.Name = "label8";
            label8.Size = new Size(41, 20);
            label8.TabIndex = 14;
            label8.Text = "Price";
            // 
            // cboUpdateCat
            // 
            cboUpdateCat.DropDownStyle = ComboBoxStyle.DropDownList;
            cboUpdateCat.FormattingEnabled = true;
            cboUpdateCat.Location = new Point(91, 115);
            cboUpdateCat.Name = "cboUpdateCat";
            cboUpdateCat.Size = new Size(190, 28);
            cboUpdateCat.TabIndex = 13;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(16, 117);
            label4.Name = "label4";
            label4.Size = new Size(69, 20);
            label4.TabIndex = 12;
            label4.Text = "Category";
            // 
            // txtUpdateName
            // 
            txtUpdateName.Location = new Point(64, 70);
            txtUpdateName.Name = "txtUpdateName";
            txtUpdateName.Size = new Size(217, 27);
            txtUpdateName.TabIndex = 11;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(16, 73);
            label5.Name = "label5";
            label5.Size = new Size(49, 20);
            label5.TabIndex = 10;
            label5.Text = "Name";
            // 
            // txtUpdateCode
            // 
            txtUpdateCode.Location = new Point(64, 28);
            txtUpdateCode.Name = "txtUpdateCode";
            txtUpdateCode.ReadOnly = true;
            txtUpdateCode.Size = new Size(217, 27);
            txtUpdateCode.TabIndex = 9;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(16, 31);
            label6.Name = "label6";
            label6.Size = new Size(44, 20);
            label6.TabIndex = 8;
            label6.Text = "Code";
            // 
            // btnUpdateSubmit
            // 
            btnUpdateSubmit.Location = new Point(187, 198);
            btnUpdateSubmit.Name = "btnUpdateSubmit";
            btnUpdateSubmit.Size = new Size(94, 29);
            btnUpdateSubmit.TabIndex = 6;
            btnUpdateSubmit.Text = "Submit";
            btnUpdateSubmit.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(703, 553);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(94, 29);
            btnDelete.TabIndex = 4;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            // 
            // chkInc
            // 
            chkInc.AutoSize = true;
            chkInc.Location = new Point(572, 556);
            chkInc.Name = "chkInc";
            chkInc.Size = new Size(125, 24);
            chkInc.TabIndex = 5;
            chkInc.Text = "Price Inclusion";
            chkInc.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1145, 601);
            Controls.Add(chkInc);
            Controls.Add(btnDelete);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(btnRefresh);
            Controls.Add(dgvProducts);
            Name = "Form1";
            Text = "Delete";
            ((System.ComponentModel.ISupportInitialize)dgvProducts).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvProducts;
        private Button btnRefresh;
        private GroupBox groupBox1;
        private Button btnCreateSubmit;
        private Label label3;
        private TextBox txtCreateName;
        private Label label2;
        private TextBox txtCreateCode;
        private Label label1;
        private GroupBox groupBox2;
        private Button btnUpdateSubmit;
        private Button btnDelete;
        private Button btnCreateClear;
        private ComboBox cboCreateCat;
        private ComboBox cboUpdateCat;
        private Label label4;
        private TextBox txtUpdateName;
        private Label label5;
        private TextBox txtUpdateCode;
        private Label label6;
        private TextBox txtCreatePrice;
        private Label label7;
        private TextBox txtUpdatePrice;
        private Label label8;
        private Button btnPricings;
        private CheckBox chkInc;
    }
}