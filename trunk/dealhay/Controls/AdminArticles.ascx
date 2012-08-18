<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AdminArticles.ascx.cs" Inherits="Controls_AdminArticles" %>
<%@ Register src="AdminMenu.ascx" tagname="AdminMenu" tagprefix="uc1" %>
    <uc1:AdminMenu ID="AdminMenu1" runat="server" />
<div style="padding:5px">
        <asp:Button ID="Button1" runat="server" Text="<%$ Resources:language, NewArticle%>" onclick="Button1_Click" /><br /><asp:Literal runat="server" Text="<%$ Resources:language, Articles%>" />:<br />
    <asp:GridView ID="GridView1" runat="server" DataSourceID="SqlDataSource1" 
        AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" 
        BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" 
        CellPadding="3" DataKeyNames="idnews" GridLines="Horizontal" PageSize="40" HeaderStyle-Font-Size="11px" OnRowDeleted="GridView1_RowDeleted">
        <PagerSettings Mode="NumericFirstLast" />
        <PagerStyle HorizontalAlign="Center" BorderWidth="5px" />
        <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
        <Columns>
            <asp:TemplateField ItemStyle-CssClass="highlightborder">
               <ItemTemplate>
                   <asp:HyperLink ID="HL2b" NavigateUrl='<%# Page.Request.Url.AbsolutePath.ToString() + "?p=EditArticle&amp;idnews=" + Eval("idnews") %>' Text="<%$ Resources:language, Edit%>" runat="server"></asp:HyperLink><br />
                   <asp:LinkButton ID="LB2" OnClientClick="return confirm('Are you sure to delete this article ?')" CommandName="Delete" Font-Bold="true" Text="<%$ Resources:language, Delete%>" runat="server"></asp:LinkButton>
               </ItemTemplate> 
            </asp:TemplateField>         
            <asp:BoundField DataField="idnews" HeaderText="id" InsertVisible="False" 
                ReadOnly="True" SortExpression="idnews" />
            <asp:TemplateField HeaderText="<%$ Resources:language, Title%>" SortExpression="title" >
               <ItemTemplate>
                   <asp:HyperLink ID="HL2" NavigateUrl='<%# Page.Request.Url.AbsolutePath.ToString() + "?p=EditArticle&amp;idnews=" + Eval("idnews") %>' Font-Underline="true" runat="server"><%# Eval("title") %></asp:HyperLink>
               </ItemTemplate> 
            </asp:TemplateField>            
            <asp:BoundField DataField="author" HeaderText="<%$ Resources:language, Author%>" 
                SortExpression="author" />
            <asp:BoundField DataField="date" HeaderText="<%$ Resources:language, Date%>" SortExpression="date" />
            <asp:TemplateField ItemStyle-CssClass="highlightborder">
               <ItemTemplate>
                   <asp:HyperLink ID="HL1" NavigateUrl='<%# "~/articles/" + Eval("idnews") + "/" + RNA(Eval("title").ToString()) + ".aspx" %>' Target="_blank" Font-Bold="true" Text="<%$ Resources:language, View%>" runat="server"></asp:HyperLink><br />
                   <asp:HyperLink ID="HL4" NavigateUrl='<%# Page.Request.Url.AbsolutePath.ToString() + "?p=AddArticle&amp;idnews=" + Eval("idnews") %>' Text="<%$ Resources:language, Copy%>" runat="server"></asp:HyperLink>
               </ItemTemplate> 
            </asp:TemplateField>
            <asp:TemplateField ItemStyle-CssClass="highlightborder">
               <ItemTemplate>
                   <asp:HyperLink ID="HL3" NavigateUrl='<%# Page.Request.Url.AbsolutePath.ToString() + "?p=AdminComments&amp;idnews=" + Eval("idnews") %>' runat="server" Text="<%$ Resources:language, ViewComments%>" Visible='<%# ViewLinkComm(Eval("comments").ToString())%>'></asp:HyperLink>
               </ItemTemplate> 
            </asp:TemplateField>         
        </Columns>
        <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
        <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
        <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
        <AlternatingRowStyle BackColor="#F7F7F7" />
        <EmptyDataTemplate>
            <asp:Label ID="lblnoresult" runat="server" Font-Bold="true" Text="There aren't articles"></asp:Label>
        </EmptyDataTemplate>        
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:anmcs %>" SelectCommand="anm_getNews" 
        SelectCommandType="StoredProcedure" DeleteCommand="anm_DeleteNews" DeleteCommandType="StoredProcedure"></asp:SqlDataSource>
    <br /><asp:Label ID="Label1" runat="server" Visible="false" ForeColor="Red"></asp:Label>
</div>