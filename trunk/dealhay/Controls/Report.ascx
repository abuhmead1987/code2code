<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Report.ascx.cs" Inherits="Controls_Report" %>
	    <%@ Register src="SearchMenu.ascx" tagname="SearchMenu" tagprefix="uc1" %>
	    <%@ Register src="SideMenu.ascx" tagname="SideMenu" tagprefix="uc1" %>
	    <%@ Register src="ArchiveMenu.ascx" tagname="ArchiveMenu" tagprefix="uc1" %>
	    <%@ Register src="RecentArticles.ascx" tagname="RecentArticles" tagprefix="uc1" %>
	    <%@ Register src="RecentComments.ascx" tagname="RecentComments" tagprefix="uc1" %>
        <%@ Register src="TagBox.ascx" tagname="TagBox" tagprefix="uc1" %>
<div id="anmcontent" class="anmcontent">
    <br /><asp:Label ID="Label1" ForeColor="Red" Font-Size="16px" Font-Bold="true" runat="server"></asp:Label>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:anmcs %>" 
        SelectCommand="anm_getComment" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:QueryStringParameter Name="idcomment" QueryStringField="idc" 
                Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
        <asp:GridView ID="GridView1" runat="server" GridLines="None"
                AutoGenerateColumns="False" Width="99%"  
                RowStyle-CssClass="commentpost" DataSourceID="SqlDataSource1" DataKeyNames="idcomment" CellPadding="5">
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                        <div class="commentheader">
                            <a name='<%# "comment" +(Eval("idcomment").ToString()) %>'></a>
                            <div class="left"><asp:Image ID="Image1" ImageUrl='<%# GetAvatar(Eval("commentator").ToString())%>' AlternateText="User Avatar" runat="server" /> </div>
							<div>&nbsp;<i><asp:Literal ID="Literal2" runat="server" Text="<%$ Resources:language, by%>" /></i> <%# Eval("commentator").ToString()%></div> 
							<div>&nbsp;<%# ViewDate(Eval("date").ToString())%></div>
                        </div>
                        <div class="commenttext">
                            <asp:Literal ID="commenttext" Text='<%# Eval("comment")%>' runat="server"></asp:Literal>
                        </div>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <br />
    <asp:Label ID="Label2" ForeColor="Red" Font-Size="16px" Font-Bold="true" runat="server" Text="Reason:"></asp:Label><br />
    <asp:TextBox ID="TextBox1" TextMode="MultiLine" Height="100px" Width="500px" runat="server"></asp:TextBox><br />
    <asp:Button ID="Button1" runat="server" Text="<%$ Resources:language, Send%>" onclick="Button1_Click" />
    <asp:Panel ID="Panelcomm" Visible="false" ForeColor="Red" runat="server">
    <div class="highlight"><asp:Literal ID="Literal1" runat="server" Text="<%$ Resources:language, Sendcomment%>" /> 
    <asp:HyperLink ID="HyperLink4" Text="<%$ Resources:language, Register%>" runat="server"></asp:HyperLink> <asp:Literal ID="Literal3" runat="server" Text="<%$ Resources:language, and%>" />  
    <asp:HyperLink ID="HyperLink5" Text="<%$ Resources:language, login%>" runat="server"></asp:HyperLink>.</div></asp:Panel></div>
	    <div id="anmsidebar" class="anmsidebar">
			        <uc1:SearchMenu ID="SearchMenu1" runat="server" />
			        <uc1:SideMenu ID="SideMenu1" runat="server" />
			        <uc1:ArchiveMenu ID="ArchiveMenu1" runat="server" />
                    <uc1:TagBox ID="TagBox" runat="server" />
			        <uc1:RecentArticles ID="RecentArticles1" runat="server" />
			        <uc1:RecentComments ID="RecentComments1" runat="server" />
	    </div>