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

namespace DB.Common
{
    public class ClassPGFCommon
    {
        /// <summary>
        /// Lấy 1 chuỗi khi truy vấn dữ liệu
        /// </summary>
        /// <returns></returns>
        string strConect = System.Configuration.ConfigurationManager.AppSettings["STRING_CONNECT"].ToString();

        public String ExecuteToString(string strSQL)
        {
            SqlDataReader drResult = SqlHelper.ExecuteReader(strConect, CommandType.Text, strSQL);

            string strResult = "";

            if (drResult.Read())
            {
              strResult =  drResult[0].ToString();
            }

            return strResult;
        }

        public String FilterSQLParamater(String strParam)
        {
            if (strParam == null)
                return "";

            String strTemp = strParam.Trim();

            try
            {
                strTemp = strTemp.Replace("'", "''");
                strTemp = strTemp.Replace(";", "");
                strTemp = strTemp.Replace("--", "");
                strTemp = strTemp.Replace("delete ", "");
                strTemp = strTemp.Replace("del ", "");
                strTemp = strTemp.Replace("set ", "");
                strTemp = strTemp.Replace("drop ", "");
                strTemp = strTemp.Replace("update ", "");
                strTemp = strTemp.Replace("select ", "");
                strTemp = strTemp.Replace("exec ", "");
                strTemp = strTemp.Replace("execute ", "");
                strTemp = strTemp.Replace("delete%", "");
                strTemp = strTemp.Replace("del%", "");
                strTemp = strTemp.Replace("set%", "");
                strTemp = strTemp.Replace("drop%", "");
                strTemp = strTemp.Replace("update%", "");
                strTemp = strTemp.Replace("select%", "");
                strTemp = strTemp.Replace("exec%", "");
                strTemp = strTemp.Replace("execute%", "");
            }
            catch (Exception) { }

            return strTemp;
        }

        public sealed class LanguagesContanst
        {
            public const int VIETNAMMESE = 1;
            public const int ENGLISH = 2;
        }

    }
}
