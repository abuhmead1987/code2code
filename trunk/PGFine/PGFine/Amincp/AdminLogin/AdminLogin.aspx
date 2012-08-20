<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminLogin.aspx.cs" Inherits="PGFine.Amincp.AdminLogin.AdminLogin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Trang đăng nhập tài khoản admin!</title>
     <link href="css/Default.css" rel="stylesheet" type="text/css" />
    <link href="css/MainStyle.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
     <div class="MasterDiv" style="width: 100%;">
        <%--  <asp:UpdatePanel ID="updatePanel" runat="server">
                <ContentTemplate>--%>
        <div class="loginBox">
            <div class="loginInfo">
                <table cellspacing="2" cellpadding="2" align="center">
                    <tr>
                        <td class="leftLoginCell">
                            Tên đăng nhập:
                        </td>
                        <td>
                            <asp:TextBox ID="txtUsername" runat="server" CssClass="Textbox" Width="230" MaxLength="20"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="leftLoginCell">
                            Mật mã:
                        </td>
                        <td>
                            <asp:TextBox ID="txtPassword" runat="server" CssClass="Textbox" TextMode="Password"
                                Width="230" MaxLength="18"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="leftLoginCell">
                            Ngôn ngữ quản lý:
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlLocation" runat="server" CssClass="Dropdown" Width="150">
                                <asp:ListItem Value="VIE">Tiếng Việt</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="leftLoginCell">
                            &nbsp;
                        </td>
                        <td>
                            <asp:Button ID="cmdLogin" runat="server" Text="Đăng nhập" CssClass="Button " 
                                onclick="cmdLogin_Click" />
                            <asp:Button ID="cmdExit" runat="server" Text="Thoát" CssClass="Button " 
                                Width="76px" />
                        </td>
                    </tr>
                    <tr>
                        <td class="centerLoginCell" colspan="2">
                            <asp:Label ID="lbError" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        <%--   </ContentTemplate>
            </asp:UpdatePanel>--%>
    </div>
    </form>
</body>
</html>
