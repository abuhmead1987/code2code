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

public partial class Controls_Tags : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.IsAuthenticated)
            {
                Page.Title = GetGlobalResourceObject("language", "Tags") + " ";
                string path = Page.Request.Url.AbsolutePath.ToString();
                MembershipUser user = Membership.GetUser();
                anm_Utility ut = new anm_Utility();
                string role = ut.GetRole(user.UserName);
                if (role != "1")
                    Response.Redirect(path + "?p=Confirm&mes=" + GetGlobalResourceObject("language", "nopermission") + "");
            }
            else
                FormsAuthentication.RedirectToLoginPage();
        }
    }
    protected void BtnAddTag_Click(object sender, EventArgs e)
    {
        try
        {
            if (TBtag.Text != GetGlobalResourceObject("language", "inserttaghere"))
            {
                string strConn = ConfigurationManager.ConnectionStrings["anmcs"].ToString();
                SqlConnection conn = new SqlConnection(strConn);
                SqlCommand command = new SqlCommand("anm_InsertTag", conn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@tag", SqlDbType.NVarChar).Value = TBtag.Text;
                command.Parameters.Add("@size", SqlDbType.NVarChar).Value = TBsize.Text;
                conn.Open();
                command.ExecuteNonQuery();
                conn.Close();
                BtnAddTag.Visible = TBtag.Visible = TBsize.Visible = lblTag.Visible = lblSize.Visible = false;
                Response.Redirect(Page.Request.Url.AbsolutePath.ToString() + "?p=Tags");
            }
        }
        catch
        {
            Response.Redirect(Page.Request.Url.AbsolutePath.ToString() + "?p=Tags");
        }
    }
    protected void LBadd_Click(object sender, EventArgs e)
    {
        BtnAddTag.Visible = TBtag.Visible = TBsize.Visible = lblTag.Visible = lblSize.Visible = true;
    }
}