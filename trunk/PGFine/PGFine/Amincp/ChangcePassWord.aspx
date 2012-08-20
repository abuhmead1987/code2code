<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChangcePassWord.aspx.cs" MasterPageFile="~/Amincp/MP/MasterPageAdmin.Master" Inherits="PGFine.Amincp.ChangcePassWord" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table border="0" cellpadding="2" cellspacing="2" width="95%" align="center">
        <tr>
            <td colspan="3">
                <asp:Label ID="_errorLabel" runat="server" Visible="True" CssClass="errorMessage" />
            </td>
        </tr>
        <tr>
            <td class="FieldTD">
                <span class="FieldCaption">Tên truy cập:</span>
            </td>
            <td>
                <asp:TextBox ID="txtUserName" runat="server" Enabled="True" CssClass="Textbox"></asp:TextBox>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td class="FieldTD">
                <span class="FieldCaption">Mật khẩu cũ:</span>
            </td>
            <td>
                 <asp:TextBox ID="txtPassWordOld" runat="server" Enabled="True" 
                     CssClass="Textbox" TextMode="Password"></asp:TextBox>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td class="FieldTD">
                <span class="FieldCaption">Mật khẩu mới:</span>
            </td>
            <td>
                <asp:TextBox ID="txtPassNew" runat="server" Enabled="True" CssClass="Textbox"
                    MaxLength="1073741823" TextMode="Password"></asp:TextBox>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td class="FieldTD">
                <span class="FieldCaption">Nhập lại mật khẩu mới:</span>
            </td>
            <td>
                <asp:TextBox ID="txtPassNewAgain" runat="server" Enabled="True" CssClass="Textbox"
                    MaxLength="1073741823" TextMode="Password"></asp:TextBox>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td style="width: 399px">
                <asp:Button ID="cmdSave" runat="server" Text="Lưu lại" CssClass="Button" OnClick="cmdSave_Click"
                    Width="47px"></asp:Button>&nbsp;
                <asp:Button ID="btnCancel" runat="server" Text="Bỏ qua" CausesValidation="False"
                    CssClass="Button" OnClick="btnCancel_Click"></asp:Button>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
</asp:Content>
