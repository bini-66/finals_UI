using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;
using Org.BouncyCastle.Cms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;
using System.Runtime.Remoting.Messaging;
using finals_UI.Controller;


namespace finals_UI.View
{
    public partial class sendCode : Form
    {
        userController userController=new userController(); 
        private string randomCode = "";
        public static string to;

        public sendCode()
        {
            InitializeComponent();
        }
        //btnsend
        private void button1_Click(object sender, EventArgs e) {
            string username = this.txtemail.Text;
            //calling teh functon to validate username
          int userCount= userController.validateUsername(username);
            if (userCount == -1)
            {
                return;
            }



            Random rand = new Random();
            randomCode = rand.Next(999999).ToString();
            string recipient = txtemail.Text;
            string subject = "Password Reset Code";
            string body = "Your reset code is " + randomCode;

                    if (string.IsNullOrWhiteSpace(recipient) )
                    {
                        MessageBox.Show("Please enter an email to send the code", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

            SendEmail(recipient, subject, body);

}

        private void SendEmail(string toEmail, string subject, string body)
        {
           
            try
            {
                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential("futuretechtips@gmail.com", "kanx mahw lwbb lfgn"),
                    EnableSsl = true
                };

                MailMessage mailMessage = new MailMessage
                {
                    From = new MailAddress("futuretechtips@gmail.com"),
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = true
                };

                mailMessage.To.Add(toEmail);


                smtpClient.Send(mailMessage);
                MessageBox.Show("Email Sent Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Email Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
       
        }


        private void  btnverify_Click(object sender, EventArgs e)
        {
            string username = this.txtemail.Text;
           
            
            if (randomCode == (txtvercode.Text).ToString())
            {
                
                resetPW resetPW = new resetPW(username);
                this.Hide();
                resetPW.Show();
            }
            else
            {
                MessageBox.Show("wrong code");
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            sign_in sign_In = new sign_in();
            this.Hide();
            sign_In.Show();
        }

        private void sendCode_Load(object sender, EventArgs e)
        {

        }
    }
}
