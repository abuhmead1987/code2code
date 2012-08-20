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


namespace PGFine
{
    public partial class Trainers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string strTrainersID = "";
            try
            {
                strTrainersID = Request.QueryString["TrainersID"].ToString();
                if (!string.IsNullOrEmpty(strTrainersID))
                {
                    RenderData();
                }
            }
            catch
            {
                RenderData();
            }
        }

        // Gán lỗi khi phát sinh vào label thông báo lỗi        
        private void SetErrorMessage(string text)
        {
            _errorLabel.Text = "Thông báo : " + text;
            _errorLabel.Visible = null != text && 0 < text.Length;
        }

        private void LoadTimes(int LangugagesID)
        {
            DateTime dtData = DateTime.Now;
            if (LangugagesID == 1)
            {
                lbCaptionDay.Text = "Today, " + dtData.Day + "/" + dtData.Month + "/" + dtData.Year;
            }
            else
            {
                lbCaptionDay.Text = "Ngày, " + dtData.Day + "/" + dtData.Month + "/" + dtData.Year;
            }
        }

        private void LoadDataList(int intLanguagesID)
        {
            try
            {
                DB.DB_Object.ClassSize objClassData = new DB.DB_Object.ClassSize();
                DataTable dt = objClassData.getDataTrainers(intLanguagesID);
                if (dt.Rows.Count > 0)
                {
                    GridView1.DataSource = dt;
                    GridView1.DataBind();                 
                }
                else
                {
                    lbNewsNull.Visible = true;
                }
            }
            catch (Exception objExc)
            {
                SetErrorMessage(objExc.Message);
            }
        }

        private void RenderData()
        {

            //Label Information

            lbTrainers.Text = Location.GetLanguageTag("Trainner").ToString();

            if (Location.GetLocation == "VIE")
            {
                LoadDataList(2);    // 1 là ngôn ngữ tiếng Anh, còn ngược lại là tiếng việt                                                                     
                LoadTimes(2);       //Lấy thời gian hệ thống
            }
            else
            {
                LoadDataList(1);    // 1 là ngôn ngữ tiếng Anh, còn ngược lại là tiếng việt                                                                     
                LoadTimes(1);       //Lấy thời gian hệ thống
            }

            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                GridViewRow item = GridView1.Rows[i];
                HyperLink hplMore = (HyperLink)item.FindControl("hplMore");
                hplMore.Text = Location.GetLanguageTag("More").ToString();
            }
            GridView1.PagerSettings.LastPageText = Location.GetLanguageTag("Last").ToString();
            GridView1.PagerSettings.FirstPageText = Location.GetLanguageTag("First").ToString();

        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;            
            RenderData();
        }

    }
}
