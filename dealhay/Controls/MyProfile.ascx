<%@ Control Language="C#" AutoEventWireup="true" CodeFile="MyProfile.ascx.cs" Inherits="Controls_MyProfile" %>
	    <%@ Register src="SearchMenu.ascx" tagname="SearchMenu" tagprefix="uc1" %>
	    <%@ Register src="SideMenu.ascx" tagname="SideMenu" tagprefix="uc1" %>
	    <%@ Register src="ArchiveMenu.ascx" tagname="ArchiveMenu" tagprefix="uc1" %>
	    <%@ Register src="RecentArticles.ascx" tagname="RecentArticles" tagprefix="uc1" %>
	    <%@ Register src="RecentComments.ascx" tagname="RecentComments" tagprefix="uc1" %>
        <%@ Register src="TagBox.ascx" tagname="TagBox" tagprefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

    <div id="anmcontent" class="anmcontent">
     <asp:Literal runat="server" Text="<%$ Resources:language, Hi%>" /> <asp:LoginName ID="LoginName1" Font-Bold="true" runat="server" />. <asp:Literal runat="server" Text="<%$ Resources:language, modifyaccmsg%>" /><br /><br /><br />

<asp:TabContainer runat="server" ID="TabContainer1">       
        <asp:TabPanel runat="server" ID="TabPanel1" HeaderText="<%$ Resources:language, Password%>" Enabled="true">
            <ContentTemplate>
                <asp:ChangePassword ID="ChangePassword1" runat="server">
                </asp:ChangePassword><br /><br /><br />
            </ContentTemplate>
        </asp:TabPanel>
       
        <asp:TabPanel runat="server" ID="TabPanel2" HeaderText="<%$ Resources:language, Email%>">
            <ContentTemplate>
                <asp:Literal runat="server" Text="<%$ Resources:language, Changemailadd%>" /><br/> 
                <asp:TextBox ID="TextBoxEmail" runat="server"></asp:TextBox> 
                <asp:Button ID="ButtonEmail" runat="server" Text="<%$ Resources:language, ChangeEmail%>" 
                    onclick="ButtonEmail_Click" /> <br /><br />
                <asp:Label ID="lblEmail" ForeColor="Red" runat="server" Visible="false"></asp:Label><br /><br /><br />
            </ContentTemplate>
        </asp:TabPanel>

        <asp:TabPanel runat="server" ID="TabPanel5" HeaderText="Avatar">
            <ContentTemplate>
                <asp:Literal ID="LitAvatar" runat="server" Text="<%$ Resources:language, UploadFile%>" /></b> <asp:FileUpload ID="FUAvatar" runat="server" /> <asp:Button ID="BtnAvatar" runat="server" Text="<%$ Resources:language, Send%>" OnClick="UploadAvatar" /> <br />
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="<%$ Resources:language, ImageFormat%>" ControlToValidate="FUAvatar" ValidationExpression="^.+\.((jpg)|(gif)|(jpeg)|(png)|(bmp)|(psd)|(JPG)|(JPEG)|(GIF)|(PNG)|(BMP)|(PSD))$"></asp:RegularExpressionValidator><br />
                <br />
                <asp:Label ID="LTAvatarOk" Visible="false" Text="<%$ Resources:language, FileUploaded%>" ForeColor="Red" runat="server"></asp:Label><br />
                <asp:Image ID="ImgAvatar" AlternateText="User Avatar" runat="server" /><br />
            </ContentTemplate>
        </asp:TabPanel>
       
        <asp:TabPanel runat="server" ID="TabPanel3" HeaderText="<%$ Resources:language, SecurityQuestion%>">
            <ContentTemplate>
                <asp:Literal runat="server" Text="<%$ Resources:language, ChangeQA%>" /><br/><br/><br/>
                <asp:Literal runat="server" Text="<%$ Resources:language, YourPsw%>" /><br /> <asp:TextBox ID="txtpswqa" runat="server" TextMode="Password"></asp:TextBox><br />
                <asp:Literal runat="server" Text="<%$ Resources:language, NewQA%>" /><br /> <asp:TextBox ID="txtquestion" runat="server"></asp:TextBox><br />
                <asp:Literal runat="server" Text="<%$ Resources:language, NewAnswer%>" /><br /> <asp:TextBox ID="txtanswer" runat="server"></asp:TextBox><br /><br/>
                <asp:Button ID="BtnSecurity" runat="server" Text="<%$ Resources:language, ChangeQAbtn%>"
                    onclick="ButtonQa_Click" /> <br />
                <asp:Label ID="lblQa" ForeColor="Red" runat="server" Visible="false"></asp:Label><br /><br /><br />
            </ContentTemplate>
        </asp:TabPanel>
        
        <asp:TabPanel runat="server" ID="TabPanel4" HeaderText="<%$ Resources:language, DeleteAcc%>">
            <ContentTemplate>
                <asp:Literal runat="server" Text="<%$ Resources:language, DeleteAccount%>" /><br/><br/>                    

                        <asp:Label ID="lbl1" ForeColor="Red" runat="server"></asp:Label><br /><br />
                        <asp:Button ID="DtnDeletMe" runat="server" Text="<%$ Resources:language, DeleteMe%>" OnClientClick="return confirm('Confirm ?')" onclick="Button1_Click" />

                <asp:Label ID="lblalert" ForeColor="Red" runat="server" Text=""></asp:Label>
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