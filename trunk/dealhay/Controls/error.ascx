<%@ Control Language="C#" AutoEventWireup="true" CodeFile="error.ascx.cs" Inherits="Controls_error" %>
	    <%@ Register src="SearchMenu.ascx" tagname="SearchMenu" tagprefix="uc1" %>
	    <%@ Register src="SideMenu.ascx" tagname="SideMenu" tagprefix="uc1" %>
	    <%@ Register src="ArchiveMenu.ascx" tagname="ArchiveMenu" tagprefix="uc1" %>
	    <%@ Register src="RecentArticles.ascx" tagname="RecentArticles" tagprefix="uc1" %>
	    <%@ Register src="RecentComments.ascx" tagname="RecentComments" tagprefix="uc1" %>
        <%@ Register src="TagBox.ascx" tagname="TagBox" tagprefix="uc1" %>

    <div id="anmcontent" class="anmcontent">                 
        <br /><asp:Literal runat="server" Text="<%$ Resources:language, error%>" /> <br /><br /><asp:Literal runat="server" Text="<%$ Resources:language, contactadminerror%>" /><br /><br />
        <asp:HyperLink ID="Hlcontact" Text="<%$ Resources:language, ContactUs%>" runat="server"></asp:HyperLink>
        <br /><br />
    </div>   
	    <div id="anmsidebar" class="anmsidebar">
			        <uc1:SearchMenu ID="SearchMenu1" runat="server" />
			        <uc1:SideMenu ID="SideMenu1" runat="server" />
			        <uc1:ArchiveMenu ID="ArchiveMenu1" runat="server" />
                    <uc1:TagBox ID="TagBox" runat="server" />
			        <uc1:RecentArticles ID="RecentArticles1" runat="server" />
			        <uc1:RecentComments ID="RecentComments1" runat="server" />
	    </div>
