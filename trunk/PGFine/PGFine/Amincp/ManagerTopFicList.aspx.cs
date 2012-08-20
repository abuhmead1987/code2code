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
using System.Text;

namespace PGFine.Amincp
{
    public partial class ManagerTopFicList : System.Web.UI.Page
    {
        StringBuilder strHTML = new StringBuilder();
       

        protected void Page_Load(object sender, EventArgs e)
        {
            LoadGrid();             
        }
        private void LoadGrid()
        {
            int intNkey = 0;//Null=0
            DB.DB_Object.ClassTypeNews objClassData = new DB.DB_Object.ClassTypeNews();
            DataTable dt = objClassData.getDataTypeNewsByNkey(intNkey);
            if (dt.Rows.Count > 0)
            {
                
                foreach (DataRow dr in dt.Rows)
                {
                    //Create Grid
                    string strPosition = string.Empty;
                    if (int.Parse(dr["PositionDisPlay"].ToString()) == 0)
                    {
                        strPosition = "Menu trên";
                    }
                    else if (int.Parse(dr["PositionDisPlay"].ToString()) == 1)
                    {
                        strPosition = "Menu dưới";
                    }
                    else if (int.Parse(dr["PositionDisPlay"].ToString()) == 2)
                    {
                        strPosition = "Menu trên + Dưới";
                    }
                    else if (int.Parse(dr["PositionDisPlay"].ToString()) == 3)
                    {
                        strPosition = "Menu trên phải";
                    }
                    else
                    {
                        strPosition = "Chi tiết sản phẩm";
                    }

                    strHTML.AppendFormat("<tr style=\"height:20px;\"><td><a href='{0}'>{1}</a></td><td>{2}</td><td>{3}</td></tr>", ResolveUrl("~/Amincp/ManagerTopFicEditor.aspx?Flag=Edit&TypeNewsID=" + dr["TypeNewsID"].ToString()), dr["NameNewsVN"].ToString(), dr["OrderNo"].ToString(), strPosition);

                    //Tạo menu cap 2
                    CreateMenuItem(int.Parse(dr["TypeNewsID"].ToString()));
                }
                ltrHtmlTr.Text = strHTML.ToString();
            }
        }

        private void CreateMenuItem(int intNkey)
        {
            DB.DB_Object.ClassTypeNews objClassData = new DB.DB_Object.ClassTypeNews();
            DataTable dt = objClassData.getDataTypeNewsByNkey(intNkey);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    //Create Grid
                    string strPosition = string.Empty;
                    if (int.Parse(dr["PositionDisPlay"].ToString()) == 0)
                    {
                        strPosition = "Menu trên";
                    }
                    else if (int.Parse(dr["PositionDisPlay"].ToString()) == 1)
                    {
                        strPosition = "Menu dưới";
                    }
                    else if (int.Parse(dr["PositionDisPlay"].ToString()) == 2)
                    {
                        strPosition = "Menu trên + Dưới";
                    }
                    else if (int.Parse(dr["PositionDisPlay"].ToString()) == 3)
                    {
                        strPosition = "Menu trên phải";
                    }
                    else
                    {
                        strPosition = "Chi tiết sản phẩm";
                    }

                    strHTML.AppendFormat("<tr><td class=\"TopficLeft\"><a href='{0}'>{1}</a></td><td>{2}</td><td>{3}</td></tr>", ResolveUrl("~/Amincp/ManagerTopFicEditor.aspx?Flag=Edit&TypeNewsID=" + dr["TypeNewsID"].ToString()), dr["NameNewsVN"].ToString(), dr["OrderNo"].ToString(), strPosition);
                }
            }
        }


    }
}
