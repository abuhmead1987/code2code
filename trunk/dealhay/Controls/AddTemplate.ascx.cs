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

public partial class Controls_AddTemplate : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.IsAuthenticated)
            {
                Page.Title = GetGlobalResourceObject("language", "Add") + " " + GetGlobalResourceObject("language", "Template");
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
        int id = 0;
        try
        {
            string strConn = ConfigurationManager.ConnectionStrings["anmcs"].ToString();
            SqlConnection myConnection = new SqlConnection(strConn);
            SqlCommand myCommand = new SqlCommand();
            myCommand.Connection = myConnection;

            myCommand.CommandText = "SELECT TOP 1 * from anm_Templates ORDER BY Template DESC";
            myConnection.Open();

            SqlDataReader reader = myCommand.ExecuteReader();
            while (reader.Read())
            {
                id = Convert.ToInt32(reader["Template"].ToString());
            }
            myConnection.Close();
            string idt = (id + 1).ToString();
            FileUpload1.SaveAs(Server.MapPath("~\\css\\css") + idt + ".css");
            anm_Utility ut = new anm_Utility();
            ut.AddTemplate(TextBox1.Text.ToString(), TextBox2.Text.ToString(), TextBox3.Text.ToString());
        }
        catch (Exception ex)
        {
            lblerror.Text = ex.Message;
            lblerror.Visible = true;
        }
        Response.Redirect(Page.Request.Url.AbsolutePath.ToString() + "?p=AdminTemplates");
    }
}
