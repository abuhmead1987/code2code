<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManagerTopFicEditor.aspx.cs"
    Inherits="PGFine.Amincp.ManagerTopFicEditor" MasterPageFile="~/Amincp/MP/MasterPageAdmin.Master" %>

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
                <asp:TextBox ID="txtTypeNewsID" runat="server" Enabled="False" CssClass="Textbox" Width="100px"></asp:TextBox>
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
                <span class="FieldCaption">Tin tức tiếng anh:</span>
            </td>
            <td>
                <asp:TextBox ID="txtTypeNewsEL" runat="server" Enabled="True" CssClass="Textbox"
                    MaxLength="1073741823"></asp:TextBox>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td class="FieldTD">
                <span class="FieldCaption">Tin tức tiếng việt:</span>
            </td>
            <td>
                <asp:TextBox ID="txtTypeNewsVN" runat="server" Enabled="True" CssClass="Textbox"
                    MaxLength="1073741823"></asp:TextBox>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td class="FieldTD">
                <span class="FieldCaption">Hiển thị tức thời</span>
            </td>
            <td>
                <asp:RadioButtonList ID="chkTypeDisplay" runat="server" RepeatDirection="Horizontal"
                    Width="138px">
                    <asp:ListItem Value="0">Không</asp:ListItem>
                    <asp:ListItem Value="1">Có</asp:ListItem>
                </asp:RadioButtonList>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td class="FieldTD">
                <span class="FieldCaption">Vị trí hiển thị</span>
            </td>
            <td>
                <asp:RadioButtonList ID="rdoPositionDisplay" runat="server" RepeatDirection="Horizontal"
                    Width="531px">
                    <asp:ListItem Value="0">Menu trên</asp:ListItem>
                    <asp:ListItem Value="1">Menu dưới</asp:ListItem>
                    <asp:ListItem Value="2">Menu trên + Dưới</asp:ListItem>
                    <asp:ListItem Value="3">Menu trên phải</asp:ListItem>
                    <asp:ListItem Value="4">Chi tiết sản phẩm</asp:ListItem>
                </asp:RadioButtonList>
            </td>
            <td>
            </td>
        </tr>
         <tr>
            <td class="FieldTD">
                <span class="FieldCaption">Thứ tự:</span>
            </td>
            <td>
                <asp:TextBox ID="txtOrder" runat="server" Enabled="True" CssClass="Textbox" Width="100px"
                    MaxLength="1073741823"></asp:TextBox>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td class="FieldTD">
                <span class="FieldCaption">Trang liên kết:</span>
            </td>
            <td>
                <asp:TextBox ID="txtPageLink" runat="server" Enabled="True" CssClass="Textbox"
                    MaxLength="1073741823"></asp:TextBox>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td class="FieldTD">
                <span class="FieldCaption">Ảnh Banner:</span>
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
            <td>
                &nbsp;
            </td>
            <td style="width: 399px">
                <asp:Button ID="cmdSave" runat="server" Text="Save" CssClass="Button" OnClick="cmdSave_Click"
                    Width="47px"></asp:Button>&nbsp;
                <asp:Button ID="btDelete" runat="server" Text="Xoá" CssClass="Button" Visible="false"
                    Width="47px" onclick="btDelete_Click"></asp:Button>&nbsp;                
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" CausesValidation="False"
                    CssClass="Button" OnClick="btnCancel_Click"></asp:Button>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
</asp:Content>
