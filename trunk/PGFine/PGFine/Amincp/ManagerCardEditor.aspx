<%@ Page Language="C#" AutoEventWireup="true" ValidateRequest="false" MasterPageFile="~/Amincp/MP/MasterPageAdmin.Master"
    CodeBehind="ManagerCardEditor.aspx.cs" Inherits="PGFine.Amincp.ManagerCardEditor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="float: left; width: 940px; height: 800px; margin: 20px 0px 0px 30px;">
        <div style="float: left; text-align: center; width: 940px; font-size: 12px; font-weight: bold;
            color: Blue;">
            THÔNG TIN HOÁ ĐƠN
        </div>
        <div style="float: left; width: 940px;">
            <div style="float: left; padding: 10px 0px 10px 0px; font-size: 12px; font-weight: bold;">
                Danh sách sản phẩm</div>
            <div>
                <div style="float: left; border: solid 1px #CFCFCF; width: 933px; height: 35px; font-family: Arial;
                    background-color: #FDE0EA; font-size: 12px;">
                    <div style="float: left; height: 25px; width: 121px; border-right: solid 1px #CFCFCF;
                        text-align: center; padding: 10px 0px 10px 0px;">
                        Hình ảnh</div>
                    <div style="float: left; height: 25px; width: 240px; border-right: solid 1px #CFCFCF;
                        text-align: center; padding: 10px 0px 10px 0px;">
                        Tên sản phẩm</div>
                    <div style="float: left; height: 25px; width: 104px; border-right: solid 1px #CFCFCF;
                        text-align: center; padding: 10px 0px 10px 0px;">
                        Mã sản phẩm</div>
                    <div style="float: left; height: 25px; width: 56px; border-right: solid 1px #CFCFCF;
                        text-align: center; padding: 10px 0px 10px 0px;">
                        Kích cỡ</div>
                    <div style="float: left; height: 25px; width: 102px; border-right: solid 1px #CFCFCF;
                        text-align: center; padding: 10px 0px 10px 0px;">
                        Màu sắc</div>
                    <div style="float: left; height: 25px; width: 80px; border-right: solid 1px #CFCFCF;
                        text-align: center; padding: 10px 0px 10px 0px;">
                        Số lượng</div>
                    <div style="float: left; height: 25px; width: 90px; border-right: solid 1px #CFCFCF;
                        text-align: center; padding: 10px 0px 10px 0px;">
                        Đơn giá</div>
                    <div style="float: left; height: 25px; width: 80px; text-align: center; padding: 10px 0px 10px 0px;">
                        Thành tiền</div>
                </div>
                <asp:Repeater ID="mylist" runat="server">
                    <ItemTemplate>
                        <div style="float: left; border: solid 1px #CFCFCF; width: 933px; height: 89px; font-family: Arial;
                            font-size: 12px;">
                            <div style="float: left; height: 89px; width: 115px; border-right: solid 1px #CFCFCF;
                                text-align: center; padding: 3px;">
                                <asp:Image ID="Image1" runat="server" Width="45" Height="76" ImageUrl='<%# DataBinder.Eval(Container.DataItem,"ImagesProduct")%>' /></div>
                            <div style="float: left; height: 89px; width: 234px; border-right: solid 1px #CFCFCF;
                                text-align: left; padding: 3px;">
                                <%#DataBinder.Eval(Container.DataItem, "NameProduct")%></div>
                            <div style="float: left; height: 89px; width: 98px; border-right: solid 1px #CFCFCF;
                                text-align: center; padding: 3px;">
                                <asp:Label ID="Ma_sach" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"CodeProduct")%>'></asp:Label>
                            </div>
                            <div style="float: left; height: 89px; width: 50px; border-right: solid 1px #CFCFCF;
                                text-align: center; padding: 3px;">
                                <%#DataBinder.Eval(Container.DataItem, "Size")%></div>
                            <div style="float: left; height: 89px; width: 96px; border-right: solid 1px #CFCFCF;
                                text-align: center; padding: 3px;">
                                <asp:Literal ID="Literal1" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Color") %>'></asp:Literal></div>
                            <div style="float: left; height: 89px; width: 74px; border-right: solid 1px #CFCFCF;
                                text-align: center; padding: 3px;">
                                <asp:TextBox ID="txtNumber" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Number") %>'
                                    Width="24px" CssClass="TextBoxNum"></asp:TextBox></div>
                            <div style="float: left; height: 89px; width: 84px; border-right: solid 1px #CFCFCF;
                                text-align: center; padding: 3px;">
                                <%#DataBinder.Eval(Container.DataItem, "Price")%></div>
                            <div style="float: left; height: 89px; width: 80px; text-align: center; padding: 3px;">
                                <%#DataBinder.Eval(Container.DataItem, "SumMoney")%></div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
                <div style="float: left; border: solid 1px #CFCFCF; width: 928px; height: 25px; font-family: Arial;
                    background-color: #FDE0EA; font-size: 12px; text-align: right; padding: 10px 5px 0px 0px;">
                    Tổng tiền:
                    <asp:Label ID="totalPrice" runat="server" Text=""></asp:Label>
                </div>
            </div>
        </div>
        <div style="float: left; width: 940px;">
            <div style="float: left; padding: 10px 0px 10px 0px; font-size: 12px; font-weight: bold;">
                Thông tin Khách hàng</div>
            <table cellpadding="0" cellspacing="0" width="940px">
                <tr>
                    <td width="65%" align="left">
                        <div style="float: left; width: 425px; margin: 10px 0px 0px 0px; height: 220px;">
                            <div class="InformationCustomer">
                                <div class="TitleCaptionInput">
                                    thông tin người thanh toán</div>
                            </div>
                            <div style="float: left; margin: 10px 0px 0px 40px; width: 450px;">
                                <div style="font-family: Arial; font-size: 12px; font-weight: bold; float: left;
                                    width: 100px;">
                                    Danh xưng:
                                </div>
                                <div style="font-family: Arial; font-size: 12px; float: left; margin-left: 10px;">
                                    <asp:Literal ID="ltrDanhXungThanh" runat="server"></asp:Literal>
                                </div>
                            </div>
                            <div style="float: left; margin: 10px 0px 0px 40px; width: 450px;">
                                <div style="font-family: Arial; font-size: 12px; font-weight: bold; float: left;
                                    width: 100px;">
                                    Họ và tên:
                                </div>
                                <div style="font-family: Arial; font-size: 12px; float: left; margin-left: 10px;">
                                    <asp:Literal ID="ltrNameThanh" runat="server"></asp:Literal>
                                </div>
                            </div>
                            <div style="float: left; margin: 10px 0px 0px 40px; width: 450px;">
                                <div style="font-family: Arial; font-size: 12px; font-weight: bold; float: left;
                                    width: 100px;">
                                    Quân/Huyện:
                                </div>
                                <div style="font-family: Arial; font-size: 12px; float: left; margin-left: 10px;">
                                    <asp:Literal ID="ltrDictThanh" runat="server"></asp:Literal>
                                </div>
                            </div>
                            <div style="float: left; margin: 10px 0px 0px 40px; width: 450px;">
                                <div style="font-family: Arial; font-size: 12px; font-weight: bold; float: left;
                                    width: 100px;">
                                    Địa chỉ:
                                </div>
                                <div style="font-family: Arial; font-size: 12px; float: left; margin-left: 10px;">
                                    <asp:Literal ID="ltrAddressThanh" runat="server"></asp:Literal>
                                </div>
                            </div>
                            <div style="float: left; margin: 10px 0px 0px 40px; width: 450px;">
                                <div style="font-family: Arial; font-size: 12px; font-weight: bold; float: left;
                                    width: 100px;">
                                    Điện thoại:
                                </div>
                                <div style="font-family: Arial; font-size: 12px; float: left; margin-left: 10px;">
                                    <%--Ông Mr Dam--%>
                                    <asp:Literal ID="ltrPhoneThanh" runat="server"></asp:Literal>
                                </div>
                            </div>
                            <div style="float: left; margin: 10px 0px 0px 40px; width: 450px;">
                                <div style="font-family: Arial; font-size: 12px; font-weight: bold; float: left;
                                    width: 100px;">
                                    ĐTDĐ:
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
                    <td width="35%" align="right">
                        <div style="float: left; width: 425px; margin: 10px 0px 0px 0px; height: 220px;">
                            <div class="InformationCustomer">
                                <div class="TitleCaptionInput">
                                    thông tin người nhận hàng</div>
                            </div>
                            <div style="float: left; margin: 10px 0px 0px 40px; width: 450px;">
                                <div style="font-family: Arial; font-size: 12px; font-weight: bold; float: left;
                                    width: 100px; text-align: left;">
                                    Danh xưng:
                                </div>
                                <div style="font-family: Arial; font-size: 12px; float: left; margin-left: 10px;">
                                    <%--115 Lê Văn Sỹ--%>
                                    <asp:Literal ID="ltrDanhXung" runat="server"></asp:Literal>
                                </div>
                            </div>
                            <div style="float: left; margin: 10px 0px 0px 40px; width: 450px;">
                                <div style="font-family: Arial; font-size: 12px; font-weight: bold; float: left;
                                    width: 100px; text-align: left;">
                                    Họ và tên:
                                </div>
                                <div style="font-family: Arial; font-size: 12px; float: left; margin-left: 10px;">
                                    <%--6555655--%>
                                    <asp:Literal ID="ltrName" runat="server"></asp:Literal>
                                </div>
                            </div>
                            <div style="float: left; margin: 10px 0px 0px 40px; width: 450px;">
                                <div style="font-family: Arial; font-size: 12px; font-weight: bold; float: left;
                                    width: 100px; text-align: left;">
                                    Quân/Huyện:
                                </div>
                                <div style="font-family: Arial; font-size: 12px; float: left; margin-left: 10px;">
                                    <%-- 0321555555--%>
                                    <asp:Literal ID="ltrDict" runat="server"></asp:Literal>
                                </div>
                            </div>
                            <div style="float: left; margin: 10px 0px 0px 40px; width: 450px;">
                                <div style="font-family: Arial; font-size: 12px; font-weight: bold; float: left;
                                    width: 100px; text-align: left;">
                                    Địa chỉ:
                                </div>
                                <div style="font-family: Arial; font-size: 12px; float: left; margin-left: 10px;">
                                    <%-- duytnc@yahoo.com--%>
                                    <asp:Literal ID="ltrAddress" runat="server"></asp:Literal>
                                </div>
                            </div>
                            <div style="float: left; margin: 10px 0px 0px 40px; width: 450px;">
                                <div style="font-family: Arial; font-size: 12px; font-weight: bold; float: left;
                                    width: 100px; text-align: left;">
                                    Điện thoại:
                                </div>
                                <div style="font-family: Arial; font-size: 12px; float: left; margin-left: 10px;">
                                    <%--Ông Mr Dam--%>
                                    <asp:Literal ID="ltrPhone" runat="server"></asp:Literal>
                                </div>
                            </div>
                            <div style="float: left; margin: 10px 0px 0px 40px; width: 450px;">
                                <div style="font-family: Arial; font-size: 12px; font-weight: bold; float: left;
                                    width: 100px; text-align: left;">
                                    ĐTDĐ:
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
                    <td width="65%" align="left">
                        <div style="float: left; width: 425px; margin: 10px 0px 0px 0px; height: 150px;">
                            <div class="InformationCustomer">
                                <div class="TitleCaptionInput">
                                    phương thức thanh toán</div>
                            </div>
                            <div class="CssThanhToan">
                                <%--115 Lê Văn Sỹ--%>
                                <asp:Literal ID="ltrThanhToanBy" runat="server"></asp:Literal>
                            </div>
                            <div style="float: left; padding-top: 35px; width: 425px;">
                                <div style="float: left; margin: 5px 0px 0px 0px;">
                                    <asp:CheckBox ID="chkBill" runat="server" /></div>
                                <div style="float: left; font-family: Arial; font-size: 12px; color: #3D3C3C; margin: 8px 0px 0px 5px;
                                    width: 350px;">
                                    Yêu cầu viết hoá đơn.</div>
                            </div>
                        </div>
                    </td>
                    <td width="35%" align="right">
                        <div style="float: left; width: 425px; margin: 10px 0px 0px 0px; height: 150px;">
                            <div class="InformationCustomer">
                                <div class="TitleCaptionInput">
                                    thông tin giao nhận</div>
                            </div>
                            <div class="CssThanhToan">
                                <%--6555655--%>
                                <asp:Literal ID="ltrGiaoNhanBy" runat="server"></asp:Literal>
                            </div>
                        </div>
                    </td>
                </tr>
            </table>
        </div>
        <div style="float: left; width: 940px;padding:0px 0px 20px 0px;">
            <div style="float:left;font-size:12px;font-weight:bold;padding-right:10px;padding-top:2px;">
                Trạng thái hoá đơn:</div>
            <div>
                <asp:DropDownList ID="dropStatus" runat="server">
                    <asp:ListItem Value="1">Chưa xem</asp:ListItem>
                    <asp:ListItem Value="0">Đã xem</asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>
        <div style="float: left; width: 940px;">
            <asp:Button ID="btUpdate" runat="server" Text="Cập nhật trạng thái" OnClick="btUpdate_Click" />
            <asp:Button ID="btBack" runat="server" Text="Trở về" OnClick="btBack_Click" />
        </div>
    </div>
</asp:Content>
