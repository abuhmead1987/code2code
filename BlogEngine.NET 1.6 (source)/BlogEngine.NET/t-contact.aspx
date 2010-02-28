<%@ Page Title="" Language="C#" MasterPageFile="~/themes/thanhlien/site.master" AutoEventWireup="true"
    CodeFile="t-contact.aspx.cs" Inherits="t_contact" %>

<%@ Import Namespace="BlogEngine.Core" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphBody" runat="Server">
    <div class="center">
        <img src='<%=Page.ResolveUrl("themes/thanhlien/images/bg_mid_col.jpg")%>' width="128"
            height="39" /></div>
    <div id="contact">
        <div id="divForm" runat="server">
            <h1>
                <%=Resources.labels.contact %></h1>
            <div>
      <%=Resources.labels.contactSubTitle.ToString() %>
            </div>
            <label for="<%=txtName.ClientID %>">
                <%=Resources.labels.name %></label>
            <asp:TextBox runat="server" ID="txtName" CssClass="field" />
            <asp:RequiredFieldValidator ID="Requiredfieldvalidator1" runat="server" ControlToValidate="txtName"
                ErrorMessage="<%$Resources:labels, required %>" ValidationGroup="contact" /><br />
            <label for="<%=txtEmail.ClientID %>">
                <%=Resources.labels.email %></label>
            <asp:TextBox runat="server" ID="txtEmail" CssClass="field" />
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail"
                Display="dynamic" ErrorMessage="<%$Resources:labels, enterValidEmail %>" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                ValidationGroup="contact" />
            <asp:RequiredFieldValidator ID="Requiredfieldvalidator2" runat="server" ControlToValidate="txtEmail"
                ErrorMessage="<%$Resources:labels, required %>" ValidationGroup="contact" /><br />
            <label for="<%=txtSubject.ClientID %>">
                <%=Resources.labels.subject %></label>
            <asp:TextBox runat="server" ID="txtSubject" CssClass="field" />
            <asp:RequiredFieldValidator ID="Requiredfieldvalidator3" runat="server" ControlToValidate="txtSubject"
                ErrorMessage="<%$Resources:labels, required %>" ValidationGroup="contact" /><br />
            <label for="<%=txtMessage.ClientID %>">
                <%=Resources.labels.message %></label>
            <asp:TextBox runat="server" ID="txtMessage" TextMode="multiline" Rows="5" Columns="30" />
            <asp:RequiredFieldValidator ID="Requiredfieldvalidator4" runat="server" ControlToValidate="txtMessage"
                ErrorMessage="<%$Resources:labels, required %>" Display="dynamic" ValidationGroup="contact" />
            <asp:PlaceHolder runat="server" ID="phAttachment">
                <label for="<%=txtAttachment.ClientID %>">
                    <%=Resources.labels.attachFile %></label>
                <asp:FileUpload runat="server" ID="txtAttachment" />
            </asp:PlaceHolder>
            <br />
            <br />
            <asp:Button runat="server" ID="btnSend" Text="<%$Resources:labels, send %>" OnClientClick="return beginSendMessage();"
                ValidationGroup="contact" />
            <asp:Label runat="server" ID="lblStatus" Visible="false">This form does not work at the moment. Sorry for the inconvenience.</asp:Label>
        </div>
        <div id="thanks">
            <div id="divThank" runat="Server" visible="False">
                <%=BlogSettings.Instance.ContactThankMessage %>
            </div>
        </div>
    </div>

    <script type="text/javascript">
        function beginSendMessage() {
            if (BlogEngine.$('<%=txtAttachment.ClientID %>') && BlogEngine.$('<%=txtAttachment.ClientID %>').value.length > 0)
                return true;

            if (!Page_ClientValidate('contact'))
                return false;

            var name = BlogEngine.$('<%=txtName.ClientID %>').value;
            var email = BlogEngine.$('<%=txtEmail.ClientID %>').value;
            var subject = BlogEngine.$('<%=txtSubject.ClientID %>').value;
            var message = BlogEngine.$('<%=txtMessage.ClientID %>').value;
            var sep = '-||-';
            var arg = name + sep + email + sep + subject + sep + message;
            WebForm_DoCallback('__Page', arg, endSendMessage, 'contact', null, false)

            BlogEngine.$('<%=btnSend.ClientID %>').disabled = true;

            return false;
        }

        function endSendMessage(arg, context) {
            BlogEngine.$('<%=btnSend.ClientID %>').disabled = false;
            var form = BlogEngine.$('<%=divForm.ClientID %>')
            var thanks = BlogEngine.$('thanks');

            form.style.display = 'none';
            thanks.innerHTML = arg;
        }
    </script>

</asp:Content>
