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
using System.Drawing.Imaging;

namespace PGFine.Amincp
{
    public partial class ManagerNewsEditor : System.Web.UI.Page
    {
        DB.Common.ClassPGFCommon objClassCommon = new DB.Common.ClassPGFCommon();

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
                            txtReadTimes.Enabled = true;
                        }
                    }
                }
                catch
                {
                    Response.Redirect("~/Amincp/ManagerNews.aspx");
                }
            }
        }

        #endregion

        #region Các hàm hỗ trợ...
                
        // Load thông tin tên loại tin tức lên các combox VN
        protected void LoadComBoBoxTypeNewsVN()
        {
            DB.DB_Object.ClassNews ClassNews = new DB.DB_Object.ClassNews();
            DataTable dt = ClassNews.GetDataLoadComBoxVN();
            if (dt != null)
            {
                ListItem Item = new ListItem();
                Item.Text = "----- Chọn ngành nghề -----";
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

        // Load dữ lieu lên các TextBox tương ứng
        private void LoadTextBox()
        {
            int intID = 0;

            if (CommonClass.StringValidator.IsNumber(Request["NewsID"].ToString().Trim()))
                intID = int.Parse(Request["NewsID"].ToString().Trim());

            DB.DB_Object.ClassNews objClassData = new DB.DB_Object.ClassNews();
            DataTable dt = objClassData.getDataEditNews(intID);
            foreach (DataRow dr in dt.Rows)
            {
                txtTypeNewsID.Text = dr["NewsID"].ToString();
                cboNameNewsVN.SelectedValue = dr["TypeNewsID"].ToString();
                txtTitleNewsEL.Text = dr["TitleNewsEL"].ToString();
                txtTitleNewsVN.Text = dr["TitleNewsVN"].ToString();
                txtShortDescriptionEL.Text = dr["ShortDescriptionEL"].ToString();
                txtShortDescriptionVN.Text = dr["ShortDescriptionVN"].ToString();
                txtContentEL.Value = dr["ContentEL"].ToString();
                txtContentVN.Value = dr["ContentVN"].ToString();
                txtPathImages.Text = dr["PathImages"].ToString(); 
                txtReadTimes.Text = dr["ReadTimes"].ToString();
                chkTypeDisplay.SelectedValue = dr["TypeDisplay"].ToString();
            }

            // Visible cái fileUpload khi không cần thiết
            FileUpload1.Visible = false;
            txtPathImages.Visible = true;
            btChangeImages.Visible = true;
        }

        // Gán lỗi khi phát sinh vào label thông báo lỗi        
        private void SetErrorMessage(string text)
        {
            _errorLabel.Text = "Thông báo : " + text;
            _errorLabel.Visible = null != text && 0 < text.Length;
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

        // Insert mới thông tin một News...
        private void Insert()
        {
            try
            {
                string strTitleNewsEL = CommonClass.StringValidator.GetSafeString(txtTitleNewsEL.Text.Trim());
                string strTitleNewsVN =CommonClass.StringValidator.GetSafeString(txtTitleNewsVN.Text.Trim());
                int intTypeNewsID = int.Parse(cboNameNewsVN.SelectedValue);
                string strShortDescriptionEL = CommonClass.StringValidator.GetSafeString(txtShortDescriptionEL.Text.Trim());
                string strShortDescriptionVN = CommonClass.StringValidator.GetSafeString(txtShortDescriptionVN.Text.Trim());
                string strContentEL =objClassCommon.FilterSQLParamater(txtContentEL.Value);
                string strContentVN =objClassCommon.FilterSQLParamater(txtContentVN.Value);
                string strPathImages = "~/Images/ImgNews/defaultimage.GIF";
                int intTypeDisplay = int.Parse(chkTypeDisplay.SelectedValue);
                    
                if (!string.IsNullOrEmpty(FileUpload1.FileName) && CheckExtention(FileUpload1) == true)
                {
                    Sycomore.UploadFile Upload = new Sycomore.UploadFile();
                    Upload.StrFileName = FileUpload1.FileName;
                    Upload.StrFolder = Server.MapPath("~/Images/ImgNews/");
                    Upload.Upload(FileUpload1);
                    strPathImages = "~/Images/ImgNews/" + Upload.StrFileName;
                }

                DB.DB_Object.ClassNews objClassData = new DB.DB_Object.ClassNews();
                if (objClassData.InsertNews(strTitleNewsEL, strTitleNewsVN, intTypeNewsID, strShortDescriptionEL,
                    strShortDescriptionVN, strContentEL, strContentVN, strPathImages, intTypeDisplay) == true)
                {
                    Response.Redirect("~/Amincp/ManagerNews.aspx");
                }
                else
                    CommonClass.MessageBox.Show("Lỗi kết nối đến Server. Vui lòng kiểm tra hệ thống mạng!");
            }
            catch (Exception e)
            {
                SetErrorMessage(e.Message);
            }
        }

        // Update mới thông tin một News...
        private void Update()
        {
            try
            {
                int intNewsID = int.Parse(txtTypeNewsID.Text.Trim());
                string strTitleNewsEL = CommonClass.StringValidator.GetSafeString(txtTitleNewsEL.Text.Trim());
                string strTitleNewsVN = CommonClass.StringValidator.GetSafeString(txtTitleNewsVN.Text.Trim());
                int intTypeNewsID = int.Parse(cboNameNewsVN.SelectedValue);
                string strShortDescriptionEL = CommonClass.StringValidator.GetSafeString(txtShortDescriptionEL.Text.Trim());
                string strShortDescriptionVN = CommonClass.StringValidator.GetSafeString(txtShortDescriptionVN.Text.Trim());
                string strContentEL = objClassCommon.FilterSQLParamater(txtContentEL.Value);
                string strContentVN = objClassCommon.FilterSQLParamater(txtContentVN.Value);
                string strPathImages =txtPathImages.Text.Trim();
                int intReadTimes = Convert.ToInt32(txtReadTimes.Text);
                int intTypeDisplay = int.Parse(chkTypeDisplay.SelectedValue);

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

                DB.DB_Object.ClassNews objClassData = new DB.DB_Object.ClassNews();
                if (objClassData.UpdateNews(intNewsID, strTitleNewsEL, strTitleNewsVN, intTypeNewsID, strShortDescriptionEL,
                    strShortDescriptionVN, strContentEL, strContentVN, strPathImages, intReadTimes, intTypeDisplay) == true)
                {
                    Response.Redirect("~/Amincp/ManagerNews.aspx");
                }
                else
                    CommonClass.MessageBox.Show("Lỗi kết nối đến Server. Vui lòng kiểm tra hệ thống mạng!");
            }
            catch (Exception e)
            {
                SetErrorMessage(e.Message);
            }
        }

        private bool checkInput()
        {
            //if (txtTitleNewsEL.Text.Trim().Length < 2 || txtTitleNewsEL.Text.Trim().Length > 150)
            //{
            //    CommonClass.MessageBox.Show("Chưa nhập tiêu đề tiếng anh hoặc chiều dài tiêu đề tiếng anh vượt quá 150 ký tự!");
            //    txtTitleNewsEL.Focus();
            //    return false;
            //}
            //if (txtTitleNewsVN.Text.Trim().Length < 2 || txtTitleNewsEL.Text.Trim().Length > 150)
            //{
            //    CommonClass.MessageBox.Show("Chưa nhập tiêu đề tiếng việt hoặc chiều dài tiêu đề tiếng việt vượt quá 150 ký tự!");
            //    txtTitleNewsVN.Focus();
            //    return false;
            //}

            //if (cboNameNewsVN.SelectedValue == "0")
            //{
            //    CommonClass.MessageBox.Show("Chưa chọn loại tin tức!");
            //    cboNameNewsVN.Focus();
            //    return false;
            //}

            //if (txtShortDescriptionEL.Text.Trim().Length < 2 || txtShortDescriptionEL.Text.Trim().Length > 215)
            //{
            //    CommonClass.MessageBox.Show("Chưa nhập mô tả ngắn tiếng anh hoặc chiều dài mô tả ngắn tiếng anh vượt quá 215 ký tự!");
            //    txtShortDescriptionEL.Focus();
            //    return false;
            //}
            //if (txtShortDescriptionVN.Text.Trim().Length < 2 || txtShortDescriptionVN.Text.Trim().Length > 215)
            //{
            //    CommonClass.MessageBox.Show("Chưa nhập mô tả ngắn tiếng việt hoặc chiều dài mô tả ngắn tiếng việt vượt quá 215 ký tự!");
            //    txtShortDescriptionVN.Focus();
            //    return false;
            //}
            //if (txtContentEL.Text.Trim().Length < 2)
            //{
            //    CommonClass.MessageBox.Show("Chưa nhập nội dung tiếng anh!");
            //    txtContentEL.Focus();
            //    return false;
            //}
            //if (txtContentVN.Text.Trim().Length < 2)
            //{
            //    CommonClass.MessageBox.Show("Chưa nhập nội dung tiếng việt!");
            //    txtContentVN.Focus();
            //    return false;
            //}
            if (!CommonClass.StringValidator.IsNumber(txtReadTimes.Text.Trim()))
            {
                CommonClass.MessageBox.Show("Số lần đọc phải là ký tự số!");
                txtReadTimes.Focus();
                return false;
            }
            return true;
        }


        #endregion

        #region Các hàm xử lý...

        protected void cmdSave_Click(object sender, EventArgs e)
        {
            string FlagButtonClick = "";
            FlagButtonClick = Request.QueryString["Flag"].ToString();
            if (FlagButtonClick == "Insert")
            {
                //  Gọi hàm thêm mới dữ liệu
                if (checkInput())
                {
                    Insert(); 
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

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Amincp/ManagerNews.aspx");
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

        protected void cboNameNewsVN_SelectedIndexChanged(object sender, EventArgs e)
        {
            DB.DB_Object.ClassNews objClassTypeNews = new DB.DB_Object.ClassNews();
            if (objClassTypeNews.CheckMenuParent(cboNameNewsVN.SelectedValue))
            {
                CommonClass.MessageBox.Show("Không thể thêm tin tức vào Menu này. Yêu cầu chọn lại menu khác!");
                cboNameNewsVN.SelectedValue = "0";
            }
        }

        #endregion               
      
    }
}
