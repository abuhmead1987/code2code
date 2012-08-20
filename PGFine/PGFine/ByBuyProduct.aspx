<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ByBuyProduct.aspx.cs" MasterPageFile="~/MasterPageUser/MasterPageUser.Master"
    Inherits="PGFine.ByBuyProduct" EnableEventValidation="false" %>

<%@ Register Src="Ctrl/CtrlMainBanner.ascx" TagName="CtrlMainBanner" TagPrefix="uc1" %>
<%@ Register Src="Ctrl/CtrlRandomProduct.ascx" TagName="CtrlRandomProduct" TagPrefix="uc2" %>
<%@ Register Src="Ctrl/CtrlCardList.ascx" TagName="CtrlCardList" TagPrefix="uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="_errorLabel" runat="server" Visible="false"></asp:Label>
    <uc1:CtrlMainBanner ID="CtrlMainBanner1" runat="server" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="Pageging">
        <div runat="server" id="BannerBreakrum">
            <asp:Label ID="lbBreakrum" runat="server" Text="sản phẩm đã chọn" CssClass="Breakrum"></asp:Label>
        </div>
    </div>
    <div class="ListProduct">
        <div class="DivBgTopGioHang">
            <asp:Image ID="Image2" runat="server" ImageUrl="~/Images/bgTopThanhtoan.gif" Width="954"
                Height="30" />
        </div>
        <uc3:CtrlCardList ID="CtrlCardList1" runat="server" />
        <table cellpadding="0" cellspacing="0" width="1061px">
            <tr>
                <td width="50%" align="left">
                    <div style="float: left; width: 425px; margin: 10px 0px 0px 15px; height: 240px;">
                        <div class="InformationCustomer">
                            <div class="TitleCaptionInput">
                                <%--thanh toán--%><asp:Literal ID="ltrPay" runat="server"></asp:Literal></div>
                        </div>
                        <div style="float: left; padding-top: 5px;">
                            <div style="float: left; margin: 5px 0px 0px 45px;">
                                <asp:RadioButton ID="rdoMoney" runat="server" AutoPostBack="True" Checked="True"
                                    OnCheckedChanged="rdoMoney_CheckedChanged" /></div>
                            <div style="float: left; font-family: Arial; font-size: 12px; color: #3D3C3C; margin: 8px 0px 0px 5px;
                                width: 350px;">
                                <%--Tiền mặt khi nhận hàng--%><asp:Literal ID="ltrMoneyRecer" runat="server"></asp:Literal></div>
                        </div>
                        <div style="float: left; padding-top: 5px;">
                            <div style="float: left; margin: 5px 0px 0px 45px;">
                                <asp:RadioButton ID="rdoChance" runat="server" AutoPostBack="True" OnCheckedChanged="rdoChance_CheckedChanged" /></div>
                            <div style="float: left; font-family: Arial; font-size: 12px; color: #3D3C3C; margin: 8px 0px 0px 5px;
                                width: 350px;">
                                <%--Chuyển khoản qua ngân hàng--%><asp:Literal ID="ltrTranscer" runat="server"></asp:Literal></div>
                        </div>
                        <div style="float: left; color: #8D8D8D; font-size: 11px; font-family: Arial; margin: 5px 0px 0px 90px;
                            width: 450px;">
                           <%-- Thông tin chuyển khoản:--%><asp:Literal ID="ltrInformationChance" runat="server"></asp:Literal>
                        </div>
                        <div style="float: left; color: #8D8D8D; font-size: 11px; font-family: Arial; margin: 5px 0px 0px 90px;
                            width: 450px;">
                            <%--Chủ tài khoản: Phan Duy Khang--%><asp:Literal ID="ltrChutaikhoan" runat="server"></asp:Literal>
                        </div>
                        <div style="float: left; color: #8D8D8D; font-size: 11px; font-family: Arial; margin: 5px 0px 0px 90px;
                            width: 450px;">
                           <%-- Số tài khoản: 0102555521--%><asp:Literal ID="ltrSotaiKhoan" runat="server"></asp:Literal>
                        </div>
                        <div style="float: left; color: #8D8D8D; font-size: 11px; font-family: Arial; margin: 5px 0px 0px 90px;
                            width: 450px;">
                            <%--Ngân hàng Đông Á - Chi nhánh Đinh Tiên Hoàng--%><asp:Literal ID="ltrChinhanh" runat="server"></asp:Literal>
                        </div>
                        <div style="float: left; padding-top: 5px;">
                            <div style="float: left; margin: 5px 0px 0px 45px;">
                                <asp:CheckBox ID="chkBill" runat="server" /></div>
                            <div style="float: left; font-family: Arial; font-size: 12px; color: #3D3C3C; margin: 8px 0px 0px 5px;
                                width: 350px;">
                                <%--Yêu cầu viết hoá đơn.--%><asp:Literal ID="ltrBillWrite" runat="server"></asp:Literal></div>
                        </div>
                    </div>
                </td>
                <td width="50%" align="right">
                    <div style="float: left; width: 425px; margin: 10px 0px 0px 15px; height: 240px;">
                        <div class="InformationCustomer">
                            <div class="TitleCaptionInput">
                                <%--giao nhận--%><asp:Literal ID="ltrExchange" runat="server"></asp:Literal></div>
                        </div>
                        <div style="float: left; padding-top: 5px;">
                            <div style="float: left; margin: 5px 0px 0px 45px;">
                                <asp:RadioButton ID="rdoPost" runat="server" AutoPostBack="True" OnCheckedChanged="rdoPost_CheckedChanged" /></div>
                            <div style="float: left; font-family: Arial; font-size: 12px; color: #3D3C3C; margin: 8px 0px 0px 5px;
                                width: 350px; text-align: left;">
                                <%--Gửi hàng qua bưu điện--%><asp:Literal ID="ltrbyPost" runat="server"></asp:Literal></div>
                        </div>
                        <div style="float: left; padding-top: 5px;">
                            <div style="float: left; margin: 5px 0px 0px 45px;">
                                <asp:RadioButton ID="rdoAddCustomer" runat="server" AutoPostBack="True" OnCheckedChanged="rdoAddCustomer_CheckedChanged" /></div>
                            <div style="float: left; font-family: Arial; font-size: 12px; color: #3D3C3C; margin: 8px 0px 0px 5px;
                                width: 350px; text-align: left;">
                                <%--Giao hàng tại địa chỉ của quý khách--%><asp:Literal ID="ltrcustomer" runat="server"></asp:Literal></div>
                        </div>
                        <div style="float: left; padding-top: 5px;">
                            <div style="float: left; margin: 5px 0px 0px 45px;">
                                <asp:RadioButton ID="rdoCompany" runat="server" AutoPostBack="True" Checked="True"
                                    OnCheckedChanged="rdoCompany_CheckedChanged" /></div>
                            <div style="float: left; font-family: Arial; font-size: 12px; color: #3D3C3C; margin: 8px 0px 0px 5px;
                                width: 350px; text-align: left;">
                                <%--Nhận hàng tại Big Nose and Littel Toe--%><asp:Literal ID="ltrCompa" runat="server"></asp:Literal></div>
                        </div>
                        <div style="float: left; height: 30px; padding: 55px 0px 0px 0px; text-align: right;">
                            <asp:Button ID="btContinute" runat="server" Text="Tiếp tục" CssClass="buttonInput"
                                OnClick="btContinute_Click" />
                        </div>
                    </div>
                </td>
            </tr>
        </table>
        <uc2:CtrlRandomProduct ID="CtrlRandomProduct1" runat="server" />
        <div class="DivUpHome">
            <div class="testUp">
                <a href="javascript:top.window.scrollTo(0,0)">
                    <asp:Label ID="ltrBacktotop" runat="server" Text="Lên đầu trang" Font-Underline="false"></asp:Label></a></div>
            <div class="ImagesUp">
                <a href="javascript:top.window.scrollTo(0,0)">
                    <asp:Image ID="Image33" runat="server" ImageUrl="~/Images/btlendautrang.gif" /></a></div>
        </div>
    </div>
</asp:Content>
