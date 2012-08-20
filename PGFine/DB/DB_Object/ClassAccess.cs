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
    public class ClassAccess
    {
        #region Khai báo biến toàn cục....

        DB.Common.ClassPGFCommon objPGFCommon = new DB.Common.ClassPGFCommon();

        #endregion

        //lấy tên của loại tin tức để gán vào caption tiêu đề
        public string ReturnCoutAccess()
        {
            return objPGFCommon.ExecuteToString("PGF_Access_GetData");
        }
        public bool UpdateCoutAccess()
        {
            string strConect = System.Configuration.ConfigurationManager.AppSettings["STRING_CONNECT"].ToString();

            string strSql = "PGF_Access_Update";
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
    }
}
