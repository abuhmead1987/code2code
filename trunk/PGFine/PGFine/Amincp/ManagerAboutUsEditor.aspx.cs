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
    public partial class ManagerAboutUsEditor : System.Web.UI.Page
    {
        DB.Common.ClassPGFCommon objClassDataCommon = new DB.Common.ClassPGFCommon();
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
                            LoadComBoBoxTypeNewsVN();
                            //tiến hành load text lên các text box
                            LoadTextBox();
                        }
                    }
                }
                catch
                {
                    Response.Redirect("~/Amincp/ManagerAboutUs.aspx");
                }
            }
        }

        // Load thông tin tên loại tin tức lên các combox VN
        protected void LoadComBoBoxTypeNewsVN()
        {
            DB.DB_Object.AboutUs AboutUs = new DB.DB_Object.AboutUs();
            DataTable dt = AboutUs.GetDataLoadComBoxVN();
            if (dt != null)
            {
                ListItem Item = new ListItem();
                Item.Text = "----- Chọn Menu giới thiệu -----";
                Item.Value = "0";
                cboNameNewsVN.Items.Add(Item);
                foreach (DataRow dr in dt.Rows)
                {
                    ListItem newItem = new ListItem();
                    newItem.Text = dr[1].ToString();
                    newItem.Value = dr[0].ToString();
                    cboNameNewsVN.Items.Add(newItem);
                }
            }
        }

        // Gán lỗi khi phát sinh vào label thông báo lỗi        
        private void SetErrorMessage(string text)
        {
            _errorLabel.Text = "Thông báo : " + text;
            _errorLabel.Visible = null != text && 0 < text.Length;
        }

        // Load dữ lieu lên các TextBox tương ứng
        private void LoadTextBox()
        {
            int intID = 0;

            if (CommonClass.StringValidator.IsNumber(Request["ChilAboutUsID"].ToString().Trim()))
                intID = int.Parse(Request["ChilAboutUsID"].ToString().Trim());

            DB.DB_Object.AboutUs objClassData = new DB.DB_Object.AboutUs();
            DataTable dt = objClassData.getDataEditAboutUs(intID);
            foreach (DataRow dr in dt.Rows)
            {
                txtChilAboutUsID.Text=dr["chilAboutUsID"].ToString();
                cboNameNewsVN.SelectedValue = dr["chilAboutUsID"].ToString();
                txtContentEL.Value = dr["ContentEL"].ToString();
                //txtContentVN. = dr["ContentVN"].ToString();
                
            }         
        }

        private bool checkInput()
        {
            if (txtContentEL.Value.Trim().Length < 2)
            {
                CommonClass.MessageBox.Show("Nội dung không được quá ngắn!");
                txtContentEL.Focus();
                return false;
            }
            if (txtContentVN.Value.Trim().Length < 2 )
            {
                CommonClass.MessageBox.Show("Nội dung không được quá ngắn!");
                txtContentVN.Focus();
                return false;
            }
           
            return true;
        }

        // Update mới thông tin một News...
        private void Update()
        {
            try
            {
                int intNewsID = int.Parse(txtChilAboutUsID.Text.Trim());
                string strContentEL = objClassDataCommon.FilterSQLParamater(txtContentEL.Value.Trim());
                string strContentVN = objClassDataCommon.FilterSQLParamater(txtContentVN.Value.Trim());
               
                DB.DB_Object.AboutUs objClassData = new DB.DB_Object.AboutUs();
                if (objClassData.UpdateAboutUs(intNewsID, strContentEL, strContentVN) == true)
                {
                    Response.Redirect("~/Amincp/ManagerAboutUs.aspx");
                }
                else
                    CommonClass.MessageBox.Show("Lỗi kết nối đến Server. Vui lòng kiểm tra hệ thống mạng!");
            }
            catch (Exception e)
            {
                SetErrorMessage(e.Message);
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Amincp/ManagerAboutUs.aspx");
        }

        protected void cmdSave_Click(object sender, EventArgs e)
        {
            string FlagButtonClick = "";
            FlagButtonClick = Request.QueryString["Flag"].ToString();
            if (FlagButtonClick == "Insert")
            {
                //  Gọi hàm thêm mới dữ liệu
                if (checkInput())
                {
                   // Insert();
                }
            }
            else if (FlagButtonClick == "Edit")
            {
                // Gọi hàm cập nhật dữ liệu
                if (checkInput())
                {
                    Update();
                }
            }
            else
                return;
        }
    }
}
