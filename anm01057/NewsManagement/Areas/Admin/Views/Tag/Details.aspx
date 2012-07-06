<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<NewsManagement.anm_Tags>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Details</h2>

<fieldset>
    <legend>anm_Tags</legend>

    <div class="display-label">Size</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.Size) %>
    </div>
</fieldset>
<p>

    <%: Html.ActionLink("Edit", "Edit", new { id=Model.Tag }) %> |
    <%: Html.ActionLink("Back to List", "Index") %>
</p>

</asp:Content>
