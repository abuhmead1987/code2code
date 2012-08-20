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

namespace PGFine.Ctrl
{
    public partial class CtrlMenu : System.Web.UI.UserControl
    {

        #region các Properties.......

        DataTable m_DataMenu;
        public DataTable DataMenu
        {
            set
            {
                m_DataMenu = value;
            }
        }

        string m_SessionLanguages;
        public string Languages
        {
            set
            {
                m_SessionLanguages = value;
            }
        }

        string m_TextTitleEL;
        public string TextTitleEL
        {
            set
            {
                m_TextTitleEL = value;
            }
        }

        string m_TextTitleVN;
        public string TextTitleVN
        {
            set
            {
                m_TextTitleVN = value;
            }
        }

        string m_LinksPages;
        public string LinksPages
        {
            set
            {
                m_LinksPages = value;
            }
        }      


        #endregion

        #region Hàm khởi tạo....

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CreateMenu(CtrMenuControl, m_DataMenu, m_SessionLanguages, m_TextTitleEL, m_TextTitleVN);
            }
        }

        #endregion

        #region các phương thức, hàm....

        private void CreateMenu(Menu Menu, DataTable dataMenuR, string Languages, string TextTitleEL, string TextTitleVN)//, string NameImageBetwen, string XMPPath)
        {

            if (Languages == "1")
            {
                MenuItem _menuItem = new MenuItem();
                _menuItem.Text = TextTitleEL;
                _menuItem.NavigateUrl = m_LinksPages + "0";
                this.RendMenu(_menuItem, Menu, dataMenuR, "1");
                Menu.Items.Add(_menuItem);
            }
            else
            {
                MenuItem _menuItem = new MenuItem();
                _menuItem.Text = TextTitleVN;
                _menuItem.NavigateUrl = m_LinksPages + "0";
                this.RendMenu(_menuItem, Menu, dataMenuR, "2");
                Menu.Items.Add(_menuItem);
            }
        }
        private void RendMenu(MenuItem objMenuItem, Menu Menu, DataTable dtMenu, string Languages)
        {
            if (dtMenu == null)
                return;
            if (Languages == "1")
            {
                DataRow[] ArrayDataRow = dtMenu.Select("Nkey is null");
                for (int i = 0; i < ArrayDataRow.Length; i++)
                {
                    MenuItem _menuItem = new MenuItem();                    
                    _menuItem.Text = ArrayDataRow[i]["NameNewsEL"].ToString();
                    // _menuItem.ImageUrl = "~/Images/Symbol1.gif";

                    // kiểm tra xem có là node cuoi cung trong menu khong?
                    DataRow[] DataRowCoutRows = dtMenu.Select("Nkey = " + ArrayDataRow[i][0]);
                    if (DataRowCoutRows.Length <= 0)
                    {
                        _menuItem.NavigateUrl = m_LinksPages + ArrayDataRow[i][0].ToString();
                    }

                    this.RendItem(_menuItem, dtMenu, ArrayDataRow[i][0].ToString(), "1");                     
                    objMenuItem.ChildItems.Add(_menuItem);
                }
            }
            else
            {
                DataRow[] ArrayDataRow = dtMenu.Select("Nkey is null");
                for (int i = 0; i < ArrayDataRow.Length; i++)
                {
                    MenuItem _menuItem = new MenuItem();                    
                    _menuItem.Text = ArrayDataRow[i]["NameNewsVN"].ToString();

                    // kiểm tra xem có là node cuoi cung trong menu khong?
                    DataRow[] DataRowCoutRows = dtMenu.Select("Nkey = " + ArrayDataRow[i][0]);
                    if (DataRowCoutRows.Length <= 0)
                    {
                        _menuItem.NavigateUrl = m_LinksPages + ArrayDataRow[i][0].ToString();
                    }

                    this.RendItem(_menuItem, dtMenu, ArrayDataRow[i][0].ToString(), "2");                   
                    objMenuItem.ChildItems.Add(_menuItem);
                }
            }
        }
        private void RendItem(MenuItem MenuItemObj, DataTable dtMenu, string Nkey, string Languages)
        {
            if (Languages == "1")
            {
                DataRow[] ArrayDataRowItem = dtMenu.Select("Nkey = " + int.Parse(Nkey));
                for (int i = 0; i < ArrayDataRowItem.Length; i++)
                {
                    MenuItem _menuItem = new MenuItem();
                    _menuItem.NavigateUrl = m_LinksPages + ArrayDataRowItem[i][0].ToString();                  
                    _menuItem.Text = ArrayDataRowItem[i]["NameNewsEL"].ToString();
                    MenuItemObj.ChildItems.Add(_menuItem);
                }
            }
            else
            {
                DataRow[] ArrayDataRowItem = dtMenu.Select("Nkey = " + int.Parse(Nkey));
                for (int i = 0; i < ArrayDataRowItem.Length; i++)
                {
                    MenuItem _menuItem = new MenuItem();
                    _menuItem.NavigateUrl = m_LinksPages + ArrayDataRowItem[i][0].ToString();                  
                    _menuItem.Text = ArrayDataRowItem[i]["NameNewsVN"].ToString();
                    MenuItemObj.ChildItems.Add(_menuItem);
                }
            }
        }

        #endregion

    }
}