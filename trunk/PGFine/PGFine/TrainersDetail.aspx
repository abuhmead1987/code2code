<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TrainersDetail.aspx.cs"
    MasterPageFile="~/MasterPageUser/MasterPageUser.Master" Inherits="PGFine.TrainersDetail" %>

<%@ Register Assembly="CollectionPager" Namespace="SiteUtils" TagPrefix="cc2" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="FlashMain">
        <object classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" codebase="Images/fla2_1.swf"
            width="504" height="269">
            <param name="movie" value="Images/fla2_1.swf" />
            <param name="wmode" value="transparent" />
            <embed src="Images/fla2_1.swf" quality="high" pluginspage="http://www.macromedia.com/go/getflashplayer"
                type="application/x-shockwave-flash" width="504" height="269"></embed>
        </object>
    </div>
    <div class="MainCompanyProfile">
        <div class="GroupTitleNews">
            <asp:Label ID="lbTrainers" runat="server" Text="TRAINERS" CssClass="GroupTitleNewsCaptionMain"></asp:Label>
            <asp:Label ID="lbCaptionDay" runat="server" Text="Ngày, 14/01/2009" CssClass="Time"></asp:Label>
        </div>
        <div class="ContentProgram">
            <div class="ContentAboutGS">
                <asp:Label ID="lbContent" runat="server" CssClass="ContentDetailNews"></asp:Label>
            </div>
            <asp:Label ID="_errorLabel" runat="server" Text="Label" Visible="false"></asp:Label>
            <asp:Label ID="lbNewsNull" runat="server" Text="" Visible="false" CssClass="NewsNull"></asp:Label>
            <div class="ButtonBackTo">
                <asp:HyperLink ID="HyperLink1" runat="server" Text="Back" NavigateUrl="javascript:history.go(-1)"></asp:HyperLink>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="head">
</asp:Content>
