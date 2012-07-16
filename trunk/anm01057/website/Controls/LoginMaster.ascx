<%@ Control Language="C#" AutoEventWireup="true" CodeFile="LoginMaster.ascx.cs" Inherits="Controls_LoginMaster" %>
            <asp:Label ID="currentDate" runat="server"></asp:Label>
            <asp:LoginView ID="LoginView2" runat="server">
                <LoggedInTemplate>
                    || &nbsp;<asp:LoginName ID="LoginName1" Font-Bold="true" runat="server" />: <asp:HyperLink ID="MyP" Text="<%$ Resources:language, MyProfile %>" runat="server"></asp:HyperLink> -- <asp:LoginStatus ID="LoginStatus1" OnLoggedOut="redirect" runat="server" /> &nbsp;||&nbsp; <% Response.Write(AdminLink()); %>
                </LoggedInTemplate>
                <AnonymousTemplate>
                    || &nbsp;<asp:LoginStatus ID="LoginStatus1" Font-Bold="true" runat="server" /> &nbsp;||&nbsp; <asp:HyperLink ID="HLreg" Text="<%$ Resources:language, Register %>" runat="server"></asp:HyperLink>
                </AnonymousTemplate>
            </asp:LoginView>
