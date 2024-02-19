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

namespace BALayer
{
    public class Email
    {
        public string RecieverEmail { get; set; }

        public string Subject { get; set; }

        public string BodyMessage { get; set; }

        public HttpPostedFile Attachment { get; set; }

        // Constructor
        public Email(string recieverEmail, string subject, string bodyMessage, HttpPostedFile attachment)
        {
            this.RecieverEmail = recieverEmail;
            this.Subject = subject;
            this.BodyMessage = bodyMessage;
            this.Attachment = attachment;
        }

        public string SendEmail(Email e)
        {
            try
            {
                SmtpSection smtpSection = (SmtpSection)ConfigurationManager.GetSection("system.net/mailSettings/smtp");

                string senderEmail = smtpSection.Network.UserName;

                MailMessage message = new MailMessage(senderEmail, e.RecieverEmail);

                message.Subject = e.Subject;
                message.Body = e.BodyMessage;

                if (e.Attachment.FileName != "")
                {
                    string fileName = Path.GetFileName(e.Attachment.FileName);
                    message.Attachments.Add(new Attachment(e.Attachment.InputStream, fileName));
                }
                message.IsBodyHtml = false;

                SmtpClient smtpClient = new SmtpClient();

                smtpClient.Host = smtpSection.Network.Host;
                smtpClient.EnableSsl = smtpSection.Network.EnableSsl;
                NetworkCredential networkCred = new NetworkCredential(senderEmail, smtpSection.Network.Password);
                smtpClient.UseDefaultCredentials = smtpSection.Network.DefaultCredentials;
                smtpClient.Credentials = networkCred;
                smtpClient.Port = smtpSection.Network.Port;
                smtpClient.Send(message);

                ErrorLogger.WriteLog($"Email Sent Successfully to {e.RecieverEmail}");
                return $"Email Sent Successfully to {e.RecieverEmail}";

            }
            catch (Exception Ex)
            {
                ErrorLogger.WriteLog($"Error : {Ex.Message}");
                return $"Error : {Ex.Message}";
            }
        }
    }
}