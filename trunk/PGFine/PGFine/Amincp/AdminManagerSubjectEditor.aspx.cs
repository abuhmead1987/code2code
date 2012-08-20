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
    public partial class AdminManagerSubjectEditor : System.Web.UI.Page
    {
        DB.Common.ClassPGFCommon objClassCommon = new DB.Common.ClassPGFCommon();

        #region Hàm Page Load...

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
                    Response.Redirect("~/Amincp/AdminManagerSubject.aspx");
                }
            }
        }

        #endregion
     
        // Load dữ lieu lên các TextBox tương ứng
        private void LoadTextBox()
        {
            int intID = 0;

            if (CommonClass.StringValidator.IsNumber(Request["SubjectID"].ToString().Trim()))
                intID = int.Parse(Request["SubjectID"].ToString().Trim());

            DB.DB_Object.ClassSubject objClassData = new DB.DB_Object.ClassSubject();
            DataTable dt = objClassData.getDataEditSubject(intID);
            foreach (DataRow dr in dt.Rows)
            {
                txtTypeNewsID.Text = dr["SubjectID"].ToString();             
                txtTitleNewsEL.Text = dr["TitleSubjectEL"].ToString();
                txtTitleNewsVN.Text = dr["TitleSubjectVN"].ToString();
                txtShortDescriptionEL.Text = dr["ShortDescriptionEL"].ToString();
                txtShortDescriptionVN.Text = dr["ShortDescriptionVN"].ToString();
                txtContentEL.Value = dr["ContentEL"].ToString();
                txtContentVN.Value = dr["ContentVN"].ToString();
                txtPathImages.Text = dr["PathImages"].ToString();
                txtReadTimes.Text = dr["ReadTimes"].ToString();
                txtIndexof.Text=dr["Indexof"].ToString();
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

        private bool checkInput()
        {
            if (txtReadTimes.Text.Trim().Length < 0 || !CommonClass.StringValidator.IsNumber(txtReadTimes.Text.Trim()))
            {
                CommonClass.MessageBox.Show("Số lần đọc chưa nhập hoặc tồn tại ký tự!");
                txtReadTimes.Focus();
                return false;
            }
            if (txtIndexof.Text.Trim().Length < 0 || !CommonClass.StringValidator.IsNumber(txtIndexof.Text.Trim()))
            {
                CommonClass.MessageBox.Show("Số lần đọc chưa nhập hoặc tồn tại ký tự!");
                txtIndexof.Focus();
                return false;
            }      
            return true;
        }

        // Insert mới thông tin một News...
        private void Insert()
        {
            try
            {
                string strTitleNewsEL = CommonClass.StringValidator.GetSafeString(txtTitleNewsEL.Text.Trim());
                string strTitleNewsVN = CommonClass.StringValidator.GetSafeString(txtTitleNewsVN.Text.Trim());               
                string strShortDescriptionEL = CommonClass.StringValidator.GetSafeString(txtShortDescriptionEL.Text.Trim());
                string strShortDescriptionVN = CommonClass.StringValidator.GetSafeString(txtShortDescriptionVN.Text.Trim());
                string strContentEL = objClassCommon.FilterSQLParamater(txtContentEL.Value);
                string strContentVN = objClassCommon.FilterSQLParamater(txtContentVN.Value);
                string strPathImages = "~/Images/ImgNews/defaultimage.GIF";
                int intTypeNewsID = 1;                              
                int intIndexof = 0;

                if (txtIndexof.Text.Trim().Length > 0)
                {
                    intIndexof = int.Parse(txtIndexof.Text.Trim());
                }


                if (!string.IsNullOrEmpty(FileUpload1.FileName) && CheckExtention(FileUpload1) == true)
                {
                    Sycomore.UploadFile Upload = new Sycomore.UploadFile();
                    Upload.StrFileName = FileUpload1.FileName;
                    Upload.StrFolder = Server.MapPath("~/Images/ImgNews/");
                    Upload.Upload(FileUpload1);
                    strPathImages = "~/Images/ImgNews/" + Upload.StrFileName;
                }

                DB.DB_Object.ClassSubject objClassData = new DB.DB_Object.ClassSubject();
                if (objClassData.InsertSubjects(strTitleNewsEL, strTitleNewsVN, intTypeNewsID, strShortDescriptionEL,
                    strShortDescriptionVN, strContentEL, strContentVN, strPathImages, intIndexof) == true)
                {
                    Response.Redirect("~/Amincp/AdminManagerSubject.aspx");
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
                int intSubjectID = int.Parse(txtTypeNewsID.Text.Trim());
                string strTitleSubjectEL = CommonClass.StringValidator.GetSafeString(txtTitleNewsEL.Text.Trim());
                string strTitleSubjectVN = CommonClass.StringValidator.GetSafeString(txtTitleNewsVN.Text.Trim());               
                string strShortDescriptionEL = CommonClass.StringValidator.GetSafeString(txtShortDescriptionEL.Text.Trim());
                string strShortDescriptionVN = CommonClass.StringValidator.GetSafeString(txtShortDescriptionVN.Text.Trim());
                string strContentEL = objClassCommon.FilterSQLParamater(txtContentEL.Value.Trim());
                string strContentVN = objClassCommon.FilterSQLParamater(txtContentVN.Value.Trim());
                string strPathImages = txtPathImages.Text.Trim();
                int intReadTimes = 0;
                int intTypeNewsID = 1;
                int intIndexof = 0;

                if (txtReadTimes.Text.Trim().Length > 0)
                {
                    intReadTimes = int.Parse(txtReadTimes.Text.Trim());
                }

                if (txtIndexof.Text.Trim().Length > 0)
                {
                    intIndexof = int.Parse(txtIndexof.Text.Trim());
                }

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

                DB.DB_Object.ClassSubject objClassData = new DB.DB_Object.ClassSubject();
                if (objClassData.UpdateSubject(intSubjectID,strTitleSubjectEL, strTitleSubjectVN, intTypeNewsID, strShortDescriptionEL,
                    strShortDescriptionVN, strContentEL, strContentVN, strPathImages, intReadTimes, intIndexof) == true)
                {
                    Response.Redirect("~/Amincp/AdminManagerSubject.aspx");
                }
                else
                    CommonClass.MessageBox.Show("Lỗi kết nối đến Server. Vui lòng kiểm tra hệ thống mạng!");
            }
            catch (Exception e)
            {
                SetErrorMessage(e.Message);
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
            Response.Redirect("~/Amincp/AdminManagerSubject.aspx");
        }

        protected void cboNameNewsVN_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

       
    }
}
