<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlProgramsHot.ascx.cs"
    Inherits="PGFine.Ctrl.CtrlProgramsHot" %>
<asp:DataList ID="DataList1" runat="server">
    <ItemTemplate>
        <a id="A1" class="link2" runat="server" href='<%# "~/ProgramDetail.aspx?SubjectID=" + Eval("SubjectID").ToString() %>'>
            <asp:Label ID="Label1" runat="server" Text='<%# Eval("TitleNews").ToString() %>'
                CssClass="MasterMainProgramsContent" Font-Underline="false"></asp:Label>
        </a>
    </ItemTemplate>
</asp:DataList>
<asp:Label ID="_errorLabel" runat="server" Text="Label" Visible="false"></asp:Label>
<asp:Label ID="lbNewsNull" runat="server" Text="" Visible="false" CssClass="NewsNull"></asp:Label>

