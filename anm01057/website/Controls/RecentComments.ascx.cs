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

public partial class Controls_RecentComments : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        anm_Utility ut = new anm_Utility();
        if (ut.GetSetting("LastComments") == "True")
            UpdatePanel1.Visible = true;
    }
    protected string RNA(string text)
    {
        anm_Utility ut = new anm_Utility();
        return ut.RemoveNonAlfaNumeric(text);
    }
    protected string PreviewComment(string text)
    {
        Regex exp = new Regex(@"\<blockquote\>(.+?)\</blockquote\>");
        string preview = exp.Replace(text, "");
        preview = Regex.Replace(preview, @"<(.|\n)*?>", string.Empty);
        if (preview.Length > 80)
            preview = preview.Substring(0, 81) + "...";
        return preview;
    }
    protected string GetLinkNews(string idc)
    {
        return Page.Request.ApplicationPath.ToString() + "/comment/" + idc + ".aspx#comment" + idc;
    }
    protected string ViewDate(string date)
    {
        DateTime d = Convert.ToDateTime(date);
        anm_Utility ut = new anm_Utility();
        return ut.GetRelativeTime(d);
    }
}
