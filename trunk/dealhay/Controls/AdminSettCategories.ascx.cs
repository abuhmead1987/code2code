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

public partial class Controls_AdminSettCategories : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.IsAuthenticated)
            {
                Page.Title = GetGlobalResourceObject("language", "Category") + " " + GetGlobalResourceObject("language", "Settings");
                MembershipUser user = Membership.GetUser();
                anm_Utility ut = new anm_Utility();
                string role = ut.GetRole(user.UserName);
                if (role != "1")
                    Response.Redirect(Page.Request.Url.AbsolutePath.ToString() + "?p=Confirm&mes=" + GetGlobalResourceObject("language", "nopermission") + "");
                if (ut.GetSetting("TopMenu") != "")
                    CheckBox1.Checked = Convert.ToBoolean(ut.GetSetting("TopMenu"));
                if (ut.GetSetting("SideMenu") != "")
                    CheckBox3.Checked = Convert.ToBoolean(ut.GetSetting("SideMenu"));
            }
            else
                FormsAuthentication.RedirectToLoginPage();
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            string strConn = ConfigurationManager.ConnectionStrings["anmcs"].ToString();
            SqlConnection myConnection = new SqlConnection(strConn);
            SqlCommand myCommand = new SqlCommand();
            myCommand.Connection = myConnection;

            myCommand.Parameters.Add(
               "@TopMenu", SqlDbType.Bit).Value = CheckBox1.Checked;
            HttpContext.Current.Cache.Insert("TopMenu", CheckBox1.Checked.ToString(), null, DateTime.Now.AddMonths(6), TimeSpan.Zero, System.Web.Caching.CacheItemPriority.High, null);
            myCommand.Parameters.Add(
               "@SideMenu", SqlDbType.Bit).Value = CheckBox3.Checked;
            HttpContext.Current.Cache.Insert("SideMenu", CheckBox3.Checked.ToString(), null, DateTime.Now.AddMonths(6), TimeSpan.Zero, System.Web.Caching.CacheItemPriority.High, null);
            myCommand.CommandText = "UPDATE anm_Settings SET TopMenu=@TopMenu,SideMenu=@SideMenu WHERE id=1";
            myConnection.Open();
            myCommand.ExecuteScalar();
            Response.Redirect("homepage.aspx");
        }
        catch (Exception ex)
        {
            Label4.Visible = true;
            Label4.Text = ex.Message;
        }
    }
}
