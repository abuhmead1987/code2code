<%@ Control Language="C#" AutoEventWireup="true" CodeFile="NewUser.ascx.cs" Inherits="Controls_NewUser" %>
	    <%@ Register src="SearchMenu.ascx" tagname="SearchMenu" tagprefix="uc1" %>
	    <%@ Register src="SideMenu.ascx" tagname="SideMenu" tagprefix="uc1" %>
	    <%@ Register src="ArchiveMenu.ascx" tagname="ArchiveMenu" tagprefix="uc1" %>
	    <%@ Register src="RecentArticles.ascx" tagname="RecentArticles" tagprefix="uc1" %>
	    <%@ Register src="RecentComments.ascx" tagname="RecentComments" tagprefix="uc1" %>
        <%@ Register src="TagBox.ascx" tagname="TagBox" tagprefix="uc1" %>
    <div id="anmcontent" class="anmcontent">
    <asp:Panel ID="Panel1" runat="server">
        <asp:CreateUserWizard ID="CreateUserWizard1" emailregularexpression="^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$" 
            OnCreatedUser="CreateUserWizard1_CreatedUser" OnCreatingUser="CreateUserWizard1_Captcha" 
            runat="server" BackColor="#EFF3FB" BorderColor="#B5C7DE" BorderStyle="Solid" 
            BorderWidth="1px" Font-Names="Verdana" Font-Size="1.2em" Height="243px" Width="390px">
            <SideBarStyle BackColor="#507CD1" VerticalAlign="Top" />
            <SideBarButtonStyle BackColor="#507CD1" Font-Names="Verdana" 
                ForeColor="White" />
            <ContinueButtonStyle BackColor="White" BorderColor="#507CD1" 
                BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" 
                ForeColor="#284E98" />
            <NavigationButtonStyle BackColor="White" BorderColor="#507CD1" 
                BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" 
                ForeColor="#284E98" />
            <HeaderStyle BackColor="#284E98" BorderColor="#EFF3FB" BorderStyle="Solid" 
                BorderWidth="2px" Font-Bold="True" Font-Size="1.0em" ForeColor="White" 
                HorizontalAlign="Center" />
            <CreateUserButtonStyle BackColor="White" BorderColor="#507CD1" 
                BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" 
                ForeColor="#284E98" />
            <TitleTextStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <StepStyle Font-Size="0.9em" />
            <WizardSteps>
                <asp:CreateUserWizardStep ID="CreateUserWizardStep1" runat="server">
                </asp:CreateUserWizardStep>
                <asp:CompleteWizardStep ID="CompleteWizardStep1" runat="server">
                </asp:CompleteWizardStep>
            </WizardSteps>
        </asp:CreateUserWizard>
        <asp:UpdatePanel ID="UpdatePanel1" Visible="false" runat="server">
            <ContentTemplate>
                <asp:Literal runat="server" Text="<%$ Resources:language, SecurityImage%>" /><br />
                <asp:Image ID="imgcaptcha" runat="server" /><br />
                <asp:LinkButton ID="LBcaptcha" runat="server" Text="<%$ Resources:language, Generateimage%>" onclick="LBcaptcha_Click"></asp:LinkButton>
            </ContentTemplate>
        </asp:UpdatePanel><br />
        <asp:Label ID="lblcaptcha" runat="server" Visible="false" Text="<%$ Resources:language, Typeletters%>"></asp:Label> <asp:TextBox ID="txtcaptcha" Visible="false" runat="server"></asp:TextBox><br />
        <asp:Label ID="errorcaptcha" runat="server" ForeColor="Red" Text="<%$ Resources:language, TypeletterserrorReg%>" Visible="false"></asp:Label>
    </asp:Panel>
        </div>   
	    <div id="anmsidebar" class="anmsidebar">
			        <uc1:SearchMenu ID="SearchMenu1" runat="server" />
			        <uc1:SideMenu ID="SideMenu1" runat="server" />
			        <uc1:ArchiveMenu ID="ArchiveMenu1" runat="server" />
                    <uc1:TagBox ID="TagBox" runat="server" />
			        <uc1:RecentArticles ID="RecentArticles1" runat="server" />
			        <uc1:RecentComments ID="RecentComments1" runat="server" />
	    </div>   