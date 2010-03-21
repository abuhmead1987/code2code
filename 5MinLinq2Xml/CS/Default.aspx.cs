using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public partial class _Default : System.Web.UI.Page 
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadContacts();
        }
    }

    public void LoadContacts()
    {
        string filePath = Server.MapPath("~/App_Data/contact.xml");
        XElement Contacts = XElement.Load(filePath);
        if (Contacts != null)
        {
            var query = from c in Contacts.Elements("contact")
                        select new
                        {
                            Id = (string)c.Attribute("id").Value,
                            Name = c.Attribute("name").Value,
                            Email = c.Attribute("email").Value
                        };
            grdContact.DataSource = query.ToList();
            grdContact.DataBind();
        }
    }

    protected void grdContact_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
    {
        string FilePath = Server.MapPath("~/App_Data/contact.xml");
        string contactId = (string)grdContact.DataKeys[e.RowIndex].Value;
        XElement element = XElement.Load(FilePath);
        var query = (from c in element.Descendants("contact")
                    where c.Attribute("id").Value == contactId
                    select c).Single();
        if (query != null)
        {
            query.Remove();
            element.Save(FilePath);
        }
        LoadContacts();
    }
    protected void grdContact_RowCancelingEdit(object sender, System.Web.UI.WebControls.GridViewCancelEditEventArgs e)
    {
        grdContact.EditIndex = -1;
        LoadContacts();
    }
    protected void grdContact_RowUpdating(object sender, System.Web.UI.WebControls.GridViewUpdateEventArgs e)
    {
        string contactId = (string)grdContact.DataKeys[e.RowIndex].Value;
        string FilePath = Server.MapPath("~/App_Data/contact.xml");

        string name = (grdContact.Rows[e.RowIndex].FindControl("txtName") as TextBox).Text.Trim();
        string email = (grdContact.Rows[e.RowIndex].FindControl("txtEmail") as TextBox).Text.Trim();

        XDocument doc = XDocument.Load(FilePath);
        IEnumerable<XElement> contacts = doc.Element("contacts").Elements("contact");
        var contact = (from c in contacts
                       where c.Attribute("id").Value.Equals(contactId) == true
                       select c).SingleOrDefault();
        contact.SetAttributeValue("name", name);
        contact.SetAttributeValue("email", email);
        doc.Save(FilePath);
        LoadContacts();
    }
    protected void grdContact_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
    {
        grdContact.EditIndex = e.NewEditIndex;
        LoadContacts();
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        string name = txtUserName.Text.Trim();
        string email = txtEmailAdress.Text.Trim();
        string FilePath = Server.MapPath("~/App_Data/contact.xml");
        XDocument doc = XDocument.Load(FilePath);
        IEnumerable<XElement> contacts = doc.Element("contacts").Elements("contact");
        var contact = new XElement("contact",
            new XAttribute("id", Guid.NewGuid().ToString().Replace("-","")),
            new XAttribute("name", name),
            new XAttribute("email",email));
        contacts.Last().AddAfterSelf(contact);
        doc.Save(FilePath);
        LoadContacts();
        txtUserName.Text = txtEmailAdress.Text = "";
    }
}
