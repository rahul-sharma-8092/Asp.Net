using BALayer;
using DALayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Configuration;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StudentCore
{
    public partial class SendEmail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // Send Email
        protected void BtnSendEmail_Click(object sender, EventArgs e)
        {
            lblMessage.Text = "";

            string recieverEmail = SentTo.Text;
            string subject = Subject.Text;
            string bodyMessage = BodyMsg.Text;
            HttpPostedFile attachment = Attachment.PostedFile;

            Email email = new Email(recieverEmail, subject, bodyMessage, attachment);

            string result = email.SendEmail(email);

            lblMessage.Text = result;

        }
    }
}