<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AdminSettSite.ascx.cs" Inherits="Controls_AdminSettSite" %>
<%@ Register src="AdminMenu.ascx" tagname="AdminMenu" tagprefix="uc1" %>

    <uc1:AdminMenu ID="AdminMenu1" runat="server" />
<div style="padding:5px">

    <asp:Label ID="Label1" runat="server" Font-Size="14px" Font-Bold="true" Text="<%$ Resources:language, SiteName%>"></asp:Label> <asp:TextBox ID="txtsn" Width="250px" runat="server"></asp:TextBox><br /><br />
    <asp:Label ID="Label2" runat="server" Font-Size="14px" Font-Bold="true" Text="<%$ Resources:language, AdminEmail%>"></asp:Label> <asp:TextBox ID="txtemail" Width="250px" runat="server"></asp:TextBox>
       <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtemail" ErrorMessage="<%$ Resources:language, RequiredField%>"></asp:RequiredFieldValidator><br /><asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="txtemail" ValidationExpression="^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$" ErrorMessage="<%$ Resources:language, Insertemail%>"></asp:RegularExpressionValidator><br />
    <asp:Label ID="Label3" runat="server" Font-Size="14px" Font-Bold="true" Text="<%$ Resources:language, SiteUrl%>"></asp:Label> <asp:TextBox ID="txturl" Width="250px" runat="server"></asp:TextBox>
       <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txturl" ErrorMessage="<%$ Resources:language, RequiredField%>"></asp:RequiredFieldValidator><br /><br />
    <asp:Label ID="Label4" runat="server" Font-Size="14px" Font-Bold="true" Text="<%$ Resources:language, EnableTopBanner%>"></asp:Label> <asp:CheckBox ID="CheckBox2" runat="server"  
        oncheckedchanged="CheckBox2_CheckedChanged" Autopostback="True" /> <asp:TextBox ID="txtBanner" runat="server" Visible="false" ReadOnly="true"></asp:TextBox> 
    <asp:FileUpload ID="FileUpload1" runat="server" Visible="false"/> 
    <asp:Label ID="Label8" runat="server" Text="<%$ Resources:language, BannerResizeWidth%>" Visible="false"></asp:Label>
    <asp:TextBox ID="txtW" columns="3" maxlength="4" runat="server" Visible="false"></asp:TextBox> <asp:Label ID="Label9" runat="server" Visible="false" Text="<%$ Resources:language, BannerResizeHeight%>"></asp:Label> 
    <asp:TextBox ID="txtH" columns="3" maxlength="4" runat="server" Visible="false"></asp:TextBox><asp:Label ID="Label10" runat="server" Visible="false" Text="<%$ Resources:language, leaveblanknores%>"></asp:Label>
    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="<%$ Resources:language, ImageFormat%>" ControlToValidate="FileUpload1" ValidationExpression="^.+\.((jpg)|(gif)|(jpeg)|(png)|(bmp)|(psd)|(JPG)|(JPEG)|(GIF)|(PNG)|(BMP)|(PSD))$"></asp:RegularExpressionValidator><br /><asp:Literal runat="server" Text="<%$ Resources:language, bannerinfo%>" />
    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="<%$ Resources:language, Insertvalidwidth %>" ControlToValidate="txtW" ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ErrorMessage="<%$ Resources:language, Insertvalidheigth %>" ControlToValidate="txtH" ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
<br /><br />
<asp:Label ID="Label13" runat="server" Font-Size="14px" Font-Bold="true" Text="<%$ Resources:language, EnableValidators%>"></asp:Label> <asp:CheckBox ID="CheckBox3" runat="server" /><br /><asp:Literal runat="server" Text="<%$ Resources:language, EnableValidatorsexp%>" /><br /><br />
<asp:Label ID="Label14" runat="server" Font-Size="14px" Font-Bold="true" Text="<%$ Resources:language, EnableLABox%>"></asp:Label> <asp:CheckBox ID="CheckBox6" runat="server" /><br /><asp:Literal runat="server" Text="<%$ Resources:language, EnableLABoxexp%>" /><br /><br />
<asp:Label ID="Label15" runat="server" Font-Size="14px" Font-Bold="true" Text="<%$ Resources:language, EnableLCBox%>"></asp:Label> <asp:CheckBox ID="CheckBox7" runat="server" /><br /><asp:Literal runat="server" Text="<%$ Resources:language, EnableLCBoxexp%>" /><br /><br />
<asp:Label ID="Label16" runat="server" Font-Size="14px" Font-Bold="true" Text="<%$ Resources:language, EnableRegCaptcha%>"></asp:Label> <asp:CheckBox ID="CheckBox8" runat="server" /><br /><asp:Literal runat="server" Text="<%$ Resources:language, EnableRegCaptchaexp%>" /><br /><br />
<asp:Label ID="Label17" runat="server" Font-Size="14px" Font-Bold="true" Text="<%$ Resources:language, EnableComCaptcha%>"></asp:Label> <asp:CheckBox ID="CheckBox10" runat="server" /><br /><asp:Literal runat="server" Text="<%$ Resources:language, EnableComCaptchaexp%>" /><br /><br />
<asp:Label ID="Label19" runat="server" Font-Size="14px" Font-Bold="true" Text="<%$ Resources:language, ChooseTypeCaptcha%>"></asp:Label> <asp:DropDownList ID="DDcaptcha" runat="server" onselectedindexchanged="DDcaptcha_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList> <asp:Image ID="ddimg" runat="server" /><br /><br />
<asp:Label ID="Label5" runat="server" Font-Size="14px" Font-Bold="true" Text="<%$ Resources:language, EnableSearch%>"></asp:Label> <asp:CheckBox ID="CheckBox4" runat="server" /><br /><asp:Literal runat="server" Text="<%$ Resources:language,EnableSearchexp%>" /><br /><br />
<asp:Label ID="Label20" runat="server" Font-Size="14px" Font-Bold="true" Text="<%$ Resources:language, EnableOnlineUsers%>"></asp:Label> <asp:CheckBox ID="CheckBox12" runat="server" /><br /><br />
<asp:Label ID="Label6" runat="server" Font-Size="14px" Font-Bold="true" Text="<%$ Resources:language, EnableArchiveMenu%>"></asp:Label> <asp:CheckBox ID="CheckBox5" runat="server" /><br />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
<asp:Literal runat="server" Text="<%$ Resources:language,Choosetype%>" />
<asp:Literal runat="server" Text="<%$ Resources:language,Simple%>" />: <asp:CheckBox ID="chkType1" oncheckedchanged="chkType1_CheckedChanged" Autopostback="True" runat="server" />
<asp:Literal runat="server" Text="<%$ Resources:language,Dropdown%>" />: <asp:CheckBox ID="chkType2" oncheckedchanged="chkType2_CheckedChanged" Autopostback="True" runat="server" /><br /><br />
    </ContentTemplate>
    </asp:UpdatePanel>
<asp:Label ID="Label12" runat="server" Font-Size="14px" Font-Bold="true" Text="<%$ Resources:language,Viewnumberart%>"></asp:Label> <asp:CheckBox ID="CheckBox1" runat="server" /><br /><asp:Literal ID="Literal1" runat="server" Text="<%$ Resources:language,Viewnumberartexp%>" /><br /><br />
<asp:Label ID="Label18" runat="server" Font-Size="14px" Font-Bold="true" Text="<%$ Resources:language,EnableTagBox%>"></asp:Label> <asp:CheckBox ID="CheckBox11" runat="server" /><br /><br />
<asp:Label ID="Label7" runat="server" Font-Size="14px" Font-Bold="true" Text="<%$ Resources:language,EnableEmailConfirmation%>"></asp:Label> <asp:CheckBox ID="CheckBox9" runat="server" /><br /><asp:Literal runat="server" Text="<%$ Resources:language,EnableEmailConfirmationexp%>" /><br /><asp:Literal runat="server" Text="<%$ Resources:language,EnableEmailConfirmationexp2%>" /><br />
    <asp:Label ID="lblsmtp" runat="server" Text="<%$ Resources:language,smtpserver%>"></asp:Label>: <asp:TextBox ID="txtSmtp" runat="server"></asp:TextBox> 
    <asp:Label ID="lblport" runat="server" Text="<%$ Resources:language,port%>"></asp:Label>: <asp:TextBox ID="txtPort" runat="server"></asp:TextBox> 
    <asp:Label ID="lblum" runat="server" Text="<%$ Resources:language,Useremail%>"></asp:Label>: <asp:TextBox ID="txtUserMail" runat="server"></asp:TextBox> 
    <asp:Label ID="lblpm" runat="server" Text="<%$ Resources:language,Passwordemail%>"></asp:Label>: <asp:TextBox ID="txtPswMail" runat="server"></asp:TextBox><br />
    <asp:Label ID="Label11" runat="server" Visible="false" ForeColor="Red"></asp:Label><br />
<asp:Button ID="UpdateSettings" runat="server" Text="<%$ Resources:language,Update%>" 
        onclick="UpdateSettings_Click" />


</div>