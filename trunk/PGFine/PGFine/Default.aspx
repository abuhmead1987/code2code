<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" MasterPageFile="~/MasterPageUser/MasterPageUser.Master"
    Inherits="PGFine.Default" EnableEventValidation="false" %>

<%@ Register Src="Ctrl/CtrlMainBanner.ascx" TagName="CtrlMainBanner" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="_errorLabel" runat="server" Visible="false"></asp:Label>
    <uc1:CtrlMainBanner ID="CtrlMainBanner1" runat="server" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="Pageging">
        <div style="float: left; width: 800px; margin-left: 10px;">
            <asp:Label ID="lbPage" runat="server" Text="Trang:" CssClass="LabelMenuRight"></asp:Label>
            <asp:Label ID="LblPage" runat="server" Text="Label" Visible="false"></asp:Label>
            <asp:Label ID="lblPages" runat="server" Text="Label" Visible="false"></asp:Label>
            <asp:LinkButton ID="linkFirst" runat="server" OnClick="linkFirst_Click" CssClass="LabelMenuRight"
                Visible="false" Font-Underline="false">Trang đầu >></asp:LinkButton>
            <asp:Repeater ID="PageList" runat="server" OnItemCommand="PageList_ItemCommand" OnItemDataBound="PageList_ItemDataBound">
                <ItemTemplate>
                    <asp:LinkButton ID="PageIndexLink" CausesValidation="false" CommandName='<%# Eval("Key") %>'
                        CssClass="LabelMenuRight" runat="server"><%# Eval("Value") %></asp:LinkButton>
                </ItemTemplate>
            </asp:Repeater>
            <asp:LinkButton ID="LinkPrevious" runat="server" OnClick="LinkPrevious_Click" CssClass="LabelMenuRight"
                Font-Underline="false" Visible="false">Trang trước</asp:LinkButton>
            <asp:LinkButton ID="LinkNext" runat="server" OnClick="LinkNext_Click1" CssClass="LabelMenuRight"
                Font-Underline="false"><%--&nbsp;Xem hết--%></asp:LinkButton>
        </div>
        <div style="float: right; margin-right: 7px;">
            <asp:Label ID="lbDisplay" runat="server" Text="Hiển thị:" CssClass="LabelMenuRight"></asp:Label>
            <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                <asp:ListItem>15</asp:ListItem>
                <asp:ListItem>30</asp:ListItem>
                <asp:ListItem>40</asp:ListItem>
                <asp:ListItem>50</asp:ListItem>
            </asp:DropDownList>
        </div>
    </div>
    <div class="ListProduct">
        <table cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td align="left">
                    <asp:Repeater ID="rptListProduct" runat="server" OnItemDataBound="rptListProduct_ItemDataBound">
                        <ItemTemplate>
                            <div class="ProductMain">
                                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# "~/ProductDetail.aspx?productid=" + Eval("ProductID").ToString() %>'
                                    onmouseout="BBTOnline_HideTooltip();" onmouseover='<%# getURLTooltip(Eval("ProductID").ToString())%>'>
                                    <asp:Image ID="Image15" runat="server" ImageUrl='<%# Eval("ImagesProduct").ToString() %>' /></asp:HyperLink>
                                <div class="CaptionProductPrice">
                                    <div class="DfTitle">
                                        <%-- <asp:Label ID="Label6" runat="server" Text='<%# Eval("NameProduct").ToString() %>'></asp:Label>--%>
                                        <asp:HyperLink ID="hplTitleProduct" runat="server" onmouseout="BBTOnline_HideTooltip();"
                                            onmouseover='<%# getURLTooltip(Eval("ProductID").ToString())%>' Text='<%# Eval("NameProduct").ToString() %>'
                                            NavigateUrl='<%# "~/ProductDetail.aspx?productid=" + Eval("ProductID").ToString() %>'
                                            CssClass="NameProductDe"></asp:HyperLink>
                                    </div>
                                    <div class="imgMid">
                                        <asp:Image ID="Image16" runat="server" ImageUrl="~/Images/MiddlePrice.gif" />
                                    </div>
                                    <div class="dfPrice">
                                        <asp:Label ID="lbPrice" runat="server" Text='<%# Eval("Price").ToString() + " VND" %>'
                                            CssClass="ColorPriceOld"></asp:Label>
                                        <asp:Label ID="lbPriceNew" runat="server" Text='<%# Eval("PriceNew").ToString()+ " VND" %>'
                                            CssClass="ColorPrice"></asp:Label>
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                    <asp:HiddenField ID="hdCategory" runat="server" />
                    <asp:HiddenField ID="hdToltalRows" runat="server" />
                </td>
            </tr>
        </table>
    </div>
    <div class="PagegingBottomDe">
        <div style="float: left; width: 800px; margin-left: 10px; margin-bottom: 3px; height: 20px;">
            <asp:Label ID="lbPageBottom" runat="server" Text="Trang:" CssClass="LabelMenuRight"></asp:Label>
            <asp:Repeater ID="rptPaggingBottom" runat="server" OnItemCommand="PageList_ItemCommand"
                OnItemDataBound="PageList_ItemDataBound">
                <ItemTemplate>
                    <asp:LinkButton ID="PageIndexLink" CausesValidation="false" CommandName='<%# Eval("Key") %>'
                        CssClass="LabelMenuRight" runat="server"><%# Eval("Value") %></asp:LinkButton>
                </ItemTemplate>
            </asp:Repeater>
            <asp:LinkButton ID="lbtNextBottom" runat="server" OnClick="LinkNext_Click1" CssClass="LabelMenuRight"
                Font-Underline="false">&nbsp;Xem hết</asp:LinkButton>
        </div>
        <div style="float: right; height: 20px;">
            <div class="TitleUptop">
                <a href="javascript:top.window.scrollTo(0,0)"><asp:Label ID="lbBacktotop"
                    runat="server" Text="Lên đầu trang" Font-Underline="false"></asp:Label></a>
            </div>
            <div class="ImagesUptop">
                <a href="javascript:top.window.scrollTo(0,0)">
                    <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/btlendautrang.gif" />
                </a>
            </div>
        </div>
    </div>
</asp:Content>
