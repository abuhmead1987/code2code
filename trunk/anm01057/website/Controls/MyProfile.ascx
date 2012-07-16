<%@ Control Language="C#" AutoEventWireup="true" CodeFile="MyProfile.ascx.cs" Inherits="Controls_MyProfile" %>
<%@ Register Src="SearchMenu.ascx" TagName="SearchMenu" TagPrefix="uc1" %>
<%@ Register Src="SideMenu.ascx" TagName="SideMenu" TagPrefix="uc1" %>
<%@ Register Src="ArchiveMenu.ascx" TagName="ArchiveMenu" TagPrefix="uc1" %>
<%@ Register Src="RecentArticles.ascx" TagName="RecentArticles" TagPrefix="uc1" %>
<%@ Register Src="RecentComments.ascx" TagName="RecentComments" TagPrefix="uc1" %>
<%@ Register Src="TagBox.ascx" TagName="TagBox" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<div id="anmcontent" class="anmcontent">
    <asp:Literal runat="server" Text="<%$ Resources:language, Hi%>" />
    <asp:LoginName ID="LoginName1" Font-Bold="true" runat="server" />
    .
    <asp:Literal runat="server" Text="<%$ Resources:language, modifyaccmsg%>" /><br />
    <br />
    <br />
    <asp:TabContainer runat="server" ID="TabContainer1" ActiveTabIndex="5">
        <asp:TabPanel runat="server" ID="TabPanel1" HeaderText="<%$ Resources:language, Password%>"
            Enabled="true">
            <ContentTemplate>
                <asp:ChangePassword ID="ChangePassword1" runat="server">
                </asp:ChangePassword>
                <br />
                <br />
                <br />
            </ContentTemplate>
        </asp:TabPanel>
        <asp:TabPanel runat="server" ID="TabPanel2" HeaderText="<%$ Resources:language, Email%>">
            <ContentTemplate>
                <asp:Literal runat="server" Text="<%$ Resources:language, Changemailadd%>" /><br />
                <asp:TextBox ID="TextBoxEmail" runat="server"></asp:TextBox>
                <asp:Button ID="ButtonEmail" runat="server" Text="<%$ Resources:language, ChangeEmail%>"
                    OnClick="ButtonEmail_Click" />
                <br />
                <br />
                <asp:Label ID="lblEmail" ForeColor="Red" runat="server" Visible="false"></asp:Label><br />
                <br />
                <br />
            </ContentTemplate>
        </asp:TabPanel>
        <asp:TabPanel runat="server" ID="TabPanel5" HeaderText="Avatar">
            <ContentTemplate>
                <asp:Literal ID="LitAvatar" runat="server" Text="<%$ Resources:language, UploadFile%>" /></b>
                <asp:FileUpload ID="FUAvatar" runat="server" />
                <asp:Button ID="BtnAvatar" runat="server" Text="<%$ Resources:language, Send%>" OnClick="UploadAvatar" />
                <br />
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="<%$ Resources:language, ImageFormat%>"
                    ControlToValidate="FUAvatar" ValidationExpression="^.+\.((jpg)|(gif)|(jpeg)|(png)|(bmp)|(psd)|(JPG)|(JPEG)|(GIF)|(PNG)|(BMP)|(PSD))$"></asp:RegularExpressionValidator><br />
                <br />
                <asp:Label ID="LTAvatarOk" Visible="false" Text="<%$ Resources:language, FileUploaded%>"
                    ForeColor="Red" runat="server"></asp:Label><br />
                <asp:Image ID="ImgAvatar" AlternateText="User Avatar" runat="server" /><br />
            </ContentTemplate>
        </asp:TabPanel>
        <asp:TabPanel runat="server" ID="TabPanel3" HeaderText="<%$ Resources:language, SecurityQuestion%>">
            <ContentTemplate>
                <asp:Literal runat="server" Text="<%$ Resources:language, ChangeQA%>" /><br />
                <br />
                <br />
                <asp:Literal runat="server" Text="<%$ Resources:language, YourPsw%>" /><br />
                <asp:TextBox ID="txtpswqa" runat="server" TextMode="Password"></asp:TextBox><br />
                <asp:Literal runat="server" Text="<%$ Resources:language, NewQA%>" /><br />
                <asp:TextBox ID="txtquestion" runat="server"></asp:TextBox><br />
                <asp:Literal runat="server" Text="<%$ Resources:language, NewAnswer%>" /><br />
                <asp:TextBox ID="txtanswer" runat="server"></asp:TextBox><br />
                <br />
                <asp:Button ID="BtnSecurity" runat="server" Text="<%$ Resources:language, ChangeQAbtn%>"
                    OnClick="ButtonQa_Click" />
                <br />
                <asp:Label ID="lblQa" ForeColor="Red" runat="server" Visible="false"></asp:Label><br />
                <br />
                <br />
            </ContentTemplate>
        </asp:TabPanel>
        <asp:TabPanel runat="server" ID="TabPanel4" HeaderText="<%$ Resources:language, DeleteAcc%>">
            <ContentTemplate>
                <asp:Literal runat="server" Text="<%$ Resources:language, DeleteAccount%>" /><br />
                <br />
                <asp:Label ID="lbl1" ForeColor="Red" runat="server"></asp:Label><br />
                <br />
                <asp:Button ID="DtnDeletMe" runat="server" Text="<%$ Resources:language, DeleteMe%>"
                    OnClientClick="return confirm('Confirm ?')" OnClick="Button1_Click" />
                <asp:Label ID="lblalert" ForeColor="Red" runat="server" Text=""></asp:Label>
            </ContentTemplate>
        </asp:TabPanel>
        <asp:TabPanel ID="TabPanel6" runat="server" HeaderText="Customer Information">
            <ContentTemplate>
            Fullname: <asp:TextBox ID="txtFullname" runat="server"></asp:TextBox> <br />
            Sex: 
                <asp:RadioButton ID="radMale" runat="server" Text="Male" Checked="True" />
                <asp:RadioButton ID="radFemale" runat="server" Text="Female"/>
            <br /> Homepage: <asp:TextBox ID="txtHomepage" runat="server"></asp:TextBox>
                <br />
                 Phone: <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox>

                 <br />
                 Tên đường: <asp:TextBox ID="txtStreetName" runat="server"></asp:TextBox>
                 Số nhà: <asp:TextBox ID="txtHouseNumber" runat="server"></asp:TextBox>
                 Phường: <asp:TextBox ID="txtWard" runat="server"></asp:TextBox>
                 Quận: <asp:TextBox ID="txtDistrict" runat="server"></asp:TextBox>
                 <br />
                <asp:Button ID="btnUpdateProfile" runat="server" Text="Update" 
                    onclick="btnUpdateProfile_Click" />
            </ContentTemplate>
        </asp:TabPanel>
    </asp:TabContainer>
</div>
<div id="anmsidebar" class="anmsidebar">
    <uc1:SearchMenu ID="SearchMenu1" runat="server" />
    <uc1:SideMenu ID="SideMenu1" runat="server" />
    <uc1:ArchiveMenu ID="ArchiveMenu1" runat="server" />
    <uc1:TagBox ID="TagBox" runat="server" />
    <uc1:RecentArticles ID="RecentArticles1" runat="server" />
    <uc1:RecentComments ID="RecentComments1" runat="server" />
</div>
