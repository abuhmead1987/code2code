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
    public partial class ManagerTypeNews : System.Web.UI.Page
    {

        #region Khai báo biến...

        #endregion

        #region Hàm PageLoad...

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {               
                LoadGrid();
            }
        }

        #endregion

        #region Các hàm hỗ trợ...

        // Lấy toàn bộ thông tin từ trong table lên lưới
        private void LoadGrid()
        {
            DB.DB_Object.ClassTypeNews objClassData = new DB.DB_Object.ClassTypeNews();
            DataTable dt = objClassData.getDataTypeNews();
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

        // Lấy thông tin theo tiêu chí tìm kiếm nhat định
        private void LoadGridSearch()
        {
            int IsSelectAll = 0;

            int KeyID = 0;
            if (txtCritId.Text.Trim().Length > 0)
                KeyID = int.Parse(txtCritId.Text.Trim());

            string NameNewsEL = CommonClass.StringValidator.GetSafeString(txtCritNameEL.Text.Trim());
            string NameNewsVN = CommonClass.StringValidator.GetSafeString(txtCridNameVN.Text.Trim());

            DB.DB_Object.ClassTypeNews objClassData = new DB.DB_Object.ClassTypeNews();
            DataTable dt = objClassData.getDataSearchTypeNews(IsSelectAll, KeyID, NameNewsEL, NameNewsVN);
            
            lblTotalRows.Text = dt.Rows.Count.ToString();
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
            txtCridNameVN.Text = "";
            txtCritNameEL.Text = "";

        }


        #endregion

        #region Các hàm xữ lý...

        protected void _editButton_Command(object sender, CommandEventArgs e)
        {
            Response.Redirect("~/Amincp/ManagerTypeNewsEditor.aspx?Flag=Edit&TypeNewsID=" + e.CommandName);
        }

        protected void _insertButton_Command(object sender, CommandEventArgs e)
        {
            Response.Redirect("~/Amincp/ManagerTypeNewsEditor.aspx?Flag=Insert");
        }

        protected void _DeleteButton_Command(object sender, CommandEventArgs e)
        {
            try
            {
                int i = 0;
                CheckBox cb;
                int id;
                DB.DB_Object.ClassTypeNews objClassData = new DB.DB_Object.ClassTypeNews();
                foreach (DataGridItem dgi in _grid.Items)
                {
                    cb = (CheckBox)dgi.Cells[0].Controls[1];
                    if (cb.Checked)
                    {
                        // lấy Mã số của record cần xóa...
                        id = (int)_grid.DataKeys[i];
                        // gọi hàm xóa từng record...                       
                        if (objClassData.DeleteTypeNews(id) > 0)
                        {
                            CommonClass.MessageBox.Show("Còn tồn tại tin tức hoặc loại tin tức thuộc menu này.\nYêu cầu kiểm tra lại!");
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

        protected void btnClear_Click(object sender, EventArgs e)
        {
            LoadGrid();
        }

        protected void btnFilter_Click(object sender, EventArgs e)
        {
            if (CheckInputSearch())
                LoadGridSearch();
            Clearn();            
        }

        protected void _grid_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            _grid.CurrentPageIndex = e.NewPageIndex;
            LoadGrid();
        }

        #endregion           
       
    }
}
