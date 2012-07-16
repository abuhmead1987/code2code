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

public partial class Controls_AddAuthor : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.IsAuthenticated)
            {
                Page.Title = GetGlobalResourceObject("language", "Add") + " " + GetGlobalResourceObject("language", "Author");
                MembershipUser user = Membership.GetUser();
                anm_Utility ut = new anm_Utility();
                string role = ut.GetRole(user.UserName);
                if (role != "1")
                    Response.Redirect(Page.Request.Url.AbsolutePath.ToString() + "?p=Confirm&mes=" + GetGlobalResourceObject("language", "nopermission") + "");
            }
            else
                FormsAuthentication.RedirectToLoginPage();
        }
        DropDownList2.Items.Add(new ListItem("Admin", "1"));
        DropDownList2.Items.Add(new ListItem("Publisher", "2"));
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        anm_Utility ut = new anm_Utility();
        try { ut.AddAuthor(DropDownList1.Text.ToString(), DropDownList2.Text.ToString()); } catch { }
        Response.Redirect(Page.Request.Url.AbsolutePath.ToString() + "?p=AdminAuthors");
    }
}
