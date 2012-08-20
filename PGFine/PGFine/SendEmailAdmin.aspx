<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SendEmailAdmin.aspx.cs"
    Inherits="PGFine.SendEmailAdmin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Send Testimonial admin</title>
    <link href="Css/UserCss.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div style="float: left; width: 400px; height: 300px;">
        <div class="CaptionSendMail">
           <%-- Gửi ý kiến của bạn--%><asp:Literal ID="ltrtestimial" runat="server"></asp:Literal>
        </div>
        <asp:Label ID="_errorLabel" runat="server" Text="" Visible="false"></asp:Label>
        <div class="BothSendM">
            <div class="TitleCaptionS">
                <%--Họ tên:--%><asp:Literal ID="ltrName" runat="server"></asp:Literal>
            </div>
            <div class="txtEmailS">
                <asp:TextBox ID="txtName" runat="server" Width="189px" ValidationGroup="CheckInput"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="CheckInput"
                    runat="server" ErrorMessage="Khác rỗng" CssClass="validatemess" ControlToValidate="txtName">
                </asp:RequiredFieldValidator>
            </div>
        </div>
        <div class="BothSendM">
            <div class="TitleCaptionS">
                <%--Điện thoại :--%><asp:Literal ID="ltrPhone" runat="server"></asp:Literal>
            </div>
            <div class="txtEmailS">
                <asp:TextBox ID="txtPhone" runat="server" Width="189px" ValidationGroup="CheckInput"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="CheckInput"
                    ErrorMessage="Khác rỗng" CssClass="validatemess" ControlToValidate="txtPhone">
                </asp:RequiredFieldValidator>
            </div>
        </div>
        <div class="BothSendM">
            <div class="TitleCaptionS">
                Email(*):
            </div>
            <div class="txtEmailS">
                <asp:TextBox ID="txtEmail" runat="server" Width="189px" ValidationGroup="CheckInput"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ValidationGroup="CheckInput"
                    ErrorMessage="Khác rỗng" CssClass="validatemess" ControlToValidate="txtEmail" Display="Dynamic">
                </asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail"
                    ValidationExpression="[\w]+@[\w]+\.(com|net|org|co\.th|go\.th|ac\.th|or\.th|go\.th)"
                    Display="Dynamic" ErrorMessage="Sai định dạng" ValidationGroup="CheckInput" CssClass="validatemess"></asp:RegularExpressionValidator>
            </div>
        </div>
        <div class="BothSendM">
            <div class="TitleCaptionS">
               <%-- Địa chỉ:--%><asp:Literal ID="ltrAddress" runat="server"></asp:Literal>
            </div>
            <div class="txtEmailS">
                <asp:TextBox ID="txtAddress" runat="server" Width="189px" ValidationGroup="CheckInput"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ValidationGroup="CheckInput"
                    ErrorMessage="Khác rỗng" CssClass="validatemess" ControlToValidate="txtAddress">
                </asp:RequiredFieldValidator>
            </div>
        </div>
        <div class="BothSendM">
            <div class="TitleCaptionS">
               <%-- Nội dung:--%><asp:Literal ID="ltrContent" runat="server"></asp:Literal>
            </div>
            <div class="txtEmailS">
                <asp:TextBox ID="txtContent" runat="server" Width="223px" ValidationGroup="CheckInput"
                    TextMode="MultiLine" Height="90px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ValidationGroup="CheckInput"
                    ErrorMessage="Khác rỗng" CssClass="validatemess" ControlToValidate="txtContent">
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
