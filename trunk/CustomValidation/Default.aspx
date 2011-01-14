<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>CustomValidator in asp.net</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:RadioButton Text="Male" ID="male" runat="server" GroupName="gender" ValidationGroup="genderValidation" />
        &nbsp
        <asp:RadioButton Text="FeMale" ID="female" runat="server" GroupName="gender" ValidationGroup="genderValidation" />
        <br />
        <asp:CustomValidator ID="cusGenderValidation" runat="server" ClientValidationFunction="ClientCheckGender"
            OnServerValidate="ServerCheckGender" ValidationGroup="genderValidation" ErrorMessage="Please select your gender"
            EnableClientScript="true" Display="Dynamic" ForeColor="Red"></asp:CustomValidator>
        <br />
        <asp:Button Text="Submit" runat="server" ID="btnSubmit" OnClick="btnSubmit_Click"
            ValidationGroup="genderValidation" />
    </div>
    <script type="text/javascript">
        function ClientCheckGender(sender, args) {
            var male = document.getElementById('male');
            var female = document.getElementById('female');
            if (male.checked == true || female.checked == true) {
                args.IsValid = true;
            }
        }
    </script>
    </form>
</body>
</html>
