<%@ Control Language="C#" AutoEventWireup="true" CodeFile="TagBox.ascx.cs" Inherits="Controls_TagBox" %>

        <asp:Panel ID="pnlTags" Visible="false" runat="server">
        <h2><asp:Literal runat="server" Text="<%$ Resources:language, tag%>" /></h2>
        <div class="sp">
        <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
        </div>
        </asp:Panel>
