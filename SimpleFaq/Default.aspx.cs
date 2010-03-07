using System;
using System.Collections.Generic;
using System.Xml.Linq;

public partial class _Default : System.Web.UI.Page 
{
    public IEnumerable<XElement> faqsElement;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            XElement element = XElement.Load(Server.MapPath("~/App_Data/Faq.xml"));
            faqsElement = element.Elements("faq"); 
        }
    }
}
