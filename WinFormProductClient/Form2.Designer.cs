namespace WinFormProductClient
{
    partial class Form2
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
            txtCode = new TextBox();
            label1 = new Label();
            dgvPricings = new DataGridView();
            label3 = new Label();
            btnBrowse = new Button();
            groupBox1 = new GroupBox();
            btnCreateSubmit = new Button();
            dtpCreateEff = new DateTimePicker();
            label4 = new Label();
            txtCreateValue = new TextBox();
            label2 = new Label();
            groupBox2 = new GroupBox();
            btnUpdateSubmit = new Button();
            txtUpdateValue = new TextBox();
            label6 = new Label();
            btnDelete = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvPricings).BeginInit();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // txtCode
            // 
            txtCode.Location = new Point(74, 9);
            txtCode.Name = "txtCode";
            txtCode.Size = new Size(217, 27);
            txtCode.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(44, 20);
            label1.TabIndex = 4;
            label1.Text = "Code";
            // 
            // dgvPricings
            // 
            dgvPricings.AllowUserToAddRows = false;
            dgvPricings.AllowUserToDeleteRows = false;
            dgvPricings.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPricings.Location = new Point(12, 70);
            dgvPricings.Name = "dgvPricings";
            dgvPricings.ReadOnly = true;
            dgvPricings.RowHeadersWidth = 51;
            dgvPricings.RowTemplate.Height = 29;
            dgvPricings.Size = new Size(612, 270);
            dgvPricings.TabIndex = 8;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 47);
            label3.Name = "label3";
            label3.Size = new Size(60, 20);
            label3.TabIndex = 9;
            label3.Text = "Pricings";
            // 
            // btnBrowse
            // 
            btnBrowse.Location = new Point(306, 9);
            btnBrowse.Name = "btnBrowse";
            btnBrowse.Size = new Size(94, 29);
            btnBrowse.TabIndex = 10;
            btnBrowse.Text = "Browse";
            btnBrowse.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnCreateSubmit);
            groupBox1.Controls.Add(dtpCreateEff);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(txtCreateValue);
            groupBox1.Controls.Add(label2);
            groupBox1.Location = new Point(12, 357);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(294, 175);
            groupBox1.TabIndex = 11;
            groupBox1.TabStop = false;
            groupBox1.Text = "Creating";
            // 
            // btnCreateSubmit
            // 
            btnCreateSubmit.Location = new Point(186, 128);
            btnCreateSubmit.Name = "btnCreateSubmit";
            btnCreateSubmit.Size = new Size(94, 29);
            btnCreateSubmit.TabIndex = 4;
            btnCreateSubmit.Text = "Submit";
            btnCreateSubmit.UseVisualStyleBackColor = true;
            // 
            // dtpCreateEff
            // 
            dtpCreateEff.Location = new Point(20, 92);
            dtpCreateEff.Name = "dtpCreateEff";
            dtpCreateEff.Size = new Size(260, 27);
            dtpCreateEff.TabIndex = 3;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(15, 69);
            label4.Name = "label4";
            label4.Size = new Size(102, 20);
            label4.TabIndex = 2;
            label4.Text = "Effected From";
            // 
            // txtCreateValue
            // 
            txtCreateValue.Location = new Point(72, 29);
            txtCreateValue.Name = "txtCreateValue";
            txtCreateValue.Size = new Size(106, 27);
            txtCreateValue.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(11, 31);
            label2.Name = "label2";
            label2.Size = new Size(45, 20);
            label2.TabIndex = 0;
            label2.Text = "Value";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btnUpdateSubmit);
            groupBox2.Controls.Add(txtUpdateValue);
            groupBox2.Controls.Add(label6);
            groupBox2.Location = new Point(326, 357);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(294, 89);
            groupBox2.TabIndex = 12;
            groupBox2.TabStop = false;
            groupBox2.Text = "Updating";
            // 
            // btnUpdateSubmit
            // 
            btnUpdateSubmit.Location = new Point(184, 31);
            btnUpdateSubmit.Name = "btnUpdateSubmit";
            btnUpdateSubmit.Size = new Size(94, 29);
            btnUpdateSubmit.TabIndex = 4;
            btnUpdateSubmit.Text = "Submit";
            btnUpdateSubmit.UseVisualStyleBackColor = true;
            // 
            // txtUpdateValue
            // 
            txtUpdateValue.Location = new Point(72, 29);
            txtUpdateValue.Name = "txtUpdateValue";
            txtUpdateValue.Size = new Size(106, 27);
            txtUpdateValue.TabIndex = 1;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(11, 31);
            label6.Name = "label6";
            label6.Size = new Size(45, 20);
            label6.TabIndex = 0;
            label6.Text = "Value";
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(526, 503);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(94, 29);
            btnDelete.TabIndex = 13;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(647, 546);
            Controls.Add(btnDelete);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(btnBrowse);
            Controls.Add(label3);
            Controls.Add(dgvPricings);
            Controls.Add(txtCode);
            Controls.Add(label1);
            Name = "Form2";
            Text = "Product Pricings";
            ((System.ComponentModel.ISupportInitialize)dgvPricings).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox txtCode;
        private Label label1;
        private DataGridView dgvPricings;
        private Label label3;
        private Button btnBrowse;
        private GroupBox groupBox1;
        private Button btnCreateSubmit;
        private DateTimePicker dtpCreateEff;
        private Label label4;
        private TextBox txtCreateValue;
        private Label label2;
        private GroupBox groupBox2;
        private Button btnUpdateSubmit;
        private Label label6;
        private Button btnDelete;
        private TextBox txtUpdateValue;
    }
}