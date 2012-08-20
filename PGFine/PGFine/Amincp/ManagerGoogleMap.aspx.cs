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

namespace PGFine.Amincp
{
    public partial class ManagerGoogleMap : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadGoogleMap("GoogleMap");
            }
        }

        private void LoadGoogleMap(string sKey)
        {
            DB.DB_Object.ClassSetting objClassData = new DB.DB_Object.ClassSetting();
            DataTable dt = objClassData.SelectSettingByKeyValues(sKey);
            if (dt.Rows.Count > 0)
            {
                txtGoogleMap.Text = dt.Rows[0]["Values"].ToString().Trim();
            }
        }


        protected void cmdSave_Click(object sender, EventArgs e)
        {
            string strValues = txtGoogleMap.Text.Trim();

            DB.DB_Object.ClassSetting objClassData = new DB.DB_Object.ClassSetting();
            if (objClassData.UpdateSetting("GoogleMap", strValues) == true)
            {
                CommonClass.MessageBox.Show("Chỉnh sửa thành công!");
            }
            else
                CommonClass.MessageBox.Show("Lỗi cập nhật thông tin google map!");
        }
    }
}
