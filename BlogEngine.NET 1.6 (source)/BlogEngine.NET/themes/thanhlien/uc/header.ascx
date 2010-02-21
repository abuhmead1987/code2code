<%@ Control Language="C#" AutoEventWireup="true" CodeFile="header.ascx.cs" Inherits="themes_thanhlien_uc_header" %>
<a href="#">
    <img src='<%=Page.ResolveUrl("~/themes/thanhlien/images/logo.jpg")%>' alt="Thanh Lien Hotel"
        title="Thanh Lien Hotel" width="237" height="157" border="0" class="left" /></a><ul
            id="nav">
            <li><a href="/t-Default.aspx"><%=Resources.labels.home %></a></li>
            <li><a href="#"><%=Resources.labels.Intro %></a></li>
            <li><a href="#"><%=Resources.labels.Room %></a></li>
            <li><a href="#"><%=Resources.labels.Feedback %></a></li>
            <li><a href="#"><%=Resources.labels.NewEvent%></a></li>
            <li><a href='<%= ResolveUrl("~/t-Contact.aspx") %>'><%=Resources.labels.contact %></a></li></ul>
<div id="nav_timer">
    <%=DateTime.Now.ToLongDateString() %>
    <a runat="server" id="aLogin" />
</div>
<div class="clr">
</div>
