<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="newslist.aspx.cs" MasterPageFile="~/MasterPageUser/MasterPageUser.Master"
    Inherits="PGFine.newslist" EnableEventValidation="false" %>

<%@ Register Src="Ctrl/CtrlRandomProduct.ascx" TagName="CtrlRandomProduct" TagPrefix="uc2" %>
<%@ Register Src="Ctrl/CtrlMainBanner.ascx" TagName="CtrlMainBanner" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="_errorLabel" runat="server" Visible="false"></asp:Label>
    <uc1:CtrlMainBanner ID="CtrlMainBanner1" runat="server" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="Pageging">
        <div runat="server" id="BannerBreakrum">
            <asp:Label ID="lbBreakrum" runat="server" Text="men" CssClass="Breakrum"></asp:Label>
        </div>
    </div>
    <div class="ListProduct">
        <asp:Repeater ID="rptListProduct" runat="server" OnItemDataBound="rptListProduct_ItemDataBound">
            <ItemTemplate>
                <div class="ListNews">
                    <div style="float: left; width: 470px;">
                        <asp:Literal ID="ltrImages" runat="server"></asp:Literal>
                        <div style="height:90px;">
                            <div class="ListNewsTitle" runat="server" id="htmlTitle">
                                <asp:HyperLink ID="hplTitle" runat="server" Font-Underline="false" CssClass="ListNewsT"></asp:HyperLink>
                            </div>
                            <div class="ListNewsShortDescript" runat="server" id="htmlShort">
                                <asp:Literal ID="ltrShortDescription" runat="server"></asp:Literal>
                            </div>
                        </div>
                        <div style="float:left; width: 340px;height: 15px;">
                            <div style="float: right;padding-top:3px;">
                                <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/button_Xemthem.gif" CssClass="ImgesXem" />
                            </div>
                            <div style="float: right; font-family: Arial; font-size: 11px; color: #D91A5D;padding-right:5px;">
                               <%-- XEM THÊM--%><asp:HyperLink ID="hplView" runat="server" CssClass="ViewCss"></asp:HyperLink>
                            </div>
                        </div>
                    </div>
                    <div style="float: right; width: 3px; height: 110px;">
                        <asp:Image ID="imgDot_NewList" runat="server" ImageUrl="~/Images/Dot_news_list.gif" />
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
        <asp:HiddenField ID="hdCategory" runat="server" />
        <asp:HiddenField ID="hdToltalRows" runat="server" />
        <div class="PagegingBottom">
            <div id="Div1" style="float: right; margin-right: 7px;" runat="server" visible="false">
                <asp:Label ID="Label1" runat="server" Text="Hiển thị:" CssClass="LabelMenuRight"></asp:Label>
                <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                    <asp:ListItem>16</asp:ListItem>
                    <asp:ListItem>30</asp:ListItem>
                    <asp:ListItem>40</asp:ListItem>
                    <asp:ListItem>50</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div style="float: left; width: 700px; margin-right: 15px; padding-bottom: 5px;">
                <asp:Label ID="Label5" runat="server" Text="Trang:" CssClass="LabelMenuRight"></asp:Label>
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
                    Font-Underline="false">&nbsp;Xem hết</asp:LinkButton>
            </div>
        </div>
        <uc2:CtrlRandomProduct ID="CtrlRandomProduct1" runat="server" />
        <div class="DivUpHome">
            <div class="testUp">
                <a href="javascript:top.window.scrollTo(0,0)">
                    <asp:Label ID="Label11" runat="server" Text="Lên đầu trang" Font-Underline="false"></asp:Label></a></div>
            <div class="ImagesUp">
                <a href="javascript:top.window.scrollTo(0,0)">
                    <asp:Image ID="Image33" runat="server" ImageUrl="~/Images/btlendautrang.gif" /></a></div>
        </div>
    </div>
</asp:Content>
