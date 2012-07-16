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
using System.Data.SqlClient;
using anm_utility;
using System.IO;
using System.Text.RegularExpressions;

public partial class Controls_AddArticle : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.IsAuthenticated)
            {
                CKFinder.FileBrowser _FileBrowser = new CKFinder.FileBrowser();
                _FileBrowser.BasePath = anm_Utility.GetWebAppRoot() + "/ckfinder/";
                _FileBrowser.SetupCKEditor(txtSummary);
                _FileBrowser.SetupCKEditor(txtNews); 
                Page.Title = GetGlobalResourceObject("language", "Add") + " " + GetGlobalResourceObject("language", "Article");
                MembershipUser user = Membership.GetUser();
                anm_Utility ut = new anm_Utility();
                string role = ut.GetRole(user.UserName);
                if (role != "1" && role!="2")
                        Response.Redirect(Page.Request.Url.AbsolutePath.ToString() + "?p=Confirm&mes=" + GetGlobalResourceObject("language", "nopermission") + "");
                HLAddCategory.NavigateUrl = Page.Request.Url.AbsolutePath.ToString() + "?p=AddCategory";
                DDimages.Items.Add("Choose the image from the server:");
                var files = Directory.GetFiles(Server.MapPath("~/images/")).Select(o => new FileInfo(o).Name);
                var orderedFiles = files.OrderBy(f => f);
                foreach (var item in orderedFiles)
                {
                    if (item.Substring(0, 5) == "full_")
                        DDimages.Items.Add(item.Substring(5, item.Length - 5));
                }                
                if (Request.QueryString["idnews"] != null)
                {
                    string strConn = ConfigurationManager.ConnectionStrings["anmcs"].ToString();
                    SqlConnection conn = new SqlConnection(strConn);
                    SqlCommand command = new SqlCommand("anm_getNewsById", conn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@idnews", SqlDbType.Int).Value = Request.QueryString["idnews"];
                    conn.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        txtTitle.Text = reader["title"].ToString().Replace("&amp;", "&");
                        string imgfilename = reader["image"].ToString();
                        if (imgfilename != "")
                        {
                            ddimg.Visible = true;
                            DDimages.SelectedValue = reader["image"].ToString();
                            ddimg.ImageUrl = "~/images/" + reader["image"].ToString();
                        }
                        ddlcategory.SelectedValue = reader["idcategory"].ToString();
                        chkComments.Checked = Convert.ToBoolean(reader["commentcheck"]);
                        chkHL.Checked = Convert.ToBoolean(reader["highlight"]);
                        chkSN.Checked = Convert.ToBoolean(reader["sidenews"]);
                        chkPB.Checked = Convert.ToBoolean(reader["postedby"]);
                        try { chkSS.Checked = Convert.ToBoolean(reader["homeslide"]); }
                        catch { }
                        txtSummary.Text = reader["summary"].ToString();
                        txtNews.Text = reader["news"].ToString();
                        txtTags.Text = reader["tags"].ToString().Replace("&amp;", "&");
                    }
                    conn.Close();
                }
            }
            else
                FormsAuthentication.RedirectToLoginPage();
        }

    }
    protected void NewArticle(object sender, EventArgs e)
    {
        if (txtNews.Text.ToString() == "")
        {
            Label1.Text = Label2.Text = GetGlobalResourceObject("language", "InsertArticle").ToString();
            Label1.Visible = Label2.Visible = true;
        }
        else if (ddlcategory.Text == "Select a category:")
        {
            lblCategoryerr.Visible = true;
            Label1.Visible = false;
        }
        else
        {
            anm_Utility ut = new anm_Utility();
            MembershipUser currentUser = Membership.GetUser();
            Boolean approve;
            try { approve = Convert.ToBoolean(ut.GetSetting("ApproveArticles")); }
            catch { approve = true; }
            string filename = FileUpload1.FileName;
            if (DDimages.Text != "Choose the image from the server:")
                filename = DDimages.Text;
            else if (filename != "")
            {
                string tempfileName = "";
                string savePath = Server.MapPath("~\\images\\");
                string pathToCheck = savePath + filename;
                if (System.IO.File.Exists(pathToCheck))
                {
                    int counter = 2;
                    while (System.IO.File.Exists(pathToCheck))
                    {
                        tempfileName = counter.ToString() + filename;
                        pathToCheck = savePath + tempfileName;
                        counter++;
                    }
                    filename = tempfileName;
                }
                FileUpload1.SaveAs(Server.MapPath("~\\images\\app_") + filename);
                string copyright = "";
                try
                {
                    if (Convert.ToBoolean(ut.GetSetting("Copyright")))
                        copyright = ut.GetSetting("SiteName");
                }
                catch
                {
                    copyright = "";
                }
                int width = 0;
                try
                {
                    width = Convert.ToInt32(ut.GetSetting("ArtImageWidth"));
                }
                catch
                {
                    width = 200;
                }
                ut.GenerateImage(Server.MapPath("~\\images\\app_") + filename, Server.MapPath("~\\images\\full_") + filename, 0, 0, copyright, "", "jpeg", "White", "Arial", 0, "bl");
                ut.GenerateImage(Server.MapPath("~\\images\\full_") + filename, Server.MapPath("~\\images\\") + filename, width, 0, "", "", "jpeg", "White", "Arial", 0, "bl");
                File.Delete(Server.MapPath("~\\images\\app_") + filename);
            }
            string title = txtTitle.Text;
            title = title.Replace("&", "&amp;");
            string tags = txtTags.Text;
            tags = tags.Replace("&", "&amp;");
            tags = tags.Replace(", ", ",");
            while (tags.Contains(".,"))
            {
                tags = tags.Replace(".,", ",");
            }
            tags = tags.TrimEnd(',');
            tags = tags.TrimEnd('.');
            ut.AddArticle(title.ToString(), currentUser.UserName.ToString(), filename, txtSummary.Text.ToString().Replace("&", "&amp;"), txtNews.Text.ToString().Replace("&", "&amp;"), ddlcategory.SelectedValue.ToString(), chkComments.Checked, !approve, chkHL.Checked, chkSN.Checked, chkPB.Checked, tags, chkSS.Checked);
            if (approve)
                Response.Redirect(Page.Request.Url.AbsolutePath.ToString() + "?p=ApproveArticles");
            else
                Response.Redirect("homepage.aspx");
        }
    }
    protected void DDimages_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DDimages.Text == "Choose the image from the server:")
        {
            ddimg.ImageUrl = "";
            ddimg.Visible = false;
        }
        else
        {
            ddimg.ImageUrl = "~/images/" + DDimages.Text;
            ddimg.Visible = true;
        }
    }
}
