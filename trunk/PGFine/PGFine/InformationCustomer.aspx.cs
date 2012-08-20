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
    public partial class InformationCustomer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request["BillId"]))
                {
                    LoadDetailCustomer(int.Parse(Request["BillId"]));
                }
            }
            RenderData();
        }

        private void RenderData()
        {
            ltrInformationC.Text = Location.GetLanguageTag("InformationCustomer").ToString();
            ltrAlias.Text = Location.GetLanguageTag("Alias").ToString();
            ltrName.Text = Location.GetLanguageTag("Name").ToString().Replace("(*)", "");
            ltrDics.Text = Location.GetLanguageTag("District").ToString();
            ltrAddress.Text = Location.GetLanguageTag("Address").ToString().Replace("(*)", "");
            ltrPhone.Text = Location.GetLanguageTag("Phone").ToString().Replace("(*)", "");
            ltrTel.Text = Location.GetLanguageTag("tel").ToString();
            ltrNote.Text = Location.GetLanguageTag("Note").ToString();

            ltrAlias1.Text = Location.GetLanguageTag("Alias").ToString();
            ltrName1.Text = Location.GetLanguageTag("Name").ToString().Replace("(*)", "");
            ltrDics1.Text = Location.GetLanguageTag("District").ToString();
            ltrAddress1.Text = Location.GetLanguageTag("Address").ToString().Replace("(*)", "");
            ltrPhone1.Text = Location.GetLanguageTag("Phone").ToString().Replace("(*)", "");
            ltrTel1.Text = Location.GetLanguageTag("tel").ToString();
            lbBacktoTop.Text = Location.GetLanguageTag("BacktoTop").ToString();
            btContinute.Text = Location.GetLanguageTag("btBuyCtinu").ToString();
            ltrInformationR.Text = Location.GetLanguageTag("InformationReceiver").ToString();
            ltrLike.Text = Location.GetLanguageTag("Like").ToString();
            lbBreakrum.Text = Location.GetLanguageTag("DreakrunC").ToString();
        }

        private void LoadDetailCustomer(int intBillId)
        {
            //Load thong tin Customer
            DB.DB_Object.ClassBill objClassData = new DB.DB_Object.ClassBill();
            DataTable dt = objClassData.SelectCustomer(intBillId);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    if (int.Parse(dr["TypeUser"].ToString()) == 0)
                    {
                        txtDanhXungThanhToan.Text = dr["NameOrther"].ToString();
                        txtNameThanhToan.Text = dr["Name"].ToString();
                        txtQuanHuyenThanhToan.Text = dr["Disct"].ToString();
                        txtAddressThanhToan.Text = dr["Address"].ToString();
                        txtPhoneThanhToan.Text = dr["Phone"].ToString();
                        txtTelThanhToan.Text = dr["Tel"].ToString();
                        txtEmailThanh.Text = dr["Email"].ToString();
                        txtDescriptionThanhToan.Text = dr["Description"].ToString();
                    }
                    else
                    {
                        txtDanhxungNhan.Text = dr["NameOrther"].ToString();
                        txtNameNhan.Text = dr["Name"].ToString();
                        txtDisctNhan.Text = dr["Disct"].ToString();
                        txtAddressNhan.Text = dr["Address"].ToString();
                        txtPhoneNhan.Text = dr["Phone"].ToString();
                        txtTelNhan.Text = dr["Tel"].ToString();
                        txtEmailNhan.Text = dr["Email"].ToString();
                    }
                }
            }
        }

        protected void btContinute_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request["BillId"]))
            {
                int intBillId = int.Parse(Request["BillId"]);
                UpdateCustomerThanhToan(intBillId);
                UpdateCustomerNhan(intBillId);
                Response.Redirect("~/BillInformation.aspx?BillId=" + intBillId);
            }
            else
            {
                if (Session["BillId"]==null)
                {
                    try
                    {
                        //Insert Bill
                        int intBillId = InsertBill();

                        //IsertCustomer1
                        InsertCustomerThanhToan(intBillId);
                        //IsertCustomer2
                        InsertCustomerNhan(intBillId);

                        //Add session luu tru BillId
                        Session["BillId"] = intBillId;

                        Response.Redirect("~/ByBuyProduct.aspx?BillId=" + intBillId);
                    }
                    catch
                    {
                        CommonClass.MessageBox.Show("Lỗi thêm data.");
                        return;
                    }
                }
            }
        }

        protected void UpdateCustomerThanhToan(int intBillId)
        {
            int TypeUser = 0;
            string NameOrther = string.Empty;
            string Name = string.Empty;
            string Disct = string.Empty;
            string Address = string.Empty;
            string Phone = string.Empty;
            string Tel = string.Empty;
            string Email = string.Empty;
            string Description = string.Empty;

            NameOrther = txtDanhXungThanhToan.Text.Trim();
            Name = txtNameThanhToan.Text.Trim();
            Disct = txtQuanHuyenThanhToan.Text.Trim();
            Address = txtAddressThanhToan.Text.Trim();
            Phone = txtPhoneThanhToan.Text.Trim();
            Tel = txtTelThanhToan.Text.Trim();
            Email = txtEmailThanh.Text.Trim();
            Description = txtDescriptionThanhToan.Text.Trim();

            DB.DB_Object.ClassBill objClassData = new DB.DB_Object.ClassBill();
            try
            {
                objClassData.UpdateCustomer(intBillId, TypeUser, NameOrther, Name, Disct, Address, Phone, Tel, Email, Description);
            }
            catch
            {
                CommonClass.MessageBox.Show("Lỗi thêm thông tin người thanh toán.");
                return;
            }

        }

        protected void UpdateCustomerNhan(int intBillId)
        {
            int TypeUser = 1;  //if la nguoi nhan thi =1 nguoi thanh toan = 0
            string NameOrther = string.Empty;
            string Name = string.Empty;
            string Disct = string.Empty;
            string Address = string.Empty;
            string Phone = string.Empty;
            string Tel = string.Empty;
            string Email = string.Empty;
            string Description = string.Empty;

            NameOrther = txtDanhxungNhan.Text.Trim();
            Name = txtNameNhan.Text.Trim();
            Disct = txtDisctNhan.Text.Trim();
            Address = txtAddressNhan.Text.Trim();
            Phone = txtPhoneNhan.Text.Trim();
            Tel = txtTelNhan.Text.Trim();
            Email = txtEmailNhan.Text.Trim();

            DB.DB_Object.ClassBill objClassData = new DB.DB_Object.ClassBill();
            try
            {
                objClassData.UpdateCustomer(intBillId, TypeUser, NameOrther, Name, Disct, Address, Phone, Tel, Email, Description);
            }
            catch
            {
                CommonClass.MessageBox.Show("Lỗi thêm thông tin người nhận.");
                return;
            }

        }

        protected int InsertBill()
        {
            int intStatus = 0;
            int intSumMoneyBill =0;
	        int intMoneyBy =0;
            int intReceiverBy = 0;
            int IsWriteBill = 0;

            DB.DB_Object.ClassBill objClassData = new DB.DB_Object.ClassBill();
            try
            {
                int BillId = objClassData.InsertBillReturnId(intStatus, intSumMoneyBill, intMoneyBy, intReceiverBy, IsWriteBill);
                return BillId;
            }
            catch
            {
                CommonClass.MessageBox.Show("Lỗi kết nối đến Server. Vui lòng kiểm tra hệ thống mạng!");
                return 0;
            }
        }

        protected void InsertCustomerThanhToan(int intBillId)
        {
            int TypeUser = 0;
            string NameOrther = string.Empty;
            string Name = string.Empty;
            string Disct = string.Empty;
            string Address = string.Empty;
            string Phone = string.Empty;
            string Tel = string.Empty;
            string Email = string.Empty;
            string Description = string.Empty;

            NameOrther = txtDanhXungThanhToan.Text.Trim();
            Name = txtNameThanhToan.Text.Trim();
            Disct = txtQuanHuyenThanhToan.Text.Trim();
            Address = txtAddressThanhToan.Text.Trim();
            Phone = txtPhoneThanhToan.Text.Trim();
            Tel = txtTelThanhToan.Text.Trim();
            Email = txtEmailThanh.Text.Trim();
            Description = txtDescriptionThanhToan.Text.Trim();

            DB.DB_Object.ClassBill objClassData = new DB.DB_Object.ClassBill();
            try
            {
                objClassData.InsertCustomer(intBillId, TypeUser, NameOrther, Name, Disct, Address, Phone, Tel, Email, Description);
            }
            catch
            {
                CommonClass.MessageBox.Show("Lỗi thêm thông tin người thanh toán.");
                return;
            }

        }

        protected void InsertCustomerNhan(int intBillId)
        {
            int TypeUser = 1;  //if la nguoi nhan thi =1 nguoi thanh toan = 0
            string NameOrther = string.Empty;
            string Name = string.Empty;
            string Disct = string.Empty;
            string Address = string.Empty;
            string Phone = string.Empty;
            string Tel = string.Empty;
            string Email = string.Empty;
            string Description = string.Empty;

            NameOrther = txtDanhxungNhan.Text.Trim();
            Name = txtNameNhan.Text.Trim();
            Disct = txtDisctNhan.Text.Trim();
            Address = txtAddressNhan.Text.Trim();
            Phone = txtPhoneNhan.Text.Trim();
            Tel = txtTelNhan.Text.Trim();
            Email = txtEmailNhan.Text.Trim();            

            DB.DB_Object.ClassBill objClassData = new DB.DB_Object.ClassBill();
            try
            {
                objClassData.InsertCustomer(intBillId, TypeUser, NameOrther, Name, Disct, Address, Phone, Tel, Email, Description);
            }
            catch
            {
                CommonClass.MessageBox.Show("Lỗi thêm thông tin người nhận.");
                return;
            }

        }

        protected void chkLike_CheckedChanged(object sender, EventArgs e)
        {
            if (chkLike.Checked == true)
            {
                txtDanhxungNhan.Text = txtDanhXungThanhToan.Text.Trim();
                txtNameNhan.Text = txtNameThanhToan.Text.Trim();
                txtDisctNhan.Text = txtQuanHuyenThanhToan.Text.Trim();
                txtAddressNhan.Text = txtAddressThanhToan.Text.Trim();
                txtPhoneNhan.Text = txtPhoneThanhToan.Text.Trim();
                txtTelNhan.Text = txtTelThanhToan.Text.Trim();
                txtEmailNhan.Text = txtEmailThanh.Text.Trim();
            }
            else
            {
                txtDanhxungNhan.Text = string.Empty;
                txtNameNhan.Text = string.Empty;
                txtDisctNhan.Text = string.Empty;
                txtAddressNhan.Text = string.Empty;
                txtPhoneNhan.Text = string.Empty;
                txtTelNhan.Text = string.Empty;
                txtEmailNhan.Text = string.Empty;
            }
        }

    }
}
