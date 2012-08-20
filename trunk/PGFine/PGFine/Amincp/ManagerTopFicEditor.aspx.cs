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
    public partial class ManagerTopFicEditor : System.Web.UI.Page
    {

        #region Hàm Page Load....

        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                string FlagButtonClick = "";
                try
                {
                    // Visible TextPathImages và Button changce Images
                    txtPathImages.Visible = false;
                    btChangeImages.Visible = false;

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
                        else
                        {
                            txtOrder.Text = "0";
                        }
                    }
                }
                catch
                {
                    Response.Redirect("~/Amincp/ManagerTopFicList.aspx");
                }                
                
            }
        }

        #endregion

        #region Các hàm hỗ trợ...

        // Load dữ lieu lên các TextBox tương ứng
        private void LoadTextBox()
        {
            int intID = 0;
            if (CommonClass.StringValidator.IsNumber(Request["TypeNewsID"].ToString().Trim()))
                intID = int.Parse(Request["TypeNewsID"].ToString().Trim());

            DB.DB_Object.ClassTypeNews objClassData = new DB.DB_Object.ClassTypeNews();
            DataTable dt = objClassData.getDataEditTypeNews(intID);
            foreach (DataRow dr in dt.Rows)
            {
                txtTypeNewsID.Text = dr["TypeNewsID"].ToString();
                txtTypeNewsEL.Text = dr["NameNewsEL"].ToString();
                txtTypeNewsVN.Text = dr["NameNewsVN"].ToString();
                cboMenuParent.SelectedValue = dr["Nkey"].ToString();
                chkTypeDisplay.SelectedValue = dr["TypeDisPlay"].ToString();
                rdoPositionDisplay.SelectedValue = dr["PositionDisPlay"].ToString();
                txtPathImages.Text = dr["ImagePath"].ToString();
                txtOrder.Text = dr["OrderNo"].ToString();
                txtPageLink.Text = dr["PageLink"].ToString();
            }

            if (intID > 0)
            {
                btDelete.Visible = true;
            }

            // Visible cái fileUpload khi không cần thiết
            FileUpload1.Visible = false;
            txtPathImages.Visible = true;
            btChangeImages.Visible = true;
        }

        // Insert mới thông tin một TypeNews...
        private void Insert()
        {
            string strPathImages = "~/Images/ImgNews/defaultimage.GIF";
            if (!string.IsNullOrEmpty(FileUpload1.FileName) && CheckExtention(FileUpload1) == true)
            {
                Sycomore.UploadFile Upload = new Sycomore.UploadFile();
                Upload.StrFileName = FileUpload1.FileName;
                Upload.StrFolder = Server.MapPath("~/Images/ImgNews/");
                Upload.Upload(FileUpload1);
                strPathImages = "~/Images/ImgNews/" + Upload.StrFileName;
            }

            string strNameTypeNewsEL = CommonClass.StringValidator.GetSafeString(txtTypeNewsEL.Text.Trim());
            string strNameTypeNewsVN = CommonClass.StringValidator.GetSafeString(txtTypeNewsVN.Text.Trim());
            int intTypeDisPlay = int.Parse(chkTypeDisplay.SelectedValue);
            int intPositionDisPlay = int.Parse(rdoPositionDisplay.SelectedValue);
            int intNKey = Convert.ToInt32(cboMenuParent.SelectedValue);
            int intOrderNo = int.Parse(txtOrder.Text.Trim());
            string strPageLink = txtPageLink.Text.Trim();

            DB.DB_Object.ClassTypeNews objClassData = new DB.DB_Object.ClassTypeNews();
            try
            {
                objClassData.InsertTypeNews(strNameTypeNewsEL, strNameTypeNewsVN, intNKey, intTypeDisPlay, intPositionDisPlay, strPathImages, intOrderNo, strPageLink);
                Response.Redirect("~/Amincp/ManagerTopFicList.aspx");
            }
            catch (Exception ex)
            {
                SetErrorMessage(ex.Message);
            }
        }

        // Cập nhật thông tin một TypeNews...
        private void Update()
        {
            string strPathImages = txtPathImages.Text.Trim();
            //Khi Admin tiến hành đổi hình ảnh
            if (FileUpload1.Visible == true)
            {
                strPathImages = "~/Images/ImgNews/defaultimage.GIF";
                if (!string.IsNullOrEmpty(FileUpload1.FileName) && CheckExtention(FileUpload1) == true)
                {
                    Sycomore.UploadFile Upload = new Sycomore.UploadFile();
                    Upload.StrFileName = FileUpload1.FileName;
                    Upload.StrFolder = Server.MapPath("~/Images/ImgNews/");
                    Upload.Upload(FileUpload1);
                    strPathImages = "~/Images/ImgNews/" + Upload.StrFileName;
                }
            }
         
            string strNameTypeNewsEL = CommonClass.StringValidator.GetSafeString(txtTypeNewsEL.Text.Trim());
            string strNameTypeNewsVN = CommonClass.StringValidator.GetSafeString(txtTypeNewsVN.Text.Trim());
            int intID=int.Parse(txtTypeNewsID.Text.Trim());
            int intNKey = Convert.ToInt32(cboMenuParent.SelectedValue);
            int intTypeDisplay = int.Parse(chkTypeDisplay.SelectedValue);
            int intPositionDisplay = int.Parse(rdoPositionDisplay.SelectedValue);
            int intOrderNo = int.Parse(txtOrder.Text.Trim());
            string strPageLink = txtPageLink.Text.Trim();

            DB.DB_Object.ClassTypeNews objClassData = new DB.DB_Object.ClassTypeNews();
            try
            {
                objClassData.UpdateTypeNews(strNameTypeNewsEL, strNameTypeNewsVN, intID, intNKey, intTypeDisplay, intPositionDisplay, strPathImages, intOrderNo, strPageLink);
                Response.Redirect("~/Amincp/ManagerTopFicList.aspx");
            }
            catch (Exception ex)
            {
                SetErrorMessage(ex.Message);
            }
        }


        //Kiểm tra file upload đúng định dạng chưa
        protected bool CheckExtention(FileUpload name)
        {
            string Extentsion = Itech.Utils.CommonFunctions.getFileFormat(name.FileName);
            bool checkExtension = false;
            foreach (string strTempExtentsion in System.Configuration.ConfigurationSettings.AppSettings["FILE_FORMAT_UPLOAD"].ToString().Split(".".ToCharArray()))
            {
                if (Extentsion.ToLower() == strTempExtentsion.ToLower())
                {
                    checkExtension = true;
                    return true;
                }
            }
            if (checkExtension == false)
            {
                CommonClass.MessageBox.Show("File Upload phải thuộc các định dạng: .gif ; .jpeg ; .jpg");
                return false;
            }
            return false;
        }


        // Gán lỗi khi phát sinh vào label thông báo lỗi        
        private void SetErrorMessage(string text)
        {
            _errorLabel.Text = "Thông báo : " + text;
            _errorLabel.Visible = null != text && 0 < text.Length;
        }

        // Load thông tin tên loại tin tức lên các combox VN
        protected void LoadComBoBoxTypeNewsVN()
        {
            DB.DB_Object.ClassTypeNews objClassTypeNews = new DB.DB_Object.ClassTypeNews();
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

        #endregion

        #region Các hàm xử lý...

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Amincp/ManagerTopFicList.aspx");
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
            DB.DB_Object.ClassTypeNews objClassTypeNews = new DB.DB_Object.ClassTypeNews();
            if (objClassTypeNews.CheckMenuParent(cboMenuParent.SelectedValue))
            {
                CommonClass.MessageBox.Show("Menu này đã có tin tức tồn tại.\nKhi cập nhật thì những tin tức thuộc menu này sẽ không còn phụ thuộc menu này.\nBạn vui lòng cập nhật lại nó");
            }
        }

        protected void btChangeImages_Click(object sender, EventArgs e)
        {
            if (FileUpload1.Visible == false)
            {
                FileUpload1.Visible = true;
                txtPathImages.Visible = false;
                btChangeImages.Text = "Bỏ Qua";
            }
            else
            {
                FileUpload1.Visible = false;
                txtPathImages.Visible = true;
                btChangeImages.Text = "Đổi Ảnh";
            }
        }
        #endregion      

        protected void btDelete_Click(object sender, EventArgs e)
        {
            int intID = 0;
            if (CommonClass.StringValidator.IsNumber(Request["TypeNewsID"].ToString().Trim()))
                intID = int.Parse(Request["TypeNewsID"].ToString().Trim());

            DB.DB_Object.ClassTypeNews objClassData = new DB.DB_Object.ClassTypeNews();

            if (objClassData.DeleteTypeNews(intID) > 0)
            {
                CommonClass.MessageBox.Show("Còn tồn tại tin tức hoặc loại tin tức thuộc menu này.\nYêu cầu kiểm tra lại!");
                return;
            }
            else
            {
                Response.Redirect("~/Amincp/ManagerTopFicList.aspx");
            }

        }

    }
}
