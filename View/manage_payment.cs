using finals_UI.Controller;
using finals_UI.Model;
using finals_UI.Model.classes;
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

        public manage_payment()
        {
            InitializeComponent();
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
            this.Hide();
            Receptionist_dash dash = new Receptionist_dash();
            dash.Show();
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
                return;
            }
            
            DataSet ds = paymentController.retrieveCustomerInfo(invoiceNo);
            this.txtfullname.Text = ds.Tables[0].Rows[0]["fullname"].ToString();
            this.txtplateNo.Text = ds.Tables[0].Rows[0]["plateNumber"].ToString();
            this.txtinvtot.Text = ds.Tables[0].Rows[0]["invoiceTotal"].ToString();





        }

        private void payment_Load(object sender, EventArgs e)
        {
          
        }

        private void CBoffer_SelectedIndexChanged(object sender, EventArgs e)
        {
        


        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtpaid_Leave(object sender, EventArgs e)
        {
            payment.invoiceTotal= Convert.ToSingle(this.txtinvtot.Text);
            payment.paidAmount = Convert.ToSingle(this.txtpaid.Text);
            float balance=payment.paidAmount-payment.invoiceTotal;
            this.txtbal.Text = balance.ToString("N2");
        }

        private void CBpaymentmethod_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void btnreceipt_Click(object sender, EventArgs e)
        {
           

            payment.invoiceTotal = Convert.ToSingle(this.txtinvtot.Text);
            payment.paidAmount = Convert.ToSingle(this.txtpaid.Text);
            payment.paymentMethod=this.CBpaymentmethod.SelectedItem.ToString();
            payment.vehicleId=paymentController.retrieveVehicleId(this.txtplateNo.Text);
            payment.customerInvoiceId=paymentController.retrieveInvoiceId(this.txtinvoice.Text);
            receipt.receptionistId = 2;

            paymentController.savePaymentDetails(payment, receipt);
        }

        private void txtpaid_KeyPress(object sender, KeyPressEventArgs e)
        {
            //payment.invoiceTotal = Convert.ToSingle(this.txtinvtot.Text);
            //payment.paidAmount = Convert.ToSingle(this.txtpaid.Text);
            //float balance = payment.paidAmount - payment.invoiceTotal;
            //this.txtbal.Text = balance.ToString("N2");
        }
    }
}
