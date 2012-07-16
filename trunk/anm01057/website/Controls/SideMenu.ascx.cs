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

public partial class Controls_SideMenu : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }
    protected string ViewSideMenu()
    {
        anm_Utility ut = new anm_Utility();
        string category = "";
        if (Request.QueryString["news"] != null)
        {
            category = ut.GetCategoryFromNews(Request.QueryString["news"]);
        }
        if (Request.QueryString["category"] != null)
        {
            category = Request.QueryString["category"];
        }
        if (category == "")
        {
            string menu = "";
            if (ut.GetSetting("SideMenu") == "True")
                menu = ut.GetSideMenu();
            return menu;
        }
        else
        {
            string apath = anm_Utility.GetWebAppRoot();
            string idfather = ut.GetIdFather(category);
            String[] categories = new String[20];
            string res = "";
            int i = 1;
            categories[0] = category;
            while (!idfather.Equals("0"))
            {
                categories[i] = idfather;
                idfather = ut.GetIdFather(idfather);
                i++;
            }
            for (int j = 0; categories[j] != null; j++)
            {
                string cat = ut.GetCategory(categories[j]);
                string url = ut.GetCategoryUrl(categories[j]);
                if (url == "" || url == null)
                    res = "<li><a href='" + apath + "/subscribe/" + categories[j] + ".aspx'><img src='" + apath + "/images/rssicon.gif' alt='rss' style='border: none;' /></a> <strong><a href='" + apath + "/category" + categories[j] + ".aspx'>" + cat + "</a></strong></li>" + res;
                else
                    res = "<li>&nbsp;&nbsp;&nbsp; <strong><a href='" + url + "'>" + cat + "</a></strong></li>" + res;
            }
            string linksons = "";
            string strConn = ConfigurationManager.ConnectionStrings["anmcs"].ToString();
            SqlConnection myConnection = new SqlConnection(strConn);
            SqlCommand myCommand = new SqlCommand("anm_getSonCategories", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.Parameters.Add("@idcategory", SqlDbType.NVarChar).Value = category;
            myConnection.Open();
            SqlDataReader reader = myCommand.ExecuteReader();
            while (reader.Read())
            {
                string url = reader["url"].ToString();
                string idc = reader["idcategory"].ToString();
                string cat = reader["category"].ToString();
                if (url == "" || url == null)
                    linksons += "<li class='menulinksons'><a href='" + apath + "/subscribe/" + idc + ".aspx'><img src='" + apath + "/images/rssicon.gif' alt='rss' style='border: none;' /></a> <strong><a href='" + apath + "/category" + idc + ".aspx'>" + cat + "</a></strong></li>";
                else
                    linksons += "<li class='menulinksons'>&nbsp;&nbsp;&nbsp; <strong><a href='" + url + "'>" + cat + "</a></strong></li>";
            }
            myConnection.Close();
            if (linksons != "")
            {
                //res += "<ul class='menulinksons'>" + linksons + "</ul>";
                res += linksons;
            }

            if (ut.GetSetting("SideMenu") == "True")
                return "<h2>" + HttpContext.GetGlobalResourceObject("language", "Menu") + "</h2><div class='sp'><ul>" + res + "</ul></div>";
            else
                return "";
        }
    }
}
