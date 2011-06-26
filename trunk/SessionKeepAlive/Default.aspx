<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>How to keep session is alive using prototype</title>
    <script src="https://ajax.googleapis.com/ajax/libs/prototype/1.7.0.0/prototype.js"
        type="text/javascript"></script>
    <script language="javascript" type="text/javascript">
        function KeepSessionAlive() {
            new Ajax.Request('KeepSessionAlive.ashx', {
                method: 'post',
                onSuccess: function (transport) {
                    var ret = $('result');
                    var temp = ret.innerHTML;
                    ret.update(temp + '</br>' + transport.responseText);
                }
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
