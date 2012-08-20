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
    public class ClassSubject
    {
        #region Admin...

        public DataTable GetDataSubject()
        {
            string strConect = System.Configuration.ConfigurationManager.AppSettings["STRING_CONNECT"].ToString();
            string strSql = "PGF_Subjects_SelectAll";
            DataTable dt = SqlHelper.ExecuteDataset(strConect, CommandType.Text, strSql).Tables[0];
            return dt;
        }

        /// <summary>
        /// Xóa thông tin một bài viết về Subject
        /// </summary>
        /// <param name="NewsID"></param>
        /// <returns></returns>
        public bool DeleteSubject(int SubjectID)
        {
            try
            {
                string strConect = System.Configuration.ConfigurationManager.AppSettings["STRING_CONNECT"].ToString();
                string strSql = "PGF_Subjects_Delete " + SubjectID;
                SqlHelper.ExecuteNonQuery(strConect, CommandType.Text, strSql);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Gọi store lấy thông tin của Subject theo tiêu chí cần chỉnh sửa. Hàm trả về một DataTable
        /// </summary>
        /// <returns></returns>
        public DataTable getDataEditSubject(int intID)
        {
            string strConect = System.Configuration.ConfigurationManager.AppSettings["STRING_CONNECT"].ToString();
            string strSql = "PGF_Subjects_SelectByKey " + intID;

            DataTable dt = SqlHelper.ExecuteDataset(strConect, CommandType.Text, strSql).Tables[0];
            return dt;
        }      

        public bool UpdateSubject(int SubjectID, string strTitleSubjectEL, string strTitleSubjectVN, int intTypeSubjectID,
                    string strShortDescriptionEL, string strShortDescriptionVN, string strContentEL,
                    string strContentVN, string strPathImages, int intReadTimes,int intIndexof)
        {
            string strConect = System.Configuration.ConfigurationManager.AppSettings["STRING_CONNECT"].ToString();

            string strSql = "PGF_Subjects_Update " + SubjectID + ",N'" + strTitleSubjectEL + "',N'" + strTitleSubjectVN + "'," + intTypeSubjectID + ",N'"
                + strShortDescriptionEL + "',N'" + strShortDescriptionVN + "',N'" + strContentEL + "',N'"
                + strContentVN + "',N'" + strPathImages + "', " + intReadTimes + "," + intIndexof;
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
        ///  Hàm thêm mới thông tin chương trình giảng dạy. Tham số truyền vào là tên loại bằng tiếng anh và tiếng việt, hàm
        ///  trả về True nếu thành công và ngược lại trả về false
        /// </summary>
        /// <param name="strNameTypeNewsEL"></param>
        /// <param name="strNameTypeNewsVN"></param>
        /// <returns></returns>
        public bool InsertSubjects(string strTitleNewsEL, string strTitleNewsVN, int intTypeNewsID,
            string strShortDescriptionEL, string strShortDescriptionVN, string strContentEL,
            string strContentVN, string strPathImages,int intIndexof)
        {
            string strConect = System.Configuration.ConfigurationManager.AppSettings["STRING_CONNECT"].ToString();

            string strSql = "PGF_Subjects_Insert N'" + strTitleNewsEL + "',N'" + strTitleNewsVN + "'," + intTypeNewsID + ",N'"
                + strShortDescriptionEL + "',N'" + strShortDescriptionVN + "',N'" + strContentEL + "',N'"
                + strContentVN + "',N'" + strPathImages + "'," + intIndexof;
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

        #endregion

        public DataTable getDataSubjectLanguage(int intLanguagesID)
        {
            string strConect = System.Configuration.ConfigurationManager.AppSettings["STRING_CONNECT"].ToString();
            string strSql = "PGF_Subject_SelectAll_LangguesEL " + intLanguagesID;
            DataTable dt = SqlHelper.ExecuteDataset(strConect, CommandType.Text, strSql).Tables[0];
            return dt;
        }

        public DataTable getDataProgramsHot(int intLanguagesID)
        {
            string strConect = System.Configuration.ConfigurationManager.AppSettings["STRING_CONNECT"].ToString();
            string strSql = "PGF_Subjects_SelectAll_LangguesEL_TopHot " + intLanguagesID;
            DataTable dt = SqlHelper.ExecuteDataset(strConect, CommandType.Text, strSql).Tables[0];
            return dt;
        }

        /// <summary>
        ///  Hàm thêm mới thông tin chương trình giảng dạy. Tham số truyền vào là tên loại bằng tiếng anh và tiếng việt, hàm
        ///  trả về True nếu thành công và ngược lại trả về false
        /// </summary>
        /// <param name="strNameTypeNewsEL"></param>
        /// <param name="strNameTypeNewsVN"></param>
        /// <returns></returns>
        public bool UpdateReadTimes(int intNewsID)
        {
            string strConect = System.Configuration.ConfigurationManager.AppSettings["STRING_CONNECT"].ToString();

            string strSql = "PGF_Subjects_ReadTime_Update " + intNewsID;
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

        public DataTable getDataSearchSubject(int IsSelectAll, int KeyID, string NameEL, string NameVN)
        {
            string strConect = System.Configuration.ConfigurationManager.AppSettings["STRING_CONNECT"].ToString();
            string strSql = "PGF_Subjects_SelectAll " + IsSelectAll + "," + KeyID + ",N'" + NameEL + "',N'" + NameVN + "'";

            DataTable dt = SqlHelper.ExecuteDataset(strConect, CommandType.Text, strSql).Tables[0];
            return dt;
        }

    }
}
