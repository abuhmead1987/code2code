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
    public class ClassTypeNews
    {

        DB.Common.ClassPGFCommon objPGFCommon = new DB.Common.ClassPGFCommon();

        /// <summary>
        /// Gọi store lấy toàn bộ thông tin của bảng TypeNews. Hàm trả về một DataTable
        /// </summary>
        /// <returns></returns>
        public DataTable getDataTypeNews()
        {
            string strConect = System.Configuration.ConfigurationManager.AppSettings["STRING_CONNECT"].ToString();
            string strSql = "PGF_TypeNews_SelectAll";
            DataTable dt = SqlHelper.ExecuteDataset(strConect, CommandType.Text, strSql).Tables[0];
            return dt;

        }

        public DataTable getDataTypeNewsByNkey(int intNkey)
        {
            string strConect = System.Configuration.ConfigurationManager.AppSettings["STRING_CONNECT"].ToString();
            string strSql = "[PGF_TypeNews_SelectByNkey] " + intNkey;
            DataTable dt = SqlHelper.ExecuteDataset(strConect, CommandType.Text, strSql).Tables[0];
            return dt;

        }

        public DataTable getDataTypeNewsByPositionDisPlay(int intPositionDisPlay)
        {
            string strConect = System.Configuration.ConfigurationManager.AppSettings["STRING_CONNECT"].ToString();
            string strSql = "[PGF_AboutUs_SelectByPositionDisPlay] " + intPositionDisPlay;
            DataTable dt = SqlHelper.ExecuteDataset(strConect, CommandType.Text, strSql).Tables[0];
            return dt;

        }

        /// <summary>
        /// Hàm xóa thông tin loại tin tức theo mã của loại tin. Hàm trả về true nếu thành công và ngược lại là False
        /// </summary>
        /// <param name="TypeNewsID"></param>
        /// <returns></returns>
        public int DeleteTypeNews(int TypeNewsID)
        {
            string strConect = System.Configuration.ConfigurationManager.AppSettings["STRING_CONNECT"].ToString();
            string strSql = "PGF_TypeNews_Delete " + TypeNewsID;
            try
            {
                SqlDataReader drResult = SqlHelper.ExecuteReader(strConect, CommandType.Text, strSql);
                if (drResult.Read())
                {
                    return Convert.ToInt16(drResult[0]);
                }                
            }
            catch
            {                
            }

            return 3;
        }

        /// <summary>
        /// Gọi store lấy toàn bộ thông tin của bảng TypeNews theo tiêu chí tìm kiếm thích hợp. Hàm trả về một DataTable
        /// </summary>
        /// <returns></returns>
        public DataTable getDataSearchTypeNews(int IsSelectAll, int KeyID, string NameNewsEL, string NameNewsVN)
        {
            string strConect = System.Configuration.ConfigurationManager.AppSettings["STRING_CONNECT"].ToString();
            string strSql = "PGF_TypeNews_SelectAll " + IsSelectAll + "," + KeyID + ",'" + NameNewsEL + "',N'" + NameNewsVN + "'";

            DataTable dt = SqlHelper.ExecuteDataset(strConect, CommandType.Text, strSql).Tables[0];
            return dt;
        }

        /// <summary>
        /// Gọi store lấy thông tin của TypeNews theo tiêu chí cần chỉnh sửa. Hàm trả về một DataTable
        /// </summary>
        /// <returns></returns>
        public DataTable getDataEditTypeNews(int intID)
        {
            string strConect = System.Configuration.ConfigurationManager.AppSettings["STRING_CONNECT"].ToString();
            string strSql = "PGF_TypeNews_SelectByPK " + intID;

            DataTable dt = SqlHelper.ExecuteDataset(strConect, CommandType.Text, strSql).Tables[0];
            return dt;
        }

        /// <summary>
        ///  Hàm thêm mới thông tin loại tin tức. Tham số truyền vào là tên loại bằng tiếng anh và tiếng việt, hàm
        ///  trả về True nếu thành cong và ngược lại trả về false
        /// </summary>
        /// <param name="strNameTypeNewsEL"></param>
        /// <param name="strNameTypeNewsVN"></param>
        /// <returns></returns>
        public bool InsertTypeNews(string strNameTypeNewsEL, string strNameTypeNewsVN, int intNKey, 
            int intTypeDisplay, int intPositionDisPlay, string strImagePath, int intOrderNo,string strPageLink)
        {
            string strConect = System.Configuration.ConfigurationManager.AppSettings["STRING_CONNECT"].ToString();

            String strNKey = "null";
            if (intNKey != 0)
                strNKey = intNKey.ToString();

            string strSql = "PGF_TypeNews_Insert N'" + strNameTypeNewsEL + "',N'" + strNameTypeNewsVN + "'," + strNKey + "," + intTypeDisplay + "," + intPositionDisPlay + ",'" + strImagePath + "'," + intOrderNo + ",'" + strPageLink + "'";
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
        /// Hàm cập nhật thông tin loại tin tức. Hàm trả về True thành công và ngược lại là False
        /// </summary>
        /// <param name="strNameTypeNewsEL"></param>
        /// <param name="strNameTypeNewsVN"></param>
        /// <param name="intID"></param>
        /// <returns></returns>
        public bool UpdateTypeNews(string strNameTypeNewsEL, string strNameTypeNewsVN, int intID, int intNKey,
            int intTypeDisplay, int intPositionDisplay, string strImagePath, int intOrderNo, string strPageLink)
        {
            string strConect = System.Configuration.ConfigurationManager.AppSettings["STRING_CONNECT"].ToString();

            String strNKey = "null";
            if (intNKey != 0)
                strNKey = intNKey.ToString();

            string strSql = "PGF_TypeNews_Update N'" + strNameTypeNewsEL + "',N'" + strNameTypeNewsVN + "'," + intID + "," + strNKey + "," + intTypeDisplay + "," + intPositionDisplay + ",'" + strImagePath + "'," + intOrderNo + ",'" + strPageLink + "'"; 
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
        /// Lấy thông tin vào ComboBox Menu Cha
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataLoadComBoxVN()
        {
            string strConect = System.Configuration.ConfigurationManager.AppSettings["STRING_CONNECT"].ToString();
            string strSql = "Select TypeNewsID, NameNewsVN from PGF_TypeNews Where IsDelete = 0 and Nkey is null";
            DataTable dt = SqlHelper.ExecuteDataset(strConect, CommandType.Text, strSql).Tables[0];
            return dt;
        }

        /// <summary>
        /// Hàm kiểm tra xem menu có tồn tại tin tức trực thuộc menu này không
        /// </summary>
        /// <param name="strValue"></param>
        /// <returns></returns>
        public bool CheckMenuParent(string strValue)
        {
            string strResult = objPGFCommon.ExecuteToString("Select count(NewsID) as NewsID from PGF_News where IsDelete = 0  and TypeNewsID = " + strValue);

            if (strResult != "0")
                return true;

            return false;
        }



        //Menu News
        /// <summary>
        /// Gọi store lấy toàn bộ thông tin của bảng TypeNews. Hàm trả về một DataTable
        /// </summary>
        /// <returns></returns>
        public DataTable getDataTypeNewsCreateMenu()
        {
            string strConect = System.Configuration.ConfigurationManager.AppSettings["STRING_CONNECT"].ToString();
            string strSql = "PGF_TypeNews_SelectCreateMenu";
            DataTable dt = SqlHelper.ExecuteDataset(strConect, CommandType.Text, strSql).Tables[0];
            return dt;

        }
    }
}
