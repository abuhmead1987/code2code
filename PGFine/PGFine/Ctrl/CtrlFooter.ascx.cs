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
using CommonClass;

namespace PGFine.Ctrl
{
    public partial class CtrlFooter : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadMenu();
        }

        private void LoadMenu()
        {
            try
            {
                int intPositionDisPlay = 10000;
                DB.DB_Object.ClassTypeNews objClassData = new DB.DB_Object.ClassTypeNews();
                DataTable dt = objClassData.getDataTypeNewsByPositionDisPlay(intPositionDisPlay);
                if (dt.Rows.Count > 0)
                {
                    rptFooter.DataSource = dt;
                    rptFooter.DataBind();
                }               
            }
            catch (Exception objExc)
            {
                SetErrorMessage(objExc.Message);
            }
        }
        // Gán lỗi khi phát sinh vào label thông báo lỗi        
        private void SetErrorMessage(string text)
        {
            _errorLabel.Text = "Thông báo : " + text;
            _errorLabel.Visible = null != text && 0 < text.Length;
        }

        protected void rptFooter_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                DataRowView ItemView = (DataRowView)e.Item.DataItem;
              
                // set CSS for current page
                HyperLink hplTypeNews = e.Item.FindControl("hplTypeNews") as HyperLink;
                HiddenField hdUrl = e.Item.FindControl("hdUrl") as HiddenField;

                if (Location.GetLocation == "VIE")
                {
                    hplTypeNews.Text = ItemView["NameNewsVN"].ToString().Replace(" ", "&nbsp;");
                }
                else
                {
                    hplTypeNews.Text = ItemView["NameNewsEL"].ToString().Replace(" ", "&nbsp;");
                }               
                if (!string.IsNullOrEmpty(hdUrl.Value.Trim()))
                {
                    hplTypeNews.NavigateUrl = hdUrl.Value.Trim();
                }
                else
                {
                    hplTypeNews.NavigateUrl = "~/news.aspx?typenewsid=" + hplTypeNews.ToolTip.Trim();
                }
                
            }      
        }

    }
}