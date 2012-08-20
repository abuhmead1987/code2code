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

namespace PGFine
{
    public partial class SentVote : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Render();
        }
        private void Render()
        {
            hplClose.Text = Location.GetLanguageTag("Close").ToString();
            lbtSent.Text = Location.GetLanguageTag("btSent").ToString();
            ltrComment.Text = Location.GetLanguageTag("Comment").ToString();
        }

        protected void chkFiveVote_CheckedChanged(object sender, EventArgs e)
        {
            chkFiveVote.Checked = true;
            chkFournVote.Checked = false;
            chkThreeVote.Checked = false;
            chkTwoVote.Checked = false;
            chkOnceVote.Checked = false;
        }

        protected void chkFournVote_CheckedChanged(object sender, EventArgs e)
        {
            chkFiveVote.Checked = false;
            chkFournVote.Checked = true;
            chkThreeVote.Checked = false;
            chkTwoVote.Checked = false;
            chkOnceVote.Checked = false;
        }

        protected void chkThreeVote_CheckedChanged(object sender, EventArgs e)
        {
            chkFiveVote.Checked = false;
            chkFournVote.Checked = false;
            chkThreeVote.Checked = true;
            chkTwoVote.Checked = false;
            chkOnceVote.Checked = false;
        }

        protected void chkTwoVote_CheckedChanged(object sender, EventArgs e)
        {
            chkFiveVote.Checked = false;
            chkFournVote.Checked = false;
            chkThreeVote.Checked = false;
            chkTwoVote.Checked = true;
            chkOnceVote.Checked = false;
        }

        protected void chkOnceVote_CheckedChanged(object sender, EventArgs e)
        {
            chkFiveVote.Checked = false;
            chkFournVote.Checked = false;
            chkThreeVote.Checked = false;
            chkTwoVote.Checked = false;
            chkOnceVote.Checked = true;
        }
        // Gán lỗi khi phát sinh vào label thông báo lỗi        
        private void SetErrorMessage(string text)
        {
            _errorLabel.Text = "Thông báo : " + text;
            _errorLabel.Visible = null != text && 0 < text.Length;
        }
        private void ReBegin()
        {
            chkFiveVote.Checked = false;
            chkFournVote.Checked = false;
            chkThreeVote.Checked = false;
            chkTwoVote.Checked = false;
            chkOnceVote.Checked = false;
        }
        protected void lbtSent_Click(object sender, EventArgs e)
        {
            int intVote = 0;
            int intProductID = 0;
            if (!string.IsNullOrEmpty(Request["id"]))
            {
                intProductID = int.Parse(Request["id"]);
                if (chkOnceVote.Checked == true)
                    intVote = 2;
                if (chkTwoVote.Checked == true)
                    intVote = 4;
                if (chkThreeVote.Checked == true)
                    intVote = 6;
                if (chkFournVote.Checked == true)
                    intVote = 8;
                if (chkFiveVote.Checked == true)
                    intVote = 10;

                DB.DB_Object.ClassProduct objClassData = new DB.DB_Object.ClassProduct();
                try
                {
                    if (objClassData.InsertVote(intProductID,intVote) == true)
                    {
                        //thanh cong
                        ReBegin();
                        CommonClass.MessageBox.Show("Gửi bình luận thành công!");
                        return;
                    }
                    else
                    {
                        CommonClass.MessageBox.Show("Lỗi kết nối đến Server. Vui lòng kiểm tra hệ thống mạng!");
                    }
                }
                catch (Exception ex)
                {
                    SetErrorMessage(ex.Message);
                }
            }
        }
    }
}
