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

public partial class Controls_AdminLayout : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.IsAuthenticated)
            {
                Page.Title = "Layout";
                MembershipUser user = Membership.GetUser();
                anm_Utility ut = new anm_Utility();
                string role = ut.GetRole(user.UserName);
                if (role != "1")
                    Response.Redirect(Page.Request.Url.AbsolutePath.ToString() + "?p=Confirm&mes=" + GetGlobalResourceObject("language", "nopermission") + "");
                txtBGC.Text = ut.GetSetting("BGcolor");
                txtHBGC.Text = ut.GetSetting("HBGcolor");
                string width = ut.GetSetting("Width");
                if (width.Contains("%"))
                {
                    txtValue.Text = txtWidth.Text = width;
                    txtWidth2.Visible = false;
                    txtValue2.Visible = false;
                    Label3.Visible = false;
                    CheckBox7.Checked = true;
                }
                else
                {
                    txtValue2.Text = txtWidth2.Text = width;
                    txtValue.Visible = false;
                    txtWidth.Visible = false;
                    Label2.Visible = false;
                    CheckBox8.Checked = true;
                }
                if (ut.GetSetting("ArtImageWidth") != "")
                    txtValue3.Text = txtWidth3.Text = ut.GetSetting("ArtImageWidth");
                else
                    txtValue3.Text = txtWidth3.Text = "200";
                template.SelectedValue = ut.GetSetting("Template");
            }
            else
                FormsAuthentication.RedirectToLoginPage();
        }
    }
    protected void UpdateSettings_Click(object sender, EventArgs e)
    {
        anm_Utility dt = new anm_Utility();
        try
        {

            string strConn = ConfigurationManager.ConnectionStrings["anmcs"].ToString();
            SqlConnection myConnection = new SqlConnection(strConn);
            SqlCommand command = new SqlCommand();
            command.Connection = myConnection;
            command.Parameters.Add("@Template", SqlDbType.VarChar).Value = template.SelectedValue.ToString();
            HttpContext.Current.Cache.Remove("TemplateName");
            Cache.Insert("Template", template.SelectedValue.ToString(), null, DateTime.Now.AddMonths(6), TimeSpan.Zero, System.Web.Caching.CacheItemPriority.High, null);
            command.Parameters.Add("@BGColor", SqlDbType.NVarChar).Value = txtBGC.Text.ToString();
            Cache.Insert("BGColor", txtBGC.Text.ToString(), null, DateTime.Now.AddMonths(6), TimeSpan.Zero, System.Web.Caching.CacheItemPriority.High, null);
            command.Parameters.Add("@HBGColor", SqlDbType.NVarChar).Value = txtHBGC.Text.ToString();
            Cache.Insert("HBGColor", txtHBGC.Text.ToString(), null, DateTime.Now.AddMonths(6), TimeSpan.Zero, System.Web.Caching.CacheItemPriority.High, null);
            if (CheckBox7.Checked)
            {
                command.Parameters.Add("@Width", SqlDbType.NVarChar).Value = txtWidth.Text.ToString() + "%";
                Cache.Insert("Width", txtWidth.Text.ToString() + "%", null, DateTime.Now.AddMonths(6), TimeSpan.Zero, System.Web.Caching.CacheItemPriority.High, null);
            }
            if (CheckBox8.Checked)
            {
                command.Parameters.Add("@Width", SqlDbType.NVarChar).Value = txtWidth2.Text.ToString() + "px";
                Cache.Insert("Width", txtWidth2.Text.ToString() + "px", null, DateTime.Now.AddMonths(6), TimeSpan.Zero, System.Web.Caching.CacheItemPriority.High, null);
            }
            command.Parameters.Add("@ArtImageWidth", SqlDbType.Int).Value = Convert.ToInt32(txtWidth3.Text);
            Cache.Insert("ArtImageWidth", txtWidth3.Text.ToString(), null, DateTime.Now.AddMonths(6), TimeSpan.Zero, System.Web.Caching.CacheItemPriority.High, null);

            command.CommandText = "UPDATE anm_Settings SET Template=@Template,BGColor=@BGColor,HBGColor=@HBGColor,Width=@Width,ArtImageWidth=@ArtImageWidth WHERE id=1";
            myConnection.Open();
            object accountNumber = command.ExecuteScalar();
            myConnection.Close();
            Response.Redirect("homepage.aspx");
        }
        catch (Exception ex)
        {
            lblerror.Text = ex.Message;
            lblerror.Visible = true;
        }
    }
    protected void CheckBox7_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox8.Checked = false;
        txtWidth2.Visible = false;
        txtValue2.Visible = false;
        Label3.Visible = false;
        txtWidth.Visible = true;
        Label2.Visible = true;
        txtValue.Visible = true;
    }
    protected void CheckBox8_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox7.Checked = false;
        txtValue.Visible = false;
        txtValue2.Visible = true;
        txtWidth.Visible = false;
        Label2.Visible = false;
        Label3.Visible = true;
        txtWidth2.Visible = true;
    }
}
