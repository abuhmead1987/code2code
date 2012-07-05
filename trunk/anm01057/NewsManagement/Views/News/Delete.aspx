<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<NewsManagement.anm_News>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Delete
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Delete</h2>

<h3>Are you sure you want to delete this?</h3>
<fieldset>
    <legend>anm_News</legend>

    <div class="display-label">title</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.title) %>
    </div>

    <div class="display-label">author</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.author) %>
    </div>

    <div class="display-label">date</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.date) %>
    </div>

    <div class="display-label">image</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.image) %>
    </div>

    <div class="display-label">summary</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.summary) %>
    </div>

    <div class="display-label">news</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.news) %>
    </div>

    <div class="display-label">anm_Categories</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.anm_Categories.category) %>
    </div>

    <div class="display-label">comments</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.comments) %>
    </div>

    <div class="display-label">commentcheck</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.commentcheck) %>
    </div>

    <div class="display-label">published</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.published) %>
    </div>

    <div class="display-label">highlight</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.highlight) %>
    </div>

    <div class="display-label">postedby</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.postedby) %>
    </div>

    <div class="display-label">sidenews</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.sidenews) %>
    </div>

    <div class="display-label">Tags</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.Tags) %>
    </div>

    <div class="display-label">homeslide</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.homeslide) %>
    </div>
</fieldset>
<% using (Html.BeginForm()) { %>
    <p>
        <input type="submit" value="Delete" /> |
        <%: Html.ActionLink("Back to List", "Index") %>
    </p>
<% } %>

</asp:Content>
