using System;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    public void ServerCheckGender(object sender, ServerValidateEventArgs args)
    {
        args.IsValid = male.Checked ? true : female.Checked ? true : false;
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            Response.Write(male.Checked ? "Male" : female.Checked ? "Female" : "You have no chooice");
        }
    }
}