﻿<%@ Control Language="C#" EnableViewState="False" Inherits="BlogEngine.Core.Web.Controls.CommentViewBase" %>
<div id="id_<%=Comment.Id %>" class="vcard comment<%= Post.Author.Equals(Comment.Author, StringComparison.OrdinalIgnoreCase) ? " self" : "" %>">
    <p class="date">
        <%= Comment.DateCreated %>
        <a href="#id_<%=Comment.Id %>">#</a></p>
    <p class="gravatar">
        <%= Gravatar(80)%></p>
    <p class="content">
        <%= Text %></p>
    <p class="author">
        <%= Comment.Website != null ? "<a href=\"" + Comment.Website + "\" rel=\"nofollow\" class=\"url fn\">" + Comment.Author + "</a>" : "<span class=\"fn\">" +Comment.Author + "</span>" %>
        <%= Flag %>
        <%= ((BlogEngine.Core.BlogSettings.Instance.IsCommentNestingEnabled && Comment.IsApproved) ? " | " : "") %>
        <%= ReplyToLink %>
        <%= AdminLinks %>
    </p>
    <div class="comment-replies" id="replies_<%=Comment.Id %>" <%= (Comment.Comments.Count == 0) ? " style=\"display:none;\"" : "" %>>
        <asp:PlaceHolder ID="phSubComments" runat="server" />
    </div>
</div>
