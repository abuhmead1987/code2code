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

public partial class Controls_error : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Hlcontact.NavigateUrl = anm_Utility.GetWebAppRoot() + "/Contact_Us.aspx";
    }

}
