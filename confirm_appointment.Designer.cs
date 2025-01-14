namespace finals_UI
{
    partial class confirm_appointment
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Appointment_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Customer_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Appointment_Status = new System.Windows.Forms.DataGridViewButtonColumn();
            this.decline = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.Teal;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Appointment_ID,
            this.Time,
            this.Customer_Name,
            this.Appointment_Status,
            this.decline});
            this.dataGridView1.GridColor = System.Drawing.Color.Teal;
            this.dataGridView1.Location = new System.Drawing.Point(130, 88);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(838, 397);
            this.dataGridView1.TabIndex = 30;
            // 
            // Appointment_ID
            // 
            this.Appointment_ID.HeaderText = "Appointment_ID";
            this.Appointment_ID.MinimumWidth = 6;
            this.Appointment_ID.Name = "Appointment_ID";
            this.Appointment_ID.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Appointment_ID.Width = 125;
            // 
            // Time
            // 
            this.Time.HeaderText = "Time";
            this.Time.MinimumWidth = 6;
            this.Time.Name = "Time";
            this.Time.Width = 125;
            // 
            // Customer_Name
            // 
            this.Customer_Name.HeaderText = "Customer_Name";
            this.Customer_Name.MinimumWidth = 6;
            this.Customer_Name.Name = "Customer_Name";
            this.Customer_Name.Width = 125;
            // 
            // Appointment_Status
            // 
            this.Appointment_Status.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Appointment_Status.HeaderText = "";
            this.Appointment_Status.MinimumWidth = 6;
            this.Appointment_Status.Name = "Appointment_Status";
            this.Appointment_Status.Text = "Confirm";
            this.Appointment_Status.UseColumnTextForButtonValue = true;
            // 
            // decline
            // 
            this.decline.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.decline.HeaderText = "";
            this.decline.MinimumWidth = 6;
            this.decline.Name = "decline";
            this.decline.Text = "Decline";
            this.decline.UseColumnTextForButtonValue = true;
            // 
            // confirm_appointment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1099, 572);
            this.Controls.Add(this.dataGridView1);
            this.Name = "confirm_appointment";
            this.Text = "confirm_appointment";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Appointment_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Time;
        private System.Windows.Forms.DataGridViewTextBoxColumn Customer_Name;
        private System.Windows.Forms.DataGridViewButtonColumn Appointment_Status;
        private System.Windows.Forms.DataGridViewButtonColumn decline;
    }
}