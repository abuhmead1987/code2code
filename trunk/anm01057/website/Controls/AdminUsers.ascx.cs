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
using System.Net;
using System.Net.Mail;
using System.Text;

public partial class Controls_AdminUsers : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.IsAuthenticated)
            {
                Page.Title = GetGlobalResourceObject("language", "User") + " " + GetGlobalResourceObject("language", "Settings");
                MembershipUser user = Membership.GetUser();
                anm_Utility ut = new anm_Utility();
                string role = ut.GetRole(user.UserName);
                if (role != "1")
                    Response.Redirect(Page.Request.Url.AbsolutePath.ToString() + "?p=Confirm&mes=" + GetGlobalResourceObject("language", "nopermission") + "");
            }
            else
                FormsAuthentication.RedirectToLoginPage();
        }
    }
    protected void Delete_Command(object sender, CommandEventArgs e)
    {
        try
        {
            anm_Utility ut = new anm_Utility();
            string username = (string)e.CommandArgument;

            if (username == "Anonymous")
            {
                lblalert.Text = GetGlobalResourceObject("language", "cannotremove") + " Anonymous";
                lblalert.Visible = true;
            }
            else
            {
                string strConn = ConfigurationManager.ConnectionStrings["anmcs"].ToString();
                SqlConnection myConnection = new SqlConnection(strConn);
                SqlCommand myCommand = new SqlCommand();
                myCommand.Connection = myConnection;

                myCommand.Parameters.Add(
                   "@commentator", SqlDbType.NVarChar).Value = username;
                myCommand.CommandText = "UPDATE anm_Comments SET commentator='Anonymous' WHERE commentator=@commentator";
                myConnection.Open();
                object accountNumber = myCommand.ExecuteScalar();
                myConnection.Close();

                Membership.DeleteUser(username);
                lblalert.Text = GetGlobalResourceObject("language", "Userdeleted").ToString();
                lblalert.Visible = true;
                GridView1.DataBind();
            }
        }
        catch
        {
            lblalert.Text = GetGlobalResourceObject("language", "deleteuserreq").ToString();
            lblalert.Visible = true;
        }
    }
    protected void ButtonEmail_Click(object sender, EventArgs e)
    {
        anm_Utility ut = new anm_Utility();
        lblalert.Text = ut.ChangeEmail(Membership.GetUser(lblusername.Text.ToString()), TextBoxEmail.Text);
        lblalert.Visible = true;
        GridView1.DataBind();
    }
    protected void Email_Command(object sender, CommandEventArgs e)
    {
        try
        {
            anm_Utility ut = new anm_Utility();
            lblusername.Text = (string)e.CommandArgument;
            lblusername.Visible = lblemail.Visible = TextBoxEmail.Visible = ButtonEmail.Visible = true;
            lblalert.Visible = false;
            TextBoxEmail.Text = "";
        }
        catch (Exception ex)
        {
            lblalert.Text = ex.Message;
        }
    }
    protected void DeleteAv_Command(object sender, CommandEventArgs e)
    {
        try
        {
            string pathToCheck = Server.MapPath("~\\images\\Avatars\\") + (string)e.CommandArgument + ".jpg";
            if (System.IO.File.Exists(pathToCheck))
                System.IO.File.Delete(pathToCheck);
            lblalert.Text = GetGlobalResourceObject("language", "AvatarDeleted").ToString();
            lblalert.Visible = true;
        }
        catch
        {
        }

    }
    protected void Approve_Command(object sender, CommandEventArgs e)
    {
        try
        {
            anm_Utility ut = new anm_Utility();
            string[] commandArgs = e.CommandArgument.ToString().Split(new char[] { ',' });
            string username = commandArgs[0];
            string userid = commandArgs[1];
            bool approved = Convert.ToBoolean(commandArgs[2]);
            if (!approved)
            {
                string strConn = ConfigurationManager.ConnectionStrings["anmcs"].ToString();
                SqlConnection myConnection = new SqlConnection(strConn);
                SqlCommand myCommand = new SqlCommand();
                myCommand.Connection = myConnection;

                myCommand.Parameters.Add(
                   "@IsApproved", SqlDbType.Bit).Value = true;
                myCommand.Parameters.Add(
                   "@UserId", SqlDbType.NVarChar).Value = userid;
                myCommand.CommandText = "UPDATE aspnet_Membership SET IsApproved=@IsApproved WHERE UserId=@UserId";
                myConnection.Open();
                object accountNumber = myCommand.ExecuteScalar();
                myConnection.Close();
                lblalert.Text = GetGlobalResourceObject("language", "Userapproved").ToString();
                GridView1.DataBind();
            }
            else
                lblalert.Text = GetGlobalResourceObject("language", "Useralrapproved").ToString();
        }
        catch (Exception ex)
        {
            lblalert.Text = ex.Message;
        }
        lblalert.Visible = true;
    }
    protected void NewPassword_Command(object sender, CommandEventArgs e)
    {
        try
        {
            anm_Utility ut = new anm_Utility();
            string[] commandArgs = e.CommandArgument.ToString().Split(new char[] { ',' });
            string username = commandArgs[0];
            string userid = commandArgs[1];
            string oldpassword = "";
                string strConn = ConfigurationManager.ConnectionStrings["anmcs"].ToString();
                SqlConnection myConnection = new SqlConnection(strConn);
                SqlCommand myCommand = new SqlCommand();
                myCommand.Connection = myConnection;

                myCommand.Parameters.Add(
                   "@UserId", SqlDbType.NVarChar).Value = userid;
                myConnection.Open();
                myCommand.CommandText = "SELECT Password FROM aspnet_Membership WHERE UserId=@UserId";
                SqlDataReader reader = myCommand.ExecuteReader();
                while (reader.Read())
                    oldpassword = reader["Password"].ToString();
                myConnection.Close();

                MembershipProvider mp = Membership.Providers["TempMembershipSqlProvider"];
                MembershipUser mu = mp.GetUser(username, false);
                if (mu.IsLockedOut == true)
                    mu.UnlockUser();
                string newpassword = mu.ResetPassword();

                StringBuilder bodyMsg = new StringBuilder();
                bodyMsg.Append(GetGlobalResourceObject("language", "newpswgenerated") + " " + ut.GetSetting("SiteUrl") + ".");
                bodyMsg.Append("<br />");
                bodyMsg.Append("<br />");
                bodyMsg.AppendFormat("UserName: {0}", username);
                bodyMsg.Append("<br />");
                bodyMsg.AppendFormat("Password: {0}", newpassword);
                bodyMsg.Append("<br />");

                NetworkCredential loginInfo = new NetworkCredential(ut.GetSetting("MailUser"), ut.GetSetting("MailPassword"));
                MailMessage msg = new MailMessage();
                msg.From = new MailAddress(ut.GetSetting("SiteEmail"));
                msg.To.Add(new MailAddress(mu.Email));
                msg.Subject = GetGlobalResourceObject("language", "newpswgenby") + " " + ut.GetSetting("SiteUrl");
                msg.Body = bodyMsg.ToString();
                msg.IsBodyHtml = true;

                SmtpClient client = new SmtpClient(ut.GetSetting("smtpserver"), Convert.ToInt32(ut.GetSetting("port")));
                client.Credentials = loginInfo;
                client.Send(msg);

                lblalert.Text = GetGlobalResourceObject("language", "newpswsent").ToString();
        }
        catch (Exception ex)
        {
            lblalert.Text = ex.Message;
        }
        lblalert.Visible = true;
    }
}
