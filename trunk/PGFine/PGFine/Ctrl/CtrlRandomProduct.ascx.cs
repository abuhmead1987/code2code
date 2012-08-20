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

namespace PGFine.Ctrl
{
    public partial class CtrlRandomProduct : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadOrtherProduct();
            }
        }
        private DataTable AddRowsToDataTable(DataRow dr, DataTable dtListNews)
        {
            // New once Rows
            DataRow drListOrthers;
            drListOrthers = dtListNews.NewRow();

            // set values to rows                                       
            drListOrthers["productId"] = dr["ProductID"].ToString();
            drListOrthers["NameProduct"] = dr["NameProduct"].ToString();
            if (int.Parse(dr["PriceNew"].ToString()) <= 0)         
                drListOrthers["Price"] = dr["Price"].ToString();            
            else
                drListOrthers["Price"] = dr["PriceNew"].ToString();
            drListOrthers["Images"] = dr["ImagesProduct"].ToString();

            dtListNews.Rows.Add(drListOrthers);
            return dtListNews;
        }


        private void LoadOrtherProduct()
        {
            DB.DB_Object.ClassProduct objClassData = new DB.DB_Object.ClassProduct();
            DataTable dt = objClassData.getDataProduct();

            //Khởi tạo DataTable
            DataTable dtNew = new DataTable();

            // create column            
            DataColumn productId = new DataColumn("productId", Type.GetType("System.String"));
            DataColumn NameProduct = new DataColumn("NameProduct", Type.GetType("System.String"));
            DataColumn Price = new DataColumn("Price", Type.GetType("System.String"));
            DataColumn Images = new DataColumn("Images", Type.GetType("System.String"));

            // add cloumn to table 
            dtNew.Columns.Add(productId);
            dtNew.Columns.Add(NameProduct);
            dtNew.Columns.Add(Price);
            dtNew.Columns.Add(Images);
            int values = 0;
            int intFlag = 0;
            if (dt.Rows.Count > 0)
            {
                for (int w = 0; w < 6; w++)
                {
                    Random rnd = new Random();
                    for (int i = 0; i <= dt.Rows.Count; i++)
                    {
                        values = rnd.Next(i);
                    }

                    if (dt.Rows.Count - values > 0)
                    {
                        for (int g = values; g < dt.Rows.Count; g++)
                        {
                            if (intFlag < 6)
                            {
                                AddRowsToDataTable(dt.Rows[g], dtNew);
                                intFlag++;
                            }
                        }
                    }
                    else
                    {
                        for (int g = 0; g < 6; g++)
                        {
                            if (!string.IsNullOrEmpty(dt.Rows[g]["ProductID"].ToString()))
                            {
                                AddRowsToDataTable(dt.Rows[g], dtNew);
                            }
                        }
                    }
                    if (intFlag < 6)
                    {
                        for (int g = 0; g < 6; g++)
                        {
                            if (!string.IsNullOrEmpty(dt.Rows[g]["ProductID"].ToString()))
                            {
                                if (intFlag < 6)
                                {
                                    AddRowsToDataTable(dt.Rows[g], dtNew);
                                    intFlag++;
                                }
                            }
                        }
                    }
                }

            }
            if (dtNew.Rows.Count > 0)
            {
                rptOrtherProduct.DataSource = dtNew;
                rptOrtherProduct.DataBind();
            }
        }

        // Gán lỗi khi phát sinh vào label thông báo lỗi        
        private void SetErrorMessage(string text)
        {
            _errorLabel.Text = "Thông báo : " + text;
            _errorLabel.Visible = null != text && 0 < text.Length;
        }
        protected void rptOrtherProduct_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                DataRowView ItemRows = (DataRowView)e.Item.DataItem;

                Image imaImageOrther = e.Item.FindControl("imaImageOrther") as Image;
                HyperLink hplDetailOrther = e.Item.FindControl("hplDetailOrther") as HyperLink;
                HyperLink hplNameProduct = e.Item.FindControl("hplNameProduct") as HyperLink;
                Literal ltrPrice = e.Item.FindControl("ltrPrice") as Literal;

                imaImageOrther.ImageUrl = ItemRows["Images"].ToString();
                hplDetailOrther.NavigateUrl = string.Format("~/ProductDetail.aspx?productid={0}", ItemRows["productId"].ToString());
                hplNameProduct.NavigateUrl = string.Format("~/ProductDetail.aspx?productid={0}", ItemRows["productId"].ToString());
                hplNameProduct.Text = ItemRows["NameProduct"].ToString();
                ltrPrice.Text = ItemRows["Price"].ToString();
            }
        }
    }
}