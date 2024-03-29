﻿<%@ Control Language="C#" AutoEventWireup="true" CodeFile="PasswordRecovery.ascx.cs" Inherits="Controls_PasswordRecovery" %>
	    <%@ Register src="SearchMenu.ascx" tagname="SearchMenu" tagprefix="uc1" %>
	    <%@ Register src="SideMenu.ascx" tagname="SideMenu" tagprefix="uc1" %>
	    <%@ Register src="ArchiveMenu.ascx" tagname="ArchiveMenu" tagprefix="uc1" %>
	    <%@ Register src="RecentArticles.ascx" tagname="RecentArticles" tagprefix="uc1" %>
	    <%@ Register src="RecentComments.ascx" tagname="RecentComments" tagprefix="uc1" %>
        <%@ Register src="TagBox.ascx" tagname="TagBox" tagprefix="uc1" %>

    <div id="anmcontent" class="anmcontent">
    <asp:Panel ID="Panel1" runat="server">
        <asp:PasswordRecovery ID="PasswordRecovery1" runat="server" BackColor="#EFF3FB" 
            BorderColor="#B5C7DE" BorderPadding="4" BorderStyle="Solid" BorderWidth="1px" 
            Font-Names="Verdana" Font-Size="1.2em" Height="96px" Width="400px">
            <InstructionTextStyle Font-Italic="True" ForeColor="Black" />
            <SuccessTextStyle Font-Bold="True" ForeColor="#507CD1" />
            <TextBoxStyle Font-Size="0.9em" />
            <TitleTextStyle BackColor="#507CD1" Font-Bold="True" Font-Size="1.0em" 
                ForeColor="White" />
            <SubmitButtonStyle BackColor="White" BorderColor="#507CD1" BorderStyle="Solid" 
                BorderWidth="1px" Font-Names="Verdana" Font-Size="0.9em" ForeColor="#284E98" />
        </asp:PasswordRecovery>
        <asp:LoginStatus ID="LoginStatus1" runat="server" /><br /><br />
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