<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlYahooOnline.ascx.cs"
    Inherits="PGFine.Ctrl.CtrlYahooOnline" %>
<div class="TitleSupport">
    <asp:Label ID="lbCaptionOnline" runat="server" Text="HỖ TRỢ TRỰC TUYẾN :"></asp:Label>
</div>
<div class="ImgSupport">
    <asp:HyperLink ID="hplinkOnline1" runat="server">
        <asp:Image ID="imgOnline" runat="server" ImageUrl="~/Images/hotro_on1.gif" /></asp:HyperLink>
</div>
<div class="ImgSupport">
    <asp:HyperLink ID="hplinkOnline2" runat="server">
        <asp:Image ID="imgOnline1" runat="server" ImageUrl="~/Images/hotro_off2.gif" /></asp:HyperLink>
</div>
<div class="ImgSupporttel">
    <asp:Image ID="Image7" runat="server" ImageUrl="~/Images/tel.gif" />
</div>
<div class="TelSupport">
    <asp:Label ID="Label3" runat="server" Text="08.3653253"></asp:Label>
</div>
