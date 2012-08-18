<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SearchMenu.ascx.cs" Inherits="Controls_SearchMenu" %>

        <asp:Panel ID="PnlSearch" Visible="false" DefaultButton="btnSearch" runat="server">
            <asp:TextBox ID="txtSearch" MaxLength="128" Width="65%" Font-Size="10px" Text="<%$ Resources:language, searchsite%>" 
                runat="server"></asp:TextBox> 
            <asp:LinkButton ID="btnSearch" onclick="BtnSearchClick" runat="server"><asp:Image ID="ImgSearch" ImageUrl="~/images/search-icon.gif" ImageAlign="top" BorderStyle="None" AlternateText="Search Button" runat="server" /></asp:LinkButton>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ValidationExpression="^[^<>]{1,500}$" ControlToValidate = "txtSearch" ErrorMessage="invalid"></asp:RegularExpressionValidator>
        </asp:Panel>
