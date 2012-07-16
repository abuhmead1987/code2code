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

public partial class Controls_Header : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        anm_Utility ut = new anm_Utility();
        string banner = ut.GetSetting("Banner");
        //HLtitle.ToolTip = ut.GetSetting("SiteName") + " - HomePage";
        ImgTitle.AlternateText = ut.GetSetting("SiteName") + " - HomePage";
        if (banner != "")
            ImgTitle.ImageUrl = anm_Utility.GetWebAppRoot() + "/images/" + banner;
        else
            HLtitle.Text = ut.GetSetting("SiteName");
        //header.Style.Add("background-color", "#" + ut.GetSetting("HBGColor"));
        HLtitle.NavigateUrl = anm_Utility.GetWebAppRoot() + "/homepage.aspx";
    }
    protected string ViewMenu()
    {
        anm_Utility ut = new anm_Utility();
        string menu = "";
        if (ut.GetSetting("TopMenu") == "True")
            menu = ut.GetMenu();
        return menu;
    }
}
