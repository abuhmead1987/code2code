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
    public partial class ManagerCardList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadGrid();
            }
        }

        // Lấy toàn bộ thông tin từ trong table lên lưới
        private void LoadGrid()
        {
            DB.DB_Object.ClassBill objClassData = new DB.DB_Object.ClassBill();
            DataTable dt = objClassData.SelectBillAdmin();
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
            Response.Redirect("~/Amincp/ManagerCardEditor.aspx?Flag=Edit&BillID=" + e.CommandName);
        }

        protected void _insertButton_Command(object sender, CommandEventArgs e)
        {
            Response.Redirect("~/Amincp/ManagerCardEditor.aspx?Flag=Insert");
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            LoadGrid();
        }

        private void Clearn()
        {
            txtCritId.Text = "";            
        }
        protected void _DeleteButton_Command(object sender, CommandEventArgs e)
        {
            try
            {
                int i = 0;
                CheckBox cb;
                int id;
                DB.DB_Object.ClassBill objClassData = new DB.DB_Object.ClassBill();
                foreach (DataGridItem dgi in _grid.Items)
                {
                    cb = (CheckBox)dgi.Cells[0].Controls[1];
                    if (cb.Checked)
                    {
                        // lấy Mã số của record cần xóa...
                        id = (int)_grid.DataKeys[i];
                        // gọi hàm xóa từng record...                       
                        if (objClassData.DeleteBill(id) == false)
                        {
                            CommonClass.MessageBox.Show("Lỗi không thể xóa. Yêu cầu kiểm tra lại hệ thống!");
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


        private void LoadGridSearch()
        {
            int IsSelectAll = 0;

            int KeyID = 0;
            if (txtCritId.Text.Trim().Length > 0)
                KeyID = int.Parse(txtCritId.Text.Trim());

            DB.DB_Object.ClassBill objClassData = new DB.DB_Object.ClassBill();
            DataTable dt = objClassData.SelectBillAdmin();

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

        protected void _grid_PageIndexChanged1(object source, DataGridPageChangedEventArgs e)
        {
            _grid.CurrentPageIndex = e.NewPageIndex;
            LoadGrid();
        }

        protected void _grid_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            Label lbStatus = e.Item.FindControl("lbStatus") as Label;
            DataRowView dr = (DataRowView)e.Item.DataItem;
            if (int.Parse(dr["Status"].ToString()) == 1)
            {
                lbStatus.Text = "Chưa xem";
            }
            else
            {
                lbStatus.Text = "Đã xem";
                
            }
        }    


    }
}
