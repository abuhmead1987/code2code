<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UsersOnline.ascx.cs" Inherits="Controls_UsersOnline" %>
        <asp:Panel ID="pnlVisitors" Visible="false" runat="server">
        <h2><asp:Literal ID="Literal1" runat="server" Text="<%$ Resources:language, OnlineUsers%>" /></h2>
        <div class="sp">
        - <asp:Literal ID="Literal2" runat="server" Text="<%$ Resources:language, TotalUsers%>" />: 
            <asp:Literal ID="TotalUsers" runat="server"></asp:Literal><br />
        - <asp:Literal ID="Literal4" runat="server" Text="<%$ Resources:language, Members%>" />: 
            <asp:Literal ID="Members" runat="server"></asp:Literal><br />
        - <asp:Literal ID="Literal3" runat="server" Text="<%$ Resources:language, Visitors%>" />: 
            <asp:Literal ID="Visitors" runat="server"></asp:Literal><br /><br />
        <asp:Literal ID="Literal5" runat="server" Text="<%$ Resources:language, OnlineNow%>" />: <asp:Label ID="OnlineNow" runat="server" Text="Label"></asp:Label>
        </div>
        </asp:Panel>