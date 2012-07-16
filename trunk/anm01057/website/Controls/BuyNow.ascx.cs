using System;
using System.Web;
using System.Web.Security;
using System.Web.UI;

public partial class Controls_BuyNow : UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!HttpContext.Current.Request.IsAuthenticated)
        {
            FormsAuthentication.RedirectToLoginPage();
        }

        string newid = Request.QueryString["news"].ToString();
        Response.Write(newid);
    }
}