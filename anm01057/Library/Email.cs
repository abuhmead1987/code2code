using System;
using System.Configuration;
using System.Net.Configuration;
using System.Net.Mail;
using News.EntityFramework.Models;
using System.Net;

namespace Library
{
    public class Email
    {
        public static String FormAddress
        {
            get
            {
                SmtpSection cfg = (SmtpSection)ConfigurationManager.GetSection("system.net/mailSettings/smtp");
                return cfg.Network.UserName;
            }
        }

        public void Send(Contact contact)
        {
            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress(FormAddress, "Admin");
                mail.To.Add(FormAddress);
                mail.Subject = contact.Subject;
                mail.Body = contact.Message;
                NetworkCredential credential = new NetworkCredential(FormAddress, "");

                SmtpClient client = new SmtpClient();
                client.Credentials = credential;
                client.EnableSsl = true;
                client.Send(mail);
            }
        }
    }
}