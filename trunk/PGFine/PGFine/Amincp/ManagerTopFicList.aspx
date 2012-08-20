<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManagerTopFicList.aspx.cs"
    Inherits="PGFine.Amincp.ManagerTopFicList" MasterPageFile="~/Amincp/MP/MasterPageAdmin.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">    
    <div style="float:left;margin:0px 0px 0px 40px;border:solid 1px #F1D7DE;">
        <table cellpadding="0" cellspacing="1" width="917px">
            <tr style="background-color:#F1D7DE;height:20px;font-size:13px;font-weight:bold;">
                <td align="center">
                    Tên chủ đề
                </td>
                <td align="center" width="50">
                    Thứ tự
                </td>
                <td align="center" width="150">
                    Vị trí
                </td>
            </tr>            
            <asp:Literal ID="ltrHtmlTr" runat="server"></asp:Literal>
        </table>
    </div>
</asp:Content>
