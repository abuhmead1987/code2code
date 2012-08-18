<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Tags.ascx.cs" Inherits="Controls_Tags" %>
<%@ Register src="AdminMenu.ascx" tagname="AdminMenu" tagprefix="uc1" %>
    <uc1:AdminMenu ID="AdminMenu1" runat="server" />
<div style="padding:5px">
Customize Tag Box:<br /><br />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:LinkButton ID="LBadd" runat="server" onclick="LBadd_Click" Text="<%$ Resources:language, AddTagbox%>" Font-Bold="true"></asp:LinkButton><br />
            <asp:Label ID="lblTag" runat="server" Visible="false" Text="Tag:"></asp:Label> <asp:TextBox ID="TBtag" Visible="false" Text="<%$ Resources:language, inserttaghere%>" Font-Italic="true" OnClick="this.value=''" runat="server"></asp:TextBox> <asp:Label ID="lblSize" Visible="false" runat="server" Text="Size:"></asp:Label> <asp:TextBox ID="TBsize" Visible="false" Text="11" Width="30px" runat="server"></asp:TextBox><asp:RequiredFieldValidator
                ID="RequiredFieldValidator1" runat="server" ErrorMessage="Required Field" ControlToValidate="TBsize"></asp:RequiredFieldValidator> <br /><asp:Button ID="BtnAddTag" Visible="false" runat="server" Text="Add tag" onclick="BtnAddTag_Click" />
                <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="<%$ Resources:language, Insertsize940%>" MaximumValue="40" MinimumValue="9" Type="Integer" ControlToValidate="TBsize"></asp:RangeValidator><br /><asp:RequiredFieldValidator
                ID="RequiredFieldValidator2" runat="server" ErrorMessage="<%$ Resources:language, InsertTag%>" ControlToValidate="TBtag"></asp:RequiredFieldValidator> <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ValidationExpression="^[^<>]{1,500}$" ControlToValidate = "TBtag" ErrorMessage="< and > are invalid characters"></asp:RegularExpressionValidator><br />
        </ContentTemplate>
    </asp:UpdatePanel>
<asp:SqlDataSource ID="SqlDataSource1" runat="server" 
    ConnectionString="<%$ ConnectionStrings:anmcs %>" DeleteCommand="anm_DeleteTag" 
    DeleteCommandType="StoredProcedure" InsertCommand="anm_InsertTag" 
    InsertCommandType="StoredProcedure" SelectCommand="anm_getTags" 
    SelectCommandType="StoredProcedure" UpdateCommand="anm_UpdateTag" 
    UpdateCommandType="StoredProcedure">
    <DeleteParameters>
        <asp:Parameter Name="Tag" Type="String" />
    </DeleteParameters>
    <InsertParameters>
        <asp:Parameter Name="tag" Type="String" />
        <asp:Parameter Name="size" Type="Int32" />
    </InsertParameters>
    <UpdateParameters>
        <asp:Parameter Name="tag" Type="String" />
        <asp:Parameter Name="size" Type="Int32" />
    </UpdateParameters>
</asp:SqlDataSource>
<asp:GridView ID="GridView1" runat="server" DataSourceID="SqlDataSource1" 
    AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" 
        BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" 
        CellPadding="3" DataKeyNames="Tag" GridLines="Horizontal" 
    PageSize="30" HeaderStyle-Font-Size="11px" EnableModelValidation="True">
        <PagerSettings Mode="NextPreviousFirstLast" FirstPageImageUrl="~/images/first.gif" LastPageImageUrl="~/images/last.gif" NextPageImageUrl="~/images/next.gif" PreviousPageImageUrl="~/images/previous.gif" />
        <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
    <Columns>
        <asp:CommandField ShowEditButton="True" />
        <asp:TemplateField >
               <ItemTemplate >                                      
                   <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Delete"
                   OnClientClick="return confirm('Confirm to delete?')"
                   Text="<%$ Resources:language, Delete%>" />
               </ItemTemplate>   
        </asp:TemplateField>
        <asp:BoundField DataField="Tag" HeaderText="<%$ Resources:language, Tag%>" ReadOnly="True" 
            SortExpression="Tag" ItemStyle-Font-Bold="true" />
        <asp:BoundField DataField="Size" HeaderText="<%$ Resources:language, Size%>" SortExpression="Size" />
    </Columns>
        <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
        <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
        <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
        <AlternatingRowStyle BackColor="#F7F7F7" />     
</asp:GridView>
</div>

