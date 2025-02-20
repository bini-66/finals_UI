namespace finals_UI.View
{
    partial class sendCode
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
            this.txtemail = new System.Windows.Forms.TextBox();
            this.txtvercode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnverify = new System.Windows.Forms.Button();
            this.btnsend = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtemail
            // 
            this.txtemail.Location = new System.Drawing.Point(412, 150);
            this.txtemail.Name = "txtemail";
            this.txtemail.Size = new System.Drawing.Size(100, 22);
            this.txtemail.TabIndex = 0;
            // 
            // txtvercode
            // 
            this.txtvercode.Location = new System.Drawing.Point(412, 238);
            this.txtvercode.Name = "txtvercode";
            this.txtvercode.Size = new System.Drawing.Size(100, 22);
            this.txtvercode.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(282, 150);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Enter Email";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(282, 238);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Enter Code";
            // 
            // btnverify
            // 
            this.btnverify.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(184)))), ((int)(((byte)(206)))));
            this.btnverify.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnverify.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnverify.Location = new System.Drawing.Point(542, 230);
            this.btnverify.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnverify.Name = "btnverify";
            this.btnverify.Size = new System.Drawing.Size(108, 37);
            this.btnverify.TabIndex = 37;
            this.btnverify.Text = "Verify";
            this.btnverify.UseVisualStyleBackColor = false;
            this.btnverify.Click += new System.EventHandler(this.btnverify_Click);
            // 
            // btnsend
            // 
            this.btnsend.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(184)))), ((int)(((byte)(206)))));
            this.btnsend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnsend.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnsend.Location = new System.Drawing.Point(542, 150);
            this.btnsend.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnsend.Name = "btnsend";
            this.btnsend.Size = new System.Drawing.Size(108, 30);
            this.btnsend.TabIndex = 38;
            this.btnsend.Text = "Send";
            this.btnsend.UseVisualStyleBackColor = false;
            this.btnsend.Click += new System.EventHandler(this.button1_Click);
            // 
            // sendCode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(954, 529);
            this.Controls.Add(this.btnsend);
            this.Controls.Add(this.btnverify);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtvercode);
            this.Controls.Add(this.txtemail);
            this.Name = "sendCode";
            this.Text = "sendCode";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtemail;
        private System.Windows.Forms.TextBox txtvercode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnverify;
        private System.Windows.Forms.Button btnsend;
    }
}