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

public partial class Controls_Confirm : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string apath = anm_Utility.GetWebAppRoot();
        anm_Utility ut = new anm_Utility();
        Label1.Text = Request.QueryString["mes"];
        HLhome.NavigateUrl = apath + "/homepage.aspx";
        if (Request.QueryString["link"] != null)
        {
            HyperLink1.Text = "&lt;- " + GetGlobalResourceObject("language", "GoBack");
            HyperLink1.NavigateUrl = apath + "/articles/" + Request.QueryString["link"] + "/" + ut.RemoveNonAlfaNumeric(ut.GetTitleNews(Request.QueryString["link"].ToString())) + ".aspx";
        }
        else
            HyperLink1.Visible = false;
    }
}
