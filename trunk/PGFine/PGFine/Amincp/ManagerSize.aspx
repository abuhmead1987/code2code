﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManagerSize.aspx.cs"
    MasterPageFile="~/Amincp/MP/MasterPageAdmin.Master" Inherits="PGFine.Amincp.ManagerSize" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table cellpadding="2" cellspacing="2" border="0" width="95%" align="center">
        <tr>
            <td>
                <asp:Label ID="_errorLabel" runat="server" CssClass="errorMessage" Visible="False" />
                <br>
                <asp:DataGrid ID="_grid" runat="server" Width="100%" AutoGenerateColumns="False"
                    AllowPaging="True" DataKeyField="ID" CssClass="dgGrid"
                    ShowFooter="True" onpageindexchanged="_grid_PageIndexChanged" >
                    <HeaderStyle CssClass="dgHeader" />
                    <ItemStyle CssClass="dgItem" />
                    <AlternatingItemStyle BackColor="#F2F5F8" CssClass="dgAltItem" />
                    <FooterStyle CssClass="dgFooter" />
                    <PagerStyle Mode="NumericPages" HorizontalAlign="Left" CssClass="dgPager" />
                    <Columns>
                        <asp:TemplateColumn>
                            <HeaderTemplate>
                                <img src="../Images/n.gif" width="20" height="1">
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:CheckBox runat="server" ID="chkDelete"></asp:CheckBox>
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:ImageButton CommandName="Delete" runat="server" ImageUrl="../images/Delete.gif"
                                    AlternateText="Delete Record" ID="_DeleteButton" OnCommand="_DeleteButton_Command">
                                </asp:ImageButton>
                            </FooterTemplate>
                            <ItemStyle Width="20px" />
                        </asp:TemplateColumn>
                        <asp:TemplateColumn>
                            <HeaderTemplate>
                                <img src="../Images/n.gif" width="20" height="1">
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:ImageButton ImageUrl="../Images/Edit.gif" AlternateText="Edit Record" CommandName='<%# Eval("ID").ToString() %>'
                                    runat="server" ID="_editButton" OnCommand="_editButton_Command" />
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:ImageButton ImageUrl="../Images/Insert.gif" AlternateText="Insert Record" runat="server"
                                    ID="_insertButton" OnCommand="_insertButton_Command" />
                            </FooterTemplate>
                            <ItemStyle Width="20px" />
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="Mã" SortExpression="id">
                            <ItemTemplate>
                                <asp:Label ID="Label1" Text='<%# DataBinder.Eval(Container.DataItem, "ID") %>'
                                    runat="server" />
                            </ItemTemplate>
                        </asp:TemplateColumn>
                           <asp:TemplateColumn HeaderText="Thứ tự hiển thị" SortExpression="IndexOf">
                            <ItemTemplate>
                                <asp:Label ID="lbIndexOf" Text='<%# DataBinder.Eval(Container.DataItem, "NameSize") %>'
                                    runat="server" />
                            </ItemTemplate>
                        </asp:TemplateColumn>                        
                    </Columns>
                </asp:DataGrid>                
            </td>
        </tr>
    </table>
</asp:Content>
