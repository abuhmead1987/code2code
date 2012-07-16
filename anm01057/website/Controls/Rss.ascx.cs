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
using anm_utility;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Xml;
using System.Text;

public partial class Controls_Rss : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        anm_Utility ut = new anm_Utility();
        string siteurl = ut.GetSetting("SiteUrl");
        try
        {
            if (siteurl.Substring(0, 4) != "http")
                siteurl = "http://" + siteurl;
        }
        catch
        {
            siteurl = "http://" + siteurl;
        }
        string sitetitle = ut.GetSetting("SiteName") + " RSS";
        string idc = "";
        string idn = "";
        string titlenews = "";
        if (Request.QueryString["cat"] != null)
        {
            idc = Request.QueryString["cat"].ToString();
            sitetitle = ut.GetCategory(idc) + " RSS" + " - " + ut.GetSetting("SiteName");
        }
        if (Request.QueryString["news"] != null)
        {
            idn = Request.QueryString["news"].ToString();
            sitetitle = ut.GetTitleNews(idn) + " - Comment RSS" + " - " + ut.GetSetting("SiteName");
        }
        Response.Clear();
        Response.ContentType = "text/xml";

        XmlTextWriter RSSFeed = new XmlTextWriter(Response.OutputStream, Encoding.UTF8);

        RSSFeed.WriteStartDocument();

        RSSFeed.WriteStartElement("rss");
        RSSFeed.WriteAttributeString("version", "2.0");
        //RSSFeed.WriteAttributeString("xmlns:atom", "http://www.w3.org/2005/Atom");
        RSSFeed.WriteStartElement("channel");
        RSSFeed.WriteElementString("title", ut.FormatForXML(sitetitle));
        RSSFeed.WriteElementString("link", siteurl);

        string strConn = ConfigurationManager.ConnectionStrings["anmcs"].ToString();
        SqlConnection myConnection = new SqlConnection(strConn);
        SqlCommand myCommand = new SqlCommand("anm_GetRss", myConnection);
        if (idc != "")
        {
            myCommand = new SqlCommand("anm_GetRssByCat", myConnection);
            myCommand.Parameters.Add("@idcategory", SqlDbType.VarChar).Value = idc;
            RSSFeed.WriteElementString("description", sitetitle + ": " + ut.GetCategory(idc));
        }
        else if (idn != "")
        {
            myCommand = new SqlCommand("anm_GetRssComments", myConnection);
            myCommand.Parameters.Add("@idn", SqlDbType.VarChar).Value = idn;
            titlenews = ut.GetTitleNews(idn);
            RSSFeed.WriteElementString("description", sitetitle + ": " + titlenews);
        }
        else
            RSSFeed.WriteElementString("description", sitetitle);

        myCommand.CommandType = CommandType.StoredProcedure;
        myConnection.Open();
        SqlDataReader reader = myCommand.ExecuteReader();

        string description = "";
        if (idn != "")
        {
            while (reader.Read())
            {
                string idcom = reader["idcomment"].ToString();
                RSSFeed.WriteStartElement("item");
                RSSFeed.WriteElementString("title", titlenews);
                RSSFeed.WriteElementString("description", reader["comment"].ToString());
                RSSFeed.WriteElementString("link", siteurl + "/comment/" + idcom + "/articles/" + idn + "/" + ut.RemoveNonAlfaNumeric(titlenews) + ".aspx#comment" + idcom);
                RSSFeed.WriteElementString("pubDate", (Convert.ToDateTime(reader["date"].ToString())).ToString("r"));
                RSSFeed.WriteElementString("category", "Comment");
                RSSFeed.WriteElementString("guid", siteurl + "/comment/" + idcom + "/articles/" + idn + "/" + ut.RemoveNonAlfaNumeric(titlenews) + ".aspx#comment" + idcom);
                RSSFeed.WriteEndElement();
            }
        }
        else
        {
            while (reader.Read())
            {
                RSSFeed.WriteStartElement("item");
                RSSFeed.WriteElementString("title", reader["title"].ToString());
                description = reader["summary"].ToString();
                if (description.Length < 9)
                    description = reader["news"].ToString();
                RSSFeed.WriteElementString("description", description);
                RSSFeed.WriteElementString("link", siteurl + "/articles/" + reader["idnews"].ToString() + "/" + ut.RemoveNonAlfaNumeric(reader["title"].ToString()) + ".aspx");
                RSSFeed.WriteElementString("pubDate", (Convert.ToDateTime(reader["date"].ToString())).ToString("r"));
                RSSFeed.WriteElementString("category", ut.GetCategory(reader["idcategory"].ToString()));
                RSSFeed.WriteElementString("guid", siteurl + "/articles/" + reader["idnews"].ToString() + "/" + ut.RemoveNonAlfaNumeric(reader["title"].ToString()) + ".aspx");
                RSSFeed.WriteEndElement();
            }
        }
        myConnection.Close();
        /*
        RSSFeed.WriteStartElement("atom:link");
        RSSFeed.WriteAttributeString("href", siteurl + Page.Request.Url.AbsolutePath.ToString() + "?p=Rss");
        RSSFeed.WriteAttributeString("rel", "self");
        RSSFeed.WriteAttributeString("type", "application/rss+xml");
        RSSFeed.WriteEndElement();
        */        
        RSSFeed.WriteEndElement();
        RSSFeed.WriteEndElement();
        RSSFeed.WriteEndDocument();
        RSSFeed.Flush();
        RSSFeed.Close();
        Response.End();
    }
}
