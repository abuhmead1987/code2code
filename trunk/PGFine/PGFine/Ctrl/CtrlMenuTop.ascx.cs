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
using CommonClass;

namespace PGFine.Ctrl
{
    public partial class CtrlMenuTop : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Location.GetLocation == "VIE")
                {
                    CreateMenu(DB.Common.ClassPGFCommon.LanguagesContanst.VIETNAMMESE);
                }
                else
                {
                    CreateMenu(DB.Common.ClassPGFCommon.LanguagesContanst.ENGLISH);
                }
                
            }
        }

        private void CreateMenu(int intLanguages)
        {
            try
            {
                int intPositionDisPlay = 20000;
                DB.DB_Object.ClassTypeNews objClassData = new DB.DB_Object.ClassTypeNews();
                DataTable dt = objClassData.getDataTypeNewsByPositionDisPlay(intPositionDisPlay);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        MenuItem _menuItem = new MenuItem();

                        if (intLanguages == DB.Common.ClassPGFCommon.LanguagesContanst.ENGLISH)
                            _menuItem.Text = dr["NameNewsEL"].ToString();
                        else
                            _menuItem.Text = dr["NameNewsVN"].ToString();

                        if (!string.IsNullOrEmpty(dr["PageLink"].ToString()))
                        {
                            _menuItem.NavigateUrl = dr["PageLink"].ToString();
                        }
                        else
                        {
                            _menuItem.NavigateUrl = "~/news.aspx?typenewsid=" + dr["TypeNewsID"].ToString();
                        }

                        this.RendMenu(_menuItem, CtrMenuControl, int.Parse(dr["TypeNewsID"].ToString()), intLanguages);
                        CtrMenuControl.Items.Add(_menuItem);
                    }
                }
            }
            catch (Exception objExc)
            {
                SetErrorMessage(objExc.Message);
            }
        }

        private void RendMenu(MenuItem objMenuItem, Menu Menu, int intCategory, int intLanguages)
        {
            DB.DB_Object.ClassTypeNews objClassData = new DB.DB_Object.ClassTypeNews();
            DataTable dt = objClassData.getDataTypeNewsByNkey(intCategory);
            if(dt.Rows.Count>0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    MenuItem _menuItem = new MenuItem();                    

                    if (intLanguages == DB.Common.ClassPGFCommon.LanguagesContanst.ENGLISH)
                        _menuItem.Text = dr["NameNewsEL"].ToString();
                    else
                        _menuItem.Text = dr["NameNewsVN"].ToString();                        

                    if (!string.IsNullOrEmpty(dr["PageLink"].ToString()))
                    {
                        _menuItem.NavigateUrl = dr["PageLink"].ToString();
                    }
                    else
                    {
                        _menuItem.NavigateUrl = "~/news.aspx?typenewsid=" + dr["TypeNewsID"].ToString();
                    }
                    //_menuItem.SeparatorImageUrl = "~/Images/MiddlePrice.gif";
                    //_menuItem.PopOutImageUrl = "~/Images/MiddlePrice.gif";                    
                    objMenuItem.ChildItems.Add(_menuItem);
                }
            }
        }
        
        private void SetErrorMessage(string text)
        {
            _errorLabel.Text = "Thông báo : " + text;
            _errorLabel.Visible = null != text && 0 < text.Length;
        }



    }
}