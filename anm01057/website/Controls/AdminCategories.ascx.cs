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

public partial class Controls_AdminCategories : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.IsAuthenticated)
            {
                Page.Title = GetGlobalResourceObject("language", "Categories") + " ";
                MembershipUser user = Membership.GetUser();
                anm_Utility ut = new anm_Utility();
                string role = ut.GetRole(user.UserName);
                if (role != "1")
                    Response.Redirect(Page.Request.Url.AbsolutePath.ToString() + "?p=Confirm&mes=" + GetGlobalResourceObject("language", "nopermission") + "");
            }
            else
                FormsAuthentication.RedirectToLoginPage();
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect(Page.Request.Url.AbsolutePath.ToString() + "?p=AddCategory");
    }
    protected void GridView1_RowDeleted(object sender, GridViewDeletedEventArgs e)
    {
        if (e.Exception != null)
        {
            Label1.Visible = true;
            e.ExceptionHandled = true;
            Label1.Text = GetGlobalResourceObject("language", "cannotdeletecat").ToString();
        }
        else
            Label1.Visible = false;
    }
    protected void ChangeFather(object sender, CommandEventArgs e)
    {
        anm_Utility ut = new anm_Utility();
        string[] commandArgs = e.CommandArgument.ToString().Split(new char[] { ',' });
        String idcategory = commandArgs[0];
        string idfather = commandArgs[1];
        lblcfc.Visible = DdlFatherCat.Visible = BtnFatherCat.Visible = true;
        lblidc.Text = idcategory;
        Label1.Visible = false;
    }
    protected void SetUpMain(object sender, CommandEventArgs e)
    {
        anm_Utility ut = new anm_Utility();
        string[] commandArgs = e.CommandArgument.ToString().Split(new char[] { ',' });
        String idcategory = commandArgs[0];
        string idfather = commandArgs[1];
        if (idfather == "0")
        {
            Label1.Text = GetGlobalResourceObject("language", "yetMainCat").ToString();
            Label1.Visible = true;
        }
        else
        {
            try
            {
                string strConn = ConfigurationManager.ConnectionStrings["anmcs"].ToString();
                SqlConnection myConnection = new SqlConnection(strConn);
                SqlCommand myCommand = new SqlCommand();
                myCommand.Connection = myConnection;
                myConnection.Open();

                myCommand.Parameters.Add("@idcategory", SqlDbType.Int).Value = idcategory;
                myCommand.CommandText = "UPDATE anm_Categories SET idfather = 0, idrootcat = @idcategory WHERE idcategory = @idcategory";
                myCommand.ExecuteScalar();

                myConnection.Close();
                GridView1.DataBind();
                Label1.Text = GetGlobalResourceObject("language", "CategoryUpdated").ToString();
                Label1.Visible = true;
            }
            catch (Exception ex)
            {
                Label1.Text = ex.Message;
                Label1.Visible = true;
            }
        }
    }
    protected void BtnFatherCat_Click(object sender, EventArgs e)
    {
        try
        {
            string idf = DdlFatherCat.SelectedValue;
            string strConn = ConfigurationManager.ConnectionStrings["anmcs"].ToString();
            SqlConnection myConnection = new SqlConnection(strConn);
            SqlCommand myCommand = new SqlCommand("anm_getCategoriesById", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.Parameters.Add("@idcategory", SqlDbType.Int).Value = DdlFatherCat.SelectedValue;
            myConnection.Open();
            SqlDataReader reader = myCommand.ExecuteReader();

            string idrootcat = "";
            while (reader.Read())
            {
                if (reader["idrootcat"].ToString() == "0" || reader["idrootcat"].ToString() == "" || reader["idrootcat"].ToString() == null)
                    idrootcat = DdlFatherCat.SelectedValue;
                else
                    idrootcat = reader["idrootcat"].ToString();
            }
            myConnection.Close();
            string idc = lblidc.Text;
            if (idf != idc)
            {
                anm_Utility ut = new anm_Utility();
                string father = ut.GetIdFather(idf);
                if (father != idc)
                {
                    SqlConnection myConnection2 = new SqlConnection(strConn);
                    SqlCommand myCommand2 = new SqlCommand();
                    myCommand2.Connection = myConnection2;
                    myConnection2.Open();

                    myCommand2.Parameters.Add("@idfather", SqlDbType.Int).Value = Convert.ToInt32(idf);
                    myCommand2.Parameters.Add("@idcategory", SqlDbType.Int).Value = Convert.ToInt32(idc);
                    myCommand2.Parameters.Add("@idrootcat", SqlDbType.NVarChar).Value = idrootcat;
                    myCommand2.CommandText = "UPDATE anm_Categories SET idfather = @idfather, idrootcat = @idrootcat WHERE idcategory = @idcategory";
                    myCommand2.ExecuteScalar();

                    myConnection2.Close();
                    GridView1.DataBind();
                    Label1.Text = GetGlobalResourceObject("language", "CategoryUpdated").ToString();
                    Label1.Visible = true;
                    lblcfc.Visible = DdlFatherCat.Visible = BtnFatherCat.Visible = false;
                }
                else
                {
                    Label1.Text = GetGlobalResourceObject("language", "chooseanothercat").ToString();
                    Label1.Visible = true;
                }
            }
            else
            {
                Label1.Text = GetGlobalResourceObject("language", "cannotchoosesamecat").ToString();
                Label1.Visible = true;
            }
        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
            Label1.Visible = true;
        }
    }
    protected string FatherCat(string idcat)
    {
        anm_Utility ut = new anm_Utility();
        if (idcat == "0")
            return "-";
        else
            return ut.GetCategory(idcat);
    }
}
