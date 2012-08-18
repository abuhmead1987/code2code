<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Activate.ascx.cs" Inherits="Controls_Activate" %>
	    <%@ Register src="SearchMenu.ascx" tagname="SearchMenu" tagprefix="uc1" %>
	    <%@ Register src="SideMenu.ascx" tagname="SideMenu" tagprefix="uc1" %>
	    <%@ Register src="ArchiveMenu.ascx" tagname="ArchiveMenu" tagprefix="uc1" %>

    <div id="anmcontent" class="anmcontent">
    <asp:Table ID="Table1" runat="server" CellPadding="15" CellSpacing="15" GridLines="Both" BorderStyle="Groove" BackColor="BlanchedAlmond" Caption="Account Information">

            <asp:TableRow ID="TableRow1" runat="server">
                <asp:TableCell ID="TableCell1" HorizontalAlign="Right" runat="server">Account Status:</asp:TableCell>
                <asp:TableCell ID="TableCell2" HorizontalAlign="Left" runat="server"><asp:Label ID="ActivationStatusLabel" Font-Bold="true" runat="server" style="position: static"></asp:Label></asp:TableCell>
            </asp:TableRow>
            
            <asp:TableRow ID="TableRow2" runat="server">
                <asp:TableCell ID="TableCell3" HorizontalAlign="Right" runat="server"></asp:TableCell>
                <asp:TableCell ID="TableCell4" HorizontalAlign="Left" runat="server"><asp:LoginStatus ID="LoginStatus1" Visible="false" runat="server" /></asp:TableCell>
            </asp:TableRow>

        </asp:Table>
        </div>   
	    <div id="anmsidebar" class="anmsidebar">
			        <uc1:SearchMenu ID="SearchMenu1" runat="server" />
			        <uc1:SideMenu ID="SideMenu1" runat="server" />
			        <uc1:ArchiveMenu ID="ArchiveMenu1" runat="server" />
	    </div>        