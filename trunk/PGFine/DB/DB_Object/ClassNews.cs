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
    public class ClassNews
    {
        #region Khai báo biến toàn cục....

        DB.Common.ClassPGFCommon objPGFCommon = new DB.Common.ClassPGFCommon();

        #endregion

        #region Hàm hỗ trợ của admin...

        /// <summary>
        /// Hàm lấy thông tin toàn bộ các tin tức lên lưới
        /// </summary>
        /// <returns></returns>
        public DataTable getDataNews()
        {
            string strConect = System.Configuration.ConfigurationManager.AppSettings["STRING_CONNECT"].ToString();
            string strSql = "PGF_News_SelectAll";
            DataTable dt = SqlHelper.ExecuteDataset(strConect, CommandType.Text, strSql).Tables[0];
            return dt;
        }           
        
        // load thông tin ngành nghề lên combobox khi Tìm kiếm
        public DataTable GetDataLoadComBoxVN()
        {
            string strConect = System.Configuration.ConfigurationManager.AppSettings["STRING_CONNECT"].ToString();
            string strSql = "Select TypeNewsID, NameNewsVN from PGF_TypeNews Where IsDelete = 0";
            DataTable dt = SqlHelper.ExecuteDataset(strConect, CommandType.Text, strSql).Tables[0];
            return dt;
        }       

        /// <summary>
        /// Xóa thông tin một bài viết về tin tức
        /// </summary>
        /// <param name="NewsID"></param>
        /// <returns></returns>
        public bool DeleteNews(int NewsID)
        {
            try
            {
                string strConect = System.Configuration.ConfigurationManager.AppSettings["STRING_CONNECT"].ToString();
                string strSql = "PGF_News_Delete " + NewsID;
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
        public bool InsertNews(string strTitleNewsEL,string strTitleNewsVN, int intTypeNewsID,
            string strShortDescriptionEL,string strShortDescriptionVN,string strContentEL,
            string strContentVN, string strPathImages,int intTypeDisplay)
        {
            string strConect = System.Configuration.ConfigurationManager.AppSettings["STRING_CONNECT"].ToString();

            string strSql = "PGF_News_Insert N'" + strTitleNewsEL + "',N'" + strTitleNewsVN + "'," + intTypeNewsID + ",'"
                + strShortDescriptionEL + "',N'" + strShortDescriptionVN + "',N'" + strContentEL + "',N'"
                + strContentVN + "','" + strPathImages + "'," + intTypeDisplay;
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

        public bool UpdateNews(int NewsID, string strTitleNewsEL, string strTitleNewsVN, int intTypeNewsID,
          string strShortDescriptionEL, string strShortDescriptionVN, string strContentEL,
          string strContentVN, string strPathImages, int intReadTimes, int intTypeDisplay)
        {
            string strConect = System.Configuration.ConfigurationManager.AppSettings["STRING_CONNECT"].ToString();

            string strSql = "PGF_News_Update " + NewsID + ",N'" + strTitleNewsEL + "',N'" + strTitleNewsVN + "'," + intTypeNewsID + ",N'"
                + strShortDescriptionEL + "',N'" + strShortDescriptionVN + "',N'" + strContentEL + "',N'"
                + strContentVN + "','" + strPathImages + "' , " + intReadTimes + "," + intTypeDisplay;
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
        public DataTable getDataEditNews(int intID)
        {
            string strConect = System.Configuration.ConfigurationManager.AppSettings["STRING_CONNECT"].ToString();
            string strSql = "PGF_News_SelectByPK " + intID;

            DataTable dt = SqlHelper.ExecuteDataset(strConect, CommandType.Text, strSql).Tables[0];
            return dt;
        }

        //Kiểm tra Combobox khi Menu không là Menu cuối
        public bool CheckMenuParent(string strValue)
        {
            string strResult = objPGFCommon.ExecuteToString("Select count(TypeNewsID) as TypeNewsID from PGF_TypeNews where IsDelete = 0  and Nkey = " + strValue);

            if (strResult != "0")
                return true;

            return false;
        }

        #endregion

        public DataTable getDataNewsLanguage(int intTypeNewsID, int intLanguagesID)
        {
            string strConect = System.Configuration.ConfigurationManager.AppSettings["STRING_CONNECT"].ToString();
            string strSql = "PGF_News_SelectAll_LangguesEL " + intTypeNewsID + "," + intLanguagesID;
            DataTable dt = SqlHelper.ExecuteDataset(strConect, CommandType.Text, strSql).Tables[0];
            return dt;
        }

        public DataTable getDataNewsOrtherLanguage(int intTypeNewsID, int intLanguagesID)
        {
            string strConect = System.Configuration.ConfigurationManager.AppSettings["STRING_CONNECT"].ToString();
            string strSql = "PGF_News_SelectAll_OrtherNews_LangguesEL " + intTypeNewsID + "," + intLanguagesID;
            DataTable dt = SqlHelper.ExecuteDataset(strConect, CommandType.Text, strSql).Tables[0];
            return dt;
        }

        /// <summary>
        /// Hàm lấy thông tin toàn bộ các tin tức lên lưới
        /// </summary>
        /// <returns></returns>
        public DataTable getDataNewsDefaulTop(int strLanguages)
        {
            string strConect = System.Configuration.ConfigurationManager.AppSettings["STRING_CONNECT"].ToString();
            string strSql = "PGF_News_SelectAll_LangguesEL_Top " + strLanguages;
            DataTable dt = SqlHelper.ExecuteDataset(strConect, CommandType.Text, strSql).Tables[0];
            return dt;
        }

        /// <summary>
        /// Hàm lấy thông tin toàn bộ các tin tức lên lưới
        /// </summary>
        /// <returns></returns>
        public DataTable getDataNewsHot(int strLanguages)
        {
            string strConect = System.Configuration.ConfigurationManager.AppSettings["STRING_CONNECT"].ToString();
            string strSql = "PGF_News_SelectAll_LangguesEL_TopHot " + strLanguages;
            DataTable dt = SqlHelper.ExecuteDataset(strConect, CommandType.Text, strSql).Tables[0];
            return dt;
        }

        //lấy tên của loại tin tức để gán vào caption tiêu đề
        public string ReturTypeNews(int intTypeNewsID, int intLanguagesID)
        {
            return objPGFCommon.ExecuteToString("PGF_TypeNews_GetName " + intTypeNewsID + "," + intLanguagesID);
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

            string strSql = "PGF_News_ReadTime_Update " + intNewsID;
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

        public DataTable getDataSearchNews(int IsSelectAll, int KeyID, string NameVN, string NameEL)
        {
            string strConect = System.Configuration.ConfigurationManager.AppSettings["STRING_CONNECT"].ToString();
            string strSql = "PGF_News_SelectAll " + IsSelectAll + "," + KeyID + ",N'" + NameVN + "',N'" + NameEL + "'";

            DataTable dt = SqlHelper.ExecuteDataset(strConect, CommandType.Text, strSql).Tables[0];
            return dt;
        }

        /// <summary>
        /// get news typedisplay = 1 in TypeNews
        /// </summary>
        /// <param name="strLanguages"></param>
        /// <returns></returns>
        public DataTable getDataNewsTypeDisplay(int intTypeNewsId)
        {
            string strConect = System.Configuration.ConfigurationManager.AppSettings["STRING_CONNECT"].ToString();
            string strSql = "PGF_News_SelectByTypeDisplay " + intTypeNewsId;
            DataTable dt = SqlHelper.ExecuteDataset(strConect, CommandType.Text, strSql).Tables[0];
            return dt;
        }
        /// <summary>
        /// Gets data orther News 
        /// </summary>
        /// <param name="intTypeNewsId"></param>
        /// <returns></returns>
        public DataTable getDataNewsOrtherNews(int intTypeNewsId)
        {
            string strConect = System.Configuration.ConfigurationManager.AppSettings["STRING_CONNECT"].ToString();
            string strSql = "PGF_News_SelectOrtherNews " + intTypeNewsId;
            DataTable dt = SqlHelper.ExecuteDataset(strConect, CommandType.Text, strSql).Tables[0];
            return dt;
        }

        /// <summary>
        /// Gets data List News 
        /// </summary>
        /// <param name="intTypeNewsId"></param>
        /// <returns></returns>
        public DataTable getDataNewsList(int intTypeNewsId)
        {
            string strConect = System.Configuration.ConfigurationManager.AppSettings["STRING_CONNECT"].ToString();
            string strSql = "PGF_News_SelectList " + intTypeNewsId;
            DataTable dt = SqlHelper.ExecuteDataset(strConect, CommandType.Text, strSql).Tables[0];
            return dt;
        }





    }
}
