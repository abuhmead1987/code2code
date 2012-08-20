<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManagerSizeEditor.aspx.cs"
    ValidateRequest="false" MasterPageFile="~/Amincp/MP/MasterPageAdmin.Master" Inherits="PGFine.Amincp.ManagerSizeEditor" %>


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
                <asp:TextBox ID="txtSizeID" runat="server" Enabled="False" CssClass="Textbox"></asp:TextBox>
                <asp:HiddenField ID="hdProductId" runat="server" />
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td class="FieldTD">
                <span class="FieldCaption">Tên màu:</span>
            </td>
            <td>
                <asp:TextBox ID="txtNameSize" runat="server" Enabled="True" CssClass="Textbox" MaxLength="1073741823"></asp:TextBox>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td class="FieldTD">
                <span class="FieldCaption">Icon màu:</span>
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
                <span class="FieldCaption">Hình ảnh 1:</span>
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
                <span class="FieldCaption">Hình ảnh 2:</span>
            </td>
            <td>
                <asp:FileUpload ID="FileUpload3" runat="server" />
                <asp:TextBox ID="txtPathImages2" runat="server" CssClass="Textbox"></asp:TextBox>
            </td>
            <td>
                <asp:Button ID="btChangeImages2" runat="server" Text="Đổi Ảnh" CssClass="Button"
                    OnClick="btChangeImages2_Click" />
            </td>
        </tr>
        <tr>
            <td class="FieldTD">
                <span class="FieldCaption">Hình ảnh 3:</span>
            </td>
            <td>
                <asp:FileUpload ID="FileUpload4" runat="server" />
                <asp:TextBox ID="txtPathImages3" runat="server" CssClass="Textbox"></asp:TextBox>
            </td>
            <td>
                <asp:Button ID="btChangeImages3" runat="server" Text="Đổi Ảnh" CssClass="Button"
                    OnClick="btChangeImages3_Click" />
            </td>
        </tr>
         <tr>
            <td class="FieldTD">
                <span class="FieldCaption">Hình ảnh 4:</span>
            </td>
            <td>
                <asp:FileUpload ID="FileUpload5" runat="server" />
                <asp:TextBox ID="txtPathImages4" runat="server" CssClass="Textbox"></asp:TextBox>
            </td>
            <td>
                <asp:Button ID="btChangeImages4" runat="server" Text="Đổi Ảnh" CssClass="Button"
                    OnClick="btChangeImages4_Click" />
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td style="width: 399px">
                <asp:Button ID="cmdSave" runat="server" Text="Save" CssClass="Button" Width="48px"
                    OnClick="cmdSave_Click"></asp:Button>&nbsp;
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" CausesValidation="False"
                    CssClass="Button" Width="48px" OnClick="btnCancel_Click"></asp:Button>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
</asp:Content>
