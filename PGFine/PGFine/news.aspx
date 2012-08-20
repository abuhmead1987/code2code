<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="news.aspx.cs" MasterPageFile="~/MasterPageUser/MasterPageUser.Master"
    Inherits="PGFine.news" EnableEventValidation="false" %>

<%@ Register Src="Ctrl/CtrlMainBanner.ascx" TagName="CtrlMainBanner" TagPrefix="uc1" %>
<%@ Register Src="Ctrl/CtrlRandomProduct.ascx" TagName="CtrlRandomProduct" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script type="text/javascript" language="javascript">  
  function openWin(pageUrl, w, h) {
		width = w;
		height = h;
		top_val = (screen.height - height) / 2 - 30;
		if (top_val < 0) { top_val = 0; }
		left_val = (screen.width - width) / 2; 
        
        window.open(pageUrl, null, "toolbar=0,location=0,status=1,menubar=0,scrollbars=0,resizable=0,width=" + width + ",height=" + height + ", top=" + top_val + ",left=" + left_val);
}
    </script>

    <asp:Label ID="_errorLabel" runat="server" Visible="false"></asp:Label>
    <uc1:CtrlMainBanner ID="CtrlMainBanner1" runat="server" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:PlaceHolder ID="htmlRenderNews" runat="server">
        <div class="Pageging">
            <div runat="server" id="BannerBreakrum">
                <asp:Label ID="lbBreakrum" runat="server" Text="men" CssClass="Breakrum"></asp:Label>
            </div>
        </div>
        <div class="ListProduct">
            <div class="NewsDetailContent">
                <asp:Label ID="lbTitle" runat="server" Text="Label" CssClass="TitleNewsDetail"></asp:Label>
                <asp:Label ID="lbShortdescription" runat="server" Text="Label" CssClass="ShortDescriptionNewsDetail"></asp:Label>
                <asp:Label ID="lbDescription" runat="server" Text="Label" CssClass="DescriptionNewsDetail"></asp:Label>
            </div>
        </div>
    </asp:PlaceHolder>
    <div class="ListProduct">
        <div style="float: left; border-bottom: dotted 1px #CBC9C9; border-top: dotted 1px #CBC9C9;
            height: 25px; width: 985px; margin: 10px 0px 10px 0px;">
            <div style="font-family: Arial; font-size: 10px; color: #A09898; float: left; margin: 7px 0px 0px 0px;">
                <strong>CẬP NHẬT:</strong> 10/09/2010
            </div>
            <div style="float: right;">
                <div style="float: right; margin: 5px 10px 0px 0px;">
                    <asp:Image ID="Image24" runat="server" ImageUrl="~/Images/print.gif" /></div>
                <div class="BottomPrint">
                    <asp:LinkButton ID="lbtPrint" runat="server" CssClass="TextPrintDetailNews">In trang này</asp:LinkButton>
                </div>
                <div style="float: right; margin: 5px 10px 0px 0px;">
                    <asp:Image ID="Image2" runat="server" ImageUrl="~/Images/guiphanhoi.gif" /></div>
                <div class="BottomPrint">
                    <asp:HyperLink ID="hplSendAdmin" runat="server" NavigateUrl="javascript:void(0);"
                        CssClass="TextPrint">Gửi phản hồi</asp:HyperLink>
                </div>
                <div style="float: right; margin: 5px 10px 0px 0px;">
                    <asp:Image ID="Image3" runat="server" ImageUrl="~/Images/ContactYou.gif" /></div>
                <div class="BottomPrint">
                    <asp:HyperLink ID="hplIntroduct" runat="server" NavigateUrl="javascript:void(0);"
                        CssClass="TextPrint">Giới thiệu bạn bè</asp:HyperLink>
                </div>
            </div>
        </div>
        <div class="CaptionOrtherNews">
            <%--Tin Tức khác--%><asp:Literal ID="ltrOrtherNews" runat="server"></asp:Literal>
        </div>
        <div class="BottomOrtherNews">
        </div>
        <div class="ListOrtherNews">
            <asp:Repeater ID="rptListOrtherNews" runat="server" OnItemDataBound="rptListOrtherNews_ItemDataBound">
                <ItemTemplate>
                    <div style="float: left; width: 900px; padding: 5px 0px 0px;">
                        <div style="float: left; padding: 3px 0px 0px 30px;">
                            <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/vote.gif" />
                        </div>
                        <div class="LinkOrtherNews">
                            <asp:HyperLink ID="hplLinkOrther" runat="server" Font-Underline="false" ForeColor="#D91A5D"></asp:HyperLink>
                        </div>
                    </div>
                </ItemTemplate>
                <FooterTemplate>
                    <div style="padding-top: 10px; float: left; width: 600px; height: 2px;">
                    </div>
                </FooterTemplate>
            </asp:Repeater>
        </div>
        <uc2:CtrlRandomProduct ID="CtrlRandomProduct1" runat="server" />
        <div class="DivUpHome">
            <div class="testUp">
                <a href="javascript:top.window.scrollTo(0,0)">
                    <asp:Label ID="lbDreakrum" runat="server" Text="Lên đầu trang" Font-Underline="false"></asp:Label></a></div>
            <div class="ImagesUp">
                <a href="javascript:top.window.scrollTo(0,0)">
                    <asp:Image ID="Image33" runat="server" ImageUrl="~/Images/btlendautrang.gif" /></a></div>
        </div>
    </div>
</asp:Content>
