namespace finals_UI
{
    partial class manage_payment
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
            this.txtfullname = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.CBpaymentmethod = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtpaid = new System.Windows.Forms.TextBox();
            this.btnreceipt = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.txtinvtot = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.button14 = new System.Windows.Forms.Button();
            this.txtinvoice = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtbal = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btngo = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtplateNo = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtfullname
            // 
            this.txtfullname.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.txtfullname.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtfullname.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtfullname.ForeColor = System.Drawing.Color.White;
            this.txtfullname.Location = new System.Drawing.Point(312, 123);
            this.txtfullname.Multiline = true;
            this.txtfullname.Name = "txtfullname";
            this.txtfullname.ReadOnly = true;
            this.txtfullname.Size = new System.Drawing.Size(241, 30);
            this.txtfullname.TabIndex = 45;
            this.txtfullname.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(161)))), ((int)(((byte)(176)))));
            this.label2.Location = new System.Drawing.Point(59, 123);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 23);
            this.label2.TabIndex = 44;
            this.label2.Text = "Full Name";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(161)))), ((int)(((byte)(176)))));
            this.label5.Location = new System.Drawing.Point(111, 611);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(159, 23);
            this.label5.TabIndex = 52;
            this.label5.Text = "Payment Method";
            // 
            // CBpaymentmethod
            // 
            this.CBpaymentmethod.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(79)))), ((int)(((byte)(99)))));
            this.CBpaymentmethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBpaymentmethod.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CBpaymentmethod.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CBpaymentmethod.ForeColor = System.Drawing.Color.White;
            this.CBpaymentmethod.FormattingEnabled = true;
            this.CBpaymentmethod.Items.AddRange(new object[] {
            "Cash",
            "Card",
            "Online"});
            this.CBpaymentmethod.Location = new System.Drawing.Point(431, 611);
            this.CBpaymentmethod.Name = "CBpaymentmethod";
            this.CBpaymentmethod.Size = new System.Drawing.Size(177, 27);
            this.CBpaymentmethod.TabIndex = 53;
            this.CBpaymentmethod.SelectedIndexChanged += new System.EventHandler(this.CBpaymentmethod_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(161)))), ((int)(((byte)(176)))));
            this.label6.Location = new System.Drawing.Point(112, 536);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(120, 23);
            this.label6.TabIndex = 54;
            this.label6.Text = "Paid Amount";
            // 
            // txtpaid
            // 
            this.txtpaid.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(79)))), ((int)(((byte)(99)))));
            this.txtpaid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtpaid.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtpaid.ForeColor = System.Drawing.Color.White;
            this.txtpaid.Location = new System.Drawing.Point(431, 529);
            this.txtpaid.Multiline = true;
            this.txtpaid.Name = "txtpaid";
            this.txtpaid.Size = new System.Drawing.Size(148, 30);
            this.txtpaid.TabIndex = 55;
            this.txtpaid.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtpaid_KeyPress);
            this.txtpaid.Leave += new System.EventHandler(this.txtpaid_Leave);
            // 
            // btnreceipt
            // 
            this.btnreceipt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(184)))), ((int)(((byte)(206)))));
            this.btnreceipt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnreceipt.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnreceipt.Location = new System.Drawing.Point(296, 800);
            this.btnreceipt.Name = "btnreceipt";
            this.btnreceipt.Size = new System.Drawing.Size(205, 33);
            this.btnreceipt.TabIndex = 57;
            this.btnreceipt.Text = "Generate Receipt";
            this.btnreceipt.UseVisualStyleBackColor = false;
            this.btnreceipt.Click += new System.EventHandler(this.btnreceipt_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(161)))), ((int)(((byte)(176)))));
            this.label7.Location = new System.Drawing.Point(112, 460);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(119, 23);
            this.label7.TabIndex = 58;
            this.label7.Text = "Invoice Total";
            // 
            // txtinvtot
            // 
            this.txtinvtot.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(79)))), ((int)(((byte)(99)))));
            this.txtinvtot.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtinvtot.Font = new System.Drawing.Font("Arial Black", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtinvtot.ForeColor = System.Drawing.Color.White;
            this.txtinvtot.Location = new System.Drawing.Point(431, 460);
            this.txtinvtot.Multiline = true;
            this.txtinvtot.Name = "txtinvtot";
            this.txtinvtot.ReadOnly = true;
            this.txtinvtot.Size = new System.Drawing.Size(148, 30);
            this.txtinvtot.TabIndex = 59;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial Black", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(109, 84);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(359, 40);
            this.label9.TabIndex = 60;
            this.label9.Text = "Payment Management";
            // 
            // button14
            // 
            this.button14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.button14.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button14.Font = new System.Drawing.Font("Arial Black", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(161)))), ((int)(((byte)(176)))));
            this.button14.Location = new System.Drawing.Point(1460, 12);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(30, 28);
            this.button14.TabIndex = 76;
            this.button14.Text = "X";
            this.button14.UseVisualStyleBackColor = false;
            this.button14.Click += new System.EventHandler(this.button14_Click);
            // 
            // txtinvoice
            // 
            this.txtinvoice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(79)))), ((int)(((byte)(99)))));
            this.txtinvoice.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtinvoice.Font = new System.Drawing.Font("Arial Black", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtinvoice.ForeColor = System.Drawing.Color.White;
            this.txtinvoice.Location = new System.Drawing.Point(427, 153);
            this.txtinvoice.Multiline = true;
            this.txtinvoice.Name = "txtinvoice";
            this.txtinvoice.Size = new System.Drawing.Size(177, 30);
            this.txtinvoice.TabIndex = 116;
            this.txtinvoice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(161)))), ((int)(((byte)(176)))));
            this.label8.Location = new System.Drawing.Point(111, 160);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(101, 23);
            this.label8.TabIndex = 117;
            this.label8.Text = "Invoice No";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // txtbal
            // 
            this.txtbal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(79)))), ((int)(((byte)(99)))));
            this.txtbal.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtbal.Font = new System.Drawing.Font("Arial Black", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbal.ForeColor = System.Drawing.Color.White;
            this.txtbal.Location = new System.Drawing.Point(431, 674);
            this.txtbal.Multiline = true;
            this.txtbal.Name = "txtbal";
            this.txtbal.ReadOnly = true;
            this.txtbal.Size = new System.Drawing.Size(148, 30);
            this.txtbal.TabIndex = 118;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(161)))), ((int)(((byte)(176)))));
            this.label1.Location = new System.Drawing.Point(112, 681);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 23);
            this.label1.TabIndex = 119;
            this.label1.Text = "Balance";
            // 
            // btngo
            // 
            this.btngo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(184)))), ((int)(((byte)(206)))));
            this.btngo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btngo.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btngo.Location = new System.Drawing.Point(743, 153);
            this.btngo.Name = "btngo";
            this.btngo.Size = new System.Drawing.Size(72, 33);
            this.btngo.TabIndex = 120;
            this.btngo.Text = "GO";
            this.btngo.UseVisualStyleBackColor = false;
            this.btngo.Click += new System.EventHandler(this.btngo_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(79)))), ((int)(((byte)(99)))));
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.txtfullname);
            this.groupBox1.Controls.Add(this.txtplateNo);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Font = new System.Drawing.Font("Arial Black", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.groupBox1.Location = new System.Drawing.Point(115, 214);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(700, 188);
            this.groupBox1.TabIndex = 121;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Customer Details";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(161)))), ((int)(((byte)(176)))));
            this.label11.Location = new System.Drawing.Point(59, 58);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(197, 23);
            this.label11.TabIndex = 65;
            this.label11.Text = "Vehicle Plate Number";
            // 
            // txtplateNo
            // 
            this.txtplateNo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.txtplateNo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtplateNo.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtplateNo.ForeColor = System.Drawing.Color.White;
            this.txtplateNo.Location = new System.Drawing.Point(312, 62);
            this.txtplateNo.Multiline = true;
            this.txtplateNo.Name = "txtplateNo";
            this.txtplateNo.ReadOnly = true;
            this.txtplateNo.Size = new System.Drawing.Size(177, 30);
            this.txtplateNo.TabIndex = 47;
            // 
            // manage_payment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.ClientSize = new System.Drawing.Size(949, 1012);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btngo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtbal);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtinvoice);
            this.Controls.Add(this.button14);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtinvtot);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnreceipt);
            this.Controls.Add(this.txtpaid);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.CBpaymentmethod);
            this.Controls.Add(this.label5);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "manage_payment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "payment";
            this.Load += new System.EventHandler(this.payment_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtfullname;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox CBpaymentmethod;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtpaid;
        private System.Windows.Forms.Button btnreceipt;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtinvtot;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button button14;
        private System.Windows.Forms.TextBox txtinvoice;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtbal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btngo;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtplateNo;
    }
}