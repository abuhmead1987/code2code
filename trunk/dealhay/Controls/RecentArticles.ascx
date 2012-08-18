<%@ Control Language="C#" AutoEventWireup="true" CodeFile="RecentArticles.ascx.cs" Inherits="Controls_RecentArticles" %>

<asp:UpdatePanel ID="UpdatePanel1" Visible="false" runat="server">
<ContentTemplate>
    <h2><asp:Literal runat="server" Text="<%$ Resources:language, LastArticles%>" /></h2>
    <div class="sp">
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" PageSize="5" Width="100%" BorderWidth="0" RowStyle-BorderColor="#CCCCCC" BorderStyle="Dotted" GridLines="None"  
        AutoGenerateColumns="False" DataKeyNames="idnews" DataSourceID="SqlDataSource1" ShowHeader="false">
        <PagerStyle HorizontalAlign="Right" />
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                        <asp:HyperLink ID="HLT" Font-Bold="true" NavigateUrl='<%# GetLinkNews(Eval("idnews").ToString(),Eval("title").ToString()) %>' runat="server"><%# Eval("Title")%></asp:HyperLink>
          	            <br /><span class="small"><%# PreviewArticle(Eval("summary").ToString(),Eval("news").ToString())%></span>
                        <p class="anmbyline"><%# Category(Eval("idcategory").ToString())%> <b>|</b> <asp:HyperLink ID="HLCc" NavigateUrl='<%# GetLinkComments(Eval("idnews").ToString(),Eval("title").ToString()) %>' runat="server"><%# GetNcom(Eval("idnews").ToString(), Eval("commentcheck").ToString(), Eval("comments").ToString())%></asp:HyperLink></p>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <EmptyDataTemplate>
            <asp:Literal runat="server" Text="<%$ Resources:language, NoRecentArticles%>" />
        </EmptyDataTemplate>
    </asp:GridView>
    </div>
</ContentTemplate>
</asp:UpdatePanel>

<asp:SqlDataSource ID="SqlDataSource1" runat="server" 
    ConnectionString="<%$ ConnectionStrings:anmcs %>" SelectCommand="anm_getRss" 
    SelectCommandType="StoredProcedure"></asp:SqlDataSource>
