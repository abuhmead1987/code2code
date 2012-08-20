<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SentVote.aspx.cs" Inherits="PGFine.SentVote" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Send vote product</title>
    <link href="Css/UserCss.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="MainSentVote">
        <div class="TitleCationVote">
            <%--Gửi Bình Luận--%><asp:Literal ID="ltrComment" runat="server"></asp:Literal>
        </div>
        <div class="RowsVote">
            <div class="CheckBokVote">
                <asp:CheckBox ID="chkOnceVote" runat="server" Text="1 Vote" AutoPostBack="True" 
                    oncheckedchanged="chkOnceVote_CheckedChanged" /></div>
            <div class="ImagesVoteSent">
                <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/vote.gif" /></div>
        </div>
        <div class="RowsVote">
            <div class="CheckBokVote">
                <asp:CheckBox ID="chkTwoVote" runat="server" Text="2 Vote" AutoPostBack="True" 
                    oncheckedchanged="chkTwoVote_CheckedChanged" /></div>
            <div class="ImagesVoteSent">
                <asp:Image ID="Image2" runat="server" ImageUrl="~/Images/vote.gif" /></div>
            <div class="ImagesVoteSent">
                <asp:Image ID="Image15" runat="server" ImageUrl="~/Images/vote.gif" /></div>
        </div>
        <div class="RowsVote">
            <div class="CheckBokVote">
                <asp:CheckBox ID="chkThreeVote" runat="server" Text="3 Vote" 
                    AutoPostBack="True" oncheckedchanged="chkThreeVote_CheckedChanged" /></div>
            <div class="ImagesVoteSent">
                <asp:Image ID="Image3" runat="server" ImageUrl="~/Images/vote.gif" /></div>
            <div class="ImagesVoteSent">
                <asp:Image ID="Image13" runat="server" ImageUrl="~/Images/vote.gif" /></div>
            <div class="ImagesVoteSent">
                <asp:Image ID="Image14" runat="server" ImageUrl="~/Images/vote.gif" /></div>
        </div>
        <div class="RowsVote">
            <div class="CheckBokVote">
                <asp:CheckBox ID="chkFournVote" runat="server" Text="4 Vote" 
                    AutoPostBack="True" oncheckedchanged="chkFournVote_CheckedChanged" /></div>
            <div class="ImagesVoteSent">
                <asp:Image ID="Image4" runat="server" ImageUrl="~/Images/vote.gif" /></div>
            <div class="ImagesVoteSent">
                <asp:Image ID="Image10" runat="server" ImageUrl="~/Images/vote.gif" /></div>
            <div class="ImagesVoteSent">
                <asp:Image ID="Image11" runat="server" ImageUrl="~/Images/vote.gif" /></div>
            <div class="ImagesVoteSent">
                <asp:Image ID="Image12" runat="server" ImageUrl="~/Images/vote.gif" /></div>
        </div>
        <div class="RowsVote">
            <div class="CheckBokVote">
                <asp:CheckBox ID="chkFiveVote" runat="server" Text="5 Vote" AutoPostBack="True" 
                    oncheckedchanged="chkFiveVote_CheckedChanged" /></div>
            <div class="ImagesVoteSent">
                <asp:Image ID="Image5" runat="server" ImageUrl="~/Images/vote.gif" /></div>
            <div class="ImagesVoteSent">
                <asp:Image ID="Image6" runat="server" ImageUrl="~/Images/vote.gif" /></div>
            <div class="ImagesVoteSent">
                <asp:Image ID="Image7" runat="server" ImageUrl="~/Images/vote.gif" /></div>
            <div class="ImagesVoteSent">
                <asp:Image ID="Image8" runat="server" ImageUrl="~/Images/vote.gif" /></div>
            <div class="ImagesVoteSent">
                <asp:Image ID="Image9" runat="server" ImageUrl="~/Images/vote.gif" /></div>
            <asp:Label ID="_errorLabel" runat="server" Text="Lỗi data" Visible="false"></asp:Label>
        </div>
        <div class="RowsVotebt">
            <asp:LinkButton ID="lbtSent" runat="server" CssClass="lbtSentVote" 
                onclick="lbtSent_Click">Gửi</asp:LinkButton>
            <asp:HyperLink ID="hplClose" runat="server" CssClass="hplSentVote" NavigateUrl="javascript:window.close()">Đóng</asp:HyperLink>
        </div>
    </div>
    </form>
</body>
</html>
