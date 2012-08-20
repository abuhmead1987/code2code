<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManagerProductEditor.aspx.cs"
    Inherits="PGFine.Amincp.ManagerProductEditor" MasterPageFile="~/Amincp/MP/MasterPageAdmin.Master" %>



<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

  <script language="javascript" type="text/javascript">

      $(function () {

          $('#<%=txtExpiredDate.ClientID%>').datepicker({ changeYear: true, yearRange: '1950:2010' });

      });

    </script>

    <table border="0" cellpadding="2" cellspacing="2" width="95%" align="center">
        <tr>
            <td colspan="3">
                <asp:Label ID="_errorLabel" runat="server" Visible="False" CssClass="errorMessage" />
            </td>
        </tr>
        <tr>
            <td class="FieldTD">
                <span class="FieldCaption">ID:</span>
            </td>
            <td>
                <asp:TextBox ID="txtID" runat="server" Enabled="False" CssClass="Textbox"></asp:TextBox>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td class="FieldTD">
                <span class="FieldCaption">Mã sản phẩm:</span>
            </td>
            <td>
                <asp:TextBox ID="txtCodeProduct" runat="server" CssClass="Textbox"></asp:TextBox>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td class="FieldTD">
                <span class="FieldCaption">Loại sản phẩm:</span>
            </td>
            <td>
                <asp:DropDownList ID="CboTypeProduct" runat="server" CssClass="Dropdown">
                </asp:DropDownList>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td class="FieldTD">
                <span class="FieldCaption">Tên sản phẩm:</span>
            </td>
            <td>
                <asp:TextBox ID="txtNameProduct" runat="server" Enabled="True" CssClass="Textbox"
                    MaxLength="1073741823"></asp:TextBox>
            </td>
            <td>
            </td>
        </tr>
         <tr>
            <td class="FieldTD">
                <span class="FieldCaption">Tên sản phẩm tiếng anh:</span>
            </td>
            <td>
                <asp:TextBox ID="txtNameProductEL" runat="server" Enabled="True" CssClass="Textbox"
                    MaxLength="1073741823"></asp:TextBox>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td class="FieldTD">
                <span class="FieldCaption">Giá:</span>
            </td>
            <td>
                <asp:TextBox ID="txtPrice" runat="server" CssClass="Textbox"></asp:TextBox>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td class="FieldTD">
                <span class="FieldCaption">Giá mới:</span>
            </td>
            <td>
                <asp:TextBox ID="txtPriceNew" runat="server" CssClass="Textbox"></asp:TextBox>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td class="FieldTD">
                <span class="FieldCaption">Ảnh đại diện:</span>
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
                <span class="FieldCaption">Ảnh tooltip:</span>
            </td>
            <td>
                <asp:FileUpload ID="FileUpload2" runat="server" />
                <asp:TextBox ID="txtPathImages1" runat="server" CssClass="Textbox"></asp:TextBox>
                <asp:Button ID="btChangeImages1" runat="server" Text="Đổi Ảnh" CssClass="Button" OnClick="btChangeImages1_Click" />
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td class="FieldTD">
                <span class="FieldCaption">Mô tả ngắn:</span>
            </td>
            <td>
                <asp:TextBox ID="txtShortDescription" runat="server" Enabled="True" CssClass="Textbox"
                    MaxLength="1073741823" Height="83px" TextMode="MultiLine"></asp:TextBox>
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
                    MaxLength="1073741823" Height="83px" TextMode="MultiLine"></asp:TextBox>
            </td>
            <td>
            </td>
        </tr>

              <tr>
            <td class="FieldTD">
                <span class="FieldCaption">Mô tả đầy đủ:</span>
            </td>
            <td>
                <FCKeditorV2:FCKeditor ID="txtContentVN" runat="server" Height="300" ToolbarSet="TapChiXeCoGioi">
                </FCKeditorV2:FCKeditor>
            </td>
            <td>
            </td>
        </tr>

          <tr>
            <td class="FieldTD">
                <span class="FieldCaption">Thời gian hết hạn:</span>
            </td>
            <td>
            
                <asp:TextBox ID="txtExpiredDate" runat="server" CssClass="Textbox"></asp:TextBox>
            </td>
            <td>
            </td>
        </tr>

        <tr>
            <td class="FieldTD">
                <span class="FieldCaption">Kích thước:</span>
            </td>
            <td>
                <asp:TextBox ID="txtContent" runat="server" CssClass="Textbox"></asp:TextBox>
            </td>
            <td>
            </td>
        </tr>
          <tr>
            <td class="FieldTD">
                <span class="FieldCaption">Tình trạng:</span>
            </td>
            <td>
                <asp:TextBox ID="txtStatus" runat="server" CssClass="Textbox"></asp:TextBox>
            </td>
            <td>
            </td>
        </tr>
           <tr>
            <td class="FieldTD">
                <span class="FieldCaption">Tình trạng tiếng anh:</span>
            </td>
            <td>
                <asp:TextBox ID="txtStatusEL" runat="server" CssClass="Textbox"></asp:TextBox>
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
