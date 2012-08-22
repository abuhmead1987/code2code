<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.Master" AutoEventWireup="true"
    CodeBehind="cart.aspx.cs" Inherits="PGFine.cart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="inner group" id="primary">
        <div class="layout-sidebar-no group">
            <!-- START CONTENT -->
            <div class="group" role="main" id="content">
                <div class="theme_breadcumb" id="crumbs">
                    <a href="home.html" class="home">Home Page</a> › <a href="#" class="no-link current">
                        Cart</a>
                    <div class="breadcrumb-end">
                    </div>
                </div>
                <h2>
                    Cart</h2>
                <div class="post-12 page type-page status-publish hentry group" id="post-12">
                    <a class="large green sc-button" href="shop.html">&lt; Continue Shopping</a>
                    <p>
                        Your cart is empty.</p>
                    <p>
                        <a href="shop.html" class="button">← Return To Shop</a></p>
                    <a class="large green sc-button" href="shop.html">&lt; Continue Shopping</a>
                </div>
                <div id="comments">
                    <!--<p class="nocomments">&nbsp;</p>-->
                </div>
                <!-- #comments -->
            </div>
            <!-- END CONTENT -->
            <!-- START SIDEBAR -->
            <!-- END SIDEBAR -->
        </div>
        <!-- START EXTRA CONTENT -->
        <!-- END EXTRA CONTENT -->
    </div>
</asp:Content>
