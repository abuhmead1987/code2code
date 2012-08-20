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
    public class ClassTypeAboutUs
    {



        // Menu Create
        /// <summary>
        /// Gọi store lấy toàn bộ thông tin của bảng TypeNews. Hàm trả về một DataTable
        /// </summary>
        /// <returns></returns>
        public DataTable getDataAboutUsCreateMenu()
        {
            string strConect = System.Configuration.ConfigurationManager.AppSettings["STRING_CONNECT"].ToString();
            string strSql = "PGF_TypeAboutUs_SelectCreateMenu";
            DataTable dt = SqlHelper.ExecuteDataset(strConect, CommandType.Text, strSql).Tables[0];
            return dt;
        }

    }
}
