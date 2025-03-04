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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(manage_payment));
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.btnacc = new System.Windows.Forms.Button();
            this.btncust = new System.Windows.Forms.Button();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnlogout = new System.Windows.Forms.Button();
            this.btnpayment = new System.Windows.Forms.Button();
            this.btnsales = new System.Windows.Forms.Button();
            this.btnappt = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtfullname
            // 
            this.txtfullname.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.txtfullname.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtfullname.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtfullname.ForeColor = System.Drawing.Color.White;
            this.txtfullname.Location = new System.Drawing.Point(351, 154);
            this.txtfullname.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtfullname.Multiline = true;
            this.txtfullname.Name = "txtfullname";
            this.txtfullname.ReadOnly = true;
            this.txtfullname.Size = new System.Drawing.Size(271, 38);
            this.txtfullname.TabIndex = 45;
            this.txtfullname.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(161)))), ((int)(((byte)(176)))));
            this.label2.Location = new System.Drawing.Point(66, 154);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 27);
            this.label2.TabIndex = 44;
            this.label2.Text = "Full Name";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(161)))), ((int)(((byte)(176)))));
            this.label5.Location = new System.Drawing.Point(534, 774);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(194, 27);
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
            this.CBpaymentmethod.Location = new System.Drawing.Point(894, 774);
            this.CBpaymentmethod.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.CBpaymentmethod.Name = "CBpaymentmethod";
            this.CBpaymentmethod.Size = new System.Drawing.Size(199, 31);
            this.CBpaymentmethod.TabIndex = 53;
            this.CBpaymentmethod.SelectedIndexChanged += new System.EventHandler(this.CBpaymentmethod_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(161)))), ((int)(((byte)(176)))));
            this.label6.Location = new System.Drawing.Point(536, 680);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(149, 27);
            this.label6.TabIndex = 54;
            this.label6.Text = "Paid Amount";
            // 
            // txtpaid
            // 
            this.txtpaid.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(79)))), ((int)(((byte)(99)))));
            this.txtpaid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtpaid.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtpaid.ForeColor = System.Drawing.Color.White;
            this.txtpaid.Location = new System.Drawing.Point(894, 671);
            this.txtpaid.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtpaid.Multiline = true;
            this.txtpaid.Name = "txtpaid";
            this.txtpaid.Size = new System.Drawing.Size(166, 38);
            this.txtpaid.TabIndex = 55;
            this.txtpaid.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtpaid_KeyPress);
            this.txtpaid.Leave += new System.EventHandler(this.txtpaid_Leave);
            // 
            // btnreceipt
            // 
            this.btnreceipt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(184)))), ((int)(((byte)(206)))));
            this.btnreceipt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnreceipt.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnreceipt.Location = new System.Drawing.Point(742, 1010);
            this.btnreceipt.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnreceipt.Name = "btnreceipt";
            this.btnreceipt.Size = new System.Drawing.Size(231, 41);
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
            this.label7.Location = new System.Drawing.Point(536, 585);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(143, 27);
            this.label7.TabIndex = 58;
            this.label7.Text = "Invoice Total";
            // 
            // txtinvtot
            // 
            this.txtinvtot.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(79)))), ((int)(((byte)(99)))));
            this.txtinvtot.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtinvtot.Font = new System.Drawing.Font("Arial Black", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtinvtot.ForeColor = System.Drawing.Color.White;
            this.txtinvtot.Location = new System.Drawing.Point(894, 585);
            this.txtinvtot.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtinvtot.Multiline = true;
            this.txtinvtot.Name = "txtinvtot";
            this.txtinvtot.ReadOnly = true;
            this.txtinvtot.Size = new System.Drawing.Size(166, 38);
            this.txtinvtot.TabIndex = 59;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial Black", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(532, 115);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(422, 46);
            this.label9.TabIndex = 60;
            this.label9.Text = "Payment Management";
            // 
            // button14
            // 
            this.button14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.button14.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button14.Font = new System.Drawing.Font("Arial Black", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(161)))), ((int)(((byte)(176)))));
            this.button14.Location = new System.Drawing.Point(1642, 15);
            this.button14.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(34, 35);
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
            this.txtinvoice.Location = new System.Drawing.Point(890, 201);
            this.txtinvoice.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtinvoice.Multiline = true;
            this.txtinvoice.Name = "txtinvoice";
            this.txtinvoice.Size = new System.Drawing.Size(199, 38);
            this.txtinvoice.TabIndex = 116;
            this.txtinvoice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(161)))), ((int)(((byte)(176)))));
            this.label8.Location = new System.Drawing.Point(534, 210);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(123, 27);
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
            this.txtbal.Location = new System.Drawing.Point(894, 852);
            this.txtbal.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtbal.Multiline = true;
            this.txtbal.Name = "txtbal";
            this.txtbal.ReadOnly = true;
            this.txtbal.Size = new System.Drawing.Size(166, 38);
            this.txtbal.TabIndex = 118;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(161)))), ((int)(((byte)(176)))));
            this.label1.Location = new System.Drawing.Point(536, 861);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 27);
            this.label1.TabIndex = 119;
            this.label1.Text = "Balance";
            // 
            // btngo
            // 
            this.btngo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(184)))), ((int)(((byte)(206)))));
            this.btngo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btngo.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btngo.Location = new System.Drawing.Point(1245, 201);
            this.btngo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btngo.Name = "btngo";
            this.btngo.Size = new System.Drawing.Size(81, 41);
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
            this.groupBox1.Location = new System.Drawing.Point(539, 278);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(788, 235);
            this.groupBox1.TabIndex = 121;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Customer Details";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(161)))), ((int)(((byte)(176)))));
            this.label11.Location = new System.Drawing.Point(66, 72);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(244, 27);
            this.label11.TabIndex = 65;
            this.label11.Text = "Vehicle Plate Number";
            // 
            // txtplateNo
            // 
            this.txtplateNo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.txtplateNo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtplateNo.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtplateNo.ForeColor = System.Drawing.Color.White;
            this.txtplateNo.Location = new System.Drawing.Point(351, 78);
            this.txtplateNo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtplateNo.Multiline = true;
            this.txtplateNo.Name = "txtplateNo";
            this.txtplateNo.ReadOnly = true;
            this.txtplateNo.Size = new System.Drawing.Size(199, 38);
            this.txtplateNo.TabIndex = 47;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.panel1.Controls.Add(this.pictureBox6);
            this.panel1.Controls.Add(this.btnacc);
            this.panel1.Controls.Add(this.btncust);
            this.panel1.Controls.Add(this.pictureBox5);
            this.panel1.Controls.Add(this.pictureBox4);
            this.panel1.Controls.Add(this.pictureBox3);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.btnlogout);
            this.panel1.Controls.Add(this.btnpayment);
            this.panel1.Controls.Add(this.btnsales);
            this.panel1.Controls.Add(this.btnappt);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(287, 1106);
            this.panel1.TabIndex = 122;
            // 
            // pictureBox6
            // 
            this.pictureBox6.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox6.Image")));
            this.pictureBox6.Location = new System.Drawing.Point(30, 608);
            this.pictureBox6.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(44, 45);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox6.TabIndex = 54;
            this.pictureBox6.TabStop = false;
            // 
            // btnacc
            // 
            this.btnacc.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnacc.FlatAppearance.BorderSize = 0;
            this.btnacc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnacc.Font = new System.Drawing.Font("Nirmala UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnacc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.btnacc.Location = new System.Drawing.Point(0, 608);
            this.btnacc.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnacc.Name = "btnacc";
            this.btnacc.Size = new System.Drawing.Size(287, 65);
            this.btnacc.TabIndex = 53;
            this.btnacc.Text = "Account";
            this.btnacc.UseVisualStyleBackColor = true;
            this.btnacc.Click += new System.EventHandler(this.btnacc_Click);
            // 
            // btncust
            // 
            this.btncust.Dock = System.Windows.Forms.DockStyle.Top;
            this.btncust.FlatAppearance.BorderSize = 0;
            this.btncust.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btncust.Font = new System.Drawing.Font("Nirmala UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btncust.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.btncust.Location = new System.Drawing.Point(0, 543);
            this.btncust.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btncust.Name = "btncust";
            this.btncust.Size = new System.Drawing.Size(287, 65);
            this.btncust.TabIndex = 52;
            this.btncust.Text = "Customers";
            this.btncust.UseVisualStyleBackColor = true;
            this.btncust.Click += new System.EventHandler(this.btncust_Click);
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox5.Image")));
            this.pictureBox5.Location = new System.Drawing.Point(30, 1052);
            this.pictureBox5.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(44, 45);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5.TabIndex = 51;
            this.pictureBox5.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(30, 618);
            this.pictureBox4.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(44, 45);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 50;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(30, 420);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(44, 45);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 49;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(30, 345);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(44, 45);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 8;
            this.pictureBox2.TabStop = false;
            // 
            // btnlogout
            // 
            this.btnlogout.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnlogout.FlatAppearance.BorderSize = 0;
            this.btnlogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnlogout.Font = new System.Drawing.Font("Nirmala UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnlogout.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.btnlogout.Location = new System.Drawing.Point(0, 1041);
            this.btnlogout.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnlogout.Name = "btnlogout";
            this.btnlogout.Size = new System.Drawing.Size(287, 65);
            this.btnlogout.TabIndex = 6;
            this.btnlogout.Text = "Log Out";
            this.btnlogout.UseVisualStyleBackColor = true;
            // 
            // btnpayment
            // 
            this.btnpayment.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnpayment.FlatAppearance.BorderSize = 0;
            this.btnpayment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnpayment.Font = new System.Drawing.Font("Nirmala UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnpayment.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.btnpayment.Location = new System.Drawing.Point(0, 478);
            this.btnpayment.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnpayment.Name = "btnpayment";
            this.btnpayment.Size = new System.Drawing.Size(287, 65);
            this.btnpayment.TabIndex = 3;
            this.btnpayment.Text = "Payments";
            this.btnpayment.UseVisualStyleBackColor = true;
            this.btnpayment.Click += new System.EventHandler(this.btnpayment_Click);
            // 
            // btnsales
            // 
            this.btnsales.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnsales.FlatAppearance.BorderSize = 0;
            this.btnsales.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnsales.Font = new System.Drawing.Font("Nirmala UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnsales.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.btnsales.Location = new System.Drawing.Point(0, 413);
            this.btnsales.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnsales.Name = "btnsales";
            this.btnsales.Size = new System.Drawing.Size(287, 65);
            this.btnsales.TabIndex = 2;
            this.btnsales.Text = "Sales";
            this.btnsales.UseVisualStyleBackColor = true;
            this.btnsales.Click += new System.EventHandler(this.btnsales_Click);
            // 
            // btnappt
            // 
            this.btnappt.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnappt.FlatAppearance.BorderSize = 0;
            this.btnappt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnappt.Font = new System.Drawing.Font("Nirmala UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnappt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.btnappt.Location = new System.Drawing.Point(0, 334);
            this.btnappt.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnappt.Name = "btnappt";
            this.btnappt.Size = new System.Drawing.Size(287, 79);
            this.btnappt.TabIndex = 1;
            this.btnappt.Text = "Appointments";
            this.btnappt.UseVisualStyleBackColor = true;
            this.btnappt.Click += new System.EventHandler(this.btnappt_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(287, 334);
            this.panel2.TabIndex = 0;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Nirmala UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.label10.Location = new System.Drawing.Point(74, 230);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(141, 30);
            this.label10.TabIndex = 48;
            this.label10.Text = "Receptionist";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Nirmala UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.label3.Location = new System.Drawing.Point(93, 181);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 30);
            this.label3.TabIndex = 47;
            this.label3.Text = "WELCOME";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(99, 55);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(84, 91);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 32;
            this.pictureBox1.TabStop = false;
            // 
            // manage_payment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.ClientSize = new System.Drawing.Size(1538, 1106);
            this.Controls.Add(this.panel1);
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
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "manage_payment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "payment";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.payment_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
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
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.Button btnacc;
        private System.Windows.Forms.Button btncust;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button btnlogout;
        private System.Windows.Forms.Button btnpayment;
        private System.Windows.Forms.Button btnsales;
        private System.Windows.Forms.Button btnappt;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}