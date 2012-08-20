<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlMenu.ascx.cs" Inherits="PGFine.Ctrl.CtrlMenu" %>

<asp:Image ID="Image1" runat="server" ImageUrl="~/Images/bt1.gif" CssClass="ImagesLeftMenu" />
<div class="MenuMain">
    <asp:Menu ID="CtrMenuControl" runat="server" Orientation="Horizontal" DynamicEnableDefaultPopOutImage="False"
        StaticEnableDefaultPopOutImage="False" DynamicVerticalOffset="2" DynamicMenuItemStyle-BackColor="White" DynamicMenuStyle-BackColor="White">
        <StaticMenuItemStyle CssClass="statics" />
        <DynamicHoverStyle Font-Bold="True" Font-Size="12pt" />
        <DynamicMenuItemStyle CssClass="dynamic" />
        <StaticHoverStyle Font-Bold="True" Font-Size="10pt" />
    </asp:Menu>
</div>
<asp:Image ID="Image2" runat="server" ImageUrl="~/Images/bt3.gif" CssClass="ImagesRightMenu"/>
