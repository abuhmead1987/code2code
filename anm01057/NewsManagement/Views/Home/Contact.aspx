<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<NewsManagement.Models.ContactViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Contact
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Contact</h2>
    <script src="<%: Url.Content("~/Scripts/jquery.validate.min.js") %>" type="text/javascript"></script>
    <script src="<%: Url.Content("~/Scripts/jquery.validate.unobtrusive.min.js") %>"
        type="text/javascript"></script>
    <% using (Html.BeginForm())
       { %>
    <%: Html.ValidationSummary(true) %>
    <fieldset>
        <legend>ContactViewModel</legend>
        <div class="editor-label">
            <%: Html.LabelFor(model => model.From) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.From) %>
            <%: Html.ValidationMessageFor(model => model.From) %>
        </div>
        <div class="editor-label">
            <%: Html.LabelFor(model => model.Subject) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.Subject) %>
            <%: Html.ValidationMessageFor(model => model.Subject) %>
        </div>
        <div class="editor-label">
            <%: Html.LabelFor(model => model.Message) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.Message) %>
            <%: Html.ValidationMessageFor(model => model.Message) %>
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
