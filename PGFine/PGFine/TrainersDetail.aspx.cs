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
    public partial class TrainersDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string strTrainersID = "";
                try
                {
                    strTrainersID = Request.QueryString["ID"].ToString();
                    if (!string.IsNullOrEmpty(strTrainersID))
                    {
                        RenderData(strTrainersID);                                          
                    }
                }
                catch
                {
                    Response.Redirect("~/Trainers.aspx");
                }
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

        private void LoadDetail(int intNewsID, int intLanguages)
        {
            try
            {
                DB.DB_Object.ClassSize objClassData = new DB.DB_Object.ClassSize();
                lbContent.Text = objClassData.LoadDetail(intNewsID,intLanguages);
               
            }
            catch (Exception objExc)
            {
                SetErrorMessage(objExc.Message);
            }
        }

        private void RenderData(string strTrainersID)
        {

            //Label Information

            lbTrainers.Text = Location.GetLanguageTag("Trainner").ToString();

            if (Location.GetLocation == "VIE")
            {
                LoadDetail(int.Parse(strTrainersID), 2); // 1 là ngôn ngữ tiếng Anh, còn ngược lại là tiếng việt
                LoadTimes(2);               
            }
            else
            {
                LoadDetail(int.Parse(strTrainersID), 1); // 1 là ngôn ngữ tiếng Anh, còn ngược lại là tiếng việt
                LoadTimes(1); 
            }
        }


    }
}
