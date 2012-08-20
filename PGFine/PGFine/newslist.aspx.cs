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
using Itech.Utils;
using CommonClass;
using System.Data.SqlClient;

namespace PGFine
{
    public partial class newslist : System.Web.UI.Page
    {
        int pagesize = 5;

        #region Hàm PageLoad....

        protected void rptListProduct_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                DataRowView Item = (DataRowView)e.Item.DataItem;

                Literal ltrImages = e.Item.FindControl("ltrImages") as Literal;
                HyperLink hplTitle = e.Item.FindControl("hplTitle") as HyperLink;
                Literal ltrShortDescription = e.Item.FindControl("ltrShortDescription") as Literal;
                HtmlControl htmlTitle = e.Item.FindControl("htmlTitle") as HtmlControl;
                HtmlControl htmlShort = e.Item.FindControl("htmlShort") as HtmlControl;
                Image imgDot_NewList = e.Item.FindControl("imgDot_NewList") as Image;
                HyperLink hplView = e.Item.FindControl("hplView") as HyperLink;
                
                if (e.Item.ItemIndex % 2 != 0)
                {
                    imgDot_NewList.Visible = false;
                }

                if (!CheckImagesDefault(Item["PathImages"].ToString()))
                {
                    ltrImages.Text = string.Format("<div class=\"ListNewsImages\"><a href='{0}' title='{1}'> <img Width=\"120px\" Height=\"90px\" src='{2}' border='0' /> </a></div>", ResolveUrl(string.Format("~/NewsDetail.aspx?newsid={0}", Item["NewsID"].ToString())), Item["TitleNewsVN"].ToString(), ResolveUrl(Item["PathImages"].ToString()));
                    htmlTitle.Attributes.Add("class", "ListNewsTitle");
                    htmlShort.Attributes.Add("class", "ListNewsShortDescript");
                }
                else
                {
                    ltrImages.Text = string.Format("<div class=\"ListNewsImages NoImages\"><img src='{0}' /> </div>", ResolveUrl(Item["PathImages"].ToString()));
                    htmlTitle.Attributes.Add("class", "ListNewsTitle NoI");
                    htmlShort.Attributes.Add("class", "ListNewsShortDescript NoI");
                }
                if (Location.GetLocation == "VIE")
                {
                    hplTitle.Text = Item["TitleNewsVN"].ToString();
                    ltrShortDescription.Text = Server.HtmlEncode(Item["ShortDescriptionVN"].ToString());
                }
                else
                {
                    hplTitle.Text = Item["TitleNewsEL"].ToString();
                    ltrShortDescription.Text = Server.HtmlEncode(Item["ShortDescriptionEL"].ToString());
                }
              
                hplTitle.NavigateUrl = ResolveUrl(string.Format("~/NewsDetail.aspx?newsid={0}", Item["NewsID"].ToString()));
                

                hplView.Text = Location.GetLanguageTag("View").ToString();
                hplView.NavigateUrl = ResolveUrl(string.Format("~/NewsDetail.aspx?newsid={0}", Item["NewsID"].ToString()));
            }
        }

        private bool CheckImagesDefault(string strImagesPath)
        {
            strImagesPath = strImagesPath.Replace("~/Images/ImgNews/", "").Replace(".GIF","");
            if (string.Compare(strImagesPath, "defaultimage") == 0)            
                return true;            
            else
                return false;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request["typenewsid"]))
                {
                    LoadBanner(int.Parse(Request["typenewsid"]));
                    pagesize = int.Parse(DropDownList1.SelectedValue);
                    hdCategory.Value = Request["typenewsid"].ToString();
                    LblPage.Text = "1";                    
                    int rows = FillRecruiterAccount1(rptListProduct, pagesize);
                    hdToltalRows.Value = rows.ToString();
                    lblPages.Text = (rows / pagesize + ((rows % pagesize) > 0 ? 1 : 0)).ToString();
                    LinkPrevious.Enabled = false;
                    linkFirst.Enabled = false;
                    LoadPager();
                    LoadBreakrum(int.Parse(Request["typenewsid"]));
                }
                else
                {
                    Response.Redirect("~/Default.aspx");
                }
            }
        }

        private void LoadBreakrum(int intTypeNewsId)
        {
            DB.DB_Object.ClassTypeNews objClassData = new DB.DB_Object.ClassTypeNews();
            DataTable dt = objClassData.getDataEditTypeNews(intTypeNewsId);
            if (dt.Rows.Count > 0)
            {
                lbBreakrum.Text = dt.Rows[0]["NameNewsVN"].ToString();
            }
        }

        #endregion

        #region Hàm Hỗ Trợ....

        // Gán lỗi khi phát sinh vào label thông báo lỗi        
        private void SetErrorMessage(string text)
        {
            _errorLabel.Text = "Thông báo : " + text;
            _errorLabel.Visible = null != text && 0 < text.Length;
        }

        protected void PageList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                // set CSS for current page
                LinkButton PageIndexLink = e.Item.FindControl("PageIndexLink") as LinkButton;

                PageIndexLink.ToolTip = string.Format("{0} {1}", "Page", Convert.ToInt32(PageIndexLink.CommandName) + 1);
                if (PageIndexLink.CommandName.Equals((int.Parse(LblPage.Text) - 1).ToString()))
                {
                    PageIndexLink.Enabled = false;
                }
            }
        }

        protected void PageList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            // change current page
            LblPage.Text = (int.Parse(e.CommandName) + 1).ToString();
            //lay ra trang hien hanh
            int currentPage = int.Parse(e.CommandName) + 1;

            FillRecruiterAccount(this.rptListProduct, (currentPage - 1) * int.Parse(DropDownList1.SelectedValue), int.Parse(DropDownList1.SelectedValue));
            LblPage.Text = currentPage.ToString();
            LoadPager();
            LinkButton PageIndexLink = e.Item.FindControl("PageIndexLink") as LinkButton;
            if (PageIndexLink.CommandName.Equals((int.Parse(LblPage.Text)).ToString()))
                PageIndexLink.Enabled = false;
            else
                PageIndexLink.Enabled = true;
        }

        private void LoadPager()
        {
            SortedList listPages = new SortedList();
            for (int i = 0; i < int.Parse(lblPages.Text); i++)
            {
                if (i < int.Parse(lblPages.Text))
                {
                    listPages.Add(i, i + 1);
                }
            }

            PageList.DataSource = listPages;
            PageList.DataBind();
        }

        private void LoadBanner(int intTypeProductID)
        {
            DB.DB_Object.ClassTypeProduct objClassData = new DB.DB_Object.ClassTypeProduct();
            DataTable dt = objClassData.getDataEditTypeProduct(intTypeProductID);
            if (dt.Rows.Count > 0)
            {
                CtrlMainBanner1.BannerPath = dt.Rows[0]["ImagePath"].ToString().Replace("~", "");
            }
        }
       
        public bool ktraso(string str)
        {
            try
            {
                int so = Convert.ToInt32(str);
                return false;
            }
            catch(Exception ex)
            {
                return true;
            }
        }
        protected int GetOneV()
        {
            int rows = 0;
            SqlConnection connect = new SqlConnection(ConfigurationManager.AppSettings["STRING_CONNECT"]);
            connect.Open();
            string select = "select count(*) from PGF_News where TypeNewsID = " + int.Parse(hdCategory.Value);
            SqlCommand cmd = new SqlCommand(select, connect);
            rows = Convert.ToInt32(cmd.ExecuteScalar());
            connect.Close();
            return rows;
        }
        public int FillRecruiterAccount1(Repeater DataList1, int maxRecord)
        {
            int totalRecord = 0;
            try
            {
                SqlConnection connect = new SqlConnection(ConfigurationManager.AppSettings["STRING_CONNECT"]);
                connect.Open();
                DataTable dt = ViewNewSP(0, maxRecord);
                totalRecord = GetOneV();
                DataList1.DataSource = dt;
                DataList1.DataBind();
            }
            catch (Exception ex)
            {

            }
            return totalRecord;
        }
        public DataTable ViewNewSP(int start, int maxR)
        {
            SqlConnection connect = new SqlConnection(ConfigurationManager.AppSettings["STRING_CONNECT"]);
            string select = "select * from PGF_News where TypeNewsID = " + int.Parse(hdCategory.Value);
            SqlDataAdapter adapter = new SqlDataAdapter(select, connect);
            DataTable dt = new DataTable();
            adapter.Fill(start, maxR, dt);
            return dt;
        }
        public int FillRecruiterAccount(Repeater DataList1, int startRecord, int maxRecord)
        {
            int totalRecord = 0;
            try
            {
                SqlConnection connect = new SqlConnection(ConfigurationManager.AppSettings["STRING_CONNECT"]);
                connect.Open();
                DataTable dt = ViewNewSP(startRecord, maxRecord);
                totalRecord = dt.Rows.Count;

                DataList1.DataSource = dt;
                DataList1.DataBind();
            }
            catch (Exception ex)
            {

            }
            return totalRecord;
        }
        protected void LinkNext_Click1(object sender, EventArgs e)
        {            
            LinkPrevious.Enabled = true;
            linkFirst.Enabled = true;
            int currentPage = 1;
            int intPageSize = int.MaxValue;
            FillRecruiterAccount(this.rptListProduct, (currentPage - 1) * intPageSize, intPageSize);
            LblPage.Text = currentPage.ToString();

            if (currentPage == Convert.ToInt32(lblPages.Text))
            {
                //   linkLast.Enabled = false;
                LinkNext.Enabled = false;
            }
            else
            {
                linkFirst.Enabled = true;
                LinkPrevious.Enabled = true;
            }
        }
        protected void LinkPrevious_Click(object sender, EventArgs e)
        {
            LinkPrevious.Enabled = true;

            int currentPage = Convert.ToInt32(LblPage.Text);
            int intPageSize = Convert.ToInt32(DropDownList1.SelectedValue);
            if (currentPage > 1)
                currentPage--;

            FillRecruiterAccount(rptListProduct, (currentPage - 1) * intPageSize, intPageSize);

            LblPage.Text = currentPage.ToString();
            //txtPage.Text = LblPage.Text;

            if (currentPage == 1)
            {
                LinkPrevious.Enabled = false;
                //LinkNext.Enabled = true;
                linkFirst.Enabled = false;
            }
            else
            {
                LinkPrevious.Enabled = true;
                linkFirst.Enabled = true;
                LinkNext.Enabled = true;
            }
        }
        protected void linkFirst_Click(object sender, EventArgs e)
        {
            int intPageSize = Convert.ToInt32(DropDownList1.SelectedValue);
            FillRecruiterAccount(this.rptListProduct, 0, intPageSize);
            LblPage.Text = "1";
            //txtPage.Text = LblPage.Text;
            LinkPrevious.Enabled = false;
            linkFirst.Enabled = false;

            LinkNext.Enabled = true;
            //   linkLast.Enabled = true;
        }
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int soP = Convert.ToInt32(DropDownList1.SelectedValue);
            int so = Convert.ToInt32(lblPages.Text);

            //lay ra trang hien hanh
            int currentPage = 1;

            //số page
            int rows = FillRecruiterAccount1(rptListProduct, soP);
            hdToltalRows.Value = rows.ToString();
            lblPages.Text = (rows / soP + ((rows % soP) > 0 ? 1 : 0)).ToString();

            FillRecruiterAccount(this.rptListProduct, (currentPage - 1) * soP, soP);
            LblPage.Text = currentPage.ToString();
            //cho phep su dung cac lien ket
            linkFirst.Enabled = true;
            LinkPrevious.Enabled = true;
            LinkNext.Enabled = true;
            //vo hieu hoa first va last neu trang cuoi cung
            if (currentPage == Convert.ToInt32(lblPages.Text))
            {
                LinkNext.Enabled = false;
            }
            //vo hieu hoa First va Previos neu trang dau tien
            if (currentPage == 1)
            {
                linkFirst.Enabled = false;
                LinkPrevious.Enabled = false;
            }
            LoadPager();

        }
             
    
        #endregion

    }
}
