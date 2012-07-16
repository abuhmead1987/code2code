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
using System.Text.RegularExpressions;

public partial class Controls_Search : System.Web.UI.UserControl
{
    int currentpage = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DDcat.Items.Add(new ListItem(GetGlobalResourceObject("language", "All").ToString()));
            string strConn = ConfigurationManager.ConnectionStrings["anmcs"].ToString();
            SqlConnection myConnection = new SqlConnection(strConn);
            SqlCommand myCommand = new SqlCommand("anm_getCategories", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;
            myConnection.Open();
            SqlDataReader reader = myCommand.ExecuteReader();
            while (reader.Read())
            {
                string idc = reader["idcategory"].ToString();
                string category = reader["category"].ToString();
                DDcat.Items.Add(new ListItem(category, idc));
            }
            myConnection.Close();
            if (Request.QueryString["category"] != "")
                DDcat.SelectedValue = Request.QueryString["category"];
            if (Request.QueryString["page"] != null)
                currentpage = Convert.ToInt32(HttpContext.Current.Request.QueryString["page"].ToString());
            anm_Utility ut = new anm_Utility(); 
            Label1.Text = ut.UrlDecode(Request.QueryString["title"].ToString());
            LitCat.Text = GetGlobalResourceObject("language", "Category").ToString() + ": ";
        }
    }
    protected string ViewResult()
    {
        string category = "";
        string res = "";
        string spname = "";
        int numarticles = 0;
        string apath = anm_Utility.GetWebAppRoot();
        if (Request.QueryString["category"] != null)
        {
            spname = "anm_SearchNewsbyCatPaged";
            category = Request.QueryString["category"];
        }
        else
            spname = "anm_SearchNewsPaged";

        anm_Utility ut = new anm_Utility();
        string text = ut.UrlDecode(Request.QueryString["title"].ToString()).Trim();
        string value = text.Replace("[", "[[]");
        value = value.Replace("%", "[%]");
        value = value.Replace("_", "[_]");
        value = value.Trim();
        Label1.Text = text;

        string strConn = ConfigurationManager.ConnectionStrings["anmcs"].ToString();
        SqlConnection myConnection = new SqlConnection(strConn);
        SqlCommand myCommand = new SqlCommand(spname, myConnection);
        myCommand.CommandType = CommandType.StoredProcedure;
        if (category != "")
        {
            Page.Title = GetGlobalResourceObject("language", "Search") + ": " + text + " - " + ut.GetCategory(Request.QueryString["category"]) + " - " + ut.GetSetting("SiteName");
            myCommand.Parameters.Add("@idcategory", SqlDbType.VarChar).Value = category;
        }
        else
            Page.Title = GetGlobalResourceObject("language", "Search") + ": " + text + " - " + ut.GetSetting("SiteName");
        myCommand.Parameters.Add("@title", SqlDbType.NVarChar).Value = value;
        int startrow = 0;
        int rows = 15;
        int page = 1;
        if (Request.QueryString["page"] != null)
            startrow = rows * (Convert.ToInt32(Request.QueryString["page"]) - 1);
        myCommand.Parameters.Add("@startRowIndex", SqlDbType.VarChar).Value = startrow;
        myCommand.Parameters.Add("@maximumRows", SqlDbType.VarChar).Value = rows;
        myConnection.Open();
        SqlDataReader reader = myCommand.ExecuteReader();
        while (reader.Read())
            res += Result(reader["title"].ToString(), reader["idnews"].ToString(), reader["image"].ToString(), reader["summary"].ToString(), reader["news"].ToString());
        myConnection.Close();

        if (res == "")
        {
            string[] words = value.Split(' ');
            string condition = "(";
            for (int i = 0; i < words.Length; i++)
            {
                if (words[i].Length > 3)
                {
                    string val = words[i].ToString();
                    condition += "((title LIKE '%' + '" + val + "' + '%') OR (news LIKE '%' + '" + val + "' + '%') OR (summary LIKE '%' + '" + val + "' + '%')) AND ";
                }
            }
            if (condition != "(")
                condition = condition.Remove(condition.Length - 4, 4) + ") and";
            else
                condition = "";
            if (Request.QueryString["category"] != null)
            {
                SqlCommand myCommand2 = new SqlCommand();
                myCommand2.Connection = myConnection;
                myConnection.Open();
                myCommand2.CommandText = "SELECT title,idnews,image,Summary,news FROM (SELECT title,idnews,image,Summary,news, ROW_NUMBER() OVER(ORDER BY idnews  DESC) AS RowNumber FROM anm_News,anm_Categories WHERE " + condition + " published='true' and anm_News.idcategory = anm_Categories.idcategory and (anm_News.idcategory = " + Request.QueryString["category"] + " or anm_Categories.idfather = " + Request.QueryString["category"] + " or anm_Categories.idrootcat = " + Request.QueryString["category"] + ")) AS NewsWithRowNumbers WHERE RowNumber > " + startrow + " AND RowNumber <= " + (startrow + rows) + "";
                SqlDataReader reader2 = myCommand2.ExecuteReader();
                while (reader2.Read())
                {
                    res += Result(reader2["title"].ToString(), reader2["idnews"].ToString(), reader2["image"].ToString(), reader2["summary"].ToString(), reader2["news"].ToString());
                }
                myConnection.Close();
                Page.Title = GetGlobalResourceObject("language", "Search") + ": " + text + " - " + ut.GetCategory(Request.QueryString["category"]) + " - " + ut.GetSetting("SiteName");
                DDcat.SelectedValue = Request.QueryString["category"];
                numarticles = ut.GetNumberSearchResults("SELECT COUNT(*) FROM anm_News,anm_Categories WHERE " + condition + " published='true' and anm_News.idcategory = anm_Categories.idcategory and (anm_News.idcategory = " + Request.QueryString["category"] + " or anm_Categories.idfather = " + Request.QueryString["category"] + " or anm_Categories.idrootcat = " + Request.QueryString["category"]);
            }
            else
            {
                SqlCommand myCommand3 = new SqlCommand();
                myCommand3.Connection = myConnection;
                myConnection.Open();
                myCommand3.CommandText = "SELECT title,idnews,image,Summary,news FROM (SELECT title,idnews,image,Summary,news, ROW_NUMBER() OVER(ORDER BY idnews  DESC) AS RowNumber FROM anm_News WHERE " + condition + " published='true') AS NewsWithRowNumbers WHERE RowNumber > " + startrow + " AND RowNumber <= " + (startrow + rows) + "";
                SqlDataReader reader3 = myCommand3.ExecuteReader();
                while (reader3.Read())
                {
                    res += Result(reader3["title"].ToString(), reader3["idnews"].ToString(), reader3["image"].ToString(), reader3["summary"].ToString(), reader3["news"].ToString());
                }
                myConnection.Close();
                Page.Title = GetGlobalResourceObject("language", "Search") + ": " + text + " - " + ut.GetSetting("SiteName");
                numarticles = ut.GetNumberSearchResults("SELECT COUNT(*) FROM anm_News WHERE " + condition + " published='true'");
            }
            if (res == "")
            {
                condition = "(";
                for (int i = 0; i < words.Length; i++)
                {
                    if (words[i].Length > 3)
                    {
                        string val = words[i].ToString();
                        condition += "(title LIKE '%' + '" + val + "' + '%') OR (news LIKE '%' + '" + val + "' + '%') OR (summary LIKE '%' + '" + val + "' + '%') OR ";
                    }
                }
                if (condition != "(")
                    condition = condition.Remove(condition.Length - 4, 4) + ") and";
                else
                    condition = "";
                if (Request.QueryString["category"] != null)
                {
                    SqlCommand myCommand2 = new SqlCommand();
                    myCommand2.Connection = myConnection;
                    myConnection.Open();
                    myCommand2.CommandText = "SELECT title,idnews,image,Summary,news FROM (SELECT title,idnews,image,Summary,news, ROW_NUMBER() OVER(ORDER BY idnews  DESC) AS RowNumber FROM anm_News,anm_Categories WHERE " + condition + " published='true' and anm_News.idcategory = anm_Categories.idcategory and (anm_News.idcategory = " + Request.QueryString["category"] + " or anm_Categories.idfather = " + Request.QueryString["category"] + " or anm_Categories.idrootcat = " + Request.QueryString["category"] + ")) AS NewsWithRowNumbers WHERE RowNumber > " + startrow + " AND RowNumber <= " + (startrow + rows) + "";
                    SqlDataReader reader2 = myCommand2.ExecuteReader();
                    while (reader2.Read())
                    {
                        res += Result(reader2["title"].ToString(), reader2["idnews"].ToString(), reader2["image"].ToString(), reader2["summary"].ToString(), reader2["news"].ToString());
                    }
                    myConnection.Close();
                    Page.Title = GetGlobalResourceObject("language", "Search") + ": " + text + " - " + ut.GetCategory(Request.QueryString["category"]) + " - " + ut.GetSetting("SiteName");
                    DDcat.SelectedValue = Request.QueryString["category"];
                    numarticles = ut.GetNumberSearchResults("SELECT COUNT(*) FROM anm_News,anm_Categories WHERE " + condition + " published='true' and anm_News.idcategory = anm_Categories.idcategory and (anm_News.idcategory = " + Request.QueryString["category"] + " or anm_Categories.idfather = " + Request.QueryString["category"] + " or anm_Categories.idrootcat = " + Request.QueryString["category"]);
                }
                else
                {
                    SqlCommand myCommand3 = new SqlCommand();
                    myCommand3.Connection = myConnection;
                    myConnection.Open();
                    myCommand3.CommandText = "SELECT title,idnews,image,Summary,news FROM (SELECT title,idnews,image,Summary,news, ROW_NUMBER() OVER(ORDER BY idnews  DESC) AS RowNumber FROM anm_News WHERE " + condition + " published='true') AS NewsWithRowNumbers WHERE RowNumber > " + startrow + " AND RowNumber <= " + (startrow + rows) + "";
                    SqlDataReader reader3 = myCommand3.ExecuteReader();
                    while (reader3.Read())
                    {
                        res += Result(reader3["title"].ToString(), reader3["idnews"].ToString(), reader3["image"].ToString(), reader3["summary"].ToString(), reader3["news"].ToString());
                    }
                    myConnection.Close();
                    Page.Title = GetGlobalResourceObject("language", "Search") + ": " + text + " - " + ut.GetSetting("SiteName");
                    numarticles = ut.GetNumberSearchResults("SELECT COUNT(*) FROM anm_News WHERE " + condition + " published='true'");
                }
            }
        }
        else
        {
            if (category == "")
                numarticles = ut.GetNumberSearchResults("SELECT COUNT(*) FROM [anm_News] WHERE (([title] LIKE '%' + '" + value + "' + '%') OR ([news] LIKE '%' + '" + value + "' + '%') OR ([summary] LIKE '%' + '" + value + "' + '%')) and published='true' and date<GETDATE()");
            else
                numarticles = ut.GetNumberSearchResults("SELECT COUNT(*) FROM [anm_News],[anm_Categories] WHERE (([title] LIKE '%' + '" + value + "' + '%') OR ([news] LIKE '%' + '" + value + "' + '%') OR ([summary] LIKE '%' + '" + value + "' + '%')) and published='true' and anm_News.idcategory = anm_Categories.idcategory and (anm_News.idcategory = " + category + " or anm_Categories.idfather = " + category + " or anm_Categories.idrootcat = " + category + ") and date<GETDATE()");
        }
        if (res != "")
        {
            string linknav = "<div class='linkpage'>";
            int maximumRows = rows;
            int maxpage = (numarticles / maximumRows) + 1;
            if (numarticles % maximumRows == 0)
                maxpage = numarticles / maximumRows;
            if (currentpage != 0)
            {
                page = currentpage;
                if (numarticles > maximumRows)
                {
                    for (int i = (page - 5); i < (page + 10); i++)
                    {
                        if (i >= 1 && i <= (maxpage))
                        {
                            if (category != "")
                            {
                                if (page == i)
                                    linknav += "<a href='" + apath + "/page" + i + "_cat" + category + "_search/" + text + ".aspx' class='pagenavselected'>" + i + "</a> ";
                                else
                                    linknav += "<a href='" + apath + "/page" + i + "_cat" + category + "_search/" + text + ".aspx' class='pagenav'>" + i + "</a> ";
                            }
                            else
                            {
                                if (page == i)
                                    linknav += "<a href='" + apath + "/page" + i + "/search/" + text + ".aspx' class='pagenavselected'>" + i + "</a> ";
                                else
                                    linknav += "<a href='" + apath + "/page" + i + "/search/" + text + ".aspx' class='pagenav'>" + i + "</a> ";
                            }
                        }
                    }
                }
            }
            else
            {
                for (int i = 1; i < 11; i++)
                {
                    if (category != "")
                    {
                        if (i == 1)
                            linknav += "<a href='" + apath + "/page" + i + "_cat" + category + "_search/" + text + ".aspx' class='pagenavselected'>" + i + "</a> ";
                        if (i > 1 && i <= maxpage)
                            linknav += "<a href='" + apath + "/page" + i + "_cat" + category + "_search/" + text + ".aspx' class='pagenav'>" + i + "</a> ";
                    }
                    else
                    {
                        if (i == 1)
                            linknav += "<a href='" + apath + "/page" + i + "/search/" + text + ".aspx' class='pagenavselected'>" + i + "</a> ";
                        if (i > 1 && i <= maxpage)
                            linknav += "<a href='" + apath + "/page" + i + "/search/" + text + ".aspx' class='pagenav'>" + i + "</a> ";
                    }
                }
            }
            if (linknav != "<div class='linkpage'>")
                linknav += "- " + GetGlobalResourceObject("language", "Page") + " " + page + " " + GetGlobalResourceObject("language", "Of") + " " + maxpage + "</div>";
            else
                linknav = "";
            LTpagelink.Text = linknav;
            if (res == "" || maxpage == 1)
                LTpagelink.Visible = false;

        }
        else
            res = "- No results.";

        return res;
    }
    protected string ViewNews(String s, String n)
    {
        if (s.Length < 9)
            return n;
        else
            return s;
    }
    protected string RNA(string text)
    {
        anm_Utility ut = new anm_Utility();
        return ut.RemoveNonAlfaNumeric(text);
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
    protected string LinkCat()
    {
        anm_Utility ut = new anm_Utility();
        string strConn = ConfigurationManager.ConnectionStrings["anmcs"].ToString();
        SqlConnection myConnection = new SqlConnection(strConn);
        SqlCommand myCommand = new SqlCommand("anm_getMainCategories", myConnection);
        myCommand.CommandType = CommandType.StoredProcedure;
        myConnection.Open();
        SqlDataReader reader = myCommand.ExecuteReader();
        string res = "";
        string value = Request.QueryString["title"].ToString();
        while (reader.Read())
        {
            string idc = reader["idcategory"].ToString();
            string category = reader["category"].ToString();
            if (Request.QueryString["type"] != null)
                res += "<a href='" + Page.Request.ApplicationPath.ToString() + "/ctg_" + idc + "/search" + Request.QueryString["type"] + "/" + ut.UrlEncode(value) + ".aspx'>" + reader["category"].ToString() + "</a> - ";
            else
                res += "<a href='" + Page.Request.ApplicationPath.ToString() + "/cat"+idc+"/search/" + ut.UrlEncode(value) + ".aspx'>" + reader["category"].ToString() + "</a> - ";
        }
        myConnection.Close();
        return res;
    }
    protected string Result(string title, string idn, string image, string sum, string news)
    {
        string apath = anm_Utility.GetWebAppRoot();
        string res = "<hr />";
        anm_Utility ut = new anm_Utility();
        string preview = Regex.Replace(ViewNews(sum,news), @"<(.|\n)*?>", string.Empty);
        if (preview.Length > 180)
            preview = preview.Substring(0, 181) + "...";

        string title2 = title;
        string text = ut.UrlDecode(Request.QueryString["title"].ToString()).Trim();
        string value = text.Replace("[", "[[]");
        value = value.Replace("%", "[%]");
        value = value.Replace("_", "[_]");
        value = value.Trim();
        string[] words = value.Split(' ');
        for (int i = 0; i < words.Length; i++)
        {
            if (words[i].Length > 3)
            {
                preview = Regex.Replace(preview, words[i].ToLower(), "<b>" + words[i].ToLower() + "</b>", RegexOptions.IgnoreCase);
                title2 = Regex.Replace(title2, words[i].ToLower(), "<b>" + words[i].ToLower() + "</b>", RegexOptions.IgnoreCase);
            }
        }

        if (image != "")
            res += "<div style='height:50px;padding:2px;'><a href='" + apath + "/articles/" + idn + "/" + RNA(title) + ".aspx'><img alt='" + title + "' class='left' style='max-height:50px;max-width:70px' src='" + apath + "/images/" + image + "' /></a>-  <a href='" + apath + "/articles/" + idn + "/" + RNA(title) + ".aspx'>" + title2 + "</a> <br /><span>" + preview + "</span></div>";
        else
            res += "<div style='padding:2px;'>-  <a href='" + apath + "/articles/" + idn + "/" + RNA(title) + ".aspx'>" + title2 + "</a> <br /><span>" + preview + "</span></div>";
        return res;
    }
    protected void ddcat_SelectedIndexChanged(object sender, EventArgs e)
    {
        string value = DDcat.SelectedValue;
        if (value != GetGlobalResourceObject("language", "All").ToString())
            Response.Redirect(Page.Request.ApplicationPath.ToString() + "/cat" + value + "/search/" + Request.QueryString["title"] + ".aspx");
        else
            Response.Redirect(Page.Request.ApplicationPath.ToString() + "/search/" + Request.QueryString["title"] + ".aspx");
    }
    protected string NewSearch()
    {
        if (Request.QueryString["category"] == null)
        {
            if (Request.QueryString["type"] == null)
                Response.Redirect(Page.Request.ApplicationPath.ToString() + "/t_1/search/" + Request.QueryString["title"] + ".aspx");
            else if (Request.QueryString["type"] == "1")
                Response.Redirect(Page.Request.ApplicationPath.ToString() + "/t_2/search/" + Request.QueryString["title"] + ".aspx");
        }
        return "- No result";

    }
}
