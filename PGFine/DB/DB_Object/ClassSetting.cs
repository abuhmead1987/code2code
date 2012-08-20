using System;
using System.Data;
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
    public class ClassSetting
    {
        public DataTable SelectSettingByKeyValues(string KeyValues)
        {
            string strConect = System.Configuration.ConfigurationManager.AppSettings["STRING_CONNECT"].ToString();
            string strSql = "[PGF_Setting_Select] " + KeyValues;
            DataTable dt = SqlHelper.ExecuteDataset(strConect, CommandType.Text, strSql).Tables[0];

            return dt;
        }
     
        public bool UpdateSetting(string KeyValues, string Values)
        {
            string strConect = System.Configuration.ConfigurationManager.AppSettings["STRING_CONNECT"].ToString();

            string strSql = "[PGF_Setting_Update] N'" + KeyValues + "',N'" + Values + "'";
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
