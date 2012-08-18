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
using System.IO;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Drawing.Drawing2D;
using anm_utility;

public partial class Controls_Captcha : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        anm_Utility ut = new anm_Utility();
        if (ut.GetSetting("CaptchaType") != "2")
        {
            Bitmap bmp = new Bitmap(Server.MapPath("~\\images\\captcha1.jpg")); //background image
            MemoryStream memStream = new MemoryStream();

            int width = bmp.Width;
            int height = bmp.Height;
            string familyName = "Arial";
            string text = Request.Cookies["Captcha"]["value"]; //take the text from the cookie

            Bitmap bitmap = new Bitmap(bmp, new Size(width, height));
            Graphics g = Graphics.FromImage(bitmap);
            g.SmoothingMode = SmoothingMode.AntiAlias;

            int xCopyright = width - 150;
            int yCopyright = height - 50;

            Rectangle rect;
            Font font;
            int newfontsize = 45;

            font = new Font(familyName, newfontsize, FontStyle.Italic);

            rect = new Rectangle(xCopyright, yCopyright, 0, 0);

            StringFormat format = new StringFormat();
            format.Alignment = StringAlignment.Near;
            format.LineAlignment = StringAlignment.Near;
            GraphicsPath path = new GraphicsPath();
            path.AddString(text, font.FontFamily, (int)font.Style, font.Size, rect, format);

            //choose text color and effect
            HatchBrush hatchBrush = new HatchBrush(
                HatchStyle.LargeConfetti,
                Color.FromName("White"),
                Color.FromName("Black"));
            g.FillPath(hatchBrush, path);

            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.ContentType = "image/jpeg";

            bitmap.Save(memStream, ImageFormat.Jpeg);

            bmp.Dispose();
            font.Dispose();
            hatchBrush.Dispose();
            g.Dispose();

            memStream.WriteTo(HttpContext.Current.Response.OutputStream);
            bitmap.Dispose();
        }
        else
        {
            Bitmap bitmap3 = new Bitmap(Server.MapPath("~\\images\\captcha2.jpg"));
            MemoryStream memStream = new MemoryStream();

            int width = bitmap3.Width;
            int height = bitmap3.Height;
            string familyName = "Arial";
            string text = Request.Cookies["Captcha"]["value"];

            Bitmap bitmap = new Bitmap(bitmap3, new Size(width, height));
            Graphics g = Graphics.FromImage(bitmap);
            g.SmoothingMode = SmoothingMode.AntiAlias;

            int xCopyright = width - 240;
            int yCopyright = height - 95;

            Rectangle rect;
            Font font;
            int newfontsize = 75;

            font = new Font(familyName, newfontsize, FontStyle.Italic);

            rect = new Rectangle(xCopyright, yCopyright, 0, 0);

            StringFormat format = new StringFormat();
            format.Alignment = StringAlignment.Near;
            format.LineAlignment = StringAlignment.Near;
            GraphicsPath path = new GraphicsPath();
            path.AddString(text, font.FontFamily, (int)font.Style, font.Size, rect, format);
            path.AddEllipse(10, 40, 230, 35);

            HatchBrush hatchBrush = new HatchBrush(
                HatchStyle.LargeConfetti,
                Color.FromName("Grey"),
                Color.FromName("White"));
            g.FillPath(hatchBrush, path);


            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.ContentType = "image/jpeg";


            bitmap.Save(memStream, ImageFormat.Jpeg);

            bitmap3.Dispose();
            font.Dispose();
            hatchBrush.Dispose();
            g.Dispose();

            memStream.WriteTo(HttpContext.Current.Response.OutputStream);
            bitmap.Dispose();
        }
    }
}
