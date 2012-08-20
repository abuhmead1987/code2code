<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManagerGoogleMap.aspx.cs"
    ValidateRequest="false" MasterPageFile="~/Amincp/MP/MasterPageAdmin.Master" Inherits="PGFine.Amincp.ManagerGoogleMap" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<script type="text/javascript" language="javascript">   
 function validateShort(oSrc, args){     
    var isHasFile = false;          
    var txtGoogleMap = $get('<%=this.txtGoogleMap.ClientID%>');   
    if(txtGoogleMap !=null)
    {         
        isHasFile = txtGoogleMap.value.length > 0 && txtGoogleMap.value.length < 4000;
    }
    args.IsValid = isHasFile;
  }
</script>

    <table cellpadding="2" cellspacing="2" width="95%" align="center" border="0">
        <tr>
            <td colspan="3">
                <asp:Label ID="_errorLabel" runat="server" Visible="False" CssClass="errorMessage" />
            </td>
        </tr>
        <tr>
            <td class="FieldTD">
                <span class="FieldCaption">Đường dẫn Key:</span>
            </td>
            <td >
                <asp:TextBox ID="txtGoogleMap" runat="server" width="610"
                    TextMode="MultiLine" Height="90px"></asp:TextBox>
                    <asp:CustomValidator ID="CustomValidatorShortDescription" runat="server" ErrorMessage="Không được rỗng."
            Display="Dynamic" ClientValidationFunction="validateShort"></asp:CustomValidator>
            </td>
            <td valign="bottom">
            </td>
        </tr>        
         <tr>
            <td class="FieldTD">                
            </td>
            <td width="510" align="left">
                <asp:Button ID="cmdSave" runat="server" Text="Lưu lại" CssClass="Button" 
                    Width="47px" onclick="cmdSave_Click"></asp:Button>
            </td>
            <td valign="bottom">
            </td>
        </tr>       
    </table>
</asp:Content>
