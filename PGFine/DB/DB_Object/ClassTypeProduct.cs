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
    public class ClassTypeProduct
    {
        public DataTable getDataTypeProduct() // admin lấy thông tin lên lưới hiển thị
        {
            string strConect = System.Configuration.ConfigurationManager.AppSettings["STRING_CONNECT"].ToString();
            string strSql = "[PhanGia_TypeProduct_SelectAll]";
            DataTable dt = SqlHelper.ExecuteDataset(strConect, CommandType.Text, strSql).Tables[0];
            return dt;
        }

        public bool DeleteTypeProduct(int ID)
        {
            string strConect = System.Configuration.ConfigurationManager.AppSettings["STRING_CONNECT"].ToString();
            string strSql = "[PhanGia_TypeProduct_Delete] " + ID;
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

        public DataTable getDataSearchTypeProduct(int KeyID, string Name)
        {
            string strConect = System.Configuration.ConfigurationManager.AppSettings["STRING_CONNECT"].ToString();
            string strSql = "[PhanGia_TypeProduct_SelectBySearch] " + KeyID + ",N'" + Name + "'";

            DataTable dt = SqlHelper.ExecuteDataset(strConect, CommandType.Text, strSql).Tables[0];
            return dt;
        }

        public DataTable getDataEditTypeProduct(int intID)
        {
            string strConect = System.Configuration.ConfigurationManager.AppSettings["STRING_CONNECT"].ToString();
            string strSql = "[PhanGia_TypeProduct_SelectByKey] " + intID;

            DataTable dt = SqlHelper.ExecuteDataset(strConect, CommandType.Text, strSql).Tables[0];
            return dt;
        }

        public bool InsertTypeProduct(string strName, string strPath1, string strPath2, string strNameEL, string strPathImage)
        {
            string strConect = System.Configuration.ConfigurationManager.AppSettings["STRING_CONNECT"].ToString();

            string strSql = "[PhanGia_TypeProduct_Insert] N'" + strName + "','" + strPath1 + "','" + strPath2 + "',N'" + strName + "','" + strPathImage + "'";
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

        public bool UpdateTypeProduct(int intID, string strTypeName, string strPath1, string strPath2,string strNameEL,string strImagePath)
        {
            string strConect = System.Configuration.ConfigurationManager.AppSettings["STRING_CONNECT"].ToString();

            string strSql = "[PhanGia_TypeProduct_Update] " + intID + ",N'" + strTypeName + "','" + strPath1 + "','" + strPath2 + "',N'" + strNameEL + "','" + strImagePath + "'";
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

        public DataTable getDataTypeProductCreateMenu()
        {
            string strConect = System.Configuration.ConfigurationManager.AppSettings["STRING_CONNECT"].ToString();
            string strSql = "[PhanGia_TypeProduct_GetDataCreateMenu]";
            DataTable dt = SqlHelper.ExecuteDataset(strConect, CommandType.Text, strSql).Tables[0];
            return dt;

        }
    }
}
