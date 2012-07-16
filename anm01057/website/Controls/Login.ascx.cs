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

public partial class Controls_Login : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            anm_Utility ut = new anm_Utility();
            Login1.DestinationPageUrl = Page.Request.Url.AbsolutePath.ToString();
            HyperLink1.NavigateUrl = Page.Request.Url.AbsolutePath.ToString() + "?p=PasswordRecovery";
            HyperLink2.NavigateUrl = Page.Request.Url.AbsolutePath.ToString() + "?p=NewUser";
            Page.Title = ut.GetSetting("SiteName") + " - Login";
        }
    }
    protected void Login1_LoginError(object sender, EventArgs e)
    {
        anm_Utility ut = new anm_Utility();
        Login1.FailureText = ut.CheckLogin(Login1.UserName);
    }
}
