<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" MasterPageFile="~/MasterPageUser/MasterPageUser.Master"
    Inherits="PGFine.Contact" EnableEventValidation="false" %>

<%@ Register Src="Ctrl/CtrlContact.ascx" TagName="CtrlContact" TagPrefix="uc1" %>
<%@ Register Src="Ctrl/CtrlMainBanner.ascx" TagName="CtrlMainBanner" TagPrefix="uc1" %>
<%@ Register Src="Ctrl/CtrlRandomProduct.ascx" TagName="CtrlRandomProduct" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="_errorLabel" runat="server" Visible="false"></asp:Label>
    <uc1:CtrlMainBanner ID="CtrlMainBanner1" runat="server" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="Pageging">
        <asp:Label ID="lbBreakrumContact" runat="server" Text="Contact" CssClass="Breakrum"></asp:Label>
    </div>
    <div style="float: left; width: 970px; height: 460px;">
        <uc1:CtrlContact ID="CtrlContact1" runat="server" />
        <div class="ContactRight">
            <div class="InformationContact">
                <div style="float: left; width: 400px;">
                    The Big Nose and little toe
                </div>
                <div class="TitleInformationC">
                    <%--115 Lê Văn Sỹ, Phường 13, Quận Phú Nhuận, TP.HCM--%><asp:Literal ID="ltrAddressCompany" runat="server"></asp:Literal>
                </div>
                <div class="TitleInformationC">
                    <%--Điện thoại: (+84.8) 9999999--%><asp:Literal ID="ltrPhoneCompany" runat="server"></asp:Literal>
                </div>
                <div class="TitleInformationC">
                    Fax: (+84.8) 9999999
                </div>
                <div class="TitleInformationC">
                    Email: info@thebisnoseandlitletoe.com
                </div>
            </div>
            <div class="MapContact">
                <div style="float: left; width: 400px; margin: 10px 0px 0px 5px;">
                    <%--Bản đồ--%><asp:Literal ID="ltrMapg" runat="server"></asp:Literal>
                </div>
                <div id="conner">
                    <b class="rtop"><b class="r1"></b><b class="r2"></b><b class="r3"></b><b class="r4">
                    </b></b>
                    <div style="float: left; margin-left: 1px; border-left: solid 1px #D6D0D0; border-right: solid 1px #D6D0D0;">
                        <asp:Literal ID="ltrMap" runat="server"></asp:Literal>
                    </div>
                    <b class="rbottom"><b class="r4"></b><b class="r3"></b><b class="r2"></b><b class="r1">
                    </b></b>
                </div>
            </div>
        </div>
    </div>
    <uc2:CtrlRandomProduct ID="CtrlRandomProduct1" runat="server" />
    <div class="DivUpHome">
        <div class="testUp">
            <a href="javascript:top.window.scrollTo(0,0)">
                <asp:Label ID="lbBreakrum" runat="server" Text="Lên đầu trang" Font-Underline="false"></asp:Label></a></div>
        <div class="ImagesUp">
            <a href="javascript:top.window.scrollTo(0,0)">
                <asp:Image ID="Image33" runat="server" ImageUrl="~/Images/btlendautrang.gif" /></a></div>
    </div>
</asp:Content>
