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

public partial class Controls_LoginMaster : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        anm_Utility ut = new anm_Utility();
        DateTime data = DateTime.Now;
        currentDate.Text = string.Format("{0}", data.ToString("f", System.Globalization.CultureInfo.CurrentCulture));
        if (LoginView2.FindControl("HLreg") == null)
        {
            HyperLink myp = (HyperLink)LoginView2.FindControl("Myp");
            myp.NavigateUrl = Page.Request.ApplicationPath.ToString() +"/MyProfile.aspx";
        }
        else
        {
            HyperLink hlreg = (HyperLink)LoginView2.FindControl("HLreg");
            hlreg.NavigateUrl = Page.Request.Url.AbsolutePath.ToString() + "?p=NewUser";
        }
    }
    protected void redirect(object sender, EventArgs e)
    {
        Response.Redirect(Page.Request.Url.AbsolutePath.ToString());
    }
    protected string AdminLink()
    {
        anm_Utility ut = new anm_Utility();
        MembershipUser user = Membership.GetUser();
        string link = "";
        if (user != null)
        {
            string role = ut.GetRole(user.UserName);
            if (role == "1" || role == "2")
            {
                link = "<a href='" + Page.Request.Url.AbsolutePath.ToString() + "?p=AdminArticles'>" + GetGlobalResourceObject("language", "AdminPage") + "</a>";
            }
        }
        return link;
    }
}
