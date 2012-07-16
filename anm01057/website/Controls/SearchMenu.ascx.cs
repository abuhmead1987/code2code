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

public partial class Controls_SearchMenu : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        anm_Utility ut = new anm_Utility();
        PnlSearch.Visible = Convert.ToBoolean(ut.GetSetting("SearchMenu"));
        txtSearch.Attributes["onclick"] = "this.value=''";
        txtSearch.Attributes.Add("onkeypress", "javascript:if (event.keyCode == 13) __doPostBack('" + btnSearch.UniqueID + "','')");
    }
    protected void BtnSearchClick(object sender, EventArgs e)
    {
        if (txtSearch.Text != "" && txtSearch.Text != GetGlobalResourceObject("language", "searchsite").ToString())
        {
            anm_Utility ut = new anm_Utility();
            string value = txtSearch.Text.ToString().Replace("&", "&amp;");
            Response.Redirect(anm_Utility.GetWebAppRoot() + "/search/" + ut.UrlEncode(value.Trim()) + ".aspx");
        }
    }
}
