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
    public partial class ManagerTypeProductEditor : System.Web.UI.Page
    {
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

                    // Visible TextPathImages và Button changce Images
                    txtPathImages1.Visible = false;
                    btChangeImages1.Visible = false;

                    // Visible TextPathImages và Button changce Images
                    txtPathImages2.Visible = false;
                    btChangeImages2.Visible = false;

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
                    Response.Redirect("~/Amincp/ManagerTypeProduct.aspx");
                }
            }
        }

        private void LoadTextBox()
        {
            int intID = 0;

            if (CommonClass.StringValidator.IsNumber(Request["ID"].ToString().Trim()))
                intID = int.Parse(Request["ID"].ToString().Trim());

            DB.DB_Object.ClassTypeProduct objClassData = new DB.DB_Object.ClassTypeProduct();
            DataTable dt = objClassData.getDataEditTypeProduct(intID);
            foreach (DataRow dr in dt.Rows)
            {
                txtId.Text = dr["ID"].ToString();
                txtName.Text = dr["TypeName"].ToString();
                txtPathImages.Text = dr["ImagePathOut"].ToString();
                txtPathImages1.Text = dr["ImagePathOver"].ToString();
                txtPathImages2.Text = dr["ImagePath"].ToString();
                txtNameEL.Text = dr["TypeNameEL"].ToString();
            }
            // Visible cái fileUpload khi không cần thiết
            FileUpload1.Visible = false;
            txtPathImages.Visible = true;
            btChangeImages.Visible = true;

            // Visible cái fileUpload khi không cần thiết
            FileUpload2.Visible = false;
            txtPathImages1.Visible = true;
            btChangeImages1.Visible = true;

            // Visible cái fileUpload khi không cần thiết
            FileUpload3.Visible = false;
            txtPathImages2.Visible = true;
            btChangeImages2.Visible = true;
        }

        // Gán lỗi khi phát sinh vào label thông báo lỗi        
        private void SetErrorMessage(string text)
        {
            _errorLabel.Text = "Thông báo : " + text;
            _errorLabel.Visible = null != text && 0 < text.Length;
        }

        // Insert mới thông tin một News...
        private void Insert()
        {
            try
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

                string strPathImages1 = "~/Images/ImgNews/defaultimage.GIF";
                if (!string.IsNullOrEmpty(FileUpload2.FileName) && CheckExtention(FileUpload2) == true)
                {
                    Sycomore.UploadFile Upload = new Sycomore.UploadFile();
                    Upload.StrFileName = FileUpload2.FileName;
                    Upload.StrFolder = Server.MapPath("~/Images/ImgNews/");
                    Upload.Upload(FileUpload2);
                    strPathImages1 = "~/Images/ImgNews/" + Upload.StrFileName;
                }

                string strPathImages2 = "~/Images/ImgNews/defaultimage.GIF";
                if (!string.IsNullOrEmpty(FileUpload3.FileName) && CheckExtention(FileUpload3) == true)
                {
                    Sycomore.UploadFile Upload = new Sycomore.UploadFile();
                    Upload.StrFileName = FileUpload3.FileName;
                    Upload.StrFolder = Server.MapPath("~/Images/ImgNews/");
                    Upload.Upload(FileUpload3);
                    strPathImages2 = "~/Images/ImgNews/" + Upload.StrFileName;
                }

                string strTypeName = CommonClass.StringValidator.GetSafeString(txtName.Text.Trim());
                string strNameEL = txtNameEL.Text.Trim();

                DB.DB_Object.ClassTypeProduct objClassData = new DB.DB_Object.ClassTypeProduct();
                if (objClassData.InsertTypeProduct(strTypeName, strPathImages, strPathImages1, strNameEL, strPathImages2) == true)
                {
                    Response.Redirect("~/Amincp/ManagerTypeProduct.aspx");
                }
                else
                    CommonClass.MessageBox.Show("Lỗi kết nối đến Server. Vui lòng kiểm tra hệ thống mạng!");
            }
            catch (Exception e)
            {
                SetErrorMessage(e.Message);
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

        // Update mới thông tin một News...
        private void Update()
        {
            try
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

                string strPathImages1 = txtPathImages1.Text.Trim();
                //Khi Admin tiến hành đổi hình ảnh
                if (FileUpload2.Visible == true)
                {
                    strPathImages1 = "~/Images/ImgNews/defaultimage.GIF";
                    if (!string.IsNullOrEmpty(FileUpload2.FileName) && CheckExtention(FileUpload2) == true)
                    {
                        Sycomore.UploadFile Upload = new Sycomore.UploadFile();
                        Upload.StrFileName = FileUpload2.FileName;
                        Upload.StrFolder = Server.MapPath("~/Images/ImgNews/");
                        Upload.Upload(FileUpload2);
                        strPathImages1 = "~/Images/ImgNews/" + Upload.StrFileName;
                    }
                }

                string strPathImages2 = txtPathImages2.Text.Trim();
                //Khi Admin tiến hành đổi hình ảnh
                if (FileUpload3.Visible == true)
                {
                    strPathImages2 = "~/Images/ImgNews/defaultimage.GIF";
                    if (!string.IsNullOrEmpty(FileUpload3.FileName) && CheckExtention(FileUpload3) == true)
                    {
                        Sycomore.UploadFile Upload = new Sycomore.UploadFile();
                        Upload.StrFileName = FileUpload3.FileName;
                        Upload.StrFolder = Server.MapPath("~/Images/ImgNews/");
                        Upload.Upload(FileUpload3);
                        strPathImages2 = "~/Images/ImgNews/" + Upload.StrFileName;
                    }
                }

                int intNewsID = int.Parse(txtId.Text.Trim());              
                string strTypeName = CommonClass.StringValidator.GetSafeString(txtName.Text.Trim());
                string strTypeNameEL = CommonClass.StringValidator.GetSafeString(txtNameEL.Text.Trim());

                DB.DB_Object.ClassTypeProduct objClassData = new DB.DB_Object.ClassTypeProduct();
                if (objClassData.UpdateTypeProduct(intNewsID, strTypeName, strPathImages, strPathImages1, strTypeNameEL, strPathImages2) == true)
                {
                    Response.Redirect("~/Amincp/ManagerTypeProduct.aspx");
                }
                else
                    CommonClass.MessageBox.Show("Lỗi kết nối đến Server. Vui lòng kiểm tra hệ thống mạng!");
            }
            catch (Exception e)
            {
                SetErrorMessage(e.Message);
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
            Response.Redirect("~/Amincp/ManagerTypeProduct.aspx");
        }

        private bool checkInput()
        {
            if (txtName.Text.Trim().Length <= 0)
            {
                CommonClass.MessageBox.Show("Vui lòng nhập Tên loại sản phẩm!");
                txtName.Focus();
                return false;
            }
            return true;
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
        protected void btChangeImages1_Click(object sender, EventArgs e)
        {
            if (FileUpload2.Visible == false)
            {
                FileUpload2.Visible = true;
                txtPathImages1.Visible = false;
                btChangeImages1.Text = "Bỏ Qua";
            }
            else
            {
                FileUpload2.Visible = false;
                txtPathImages1.Visible = true;
                btChangeImages1.Text = "Đổi Ảnh";
            }
        }
        protected void btChangeImages2_Click(object sender, EventArgs e)
        {
            if (FileUpload3.Visible == false)
            {
                FileUpload3.Visible = true;
                txtPathImages2.Visible = false;
                btChangeImages2.Text = "Bỏ Qua";
            }
            else
            {
                FileUpload3.Visible = false;
                txtPathImages2.Visible = true;
                btChangeImages2.Text = "Đổi Ảnh";
            }
        }

    }
}
