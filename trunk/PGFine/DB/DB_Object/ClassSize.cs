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
    public class ClassSize
    {

        DB.Common.ClassPGFCommon objPGFCommon = new DB.Common.ClassPGFCommon();

        /// <summary>
        /// Hàm lấy thông tin toàn bộ các Trainers lên Datalist
        /// </summary>
        /// <returns></returns>
        public DataTable getDataTrainers(int intProductId)
        {
            string strConect = System.Configuration.ConfigurationManager.AppSettings["STRING_CONNECT"].ToString();
            string strSql = "[Size_SelectByProductId] " + intProductId;
            DataTable dt = SqlHelper.ExecuteDataset(strConect, CommandType.Text, strSql).Tables[0];
            return dt;
        }

        /// <summary>
        /// Hàm lấy thông tin toàn bộ các Trainers lên Datalist cho trang Admin
        /// </summary>
        /// <returns></returns>
        public DataTable getDataTrainersAdmin(int intIsSelectAll, int intProductId)
        {
            string strConect = System.Configuration.ConfigurationManager.AppSettings["STRING_CONNECT"].ToString();
            string strSql = "[PGF_Size_SelectAll] " + intIsSelectAll + ", " + intProductId;
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
        public bool InsertSize(int intProductId, string strNameSize, string strPathImages1, string strPathImages2, string strPathImages3, string strPathImages4, string strPathImages5)
        {
            string strConect = System.Configuration.ConfigurationManager.AppSettings["STRING_CONNECT"].ToString();

            string strSql = "[Size_Insert] " + intProductId + ",N'" + strNameSize + "',N'" + strPathImages1 + "',N'" + strPathImages2 + "',N'"
                + strPathImages3 + "',N'" + strPathImages4 + "',N'" + strPathImages5 + "'";
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
        public bool UpdateTrainer(int intID, string strNameSize, string strPathImages1, string strPathImages2, string strPathImages3, string strPathImages4, string strPathImages5)
        {
            string strConect = System.Configuration.ConfigurationManager.AppSettings["STRING_CONNECT"].ToString();

            string strSql = "[Size_Update] " + intID + ", N'" + strNameSize + "',N'" + strPathImages1 + "',N'" + strPathImages2 + "',N'"
                + strPathImages3 + "',N'" + strPathImages4 + "',N'" + strPathImages5 + "'";
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

        public bool DeleteTrainer(int intID)
        {
            string strConect = System.Configuration.ConfigurationManager.AppSettings["STRING_CONNECT"].ToString();

            string strSql = "PGF_TrainersAndAdvisors_Delete " + intID;
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
        /// Gọi store lấy thông tin của News theo tiêu chí cần chỉnh sửa. Hàm trả về một DataTable
        /// </summary>
        /// <returns></returns>
        public DataTable getDataTrainersAndAdvisors(int intID)
        {
            string strConect = System.Configuration.ConfigurationManager.AppSettings["STRING_CONNECT"].ToString();
            string strSql = "[PGF_Size_SelectByKey] " + intID;

            DataTable dt = SqlHelper.ExecuteDataset(strConect, CommandType.Text, strSql).Tables[0];
            return dt;
        }

        //load detail Trainers
        public string LoadDetail(int ID, int LanguagesID)
        {
            string strResult = objPGFCommon.ExecuteToString("PGF_TrainersAndAdvisors_SelectDetail_LangguesEL " + ID + "," + LanguagesID);
            
            return strResult;
        }

        public DataTable getDataSearchTrainers(int IsSelectAll, int KeyID, string NameEL, string NameVN)
        {
            string strConect = System.Configuration.ConfigurationManager.AppSettings["STRING_CONNECT"].ToString();
            string strSql = "PGF_TrainersAndAdvisors_SelectAll " + IsSelectAll + "," + KeyID + ",N'" + NameEL + "',N'" + NameVN + "'";

            DataTable dt = SqlHelper.ExecuteDataset(strConect, CommandType.Text, strSql).Tables[0];
            return dt;
        }

    }
}
