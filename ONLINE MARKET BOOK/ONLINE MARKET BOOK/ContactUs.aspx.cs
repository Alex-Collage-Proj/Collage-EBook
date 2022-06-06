using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Net.Mail;

namespace ONLINE_MARKET_BOOK
{
    public partial class WebForm5 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ContactSend_Click(object sender, EventArgs e)
        {
            try
            {
                //string content = "";
                //content += Email.Text;
                SendEmail("email@gmail.com", Subject.Text, Desc.Text, FullName.Text, PhoneNum.Text);// content.
                Response.Write("Message has been sent successfully");
            }
            catch(Exception ex)
            {
                Response.Write("Could not send email"+ex.Message);
            }
        }
        public void SendEmail(string To, string Subject, string Content, string FullName, string PhoneNumber)
        {

            MailMessage mailMessage = new MailMessage();
            mailMessage.To.Add(To);
            mailMessage.From = new MailAddress(Email.Text);
            mailMessage.Subject = Subject;
            mailMessage.Body = Content+FullName+PhoneNumber;          
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");
            smtpClient.Port = 587;
            smtpClient.EnableSsl = true;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new System.Net.NetworkCredential("gmail@gmail.com", "סיסמה");
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.Send(mailMessage);

        }
    }
}