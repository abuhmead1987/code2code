<%@ Page Title="" Language="C#" MasterPageFile="~/themes/thanhlien/site.master" AutoEventWireup="true" CodeFile="TestPage.aspx.cs" Inherits="TestPage" %>

<%@ Register src="widgets/Newsletter/widget.ascx" tagname="widget" tagprefix="uc1" %>

<%@ Register src="themes/thanhlien/uc/newsletter.ascx" tagname="newsletter" tagprefix="uc2" %>


<asp:Content ID="Content1" ContentPlaceHolderID="cphBody" Runat="Server">
    
    <uc2:newsletter ID="newsletter1" runat="server" />
    
</asp:Content>

