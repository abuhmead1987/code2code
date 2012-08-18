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

public partial class Controls_Activate : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            anm_Utility ut = new anm_Utility();
            if (ut.ActivateUser(Request.QueryString["ID"]))
            {
                ActivationStatusLabel.Text = GetGlobalResourceObject("language", "Activated").ToString();
                LoginStatus1.Visible = true;
            }
            else
            {
            }
        }
    }
}
