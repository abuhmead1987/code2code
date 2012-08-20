using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using Itech.Utils;
using CommonClass;
using System.Text;

namespace PGFine
{
    public partial class google : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadGoogleMap("GoogleMap");
            }
        }

        private void LoadGoogleMap(string KeyValues)
        {
            DB.DB_Object.ClassSetting objClassData = new DB.DB_Object.ClassSetting();
            DataTable dt = objClassData.SelectSettingByKeyValues(KeyValues);
            if (dt.Rows.Count > 0)
            {
                StringBuilder strResult = new StringBuilder();
                strResult.Append("<iframe width='962' height='452' frameborder='0' scrolling='no' marginheight='0'");
                strResult.Append(string.Format(" marginwidth='0' src='{0}'>", dt.Rows[0]["Values"].ToString().Trim() + "&amp;output=embed"));
                strResult.Append("</iframe>");
                ltrIframe.Text = strResult.ToString();
            }            
        }
        
    }
}
