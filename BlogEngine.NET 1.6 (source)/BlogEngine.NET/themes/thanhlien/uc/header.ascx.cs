using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class themes_thanhlien_uc_header : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.User.Identity.IsAuthenticated)
        {
            aLogin.InnerText = Resources.labels.logoff;
            aLogin.HRef = BlogEngine.Core.Utils.RelativeWebRoot + "login.aspx?logoff";
        }
        else
        {
            aLogin.HRef = BlogEngine.Core.Utils.RelativeWebRoot + "login.aspx";
            aLogin.InnerText = Resources.labels.login;
        }
    }
}
