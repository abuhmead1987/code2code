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

namespace PGFine.Amincp
{
    public partial class ManagerCardEditor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request["BillID"]))
                {
                    int intBillId = int.Parse(Request["BillID"]);
                    LoadDetailProduct(intBillId);
                    LoadCustomer(intBillId);
                    LoadPhuongThucThanhtoan(intBillId);
                    //Load is write bill
                    LoadDetailbill(intBillId);
                }
            }
        }

        private void LoadDetailbill(int intBillId)
        {
            DB.DB_Object.ClassBill objClassData = new DB.DB_Object.ClassBill();
            DataTable dt = objClassData.SelectBill(intBillId);
            if (dt.Rows.Count > 0)
            {
                if (int.Parse(dt.Rows[0]["IsWriteBill"].ToString()) == 1)
                    chkBill.Checked = true;

                dropStatus.SelectedValue = dt.Rows[0]["IsStatus"].ToString();
            }
        }

        private void LoadDetailProduct(int intBillId)
        {
            DB.DB_Object.ClassBill objClassData = new DB.DB_Object.ClassBill();
            DataTable dt = objClassData.BillBillDetailSelect(intBillId);
            if (dt.Rows.Count > 0)
            {
                mylist.DataSource = dt;
                mylist.DataBind();
            }
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

        protected void btBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Amincp/ManagerCardList.aspx");
        }

        protected void btUpdate_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request["BillID"]))
            {
                int intBillId = int.Parse(Request["BillID"]);
                int intStatus = int.Parse(dropStatus.SelectedValue);
                //Update SumMoney to Bill
                DB.DB_Object.ClassBill objClassData = new DB.DB_Object.ClassBill();
                objClassData.UpdateBillStatus(intBillId, intStatus);
                Response.Redirect("~/Amincp/ManagerCardList.aspx");
            }
        }       
    }
}
