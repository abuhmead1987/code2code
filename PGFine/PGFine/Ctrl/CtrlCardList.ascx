<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlCardList.ascx.cs"
    Inherits="PGFine.Ctrl.CtrlCardList" %>
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
