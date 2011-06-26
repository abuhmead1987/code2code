<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default2.aspx.cs" Inherits="Default2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.6.1/jquery.min.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript">
        function KeepSessionAlive() {
            // 1. Make request to server
            $.post('KeepSessionAlive.ashx', function (data) {
                var ret = $('#result');
                var temp = ret.html();
                ret.append(data + '</br>');
            });
        }
        setInterval(KeepSessionAlive, 5000);
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="result">
    </div>
    </form>
</body>
</html>
