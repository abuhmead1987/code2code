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
    public partial class ManagerAboutUs : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadGrid();
            }
        }
        private void LoadGrid()
        {
            DB.DB_Object.AboutUs objClassData = new DB.DB_Object.AboutUs();
            DataTable dt = objClassData.getDataAboutUs();
            lblTotalRows.Text = dt.Rows.Count.ToString();
            _grid.DataSource = dt;
            _grid.DataBind();
        }

        // Lưu thông tin lỗi khi phát sinh
        private void SetErrorMessage(string text)
        {
            _errorLabel.Text = "Thông báo : " + text;
            _errorLabel.Visible = null != text && 0 < text.Length;
        }
        
        protected void _editButton_Command(object sender, CommandEventArgs e)
        {
            Response.Redirect("~/Amincp/ManagerAboutUsEditor.aspx?Flag=Edit&ChilAboutUsID=" + e.CommandName);
        }

        protected void btnFilter_Click(object sender, EventArgs e)
        {
            
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {

        }      
    }
}
