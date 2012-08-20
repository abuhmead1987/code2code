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


namespace PGFine
{
    public partial class BillInformation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request["BillId"]))
                {
                    int intBillId = int.Parse(Request["BillId"]);
                    LoadCustomer(intBillId);
                    LoadPhuongThucThanhtoan(intBillId);
                }
            }
            RenderData();
        }
        private void RenderData()
        {
            lbBreakrum.Text = Location.GetLanguageTag("DreakrunC").ToString();
            ltrInformationToPay.Text = Location.GetLanguageTag("InformationCustomer").ToString();
            lbtChaceThanh.Text = Location.GetLanguageTag("Chance").ToString();
            lbtChaceNhan.Text = Location.GetLanguageTag("Chance").ToString();
            lbtPhuongThuc.Text = Location.GetLanguageTag("Chance").ToString();
            lbtGiao.Text = Location.GetLanguageTag("Chance").ToString();
            ltrInforGiao.Text = Location.GetLanguageTag("Informationexchange").ToString();
            ltrPaymentMethod.Text = Location.GetLanguageTag("PaymentMethod").ToString();
            ltrBacktotop.Text = Location.GetLanguageTag("BacktoTop").ToString();
            ltrInformtionRecer.Text = Location.GetLanguageTag("InformationReceiver").ToString();

            ltrPhoneCaption.Text = Location.GetLanguageTag("Phone").ToString().Replace(" (*)", ":");
            ltrPhoneCaption1.Text = Location.GetLanguageTag("Phone").ToString().Replace(" (*)", ":");

            ltrTelCaption.Text = Location.GetLanguageTag("tel").ToString();
            ltrTelCaption1.Text = Location.GetLanguageTag("tel").ToString();

            ltrAliasCaption.Text = Location.GetLanguageTag("Alias").ToString();
            ltrAliasCaption1.Text = Location.GetLanguageTag("Alias").ToString();

            ltrNameCaption.Text = Location.GetLanguageTag("Name").ToString().Replace(" (*)", ":");
            ltrNameCaption1.Text = Location.GetLanguageTag("Name").ToString().Replace(" (*)", ":");
            
            ltrDicsCaption.Text = Location.GetLanguageTag("District").ToString();
            ltrDicsCaption1.Text = Location.GetLanguageTag("District").ToString();
            
            lbAddressCaption.Text = Location.GetLanguageTag("Address").ToString().Replace(" (*)", ":");
            ltrAddressCaption1.Text = Location.GetLanguageTag("Address").ToString().Replace(" (*)", ":");

            btDeleteBill.Text = Location.GetLanguageTag("DeleteInformation").ToString();
            btBuy.Text = Location.GetLanguageTag("btBuyPC").ToString();
            ltrNoteCa.Text = Location.GetLanguageTag("ltrNoteCa").ToString();
            ltrDatmuahang.Text = "\"" + Location.GetLanguageTag("BuyPD").ToString() + "\"";

        }

        private void LoadCustomer(int intBillId)
        {
            DB.DB_Object.ClassBill objClassData = new DB.DB_Object.ClassBill();
            DataTable dt = objClassData.SelectCustomer(intBillId);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    if (int.Parse(dr["TypeUser"].ToString()) == 0)
                    {
                        ltrDanhXungThanh.Text = dr["NameOrther"].ToString();
                        ltrNameThanh.Text = dr["Name"].ToString();
                        ltrDictThanh.Text = dr["Disct"].ToString();
                        ltrAddressThanh.Text = dr["Address"].ToString();
                        ltrPhoneThanh.Text = dr["Phone"].ToString();
                        ltrTelThanh.Text = dr["Tel"].ToString();
                        ltrEmailThanh.Text = dr["Email"].ToString();
                    }
                    else
                    {
                        ltrDanhXung.Text = dr["NameOrther"].ToString();
                        ltrName.Text = dr["Name"].ToString();
                        ltrDict.Text = dr["Disct"].ToString();
                        ltrAddress.Text = dr["Address"].ToString();
                        ltrPhone.Text = dr["Phone"].ToString();
                        ltrTel.Text = dr["Tel"].ToString();
                        ltrEmail.Text = dr["Email"].ToString();
                    }
                }
            }
        }

        private void LoadPhuongThucThanhtoan(int intBillId)
        {
            DB.DB_Object.ClassBill objClassData = new DB.DB_Object.ClassBill();
            DataTable dt = objClassData.SelectBill(intBillId);
            if (dt.Rows.Count > 0)
            {
                if (int.Parse(dt.Rows[0]["MoneyBy"].ToString()) == 1)
                {
                    ltrThanhToanBy.Text = "Tiền mặt khi nhận hàng";
                }
                else
                {
                    ltrThanhToanBy.Text = "Chuyển khoản qua ngân hàng";
                }

                if (int.Parse(dt.Rows[0]["ReceiverBy"].ToString()) == 1)
                {
                    ltrGiaoNhanBy.Text = "Gửi hàng qua bưu điện";
                }
                else if (int.Parse(dt.Rows[0]["ReceiverBy"].ToString()) == 2)
                {
                    ltrGiaoNhanBy.Text = "Giao hàng tại địa chỉ của quý khách";
                }
                else
                {
                    ltrGiaoNhanBy.Text = "Nhận hàng tại Big Nose and Littel Toe";
                }
            }
           
        }       

        protected void btBuy_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request["BillId"]))
            {
                int intBillId = int.Parse(Request["BillId"]);
                BuyProduct(intBillId);

                Session["Cart"] = null;
                Session["BillId"] = null;

                Response.Redirect("~/Default.aspx");
            }
        }

        private void BuyProduct(int intBillId)
        {
            if (Session["Cart"] == null)
            {
                Session["Cart"] = new Cart();
            }
            Cart mycart = new Cart();
            mycart = (Cart)Session["Cart"];
            
            double strTongtien = mycart.TotalPrice;
            if (strTongtien >0)
            {
                //Update SumMoney to Bill
                DB.DB_Object.ClassBill objClassData = new DB.DB_Object.ClassBill();
                objClassData.UpdateEndBuyBill(intBillId, 1, strTongtien);

                foreach (ShoppingOnlineCart shop in mycart.Table)
                {
                    //  Inert_chiTietgiohang(Convert.ToInt32(idGiohang), shop.Ma, shop.Luong, (float)shop.Gia);
                    InsertBillDetail(intBillId, shop.ImagesPath, shop.Ten, shop.CodeProduct, shop.KichCo,Server.HtmlDecode(shop.ImagesColor), shop.Luong, shop.Gia,shop.Tong);
                }
            }
            else
            {
                Response.Write("<script>alert(\"Giỏ hàng bạn rỗng nên không thể đặt hàng!\")</script>");
            }
        }

        private void InsertBillDetail(int BillId, string ImagesProduct, string NameProduct, string CodeProduct, string Size,
                string Color, int Number, double Price, double SumMoney)
        {
            DB.DB_Object.ClassBill objClassData = new DB.DB_Object.ClassBill();
            if (objClassData.InsertBillDetail(BillId, ImagesProduct, NameProduct, CodeProduct, Size, Color,  Number,  Price,  SumMoney) == true)
            {                
            }
            else
                CommonClass.MessageBox.Show("Lỗi cập nhật thông tin thanh toán!");
        }

        protected void btDeleteBill_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request["BillId"]))
            {
                int intBillId = int.Parse(Request["BillId"]);

                DB.DB_Object.ClassBill objClassData = new DB.DB_Object.ClassBill();
                if (objClassData.DeleteBill(intBillId) == true)
                {
                    Response.Redirect("~/Default.aspx");
                }
                else
                    CommonClass.MessageBox.Show("Lỗi xoá hoá đơn!");
            }
        }

        protected void lbtChaceThanh_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request["BillId"]))
            {
                int intBillId = int.Parse(Request["BillId"]);
                Response.Redirect("~/InformationCustomer.aspx?BillId=" + intBillId);
            }
        }

        protected void lbtChaceNhan_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request["BillId"]))
            {
                int intBillId = int.Parse(Request["BillId"]);
                Response.Redirect("~/InformationCustomer.aspx?BillId=" + intBillId);
            }
        }

        protected void lbtPhuongThuc_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request["BillId"]))
            {
                int intBillId = int.Parse(Request["BillId"]);
                Response.Redirect("~/ByBuyProduct.aspx?BillId=" + intBillId);
            }
        }

        protected void lbtGiao_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request["BillId"]))
            {
                int intBillId = int.Parse(Request["BillId"]);
                Response.Redirect("~/ByBuyProduct.aspx?BillId=" + intBillId);
            }
        }
    }
}
