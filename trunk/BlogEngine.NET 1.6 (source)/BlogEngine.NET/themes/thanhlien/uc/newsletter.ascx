<%@ Control Language="C#" AutoEventWireup="true" CodeFile="newsletter.ascx.cs" Inherits="themes_thanhlien_uc_newsletter" %>
<div id="newsletterform">
    <img src='<%=Page.ResolveUrl("~/themes/thanhlien/images/header_dangky.jpg")%>' alt="Đăng ký nhận tin"
        width="201" height="55" />
    <p class="center">
        <label for="<%=txtEmail.ClientID %>" style="font-weight: bold">
            <%= Resources.labels.EmailNewLetter.ToString() %></label><br />
    </p>
    <p class="dangky">
        <asp:TextBox runat="server" ID="txtEmail" Width="158px" />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtEmail"
            ErrorMessage="Please enter an e-mail address" Display="dynamic" ValidationGroup="newsletter" />
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail"
            ErrorMessage="<%$Resources:labels, enterValidEmail %>" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
            Display="dynamic" ValidationGroup="newsletter" />
        <div style="text-align: center">
            <asp:ImageButton ID="btnSave" runat="server" ValidationGroup="newsletter" Text="Notify me"
                OnClientClick="return beginAddEmail()" ImageUrl="~/themes/thanhlien/images/btn_dangky.gif" />
        </div>
    </p>
</div>
<div id="newsletterthanks" style="display: none; text-align: center">
    <h2 id="newsletteraction">
        <%= Resources.labels.Thanks.ToString()%></h2>
</div>

<script type="text/javascript">
  function beginAddEmail()
  {
    if(!Page_ClientValidate('newsletter'))
      return false;
      
    var arg = BlogEngine.$('<%=txtEmail.ClientID %>').value;
    var context = 'newsletter';
    <%=Page.ClientScript.GetCallbackEventReference(this, "arg", "endAddEmail", "context") %>;
    
    return false;
  }
  
  function endAddEmail(arg, context)
  {
    BlogEngine.$('newsletterform').style.display = 'none';
    BlogEngine.$('newsletterthanks').style.display = 'block';
    if (arg == "false")
    {
      BlogEngine.$('newsletteraction').innerHTML = "You are now unsubscribed";
    }
  }
</script>

