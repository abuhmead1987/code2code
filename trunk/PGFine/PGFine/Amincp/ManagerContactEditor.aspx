<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManagerContactEditor.aspx.cs" MasterPageFile="~/Amincp/MP/MasterPageAdmin.Master" Inherits="PGFine.Amincp.ManagerContactEditor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table border="0" cellpadding="2" cellspacing="2" width="95%" align="center">
        <tr>
            <td colspan="3">
                <asp:Label ID="_errorLabel" runat="server" Visible="False" CssClass="errorMessage" />
            </td>
        </tr>
        <tr>
            <td class="FieldTD">
                <span class="FieldCaption">Mã:</span>
            </td>
            <td>
                <asp:TextBox ID="txtId" runat="server" Enabled="False" CssClass="Textbox"></asp:TextBox>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td class="FieldTD">
                <span class="FieldCaption">Khách hàng:</span>
            </td>
            <td>
                <asp:TextBox ID="txtName" runat="server" Enabled="False" 
                    CssClass="Textbox"></asp:TextBox>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td class="FieldTD">
                <span class="FieldCaption">Phone:</span>
            </td>
            <td>
                <asp:TextBox ID="txtPhone" runat="server" Enabled="True" CssClass="Textbox"
                    MaxLength="1073741823"></asp:TextBox>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td class="FieldTD">
                <span class="FieldCaption">Email:</span>
            </td>
            <td>
                <asp:TextBox ID="txtEmail" runat="server" Enabled="True" CssClass="Textbox"
                    MaxLength="1073741823"></asp:TextBox>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td class="FieldTD">
                <span class="FieldCaption">Địa chỉ:</span>
            </td>
            <td>
                <asp:TextBox ID="txtAddress" runat="server" Enabled="True" CssClass="Textbox"
                    MaxLength="1073741823"></asp:TextBox>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td class="FieldTD">
                <span class="FieldCaption">Nội dung:</span>
            </td>
            <td>
                <asp:TextBox ID="txtContent" runat="server" Enabled="True" CssClass="Textbox"
                    MaxLength="1073741823" Height="189px" TextMode="MultiLine"></asp:TextBox>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td style="width: 399px">
                <asp:Button ID="cmdSave" runat="server" Text="Save" CssClass="Button"
                    Width="47px" Enabled="False"></asp:Button>&nbsp;
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" CausesValidation="False"
                    CssClass="Button" OnClick="btnCancel_Click"></asp:Button>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
</asp:Content>
