<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminManagerSubjectEditor.aspx.cs" ValidateRequest="false"
    MasterPageFile="~/Amincp/MP/MasterPageAdmin.Master" Inherits="PGFine.Amincp.AdminManagerSubjectEditor" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
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
                <asp:TextBox ID="txtTypeNewsID" runat="server" Enabled="False" CssClass="Textbox"></asp:TextBox>
            </td>
            <td>
            </td>
        </tr>       
        <tr>
            <td class="FieldTD">
                <span class="FieldCaption">Tên môn học tiếng anh:</span>
            </td>
            <td>
                <asp:TextBox ID="txtTitleNewsEL" runat="server" Enabled="True" CssClass="Textbox"
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
                <asp:TextBox ID="txtTitleNewsVN" runat="server" Enabled="True" CssClass="Textbox"
                    MaxLength="1073741823"></asp:TextBox>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td class="FieldTD">
                <span class="FieldCaption">Số lần đọc:</span>
            </td>
            <td>
                <asp:TextBox ID="txtReadTimes" runat="server" CssClass="Textbox"
                    MaxLength="1073741823"></asp:TextBox>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td class="FieldTD">
                <span class="FieldCaption">Thứ tự hiển thị:</span>
            </td>
            <td>
                <asp:TextBox ID="txtIndexof" runat="server" CssClass="Textbox"
                    MaxLength="1073741823"></asp:TextBox>
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
                <span class="FieldCaption">Mô tả ngắn tiếng anh:</span>
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
                <span class="FieldCaption">Mô tả ngắn tiếng việt:</span>
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
                <span class="FieldCaption">Nội dung tiếng anh:</span>
            </td>
            <td>
               
                <FCKeditorV2:FCKeditor ID="txtContentEL" runat="server" Height="300" ToolbarSet="TapChiXeCoGioi">
                </FCKeditorV2:FCKeditor>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td class="FieldTD">
                <span class="FieldCaption">Nội dung tiếng việt:</span>
            </td>
            <td>
               

                <FCKeditorV2:FCKeditor ID="txtContentVN" runat="server" Height="300" ToolbarSet="TapChiXeCoGioi">
                </FCKeditorV2:FCKeditor>
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
