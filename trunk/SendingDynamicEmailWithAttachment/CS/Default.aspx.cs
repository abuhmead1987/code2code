using System;
using System.Configuration;
using System.IO;
using System.Net.Configuration;
using System.Net.Mail;

public partial class _Default : System.Web.UI.Page
{

    public static String FormAddress
    {
        get
        {
            SmtpSection cfg = (SmtpSection)ConfigurationManager.GetSection
                ("system.net/mailSettings/smtp");
            return cfg.Network.UserName;
        }
    }

    public string SendMail(string subject, string body, string to, bool isHtml, bool isSSL)
    {
        try
        {
            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress(FormAddress, "code2code.info");
                mail.To.Add(to);
                mail.Subject = subject;
                mail.Body = body;
                mail.IsBodyHtml = isHtml;
                SmtpClient client = new SmtpClient();
                client.EnableSsl = isSSL;
                if (FileUpload1.HasFile)
                {
                    mail.Attachments.Add(new Attachment(FileUpload1.PostedFile.InputStream, FileUpload1.FileName));
                }
                client.Send(mail);
            }
        }
        catch (SmtpException ex)
        {
            return ex.Message;
        }
        return "Send email successful!";
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void ButtonSend_Click(object sender, EventArgs e)
    {
        StreamReader sr = new StreamReader(Server.MapPath("template/Contact.htm"));
        sr = File.OpenText(Server.MapPath("template/Contact.htm"));
        string content = sr.ReadToEnd();
        content = content.Replace("[Sender]", TextBoxName.Text.Trim());
        content = content.Replace("[Email]", TextBoxEmail.Text);
        content = content.Replace("[Content]", TextBoxContent.Text);
        content = content.Replace("[DateTime]", DateTime.Now.ToShortDateString());
        try
        {
            Response.Write(SendMail("Liên hệ khách hàng", content, "quachngochoangnguyen@gmail.com", true, true));
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
    }
}
