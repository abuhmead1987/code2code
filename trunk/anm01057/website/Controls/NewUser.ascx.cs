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

public partial class Controls_NewUser : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            anm_Utility ut = new anm_Utility();
            bool confirm = Convert.ToBoolean(ut.GetSetting("EmailConfirm"));
            CreateUserWizard1.DisableCreatedUser = confirm;
            //CreateUserWizard1.LoginCreatedUser = !confirm;
            if (ut.GetSetting("CaptchaNewUser") == "True")
            {
                string text = (Guid.NewGuid().ToString()).Substring(0, 5);
                Response.Cookies["Captcha"]["value"] = text;
                imgcaptcha.ImageUrl = Page.Request.Url.AbsolutePath.ToString() + "?p=captcha";
                UpdatePanel1.Visible = lblcaptcha.Visible = txtcaptcha.Visible = true;
            }
            Page.Title = ut.GetSetting("SiteName") + " - " + GetGlobalResourceObject("language", "RegisterPage");
        }
    }
    protected void CreateUserWizard1_CreatedUser(object sender, EventArgs e)
    {
        try
        {
            StringBuilder bodyMsg = new StringBuilder();
            TextBox username = (TextBox)CreateUserWizard1.CreateUserStep.ContentTemplateContainer.FindControl("UserName");
            TextBox password = (TextBox)CreateUserWizard1.CreateUserStep.ContentTemplateContainer.FindControl("Password");
            TextBox email = (TextBox)CreateUserWizard1.CreateUserStep.ContentTemplateContainer.FindControl("Email");

            CreateUserWizard cuw = (CreateUserWizard)sender;
            MembershipUser user = Membership.GetUser(cuw.UserName);
            Guid userID = (Guid)user.ProviderUserKey;
            anm_Utility ut = new anm_Utility();

            string siteurl = (ut.GetSetting("SiteUrl")).Replace("http://", "");
            if (ut.GetSetting("EmailConfirm") == "True")
            {
                bodyMsg.Append(GetGlobalResourceObject("language", "Thankaccount") + "\n\n" + GetGlobalResourceObject("language", "followlink"));
				string url = siteurl + Page.Request.Url.AbsolutePath.ToString() + "?p=Activate&ID=" + userID.ToString();
                bodyMsg.Append("<br /><br /><a href=" + url + ">" + GetGlobalResourceObject("language", "ActivateAccount") + "</a>");
                bodyMsg.Append("<br />");
                bodyMsg.Append("<br />");
                bodyMsg.Append(GetGlobalResourceObject("language", "linknowork") + " " + url);
                bodyMsg.Append("<br />");
                bodyMsg.Append("<br />");
                bodyMsg.AppendFormat("UserName: {0}", username.Text);
                bodyMsg.Append("<br />");
                bodyMsg.AppendFormat("Password: {0}", password.Text);
                bodyMsg.Append("<br />");
                bodyMsg.AppendFormat("Registered Email: {0}", email.Text);

                NetworkCredential loginInfo = new NetworkCredential(ut.GetSetting("MailUser"), ut.GetSetting("MailPassword"));
                MailMessage msg = new MailMessage();
                msg.From = new MailAddress(ut.GetSetting("SiteEmail"));
                msg.To.Add(new MailAddress(CreateUserWizard1.Email));
                msg.Subject = GetGlobalResourceObject("language", "AccountInformation").ToString();
                msg.Body = bodyMsg.ToString();
                msg.IsBodyHtml = true;

                SmtpClient client = new SmtpClient(ut.GetSetting("smtpserver"), Convert.ToInt32(ut.GetSetting("port")));
                client.Credentials = loginInfo;
                client.Send(msg);
                Response.Redirect(Page.Request.Url.AbsolutePath.ToString() + "?p=confirm&mes=" + GetGlobalResourceObject("language", "Registrationcompleted") + " " + GetGlobalResourceObject("language", "checkemail") + "");
            }
            else
                Response.Redirect(Page.Request.Url.AbsolutePath.ToString() + "?p=confirm&mes=" + GetGlobalResourceObject("language", "Registrationcompleted") + "");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void CreateUserWizard1_Captcha(object sender, LoginCancelEventArgs e)
    {
        anm_Utility ut = new anm_Utility();
        if (ut.GetSetting("CaptchaNewUser") == "True")
        {
            if (txtcaptcha.Text.ToString() != Request.Cookies["Captcha"]["value"])
            {
                e.Cancel = true;
                errorcaptcha.Visible = true;
            }
        }

    }
    protected void LBcaptcha_Click(object sender, EventArgs e)
    {
        Response.Cookies["Captcha"]["value"] = (Guid.NewGuid().ToString()).Substring(0, 5);
        string text = (Guid.NewGuid().ToString()).Substring(0, 4);
        imgcaptcha.ImageUrl = Page.Request.Url.AbsolutePath.ToString() + "?p=captcha&text=" + text;
    }
}
