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
    public partial class CtrlContact : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                RenderData();
            }
        }

        #region Hàm hỗ trợ...
        
        private void InsertContact()
        {
            try
            {
                string strName = CommonClass.StringValidator.GetSafeString(txtName.Text.Trim());
                string strPhone = CommonClass.StringValidator.GetSafeString(txtPhone.Text.Trim());
                string strEmail = CommonClass.StringValidator.GetSafeString(txtEmail.Text.Trim());
                string strAddress = CommonClass.StringValidator.GetSafeString(txtAddress.Text.Trim());
                string strDetail = CommonClass.StringValidator.GetSafeString(txtContent.Text.Trim());
                             
                DB.DB_Object.ClassContact objClassData = new DB.DB_Object.ClassContact();
                if (objClassData.InsertContact(strName, strPhone, strEmail,strAddress, strDetail) == true)
                {
                   // BeginAgain();
                    //Response.Write(string.Format("<script type=\"text/javascript\">alert(\"{0}\")</script>", "Thông tin được gửi thành công"));
                    ltrSuccess.Visible = true;
                    return;
                }
                else
                    CommonClass.MessageBox.Show("Lỗi kết nối đến Server. Vui lòng kiểm tra hệ thống mạng!");
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

        // Kiểm tra đăng nhập...
       
        private void BeginAgain()
        {
            txtName.Text = "";
            txtPhone.Text = "";
            txtEmail.Text = "";
            txtAddress.Text = "";
            txtContent.Text = "";
            ltrSuccess.Visible = false;
        }

        private void RenderData()
        {

            //Label Information

            lbInformation.Text = Location.GetLanguageTag("InformationContact").ToString();
            //lbInformation.Text = Location.GetLanguageTag("CaptionContact").ToString();
            lbName.Text = Location.GetLanguageTag("Name").ToString();
            lbPhone.Text = Location.GetLanguageTag("Phone").ToString();
            lbEmail.Text = Location.GetLanguageTag("Email").ToString();
            lbAddress.Text = Location.GetLanguageTag("Address").ToString();
            lbContent.Text = Location.GetLanguageTag("Content").ToString();
            btSent.Text = Location.GetLanguageTag("btSent").ToString();
            lbtReset.Text = Location.GetLanguageTag("btCancel").ToString();
                      
        }


        #endregion


        protected void lbtReset_Click(object sender, EventArgs e)
        {
            BeginAgain();
        }

        protected void btSent_Click(object sender, EventArgs e)
        {
            InsertContact();
        }
    }
}