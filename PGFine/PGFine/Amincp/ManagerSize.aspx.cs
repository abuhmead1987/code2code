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
    public partial class ManagerSize : System.Web.UI.Page
    {
        #region Hàm hỗ trợ

        private void LoadGrid(int intProductId)
        {
            DB.DB_Object.ClassSize objClassTrainers = new DB.DB_Object.ClassSize();
            DataTable dt = objClassTrainers.getDataTrainersAdmin(1, intProductId);
            _grid.DataSource = dt;
            _grid.DataBind();
        }     

        // Gán lỗi khi phát sinh vào label thông báo lỗi        
        private void SetErrorMessage(string text)
        {
            _errorLabel.Text = "Thông báo : " + text;
            _errorLabel.Visible = null != text && 0 < text.Length;
        }
    
        #endregion

        #region Hàm xử lý

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request["ProductId"]))
                {
                    LoadGrid(int.Parse(Request["ProductID"]));
                }
            }
        }
        protected void _DeleteButton_Command(object sender, CommandEventArgs e)
        {
            try
            {
                int i = 0;
                CheckBox cb;
                int id;
                DB.DB_Object.ClassSize objClassData = new DB.DB_Object.ClassSize();
                foreach (DataGridItem dgi in _grid.Items)
                {
                    cb = (CheckBox)dgi.Cells[0].Controls[1];
                    if (cb.Checked)
                    {
                        // lấy Mã số của record cần xóa...
                        id = (int)_grid.DataKeys[i];
                        // gọi hàm xóa từng record...                       
                        if (objClassData.DeleteTrainer(id) != true)
                        {
                            CommonClass.MessageBox.Show("Lỗi không thể xóa giáo viên.\nYêu cầu kiểm tra lại!");
                            LoadGrid(int.Parse(Request["ProductID"]));
                            return;
                        }
                    }
                    i++;
                }

                LoadGrid(int.Parse(Request["ProductID"]));
            }
            catch (Exception ex)
            {
                SetErrorMessage(ex.Message);
            }
        }

        protected void _editButton_Command(object sender, CommandEventArgs e)
        {
            Response.Redirect("~/Amincp/ManagerSizeEditor.aspx?Flag=Edit&ID=" + e.CommandName);
        }

        protected void _insertButton_Command(object sender, CommandEventArgs e)
        {
            Response.Redirect("~/Amincp/ManagerSizeEditor.aspx?Flag=Insert&ProductId=" + int.Parse(Request["ProductID"]));
        }

        #endregion

        protected void _grid_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            _grid.CurrentPageIndex = e.NewPageIndex;
            LoadGrid(int.Parse(Request["ProductID"]));
        }
    }
}
