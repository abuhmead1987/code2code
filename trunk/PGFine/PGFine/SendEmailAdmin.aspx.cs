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
using CommonClass;

namespace PGFine
{
    public partial class SendEmailAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Render();
        }

        private void Render()
        {
            ltrtestimial.Text = Location.GetLanguageTag("SendAdmin").ToString();
            ltrName.Text = Location.GetLanguageTag("Name").ToString() + ":";
            ltrPhone.Text = Location.GetLanguageTag("Phone").ToString() + ":";
            ltrAddress.Text = Location.GetLanguageTag("Address").ToString() + ":";
            ltrContent.Text = Location.GetLanguageTag("Content").ToString() + ":";
            btSend.Text = Location.GetLanguageTag("btSent").ToString();
            btReset.Text = Location.GetLanguageTag("Reset").ToString();
        }

        protected void btSend_Click(object sender, EventArgs e)
        {
            InsertContact();
        }

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
                if (objClassData.InsertContact(strName, strPhone, strEmail, strAddress, strDetail) == true)
                {
                    BeginAgain();
                    Response.Write(string.Format("<script type=\"text/javascript\">alert(\"{0}\")</script>", "Thông tin được gửi thành công"));
                    //ltrSuccess.Visible = true;
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

        private void BeginAgain()
        {
            txtName.Text = "";
            txtPhone.Text = "";
            txtEmail.Text = "";
            txtAddress.Text = "";
            txtContent.Text = "";            
        }

        // Gán lỗi khi phát sinh vào label thông báo lỗi        
        private void SetErrorMessage(string text)
        {
            _errorLabel.Text = "Thông báo : " + text;
            _errorLabel.Visible = null != text && 0 < text.Length;
        }

        protected void btReset_Click(object sender, EventArgs e)
        {
            BeginAgain();
        }




    }
}
