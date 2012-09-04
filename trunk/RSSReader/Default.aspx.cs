using System;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Xml;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        using (XmlReader reader = XmlReader.Create("http://www.24h.com.vn/upload/rss/tintuctrongngay.rss"))
        {
            Rss20FeedFormatter formater = new Rss20FeedFormatter();
            formater.ReadFrom(reader);
            string strCopyright = formater.Feed.Copyright.Text;

            var news = from n in formater.Feed.Items.Take(5)
                       select new News
                       {
                           Id = n.Id,
                           Text = n.Title.Text,
                           Summary = n.Summary.Text,
                           PublishDate = n.PublishDate.ToString(),
                           CopyRight = strCopyright
                       };

            DataList1.DataSource = news;
            DataList1.DataBind();

        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        //loop all checked items
        for (int i = 0; i < DataList1.Items.Count; i++)
        {
            CheckBox chkCtrl = (CheckBox)DataList1.Items[i].FindControl("chkCheck");
            if (chkCtrl != null)
            {
                if (chkCtrl.Checked)
                {
                    HyperLink link = (HyperLink)DataList1.Items[i].FindControl("id");
                }
            }
        }
        //
    }
}
public class News
{
    public string Id { get; set; }
    public string Text { get; set; }
    public string Summary { get; set; }
    public string PublishDate { get; set; }
    public string CopyRight { get; set; }
}