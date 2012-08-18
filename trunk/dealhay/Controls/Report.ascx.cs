using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using anm_utility;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Security;

public partial class Controls_Report : System.Web.UI.UserControl
{
    string apath = anm_Utility.GetWebAppRoot();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Page.Title = GetGlobalResourceObject("language", "Report").ToString() + " comment " + Request.QueryString["idc"];
            anm_Utility ut = new anm_Utility();
            Label1.Text = GetGlobalResourceObject("language", "Report").ToString() + ":";
            Label2.Text = GetGlobalResourceObject("language", "Reason").ToString() + ":";
            if (Request.IsAuthenticated)
                Panelcomm.Visible = false;
            else
            {
                HyperLink4.NavigateUrl = apath + "/default.aspx?p=NewUser";
                HyperLink5.NavigateUrl = apath + "/default.aspx?p=Login";
                Panelcomm.Visible = true;
                Button1.Visible = false;
            }
        }
    }
    protected string ViewDate(string date)
    {
        DateTime d = Convert.ToDateTime(date);
        anm_Utility ut = new anm_Utility();
        return ut.GetRelativeTime(d);
    }
    protected string GetAvatar(string username)
    {
        string pathToCheck = Server.MapPath("~\\images\\Avatars\\") + username + ".jpg";
        if (System.IO.File.Exists(pathToCheck))
            return apath + "/images/Avatars/" + username + ".jpg";
        else
            return apath + "/images/Avatars/Anonymous.jpg";
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        anm_Utility ut = new anm_Utility();
        MembershipUser user = Membership.GetUser();
        string strConn = ConfigurationManager.ConnectionStrings["anmcs"].ToString();
        SqlConnection conn = new SqlConnection(strConn);
        SqlCommand command = new SqlCommand("anm_InsertReport", conn);
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.Add("@username", SqlDbType.NVarChar).Value = user.UserName;
        command.Parameters.Add("@idreported", SqlDbType.NVarChar).Value = Request.QueryString["idc"];
        command.Parameters.Add("@reason", SqlDbType.NVarChar).Value = TextBox1.Text;
        command.Parameters.Add("@date", SqlDbType.DateTime).Value = DateTime.Now;
        conn.Open();
        int rows = command.ExecuteNonQuery();
        conn.Close();
        string idn = Request.QueryString["idn"];
        Response.Redirect(apath + "?p=confirm&mes=" + GetGlobalResourceObject("language", "Messagesent") + "&link=" + idn);
    }
}