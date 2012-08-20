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
    public class ClassProduct
    {
        public DataTable getDataProduct() // admin lấy thông tin lên lưới hiển thị
        {
            string strConect = System.Configuration.ConfigurationManager.AppSettings["STRING_CONNECT"].ToString();
            string strSql = "[PhanGia_Product_SelectAll]";
            DataTable dt = SqlHelper.ExecuteDataset(strConect, CommandType.Text, strSql).Tables[0];
            return dt;
        }

        public DataTable getDataProductUser(int intProductID) // admin lấy thông tin lên lưới hiển thị
        {
            string strConect = System.Configuration.ConfigurationManager.AppSettings["STRING_CONNECT"].ToString();
            string strSql = "[PhanGia_Product_SelectByTypeProduct] " + intProductID;
            DataTable dt = SqlHelper.ExecuteDataset(strConect, CommandType.Text, strSql).Tables[0];
            return dt;
        }

        public DataTable getDataProductCreateMenu() // admin lấy thông tin lên lưới hiển thị
        {
            string strConect = System.Configuration.ConfigurationManager.AppSettings["STRING_CONNECT"].ToString();
            string strSql = "[PhanGia_Product_SelectAllCreateMenu]";
            DataTable dt = SqlHelper.ExecuteDataset(strConect, CommandType.Text, strSql).Tables[0];
            return dt;
        }

        public bool DeleteProduct(int ID)
        {
            string strConect = System.Configuration.ConfigurationManager.AppSettings["STRING_CONNECT"].ToString();
            string strSql = "[PhanGia_Product_Delete] " + ID;
            try
            {
                SqlHelper.ExecuteNonQuery(strConect, CommandType.Text, strSql);
                return true;
            }
            catch
            {
            }

            return false;
        }

        public DataTable getDataSearchProduct(int KeyID, int TypeProductID, string NameProduct)
        {
            string strConect = System.Configuration.ConfigurationManager.AppSettings["STRING_CONNECT"].ToString();
            string strSql = "[PhanGia_Product_SelectBySearch] " + KeyID + "," + TypeProductID + ",N'" + NameProduct + "'";

            DataTable dt = SqlHelper.ExecuteDataset(strConect, CommandType.Text, strSql).Tables[0];
            return dt;
        }

        /// <summary>
        /// Get vote of Product by Product ID
        /// </summary>
        /// <param name="ProductId"></param>
        /// <returns></returns>
        public DataTable getVote(int ProductId)
        {
            string strConect = System.Configuration.ConfigurationManager.AppSettings["STRING_CONNECT"].ToString();
            string strSql = "[PGF_Vote_Select] " + ProductId;

            DataTable dt = SqlHelper.ExecuteDataset(strConect, CommandType.Text, strSql).Tables[0];
            return dt;
        }

        public DataTable getDataEditProduct(int intID)
        {
            string strConect = System.Configuration.ConfigurationManager.AppSettings["STRING_CONNECT"].ToString();
            string strSql = "[PhanGia_Product_SelectByKey] " + intID;

            DataTable dt = SqlHelper.ExecuteDataset(strConect, CommandType.Text, strSql).Tables[0];
            return dt;
        }

        public bool InsertProduct(int TypeProduct, string NameProduct, string ShortDescription, string Description, string ImagesProduct,
            int intPride, int intPriceNew, string strCodeProduct, string strStatus, string ImagesOver, string NameProductEL, string ShortDescriptionEL, string strStatusEL)
        {
            string strConect = System.Configuration.ConfigurationManager.AppSettings["STRING_CONNECT"].ToString();

            string strSql = "[PhanGia_Product_Insert] " + TypeProduct + ", N'" + NameProduct + "',N'" + ShortDescription + "',N'" + Description + "',N'" + ImagesProduct + "'," + intPride + "," + intPriceNew + ",'" + strCodeProduct + "',N'" + strStatus + "','" + ImagesOver + "',N'" + NameProductEL + "',N'" + ShortDescriptionEL + "',N'" + strStatusEL + "'";
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

        public bool InsertVote(int ProductId, int intVote)
        {
            string strConect = System.Configuration.ConfigurationManager.AppSettings["STRING_CONNECT"].ToString();

            string strSql = "PGF_Vote_Insert " + ProductId + "," + intVote;
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

        public bool UpdateProduct(int ProductID, int TypeProduct, string NameProduct, string ShortDescription,
            string Description, string ImagesProduct, int intPride, int intPriceNew, string strStatus, string ImagesOver, string NameProductEL, string ShortDescriptionEL, string strStatusEL)
        {
            string strConect = System.Configuration.ConfigurationManager.AppSettings["STRING_CONNECT"].ToString();

            string strSql = "[PhanGia_Product_Update] " + ProductID + "," + TypeProduct + ", N'" + NameProduct + "',N'" + ShortDescription + "',N'" + Description + "',N'" + ImagesProduct + "'," + intPride + "," + intPriceNew + ",N'" + strStatus + "','" + ImagesOver + "',N'" + NameProductEL + "',N'" + ShortDescriptionEL + "',N'" + strStatusEL + "'";
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

        public DataTable getDataProductDefaule() // admin lấy thông tin lên lưới hiển thị
        {
            string strConect = System.Configuration.ConfigurationManager.AppSettings["STRING_CONNECT"].ToString();
            string strSql = "[PhanGia_Product_SelectDefault]";
            DataTable dt = SqlHelper.ExecuteDataset(strConect, CommandType.Text, strSql).Tables[0];
            return dt;
        }

    }
}
