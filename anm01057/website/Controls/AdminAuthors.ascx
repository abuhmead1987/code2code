<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AdminAuthors.ascx.cs" Inherits="Controls_AdminAuthors" %>
<%@ Register src="AdminMenu.ascx" tagname="AdminMenu" tagprefix="uc1" %>
    <uc1:AdminMenu ID="AdminMenu1" runat="server" />
<div style="padding:5px">
    <asp:Button ID="Button1" runat="server" Text="<%$ Resources:language, AddAuthor%>" onclick="Button1_Click" />
    <br /><br />
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
        AllowSorting="True" AutoGenerateColumns="False" BackColor="White" 
        BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3" 
        DataKeyNames="author" DataSourceID="SqlDataSource1" GridLines="Horizontal" OnRowDeleting="GridView1_RowDeleting">
        <PagerSettings FirstPageText="&lt;&lt; First" LastPageText="Last &gt;&gt;" 
            Mode="NextPreviousFirstLast" NextPageText="Next &gt;" 
            PreviousPageText="&lt; Previous" />        
        <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
        <Columns>
            <asp:BoundField DataField="author" HeaderText="<%$ Resources:language, Author%>" 
                InsertVisible="False" ReadOnly="True" SortExpression="author" />
           <asp:TemplateField HeaderText="<%$ Resources:language, role%>" SortExpression="role">
               <ItemTemplate >
                    <asp:Label ID="lblrole" Text='<%# ViewRole(Eval("role").ToString())%>' runat="server"></asp:Label>                     
               </ItemTemplate>
               <EditItemTemplate>
                    <asp:DropDownList ID="role" runat="server" DataTextField="rolename" DataValueField="role" SelectedValue='<%# Bind("role", "{0}") %>'>
                        <asp:ListItem Text="admin" Value="1" />
                        <asp:ListItem Text="publisher" Value="2" />
                    </asp:DropDownList>               
               </EditItemTemplate>
            </asp:TemplateField>
            <asp:CommandField ShowEditButton="True" />
            <asp:TemplateField>
               <ItemTemplate >
                   <asp:LinkButton ID="LinkButton1" OnClientClick="return confirm('Are you sure to delete this author ?')" CommandName="Delete" Text="<%$ Resources:language, Delete%>" runat="server"></asp:LinkButton>
               </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
        <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
        <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
        <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
        <AlternatingRowStyle BackColor="#F7F7F7" />
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:anmcs %>" 
        DeleteCommand="anm_DeleteAuthor" DeleteCommandType="StoredProcedure" 
        InsertCommand="anm_InsertAuthor" InsertCommandType="StoredProcedure" 
        SelectCommand="anm_SelectAuthor" SelectCommandType="StoredProcedure" 
        UpdateCommand="anm_UpdateRole" UpdateCommandType="StoredProcedure">
        <DeleteParameters>
            <asp:Parameter Name="author" Type="String" />
        </DeleteParameters>
        <UpdateParameters>
            <asp:Parameter Name="author" Type="String" />
            <asp:Parameter Name="role" Type="Int32" />
        </UpdateParameters>
        <InsertParameters>
            <asp:Parameter Name="author" Type="String" />
            <asp:Parameter Name="role" Type="Int32" />
        </InsertParameters>
    </asp:SqlDataSource>
    <br /><asp:Label ID="lblMessage" runat="server" ForeColor="Red" Visible="false"></asp:Label><br /><br />
    <strong>Publisher</strong> <asp:Literal runat="server" Text="<%$ Resources:language, PublisherPerm%>" /><br />
</div>