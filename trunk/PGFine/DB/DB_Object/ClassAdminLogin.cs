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
using System.Text;

namespace DB.DB_Object
{    
    
    public class ClassAdminLogin
    {
        private string strUsername = "";
        private string strPassword = "";

        public string Username
        {
            get { return strUsername; }
            set { strUsername = value; }
        }

        public string Password
        {
            get { return strPassword; }
            set { strPassword = value; }
        }

        public bool CheckLogin()
        {
            string strConect = System.Configuration.ConfigurationManager.AppSettings["STRING_CONNECT"].ToString();
            string strSQL = "[PGF_Administrator_Login] '" + strUsername + "', '" + strPassword + "'";
            SqlDataReader drResult = SqlHelper.ExecuteReader(strConect, CommandType.Text, strSQL);

            if (drResult.Read())
            {
                if (!Convert.IsDBNull(drResult["Username"]))
                {
                    return true;
                }
            }

            return false;
        }

        public bool UpdatePass(string strUserName, string strPassWordOld, string strPassWordNew)
        {
            string strConect = System.Configuration.ConfigurationManager.AppSettings["STRING_CONNECT"].ToString();           
            string strSql = "PGF_Administrator_UpdatePass '" + strUserName + "','" + strPassWordOld + "','" + strPassWordNew + "'";
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
