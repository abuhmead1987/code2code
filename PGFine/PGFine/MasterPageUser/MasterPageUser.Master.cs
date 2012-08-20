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
using Itech.Utils;
using CommonClass;

namespace PGFine.MasterPageUser
{
    public partial class MasterPageUser : System.Web.UI.MasterPage
    {
        #region Các biến toàn cục...
        public string strPathF = "";
        #endregion

        #region Hàm PageLoad....

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {              
                LoadProduct();
                RenderData();//Load data to Languages

                //Load menu top right 0:top left 1: bottom 2:ca hai 3:top right 4: detail product
                CreateMenuTopRight(3); 
                //load Images button search
                imgSearch.Attributes.Add("OnMouseOver", string.Format("this.src='..{0}';", ResolveUrl("~/Images/btSearchHover.gif")));
                imgSearch.Attributes.Add("OnMouseOut", string.Format("this.src='..{0}';", ResolveUrl("~/Images/btSearch.gif")));

                //Load Images Languages
                LoaImagesButtonLang();
            }
        }

        #endregion

        private void LoaImagesButtonLang()
        {
            if (Location.GetLocation == "VIE")            
                imgBtLang.ImageUrl = ResolveUrl("~/Images/Lag_EN.gif");                            
            else            
                imgBtLang.ImageUrl = ResolveUrl("~/Images/iconLangVN.jpeg");           
        }

        private void LoadProduct()
        {
            if (Session["Cart"] == null)
            {
                Session["Cart"] = new Cart();
            }            
            Cart mycart = new Cart();
            mycart = (Cart)Session["Cart"];            
            hplProduct.Text = string.Format("{0} {1}", mycart.Table.Count,Location.GetLanguageTag("Product").ToString());
        }

        private void CreateMenuTopRight(int intPositionDisPlay)
        {
            DB.DB_Object.ClassTypeNews objClassData = new DB.DB_Object.ClassTypeNews();
            DataTable dt = objClassData.getDataTypeNewsByPositionDisPlay(intPositionDisPlay);
            if (dt.Rows.Count > 0)
            {
                rptMenuTopRight.DataSource = dt;
                rptMenuTopRight.DataBind();
            }
        }

        protected void rptMenuTopRight_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                DataRowView ItemView = (DataRowView)e.Item.DataItem;

                HyperLink hplMenuTop = e.Item.FindControl("hplMenuTop") as HyperLink;

                if (Location.GetLocation == "VIE")
                {
                    hplMenuTop.Text = ItemView["NameNewsVN"].ToString();
                }
                else
                {
                    hplMenuTop.Text = ItemView["NameNewsEL"].ToString();
                }

                if (!string.IsNullOrEmpty(ItemView["PageLink"].ToString()))
                {
                    hplMenuTop.NavigateUrl = ItemView["PageLink"].ToString();
                }
                else
                {
                    hplMenuTop.NavigateUrl = "~/news.aspx?typenewsid=" + ItemView["TypeNewsID"].ToString();
                }

            }
        }

        //Menu News
        private DataTable LoadMenuNews()
        {
            DB.DB_Object.ClassTypeNews objClassData = new DB.DB_Object.ClassTypeNews();
            DataTable dt = objClassData.getDataTypeNewsCreateMenu();
            return dt;
        }

        private void Load_Access(string strLanguages)
        {
            //DB.DB_Object.ClassAccess objData=new DB.DB_Object.ClassAccess();
            //if (strLanguages == "1")
            //{
            //    lbCoutConect.Text = "Visitor: " + objData.ReturnCoutAccess();
            //}
            //else
            //{
            //    lbCoutConect.Text = "Truy cập: " + objData.ReturnCoutAccess();
            //}
        }

        //Menu Programs
        private DataTable LoadMenuPrograms()
        {
            DB.DB_Object.ClassPrograms objClassPrograms = new DB.DB_Object.ClassPrograms();
            DataTable dt = objClassPrograms.getDataProgramsCreateMenu();
            return dt;
        }

        private void RenderData()
        {
            txtKeySearch.Text = Location.GetLanguageTag("InputKeyS").ToString();
            lbtLanguages.Text = Location.GetLanguageTag("CaptionLang").ToString();
            lbSearch.Text = Location.GetLanguageTag("CaptionSearch").ToString();
            lbShare.Text = Location.GetLanguageTag("lbShare").ToString();
        }

        protected void imgSearch_Click(object sender, ImageClickEventArgs e)
        {
           
        }

        protected void imgBtLang_Click(object sender, ImageClickEventArgs e)
        {
            if (Location.GetLocation == "VIE")
            {
                Location.SetLocation("ENG");                
                Response.Redirect(Request.Url.AbsoluteUri);
            }
            else
            {
                Location.SetLocation("VIE");                
                Response.Redirect(Request.Url.AbsoluteUri);
            }
        }        

        protected void lbtLanguages_Click(object sender, EventArgs e)
        {
            if (Location.GetLocation == "VIE")
            {
                Location.SetLocation("ENG");
                Response.Redirect(Request.Url.AbsoluteUri);
            }
            else
            {
                Location.SetLocation("VIE");
                Response.Redirect(Request.Url.AbsoluteUri);
            }
        }
        
    }
}
