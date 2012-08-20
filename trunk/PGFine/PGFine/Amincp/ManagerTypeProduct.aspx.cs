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
    public partial class ManagerTypeProduct : System.Web.UI.Page
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
            DB.DB_Object.ClassTypeProduct objData = new DB.DB_Object.ClassTypeProduct();
            DataTable dt = objData.getDataTypeProduct();
            _grid.DataSource = dt;
            _grid.DataBind();
        }

        // Gán lỗi khi phát sinh vào label thông báo lỗi        
        private void SetErrorMessage(string text)
        {
            _errorLabel.Text = "Thông báo : " + text;
            _errorLabel.Visible = null != text && 0 < text.Length;
        }

        // Trả các TextBox về trạng thái trước khi tìm
        private void Clearn()
        {

            txtCritId.Text = "";
            txtName.Text = "";
        
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

        // Lấy thông tin theo tiêu chí tìm kiếm nhat định
        private void LoadGridSearch()
        {
            int KeyID = 0;
            if (txtCritId.Text.Trim().Length > 0)
                KeyID = int.Parse(txtCritId.Text.Trim());

            string Name = CommonClass.StringValidator.GetSafeString(txtName.Text.Trim());

            DB.DB_Object.ClassTypeProduct objClassData = new DB.DB_Object.ClassTypeProduct();
            DataTable dt = objClassData.getDataSearchTypeProduct(KeyID, Name);

            lblTotalRows.Text = dt.Rows.Count.ToString();
            _grid.DataSource = dt;
            _grid.DataBind();
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

        protected void _grid_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            _grid.CurrentPageIndex = e.NewPageIndex;
            LoadGrid();
        }

        protected void _DeleteButton_Command(object sender, CommandEventArgs e)
        {
            try
            {
                int i = 0;
                CheckBox cb;
                int id;
                DB.DB_Object.ClassTypeProduct objClassData = new DB.DB_Object.ClassTypeProduct();
                foreach (DataGridItem dgi in _grid.Items)
                {
                    cb = (CheckBox)dgi.Cells[0].Controls[1];
                    if (cb.Checked)
                    {
                        // lấy Mã số của record cần xóa...
                        id = (int)_grid.DataKeys[i];
                        // gọi hàm xóa từng record...                       
                        if (objClassData.DeleteTypeProduct(id) == false)
                        {
                            CommonClass.MessageBox.Show("Lỗi không thể xóa phần loại sản phẩm này!");
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
            Response.Redirect("~/Amincp/ManagerTypeProductEditor.aspx?Flag=Edit&ID=" + e.CommandName);
        }

        protected void _insertButton_Command(object sender, CommandEventArgs e)
        {
            Response.Redirect("~/Amincp/ManagerTypeProductEditor.aspx?Flag=Insert");
        }
    }
}
