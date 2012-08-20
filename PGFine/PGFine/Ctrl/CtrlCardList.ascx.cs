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
    public partial class CtrlCardList : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Cart"] == null)
            {
                Session["Cart"] = new Cart();
            }
            //Cart mycart = (Cart)Session["Cart"];
            Cart mycart = new Cart();
            mycart = (Cart)Session["Cart"];//convert  biến thành một đối tượng kiểu Cart với Cart là một cấu trúc            
            mylist.DataSource = mycart.Table; //cấu trúc Cart() có Table là số dòng trong Hashtable giống như table
            mylist.DataBind();
            //totalPrice.Text =string.Format("{0:c}", mycart.TotalPrice);   //thực chất chỉ là convert sang kieu chuoi ký tự      
            totalPrice.Text = Convert.ToString(mycart.TotalPrice);

            //Load Langues
            RenderData();
        }
        private void RenderData()
        {
            ltrSummoney.Text = Location.GetLanguageTag("Summoney").ToString();           
            ltrDelete.Text = Location.GetLanguageTag("ltrDelete").ToString();
            ltrImages.Text = Location.GetLanguageTag("ImagesP").ToString();
            ltrProductName.Text = Location.GetLanguageTag("ImagesP").ToString();
            ltrNameCode.Text = Location.GetLanguageTag("ProductCode").ToString();
            ltrZise.Text = Location.GetLanguageTag("ltrSize").ToString();
            ltrColor.Text = Location.GetLanguageTag("ColorC").ToString();
            ltrNumber.Text = Location.GetLanguageTag("Numberc").ToString();
            ltrPrice.Text = Location.GetLanguageTag("PriceC").ToString();
            ltrMoney.Text = Location.GetLanguageTag("SumM").ToString();
        }


    }
}