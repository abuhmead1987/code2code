using System;
using System.Xml;

public partial class themes_thanhlien_uc_right : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        XmlDocument xDoc = new XmlDocument();
        xDoc.Load(Server.MapPath("~/App_Data/AccountContact.xml"));

        lstContact.DataSource = xDoc.SelectNodes("//yahoo");
        lstContact.DataBind();

        //foreach (XmlNode item in xDoc.SelectNodes("//yahoo"))
        //{
        //    string name = item.Attributes.GetNamedItem("name").Value.ToString();
        //    string id = item.Attributes.GetNamedItem("id").Value.ToString();
        //}
    }
}
