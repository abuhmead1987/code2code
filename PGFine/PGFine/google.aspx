<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="google.aspx.cs" MasterPageFile="~/MasterPageUser/MasterPageUser.Master"
    Inherits="PGFine.google" EnableEventValidation="false" %>

<%@ Register Src="Ctrl/CtrlMainBanner.ascx" TagName="CtrlMainBanner" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="_errorLabel" runat="server" Visible="false"></asp:Label>
    <uc1:CtrlMainBanner ID="CtrlMainBanner1" runat="server" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="googleMap">    
        <asp:Literal ID="ltrIframe" runat="server"></asp:Literal>    
    </div>
</asp:Content>
