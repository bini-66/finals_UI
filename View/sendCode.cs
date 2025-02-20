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


namespace finals_UI.View
{
    public partial class sendCode : Form
    {
        string randomCode;
        public static string to;

        public sendCode()
        {
            InitializeComponent();
        }
        //btnsend
        private void button1_Click(object sender, EventArgs e)
        {
            string from = "binithi.vihanga@gmail.com";
            string to = txtemail.Text;
            string messageBody;
            Random rand = new Random();
            string randomCode = rand.Next(999999).ToString();

            MailMessage message = new MailMessage
            {
                From = new MailAddress(from),
                Subject = "Password Reset Code",
                Body = "Your reset code is " + randomCode
            };
            message.To.Add(to);

            SmtpClient smtp = new SmtpClient("smtp.office365.com")
            {
                Port = 587,
                EnableSsl = true,
                Credentials = new NetworkCredential("binithi.elvitigala@outlook.com", "microout123")
            };


            try
            {
                smtp.Send(message);
                MessageBox.Show("code send successfully" + randomCode);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnverify_Click(object sender, EventArgs e)
        {
            if (randomCode == (txtvercode.Text).ToString())
            {
                to = txtemail.Text;
                resetPW resetPW = new resetPW();
                this.Hide();
                resetPW.Show();
            }
            else
            {
                MessageBox.Show("wrong code");
            }
        }
    }
}
