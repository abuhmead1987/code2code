<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrListPage.ascx.cs"
    Inherits="PGFine.Ctrl.CtrListPage" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Assembly="System.Web.Extensions" Namespace="System.Web.UI" TagPrefix="asp" %>
<asp:LinkButton ID="lbtnChangePageSize" runat="server" Style="display: none" OnClick="lbtnChangePageSize_Click">
</asp:LinkButton>
<div class="Pageging">
    <%--<asp:LinkButton ID="PreviousPager" runat="server" OnClick="PreviousPager_Click" CausesValidation="False"
        CssClass="uiIcon lnkBack" ToolTip="...">Trang trước</asp:LinkButton>--%>
    <%--<div class="floadL middPaging">
        <ul>--%>
    <asp:Label ID="Label5" runat="server" Text="Trang:" CssClass="LabelMenuRight"></asp:Label>
    <asp:Repeater ID="PageList" runat="server" OnItemCommand="PageList_ItemCommand" OnItemDataBound="PageList_ItemDataBound">
        <ItemTemplate>
            <asp:LinkButton ID="PageIndexLink" CausesValidation="false" CommandName='<%# Eval("Key") %>'
                CssClass="LabelMenuRight" runat="server"><%# Eval("Value") %></asp:LinkButton>
        </ItemTemplate>
    </asp:Repeater>
    <%-- </ul>
    </div>--%>
    <asp:LinkButton ID="NextPager" runat="server" OnClick="NextPager_Click" CausesValidation="False"
        CssClass="LabelMenuRight" ToolTip="..." Font-Underline="false">View all</asp:LinkButton>
</div>
