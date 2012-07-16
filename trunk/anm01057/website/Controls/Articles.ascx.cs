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
using System.Data.SqlClient;
using System.Net;
using System.Text.RegularExpressions;
using anm_utility;

public partial class Controls_Articles : System.Web.UI.UserControl
{
    int currentIDC = 1;
    int currentpage = 0;
    string apath = anm_Utility.GetWebAppRoot();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            anm_Utility ut = new anm_Utility();
            string idn = HttpContext.Current.Request.QueryString["news"];
            string titlenews = ut.GetTitleNews(idn);
            Page.Title = titlenews + " - " + ut.GetSetting("SiteName");
            if (Request.QueryString["page"] != null)
            {
                currentpage = Convert.ToInt32(HttpContext.Current.Request.QueryString["page"].ToString());
            }
            if (Request.QueryString["comment"] != null)
            {
                string idc = Request.QueryString["comment"];
                int rownumber = 0;
                try
                {
                    idn = ut.GetIdNewsByComment(Request.QueryString["comment"]);
                    string strConn = ConfigurationManager.ConnectionStrings["anmcs"].ToString();
                    SqlConnection myConnection = new SqlConnection(strConn);
                    SqlCommand myCommand2 = new SqlCommand();
                    myCommand2.Connection = myConnection;
                    myConnection.Open();
                    myCommand2.CommandText = "SELECT RowNumber FROM (SELECT idcomment, ROW_NUMBER() OVER(ORDER BY idcomment DESC) AS RowNumber FROM [anm_Comments] WHERE [idnews] = " + idn + " and [approved] = 'true') AS NewsWithRowNumbers WHERE idcomment = " + idc + "";
                    SqlDataReader reader2 = myCommand2.ExecuteReader();
                    if (reader2.Read())
                    {
                        rownumber = Convert.ToInt32(reader2["RowNumber"].ToString());
                    }
                    myConnection.Close();
                }
                catch
                {
                    Response.Redirect(apath + "/homepage.aspx");
                }
                int maxRows = 15;
                if (ut.GetSetting("NumComments") != "")
                    maxRows = Convert.ToInt32(ut.GetSetting("NumComments"));
                int page = (rownumber / maxRows) + 1;
                if (rownumber % maxRows == 0)
                    page = page - 1;
                titlenews = ut.GetTitleNews(idn);
                currentpage = page;
                Page.Title = titlenews + " - " + GetGlobalResourceObject("language", "Comment").ToString() + " " + idc + " - " + ut.GetSetting("SiteName");
            }

            SqlDataSource2.SelectParameters["idnews"].DefaultValue = idn;
            SqlDataSource1.SelectParameters["idnews"].DefaultValue = idn;

            string path = Page.Request.Url.AbsolutePath.ToString();
            string idnews = idn;
            HLrssComments.NavigateUrl = HLsubscribeCom.NavigateUrl = apath + "/subscribecomments/" + idnews + ".aspx";
            HLsubscribeCom.Text = GetGlobalResourceObject("language", "Subscribe").ToString() + " " + GetGlobalResourceObject("language", "Comments").ToString();
            if (Request.QueryString["err"] == "1")
            {
                lblerror.Visible = true;
                lblerror.Text = GetGlobalResourceObject("language", "insertcomment").ToString();
                errorcaptcha.Visible = false;
                Panelcomm.Visible = false;
            }
            if (Request.QueryString["err"] == "4")
            {
                lblerror.Visible = true;
                lblerror.Text = GetGlobalResourceObject("language", "commentlength").ToString();
                errorcaptcha.Visible = false;
                Panelcomm.Visible = false;
            }
            if (Request.QueryString["err"] == "3")
            {
                errorcaptcha.Visible = true;
                lblerror.Visible = false;
                Panelcomm.Visible = false;
            }
            if (Request.QueryString["err"] == "5")
            {
                Panelcomm.Visible = true;
                lblerror.Visible = false;
                errorcaptcha.Visible = false;
            }
            if (Request.IsAuthenticated)
            {
                MembershipUser user = Membership.GetUser();
                string role = ut.GetRole(user.UserName);
                if (role == "1" || role == "2")
                {
                    HLAdminComm.Text = "| [ADMIN] " + GetGlobalResourceObject("language", "ManageComments") + " |";
                    HLAdminComm.NavigateUrl = path + "?p=AdminComments&idnews=" + idnews;
                }
                Panelcomm.Visible = false;
            }
            else if (ut.GetSetting("Anonymous") == "False")
            {
                HyperLink4.NavigateUrl = apath + "/default.aspx?p=NewUser";
                HyperLink5.NavigateUrl = apath + "/default.aspx?p=Login";
                Panelcomm.Visible = true;
                btnSendC.Visible = false;
            }
            imgRssIcon.ImageUrl = apath + "/images/rssicon.gif";

            int maximumRows = 15;
            int numarticles = 0;
            numarticles = ut.GetNumberComments(idn);
            if (ut.GetSetting("NumComments") != "")
                maximumRows = Convert.ToInt32(ut.GetSetting("NumComments"));
            int maxpage = (numarticles / maximumRows) + 1;
            if (numarticles % maximumRows == 0)
                maxpage = numarticles / maximumRows;

            string linknav = "<div class='linkpage'>";
            if (currentpage != 0)
            {
                int page = currentpage;
                SqlDataSource2.SelectParameters["startRowIndex"].DefaultValue = (maximumRows * (page - 1)).ToString();
                if (numarticles > maximumRows)
                {
                    for (int i = (page - 5); i < (page + 10); i++)
                    {
                        if (i >= 1 && i <= (maxpage))
                        {
                            if (page == i)
                                linknav += "<a href='" + apath + "/page" + i + "/comments/articles/" + idn + "/" + ut.RemoveNonAlfaNumeric(titlenews) + ".aspx#comments' class='pagenavselected'>" + i + "</a> ";
                            else
                                linknav += "<a href='" + apath + "/page" + i + "/comments/articles/" + idn + "/" + ut.RemoveNonAlfaNumeric(titlenews) + ".aspx#comments' class='pagenav'>" + i + "</a> ";
                        }
                    }
                }
            }
            else
            {
                currentpage = 1;
                SqlDataSource2.SelectParameters["startRowIndex"].DefaultValue = "0";
                for (int i = 1; i < 11; i++)
                {
                    if (i == 1)
                        linknav += "<a href='" + apath + "/page" + i + "/comments/articles/" + idn + "/" + ut.RemoveNonAlfaNumeric(titlenews) + ".aspx#comments' class='pagenavselected'>" + i + "</a> ";
                    if (i > 1 && i <= maxpage)
                        linknav += "<a href='" + apath + "/page" + i + "/comments/articles/" + idn + "/" + ut.RemoveNonAlfaNumeric(titlenews) + ".aspx#comments' class='pagenav'>" + i + "</a> ";
                }
            }
            if (linknav != "<div class='linkpage'>")
                linknav += "- " + GetGlobalResourceObject("language", "Page") + " " + currentpage + " " + GetGlobalResourceObject("language", "Of") + " " + maxpage + "</div>";
            else
                linknav = "";
            LTpagelink.Text = linknav;
            if (maxpage == 1)
                LTpagelink.Visible = false;
            SqlDataSource2.SelectParameters["maximumRows"].DefaultValue = maximumRows.ToString();
            if ((ut.GetSetting("CaptchaComments") == "True" && ut.GetSetting("Anonymous") == "False" && Request.IsAuthenticated) || (ut.GetSetting("CaptchaComments") == "True" && ut.GetSetting("Anonymous") == "True") || (ut.GetSetting("CaptchaComments") == "True" && ut.GetSetting("Anonymous") == null))
            {
                string text = (Guid.NewGuid().ToString()).Substring(0, 5);
                Response.Cookies["Captcha"]["value"] = text;
                imgcaptcha.ImageUrl = path + "?p=captcha";
                UpdatePanel1.Visible = lblcaptcha.Visible = txtcaptcha.Visible = true;
            }
        }
    }
    protected string NoComments()
    {
        LTpagelink.Visible = HLAdminComm.Visible = HLleaveComment.Visible = false;
        return "";
    }
    protected bool ViewImage(string img)
    {
        /*
        if (img != "")
        {
            anm_Utility ut = new anm_Utility();
            HtmlMeta meta = new HtmlMeta();
            meta.Attributes.Add("property", "og:image");
            string url = ut.GetSetting("SiteUrl") + "/images/" + img;
            meta.Content = url.Replace("//images/","/images/");
            Page.Header.Controls.Add(meta);
        }
         */
        return (img != "");
    }
    protected string GetCommentUrl(string idcomment)
    {
        anm_Utility ut = new anm_Utility();
        return apath + "/comment/" + idcomment + ".aspx#comment" + idcomment;
    }
    protected string ShowImage(string img)
    {
        if (ViewImage(img))
            return "<img src='" + apath + "/images/" + img + "' alt='" + GetGlobalResourceObject("language", "fullsize") + "' class='right imageanm' width='" + SetImageWidth() + "px' />";
        else
            return "";
    }
    protected string Comments(string idn, string c, string idc, string title)
    {
        string res = "";
        if (c == "True")
        {
            string path = Page.Request.Url.AbsolutePath.ToString();
            anm_Utility ut = new anm_Utility();
            string titlenews = ut.GetTitleNews(idn);
            res = "<a href='" + apath + "/articles/" + idn + "/" + ut.RemoveNonAlfaNumeric(title) + ".aspx#comments' class='imgcomment' rel='nofollow'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</a><a href='" + apath + "/articles/" + idn + "/" + ut.RemoveNonAlfaNumeric(title) + ".aspx#comments' class='comments'>" + GetGlobalResourceObject("language", "Comments") + " (" + idc + ")</a>";
            PnlSendComment.Visible = PnlComments.Visible = true;
            /*
            if (ut.GetSetting("NumComments") != "")
            {
                int originalNumComments = Convert.ToInt32(ut.GetSetting("NumComments"));
                int numComments = originalNumComments;
                GridView2.PageSize = numComments;
                if (Request.QueryString["idcom"] != null)
                {
                        bool commentNotFound = true;
                        while (commentNotFound)
                        {                        
                            string strConn = ConfigurationManager.ConnectionStrings["anmcs"].ToString();
                            SqlConnection myConnection = new SqlConnection(strConn);
                            SqlCommand myCommand = new SqlCommand();
                            myCommand.Connection = myConnection;
                            myConnection.Open();
                            myCommand.CommandText = "SELECT TOP " + numComments + " idcomment FROM anm_Comments WHERE idnews=" + idn + " and approved='true' ORDER BY idcomment desc";
                            SqlDataReader reader = myCommand.ExecuteReader();
                            numComments +=  originalNumComments;
                            while (reader.Read())
                            {
                                string idcomm = reader["idcomment"].ToString();
                                if (idcomm == Request.QueryString["idcom"].ToString())
                                {
                                    commentNotFound = false;
                                    numComments = numComments - originalNumComments;
                                }
                            }                         
                            myConnection.Close();
                        }
                        GridView2.PageSize = numComments;
                }
            }
            else
                GridView2.PageSize = 20;
             */
            try { PanelBBcode.Visible = Convert.ToBoolean(ut.GetSetting("BBcode")); }
            catch { PanelBBcode.Visible = false; }

            lblchrleft.Text = GetGlobalResourceObject("language", "charactersleft").ToString();
            HtmlLink myrss = new HtmlLink();
            myrss.Href = apath + "/subscribecomments/" + idn + ".aspx";
            myrss.Attributes.Add("type", "application/rss+xml");
            myrss.Attributes.Add("rel", "alternate");
            myrss.Attributes.Add("title", titlenews + " - Comments RSS" + " - " + ut.GetSetting("SiteName"));
            Page.Header.Controls.Add(myrss);
        }
        return res;
    }
    protected string Category(string idcat, string date)
    {
        anm_Utility ut = new anm_Utility();
        HtmlLink myrss = new HtmlLink();
        string category = ut.GetCategory(idcat);
        string res = "";
        //myrss.Href = path + "?p=Rss&amp;cat=" + idcat;
        myrss.Href = "subscribe/" + idcat + ".aspx";
        myrss.Attributes.Add("type", "application/rss+xml");
        myrss.Attributes.Add("rel", "alternate");
        myrss.Attributes.Add("title", category + " RSS" + " - " + ut.GetSetting("SiteName"));
        Page.Header.Controls.Add(myrss);
        res = "<strong><a href='" + apath + "/category" + idcat + ".aspx'>" + category + "</a></strong>";
        DateTime d = Convert.ToDateTime(date);
        HLContentArchive.NavigateUrl = apath + "/archive/month_" + d.Month + "/year_" + d.Year + "/category" + idcat + ".aspx";
        return res;
    }
    protected string GetAvatar(string username)
    {
        string pathToCheck = Server.MapPath("~\\images\\Avatars\\") + username + ".jpg";
        if (System.IO.File.Exists(pathToCheck))
            return apath + "/images/Avatars/" + username + ".jpg";
        else
            return apath + "/images/Avatars/Anonymous.jpg";
    }
    protected string EncodeStr(string text)
    {
        return Server.HtmlEncode(text);
    }
    protected string SetRelatedContent(string idc, string title, string idn)
    {
        string res = "<h3>" + GetGlobalResourceObject("language", "RelatedContent") + "</h3><hr />";
        anm_Utility ut = new anm_Utility();
        string[] keyw = ut.RemoveNonAlfaNumeric(title).Split('-');
        int j = 1;
        string condition = "(";
        for (int i = 0; i < keyw.Length; i++)
        {
            if (keyw[i].Length > 3)
            {
                string value = keyw[i].ToString();
                condition += "(title LIKE '%' + '" + value + "' + '%') OR (news LIKE '%' + '" + value + "' + '%') OR (summary LIKE '%' + '" + value + "' + '%') OR ";
            }
        }
        if (condition != "(")
            condition = condition.Remove(condition.Length - 4, 4) + ") and";
        else
            condition = "";
        string strConn = ConfigurationManager.ConnectionStrings["anmcs"].ToString();
        SqlConnection myConnection = new SqlConnection(strConn);
        SqlCommand myCommand = new SqlCommand();
        myCommand.Connection = myConnection;
        myConnection.Open();
        myCommand.CommandText = "SELECT TOP 3 idnews,news,title,image FROM anm_News,anm_Categories WHERE " + condition + " published='true' and anm_News.idnews <> " + idn + " and anm_News.idcategory = anm_Categories.idcategory and (anm_News.idcategory = " + idc + " or anm_Categories.idfather = " + idc + " or anm_Categories.idrootcat = " + idc + ") ORDER BY anm_News.date DESC";
        SqlDataReader reader = myCommand.ExecuteReader();
        while (reader.Read())
        {
            string idnews = reader["idnews"].ToString();
            string t = reader["title"].ToString();
            string image = reader["image"].ToString();
            string preview = reader["news"].ToString();
            preview = Regex.Replace(preview, @"<(.|\n)*?>", string.Empty);
            if (preview.Length > 106)
                preview = preview.Substring(0, 107) + "...";
            /*
            if (image != "")
            {
                if (j % 2 == 1)
                    res += "<div style='height:63px;padding:5px;'><a href='" + apath + "/articles/" + idnews + "/" + RNA(t) + ".aspx'><img alt='" + t + "' class='left' style='max-height:60px;max-width:70px' src='" + apath + "/images/" + image + "' /></a>-  <a href='" + apath + "/articles/" + idnews + "/" + RNA(t) + ".aspx'>" + t + "</a> ";
                else
                    res += "<div class='right' style='width:50%;height:63px;padding:5px;'><a href='" + apath + "/articles/" + idnews + "/" + RNA(t) + ".aspx'><img alt='" + t + "' class='left' style='max-height:60px;max-width:70px' src='" + apath + "/images/" + image + "' /></a>-  <a href='" + apath + "/articles/" + idnews + "/" + RNA(t) + ".aspx'>" + t + "</a> </div></div>";
            }
            else
            {
                if (j % 2 == 1)
                    res += "<div style='padding:5px;'>-  <a href='" + apath + "/articles/" + idnews + "/" + RNA(t) + ".aspx'>" + t + "</a> ";
                else
                    res += "<div class='right' style='width:50%;padding:5px;'>-  <a href='" + apath + "/articles/" + idnews + "/" + RNA(t) + ".aspx'>" + t + "</a> </div></div>";
            }
             */
            if (image != "")
                res += "<div style='height:50px;padding:2px;'><a href='" + apath + "/articles/" + idnews + "/" + RNA(t) + ".aspx'><img alt='" + t + "' class='left' style='max-height:50px;max-width:70px' src='" + apath + "/images/" + image + "' /></a>-  <a href='" + apath + "/articles/" + idnews + "/" + RNA(t) + ".aspx'>" + t + "</a> <br /><span class='small'>" + preview + "</span></div>";
            else
                res += "<div style='padding:2px;'>-  <a href='" + apath + "/articles/" + idnews + "/" + RNA(t) + ".aspx'>" + t + "</a> <br /><span class='small'>" + preview + "</span></div>";

            j++;
        }
        myConnection.Close();
        if (res == "<h3>Related Contents</h3>")
            res = "";
        if (res == "<h3>" + GetGlobalResourceObject("language", "RelatedContent") + "</h3><hr />")
            return "";
        else
            return res + "<hr />";
    }
    protected string GetImage(string filename)
    {
        return apath + "/images/" + filename;
    }
    protected string UrlJqBBCode()
    {
        return apath + "/jquery.bbcode.js";
    }
    protected string UrlJQuery()
    {
        return apath + "/jquery-1.7.1.min.js";
    }
    protected string Description(string summary, string news, string title)
    {
        string descr = Regex.Replace(summary, @"<(.|\n)*?>", string.Empty);
        if (descr.Length < 1)
            descr = Regex.Replace(news, @"<(.|\n)*?>", string.Empty);
        if (descr.Length > 195)
            descr = descr.Substring(0, 196) + "...";

        if (Request.QueryString["comment"] != null)
        {
            descr = title + " - Comment " + Request.QueryString["comment"];
        }
        HtmlMeta keywords = new HtmlMeta();
        keywords.Name = "description";
        keywords.Content = descr;
        Page.Header.Controls.Add(keywords);
        return "";
    }
    protected void SendComment(object sender, EventArgs e)
    {
        String comment = Page.Request.Form["commentarea"];
        MembershipUser currentUser = Membership.GetUser();
        anm_Utility ut = new anm_Utility();
        string idn = "";
        if (HttpContext.Current.Request.QueryString["news"] != null)
            idn = HttpContext.Current.Request.QueryString["news"];
        else
            idn = ut.GetIdNewsByComment(Request.QueryString["comment"]);
        string titlenews = ut.GetTitleNews(idn);
        string url = Page.Request.Url.AbsolutePath.ToString() + "?p=articles&news=" + idn;
        if (currentUser == null && (ut.GetSetting("Anonymous") == "False" || ut.GetSetting("Anonymous") == ""))
            Response.Redirect(url + "&err=5#response");
        else if (comment.Length == 0)
            Response.Redirect(url + "&err=1#response");
        else if (comment.Length > 2000)
            Response.Redirect(url + "&err=4#response");
        else
        {
            if (ut.GetSetting("CaptchaComments") == "True")
            {
                if (txtcaptcha.Text.ToString() != Request.Cookies["Captcha"]["value"])
                {
                    Response.Redirect(url + "&err=3#response");
                }
            }
            Boolean bbcode;
            String commento;
            try { bbcode = Convert.ToBoolean(ut.GetSetting("BBcode")); }
            catch { bbcode = false; }
            if (bbcode)
                commento = ut.ConvertBBCodeToHTML(comment);
            else
            {
                Regex exp;
                exp = new Regex(@"\&lt;blockquote\&gt;(.+?)\&lt;/blockquote\&gt;");
                commento = exp.Replace(comment, "");
                exp = new Regex(@"\[QUOTE\=(.+?)\](.+?)\[/QUOTE\]");
                commento = exp.Replace(commento, "<blockquote><strong>$1 wrote</strong>:<br/>$2</blockquote>");
                exp = new Regex(@"\[QUOTE\](.+?)\[/QUOTE\]");
                commento = exp.Replace(commento, "<blockquote>$1</blockquote>");
                commento = commento.Replace("&lt;br /&gt;", "\n");
                commento = commento.Replace("\r\n", "<br />");
                commento = commento.Replace("\n", "<br />");
                commento = commento.Replace("</blockquote><br />", "</blockquote>");
            }
            Boolean approve;
            try { approve = Convert.ToBoolean(ut.GetSetting("ApproveComments")); }
            catch { approve = true; }
            string ip = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            string idnews = idn.ToString();
            int nc = ut.GetCommentsNews(idnews);
            try
            {
                string strConn = ConfigurationManager.ConnectionStrings["anmcs"].ToString();
                SqlConnection conn = new SqlConnection(strConn);
                SqlCommand command = new SqlCommand("anm_InsertComment", conn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@idnews", SqlDbType.Int).Value = idnews;
                if (currentUser == null)
                    command.Parameters.Add("@commentator", SqlDbType.NVarChar).Value = "Anonymous";
                else
                    command.Parameters.Add("@commentator", SqlDbType.NVarChar).Value = currentUser.UserName.ToString();
                command.Parameters.Add("@comment", SqlDbType.NText).Value = commento;
                command.Parameters.Add("@ip", SqlDbType.NVarChar).Value = ip;
                command.Parameters.Add("@approved", SqlDbType.NVarChar).Value = !approve;
                conn.Open();
                int rows = command.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                lblerror.Text = ex.Message;
                lblerror.Visible = true;
            }
            if (approve)
                Response.Redirect(Page.Request.Url.AbsolutePath.ToString() + "?p=confirm&mes=" + GetGlobalResourceObject("language", "CommentSent") + "&link=" + idnews);
            else
            {
                ut.IcreaseComments(idnews, nc + 1);
                Response.Redirect(apath + "/articles/" + idn + "/" + ut.RemoveNonAlfaNumeric(titlenews) + ".aspx#comments");
            }
        }
    }
    protected int SetImageWidth()
    {
        anm_Utility ut = new anm_Utility();
        if (ut.GetSetting("ArtImageWidth") != "")
            return Convert.ToInt32(ut.GetSetting("ArtImageWidth"));
        else
            return 200;
    }
    protected string SetleaveClink(string idnews, string title)
    {
        anm_Utility ut = new anm_Utility();
        HLleaveComment.NavigateUrl = apath + "/articles/" + idnews + "/" + ut.RemoveNonAlfaNumeric(title) + ".aspx#response";
        return "";
    }
    protected string ViewArticle(string check, string date)
    {
        string role = "0";
        DateTime data = DateTime.Parse(date);
        if (Request.IsAuthenticated)
        {
            MembershipUser user = Membership.GetUser();
            anm_Utility ut = new anm_Utility();
            role = ut.GetRole(user.UserName);
        }
        if ((check == "False" || data > DateTime.Now) && role != "1")
            Response.Redirect(apath + "/homepage.aspx");
        return "";
    }
    protected string ViewComment(string comment)
    {
        return Server.HtmlDecode(comment);
    }



    protected string TagNews(string value)
    {
        anm_Utility ut = new anm_Utility();
        if (value == "" || value == null)
            return "";
        else
        {
            HtmlMeta keywords = new HtmlMeta();
            keywords.Name = "keywords";
            keywords.Content = value;
            Page.Header.Controls.Add(keywords);

            string[] input = value.Split(',');
            string OutPut = "|| " + GetGlobalResourceObject("language", "Tags") + " - <strong>";
            for (int i = 0; i < input.Length; i++)
            {
                OutPut = OutPut + " " + "<a href='" + apath + "/tag/" + ut.UrlEncode(input[i].ToString()) + ".aspx'>" + input[i].ToString() + "</a> - ";
            }
            return OutPut + "</strong>";
        }
    }
    protected string PostedBy(string author, string date, string postedby)
    {
        anm_Utility ut = new anm_Utility();
        DateTime data = DateTime.Parse(date);
        string newDate = string.Format("{0}", data.ToString("f", System.Globalization.CultureInfo.CurrentCulture));
        string res = "";
        if (postedby == "True")
            res = GetGlobalResourceObject("language", "Postedby") + " <a href='" + apath + "/articles/author/" + ut.UrlEncode(author) + ".aspx'>" + author.Replace("&", "&amp;") + "</a> " + GetGlobalResourceObject("language", "on") + " " + newDate;
        return res;
    }
    protected string Edit()
    {
        string res = "";
        anm_Utility ut = new anm_Utility();
        if (Request.IsAuthenticated)
        {
            MembershipUser user = Membership.GetUser();
            string role = ut.GetRole(user.UserName);
            if (role == "1")
            {
                string idn = "";
                if (Request.QueryString["comment"] != null)
                    idn = ut.GetIdNewsByComment(Request.QueryString["comment"]);
                else
                    idn = Request.QueryString["news"];
                res = "<a href='" + Page.Request.Url.AbsolutePath.ToString() + "?p=EditArticle&amp;idnews=" + idn + "'>|" + GetGlobalResourceObject("language", "Edit") + "|</a>";
            }
        }
        return res;
    }
    protected string EditComment(string idc, string idn)
    {
        string res = "";
        anm_Utility ut = new anm_Utility();
        if (Request.IsAuthenticated)
        {
            MembershipUser user = Membership.GetUser();
            string role = ut.GetRole(user.UserName);
            if (role == "1")
                res = "<b><a href='" + Page.Request.Url.AbsolutePath.ToString() + "?p=AdminComments&amp;idc=" + idc + "&amp;idnews=" + idn + "'>|" + GetGlobalResourceObject("language", "Edit") + "|</a></b>";
        }
        return res;
    }
    protected string Navigation()
    {
        anm_Utility ut = new anm_Utility();
        string idn = HttpContext.Current.Request.QueryString["news"];
        string titlenews = ut.GetTitleNews(idn);
        return "<div class='navigationbar'>" + ut.GetNavigation() + titlenews + "</div>";
    }
    protected void LBcaptcha_Click(object sender, EventArgs e)
    {
        Response.Cookies["Captcha"]["value"] = (Guid.NewGuid().ToString()).Substring(0, 5);
        string text = (Guid.NewGuid().ToString()).Substring(0, 4);
        imgcaptcha.ImageUrl = Page.Request.Url.AbsolutePath.ToString() + "?p=captcha&text=" + text;
    }
    protected Boolean IsAdmin()
    {
        Boolean isadmin = false;
        try
        {
            if (Request.IsAuthenticated)
            {
                MembershipUser user = Membership.GetUser();
                anm_Utility ut = new anm_Utility();
                string role = ut.GetRole(user.UserName);
                if (role == "1")
                    isadmin = true;
            }
        }
        catch
        {
            isadmin = false;
        }
        return isadmin;
    }
    protected Boolean CheckBBCode()
    {
        //anm_Utility ut = new anm_Utility();
        //return !Convert.ToBoolean(ut.GetSetting("BBCode"));
        return false;
    }
    protected void DeleteComment_Command(object sender, CommandEventArgs e)
    {
        try
        {
            anm_Utility ut = new anm_Utility();
            string[] commandArgs = e.CommandArgument.ToString().Split(new char[] { ',' });
            string idc = commandArgs[0];
            string idn = commandArgs[1];
            string value = commandArgs[2];
            int nc = ut.GetCommentsNews(idn);
            string titlenews = ut.GetTitleNews(idn);
            string strConn = ConfigurationManager.ConnectionStrings["anmcs"].ToString();
            SqlConnection myConnection = new SqlConnection(strConn);
            SqlCommand myCommand = new SqlCommand();
            myCommand.Connection = myConnection;
            myConnection.Open();
            myCommand.CommandText = "DELETE FROM anm_Comments WHERE idcomment =" + idc;
            object accountNumber = myCommand.ExecuteScalar();
            myConnection.Close();

            if (value == "True")
                ut.IcreaseComments(idn, nc - 1);
            Response.Redirect(apath + "/articles/" + idn + "/" + ut.RemoveNonAlfaNumeric(titlenews) + ".aspx");
        }
        catch
        {
        }
    }
    protected string RNA(string text)
    {
        anm_Utility ut = new anm_Utility();
        return ut.RemoveNonAlfaNumeric(text);
    }
    protected string ViewDate(string date)
    {
        DateTime d = Convert.ToDateTime(date);
        anm_Utility ut = new anm_Utility();
        return ut.GetRelativeTime(d);
    }

    protected string BuyNow(string idnews)
    {
        anm_Utility ut = new anm_Utility();
        string titlenews = ut.GetTitleNews(idnews);
        string buylink = "";
        if (idnews == "" || idnews == null) return "";
        else
        {
            buylink = String.Format("<a href='{0}/buy/{1}/{2}.aspx'>Buy Now</a>", apath, idnews, anm_Utility.RNA(titlenews));
        }
        return buylink;
    }
}