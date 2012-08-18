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

public partial class Controls_AdminTemplates : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.IsAuthenticated)
            {
                Page.Title = GetGlobalResourceObject("language", "Template") + " " + GetGlobalResourceObject("language", "Settings");
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
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect(Page.Request.Url.AbsolutePath.ToString() + "?p=AddTemplate");
    }
    protected void ConfirmTemplate(object sender, EventArgs e)
    {
        Label2.Text = GridView1.SelectedRow.Cells[1].Text;
        Label1.Text = GetGlobalResourceObject("language", "confirmtemplate").ToString();
        Label1.Visible = Button2.Visible = true;
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        try
        {
                string strConn = ConfigurationManager.ConnectionStrings["anmcs"].ToString();
                SqlConnection myConnection = new SqlConnection(strConn);
                SqlCommand myCommand = new SqlCommand();
                myCommand.Connection = myConnection;

                myCommand.Parameters.Add(
                   "@Template", SqlDbType.VarChar).Value = Label2.Text;
                HttpContext.Current.Cache.Remove("TemplateName");
                Cache.Insert("Template", Label2.Text.ToString(), null, DateTime.Now.AddMonths(6), TimeSpan.Zero, System.Web.Caching.CacheItemPriority.High, null);
                myCommand.CommandText = "UPDATE anm_Settings SET Template=@Template WHERE id=1";
                myConnection.Open();
                object accountNumber = myCommand.ExecuteScalar();
                Response.Redirect("homepage.aspx");
        }
        catch (Exception ex)
        {
            Label1.Visible = true;
            Label1.Text = ex.Message;
        }
    }
}
