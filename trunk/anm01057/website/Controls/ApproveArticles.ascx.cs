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

public partial class Controls_ApproveArticles : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.IsAuthenticated)
            {
                Page.Title = GetGlobalResourceObject("language", "Approve") + " " + GetGlobalResourceObject("language", "Articles");
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
    protected void Approve_Command(object sender, CommandEventArgs e)
    {
        string id = (string)e.CommandArgument;
        anm_Utility ut = new anm_Utility();
        ut.ApproveNews(id);
        Response.Redirect(Page.Request.Url.AbsolutePath.ToString() + "?p=ApproveArticles");
    }
    protected string RNA(string text)
    {
        anm_Utility ut = new anm_Utility();
        return ut.RemoveNonAlfaNumeric(text);
    }
}
