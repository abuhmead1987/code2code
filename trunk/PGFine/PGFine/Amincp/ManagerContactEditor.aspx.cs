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
    public partial class ManagerContactEditor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string FlagButtonClick = "";
                try
                {
                    FlagButtonClick = Request.QueryString["Flag"].ToString();
                    if (!string.IsNullOrEmpty(FlagButtonClick))
                    {
                        //if flag khác rỗng thì tiến hành so sánh xem button nao Click
                        if (string.Compare(FlagButtonClick, "Edit") == 0)
                        {
                            //tiến hành load text lên các text box
                            LoadTextBox();                          
                        }
                    }
                }
                catch
                {
                    Response.Redirect("~/Amincp/ManagerContact.aspx");
                }
            }
        }

        // Load dữ lieu lên các TextBox tương ứng
        private void LoadTextBox()
        {
            int intID = 0;

            if (CommonClass.StringValidator.IsNumber(Request["ContactID"].ToString().Trim()))
                intID = int.Parse(Request["ContactID"].ToString().Trim());

            DB.DB_Object.ClassContact objClassData = new DB.DB_Object.ClassContact();
            DataTable dt = objClassData.getDataEditContact(intID);
            foreach (DataRow dr in dt.Rows)
            {
                txtId.Text = dr["ContactID"].ToString();
                txtName.Text = dr["Name"].ToString();
                txtPhone.Text = dr["Phone"].ToString();
                txtEmail.Text = dr["Email"].ToString();
                txtAddress.Text = dr["Address"].ToString();
                txtContent.Text = dr["Detail"].ToString();            
            }         
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Amincp/ManagerContact.aspx");
        }
    }
}
