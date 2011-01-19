<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
<script src="http://ajax.googleapis.com/ajax/libs/jquery/1.4.2/jquery.js" type="text/javascript"
    language="javascript"></script>
<script type="text/javascript">
    $(document).ready(function () {
        $('#name').val('--- Please input ---');
        $('#name').blur(function () {
            if ($('#name').val() == '')
                $('#name').val('--- Please input ---');
        });
        $('#name').focus(function () {
            $('#name').val('');
        });
    });
</script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <p>
            <label for="name">
                User name:
            </label>
            <asp:TextBox runat="server" ID="name" />
        </p>
        <p>
            <label for="email">
                Email Address:</label>
            <asp:TextBox runat="server" ID="email" />
        </p>
    </div>
    </form>
</body>
</html>
