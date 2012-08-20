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

namespace PGFine.Ctrl
{
    public partial class CtrlMainBanner : System.Web.UI.UserControl
    {
        string _BannerPath;
        public string BannerPath
        {            
            get
            {
                return _BannerPath;
            }
            set
            {
                _BannerPath = value;
            }
        }

        int  _CategoryTopicID;
        public int CategoryTopicID
        {
            
            get {
                return _CategoryTopicID;
            }
            set
            {
                _CategoryTopicID = value;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadBannerMain();
        }

        private void LoadBannerMain()
        {
            if (!string.IsNullOrEmpty(BannerPath))
                ltrDivBannerMain.Text = string.Format("<div class='ImgBannerMainImages' style=\"background-image: url('..{0}');\">", ResolveUrl("~" + BannerPath.Replace("~", "")));
            else
                ltrDivBannerMain.Text = string.Format("<div class='ImgBannerMainImages' style=\"background-image: url('..{0}');\">", ResolveUrl(ConfigurationManager.AppSettings["BannerMainPath"]));

            try
            {
                DB.DB_Object.ClassTypeProduct objClassData = new DB.DB_Object.ClassTypeProduct();
                DataTable dt = objClassData.getDataTypeProduct();
                if (dt.Rows.Count > 0)
                {
                    rptProductMenu.DataSource = dt;
                    rptProductMenu.DataBind();
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

        protected void rptProductMenu_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            //DataRow item = e.Item.DataItem as DataRow;
            HiddenField hdHover = e.Item.FindControl("hdHover") as HiddenField;
            HiddenField hdOut = e.Item.FindControl("hdOut") as HiddenField;

            ImageButton imgbtImages = e.Item.FindControl("imgbtImages") as ImageButton;
            imgbtImages.ImageUrl = hdOut.Value.Trim();
            imgbtImages.Attributes.Add("OnMouseOver", string.Format("this.src='..{0}';",ResolveUrl(hdHover.Value.Trim())));
            imgbtImages.Attributes.Add("OnMouseOut", string.Format("this.src='..{0}';",ResolveUrl(hdOut.Value.Trim())));
            
        }
        protected void imgbtImages_Command(object sender, CommandEventArgs e)
        {
            Response.Redirect("~/Default.aspx?IsProduct=1&ID=" + e.CommandName);
        }

      

    }
}