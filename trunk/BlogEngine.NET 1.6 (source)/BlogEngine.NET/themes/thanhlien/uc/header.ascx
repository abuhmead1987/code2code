﻿<%@ Control Language="C#" AutoEventWireup="true" CodeFile="header.ascx.cs" Inherits="themes_thanhlien_uc_header" %>
<a href="#">
    <img src='<%=Page.ResolveUrl("~/themes/thanhlien/images/logo.jpg")%>' alt="Thanh Lien Hotel"
        title="Thanh Lien Hotel" width="237" height="157" border="0" class="left" /></a><ul
            id="nav">
            <li><a href='<%= ResolveUrl("~/default.aspx")%>'>
                <%=Resources.labels.home %></a></li>
            <li><a href="<%= ResolveUrl("~/page/intro.aspx")%>">
                <%=Resources.labels.Intro %></a></li>
            <li><a href='<%= ResolveUrl("~/page/Room.aspx")%>'>
                <%=Resources.labels.Room %></a></li>
          <%--  <li><a href="#">
                <%=Resources.labels.Feedback %></a></li>--%>
            <li><a href='<%= ResolveUrl("~/news.aspx") %>'>
                <%=Resources.labels.NewEvent%></a></li>
            <li><a href='<%= ResolveUrl("~/t-Contact.aspx") %>'>
                <%=Resources.labels.contact %></a></li></ul>
<div id="nav_timer">
    <%=DateTime.Now.ToLongDateString() %>
    <a runat="server" id="aLogin" />
</div>
<div class="clr">
</div>
