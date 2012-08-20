<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlFooter.ascx.cs"
    Inherits="PGFine.Ctrl.CtrlFooter" %>
<asp:Repeater ID="rptFooter" runat="server" 
    onitemdatabound="rptFooter_ItemDataBound">
    <ItemTemplate>
        <div class="DivTitleFooter">
            <asp:Label ID="Label1" runat="server" Text="Label" Visible="false"></asp:Label>
            <asp:HiddenField ID="hdUrl" runat="server" Value='<%# Eval("PageLink").ToString() %>' />
            <asp:HyperLink ID="hplTypeNews" runat="server" Text='<%# Eval("NameNewsVN").ToString() %>' 
                NavigateUrl="#" CssClass="TitleFooter" ToolTip='<%# Eval("TypeNewsID").ToString() %>'></asp:HyperLink></div>     
    </ItemTemplate>
</asp:Repeater>
<asp:Label ID="_errorLabel" runat="server" Text="Label" Visible="false"></asp:Label>
