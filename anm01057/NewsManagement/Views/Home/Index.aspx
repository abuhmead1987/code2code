<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<NewsManagement.anm_News>>" %>

<%@ Import Namespace="NewsManagement.Helper" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Home Page
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <% foreach (var item in Model)
       { %>
    <div>
        <h3>
            <%: Html.ActionLink(item.title, "View", new { id = item.idnews })%></h3>
        <span>Posted by:
            <%: item.author %>
            on
            <%:item.date %>
        </span>
        <%if (String.IsNullOrEmpty(item.summary))
          {%>
        <p>
            <%: item.news%></p>
        <%}
          else
          {%>
        <p>
            <%: item.summary%></p>
        <%}%>
        <%if (!String.IsNullOrEmpty(item.image))
          { %>
        <%=Html.ImageActionLink(Url.Content(String.Format("~/{0}/{1}", "UserUpload", item.image)), "", "View", new { id = item.idnews })%>
        <img src="<%:ResolveUrl(String.Format("{0}/{1}","UserUpload",item.image)) %>" alt="<%: item.title%>" />
        <%}%>
        <%: Html.ActionLink("Read Full Article", "View", new { id = item.idnews })%>
        <%: Html.ActionLink("Edit", "Edit", new { id = item.idnews })%>
    </div>
    <% }%>
</asp:Content>
