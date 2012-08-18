<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AddAuthor.ascx.cs" Inherits="Controls_AddAuthor" %>
<%@ Register src="AdminMenu.ascx" tagname="AdminMenu" tagprefix="uc1" %>

     <uc1:AdminMenu ID="AdminMenu1" runat="server" />
<div style="padding:5px">
    <asp:Label ID="Label1" runat="server" Font-Bold="true" Text="<%$ Resources:language, ChooseAuthor%>"></asp:Label> 
                    <asp:DropDownList ID="DropDownList1" runat="server" 
                        DataSourceID="SqlDataSource1" DataTextField="UserName" DataValueField="UserName">
                    </asp:DropDownList>
    <br /><br />
    <asp:Label ID="Label2" runat="server" Font-Bold="true" Text="<%$ Resources:language, ChooseRole%>"></asp:Label> 
    <asp:DropDownList ID="DropDownList2" runat="server">
    </asp:DropDownList> Publisher <asp:Literal runat="server" Text="<%$ Resources:language, PublisherPerm%>" /><br /><br />
    <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="<%$ Resources:language, Add%>" />
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:anmcs %>" 
        SelectCommand="anm_GetUserNames" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
</div>