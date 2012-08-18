<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AddTemplate.ascx.cs" Inherits="Controls_AddTemplate" %>
<%@ Register src="AdminMenu.ascx" tagname="AdminMenu" tagprefix="uc1" %>

    <uc1:AdminMenu ID="AdminMenu1" runat="server" />
<div style="padding:5px">
    <asp:Label ID="Label1" runat="server" Text="<%$ Resources:language, Templatename%>"></asp:Label> 
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox><br />
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="<%$ Resources:language, RequiredField%>" ControlToValidate="TextBox1"></asp:RequiredFieldValidator><br />
    <asp:Label ID="Label2" runat="server" Text="<%$ Resources:language, Author%>"></asp:Label>: 
    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox><br />
    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="<%$ Resources:language, RequiredField%>" ControlToValidate="TextBox2"></asp:RequiredFieldValidator><br />
    <asp:Label ID="Label3" runat="server" Text="<%$ Resources:language, AuthorSite%>"></asp:Label> 
    <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox><br />
    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="<%$ Resources:language, RequiredField%>" ControlToValidate="TextBox3"></asp:RequiredFieldValidator><br />
    <asp:Literal ID="Literal1" runat="server" Text="<%$ Resources:language, UploadFile%>" /> <asp:FileUpload ID="FileUpload1" runat="server"/><br /> 
    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="<%$ Resources:language, RequiredField%>" ControlToValidate="FileUpload1"></asp:RequiredFieldValidator><br />
    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="You have to upload a .css file" ControlToValidate="FileUpload1" ValidationExpression="^.+\.((css)|(CSS))$"></asp:RegularExpressionValidator><br />
    <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="<%$ Resources:language, Add%>" /><br />
    <asp:Label ID="lblerror" runat="server" ForeColor="Red" Visible="false"></asp:Label>
</div>