<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<NewsManagement.anm_Categories>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Create
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Create</h2>

<script src="<%: Url.Content("~/Scripts/jquery.validate.min.js") %>" type="text/javascript"></script>
<script src="<%: Url.Content("~/Scripts/jquery.validate.unobtrusive.min.js") %>" type="text/javascript"></script>

<% using (Html.BeginForm()) { %>
    <%: Html.ValidationSummary(true) %>
    <fieldset>
        <legend>anm_Categories</legend>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.category) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.category) %>
            <%: Html.ValidationMessageFor(model => model.category) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.idfather) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.idfather) %>
            <%: Html.ValidationMessageFor(model => model.idfather) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.ordercat) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.ordercat) %>
            <%: Html.ValidationMessageFor(model => model.ordercat) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.url) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.url) %>
            <%: Html.ValidationMessageFor(model => model.url) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.idrootcat) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.idrootcat) %>
            <%: Html.ValidationMessageFor(model => model.idrootcat) %>
        </div>

        <p>
            <input type="submit" value="Create" />
        </p>
    </fieldset>
<% } %>

<div>
    <%: Html.ActionLink("Back to List", "Index") %>
</div>

</asp:Content>
