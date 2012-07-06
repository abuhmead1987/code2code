<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<NewsManagement.anm_Categories>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Category Management</h2>
    <p>
        <%: Html.ActionLink("Create New", "Create") %>
    </p>
    <table>
        <tr>
            <th>
                category
            </th>
            <th>
                idfather
            </th>
            <th>
                ordercat
            </th>
            <th>
                url
            </th>
            <th>
                idrootcat
            </th>
            <th>
            </th>
        </tr>
        <% foreach (var item in Model)
           { %>
        <tr>
            <td>
                <%: Html.DisplayFor(modelItem => item.category) %>
            </td>
            <td>
                <%: Html.DisplayFor(modelItem => item.idfather) %>
            </td>
            <td>
                <%: Html.DisplayFor(modelItem => item.ordercat) %>
            </td>
            <td>
                <%: Html.DisplayFor(modelItem => item.url) %>
            </td>
            <td>
                <%: Html.DisplayFor(modelItem => item.idrootcat) %>
            </td>
            <td>
                <%: Html.ActionLink("Edit", "Edit", new { id=item.idcategory }) %>
                |
                <%: Html.ActionLink("Details", "Details", new { id=item.idcategory }) %>
                |
                <%: Html.ActionLink("Delete", "Delete", new { id=item.idcategory }) %>
            </td>
        </tr>
        <% } %>
    </table>
</asp:Content>
