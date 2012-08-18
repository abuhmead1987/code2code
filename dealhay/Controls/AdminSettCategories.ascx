<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AdminSettCategories.ascx.cs" Inherits="Controls_AdminSettCategories" %>
<%@ Register src="AdminMenu.ascx" tagname="AdminMenu" tagprefix="uc1" %>

    <uc1:AdminMenu ID="AdminMenu1" runat="server" />
    <div style="padding:5px">
        <asp:Label ID="Label1" runat="server" Font-Size="14px" Font-Bold="true" Text="<%$ Resources:language, EnableTopMenu %>"></asp:Label><asp:CheckBox ID="CheckBox1" runat="server" /><br /><asp:Literal runat="server" Text="<%$ Resources:language, EnableTopMenuexp%>" /><br /><br />
        <asp:Label ID="Label2" runat="server" Font-Size="14px" Font-Bold="true" Text="<%$ Resources:language, EnableSideMenu %>"></asp:Label><asp:CheckBox ID="CheckBox3" runat="server" /><br /><asp:Literal ID="Literal1" runat="server" Text="<%$ Resources:language, EnableSideMenuexp%>" /><br /><br />
        <asp:Button ID="Button1" runat="server" Text="<%$ Resources:language, SaveSettings %>" onclick="Button1_Click" /><br />
        <asp:Label ID="Label4" runat="server" Visible="false"></asp:Label>
    </div>