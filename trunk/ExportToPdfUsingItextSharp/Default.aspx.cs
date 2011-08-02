using System;
using System.IO;
using System.Web;
using PDFBuilder;
using iTextSharp.text;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnExportPdf_Click(object sender, EventArgs e)
    {
        string path = Server.MapPath("~/PDF/");
        string filename = DateTime.Now.Ticks.ToString() + ".pdf";

        HtmlToPdfBuilder builder = new HtmlToPdfBuilder(PageSize.LETTER);
        HtmlPdfPage first = builder.AddPage();
        first.AppendHtml(content.InnerText);
        byte[] file = builder.RenderPdf();
        filename = DateTime.Now.Ticks.ToString() + ".pdf";
        File.WriteAllBytes(path + filename + ".pdf", file);

        //
        HttpContext.Current.Response.Buffer = true;
        HttpContext.Current.Response.ClearContent();
        HttpContext.Current.Response.ClearHeaders();
        HttpContext.Current.Response.ContentType = "application//pdf";
        HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment;filename=" + filename);
        HttpContext.Current.Response.BinaryWrite(file);
        HttpContext.Current.Response.End();
    }
}