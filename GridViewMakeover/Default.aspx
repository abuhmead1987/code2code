<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ASP.NET GridView makeover using CSS</title>
    <link type="text/css" rel="stylesheet" href="css/style.css" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="container">
        <h1>
            ASP.NET GridView makeover using CSS</h1>
        <asp:GridView ID="gvCustomres" runat="server" DataSourceID="customresDataSource"
            AutoGenerateColumns="False" GridLines="None" AllowPaging="true" CssClass="mGrid" PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt">
            <Columns>
                <asp:BoundField DataField="CompanyName" HeaderText="Company Name" />
                <asp:BoundField DataField="ContactName" HeaderText="Contact Name" />
                <asp:BoundField DataField="ContactTitle" HeaderText="Contact Title" />
                <asp:BoundField DataField="Address" HeaderText="Address" />
                <asp:BoundField DataField="City" HeaderText="City" />
                <asp:BoundField DataField="Country" HeaderText="Country" />
            </Columns>
        </asp:GridView>
        <asp:XmlDataSource ID="customresDataSource" runat="server" DataFile="~/App_Data/data.xml">
        </asp:XmlDataSource>
    </div>
    </form>
</body>
</html>
