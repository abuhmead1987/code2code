<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlMenuTop.ascx.cs"
    Inherits="PGFine.Ctrl.CtrlMenuTop" %>
<div class="ImagesIconLeft">
    <asp:Image ID="imgImageRow" runat="server" ImageUrl="~/Images/MenuRow.gif" CssClass="ImagesRows" /></div>
<asp:Label ID="_errorLabel" runat="server" Text="Label" Visible="false"></asp:Label>
<asp:Menu ID="CtrMenuControl" runat="server" Orientation="Horizontal" DynamicEnableDefaultPopOutImage="false"
    StaticEnableDefaultPopOutImage="false" DynamicVerticalOffset="2" >
    <StaticMenuItemStyle CssClass="LabelMenuTop" />    
    <DynamicMenuItemStyle CssClass="dynamic" />    
</asp:Menu>
