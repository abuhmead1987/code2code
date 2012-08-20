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

namespace PGFine.Ctrl
{
    public partial class CtrlProgramsHot : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                RenderData();
                //LoadTextProgramsHot(1); // 1 là ngôn ngữ tiếng anh
            }
        }

        private void LoadTextProgramsHot(int intLanguagesID)
        {
            try
            {
                DB.DB_Object.ClassSubject objClassData = new DB.DB_Object.ClassSubject();
                DataTable dt = objClassData.getDataProgramsHot(intLanguagesID);
                DataList1.DataSource = dt;
                DataList1.DataBind();
                if (dt.Rows.Count > 0)
                {
                    DataList1.DataSource = dt;
                    DataList1.DataBind();
                }
                else
                {
                    lbNewsNull.Visible = true;
                }
            }
            catch (Exception objExc)
            {
                SetErrorMessage(objExc.Message);
            }
        }

        private void RenderData()
        {
            if (Location.GetLocation == "VIE")
            {
                LoadTextProgramsHot(2); //load tiếng việt là 2
            }
            else
            {
                LoadTextProgramsHot(1); // 1 là ngôn ngữ tiếng anh
            }
        }

        // Gán lỗi khi phát sinh vào label thông báo lỗi        
        private void SetErrorMessage(string text)
        {
            _errorLabel.Text = "Thông báo : " + text;
            _errorLabel.Visible = null != text && 0 < text.Length;
        }

    }   
}