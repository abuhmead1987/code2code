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
using DB.ClassPrint;

namespace PGFine
{
    public partial class PrintPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request["Type"]))
            {
                string ctrl = (string)Session["htmlNews"];
                ClassPrint.PrintWebControl(ctrl);
            }
            else
            {
                string ctrl = (string)Session["ctrl"];
                ClassPrint.PrintWebControl(ctrl);
            }

        }
    }
}
