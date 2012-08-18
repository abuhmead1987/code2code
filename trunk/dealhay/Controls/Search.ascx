<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Search.ascx.cs" Inherits="Controls_Search" %>
	    <%@ Register src="SearchMenu.ascx" tagname="SearchMenu" tagprefix="uc1" %>
	    <%@ Register src="SideMenu.ascx" tagname="SideMenu" tagprefix="uc1" %>
	    <%@ Register src="ArchiveMenu.ascx" tagname="ArchiveMenu" tagprefix="uc1" %>
	    <%@ Register src="RecentArticles.ascx" tagname="RecentArticles" tagprefix="uc1" %>
	    <%@ Register src="RecentComments.ascx" tagname="RecentComments" tagprefix="uc1" %>
        <%@ Register src="TagBox.ascx" tagname="TagBox" tagprefix="uc1" %>
<div id="anmcontent" class="anmcontent">
<div class="anmsearch">
    <asp:UpdatePanel ID="PnlComments" runat="server">
        <ContentTemplate>
        <asp:UpdateProgress runat="server" ID="uProgress">
            <ProgressTemplate>  
                <asp:Image ID="imgLoader" ImageUrl="~/images/ajax-loader.gif" alt="Please Wait..." runat="server" />  
            </ProgressTemplate>  
        </asp:UpdateProgress>
    <h2><asp:Literal runat="server" Text="<%$ Resources:language, Resultsfor%>" /> <asp:Label ID="Label1" runat="server" ForeColor="#AA5050" Font-Bold="true"></asp:Label></h2><hr />
    <div class="highlight"><b><asp:Literal ID="LitFbc" runat="server" Text="<%$ Resources:language, Filterbycat%>" />:</b> <%= LinkCat() %> 
        <div class="right"><asp:Literal ID="LitCat" runat="server" /><asp:DropDownList ID="DDcat" OnSelectedIndexChanged="ddcat_SelectedIndexChanged" AutoPostBack="true" runat="server"></asp:DropDownList></div>
    </div> <br />
    <% Response.Write(ViewResult()); %>
    <asp:Literal ID="LTpagelink" runat="server"></asp:Literal>
    </ContentTemplate>
    </asp:UpdatePanel>
</div>
</div>
	    <div id="anmsidebar" class="anmsidebar">
			        <uc1:SearchMenu ID="SearchMenu1" runat="server" />
			        <uc1:SideMenu ID="SideMenu1" runat="server" />
			        <uc1:ArchiveMenu ID="ArchiveMenu1" runat="server" />
                    <uc1:TagBox ID="TagBox" runat="server" />
			        <uc1:RecentArticles ID="RecentArticles1" runat="server" />
			        <uc1:RecentComments ID="RecentComments1" runat="server" />
	    </div>