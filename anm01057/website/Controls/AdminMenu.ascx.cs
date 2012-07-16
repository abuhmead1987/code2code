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
using anm_utility;

public partial class Controls_AdminMenu : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string path = Page.Request.Url.AbsolutePath.ToString();
            anm_Utility ut = new anm_Utility();
            if (Request.IsAuthenticated)
            {
                MembershipUser user = Membership.GetUser();
                string role = ut.GetRole(user.UserName);
                if (role == "1")
                {
                    HLa1.NavigateUrl = HLmenu1.NavigateUrl = path + "?p=AdminArticles";
                    HLa2.NavigateUrl = path + "?p=AddArticle";
                    HLa3.NavigateUrl = path + "?p=ApproveArticles";
                    HLa4.NavigateUrl = path + "?p=AdminSettArticles";
                    HLc1.NavigateUrl = HLmenu2.NavigateUrl = path + "?p=AdminComments&idnews=*";
                    HLc2.NavigateUrl = path + "?p=AdminComments";
                    HLc3.NavigateUrl = path + "?p=AdminSettComments";
                    HLc4.NavigateUrl = path + "?p=AdminReports";
                    Hlca1.NavigateUrl = HLmenu3.NavigateUrl = path + "?p=AdminCategories";
                    Hlca2.NavigateUrl = path + "?p=AddCategory";
                    Hlca3.NavigateUrl = path + "?p=AdminSettCategories";
                    Hlau2.NavigateUrl = path + "?p=AdminAuthors";
                    Hls3.NavigateUrl = path + "?p=AdminTemplates";
                    Hls1.NavigateUrl = HLmenu5.NavigateUrl = path + "?p=AdminSettSite";
                    Hls2.NavigateUrl = path + "?p=AdminLayout";
                    Hls4.NavigateUrl = path + "?p=Tags";
                    HLmenu4.NavigateUrl = Hlau1.NavigateUrl = path + "?p=AdminUsers";
                }
                else
                {
                    HLa1.Visible = false;
                    HLmenu1.NavigateUrl = "";
                    HLa2.NavigateUrl = path + "?p=AddArticle";
                    HLa3.Visible = false;
                    HLa4.Visible = false;
                    HLc1.NavigateUrl = HLmenu2.NavigateUrl = path + "?p=AdminComments&idnews=*";
                    HLc2.NavigateUrl = path + "?p=AdminComments";
                    HLc3.Visible = false;
                    Hlca1.Visible = false;
                    HLmenu3.Visible = false;
                    Hlca2.Visible = false;
                    Hlca3.Visible = false;
                    Hlau2.Visible = false;
                    Hls3.Visible = false;
                    Hls1.Visible = false;
                    HLmenu5.Visible = false;
                    Hls2.Visible = false;
                    Hls4.Visible = false;
                    HLmenu4.Visible = false;
                    Hlau1.Visible = false;
                    HLa3n.Visible = false;
                }
            }
            lblversion.Text = "Anm version: " + ut.GetSetting("Version");
            try
            {
                string strConn = ConfigurationManager.ConnectionStrings["anmcs"].ToString();
                SqlConnection myConnection = new SqlConnection(strConn);
                SqlCommand myCommand = new SqlCommand();
                myCommand.Connection = myConnection;
                myConnection.Open();
                myCommand.CommandText = "SELECT COUNT(*) FROM anm_News WHERE published='false'";
                Int32 articles = (Int32)myCommand.ExecuteScalar();
                myCommand.CommandText = "SELECT COUNT(*) FROM anm_Comments WHERE approved='false'";
                Int32 comments = (Int32)myCommand.ExecuteScalar();
                myCommand.CommandText = "SELECT COUNT(*) FROM anm_Reports";
                Int32 report = (Int32)myCommand.ExecuteScalar();
                myConnection.Close();
                if (articles > 0)
                    HLa3n.Font.Bold = true;
                if (comments > 0)
                    HLc2n.Font.Bold = true;
                HLa3n.Text = "(" + articles + ")";
                HLc2n.Text = "(" + comments + ")";
                HLc4n.Text = "(" + report + ")";
            }
            catch (Exception ex)
            {
                lblerror.Text = ex.Message;
                lblerror.Visible = true;
            }
        }
    }
}
