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

public partial class Controls_AllNews : System.Web.UI.UserControl
{
    string apath = anm_Utility.GetWebAppRoot();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            anm_Utility ut = new anm_Utility();
            if (Request.QueryString["tag"] == null)
            {
                if (Request.QueryString["author"] == null)
                {
                    if (Request.QueryString["category"] != null)
                    {
                        string category = Request.QueryString["category"];
                        if (Request.QueryString["year"] == null)
                        {
                            GridView2.DataSourceID = "SqlDataSource3";
                            GridView3.DataSourceID = "SqlDataSource5";
                            GridView4.DataSourceID = "SqlDataSource7";
                            Page.Title = ut.GetCategory(Request.QueryString["category"]) + " - " + ut.GetSetting("SiteName");
                        }
                        else
                        {
                            int year = Convert.ToInt32(Request.QueryString["year"].ToString());
                            int categ = Convert.ToInt32(category);
                            int month = Convert.ToInt32(Request.QueryString["month"].ToString());
                            if (ut.GetNumberArticles(month, year, categ) == 0)
                            {
                                int i = 1;
                                while (i < 13 && ut.GetNumberArticles(i, year, categ) == 0)
                                {
                                    i++;
                                }
                                if (i != 13)
                                    Response.Redirect(apath + "/month_" + i + "/year_" + year + "/category" + categ + ".aspx");
                            }
                            if (ut.GetNumberArticles(1, year, categ)!=0)
                                ddMonth.Items.Add(new ListItem(GetGlobalResourceObject("language", "January").ToString() + " (" + ut.GetNumberArticles(1, year, categ) + ")", "1"));
                            if (ut.GetNumberArticles(2, year, categ) != 0)
                                ddMonth.Items.Add(new ListItem(GetGlobalResourceObject("language", "February").ToString() + " (" + ut.GetNumberArticles(2, year, categ) + ")", "2"));
                            if (ut.GetNumberArticles(3, year, categ) != 0)
                                ddMonth.Items.Add(new ListItem(GetGlobalResourceObject("language", "March").ToString() + " (" + ut.GetNumberArticles(3, year, categ) + ")", "3"));
                            if (ut.GetNumberArticles(4, year, categ) != 0)
                                ddMonth.Items.Add(new ListItem(GetGlobalResourceObject("language", "April").ToString() + " (" + ut.GetNumberArticles(4, year, categ) + ")", "4"));
                            if (ut.GetNumberArticles(5, year, categ) != 0)
                                ddMonth.Items.Add(new ListItem(GetGlobalResourceObject("language", "May").ToString() + " (" + ut.GetNumberArticles(5, year, categ) + ")", "5"));
                            if (ut.GetNumberArticles(6, year, categ) != 0)
                                ddMonth.Items.Add(new ListItem(GetGlobalResourceObject("language", "June").ToString() + " (" + ut.GetNumberArticles(6, year, categ) + ")", "6"));
                            if (ut.GetNumberArticles(7, year, categ) != 0)
                                ddMonth.Items.Add(new ListItem(GetGlobalResourceObject("language", "July").ToString() + " (" + ut.GetNumberArticles(7, year, categ) + ")", "7"));
                            if (ut.GetNumberArticles(8, year, categ) != 0)
                                ddMonth.Items.Add(new ListItem(GetGlobalResourceObject("language", "August").ToString() + " (" + ut.GetNumberArticles(8, year, categ) + ")", "8"));
                            if (ut.GetNumberArticles(9, year, categ) != 0)
                                ddMonth.Items.Add(new ListItem(GetGlobalResourceObject("language", "September").ToString() + "(" + ut.GetNumberArticles(9, year, categ) + ")", "9"));
                            if (ut.GetNumberArticles(10, year, categ) != 0)
                                ddMonth.Items.Add(new ListItem(GetGlobalResourceObject("language", "October").ToString() + " (" + ut.GetNumberArticles(10, year, categ) + ")", "10"));
                            if (ut.GetNumberArticles(11, year, categ) != 0)
                                ddMonth.Items.Add(new ListItem(GetGlobalResourceObject("language", "November").ToString() + " (" + ut.GetNumberArticles(11, year, categ) + ")", "11"));
                            if (ut.GetNumberArticles(12, year, categ) != 0)
                                ddMonth.Items.Add(new ListItem(GetGlobalResourceObject("language", "December").ToString() + " (" + ut.GetNumberArticles(12, year, categ) + ")", "12"));
                            int archiveYear = Convert.ToInt32(ut.GetSetting("Year").ToString());
                            int currentYear = DateTime.Now.Year;
                            while (archiveYear <= currentYear)
                            {
                                ddYear.Items.Add(new ListItem(archiveYear.ToString(), archiveYear.ToString()));
                                archiveYear++;
                            }
                            ddYear.Visible = lblYear.Visible = lblMonth.Visible = ddMonth.Visible = true;
                            ddYear.SelectedValue = Request.QueryString["year"].ToString();
                            ddMonth.SelectedValue = Request.QueryString["month"].ToString();
                            if (Request.QueryString["month"] != null)
                                Page.Title = ut.GetCategory(ut.GetIdFather(category)) + " - " + ut.GetCategory(category) + " - " + GetGlobalResourceObject("language", "Year") + ": " + Request.QueryString["year"].ToString() + " - " + GetGlobalResourceObject("language", "Month") + ": " + ut.SetLongMonth(Convert.ToInt32(Request.QueryString["month"].ToString())) + " - " + ut.GetSetting("SiteName");
                            else
                                Page.Title = ut.GetCategory(ut.GetIdFather(category)) + " - " + ut.GetCategory(category) + " - " + GetGlobalResourceObject("language", "Year") + ": " + Request.QueryString["year"].ToString() + " - " + ut.GetSetting("SiteName");
                            GridView2.DataSourceID = "SqlDataSource15";
                            GridView3.DataSourceID = "SqlDataSource11";
                            GridView4.DataSourceID = "SqlDataSource13";
                        }
                    }
                    else
                    {
                        if (Request.QueryString["year"] == null)
                        {
                            GridView2.DataSourceID = "SqlDataSource4";
                            GridView3.DataSourceID = "SqlDataSource6";
                            GridView4.DataSourceID = "SqlDataSource8";
                            Page.Title = ut.GetSetting("SiteName");
                        }
                        else
                        {
                            int year = Convert.ToInt32(Request.QueryString["year"].ToString());
                            int month = Convert.ToInt32(Request.QueryString["month"].ToString());
                            if (ut.GetNumberArticles(month, year) == 0)
                            {
                                int i = 1;
                                while (i < 13 && ut.GetNumberArticles(i, year) == 0)
                                {
                                    i++;
                                }
                                if (i != 13)
                                    Response.Redirect(apath + "/year_" + year + "/month_" + i + ".aspx");
                            }
                            if (ut.GetNumberArticles(1, year) != 0)
                                ddMonth.Items.Add(new ListItem(GetGlobalResourceObject("language", "January").ToString() + " (" + ut.GetNumberArticles(1, year) + ")", "1"));
                            if (ut.GetNumberArticles(2, year) != 0)
                                ddMonth.Items.Add(new ListItem(GetGlobalResourceObject("language", "February").ToString() + " (" + ut.GetNumberArticles(2, year) + ")", "2"));
                            if (ut.GetNumberArticles(3, year) != 0)
                                ddMonth.Items.Add(new ListItem(GetGlobalResourceObject("language", "March").ToString() + " (" + ut.GetNumberArticles(3, year) + ")", "3"));
                            if (ut.GetNumberArticles(4, year) != 0)
                                ddMonth.Items.Add(new ListItem(GetGlobalResourceObject("language", "April").ToString() + " (" + ut.GetNumberArticles(4, year) + ")", "4"));
                            if (ut.GetNumberArticles(5, year) != 0)
                                ddMonth.Items.Add(new ListItem(GetGlobalResourceObject("language", "May").ToString() + " (" + ut.GetNumberArticles(5, year) + ")", "5"));
                            if (ut.GetNumberArticles(6, year) != 0)
                                ddMonth.Items.Add(new ListItem(GetGlobalResourceObject("language", "June").ToString() + " (" + ut.GetNumberArticles(6, year) + ")", "6"));
                            if (ut.GetNumberArticles(7, year) != 0)
                                ddMonth.Items.Add(new ListItem(GetGlobalResourceObject("language", "July").ToString() + " (" + ut.GetNumberArticles(7, year) + ")", "7"));
                            if (ut.GetNumberArticles(8, year) != 0)
                                ddMonth.Items.Add(new ListItem(GetGlobalResourceObject("language", "August").ToString() + " (" + ut.GetNumberArticles(8, year) + ")", "8"));
                            if (ut.GetNumberArticles(9, year) != 0)
                                ddMonth.Items.Add(new ListItem(GetGlobalResourceObject("language", "September").ToString() + " (" + ut.GetNumberArticles(9, year) + ")", "9"));
                            if (ut.GetNumberArticles(10, year) != 0)
                                ddMonth.Items.Add(new ListItem(GetGlobalResourceObject("language", "October").ToString() + " (" + ut.GetNumberArticles(10, year) + ")", "10"));
                            if (ut.GetNumberArticles(11, year) != 0)
                                ddMonth.Items.Add(new ListItem(GetGlobalResourceObject("language", "November").ToString() + " (" + ut.GetNumberArticles(11, year) + ")", "11"));
                            if (ut.GetNumberArticles(12, year) != 0)
                                ddMonth.Items.Add(new ListItem(GetGlobalResourceObject("language", "December").ToString() + " (" + ut.GetNumberArticles(12, year) + ")", "12"));
                            int archiveYear = Convert.ToInt32(ut.GetSetting("Year").ToString());
                            int currentYear = DateTime.Now.Year;
                            while (archiveYear <= currentYear)
                            {
                                ddYear.Items.Add(new ListItem(archiveYear.ToString(), archiveYear.ToString()));
                                archiveYear++;
                            }
                            ddYear.Visible = lblYear.Visible = lblMonth.Visible = ddMonth.Visible = true;
                            ddYear.SelectedValue = Request.QueryString["year"].ToString();
                            ddMonth.SelectedValue = Request.QueryString["month"].ToString();
                            if (Request.QueryString["month"] != null)
                                Page.Title = GetGlobalResourceObject("language", "Year") + ": " + Request.QueryString["year"].ToString() + " - " + GetGlobalResourceObject("language", "Month") + ": " + ut.SetLongMonth(Convert.ToInt32(Request.QueryString["month"].ToString())) + " - " + ut.GetSetting("SiteName");
                            else
                                Page.Title = GetGlobalResourceObject("language", "Year") + ": " + Request.QueryString["year"].ToString() + " - " + ut.GetSetting("SiteName");

                            GridView2.DataSourceID = "SqlDataSource16";
                            GridView3.DataSourceID = "SqlDataSource12";
                            GridView4.DataSourceID = "SqlDataSource14";
                        }
                    }
                }
                else
                {
                    string value = ut.UrlDecode(Request.QueryString["author"].ToString());
                    Page.Title = GetGlobalResourceObject("language", "PostedByAllArticles") + " " + value + " - " + ut.GetSetting("SiteName");
                    lblauthor.Text = GetGlobalResourceObject("language", "PostedByAllArticles") + " <b>" + value + "</b>:";
                    lblauthor.Font.Size = 16;
                }
            }
            else
            {
                string text = ut.UrlDecode(Request.QueryString["tag"].ToString());
                string value = text.Replace("[", "[[]");
                value = value.Replace("%", "[%]");
                value = value.Replace("_", "[_]");
                Page.Title = GetGlobalResourceObject("language", "RelatedToAllArticles") + " " + value + " - " + ut.GetSetting("SiteName");
                lblauthor.Text = GetGlobalResourceObject("language", "RelatedToAllArticles") + " <b>" + text + "</b>:";
                lblauthor.Font.Size = 16;
            }
            if (Request.QueryString["page"] != null)
                Page.Title = Page.Title + " - " + GetGlobalResourceObject("language", "Page") + ": " + Request.QueryString["page"];

            HtmlMeta keywords = new HtmlMeta();
            keywords.Name = "description";
            keywords.Content = Page.Title;
            Page.Header.Controls.Add(keywords);
            if (Request.QueryString["category"] != null & Request.QueryString["month"] != null)
                HLContentArchive.NavigateUrl = apath + "/archive/month_" + Request.QueryString["month"] + "/year_" + Request.QueryString["year"] + "/category" + Request.QueryString["category"] + ".aspx";
            else if (Request.QueryString["category"] != null)
                HLContentArchive.NavigateUrl = apath + "/archive/month_" + DateTime.Now.Month + "/year_" + DateTime.Now.Year + "/category" + Request.QueryString["category"] + ".aspx";
            else if (Request.QueryString["month"] != null)
                HLContentArchive.NavigateUrl = apath + "/archive/year_" + Request.QueryString["year"] + "/month_" + Request.QueryString["month"] + ".aspx";
            else
                HLContentArchive.NavigateUrl = apath + "/archive/year_" + DateTime.Now.Year + "/month_" + DateTime.Now.Month + ".aspx";
        }
    }
    protected void ddYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Request.QueryString["page"] != null)
        {
            if (Request.QueryString["category"] != null)
                Response.Redirect(apath + "/month_" + Request.QueryString["month"].ToString() + "/year_" + ddYear.SelectedValue.ToString() + "/category" + Request.QueryString["category"].ToString() + ".aspx");
            else
                Response.Redirect(apath + "/year_" + ddYear.SelectedValue.ToString() + "/month_" + Request.QueryString["month"].ToString() + ".aspx");
        }
        else
        {
            if (Request.QueryString["category"] != null)
                Response.Redirect(apath + "/month_" + Request.QueryString["month"].ToString() + "/year_" + ddYear.SelectedValue.ToString() + "/category" + Request.QueryString["category"].ToString() + ".aspx");
            else
                Response.Redirect(apath + "/year_" + ddYear.SelectedValue.ToString() + "/month_" + Request.QueryString["month"].ToString() + ".aspx");
        }
    }
    protected void ddMonth_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Request.QueryString["category"] != null)
            Response.Redirect(apath + "/month_" + ddMonth.SelectedValue.ToString() + "/year_" + Request.QueryString["year"].ToString() + "/category" + Request.QueryString["category"].ToString() + ".aspx");
        else
            Response.Redirect(apath + "/year_" + Request.QueryString["year"].ToString() + "/month_" + ddMonth.SelectedValue.ToString() + ".aspx");
    }
    protected string ShowImage(string img)
    {
        if (img != "")
            return "<img src='" + apath + "/images/" + img + "' alt='" + GetGlobalResourceObject("language", "fullsize") + "' class='right imageanm' width='" + SetImageWidth() + "px' />";
        else
            return "";
    }
    protected string ShowImage2(string img)
    {
        if (ViewImage(img))
            return "<img src='" + apath + "/images/" + img + "' alt='" + GetGlobalResourceObject("language", "fullsize") + "' class='right imageanm' width='99%' />";
        else
            return "";
    }
    protected bool ViewImage(string img)
    {
        return (img != "");
    }
    protected int SetImageWidth()
    {
        anm_Utility ut = new anm_Utility();
        if (ut.GetSetting("ArtImageWidth") != "")
            return Convert.ToInt32(ut.GetSetting("ArtImageWidth"));
        else
            return 200;
    }
    protected string ViewNews(String s, String n)
    {
        if (s.Length < 9)
            return n;
        else
            return s;
    }
    protected string PagedArticles()
    {
        string oldent = GetGlobalResourceObject("language", "OlderEntries").ToString();
        string newent = GetGlobalResourceObject("language", "NewerEntries").ToString();
        string auth = null;
        string tags = null;
        string category = null;
        string year = null;
        string month = null;
        string result = "";
        string spname = "";
        anm_Utility ut = new anm_Utility();
        string strConn = ConfigurationManager.ConnectionStrings["anmcs"].ToString();
        SqlConnection myConnection = new SqlConnection(strConn);
        if (Request.QueryString["year"] != null)
        {
            year = Request.QueryString["year"];
            month = Request.QueryString["month"];
        }
        if (Request.QueryString["tag"] == null)
        {
            if (Request.QueryString["author"] == null)
            {
                if (Request.QueryString["category"] != null)
                {
                    category = Request.QueryString["category"];
                    if (year == null)
                    {
                        spname = "anm_showAllNewsByCatPaged";
                    }
                    else
                        spname = "anm_showAllNewsByCatDatePaged";
                }
                else
                {
                    if (year == null)
                        spname = "anm_showAllNewsPaged";
                    else
                        spname = "anm_showAllNewsByDatePaged";
                }
            }
            else
            {
                auth = Request.QueryString["author"];
                spname = "anm_getNewsByAuthorPaged";
            }
        }
        else
        {
            tags = Request.QueryString["tag"];
            spname = "anm_getNewsByTagPaged";
        }
        int maximumRows = 15;
        int numarticles = 0;
        if (tags == null)
        {
            if (auth == null)
            {
                if (category != null)
                {
                    if (year != null)
                        numarticles = ut.GetNumberArticle(Convert.ToInt32(month), Convert.ToInt32(year), Convert.ToInt32(category));
                    else
                        numarticles = ut.GetNumberArticles(Convert.ToInt32(category));
                }
                else
                    if (year != null)
                        numarticles = ut.GetNumberArticle(Convert.ToInt32(month), Convert.ToInt32(year));
                    else
                        numarticles = ut.GetNumberArticles();
            }
            else
            {
                numarticles = ut.GetNumberArticles(ut.UrlDecode(auth));
            }
        }
        else
        {
            numarticles = ut.GetNumberArticle(ut.UrlDecode(tags));
        }
        if (ut.GetSetting("NumArticles") != "")
            maximumRows = Convert.ToInt32(ut.GetSetting("NumArticles"));
        int maxpage = (numarticles / maximumRows) + 1;
        if (numarticles % maximumRows == 0)
            maxpage = numarticles / maximumRows;

        SqlCommand myCommand = new SqlCommand(spname, myConnection);
        myCommand.CommandType = CommandType.StoredProcedure;
        if (auth == null && tags == null)
        {
            myCommand.Parameters.Add("@highlight", SqlDbType.VarChar).Value = "False";
            myCommand.Parameters.Add("@sidenews", SqlDbType.VarChar).Value = "False";
        }
        if (Request.QueryString["page"] != null)
            myCommand.Parameters.Add("@startRowIndex", SqlDbType.VarChar).Value = maximumRows * (Convert.ToInt32(Request.QueryString["page"]) - 1);
        else
            myCommand.Parameters.Add("@startRowIndex", SqlDbType.VarChar).Value = "0";
        myCommand.Parameters.Add("@maximumRows", SqlDbType.VarChar).Value = maximumRows;
        if (category != null)
            myCommand.Parameters.Add("@idcategory", SqlDbType.VarChar).Value = category;
        if (year != null)
        {
            myCommand.Parameters.Add("@year", SqlDbType.VarChar).Value = year;
            myCommand.Parameters.Add("@month", SqlDbType.VarChar).Value = month;
        }
        if (auth != null)
            myCommand.Parameters.Add("@author", SqlDbType.NVarChar).Value = ut.UrlDecode(auth);
        if (tags != null)
        {
            string value = ut.UrlDecode(tags);
            value = value.Replace("[", "[[]");
            value = value.Replace("%", "[%]");
            value = value.Replace("_", "[_]");
            myCommand.Parameters.Add("@tag", SqlDbType.NVarChar).Value = value;
        }
        myConnection.Open();
        SqlDataReader reader = myCommand.ExecuteReader();

        while (reader.Read())
        {
            string idnews = reader["idnews"].ToString();
            string title = reader["title"].ToString();
            string author = reader["Author"].ToString();
            string date = reader["date"].ToString();
            string postedby = reader["postedby"].ToString();
            string image = reader["image"].ToString();
            string summary = reader["Summary"].ToString();
            string news = reader["News"].ToString();
            string commentcheck = reader["commentcheck"].ToString();
            string comments = reader["comments"].ToString();

            result +=
            "<div class='post'>" +
                "<h3 class='title'><a href='" + apath + "/articles/" + idnews + "/" + RNA(title) + ".aspx'>" + title + "</a> <span class='right'>" + Edit(idnews) + "</span></h3>" +
                "<div class='anmbyline'>" + PostedBy(author, date, postedby) + "</div>" +
                    "<div class='postcontent'><a href='" + apath + "/articles/" + idnews + "/" + RNA(title) + ".aspx'>" + ShowImage(image) + "</a>" + ViewNews(summary, news) + "</div>" +
                "<div class='meta'>" +
                    "<span class='links'>" + ReadMore(summary, idnews, title, commentcheck) + " " + Comments(idnews, commentcheck, comments, title) + "</span><br />" +
                    "<div class='addthis_toolbox addthis_default_style '></div>" +
                "</div>" +
            "</div>";

        }
        myConnection.Close();
        string newold = "<div class='center'>";
        int page = 1;
        if (Request.QueryString["page"] != null)
        {
            page = Convert.ToInt32(Request.QueryString["page"].ToString());
            if (numarticles > maximumRows)
            {
                if (page > 1 && page < maxpage)
                {
                    if (tags == null)
                    {
                        if (auth == null)
                        {
                            if (category != null)
                            {
                                if (year != null)
                                {
                                    newold += "<a href='" + apath + "/page" + (page - 1) + "/month_" + month + "/year_" + year + "/cat" + category + ".aspx' rel='nofollow'>" + newent + "</a> ";
                                    newold += "<a href='" + apath + "/page" + (page + 1) + "/month_" + month + "/year_" + year + "/cat" + category + ".aspx' rel='nofollow'>" + oldent + "</a>";
                                }
                                else
                                {
                                    newold += "<a href='" + apath + "/page" + (page - 1) + "/category" + category + ".aspx' rel='nofollow'>" + newent + "</a> ";
                                    newold += "<a href='" + apath + "/page" + (page + 1) + "/category" + category + ".aspx' rel='nofollow'>" + oldent + "</a>";
                                }
                            }
                            else
                            {
                                if (year != null)
                                {
                                    newold += "<a href='" + apath + "/page" + (page - 1) + "/year_" + year + "/month_" + month + ".aspx' rel='nofollow'>" + newent + "</a> ";
                                    newold += "<a href='" + apath + "/page" + (page + 1) + "/year_" + year + "/month_" + month + ".aspx' rel='nofollow'>" + oldent + "</a>";
                                }
                                else
                                {
                                    newold += "<a href='" + apath + "/page" + (page - 1) + "/news.aspx' rel='nofollow'>" + newent + "</a> ";
                                    newold += "<a href='" + apath + "/page" + (page + 1) + "/news.aspx' rel='nofollow'>" + oldent + "</a>";
                                }
                            }
                        }
                        else
                        {
                            newold += "<a href='" + apath + "/page" + (page - 1) + "/articles/author/" + ut.UrlEncode(auth) + ".aspx' rel='nofollow'>" + newent + "</a> ";
                            newold += "<a href='" + apath + "/page" + (page + 1) + "/articles/author/" + ut.UrlEncode(auth) + ".aspx' rel='nofollow'>" + oldent + "</a>";
                        }
                    }
                    else
                    {
                        newold += "<a href='" + apath + "/page" + (page - 1) + "/tag/" + ut.UrlEncode(tags) + ".aspx' rel='nofollow'>" + newent + "</a> ";
                        newold += "<a href='" + apath + "/page" + (page + 1) + "/tag/" + ut.UrlEncode(tags) + ".aspx' rel='nofollow'>" + oldent + "</a>";
                    }
                }
                if (page == 1 && page < maxpage)
                {
                    if (tags == null)
                    {
                        if (auth == null)
                        {
                            if (category != null)
                            {
                                if (year != null)
                                {
                                    newold += "<a href='" + apath + "/page" + (page + 1) + "/month_" + month + "/year_" + year + "/cat" + category + ".aspx'>" + oldent + "</a>";
                                }
                                else
                                {
                                    newold += "<a href='" + apath + "/page" + (page + 1) + "/category" + category + ".aspx'>" + oldent + "</a>";
                                }
                            }
                            else
                            {
                                if (year != null)
                                {
                                    newold += "<a href='" + apath + "/page" + (page + 1) + "/year_" + year + "/month_" + month + ".aspx'>" + oldent + "</a>";
                                }
                                else
                                {
                                    newold += "<a href='" + apath + "/page" + (page + 1) + "/news.aspx'>" + oldent + "</a>";
                                }
                            }
                        }
                        else
                        {
                            newold += "<a href='" + apath + "/page" + (page + 1) + "/articles/author/" + ut.UrlEncode(auth) + ".aspx'>" + oldent + "</a>";
                        }
                    }
                    else
                    {
                        newold += "<a href='" + apath + "/page" + (page + 1) + "/tag/" + ut.UrlEncode(tags) + ".aspx'>" + oldent + "</a>";
                    }
                }
                if (page > 1 && page == maxpage)
                {
                    if (tags == null)
                    {
                        if (auth == null)
                        {
                            if (category != null)
                            {
                                if (year != null)
                                {
                                    newold += "<a href='" + apath + "/page" + (page - 1) + "/month_" + month + "/year_" + year + "/cat" + category + ".aspx'>" + newent + "</a> ";
                                }
                                else
                                {
                                    newold += "<a href='" + apath + "/page" + (page - 1) + "/category" + category + ".aspx'>" + newent + "</a> ";
                                }
                            }
                            else
                            {
                                if (year != null)
                                {
                                    newold += "<a href='" + apath + "/page" + (page - 1) + "/year_" + year + "/month_" + month + ".aspx'>" + newent + "</a> ";
                                }
                                else
                                {
                                    newold += "<a href='" + apath + "/page" + (page - 1) + "/news.aspx'>" + newent + "</a> ";
                                }
                            }
                        }
                        else
                        {
                            newold += "<a href='" + apath + "/page" + (page - 1) + "/articles/author/" + ut.UrlEncode(auth) + ".aspx'>" + newent + "</a> ";
                        }
                    }
                    else
                    {
                        newold += "<a href='" + apath + "/page" + (page - 1) + "/tag/" + ut.UrlEncode(tags) + ".aspx'>" + newent + "</a> ";
                    }
                }
            }
        }
        else
        {
            if (numarticles > maximumRows)
            {
                if (tags == null)
                {
                    if (auth == null)
                    {
                        if (category != null)
                        {
                            if (year != null)
                            {
                                newold += "<a href='" + apath + "/page2/month_" + month + "/year_" + year + "/cat" + category + ".aspx'>" + oldent + "</a>";
                            }
                            else
                            {
                                newold += "<a href='" + apath + "/page2/category" + category + ".aspx'>" + oldent + "</a>";
                            }
                        }
                        else
                        {
                            if (year != null)
                            {
                                newold += "<a href='" + apath + "/page2/year_" + year + "/month_" + month + ".aspx'>" + oldent + "</a>";
                            }
                            else
                            {
                                newold += "<a href='" + apath + "/page2/news.aspx'>" + oldent + "</a>";
                            }
                        }
                    }
                    else
                    {
                        newold += "<a href='" + apath + "/page2/articles/author/" + ut.UrlEncode(auth) + ".aspx'>" + oldent + "</a>";
                    }
                }
                else
                {
                    newold += "<a href='" + apath + "/page2/tag/" + ut.UrlEncode(tags) + ".aspx'>" + oldent + "</a>";
                }
            }
        }
        if (newold != "<div class='center'>")
            newold += "</div>";
        else
            newold = "";

        string linknav = "<div class='linkpage'>";
        if (Request.QueryString["page"] != null)
        {
            page = Convert.ToInt32(Request.QueryString["page"].ToString());
            if (numarticles > maximumRows)
            {
                for (int i = (page - 5); i < (page + 10); i++)
                {
                    if (i >= 1 && i <= (maxpage))
                    {
                        if (tags == null)
                        {
                            if (auth == null)
                            {
                                if (category != null)
                                {
                                    if (year != null)
                                    {
                                        if (page == i)
                                            linknav += "<a href='" + apath + "/page" + i + "/month_" + month + "/year_" + year + "/cat" + category + ".aspx' class='pagenavselected'>" + i + "</a> ";
                                        else
                                            linknav += "<a href='" + apath + "/page" + i + "/month_" + month + "/year_" + year + "/cat" + category + ".aspx' class='pagenav'>" + i + "</a> ";
                                    }
                                    else
                                    {
                                        if (page == i)
                                            linknav += "<a href='" + apath + "/page" + i + "/category" + category + ".aspx' class='pagenavselected'>" + i + "</a> ";
                                        else
                                            linknav += "<a href='" + apath + "/page" + i + "/category" + category + ".aspx' class='pagenav'>" + i + "</a> ";
                                    }
                                }
                                else
                                {
                                    if (year != null)
                                    {
                                        if (page == i)
                                            linknav += "<a href='" + apath + "/page" + i + "/year_" + year + "/month_" + month + ".aspx' class='pagenavselected'>" + i + "</a> ";
                                        else
                                            linknav += "<a href='" + apath + "/page" + i + "/year_" + year + "/month_" + month + ".aspx' class='pagenav'>" + i + "</a> ";
                                    }
                                    else
                                    {
                                        if (page == i)
                                            linknav += "<a href='" + apath + "/page" + i + "/news.aspx' class='pagenavselected'>" + i + "</a> ";
                                        else
                                            linknav += "<a href='" + apath + "/page" + i + "/news.aspx' class='pagenav'>" + i + "</a> ";
                                    }
                                }
                            }
                            else
                            {
                                if (page == i)
                                    linknav += "<a href='" + apath + "/page" + i + "/articles/author/" + ut.UrlEncode(auth) + ".aspx' class='pagenavselected'>" + i + "</a> ";
                                else
                                    linknav += "<a href='" + apath + "/page" + i + "/articles/author/" + ut.UrlEncode(auth) + ".aspx' class='pagenav'>" + i + "</a> ";
                            }
                        }
                        else
                        {
                            if (page == i)
                                linknav += "<a href='" + apath + "/page" + i + "/tag/" + ut.UrlEncode(tags) + ".aspx' class='pagenavselected'>" + i + "</a> ";
                            else
                                linknav += "<a href='" + apath + "/page" + i + "/tag/" + ut.UrlEncode(tags) + ".aspx' class='pagenav'>" + i + "</a> ";
                        }
                    }
                }
            }
        }
        else
        {
            for (int i = 1; i < 11; i++)
            {
                if (tags == null)
                {
                    if (auth == null)
                    {
                        if (category != null)
                        {
                            if (year != null)
                            {
                                if (i == 1)
                                    linknav += "<a href='" + apath + "/page" + i + "/month_" + month + "/year_" + year + "/cat" + category + ".aspx' class='pagenavselected'>" + i + "</a> ";
                                if (i > 1 && i <= maxpage)
                                    linknav += "<a href='" + apath + "/page" + i + "/month_" + month + "/year_" + year + "/cat" + category + ".aspx' class='pagenav'>" + i + "</a> ";
                            }
                            else
                            {
                                if (i == 1)
                                    linknav += "<a href='" + apath + "/page" + i + "/category" + category + ".aspx' class='pagenavselected'>" + i + "</a> ";
                                if (i > 1 && i <= maxpage)
                                    linknav += "<a href='" + apath + "/page" + i + "/category" + category + ".aspx' class='pagenav'>" + i + "</a> ";
                            }
                        }
                        else
                        {
                            if (year != null)
                            {
                                if (i == 1)
                                    linknav += "<a href='" + apath + "/page" + i + "/year_" + year + "/month_" + month + ".aspx' class='pagenavselected'>" + i + "</a> ";
                                if (i > 1 && i <= maxpage)
                                    linknav += "<a href='" + apath + "/page" + i + "/year_" + year + "/month_" + month + ".aspx' class='pagenav'>" + i + "</a> ";
                            }
                            else
                            {
                                if (i == 1)
                                    linknav += "<a href='" + apath + "/page" + i + "/news.aspx' class='pagenavselected'>" + i + "</a> ";
                                if (i > 1 && i <= maxpage)
                                    linknav += "<a href='" + apath + "/page" + i + "/news.aspx' class='pagenav'>" + i + "</a> ";
                            }
                        }
                    }
                    else
                    {
                        if (i == 1)
                            linknav += "<a href='" + apath + "/page" + i + "/articles/author/" + ut.UrlEncode(auth) + ".aspx' class='pagenavselected'>" + i + "</a> ";
                        if (i > 1 && i <= maxpage)
                            linknav += "<a href='" + apath + "/page" + i + "/articles/author/" + ut.UrlEncode(auth) + ".aspx' class='pagenav'>" + i + "</a> ";
                    }
                }
                else
                {
                    if (i == 1)
                        linknav += "<a href='" + apath + "/page" + i + "/tag/" + ut.UrlEncode(tags) + ".aspx' class='pagenavselected'>" + i + "</a> ";
                    if (i > 1 && i <= maxpage)
                        linknav += "<a href='" + apath + "/page" + i + "/tag/" + ut.UrlEncode(tags) + ".aspx' class='pagenav'>" + i + "</a> ";
                }
            }
        }
        if (linknav != "<div class='linkpage'>")
            linknav += "- " + GetGlobalResourceObject("language", "Page") + " " + page + " " + GetGlobalResourceObject("language", "Of") + " " + maxpage + "</div>";
        else
            linknav = "";
        LTpagelink.Text = linknav;
        if (result == "" || maxpage == 1)
            LTpagelink.Visible = false;
        return result + newold;
    }
    protected string HomeSlideshow()
    {
        if (Request.QueryString["tag"] == null && Request.QueryString["author"] == null && Request.QueryString["category"] == null && Request.QueryString["year"] == null && Request.QueryString["month"] == null && Request.QueryString["page"] == null)
        {
            anm_Utility ut = new anm_Utility();
            return ut.HomeSlideshow();
        }
        else
            return "";
    }
    protected string ReadMore(string s, string idn, string title, string c)
    {
        string res = "";
        anm_Utility ut = new anm_Utility();
        if (s.Length > 8)
        {
            if (c == "True")
                res = "<a href='" + apath + "/articles/" + idn + "/" + ut.RemoveNonAlfaNumeric(title) + ".aspx' class='imgreadmore' rel='nofollow'>&nbsp;&nbsp;&nbsp;&nbsp;</a><a href='" + apath + "/articles/" + idn + "/" + ut.RemoveNonAlfaNumeric(title) + ".aspx' class='more'>" + GetGlobalResourceObject("language", "Readfullarticle") + "</a> <b>|</b> ";
            else
                res = "<a href='" + apath + "/articles/" + idn + "/" + ut.RemoveNonAlfaNumeric(title) + ".aspx' class='imgreadmore' rel='nofollow'>&nbsp;&nbsp;&nbsp;&nbsp;</a><a href='" + apath + "/articles/" + idn + "/" + ut.RemoveNonAlfaNumeric(title) + ".aspx' class='more'>" + GetGlobalResourceObject("language", "Readfullarticle") + "</a>";
        }
        return res;
    }
    protected string Comments(string idn, string c, string nc, string title)
    {
        string res = "";
        anm_Utility ut = new anm_Utility();
        if (c == "True")
            res = "<a href='" + apath + "/articles/" + idn + "/" + ut.RemoveNonAlfaNumeric(title) + ".aspx#comments' class='imgcomment' rel='nofollow'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</a><a href='" + apath + "/articles/" + idn + "/" + ut.RemoveNonAlfaNumeric(title) + ".aspx#comments' class='comments'>" + GetGlobalResourceObject("language", "Comments") + " (" + nc + ")</a>";
        return res;
    }
    protected string PostedBy(string author, string date, string postedby)
    {
        anm_Utility ut = new anm_Utility();
        DateTime data = DateTime.Parse(date);
        string newDate = string.Format("{0}", data.ToString("f", System.Globalization.CultureInfo.CurrentCulture));
        string res = "";
        if (postedby == "True")
            res = GetGlobalResourceObject("language", "Postedby") + " <a href='" + apath + "/articles/author/" + ut.UrlEncode(author) + ".aspx'>" + author + "</a> " + GetGlobalResourceObject("language", "on") + " " + newDate;
        return res;
    }
    protected string Edit(string idn)
    {
        string res = "";
        anm_Utility ut = new anm_Utility();
        if (Request.IsAuthenticated)
        {
            MembershipUser user = Membership.GetUser();
            string role = ut.GetRole(user.UserName);
            if (role == "1")
                res = "<a href='" + Page.Request.Url.AbsolutePath.ToString() + "?p=EditArticle&amp;idnews=" + idn + "'>|" + GetGlobalResourceObject("language", "Edit") + "|</a>";
        }
        return res;
    }
    protected string UrlJQuery()
    {
        return apath + "/jquery-1.7.1.min.js";
    }
    protected string Navigation()
    {
        anm_Utility ut = new anm_Utility();
        return "<div class='navigationbar'>" + ut.GetNavigation() + "</div>";
    }
    protected string RNA(string text)
    {
        anm_Utility ut = new anm_Utility();
        return ut.RemoveNonAlfaNumeric(text);
    }
}
