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


namespace PGFine
{
    public partial class CartProduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
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
            }
            RenderData();
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }
        protected void btUpdate_Click(object sender, EventArgs e)
        {
            if (Session["Cart"] == null)
            {
                Session["Cart"] = new Cart();
            }
            Cart mycart = (Cart)Session["Cart"];
            //_____________mylist là tên của control repeater một control mới khi can mới thực hiện hien thi gia trị
            //___________tự như trong windown form diếm số control ton tai trong repeater có gia tri se hien thi
            for (int i = 0; i < mylist.Items.Count; i++)//lặp tất cả các số dòng trong repeater<=>datalist<=>gridview
            {
                RepeaterItem item = mylist.Items[i];  //xét control hiện hành trên repeater<=>datalist<=>gridview
                CheckBox remove = (CheckBox)item.FindControl("Remove");  //khai báo một checkbox ten remove trong xu lý và checkbox này duoc gan bằng với check trong thiết kế        
                HiddenField hdIDProduct = (HiddenField)item.FindControl("hdIDProduct");//tương tự trên checkbox

                if (remove.Checked)     //kiem tra checkbox được check hay không
                {
                    mycart.Remove(Convert.ToInt32(hdIDProduct.Value.Trim())); //remove object ra khỏi đối tượng lưu trữ Cart()
                }
                TextBox txtNumber = (TextBox)item.FindControl("txtNumber");//Tượng tự checkbox
                mycart.Update(Convert.ToInt32(hdIDProduct.Value.Trim()), Convert.ToInt32(txtNumber.Text.Trim()));//Cập nhật lại đối tượng Cart()sau khi thay đổi
                //   Collection cl = new Collection();
                //     Control timkiem = Page.Form.FindControl("Timkiem1");
                //   Label lb = (Label)cl.FindRecusive("label1", timkiem);
                //   if (lb != null)
                // {
                totalPrice.Text = string.Format("{0:C}", mycart.TotalPrice);
                // }
            }
            totalPrice.Text = string.Format("{0:c}", mycart.TotalPrice);
            mylist.DataSource = mycart.Table;
            mylist.DataBind();
        }

        protected void btBuyCont_Click(object sender, EventArgs e)
        {
            if (Session["BillId"] == null)
            {
                Response.Redirect("~/InformationCustomer.aspx");
            }
            else
            {
                Response.Redirect("~/InformationCustomer.aspx?BillId=" + Session["BillId"]);
            }
        }

        private void RenderData()
        {
            ltrSummoney.Text = Location.GetLanguageTag("Summoney").ToString();
            btUpdate.Text = Location.GetLanguageTag("btUpdateCard").ToString();
            btBuyCont.Text = Location.GetLanguageTag("btBuyPC").ToString();
            Button2.Text = Location.GetLanguageTag("btBuyCtinu").ToString();
            ltrDelete.Text = Location.GetLanguageTag("ltrDelete").ToString();
            ltrImages.Text = Location.GetLanguageTag("ImagesP").ToString();
            ltrProductName.Text = Location.GetLanguageTag("ImagesP").ToString();
            lbBacktotop.Text = Location.GetLanguageTag("BacktoTop").ToString();
            ltrNameCode.Text = Location.GetLanguageTag("ProductCode").ToString();
            ltrZise.Text = Location.GetLanguageTag("ltrSize").ToString();
            ltrColor.Text = Location.GetLanguageTag("ColorC").ToString();
            ltrNumber.Text = Location.GetLanguageTag("Numberc").ToString();
            ltrPrice.Text = Location.GetLanguageTag("PriceC").ToString();
            ltrMoney.Text = Location.GetLanguageTag("SumM").ToString();
            lbBreakrum.Text = Location.GetLanguageTag("DreakrunC").ToString();
            ltrCondition.Text = Location.GetLanguageTag("ltrCondition").ToString();
            ltrUpdateCard.Text = Location.GetLanguageTag("btUpdateCard").ToString();
            ltrCondition1.Text = Location.GetLanguageTag("ltrCondition1").ToString();
            ltrBuyRoduct.Text = Location.GetLanguageTag("BuyPD").ToString();
            ltrCondition2.Text = Location.GetLanguageTag("ltrCondition2").ToString();
            ltrCondition3.Text = Location.GetLanguageTag("ltrCondition3").ToString();
            ltrBuyc.Text = Location.GetLanguageTag("btBuyCtinu").ToString();
            ltrCondition4.Text = Location.GetLanguageTag("ltrCondition4").ToString();
            ltrupdatec.Text = Location.GetLanguageTag("btUpdateCard").ToString();
        }
    }
}
