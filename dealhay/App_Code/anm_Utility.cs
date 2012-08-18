using System;
using System.Data;
using System.Collections;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Drawing.Drawing2D;
using System.Text.RegularExpressions;
using System.Web.ClientServices.Providers;

namespace anm_utility
{
    public class anm_Utility
    {
        public anm_Utility()
        {

        }
        public String ChangeEmail(MembershipUser user, String email)
        {
            string message = "";
            if (Regex.IsMatch(email, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"))
            {
                user.Email = email;
                try
                {
                    Membership.UpdateUser(user);
                    message = HttpContext.GetGlobalResourceObject("language", "Emailupdated").ToString();
                }
                catch
                {
                    message = HttpContext.GetGlobalResourceObject("language", "Emailused").ToString();
                }
            }
            else
            {
                message = HttpContext.GetGlobalResourceObject("language", "Insertemail").ToString();
            }
            return message;
        }
        public String CheckLogin(String UserName)
        {
            MembershipUser userInfo = Membership.GetUser(UserName);
            String errormsg = "";
            if (userInfo != null)
            {
                if (!userInfo.IsApproved)
                    errormsg = HttpContext.GetGlobalResourceObject("language", "needtoactivateacc").ToString();
                else
                    errormsg = HttpContext.GetGlobalResourceObject("language", "Incorrectpassword").ToString();
            }
            else
            {
                errormsg = HttpContext.GetGlobalResourceObject("language", "Loginerror").ToString();
            }
            return errormsg;
        }	
        public String GetSetting(String type)
        {
            string res = "";
            if (HttpContext.Current.Cache[type] != null)
            {
                res = HttpContext.Current.Cache[type].ToString();
            }
            else
            {
                try
                {
                    string strConn = ConfigurationManager.ConnectionStrings["anmcs"].ToString();
                    SqlConnection myConnection = new SqlConnection(strConn);
                    SqlCommand myCommand = new SqlCommand("anm_GetSettings", myConnection);
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myConnection.Open();
                    SqlDataReader reader = myCommand.ExecuteReader();

                    while (reader.Read())
                    {
                        res = reader[type].ToString();
                        HttpContext.Current.Cache.Insert(type, res, null, DateTime.Now.AddMonths(6), TimeSpan.Zero, System.Web.Caching.CacheItemPriority.High, null);
                    }

                    myConnection.Close();
                }
                catch
                {
                    res = "1.0";
                }
            }
            return res;
        }
        public Boolean IsInstalled()
        {
            Boolean res = false;
            if (HttpContext.Current.Cache["IsInstalled"] != null)
            {
                res = Convert.ToBoolean(HttpContext.Current.Cache["IsInstalled"].ToString());
            }
            else
            {
                try
                {
                    string strConn = ConfigurationManager.ConnectionStrings["anmcs"].ToString();
                    SqlConnection myConnection = new SqlConnection(strConn);
                    SqlCommand myCommand = new SqlCommand();
                    myCommand.Connection = myConnection;

                    myConnection.Open();

                    myCommand.CommandText = "SELECT COUNT(*) FROM anm_Settings";
                    Int32 sett = (Int32)myCommand.ExecuteScalar();
                    myConnection.Close();
                    res = (sett > 0);
                    HttpContext.Current.Cache.Insert("IsInstalled", res, null, DateTime.Now.AddMinutes(12), TimeSpan.Zero);
                }
                catch
                {
                    res = false;
                }
            }
            return res;
        }
        public String[] GetTemplate(string id)
        {
            String[] res = new String[3];
            if (HttpContext.Current.Cache["TemplateName"] != null)
            {
                res[0] = HttpContext.Current.Cache["TemplateName"].ToString();
                res[1] = HttpContext.Current.Cache["TemplateAuthor"].ToString();
                res[2] = HttpContext.Current.Cache["TemplateSiteAut"].ToString();
            }
            else
            {
                string strConn = ConfigurationManager.ConnectionStrings["anmcs"].ToString();
                SqlConnection myConnection = new SqlConnection(strConn);
                SqlCommand myCommand = new SqlCommand("anm_GetTemplateById", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                myCommand.Parameters.Add("@Template", SqlDbType.VarChar).Value = id;
                myConnection.Open();
                SqlDataReader reader = myCommand.ExecuteReader();

                while (reader.Read())
                {
                    res[0] = reader["name"].ToString();
                    res[1] = reader["author"].ToString();
                    res[2] = reader["siteauthor"].ToString();
                    HttpContext.Current.Cache.Insert("TemplateName", res[0].ToString(), null, DateTime.Now.AddMonths(6), TimeSpan.Zero, System.Web.Caching.CacheItemPriority.High, null);
                    HttpContext.Current.Cache.Insert("TemplateAuthor", res[1].ToString(), null, DateTime.Now.AddMonths(6), TimeSpan.Zero, System.Web.Caching.CacheItemPriority.High, null);
                    HttpContext.Current.Cache.Insert("TemplateSiteAut", res[2].ToString(), null, DateTime.Now.AddMonths(6), TimeSpan.Zero, System.Web.Caching.CacheItemPriority.High, null);
                }
                myConnection.Close();
            }
            return res;
        }
        public String GetRole(String UserName)
        {
            string role = "";
                string strConn = ConfigurationManager.ConnectionStrings["anmcs"].ToString();
                SqlConnection myConnection = new SqlConnection(strConn);
                SqlCommand myCommand = new SqlCommand("anm_GetRole", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                myCommand.Parameters.Add("@author", SqlDbType.NVarChar).Value = UserName;
                myConnection.Open();
                SqlDataReader reader = myCommand.ExecuteReader();
                while (reader.Read())
                {
                    role = reader["role"].ToString();
                }
                myConnection.Close();
            return role;
        }
        public String GetTitleNews(string idn)
        {
            if (idn != null)
            {
                string strConn = ConfigurationManager.ConnectionStrings["anmcs"].ToString();
                SqlConnection myConnection = new SqlConnection(strConn);
                SqlCommand myCommand = new SqlCommand("anm_getNewsById", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                myCommand.Parameters.Add("@idnews", SqlDbType.NVarChar).Value = idn;
                myConnection.Open();
                SqlDataReader reader = myCommand.ExecuteReader();

                string title = "";
                while (reader.Read())
                    title = reader["title"].ToString();

                myConnection.Close();
                return title;
            }
            else
                return "";
        }
        public String GetComment(string idc)
        {
            string strConn = ConfigurationManager.ConnectionStrings["anmcs"].ToString();
            SqlConnection myConnection = new SqlConnection(strConn);
            SqlCommand myCommand = new SqlCommand("anm_getComment", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.Parameters.Add("@idcomment", SqlDbType.NVarChar).Value = idc;
            myConnection.Open();
            SqlDataReader reader = myCommand.ExecuteReader();

            string comment = "";
            while (reader.Read())
                comment = reader["comment"].ToString();

            myConnection.Close();
            return comment;
        }
        public String GetCategoryFromNews(string idn)
        {
            String res = "";
            if (HttpContext.Current.Cache["cat_name_" + idn] != null && !IsAdmin())
            {
                res = HttpContext.Current.Cache["cat_name_" + idn].ToString();
            }
            else
            {
                string strConn = ConfigurationManager.ConnectionStrings["anmcs"].ToString();
                SqlConnection myConnection = new SqlConnection(strConn);
                SqlCommand myCommand = new SqlCommand("anm_getNewsById", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                myCommand.Parameters.Add("@idnews", SqlDbType.NVarChar).Value = idn;
                myConnection.Open();
                SqlDataReader reader = myCommand.ExecuteReader();
                while (reader.Read())
                    res = reader["idcategory"].ToString();
                myConnection.Close();
                HttpContext.Current.Cache.Insert("cat_name_" + idn, res, null, DateTime.Now.AddMinutes(12), TimeSpan.Zero);
            }
            return res;

        }		
        public int GetCommentsNews(string idn)
        {
            String res = "";
            if (HttpContext.Current.Cache["num_comm_news" + idn] != null && !IsAdmin())
            {
                res = HttpContext.Current.Cache["num_comm_news" + idn].ToString();
            }
            else
            {
                string strConn = ConfigurationManager.ConnectionStrings["anmcs"].ToString();
                SqlConnection myConnection = new SqlConnection(strConn);
                SqlCommand myCommand = new SqlCommand("anm_getNewsById", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                myCommand.Parameters.Add("@idnews", SqlDbType.NVarChar).Value = idn;
                myConnection.Open();
                SqlDataReader reader = myCommand.ExecuteReader();

                while (reader.Read())
                    res = reader["comments"].ToString();

                myConnection.Close();
                HttpContext.Current.Cache.Insert("num_comm_news" + idn, res, null, DateTime.Now.AddMinutes(12), TimeSpan.Zero);
            }
            return Convert.ToInt32(res);
        }
        public string GetIdNewsByComment(string idcomment)
        {
            String res = "";
            if (HttpContext.Current.Cache["idnewsbycomm" + idcomment] != null && !IsAdmin())
            {
                res = HttpContext.Current.Cache["idnewsbycomm" + idcomment].ToString();
            }
            else
            {
                string strConn = ConfigurationManager.ConnectionStrings["anmcs"].ToString();
                SqlConnection myConnection = new SqlConnection(strConn);
                SqlCommand myCommand = new SqlCommand("anm_getComment", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                myCommand.Parameters.Add("@idcomment", SqlDbType.NVarChar).Value = idcomment;
                myConnection.Open();
                SqlDataReader reader = myCommand.ExecuteReader();
                while (reader.Read())
                    res = reader["idnews"].ToString();
                myConnection.Close();
                HttpContext.Current.Cache.Insert("idnewsbycomm" + idcomment, res, null, DateTime.Now.AddMinutes(12), TimeSpan.Zero);
            }
            return res;
        }
        public String GetCategory(string id)
        {
            String res = "";
            if (HttpContext.Current.Cache["cat" + id] != null && !IsAdmin())
            {
                res = HttpContext.Current.Cache["cat" + id].ToString();
            }
            else
            {
                try
                {
                    string strConn = ConfigurationManager.ConnectionStrings["anmcs"].ToString();
                    SqlConnection myConnection = new SqlConnection(strConn);
                    SqlCommand myCommand = new SqlCommand("anm_getCategoriesById", myConnection);
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.Add("@idcategory", SqlDbType.Int).Value = id;
                    myConnection.Open();
                    SqlDataReader reader = myCommand.ExecuteReader();

                    while (reader.Read())
                        res = reader["category"].ToString();

                    HttpContext.Current.Cache.Insert("cat" + id, res, null, DateTime.Now.AddHours(12), TimeSpan.Zero);
                    myConnection.Close();
                }
                catch
                {
                }
            }
            return res;
        }
        public String GetCategoryUrl(string id)
        {
            String res = "";
            if (HttpContext.Current.Cache["caturl" + id] != null && !IsAdmin())
            {
                res = HttpContext.Current.Cache["caturl" + id].ToString();
            }
            else
            {
                try
                {
                    string strConn = ConfigurationManager.ConnectionStrings["anmcs"].ToString();
                    SqlConnection myConnection = new SqlConnection(strConn);
                    SqlCommand myCommand = new SqlCommand("anm_getCategoriesById", myConnection);
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.Add("@idcategory", SqlDbType.Int).Value = id;
                    myConnection.Open();
                    SqlDataReader reader = myCommand.ExecuteReader();

                    while (reader.Read())
                        res = reader["url"].ToString();

                    HttpContext.Current.Cache.Insert("caturl" + id, res, null, DateTime.Now.AddHours(12), TimeSpan.Zero);
                    myConnection.Close();
                }
                catch
                {
                }
            }
            return res;
        }
        public String GetIdFather(string id)
        {
            string strConn = ConfigurationManager.ConnectionStrings["anmcs"].ToString();
            SqlConnection myConnection = new SqlConnection(strConn);
            SqlCommand myCommand = new SqlCommand("anm_getCategoriesById", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.Parameters.Add("@idcategory", SqlDbType.Int).Value = id;
            myConnection.Open();
            SqlDataReader reader = myCommand.ExecuteReader();

            string res = "0";
            while (reader.Read())
                res = reader["idfather"].ToString();

            myConnection.Close();
            return res;
        }
        public String GetIdcRoot(string id)
        {
            string strConn = ConfigurationManager.ConnectionStrings["anmcs"].ToString();
            SqlConnection myConnection = new SqlConnection(strConn);
            SqlCommand myCommand = new SqlCommand("anm_getCategoriesById", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.Parameters.Add("@idcategory", SqlDbType.Int).Value = id;
            myConnection.Open();
            SqlDataReader reader = myCommand.ExecuteReader();

            string res = "";
            while (reader.Read())
                res = reader["idrootcat"].ToString();

            myConnection.Close();
            return res;
        }		
        public HtmlLink InitializeSite(HyperLink version, string css)
        {
            //if (HttpContext.Current.Request.QueryString["p"] == null)
            //    HttpContext.Current.Response.Redirect(HttpContext.Current.Request.Url.AbsolutePath.ToString() + "?p=AllNews");
            if (!(version.Visible == true && version.NavigateUrl == "http://www.allnewsmanager.net" && version.Text == "AllNewsManager.NET"))
                HttpContext.Current.Response.Redirect("http://www.google.com");
            HtmlLink mycss = new HtmlLink();
            mycss.Href = anm_Utility.GetWebAppRoot() + "/css/css" + css + ".css";
            mycss.Attributes.Add("type", "text/css");
            mycss.Attributes.Add("rel", "stylesheet");
            return mycss;
        }
        public String GetMenu()
        {
            string apppath = anm_Utility.GetWebAppRoot();
            string strConn = ConfigurationManager.ConnectionStrings["anmcs"].ToString();
            SqlConnection myConnection = new SqlConnection(strConn);
            SqlCommand myCommand = new SqlCommand("anm_getMainCategories", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;
            myConnection.Open();
            SqlDataReader reader = myCommand.ExecuteReader();
            string category = HttpContext.Current.Request.QueryString["category"];
            string idnews = HttpContext.Current.Request.QueryString["news"];
            string page = HttpContext.Current.Request.QueryString["p"].ToString();
            if (category == null)
                category = "0";
            if (idnews != null)
                category = GetCategoryFromNews(idnews);

            if (category == "")
                HttpContext.Current.Response.Redirect(apppath + "/homepage.aspx");
            string idfather = GetIdFather(category);
            string idrootcat = GetIdcRoot(category);
            string url = "";
            string menu = "<div class='menu'><ul>";
            while (reader.Read())
            {
                string idc = reader["idcategory"].ToString();
                url = reader["url"].ToString();
                if (idc == category || idc == idrootcat || idc == idfather)
                {
                    if (url == "" || url == null)
                        menu += "<li class='menuselected'><a href='" + apppath + "/category" + idc + ".aspx'>" + reader["category"].ToString() + "</a>";
                    else
                        menu += "<li class='menuselected'><a href='" + url + "'>" + reader["category"].ToString() + "</a>";
                }
                else
                {
                    if (url == "" || url == null)
                        menu += "<li><a href='" + apppath + "/category" + idc + ".aspx'>" + reader["category"].ToString() + "</a>";
                    else
                    {
                        if (url == HttpContext.Current.Request.Url.ToString())
                            menu += "<li class='menuselected'><a href='" + url + "'>" + reader["category"].ToString() + "</a>";
                        else
                            menu += "<li><a href='" + url + "'>" + reader["category"].ToString() + "</a>";
                    }
                }
                SqlConnection myConnection2 = new SqlConnection(strConn);
                SqlCommand cmd = new SqlCommand("anm_getSonCategories", myConnection2);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@idcategory", SqlDbType.NVarChar).Value = idc;
                myConnection2.Open();
                SqlDataReader reader2 = cmd.ExecuteReader();
                if (reader2.HasRows == true)
                {
                    menu += "<ul>";
                    while (reader2.Read())
                    {
                        idc = reader2["idcategory"].ToString();
                        url = reader2["url"].ToString();
                        if (idc == category)
                        {
                            if (url == "" || url == null)
                                menu += "<li class='menuselected'><a href='" + apppath + "/category" + idc + ".aspx'>" + reader2["category"].ToString() + "</a></li>";
                            else
                                menu += "<li class='menuselected'><a href='" + url + "'>" + reader2["category"].ToString() + "</a></li>";
                        }
                        else
                        {
                            if (url == "" || url == null)
                                menu += "<li><a href='" + apppath + "/category" + idc + ".aspx'>" + reader2["category"].ToString() + "</a></li>";
                            else
                                menu += "<li><a href='" + url + "'>" + reader2["category"].ToString() + "</a></li>";
                        }
                    }
                    menu += "</ul>";
                }
                menu += "</li>";
                myConnection2.Close();
            }
            menu += "</ul></div>";
            myConnection.Close();
            return menu;
        }
        public String GetNavigation()
        {
            string path = anm_Utility.GetWebAppRoot();
            string navigation = "<a href='" + path + "/homepage.aspx'>Home</a> &gt; ";
            //string navigation =  "<a href='" + HttpContext.Current.Server.MapPath("~/homepage.aspx") + "'>Home</a> &gt; ";
            string idcategory = HttpContext.Current.Request.QueryString["category"];
            string idnews = HttpContext.Current.Request.QueryString["news"];
            string page = HttpContext.Current.Request.QueryString["p"].ToString();
            if (idcategory == null)
                idcategory = "0";
            if (idnews != null)
                idcategory = GetCategoryFromNews(idnews);
            String[] categories = new String[20];
            int i = 0;

            while (idcategory != "0")
            {
                categories[i] = idcategory;
                idcategory = GetIdFather(idcategory);
                i = i + 1;
            }
            i = i - 1;
            while (i >= 0)
            {
                string strConn = ConfigurationManager.ConnectionStrings["anmcs"].ToString();
                SqlConnection myConnection = new SqlConnection(strConn);
                SqlCommand myCommand = new SqlCommand("anm_getCategoriesById", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                myCommand.Parameters.Add("@idcategory", SqlDbType.Int).Value = categories[i];
                myConnection.Open();
                SqlDataReader reader = myCommand.ExecuteReader();

                string cat = "";
                string url = "";
                while (reader.Read())
                {
                    cat = reader["category"].ToString();
                    url = reader["url"].ToString();
                }
                myConnection.Close();

                if (url == "" || url == null)
                    navigation += "<a href='" + path + "/category" + categories[i] + ".aspx'>" + cat + "</a> &gt; ";
                else
                    navigation += "<a href='" + url + "'>" + cat + "</a> &gt; ";
                i = i - 1;
            }
            if (HttpContext.Current.Request.QueryString["month"] != null)
                navigation += SetLongMonth(Convert.ToInt32(HttpContext.Current.Request.QueryString["month"].ToString())) + " " + HttpContext.Current.Request.QueryString["year"].ToString();
            return navigation;
        }
        public String HomeSlideshow()
        {
            string strConn = ConfigurationManager.ConnectionStrings["anmcs"].ToString();
            SqlConnection myConnection = new SqlConnection(strConn);
            SqlCommand myCommand = new SqlCommand("anm_showSlideshowNews", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;
            myConnection.Open();
            SqlDataReader reader = myCommand.ExecuteReader();
            string path = anm_Utility.GetWebAppRoot();
            string slideshow = "<div id='slideShow'><div id='slideShowItems'>";
            string title = "";
            string text = "";
            string image = "";
            anm_Utility ut = new anm_Utility();
            while (reader.Read())
            {
                text = reader["summary"].ToString(); 
                title = reader["title"].ToString();
                image = reader["image"].ToString();
                if (text.Length < 9)
                {
                    text = reader["news"].ToString();
                    if (image != "")
                        slideshow += "<div><a href='" + path + "/articles/" + reader["idnews"].ToString() + "/" + ut.RemoveNonAlfaNumeric(title) + ".aspx'><img alt='" + title + "' src='images/" + reader["image"].ToString() + "'/></a> <h2>&nbsp;<a href='" + path + "/articles/" + reader["idnews"].ToString() + "/" + ut.RemoveNonAlfaNumeric(title) + ".aspx'>" + title + "</a></h2> <p>" + text + "</p></div>";
                    else
                        slideshow += "<div><h2>&nbsp;<a href='" + path + "/articles/" + reader["idnews"].ToString() + "/" + ut.RemoveNonAlfaNumeric(title) + ".aspx'>" + title + "</a></h2> <p>" + text + "</p></div>";
                }
                else
                {
                    if (image != "")
                        slideshow += "<div><a href='" + path + "/articles/" + reader["idnews"].ToString() + "/" + ut.RemoveNonAlfaNumeric(title) + ".aspx'><img alt='" + title + "' src='images/" + reader["image"].ToString() + "'/></a> <h2>&nbsp;<a href='" + path + "/articles/" + reader["idnews"].ToString() + "/" + ut.RemoveNonAlfaNumeric(title) + ".aspx'>" + title + "</a></h2> <p>" + text + " <br /><a href='" + anm_Utility.GetWebAppRoot() + "/articles/" + reader["idnews"].ToString() + "/" + ut.RemoveNonAlfaNumeric(title) + ".aspx'>" + HttpContext.GetGlobalResourceObject("language", "Readfullarticle") + "</a></p></div>";
                    else
                        slideshow += "<div><h2>&nbsp;<a href='" + path + "/articles/" + reader["idnews"].ToString() + "/" + ut.RemoveNonAlfaNumeric(title) + ".aspx'>" + title + "</a></h2> <p>" + text + " <br /><a href='" + anm_Utility.GetWebAppRoot() + "/articles/" + reader["idnews"].ToString() + "/" + ut.RemoveNonAlfaNumeric(title) + ".aspx'>" + HttpContext.GetGlobalResourceObject("language", "Readfullarticle") + "</a></p></div>";
                }
            }
            myConnection.Close();
            if (slideshow != "<div id='slideShow'><div id='slideShowItems'>")
                return slideshow + "</div></div>";
            else
                return "";
        }
        public String GetFooterMenu()
        {
            string strConn = ConfigurationManager.ConnectionStrings["anmcs"].ToString();
            SqlConnection myConnection = new SqlConnection(strConn);
            SqlCommand myCommand = new SqlCommand("anm_getMainCategories", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;
            myConnection.Open();
            SqlDataReader reader = myCommand.ExecuteReader();
            string path = anm_Utility.GetWebAppRoot();
            string page = HttpContext.Current.Request.QueryString["p"].ToString(); 
            string menu = "";
            string url = "";
            while (reader.Read())
            {
                url = reader["url"].ToString();
                if (url == "" || url == null)
                    menu += "<a href='" + path + "/category" + reader["idcategory"].ToString() + ".aspx'>" + reader["category"].ToString() + "</a> | ";
                else
                    menu += "<a href='" + url + "'>" + reader["category"].ToString() + "</a> | ";
            }
            myConnection.Close();
            return menu;
        }
        public String GetSideMenu()
        {
            string apppath = anm_Utility.GetWebAppRoot();
            string strConn = ConfigurationManager.ConnectionStrings["anmcs"].ToString();
            SqlConnection myConnection = new SqlConnection(strConn);
            SqlCommand myCommand = new SqlCommand("anm_getMainCategories", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;
            myConnection.Open();
            SqlDataReader reader = myCommand.ExecuteReader();
            string url = "";
            string menu = "<h2>" + HttpContext.GetGlobalResourceObject("language", "Menu") + "</h2><div class='sp'><ul>";
            while (reader.Read())
            {
                url = reader["url"].ToString();
                if (url == "" || url == null)
                    menu += "<li><a href='" + apppath + "/subscribe/" + reader["idcategory"].ToString() + ".aspx'><img src='" + apppath + "/images/rssicon.gif' alt='rss' style='border: none;' /></a> <strong><a href='" + apppath + "/category" + reader["idcategory"].ToString() + ".aspx'>" + reader["category"].ToString() + "</a></strong></li>";
                else
                    menu += "<li>&nbsp;&nbsp;&nbsp; <strong><a href='" + url + "'>" + reader["category"].ToString() + "</a></strong></li>";
            }
            menu += "</ul></div>";
            myConnection.Close();
            return menu;
        }
        public String GetSearch()
        {
            return "<li><h2>Search</h2><asp:TextBox ID='txtSearch' runat='server'></asp:TextBox> <asp:Button ID='Button1' runat='server' Text='Search' onclick='Button1_Click' BackColor='#006699' ForeColor='#dddddd' BorderWidth='2' BorderColor='#006699' /></li>";
        }
        public String GetArchiveMenu(int InitialYear, int InitialMonth)
        {
            string menu = "";
            int currentYear = Convert.ToInt32(DateTime.Now.Year.ToString());
            int currentMonth = Convert.ToInt32(DateTime.Now.Month.ToString());
            int i, j;
            int nart = 0;
            string viewart = GetSetting("ViewNarticles");
            string path = anm_Utility.GetWebAppRoot();
            menu += "<strong>" + currentYear + "</strong>" + "<br/>";
            if (currentYear == InitialYear)
            {
                for (i = currentMonth; i >= InitialMonth; i--)
                {
                    if (viewart == "True")
                    {
                        nart = GetNumberArticles(i, currentYear);
                        if (nart != 0)
                            menu += " - <a href='" + path + "/year_" + currentYear + "/month_" + i + ".aspx'>" + SetMonth(i) + " (" + nart + ")" + "</a>";
                    }
                    else
                        menu += " - <a href='" + path + "/year_" + currentYear + "/month_" + i + ".aspx'>" + SetMonth(i) + "</a>";
                }
            }
            else
            {
                for (i = currentMonth; i > 0; i--)
                {
                    if (viewart == "True")
                    {
                        nart = GetNumberArticles(i, currentYear);
                        if (nart != 0)
                            menu += " - <a href='" + path + "/year_" + currentYear + "/month_" + i + ".aspx'>" + SetMonth(i) + " (" + nart + ")" + "</a>";
                    }
                    else
                        menu += " - <a href='" + path + "/year_" + currentYear + "/month_" + i + ".aspx'>" + SetMonth(i) + "</a>";
                }
            }
            menu += "<br />";
            for (j = currentYear - 1; j >= InitialYear; j--)
            {
                menu += "<strong>" + j + "</strong>" + "<br/>";
                if (j == InitialYear)
                {
                    for (i = 12; i >= InitialMonth; i--)
                    {
                        //if (i %2 != 0)
                        //    menu += " - <a href='" + path + "?p=allnews&amp;year=" + j + "&amp;month=" + i + "'>" + SetMonth(i) + "</a>";
                        //else
                        if (viewart == "True")
                        {
                            nart = GetNumberArticles(i, j);
                            if (nart != 0)
                                menu += " - <a href='" + path + "/year_" + j + "/month_" + i + ".aspx'>" + SetMonth(i) + " (" + nart + ")" + "</a>";
                        }
                        else
                            menu += " - <a href='" + path + "/year_" + j + "/month_" + i + ".aspx'>" + SetMonth(i) + "</a>";
                    }
                }
                else
                {
                    for (i = 12; i > 0; i--)
                    {
                        if (viewart == "True")
                        {
                            nart = GetNumberArticles(i, j);
                            if (nart != 0)
                                menu += " - <a href='" + path + "/year_" + j + "/month_" + i + ".aspx'>" + SetMonth(i) + " (" + nart + ")" + "</a>";
                        }
                        else
                            menu += " - <a href='" + path + "/year_" + j + "/month_" + i + ".aspx'>" + SetMonth(i) + "</a>";
                    }
                    menu += "<br />";
                }
            }
            return menu;
        }
        public String GetArchiveMenu(int InitialYear, int InitialMonth, int category)
        {
            string menu = "";
            int currentYear = Convert.ToInt32(DateTime.Now.Year.ToString());
            int currentMonth = Convert.ToInt32(DateTime.Now.Month.ToString());
            int i, j;
            int nart = 0;
            string viewart = GetSetting("ViewNarticles");
            string path = anm_Utility.GetWebAppRoot();
            menu += "<strong>" + currentYear + "</strong>" + "<br />";
            if (currentYear == InitialYear)
            {
                for (i = currentMonth; i >= InitialMonth; i--)
                {
                    if (viewart == "True")
                    {
                        nart = GetNumberArticles(i, currentYear, category);
                        if (nart != 0)
                            menu += " - <a href='" + path + "/month_" + i + "/year_" + currentYear + "/category" + category + ".aspx'>" + SetMonth(i) + " (" + nart + ")" + "</a>";
                    }
                    else
                        menu += " - <a href='" + path + "/month_" + i + "/year_" + currentYear + "/category" + category + ".aspx'>" + SetMonth(i) + "</a>";
                }
            }
            else
            {
                for (i = currentMonth; i > 0; i--)
                {
                    if (viewart == "True")
                    {
                        nart = GetNumberArticles(i, currentYear, category);
                        if (nart != 0)
                            menu += " - <a href='" + path + "/month_" + i + "/year_" + currentYear + "/category" + category + ".aspx'>" + SetMonth(i) + " (" + nart + ")" + "</a>";
                    }
                    else
                        menu += " - <a href='" + path + "/month_" + i + "/year_" + currentYear + "/category" + category + ".aspx'>" + SetMonth(i) + "</a>";
                }
            }
            menu += "<br />";
            for (j = currentYear - 1; j >= InitialYear; j--)
            {
                menu += "<strong>" + j + "</strong>" + "<br />";
                if (j == InitialYear)
                {
                    for (i = 12; i >= InitialMonth; i--)
                    {
                        //if (i %2 != 0)
                        //    menu += " - <a href='" + path + "?p=allnews&amp;year=" + j + "&amp;month=" + i + "'>" + SetMonth(i) + "</a>";
                        //else
                        if (viewart == "True")
                        {
                            nart = GetNumberArticles(i, j, category);
                            if (nart != 0)
                                menu += " - <a href='" + path + "/month_" + i + "/year_" + currentYear + "/category" + category + ".aspx'>" + SetMonth(i) + " (" + nart + ")" + "</a>";
                        }
                        else
                            menu += " - <a href='" + path + "/month_" + i + "/year_" + currentYear + "/category" + category + ".aspx'>" + SetMonth(i) + "</a>";
                    }
                }
                else
                {
                    for (i = 12; i > 0; i--)
                    {
                        if (viewart == "True")
                        {
                            nart = GetNumberArticles(i, j, category);
                            if (nart != 0)
                                menu += " - <a href='" + path + "/month_" + i + "/year_" + currentYear + "/category" + category + ".aspx'>" + SetMonth(i) + " (" + nart + ")" + "</a>";
                        }
                        else
                            menu += " - <a href='" + path + "/month_" + i + "/year_" + currentYear + "/category" + category + ".aspx'>" + SetMonth(i) + "</a>";
                    }
                    menu += "<br />";
                }
            }

            return menu;
        }
        public string SetMonth(int value)
        {
            string month = "";
            if (value == 1)
                month = HttpContext.GetGlobalResourceObject("language", "Jan").ToString();
            if (value == 2)
                month = HttpContext.GetGlobalResourceObject("language", "Feb").ToString();
            if (value == 3)
                month = HttpContext.GetGlobalResourceObject("language", "Mar").ToString();
            if (value == 4)
                month = HttpContext.GetGlobalResourceObject("language", "Apr").ToString();
            if (value == 5)
                month = HttpContext.GetGlobalResourceObject("language", "May2").ToString();
            if (value == 6)
                month = HttpContext.GetGlobalResourceObject("language", "Jun").ToString();
            if (value == 7)
                month = HttpContext.GetGlobalResourceObject("language", "Jul").ToString();
            if (value == 8)
                month = HttpContext.GetGlobalResourceObject("language", "Aug").ToString();
            if (value == 9)
                month = HttpContext.GetGlobalResourceObject("language", "Sep").ToString();
            if (value == 10)
                month = HttpContext.GetGlobalResourceObject("language", "Oct").ToString();
            if (value == 11)
                month = HttpContext.GetGlobalResourceObject("language", "Nov").ToString();
            if (value == 12)
                month = HttpContext.GetGlobalResourceObject("language", "Dec").ToString();
            return month;
        }
        public string SetLongMonth(int value)
        {
            string month = "";
            if (value == 1)
                month = HttpContext.GetGlobalResourceObject("language", "January").ToString();
            if (value == 2)
                month = HttpContext.GetGlobalResourceObject("language", "February").ToString();
            if (value == 3)
                month = HttpContext.GetGlobalResourceObject("language", "March").ToString();
            if (value == 4)
                month = HttpContext.GetGlobalResourceObject("language", "April").ToString();
            if (value == 5)
                month = HttpContext.GetGlobalResourceObject("language", "May").ToString();
            if (value == 6)
                month = HttpContext.GetGlobalResourceObject("language", "June").ToString();
            if (value == 7)
                month = HttpContext.GetGlobalResourceObject("language", "July").ToString();
            if (value == 8)
                month = HttpContext.GetGlobalResourceObject("language", "August").ToString();
            if (value == 9)
                month = HttpContext.GetGlobalResourceObject("language", "September").ToString();
            if (value == 10)
                month = HttpContext.GetGlobalResourceObject("language", "October").ToString();
            if (value == 11)
                month = HttpContext.GetGlobalResourceObject("language", "November").ToString();
            if (value == 12)
                month = HttpContext.GetGlobalResourceObject("language", "December").ToString();
            return month;
        }
        public bool ActivateUser(String userID)
        {
            /*
            Guid gd = new Guid(userID);
            String[] Activation = new String[2];
            MembershipUser user = Membership.GetUser(gd);
            user.IsApproved = true;
            Roles.AddUserToRole(user.ToString(), "Confirmed");
            Membership.UpdateUser(user);
            Activation[1] = user.UserName;
            Activation[2] = user.CreationDate.ToShortDateString();
            if (user.IsApproved)
            {
                Activation[0] = "Activated";
            }
            else
            {
                Activation[0] = "Waiting for Confirm";
            }
            return Activation;
             */
            bool activation = false;
            try
            {
                string strConn = ConfigurationManager.ConnectionStrings["anmcs"].ToString();
                SqlConnection myConnection = new SqlConnection(strConn);
                SqlCommand myCommand = new SqlCommand();
                myCommand.Connection = myConnection;
                myConnection.Open();

                myCommand.Parameters.Add(
                   "@UserID", SqlDbType.NChar).Value = userID;
                myCommand.CommandText = "UPDATE aspnet_Membership SET IsApproved = 'True' WHERE UserID = @UserId";
                object accountNumber = myCommand.ExecuteScalar();

                myConnection.Close();
                activation = true;
            }
            catch
            {
            }
            return activation;

        }

        public void UpdateUser()
        {
            MembershipUser currentUser = Membership.GetUser();
            if (currentUser != null)
            {
                currentUser.LastActivityDate = DateTime.Now;
                Membership.UpdateUser(currentUser);
            }
        }
        public void AddCategory(String cat_name, int fathercategory, int ordercat, string idrootcat)
        {
            string strConn = ConfigurationManager.ConnectionStrings["anmcs"].ToString();
            SqlConnection conn = new SqlConnection(strConn);
            SqlCommand command = new SqlCommand("anm_InsertCategory", conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@category", SqlDbType.NVarChar).Value = cat_name;
            command.Parameters.Add("@idfather", SqlDbType.Int).Value = fathercategory;
            command.Parameters.Add("@ordercat", SqlDbType.Int).Value = ordercat;
            command.Parameters.Add("@idrootcat", SqlDbType.Int).Value = idrootcat; 
            conn.Open();
            command.ExecuteNonQuery();
            conn.Close();
        }
        public int GetOrderCat(int idfather)
        {
            string strConn = ConfigurationManager.ConnectionStrings["anmcs"].ToString();
            SqlConnection myConnection = new SqlConnection(strConn);
            SqlCommand myCommand = new SqlCommand();
            myCommand.Connection = myConnection;
            myConnection.Open();
            if (idfather != 0)
            {
                myCommand.Parameters.Add("@idcategory", SqlDbType.NVarChar).Value = idfather;
                myCommand.CommandText = "SELECT COUNT(*) FROM anm_Categories WHERE idfather=@idcategory";
            }
            else
            {
                myCommand.CommandText = "SELECT COUNT(*) FROM anm_Categories WHERE idfather=0";
            }
            Int32 subcategories = (Int32)myCommand.ExecuteScalar();
            myConnection.Close();
            return subcategories;
        }
		public void AddTemplate(string template_name, string template_author, string site_author)
        {
            string strConn = ConfigurationManager.ConnectionStrings["anmcs"].ToString();
            SqlConnection conn = new SqlConnection(strConn);
            SqlCommand command = new SqlCommand("anm_InsertTemplate", conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@name", SqlDbType.NVarChar).Value = template_name;
            command.Parameters.Add("@author", SqlDbType.NVarChar).Value = template_author;
            command.Parameters.Add("@siteauthor", SqlDbType.NVarChar).Value = site_author;
            conn.Open();
            int rows = command.ExecuteNonQuery();
            conn.Close();
        }
        public void AddAuthor(String author_name, String role)
        {
            try
            {
                string strConn = ConfigurationManager.ConnectionStrings["anmcs"].ToString();
                SqlConnection conn = new SqlConnection(strConn);
                SqlCommand command = new SqlCommand("anm_InsertAuthor", conn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@author", SqlDbType.NVarChar).Value = author_name;
                command.Parameters.Add("@role", SqlDbType.NVarChar).Value = role;
                conn.Open();
                int rows = command.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void AddArticle(String title, String author, String filename, String summary, String news, String category, bool comments, bool approve, bool highlight, bool sidenews, bool postedby, string tags, bool homeslide)
        {
            try
            {
                string strConn = ConfigurationManager.ConnectionStrings["anmcs"].ToString();
                SqlConnection conn = new SqlConnection(strConn);
                SqlCommand command = new SqlCommand("anm_InsertArticle", conn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@title", SqlDbType.NVarChar).Value = title;
                command.Parameters.Add("@author", SqlDbType.NVarChar).Value = author;
                command.Parameters.Add("@image", SqlDbType.NVarChar).Value = filename;
                command.Parameters.Add("@summary", SqlDbType.NText).Value = HttpUtility.HtmlDecode(summary);
                command.Parameters.Add("@news", SqlDbType.NText).Value = HttpUtility.HtmlDecode(news);
                command.Parameters.Add("@idcategory", SqlDbType.Int).Value = Convert.ToInt32(category);
                command.Parameters.Add("@comments", SqlDbType.Int).Value = 0;
                command.Parameters.Add("@commentcheck", SqlDbType.Bit).Value = comments;
                command.Parameters.Add("@published", SqlDbType.Bit).Value = approve;
                command.Parameters.Add("@highlight", SqlDbType.Bit).Value = highlight;
                command.Parameters.Add("@sidenews", SqlDbType.Bit).Value = sidenews;
                command.Parameters.Add("@postedby", SqlDbType.Bit).Value = postedby;
                command.Parameters.Add("@tags", SqlDbType.NVarChar).Value = tags;
                command.Parameters.Add("@homeslide", SqlDbType.Bit).Value = homeslide;
                conn.Open();
                int rows = command.ExecuteNonQuery();
                conn.Close();
            }
            catch
            {
            }
        }
        public void EditArticle(String idnews, String title, String author, String filename, String summary, String news, String category, bool comments, bool published, bool highlight, bool sidenews, bool postedby, DateTime date, string tags, bool homeslide)
        {
            string strConn = ConfigurationManager.ConnectionStrings["anmcs"].ToString();
            SqlConnection conn = new SqlConnection(strConn);
            SqlCommand command = new SqlCommand("anm_UpdateArticle", conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@idnews", SqlDbType.VarChar).Value = idnews;
            command.Parameters.Add("@title", SqlDbType.NVarChar).Value = title;
            command.Parameters.Add("@image", SqlDbType.NVarChar).Value = filename;
            command.Parameters.Add("@summary", SqlDbType.NText).Value = HttpUtility.HtmlDecode(summary);
            command.Parameters.Add("@news", SqlDbType.NText).Value = HttpUtility.HtmlDecode(news);
            command.Parameters.Add("@idcategory", SqlDbType.Int).Value = Convert.ToInt32(category);
            command.Parameters.Add("@commentcheck", SqlDbType.Bit).Value = comments;
            command.Parameters.Add("@published", SqlDbType.Bit).Value = published;
            command.Parameters.Add("@highlight", SqlDbType.Bit).Value = highlight;
            command.Parameters.Add("@sidenews", SqlDbType.Bit).Value = sidenews;
            command.Parameters.Add("@postedby", SqlDbType.Bit).Value = postedby;
            command.Parameters.Add("@date", SqlDbType.DateTime).Value = date;
            command.Parameters.Add("@tags", SqlDbType.NVarChar).Value = tags;
            command.Parameters.Add("@homeslide", SqlDbType.Bit).Value = homeslide;
            conn.Open();
            command.ExecuteNonQuery();
            conn.Close();
        }
        public void DeleteArticle(String idnews)
        {
            string strConn = ConfigurationManager.ConnectionStrings["anmcs"].ToString();
            SqlConnection conn = new SqlConnection(strConn);
            SqlCommand command = new SqlCommand("anm_DeleteNews", conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@idnews", SqlDbType.VarChar).Value = idnews;
            conn.Open();
            command.ExecuteNonQuery();
            conn.Close();
        }
        public void ApproveNews(string idnews)
        {
            string strConn = ConfigurationManager.ConnectionStrings["anmcs"].ToString();
            SqlConnection conn = new SqlConnection(strConn);
            SqlCommand command = new SqlCommand("anm_ApproveNews", conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@idnews", SqlDbType.VarChar).Value = idnews;
            conn.Open();
            int rows = command.ExecuteNonQuery();
            conn.Close();
        }
        public void AllowComments(string idnews)
        {
            string strConn = ConfigurationManager.ConnectionStrings["anmcs"].ToString();
            SqlConnection conn = new SqlConnection(strConn);
            SqlCommand command = new SqlCommand("anm_AllowComments", conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@idnews", SqlDbType.VarChar).Value = idnews;
            conn.Open();
            int rows = command.ExecuteNonQuery();
            conn.Close();
        }
        public void ApproveComment(string idc, string value)
        {
            string strConn = ConfigurationManager.ConnectionStrings["anmcs"].ToString();
            SqlConnection conn = new SqlConnection(strConn);
            SqlCommand command = new SqlCommand("anm_ApproveComment", conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@idcomment", SqlDbType.VarChar).Value = idc;
            command.Parameters.Add("@approved", SqlDbType.VarChar).Value = value;
            conn.Open();
            int rows = command.ExecuteNonQuery();
            conn.Close();
        }
        public void IcreaseComments(string idn, int nc)
        {
            string strConn = ConfigurationManager.ConnectionStrings["anmcs"].ToString();
            SqlConnection conn = new SqlConnection(strConn);
            SqlCommand command = new SqlCommand("anm_IncreaseComments", conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@idnews", SqlDbType.VarChar).Value = idn;
            command.Parameters.Add("@comments", SqlDbType.VarChar).Value = nc;
            conn.Open();
            int rows = command.ExecuteNonQuery();
            conn.Close();
        }
        protected Boolean IsAdmin()
        {
            Boolean isadmin = false;
            try
            {
                if (HttpContext.Current.Request.IsAuthenticated)
                {
                    MembershipUser user = Membership.GetUser();
                    anm_Utility ut = new anm_Utility();
                    string role = ut.GetRole(user.UserName);
                    if (role == "1")
                        isadmin = true;
                }
            }
            catch
            {
                isadmin = false;
            }
            return isadmin;
        }
        public int GetNumberComments(string idnews)
        {
            Int32 comments = 0;
            if (HttpContext.Current.Cache["numcom" + idnews] != null && !IsAdmin())
            {
                comments = Convert.ToInt32(HttpContext.Current.Cache["numcom" + idnews].ToString());
            }
            else
            {
                string strConn = ConfigurationManager.ConnectionStrings["anmcs"].ToString();
                SqlConnection myConnection = new SqlConnection(strConn);
                SqlCommand myCommand = new SqlCommand();
                myCommand.Connection = myConnection;
                myConnection.Open();
                myCommand.CommandText = "SELECT COUNT(*) FROM anm_Comments WHERE anm_Comments.idnews = '" + idnews + "'AND approved='True'";
                comments = (Int32)myCommand.ExecuteScalar();
                myConnection.Close();
                HttpContext.Current.Cache.Insert("numcom" + idnews, comments, null, DateTime.Now.AddMinutes(1), TimeSpan.Zero);
            }
            return comments;
        }
        public int GetNumberSearchResults(string searchquery)
        {
            int nres = 0;
            try
            {
                string strConn = ConfigurationManager.ConnectionStrings["anmcs"].ToString();
                SqlConnection myConnection = new SqlConnection(strConn);
                SqlCommand myCommand = new SqlCommand();
                myCommand.Connection = myConnection;
                myConnection.Open();
                myCommand.CommandText = searchquery;
                nres = (Int32)myCommand.ExecuteScalar();
                myConnection.Close();
            }
            catch
            {
            }
            return nres;
        }
        public int GetNumberArticles(int month, int year)
        {
            Int32 articles = 0;
            if (HttpContext.Current.Cache["nart" + month + "_" + year] != null && !IsAdmin())
            {
                articles = Convert.ToInt32(HttpContext.Current.Cache["nart" + month + "_" + year].ToString());
            }
            else
            {
                string strConn = ConfigurationManager.ConnectionStrings["anmcs"].ToString();
                SqlConnection myConnection = new SqlConnection(strConn);
                SqlCommand myCommand = new SqlCommand();
                myCommand.Connection = myConnection;
                myConnection.Open();
                myCommand.CommandText = "SELECT COUNT(*) FROM anm_News WHERE published='True' AND DATEPART(year,date)=" + year + " AND DATEPART(month,date)=" + month + " AND date<GETDATE()";
                articles = (Int32)myCommand.ExecuteScalar();
                myConnection.Close();
                HttpContext.Current.Cache.Insert("nart" + month + "_" + year, articles, null, DateTime.Now.AddMinutes(30), TimeSpan.Zero);
            }
            return articles;
        }
        public int GetNumberArticles(int month, int year, int category)
        {
            Int32 articles = 0;
            if (HttpContext.Current.Cache["nartcat" + month + "_" + year + "_" + category] != null && !IsAdmin())
            {
                articles = Convert.ToInt32(HttpContext.Current.Cache["nartcat" + month + "_" + year + "_" + category].ToString());
            }
            else
            {
                string strConn = ConfigurationManager.ConnectionStrings["anmcs"].ToString();
                SqlConnection myConnection = new SqlConnection(strConn);
                SqlCommand myCommand = new SqlCommand();
                myCommand.Connection = myConnection;
                myConnection.Open();
                myCommand.CommandText = "SELECT COUNT(*) FROM anm_News,anm_Categories WHERE anm_News.idcategory = anm_Categories.idcategory and (anm_News.idcategory='" + category + "' or anm_Categories.idrootcat='" + category + "' or anm_Categories.idfather='" + category + "') AND published='True' AND DATEPART(year,date)=" + year + " AND DATEPART(month,date)=" + month + "";
                articles = (Int32)myCommand.ExecuteScalar();
                myConnection.Close();
                HttpContext.Current.Cache.Insert("nartcat" + month + "_" + year + "_" + category, articles, null, DateTime.Now.AddMinutes(30), TimeSpan.Zero);
            }
            return articles;
        }
        public int GetNumberArticle(int month, int year)
        {
            Int32 articles = 0;
            if (HttpContext.Current.Cache[month + "_" + year] != null && !IsAdmin())
            {
                articles = Convert.ToInt32(HttpContext.Current.Cache[month + "_" + year].ToString());
            }
            else
            {
                string strConn = ConfigurationManager.ConnectionStrings["anmcs"].ToString();
                SqlConnection myConnection = new SqlConnection(strConn);
                SqlCommand myCommand = new SqlCommand();
                myCommand.Connection = myConnection;
                myConnection.Open();
                myCommand.CommandText = "SELECT COUNT(*) FROM anm_News WHERE published='True' AND DATEPART(year,date)=" + year + " AND DATEPART(month,date)=" + month + " AND date<GETDATE() and sidenews='false' and highlight='false'";
                articles = (Int32)myCommand.ExecuteScalar();
                myConnection.Close();
                HttpContext.Current.Cache.Insert(month + "_" + year, articles, null, DateTime.Now.AddMinutes(30), TimeSpan.Zero);
            }
            return articles;
        }
        public int GetNumberArticle(int month, int year, int category)
        {
            Int32 articles = 0;
            if (HttpContext.Current.Cache[month + "_" + year + "_" + category] != null && !IsAdmin())
            {
                articles = Convert.ToInt32(HttpContext.Current.Cache[month + "_" + year + "_" + category].ToString());
            }
            else
            {
                string strConn = ConfigurationManager.ConnectionStrings["anmcs"].ToString();
                SqlConnection myConnection = new SqlConnection(strConn);
                SqlCommand myCommand = new SqlCommand();
                myCommand.Connection = myConnection;
                myConnection.Open();
                myCommand.CommandText = "SELECT COUNT(*) FROM anm_News,anm_Categories WHERE anm_News.idcategory = anm_Categories.idcategory and (anm_News.idcategory='" + category + "' or anm_Categories.idrootcat='" + category + "' or anm_Categories.idfather='" + category + "') AND published='True' AND DATEPART(year,date)=" + year + " AND DATEPART(month,date)=" + month + " and sidenews='false' and highlight='false'";
                articles = (Int32)myCommand.ExecuteScalar();
                myConnection.Close();
                HttpContext.Current.Cache.Insert(month + "_" + year + "_" + category, articles, null, DateTime.Now.AddMinutes(30), TimeSpan.Zero);
            }
            return articles;
        }
        public int GetNumberArticles()
        {
            Int32 articles = 0;
            if (HttpContext.Current.Cache["maximumRows"] != null && !IsAdmin())
            {
                articles = Convert.ToInt32(HttpContext.Current.Cache["maximumRows"].ToString());
            }
            else
            {
                string strConn = ConfigurationManager.ConnectionStrings["anmcs"].ToString();
                SqlConnection myConnection = new SqlConnection(strConn);
                SqlCommand myCommand = new SqlCommand();
                myCommand.Connection = myConnection;
                myConnection.Open();
                myCommand.CommandText = "SELECT COUNT(*) FROM anm_News Where date<GETDATE() and published = 'true' and sidenews='false' and highlight='false'";
                articles = (Int32)myCommand.ExecuteScalar();
                myConnection.Close();
                HttpContext.Current.Cache.Insert("maximumRows", articles, null, DateTime.Now.AddMinutes(30), TimeSpan.Zero);
            }
            return articles;
        }
        public int GetNumberArticles(int category)
        {
            Int32 articles = 0;
            if (HttpContext.Current.Cache["numart" + category] != null && !IsAdmin())
            {
                articles = Convert.ToInt32(HttpContext.Current.Cache["numart" + category].ToString());
            }
            else
            {
                string strConn = ConfigurationManager.ConnectionStrings["anmcs"].ToString();
                SqlConnection myConnection = new SqlConnection(strConn);
                SqlCommand myCommand = new SqlCommand();
                myCommand.Connection = myConnection;
                myConnection.Open();
                myCommand.CommandText = "SELECT COUNT(*) FROM anm_News,anm_Categories WHERE anm_News.idcategory = anm_Categories.idcategory and (anm_News.idcategory='" + category + "' or anm_Categories.idrootcat='" + category + "' or anm_Categories.idfather='" + category + "') AND published='True' AND highlight='False' AND sidenews='False'";
                articles = (Int32)myCommand.ExecuteScalar();
                myConnection.Close();
                HttpContext.Current.Cache.Insert("numart" + category, articles, null, DateTime.Now.AddMinutes(30), TimeSpan.Zero);
            }
            return articles;
        }
        public int GetNumberArticles(string author)
        {
            Int32 articles = 0;
            if (HttpContext.Current.Cache["aut" + author] != null && !IsAdmin())
            {
                articles = Convert.ToInt32(HttpContext.Current.Cache["aut" + author].ToString());
            }
            else
            {
                string strConn = ConfigurationManager.ConnectionStrings["anmcs"].ToString();
                SqlConnection myConnection = new SqlConnection(strConn);
                SqlCommand myCommand = new SqlCommand();
                myCommand.Connection = myConnection;
                myConnection.Open();
                myCommand.CommandText = "SELECT COUNT(*) FROM anm_News WHERE anm_News.author = '" + author.Replace("'", "''") + "' AND published='True' AND highlight='False' AND sidenews='False'";
                articles = (Int32)myCommand.ExecuteScalar();
                myConnection.Close();
                HttpContext.Current.Cache.Insert("aut" + author, articles, null, DateTime.Now.AddMinutes(30), TimeSpan.Zero);
            }
            return articles;
        }
        public int GetNumberArticle(string tag)
        {
            Int32 articles = 0;
            if (HttpContext.Current.Cache["tag" + tag] != null && !IsAdmin())
            {
                articles = Convert.ToInt32(HttpContext.Current.Cache["tag" + tag].ToString());
            }
            else
            {
                string strConn = ConfigurationManager.ConnectionStrings["anmcs"].ToString();
                SqlConnection myConnection = new SqlConnection(strConn);
                SqlCommand myCommand = new SqlCommand();
                myCommand.Connection = myConnection;
                myConnection.Open();
                string value = tag.Replace("[", "[[]");
                value = value.Replace("%", "[%]");
                value = value.Replace("_", "[_]");
                myCommand.CommandText = "SELECT COUNT(*) FROM anm_News WHERE anm_News.tags LIKE '%" + value + "%' AND published='True' AND highlight='False' AND sidenews='False'";
                articles = (Int32)myCommand.ExecuteScalar();
                myConnection.Close();
                HttpContext.Current.Cache.Insert("tag" + tag, articles, null, DateTime.Now.AddMinutes(30), TimeSpan.Zero);
            }
            return articles;
        }
        public void GenerateImage(String PathOrig, String PathDest, int w, int h, String copyright, String PathLogo, String ImgFormat, String fontColorCopyright, String fontType, float fontSize, String positionCopyright)
        {
            Bitmap bitmap3 = new Bitmap(PathOrig);
            MemoryStream memStream = new MemoryStream();

            decimal width = bitmap3.Width;
            decimal height = bitmap3.Height;
            string familyName = fontType;
            string text = copyright;
            string logo = PathLogo;
            decimal maxWidth;
            decimal maxHeight;
            decimal NewW;
            decimal NewH;

            if (w == null || w<200 && w!=0)
                w = 200;

            if (w == 0 && h == 0)
            {
                maxWidth = width;
                maxHeight = height;
            }
            else
            {
                maxWidth = w;
                maxHeight = h;
                if (w == 0)
                {
                    maxWidth = 10000;
                }
                if (h == 0)
                {
                    maxHeight = 10000;
                }
            }

            if (width <= maxWidth)
            {
                NewW = width;
            }
            else
            {
                NewW = maxWidth;
            }

            NewH = height * NewW / width;
            if (NewH > maxHeight)
            {
                // Resize with height instead
                NewW = width * maxHeight / height;
                NewH = maxHeight;
            }

            int newwidth = Convert.ToInt32(NewW);
            int newheight = Convert.ToInt32(NewH);
            Bitmap bitmap = new Bitmap(bitmap3, new Size(newwidth, newheight));
            Graphics g = Graphics.FromImage(bitmap);
            g.SmoothingMode = SmoothingMode.AntiAlias;

            int xCopyright = newwidth - 120;
            int yCopyright = newheight - 20;
            if (positionCopyright == "br")
            {
                //xCopyright = xCopyright;
                //yCopyright = yCopyright;
            }
            else if (positionCopyright == "bl")
            {
                xCopyright = newwidth / 18;
                //if (newwidth < 400)
                //{
                    //xCopyright = 15;
                //    yCopyright = yCopyright - 10;
                //}
                yCopyright = newheight - (newheight / 10);
            }
            else if (positionCopyright == "tl")
            {
                if (newwidth < 400)
                {
                    xCopyright = 10;
                    yCopyright = 20;
                }
                else
                {
                    yCopyright = 50;
                    xCopyright = 40;
                }
            }
            else if (positionCopyright == "tr")
            {
                //xCopyright = xCopyright;
                if (newwidth < 400)
                {
                    yCopyright = 20;
                }
                else
                {
                    yCopyright = 50;
                }
            }
            Rectangle rect;
            Font font;
            int newfontsize = Convert.ToInt32(fontSize);
            if (fontSize == 0)
            {
                if (newwidth > newheight)
                    newfontsize = newheight / 20;
                else
                    newfontsize = newwidth / 20;
            }
            if (newfontsize < 8)
                newfontsize = 8;
			font = new Font(familyName, newfontsize, FontStyle.Bold);

            //if (newwidth < 400)
            //{
            //    rect = new Rectangle(xCopyright + 20, yCopyright + 7, 0, 0);
            //}
            //else
            //{
                rect = new Rectangle(xCopyright, yCopyright, 0, 0);
            //}
            StringFormat format = new StringFormat();
            format.Alignment = StringAlignment.Near;
            format.LineAlignment = StringAlignment.Near;
            GraphicsPath path = new GraphicsPath();
            path.AddString(text, font.FontFamily, (int)font.Style, font.Size, rect, format);

            HatchBrush hatchBrush = new HatchBrush(
                HatchStyle.LargeConfetti,
                Color.FromName(fontColorCopyright),
                Color.FromName(fontColorCopyright));
            g.FillPath(hatchBrush, path);

            if (logo == "")
            {
            }
            else
            {
                Bitmap bitmap2 = new Bitmap(logo);
                bitmap2.MakeTransparent();
                //if (newwidth < 400)
                //{
                //    g.DrawImage(bitmap2, xCopyright + 10, yCopyright - 15, 18, 18);
                //}
                //else
                //{
                //    g.DrawImage(bitmap2, xCopyright - 15, yCopyright - 40);
                //}
                    g.DrawImage(bitmap2, xCopyright, yCopyright);
            }


            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.ContentType = "image/" + ImgFormat;
            ImageFormat formato;

            if (ImgFormat == "jpeg")
            {
                formato = ImageFormat.Jpeg;
            }
            else if (ImgFormat == "gif")
            {
                formato = ImageFormat.Gif;
            }
            else if (ImgFormat == "bmp")
            {
                formato = ImageFormat.Bmp;
            }
            else if (ImgFormat == "icon")
            {
                formato = ImageFormat.Icon;
            }
            else if (ImgFormat == "png")
            {
                formato = ImageFormat.Png;
            }
            else if (ImgFormat == "tiff")
            {
                formato = ImageFormat.Tiff;
            }
            else
            {
                formato = ImageFormat.Jpeg;
            }

            //bitmap.Save(memStream, formato);

            bitmap3.Dispose();
            font.Dispose();
            hatchBrush.Dispose();
            g.Dispose();

            if (PathOrig == PathDest)
            {
                System.IO.File.Delete(PathOrig);
            }

            bitmap.Save(PathDest, formato);
            //memStream.WriteTo(HttpContext.Current.Response.OutputStream);
            bitmap.Dispose();

        }
        public string ConvertBBCodeToHTML(string str)
        {
            Regex exp;
            exp = new Regex(@"\[b\](.+?)\[/b\]");
            str = exp.Replace(str, "<strong>$1</strong>");
            exp = new Regex(@"\[i\](.+?)\[/i\]");
            str = exp.Replace(str, "<em>$1</em>");
            exp = new Regex(@"\[u\](.+?)\[/u\]");
            str = exp.Replace(str, "<u>$1</u>");
            exp = new Regex(@"\[s\](.+?)\[/s\]");
            str = exp.Replace(str, "<strike>$1</strike>");
            exp = new Regex(@"\[img\]([^\]]+)\[/img\]");
            str = exp.Replace(str, "<img src=\"$1\" alt='img' />");
            exp = new Regex(@"\[img\=([^\]]+)\]([^\]]+)\[/img\]");
            str = exp.Replace(str, "<img src=\"$1\" alt=\"$2\" />");
            exp = new Regex(@"\[url href=([^\]]*)\]([^\[]*)\[/url\]");
            str = exp.Replace(str, "<a href=\"$1\" target='_blank' rel='nofollow'>$2</a>");
            exp = new Regex(@"\[color\=([^\]]+)\]([^\]]+)\[/color\]");
            str = exp.Replace(str, "<font color=\"$1\">$2</font>");
            exp = new Regex(@"\[colour\=([^\]]+)\]([^\]]+)\[/colour\]");
            str = exp.Replace(str, "<font color=\"$1\">$2</font>");
            exp = new Regex(@"\[size\=([^\]]+)\]([^\]]+)\[/size\]");
            str = exp.Replace(str, "<font size=\"+$1\">$2</font>");
            exp = new Regex(@"\&lt;blockquote\&gt;(.+?)\&lt;/blockquote\&gt;");
            str = exp.Replace(str, "");
            exp = new Regex(@"\[QUOTE\=(.+?)\](.+?)\[/QUOTE\]");
            str = exp.Replace(str, "<blockquote><strong>$1 wrote</strong>:<br/>$2</blockquote>");
            exp = new Regex(@"\[QUOTE\](.+?)\[/QUOTE\]");
            str = exp.Replace(str, "<blockquote>$1</blockquote>");
            str = str.Replace("&lt;br /&gt;", "\n");
            str = str.Replace("\r\n", "<br />");
            str = str.Replace("\n", "<br />");
            str = str.Replace("</blockquote><br>", "</blockquote>");
            str = str.Replace("</blockquote><br />", "</blockquote>");
            return str;
        }
        public string RemoveNonAlfaNumeric(string text)
        {
            string res = text.Replace(" ","-");
            res = res.Replace("&amp;", "-");
            res = Regex.Replace(res, @"[^\w-]+", "-");
            res = res.Replace("---", "-");
            return res.Replace("--", "-");
        }
        public string FormatForXML(string text)
        {
            string data = text;
            data = data.Replace("&", "&amp;");
            data = data.Replace("\"", "&quot;");
            data = data.Replace("'", "&apos;");
            data = data.Replace("<", "&lt;");
            data = data.Replace(">", "&gt;");
            return data;
        }
        public string UrlEncode(string encode)
        {
            string Results = encode;
            Results = HttpUtility.UrlEncode(Results);
            Results = Results.Replace(">", "__3E");
            Results = Results.Replace("#", "__23");
            Results = Results.Replace("%", "__25");
            Results = Results.Replace("{", "__7B");
            Results = Results.Replace("}", "__7D");
            Results = Results.Replace("|", "__7C");
            int i = 92;
            char c = (char)i;
            Results = Results.Replace(new string(c,1), "__5C");
            Results = Results.Replace("^", "__5E");
            Results = Results.Replace("~", "__7E");
            Results = Results.Replace("[", "__5B");
            Results = Results.Replace("]", "__5D");
            Results = Results.Replace("`", "__60");
            Results = Results.Replace(";", "__3B");
            Results = Results.Replace("/", "__2F");
            Results = Results.Replace("?", "__3F");
            Results = Results.Replace(":", "__3A");
            Results = Results.Replace("@", "__40");
            Results = Results.Replace("=", "__3D");
            Results = Results.Replace("&", "__26");
            Results = Results.Replace("$", "__24");
            Results = Results.Replace("'", "__27");
            Results = Results.Replace("+", "__2B"); 
            Results = Results.Replace("+", " ");
            return Results;
        }
        public string UrlDecode(string decode)
        {
            string Results = decode;
            Results = Results.Replace("__3E", ">");
            Results = Results.Replace("__23", "#");
            Results = Results.Replace("__25", "%");
            Results = Results.Replace("__7B", "{");
            Results = Results.Replace("__7D", "}");
            Results = Results.Replace("__7C", "|");
            int i = 92;
            char c = (char)i;
            Results = Results.Replace("__5C", new string(c, 1));
            Results = Results.Replace("__5E", "^");
            Results = Results.Replace("__7E", "~");
            Results = Results.Replace("__5B", "[");
            Results = Results.Replace("__5D", "]");
            Results = Results.Replace("__60", "`");
            Results = Results.Replace("__3B", ";");
            Results = Results.Replace("__2F", "/");
            Results = Results.Replace("__3F", "?");
            Results = Results.Replace("__3A", ":");
            Results = Results.Replace("__40", "@");
            Results = Results.Replace("__3D", "=");
            Results = Results.Replace("__26", "&");
            Results = Results.Replace("__24", "$");
            Results = Results.Replace("__27", "'");
            Results = Results.Replace("__2B", "+");
            Results = HttpUtility.UrlDecode(Results);
            return Results;
        }
        public string GetRelativeTime(DateTime date)
        {
            TimeSpan s = DateTime.Now.Subtract(date);
            int dayDiff = (int)s.TotalDays;
            int secDiff = (int)s.TotalSeconds;
            if (dayDiff < 0 || dayDiff >= 31)
            {
                return date.ToShortDateString();
            }
            if (dayDiff == 0)
            {
                if (secDiff < 2)
                {
                    return "1 " + HttpContext.GetGlobalResourceObject("language", "second").ToString() + " " + HttpContext.GetGlobalResourceObject("language", "ago").ToString();
                }
                if (secDiff < 60)
                {
                    return secDiff + " " + HttpContext.GetGlobalResourceObject("language", "seconds").ToString() + " " + HttpContext.GetGlobalResourceObject("language", "ago").ToString();
                }
                if (secDiff < 120)
                {
                    return "1 " + HttpContext.GetGlobalResourceObject("language", "minute").ToString() + " " + HttpContext.GetGlobalResourceObject("language", "ago").ToString();
                }
                if (secDiff < 3600)
                {
                return string.Format("{0} " + HttpContext.GetGlobalResourceObject("language", "minutes").ToString() + " " + HttpContext.GetGlobalResourceObject("language", "ago").ToString(),
                    Math.Floor((double)secDiff / 60));
                }
                if (secDiff < 7200)
                {
                    return "1 " + HttpContext.GetGlobalResourceObject("language", "hour").ToString() + " " + HttpContext.GetGlobalResourceObject("language", "ago").ToString();
                }
                if (secDiff < 86400)
                {
                    return string.Format("{0} " + HttpContext.GetGlobalResourceObject("language", "hours").ToString() + " " + HttpContext.GetGlobalResourceObject("language", "ago").ToString(),
                    Math.Floor((double)secDiff / 3600));
                }
            }
            if (dayDiff == 1)
            {
                return HttpContext.GetGlobalResourceObject("language", "yesterday").ToString();
            }
            if (dayDiff < 31)
            {
                return string.Format("{0} " + HttpContext.GetGlobalResourceObject("language", "days").ToString() + " " + HttpContext.GetGlobalResourceObject("language", "ago").ToString(),
                dayDiff);
            }
            /*if (dayDiff < 31)
            {
                return string.Format("{0} weeks ago",
                Math.Ceiling((double)dayDiff / 7));
            }*/
            return null;
        }
        public static string GetWebAppRoot()
        {
            if (HttpContext.Current.Request.ApplicationPath == "/")
                return "http://" + HttpContext.Current.Request.Url.Host;
            else
                return "http://" + HttpContext.Current.Request.Url.Host + HttpContext.Current.Request.ApplicationPath;
        }
    }
}
