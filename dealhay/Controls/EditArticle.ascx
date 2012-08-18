<%@ Control Language="C#" AutoEventWireup="true" CodeFile="EditArticle.ascx.cs" Inherits="Controls_EditArticle" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<%@ Register src="AdminMenu.ascx" tagname="AdminMenu" tagprefix="uc1" %>

    <uc1:AdminMenu ID="AdminMenu1" runat="server" />
<div style="padding:5px">
* = <asp:Literal runat="server" Text="<%$ Resources:language, Optional%>" />
<br /><br />
    <asp:Button ID="Button1" runat="server" Text="<%$ Resources:language, Edit%>" onclick="EditArticle" /> - <asp:Button ID="Button3" runat="server" Text="<%$ Resources:language, Delete%>" onclick="DeleteArticle" OnClientClick="return confirm('Are you sure to delete this article ?')" /> <asp:Label ID="Label2" runat="server" ForeColor="Red" Visible="false"></asp:Label> - <asp:HyperLink ID="HLcopy" Text="<%$ Resources:language, Copy%>" runat="server"></asp:HyperLink>
<br /><br />
<b><asp:Literal runat="server" Text="<%$ Resources:language, Title%>" />:</b> <asp:TextBox ID="txtTitle" runat="server" Width="340px"></asp:TextBox><asp:RegularExpressionValidator
            ID="RegularExpressionValidator1" runat="server" ValidationExpression="^[^<>]{1,2000}$" ControlToValidate = "txtTitle" ErrorMessage="You cannot use these characters: < >"></asp:RegularExpressionValidator><br />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate = "txtTitle" ErrorMessage="<%$ Resources:language, Insertatitle%>"></asp:RequiredFieldValidator><br />
<b>*<asp:Literal runat="server" Text="<%$ Resources:language, Image%>" />:</b> 
            <asp:TextBox ID="txtImage" ReadOnly="true" runat="server"></asp:TextBox>
            <asp:Button ID="BtnRemove" runat="server" Text="<%$ Resources:language, Remove%>" Visible="false" onclick="BtnRemove_Click" /> 
            <asp:Button ID="BtnInsert" runat="server" Text="<%$ Resources:language, InsertNewImage%>" onclick="BtnInsert_Click" />
            <asp:FileUpload ID="FileUpload1" runat="server" Visible="false"/> <asp:Label ID="lblor" runat="server" Text="<%$ Resources:language, or%>" Visible="false"></asp:Label> 
               <asp:DropDownList ID="DDimages" runat="server" onselectedindexchanged="DDimages_SelectedIndexChanged" AutoPostBack="true" Visible="false"></asp:DropDownList>
               <asp:Image ID="ddimg" Width="150px" runat="server" Visible="false"/><br />
          <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="<%$ Resources:language, ImageFormat%>" ControlToValidate="FileUpload1" ValidationExpression="^.+\.((jpg)|(gif)|(jpeg)|(png)|(bmp)|(psd)|(JPG)|(JPEG)|(GIF)|(PNG)|(BMP)|(PSD))$"></asp:RegularExpressionValidator><br />
<b><asp:Literal runat="server" Text="<%$ Resources:language, Category%>" />:</b> <asp:DropDownList ID="ddlcategory" runat="server" 
        DataSourceID="SqlDataSource1" DataTextField="category" 
        DataValueField="idcategory"></asp:DropDownList><br /><br />
<b><asp:Literal runat="server" Text="<%$ Resources:language, Date%>" />:</b>
        <asp:TextBox ID="txtdate" runat="server"></asp:TextBox>
        <asp:ImageButton ID="ImgBntCalc" runat="server" ImageUrl="~/images/CalendarIcon.gif" CausesValidation="False" />
        <asp:CalendarExtender ID="CalendarExtender1" TargetControlID="txtdate" Format="MMMM d, yyyy" PopupButtonID="ImgBntCalc" runat="server">
        </asp:CalendarExtender>
        <br /><br />
<b><asp:Literal runat="server" Text="<%$ Resources:language, AllowComments%>" /></b> <asp:CheckBox ID="chkComments" runat="server" /><br /><br />
<b><asp:Literal runat="server" Text="<%$ Resources:language, Viewpostedby%>" /></b> <asp:CheckBox ID="chkPB" runat="server" /><br /><br />
<b><asp:Literal runat="server" Text="<%$ Resources:language, Publish%>" /></b> <asp:CheckBox ID="chkPub" runat="server" /><br /><br />
<b><asp:Literal runat="server" Text="<%$ Resources:language, Highlight%>" /></b> <asp:CheckBox ID="chkHL" runat="server" /><br /><br />
<b><asp:Literal runat="server" Text="<%$ Resources:language, SetasaSideNews%>" /></b> <asp:CheckBox ID="chkSN" runat="server" /><br /><br />
<b><asp:Literal runat="server" Text="<%$ Resources:language, HomePageSlideShow%>" /></b> <asp:CheckBox ID="chkSS" runat="server" /><br /><br />
<b>*<asp:Literal runat="server" Text="<%$ Resources:language, Tags%>" /></b>
        <asp:TextBox ID="txtTags" Width="280px" runat="server"></asp:TextBox> <asp:Literal runat="server" Text="<%$ Resources:language, Tagscommas%>" /><br /><asp:RegularExpressionValidator
            ID="RegularExpressionValidator3" runat="server" ValidationExpression="^[^<>]{1,2000}$" ControlToValidate = "txtTags" ErrorMessage="You cannot use these characters: < >"></asp:RegularExpressionValidator><br />
<b>*<asp:Literal runat="server" Text="<%$ Resources:language, Summary%>" />:</b> <br />
<CKEditor:CKEditorControl ID="txtSummary" Width="81%" Height="120px" BasePath="~/ckeditor" EnterMode="BR" Entities="false" runat="server"></CKEditor:CKEditorControl><br />
<b><asp:Literal runat="server" Text="<%$ Resources:language, ArticleNews%>" />: </b> <br />
<CKEditor:CKEditorControl ID="txtNews" Width="81%" Height="350px" BasePath="~/ckeditor" EnterMode="BR" Entities="false" runat="server"></CKEditor:CKEditorControl><br />
    <asp:Label ID="Label1" runat="server" ForeColor="Red" Visible="false"></asp:Label><br />
    <asp:Button ID="Button2" runat="server" Text="<%$ Resources:language, Edit%>" onclick="EditArticle" /> - <asp:Button ID="Button4" runat="server" Text="<%$ Resources:language, Delete%>" onclick="DeleteArticle" OnClientClick="return confirm('Are you sure to delete this article ?')" /> - <asp:HyperLink ID="HLcopy2" Text="<%$ Resources:language, Copy%>" runat="server"></asp:HyperLink>
<br /><br />
* = <asp:Literal runat="server" Text="<%$ Resources:language, Optional%>" />
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:anmcs %>" 
        SelectCommand="anm_getCategories" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
</div>