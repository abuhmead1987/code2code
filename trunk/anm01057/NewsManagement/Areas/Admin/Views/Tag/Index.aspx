<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<NewsManagement.anm_Tags>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Tag Management</h2>
    <p>
        <%: Html.ActionLink("Create New", "Create") %>
    </p>
    <% if (Model.Count() > 0)
       { %>
    <table>
        <tr>
            <th>
                Size
            </th>
            <th>
            </th>
        </tr>
        <% foreach (var item in Model)
           { %>
        <tr>
            <td>
                <%: Html.DisplayFor(modelItem => item.Size) %>
            </td>
            <td>
                <%: Html.ActionLink("Edit", "Edit", new { id=item.Tag }) %>
                |
                <%: Html.ActionLink("Details", "Details", new { id=item.Tag }) %>
                |
                <%: Html.ActionLink("Delete", "Delete", new { id=item.Tag }) %>
            </td>
        </tr>
        <% } %>
    </table>
    <%  } %>
</asp:Content>
