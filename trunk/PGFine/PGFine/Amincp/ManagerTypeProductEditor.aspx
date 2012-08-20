<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManagerTypeProductEditor.aspx.cs"
    MasterPageFile="~/Amincp/MP/MasterPageAdmin.Master" Inherits="PGFine.Amincp.ManagerTypeProductEditor" %>

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
                T<span class="FieldCaption">ên loại sản phẩm:</span>
            </td>
            <td>
                <asp:TextBox ID="txtName" runat="server" CssClass="Textbox"></asp:TextBox>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td class="FieldTD">
                T<span class="FieldCaption">ên tiếng anh:</span>
            </td>
            <td>
                <asp:TextBox ID="txtNameEL" runat="server" CssClass="Textbox"></asp:TextBox>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td class="FieldTD">
                <span class="FieldCaption">Hình ảnh Out:</span>
            </td>
            <td>
                <asp:FileUpload ID="FileUpload1" runat="server" />
                <asp:TextBox ID="txtPathImages" runat="server" CssClass="Textbox"></asp:TextBox>
            </td>
            <td>
                <asp:Button ID="btChangeImages" runat="server" Text="Đổi Ảnh" CssClass="Button" OnClick="btChangeImages_Click" />
            </td>
        </tr>
        <tr>
            <td class="FieldTD">
                <span class="FieldCaption">Hình ảnh hover:</span>
            </td>
            <td>
                <asp:FileUpload ID="FileUpload2" runat="server" />
                <asp:TextBox ID="txtPathImages1" runat="server" CssClass="Textbox"></asp:TextBox>
            </td>
            <td>
                <asp:Button ID="btChangeImages1" runat="server" Text="Đổi Ảnh" CssClass="Button"
                    OnClick="btChangeImages1_Click" />
            </td>
        </tr>
        <tr>
            <td class="FieldTD">
                <span class="FieldCaption">Hình ảnh banner:</span>
            </td>
            <td>
                <asp:FileUpload ID="FileUpload3" runat="server" />
                <asp:TextBox ID="txtPathImages2" runat="server" CssClass="Textbox"></asp:TextBox>
            </td>
            <td>
                <asp:Button ID="btChangeImages2" runat="server" Text="Đổi Ảnh" CssClass="Button" OnClick="btChangeImages2_Click" />
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
