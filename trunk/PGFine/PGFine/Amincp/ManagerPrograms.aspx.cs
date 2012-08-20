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
    public partial class ManagerPrograms : System.Web.UI.Page
    {

        #region Hàm Page Load....

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadGrid();
            }
        }

        #endregion

        #region Các hàm hỗ trợ...

        // Hàm load toàn bộ thông tin của chương trình giảng dạy lên lưới
        private void LoadGrid()
        {
            DB.DB_Object.ClassPrograms objClassPrograms = new DB.DB_Object.ClassPrograms();
            DataTable dt = objClassPrograms.getDataPrograms();
            lblTotalRows.Text = dt.Rows.Count.ToString();
            _grid.DataSource = dt;
            _grid.DataBind();
        }

        // Lấy thông tin theo tiêu chí tìm kiếm nhat định
        private void LoadGridSearch()
        {
            int IsSelectAll = 0;

            int KeyID = 0;
            if (txtCritId.Text.Trim().Length > 0)
                KeyID = int.Parse(txtCritId.Text.Trim());

            string NameNewsEL = CommonClass.StringValidator.GetSafeString(txtCritNameEL.Text.Trim());
            string NameNewsVN = CommonClass.StringValidator.GetSafeString(txtCridNameVN.Text.Trim());

            DB.DB_Object.ClassPrograms objClassData = new DB.DB_Object.ClassPrograms();
            DataTable dt = objClassData.getDataSearchPrograms(IsSelectAll, KeyID, NameNewsEL, NameNewsVN);

            lblTotalRows.Text = dt.Rows.Count.ToString();
            _grid.DataSource = dt;
            _grid.DataBind();
        }

        private bool CheckInputSearch()
        {

            if (txtCritId.Text.Trim().Length > 0 && !CommonClass.StringValidator.IsNumber(txtCritId.Text.Trim()))
            {
                CommonClass.MessageBox.Show("Mã phải là kiểu dữ liệu số. Yêu cầu nhập lại");
                txtCritId.Focus();
                return false;
            }

            return true;
        }

        private void SetErrorMessage(string text)
        {
            _errorLabel.Text = "Thông báo : " + text;
            _errorLabel.Visible = null != text && 0 < text.Length;
        }

        // Trả các TextBox về trạng thái trước khi tìm
        private void Clearn()
        {
            txtCritId.Text = "";
            txtCridNameVN.Text = "";
            txtCritNameEL.Text = "";
        }

        #endregion

        #region Các hàm xử lý ...

        protected void _DeleteButton_Command(object sender, CommandEventArgs e)
        {
            try
            {
                int i = 0;
                CheckBox cb;
                int id;
                DB.DB_Object.ClassPrograms objClassData = new DB.DB_Object.ClassPrograms();
                foreach (DataGridItem dgi in _grid.Items)
                {
                    cb = (CheckBox)dgi.Cells[0].Controls[1];
                    if (cb.Checked)
                    {
                        // lấy Mã số của record cần xóa...
                        id = (int)_grid.DataKeys[i];
                        // gọi hàm xóa từng record...                       
                        if (objClassData.DeletePrograms(id) > 0)
                        {
                            CommonClass.MessageBox.Show("Còn tồn tại môn học hoặc chương trình giảng dạy thuộc menu này.\nYêu cầu kiểm tra lại!");
                            return;
                        }
                    }
                    i++;
                }

                LoadGrid();
            }
            catch (Exception ex)
            {
                SetErrorMessage(ex.Message);
            }
        }

        protected void _editButton_Command(object sender, CommandEventArgs e)
        {            
            Response.Redirect("~/Amincp/ManagerProgramsEditor.aspx?Flag=Edit&ProgramsID=" + e.CommandName);
        }

        protected void _insertButton_Command(object sender, CommandEventArgs e)
        {
            Response.Redirect("~/Amincp/ManagerProgramsEditor.aspx?Flag=Insert");
        }

        protected void btnFilter_Click(object sender, EventArgs e)
        {
            if (CheckInputSearch())
                LoadGridSearch();
            Clearn();     
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            LoadGrid();
        }

        #endregion

    }
}
