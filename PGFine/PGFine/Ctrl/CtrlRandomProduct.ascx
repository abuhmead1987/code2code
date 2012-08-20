<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlRandomProduct.ascx.cs"
    Inherits="PGFine.Ctrl.CtrlRandomProduct" %>
<div class="ListImagesProduct">
    <asp:Repeater ID="rptOrtherProduct" runat="server" OnItemDataBound="rptOrtherProduct_ItemDataBound">
        <ItemTemplate>
            <div class="ListOrtherProduct">
                <div>
                    <asp:HyperLink ID="hplDetailOrther" runat="server">
                        <asp:Image ID="imaImageOrther" runat="server" ImageUrl="~/Images/listImagesOrther.gif"
                            Width="84" Height="137" />
                    </asp:HyperLink>
                </div>
                <div class="ListProductName">
                    <%-- Hold Your Han--%><asp:HyperLink ID="hplNameProduct" runat="server" CssClass="ListProductNamehpl"></asp:HyperLink>
                </div>
                <div class="ListPriceDetailt">
                    <%--120.000 VND--%>
                    <asp:Literal ID="ltrPrice" runat="server"></asp:Literal>
                </div>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</div>
<asp:Label ID="_errorLabel" runat="server" Text="Label" Visible="false"></asp:Label>