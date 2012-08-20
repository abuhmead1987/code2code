<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManagerProgramsEditor.aspx.cs"
    MasterPageFile="~/Amincp/MP/MasterPageAdmin.Master" Inherits="PGFine.Amincp.ManagerProgramsEditor" %>

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
                <asp:TextBox ID="txtProgramsID" runat="server" Enabled="False" CssClass="Textbox"></asp:TextBox>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td class="FieldTD">
                <span class="FieldCaption">Menu cha:</span>
            </td>
            <td>
                <asp:DropDownList ID="cboMenuParent" runat="server" CssClass="Dropdown" AutoPostBack="True"
                    OnSelectedIndexChanged="cboMenuParent_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td class="FieldTD">
                <span class="FieldCaption">Tên môn học tiếng anh:</span>
            </td>
            <td>
                <asp:TextBox ID="txtProgramsEL" runat="server" Enabled="True" CssClass="Textbox"
                    MaxLength="1073741823"></asp:TextBox>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td class="FieldTD">
                <span class="FieldCaption">Tên môn học tiếng việt:</span>
            </td>
            <td>
                <asp:TextBox ID="txtProgramsVN" runat="server" Enabled="True" CssClass="Textbox"
                    MaxLength="1073741823"></asp:TextBox>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td style="width: 399px">
                <asp:Button ID="cmdSave" runat="server" Text="Save" CssClass="Button" Width="47px"
                    OnClick="cmdSave_Click"></asp:Button>&nbsp;
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" CausesValidation="False"
                    CssClass="Button" OnClick="btnCancel_Click"></asp:Button>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
</asp:Content>
