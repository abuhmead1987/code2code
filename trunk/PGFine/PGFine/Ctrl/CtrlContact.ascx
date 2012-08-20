<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlContact.ascx.cs"
    Inherits="PGFine.Ctrl.CtrlContact" %>

<script type="text/javascript">
         function validateName(oSrc, args){     
    var isHasFile = false;          
    var txtName = $get('<%=this.txtName.ClientID%>');   
    if(txtName !=null)
    {         
        isHasFile = txtName.value.length > 0 && txtName.value.length < 200;
    }
    args.IsValid = isHasFile;
  }  
   function validatePhone(oSrc, args){     
    var isHasFile = false;          
    var txtName = $get('<%=this.txtPhone.ClientID%>');   
    if(txtName !=null)
    {         
        isHasFile = txtName.value.length > 0;
    }
    args.IsValid = isHasFile;
  }     
  function validateEmail(oSrc, args){     
    var isHasFile = false;          
    var txtEmail = $get('<%=this.txtEmail.ClientID%>');   
    if(txtEmail !=null)
    {         
        isHasFile = txtEmail.value.length > 0 && txtEmail.value.length < 50;
    }
    args.IsValid = isHasFile;
  }    
    function validateAddress(oSrc, args){     
    var isHasFile = false;          
    var txtName = $get('<%=this.txtAddress.ClientID%>');   
    if(txtName !=null)
    {         
        isHasFile = txtName.value.length > 0;
    }
    args.IsValid = isHasFile;
  }    
   function validateContent(oSrc, args){     
    var isHasFile = false;          
    var txtName = $get('<%=this.txtContent.ClientID%>');   
    if(txtName !=null)
    {         
        isHasFile = txtName.value.length > 0;
    }
    args.IsValid = isHasFile;
  }     
  
</script>

<div class="ContactLeft">
    <asp:Label ID="_errorLabel" runat="server" Text="" Visible="false"></asp:Label>
    <div class="CaptionContact">
        <asp:Label ID="lbInformation" runat="server" Text="Để liên hệ với chúng tôi, các bạn vui lòng cung cấp đầy đủ các thông tin bên dưới, thông tin có (*) là nên có để chúng tôi phục vụ các bạn tốt hơn."></asp:Label></div>
    <div class="PaceContact">
        <asp:Label ID="lbName" runat="server" Text="Your Name (*)" Width="100px" CssClass="TitleContact"></asp:Label>
        <asp:TextBox ID="txtName" runat="server" ValidationGroup="ValidateCheck" CssClass="textboxContact"></asp:TextBox>
        <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="Chiều dài >0 và <200 ký tự."
            Display="Dynamic" ValidationGroup="ValidateCheck" ClientValidationFunction="validateName"
            CssClass="ValidateMess"></asp:CustomValidator>
    </div>
    <div class="PaceContact">
        <asp:Label ID="lbPhone" runat="server" Text="Phone (*)" Width="100px" CssClass="TitleContact"></asp:Label>
        <asp:TextBox ID="txtPhone" runat="server" ValidationGroup="ValidateCheck" CssClass="textboxContact"></asp:TextBox>
        <asp:CustomValidator ID="CustomValidator4" runat="server" ErrorMessage="Chiều dài >0."
            Display="Dynamic" ValidationGroup="ValidateCheck" ClientValidationFunction="validatePhone"
            CssClass="ValidateMess"></asp:CustomValidator>
    </div>
    <div class="PaceContact">
        <asp:Label ID="lbEmail" runat="server" Text="Email (*)" CssClass="TitleContact"></asp:Label>
        <asp:TextBox ID="txtEmail" runat="server" ValidationGroup="ValidateCheck" CssClass="textboxContact"
            TabIndex="2"></asp:TextBox>
        <asp:CustomValidator ID="CustomValidator5" runat="server" ErrorMessage="Email <> rỗng và < 50 ký tự."
            Display="Dynamic" CssClass="ValidateMess" ValidationGroup="ValidateCheck" ClientValidationFunction="validateEmail"></asp:CustomValidator>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail"
            ValidationExpression="[\w]+@[\w]+\.(com|net|org|co\.th|go\.th|ac\.th|or\.th|go\.th)"
            Display="Dynamic" ErrorMessage="Email chưa đúng định dạng!" ValidationGroup="ValidateCheck"
            CssClass="ValidateMess"></asp:RegularExpressionValidator>
    </div>
    <div class="PaceContact">
        <asp:Label ID="lbAddress" runat="server" Text="Address (*)" CssClass="TitleContact"></asp:Label>
        <asp:TextBox ID="txtAddress" runat="server" CssClass="textboxContact" TabIndex="3"
            ValidationGroup="ValidateCheck"></asp:TextBox>
        <asp:CustomValidator ID="CustomValidator3" runat="server" ErrorMessage="Chiều dài >0."
            ValidationGroup="ValidateCheck" Display="Dynamic" ClientValidationFunction="validateAddress"
            CssClass="ValidateMess"></asp:CustomValidator>
    </div>
    <div class="PaceContact">
        <asp:Label ID="lbContent" runat="server" Text="Content (*)" CssClass="TitleContact"></asp:Label>
        <asp:TextBox ID="txtContent" runat="server" Height="120px" TextMode="MultiLine" CssClass="TextModeContac"
            ValidationGroup="ValidateCheck" TabIndex="4"></asp:TextBox>
        <asp:CustomValidator ID="CustomValidator2" runat="server" ErrorMessage="Chiều dài >0."
            ValidationGroup="ValidateCheck" Display="Dynamic" ClientValidationFunction="validateContent"
            CssClass="ValidateMess"></asp:CustomValidator>
    </div>
    <div class="PaceContactBT">
        <asp:LinkButton ID="btSent" runat="server" OnClick="btSent_Click" ValidationGroup="ValidateCheck"
            TabIndex="5" CssClass="linkButtonContac" Text="Gửi"></asp:LinkButton>
        <asp:LinkButton ID="lbtReset" runat="server" CssClass="linkButtonContac" OnClick="lbtReset_Click" Text="Làm lại"></asp:LinkButton>
        <asp:Label ID="ltrSuccess" runat="server" Text="Thông tin được gửi thành công!" CssClass="MessageSuccess"
            Visible="false"></asp:Label>
    </div>
</div>
