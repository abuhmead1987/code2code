<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BillInformation.aspx.cs"
    EnableEventValidation="false" Inherits="PGFine.BillInformation" MasterPageFile="~/MasterPageUser/MasterPageUser.Master" %>

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
            <asp:Image ID="Image2" runat="server" ImageUrl="~/Images/detail_thongtinHOADONNguyen.gif"
                Width="954" Height="30" />
        </div>
        <uc3:CtrlCardList ID="CtrlCardList1" runat="server" />
        <table cellpadding="0" cellspacing="0" width="1061px">
            <tr>
                <td width="50%" align="left">
                    <div style="float: left; width: 425px; margin: 10px 0px 0px 15px; height: 220px;">
                        <div class="InformationCustomer">
                            <div class="TitleCaptionInput">
                                <%--thông tin người thanh toán--%><asp:Literal ID="ltrInformationToPay" runat="server"></asp:Literal></div>
                            <div class="hplChanceI">
                                <asp:LinkButton ID="lbtChaceThanh" runat="server" ForeColor="#A4A3A3" OnClick="lbtChaceThanh_Click">Thay đổi</asp:LinkButton>
                            </div>
                        </div>
                        <div style="float: left; margin: 10px 0px 0px 40px; width: 450px;">
                            <div style="font-family: Arial; font-size: 12px; font-weight: bold; float: left;
                                width: 100px;">
                                <%-- Danh xưng:--%><asp:Literal ID="ltrAliasCaption1" runat="server"></asp:Literal>
                            </div>
                            <div style="font-family: Arial; font-size: 12px; float: left; margin-left: 10px;">
                                <asp:Literal ID="ltrDanhXungThanh" runat="server"></asp:Literal>
                            </div>
                        </div>
                        <div style="float: left; margin: 10px 0px 0px 40px; width: 450px;">
                            <div style="font-family: Arial; font-size: 12px; font-weight: bold; float: left;
                                width: 100px;">
                                <%-- Họ và tên:--%>
                                <asp:Literal ID="ltrNameCaption1" runat="server"></asp:Literal>
                            </div>
                            <div style="font-family: Arial; font-size: 12px; float: left; margin-left: 10px;">
                                <asp:Literal ID="ltrNameThanh" runat="server"></asp:Literal>
                            </div>
                        </div>
                        <div style="float: left; margin: 10px 0px 0px 40px; width: 450px;">
                            <div style="font-family: Arial; font-size: 12px; font-weight: bold; float: left;
                                width: 100px;">
                                <%--Quân/Huyện:--%><asp:Literal ID="ltrDicsCaption1" runat="server"></asp:Literal>
                            </div>
                            <div style="font-family: Arial; font-size: 12px; float: left; margin-left: 10px;">
                                <asp:Literal ID="ltrDictThanh" runat="server"></asp:Literal>
                            </div>
                        </div>
                        <div style="float: left; margin: 10px 0px 0px 40px; width: 450px;">
                            <div style="font-family: Arial; font-size: 12px; font-weight: bold; float: left;
                                width: 100px;">
                                <%--Địa chỉ:--%><asp:Literal ID="ltrAddressCaption1" runat="server"></asp:Literal>
                            </div>
                            <div style="font-family: Arial; font-size: 12px; float: left; margin-left: 10px;">
                                <asp:Literal ID="ltrAddressThanh" runat="server"></asp:Literal>
                            </div>
                        </div>
                        <div style="float: left; margin: 10px 0px 0px 40px; width: 450px;">
                            <div style="font-family: Arial; font-size: 12px; font-weight: bold; float: left;
                                width: 100px;">
                                <%-- Điện thoại:--%><asp:Literal ID="ltrPhoneCaption" runat="server"></asp:Literal>
                            </div>
                            <div style="font-family: Arial; font-size: 12px; float: left; margin-left: 10px;">
                                <%--Ông Mr Dam--%>
                                <asp:Literal ID="ltrPhoneThanh" runat="server"></asp:Literal>
                            </div>
                        </div>
                        <div style="float: left; margin: 10px 0px 0px 40px; width: 450px;">
                            <div style="font-family: Arial; font-size: 12px; font-weight: bold; float: left;
                                width: 100px;">
                                <%-- ĐTDĐ:--%><asp:Literal ID="ltrTelCaption" runat="server"></asp:Literal>
                            </div>
                            <div style="font-family: Arial; font-size: 12px; float: left; margin-left: 10px;">
                                <%--Trần Văn Duy--%>
                                <asp:Literal ID="ltrTelThanh" runat="server"></asp:Literal>
                            </div>
                        </div>
                        <div style="float: left; margin: 10px 0px 0px 40px; width: 450px;">
                            <div style="font-family: Arial; font-size: 12px; font-weight: bold; float: left;
                                width: 100px;">
                                Email:
                            </div>
                            <div style="font-family: Arial; font-size: 12px; float: left; margin-left: 10px;">
                                <%--An Giang--%>
                                <asp:Literal ID="ltrEmailThanh" runat="server"></asp:Literal>
                            </div>
                        </div>
                    </div>
                </td>
                <td width="50%" align="right">
                    <div style="float: left; width: 425px; margin: 10px 0px 0px 15px; height: 220px;">
                        <div class="InformationCustomer">
                            <div class="TitleCaptionInput">
                                <%--thông tin người nhận hàng--%><asp:Literal ID="ltrInformtionRecer" runat="server"></asp:Literal></div>
                            <div class="hplChanceI">
                                <asp:LinkButton ID="lbtChaceNhan" runat="server" ForeColor="#A4A3A3" OnClick="lbtChaceNhan_Click">Thay đổi</asp:LinkButton>
                            </div>
                        </div>
                        <div style="float: left; margin: 10px 0px 0px 40px; width: 450px;">
                            <div style="font-family: Arial; font-size: 12px; font-weight: bold; float: left;
                                width: 100px; text-align: left;">
                                <%-- Danh xưng:--%><asp:Literal ID="ltrAliasCaption" runat="server"></asp:Literal>
                            </div>
                            <div style="font-family: Arial; font-size: 12px; float: left; margin-left: 10px;">
                                <%--115 Lê Văn Sỹ--%>
                                <asp:Literal ID="ltrDanhXung" runat="server"></asp:Literal>
                            </div>
                        </div>
                        <div style="float: left; margin: 10px 0px 0px 40px; width: 450px;">
                            <div style="font-family: Arial; font-size: 12px; font-weight: bold; float: left;
                                width: 100px; text-align: left;">
                                <%-- Họ và tên:--%><asp:Literal ID="ltrNameCaption" runat="server"></asp:Literal>
                            </div>
                            <div style="font-family: Arial; font-size: 12px; float: left; margin-left: 10px;">
                                <%--6555655--%>
                                <asp:Literal ID="ltrName" runat="server"></asp:Literal>
                            </div>
                        </div>
                        <div style="float: left; margin: 10px 0px 0px 40px; width: 450px;">
                            <div style="font-family: Arial; font-size: 12px; font-weight: bold; float: left;
                                width: 100px; text-align: left;">
                                <%--Quân/Huyện:--%><asp:Literal ID="ltrDicsCaption" runat="server"></asp:Literal>
                            </div>
                            <div style="font-family: Arial; font-size: 12px; float: left; margin-left: 10px;">
                                <%-- 0321555555--%>
                                <asp:Literal ID="ltrDict" runat="server"></asp:Literal>
                            </div>
                        </div>
                        <div style="float: left; margin: 10px 0px 0px 40px; width: 450px;">
                            <div style="font-family: Arial; font-size: 12px; font-weight: bold; float: left;
                                width: 100px; text-align: left;">
                                <%-- Địa chỉ:--%><asp:Literal ID="lbAddressCaption" runat="server"></asp:Literal>
                            </div>
                            <div style="font-family: Arial; font-size: 12px; float: left; margin-left: 10px;">
                                <%-- duytnc@yahoo.com--%>
                                <asp:Literal ID="ltrAddress" runat="server"></asp:Literal>
                            </div>
                        </div>
                        <div style="float: left; margin: 10px 0px 0px 40px; width: 450px;">
                            <div style="font-family: Arial; font-size: 12px; font-weight: bold; float: left;
                                width: 100px; text-align: left;">
                                <%-- Điện thoại:--%><asp:Literal ID="ltrPhoneCaption1" runat="server"></asp:Literal>
                            </div>
                            <div style="font-family: Arial; font-size: 12px; float: left; margin-left: 10px;">
                                <%--Ông Mr Dam--%>
                                <asp:Literal ID="ltrPhone" runat="server"></asp:Literal>
                            </div>
                        </div>
                        <div style="float: left; margin: 10px 0px 0px 40px; width: 450px;">
                            <div style="font-family: Arial; font-size: 12px; font-weight: bold; float: left;
                                width: 100px; text-align: left;">
                                <%--  ĐTDĐ:--%><asp:Literal ID="ltrTelCaption1" runat="server"></asp:Literal>
                            </div>
                            <div style="font-family: Arial; font-size: 12px; float: left; margin-left: 10px;">
                                <%--Trần Văn Duy--%>
                                <asp:Literal ID="ltrTel" runat="server"></asp:Literal>
                            </div>
                        </div>
                        <div style="float: left; margin: 10px 0px 0px 40px; width: 450px;">
                            <div style="font-family: Arial; font-size: 12px; font-weight: bold; float: left;
                                width: 100px; text-align: left;">
                                Email:
                            </div>
                            <div style="font-family: Arial; font-size: 12px; float: left; margin-left: 10px;">
                                <%-- An Giang--%>
                                <asp:Literal ID="ltrEmail" runat="server"></asp:Literal>
                            </div>
                        </div>
                    </div>
                </td>
            </tr>
            <tr>
                <td width="50%" align="left">
                    <div style="float: left; width: 425px; margin: 10px 0px 0px 15px; height: 200px;">
                        <div class="InformationCustomer">
                            <div class="TitleCaptionInput">
                                <%--phương thức thanh toán--%><asp:Literal ID="ltrPaymentMethod" runat="server"></asp:Literal></div>
                            <div class="hplChanceI">
                                <asp:LinkButton ID="lbtPhuongThuc" runat="server" ForeColor="#A4A3A3" OnClick="lbtPhuongThuc_Click">Thay đổi</asp:LinkButton>
                            </div>
                        </div>
                        <div class="CssThanhToan">
                            <%--115 Lê Văn Sỹ--%>
                            <asp:Literal ID="ltrThanhToanBy" runat="server"></asp:Literal>
                        </div>
                        <div style="float: left; width: 425px; text-align: right; margin: 50px 0px 0px 0px;">
                            <asp:Button ID="btBuy" runat="server" Text="Đặt mua hàng" OnClick="btBuy_Click" />
                        </div>
                        <div style="float: left; width: 425px; text-align: right; margin-top: 20px;">
                            <div style="float: right; font-family: Arial; font-size: 12px; color: #E00303; margin-left: 3px;">
                                <%--"Đặt mua hàng"--%><asp:Literal ID="ltrDatmuahang" runat="server"></asp:Literal></div>
                            <div style="float: right; font-family: Arial; font-size: 12px; color: Black;">
                               <%-- Nếu đồng ý với thông tin trên, hãy nhấn--%><asp:Literal ID="ltrNoteCa" runat="server"></asp:Literal></div>
                        </div>
                    </div>
                </td>
                <td width="50%" align="right">
                    <div style="float: left; width: 425px; margin: 10px 0px 0px 15px; height: 200px;">
                        <div class="InformationCustomer">
                            <div class="TitleCaptionInput">
                                <%--thông tin giao nhận--%><asp:Literal ID="ltrInforGiao" runat="server"></asp:Literal></div>
                            <div class="hplChanceI">
                                <asp:LinkButton ID="lbtGiao" runat="server" ForeColor="#A4A3A3" OnClick="lbtGiao_Click">Thay đổi</asp:LinkButton>
                            </div>
                        </div>
                        <div class="CssThanhToan">
                            <%--6555655--%>
                            <asp:Literal ID="ltrGiaoNhanBy" runat="server"></asp:Literal>
                        </div>
                        <div style="float: left; width: 425px; text-align: left; margin: 50px 0px 0px 0px;">
                            <asp:Button ID="btDeleteBill" runat="server" Text="Xoá thông tin" OnClick="btDeleteBill_Click" />
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
