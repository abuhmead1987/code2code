<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ArchiveMenu.ascx.cs" Inherits="Controls_ArchiveMenu" %>

<asp:Panel ID="PnlArchiveMenu" Visible="false" runat="server">
<h2><asp:Literal ID="h2archive" runat="server" Text="<%$ Resources:language, Archives%>" /></h2>
<div class="sp">
<asp:DropDownList ID="ddlarchive" Visible="false" OnSelectedIndexChanged="ddlarchive_SelectedIndexChanged" AutoPostBack="true" runat="server"></asp:DropDownList><% Response.Write(ViewArchiveMenu()); %>
</div>
</asp:Panel>

