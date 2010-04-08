<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Sending dynamic email with VB.NET</title>
</head>
<body>
    <form id="form1" runat="server">
    <div align="center">
        <table>
            <tr>
                <td colspan="2" style="text-align: center;">
                    <h4>
                        Liên hệ khách hàng</h4>
                </td>
            </tr>
            <tr>
                <td>
                    Tên người dùng:
                </td>
                <td>
                    <asp:TextBox ID="TextBoxName"  Width="250"  runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Địa chỉ Email:
                </td>
                <td>
                    <asp:TextBox ID="TextBoxEmail"  Width="250"  runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td valign="top">
                    Nội dung:
                </td>
                <td>
                    <asp:TextBox ID="TextBoxContent"  Width="250" TextMode="MultiLine" Height="150" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
            <td>Đính kèm:</td>
            <td>
                <asp:FileUpload ID="FileUpload1" runat="server" />
            </td>
            </tr>
            <tr>
            <td></td>
            <td style="text-align:right;">
                <asp:Button ID="ButtonSend" runat="server" Text=" Gửi "></asp:Button></td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
