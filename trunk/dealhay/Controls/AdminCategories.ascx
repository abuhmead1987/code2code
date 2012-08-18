<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AdminCategories.ascx.cs" Inherits="Controls_AdminCategories" %>
<%@ Register src="AdminMenu.ascx" tagname="AdminMenu" tagprefix="uc1" %>

    <uc1:AdminMenu ID="AdminMenu1" runat="server" />
    <div style="padding:5px">
    <asp:Button ID="Button1" runat="server" Text="<%$ Resources:language, AddCategory%>" onclick="Button1_Click" />
    <br /><br /><asp:Label ID="lblcfc" runat="server" Text="<%$ Resources:language, ChooseFatherCat%>" ForeColor="Red" Visible="false"></asp:Label>
                    <asp:DropDownList ID="DdlFatherCat" runat="server" 
                        DataSourceID="SqlDataSource2" DataTextField="category" DataValueField="idcategory" Visible="false">
                    </asp:DropDownList> 
        <asp:Button ID="BtnFatherCat" runat="server" Text="<%$ Resources:language, Update%>" Visible="false" 
            onclick="BtnFatherCat_Click"/><asp:Label ID="lblidc" runat="server" Visible="false"></asp:Label>
        <br /><br />
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
        AllowSorting="True" AutoGenerateColumns="False" BackColor="White" 
        BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3" 
        DataKeyNames="idcategory" DataSourceID="SqlDataSource1" 
        GridLines="Horizontal" OnRowDeleted="GridView1_RowDeleted" PageSize="25">
        <PagerSettings FirstPageText="&lt;&lt; First" LastPageText="Last &gt;&gt;" 
            Mode="NextPreviousFirstLast" NextPageText="Next &gt;" 
            PreviousPageText="&lt; Previous" />
        <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
        <Columns>
            <asp:BoundField DataField="idcategory" HeaderText="idcategory" 
                InsertVisible="False" ReadOnly="True" SortExpression="idcategory" />
            <asp:BoundField DataField="category" HeaderText="<%$ Resources:language, Category%>" 
                SortExpression="category" ItemStyle-Font-Bold="true" />
            <asp:TemplateField HeaderText="<%$ Resources:language, Father%>" SortExpression="idfather">
               <ItemTemplate>
                    <asp:Label ID="lblidfather" Text='<%# FatherCat(Eval("idfather").ToString())%>' runat="server"></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                </EditItemTemplate>
                <InsertItemTemplate>              
                </InsertItemTemplate>                
            </asp:TemplateField>                        
            <asp:BoundField DataField="ordercat" HeaderText="<%$ Resources:language, order%>" 
                SortExpression="ordercat" />
            <asp:BoundField DataField="url" HeaderText="<%$ Resources:language, url%>" 
                SortExpression="url" /> 
            <asp:CommandField ShowEditButton="True" ItemStyle-CssClass="highlightborder"/>
            <asp:TemplateField ItemStyle-CssClass="highlightborder">
               <ItemTemplate>
                    <asp:LinkButton ID="ChangeFather" CommandArgument='<%# Eval("idcategory") + "," + Eval("idfather") %>' Text="<%$ Resources:language, ChangeFather%>" runat="server" OnCommand="ChangeFather" />
               </ItemTemplate>
            </asp:TemplateField>            
            <asp:TemplateField ItemStyle-CssClass="highlightborder">
               <ItemTemplate >
                   <asp:LinkButton ID="LinkButton1" OnClientClick="return confirm('Are you sure to delete this category ?')" CommandName="Delete" Text="<%$ Resources:language, Delete%>" Font-Bold="true" runat="server"></asp:LinkButton>
               </ItemTemplate> 
            </asp:TemplateField>
            <asp:TemplateField ItemStyle-CssClass="highlightborder">
               <ItemTemplate>
                    <asp:LinkButton ID="SetUpMain" CommandArgument='<%# Eval("idcategory") + "," + Eval("idfather") %>' Text="<%$ Resources:language, SetupMainCat%>" runat="server" OnCommand="SetUpMain" />
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
        DeleteCommand="anm_DeleteCategory" DeleteCommandType="StoredProcedure" 
        InsertCommand="anm_InsertCategory" InsertCommandType="StoredProcedure" 
        SelectCommand="anm_SelectCategory" SelectCommandType="StoredProcedure" 
        UpdateCommand="anm_UpdateCategory" UpdateCommandType="StoredProcedure">
        <DeleteParameters>
            <asp:Parameter Name="idcategory" Type="Int32" />
        </DeleteParameters>
        <UpdateParameters>
            <asp:Parameter Name="idcategory" Type="Int32" />
            <asp:Parameter Name="ordercat" Type="Int32" />
            <asp:Parameter Name="category" Type="String" />
        </UpdateParameters>
        <InsertParameters>
            <asp:Parameter Name="category" Type="String" />
        </InsertParameters>
    </asp:SqlDataSource>
    <asp:Label ID="Label1" runat="server" Visible="false" ForeColor="Red"></asp:Label>
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
        ConnectionString="<%$ ConnectionStrings:anmcs %>" 
        SelectCommand="anm_getCategories" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
</div>