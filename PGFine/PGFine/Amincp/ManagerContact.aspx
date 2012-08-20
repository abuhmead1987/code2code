<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManagerContact.aspx.cs" MasterPageFile="~/Amincp/MP/MasterPageAdmin.Master" Inherits="PGFine.Amincp.ManagerContact" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table cellpadding="2" cellspacing="2" border="0" width="95%" align="center">
        <tr>
            <td>
                <asp:Label ID="_errorLabel" runat="server" CssClass="errorMessage" Visible="False" />
                <br>
                <asp:DataGrid ID="_grid" runat="server" Width="100%" AutoGenerateColumns="False"
                    AllowPaging="True" DataKeyField="ContactID" CssClass="dgGrid"
                    ShowFooter="True" onpageindexchanged="_grid_PageIndexChanged">
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
                                    AlternateText="Delete Record" ID="_DeleteButton" 
                                    oncommand="_DeleteButton_Command"></asp:ImageButton>
                            </FooterTemplate>
                            <ItemStyle Width="20px" />
                        </asp:TemplateColumn>
                        <asp:TemplateColumn>
                            <HeaderTemplate>
                                <img src="../Images/n.gif" width="20" height="1">
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:ImageButton ImageUrl="../Images/Edit.gif" AlternateText="Edit Record" CommandName='<%# Eval("ContactID").ToString() %>'
                                    runat="server" ID="_editButton" OnCommand="_editButton_Command" 
                                    Height="16px" />
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:ImageButton ImageUrl="../Images/Insert.gif" AlternateText="Insert Record" runat="server"
                                    ID="_insertButton" Enabled="false" />
                            </FooterTemplate>
                            <ItemStyle Width="20px" />
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="Tên Khách Hàng" SortExpression="id">
                            <ItemTemplate>
                                <asp:Label ID="Label1" Text='<%# DataBinder.Eval(Container.DataItem, "Name") %>'
                                    runat="server" />
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="Điện Thoại" SortExpression="noidung">
                            <ItemTemplate>
                                <asp:Label ID="Label2" Text='<%# DataBinder.Eval(Container.DataItem, "Phone") %>'
                                    runat="server" />
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="Email" SortExpression="noidung">
                            <ItemTemplate>
                                <asp:Label ID="Label212" Text='<%# DataBinder.Eval(Container.DataItem, "Email") %>'
                                    runat="server" />
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="Địa Chỉ" SortExpression="noidung">
                            <ItemTemplate>
                                <asp:Label ID="Label233" Text='<%# DataBinder.Eval(Container.DataItem, "Address") %>'
                                    runat="server" />
                            </ItemTemplate>
                        </asp:TemplateColumn>
                    </Columns>
                </asp:DataGrid>
                <table cellspacing="0" cellpadding="0" class="TableFitter" width="100%" border="0">
                    <tr class="filterHeader">
                        <td class="" align="left">
                            &nbsp;&nbsp;<asp:ImageButton ID="btnShowFilter" runat="server" ImageUrl="../images/filter.gif"
                                AlternateText="Filter records"></asp:ImageButton>
                            <strong><span>&nbsp;TÌM KIẾM:</span></strong>
                            <asp:Label ID="lblFilter" runat="server" CssClass="">None</asp:Label>
                        </td>
                        <td>
                        </td>
                        <td class="" align="right">
                            <span>Tổng số mục hiện tại:</span>
                            <asp:Label ID="lblTotalRows" runat="server" CssClass="" Font-Bold="true">0</asp:Label>&nbsp;&nbsp;
                        </td>
                    </tr>
                </table>
                <div class="filterBox">
                    <table border="0">
                        <tr>
                            <td>
                                <asp:Label ID="lblCritId" runat="server">Mã:</asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtCritId" runat="server" CssClass="TextboxSearch"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblCritNoidung" runat="server">Khách hàng:</asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtName" runat="server" CssClass="TextboxSearch"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label3" runat="server">Phone:</asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtPhone" runat="server" CssClass="TextboxSearch"></asp:TextBox>
                            </td>
                        </tr>
                         <tr>
                            <td>
                                <asp:Label ID="Label4" runat="server">Email:</asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtEmail" runat="server" CssClass="TextboxSearch"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                <asp:Button ID="btnFilter" runat="server" Text="Tìm kiếm" CssClass="Button" OnClick="btnFilter_Click">
                                </asp:Button>&nbsp;
                                <asp:Button ID="btnClear" runat="server" Text="Xem hết" CssClass="Button" Width="62px"
                                    OnClick="btnClear_Click"></asp:Button>
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>
