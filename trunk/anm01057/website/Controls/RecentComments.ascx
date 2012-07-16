<%@ Control Language="C#" AutoEventWireup="true" CodeFile="RecentComments.ascx.cs" Inherits="Controls_RecentComments" %>

<asp:UpdatePanel ID="UpdatePanel1" Visible="false" runat="server">
<ContentTemplate>
    <h2><asp:Literal runat="server" Text="<%$ Resources:language, LastComments%>" /></h2>
    <div class="sp">
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" PageSize="5" Width="100%" BorderWidth="0" RowStyle-BorderColor="#CCCCCC" BorderStyle="Dotted" GridLines="None"
        AutoGenerateColumns="False" DataKeyNames="idnews" DataSourceID="SqlDataSource1" ShowHeader="false">
        <PagerStyle HorizontalAlign="Right" />
        <Columns>
                        <asp:TemplateField ItemStyle-CssClass="padd_bott_15 maxwidthsb">
                            <ItemTemplate>
          	                        <div class="small"><asp:Literal ID="Literal2" runat="server" Text="<%$ Resources:language, by%>" /> <b><%# Eval("commentator") %></b> <asp:Literal ID="Literal3" runat="server" Text="<%$ Resources:language, on%>" /> <%# ViewDate(Eval("date").ToString()) %></div>
                                    <asp:HyperLink ID="HLT" NavigateUrl='<%# GetLinkNews(Eval("idcomment").ToString()) %>' runat="server"><%# PreviewComment(Eval("comment").ToString())%></asp:HyperLink>
                                    <br /><span class="small"><asp:Literal ID="Literal1" runat="server" Text="<%$ Resources:language, in%>" /> <i><%# Eval("title").ToString()%></i> (<%# Eval("Comments")%>)</span>
                            </ItemTemplate>
                        </asp:TemplateField>
        </Columns>
        <EmptyDataTemplate>
            <asp:Literal runat="server" Text="<%$ Resources:language, NoRecentComments%>" />
        </EmptyDataTemplate>
    </asp:GridView>
    </div>
</ContentTemplate>
</asp:UpdatePanel>

<asp:SqlDataSource ID="SqlDataSource1" runat="server" 
    ConnectionString="<%$ ConnectionStrings:anmcs %>" SelectCommand="anm_LastComments" 
    SelectCommandType="StoredProcedure"></asp:SqlDataSource>