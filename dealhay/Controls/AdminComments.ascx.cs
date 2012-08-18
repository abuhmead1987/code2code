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

public partial class Controls_AdminComments : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["idnews"] != null)
        {
            if (Request.IsAuthenticated)
            {
                CKFinder.FileBrowser _FileBrowser = new CKFinder.FileBrowser();
                _FileBrowser.BasePath = anm_Utility.GetWebAppRoot() + "/ckfinder/";
                _FileBrowser.SetupCKEditor(txtComment); 
                anm_Utility ut = new anm_Utility();
                if (Request.QueryString["idnews"] == "*")
                    Page.Title = Label1.Text = GetGlobalResourceObject("language", "AllComments") + ""; 
                else
                    Page.Title = Label1.Text = GetGlobalResourceObject("language", "Comments") + " - " + ut.GetTitleNews(Request.QueryString["idnews"].ToString()); 
                if (Request.QueryString["idc"] != null)
                {
                    string strConn = ConfigurationManager.ConnectionStrings["anmcs"].ToString();
                    SqlConnection myConnection = new SqlConnection(strConn);
                    SqlCommand myCommand = new SqlCommand();
                    myCommand.Connection = myConnection;
                    myConnection.Open();
                    myCommand.CommandText = "SELECT comment FROM anm_Comments WHERE idcomment=" + Request.QueryString["idc"];
                    SqlDataReader reader = myCommand.ExecuteReader();
                    string comment = "";
                    while (reader.Read())
                        comment = reader["comment"].ToString();
                    myConnection.Close();
                    txtComment.Text = comment;
                    txtComment.Visible = true;
                    Label2.Text = Request.QueryString["idc"].ToString();
                    UpdateComment.Visible = true;
                }
                MembershipUser user = Membership.GetUser();
                string path = Page.Request.Url.AbsolutePath.ToString();
                string role = ut.GetRole(user.UserName);
                if (role != "1" && role != "2")
                    Response.Redirect(path + "?p=Confirm&mes=" + GetGlobalResourceObject("language", "nopermission") + "");

                if (Request.QueryString["idnews"] == "*")
                    GridView1.DataSourceID = "SqlDataSource3";
                else
                    GridView1.DataSourceID = "SqlDataSource1";
            }
            else
                FormsAuthentication.RedirectToLoginPage();
        }
        else
        {
            Page.Title = Label1.Text = GetGlobalResourceObject("language", "Approve") + " " + GetGlobalResourceObject("language", "Comments");
            GridView1.DataSourceID = "SqlDataSource2";
        }
    }
    protected void Approve_Command(object sender, CommandEventArgs e)
    {
        anm_Utility ut = new anm_Utility();
        string[] commandArgs = e.CommandArgument.ToString().Split(new char[] { ',' });
        string idc = commandArgs[0];
        string idn = commandArgs[1];
        string value = commandArgs[2];
        //string approve = commandArgs[3];
        string approve = "";
        int nc = ut.GetCommentsNews(idn);

        string strConn = ConfigurationManager.ConnectionStrings["anmcs"].ToString();
        SqlConnection myConnection = new SqlConnection(strConn);
        SqlCommand myCommand = new SqlCommand();
        myCommand.Connection = myConnection;
        myConnection.Open();
        myCommand.CommandText = "SELECT approved FROM anm_Comments WHERE idcomment=" + idc;
        SqlDataReader reader = myCommand.ExecuteReader();
        while (reader.Read())
            approve = reader["approved"].ToString();
        myConnection.Close();

        ut.ApproveComment(idc, value);
        if (value == "true" && approve == "False")
            ut.IcreaseComments(idn, nc + 1);
        else if (value == "false" && approve == "True")
            ut.IcreaseComments(idn, nc - 1);
        Response.Redirect(Page.Request.Url.AbsolutePath.ToString() + "?p=AdminComments");
    }
    protected void Delete_Comment(object sender, CommandEventArgs e)
    {
        anm_Utility ut = new anm_Utility();
        string[] commandArgs = e.CommandArgument.ToString().Split(new char[] { ',' });
        string idc = commandArgs[0];
        string idn = commandArgs[1];
        string value = commandArgs[2];
        int nc = ut.GetCommentsNews(idn);

        string strConn = ConfigurationManager.ConnectionStrings["anmcs"].ToString();
        SqlConnection myConnection = new SqlConnection(strConn);
        SqlCommand myCommand = new SqlCommand();
        myCommand.Connection = myConnection;
        myConnection.Open();
        myCommand.CommandText = "DELETE FROM anm_Comments WHERE idcomment =" + idc;
        object accountNumber = myCommand.ExecuteScalar();
        myConnection.Close();

        if (value == "True")
            ut.IcreaseComments(idn, nc - 1);
        if (Request.QueryString["idnews"] != null)
            Response.Redirect(Page.Request.Url.AbsolutePath.ToString() + "?p=AdminComments&idnews=" + Request.QueryString["idnews"]);
        else
            Response.Redirect(Page.Request.Url.AbsolutePath.ToString() + "?p=AdminComments&idnews=*");
    }
    protected void Edit_Comment(object sender, CommandEventArgs e)
    {
        anm_Utility ut = new anm_Utility();
        string[] commandArgs = e.CommandArgument.ToString().Split(new char[] { ',' });
        String comment = commandArgs[0];
        string idc = commandArgs[1];

        txtComment.Text = comment;
        txtComment.Visible = true;
        Label2.Text = idc;
        UpdateComment.Visible = true;
    }
    protected void UpdateComment_Click(object sender, EventArgs e)
    {
        try
        {
            string strConn = ConfigurationManager.ConnectionStrings["anmcs"].ToString();
            SqlConnection myConnection = new SqlConnection(strConn);
            SqlCommand myCommand = new SqlCommand();
            myCommand.Connection = myConnection;

            myCommand.Parameters.Add(
               "@comment", SqlDbType.NVarChar).Value = txtComment.Text.ToString();
            myCommand.Parameters.Add(
               "@idcomment", SqlDbType.Int).Value = Convert.ToInt32(Label2.Text);
            myCommand.CommandText = "UPDATE anm_Comments SET comment=@comment WHERE idcomment=@idcomment";
            myConnection.Open();
            object accountNumber = myCommand.ExecuteScalar();
            Response.Redirect(Page.Request.Url.AbsolutePath.ToString() + "?p=AdminComments&idnews=*");
        }
        catch (Exception ex)
        {
            lblerror.Text = ex.Message;
            lblerror.Visible = true;
        }
    }
    protected string RNA(string idn)
    {
        anm_Utility ut = new anm_Utility();
        return ut.RemoveNonAlfaNumeric(ut.GetTitleNews(idn));
    }
    protected Boolean IsVisible()
    {
        MembershipUser user = Membership.GetUser();
        anm_Utility ut = new anm_Utility();
        string role = ut.GetRole(user.UserName);
        if (role == "1")
            return true;
        else
            return false;
    }
}
