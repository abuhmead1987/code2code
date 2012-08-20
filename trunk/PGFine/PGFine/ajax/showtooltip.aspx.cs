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

namespace PGFine.ajax
{
    public partial class showtooltip : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request["news_id"]))
            {
                DB.DB_Object.ClassProduct objClassData = new DB.DB_Object.ClassProduct();
                DataTable dt = objClassData.getDataEditProduct(int.Parse(Request["news_id"]));
                if (dt.Rows.Count > 0)
                {
                    imgTooltip.ImageUrl = ResolveUrl(dt.Rows[0]["ImagesOver"].ToString());
                    if (dt.Rows[0]["ImagesOver"].ToString().Trim().Replace("~/Images/ImgNews/", "").Replace(".GIF", "") == "defaultimage")
                    {
                        imgTooltip.ImageUrl = ResolveUrl(dt.Rows[0]["ImagesProduct"].ToString());                        
                    }
                    else if (string.IsNullOrEmpty(dt.Rows[0]["ImagesOver"].ToString()))
                    {
                        imgTooltip.ImageUrl = ResolveUrl(dt.Rows[0]["ImagesProduct"].ToString());
                    }
                }
            }
             
        }
    }
}
