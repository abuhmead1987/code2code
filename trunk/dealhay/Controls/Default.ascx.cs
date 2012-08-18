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
using System.Data.SqlClient;

public partial class Controls_Default : System.Web.UI.UserControl
{
    System.Diagnostics.Stopwatch sw = System.Diagnostics.Stopwatch.StartNew();
    protected void Page_Load(object sender, EventArgs e)
    {
        anm_Utility ut = new anm_Utility();
        try
        {
            if (ut.IsInstalled())
            {
                if (ut.GetSetting("Version") != "1.5")
                    Response.Redirect("~/install.aspx");
            }
            else
                Response.Redirect("~/install.aspx");
        }
        catch (Exception ex)
        {
            throw ex;
        }
        string path = Page.Request.Url.AbsolutePath.ToString();
        if (Request.QueryString["p"] == null)
            Response.Redirect("homepage.aspx");
        Control anmUserControl = LoadControl(Request.QueryString["p"] + ".ascx");
        PlaceHolder1.Controls.Add(anmUserControl);
        
        //ut.UpdateUser();
        
        //body.Style.Add("background-color", "#" + ut.GetSetting("BGColor"));
        //body.Style.Add("background-image", "images/" + ut.GetSetting("BGImage"));
        //body.Style.Add("width", ut.GetSetting("Width"));
        
        anm_.Style.Add("background-color", "#" + ut.GetSetting("BGColor"));
        //anm_.Style.Add("background-image", "images/" + ut.GetSetting("BGImage"));
        anm_.Style.Add("width", ut.GetSetting("Width"));

        string[] templateinfo = ut.GetTemplate(ut.GetSetting("template"));
        HLTemp.Text = templateinfo[1].ToString();
        string linkauthor = (templateinfo[2].ToString()).Replace("http://", "");
        HLTemp.NavigateUrl = "http://" + linkauthor;

        if (templateinfo[1].ToString() == "")
            lblTemp.Visible = false;
        try
        {
            Page.Header.Controls.Add(ut.InitializeSite(HLref, ut.GetSetting("Template")));
        }
        catch
        {
        }
        Hlrss.NavigateUrl = rssbutton.NavigateUrl = anm_Utility.GetWebAppRoot() + "/subscribe.aspx";
        Hlcontact.NavigateUrl = anm_Utility.GetWebAppRoot() + "/contact_us.aspx";
        HtmlLink myrss = new HtmlLink();
        myrss.Href = "subscribe.aspx";
        myrss.Attributes.Add("type", "application/rss+xml");
        myrss.Attributes.Add("rel", "alternate");
        myrss.Attributes.Add("title", ut.GetSetting("SiteName") + " RSS");
        Page.Header.Controls.Add(myrss);
        HtmlMeta robots = new HtmlMeta();
        robots.Name = "robots";
        robots.Content = "index, follow";
        Page.Header.Controls.Add(robots);
        HtmlMeta metag = new HtmlMeta();
        metag.Name = "Generator";
        metag.Content = "AllNewsManager.net";
        Page.Header.Controls.Add(metag);

    }
    protected override void Render(HtmlTextWriter writer)
    {
        float _seconds = ((float)sw.ElapsedMilliseconds / 1000);
        this.lblTimeP.Text = GetGlobalResourceObject("language", "Pagegenerated") + " <strong>" + _seconds.ToString() + "</strong> " + GetGlobalResourceObject("language", "seconds");
        base.Render(writer);
    }
    protected string FooterMenu()
    {
        anm_Utility ut = new anm_Utility();
        return ut.GetFooterMenu();
    }
}
