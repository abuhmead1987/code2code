<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<NewsManagement.anm_News>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    View
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <%= Model.news %>
    </div>
</asp:Content>
