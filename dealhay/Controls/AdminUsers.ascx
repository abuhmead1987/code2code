<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AdminUsers.ascx.cs" Inherits="Controls_AdminUsers" %>
<%@ Register src="AdminMenu.ascx" tagname="AdminMenu" tagprefix="uc1" %>
    <uc1:AdminMenu ID="AdminMenu1" runat="server" />
<div style="padding:5px">
    <asp:Label ID="lblemail" runat="server" Text="<%$ Resources:language, Changeemailforuser %>" ForeColor="Red" BackColor="Yellow" Visible="false"></asp:Label> <asp:Label ID="lblusername" runat="server" Font-Bold="true" Visible="false"></asp:Label> <asp:TextBox ID="TextBoxEmail" runat="server" Visible="false"></asp:TextBox> 
            <asp:Button ID="ButtonEmail" runat="server" Text="<%$ Resources:language, ChangeEmail %>" Visible="false" 
                onclick="ButtonEmail_Click" /> <br /><asp:Label ID="lblalert" runat="server" Font-Bold="true" ForeColor="Red" Visible="false"></asp:Label><br />   
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
    ConnectionString="<%$ ConnectionStrings:anmcs %>"     
        SelectCommand="SELECT aspnet_Users.UserId, aspnet_Users.UserName, aspnet_Membership.Email, aspnet_Users.LastActivityDate, aspnet_Membership.IsApproved, aspnet_Membership.CreateDate FROM aspnet_Users INNER JOIN aspnet_Membership ON aspnet_Users.UserId = aspnet_Membership.UserId ORDER BY aspnet_Users.UserName ASC"></asp:SqlDataSource>
    <asp:GridView ID="GridView1" runat="server" DataSourceID="SqlDataSource1" 
        AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" 
        BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" 
        CellPadding="3" GridLines="Horizontal" PageSize="25" 
        HeaderStyle-Font-Size="11px">
        <PagerSettings Mode="NextPreviousFirstLast" FirstPageImageUrl="~/images/first.gif" LastPageImageUrl="~/images/last.gif" NextPageImageUrl="~/images/next.gif" PreviousPageImageUrl="~/images/previous.gif" />
        <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
    <Columns>
        <asp:BoundField DataField="UserId" HeaderText="UserId" 
            SortExpression="UserId" Visible="false" />
        <asp:BoundField DataField="UserName" HeaderText="<%$ Resources:language, UserName %>" 
            SortExpression="UserName" ItemStyle-Font-Bold="true" />
        <asp:BoundField DataField="Email" HeaderText="<%$ Resources:language, Email %>" 
            SortExpression="Email" />
        <asp:BoundField DataField="LastActivityDate" HeaderText="<%$ Resources:language, LastActivity %>" 
            SortExpression="LastActivityDate" />
        <asp:CheckBoxField DataField="IsApproved" HeaderText="<%$ Resources:language, Approved %>"  
            SortExpression="IsApproved" />
        <asp:BoundField DataField="CreateDate" HeaderText="<%$ Resources:language, CreateDate %>" 
            SortExpression="CreateDate" />
            <asp:TemplateField ItemStyle-CssClass="highlightborder">
               <ItemTemplate>
                    <asp:LinkButton ID="Delete" OnClientClick="return confirm('Are you sure to delete this user ?')" CommandArgument='<%# Eval("UserName") %>' Text="<%$ Resources:language, DeleteUser %>" Font-Bold="true" runat="server" OnCommand="Delete_Command" /><br/>
                    <asp:LinkButton ID="Change" CommandArgument='<%# Eval("UserName") %>' Text="<%$ Resources:language, ChangeEmail %>" runat="server" OnCommand="Email_Command" /><br/>
                    <asp:LinkButton ID="Approve" CommandArgument='<%# Eval("UserName") + "," + Eval("UserId") + "," + Eval("IsApproved") %>' Text="<%$ Resources:language, ApproveUser %>" runat="server" Font-Bold="true" OnCommand="Approve_Command" />					
               </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField ItemStyle-CssClass="highlightborder">
               <ItemTemplate>
                    <asp:LinkButton ID="GeneratePsw" OnClientClick="return confirm('Are you sure to generate a new password ? It will be sent to the user email.')" CommandArgument='<%# Eval("UserName") + "," + Eval("UserId") %>' Text="<%$ Resources:language, Generatenewpassword %>" runat="server" OnCommand="NewPassword_Command" /><br />
                    <asp:LinkButton ID="DeleteAv" CommandArgument='<%# Eval("UserName") %>' OnClientClick="return confirm('Are you sure to delete the avatar of this user ?')" Text="<%$ Resources:language, DeleteAvatar %>" runat="server" Font-Bold="true" OnCommand="DeleteAv_Command" />
               </ItemTemplate>
            </asp:TemplateField>            
    </Columns>
        <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
        <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
        <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
        <AlternatingRowStyle BackColor="#F7F7F7" />
</asp:GridView>
</div>
