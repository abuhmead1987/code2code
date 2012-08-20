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
    public partial class ChangcePassWord : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
            }
        }

        protected void cmdSave_Click(object sender, EventArgs e)
        {
            if (CheckIput() == true)
            {
                UpdatePass();
            }
        }

        private bool CheckIput()
        {
            if (txtUserName.Text.Trim().Length <= 0)
            {
                CommonClass.MessageBox.Show("Chưa nhập tên truy cập!");
                txtUserName.Focus();
                return false;
            }
            if (txtPassWordOld.Text.Trim().Length <= 0)
            {
                CommonClass.MessageBox.Show("Chưa nhập mật khẩu cũ!");
                txtPassWordOld.Focus();
                return false;
            }
            if (txtPassNew.Text.Trim().Length <= 0)
            {
                CommonClass.MessageBox.Show("Chưa nhập mật khẩu mới!");
                txtPassNew.Focus();
                return false;
            }
            if (txtPassNewAgain.Text.Trim().Length <= 0)
            {
                CommonClass.MessageBox.Show("Chưa nhập lại mật khẩu mới!");
                txtPassNewAgain.Focus();
                return false;
            }
            if (string.Compare(txtPassNew.Text.Trim(), txtPassNewAgain.Text.Trim()) != 0)
            {
                CommonClass.MessageBox.Show("Nhập lại mật khẩu mới chưa chính xác!");
                txtPassNewAgain.Focus();
                return false;
            }

            return true;
        }

        private void UpdatePass()
        {
            try
            {
                string strUserName = txtUserName.Text.Trim();
                string strPassOld = CommonClass.StringValidator.GetMD5String(txtPassWordOld.Text.Trim());
                string strPassNewAgain = CommonClass.StringValidator.GetMD5String(txtPassNewAgain.Text.Trim());
              
                DB.DB_Object.ClassAdminLogin objData = new DB.DB_Object.ClassAdminLogin();

                if (objData.UpdatePass(strUserName, strPassOld, strPassNewAgain) == true)
                {
                    CommonClass.MessageBox.Show("Mật khẩu đã được thay đổi thành công!");
                    txtUserName.Text = "";
                    txtPassWordOld.Text = "";
                    txtPassNewAgain.Text = "";
                    txtPassNew.Text = "";
                    return;
                }
                else
                    CommonClass.MessageBox.Show("Lỗi tác vụ thay đổi mật khẩu. Vui lòng kiểm tra hệ thống mạng!");
            }
            catch (Exception e)
            {
                SetErrorMessage(e.Message);
            }
        }

        // Gán lỗi khi phát sinh vào label thông báo lỗi        
        private void SetErrorMessage(string text)
        {
            _errorLabel.Text = "Thông báo : " + text;
            _errorLabel.Visible = null != text && 0 < text.Length;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Amincp/ManagerNews.aspx");
        }
    }
}
