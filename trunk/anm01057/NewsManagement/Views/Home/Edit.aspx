<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<NewsManagement.anm_News>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Edit
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Edit</h2>
    <script src="<%: Url.Content("~/Scripts/jquery.validate.min.js") %>" type="text/javascript"></script>
    <script src="<%: Url.Content("~/Scripts/jquery.validate.unobtrusive.min.js") %>"
        type="text/javascript"></script>
    <% using (Html.BeginForm())
       { %>
    <%: Html.ValidationSummary(true) %>
    <fieldset>
        <legend>anm_News</legend>
        <%: Html.HiddenFor(model => model.idnews) %>
        <div class="editor-label">
            <%: Html.LabelFor(model => model.title) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.title) %>
            <%: Html.ValidationMessageFor(model => model.title) %>
        </div>
        <div class="editor-label">
            <%: Html.LabelFor(model => model.author) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.author) %>
            <%: Html.ValidationMessageFor(model => model.author) %>
        </div>
        <div class="editor-label">
            <%: Html.LabelFor(model => model.date) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.date) %>
            <%: Html.ValidationMessageFor(model => model.date) %>
        </div>
        <div class="editor-label">
            <%: Html.LabelFor(model => model.image) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.image) %>
            <%: Html.ValidationMessageFor(model => model.image) %>
        </div>
        <div class="editor-label">
            <%: Html.LabelFor(model => model.summary) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.summary) %>
            <%: Html.ValidationMessageFor(model => model.summary) %>
        </div>
        <div class="editor-label">
            <%: Html.LabelFor(model => model.news) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.news) %>
            <%: Html.ValidationMessageFor(model => model.news) %>
        </div>
        <div class="editor-label">
            <%: Html.LabelFor(model => model.idcategory) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.idcategory) %>
            <%: Html.ValidationMessageFor(model => model.idcategory) %>
        </div>
        <div class="editor-label">
            <%: Html.LabelFor(model => model.comments) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.comments) %>
            <%: Html.ValidationMessageFor(model => model.comments) %>
        </div>
        <div class="editor-label">
            <%: Html.LabelFor(model => model.commentcheck) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.commentcheck) %>
            <%: Html.ValidationMessageFor(model => model.commentcheck) %>
        </div>
        <div class="editor-label">
            <%: Html.LabelFor(model => model.published) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.published) %>
            <%: Html.ValidationMessageFor(model => model.published) %>
        </div>
        <div class="editor-label">
            <%: Html.LabelFor(model => model.highlight) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.highlight) %>
            <%: Html.ValidationMessageFor(model => model.highlight) %>
        </div>
        <div class="editor-label">
            <%: Html.LabelFor(model => model.postedby) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.postedby) %>
            <%: Html.ValidationMessageFor(model => model.postedby) %>
        </div>
        <div class="editor-label">
            <%: Html.LabelFor(model => model.sidenews) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.sidenews) %>
            <%: Html.ValidationMessageFor(model => model.sidenews) %>
        </div>
        <div class="editor-label">
            <%: Html.LabelFor(model => model.Tags) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.Tags) %>
            <%: Html.ValidationMessageFor(model => model.Tags) %>
        </div>
        <div class="editor-label">
            <%: Html.LabelFor(model => model.homeslide) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.homeslide) %>
            <%: Html.ValidationMessageFor(model => model.homeslide) %>
        </div>
        <p>
            <input type="submit" value="Save" />
        </p>
    </fieldset>
    <% } %>
    <div>
        <%: Html.ActionLink("Back to List", "Index") %>
    </div>
</asp:Content>
