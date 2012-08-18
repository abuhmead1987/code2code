<%@ Page Language="C#" AutoEventWireup="true" CodeFile="install.aspx.cs" Inherits="install" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>AllNewsManager.NET installation wizard</title>
</head>
<body>
    <form id="form1" runat="server">
    <div align="center">
        <asp:Image ID="Image1" ImageUrl="~/images/banner_anm2.png" runat="server" />
    <h1>AllNewsManager.NET installation wizard</h1>
        <asp:Panel ID="pnlInstall" runat="server">
        Set up your site:<br /><br />    
    Site Name: <asp:TextBox ID="tbSiteName" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tbSiteName" ForeColor="Red" ErrorMessage="Required Field"></asp:RequiredFieldValidator><br /><br />
    Site Email: <asp:TextBox ID="tbMailServer" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="tbMailServer" ForeColor="Red" ErrorMessage="Required Field"></asp:RequiredFieldValidator><br /><asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="tbMailServer" ForeColor="Red" ValidationExpression="^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$" ErrorMessage="Insert a valid email"></asp:RegularExpressionValidator><br />
    Site Url: <asp:TextBox ID="tbSiteUrl" Text="http://" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="tbSiteUrl" ForeColor="Red" ErrorMessage="Required Field"></asp:RequiredFieldValidator><br /><br />
        </asp:Panel>
        <asp:Button ID="Button1" runat="server" Text="Click to install" Font-Size="Large" onclick="Button1_Click" /><br />
        <asp:Label ID="Label1" runat="server" Text="Error!!! Check the web.config connectionString or check you have the host name and credentials with DBO access to the database." ForeColor="Red" Visible="false"></asp:Label>

    </div>
    </form>
</body>
</html>
