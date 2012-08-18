using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using anm_utility;

public partial class Controls_Validators : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        anm_Utility ut = new anm_Utility();
        Hlvalidrss.NavigateUrl = "http://feed2.w3.org/check.cgi?url=" + ut.GetSetting("SiteUrl") + "/subscribe.aspx";
        if (ut.GetSetting("Validator") != "False")
            PnlValidators.Visible = true;
    }
}