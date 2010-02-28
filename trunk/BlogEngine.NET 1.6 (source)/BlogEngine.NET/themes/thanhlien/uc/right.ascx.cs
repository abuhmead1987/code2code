using System;
using System.Xml;

public partial class themes_thanhlien_uc_right : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(Server.MapPath("~/App_Data/AccountContact.xml"));

            lstContact.DataSource = xDoc.SelectNodes("//yahoo");
            lstContact.DataBind(); 
        }
    }
}
