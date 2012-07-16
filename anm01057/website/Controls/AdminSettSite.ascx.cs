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
using anm_utility;
using System.Data.SqlClient;
using System.Web.Configuration;

public partial class Controls_AdminSettSite : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.IsAuthenticated)
            {
                Page.Title = GetGlobalResourceObject("language", "Site") + " " + GetGlobalResourceObject("language", "Settings");
                MembershipUser user = Membership.GetUser();
                anm_Utility ut = new anm_Utility();
                string role = ut.GetRole(user.UserName);
                if (role != "1")
                    Response.Redirect(Page.Request.Url.AbsolutePath.ToString() + "?p=Confirm&mes=" + GetGlobalResourceObject("language", "nopermission") + "");
                txtsn.Text = ut.GetSetting("SiteName");
                txtemail.Text = ut.GetSetting("SiteEmail");
                txturl.Text = ut.GetSetting("SiteUrl");
                CheckBox4.Checked = Convert.ToBoolean(ut.GetSetting("SearchMenu"));
                CheckBox5.Checked = Convert.ToBoolean(ut.GetSetting("ArchiveMenu"));
                CheckBox9.Checked = Convert.ToBoolean(ut.GetSetting("EmailConfirm"));
                txtSmtp.Text = ut.GetSetting("smtpserver");
                txtUserMail.Text = ut.GetSetting("MailUser");
                txtPswMail.Text = ut.GetSetting("MailPassword");
                txtPort.Text = ut.GetSetting("port");

                string banner = ut.GetSetting("Banner");
                txtBanner.Text = banner;
                if (banner != "")
                {
                    txtBanner.Visible = true;
                    FileUpload1.Visible = true;
                    CheckBox2.Checked = true;
                }
                //Label8.Visible = Label9.Visible = Label10.Visible = txtW.Visible = txtW.Enabled = CheckBox2.Checked;
                //txtH.Visible = txtH.Enabled = CheckBox2.Checked;
                txtBanner.Visible = FileUpload1.Visible = CheckBox2.Checked;
                if (ut.GetSetting("Validator") != "")
                    CheckBox3.Checked = Convert.ToBoolean(ut.GetSetting("Validator"));
                if (ut.GetSetting("ViewNarticles") != "")
                    CheckBox1.Checked = Convert.ToBoolean(ut.GetSetting("ViewNarticles"));
                if (ut.GetSetting("LastNews") != "")
                    CheckBox6.Checked = Convert.ToBoolean(ut.GetSetting("LastNews"));
                if (ut.GetSetting("LastComments") != "")
                    CheckBox7.Checked = Convert.ToBoolean(ut.GetSetting("LastComments"));
                if (ut.GetSetting("CaptchaNewUser") != "")
                    CheckBox8.Checked = Convert.ToBoolean(ut.GetSetting("CaptchaNewUser"));
                if (ut.GetSetting("CaptchaComments") != "")
                    CheckBox10.Checked = Convert.ToBoolean(ut.GetSetting("CaptchaComments"));
                if (ut.GetSetting("TagBox") != "")
                    CheckBox11.Checked = Convert.ToBoolean(ut.GetSetting("TagBox"));
                if (ut.GetSetting("OnlineUsers") != "")
                    CheckBox12.Checked = Convert.ToBoolean(ut.GetSetting("OnlineUsers")); 
                if (ut.GetSetting("ArchiveType") == "1")
                    chkType1.Checked = true;
                if (ut.GetSetting("ArchiveType") == "2")
                    chkType2.Checked = true;
                DDcaptcha.Items.Add("1");
                DDcaptcha.Items.Add("2");
                if (ut.GetSetting("CaptchaType") != "")
                {
                    DDcaptcha.SelectedValue = ut.GetSetting("CaptchaType");
                    ddimg.ImageUrl = "~/images/captchaexample" + ut.GetSetting("CaptchaType") + ".jpg";
                }
                else
                {
                    DDcaptcha.SelectedValue = "1";
                    ddimg.ImageUrl = "~/images/captchaexample1.jpg";
                }
            }
            else
                FormsAuthentication.RedirectToLoginPage();
        }
    }
    protected void UpdateSettings_Click(object sender, EventArgs e)
    {
        anm_Utility dt = new anm_Utility();
        Boolean error = false;
        if ((txtSmtp.Text == dt.GetSetting("smtpserver")) && (txtUserMail.Text == dt.GetSetting("MailUser")) && (txtPswMail.Text == dt.GetSetting("MailPassword")) && (txtPort.Text == dt.GetSetting("port")))
        {
        }
        else
        {
            try
            {
                System.Configuration.Configuration config = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~/");
                System.Net.Configuration.MailSettingsSectionGroup mailSection = config.GetSectionGroup("system.net/mailSettings") as System.Net.Configuration.MailSettingsSectionGroup;
                mailSection.Smtp.From = txtemail.Text;
                mailSection.Smtp.Network.Host = txtSmtp.Text;
                mailSection.Smtp.Network.UserName = txtUserMail.Text;
                mailSection.Smtp.Network.Password = txtPswMail.Text;
                int mailPort = 25;
                bool isNum = int.TryParse(txtPort.Text, out mailPort);
                if (isNum)
                    mailSection.Smtp.Network.Port = mailPort;
                else
                    mailSection.Smtp.Network.Port = 25;
                config.Save(ConfigurationSaveMode.Modified);
            }
            catch
            {
                Label11.Text = GetGlobalResourceObject("language", "nopermupdwebconf").ToString();
                Label11.Visible = true;
                error = true;
            }
        }
        int archivetype = 0;
        if (chkType1.Checked)
            archivetype = 1;
        if (chkType2.Checked)
            archivetype = 2;

        string strConn = ConfigurationManager.ConnectionStrings["anmcs"].ToString();
        SqlConnection myConnection = new SqlConnection(strConn);
        SqlCommand command = new SqlCommand();
        command.Connection = myConnection;
        command.Parameters.Add("@SiteName", SqlDbType.NVarChar).Value = txtsn.Text.ToString();
        Cache.Insert("SiteName", txtsn.Text.ToString(), null, DateTime.Now.AddMonths(6), TimeSpan.Zero, System.Web.Caching.CacheItemPriority.High, null);
        command.Parameters.Add("@SiteEmail", SqlDbType.NVarChar).Value = txtemail.Text.ToString();
        Cache.Insert("SiteEmail", txtemail.Text.ToString(), null, DateTime.Now.AddMonths(6), TimeSpan.Zero, System.Web.Caching.CacheItemPriority.High, null);
        command.Parameters.Add("@SiteUrl", SqlDbType.NVarChar).Value = txturl.Text.ToString();
        Cache.Insert("SiteUrl", txturl.Text.ToString(), null, DateTime.Now.AddMonths(6), TimeSpan.Zero, System.Web.Caching.CacheItemPriority.High, null);
        command.Parameters.Add("@Search", SqlDbType.Bit).Value = CheckBox4.Checked;
        Cache.Insert("SearchMenu", CheckBox4.Checked.ToString(), null, DateTime.Now.AddMonths(6), TimeSpan.Zero, System.Web.Caching.CacheItemPriority.High, null);
        command.Parameters.Add("@Validator", SqlDbType.Bit).Value = CheckBox3.Checked;
        Cache.Insert("Validator", CheckBox3.Checked.ToString(), null, DateTime.Now.AddMonths(6), TimeSpan.Zero, System.Web.Caching.CacheItemPriority.High, null);
        command.Parameters.Add("@Archive", SqlDbType.Bit).Value = CheckBox5.Checked;
        Cache.Insert("ArchiveMenu", CheckBox5.Checked.ToString(), null, DateTime.Now.AddMonths(6), TimeSpan.Zero, System.Web.Caching.CacheItemPriority.High, null);
        command.Parameters.Add("@LastNews", SqlDbType.Bit).Value = CheckBox6.Checked;
        Cache.Insert("LastNews", CheckBox6.Checked.ToString(), null, DateTime.Now.AddMonths(6), TimeSpan.Zero, System.Web.Caching.CacheItemPriority.High, null);
        command.Parameters.Add("@LastComments", SqlDbType.Bit).Value = CheckBox7.Checked;
        Cache.Insert("LastComments", CheckBox7.Checked.ToString(), null, DateTime.Now.AddMonths(6), TimeSpan.Zero, System.Web.Caching.CacheItemPriority.High, null);
        command.Parameters.Add("@CaptchaNewUser", SqlDbType.Bit).Value = CheckBox8.Checked;
        Cache.Insert("CaptchaNewUser", CheckBox8.Checked.ToString(), null, DateTime.Now.AddMonths(6), TimeSpan.Zero, System.Web.Caching.CacheItemPriority.High, null);
        command.Parameters.Add("@CaptchaComments", SqlDbType.Bit).Value = CheckBox10.Checked;
        Cache.Insert("CaptchaComments", CheckBox10.Checked.ToString(), null, DateTime.Now.AddMonths(6), TimeSpan.Zero, System.Web.Caching.CacheItemPriority.High, null);
        command.Parameters.Add("@EmailConfirm", SqlDbType.Bit).Value = CheckBox9.Checked;
        Cache.Insert("EmailConfirm", CheckBox9.Checked.ToString(), null, DateTime.Now.AddMonths(6), TimeSpan.Zero, System.Web.Caching.CacheItemPriority.High, null);
        command.Parameters.Add("@smtpserver", SqlDbType.NVarChar).Value = txtSmtp.Text.ToString();
        Cache.Insert("smtpserver", txtSmtp.Text.ToString(), null, DateTime.Now.AddMonths(6), TimeSpan.Zero, System.Web.Caching.CacheItemPriority.High, null);
        command.Parameters.Add("@MailUser", SqlDbType.NVarChar).Value = txtUserMail.Text.ToString();
        Cache.Insert("MailUser", txtUserMail.Text.ToString(), null, DateTime.Now.AddMonths(6), TimeSpan.Zero, System.Web.Caching.CacheItemPriority.High, null);
        command.Parameters.Add("@MailPassword", SqlDbType.NVarChar).Value = txtPswMail.Text.ToString();
        Cache.Insert("MailPassword", txtPswMail.Text.ToString(), null, DateTime.Now.AddMonths(6), TimeSpan.Zero, System.Web.Caching.CacheItemPriority.High, null);
        command.Parameters.Add("@port", SqlDbType.NVarChar).Value = txtPort.Text.ToString();
        Cache.Insert("port", txtPort.Text.ToString(), null, DateTime.Now.AddMonths(6), TimeSpan.Zero, System.Web.Caching.CacheItemPriority.High, null);
        command.Parameters.Add("@ViewNarticles", SqlDbType.Bit).Value = CheckBox1.Checked;
        Cache.Insert("ViewNarticles", CheckBox1.Checked.ToString(), null, DateTime.Now.AddMonths(6), TimeSpan.Zero, System.Web.Caching.CacheItemPriority.High, null);
        command.Parameters.Add("@ArchiveType", SqlDbType.Int).Value = archivetype;
        Cache.Insert("ArchiveType", archivetype, null, DateTime.Now.AddMonths(6), TimeSpan.Zero, System.Web.Caching.CacheItemPriority.High, null);
        command.Parameters.Add("@TagBox", SqlDbType.Bit).Value = CheckBox11.Checked;
        Cache.Insert("TagBox", CheckBox11.Checked.ToString(), null, DateTime.Now.AddMonths(6), TimeSpan.Zero, System.Web.Caching.CacheItemPriority.High, null);
        command.Parameters.Add("@CaptchaType", SqlDbType.NVarChar).Value = DDcaptcha.SelectedValue;
        Cache.Insert("CaptchaType", DDcaptcha.SelectedValue.ToString(), null, DateTime.Now.AddMonths(6), TimeSpan.Zero, System.Web.Caching.CacheItemPriority.High, null);
        command.Parameters.Add("@OnlineUsers", SqlDbType.Bit).Value = CheckBox12.Checked;
        Cache.Insert("OnlineUsers", CheckBox12.Checked.ToString(), null, DateTime.Now.AddMonths(6), TimeSpan.Zero, System.Web.Caching.CacheItemPriority.High, null);
        string banner = "";
        if (CheckBox2.Checked & FileUpload1.FileName.ToString() == "" & txtBanner.Text.ToString() != "")
            banner = txtBanner.Text.ToString();
        else if (CheckBox2.Checked & FileUpload1.FileName.ToString() != "")
        {
            anm_Utility ut = new anm_Utility();
            string filename = FileUpload1.FileName;
            string tempfileName = "";
            string savePath = Server.MapPath("~\\images\\");
            string pathToCheck = savePath + filename;
            if (System.IO.File.Exists(pathToCheck))
            {
                int counter = 2;
                while (System.IO.File.Exists(pathToCheck))
                {
                    tempfileName = counter.ToString() + filename;
                    pathToCheck = savePath + tempfileName;
                    counter++;
                }
                filename = tempfileName;
            }
            FileUpload1.SaveAs(Server.MapPath("~\\images\\full_") + filename);
            int newWidth = 0;
            int newHeight = 0;
            if (txtW.Text != "")
                newWidth = Convert.ToInt32(txtW.Text);
            if (txtH.Text != "")
                newHeight = Convert.ToInt32(txtH.Text);
            ut.GenerateImage(Server.MapPath("~\\images\\full_") + filename, Server.MapPath("~\\images\\") + filename, newWidth, newHeight, "", "", "jpeg", "Black", "Arial", 13, "br");

            banner = filename;
        }
        command.Parameters.Add("@Banner", SqlDbType.NVarChar).Value = banner;
        Cache.Insert("Banner", banner, null, DateTime.Now.AddMonths(6), TimeSpan.Zero, System.Web.Caching.CacheItemPriority.High, null);

        command.CommandText = "UPDATE anm_Settings SET SiteName=@SiteName,SiteEmail=@SiteEmail,SiteUrl=@SiteUrl,SearchMenu=@Search,Validator=@Validator,ArchiveMenu=@Archive,LastNews=@LastNews,LastComments=@LastComments,CaptchaNewUser=@CaptchaNewUser,CaptchaComments=@CaptchaComments,EmailConfirm=@EmailConfirm,smtpserver=@smtpserver,MailUser=@MailUser,MailPassword=@MailPassword,port=@port,Banner=@Banner,ViewNarticles=@ViewNarticles,ArchiveType=@ArchiveType,TagBox=@TagBox,CaptchaType=@CaptchaType,OnlineUsers=@OnlineUsers WHERE id=1";
        myConnection.Open();
        object accountNumber = command.ExecuteScalar();
        myConnection.Close();

        if (!error)
            Response.Redirect("homepage.aspx");
    }
    protected void CheckBox2_CheckedChanged(object sender, EventArgs e)
    {
        //Label8.Visible = Label9.Visible = Label10.Visible = txtBanner.Visible = CheckBox2.Checked;
        //txtH.Visible = txtW.Visible = txtH.Enabled = txtW.Enabled = FileUpload1.Visible = CheckBox2.Checked;
        txtBanner.Visible = FileUpload1.Visible = CheckBox2.Checked;
    }
    protected void chkType1_CheckedChanged(object sender, EventArgs e)
    {
        chkType2.Checked = false;
    }
    protected void chkType2_CheckedChanged(object sender, EventArgs e)
    {
        chkType1.Checked = false;
    }
    protected void DDcaptcha_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddimg.ImageUrl = "~/images/captchaexample" + DDcaptcha.Text + ".jpg";
    }
}
