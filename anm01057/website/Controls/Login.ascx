<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Login.ascx.cs" Inherits="Controls_Login" %>
	    <%@ Register src="SearchMenu.ascx" tagname="SearchMenu" tagprefix="uc1" %>
	    <%@ Register src="SideMenu.ascx" tagname="SideMenu" tagprefix="uc1" %>
	    <%@ Register src="ArchiveMenu.ascx" tagname="ArchiveMenu" tagprefix="uc1" %>
	    <%@ Register src="RecentArticles.ascx" tagname="RecentArticles" tagprefix="uc1" %>
	    <%@ Register src="RecentComments.ascx" tagname="RecentComments" tagprefix="uc1" %>
        <%@ Register src="TagBox.ascx" tagname="TagBox" tagprefix="uc1" %>
    <div id="anmcontent" class="anmcontent">
    <asp:Panel ID="Panel1" runat="server">
        <asp:Login ID="Login1" OnLoginError = "Login1_LoginError" 
            runat="server" BackColor="#EFF3FB" BorderColor="#B5C7DE" 
            BorderPadding="4" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" 
            Font-Size="1.2em" ForeColor="#333333" Height="130px" Width="400px">
            <TitleTextStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <TextBoxStyle Font-Size="0.9em" />
            <LoginButtonStyle BackColor="White" BorderColor="#507CD1" BorderStyle="Solid" 
                BorderWidth="1px" Font-Names="Verdana" Font-Size="0.9em" ForeColor="#284E98" />
            <InstructionTextStyle Font-Italic="True" ForeColor="Black" />
        </asp:Login>
        <asp:HyperLink ID="HyperLink1" Text="<%$ Resources:language, ForgotPsw%>" runat="server"></asp:HyperLink><br />
        <br /><br />
        <asp:Literal runat="server" Text="<%$ Resources:language, NewUser%>" /> <asp:HyperLink ID="HyperLink2" Text="<%$ Resources:language, Registerhere%>" runat="server"></asp:HyperLink><br /><br />
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