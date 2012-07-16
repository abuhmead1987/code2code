<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AddCategory.ascx.cs" Inherits="Controls_AddCategory" %>
<%@ Register src="AdminMenu.ascx" tagname="AdminMenu" tagprefix="uc1" %>
    <uc1:AdminMenu ID="AdminMenu1" runat="server" />
<div style="padding:5px">
    <asp:Label ID="Label3" runat="server" Font-Bold="true" Text="<%$ Resources:language, Addcategory%>"></asp:Label>:
<br /><br />
    <asp:Label ID="Label1" runat="server" Text="<%$ Resources:language, Categoryname%>"></asp:Label> 
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox> <br />
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1" ErrorMessage="<%$ Resources:language, RequiredFieldCat%>"></asp:RequiredFieldValidator><br />
    <asp:Literal runat="server" Text="<%$ Resources:language, Isasubcat%>" /> <asp:CheckBox ID="CheckBox1" runat="server" oncheckedchanged="CheckBox1_CheckedChanged" Autopostback="True"/><br /><br />
    <asp:Label ID="Label2" runat="server" Text="<%$ Resources:language, ChooseFat %>" Visible="false"></asp:Label>
    <asp:DropDownList ID="DropDownList1" runat="server" Visible="False" 
        DataSourceID="SqlDataSource1" DataTextField="category" 
        DataValueField="idcategory"></asp:DropDownList><br /><br />
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:anmcs %>" 
        SelectCommand="anm_getCategories" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
    <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="<%$ Resources:language, Add %>" />
</div>