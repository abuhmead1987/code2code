using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using anm_utility;

public partial class Controls_Archive : System.Web.UI.UserControl
{
    string apath = anm_Utility.GetWebAppRoot();
    string m = HttpContext.Current.Request.QueryString["month"].ToString();
    string y = HttpContext.Current.Request.QueryString["year"].ToString();
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
            if (Request.QueryString["month"] != null)
            {
                anm_Utility ut = new anm_Utility();
                if (Request.QueryString["category"] != null)
                {
                    GridView1.DataSourceID = "SqlDataSource9";
                    Page.Title = GetGlobalResourceObject("language", "ContentArchive").ToString() + " - " + GetGlobalResourceObject("language", "Year").ToString() + ": " + y + " - " + GetGlobalResourceObject("language", "Month").ToString() + ": " + ut.SetLongMonth(Convert.ToInt32(m)) + " - " + GetGlobalResourceObject("language", "Category").ToString() + ": " + ut.GetCategory(Request.QueryString["category"]) + " - " + ut.GetSetting("SiteName");
                    lblmeseanno.Text = GetGlobalResourceObject("language", "ContentArchive").ToString() + " - <i><b>" + GetGlobalResourceObject("language", "Year").ToString() + ": " + y + " - " + GetGlobalResourceObject("language", "Month").ToString() + ": " + ut.SetLongMonth(Convert.ToInt32(m)) + " - " + GetGlobalResourceObject("language", "Category").ToString() + ": " + ut.GetCategory(Request.QueryString["category"]) + "</b></i>";
                    DDcat.SelectedValue = Request.QueryString["category"];
                }
                else
                {
                    GridView1.DataSourceID = "SqlDataSource10";
                    Page.Title = GetGlobalResourceObject("language", "ContentArchive").ToString() + " - " + GetGlobalResourceObject("language", "Year").ToString() + ": " + y + " - " + GetGlobalResourceObject("language", "Month").ToString() + ": " + ut.SetLongMonth(Convert.ToInt32(m)) + " - " + ut.GetSetting("SiteName");
                    lblmeseanno.Text = GetGlobalResourceObject("language", "ContentArchive").ToString() + " - <i><b>" + GetGlobalResourceObject("language", "Year").ToString() + ": " + y + " - " + GetGlobalResourceObject("language", "Month").ToString() + ": " + ut.SetLongMonth(Convert.ToInt32(m)) + "</b></i>";
                }
            }
            else
                Response.Redirect(apath + "/archive/year_" + DateTime.Now.Year + "/month_" + DateTime.Now.Month);
        }
    }
    protected string LinkCat()
    {
        string strConn = ConfigurationManager.ConnectionStrings["anmcs"].ToString();
        SqlConnection myConnection = new SqlConnection(strConn);
        SqlCommand myCommand = new SqlCommand("anm_getCategories", myConnection);
        myCommand.CommandType = CommandType.StoredProcedure;
        myConnection.Open();
        SqlDataReader reader = myCommand.ExecuteReader();
        string res = "<br /> - ";
        while (reader.Read())
        {
            string idc = reader["idcategory"].ToString();
            string category = reader["category"].ToString();
            if (idc != Request.QueryString["category"])
                res += "<a href='" + apath + "/archive/month_"+m+"/year_"+y+"/category" + idc + ".aspx'>" + reader["category"].ToString() + "</a> - ";
            else
                res += "<b><u><a href='" + apath + "/archive/month_" + m + "/year_" + y + "/category" + idc + ".aspx'>" + reader["category"].ToString() + "</a></u></b> - ";
        }
        myConnection.Close();
        return res;
    }
    public String ViewDate(String date)
    {
        DateTime data = DateTime.Parse(date);
        return string.Format("{0}", data.ToString("f", System.Globalization.CultureInfo.CurrentCulture));
        //return TimeZoneInfo.ConvertTimeFromUtc(DateTime.Parse(date), TimeZoneInfo.Local).ToString();
    }
    protected string RNA(string text)
    {
        anm_Utility ut = new anm_Utility();
        return ut.RemoveNonAlfaNumeric(text);
    }
    public String GetArchiveMenu()
    {
        anm_Utility ut = new anm_Utility();
        string menu = "";
        int currentYear = Convert.ToInt32(DateTime.Now.Year.ToString());
        int currentMonth = Convert.ToInt32(DateTime.Now.Month.ToString());
        int i, j;
        int nart = 0;
        int InitialYear = Convert.ToInt32(ut.GetSetting("Year"));
        int InitialMonth = Convert.ToInt32(ut.GetSetting("Month"));
        int anno = Convert.ToInt32(Request.QueryString["year"].ToString());
        int mese = Convert.ToInt32(Request.QueryString["month"].ToString());
        int idcat = 0;
        if (Request.QueryString["category"] != null)
            idcat = Convert.ToInt32(Request.QueryString["category"]);
        menu += GetGlobalResourceObject("language", "ChangeMonth").ToString() + ":<br /> <strong>" + currentYear + "</strong>" + "<br /> ";
        if (currentYear == InitialYear)
        {
            for (i = currentMonth; i >= InitialMonth; i--)
            {
                if (Request.QueryString["category"] != null)
                {
                    nart = ut.GetNumberArticles(i, currentYear, idcat);
                    if (nart != 0)
                    {
                        string link = apath + "/archive/month_" + i + "/year_" + currentYear + "/category" + Request.QueryString["category"] + ".aspx";
                        if (anno == currentYear && mese == i)
                            menu += " - <b><u><a href='" + link + "'>" + ut.SetMonth(i) + " (" + nart + ")" + "</a></u></b>";
                        else
                            menu += " - <a href='" + link + "'>" + ut.SetMonth(i) + " (" + nart + ")" + "</a>";
                    }
                }
                else
                {
                    nart = ut.GetNumberArticles(i, currentYear);
                    if (nart != 0)
                    {
                        string link = apath + "/archive/year_" + currentYear + "/month_" + i + ".aspx";
                        if (anno == currentYear && mese == i)
                            menu += " - <b><u><a href='" + link + "'>" + ut.SetMonth(i) + " (" + nart + ")" + "</a></u></b>";
                        else
                            menu += " - <a href='" + link + "'>" + ut.SetMonth(i) + " (" + nart + ")" + "</a>";
                    }
                }
            }
        }
        else
        {
            if (Request.QueryString["category"] != null)
            {
                for (i = currentMonth; i > 0; i--)
                {
                    nart = ut.GetNumberArticles(i, currentYear, idcat);
                    if (nart != 0)
                    {
                        string link = apath + "/archive/month_" + i + "/year_" + currentYear + "/category" + Request.QueryString["category"] + ".aspx";
                        if (anno == currentYear && mese == i)
                            menu += " - <b><u><a href='" + link + "'>" + ut.SetMonth(i) + " (" + nart + ")" + "</a></u></b>";
                        else
                            menu += " - <a href='" + link + "'>" + ut.SetMonth(i) + " (" + nart + ")" + "</a>";
                    }
                }
            }
            else
            {
                for (i = currentMonth; i > 0; i--)
                {
                    nart = ut.GetNumberArticles(i, currentYear);
                    if (nart != 0)
                    {
                        string link = apath + "/archive/year_" + currentYear + "/month_" + i + ".aspx";
                        if (anno == currentYear && mese == i)
                            menu += " - <b><u><a href='" + link + "'>" + ut.SetMonth(i) + " (" + nart + ")" + "</a></u></b>";
                        else
                            menu += " - <a href='" + link + "'>" + ut.SetMonth(i) + " (" + nart + ")" + "</a>";
                    }
                }
            }
        }

        for (j = currentYear - 1; j >= InitialYear; j--)
        {
            menu += "<br/><strong>" + j + "</strong>" + "<br/>";
            if (j == InitialYear)
            {
                if (Request.QueryString["category"] != null)
                {
                    for (i = 12; i >= InitialMonth; i--)
                    {
                        nart = ut.GetNumberArticles(i, j, idcat);
                        if (nart != 0)
                        {
                            string link = apath + "/archive/month_" + i + "/year_" + j + "/category" + Request.QueryString["category"] + ".aspx";
                            if (anno == j && mese == i)
                                menu += " - <b><u><a href='" + link + "'>" + ut.SetMonth(i) + " (" + nart + ")" + "</a></u></b>";
                            else
                                menu += " - <a href='" + link + "'>" + ut.SetMonth(i) + " (" + nart + ")" + "</a>";
                        }
                    }
                }
                else
                {
                    for (i = 12; i >= InitialMonth; i--)
                    {
                        nart = ut.GetNumberArticles(i, j);
                        if (nart != 0)
                        {
                            string link = apath + "/archive/year_" + j + "/month_" + i + ".aspx";
                            if (anno == j && mese == i)
                                menu += " - <b><u><a href='" + link + "'>" + ut.SetMonth(i) + " (" + nart + ")" + "</a></u></b>";
                            else
                                menu += " - <a href='" + link + "'>" + ut.SetMonth(i) + " (" + nart + ")" + "</a>";
                        }
                    }
                }
            }
            else
            {
                if (Request.QueryString["category"] != null)
                {
                    for (i = 12; i > 0; i--)
                    {
                        nart = ut.GetNumberArticles(i, j, idcat);
                        if (nart != 0)
                        {
                            string link = apath + "/archive/month_" + i + "/year_" + j + "/category" + Request.QueryString["category"] + ".aspx";
                            if (anno == j && mese == i)
                                menu += " - <b><u><a href='" + link + "'>" + ut.SetMonth(i) + " (" + nart + ")" + "</a></u></b>";
                            else
                                menu += " - <a href='" + link + "'>" + ut.SetMonth(i) + " (" + nart + ")" + "</a>";
                        }
                    }
                }
                else
                {
                    for (i = 12; i > 0; i--)
                    {
                        nart = ut.GetNumberArticles(i, j);
                        if (nart != 0)
                        {
                            string link = apath + "/archive/year_" + j + "/month_" + i + ".aspx";
                            if (anno == j && mese == i)
                                menu += " - <b><u><a href='" + link + "'>" + ut.SetMonth(i) + " (" + nart + ")" + "</a></u></b>";
                            else
                                menu += " - <a href='" + link + "'>" + ut.SetMonth(i) + " (" + nart + ")" + "</a>";
                        }
                    }
                }
            }
        }
        return menu;
    }
    protected void ddcat_SelectedIndexChanged(object sender, EventArgs e)
    {
        string value = DDcat.SelectedValue;
        if (value != GetGlobalResourceObject("language", "All").ToString())
            Response.Redirect(apath + "/archive/month_" + m + "/year_" + y + "/category" + value + ".aspx");
        else
            Response.Redirect(apath + "/archive/year_" + y + "/" + "month_" + m + ".aspx");
    }
}