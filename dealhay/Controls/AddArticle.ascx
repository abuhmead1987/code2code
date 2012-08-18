<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AddArticle.ascx.cs" Inherits="Controls_AddArticle" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<%@ Register src="AdminMenu.ascx" tagname="AdminMenu" tagprefix="uc1" %>

<uc1:AdminMenu ID="AdminMenu1" runat="server" />
<div style="padding:5px">
* = <asp:Literal runat="server" Text="<%$ Resources:language, Optional%>" />
<br />
    <asp:Button ID="Button1" runat="server" Text="<%$ Resources:language, AddArticleNews%>" onclick="NewArticle" /> <asp:Label ID="Label2" runat="server" ForeColor="Red" Visible="false"></asp:Label>
<br /><br />
<b><asp:Literal runat="server" Text="<%$ Resources:language, Title%>" />:</b> <asp:TextBox ID="txtTitle" runat="server" Width="340px"></asp:TextBox><asp:RegularExpressionValidator
            ID="RegularExpressionValidator1" runat="server" ValidationExpression="^[^<>]{1,2000}$" ControlToValidate = "txtTitle" ErrorMessage="You cannot use these characters: < >"></asp:RegularExpressionValidator><br />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate = "txtTitle" ForeColor="Red" ErrorMessage="<%$ Resources:language, Insertatitle%>"></asp:RequiredFieldValidator><br />
<b>*<asp:Literal runat="server" Text="<%$ Resources:language, Image%>" />:</b> <asp:FileUpload ID="FileUpload1" FileName='<%# Eval("image")%>' runat="server" /> <asp:Literal ID="Literal1" runat="server" Text="<%$ Resources:language, or%>" />
               <asp:DropDownList ID="DDimages" runat="server" onselectedindexchanged="DDimages_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
               <asp:Image ID="ddimg" Width="150px" runat="server" Visible="false" /><br />
        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="<%$ Resources:language, ImageFormat%>" ControlToValidate="FileUpload1" ValidationExpression="^.+\.((jpg)|(gif)|(jpeg)|(png)|(bmp)|(psd)|(JPG)|(JPEG)|(GIF)|(PNG)|(BMP)|(PSD))$"></asp:RegularExpressionValidator><br />
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:anmcs %>" 
        SelectCommand="anm_getCategories" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
    <asp:Table ID="Table1" Width="80%" runat="server">
        <asp:TableRow>
            <asp:TableCell>
                <b><asp:Literal runat="server" Text="<%$ Resources:language, Category%>" />:</b> <asp:DropDownList ID="ddlcategory" runat="server" DataSourceID="SqlDataSource1" DataTextField="category" DataValueField="idcategory" AppendDataBoundItems="true">
                        <asp:ListItem>Select a category:</asp:ListItem>        
                    </asp:DropDownList>
                <asp:HyperLink ID="HLAddCategory" Target="_blank" Text="<%$ Resources:language, Addcategory%>" runat="server"></asp:HyperLink>
                    <br /><asp:Label ID="lblCategoryerr" runat="server" Text="<%$ Resources:language, Selectcategory%>" ForeColor="Red" Font-Bold="true" Visible="false"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                    <b><asp:Literal ID="Literal2" runat="server" Text="<%$ Resources:language, AllowComments%>" /></b> <asp:CheckBox ID="chkComments" Checked="true" runat="server" /> 
            </asp:TableCell>
            <asp:TableCell>
            <b><asp:Literal ID="Literal3" runat="server" Text="<%$ Resources:language, Viewpostedby%>" /></b> <asp:CheckBox ID="chkPB" Checked="true" runat="server" />
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
<b><asp:Literal runat="server" Text="<%$ Resources:language, Highlight%>" /></b> <asp:CheckBox ID="chkHL" runat="server" /> 
            </asp:TableCell>
            <asp:TableCell>
<b><asp:Literal runat="server" Text="<%$ Resources:language, SetasaSideNews%>" /></b> <asp:CheckBox ID="chkSN" runat="server" /> 
            </asp:TableCell>
            <asp:TableCell>
<b><asp:Literal runat="server" Text="<%$ Resources:language, HomePageSlideShow%>" /></b> <asp:CheckBox ID="chkSS" runat="server" />
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
<b>*<asp:Literal runat="server" Text="<%$ Resources:language, Tags%>" /></b>
        <asp:TextBox ID="txtTags" Width="280px" runat="server"></asp:TextBox> <asp:Literal runat="server" Text="<%$ Resources:language, Tagscommas%>" /><br /><asp:RegularExpressionValidator
            ID="RegularExpressionValidator3" runat="server" ValidationExpression="^[^<>]{1,2000}$" ControlToValidate = "txtTags" ErrorMessage="You cannot use these characters: < >"></asp:RegularExpressionValidator><br />
<b>*<asp:Literal runat="server" Text="<%$ Resources:language, Summary%>" />:</b> <br />
<CKEditor:CKEditorControl ID="txtSummary" Width="81%" Height="75px" BasePath="~/ckeditor" EnterMode="BR" Entities="false" runat="server"></CKEditor:CKEditorControl><br />
<b><asp:Literal runat="server" Text="<%$ Resources:language, ArticleNews%>" />: </b> <br />
<CKEditor:CKEditorControl ID="txtNews" Width="81%" Height="190px" BasePath="~/ckeditor" EnterMode="BR" Entities="false" runat="server"></CKEditor:CKEditorControl><br />
    <asp:Button ID="Button2" runat="server" Text="<%$ Resources:language, AddArticleNews%>" onclick="NewArticle" /> <asp:Label ID="Label1" runat="server" ForeColor="Red" Visible="false"></asp:Label>
<br />
* = <asp:Literal runat="server" Text="<%$ Resources:language, Optional%>" />
</div>