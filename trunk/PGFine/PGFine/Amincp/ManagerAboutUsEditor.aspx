<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManagerAboutUsEditor.aspx.cs"
    ValidateRequest="false" MasterPageFile="~/Amincp/MP/MasterPageAdmin.Master" Inherits="PGFine.Amincp.ManagerAboutUsEditor" %>

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
                <asp:TextBox ID="txtChilAboutUsID" runat="server" Enabled="False" CssClass="Textbox"></asp:TextBox>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td class="FieldTD">
                <span class="FieldCaption">Menu giới thiệu:</span>
            </td>
            <td>
                <asp:DropDownList ID="cboNameNewsVN" runat="server" CssClass="Dropdown">
                </asp:DropDownList>
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
                <%--<radE:RadEditor ID="txtContentVN" runat="server" CssClass="RadTextbox" ShowSubmitCancelButtons="False"
                    DeleteImagesPaths="~/Images/ImgNews/" ImagesPaths="~/Images/ImgNews/" UploadImagesPaths="~/Images/ImgNews/"
                    DeleteDocumentsPaths="~/Images/Document/" DocumentsPaths="~/Images/Document/"
                    UploadDocumentsPaths="~/Images/Document/" DeleteTemplatePaths="~/Images/ImgNews/"
                    TemplatePaths="~/Images/ImgNews/" UploadTemplatePaths="~/Images/ImgNews/" DeleteFlashPaths="~/Images/Document/"
                    DeleteMediaPaths="~/Images/Document/" FlashPaths="~/Images/Document/" MediaFilters="*.asf,*.asx,*.wm,*.wmx,*.wmp,*.wma,*.wax,*.wmv,*.wvx,*.avi,*.wav,*.mpeg,*.mpg,*.mpe,*.mov,*.m1v,*.pdf,*.mp2,*.mpv2,*.mp2v,*.mpa,*.mp3,*.m3u,*.mid,*.midi,*.rm,*.rma,*.rmi,*.rmv,*.aif,*.aifc,*.aiff,*.au,*.snd"
                    MediaPaths="~/Images/Document/" TemplateFilters="*.html,*.htm,*.pdf" UploadFlashPaths="~/Images/Document/"
                    UploadMediaPaths="~/Images/Document/">
                </radE:RadEditor>--%>

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
