using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;


namespace PGFine.Ctrl
{
    public partial class CtrListPage : System.Web.UI.UserControl
    {
        public delegate void ListPagerEventHandler(object sender, int eventArgument);        
        public delegate void NextPagerEventHandler(object sender, int eventArgument);
        public event NextPagerEventHandler PageIndexNextEvent;

        //private int _numSize = PageNumber.NumberSize;
        //private int _pageSize = PageNumber.PageSize;
        private int _numSize = 5;
        private int _pageSize = 2;

        #region "Properties"

        public int NumSize
        {
            set { _numSize = value; }
            get { return _numSize; }
        }

        public int CurrentPageIndex
        {
            get
            {
                if (ViewState["CurrentPageIndex"] == null)
                {
                    int page = 0;
                    if (Request["page"] != null)
                    {
                        int.TryParse(Request["page"], out page);
                        page = page - 1;
                    }

                    // set PagerCurrentIndex
                    if (page > (PagerCurrentPageIndex + 1) * PagerPageSize)
                    {
                        PagerCurrentPageIndex = page / PageSize - 1;
                    }
                    ViewState["CurrentPageIndex"] = page;
                }

                return (int)ViewState["CurrentPageIndex"];
            }
            set
            {
                ViewState["CurrentPageIndex"] = value;
            }
        }

        public int PageCount
        {
            get
            {
                if (ViewState["PageCount"] == null)
                {
                    ViewState["PageCount"] = 1;
                }

                return (int)ViewState["PageCount"];
            }
            set
            {
                ViewState["PageCount"] = value;
            }
        }

        public int PageSize
        {
            get
            {
                if (ViewState["PageSize"] == null)
                {
                    int size = 0;
                    if (Request["size"] != null)
                    {
                        int.TryParse(Request["size"], out size);
                    }
                    //ListItem item = NumberOfItemOnPageDropDownList.Items.FindByValue(size.ToString());
                    //if (item != null)
                    //{
                    //    NumberOfItemOnPageDropDownList.SelectedValue = size.ToString();
                    //}
                    ViewState["PageSize"] = NumSize;//Convert.ToInt32(NumberOfItemOnPageDropDownList.SelectedValue);
                }

                return (int)ViewState["PageSize"];
            }
            set
            {
                ViewState["PageSize"] = value;
            }
        }

        protected int PagerCurrentPageIndex
        {
            get
            {
                if (ViewState["PagerCurrentPageIndex"] == null)
                {
                    ViewState["PagerCurrentPageIndex"] = 0;
                }

                return (int)ViewState["PagerCurrentPageIndex"];
            }
            set
            {
                ViewState["PagerCurrentPageIndex"] = value;
            }
        }

        protected int PagerPageSize
        {
            get
            {
                if (ViewState["PagerPageSize"] == null)
                {
                    ViewState["PagerPageSize"] = _pageSize;
                }

                return (int)ViewState["PagerPageSize"];
            }
            set
            {
                ViewState["PagerPageSize"] = value;
            }
        }

        protected int PagerPageCount
        {
            get
            {
                if (ViewState["PagerPageCount"] == null)
                {
                    ViewState["PagerPageCount"] = 0;
                }

                return (int)ViewState["PagerPageCount"];
            }
            set
            {
                ViewState["PagerPageCount"] = value;
            }
        }

        public ScriptManager ScriptManager
        {
            get
            {
                return scriptManager;
            }
            set
            {
                scriptManager = value;
            }
        }

        #endregion

        protected ScriptManager scriptManager;

        protected void Page_Load(object sender, EventArgs e)
        {
            // add postback controls
            if (ScriptManager != null)
            {
                ScriptManager.RegisterPostBackControl(PageList);
            }

        }

        /// <summary>
        /// Refresh pager data
        /// </summary>
        public void RefreshPager()
        {
            if (CurrentPageIndex == PageCount)
            {
                CurrentPageIndex = PageCount - 1;
            }
            else
            {
                if (CurrentPageIndex > PageCount)
                {
                    CurrentPageIndex = 0;
                }
            }         

            // bind data for Pager
            PagerPageCount = PageCount % PagerPageSize == 0 ? PageCount / PagerPageSize : PageCount / PagerPageSize + 1;

            SortedList listPages = new SortedList();
            for (int i = PagerCurrentPageIndex * PagerPageSize; i < (PagerCurrentPageIndex + 1) * PagerPageSize; i++)
            {
                if (i < PageCount)
                {
                    listPages.Add(i, i + 1);
                }
            }

            PageList.DataSource = listPages;
            PageList.DataBind();

            // show hide buttons
            //NextPagerContainer.Visible = PagerCurrentPageIndex == PagerPageCount - 1 ? false : true;
            //PreviousPagerContainer.Visible = PagerCurrentPageIndex == 0 ? false : true;
            PageList.Visible = listPages.Count == 1 ? false : true;
            //NextPager.Visible = CurrentPageIndex == PageCount - 1 ? false : true;
            //LastLinkContainer.Visible = CurrentPageIndex == PageCount - 1 ? false : true;
            //PreviousPager.Visible = CurrentPageIndex == 0 ? false : true;
            //FirstLinkContainer.Visible = CurrentPageIndex == 0 ? false : true;
        }

        /// <summary>
        /// Raise event
        /// </summary>
        private void RaiseEvent()
        {

            // raise next pag
            if (PageIndexNextEvent != null)
            {
                PageIndexNextEvent(this, CurrentPageIndex);
            }

        }

        protected void PageList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            // change current page
            CurrentPageIndex = Convert.ToInt32(e.CommandName);
            RaiseEvent();
        }

        protected void PreviousLink_Click(object sender, EventArgs e)
        {
            // change current page
            CurrentPageIndex = CurrentPageIndex - 1;
            if (CurrentPageIndex < PagerCurrentPageIndex * PagerPageSize) PagerCurrentPageIndex -= 1;
            RaiseEvent();
        }

        protected void NextLink_Click(object sender, EventArgs e)
        {
            // change current page
            CurrentPageIndex = CurrentPageIndex + 1;
            if (CurrentPageIndex >= (PagerCurrentPageIndex + 1) * PagerPageSize) PagerCurrentPageIndex += 1;
            RaiseEvent();
        }

        protected void PageList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                // set CSS for current page
                LinkButton PageIndexLink = e.Item.FindControl("PageIndexLink") as LinkButton;

                PageIndexLink.ToolTip = string.Format("{0} {1}","Page", Convert.ToInt32(PageIndexLink.CommandName) + 1);
                if (PageIndexLink.CommandName.Equals(CurrentPageIndex.ToString()))
                {
                    PageIndexLink.Enabled = false;                   
                }
            }            
        }        

        protected void PreviousPager_Click(object sender, EventArgs e)
        {

            CurrentPageIndex -= 1;
            RaiseEvent();
        }

        protected void NextPager_Click(object sender, EventArgs e)
        {
            CurrentPageIndex += 1;
            RaiseEvent();
        }

        protected void lbtnChangePageSize_Click(object sender, EventArgs e)
        {
            // get selected index
            int index = Convert.ToInt32(Request.Params.Get("__EVENTARGUMENT"));
            //NumberOfItemOnPageDropDownList.SelectedIndex = index;

            // change page size
            PageSize = NumSize;// Convert.ToInt32(NumberOfItemOnPageDropDownList.SelectedValue);

            // reset current page index
            CurrentPageIndex = 0;
            // reset current pager index
            PagerCurrentPageIndex = 0;
            //NumberOfItemOnPageDropDownList.ToolTip = string.Format("Show {0} items on page", NumberOfItemOnPageDropDownList.SelectedValue);
            RaiseEvent();
        }
    }
}