<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AdminTemplates.ascx.cs" Inherits="Controls_AdminTemplates" %>
<%@ Register src="AdminMenu.ascx" tagname="AdminMenu" tagprefix="uc1" %>

    <uc1:AdminMenu ID="AdminMenu1" runat="server" />
<div style="padding:5px">
    <asp:Button ID="Button1" runat="server" Text="<%$ Resources:language, AddTemplate%>" onclick="Button1_Click" />
    <br /><br />
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
        AllowSorting="True" AutoGenerateColumns="False" BackColor="White" 
        BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3" DataKeyNames="Template" 
        DataSourceID="SqlDataSource1" GridLines="Horizontal" OnSelectedIndexChanged="ConfirmTemplate" PageSize="10">
        <PagerSettings FirstPageText="&lt;&lt; First" LastPageText="Last &gt;&gt;" 
            Mode="NextPreviousFirstLast" NextPageText="Next &gt;" 
            PreviousPageText="&lt; Previous" />
        <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
        <Columns>
            <asp:CommandField ShowSelectButton="true" ItemStyle-Font-Bold="true" />
            <asp:BoundField DataField="Template" HeaderText="<%$ Resources:language, Template%>" 
                InsertVisible="False" ReadOnly="True" SortExpression="Template" />
            <asp:BoundField DataField="name" HeaderText="<%$ Resources:language, name%>" SortExpression="name" />
            <asp:BoundField DataField="author" HeaderText="<%$ Resources:language, author%>" 
                SortExpression="author" />
            <asp:BoundField DataField="siteauthor" HeaderText="<%$ Resources:language, siteauthor%>" 
                SortExpression="siteauthor" />
            <asp:CommandField ShowEditButton="True" />
        </Columns>
        <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
        <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
        <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
        <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
        <AlternatingRowStyle BackColor="#F7F7F7" />        
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:anmcs %>" 
        InsertCommand="anm_InsertTemplate" InsertCommandType="StoredProcedure" 
        SelectCommand="anm_getTemplates" SelectCommandType="StoredProcedure" 
        UpdateCommand="anm_UpdateTemplate" UpdateCommandType="StoredProcedure">
        <UpdateParameters>
            <asp:Parameter Name="name" Type="String" />
            <asp:Parameter Name="author" Type="String" />
            <asp:Parameter Name="siteauthor" Type="String" />
            <asp:Parameter Name="Template" Type="Int32" />
        </UpdateParameters>
        <InsertParameters>
            <asp:Parameter Name="name" Type="String" />
            <asp:Parameter Name="author" Type="String" />
            <asp:Parameter Name="siteauthor" Type="String" />
        </InsertParameters>
    </asp:SqlDataSource><br />
    <asp:Label ID="Label1" runat="server" Visible="false" Text="Error!" ForeColor="Red"></asp:Label><br />
    <asp:Button ID="Button2" runat="server" Text="<%$ Resources:language, Confirm%>" Visible="false" 
        onclick="Button2_Click" /><asp:Label ID="Label2" runat="server" Visible="false"></asp:Label>
    <br /><br />
    <asp:HyperLink ID="HLAnmTemplates" NavigateUrl="http://www.allnewsmanager.net/allnewsmanager/anm.aspx?p=AllNews&tag=Template" Target="_blank" Text="<%$ Resources:language, Checknewtemp%>" runat="server"></asp:HyperLink>    
</div>