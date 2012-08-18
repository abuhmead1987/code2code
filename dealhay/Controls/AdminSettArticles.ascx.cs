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

public partial class Controls_AdminSettArticles : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.IsAuthenticated)
            {
                Page.Title = GetGlobalResourceObject("language", "Article") + " " + GetGlobalResourceObject("language", "Settings");
                MembershipUser user = Membership.GetUser();
                anm_Utility ut = new anm_Utility();
                string path = Page.Request.Url.AbsolutePath.ToString();
                string role = ut.GetRole(user.UserName);
                if (role != "1")
                    Response.Redirect(Page.Request.Url.AbsolutePath.ToString() + "?p=Confirm&mes=" + GetGlobalResourceObject("language", "nopermission") + "");
                TextBox1.Text = ut.GetSetting("NumArticles");
                if (ut.GetSetting("ApproveArticles") != "")
                    CheckBox1.Checked = Convert.ToBoolean(ut.GetSetting("ApproveArticles"));
                if (ut.GetSetting("Copyright") != "")
                    CheckBox2.Checked = Convert.ToBoolean(ut.GetSetting("Copyright"));
            }
            else
                FormsAuthentication.RedirectToLoginPage();
        }
        else
            Label4.Visible = false;
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            int numart = Convert.ToInt32(TextBox1.Text);
            if (numart < 5 || numart > 100)
                Label4.Visible = true;
            else
            {
                string strConn = ConfigurationManager.ConnectionStrings["anmcs"].ToString();
                SqlConnection myConnection = new SqlConnection(strConn);
                SqlCommand myCommand = new SqlCommand();
                myCommand.Connection = myConnection;

                myCommand.Parameters.Add(
                   "@NumArticles", SqlDbType.Int).Value = numart;
                HttpContext.Current.Cache.Insert("NumArticles", numart, null, DateTime.Now.AddMonths(6), TimeSpan.Zero, System.Web.Caching.CacheItemPriority.High, null);
                myCommand.Parameters.Add(
                   "@ApproveArticles", SqlDbType.Bit).Value = CheckBox1.Checked;
                HttpContext.Current.Cache.Insert("ApproveArticles", CheckBox1.Checked.ToString(), null, DateTime.Now.AddMonths(6), TimeSpan.Zero, System.Web.Caching.CacheItemPriority.High, null);
                myCommand.Parameters.Add(
                   "@Copyright", SqlDbType.Bit).Value = CheckBox2.Checked;
                HttpContext.Current.Cache.Insert("Copyright", CheckBox2.Checked.ToString(), null, DateTime.Now.AddMonths(6), TimeSpan.Zero, System.Web.Caching.CacheItemPriority.High, null);
                myCommand.CommandText = "UPDATE anm_Settings SET NumArticles=@NumArticles,ApproveArticles=@ApproveArticles,Copyright=@Copyright WHERE id=1";
                myConnection.Open();
                object accountNumber = myCommand.ExecuteScalar();
                Response.Redirect("homepage.aspx");
            }
        }
        catch (Exception ex)
        {
            Label4.Visible = true;
            Label4.Text = ex.Message;
        }
    }
}
