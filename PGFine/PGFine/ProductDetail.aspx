<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.Master" AutoEventWireup="true"
    CodeBehind="productdetail.aspx.cs" Inherits="PGFine.productdetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="layout-sidebar-no group">
                    <div id="container">
                        <div id="content" role="main">
                            <div id="breadcrumb">
                                <a class="home" href="home.html">Home</a> &rsaquo; <a href="#">Categories</a> &rsaquo;
                                <a href="#">Garden</a> &rsaquo; Gold mahibo
                            </div>
                            <div class="product type-product status-publish hentry">
                                <div class="images">
                                    <a href="images/product_single/originalparquet_001_big.jpg" class="zoom" rel="prettyphoto[gallery]">
                                        <img width="530" height="345" src="images/product_single/originalparquet_001_big-530x345.jpg"
                                            class="attachment-530x345 wp-post-image" alt="originalparquet_001_big" title="originalparquet_001_big" />
                                    </a>
                                    <div class="thumbnails">
                                        <a href="images/product_single/albatros_niwa_001_big.jpg" title="albatros_niwa_001_big"
                                            rel="prettyphoto[gallery]" class="zoom first">
                                            <img width="90" height="90" src="images/product_single/albatros_niwa_001_big-90x90.jpg"
                                                class="attachment-90x90" alt="albatros_niwa_001_big" title="albatros_niwa_001_big" />
                                        </a><a href="images/product_single/palaceliving_002_big.jpg" title="palaceliving_002_big"
                                            rel="prettyphoto[gallery]" class="zoom ">
                                            <img width="90" height="90" src="images/product_single/palaceliving_002_big-90x90.jpg"
                                                class="attachment-90x90" alt="palaceliving_002_big" title="palaceliving_002_big" />
                                        </a>
                                    </div>
                                    <span class="onsale">Sale!</span>
                                </div>
                                <div class="summary">
                                    <h1 class="product_title page-title">
                                        Gold mahibo</h1>
                                    <p class="price">
                                        <del>&#36;1,000.00</del> <ins>&#36;450.00</ins></p>
                                    <p>
                                        There are many variations of passages of Lorem Ipsum available, but the majority
                                        have suffered alteration in some form, by injected humour, or randomised words which
                                        don’t look even slightly believable. If you are going to use a passage of Lorem
                                        Ipsum, you need to be sure there isn’t anything embarrassing hidden in the middle
                                        of text.
                                    </p>
                                    <div class="cart">
                                    <div class="quantity">
                                        <input name="quantity" value="1" size="4" title="Qty" class="input-text qty text"
                                            maxlength="12" /></div>
                                    <button type="submit" class="button-alt">
                                        Add to cart</button>
                                    <input type="hidden" id="_n" name="_n" value="a93bb4a4c2" /><input type="hidden"
                                        name="_wp_http_referer" value="/demo/sommerce/shop/gold-mahibo/" />
                                    </div>
                                    <div class="product_meta">
                                        <span class="sku">SKU: 27.</span> <span class="posted_in">Posted in <a href="#" rel="tag">
                                            Garden</a>, <a href="#" rel="tag">Pathio</a>, <a href="#" rel="tag">Wood</a>.</span></div>
                                </div>
                                <div id="product-tabs">
                                    <ul class="tabs">
                                        <li class="active"><a href="#related-products">Related Products</a></li>
                                        <li><a href="#tab-description">Description</a></li>
                                    </ul>
                                    <div class="containers">
                                        <div class="panel" id="related-products">
                                            <div class="related products">
                                                <ul class="products">
                                                    <li class="product border shadow first last-row"><a href="#">
                                                        <div class="thumbnail">
                                                            <img width="150" height="150" src="images/common/001.png" class="attachment-shop_small wp-post-image"
                                                                alt="001" title="001" />
                                                            <div class="thumb-shadow">
                                                            </div>
                                                            <strong class="below-thumb">Elegant Glasses</strong>
                                                        </div>
                                                        <span class="price">&#36;250.00</span> </a>
                                                        <div class="buttons">
                                                            <a href="#" class="details">DETAILS</a>&nbsp;<a href="#" class="add-to-cart">ADD TO
                                                                CART</a>
                                                        </div>
                                                    </li>
                                                    <li class="product border shadow last-row"><a href="#">
                                                        <div class="thumbnail">
                                                            <img width="150" height="150" src="images/common/warmroom-150x150.jpg" class="attachment-shop_small wp-post-image"
                                                                alt="warmroom" title="warmroom" />
                                                            <div class="thumb-shadow">
                                                            </div>
                                                            <strong class="below-thumb">Hot Room</strong>
                                                        </div>
                                                        <span class="price">&#36;730.00</span> </a>
                                                        <div class="buttons">
                                                            <a href="#" class="details">DETAILS</a>&nbsp;<a href="#" class="add-to-cart">ADD TO
                                                                CART</a>
                                                        </div>
                                                    </li>
                                                    <li class="product border shadow last-row"><a href="#">
                                                        <div class="thumbnail">
                                                            <img width="150" height="150" src="images/common/ktichen21-150x150.jpg" class="attachment-shop_small wp-post-image"
                                                                alt="ktichen2" title="ktichen2" />
                                                            <div class="thumb-shadow">
                                                            </div>
                                                            <strong class="below-thumb">Wood Kitchen</strong>
                                                        </div>
                                                        <span class="price">&#36;367.00</span> </a>
                                                        <div class="buttons">
                                                            <a href="#" class="details">DETAILS</a>&nbsp;<a href="#" class="add-to-cart">ADD TO
                                                                CART</a>
                                                        </div>
                                                    </li>
                                                    <li class="product border shadow last-row"><a href="#">
                                                        <div class="thumbnail">
                                                            <img width="150" height="150" src="images/common/warmroom-150x150.jpg" class="attachment-shop_small wp-post-image"
                                                                alt="kitchen" title="kitchen" />
                                                            <div class="thumb-shadow">
                                                            </div>
                                                            <strong class="below-thumb">Dark Kitchen</strong>
                                                        </div>
                                                        <span class="price">&#36;940.00</span> </a>
                                                        <div class="buttons">
                                                            <a href="#" class="details">DETAILS</a>&nbsp;<a href="#" class="add-to-cart">ADD TO
                                                                CART</a>
                                                        </div>
                                                    </li>
                                                </ul>
                                                <div class="clear">
                                                </div>
                                            </div>
                                        </div>
                                        <div class="panel" id="tab-description">
                                            <p>
                                                There are many variations of passages of Lorem Ipsum available, but the majority
                                                have suffered alteration in some form, by injected humour, or randomised words which
                                                don&#8217;t look even slightly believable. If you are going to use a passage of
                                                Lorem Ipsum, you need to be sure there isn&#8217;t anything embarrassing hidden
                                                in the middle of text. All the Lorem Ipsum generators on the Internet tend to repeat
                                                predefined chunks as necessary, making this the first true generator on the Internet.</p>
                                        </div>
                                        <div class="panel" id="tab-attributes">
                                            <h2>
                                                Additional Information</h2>
                                        </div>
                                        <div class="panel" id="tab-reviews">
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
</asp:Content>
