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
using System.Text.RegularExpressions;

public partial class Controls_RecentArticles : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        anm_Utility ut = new anm_Utility();
        if (ut.GetSetting("LastNews") == "True")
            UpdatePanel1.Visible = true;
    }
    protected string GetNcom(string idn, string c, string nc)
    {
        anm_Utility ut = new anm_Utility();
        string res = "";
        if (c == "True")
            res = GetGlobalResourceObject("language", "comments") + ": " + nc;
        return res;
    }
    protected string Category(string idc)
    {
        anm_Utility ut = new anm_Utility();
        return "<a href='" + Page.Request.ApplicationPath.ToString() + "/category" + idc + ".aspx'>" + ut.GetCategory(idc) + "</a>";
    }
    protected string GetLinkNews(string idnews, string title)
    {
        return Page.Request.ApplicationPath.ToString() + "/articles/" + idnews + "/" + RNA(title) + ".aspx";
    }
    protected string GetLinkComments(string idnews, string title)
    {
        anm_Utility ut = new anm_Utility();
        return Page.Request.ApplicationPath.ToString() + "/articles/" + idnews + "/" + RNA(title) + ".aspx#comments";
    }
    protected string RNA(string text)
    {
        anm_Utility ut = new anm_Utility();
        return ut.RemoveNonAlfaNumeric(text);
    }
    protected string PreviewArticle(string summary, string text)
    {
        string preview = "";
        if (summary.Length < 9)
            preview = Regex.Replace(text, @"<(.|\n)*?>", string.Empty);
        else
            preview = Regex.Replace(summary, @"<(.|\n)*?>", string.Empty);
        if (preview.Length > 100)
            preview = preview.Substring(0, 101) + "...";
        return preview;
    }
}
