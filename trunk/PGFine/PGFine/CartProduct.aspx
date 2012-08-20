<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CartProduct.aspx.cs" MasterPageFile="~/MasterPageUser/MasterPageUser.Master"
    Inherits="PGFine.CartProduct" EnableEventValidation="false" %>

<%@ Register Src="Ctrl/CtrlMainBanner.ascx" TagName="CtrlMainBanner" TagPrefix="uc1" %>
<%@ Register Src="Ctrl/CtrlRandomProduct.ascx" TagName="CtrlRandomProduct" TagPrefix="uc2" %>
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
            <asp:Image ID="Image2" runat="server" ImageUrl="~/Images/bgTopGioHangNguyen.gif"
                Width="954" Height="30" />
        </div>
        <div style="float: left; border: solid 1px #CFCFCF; width: 953px; height: 35px; font-family: Arial;
            background-color: #FDE0EA; font-size: 12px; margin-left: 15px;">
            <div style="float: left; height: 25px; width: 44px; border-right: solid 1px #CFCFCF;
                text-align: center; padding: 10px 0px 10px 0px;">
                <%--Xoá--%><asp:Literal ID="ltrDelete" runat="server"></asp:Literal></div>
            <div style="float: left; height: 25px; width: 121px; border-right: solid 1px #CFCFCF;
                text-align: center; padding: 10px 0px 10px 0px;">
                <%--Hình ảnh--%><asp:Literal ID="ltrImages" runat="server"></asp:Literal></div>
            <div style="float: left; height: 25px; width: 240px; border-right: solid 1px #CFCFCF;
                text-align: center; padding: 10px 0px 10px 0px;">
               <%-- Tên sản phẩm--%><asp:Literal ID="ltrProductName" runat="server"></asp:Literal></div>
            <div style="float: left; height: 25px; width: 104px; border-right: solid 1px #CFCFCF;
                text-align: center; padding: 10px 0px 10px 0px;">
                <%--Mã sản phẩm--%><asp:Literal ID="ltrNameCode" runat="server"></asp:Literal></div>
            <div style="float: left; height: 25px; width: 56px; border-right: solid 1px #CFCFCF;
                text-align: center; padding: 10px 0px 10px 0px;">
               <%-- Kích cỡ--%><asp:Literal ID="ltrZise" runat="server"></asp:Literal></div>
            <div style="float: left; height: 25px; width: 102px; border-right: solid 1px #CFCFCF;
                text-align: center; padding: 10px 0px 10px 0px;">
                <%--Màu sắc--%><asp:Literal ID="ltrColor" runat="server"></asp:Literal></div>
            <div style="float: left; height: 25px; width: 80px; border-right: solid 1px #CFCFCF;
                text-align: center; padding: 10px 0px 10px 0px;">
                <%--Số lượng--%><asp:Literal ID="ltrNumber" runat="server"></asp:Literal></div>
            <div style="float: left; height: 25px; width: 90px; border-right: solid 1px #CFCFCF;
                text-align: center; padding: 10px 0px 10px 0px;">
                <%--đong giá--%><asp:Literal ID="ltrPrice" runat="server"></asp:Literal></div>
            <div style="float: left; height: 25px; width: 100px; text-align: center; padding: 10px 0px 10px 0px;">
               <%-- Thành tiền--%><asp:Literal ID="ltrMoney" runat="server"></asp:Literal></div>
        </div>
        <asp:Repeater ID="mylist" runat="server">
            <ItemTemplate>
                <div style="float: left; border: solid 1px #CFCFCF; width: 953px; height: 89px; font-family: Arial;
                    font-size: 12px; margin-left: 15px;">
                    <div style="float: left; height: 89px; width: 38px; border-right: solid 1px #CFCFCF;
                        text-align: center; padding: 3px;">
                        <asp:CheckBox ID="Remove" runat="server" /></div>
                    <div style="float: left; height: 89px; width: 115px; border-right: solid 1px #CFCFCF;
                        text-align: center; padding: 3px;">
                        <asp:Image ID="Image1" runat="server" Width="45" Height="76" ImageUrl='<%# DataBinder.Eval(Container.DataItem,"ImagesPath")%>' /></div>
                    <div style="float: left; height: 89px; width: 234px; border-right: solid 1px #CFCFCF;
                        text-align: left; padding: 3px;">
                        <%#DataBinder.Eval(Container.DataItem,"Ten")%></div>
                    <div style="float: left; height: 89px; width: 98px; border-right: solid 1px #CFCFCF;
                        text-align: center; padding: 3px;">
                        <asp:Label ID="Ma_sach" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"CodeProduct")%>'></asp:Label>
                        <asp:HiddenField ID="hdIDProduct" runat="server" Value='<%#DataBinder.Eval(Container.DataItem,"Ma")%>' />
                    </div>
                    <div style="float: left; height: 89px; width: 50px; border-right: solid 1px #CFCFCF;
                        text-align: center; padding: 3px;">
                        <%#DataBinder.Eval(Container.DataItem, "KichCo")%></div>
                    <div style="float: left; height: 89px; width: 96px; border-right: solid 1px #CFCFCF;
                        text-align: center; padding: 3px;">
                        <asp:Literal ID="Literal1" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"ImagesColor") %>'></asp:Literal></div>
                    <div style="float: left; height: 89px; width: 74px; border-right: solid 1px #CFCFCF;
                        text-align: center; padding: 3px;">
                        <asp:TextBox ID="txtNumber" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Luong") %>'
                            Width="24px" CssClass="TextBoxNum"></asp:TextBox></div>
                    <div style="float: left; height: 89px; width: 84px; border-right: solid 1px #CFCFCF;
                        text-align: center; padding: 3px;">
                        <%#string.Format("{0:C}", (double)DataBinder.Eval(Container.DataItem, "Gia"))%></div>
                    <div style="float: left; height: 89px; width: 100px; text-align: center; padding: 3px;">
                        <%#string.Format("{0:C}",(((int)DataBinder.Eval(Container.DataItem,"Luong"))*((double)DataBinder.Eval(Container.DataItem,"Gia")))) %></div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
        <div style="float: left; border: solid 1px #CFCFCF; width: 948px; height: 25px; font-family: Arial;
            background-color: #FDE0EA; font-size: 12px; margin-left: 15px; text-align: right;
            padding: 10px 5px 0px 0px;">
            <%--Tổng tiền:--%><asp:Literal ID="ltrSummoney" runat="server"></asp:Literal>
            <asp:Label ID="totalPrice" runat="server" Text=""></asp:Label>
        </div>
        <div style="float: left; width: 953px; margin-left: 15px; padding: 15px 0px 30px 0px;">
            <div style="float: left; width: 653px">
                <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Tiếp tục mua"
                    Width="130px" />
            </div>
            <div style="float: left; width: 150px; text-align: right;">
                <asp:Button ID="btUpdate" runat="server" OnClick="btUpdate_Click" PostBackUrl="~/CartProduct.aspx"
                    Text="Cập nhật giỏ hàng" Width="130px" />
            </div>
            <div style="float: left; width: 150px; text-align: right;">
                <asp:Button ID="btBuyCont" runat="server" OnClick="btBuyCont_Click" Text="Đặt hàng"
                    Width="130px" />
            </div>
        </div>
        <table align="center" cellpadding="0" cellspacing="0" width="953">
            <tr>
                <td style="height: 97px">
                </td>
                <td align="center" style="height: 97px">
                    <p align="justify" style="margin-top: 5px; margin-bottom: 5px">
                        <font face="Arial" style="font-size: 11px; color: #737373;"><%--+ Trên đây là các mặt hàng
                            đã có trong giỏ, bạn có thể thay đổi số lượng của từng sản phẩm, nếu muốn loại bỏ
                            một sản phẩm nào đó chọn số lượng là 0 hay xóa bỏ ô số lượng tương ứng (hoặc là
                            bạn có thể nhấp chuột vào ô vuông ngay cột xóa ), sau đó nhấn vào--%>
                            <asp:Literal ID="ltrCondition" runat="server"></asp:Literal> <b style="color: Black;">
                               <%-- Cập nhật giỏ hàng--%><asp:Literal ID="ltrUpdateCard" runat="server"></asp:Literal></b>. </font>
                    </p>
                    <p align="justify" style="margin-top: 5px; margin-bottom: 5px">
                        <font face="Arial" style="font-size: 11px; color: #737373;"><%--+ Sau khi đã lựa chọn xong
                            các sản phẩm, bạn hãy chọn--%><asp:Literal ID="ltrCondition1" runat="server"></asp:Literal> <b style="color: Black;"><%--Đặt hàng--%>
                            <asp:Literal ID="ltrBuyRoduct" runat="server"></asp:Literal></b> <%--để tiếp tục công
                            việc mua bán.--%> <asp:Literal ID="ltrCondition2" runat="server"></asp:Literal></font>
                    </p>
                    <p align="justify" style="margin-top: 5px; margin-bottom: 5px">
                        <font face="Arial" style="font-size: 11px; color: #737373;"><%--+ Để quay lại mua sản phẩm
                            khác, bạn chọn--%> <asp:Literal ID="ltrCondition3" runat="server"></asp:Literal>
                            <b style="color: Black;"><%--Tiếp tục mua hàng--%><asp:Literal ID="ltrBuyc" runat="server"></asp:Literal></b>. </font>
                    </p>
                    <p align="justify" style="margin-top: 5px; margin-bottom: 5px">
                        <font face="Arial" style="font-size: 11px; color: #737373;"><%--+ Nếu không muốn mua các
                            sản phẩm này, bạn chọn tất cả các ô checkbox rồi chọn--%><asp:Literal ID="ltrCondition4" runat="server"></asp:Literal>
                             <b style="color: Black;"><%--Cập nhật
                                giỏ hàng--%><asp:Literal ID="ltrupdatec" runat="server"></asp:Literal></b>.</font>
                    </p>
                    <p align="justify" style="margin-top: 5px; margin-bottom: 5px">
                        <font face="Arial" style="font-size: 9pt"></font>
                    </p>
                </td>
                <td style="height: 97px">
                </td>
            </tr>
        </table>
        <uc2:CtrlRandomProduct ID="CtrlRandomProduct1" runat="server" />
        <div class="DivUpHome">
            <div class="testUp">
                <a href="javascript:top.window.scrollTo(0,0)">
                    <asp:Label ID="lbBacktotop" runat="server" Text="Lên đầu trang" Font-Underline="false"></asp:Label></a></div>
            <div class="ImagesUp">
                <a href="javascript:top.window.scrollTo(0,0)">
                    <asp:Image ID="Image33" runat="server" ImageUrl="~/Images/btlendautrang.gif" /></a></div>
        </div>
    </div>
</asp:Content>
