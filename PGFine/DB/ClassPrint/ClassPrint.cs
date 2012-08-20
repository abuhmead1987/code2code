using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.IO;
using System.Text;
using System.Threading;

namespace DB.ClassPrint
{
    public class ClassPrint
    {
        public ClassPrint()
        {
        }

        public static void PrintWebControl(string ctrl)
        {
            PrintWebControl(ctrl, string.Empty);
        }

        public static void PrintWebControl(string strhtml, string Script)
        {          
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("<html xmlns=\"http://www.w3.org/1999/xhtml\" >");
            stringBuilder.Append("<head >");
            stringBuilder.Append(" <title>Print Page</title>");
            stringBuilder.Append("   <link href=\"../Tshirt/Css/UserCss.css\" rel=\"stylesheet\" type=\"text/css\" />");
            stringBuilder.Append("</head>");
            stringBuilder.Append("<body>");
            stringBuilder.Append("  <form id=\"form1\">");
            stringBuilder.Append("   <div>");
            stringBuilder.Append(strhtml);
            stringBuilder.Append("  </div>");
            stringBuilder.Append("   </form>");
            stringBuilder.Append("</body>");
            stringBuilder.Append("</html>");

            string strHTML = stringBuilder.ToString();
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.Write(strHTML);
            HttpContext.Current.Response.Write("<script>window.print();</script>");
            HttpContext.Current.Response.End();
        }

        public static string RenderHTMLControl(Control control)
        {
            StringBuilder stringBuilder = new StringBuilder();
            StringWriter stringWriter = new StringWriter(stringBuilder, Thread.CurrentThread.CurrentUICulture);
            HtmlTextWriter htmlTextWriter = new HtmlTextWriter(stringWriter);
            control.RenderControl(htmlTextWriter);

            return stringBuilder.ToString();
        }        

    }
}
