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
using System.Collections.Generic;
using CommonClass;

namespace PGFine
{
    public partial class introduction : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
            }
            Render();
        }
        public void SendMail(string MailToR)
        {
            Sycomore.SendMail mail = new Sycomore.SendMail();
            mail.MailFrom = "tuanvua6@gmail.com";
            mail.MailHost = System.Configuration.ConfigurationSettings.AppSettings["MailHost"];
            mail.MailMembersSend = MailToR;
            mail.MailName = txtEmailYou.Text.Trim();
            mail.MailContent = CommonClass.StringValidator.GetSafeString(txtContent.Text);
            mail.MailPassName = System.Configuration.ConfigurationSettings.AppSettings["PassWord"];
            List<string> path = new List<string>();
            //path.Add("D:");       
            mail.MailPathFileAttach = path;
            mail.MailPort = System.Configuration.ConfigurationSettings.AppSettings["MailPort"];
            mail.MailServerName = System.Configuration.ConfigurationSettings.AppSettings["MailServerNameSent"];
            mail.MailSubject = CommonClass.StringValidator.GetSafeString(txtSubject.Text); ;
            mail.MailTo = MailToR;
            mail.Send();
        }

        protected void btSend_Click(object sender, EventArgs e)
        {
            SendMail(txtEmailYourF.Text.Trim());
            LoadBegin();
            CommonClass.MessageBox.Show("Gửi mail thành công.");
        }

        protected void btReset_Click(object sender, EventArgs e)
        {
            LoadBegin();
        }

        private void LoadBegin()
        {
            txtEmailYourF.Text = string.Empty;
            txtSubject.Text = string.Empty;
            txtEmailYou.Text = string.Empty;
            txtContent.Text = string.Empty;
        }

        private void Render()
        {
            ltrSendYour.Text = Location.GetLanguageTag("introYour").ToString();
            ltrEmailF.Text = Location.GetLanguageTag("EmailF").ToString();
            ltrEmailReceiver.Text = Location.GetLanguageTag("EmailReceiver").ToString();
            ltrSubject.Text = Location.GetLanguageTag("SubjectS").ToString();
            ltrContent.Text = Location.GetLanguageTag("Content").ToString();
            btSend.Text = Location.GetLanguageTag("btSent").ToString();
            btReset.Text = Location.GetLanguageTag("Reset").ToString();
        }
    }
}
