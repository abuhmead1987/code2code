<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Building faq page using Linq2Xml and Jquery</title>
    <script src="jquery-1.2.6.min.js" type="text/javascript"></script>
    <style type="text/css">
        .divAnswer
        {
            display: none;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <h1>
        FAQ</h1>
    <div class="faqs">
        <% foreach (var item in faqsElement)
           { %>
        <div class="faq">
            <a href="#" class="question">
                <%= item.Attribute("question").Value %></a><br />
            <div class="divAnswer">
                <%= item.Attribute("answer").Value%>
            </div>
        </div>
        <% } %>
    </div>
    </form>
</body>
<script type="text/javascript">
    $(document).ready(function () {
        $("a.question").click(function () {
            $(this).parent().find("div.divAnswer").slideToggle();
        })
    });
</script>
</html>
