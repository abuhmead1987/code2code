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
    public partial class ManagerAdvisors : System.Web.UI.Page
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
            DB.DB_Object.ClassAdvisors objClassTrainers = new DB.DB_Object.ClassAdvisors();
            DataTable dt = objClassTrainers.getDataAdvisorsAdmin(1, 0, "", "");
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

        protected void btnClear_Click(object sender, EventArgs e)
        {
            LoadGrid();
        }
        
        private void LoadGridSearch()
        {
            int IsSelectAll = 0;

            int KeyID = 0;
            if (txtID.Text.Trim().Length > 0)
                KeyID = int.Parse(txtID.Text.Trim());

            string NameEL = CommonClass.StringValidator.GetSafeString(txtNameEL.Text.Trim());
            string NameVN = CommonClass.StringValidator.GetSafeString(txtNameVN.Text.Trim());

            DB.DB_Object.ClassAdvisors objClassData = new DB.DB_Object.ClassAdvisors();
            DataTable dt = objClassData.getDataSearchAdvisors(IsSelectAll, KeyID, NameEL, NameVN);

            lblTotalRows.Text = dt.Rows.Count.ToString();
            _grid.DataSource = dt;
            _grid.DataBind();
        }

        private bool CheckInputSearch()
        {

            if (txtID.Text.Trim().Length > 0 && !CommonClass.StringValidator.IsNumber(txtID.Text.Trim()))
            {
                CommonClass.MessageBox.Show("Mã phải là kiểu dữ liệu số. Yêu cầu nhập lại");
                txtID.Focus();
                return false;
            }

            return true;
        }

        private void Clearn()
        {
            txtID.Text = "";
            txtNameEL.Text = "";
            txtNameVN.Text = "";
        }

        protected void btnFilter_Click(object sender, EventArgs e)
        {
            if (CheckInputSearch())
                LoadGridSearch();
            Clearn();
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
                            LoadGrid();
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
            Response.Redirect("~/Amincp/ManagerAdvisorsEditor.aspx?Flag=Edit&ID=" + e.CommandName);
        }

        protected void _insertButton_Command(object sender, CommandEventArgs e)
        {
            Response.Redirect("~/Amincp/ManagerAdvisorsEditor.aspx?Flag=Insert");
        }

        protected void _grid_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            _grid.CurrentPageIndex = e.NewPageIndex;
            LoadGrid();
        }
    }
}
