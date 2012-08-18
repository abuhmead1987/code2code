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

public partial class Controls_AdminAuthors : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.IsAuthenticated)
            {
                Page.Title = GetGlobalResourceObject("language", "Authors") + " ";
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
        Response.Redirect(Page.Request.Url.AbsolutePath.ToString() + "?p=AddAuthor");
    }
    protected string ViewRole(string idrole)
    {
        string role = "";
        if (idrole == "1")
            role = "admin";
        else
            role = "publisher";
        return role;
    }
    protected void GridView1_RowDeleting(Object sender, GridViewDeleteEventArgs e)
    {
        TableCell cell = GridView1.Rows[e.RowIndex].Cells[0];
        if (cell.Text == "admin" || cell.Text == "host")
        {
            e.Cancel = true;
            lblMessage.Text = GetGlobalResourceObject("language", "cannotremove") + " " + cell.Text;
        }
        else
            lblMessage.Text = cell.Text + " " + GetGlobalResourceObject("language", "removed");
        lblMessage.Visible = true;
    } 
}
