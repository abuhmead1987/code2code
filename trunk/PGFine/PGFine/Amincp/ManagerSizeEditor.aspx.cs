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
    public partial class ManagerSizeEditor : System.Web.UI.Page
    {
        DB.Common.ClassPGFCommon objClassCommon=new DB.Common.ClassPGFCommon();

        #region Hàm xử lý

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

                    // Visible TextPathImages và Button changce Images
                    txtPathImages3.Visible = false;
                    btChangeImages3.Visible = false;

                    // Visible TextPathImages và Button changce Images
                    txtPathImages4.Visible = false;
                    btChangeImages4.Visible = false;

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
                    Response.Redirect("~/Amincp/ManagerProduct.aspx");
                }
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

        private void Insert()
        {
            int intProductId = int.Parse(Request["ProductId"]);
            string strNameEL = CommonClass.StringValidator.GetSafeString(txtNameSize.Text.Trim());            
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

            string strPathImages3 = "~/Images/ImgNews/defaultimage.GIF";
            if (!string.IsNullOrEmpty(FileUpload4.FileName) && CheckExtention(FileUpload4) == true)
            {
                Sycomore.UploadFile Upload = new Sycomore.UploadFile();
                Upload.StrFileName = FileUpload4.FileName;
                Upload.StrFolder = Server.MapPath("~/Images/ImgNews/");
                Upload.Upload(FileUpload4);
                strPathImages3 = "~/Images/ImgNews/" + Upload.StrFileName;
            }

            string strPathImages4 = "~/Images/ImgNews/defaultimage.GIF";
            if (!string.IsNullOrEmpty(FileUpload5.FileName) && CheckExtention(FileUpload5) == true)
            {
                Sycomore.UploadFile Upload = new Sycomore.UploadFile();
                Upload.StrFileName = FileUpload5.FileName;
                Upload.StrFolder = Server.MapPath("~/Images/ImgNews/");
                Upload.Upload(FileUpload5);
                strPathImages4 = "~/Images/ImgNews/" + Upload.StrFileName;
            }


            DB.DB_Object.ClassSize objClassData = new DB.DB_Object.ClassSize();
            try
            {
                if (objClassData.InsertSize(intProductId, strNameEL, strPathImages, strPathImages1, strPathImages2, strPathImages3, strPathImages4) == true)
                {
                    Response.Redirect("~/Amincp/ManagerSize.aspx?ProductId=" + intProductId);
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
            int intID = Convert.ToInt32(txtSizeID.Text.Trim());
            string strNameSize = CommonClass.StringValidator.GetSafeString(txtNameSize.Text.Trim());          
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

            string strPathImages3 = txtPathImages3.Text.Trim();

            //Khi Admin tiến hành đổi hình ảnh
            if (FileUpload4.Visible == true)
            {
                strPathImages3 = "~/Images/ImgNews/defaultimage.GIF";
                if (!string.IsNullOrEmpty(FileUpload4.FileName) && CheckExtention(FileUpload4) == true)
                {
                    Sycomore.UploadFile Upload = new Sycomore.UploadFile();
                    Upload.StrFileName = FileUpload4.FileName;
                    Upload.StrFolder = Server.MapPath("~/Images/ImgNews/");
                    Upload.Upload(FileUpload4);
                    strPathImages3 = "~/Images/ImgNews/" + Upload.StrFileName;
                }
            }

            string strPathImages4 = txtPathImages3.Text.Trim();

            //Khi Admin tiến hành đổi hình ảnh
            if (FileUpload5.Visible == true)
            {
                strPathImages4 = "~/Images/ImgNews/defaultimage.GIF";
                if (!string.IsNullOrEmpty(FileUpload5.FileName) && CheckExtention(FileUpload5) == true)
                {
                    Sycomore.UploadFile Upload = new Sycomore.UploadFile();
                    Upload.StrFileName = FileUpload5.FileName;
                    Upload.StrFolder = Server.MapPath("~/Images/ImgNews/");
                    Upload.Upload(FileUpload5);
                    strPathImages4 = "~/Images/ImgNews/" + Upload.StrFileName;
                }
            }

            DB.DB_Object.ClassSize objClassData = new DB.DB_Object.ClassSize();
            try
            {
                if (objClassData.UpdateTrainer(intID, strNameSize, strPathImages, strPathImages1, strPathImages2, strPathImages3, strPathImages4) == true)
                {
                    Response.Redirect("~/Amincp/ManagerSize.aspx?ProductId=" + hdProductId.Value.Trim());
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

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request["ProductId"]))
                Response.Redirect("~/Amincp/ManagerSize.aspx?ProductId=" + int.Parse(Request["ProductId"]));
            else
                Response.Redirect("~/Amincp/ManagerSize.aspx?ProductId=" + int.Parse(hdProductId.Value.Trim()));
        }

        #endregion

        #region Hàm hỗ trợ

        private void LoadTextBox()
        {
            int intID = 0;

            if (CommonClass.StringValidator.IsNumber(Request["ID"].ToString().Trim()))
                intID = int.Parse(Request["ID"].ToString().Trim());

            DB.DB_Object.ClassSize objClassData = new DB.DB_Object.ClassSize();
            DataTable dt = objClassData.getDataTrainersAndAdvisors(intID);
            foreach (DataRow dr in dt.Rows)
            {
                txtSizeID.Text = dr["ID"].ToString();
                txtNameSize.Text = dr["NameSize"].ToString();
                txtPathImages.Text = dr["ImagesPath1"].ToString();
                txtPathImages1.Text = dr["ImagesPath2"].ToString();
                txtPathImages2.Text = dr["ImagesPath3"].ToString();
                txtPathImages3.Text = dr["ImagesPath4"].ToString();
                txtPathImages4.Text = dr["ImagesPath5"].ToString();
                hdProductId.Value = dr["ProductId"].ToString();     
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

            // Visible cái fileUpload khi không cần thiết
            FileUpload4.Visible = false;
            txtPathImages3.Visible = true;
            btChangeImages3.Visible = true;

            // Visible cái fileUpload khi không cần thiết
            FileUpload5.Visible = false;
            txtPathImages4.Visible = true;
            btChangeImages4.Visible = true;
        }

        private bool checkInput()
        {
            if (txtNameSize.Text.Trim().Length < 1 || txtNameSize.Text.Trim().Length > 150)
            {
                CommonClass.MessageBox.Show("Chưa nhập tên size vượt quá 150 ký tự!");
                txtNameSize.Focus();
                return false;
            }            

            return true;
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

        #endregion      

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

        protected void btChangeImages3_Click(object sender, EventArgs e)
        {
            if (FileUpload4.Visible == false)
            {
                FileUpload4.Visible = true;
                txtPathImages3.Visible = false;
                btChangeImages3.Text = "Bỏ Qua";
            }
            else
            {
                FileUpload4.Visible = false;
                txtPathImages3.Visible = true;
                btChangeImages3.Text = "Đổi Ảnh";
            }
        }

        protected void btChangeImages4_Click(object sender, EventArgs e)
        {
            if (FileUpload5.Visible == false)
            {
                FileUpload5.Visible = true;
                txtPathImages4.Visible = false;
                btChangeImages4.Text = "Bỏ Qua";
            }
            else
            {
                FileUpload5.Visible = false;
                txtPathImages4.Visible = true;
                btChangeImages4.Text = "Đổi Ảnh";
            }
        }
    }
}
