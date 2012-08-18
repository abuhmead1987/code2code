<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AdminComments.ascx.cs" Inherits="Controls_AdminComments" %>
<%@ Register src="AdminMenu.ascx" tagname="AdminMenu" tagprefix="uc1" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
    <uc1:AdminMenu ID="AdminMenu1" runat="server" />
<div style="padding:5px">
    <asp:Label ID="Label1" runat="server" Text="<%$ Resources:language, Comments%>" Font-Bold="true" ></asp:Label>: <asp:Label ID="Label2" runat="server" Visible="false"></asp:Label><br /><asp:Label ID="lblerror" runat="server" ForeColor="Red" Visible="false"></asp:Label><br />
    <CKEditor:CKEditorControl ID="txtComment" Width="81%" Height="120px" BasePath="~/ckeditor" EnterMode="BR" Visible="false" runat="server"></CKEditor:CKEditorControl>
    <asp:Button ID="UpdateComment" runat="server" Text="<%$ Resources:language, Update%>" Visible="false" onclick="UpdateComment_Click" />
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" 
        BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" 
        CellPadding="3" DataKeyNames="idnews" GridLines="Horizontal" PageSize="40">
        <PagerSettings Mode="NumericFirstLast" />
        <PagerStyle HorizontalAlign="Center" BorderWidth="5px" />
        <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
        <Columns>
            <asp:TemplateField ItemStyle-CssClass="highlightborder">
               <ItemTemplate>
                    <asp:LinkButton ID="EditComment" Visible='<%# IsVisible() %>' CommandArgument='<%# Eval("comment") + "," + Eval("idcomment") %>' Text="<%$ Resources:language, Edit%>" runat="server" OnCommand="Edit_Comment" /><br/>
                    <asp:LinkButton ID="DeleteComment" Visible='<%# IsVisible() %>' OnClientClick="return confirm('Are you sure to delete this comment ?')" CommandArgument='<%# Eval("idcomment") + "," + Eval("idnews") + "," + Eval("approved") %>' Text="<%$ Resources:language, Delete%>" Font-Bold="true" runat="server" OnCommand="Delete_Comment" />
               </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="idcomment" HeaderText="idc" InsertVisible="False" 
                ReadOnly="True" SortExpression="idcomment" />
            <asp:BoundField DataField="idnews" HeaderText="news" SortExpression="idnews" />
            <asp:BoundField DataField="commentator" HeaderText="<%$ Resources:language, Author%>" SortExpression="commentator" />
            <asp:BoundField DataField="ip" HeaderText="ip" SortExpression="ip" />
            <asp:BoundField DataField="date" HeaderText="<%$ Resources:language, Date%>" SortExpression="date" />
            <asp:BoundField DataField="comment" HtmlEncode="false" HeaderText="<%$ Resources:language, Comment%>" SortExpression="comment" ItemStyle-CssClass="highlight2" />
            <asp:CheckBoxField DataField="approved" HeaderText="<%$ Resources:language, Approved%>" SortExpression="approved" />
            <asp:TemplateField ItemStyle-CssClass="highlightborder">
               <ItemTemplate>
                    <asp:LinkButton ID="ApproveButton" CommandArgument='<%# Eval("idcomment") + "," + Eval("idnews") + ",true" + "," + Eval("approved") %>' Text="<%$ Resources:language, Approve%>" Font-Bold="true" runat="server" OnCommand="Approve_Command" /><br/>
                    <asp:LinkButton ID="DisApproveButton" CommandArgument='<%# Eval("idcomment") + "," + Eval("idnews") + ",false" + "," + Eval("approved") %>' Text="<%$ Resources:language, DisApprove%>" runat="server" OnCommand="Approve_Command" /><br/>
                    <asp:HyperLink ID="ViewNewsButton" NavigateUrl='<%# "~/articles/" + Eval("idnews") + "/" + RNA(Eval("idnews").ToString()) + ".aspx" %>' Target="_blank" Text="<%$ Resources:language, ViewNews%>" Font-Bold="true" runat="server"></asp:HyperLink>
               </ItemTemplate>
            </asp:TemplateField>         
        </Columns>
        <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
        <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
        <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
        <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
        <AlternatingRowStyle BackColor="#F7F7F7" />
        <EmptyDataTemplate>
            <asp:Label ID="lblnoresult" runat="server" Font-Bold="true" Text="<%$ Resources:language, nocomments%>"></asp:Label>
        </EmptyDataTemplate>
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:anmcs %>" SelectCommand="anm_GetCommentsByIdn" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:QueryStringParameter Name="idnews" 
                QueryStringField="idnews" Type="Int32" />
        </SelectParameters>      
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
        ConnectionString="<%$ ConnectionStrings:anmcs %>" SelectCommand="anm_GetComments" SelectCommandType="StoredProcedure">            
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource3" runat="server" 
        ConnectionString="<%$ ConnectionStrings:anmcs %>" SelectCommand="anm_GetCommentsAll" SelectCommandType="StoredProcedure">               
    </asp:SqlDataSource>    
</div>