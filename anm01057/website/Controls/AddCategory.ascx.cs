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

public partial class Controls_AddCategory : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.IsAuthenticated)
            {
                Page.Title = GetGlobalResourceObject("language", "Add") + " " + GetGlobalResourceObject("language", "Category");
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
        anm_Utility ut = new anm_Utility();
        if (CheckBox1.Checked)
        {
            int idfather = Convert.ToInt32(DropDownList1.SelectedValue.ToString());
            string idrootcat = ut.GetIdcRoot(idfather.ToString());
            if (idrootcat == "0" || idrootcat == null || idrootcat == "")
                idrootcat = idfather.ToString();
            ut.AddCategory(TextBox1.Text.ToString(), idfather, ut.GetOrderCat(idfather) + 1, idrootcat);
        }
        else
            ut.AddCategory(TextBox1.Text.ToString(), 0, ut.GetOrderCat(0) + 1, "0");
        Response.Redirect(Page.Request.Url.AbsolutePath.ToString() + "?p=AdminCategories");
    }
    protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
    {
        Label2.Visible = DropDownList1.Visible = CheckBox1.Checked;
    }
}
