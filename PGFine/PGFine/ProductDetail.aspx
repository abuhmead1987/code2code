<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProductDetail.aspx.cs"
    MasterPageFile="~/MasterPageUser/MasterPageUser.Master" Inherits="PGFine.ProductDetail"
    EnableEventValidation="false" MaintainScrollPositionOnPostback="true" %>

<%@ Register Src="Ctrl/CtrlMainBanner.ascx" TagName="CtrlMainBanner" TagPrefix="uc1" %>
<%@ Register Src="Ctrl/CtrlRandomProduct.ascx" TagName="CtrlRandomProduct" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="_errorLabel" runat="server" Visible="false"></asp:Label>
    <uc1:CtrlMainBanner ID="CtrlMainBanner1" runat="server" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="Pageging">
        <asp:Label ID="lbBreakrum" runat="server" Text="men" CssClass="Breakrum"></asp:Label>
    </div>
    <div class="ListProduct">
        <table cellpadding="0" cellspacing="0">
            <tr>
                <td colspan="3">
                    <div class="TitleDetailProduct">
                        <asp:Label ID="lbNameProduct" runat="server" Text="Happiness, Like helium"></asp:Label>
                        <asp:Label ID="Label6" runat="server" Text="(code: M100831)" CssClass="CodeProduct"></asp:Label>
                    </div>
                </td>
            </tr>
            <tr>
                <td valign="top">
                    <asp:PlaceHolder ID="htmlRender" runat="server">
                        <div class="MainDetail">
                            <%--Images detail main--%>
                            <div style="float: left; width: 460px;">
                                <div class="ImagesMainDetail">
                                    <asp:Literal ID="ltrMain" runat="server"></asp:Literal>
                                </div>
                                <div class="VoteDivMain">
                                    <div class="VoteTitle">
                                        <asp:HyperLink ID="hplVote" runat="server" CssClass="VoteTitle1" NavigateUrl="javascript:void(0);"
                                            Font-Underline="false">Vote:</asp:HyperLink>
                                    </div>
                                    <div class="ImagesVote">
                                        <asp:Literal ID="ltrVote" runat="server"></asp:Literal></div>
                                    <div class="SumVote">
                                        <asp:Literal ID="ltrSumVote" runat="server" Text="23/10"></asp:Literal>
                                    </div>
                                    <div class="CationVote">
                                        <asp:Literal ID="ltrCaptionVote" runat="server" Text="(<strong>10</strong> phiếu)"></asp:Literal>
                                    </div>
                                </div>
                            </div>
                            <div class="ImagesThumsListDe">
                                <div class="ListImagesThumb">
                                    <asp:Literal ID="ltrImageThums" runat="server"></asp:Literal>
                                </div>
                                <div class="ListImagesThumb">
                                    <asp:Literal ID="ltrImageThums1" runat="server"></asp:Literal>
                                </div>
                                <div class="ListImagesThumb">
                                    <asp:Literal ID="ltrImageThums2" runat="server"></asp:Literal>
                                </div>
                                <div class="ListImagesThumb">
                                    <asp:Literal ID="ltrImageThums3" runat="server"></asp:Literal>
                                </div>
                            </div>
                        </div>
                    </asp:PlaceHolder>
                </td>
                <td valign="top">
                    <div class="MainDetailMid">
                        <div class="TitleCaptionDetail">
                            <asp:Label ID="lbInformationP" runat="server" Text="Thông tin sản phẩm"></asp:Label>
                        </div>
                        <div class="bgMidTitleCaption">
                            <div class="lbShortDescription">
                                <div class="TitleCorlor">
                                    <%--Mô tả:--%>
                                    <asp:Literal ID="lbDescription" runat="server"></asp:Literal></div>
                                <div class="ShortDeProduct">
                                    <asp:Literal ID="ltrShortDescription" runat="server"></asp:Literal>
                                    <%-- Coton 100% vai nguyên chất giá thành hợp lý phải chăng--%></div>
                            </div>
                            <div class="lbShortDescription">
                                <div class="TitleCorlor">
                                    Size:</div>
                                <div class="ShortDeProduct">
                                    <asp:Literal ID="ltrDescription" runat="server"></asp:Literal>
                                    <%--X/XXL/MXL--%>
                                </div>
                            </div>
                            <div class="bgMidIconCorlor">
                                <div class="TitleCorlor">
                                    <%--Màu sắc:--%><asp:Literal ID="ltrColorD" runat="server"></asp:Literal>
                                    </div>
                                <asp:Repeater ID="rptColor" runat="server" OnItemDataBound="rptColor_ItemDataBound">
                                    <ItemTemplate>
                                        <div class="ImagesCorlor">
                                            <asp:ImageButton ID="imgColorButton" runat="server" OnCommand="imgbtImages_Command" />
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>
                            <div class="ClickCaptionProduct">
                                <%--(Click vào ô màu để xem chi tiết sản phẩm)--%>
                                <asp:Literal ID="ltrColorView" runat="server"></asp:Literal>
                                </div>
                            <div class="bgMidIconCorlor">
                                <div class="TitleCorlor">
                                    <%--Giá:--%>
                                    <asp:Literal ID="ltrPriceD" runat="server"></asp:Literal>
                                    
                                </div>
                                <div class="PriceDetailOld" runat="server" id="DivPrice">
                                    <%--  1.2000.000 VND--%>
                                    <asp:Literal ID="ltrPriceOld" runat="server"></asp:Literal>
                                </div>
                            </div>
                            <div class="bgMidIconCorlor">
                                <div class="TitleCorlor">
                                    <%--Giá khuyến mãi:--%><asp:Literal ID="ltrCaptionPromo" runat="server"></asp:Literal>
                                </div>
                                <div class="PriceDetail">
                                    <asp:Literal ID="ltrPrice" runat="server"></asp:Literal>
                                    <%-- 90.000 VND--%>
                                </div>
                            </div>
                            <div class="bgMidIconCorlor">
                                <div class="TitleCorlor">
                                    <%--Tình trạng:--%>
                                    <asp:Literal ID="ltrSatus" runat="server"></asp:Literal>
                                </div>
                                <div class="ColorStatus">
                                    <asp:Literal ID="ltrStatus" runat="server"></asp:Literal>
                                    <%--Còn hàng--%>
                                </div>
                            </div>
                            <div class="TitleCaptionBuyDetail">
                                <asp:Label ID="lbBuyProduct" runat="server" Text="đặt hàng sản phẩm"></asp:Label>
                            </div>
                            <div class="ChoseSize">
                                <%--Chọn size:--%><asp:Literal ID="ltrSizeD" runat="server"></asp:Literal></div>
                            <div class="bgMidIconCorlor">
                                <asp:RadioButtonList ID="rdoListSize" runat="server" RepeatDirection="Horizontal"
                                    CssClass="rdoSizeCss" RepeatLayout="Flow">
                                    <asp:ListItem>S</asp:ListItem>
                                    <asp:ListItem>M</asp:ListItem>
                                    <asp:ListItem>X</asp:ListItem>
                                    <asp:ListItem>XL</asp:ListItem>
                                </asp:RadioButtonList>
                                <asp:Label ID="lbWarmingSize" runat="server" Text="(*)Chọn size" CssClass="ValidateSize"
                                    Visible="false"></asp:Label>
                            </div>
                            <div class="ChoseSize">
                                <%--Chọn màu:--%><asp:Literal ID="ltrChoseColorC" runat="server"></asp:Literal>
                                </div>
                            <div style="float: left; padding: 5px 0px 10px 0px;">
                                <asp:Repeater ID="rptListColorBuy" runat="server" OnItemDataBound="rptListColorBuy_ItemDataBound">
                                    <ItemTemplate>
                                        <div class="ChoseColor">
                                            <asp:Image ID="imgImgesIconBuy" runat="server" ImageUrl="~/Images/icon_mauden.gif"
                                                CssClass="ImagesChoseColor" />
                                            <asp:CheckBox ID="chkColorBuy" runat="server" CssClass="CheckChoseColor" />
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>
                            <div class="ChoseSize">
                                <%--Nhập số lượng:--%>
                                <asp:Literal ID="ltrInputNumber" runat="server"></asp:Literal>
                            </div>
                            <asp:TextBox ID="txtNumber" runat="server" CssClass="textNumber" ValidationGroup="CheckNumber"></asp:TextBox>
                            <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="*Kiểu số"
                                Display="Dynamic" CssClass="ValidateNum" ClientValidationFunction="validateOrderNo1"
                                ValidationGroup="CheckNumber"></asp:CustomValidator>
                            <div class="ChoseSize">
                                <div class="DivBuy">
                                    <asp:Button ID="btBuyProduct" runat="server" Text="Đặt hàng" CssClass="BtBuyProduct"
                                        OnClick="btBuyProduct_Click" ValidationGroup="CheckNumber" />
                                </div>
                            </div>
                            <%--end colum--%>
                        </div>
                    </div>
                </td>
                <td valign="top">
                    <div class="LeftMainDetail">
                        <div class="MainleftProduct">
                            <asp:Label ID="lbUtiliti" runat="server" Text="Tiện ích"></asp:Label>
                        </div>
                        <div class="DivPrintWidth">
                            <div class="ImagesCaptionPrint">
                                <asp:Image ID="Image24" runat="server" ImageUrl="~/Images/print.gif" /></div>
                            <div class="PrintCaption">
                                <asp:LinkButton ID="lbtPrint" runat="server" CssClass="TextPrintDetail">In trang này</asp:LinkButton>
                            </div>
                        </div>
                        <div class="DivPrintWidth">
                            <div class="ImagesCaptionPrint">
                                <asp:Image ID="Image25" runat="server" ImageUrl="~/Images/ContactYou.gif" /></div>
                            <div class="PrintCaption">
                                <asp:HyperLink ID="hplIntroduct" runat="server" NavigateUrl="javascript:void(0);"
                                    CssClass="TextPrintDetail">Giới thiệu bạn bè</asp:HyperLink>
                            </div>
                        </div>
                        <div class="DivPrintWidth">
                            <div class="ImagesCaptionPrint">
                                <asp:Image ID="Image26" runat="server" ImageUrl="~/Images/guiphanhoi.gif" /></div>
                            <div class="PrintCaption">
                                <asp:HyperLink ID="hplSendAdmin" runat="server" NavigateUrl="javascript:void(0);"
                                    CssClass="TextPrintDetail">Gửi phản hồi</asp:HyperLink>
                            </div>
                        </div>
                        <asp:Repeater ID="rptMenuDetailProduct" runat="server" OnItemDataBound="rptMenuDetailProduct_ItemDataBound">
                            <ItemTemplate>
                                <div class="DivPrintWidth">
                                    <div class="ImagesCaptionPrint">
                                        <asp:Image ID="Image27" runat="server" ImageUrl="~/Images/banggia.gif" /></div>
                                    <div class="PrintCaption">
                                        <asp:HyperLink ID="hplMenuTop" runat="server" CssClass="TextPrintDetail"></asp:HyperLink>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <uc2:CtrlRandomProduct ID="CtrlRandomProduct1" runat="server" />
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <div class="DivUpHome">
                        <div class="testUp">
                            <a href="javascript:top.window.scrollTo(0,0)">
                                <asp:Label ID="lbBacktoTop" runat="server" Font-Underline="false"></asp:Label></a></div>
                        <div class="ImagesUp">
                            <a href="javascript:top.window.scrollTo(0,0)">
                                <asp:Image ID="Image33" runat="server" ImageUrl="~/Images/btlendautrang.gif" /></a></div>
                    </div>
                </td>
            </tr>
        </table>
    </div>
    <asp:HiddenField ID="hdImagesPathCurrent" runat="server" />
    <asp:HiddenField ID="hdColor" runat="server" />

    <script type="text/javascript" language="javascript">  
function validateOrderNo(pathImages){
     var image;
     image=document.getElementById('imgMain');
     if (image) 
     {        
        image.src=pathImages;
     }
 } 
 function validateOrderNo1(oSrc, args){
    var isHasFile = false;          
    var txtOrderNo = $get('<%=this.txtNumber.ClientID%>');   
    if(txtOrderNo !=null)
    {  
        if(txtOrderNo.value.length > 0)
        {
            if(!isNaN(txtOrderNo.value))
                isHasFile = true;
        }
    }    
    args.IsValid = isHasFile;
 }  
  function openWin(pageUrl, w, h) {
		width = w;
		height = h;
		top_val = (screen.height - height) / 2 - 30;
		if (top_val < 0) { top_val = 0; }
		left_val = (screen.width - width) / 2; 
        
        window.open(pageUrl, null, "toolbar=0,location=0,status=1,menubar=0,scrollbars=0,resizable=0,width=" + width + ",height=" + height + ", top=" + top_val + ",left=" + left_val);
}
    </script>

</asp:Content>
