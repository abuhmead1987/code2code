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
    public partial class Default : System.Web.UI.Page
    {

        int pagesize = 5;

        #region Hàm Page Load....

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request["ID"]))
                {
                    LoadBanner(int.Parse(Request["ID"]));
                    pagesize = int.Parse(DropDownList1.SelectedValue);
                    hdCategory.Value = Request["ID"].ToString();
                    LblPage.Text = "1";                    
                    int rows = FillRecruiterAccount1(rptListProduct, pagesize);
                    hdToltalRows.Value = rows.ToString();
                    lblPages.Text = (rows / pagesize + ((rows % pagesize) > 0 ? 1 : 0)).ToString();
                    LinkPrevious.Enabled = false;
                    linkFirst.Enabled = false;
                    LoadPager();
                }
                else
                {
                    DB.DB_Object.ClassTypeProduct objClassData = new DB.DB_Object.ClassTypeProduct();
                    DataTable dt = objClassData.getDataTypeProduct();
                    if (dt.Rows.Count > 0)
                    {
                        LoadBanner(int.Parse(dt.Rows[0]["ID"].ToString()));
                        pagesize = int.Parse(DropDownList1.SelectedValue);
                        hdCategory.Value = dt.Rows[0]["ID"].ToString();
                        LblPage.Text = "1";
                        //txtPage.Text = LblPage.Text;
                        int rows = FillRecruiterAccount1(rptListProduct, pagesize);
                        hdToltalRows.Value = rows.ToString();
                        lblPages.Text = (rows / pagesize + ((rows % pagesize) > 0 ? 1 : 0)).ToString();
                        LinkPrevious.Enabled = false;
                        linkFirst.Enabled = false;
                        LoadPager();
                    }

                }

            }
            RenderData();
        }

        #endregion
        protected void rptListProduct_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                DataRowView ItemView = (DataRowView)e.Item.DataItem;

                Label lbPriceNew = e.Item.FindControl("lbPriceNew") as Label;
                Label lbPrice = e.Item.FindControl("lbPrice") as Label;
                HyperLink hplTitleProduct = e.Item.FindControl("hplTitleProduct") as HyperLink;

                if (Location.GetLocation == "VIE")
                    hplTitleProduct.Text = ItemView["NameProduct"].ToString();
                else
                    hplTitleProduct.Text = ItemView["NameProductEL"].ToString();

                if (int.Parse(ItemView["PriceNew"].ToString()) > 0)
                {
                    lbPriceNew.Text = ItemView["PriceNew"].ToString() + "VNĐ";
                    lbPrice.CssClass = "ColorPriceOld";
                }
                else
                {
                    lbPriceNew.Visible = false;
                    lbPrice.CssClass = "ColorPriceOldActive";
                }

            }
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

            //set pagging top
            PageList.DataSource = listPages;
            PageList.DataBind();

            //set pagging bottom
            rptPaggingBottom.DataSource = listPages;
            rptPaggingBottom.DataBind();
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

        // Gán lỗi khi phát sinh vào label thông báo lỗi        
        private void SetErrorMessage(string text)
        {
            _errorLabel.Text = "Thông báo : " + text;
            _errorLabel.Visible = null != text && 0 < text.Length;
        }
        public bool ktraso(string str)
        {
            try
            {
                int so = Convert.ToInt32(str);
                return false;
            }
            catch
            {
                return true;
            }
        }
        protected int GetOneV()
        {
            int rows = 0;
            SqlConnection connect = new SqlConnection(ConfigurationManager.AppSettings["STRING_CONNECT"]);
            connect.Open();
            string select = "select count(*) from Product where TypeProduct = " + int.Parse(hdCategory.Value);
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
            catch
            {

            }
            return totalRecord;
        }
        public DataTable ViewNewSP(int start, int maxR)
        {
            SqlConnection connect = new SqlConnection(ConfigurationManager.AppSettings["STRING_CONNECT"]);
            string select = "select * from Product where TypeProduct = " + int.Parse(hdCategory.Value);
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
            catch
            {

            }
            return totalRecord;
        }
        protected void LinkNext_Click1(object sender, EventArgs e)
        {
            //LinkPrevious.Enabled = true;
            //linkFirst.Enabled = true;
            //int currentPage = Convert.ToInt32(LblPage.Text);
            //int intPageSize = Convert.ToInt32(DropDownList1.SelectedValue);
            //if (currentPage > 0)
            //    currentPage++;
            ////        ControlProviders controlProviders = new ControlProviders();
            //FillRecruiterAccount(this.rptListProduct, (currentPage - 1) * intPageSize, intPageSize);
            //LblPage.Text = currentPage.ToString();
            ////txtPage.Text = LblPage.Text;
            ////if (FillRecruiterAccount(this.grid, (currentPage - 1) * pagesize + 1, pagesize) < pagesize)
            //if (currentPage == Convert.ToInt32(lblPages.Text))
            //{
            //    //   linkLast.Enabled = false;
            //    LinkNext.Enabled = false;
            //}
            //else
            //{
            //    linkFirst.Enabled = true;
            //    LinkPrevious.Enabled = true;
            //}
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

        public string getURLTooltip(object news_id)
        {
            return string.Format("BBTOnline_ShowTooltip('{0}?news_id=" + int.Parse(news_id.ToString()) + "'); return false;", ResolveUrl("~/ajax/showtooltip.aspx"));
        }

        private void RenderData()
        {
            lbPage.Text = Location.GetLanguageTag("PaggingPage").ToString();
            LinkNext.Text = Location.GetLanguageTag("ViewAll").ToString();
            lbDisplay.Text = Location.GetLanguageTag("NumberDisplay").ToString();
            lbtNextBottom.Text = Location.GetLanguageTag("ViewAll").ToString();
            lbPageBottom.Text = Location.GetLanguageTag("PaggingPage").ToString();
            lbBacktotop.Text = Location.GetLanguageTag("BacktoTop").ToString();
        }



    }




}
