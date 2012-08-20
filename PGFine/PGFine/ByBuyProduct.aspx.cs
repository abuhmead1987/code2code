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
    public partial class ByBuyProduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request["BillId"]))
                {
                    LoadPhuongThuc(int.Parse(Request["BillId"]));
                }
            }
            RenderData();
        }

        private void RenderData()
        {
            lbBreakrum.Text = Location.GetLanguageTag("DreakrunC").ToString();
            ltrPay.Text = Location.GetLanguageTag("ToPay").ToString();
            ltrExchange.Text = Location.GetLanguageTag("exchange").ToString();
            btContinute.Text = Location.GetLanguageTag("Continue").ToString();
            ltrMoneyRecer.Text = Location.GetLanguageTag("MoneyExchange").ToString();
            ltrTranscer.Text = Location.GetLanguageTag("TransferMoney").ToString();
            ltrBillWrite.Text = Location.GetLanguageTag("WriteBill").ToString();
            ltrBacktotop.Text = Location.GetLanguageTag("BacktoTop").ToString();
            ltrbyPost.Text = Location.GetLanguageTag("ByPost").ToString();
            ltrcustomer.Text = Location.GetLanguageTag("ByAddress").ToString();
            ltrCompa.Text = Location.GetLanguageTag("ByCompanyL").ToString();
            ltrInformationChance.Text = Location.GetLanguageTag("InformationChance").ToString();
            ltrChutaikhoan.Text = Location.GetLanguageTag("Chutaikhoan").ToString();
            ltrSotaiKhoan.Text = Location.GetLanguageTag("Sotaikhoan").ToString();
            ltrChinhanh.Text = Location.GetLanguageTag("Chinhanh").ToString();          
        }

        private void LoadPhuongThuc(int intBillId)
        {
            DB.DB_Object.ClassBill objClassData = new DB.DB_Object.ClassBill();
            DataTable dt = objClassData.SelectBill(intBillId);
            if (dt.Rows.Count > 0)
            {
                if (int.Parse(dt.Rows[0]["MoneyBy"].ToString()) == 1)
                {
                    rdoMoney.Checked = true;
                    rdoChance.Checked = false;
                }
                else
                {
                    rdoMoney.Checked = false;
                    rdoChance.Checked = true;
                }

                if (int.Parse(dt.Rows[0]["ReceiverBy"].ToString()) == 1)
                {
                    rdoPost.Checked = true;
                    rdoAddCustomer.Checked = false;
                    rdoCompany.Checked = false;
                }
                else if (int.Parse(dt.Rows[0]["ReceiverBy"].ToString()) == 2)
                {
                    rdoPost.Checked = false;
                    rdoAddCustomer.Checked = true;
                    rdoCompany.Checked = false;
                }
                else
                {
                    rdoPost.Checked = false;
                    rdoAddCustomer.Checked = false;
                    rdoCompany.Checked = true;
                }
            }
        }

        protected void btContinute_Click(object sender, EventArgs e)
        {
            UpdateBill();            
        }

        private void UpdateBill()
        {
            if (!string.IsNullOrEmpty(Request["BillId"]))
            {
                int BillId = int.Parse(Request["BillId"]);
                int IsStatus = 0;
                int SumMoneyBill = 0;
                int MoneyBy = 0;
                int ReceiverBy = 0;
                int IsWriteBill = 0;

                //Thong tin thanh toán
                if (rdoMoney.Checked == true)
                    MoneyBy = 1;
                if (rdoChance.Checked == true)
                    MoneyBy = 2;
                
                //Viết hoá đơn hay khong ?
                if (chkBill.Checked == true)
                    IsWriteBill = 1;

                //Thong tin nguoi nhan
                if (rdoPost.Checked == true)
                    ReceiverBy = 1;
                if (rdoAddCustomer.Checked == true)
                    ReceiverBy = 2;
                if (rdoCompany.Checked == true)
                    ReceiverBy = 3;


                DB.DB_Object.ClassBill objClassData = new DB.DB_Object.ClassBill();
                if (objClassData.UpdateBill(BillId, IsStatus, SumMoneyBill, MoneyBy, ReceiverBy, IsWriteBill) == true)
                {
                    Response.Redirect("~/BillInformation.aspx?BillId=" + BillId);
                }
                else
                    CommonClass.MessageBox.Show("Lỗi cập nhật thông tin thanh toán!");
            }
        }

        protected void rdoChance_CheckedChanged(object sender, EventArgs e)
        {
            rdoChance.Checked = true;
            rdoMoney.Checked = false;
        }

        protected void rdoMoney_CheckedChanged(object sender, EventArgs e)
        {
            rdoChance.Checked = false;
            rdoMoney.Checked = true;
        }

        protected void rdoCompany_CheckedChanged(object sender, EventArgs e)
        {
            rdoPost.Checked = false;
            rdoAddCustomer.Checked = false;
            rdoCompany.Checked = true;
        }

        protected void rdoAddCustomer_CheckedChanged(object sender, EventArgs e)
        {
            rdoPost.Checked = false;
            rdoAddCustomer.Checked = true;
            rdoCompany.Checked = false;
        }

        protected void rdoPost_CheckedChanged(object sender, EventArgs e)
        {
            rdoPost.Checked = true;
            rdoAddCustomer.Checked = false;
            rdoCompany.Checked = false;
        }


    }
}
