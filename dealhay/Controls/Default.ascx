<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Default.ascx.cs" Inherits="Controls_Default" %>
<%@ Register src="Header.ascx" tagname="Header" tagprefix="uc1" %>
<%@ Register src="LoginMaster.ascx" tagname="LoginMaster" tagprefix="uc1" %>

<% 
/* ********************************************************************************************* 
* This notice MUST stay intact for legal use. This software was created by Max (www.AllNewsManager.NET).
* If you use this software or part of it, you must leave in the footer a link to our site.
* It is a free software. Visit http://allnewsmanager.codeplex.com/license for full license.
************************************************************************************************  */ 
%>

<div id="anm_" class="anm" runat="server">

	<div class="loginmaster">
	   <uc1:LoginMaster ID="LoginMaster1" runat="server" /> || <asp:HyperLink ID="rssbutton" runat="server">
           <asp:Image ID="Image1" ImageUrl="~/images/rss.gif" BorderWidth="0px" Height="12px" AlternateText="rss" runat="server" /></asp:HyperLink>
	</div>
    <uc1:Header ID="Header1" runat="server" />
    <div id="anmpage" class="anmpage">
        <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
	    <div style="clear: both;"></div>
    </div>
    <div id="anmfooter" class="anmfooter">
	    <div class="fmenu"><%= FooterMenu() %> <asp:HyperLink ID="Hlcontact" Text="<%$ Resources:language, ContactUs%>" runat="server"></asp:HyperLink> | <asp:HyperLink ID="Hlrss" Text="<%$ Resources:language, Subscribe%>" runat="server"></asp:HyperLink> | <asp:LoginStatus ID="LoginStatus1" runat="server" /></div>
	    Powered by <asp:HyperLink ID="HLref" NavigateUrl="http://www.allnewsmanager.net" Text="AllNewsManager.NET" runat="server"></asp:HyperLink> <asp:Label ID="lblTemp" runat="server" Text="- Template by"></asp:Label> <asp:HyperLink ID="HLTemp" runat="server"></asp:HyperLink><br/>
        <asp:Label ID="lblTimeP" runat="server"></asp:Label>
    </div>

</div>