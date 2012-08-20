<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlMainBanner.ascx.cs"
    Inherits="PGFine.Ctrl.CtrlMainBanner" %>
<%--<div class="ImgBannerMainImages" style="background-image: url('../Images/MainBanner.gif');">--%>
<asp:Literal ID="ltrDivBannerMain" runat="server"></asp:Literal>
<asp:Label ID="_errorLabel" runat="server"></asp:Label>
<%-- <asp:HyperLink ID="HyperLink21" runat="server" ImageUrl="~/Images/btMenu1.gif" CssClass="btPosition"></asp:HyperLink>
    <asp:HyperLink ID="HyperLink22" runat="server" ImageUrl="~/Images/btMenu2.gif" CssClass="btPosition"></asp:HyperLink>
    <asp:HyperLink ID="HyperLink23" runat="server" ImageUrl="~/Images/btMenu3.gif" CssClass="btPosition"></asp:HyperLink>--%>
<asp:Repeater ID="rptProductMenu" runat="server" OnItemDataBound="rptProductMenu_ItemDataBound">
    <ItemTemplate>
        <asp:HiddenField ID="hdHover" runat="server" Value='<%# Eval("ImagePathOver").ToString() %>'/>
        <asp:HiddenField ID="hdOut" runat="server" Value='<%# Eval("ImagePathOut").ToString() %>' />
        <asp:ImageButton ID="imgbtImages" runat="server" ImageUrl='<%# Eval("ImagePathOut").ToString() %>' 
            OnMouseOver="this.src='../Images/btMenu2.gif';" OnMouseOut="this.src='../Images/btMenu1.gif';" CommandName='<%# Eval("ID").ToString() %>'
            CssClass="btPosition" oncommand="imgbtImages_Command" ></asp:ImageButton>
    </ItemTemplate>
</asp:Repeater>
</div> 
