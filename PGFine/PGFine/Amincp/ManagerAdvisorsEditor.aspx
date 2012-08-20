<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManagerAdvisorsEditor.aspx.cs"
    ValidateRequest="false" MasterPageFile="~/Amincp/MP/MasterPageAdmin.Master" Inherits="PGFine.Amincp.ManagerAdvisorsEditor" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>


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
                <asp:TextBox ID="txtTrainerID" runat="server" Enabled="False" CssClass="Textbox"></asp:TextBox>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td class="FieldTD">
                <span class="FieldCaption">Thứ tự hiển thị:</span>
            </td>
            <td>
                <asp:TextBox ID="txtIndexOf" runat="server" Enabled="True" CssClass="Textbox"></asp:TextBox>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td class="FieldTD">
                <span class="FieldCaption">Tên tiếng Anh:</span>
            </td>
            <td>
                <asp:TextBox ID="txtNameEL" runat="server" Enabled="True" CssClass="Textbox" MaxLength="1073741823"></asp:TextBox>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td class="FieldTD">
                <span class="FieldCaption">Tên tiếng Việt:</span>
            </td>
            <td>
                <asp:TextBox ID="txtNameVN" runat="server" Enabled="True" CssClass="Textbox" MaxLength="1073741823"></asp:TextBox>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td class="FieldTD">
                <span class="FieldCaption">Hình ảnh:</span>
            </td>
            <td>
                <asp:FileUpload ID="FileUpload1" runat="server" />
                <asp:TextBox ID="txtPathImages" runat="server" CssClass="Textbox"></asp:TextBox>
                <asp:Button ID="btChangeImages" runat="server" Text="Đổi Ảnh" CssClass="Button" OnClick="btChangeImages_Click" />
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td class="FieldTD">
                <span class="FieldCaption">Mô tả ngắn tiếng Anh:</span>
            </td>
            <td>
                <asp:TextBox ID="txtShortDescriptionEL" runat="server" Enabled="True" CssClass="Textbox"
                    MaxLength="1073741823" Height="85px" TextMode="MultiLine"></asp:TextBox>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td class="FieldTD">
                <span class="FieldCaption">Mô tả ngắn tiếng Việt:</span>
            </td>
            <td>
                <asp:TextBox ID="txtShortDescriptionVN" runat="server" Enabled="True" CssClass="Textbox"
                    MaxLength="1073741823" Height="83px" TextMode="MultiLine"></asp:TextBox>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td class="FieldTD">
                <span class="FieldCaption">Nội dung tiếng Anh:</span>
            </td>
            <td>
                <fckeditorv2:fckeditor ID="txtContentEL" runat="server" Height="300" 
                    ToolbarSet="TapChiXeCoGioi">
                </fckeditorv2:fckeditor>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td class="FieldTD">
                <span class="FieldCaption">Nội dung tiếng Việt:</span>
            </td>
            <td>
               

<fckeditorv2:fckeditor ID="txtContentVN" runat="server" Height="300" 
                    ToolbarSet="TapChiXeCoGioi">
                </fckeditorv2:fckeditor>
            </td>
            <td>
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
