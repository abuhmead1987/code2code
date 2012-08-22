<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="PGFine._default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    <title>SHOPLAND landing page</title>
    <meta name="description" content="Flash countdown offers - 30% off on all products" />
    <meta name="keywords" content="" />
    <link href="css/master.css" rel="stylesheet" type="text/css" />
    <link href="css/fonts/fonts.css" rel="stylesheet" type="text/css" />
    <link href="css/slider_1.css" rel="stylesheet" type="text/css" />
    <!--[if IE 7]>
 <link href="css/ie7.css" rel="stylesheet" type="text/css"  />
<![endif]-->
    <!-- JQUERY -->
   
    <script src="Js/jquery.js" type="text/javascript"></script>
    <!-- Form-->
    <script type="text/javascript">
        function clickclear(thisfield, defaulttext, color) {
            if (thisfield.value == defaulttext) {
                thisfield.value = "";
                if (!color) {
                    color = "6D6F71";
                }
                thisfield.style.color = "#" + color;
            }
        }
        function clickrecall(thisfield, defaulttext, color) {
            if (thisfield.value == "") {
                thisfield.value = defaulttext;
                if (!color) {
                    color = "6D6F71";
                }
                thisfield.style.color = "#" + color;
            }
        }
</script>
    <!-- fancy box img viewer -->
    <script type="text/javascript" src="js/fancybox/jquery.fancybox-1.3.1.pack.js"></script>
    <link rel="stylesheet" type="text/css" href="js/fancybox/jquery.fancybox-1.3.1.css"
        media="screen" />
    <!-- Jquery Validate-->
    <script type="text/javascript" src="js/jquery.validate.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#myform").validate();
        });
  </script>
</head>
<body>
    <form id="form1" runat="server">
    <!-- Start top -->
    <div id="top">
        <div id="top_wp">
            <a href="#">
                <img src="img/logo.png" width="162" height="27" alt="Logo" /></a>
            <!-- Your logo -->
            <h3>
                <span>Call Us</span> 877 723 6742</h3>
            <div class="clr">
            </div>
        </div>
    </div>
    <!-- End Top -->
    <div id="pxs_container" class="pxs_container">
        <div class="pxs_loading">
            Loading images...</div>
        <div class="pxs_slider_wrapper">
            <ul class="pxs_slider">
                <li>
                    <!-- Start product one -->
                    <div class="contentdiv_2">
                        <div class="main_image">
                            <a href="img/product_big_f_1.jpg" class="box">
                                <img src="img/product_big_1.png" width="480" height="405" alt="Product" /></a>
                            <div class="badge_1">
                                -35%</div>
                        </div>
                        <div class="product_info">
                            <h2>
                                $439,90 <span>$539,90</span></h2>
                            <h3>
                                HTC Hero Touch</h3>
                            <p>
                                Lorem ipsum dolor sit amet, sonet oratio persequeris qui at, te sed quem aliquip
                                sadipscing. Vim debitis splendide ad, elitr maiestatis per at.</p>
                            <div class="timer_box_main">
                                Time remaining <span id="countbox1"></span>
                            </div>
                            <div class="buttonBuy">
                                <a href="product_single.html" class="buy">Information</a><a href="cart.html" class="buy">Buy
                                    now</a></div>
                        </div>
                        <div class="clr">
                        </div>
                    </div>
                </li>
                <!-- End product one -->
                <li>
                    <!-- Start product two -->
                    <div class="contentdiv_2">
                        <div class="main_image">
                            <a href="img/product_big_f_2.jpg" class="box">
                                <img src="img/product_big_2.png" width="480" height="405" alt="Product" /></a>
                            <div class="badge_1">
                                -25%</div>
                        </div>
                        <div class="product_info">
                            <h2>
                                $339,90 <span>$439,90</span></h2>
                            <h3>
                                HTC Z Desire</h3>
                            <p>
                                Lorem ipsum dolor sit amet, sonet oratio persequeris qui at, te sed quem aliquip
                                sadipscing. Vim debitis splendide ad, elitr maiestatis per at.</p>
                            <div class="timer_box_main">
                                Time remaining <span id="countbox2"></span>
                            </div>
                            <div class="buttonBuy">
                                <a href="product_single.html" class="buy">Information</a><a href="cart.html" class="buy">Buy
                                    now</a></div>
                        </div>
                        <div class="clr">
                        </div>
                    </div>
                </li>
                <!-- End product two -->
                <li>
                    <!-- Start product three -->
                    <div class="contentdiv_2">
                        <div class="main_image">
                            <a href="img/product_big_f_3.jpg" class="box">
                                <img src="img/product_big_3.png" width="480" height="405" alt="Product" /></a>
                            <div class="badge_1">
                                -20%</div>
                        </div>
                        <div class="product_info">
                            <h2>
                                $139,90 <span>$239,90</span></h2>
                            <h3>
                                HTC Business</h3>
                            <p>
                                Lorem ipsum dolor sit amet, sonet oratio persequeris qui at, te sed quem aliquip
                                sadipscing. Vim debitis splendide ad, elitr maiestatis per at.</p>
                            <div class="timer_box_main">
                                Time remaining <span id="countbox3"></span>
                            </div>
                            <div class="buttonBuy">
                                <a href="product_single.html" class="buy">Information</a><a href="cart.html" class="buy">Buy
                                    now</a></div>
                        </div>
                        <div class="clr">
                        </div>
                    </div>
                </li>
                <!-- End product three -->
            </ul>
            <div class="pxs_navigation">
                <span class="pxs_next"></span><span class="pxs_prev"></span>
            </div>
            <!-- Start second nav circles -->
            <ul class="pxs_thumbnails">
                <li>
                    <img src="img/circle_slider.png" alt="" /></li>
                <li>
                    <img src="img/circle_slider.png" alt="" /></li>
                <li>
                    <img src="img/circle_slider.png" alt="" /></li>
            </ul>
        </div>
    </div>
    <!-- Start content one -->
    <div id="line">
    </div>
    <div id="content_1">
        <h2>
            Ending soon</h2>
        <div class="one_col">
            <a href="img/product_big_f_3.jpg" class="box">
                <img src="img/product_small_1.jpg" width="176" height="166" alt="Product" /></a>
            <span class="price">$439,<em>90</em><strong>-30%</strong></span>
            <h3>
                HTC Hero Touch</h3>
            <p>
                Lorem ipsum dolor sit amet, sonet oratio persequeris qui at, te sed quem aliquip
                sadipscing.</p>
            <div class="timer_box">
                Ends <span id="countbox4"></span>
            </div>
            <div class="buttonAligne">
                <a href="product_single.html" class="details">More info</a><a href="cart.html" class="details">Buy
                    now</a></div>
        </div>
        <div class="one_col">
            <a href="img/product_big_f_2.jpg" class="box">
                <img src="img/product_small_2.jpg" width="176" height="166" alt="Product" /></a>
            <span class="price">$339,<em>90</em><strong>-30%</strong></span>
            <h3>
                HTC Z Desire</h3>
            <p>
                Lorem ipsum dolor sit amet, sonet oratio persequeris qui at, te sed quem aliquip
                sadipscing.</p>
            <div class="timer_box">
                Ends <span id="countbox5"></span>
            </div>
            <div class="buttonAligne">
                <a href="product_single.html" class="details">More info</a><a href="cart.html" class="details">Buy
                    now</a></div>
        </div>
        <div class="one_col last">
            <a href="img/product_big_f_1.jpg" class="box">
                <img src="img/product_small_3.jpg" width="176" height="166" alt="Product" /></a>
            <span class="price">$139,<em>90</em><strong>-30%</strong></span>
            <h3>
                HTC Small Business</h3>
            <p>
                Lorem ipsum dolor sit amet, sonet oratio persequeris qui at, te sed quem aliquip
                sadipscing.</p>
            <div class="timer_box">
                Ends <span id="countbox6"></span>
            </div>
            <div class="buttonAligne">
                <a href="product_single.html" class="details">More info</a><a href="cart.html" class="details">Buy
                    now</a></div>
        </div>
        <div class="clr">
        </div>
    </div>
    <!-- End content one -->
    <!-- Start content two -->
    <div id="content_2">
        <div id="line_1">
        </div>
        <div id="content_wp">
            <div class="one_col">
                <h4>
                    Payments method</h4>
                <p>
                    Lorem ipsum dolor sit amet, facilisis euripidis eu sed, magna reque graecis sea
                    at, ipsum persecuti sit no. Te his mucius platonem.</p>
                <img src="img/credit_cards.png" width="170" height="23" alt="Credit Cards" />
            </div>
            <div class="one_col">
                <h4>
                    Free shipping</h4>
                <p>
                    Lorem ipsum dolor sit amet, facilisis euripidis eu sed, magna reque graecis sea
                    at, ipsum persecuti sit no. Mucius platonem.<strong> For all orders over 100$.</strong></p>
                <img src="img/shipping.png" width="97" height="23" alt="Shipping" />
            </div>
            <div class="one_col last">
                <h4>
                    Customer support</h4>
                <p>
                    Lorem ipsum dolor sit amet, facilisis euripidis eu sed, magna reque graecis sea
                    at, ipsum persecuti sit no. <strong>Monday to Friday 9.00am - 18.00pm.</strong></p>
                <span class="phone">0844 369 0372</span>
            </div>
            <div class="clr">
            </div>
            <div class="one_col">
                <h4>
                    Newsletter</h4>
                <p>
                    In idque voluptua invenire sit, denique intellegat cu est. Eros saperet appareat
                    te eam, brute fastidii prodesset eu voluptua invenire sithas.</p>
                <!-- Start newsletter -->
                <div id="form_bg">
                    <form method="post" id="myform" action="#">
                    <input name="Email" type="text" class="required email" value="enter your email address.."
                        onclick="clickclear(this, 'enter your email address..')" onfocus="clickclear(this, 'enter your email address..')"
                        onblur="clickrecall(this,'enter your email address..')" />
                    <button type="submit" class="send_bt">
                        Subscribe</button>
                    </form>
                </div>
                <!-- End newsletter -->
            </div>
            <div class="one_col">
                <h4>
                    Contacts</h4>
                <p>
                    1234 Street Ln., City, ST 98765
                    <br />
                    Telephone (555) 443.3221 / Fax (555) 443.3221 <a href="#">support@shopland.com</a>
                    | <a href="#">refounds@shopland.com</a></p>
                <img src="img/social.png" width="165" height="30" alt="Social" />
            </div>
            <div class="one_col last">
                <img src="img/logos.png" width="202" height="133" />
            </div>
            <!-- End one col last -->
            <div class="clr">
            </div>
        </div>
        <!-- End content two -->
        <div id="line_2">
        </div>
    </div>
    <!-- End content_wp -->
    <!-- start footer-->
    <div id="footer">
        <div id="footer_wp">
            <ul>
                <li><a href="termsconditions.html">Terms &amp; conditions</a></li>
                <li><a href="#">Guarantee and After Sales Service</a></li>
                <li class="last"><a href="contact.html">Contact Us</a></li>
            </ul>
            <p>
                Copyright © 2011 ShopLand</p>
            <div class="clr">
            </div>
        </div>
    </div>
    <!-- end footer-->
    <script src="js/timer_special_offer.js" type="text/javascript"></script>
    <script type="text/javascript" src="js/jquery.easing.1.3.js"></script>
    <script type="text/javascript" src="js/slider.js"></script>
    <script type="text/javascript">
        $(function () {
            var $pxs_container = $('#pxs_container');
            $pxs_container.parallaxSlider();
        });
        </script>
    <script type="text/javascript" src="js/fancy_functions.js"></script>
    </form>
</body>
</html>
