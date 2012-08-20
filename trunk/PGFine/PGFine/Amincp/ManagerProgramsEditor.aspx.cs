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
    public partial class ManagerProgramsEditor : System.Web.UI.Page
    {

        #region Hàm Page Load....

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string FlagButtonClick = "";
                try
                {
                    LoadComBoBoxTypeNewsVN();
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
                    Response.Redirect("~/Amincp/ManagerPrograms.aspx");
                }
            }
        }

        #endregion

        #region Các hàm hỗ trợ...

        // Load dữ lieu lên các TextBox tương ứng
        private void LoadTextBox()
        {
            int intID = 0;
            if (CommonClass.StringValidator.IsNumber(Request["ProgramsID"].ToString().Trim()))
                intID = int.Parse(Request["ProgramsID"].ToString().Trim());

            DB.DB_Object.ClassPrograms objClassData = new DB.DB_Object.ClassPrograms();
            DataTable dt = objClassData.getDataEditPrograms(intID);
            foreach (DataRow dr in dt.Rows)
            {
                txtProgramsID.Text = dr["ProgramsID"].ToString();
                txtProgramsEL.Text = dr["NameNewsEL"].ToString();
                txtProgramsVN.Text = dr["NameNewsVN"].ToString();
                cboMenuParent.SelectedValue = dr["Nkey"].ToString();
            }
        }

        // Load thông tin tên loại tin tức lên các combox VN
        protected void LoadComBoBoxTypeNewsVN()
        {
            DB.DB_Object.ClassPrograms objClassTypeNews = new DB.DB_Object.ClassPrograms();
            DataTable dt = objClassTypeNews.GetDataLoadComBoxVN();
            if (dt != null)
            {
                ListItem Item = new ListItem();
                Item.Text = "---- Chọn menu cha ----";
                Item.Value = "0";
                cboMenuParent.Items.Add(Item);
                foreach (DataRow dr in dt.Rows)
                {
                    ListItem newItem = new ListItem();
                    newItem.Text = dr[1].ToString();
                    newItem.Value = dr[0].ToString();
                    cboMenuParent.Items.Add(newItem);
                }
            }
        }

        // Gán lỗi khi phát sinh vào label thông báo lỗi        
        private void SetErrorMessage(string text)
        {
            _errorLabel.Text = "Thông báo : " + text;
            _errorLabel.Visible = null != text && 0 < text.Length;
        }

        // Insert mới thông tin một Programs...
        private void Insert()
        {
            string strNameTypeNewsEL = CommonClass.StringValidator.GetSafeString(txtProgramsEL.Text.Trim());
            string strNameTypeNewsVN = CommonClass.StringValidator.GetSafeString(txtProgramsVN.Text.Trim());
            int intNKey = Convert.ToInt32(cboMenuParent.SelectedValue);
            DB.DB_Object.ClassPrograms objClassData = new DB.DB_Object.ClassPrograms();
            try
            {
                objClassData.InsertPrograms(strNameTypeNewsEL, strNameTypeNewsVN, intNKey);
                Response.Redirect("~/Amincp/ManagerPrograms.aspx");
            }
            catch (Exception ex)
            {
                SetErrorMessage(ex.Message);
            }
        }

        // Cập nhật thông tin một Programs...
        private void Update()
        {

            string strNameProgramsEL = CommonClass.StringValidator.GetSafeString(txtProgramsEL.Text.Trim());
            string strNameProgramsVN = CommonClass.StringValidator.GetSafeString(txtProgramsVN.Text.Trim());
            int intID = int.Parse(txtProgramsID.Text.Trim());
            int intNKey = Convert.ToInt32(cboMenuParent.SelectedValue);

            DB.DB_Object.ClassPrograms objClassData = new DB.DB_Object.ClassPrograms();
            try
            {
                objClassData.UpdatePrograms(strNameProgramsEL, strNameProgramsVN, intID, intNKey);
                Response.Redirect("~/Amincp/ManagerPrograms.aspx");
            }
            catch (Exception ex)
            {
                SetErrorMessage(ex.Message);
            }
        }

        #endregion

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Amincp/ManagerPrograms.aspx");
        }

        protected void cmdSave_Click(object sender, EventArgs e)
        {
            string FlagButtonClick = "";
            FlagButtonClick = Request.QueryString["Flag"].ToString();
            if (FlagButtonClick == "Insert")
            {
                //  Gọi hàm thêm mới dữ liệu
                Insert();
            }
            else if (FlagButtonClick == "Edit")
            {
                // Gọi hàm cập nhật dữ liệu
                Update();
            }
            else
                return;
        }

        protected void cboMenuParent_SelectedIndexChanged(object sender, EventArgs e)
        {
            DB.DB_Object.ClassPrograms objClassTypeNews = new DB.DB_Object.ClassPrograms();
            if (objClassTypeNews.CheckMenuParent(cboMenuParent.SelectedValue))
            {
                CommonClass.MessageBox.Show("Chương trình này đã có tồn tại môn học.\nKhi cập nhật thì những môn học thuộc chương trình này sẽ không còn phụ thuộc chương trình này.\nBạn vui lòng cập nhật lại nó");
            }
        }

    }
}
