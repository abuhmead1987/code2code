﻿using System;
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
    public partial class ManagerAdvisorsEditor : System.Web.UI.Page
    {
        DB.Common.ClassPGFCommon objClassCommon = new DB.Common.ClassPGFCommon();

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
                        }
                    }
                }
                catch
                {
                    Response.Redirect("~/Amincp/ManagerAdvisors.aspx");
                }
            }
        }

        private void LoadTextBox()
        {
            int intID = 0;

            if (CommonClass.StringValidator.IsNumber(Request["ID"].ToString().Trim()))
                intID = int.Parse(Request["ID"].ToString().Trim());

            DB.DB_Object.ClassSize objClassData = new DB.DB_Object.ClassSize();
            DataTable dt = objClassData.getDataTrainersAndAdvisors(intID);
            foreach (DataRow dr in dt.Rows)
            {
                txtTrainerID.Text = dr["ID"].ToString();
                txtNameEL.Text = dr["NameEL"].ToString();
                txtNameVN.Text = dr["NameVN"].ToString();
                txtShortDescriptionEL.Text = dr["ShortDescriptionEL"].ToString();
                txtShortDescriptionVN.Text = dr["ShortDescriptionVN"].ToString();
                txtContentEL.Value = dr["ContentEL"].ToString();
                txtContentVN.Value = dr["ContentVN"].ToString();
                txtPathImages.Text = dr["PathImages"].ToString();
                txtIndexOf.Text=dr["IndexOf"].ToString();
            }

            // Visible cái fileUpload khi không cần thiết
            FileUpload1.Visible = false;
            txtPathImages.Visible = true;
            btChangeImages.Visible = true;
        }

        private bool checkInput()
        {
            if (txtNameEL.Text.Trim().Length < 2 || txtNameEL.Text.Trim().Length > 150)
            {
                CommonClass.MessageBox.Show("Chưa nhập tiêu đề tiếng anh hoặc chiều dài tiêu đề tiếng anh vượt quá 150 ký tự!");
                txtNameEL.Focus();
                return false;
            }
            if (txtIndexOf.Text.Trim().Length <= 0 || !CommonClass.StringValidator.IsNumber(txtIndexOf.Text))
            {
                CommonClass.MessageBox.Show("Chưa nhập thứ tự hiển thị hoặc thứ tự hiển thị không là ký số!");
                txtIndexOf.Focus();
                return false;
            }
            if (txtNameVN.Text.Trim().Length < 2 || txtNameVN.Text.Trim().Length > 150)
            {
                CommonClass.MessageBox.Show("Chưa nhập tiêu đề tiếng việt hoặc chiều dài tiêu đề tiếng việt vượt quá 150 ký tự!");
                txtNameVN.Focus();
                return false;
            }

            if (txtShortDescriptionEL.Text.Trim().Length < 2 || txtShortDescriptionEL.Text.Trim().Length > 215)
            {
                CommonClass.MessageBox.Show("Chưa nhập mô tả ngắn tiếng anh hoặc chiều dài mô tả ngắn tiếng anh vượt quá 215 ký tự!");
                txtShortDescriptionEL.Focus();
                return false;
            }
            if (txtShortDescriptionVN.Text.Trim().Length < 2 || txtShortDescriptionVN.Text.Trim().Length > 215)
            {
                CommonClass.MessageBox.Show("Chưa nhập mô tả ngắn tiếng việt hoặc chiều dài mô tả ngắn tiếng việt vượt quá 215 ký tự!");
                txtShortDescriptionVN.Focus();
                return false;
            }
            if (txtContentEL.Value.Trim().Length < 2)
            {
                CommonClass.MessageBox.Show("Chưa nhập nội dung tiếng anh!");
                txtContentEL.Focus();
                return false;
            }
            if (txtContentVN.Value.Trim().Length < 2)
            {
                CommonClass.MessageBox.Show("Chưa nhập nội dung tiếng việt!");
                txtContentVN.Focus();
                return false;
            }

            return true;
        }

        private void Insert()
        {
            string strNameEL = CommonClass.StringValidator.GetSafeString(txtNameEL.Text.Trim());
            string strNameVN = CommonClass.StringValidator.GetSafeString(txtNameVN.Text.Trim());
            string strShortDescriptionEL = CommonClass.StringValidator.GetSafeString(txtShortDescriptionEL.Text.Trim());
            string strShortDescriptionVN = CommonClass.StringValidator.GetSafeString(txtShortDescriptionVN.Text.Trim());
            string strContantEL = objClassCommon.FilterSQLParamater(txtContentEL.Value);
            string strContantVN = objClassCommon.FilterSQLParamater(txtContentVN.Value);
            string strPathImages = "~/Images/ImgNews/defaultimage.GIF";
            int intIndexof = int.Parse(txtIndexOf.Text.Trim());

            if (!string.IsNullOrEmpty(FileUpload1.FileName) && CheckExtention(FileUpload1) == true)
            {
                Sycomore.UploadFile Upload = new Sycomore.UploadFile();
                Upload.StrFileName = FileUpload1.FileName;
                Upload.StrFolder = Server.MapPath("~/Images/ImgNews/");
                Upload.Upload(FileUpload1);
                strPathImages = "~/Images/ImgNews/" + Upload.StrFileName;
            }

            DB.DB_Object.ClassAdvisors objClassData = new DB.DB_Object.ClassAdvisors();
            try
            {
                if (objClassData.InsertTrainer(strNameEL, strNameVN, strShortDescriptionEL, strShortDescriptionVN, strContantEL, strContantVN, strPathImages,intIndexof) == true)
                {
                    Response.Redirect("~/Amincp/ManagerAdvisors.aspx");
                }
                else
                {
                    CommonClass.MessageBox.Show("Lỗi kết nối đến Server. Vui lòng kiểm tra hệ thống mạng!");
                }
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

        private void Update()
        {
            int intID = Convert.ToInt32(txtTrainerID.Text.Trim());
            string strNameEL = CommonClass.StringValidator.GetSafeString(txtNameEL.Text.Trim());
            string strNameVN = CommonClass.StringValidator.GetSafeString(txtNameVN.Text.Trim());
            string strShortDescriptionEL = CommonClass.StringValidator.GetSafeString(txtShortDescriptionEL.Text.Trim());
            string strShortDescriptionVN = CommonClass.StringValidator.GetSafeString(txtShortDescriptionVN.Text.Trim());
            string strContentEL = objClassCommon.FilterSQLParamater(txtContentEL.Value);
            string strContentVN = objClassCommon.FilterSQLParamater(txtContentVN.Value);
            string strPathImages = txtPathImages.Text.Trim();
            int intIndexof = int.Parse(txtIndexOf.Text.Trim());

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
            DB.DB_Object.ClassAdvisors objClassData = new DB.DB_Object.ClassAdvisors();
            try
            {
                if (objClassData.UpdateTrainer(intID, strNameEL, strNameVN, strShortDescriptionEL, strShortDescriptionVN, strContentEL, strContentVN, strPathImages,intIndexof) == true)
                {
                    Response.Redirect("~/Amincp/ManagerAdvisors.aspx");
                }
                else
                {
                    CommonClass.MessageBox.Show("Lỗi kết nối đến Server. Vui lòng kiểm tra hệ thống mạng!");
                }
            }
            catch (Exception ex)
            {
                SetErrorMessage(ex.Message);
            }
        }

        // Gán lỗi khi phát sinh vào label thông báo lỗi        
        private void SetErrorMessage(string text)
        {
            _errorLabel.Text = "Thông báo : " + text;
            _errorLabel.Visible = null != text && 0 < text.Length;
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
            Response.Redirect("~/Amincp/ManagerAdvisors.aspx");
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
    }
}
