<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<NewsManagement.anm_News>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Index</h2>

<p>
    <%: Html.ActionLink("Create New", "Create") %>
</p>
<table>
    <tr>
        <th>
            title
        </th>
        <th>
            author
        </th>
        <th>
            date
        </th>
        <th>
            image
        </th>
        <th>
            summary
        </th>
        <th>
            news
        </th>
        <th>
            anm_Categories
        </th>
        <th>
            comments
        </th>
        <th>
            commentcheck
        </th>
        <th>
            published
        </th>
        <th>
            highlight
        </th>
        <th>
            postedby
        </th>
        <th>
            sidenews
        </th>
        <th>
            Tags
        </th>
        <th>
            homeslide
        </th>
        <th></th>
    </tr>

<% foreach (var item in Model) { %>
    <tr>
        <td>
            <%: Html.DisplayFor(modelItem => item.title) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.author) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.date) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.image) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.summary) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.news) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.anm_Categories.category) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.comments) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.commentcheck) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.published) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.highlight) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.postedby) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.sidenews) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.Tags) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.homeslide) %>
        </td>
        <td>
            <%: Html.ActionLink("Edit", "Edit", new { id=item.idnews }) %> |
            <%: Html.ActionLink("Details", "Details", new { id=item.idnews }) %> |
            <%: Html.ActionLink("Delete", "Delete", new { id=item.idnews }) %>
        </td>
    </tr>
<% } %>

</table>

</asp:Content>
