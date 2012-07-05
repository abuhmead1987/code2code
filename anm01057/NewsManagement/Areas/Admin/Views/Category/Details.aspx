<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<NewsManagement.anm_Categories>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Details</h2>

<fieldset>
    <legend>anm_Categories</legend>

    <div class="display-label">category</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.category) %>
    </div>

    <div class="display-label">idfather</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.idfather) %>
    </div>

    <div class="display-label">ordercat</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.ordercat) %>
    </div>

    <div class="display-label">url</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.url) %>
    </div>

    <div class="display-label">idrootcat</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.idrootcat) %>
    </div>
</fieldset>
<p>

    <%: Html.ActionLink("Edit", "Edit", new { id=Model.idcategory }) %> |
    <%: Html.ActionLink("Back to List", "Index") %>
</p>

</asp:Content>
