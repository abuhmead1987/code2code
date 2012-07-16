<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Confirm.ascx.cs" Inherits="Controls_Confirm" %>
	    <%@ Register src="SearchMenu.ascx" tagname="SearchMenu" tagprefix="uc1" %>
	    <%@ Register src="SideMenu.ascx" tagname="SideMenu" tagprefix="uc1" %>
	    <%@ Register src="ArchiveMenu.ascx" tagname="ArchiveMenu" tagprefix="uc1" %>
	    <%@ Register src="RecentArticles.ascx" tagname="RecentArticles" tagprefix="uc1" %>
	    <%@ Register src="RecentComments.ascx" tagname="RecentComments" tagprefix="uc1" %>
        <%@ Register src="TagBox.ascx" tagname="TagBox" tagprefix="uc1" %>
<div id="anmcontent" class="anmcontent">
    <br /><asp:Label ID="Label1" ForeColor="Red" Font-Size="16px" Font-Bold="true" runat="server" Text="Label"></asp:Label><br />
    <br /><asp:HyperLink ID="HyperLink1" Font-Size="16px" Font-Bold="true" runat="server"></asp:HyperLink>
    <br /><br /><br />
    <asp:LoginStatus ID="LoginStatus1" runat="server" /><br /><br />
    <asp:HyperLink ID="HLhome" runat="server">Home Page</asp:HyperLink><br /><br />
</div>
	    <div id="anmsidebar" class="anmsidebar">
			        <uc1:SearchMenu ID="SearchMenu1" runat="server" />
			        <uc1:SideMenu ID="SideMenu1" runat="server" />
			        <uc1:ArchiveMenu ID="ArchiveMenu1" runat="server" />
                    <uc1:TagBox ID="TagBox" runat="server" />
			        <uc1:RecentArticles ID="RecentArticles1" runat="server" />
			        <uc1:RecentComments ID="RecentComments1" runat="server" />
	    </div>