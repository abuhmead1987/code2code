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
using anm_utility;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Drawing.Drawing2D;

public partial class Controls_MyProfile : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.IsAuthenticated)
        {
            anm_Utility ut = new anm_Utility();
            Page.Title = ut.GetSetting("SiteName") + " - " + GetGlobalResourceObject("language", "MyAccount");
            MembershipUser user = Membership.GetUser();
            if (user == null)
                Response.Redirect(Page.Request.Url.AbsolutePath.ToString() + "?p=Confirm&mes=" + GetGlobalResourceObject("language", "nopermission") + "");
            lbl1.Text = "<b>" + user.UserName + "</b> " + GetGlobalResourceObject("language", "confirmdeleteacc");
            string pathToCheck = Server.MapPath("~\\images\\Avatars\\") + user.UserName + ".jpg";
            if (System.IO.File.Exists(pathToCheck))
                ImgAvatar.ImageUrl = anm_Utility.GetWebAppRoot() + "/images/Avatars/" + user.UserName + ".jpg";
            else
                ImgAvatar.ImageUrl = anm_Utility.GetWebAppRoot() + "/images/Avatars/Anonymous.jpg";
        }
        else
            FormsAuthentication.RedirectToLoginPage();
    }
    protected void ButtonEmail_Click(object sender, EventArgs e)
    {
        anm_Utility ut = new anm_Utility();
        lblEmail.Text = ut.ChangeEmail(Membership.GetUser(), TextBoxEmail.Text);
        lblEmail.Visible = true;
    }
    protected void UploadAvatar(object sender, EventArgs e)
    {
        MembershipUser user = Membership.GetUser();
        anm_Utility ut = new anm_Utility();
        if (FUAvatar.FileName != "")
        {
            string PathOrig = Server.MapPath("~\\images\\Avatars\\app_") + FUAvatar.FileName;
            FUAvatar.SaveAs(PathOrig);
            /*
            ut.GenerateImage(PathOrig, Server.MapPath("~\\images\\Avatars\\") + user.UserName + ".jpg", 0, 50, "", "", "jpeg", "White", "Arial", 0, "br");
            LTAvatarOk.Visible = true;
            if (System.IO.File.Exists(PathOrig))
                System.IO.File.Delete(PathOrig);
            Response.Redirect(Page.Request.Url.AbsolutePath.ToString() + "?p=MyProfile");
             */

            Bitmap bitmap2 = new Bitmap(PathOrig);

            decimal width = bitmap2.Width;
            decimal height = bitmap2.Height;
            decimal maxWidth = 100;
            decimal maxHeight = 50;
            decimal NewW;
            decimal NewH;

            if (width <= maxWidth)
            {
                NewW = width;
            }
            else
            {
                NewW = maxWidth;
            }

            NewH = height * NewW / width;
            if (NewH > maxHeight)
            {
                // Resize with height instead
                NewW = width * maxHeight / height;
                NewH = maxHeight;
            }

            int newwidth = Convert.ToInt32(NewW);
            int newheight = Convert.ToInt32(NewH);
            Bitmap bitmap = new Bitmap(bitmap2, new Size(newwidth, newheight));
            Graphics g = Graphics.FromImage(bitmap);
            g.SmoothingMode = SmoothingMode.AntiAlias;

            ImageFormat formato = ImageFormat.Jpeg;

            bitmap2.Dispose();
            g.Dispose();

            bitmap.Save(Server.MapPath("~\\images\\Avatars\\") + user.UserName + ".jpg", formato);
            bitmap.Dispose();

            if (System.IO.File.Exists(PathOrig))
                System.IO.File.Delete(PathOrig);
            Response.Redirect(anm_Utility.GetWebAppRoot() + "/MyProfile.aspx");
        }
        else
        {
            LTAvatarOk.Text = HttpContext.GetGlobalResourceObject("language", "RequiredField").ToString();
            LTAvatarOk.Visible = true;
        }
    }
    protected void ButtonQa_Click(object sender, EventArgs e)
    {
        try
        {
            MembershipUser mu = Membership.GetUser();
            mu.ChangePasswordQuestionAndAnswer(txtpswqa.Text, txtquestion.Text, txtanswer.Text);
            Response.Redirect("homepage.aspx");
        }
        catch (Exception ex)
        {
            lblQa.Text = ex.Message;
        }
        lblQa.Visible = true;

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        MembershipUser user = Membership.GetUser();
        if (user.UserName == "Admin")
        {
            lblalert.Text = GetGlobalResourceObject("language", "cannotdeleteadmin").ToString();
        }
        else
        {
            string strConn = ConfigurationManager.ConnectionStrings["anmcs"].ToString();
            SqlConnection myConnection = new SqlConnection(strConn);
            SqlCommand myCommand = new SqlCommand();
            myCommand.Connection = myConnection;

            myCommand.Parameters.Add(
               "@commentator", SqlDbType.NVarChar).Value = user.UserName;
            myCommand.CommandText = "UPDATE anm_Comments SET commentator='Anonymous' WHERE commentator=@commentator";
            myConnection.Open();
            object accountNumber = myCommand.ExecuteScalar();
            myConnection.Close();

            Membership.DeleteUser(user.UserName);
            FormsAuthentication.SignOut();
            FormsAuthentication.RedirectToLoginPage();
        }
    }
}
