<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AdminSettComments.ascx.cs" Inherits="Controls_AdminSettComments" %>
<%@ Register src="AdminMenu.ascx" tagname="AdminMenu" tagprefix="uc1" %>

    <uc1:AdminMenu ID="AdminMenu1" runat="server" />
<div style="padding:5px">
    <asp:Label ID="Label1" runat="server" Font-Size="14px" Font-Bold="true" Text="<%$ Resources:language, NumberComments%>"></asp:Label> <asp:TextBox ID="TextBox1" Width="23px" runat="server"></asp:TextBox><br />
    <asp:Literal runat="server" Text="<%$ Resources:language, NumberCommentsexp%>" /><br /><asp:Label ID="Label4" runat="server" ForeColor="Red" Visible="false" Text="<%$ Resources:language, Insertnumber5100%>"></asp:Label> <br />
    <asp:Label ID="Label3" runat="server" Font-Size="14px" Font-Bold="true" Text="<%$ Resources:language, ApproveCom%>"></asp:Label> <asp:CheckBox ID="CheckBox1" runat="server" /><br />
    <asp:Literal runat="server" Text="<%$ Resources:language, ApproveComexp%>" /><br /><br />
    <asp:Label ID="Label2" runat="server" Font-Size="14px" Font-Bold="true" Text="<%$ Resources:language, EnableBBCode%>"></asp:Label> <asp:CheckBox ID="CheckBox2" runat="server" /><br />
    <asp:Literal runat="server" Text="<%$ Resources:language, EnableBBCodeexp%>" /><br /><br />
    <asp:Label ID="Label5" runat="server" Font-Size="14px" Font-Bold="true" Text="<%$ Resources:language, EnableAnonymous%>"></asp:Label> <asp:CheckBox ID="CheckBox3" runat="server" /><br />
    <asp:Button ID="Button1" runat="server" Text="<%$ Resources:language, SaveSettings%>" onclick="Button1_Click" />
</div>