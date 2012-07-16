<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AdminReports.ascx.cs" Inherits="Controls_AdminReports" %>
<%@ Register src="AdminMenu.ascx" tagname="AdminMenu" tagprefix="uc1" %>

    <uc1:AdminMenu ID="AdminMenu1" runat="server" />
    <div style="padding:5px">
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:anmcs %>" 
            DeleteCommand="anm_DeleteReport" DeleteCommandType="StoredProcedure" 
            SelectCommand="anm_getReports" SelectCommandType="StoredProcedure">
            <DeleteParameters>
                <asp:Parameter Name="id" Type="Int32" />
            </DeleteParameters>
        </asp:SqlDataSource>
    <asp:GridView ID="GridView1" runat="server" DataSourceID="SqlDataSource1" 
        AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" 
        BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" 
        CellPadding="3" DataKeyNames="id" GridLines="Horizontal" PageSize="25" 
            HeaderStyle-Font-Size="11px" EnableModelValidation="True">
        <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
        <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" Font-Size="11px" 
            ForeColor="#F7F7F7" />
        <PagerStyle HorizontalAlign="Right" BorderWidth="5px" BackColor="#E7E7FF" 
            ForeColor="#4A3C8C" />
        <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
            <AlternatingRowStyle BackColor="#F7F7F7" />
            <Columns>
                <asp:CommandField ShowDeleteButton="True" ItemStyle-CssClass="highlightborder" />
                <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" 
                    ReadOnly="True" SortExpression="id" />
                <asp:BoundField DataField="username" HeaderText="username" 
                    SortExpression="username" />
            <asp:TemplateField HeaderText="idreported" SortExpression="idreported">
               <ItemTemplate>
                   <asp:HyperLink ID="HL2" NavigateUrl='<%# "~/comment/" + Eval("idreported") + ".aspx#comment" + Eval("idreported")%>' Target="_blank" Text='<%# "View Comment " + Eval("idreported") %>' runat="server"></asp:HyperLink>
               </ItemTemplate> 
            </asp:TemplateField>
                <asp:BoundField DataField="reason" HeaderText="<%$ Resources:language, Reason%>" 
                    SortExpression="reason" ItemStyle-Font-Size="16px" />       
                <asp:BoundField DataField="date" HeaderText="date" SortExpression="date" />
            </Columns>
        <EmptyDataTemplate>
            <asp:Label ID="lblnoresult" runat="server" Font-Bold="true" Text="No Report"></asp:Label>
        </EmptyDataTemplate>   
        <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
        </asp:GridView>
    </div>