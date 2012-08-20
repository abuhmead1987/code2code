<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="introduction.aspx.cs" Inherits="PGFine.introduction" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Send mail to your friend</title>
    <link href="Css/UserCss.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div style="float: left; width: 400px; height: 300px;">
        <div class="CaptionSendMail">
            <%--Gửi thông tin bạn bè--%><asp:Literal ID="ltrSendYour" runat="server"></asp:Literal>
        </div>
        <div class="BothSendM">
            <div class="TitleCaptionS">
                <%--Email của bạn:--%><asp:Literal ID="ltrEmailF" runat="server"></asp:Literal>
            </div>
            <div class="txtEmailS">
                <asp:TextBox ID="txtEmailYou" runat="server" ValidationGroup="CheckInput" Width="170px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ValidationGroup="CheckInput"
                    ErrorMessage="Khác rỗng" CssClass="validatemess" ControlToValidate="txtEmailYou"
                    Display="Dynamic">
                </asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmailYou"
                    ValidationExpression="[\w]+@[\w]+\.(com|net|org|co\.th|go\.th|ac\.th|or\.th|go\.th)"
                    Display="Dynamic" ErrorMessage="Sai định dạng" ValidationGroup="CheckInput" CssClass="validatemess">
                </asp:RegularExpressionValidator>
            </div>
        </div>
        <div class="BothSendM">
            <div class="TitleCaptionS">
                <%--Email người nhận:--%><asp:Literal ID="ltrEmailReceiver" runat="server"></asp:Literal>
            </div>
            <div class="txtEmailS">
                <asp:TextBox ID="txtEmailYourF" runat="server" Width="170px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="CheckInput"
                    ErrorMessage="Khác rỗng" CssClass="validatemess" ControlToValidate="txtEmailYourF"
                    Display="Dynamic">
                </asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtEmailYourF"
                    ValidationExpression="[\w]+@[\w]+\.(com|net|org|co\.th|go\.th|ac\.th|or\.th|go\.th)"
                    Display="Dynamic" ErrorMessage="Sai định dạng" ValidationGroup="CheckInput" CssClass="validatemess">
                </asp:RegularExpressionValidator>
            </div>
        </div>
        <div class="BothSendM">
            <div class="TitleCaptionS">
                <%--Chủ đề:--%><asp:Literal ID="ltrSubject" runat="server"></asp:Literal>
            </div>
            <div class="txtEmailS">
                <asp:TextBox ID="txtSubject" runat="server" Width="170px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="CheckInput"
                    ErrorMessage="Khác rỗng" CssClass="validatemess" ControlToValidate="txtSubject"
                    Display="Dynamic">
                </asp:RequiredFieldValidator>
            </div>
        </div>
        <div class="BothSendM">
            <div class="TitleCaptionS">
                <%--Nội dung:--%><asp:Literal ID="ltrContent" runat="server"></asp:Literal>
            </div>
            <div class="txtEmailS">
                <asp:TextBox ID="txtContent" runat="server" Width="205px" TextMode="MultiLine" Height="90px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ValidationGroup="CheckInput"
                    ErrorMessage="Khác rỗng" CssClass="validatemess" ControlToValidate="txtContent"
                    Display="Dynamic">
                </asp:RequiredFieldValidator>
            </div>
        </div>
        <div class="BothSendM">
            <div style="float: left; width: 400px; margin: 0px 0px 0px 110px;">
                <asp:Button ID="btSend" runat="server" Text="Gửi" OnClick="btSend_Click" ValidationGroup="CheckInput" />
                <asp:Button ID="btReset" runat="server" Text="Làm lại" OnClick="btReset_Click" /></div>
        </div>
    </div>
    </form>
</body>
</html>
