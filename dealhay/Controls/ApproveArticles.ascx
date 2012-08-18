<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ApproveArticles.ascx.cs" Inherits="Controls_ApproveArticles" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register src="AdminMenu.ascx" tagname="AdminMenu" tagprefix="uc1" %>

    <uc1:AdminMenu ID="AdminMenu1" runat="server" />
<div style="padding:5px">
<asp:Literal ID="Literal1" runat="server" Text="<%$ Resources:language, Approveartpublish%>" /> <br /><br />    
    <asp:GridView ID="GridView1" runat="server" DataSourceID="SqlDataSource1" 
        AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" 
        BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" 
        CellPadding="3" DataKeyNames="idnews" GridLines="Horizontal" PageSize="30">
        <PagerSettings FirstPageText="First" LastPageText="Last" 
            Mode="NextPreviousFirstLast" NextPageText="Next" PreviousPageText="Previous" />
        <PagerStyle HorizontalAlign="Center" />                
        <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
        <Columns>     
            <asp:BoundField DataField="idnews" HeaderText="idnews" InsertVisible="False" 
                ReadOnly="True" SortExpression="idnews" />
            <asp:TemplateField HeaderText="<%$ Resources:language, Title%>" SortExpression="title">
               <ItemTemplate>
                   <asp:Label runat="server"><%# Eval("title") %></asp:Label>
               </ItemTemplate> 
            </asp:TemplateField>
            <asp:BoundField DataField="author" HeaderText="<%$ Resources:language, Author%>" 
                SortExpression="author" />
            <asp:BoundField DataField="date" HeaderText="<%$ Resources:language, Date%>" SortExpression="date" />
            <asp:CheckBoxField DataField="commentcheck" HeaderText="<%$ Resources:language, CommentsAllowed%>" 
                SortExpression="commentcheck" />
            <asp:CheckBoxField DataField="highlight" HeaderText="<%$ Resources:language, Highlighted%>" 
                SortExpression="highlight" />
            <asp:CheckBoxField DataField="sidenews" HeaderText="<%$ Resources:language, SideNews%>" 
                SortExpression="sidenews" />
            <asp:TemplateField>
               <ItemTemplate >
                   <asp:HyperLink ID="HL1" NavigateUrl='<%# "~/articles/" + Eval("idnews") + "/" + RNA(Eval("title").ToString()) + ".aspx" %>' Target="_blank" Text="<%$ Resources:language, View%>" runat="server"></asp:HyperLink>
               </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
               <ItemTemplate >
                    <asp:LinkButton ID="ApproveButton" CommandArgument='<%# Eval("idnews") %>' Text="<%$ Resources:language, Approve%>" Font-Bold="true" runat="server" OnCommand="Approve_Command" />
               </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
        <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
        <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
        <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
        <AlternatingRowStyle BackColor="#F7F7F7" />
        <EmptyDataTemplate>
            <asp:Label ID="lblnoresult" runat="server" Font-Bold="true" Text="<%$ Resources:language, noarticlesapproved%>" ></asp:Label>
        </EmptyDataTemplate>
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:anmcs %>" SelectCommand="anm_getNewsToPublish" 
        SelectCommandType="StoredProcedure"></asp:SqlDataSource>
</div>