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

public partial class Controls_ArchiveMenu : System.Web.UI.UserControl
{
    string category = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            anm_Utility ut = new anm_Utility();
            if (Request.QueryString["category"] != null)
                h2archive.Text = h2archive.Text + " " + ut.GetCategory(Request.QueryString["category"]);
            else if (Request.QueryString["news"] != null)
            {
                category = ut.GetCategoryFromNews(Request.QueryString["news"]);
                h2archive.Text = h2archive.Text + " " + ut.GetCategory(category);
            }
            string menu = "";
            int nart = 0;
            int InitialYear = Convert.ToInt32(ut.GetSetting("Year"));
            int InitialMonth = Convert.ToInt32(ut.GetSetting("Month"));
            string viewart = ut.GetSetting("ViewNarticles");
            if (ut.GetSetting("ArchiveMenu") == "True")
            {
                PnlArchiveMenu.Visible = true;
                if (ut.GetSetting("ArchiveType") == "2")
                {
                    ddlarchive.Visible = true;
                    ddlarchive.Items.Add(new ListItem(GetGlobalResourceObject("language", "SelectMonth").ToString()));

                    if (Request.QueryString["category"] != null || Request.QueryString["news"] != null)
                    {
                        int cat = 0;
                        if (Request.QueryString["category"] != null)
                            cat = Convert.ToInt32(Request.QueryString["category"].ToString());
                        else
                            cat = Convert.ToInt32(ut.GetCategoryFromNews(Request.QueryString["news"].ToString()));
                        int currentYear = Convert.ToInt32(DateTime.Now.Year.ToString());
                        int currentMonth = Convert.ToInt32(DateTime.Now.Month.ToString());
                        int i, j;
                        if (currentYear == InitialYear)
                        {
                            for (i = currentMonth; i >= InitialMonth; i--)
                            {
                                if (viewart == "True")
                                {
                                    nart = ut.GetNumberArticles(i, currentYear,cat);
                                    if (nart != 0)
                                        ddlarchive.Items.Add(new ListItem(SetMonth(i) + " " + currentYear + " (" + nart + ")", i + "-" + currentYear + "-" + cat));
                                }
                                else
                                    ddlarchive.Items.Add(new ListItem(SetMonth(i) + " " + currentYear, i + "-" + currentYear + "-" + cat));
                            }
                        }
                        else
                        {
                            for (i = currentMonth; i > 0; i--)
                            {
                                if (viewart == "True")
                                {
                                    nart = ut.GetNumberArticles(i, currentYear,cat);
                                    if (nart != 0)
                                        ddlarchive.Items.Add(new ListItem(SetMonth(i) + " " + currentYear + " (" + nart + ")", i + "-" + currentYear + "-" + cat));
                                }
                                else
                                    ddlarchive.Items.Add(new ListItem(SetMonth(i) + " " + currentYear, i + "-" + currentYear + "-" + cat));
                            }
                        }
                        for (j = currentYear - 1; j >= InitialYear; j--)
                        {
                            if (j == InitialYear)
                            {
                                for (i = 12; i >= InitialMonth; i--)
                                {
                                    if (viewart == "True")
                                    {
                                        nart = ut.GetNumberArticles(i, j,cat);
                                        if (nart != 0)
                                            ddlarchive.Items.Add(new ListItem(SetMonth(i) + " " + j + " (" + nart + ")", i + "-" + j + "-" + cat));
                                    }
                                    else
                                        ddlarchive.Items.Add(new ListItem(SetMonth(i) + " " + j, i + "-" + j + "-" + cat));
                                }
                            }
                            else
                            {
                                for (i = 12; i > 0; i--)
                                {
                                    if (viewart == "True")
                                    {
                                        nart = ut.GetNumberArticles(i, j,cat);
                                        if (nart != 0)
                                            ddlarchive.Items.Add(new ListItem(SetMonth(i) + " " + j + " (" + nart + ")", i + "-" + j + "-" + cat));
                                    }
                                    else
                                        ddlarchive.Items.Add(new ListItem(SetMonth(i) + " " + j, i + "-" + j + "-" + cat));
                                }
                            }
                        }
                    }
                    else
                    {
                        int currentYear = Convert.ToInt32(DateTime.Now.Year.ToString());
                        int currentMonth = Convert.ToInt32(DateTime.Now.Month.ToString());
                        int i, j;
                        if (currentYear == InitialYear)
                        {
                            for (i = currentMonth; i >= InitialMonth; i--)
                            {
                                if (viewart == "True")
                                {
                                    nart = ut.GetNumberArticles(i, currentYear);
                                    if (nart != 0)
                                        ddlarchive.Items.Add(new ListItem(SetMonth(i) + " " + currentYear + " (" + nart + ")", i + "-" + currentYear));
                                }
                                else
                                    ddlarchive.Items.Add(new ListItem(SetMonth(i) + " " + currentYear, i + "-" + currentYear));
                            }
                        }
                        else
                        {
                            for (i = currentMonth; i > 0; i--)
                            {
                                if (viewart == "True")
                                {
                                    nart = ut.GetNumberArticles(i, currentYear);
                                    if (nart != 0)
                                        ddlarchive.Items.Add(new ListItem(SetMonth(i) + " " + currentYear + " (" + nart + ")", i + "-" + currentYear));
                                }
                                else
                                    ddlarchive.Items.Add(new ListItem(SetMonth(i) + " " + currentYear, i + "-" + currentYear));
                            }
                        }
                        for (j = currentYear - 1; j >= InitialYear; j--)
                        {
                            if (j == InitialYear)
                            {
                                for (i = 12; i >= InitialMonth; i--)
                                {
                                    if (viewart == "True")
                                    {
                                        nart = ut.GetNumberArticles(i, j);
                                        if (nart != 0)
                                            ddlarchive.Items.Add(new ListItem(SetMonth(i) + " " + j + " (" + nart + ")", i + "-" + j));
                                    }
                                    else
                                        ddlarchive.Items.Add(new ListItem(SetMonth(i) + " " + j, i + "-" + j));
                                }
                            }
                            else
                            {
                                for (i = 12; i > 0; i--)
                                {
                                    if (viewart == "True")
                                    {
                                        nart = ut.GetNumberArticles(i, j);
                                        if (nart != 0)
                                            ddlarchive.Items.Add(new ListItem(SetMonth(i) + " " + j + " (" + nart + ")", i + "-" + j));
                                    }
                                    else
                                        ddlarchive.Items.Add(new ListItem(SetMonth(i) + " " + j, i + "-" + j));
                                }
                            }
                        }
                    }

                }
            }
            Response.Write(menu);
        }
    }
    protected string SetMonth(int value)
    {
        string month = "";
        if (value == 1)
            month = GetGlobalResourceObject("language", "January").ToString();
        if (value == 2)
            month = GetGlobalResourceObject("language", "February").ToString();
        if (value == 3)
            month = GetGlobalResourceObject("language", "March").ToString();
        if (value == 4)
            month = GetGlobalResourceObject("language", "April").ToString();
        if (value == 5)
            month = GetGlobalResourceObject("language", "May").ToString();
        if (value == 6)
            month = GetGlobalResourceObject("language", "June").ToString();
        if (value == 7)
            month = GetGlobalResourceObject("language", "July").ToString();
        if (value == 8)
            month = GetGlobalResourceObject("language", "August").ToString();
        if (value == 9)
            month = GetGlobalResourceObject("language", "September").ToString();
        if (value == 10)
            month = GetGlobalResourceObject("language", "October").ToString();
        if (value == 11)
            month = GetGlobalResourceObject("language", "November").ToString();
        if (value == 12)
            month = GetGlobalResourceObject("language", "December").ToString();
        return month;
    }
    protected void ddlarchive_SelectedIndexChanged(object sender, EventArgs e)
    {
        string[] value = ddlarchive.SelectedValue.Split('-');
        if (value.Length > 2)
            Response.Redirect(Page.Request.ApplicationPath.ToString() + "/month_" + value[0].ToString() + "/year_" + value[1].ToString() + "/category" + value[2].ToString() + ".aspx");
        else
            Response.Redirect(Page.Request.ApplicationPath.ToString() + "/year_" + value[1].ToString() + "/month_" + value[0].ToString() + ".aspx");
    }
    protected string ViewArchiveMenu()
    {
        anm_Utility ut = new anm_Utility();
        string menu = ""; ;
        int InitialYear = Convert.ToInt32(ut.GetSetting("Year"));
        int InitialMonth = Convert.ToInt32(ut.GetSetting("Month"));
       if (ut.GetSetting("ArchiveMenu") == "True")
       {
           if (ut.GetSetting("ArchiveType") == "2")
               menu = "";
           else
           {
               if (Request.QueryString["category"] != null)
                   menu = ut.GetArchiveMenu(InitialYear, InitialMonth, Convert.ToInt32(Request.QueryString["category"].ToString()));
               else if (category != "")
                   menu = ut.GetArchiveMenu(InitialYear, InitialMonth, Convert.ToInt32(category));
               else
                   menu = ut.GetArchiveMenu(InitialYear, InitialMonth);
           }
       }
       return menu;

    }
}
