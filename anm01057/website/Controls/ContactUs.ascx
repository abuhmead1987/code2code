<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ContactUs.ascx.cs" Inherits="Controls_ContactUs" %>
	    <%@ Register src="SearchMenu.ascx" tagname="SearchMenu" tagprefix="uc1" %>
	    <%@ Register src="SideMenu.ascx" tagname="SideMenu" tagprefix="uc1" %>
	    <%@ Register src="ArchiveMenu.ascx" tagname="ArchiveMenu" tagprefix="uc1" %>
	    <%@ Register src="RecentArticles.ascx" tagname="RecentArticles" tagprefix="uc1" %>
	    <%@ Register src="RecentComments.ascx" tagname="RecentComments" tagprefix="uc1" %>
        <%@ Register src="TagBox.ascx" tagname="TagBox" tagprefix="uc1" %>
        <div id="anmcontent" class="anmcontent">
            <b>- <asp:Literal runat="server" Text="<%$ Resources:language, ContactUs%>" /> -</b> <br /><br />

            <asp:Literal runat="server" Text="<%$ Resources:language, Subject%>" />: 
                <asp:TextBox ID="TextBox1" Width="350px" runat="server"></asp:TextBox><br /><br />

            <asp:Literal runat="server" Text="<%$ Resources:language, msglimitcontact%>" />:<br />
                <asp:TextBox ID="TextBox2" Width="400px" Rows="15" TextMode="MultiLine" runat="server"></asp:TextBox><br /><br />

                <asp:Button ID="Button1" runat="server" Text="<%$ Resources:language, Send%>" onclick="Button1_Click" /><br />
                <asp:Label ID="Label1" runat="server" ForeColor="Red" Font-Bold="true" ></asp:Label><br />
                <asp:LoginStatus ID="LoginStatus1" runat="server" />
        </div>

	    <div id="anmsidebar" class="anmsidebar">
			        <uc1:SearchMenu ID="SearchMenu1" runat="server" />
			        <uc1:SideMenu ID="SideMenu1" runat="server" />
			        <uc1:ArchiveMenu ID="ArchiveMenu1" runat="server" />
                    <uc1:TagBox ID="TagBox" runat="server" />
			        <uc1:RecentArticles ID="RecentArticles1" runat="server" />
			        <uc1:RecentComments ID="RecentComments1" runat="server" />
        </div>