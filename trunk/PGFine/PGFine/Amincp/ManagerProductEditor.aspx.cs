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
    public partial class ManagerProductEditor : System.Web.UI.Page
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
                    LoadComBoBoxTypeProduct();

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
                            txtPrice.Text = "0";
                            txtPriceNew.Text = "0";
                        }
                    }
                }
                catch
                {
                    Response.Redirect("~/Amincp/ManagerProduct.aspx");
                }
            }
        }

        #endregion

        #region Các hàm hỗ trợ...

        // Load dữ lieu lên các TextBox tương ứng
        private void LoadTextBox()
        {
            int intID = 0;

            if (CommonClass.StringValidator.IsNumber(Request["ProductID"].ToString().Trim()))
                intID = int.Parse(Request["ProductID"].ToString().Trim());

            DB.DB_Object.ClassProduct objClassData = new DB.DB_Object.ClassProduct();
            DataTable dt = objClassData.getDataEditProduct(intID);
            foreach (DataRow dr in dt.Rows)
            {
                txtID.Text = dr["ProductID"].ToString();
                CboTypeProduct.SelectedValue = dr["TypeProduct"].ToString();
                txtNameProduct.Text = dr["NameProduct"].ToString();
                txtPathImages.Text = dr["ImagesProduct"].ToString();
                txtShortDescription.Text = dr["ShortDescription"].ToString();
                txtContent.Text = dr["Description"].ToString();
                txtPrice.Text = dr["Price"].ToString();
                txtPriceNew.Text = dr["PriceNew"].ToString();
                txtCodeProduct.Text = dr["CodeProduct"].ToString();
                txtStatus.Text = dr["Status"].ToString();
                txtPathImages1.Text = dr["ImagesOver"].ToString();
                txtNameProductEL.Text = dr["NameProductEL"].ToString();
                txtShortDescriptionEL.Text = dr["ShortDescriptionEL"].ToString();
                txtStatusEL.Text = dr["StatusEL"].ToString();
            }

            // Visible cái fileUpload khi không cần thiết
            FileUpload1.Visible = false;
            txtPathImages.Visible = true;
            btChangeImages.Visible = true;

            // Visible cái fileUpload khi không cần thiết
            FileUpload2.Visible = false;
            txtPathImages1.Visible = true;
            btChangeImages1.Visible = true;
        }

        // Gán lỗi khi phát sinh vào label thông báo lỗi        
        private void SetErrorMessage(string text)
        {
            _errorLabel.Text = "Thông báo : " + text;
            _errorLabel.Visible = null != text && 0 < text.Length;
        }

        // Load thông tin tên loại tin tức lên các combox VN
        protected void LoadComBoBoxTypeProduct()
        {
            DB.DB_Object.ClassTypeProduct ClassNews = new DB.DB_Object.ClassTypeProduct();
            DataTable dt = ClassNews.getDataTypeProduct();
            if (dt != null)
            {
                ListItem Item = new ListItem();
                Item.Text = "----- Chọn loại sản phẩm -----";
                Item.Value = "0";
                CboTypeProduct.Items.Add(Item);
                foreach (DataRow dr in dt.Rows)
                {
                    ListItem newItem = new ListItem();
                    newItem.Text = dr[1].ToString();
                    newItem.Value = dr[0].ToString();
                    CboTypeProduct.Items.Add(newItem);
                }
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

        // Insert mới thông tin một News...
        private void Insert()
        {
            try
            {
                int TypeProduct = int.Parse(CboTypeProduct.SelectedValue);
                string NameProduct = CommonClass.StringValidator.GetSafeString(txtNameProduct.Text.Trim());
                string NameProductEL = CommonClass.StringValidator.GetSafeString(txtNameProductEL.Text.Trim());
                string ShortDescription = txtShortDescription.Text.Trim();
                string ShortDescriptionEL = txtShortDescriptionEL.Text.Trim();
                string Description = txtContent.Text;
                int intPrice = int.Parse(txtPrice.Text.Trim());
                int intPriceNew = int.Parse(txtPriceNew.Text.Trim());
                string strCodeProduct = txtCodeProduct.Text.Trim();
                string strStatus = txtStatus.Text.Trim();
                string strStatusEL = txtStatusEL.Text.Trim();

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
                    strPathImages = "~/Images/ImgNews/" + Upload.StrFileName;
                }

                DB.DB_Object.ClassProduct objClassData = new DB.DB_Object.ClassProduct();
                if (objClassData.InsertProduct(TypeProduct, NameProduct, ShortDescription, Description, strPathImages, intPrice, intPriceNew, strCodeProduct, strStatus, strPathImages1,NameProductEL,ShortDescriptionEL,strStatusEL) == true)
                {
                    Response.Redirect("~/Amincp/ManagerProduct.aspx");
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
                int intProductID = int.Parse(txtID.Text.Trim());
                int TypeProduct = int.Parse(CboTypeProduct.SelectedValue);
                string NameProduct = CommonClass.StringValidator.GetSafeString(txtNameProduct.Text.Trim());
                string NameProductEL = CommonClass.StringValidator.GetSafeString(txtNameProductEL.Text.Trim());
                string ShortDescription = txtShortDescription.Text.Trim();
                string ShortDescriptionEL = txtShortDescriptionEL.Text.Trim();
                string Description = txtContent.Text.Trim();
                string strPathImages = txtPathImages.Text.Trim();
                int intPrice = int.Parse(txtPrice.Text.Trim());
                int intPriceNew = int.Parse(txtPriceNew.Text.Trim());
                string strStatus = txtStatus.Text.Trim();
                string strStatusEL = txtStatusEL.Text.Trim();

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

                DB.DB_Object.ClassProduct objClassData = new DB.DB_Object.ClassProduct();
                if (objClassData.UpdateProduct(intProductID, TypeProduct, NameProduct, ShortDescription, Description, strPathImages, intPrice, intPriceNew, strStatus, strPathImages1, NameProductEL, ShortDescriptionEL, strStatusEL) == true)
                {
                    Response.Redirect("~/Amincp/ManagerProduct.aspx");
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
            if (txtNameProduct.Text.Trim().Length <= 1)
            {
                CommonClass.MessageBox.Show("Chưa nhập tên sản phẩm!");
                txtNameProduct.Focus();
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
            Response.Redirect("~/Amincp/ManagerProduct.aspx");
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



        #endregion               
    }
}
