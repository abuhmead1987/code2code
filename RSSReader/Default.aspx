<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <asp:Button ID="btnSaveHead" runat="server" Text="Save"  onclick="btnSave_Click"     />
<div>
        <asp:DataList ID="DataList1" runat="server">
            <ItemTemplate>
                <asp:HyperLink ID="id" runat="server" NavigateUrl='<%# Eval("Id") %>' 
                    Text='<%# Eval("Text") %>'></asp:HyperLink>&nbsp
                <asp:CheckBox ID="chkCheck" runat="server" Text="Đưa vào tin tức" />
                <br />
                <br />
                <asp:Label ID="Label1" runat="server" Text='<%# Eval("Summary") %>'></asp:Label>
                <br />
                <br />
                <asp:Label ID="Label2" runat="server" Text='<%# Eval("PublishDate") %>'></asp:Label>
                &nbsp;<asp:Label ID="Label3" runat="server" Text='<%# Eval("CopyRight") %>'></asp:Label>
                <br />
                <br />
            </ItemTemplate>
        </asp:DataList>
        <asp:Button ID="btnSave" runat="server" Text="Lưu" 
            onclick="btnSave_Click"       />
    </div>
</asp:Content>
