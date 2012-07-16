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
using System.Data.SqlClient;
using System.IO;
using System.Web.Configuration;
using anm_utility;

public partial class install : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            anm_Utility ut = new anm_Utility();
            if (ut.IsInstalled())
            {
                if (ut.GetSetting("Version") == "1.5")
                    Response.Redirect("~/Default.aspx");
                else
                {
                    pnlInstall.Visible = false;
                    Button1.Text = "Click here to upgrade";
                }
            }

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            anm_Utility ut = new anm_Utility();
            Boolean update = ut.IsInstalled();
            string sqlConnectionString = ConfigurationManager.ConnectionStrings["anmcs"].ToString();
            if (update)
            {
                MembershipCreateStatus res;
                MembershipUser usr = Membership.CreateUser("Anonymous", Guid.NewGuid().ToString(), "anonymous@allnewsmanager.net", Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), true, out res);
                string version = ut.GetSetting("Version");
                if (version != "1.1" && version != "1.2" && version != "1.3" && version != "1.4")
                {

                    FileInfo file = new FileInfo(Server.MapPath("~\\script1.1.sql"));
                    string script = file.OpenText().ReadToEnd();
                    FileInfo file3 = new FileInfo(Server.MapPath("~\\script1.2.sql"));
                    string script3 = file3.OpenText().ReadToEnd();
                    FileInfo file4 = new FileInfo(Server.MapPath("~\\script1.3.sql"));
                    string script4 = file4.OpenText().ReadToEnd();
                    FileInfo file5 = new FileInfo(Server.MapPath("~\\script1.4.sql"));
                    string script5 = file5.OpenText().ReadToEnd();
                    FileInfo file6 = new FileInfo(Server.MapPath("~\\script1.5.sql"));
                    string script6 = file5.OpenText().ReadToEnd();
                    SqlConnection conn = new SqlConnection(sqlConnectionString);

                    SqlCommand command = new SqlCommand(script, conn);
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                    command.Connection.Close();

                    SqlCommand command3 = new SqlCommand(script3, conn);
                    command3.Connection.Open();
                    command3.ExecuteNonQuery();
                    command3.Connection.Close();

                    SqlCommand command4 = new SqlCommand(script4, conn);
                    command4.Connection.Open();
                    command4.ExecuteNonQuery();
                    command4.Connection.Close();

                    SqlCommand command5 = new SqlCommand(script5, conn);
                    command5.Connection.Open();
                    command5.ExecuteNonQuery();
                    command5.Connection.Close();

                    SqlCommand command6 = new SqlCommand(script6, conn);
                    command6.Connection.Open();
                    command6.ExecuteNonQuery();
                    command6.Connection.Close(); 
                }
                else if (version == "1.1")
                {

                    FileInfo file = new FileInfo(Server.MapPath("~\\script1.2.sql"));
                    string script = file.OpenText().ReadToEnd();
                    FileInfo file4 = new FileInfo(Server.MapPath("~\\script1.3.sql"));
                    string script4 = file4.OpenText().ReadToEnd();
                    FileInfo file5 = new FileInfo(Server.MapPath("~\\script1.4.sql"));
                    string script5 = file5.OpenText().ReadToEnd();
                    FileInfo file6 = new FileInfo(Server.MapPath("~\\script1.5.sql"));
                    string script6 = file6.OpenText().ReadToEnd();
                    SqlConnection conn = new SqlConnection(sqlConnectionString);

                    SqlCommand command = new SqlCommand(script, conn);
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                    command.Connection.Close();

                    SqlCommand command4 = new SqlCommand(script4, conn);
                    command4.Connection.Open();
                    command4.ExecuteNonQuery();
                    command4.Connection.Close();

                    SqlCommand command5 = new SqlCommand(script5, conn);
                    command5.Connection.Open();
                    command5.ExecuteNonQuery();
                    command5.Connection.Close();

                    SqlCommand command6 = new SqlCommand(script6, conn);
                    command6.Connection.Open();
                    command6.ExecuteNonQuery();
                    command6.Connection.Close(); 
                }
                else if (version == "1.2")
                {

                    FileInfo file = new FileInfo(Server.MapPath("~\\script1.3.sql"));
                    string script = file.OpenText().ReadToEnd();
                    FileInfo file5 = new FileInfo(Server.MapPath("~\\script1.4.sql"));
                    string script5 = file5.OpenText().ReadToEnd();
                    FileInfo file6 = new FileInfo(Server.MapPath("~\\script1.5.sql"));
                    string script6 = file6.OpenText().ReadToEnd(); 
                    SqlConnection conn = new SqlConnection(sqlConnectionString);

                    SqlCommand command = new SqlCommand(script, conn);
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                    command.Connection.Close();

                    SqlCommand command5 = new SqlCommand(script5, conn);
                    command5.Connection.Open();
                    command5.ExecuteNonQuery();
                    command5.Connection.Close();

                    SqlCommand command6 = new SqlCommand(script6, conn);
                    command6.Connection.Open();
                    command6.ExecuteNonQuery();
                    command6.Connection.Close(); 
                }
                else if (version == "1.3")
                {
                    FileInfo file = new FileInfo(Server.MapPath("~\\script1.4.sql"));
                    string script = file.OpenText().ReadToEnd();
                    FileInfo file6 = new FileInfo(Server.MapPath("~\\script1.5.sql"));
                    string script6 = file6.OpenText().ReadToEnd(); 
                    SqlConnection conn = new SqlConnection(sqlConnectionString);

                    SqlCommand command = new SqlCommand(script, conn);
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                    command.Connection.Close();

                    SqlCommand command6 = new SqlCommand(script6, conn);
                    command6.Connection.Open();
                    command6.ExecuteNonQuery();
                    command6.Connection.Close(); 
                }
                else if (version == "1.4")
                {
                    FileInfo file6 = new FileInfo(Server.MapPath("~\\script1.5.sql"));
                    string script6 = file6.OpenText().ReadToEnd();
                    SqlConnection conn = new SqlConnection(sqlConnectionString);

                    SqlCommand command6 = new SqlCommand(script6, conn);
                    command6.Connection.Open();
                    command6.ExecuteNonQuery();
                    command6.Connection.Close();
                }
            }
            else
            {
                FileInfo file = new FileInfo(Server.MapPath("~\\script.sql"));
                string script = file.OpenText().ReadToEnd();
                FileInfo file2 = new FileInfo(Server.MapPath("~\\script1.1.sql"));
                string script2 = file2.OpenText().ReadToEnd();
                FileInfo file3 = new FileInfo(Server.MapPath("~\\script1.2.sql"));
                string script3 = file3.OpenText().ReadToEnd();
                FileInfo file4 = new FileInfo(Server.MapPath("~\\script1.3.sql"));
                string script4 = file4.OpenText().ReadToEnd();
                FileInfo file5 = new FileInfo(Server.MapPath("~\\script1.4.sql"));
                string script5 = file5.OpenText().ReadToEnd();
                FileInfo file6 = new FileInfo(Server.MapPath("~\\script1.5.sql"));
                string script6 = file6.OpenText().ReadToEnd(); 
                SqlConnection conn = new SqlConnection(sqlConnectionString);

                SqlCommand command = new SqlCommand(script, conn);
                command.Connection.Open();
                command.ExecuteNonQuery();
                command.Connection.Close();

                SqlCommand command2 = new SqlCommand(script2, conn);
                command2.Connection.Open();
                command2.ExecuteNonQuery();
                command2.Connection.Close();

                SqlCommand command3 = new SqlCommand(script3, conn);
                command3.Connection.Open();
                command3.ExecuteNonQuery();
                command3.Connection.Close();

                SqlCommand command4 = new SqlCommand(script4, conn);
                command4.Connection.Open();
                command4.ExecuteNonQuery();
                command4.Connection.Close();

                SqlCommand command5 = new SqlCommand(script5, conn);
                command5.Connection.Open();
                command5.ExecuteNonQuery();
                command5.Connection.Close();

                SqlCommand command6 = new SqlCommand(script6, conn);
                command6.Connection.Open();
                command6.ExecuteNonQuery();
                command6.Connection.Close(); 
                
                MembershipCreateStatus result;
                MembershipUser user = Membership.CreateUser("admin", "anm-psw", tbMailServer.Text.ToString(), "AllNewsManager", "Yes", true, out result);
                MembershipUser user2 = Membership.CreateUser("Anonymous", Guid.NewGuid().ToString(), "anonymous@allnewsmanager.net", Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), true, out result);
            }

            string strConn = ConfigurationManager.ConnectionStrings["anmcs"].ToString();
            SqlConnection myConnection = new SqlConnection(strConn);
            SqlCommand myCommand = new SqlCommand();
            myCommand.Connection = myConnection;
            myConnection.Open();


            myCommand.CommandText = "SELECT COUNT(*) FROM anm_Authors WHERE author = 'admin'";
            Int32 row = (Int32)myCommand.ExecuteScalar();
            if (row < 1)
            {
                myCommand.Parameters.Add(
                   "@role", SqlDbType.NChar).Value = "1";
                myCommand.Parameters.Add(
                   "@author", SqlDbType.NChar).Value = "admin";
                myCommand.CommandText = "INSERT INTO anm_Authors(role,author) VALUES (@role,@author)";
                myCommand.ExecuteScalar();
            }

            myCommand.CommandText = "SELECT COUNT(*) FROM anm_Templates WHERE Template = '1'";
            row = (Int32)myCommand.ExecuteScalar();

            if (row < 1)
            {
                myCommand.Parameters.Add(
                   "@name_", SqlDbType.NChar).Value = "Light";
                myCommand.CommandText = "INSERT INTO anm_Templates(name) VALUES (@name_)";
                myCommand.ExecuteScalar();
            }

            myCommand.CommandText = "SELECT COUNT(*) FROM anm_Templates WHERE Template = '2'";
            row = (Int32)myCommand.ExecuteScalar();

            if (row < 1)
            {
                myCommand.Parameters.Add(
                   "@name_2", SqlDbType.NChar).Value = "Dark";
                myCommand.CommandText = "INSERT INTO anm_Templates(name) VALUES (@name_2)";
                myCommand.ExecuteScalar();
            }

            myCommand.CommandText = "SELECT COUNT(*) FROM anm_Categories";
            row = (Int32)myCommand.ExecuteScalar();

            if (row < 1)
            {
                myCommand.Parameters.Add(
                   "@category", SqlDbType.NChar).Value = "Welcome";
                myCommand.Parameters.Add(
                   "@idrootcat", SqlDbType.NChar).Value = "1";
                myCommand.CommandText = "INSERT INTO anm_Categories(category,idrootcat) VALUES (@category,@idrootcat)";
                myCommand.ExecuteScalar();
            }

            myCommand.CommandText = "SELECT COUNT(*) FROM anm_Settings WHERE id='1'";
            row = (Int32)myCommand.ExecuteScalar();

            if (row < 1)
            {
                myCommand.Parameters.Add(
                   "@id", SqlDbType.NChar).Value = "1";
                myCommand.Parameters.Add(
                   "@SiteName", SqlDbType.NChar).Value = tbSiteName.Text;
                myCommand.Parameters.Add(
                   "@SiteEmail", SqlDbType.NChar).Value = tbMailServer.Text;
                myCommand.Parameters.Add(
                   "@SiteUrl", SqlDbType.NChar).Value = tbSiteUrl.Text;
                myCommand.Parameters.Add(
                   "@Template", SqlDbType.NChar).Value = "1";
                myCommand.Parameters.Add(
                   "@TopMenu", SqlDbType.NChar).Value = "True";
                myCommand.Parameters.Add(
                   "@SideMenu", SqlDbType.NChar).Value = "True";
                myCommand.Parameters.Add(
                   "@SearchMenu", SqlDbType.NChar).Value = "True";
                myCommand.Parameters.Add(
                   "@ArchiveMenu", SqlDbType.NChar).Value = "True";
                myCommand.Parameters.Add(
                   "@EmailConfirm", SqlDbType.NChar).Value = "False";
                myCommand.Parameters.Add(
                   "@MailUser", SqlDbType.NChar).Value = "".Trim();
                myCommand.Parameters.Add(
                   "@MailPassword", SqlDbType.NChar).Value = "".Trim();
                myCommand.Parameters.Add(
                   "@smtpserver", SqlDbType.NChar).Value = "".Trim();
                myCommand.Parameters.Add(
                   "@port", SqlDbType.NChar).Value = "".Trim();
                myCommand.Parameters.Add(
                   "@Banner", SqlDbType.NChar).Value = "".Trim();
                myCommand.Parameters.Add(
                   "@Year", SqlDbType.NChar).Value = DateTime.Now.Year.ToString();
                myCommand.Parameters.Add(
                   "@Month", SqlDbType.NChar).Value = DateTime.Now.Month.ToString();
                myCommand.Parameters.Add(
                   "@HBGColor", SqlDbType.NChar).Value = "FFFFFF";
                myCommand.Parameters.Add(
                   "@BGcolor", SqlDbType.NChar).Value = "FFFFFF";
                myCommand.Parameters.Add(
                   "@BGimage", SqlDbType.NChar).Value = "".Trim();
                myCommand.Parameters.Add(
                   "@Width", SqlDbType.NChar).Value = "100%";

                myCommand.Parameters.Add(
                   "@NumArticles", SqlDbType.NChar).Value = "10";
                myCommand.Parameters.Add(
                   "@NumComments", SqlDbType.NChar).Value = "10";
                myCommand.Parameters.Add(
                   "@ApproveArticles", SqlDbType.NChar).Value = "False";
                myCommand.Parameters.Add(
                   "@ApproveComments", SqlDbType.NChar).Value = "False";
                myCommand.Parameters.Add(
                   "@BBCode", SqlDbType.NChar).Value = "True";
                myCommand.Parameters.Add(
                   "@Copyright", SqlDbType.NChar).Value = "False";
                myCommand.Parameters.Add(
                   "@ViewNarticles", SqlDbType.NChar).Value = "True";
                myCommand.Parameters.Add(
                   "@Validator", SqlDbType.NChar).Value = "False";
                myCommand.Parameters.Add(
                   "@LastNews", SqlDbType.NChar).Value = "True";
                myCommand.Parameters.Add(
                   "@LastComments", SqlDbType.NChar).Value = "False";
                myCommand.Parameters.Add(
                   "@CaptchaNewUser", SqlDbType.NChar).Value = "False";
                myCommand.Parameters.Add(
                   "@CaptchaComments", SqlDbType.NChar).Value = "False";
                myCommand.Parameters.Add(
                   "@Version", SqlDbType.NChar).Value = "1.5";
                myCommand.Parameters.Add(
                   "@ArchiveType", SqlDbType.NChar).Value = "2";
                myCommand.Parameters.Add(
                   "@TagBox", SqlDbType.NChar).Value = "False";
                myCommand.Parameters.Add(
                   "@CaptchaType", SqlDbType.NChar).Value = "1";
                myCommand.CommandText = "INSERT INTO anm_Settings(id,SiteName,SiteEmail,SiteUrl,Template,TopMenu,SideMenu,SearchMenu,ArchiveMenu,EmailConfirm,MailUser,MailPassword,smtpserver,port,Banner,Year,Month,HBGColor,BGcolor,BGimage,Width,NumArticles,NumComments,ApproveArticles,ApproveComments,BBCode,Copyright,ViewNarticles,Validator,LastNews,LastComments,CaptchaNewUser,CaptchaComments,Version,ArchiveType,TagBox,CaptchaType) VALUES (@id,@SiteName,@SiteEmail,@SiteUrl,@Template,@TopMenu,@SideMenu,@SearchMenu,@ArchiveMenu,@EmailConfirm,@MailUser,@MailPassword,@smtpserver,@port,@Banner,@Year,@Month,@HBGColor,@BGcolor,@BGimage,@Width,@NumArticles,@NumComments,@ApproveArticles,@ApproveComments,@BBCode,@Copyright,@ViewNarticles,@Validator,@LastNews,@LastComments,@CaptchaNewUser,@CaptchaComments,@Version,@ArchiveType,@TagBox,@CaptchaType)";
                myCommand.ExecuteScalar();
                HttpContext.Current.Response.Cookies["Version"]["Version"] = "1.5";
                HttpContext.Current.Response.Cookies["Version"].Expires = DateTime.Now.AddYears(1);
            }
            else
            {
                myCommand.Parameters.Add(
                   "@NumArticles", SqlDbType.NChar).Value = "10";
                myCommand.Parameters.Add(
                   "@NumComments", SqlDbType.NChar).Value = "10";
                myCommand.Parameters.Add(
                   "@ApproveArticles", SqlDbType.NChar).Value = "False";
                myCommand.Parameters.Add(
                   "@ApproveComments", SqlDbType.NChar).Value = "False";
                myCommand.Parameters.Add(
                   "@BBCode", SqlDbType.NChar).Value = "True";
                myCommand.Parameters.Add(
                   "@Copyright", SqlDbType.NChar).Value = "False";
                myCommand.Parameters.Add(
                   "@ViewNarticles", SqlDbType.NChar).Value = "True";
                myCommand.Parameters.Add(
                   "@Validator", SqlDbType.NChar).Value = "False";
                myCommand.Parameters.Add(
                   "@LastNews", SqlDbType.NChar).Value = "True";
                myCommand.Parameters.Add(
                   "@LastComments", SqlDbType.NChar).Value = "False";
                myCommand.Parameters.Add(
                   "@CaptchaNewUser", SqlDbType.NChar).Value = "False";
                myCommand.Parameters.Add(
                   "@CaptchaComments", SqlDbType.NChar).Value = "False";
                myCommand.Parameters.Add(
                   "@Version", SqlDbType.NChar).Value = "1.5";
                myCommand.Parameters.Add(
                   "@ArchiveType", SqlDbType.NChar).Value = "2";
                myCommand.Parameters.Add(
                   "@TagBox", SqlDbType.NChar).Value = "False";
                myCommand.Parameters.Add(
                   "@CaptchaType", SqlDbType.NChar).Value = "1";
                myCommand.CommandText = "UPDATE anm_Settings SET NumArticles=@NumArticles, NumComments=@NumComments, ApproveArticles=@ApproveArticles, ApproveComments=@ApproveComments, BBCode=@BBCode, Copyright=@Copyright, ViewNarticles=@ViewNarticles, Validator=@Validator, LastNews=@LastNews, LastComments=@LastComments ,CaptchaNewUser=@CaptchaNewUser, CaptchaComments=@CaptchaComments, Version=@Version, ArchiveType=@ArchiveType, TagBox=@TagBox, CaptchaType=@CaptchaType WHERE id = 1";
                myCommand.ExecuteScalar();
                HttpContext.Current.Response.Cookies["Version"]["Version"] = "1.5";
                HttpContext.Current.Response.Cookies["Version"].Expires = DateTime.Now.AddYears(1);
            }

            myCommand.CommandText = "SELECT COUNT(*) FROM anm_News";
            row = (Int32)myCommand.ExecuteScalar();

            if (row < 1)
            {
                myCommand.Parameters.Add(
                   "@title", SqlDbType.NChar).Value = "AllNewsManager.Net installed !!!";
                myCommand.Parameters.Add(
                   "@author_news", SqlDbType.NChar).Value = "admin";
                myCommand.Parameters.Add(
                   "@date", SqlDbType.DateTime).Value = DateTime.Now;
                myCommand.Parameters.Add(
                   "@summary", SqlDbType.NChar).Value = "".Trim();
                myCommand.Parameters.Add(
                   "@news", SqlDbType.NChar).Value = "AllNewsManager.Net installed !!! Now you can <strong>log in as admin user and configure it</strong>.<br /><br /><span style='background-color: rgb(255, 255, 0);'><strong>User:</strong> admin<br /><strong>Password: </strong>anm-psw</span><br /><br /><br /><strong>Change your password after logged in.</strong><br /><br /><em>Remove this message from admin section.</em>";
                myCommand.Parameters.Add(
                   "@idcategory", SqlDbType.NChar).Value = "1";
                myCommand.Parameters.Add(
                   "@comments", SqlDbType.NChar).Value = "0";
                myCommand.Parameters.Add(
                   "@commentcheck", SqlDbType.NChar).Value = "False";
                myCommand.Parameters.Add(
                   "@published", SqlDbType.NChar).Value = "True";
                myCommand.Parameters.Add(
                   "@highlight", SqlDbType.NChar).Value = "True";
                myCommand.Parameters.Add(
                   "@postedby", SqlDbType.NChar).Value = "False";
                myCommand.Parameters.Add(
                   "@sidenews", SqlDbType.NChar).Value = "False";
				myCommand.CommandText = "INSERT INTO anm_News(title,author,date,news,idcategory,comments,commentcheck,published,highlight,postedby,sidenews) VALUES (@title,@author_news,@date,@news,@idcategory,@comments,@commentcheck,@published,@highlight,@postedby,@sidenews)";
                myCommand.ExecuteScalar();
            }

            myConnection.Close();


            Response.Redirect("~/Default.aspx");

        }
        catch
        {
            Label1.Visible = true;
        }
    }
}
