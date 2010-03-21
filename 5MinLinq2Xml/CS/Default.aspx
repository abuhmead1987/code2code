﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:GridView ID="grdContact" runat="server" AutoGenerateColumns="False" AutoGenerateDeleteButton="True"
            AutoGenerateEditButton="True" OnRowCancelingEdit="grdContact_RowCancelingEdit"
            OnRowDeleting="grdContact_RowDeleting" OnRowEditing="grdContact_RowEditing" OnRowUpdating="grdContact_RowUpdating"
            DataKeyNames="id">
            <Columns>
                <asp:TemplateField HeaderText="Name">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtName" runat="server" Text='<%# Bind("name") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblName" runat="server" Text='<%# Bind("name") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Email">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtEmail" runat="server" Text='<%# Bind("email") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblEmail" runat="server" Text='<%# Bind("email") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
    <br />
    <p>
    <asp:Label ID="lblName" runat="server" Text="Name:"></asp:Label>
    &nbsp;<asp:TextBox ID="txtUserName" runat="server"></asp:TextBox></p>
<p>
    <asp:Label ID="Label2" runat="server" Text="Email: "></asp:Label>
    &nbsp;<asp:TextBox ID="txtEmailAdress" runat="server"></asp:TextBox>
<p />
<asp:Button ID="btnAdd" runat="server" Text="Add" onclick="btnAdd_Click" />
    </form>
</body>
</html>
