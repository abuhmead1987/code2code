<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Programs.aspx.cs" MasterPageFile="~/MasterPageUser/MasterPageUser.Master"
    Inherits="PGFine.Programs" %>

<%@ Register Assembly="CollectionPager" Namespace="SiteUtils" TagPrefix="cc2" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="FlashMain">
        <object classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" codebase="Images/fla2_1.swf"
            width="504" height="269">
            <param name="movie" value="Images/fla2_1.swf" />
            <param name="wmode" value="transparent" />
            <embed src="Images/fla2_1.swf" quality="high" pluginspage="http://www.macromedia.com/go/getflashplayer"
                type="application/x-shockwave-flash" width="504" height="269"></embed>
        </object>
    </div>
    <div class="MainCompanyProfile">
        <div class="GroupTitleNews">
            <asp:Label ID="lbCaption" runat="server" Text="PROGRAMS" CssClass="GroupTitleNewsCaptionMain"></asp:Label>
            <asp:Label ID="lbCaptionDay" runat="server" Text="Ngày, 14/01/2009" CssClass="Time"></asp:Label>
        </div>
        <div class="ContentProgram">
            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" ShowHeader="False"
                AutoGenerateColumns="False" CellPadding="0" ForeColor="#333333" GridLines="None"
                OnPageIndexChanging="GridView1_PageIndexChanging" PageSize="6">
                <PagerSettings NextPageText="Trang kế" PreviousPageText="Trở về" />
                <FooterStyle BackColor="White" Font-Bold="True" ForeColor="Black" />
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <div class="MasterNewsContent">
                                <table class="style1">
                                    <tr>
                                        <td rowspan="3">
                                            <asp:HyperLink ID="HyperLink2" runat="server" CssClass="ImagesNewss" NavigateUrl='<%# "~/ProgramDetail.aspx?SubjectID=" + Eval("SubjectID").ToString() %>'
                                                ImageUrl='<%# Eval("PathImages").ToString() %>'></asp:HyperLink>
                                        </td>
                                        <td>
                                            <asp:HyperLink ID="HyperLink21" runat="server" Text='<%# Eval("TitleNews").ToString() %>'
                                                CssClass="MasterNewsTitle" NavigateUrl='<%# "~/ProgramDetail.aspx?SubjectID=" + Eval("SubjectID").ToString() %>'
                                                Font-Underline="false"></asp:HyperLink>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:HyperLink ID="HyperLink22" runat="server" Text='<%# Eval("ShortDescription").ToString() %>'
                                                CssClass="NewsShortDescription"></asp:HyperLink>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <div class="MasterNewsDetail">
                                                <asp:HyperLink ID="hplMore" runat="server" Text="More..." CssClass="LinksDetailNews"
                                                    Font-Underline="false" NavigateUrl='<%# "~/ProgramDetail.aspx?SubjectID=" + Eval("SubjectID").ToString() %>'></asp:HyperLink>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <PagerStyle BackColor="#FFFFCC" ForeColor="Black" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <EditRowStyle BackColor="#999999" />
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            </asp:GridView>
        </div>
        <asp:Label ID="_errorLabel" runat="server" Text="Label" Visible="false"></asp:Label>
        <asp:Label ID="lbNewsNull" runat="server" Text="" Visible="false" CssClass="NewsNull"></asp:Label>
    </div>
    <%--          <div class="NewsOrther">
            <asp:Label ID="Label5" runat="server" Text="Các tin khác" CssClass="NewsOrtherText"></asp:Label>
            <div class="PaceDotted">
            </div>
        </div>
       
   <asp:DataList ID="DataList2" runat="server">
            <ItemTemplate>
                <div class="NewsOrtherContent">
                    <asp:Image ID="Image12" runat="server" ImageUrl="~/Images/Symbol1.gif" CssClass="NewsOtherI" />
                    <asp:HyperLink ID="HyperLink16" runat="server" Text='<%# Eval("TitleNews").ToString() %>'
                        NavigateUrl='<%# "~/NewsDetail.aspx?NewsID=" + Eval("NewsID").ToString() %>'
                        CssClass="NewsOtherII" Font-Underline="false"></asp:HyperLink>
                </div>
            </ItemTemplate>
        </asp:DataList>
        <cc2:CollectionPager ID="CollectionPager2" runat="server" BackNextLocation="Split"
            ControlCssClass="PhanTrang1" PageNumbersDisplay="Results" PageSize="8" ResultsLocation="None"
            ShowFirstLast="True" ShowLabel="False" ShowPageNumbers="False" SliderSize="5"
            BackNextStyle="padding-left:5px;" BackText="Xem lại" PageNumbersStyle="background-color:#FCD765;height:12px;border:solid 1px #F6921E;padding-left:5px;padding-right:5px;"
            NextText="Xem tiếp" FirstText="" HideOnSinglePage="True" LastText="">
        </cc2:CollectionPager>
    </div>--%>
</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="head">
    <style type="text/css">
        .style1
        {
            width: 500px;
        }
    </style>
</asp:Content>
