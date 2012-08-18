using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using anm_utility;

public partial class Controls_ContactUs : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Request.IsAuthenticated)
        {
            Label1.Text = GetGlobalResourceObject("language", "loginsendmsg").ToString();
        }
        anm_Utility ut = new anm_Utility();
        Page.Title = ut.GetSetting("SiteName") + " - " + GetGlobalResourceObject("language", "ContactPage");
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (Request.IsAuthenticated)
        {
            String message = TextBox2.Text;
            if (message.Length < 1001)
            {
                try
                {
                    MembershipUser user = Membership.GetUser();
                    string email = user.Email.ToString();
                    anm_Utility ut = new anm_Utility();

                    StringBuilder bodyMsg = new StringBuilder();
                    bodyMsg.AppendFormat(GetGlobalResourceObject("language", "Msgfromuser") + ": {0}", user.UserName.ToString());
                    bodyMsg.Append("<br />");
                    bodyMsg.Append("<br />");
                    bodyMsg.Append(message);
                    bodyMsg.Append("<br />");

                    NetworkCredential loginInfo = new NetworkCredential(ut.GetSetting("MailUser"), ut.GetSetting("MailPassword"));
                    MailMessage msg = new MailMessage();
                    msg.From = new MailAddress(user.Email);
                    msg.To.Add(new MailAddress(ut.GetSetting("SiteEmail")));
                    msg.Subject = TextBox1.Text.ToString();
                    msg.Body = bodyMsg.ToString();
                    msg.IsBodyHtml = true;

                    SmtpClient client = new SmtpClient(ut.GetSetting("smtpserver"), Convert.ToInt32(ut.GetSetting("port")));
                    client.Credentials = loginInfo;
                    client.Send(msg);

                    Label1.Text = GetGlobalResourceObject("language", "Messagesent").ToString();
                }
                catch
                {
                    Label1.Text = "Administrator has to configure email settings in admin section.";
                }
            }
            else
                Label1.Text = GetGlobalResourceObject("language", "msglimit").ToString();
        }
    }
}
