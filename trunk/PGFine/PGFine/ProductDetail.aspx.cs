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
using System.Text;
using System.IO;
using System.Threading;

namespace PGFine
{
    public partial class ProductDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request["productid"]))
            {
                if (!IsPostBack)
                {
                    LoadDetailProduct(int.Parse(Request["productid"]));
                    LoadColor(int.Parse(Request["productid"]));                   
                    //Load Number
                    txtNumber.Text = "1";
                    //Load vote
                    VoteDisplayImages(int.Parse(Request["productid"]));
                    //Load Menu ProductDetail
                    CreateMenuProductDetail(4);
                    AddOnclick();
                    Session["ctrl"] =DB.ClassPrint.ClassPrint.RenderHTMLControl(htmlRender);
                }
            }
            RenderData();
        }

        private void CreateMenuProductDetail(int intPositionDisPlay)
        {
            DB.DB_Object.ClassTypeNews objClassData = new DB.DB_Object.ClassTypeNews();
            DataTable dt = objClassData.getDataTypeNewsByPositionDisPlay(intPositionDisPlay);
            if (dt.Rows.Count > 0)
            {
                rptMenuDetailProduct.DataSource = dt;
                rptMenuDetailProduct.DataBind();
            }
        }

        protected void rptMenuDetailProduct_ItemDataBound(object sender, RepeaterItemEventArgs e)
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

        private void AddOnclick()
        {
            hplIntroduct.Attributes.Add("onclick", "openWin('introduction.aspx',450,300);");
            hplSendAdmin.Attributes.Add("onclick", "openWin('SendEmailAdmin.aspx',450,310);");
            lbtPrint.Attributes.Add("onclick", "openWin('PrintPage.aspx',590,582);");
        }
       
        private void VoteDisplayImages(int intProductId)
        {
            int SumVote = 0;
            int SumNumer = 0;

            DB.DB_Object.ClassProduct objClassData = new DB.DB_Object.ClassProduct();
            DataTable dt = objClassData.getVote(intProductId);
            if (dt.Rows.Count > 0)
            {
                SumVote = int.Parse(dt.Rows[0]["SumPoint"].ToString());
                SumNumer = int.Parse(dt.Rows[0]["NumberVote"].ToString());
            }

            string strImages = string.Empty;
            string PathImagesVote = ResolveUrl(ConfigurationManager.AppSettings["PathImagesVote"]);
            string PathImagesVoteMid = ResolveUrl(ConfigurationManager.AppSettings["PathImagesVoteMid"]);
            string PathImagesVoteNull = ResolveUrl(ConfigurationManager.AppSettings["PathImagesVoteNull"]);
            //Flag dem ngoi sao
            int Flag = 0;

            if (SumVote > 0 && SumNumer > 0)
            {
                //lay nguyen
                int intFile = SumVote / (SumNumer * 2);
                for (int i = 0; i < intFile; i++)
                {
                    strImages = strImages + string.Format("<div class=\"ImagesVoteDe\"><img src='{0}'/></div>", PathImagesVote);
                    Flag++;
                }
                //lay le
                double dbFileMid = SumVote % SumNumer;
                if (dbFileMid >= 3 && dbFileMid <= 6)
                {
                    strImages = strImages + string.Format("<div class=\"ImagesVoteDe\"><img src='{0}'/></div>", PathImagesVoteMid);
                    Flag++;
                }
                else if (dbFileMid > 6)
                {
                    strImages = strImages + string.Format("<div class=\"ImagesVoteDe\"><img src='{0}'/></div>", PathImagesVote);
                    Flag++;
                }
            }
            //In so ngoi sao con lai
            if ((5 - Flag) > 0)
            {
                for (int j = 0; j < (5 - Flag); j++)
                {
                    strImages = strImages + string.Format("<div class=\"ImagesVoteDe\"><img src='{0}'/></div>", PathImagesVoteNull);
                }
            }

            ltrSumVote.Text = string.Format("{0}/{1}", SumVote, SumNumer);
            ltrVote.Text = strImages;
        }
    
        private void LoadDetailProduct(int intProductId)
        {
            DB.DB_Object.ClassProduct objClassData = new DB.DB_Object.ClassProduct();
            DataTable dt = objClassData.getDataEditProduct(intProductId);
            if (dt.Rows.Count > 0)
            {
                if (Location.GetLocation == "VIE")
                {
                    lbBreakrum.Text = dt.Rows[0]["TypeName"].ToString();
                    lbNameProduct.Text = dt.Rows[0]["NameProduct"].ToString();
                    ltrShortDescription.Text = dt.Rows[0]["ShortDescription"].ToString();
                    ltrDescription.Text = dt.Rows[0]["Description"].ToString();
                    ltrPrice.Text = string.Format("{0} VNĐ", dt.Rows[0]["PriceNew"].ToString());
                    ltrPriceOld.Text = string.Format("{0} VNĐ", dt.Rows[0]["Price"].ToString());
                    ltrStatus.Text = dt.Rows[0]["Status"].ToString();
                }
                else
                {
                    lbBreakrum.Text = dt.Rows[0]["TypeNameEL"].ToString();
                    lbNameProduct.Text = dt.Rows[0]["NameProductEL"].ToString();
                    ltrShortDescription.Text = dt.Rows[0]["ShortDescriptionEL"].ToString();
                    ltrDescription.Text = dt.Rows[0]["Description"].ToString();
                    ltrPrice.Text = string.Format("{0} VNĐ", dt.Rows[0]["PriceNew"].ToString());
                    ltrPriceOld.Text = string.Format("{0} VNĐ", dt.Rows[0]["Price"].ToString());
                    ltrStatus.Text = dt.Rows[0]["StatusEL"].ToString();
                }               

                //set css
                if (int.Parse(dt.Rows[0]["PriceNew"].ToString()) > 0)
                {
                    DivPrice.Attributes.Add("class", "PriceDetailOld");
                }
                else
                {
                    DivPrice.Attributes.Add("class", "PriceDetailOldActive");
                }
            }
            //add new windows
            hplVote.Attributes.Add("onclick", string.Format("openWin('SentVote.aspx?id={0}',400,250);", intProductId));
        }

        private void LoadColor(int intProductId)
        {
            DB.DB_Object.ClassSize objClassData = new DB.DB_Object.ClassSize();
            DataTable dt = objClassData.getDataTrainersAdmin(1,intProductId);
            if(dt.Rows.Count>0)
            {
                rptColor.DataSource = dt;
                rptColor.DataBind();

                //dành cho dat hang
                rptListColorBuy.DataSource = dt;
                rptListColorBuy.DataBind();                
            }
        }

        protected void rptListColorBuy_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                DataRowView ItemRows = (DataRowView)e.Item.DataItem;
                System.Web.UI.WebControls.Image imgImgesIconBuy = e.Item.FindControl("imgImgesIconBuy") as System.Web.UI.WebControls.Image;
              
                imgImgesIconBuy.ImageUrl = ItemRows["ImagesPath1"].ToString();                                           
            }
        }
       
        protected void rptColor_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                DataRowView ItemRows = (DataRowView)e.Item.DataItem;
                ImageButton imgColorButton = e.Item.FindControl("imgColorButton") as ImageButton;

                imgColorButton.ImageUrl = ItemRows["ImagesPath1"].ToString();
                imgColorButton.CommandName = ItemRows["id"].ToString();
                if (e.Item.ItemIndex == 0)
                {
                    hdImagesPathCurrent.Value = ItemRows["ImagesPath2"].ToString();//dung khi dat hang luu images
                    ltrMain.Text = string.Format("<img src=\"{0}\" id=\"imgMain\" alt=\"imgMain\" width=\"256\" height=\"500\">", ResolveUrl(ItemRows["ImagesPath2"].ToString()));
                    ltrImageThums.Text = string.Format("<a href=\"javascript:top.window.scrollTo(980,400)\" onclick=\"validateOrderNo('{0}');\"><img src=\"{0}\" border=\"0\" id=\"ImagesThumb1\" width=\"53\" height=\"92\"></a>", ResolveUrl(ItemRows["ImagesPath2"].ToString()));
                    ltrImageThums1.Text = string.Format("<a href=\"javascript:top.window.scrollTo(980,400)\" onclick=\"validateOrderNo('{0}');\"><img src=\"{0}\" border=\"0\" id=\"ImagesThumb2\" width=\"53\" height=\"92\"></a>", ResolveUrl(ItemRows["ImagesPath3"].ToString()));
                    ltrImageThums2.Text = string.Format("<a href=\"javascript:top.window.scrollTo(980,400)\" onclick=\"validateOrderNo('{0}');\"><img src=\"{0}\" border=\"0\" id=\"ImagesThumb3\" width=\"53\" height=\"92\"></a>", ResolveUrl(ItemRows["ImagesPath4"].ToString()));
                    ltrImageThums3.Text = string.Format("<a href=\"javascript:top.window.scrollTo(980,400)\" onclick=\"validateOrderNo('{0}');\"><img src=\"{0}\" border=\"0\" id=\"ImagesThumb4\" width=\"53\" height=\"92\"></a>", ResolveUrl(ItemRows["ImagesPath5"].ToString()));                  
                }
            }
        }

        protected void imgbtImages_Command(object sender, CommandEventArgs e)
        {
            DB.DB_Object.ClassSize objClassData = new DB.DB_Object.ClassSize();
            DataTable dt = objClassData.getDataTrainersAndAdvisors(int.Parse(e.CommandName));
            if (dt.Rows.Count > 0)
            {
                hdImagesPathCurrent.Value = dt.Rows[0]["ImagesPath2"].ToString();//dung khi dat hang luu images
                ltrMain.Text = string.Format("<img src=\"{0}\" id=\"imgMain\" alt=\"imgMain\" width=\"256\" height=\"500\">", ResolveUrl(dt.Rows[0]["ImagesPath2"].ToString()));
                ltrImageThums.Text = string.Format("<a href=\"javascript:top.window.scrollTo(980,400)\" onclick=\"validateOrderNo('{0}');\"><img src=\"{0}\" border=\"0\" id=\"ImagesThumb1\" width=\"53\" height=\"92\"></a>", ResolveUrl(dt.Rows[0]["ImagesPath2"].ToString()));
                ltrImageThums1.Text = string.Format("<a href=\"javascript:top.window.scrollTo(980,400)\" onclick=\"validateOrderNo('{0}');\"><img src=\"{0}\" border=\"0\" id=\"ImagesThumb2\" width=\"53\" height=\"92\"></a>", ResolveUrl(dt.Rows[0]["ImagesPath3"].ToString()));
                ltrImageThums2.Text = string.Format("<a href=\"javascript:top.window.scrollTo(980,400)\" onclick=\"validateOrderNo('{0}');\"><img src=\"{0}\" border=\"0\" id=\"ImagesThumb3\" width=\"53\" height=\"92\"></a>", ResolveUrl(dt.Rows[0]["ImagesPath4"].ToString()));
                ltrImageThums3.Text = string.Format("<a href=\"javascript:top.window.scrollTo(980,400)\" onclick=\"validateOrderNo('{0}');\"><img src=\"{0}\" border=\"0\" id=\"ImagesThumb4\" width=\"53\" height=\"92\"></a>", ResolveUrl(dt.Rows[0]["ImagesPath5"].ToString()));                  
            }
        }
       
        protected void btBuyProduct_Click(object sender, EventArgs e)
        {
            ViewBook vb = new ViewBook();
            
            //get Product information
            int intId = 0;
            string strNameProduct = "";
            double dbPrice = 0;
            double dbGiakhuyenmai = 0;
            int intNumber = 0;
            string strSize = string.Empty;
            string strImagespath = "~/Images/ImgNews/defaultimage.GIF";
            string strCode = string.Empty;

            if (!string.IsNullOrEmpty(Request["productid"]))
            {
                intId = int.Parse(Request["productid"]);               
            }

            //Lấy màu sắc           
            string strColor = string.Empty;
            foreach (RepeaterItem row in rptListColorBuy.Items)
            {
                CheckBox chkColorBuy = row.FindControl("chkColorBuy") as CheckBox;
                System.Web.UI.WebControls.Image imgImgesIconBuy = row.FindControl("imgImgesIconBuy") as System.Web.UI.WebControls.Image;

                if (chkColorBuy != null && chkColorBuy.Checked)
                {
                    strColor = strColor + string.Format("<img src=\"{0}\" style=\"padding: 3px;\"/>", ResolveUrl(imgImgesIconBuy.ImageUrl)); 
                }
            }
            DB.DB_Object.ClassProduct objClassData = new DB.DB_Object.ClassProduct();
            DataTable dt = objClassData.getDataEditProduct(intId);
            if (dt.Rows.Count > 0)
            {
                strNameProduct = dt.Rows[0]["NameProduct"].ToString();
                dbPrice = int.Parse(dt.Rows[0]["Price"].ToString());
                dbGiakhuyenmai = int.Parse(dt.Rows[0]["PriceNew"].ToString());
                strImagespath = hdImagesPathCurrent.Value.Trim();
                strCode=dt.Rows[0]["CodeProduct"].ToString();
            }
            if(!string.IsNullOrEmpty(rdoListSize.SelectedValue))
                strSize=rdoListSize.SelectedValue.Trim();

            if (CheckIsNumber(txtNumber.Text.Trim()))
                intNumber = int.Parse(txtNumber.Text.Trim());            

            //Add Session Gio hàng
            if (Session["Cart"] == null)
            {
                Session["Cart"] = new Cart();
            }
            if (dbGiakhuyenmai > 0)
                dbPrice = dbGiakhuyenmai;
            
            //Kiem tra nhap lieu
            if (string.IsNullOrEmpty(strSize))
            {
                lbWarmingSize.Visible = true;
                return;
            }
            else
                lbWarmingSize.Visible = false;

            Cart mycart = (Cart)Session["Cart"];          
            mycart.Add(intId, strNameProduct, dbPrice, intNumber, strSize, strImagespath, strCode, strColor);

            Response.Redirect("~/CartProduct.aspx");
        }       

        private bool CheckIsNumber(string strNumber)
        {
            try
            {
                int.Parse(strNumber);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private void RenderData()
        {
            lbInformationP.Text = Location.GetLanguageTag("InforProduct").ToString();
            lbBuyProduct.Text = Location.GetLanguageTag("BuyProduct").ToString();
            lbDescription.Text = Location.GetLanguageTag("DescriptionPro").ToString();
            ltrCaptionPromo.Text = Location.GetLanguageTag("PromotionalPrice").ToString();
            ltrSatus.Text = Location.GetLanguageTag("Status").ToString();
            ltrColorView.Text = Location.GetLanguageTag("ClickDetail").ToString();
            ltrPriceD.Text = Location.GetLanguageTag("PriceD").ToString();
            ltrColorD.Text = Location.GetLanguageTag("ColorD").ToString();
            ltrChoseColorC.Text = Location.GetLanguageTag("ltrChoseColorC").ToString();
            ltrInputNumber.Text = Location.GetLanguageTag("InputNumber").ToString();
            ltrSizeD.Text = Location.GetLanguageTag("ltrSizeD").ToString();
            hplVote.Text = Location.GetLanguageTag("hplVote").ToString();
            lbBacktoTop.Text = Location.GetLanguageTag("BacktoTop").ToString();

            hplSendAdmin.Text = Location.GetLanguageTag("SendAdmin").ToString();
            hplIntroduct.Text = Location.GetLanguageTag("introYour").ToString();
            lbtPrint.Text = Location.GetLanguageTag("PrintPage").ToString();
            lbUtiliti.Text = Location.GetLanguageTag("Uitiliti").ToString();

            if (Location.GetLocation == "VIE")
                ltrCaptionVote.Text = "(<strong>10</strong> phiếu)";
            else
                ltrCaptionVote.Text = "(<strong>10</strong> Point)";

            btBuyProduct.Text = Location.GetLanguageTag("BuyPD").ToString();

        }




    }
}
