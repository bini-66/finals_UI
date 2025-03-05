namespace finals_UI
{
    partial class manage_offers
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.DTPstart = new System.Windows.Forms.DateTimePicker();
            this.DTPend = new System.Windows.Forms.DateTimePicker();
            this.txtdisc = new System.Windows.Forms.TextBox();
            this.btnup = new System.Windows.Forms.Button();
            this.btndlt = new System.Windows.Forms.Button();
            this.btnclr = new System.Windows.Forms.Button();
            this.btnadd = new System.Windows.Forms.Button();
            this.txtofferDes = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnsearch = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.txtsearch = new System.Windows.Forms.TextBox();
            this.btnview = new System.Windows.Forms.Button();
            this.btnclose = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.txtofferType = new System.Windows.Forms.TextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProvider2 = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProvider3 = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.txtacc = new System.Windows.Forms.Button();
            this.btnfeedback = new System.Windows.Forms.Button();
            this.btnemp = new System.Windows.Forms.Button();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.btnlogout = new System.Windows.Forms.Button();
            this.btnoffers = new System.Windows.Forms.Button();
            this.btnservices = new System.Windows.Forms.Button();
            this.btnattendance = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider3)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.Teal;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.GridColor = System.Drawing.Color.Teal;
            this.dataGridView1.Location = new System.Drawing.Point(341, 199);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1097, 221);
            this.dataGridView1.TabIndex = 25;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(161)))), ((int)(((byte)(176)))));
            this.label6.Location = new System.Drawing.Point(337, 618);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 23);
            this.label6.TabIndex = 27;
            this.label6.Text = "Start Date";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(161)))), ((int)(((byte)(176)))));
            this.label5.Location = new System.Drawing.Point(341, 489);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 23);
            this.label5.TabIndex = 26;
            this.label5.Text = "Offer Type";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(161)))), ((int)(((byte)(176)))));
            this.label2.Location = new System.Drawing.Point(961, 619);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 23);
            this.label2.TabIndex = 30;
            this.label2.Text = "End Date";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(161)))), ((int)(((byte)(176)))));
            this.label3.Location = new System.Drawing.Point(337, 708);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 23);
            this.label3.TabIndex = 31;
            this.label3.Text = "Discount";
            // 
            // DTPstart
            // 
            this.DTPstart.CalendarMonthBackground = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(79)))), ((int)(((byte)(99)))));
            this.DTPstart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DTPstart.Location = new System.Drawing.Point(523, 618);
            this.DTPstart.Name = "DTPstart";
            this.DTPstart.Size = new System.Drawing.Size(176, 22);
            this.DTPstart.TabIndex = 32;
            // 
            // DTPend
            // 
            this.DTPend.CalendarMonthBackground = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(79)))), ((int)(((byte)(99)))));
            this.DTPend.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DTPend.Location = new System.Drawing.Point(1139, 619);
            this.DTPend.Name = "DTPend";
            this.DTPend.Size = new System.Drawing.Size(176, 22);
            this.DTPend.TabIndex = 33;
            // 
            // txtdisc
            // 
            this.txtdisc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(79)))), ((int)(((byte)(99)))));
            this.txtdisc.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtdisc.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtdisc.ForeColor = System.Drawing.Color.White;
            this.txtdisc.Location = new System.Drawing.Point(523, 708);
            this.txtdisc.Multiline = true;
            this.txtdisc.Name = "txtdisc";
            this.txtdisc.Size = new System.Drawing.Size(176, 30);
            this.txtdisc.TabIndex = 34;
            // 
            // btnup
            // 
            this.btnup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(184)))), ((int)(((byte)(206)))));
            this.btnup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnup.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnup.Location = new System.Drawing.Point(740, 786);
            this.btnup.Name = "btnup";
            this.btnup.Size = new System.Drawing.Size(100, 33);
            this.btnup.TabIndex = 38;
            this.btnup.Text = "Update";
            this.btnup.UseVisualStyleBackColor = false;
            this.btnup.Click += new System.EventHandler(this.btnup_Click_1);
            // 
            // btndlt
            // 
            this.btndlt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(184)))), ((int)(((byte)(206)))));
            this.btndlt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btndlt.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btndlt.Location = new System.Drawing.Point(907, 786);
            this.btndlt.Name = "btndlt";
            this.btndlt.Size = new System.Drawing.Size(100, 33);
            this.btndlt.TabIndex = 37;
            this.btndlt.Text = "Delete";
            this.btndlt.UseVisualStyleBackColor = false;
            this.btndlt.Click += new System.EventHandler(this.btndlt_Click);
            // 
            // btnclr
            // 
            this.btnclr.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(184)))), ((int)(((byte)(206)))));
            this.btnclr.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnclr.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnclr.Location = new System.Drawing.Point(1069, 786);
            this.btnclr.Name = "btnclr";
            this.btnclr.Size = new System.Drawing.Size(100, 33);
            this.btnclr.TabIndex = 36;
            this.btnclr.Text = "Clear";
            this.btnclr.UseVisualStyleBackColor = false;
            this.btnclr.Click += new System.EventHandler(this.btnclr_Click);
            // 
            // btnadd
            // 
            this.btnadd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(184)))), ((int)(((byte)(206)))));
            this.btnadd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnadd.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnadd.Location = new System.Drawing.Point(572, 786);
            this.btnadd.Name = "btnadd";
            this.btnadd.Size = new System.Drawing.Size(100, 33);
            this.btnadd.TabIndex = 35;
            this.btnadd.Text = "Add";
            this.btnadd.UseVisualStyleBackColor = false;
            this.btnadd.Click += new System.EventHandler(this.btnadd_Click_1);
            // 
            // txtofferDes
            // 
            this.txtofferDes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(79)))), ((int)(((byte)(99)))));
            this.txtofferDes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtofferDes.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtofferDes.ForeColor = System.Drawing.Color.White;
            this.txtofferDes.Location = new System.Drawing.Point(1139, 489);
            this.txtofferDes.Multiline = true;
            this.txtofferDes.Name = "txtofferDes";
            this.txtofferDes.Size = new System.Drawing.Size(299, 88);
            this.txtofferDes.TabIndex = 39;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(161)))), ((int)(((byte)(176)))));
            this.label4.Location = new System.Drawing.Point(961, 489);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(160, 23);
            this.label4.TabIndex = 40;
            this.label4.Text = "Offer Description";
            // 
            // btnsearch
            // 
            this.btnsearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(184)))), ((int)(((byte)(206)))));
            this.btnsearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnsearch.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnsearch.Location = new System.Drawing.Point(1338, 143);
            this.btnsearch.Name = "btnsearch";
            this.btnsearch.Size = new System.Drawing.Size(100, 33);
            this.btnsearch.TabIndex = 56;
            this.btnsearch.Text = "Search";
            this.btnsearch.UseVisualStyleBackColor = false;
            this.btnsearch.Click += new System.EventHandler(this.btnsearch_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(161)))), ((int)(((byte)(176)))));
            this.label9.Location = new System.Drawing.Point(871, 145);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(158, 23);
            this.label9.TabIndex = 55;
            this.label9.Text = "Enter Offer Type";
            // 
            // txtsearch
            // 
            this.txtsearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(79)))), ((int)(((byte)(99)))));
            this.txtsearch.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtsearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtsearch.ForeColor = System.Drawing.Color.White;
            this.txtsearch.Location = new System.Drawing.Point(1048, 143);
            this.txtsearch.Multiline = true;
            this.txtsearch.Name = "txtsearch";
            this.txtsearch.Size = new System.Drawing.Size(264, 30);
            this.txtsearch.TabIndex = 54;
            // 
            // btnview
            // 
            this.btnview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(184)))), ((int)(((byte)(206)))));
            this.btnview.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnview.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnview.Location = new System.Drawing.Point(1296, 426);
            this.btnview.Name = "btnview";
            this.btnview.Size = new System.Drawing.Size(142, 33);
            this.btnview.TabIndex = 57;
            this.btnview.Text = "View Offers";
            this.btnview.UseVisualStyleBackColor = false;
            this.btnview.Click += new System.EventHandler(this.btnview_Click);
            // 
            // btnclose
            // 
            this.btnclose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.btnclose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnclose.Font = new System.Drawing.Font("Arial Black", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnclose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(161)))), ((int)(((byte)(176)))));
            this.btnclose.Location = new System.Drawing.Point(1466, 12);
            this.btnclose.Name = "btnclose";
            this.btnclose.Size = new System.Drawing.Size(30, 28);
            this.btnclose.TabIndex = 59;
            this.btnclose.Text = "X";
            this.btnclose.UseVisualStyleBackColor = false;
            this.btnclose.Click += new System.EventHandler(this.btnclose_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial Black", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(334, 55);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(112, 40);
            this.label8.TabIndex = 60;
            this.label8.Text = "Offers";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // txtofferType
            // 
            this.txtofferType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(79)))), ((int)(((byte)(99)))));
            this.txtofferType.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtofferType.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtofferType.ForeColor = System.Drawing.Color.White;
            this.txtofferType.Location = new System.Drawing.Point(523, 489);
            this.txtofferType.Multiline = true;
            this.txtofferType.Name = "txtofferType";
            this.txtofferType.Size = new System.Drawing.Size(317, 58);
            this.txtofferType.TabIndex = 61;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // errorProvider2
            // 
            this.errorProvider2.ContainerControl = this;
            // 
            // errorProvider3
            // 
            this.errorProvider3.ContainerControl = this;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.panel1.Controls.Add(this.pictureBox8);
            this.panel1.Controls.Add(this.pictureBox7);
            this.panel1.Controls.Add(this.pictureBox6);
            this.panel1.Controls.Add(this.pictureBox4);
            this.panel1.Controls.Add(this.pictureBox3);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.txtacc);
            this.panel1.Controls.Add(this.btnfeedback);
            this.panel1.Controls.Add(this.btnemp);
            this.panel1.Controls.Add(this.pictureBox5);
            this.panel1.Controls.Add(this.btnlogout);
            this.panel1.Controls.Add(this.btnoffers);
            this.panel1.Controls.Add(this.btnservices);
            this.panel1.Controls.Add(this.btnattendance);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(255, 1012);
            this.panel1.TabIndex = 63;
            // 
            // pictureBox8
            // 
            this.pictureBox8.Image = global::finals_UI.Properties.Resources.account1;
            this.pictureBox8.InitialImage = global::finals_UI.Properties.Resources.feedback22;
            this.pictureBox8.Location = new System.Drawing.Point(24, 536);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(39, 36);
            this.pictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox8.TabIndex = 77;
            this.pictureBox8.TabStop = false;
            // 
            // pictureBox7
            // 
            this.pictureBox7.Image = global::finals_UI.Properties.Resources.feedback23;
            this.pictureBox7.InitialImage = global::finals_UI.Properties.Resources.feedback22;
            this.pictureBox7.Location = new System.Drawing.Point(24, 490);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(39, 36);
            this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox7.TabIndex = 76;
            this.pictureBox7.TabStop = false;
            // 
            // pictureBox6
            // 
            this.pictureBox6.Image = global::finals_UI.Properties.Resources.employees1;
            this.pictureBox6.Location = new System.Drawing.Point(24, 441);
            this.pictureBox6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(39, 36);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox6.TabIndex = 75;
            this.pictureBox6.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::finals_UI.Properties.Resources.offers;
            this.pictureBox4.Location = new System.Drawing.Point(24, 385);
            this.pictureBox4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(39, 36);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 74;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::finals_UI.Properties.Resources.services;
            this.pictureBox3.Location = new System.Drawing.Point(24, 335);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(39, 36);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 73;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::finals_UI.Properties.Resources.attendance;
            this.pictureBox2.Location = new System.Drawing.Point(24, 281);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(39, 36);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 72;
            this.pictureBox2.TabStop = false;
            // 
            // txtacc
            // 
            this.txtacc.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtacc.FlatAppearance.BorderSize = 0;
            this.txtacc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.txtacc.Font = new System.Drawing.Font("Nirmala UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtacc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.txtacc.Location = new System.Drawing.Point(0, 530);
            this.txtacc.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtacc.Name = "txtacc";
            this.txtacc.Size = new System.Drawing.Size(255, 50);
            this.txtacc.TabIndex = 20;
            this.txtacc.Text = "Account";
            this.txtacc.UseVisualStyleBackColor = true;
            this.txtacc.Click += new System.EventHandler(this.txtacc_Click);
            // 
            // btnfeedback
            // 
            this.btnfeedback.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnfeedback.FlatAppearance.BorderSize = 0;
            this.btnfeedback.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnfeedback.Font = new System.Drawing.Font("Nirmala UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnfeedback.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.btnfeedback.Location = new System.Drawing.Point(0, 480);
            this.btnfeedback.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnfeedback.Name = "btnfeedback";
            this.btnfeedback.Size = new System.Drawing.Size(255, 50);
            this.btnfeedback.TabIndex = 17;
            this.btnfeedback.Text = "Feedback";
            this.btnfeedback.UseVisualStyleBackColor = true;
            this.btnfeedback.Click += new System.EventHandler(this.btnfeedback_Click);
            // 
            // btnemp
            // 
            this.btnemp.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnemp.FlatAppearance.BorderSize = 0;
            this.btnemp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnemp.Font = new System.Drawing.Font("Nirmala UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnemp.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.btnemp.Location = new System.Drawing.Point(0, 430);
            this.btnemp.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnemp.Name = "btnemp";
            this.btnemp.Size = new System.Drawing.Size(255, 50);
            this.btnemp.TabIndex = 16;
            this.btnemp.Text = "Employees";
            this.btnemp.UseVisualStyleBackColor = true;
            this.btnemp.Click += new System.EventHandler(this.btnemp_Click);
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = global::finals_UI.Properties.Resources.logout4;
            this.pictureBox5.Location = new System.Drawing.Point(24, 838);
            this.pictureBox5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(39, 36);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5.TabIndex = 15;
            this.pictureBox5.TabStop = false;
            // 
            // btnlogout
            // 
            this.btnlogout.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnlogout.FlatAppearance.BorderSize = 0;
            this.btnlogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnlogout.Font = new System.Drawing.Font("Nirmala UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnlogout.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.btnlogout.Location = new System.Drawing.Point(0, 962);
            this.btnlogout.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnlogout.Name = "btnlogout";
            this.btnlogout.Size = new System.Drawing.Size(255, 50);
            this.btnlogout.TabIndex = 6;
            this.btnlogout.Text = "Log Out";
            this.btnlogout.UseVisualStyleBackColor = true;
            this.btnlogout.Click += new System.EventHandler(this.btnlogout_Click_1);
            // 
            // btnoffers
            // 
            this.btnoffers.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnoffers.FlatAppearance.BorderSize = 0;
            this.btnoffers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnoffers.Font = new System.Drawing.Font("Nirmala UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnoffers.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.btnoffers.Location = new System.Drawing.Point(0, 380);
            this.btnoffers.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnoffers.Name = "btnoffers";
            this.btnoffers.Size = new System.Drawing.Size(255, 50);
            this.btnoffers.TabIndex = 3;
            this.btnoffers.Text = "Offers";
            this.btnoffers.UseVisualStyleBackColor = true;
            this.btnoffers.Click += new System.EventHandler(this.btnoffers_Click);
            // 
            // btnservices
            // 
            this.btnservices.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnservices.FlatAppearance.BorderSize = 0;
            this.btnservices.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnservices.Font = new System.Drawing.Font("Nirmala UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnservices.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.btnservices.Location = new System.Drawing.Point(0, 330);
            this.btnservices.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnservices.Name = "btnservices";
            this.btnservices.Size = new System.Drawing.Size(255, 50);
            this.btnservices.TabIndex = 2;
            this.btnservices.Text = "Services";
            this.btnservices.UseVisualStyleBackColor = true;
            this.btnservices.Click += new System.EventHandler(this.btnservices_Click);
            // 
            // btnattendance
            // 
            this.btnattendance.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnattendance.FlatAppearance.BorderSize = 0;
            this.btnattendance.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnattendance.Font = new System.Drawing.Font("Nirmala UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnattendance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.btnattendance.Location = new System.Drawing.Point(0, 267);
            this.btnattendance.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnattendance.Name = "btnattendance";
            this.btnattendance.Size = new System.Drawing.Size(255, 63);
            this.btnattendance.TabIndex = 1;
            this.btnattendance.Text = "Attendance";
            this.btnattendance.UseVisualStyleBackColor = true;
            this.btnattendance.Click += new System.EventHandler(this.btnattendance_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(255, 267);
            this.panel2.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Nirmala UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.label1.Location = new System.Drawing.Point(49, 178);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(155, 25);
            this.label1.TabIndex = 35;
            this.label1.Text = "Service Manager";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Nirmala UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.label7.Location = new System.Drawing.Point(71, 138);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 25);
            this.label7.TabIndex = 34;
            this.label7.Text = "WELCOME";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::finals_UI.Properties.Resources.user;
            this.pictureBox1.Location = new System.Drawing.Point(87, 50);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(75, 73);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // manage_offers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.ClientSize = new System.Drawing.Size(1805, 1012);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txtofferType);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnclose);
            this.Controls.Add(this.btnview);
            this.Controls.Add(this.btnsearch);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtsearch);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtofferDes);
            this.Controls.Add(this.btnup);
            this.Controls.Add(this.btndlt);
            this.Controls.Add(this.btnclr);
            this.Controls.Add(this.btnadd);
            this.Controls.Add(this.txtdisc);
            this.Controls.Add(this.DTPend);
            this.Controls.Add(this.DTPstart);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "manage_offers";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider3)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker DTPstart;
        private System.Windows.Forms.DateTimePicker DTPend;
        private System.Windows.Forms.TextBox txtdisc;
        private System.Windows.Forms.Button btnup;
        private System.Windows.Forms.Button btndlt;
        private System.Windows.Forms.Button btnclr;
        private System.Windows.Forms.Button btnadd;
        private System.Windows.Forms.TextBox txtofferDes;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnsearch;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtsearch;
        private System.Windows.Forms.Button btnview;
        private System.Windows.Forms.Button btnclose;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtofferType;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.ErrorProvider errorProvider2;
        private System.Windows.Forms.ErrorProvider errorProvider3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnfeedback;
        private System.Windows.Forms.Button btnemp;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Button btnlogout;
        private System.Windows.Forms.Button btnoffers;
        private System.Windows.Forms.Button btnservices;
        private System.Windows.Forms.Button btnattendance;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button txtacc;
        private System.Windows.Forms.PictureBox pictureBox8;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}