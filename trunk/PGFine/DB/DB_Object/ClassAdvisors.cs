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
    public class ClassAdvisors
    {
        DB.Common.ClassPGFCommon objPGFCommon = new DB.Common.ClassPGFCommon();

        /// <summary>
        /// User lấy danh sách thông tin của Advisors theo dang list
        /// </summary>
        /// <returns></returns>
        public DataTable getDataAdvisors(int strLanguages)
        {
            string strConect = System.Configuration.ConfigurationManager.AppSettings["STRING_CONNECT"].ToString();
            string strSql = "PGF_TrainersAndAdvisors_SelectAll_LangguesEL_Advisors " + strLanguages;
            DataTable dt = SqlHelper.ExecuteDataset(strConect, CommandType.Text, strSql).Tables[0];
            return dt;
        }

        //load detail Advisors
        public string LoadDetail(int ID, int LanguagesID)
        {
            string strResult = objPGFCommon.ExecuteToString("PGF_TrainersAndAdvisors_SelectDetail_LangguesEL_Advisors " + ID + "," + LanguagesID);

            return strResult;
        }

        /// <summary>
        /// Hàm lấy thông tin toàn bộ các Trainers lên Datalist cho trang Admin
        /// </summary>
        /// <returns></returns>
        public DataTable getDataAdvisorsAdmin(int intIsSelectAll, int intID, String strNameEL, String strNameVN)
        {
            string strConect = System.Configuration.ConfigurationManager.AppSettings["STRING_CONNECT"].ToString();
            string strSql = "PGF_TrainersAndAdvisors_SelectAll_advisors " + intIsSelectAll + ", " + intID + ", '" + strNameEL + "', N'" + strNameVN + "'";
            DataTable dt = SqlHelper.ExecuteDataset(strConect, CommandType.Text, strSql).Tables[0];
            return dt;
        }

        /// <summary>
        ///  Hàm thêm mới thông tin giảng viên. Tham số truyền vào là tên loại bằng tiếng anh và tiếng việt, hàm
        ///  trả về True nếu thành công và ngược lại trả về false
        /// </summary>
        /// <param name="strNameTypeNewsEL"></param>
        /// <param name="strNameTypeNewsVN"></param>
        /// <returns></returns>
        public bool InsertTrainer(string strNameEL, string strNameVN, string strShortDescriptionEL,
                                    string strShortDescriptionVN, string strContentEL, string strContentVN,
                                    string strPathImages, int intIndexOf
                                 )
        {
            string strConect = System.Configuration.ConfigurationManager.AppSettings["STRING_CONNECT"].ToString();

            string strSql = "PGF_TrainersAndAdvisors_Insert_Advisors N'" + strNameEL + "',N'" + strNameVN + "',N'" + strShortDescriptionEL + "',N'"
                + strShortDescriptionVN + "',N'" + strContentEL + "',N'" + strContentVN + "',N'"
                + strPathImages + "'," + intIndexOf;
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
        ///  Hàm thêm mới thông tin giảng viên. Tham số truyền vào là tên loại bằng tiếng anh và tiếng việt, hàm
        ///  trả về True nếu thành công và ngược lại trả về false
        /// </summary>
        /// <param name="strNameTypeNewsEL"></param>
        /// <param name="strNameTypeNewsVN"></param>
        /// <returns></returns>
        public bool UpdateTrainer(int intID, string strNameEL, string strNameVN, string strShortDescriptionEL,
                                    string strShortDescriptionVN, string strContentEL, string strContentVN,
                                    string strPathImages, int intIndexOf
                                 )
        {
            string strConect = System.Configuration.ConfigurationManager.AppSettings["STRING_CONNECT"].ToString();

            string strSql = "PGF_TrainersAndAdvisors_Update_Advisors " + intID + ", N'" + strNameEL + "',N'" + strNameVN + "',N'" + strShortDescriptionEL + "',N'"
                + strShortDescriptionVN + "',N'" + strContentEL + "',N'" + strContentVN + "',N'"
                + strPathImages + "'," + intIndexOf;
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

        public DataTable getDataSearchAdvisors(int IsSelectAll, int KeyID, string NameEL, string NameVN)
        {
            string strConect = System.Configuration.ConfigurationManager.AppSettings["STRING_CONNECT"].ToString();
            string strSql = "PGF_TrainersAndAdvisors_SelectAll_advisors " + IsSelectAll + "," + KeyID + ",N'" + NameEL + "',N'" + NameVN + "'";

            DataTable dt = SqlHelper.ExecuteDataset(strConect, CommandType.Text, strSql).Tables[0];
            return dt;
        }

    }
}
