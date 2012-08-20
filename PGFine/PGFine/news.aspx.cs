﻿using System;
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
using Itech.Utils;
using CommonClass;
using System.Data.SqlClient;

namespace PGFine
{
    public partial class news : System.Web.UI.Page
    {        
        #region Hàm Page Load....

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request["typenewsid"]))
                {
                    LoadDetail(int.Parse(Request["typenewsid"]));
                    AddOnclick();
                    Session["htmlNews"] = DB.ClassPrint.ClassPrint.RenderHTMLControl(htmlRenderNews);
                }
                else
                {
                    Response.Redirect("~/Default.aspx");
                }

            }
            RenderData();
        }

        private void RenderData()
        {
            ltrOrtherNews.Text = Location.GetLanguageTag("ltrOrtherNews").ToString();
            lbDreakrum.Text = Location.GetLanguageTag("BacktoTop").ToString();
            lbtPrint.Text = Location.GetLanguageTag("PrintPage").ToString();
            hplSendAdmin.Text = Location.GetLanguageTag("SendAdmin").ToString();
            hplIntroduct.Text = Location.GetLanguageTag("introYour").ToString();
        }

        private void LoadDetail(int intTypeNewsId)
        {
            DB.DB_Object.ClassTypeNews objClassData = new DB.DB_Object.ClassTypeNews();
            DataTable dt = objClassData.getDataEditTypeNews(intTypeNewsId);
            if (dt.Rows.Count > 0)
            {
                if (int.Parse(dt.Rows[0]["TypeDisPlay"].ToString()) == 1)
                {
                    //Load detail
                    lbBreakrum.Text = dt.Rows[0]["NameNewsVN"].ToString();
                    LoadDetailNews(intTypeNewsId);
                    //Load list orther
                    LoadOrtherNews(intTypeNewsId);
                }
                else
                {
                    //Load List
                    Response.Redirect("~/newslist.aspx?typenewsid=" + intTypeNewsId);
                }

            }
        }

        private void LoadOrtherNews(int intTypeNewsId)
        {
            DB.DB_Object.ClassNews objClassData = new DB.DB_Object.ClassNews();
            DataTable dt = objClassData.getDataNewsOrtherNews(intTypeNewsId);
            if (dt.Rows.Count > 0)
            {
                rptListOrtherNews.DataSource = dt;
                rptListOrtherNews.DataBind();
            }
        }

        private void LoadDetailNews(int intTypeNewsId)
        {
            DB.DB_Object.ClassNews objClassData = new DB.DB_Object.ClassNews();
            DataTable dt = objClassData.getDataNewsTypeDisplay(intTypeNewsId);
            if (dt.Rows.Count > 0)
            {
                if (Location.GetLocation == "VIE")
                {
                    lbTitle.Text = dt.Rows[0]["TitleNewsVN"].ToString();
                    lbShortdescription.Text = dt.Rows[0]["ShortDescriptionVN"].ToString();
                    lbDescription.Text = dt.Rows[0]["ContentVN"].ToString();
                }
                else
                {
                    lbTitle.Text = dt.Rows[0]["TitleNewsEL"].ToString();
                    lbShortdescription.Text = dt.Rows[0]["ShortDescriptionEL"].ToString();
                    lbDescription.Text = dt.Rows[0]["ContentEL"].ToString();
                }     
                
            }
        }

        protected void rptListOrtherNews_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                DataRowView ItemView = (DataRowView) e.Item.DataItem;              
                HyperLink hplLinkOrther = e.Item.FindControl("hplLinkOrther") as HyperLink;
              
                hplLinkOrther.NavigateUrl = ResolveUrl("~/newsdetail.aspx?newsid=" + ItemView["NewsID"].ToString());
              
                if (Location.GetLocation == "VIE")
                {
                    hplLinkOrther.Text = ItemView["TitleNewsVN"].ToString();
                    hplLinkOrther.ToolTip = ItemView["TitleNewsVN"].ToString();
                }
                else
                {
                    hplLinkOrther.Text = ItemView["TitleNewsEL"].ToString();
                    hplLinkOrther.ToolTip = ItemView["TitleNewsEL"].ToString();
                }     
                
            }
        }

        #endregion
        private void AddOnclick()
        {
            hplIntroduct.Attributes.Add("onclick", "openWin('introduction.aspx',450,300);");
            hplSendAdmin.Attributes.Add("onclick", "openWin('SendEmailAdmin.aspx',450,310);");
            lbtPrint.Attributes.Add("onclick", "openWin('PrintPage.aspx?Type=News',980,882);");
        }
     
    }
}
