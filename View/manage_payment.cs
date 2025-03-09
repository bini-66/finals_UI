using finals_UI.Controller;
using finals_UI.Model;
using finals_UI.Model.classes;
using finals_UI.View;
using Mysqlx.Crud;
using Org.BouncyCastle.Asn1.IsisMtt;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace finals_UI
{
    
    public partial class manage_payment : Form

    {
        paymentController paymentController=new paymentController();
        payment payment=new payment();
        receipt receipt = new receipt();
        string invoiceNo;

        public manage_payment(string invoiceNo)
        {
            InitializeComponent();
            this.invoiceNo = invoiceNo;
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }

        private void button14_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //this.Hide();
            //Receptionist_dash dash = new Receptionist_dash();
            //dash.Show();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void btngo_Click(object sender, EventArgs e)
        {
            if (this.txtinvoice.Text == "")
            {
                errorProvider1.SetError(this.txtinvoice,"Please enter an invoice number");
            }
           string invoiceNo = this.txtinvoice.Text;
            
         
            //checking invoice no 

            int invoiceId=paymentController.retrieveInvoiceId(invoiceNo);

            if (invoiceId ==0)
            {
                MessageBox.Show("No such invoiceNo, please enter a valid invoice no ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Stop further processing if no invoiceId was found
                return;

            }
            int count=paymentController.ckInvoiceDuplication(invoiceId);
            if (count == -1)
            {
                MessageBox.Show("Payment has been done for this invoice.");
                this.txtfullname.Text = "";
                this.txtinvtot.Text = "";
                this.txtplateNo.Text = "";
                return;
            }
            
            DataSet ds = paymentController.retrieveCustomerInfo(invoiceNo);
            this.txtfullname.Text = ds.Tables[0].Rows[0]["fullname"].ToString();
            this.txtplateNo.Text = ds.Tables[0].Rows[0]["plateNumber"].ToString();
            this.txtinvtot.Text = ds.Tables[0].Rows[0]["invoiceTotal"].ToString();





        }

        private void payment_Load(object sender, EventArgs e)
        {
           // manage_sales_invoice manage_Sales_Invoice = new manage_sales_invoice();
       //     string invoiceNo=manage_Sales_Invoice.returnInvoiceNo();
            this.txtinvoice.Text = invoiceNo;   
        }

        private void CBoffer_SelectedIndexChanged(object sender, EventArgs e)
        {
        


        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtpaid_Leave(object sender, EventArgs e)
        {
            if (this.txtinvtot.Text == "")
            {
                errorProvider2.SetError(this.txtpaid, "Total foeld cannot be empty");
                return;
            }
            else
            {
                errorProvider2.Clear();
            }
            if (this.txtpaid.Text == "")
            {
                errorProvider2.SetError(this.txtpaid, "please enter the paid amount");
                return;
            }
            else
            {
                errorProvider2.Clear();
            }

            payment.invoiceTotal= Convert.ToSingle(this.txtinvtot.Text);
            payment.paidAmount = Convert.ToSingle(this.txtpaid.Text);
            if (payment.paidAmount >= payment.invoiceTotal)
            {
                float balance = payment.paidAmount - payment.invoiceTotal;
                this.txtbal.Text = balance.ToString("N2");
            }
            else
            {
                float balanceDue = payment.invoiceTotal - payment.paidAmount; 
               MessageBox.Show($"Insufficient payment. Remaining balance: {balanceDue:N2}", "Balance Due", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void CBpaymentmethod_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void btnreceipt_Click(object sender, EventArgs e)
        {

            if (this.txtfullname.Text == "")
            {
                errorProvider1.SetError(this.txtfullname, "please enter full name of teh customer");
                return;
            }
            else
            {
                errorProvider1.Clear();
            }
            if (this.txtpaid.Text == "")
            {
                errorProvider2.SetError(this.txtpaid, "please enter the paid amount");
                return;
            }
            else
            {
                errorProvider2.Clear();
            }
            if (this.txtplateNo.Text == "")
            {
                errorProvider3.SetError(this.txtplateNo, "Please enter the plate number");
                return;

            }
            else
            {
                errorProvider3.Clear();
            }
            if (this.txtplateNo.Text == "")
            {
                errorProvider3.SetError(this.txtplateNo, "Please enter the plate number");
                return;
            }
            else
            {
                errorProvider3.Clear();
            }

            if (CBpaymentmethod.SelectedIndex == -1) 
            {
                errorProvider5.SetError(CBpaymentmethod, "Please select a payment method.");
                return;
            }
            else
            {
                errorProvider5.Clear();
            }

            payment.invoiceTotal = Convert.ToSingle(this.txtinvtot.Text);
            payment.paidAmount = Convert.ToSingle(this.txtpaid.Text);
            payment.paymentMethod=this.CBpaymentmethod.SelectedItem.ToString();
            payment.vehicleId=paymentController.retrieveVehicleId(this.txtplateNo.Text);
            payment.customerInvoiceId=paymentController.retrieveInvoiceId(this.txtinvoice.Text);
           // receipt.receptionistId = 2;

            if(payment.paidAmount < payment.invoiceTotal)
            {
                float balanceDue = payment.invoiceTotal - payment.paidAmount;
                MessageBox.Show($"Insufficient payment. Remaining balance: {balanceDue:N2}", "Balance Due", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            paymentController.savePaymentDetails(payment, receipt);

            if (this.txtinvoice.Text == "")
            {
                MessageBox.Show("Please enter an Invoice Number.", "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            receipt_display report = new receipt_display(txtinvoice.Text);
            report.WindowState = FormWindowState.Maximized;
            report.Show();
        }

        private void txtpaid_KeyPress(object sender, KeyPressEventArgs e)
        {
            //payment.invoiceTotal = Convert.ToSingle(this.txtinvtot.Text);
            //payment.paidAmount = Convert.ToSingle(this.txtpaid.Text);
            //float balance = payment.paidAmount - payment.invoiceTotal;
            //this.txtbal.Text = balance.ToString("N2");
        }

        private void btnappt_Click(object sender, EventArgs e)
        {
            view_appointment view_Appointment = new view_appointment();
            view_Appointment.Show();
            this.Hide();
        }

        private void btnsales_Click(object sender, EventArgs e)
        {
            manage_sales_invoice manage_Sales_Invoice = new manage_sales_invoice();
            manage_Sales_Invoice.Show();
            this.Hide();

        }

        private void btnpayment_Click(object sender, EventArgs e)
        {
          this.Show();
        }

        private void btncust_Click(object sender, EventArgs e)
        {
            view_customer customer = new view_customer();   
            customer.Show();
            this.Hide();
        }

        private void btnacc_Click(object sender, EventArgs e)
        {
            view_customer_inquiries view_Customer_Inquiries = new view_customer_inquiries();
            view_Customer_Inquiries.Show();
            this.Hide();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            receptionist_profile profile = new receptionist_profile();
            profile.Show();
            this.Hide();
        }
    }
}
