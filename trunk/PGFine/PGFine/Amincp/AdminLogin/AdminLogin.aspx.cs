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

namespace PGFine.Amincp.AdminLogin
{
    public partial class AdminLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
            }
        }

        protected void cmdLogin_Click(object sender, EventArgs e)
        {
            string strUserName = CommonClass.StringValidator.GetSafeString(txtUsername.Text.Trim());
            string strPassWord = CommonClass.StringValidator.GetMD5String(txtPassword.Text.Trim());
            DB.DB_Object.ClassAdminLogin objAdmin = new DB.DB_Object.ClassAdminLogin();
            objAdmin.Password = strPassWord;
            objAdmin.Username = strUserName;
            if (!objAdmin.CheckLogin())
            {
                CommonClass.MessageBox.Show("Username hoặc Password không đúng");
                txtPassword.Text = "";
                txtPassword.Focus();
            }
            else
            {
                Session["UserName"]=txtUsername.Text.Trim();
                Session["PassWord"] = true;
                Response.Redirect("~/Amincp/ManagerTopFicList.aspx");
            }
        }
    }
}
