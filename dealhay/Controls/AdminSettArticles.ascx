<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AdminSettArticles.ascx.cs" Inherits="Controls_AdminSettArticles" %>
<%@ Register src="AdminMenu.ascx" tagname="AdminMenu" tagprefix="uc1" %>

    <uc1:AdminMenu ID="AdminMenu1" runat="server" />
<div style="padding:5px">
    <asp:Label ID="Label1" runat="server" Font-Size="14px" Font-Bold="true" Text="<%$ Resources:language, NumberofArticles%>"></asp:Label> <asp:TextBox ID="TextBox1" Width="23px" runat="server"></asp:TextBox><br />
    <asp:Literal runat="server" Text="<%$ Resources:language, NumberofArticlesexp%>" /><br /><asp:Label ID="Label4" runat="server" ForeColor="Red" Visible="false" Text="<%$ Resources:language, Insertnumber5100%>"></asp:Label> <br />
    <asp:Label ID="Label3" runat="server" Font-Size="14px" Font-Bold="true" Text="<%$ Resources:language, ApproveArt%>"></asp:Label> <asp:CheckBox ID="CheckBox1" runat="server" /><br />
    <asp:Literal runat="server" Text="<%$ Resources:language, ApproveArtexp%>" /><br /><br />
    <asp:Label ID="Label2" runat="server" Font-Size="14px" Font-Bold="true" Text="<%$ Resources:language, ViewCopyrightOnImage%>"></asp:Label> <asp:CheckBox ID="CheckBox2" runat="server" /><br />
    <asp:Literal runat="server" Text="<%$ Resources:language, ViewCopyrightOnImageexp%>" /><br /><br />
    <asp:Button ID="Button1" runat="server" Text="<%$ Resources:language, SaveSettings%>" onclick="Button1_Click" />

</div>