<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Header.ascx.cs" Inherits="Controls_Header" %>
	<div id="header" class="header" align="center" runat="server">
	    <div class="sitetitle"><asp:HyperLink ID="HLtitle" runat="server">
        <asp:Image ID="ImgTitle" runat="server" /></asp:HyperLink></div>
	    <% Response.Write(ViewMenu()); %>
	</div>