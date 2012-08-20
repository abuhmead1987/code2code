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
    public class ClassPrograms
    {
        DB.Common.ClassPGFCommon objPGFCommon = new DB.Common.ClassPGFCommon();

        /// <summary>
        /// Gọi store lấy toàn bộ thông tin của bảng TypeNews. Hàm trả về một DataTable
        /// </summary>
        /// <returns></returns>
        public DataTable getDataPrograms()
        {
            string strConect = System.Configuration.ConfigurationManager.AppSettings["STRING_CONNECT"].ToString();
            string strSql = "PGF_Programs_SelectAll";
            DataTable dt = SqlHelper.ExecuteDataset(strConect, CommandType.Text, strSql).Tables[0];
            return dt;
        }

        /// <summary>
        /// Gọi store lấy toàn bộ thông tin của bảng TypeNews theo tiêu chí tìm kiếm thích hợp. Hàm trả về một DataTable
        /// </summary>
        /// <returns></returns>
        public DataTable getDataSearchPrograms(int IsSelectAll, int KeyID, string NameNewsEL, string NameNewsVN)
        {
            string strConect = System.Configuration.ConfigurationManager.AppSettings["STRING_CONNECT"].ToString();
            string strSql = "PGF_Programs_SelectAll " + IsSelectAll + "," + KeyID + ",'" + NameNewsEL + "',N'" + NameNewsVN + "'";

            DataTable dt = SqlHelper.ExecuteDataset(strConect, CommandType.Text, strSql).Tables[0];
            return dt;
        }

        public DataTable GetDataLoadComBoxVN()
        {
            string strConect = System.Configuration.ConfigurationManager.AppSettings["STRING_CONNECT"].ToString();
            string strSql = "Select ProgramsID, NameNewsVN from PGF_Programs Where IsDelete = 0 and Nkey is null";
            DataTable dt = SqlHelper.ExecuteDataset(strConect, CommandType.Text, strSql).Tables[0];
            return dt;
        }

        /// <summary>
        /// Hàm xóa thông tin chương trình giảng dạy theo mã. Hàm trả về true nếu thành công và ngược lại là False
        /// </summary>
        /// <param name="TypeNewsID"></param>
        /// <returns></returns>
        public int DeletePrograms(int ProgramsID)
        {
            string strConect = System.Configuration.ConfigurationManager.AppSettings["STRING_CONNECT"].ToString();
            string strSql = "PGF_Programs_Delete " + ProgramsID;
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
        ///  Hàm thêm mới thông tin chương trình giảng dạy. Tham số truyền vào là tên loại bằng tiếng anh và tiếng việt, hàm
        ///  trả về True nếu thành công và ngược lại trả về false
        /// </summary>
        /// <param name="strNameTypeNewsEL"></param>
        /// <param name="strNameTypeNewsVN"></param>
        /// <returns></returns>
        public bool InsertPrograms(string strNameProgramsEL, string strNameProgramsVN, int intNKey)
        {
            string strConect = System.Configuration.ConfigurationManager.AppSettings["STRING_CONNECT"].ToString();

            String strNKey = "null";
            if (intNKey != 0)
                strNKey = intNKey.ToString();

            string strSql = "PGF_Programs_Insert '" + strNameProgramsEL + "',N'" + strNameProgramsVN + "'," + strNKey;
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
        public bool UpdatePrograms(string strNameProgramsEL, string strNameProgramsVN, int intID, int intNKey)
        {
            string strConect = System.Configuration.ConfigurationManager.AppSettings["STRING_CONNECT"].ToString();

            String strNKey = "null";
            if (intNKey != 0)
                strNKey = intNKey.ToString();

            string strSql = "PGF_Programs_Update '" + strNameProgramsEL + "',N'" + strNameProgramsVN + "'," + intID + "," + strNKey;
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
        /// Gọi store lấy thông tin của TypeNews theo tiêu chí cần chỉnh sửa. Hàm trả về một DataTable
        /// </summary>
        /// <returns></returns>
        public DataTable getDataEditPrograms(int intID)
        {
            string strConect = System.Configuration.ConfigurationManager.AppSettings["STRING_CONNECT"].ToString();
            string strSql = "PGF_Program_SelectByPK " + intID;

            DataTable dt = SqlHelper.ExecuteDataset(strConect, CommandType.Text, strSql).Tables[0];
            return dt;
        }

        /// <summary>
        /// Hàm kiểm tra xem menu có tồn tại chương trình giảng dạy trực thuộc menu này không ?
        /// </summary>
        /// <param name="strValue"></param>
        /// <returns></returns>
        public bool CheckMenuParent(string strValue)
        {
            string strResult = objPGFCommon.ExecuteToString("Select count(SubjectID) as SubjectID from PGF_Subjects where IsDelete = 0  and SubjectID = " + strValue);

            if (strResult != "0")
                return true;

            return false;
        }

        // Menu Create
        /// <summary>
        /// Gọi store lấy toàn bộ thông tin của bảng TypeNews. Hàm trả về một DataTable
        /// </summary>
        /// <returns></returns>
        public DataTable getDataProgramsCreateMenu()
        {
            string strConect = System.Configuration.ConfigurationManager.AppSettings["STRING_CONNECT"].ToString();
            string strSql = "PGF_Programs_SelectCreateMenu";
            DataTable dt = SqlHelper.ExecuteDataset(strConect, CommandType.Text, strSql).Tables[0];
            return dt;
        }

    }
}
