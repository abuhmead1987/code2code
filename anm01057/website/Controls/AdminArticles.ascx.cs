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

public partial class Controls_AdminArticles : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.IsAuthenticated)
            {
                Page.Title = GetGlobalResourceObject("language", "Articles") + " ";
                string path = Page.Request.Url.AbsolutePath.ToString();
                MembershipUser user = Membership.GetUser();
                anm_Utility ut = new anm_Utility();
                string role = ut.GetRole(user.UserName);
                if (role == "2")
                    Response.Redirect(path + "?p=AdminComments");
                else if (role != "1")
                    Response.Redirect(path + "?p=Confirm&mes=" + GetGlobalResourceObject("language", "nopermission") + "");
            }
            else
                FormsAuthentication.RedirectToLoginPage();
        }
    }
    protected void GridView1_RowDeleted(object sender, GridViewDeletedEventArgs e)
    {
        if (e.Exception != null)
        {
            Label1.Visible = true;
            e.ExceptionHandled = true;
            Label1.Text = GetGlobalResourceObject("language", "cannotdeleteart").ToString();
        }
        else
        {
            Label1.Visible = true;
            Label1.Text = GetGlobalResourceObject("language", "Article") + " " + GetGlobalResourceObject("language", "removed");
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect(Page.Request.Url.AbsolutePath.ToString() + "?p=AddArticle");
    }
    protected string RNA(string text)
    {
        anm_Utility ut = new anm_Utility();
        return ut.RemoveNonAlfaNumeric(text);
    }
    protected bool ViewLinkComm(string comments)
    {
        return (comments != "0");
    }
}
