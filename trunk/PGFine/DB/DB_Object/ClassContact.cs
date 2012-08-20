using System;
using System.Data;
using System.Data.SqlClient;
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
    public class ClassContact
    {

        /// <summary>
        ///  Hàm thêm mới thông tin chương trình giảng dạy. Tham số truyền vào là tên loại bằng tiếng anh và tiếng việt, hàm
        ///  trả về True nếu thành công và ngược lại trả về false
        /// </summary>
        /// <param name="strNameTypeNewsEL"></param>
        /// <param name="strNameTypeNewsVN"></param>
        /// <returns></returns>
        public bool InsertContact(string strName, string strPhone, string strEmail,
            string strAddress, string strDetail)
        {
            string strConect = System.Configuration.ConfigurationManager.AppSettings["STRING_CONNECT"].ToString();

            string strSql = "PGF_Contacts_Insert N'" + strName + "','" + strPhone + "',N'" + strEmail + "',N'"
                + strAddress + "',N'" + strDetail + "'";
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

        public DataTable getDataContact() // admin lấy thông tin lên lưới hiển thị
        {
            string strConect = System.Configuration.ConfigurationManager.AppSettings["STRING_CONNECT"].ToString();
            string strSql = "PGF_Contact_SelectAll";
            DataTable dt = SqlHelper.ExecuteDataset(strConect, CommandType.Text, strSql).Tables[0];
            return dt;
        }

        public bool DeleteContact(int ContactID)
        {
            string strConect = System.Configuration.ConfigurationManager.AppSettings["STRING_CONNECT"].ToString();
            string strSql = "PGF_Contacts_Delete " + ContactID;
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

        public DataTable getDataSearchContact(int IsSelectAll, int KeyID, string Name, string Phone, string Email)
        {
            string strConect = System.Configuration.ConfigurationManager.AppSettings["STRING_CONNECT"].ToString();
            string strSql = "PGF_Contact_SelectAll " + IsSelectAll + "," + KeyID + ",N'" + Name + "',N'" + Phone + "','" + Email + "'";

            DataTable dt = SqlHelper.ExecuteDataset(strConect, CommandType.Text, strSql).Tables[0];
            return dt;
        }

        /// <summary>
        /// Gọi store lấy thông tin của TypeNews theo tiêu chí cần chỉnh sửa. Hàm trả về một DataTable
        /// </summary>
        /// <returns></returns>
        public DataTable getDataEditContact(int intID)
        {
            string strConect = System.Configuration.ConfigurationManager.AppSettings["STRING_CONNECT"].ToString();
            string strSql = "PGF_Contact_SelectByPK " + intID;

            DataTable dt = SqlHelper.ExecuteDataset(strConect, CommandType.Text, strSql).Tables[0];
            return dt;
        }

    }
}
