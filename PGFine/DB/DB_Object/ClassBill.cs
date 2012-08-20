using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using Microsoft.ApplicationBlocks.Data;

namespace DB.DB_Object
{
    public class ClassBill
    {
        /// <summary>
        /// insert bill and return bill Id
        /// </summary>
        /// <param name="IsStatus"></param>
        /// <param name="SumMoneyBill"></param>
        /// <param name="MoneyBy"></param>
        /// <param name="ReceiverBy"></param>
        /// <returns></returns>
        public int InsertBillReturnId(int IsStatus, int SumMoneyBill, int MoneyBy, int ReceiverBy, int IsWriteBill)
        {
            string strConect = System.Configuration.ConfigurationManager.AppSettings["STRING_CONNECT"].ToString();
            string strSql = "[PGF_Bill_Insert] " + IsStatus + ", " + SumMoneyBill + "," + MoneyBy + "," + ReceiverBy + "," + IsWriteBill;
            DataTable dt = SqlHelper.ExecuteDataset(strConect, CommandType.Text, strSql).Tables[0];

            return int.Parse(dt.Rows[0]["BillId"].ToString());
        }

        public DataTable InsertCustomer(int BillId,int TypeUser ,string NameOrther,string Name,string Disct,
	            string Address , string Phone , string Tel,string Email ,string Description)
        {
            string strConect = System.Configuration.ConfigurationManager.AppSettings["STRING_CONNECT"].ToString();
            string strSql = "[PGF_Customer_Insert] " + BillId + ", " + TypeUser + ",N'" + NameOrther + "',N'" + Name + "',N'" + Disct + "',N'" + Address + "',N'" + Phone + "',N'" + Tel + "',N'" + Email + "',N'" + Description + "'";
            DataTable dt = SqlHelper.ExecuteDataset(strConect, CommandType.Text, strSql).Tables[0];

            return dt;
        }

        public bool InsertBillDetail(int BillId, string ImagesProduct, string NameProduct, string CodeProduct, string Size,
                string Color, int Number, double Price, double SumMoney)
        {
            string strConect = System.Configuration.ConfigurationManager.AppSettings["STRING_CONNECT"].ToString();
            string strSql = "[PGF_BillDetail_Insert] " + BillId + ",N'" + ImagesProduct + "',N'" + NameProduct + "',N'" + CodeProduct + "',N'" + Size + "',N'" + Color + "'," + Number + "," + Price + "," + SumMoney;
            
            try
            {
                SqlHelper.ExecuteNonQuery(strConect, CommandType.Text, strSql);
                return true;
            }
            catch
            {
                return false;
            }           
        }

        public bool UpdateBill(int BillId, int IsStatus, int SumMoneyBill, int MoneyBy, int ReceiverBy, int IsWriteBill)
        {
            string strConect = System.Configuration.ConfigurationManager.AppSettings["STRING_CONNECT"].ToString();

            string strSql = "[PGF_Bill_Update] " + BillId + "," + IsStatus + "," + SumMoneyBill + "," + MoneyBy + "," + ReceiverBy + "," + IsWriteBill;
            try
            {
                SqlHelper.ExecuteNonQuery(strConect, CommandType.Text, strSql);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool UpdateEndBuyBill(int BillId, int IsStatus, double SumMoneyBill)
        {
            string strConect = System.Configuration.ConfigurationManager.AppSettings["STRING_CONNECT"].ToString();

            string strSql = "PGF_Bill_UpdateEndBuy " + BillId + "," + IsStatus + "," + SumMoneyBill;
            try
            {
                SqlHelper.ExecuteNonQuery(strConect, CommandType.Text, strSql);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool UpdateBillStatus(int BillId, int IsStatus)
        {
            string strConect = System.Configuration.ConfigurationManager.AppSettings["STRING_CONNECT"].ToString();

            string strSql = "[PGF_Bill_UpdateStatus] " + BillId + "," + IsStatus ;
            try
            {
                SqlHelper.ExecuteNonQuery(strConect, CommandType.Text, strSql);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Use in edit information customer when buy product
        /// </summary>
        /// <param name="CustomerId"></param>
        /// <param name="TypeUser"></param>
        /// <param name="NameOrther"></param>
        /// <param name="Name"></param>
        /// <param name="Disct"></param>
        /// <param name="Address"></param>
        /// <param name="Phone"></param>
        /// <param name="Tel"></param>
        /// <param name="Email"></param>
        /// <param name="Description"></param>
        /// <returns></returns>
        public bool UpdateCustomer(int BillId, int TypeUser, string NameOrther, string Name, string Disct, string Address, string Phone, string Tel,
	                                    string Email,string Description)
        {
            string strConect = System.Configuration.ConfigurationManager.AppSettings["STRING_CONNECT"].ToString();

            string strSql = "PGF_Customer_Update " + BillId + ", " + TypeUser + ",N'" + NameOrther + "',N'" + Name + "',N'" + Disct + "',N'" + Address + "',N'" + Phone + "',N'" + Tel + "',N'" + Email + "',N'" + Description + "'";
            try
            {
                SqlHelper.ExecuteNonQuery(strConect, CommandType.Text, strSql);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public DataTable SelectCustomer(int BillId)
        {
            string strConect = System.Configuration.ConfigurationManager.AppSettings["STRING_CONNECT"].ToString();
            string strSql = "[PGF_Customer_Select] " + BillId;
            DataTable dt = SqlHelper.ExecuteDataset(strConect, CommandType.Text, strSql).Tables[0];

            return dt;
        }

        public DataTable SelectBill(int BillId)
        {
            string strConect = System.Configuration.ConfigurationManager.AppSettings["STRING_CONNECT"].ToString();
            string strSql = "[PGF_Bill_Select] " + BillId;
            DataTable dt = SqlHelper.ExecuteDataset(strConect, CommandType.Text, strSql).Tables[0];

            return dt;
        }

        public bool DeleteBill(int BillId)
        {
            string strConect = System.Configuration.ConfigurationManager.AppSettings["STRING_CONNECT"].ToString();

            string strSql = "[PGF_Bill_Delete] " + BillId ;
            try
            {
                SqlHelper.ExecuteNonQuery(strConect, CommandType.Text, strSql);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public DataTable SelectBillAdmin()
        {
            string strConect = System.Configuration.ConfigurationManager.AppSettings["STRING_CONNECT"].ToString();
            string strSql = "[PGF_V_Bill_SelectAll] ";
            DataTable dt = SqlHelper.ExecuteDataset(strConect, CommandType.Text, strSql).Tables[0];

            return dt;
        }


        public DataTable BillBillDetailSelect(int intBillId)
        {
            string strConect = System.Configuration.ConfigurationManager.AppSettings["STRING_CONNECT"].ToString();
            string strSql = "[PGF_BillDetail_Select] " + intBillId;
            DataTable dt = SqlHelper.ExecuteDataset(strConect, CommandType.Text, strSql).Tables[0];

            return dt;
        }


    }
}
