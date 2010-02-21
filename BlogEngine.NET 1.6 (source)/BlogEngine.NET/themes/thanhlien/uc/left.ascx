<%@ Control Language="C#" AutoEventWireup="true" CodeFile="left.ascx.cs" Inherits="themes_thanhlien_uc_left" %>
<img src='<%=Page.ResolveUrl("~/themes/thanhlien/images/bg_left_col.jpg")%>' width="235"
    height="45" /><a href="#"><img src='<%=Page.ResolveUrl("~/themes/thanhlien/images/arrow_up.gif")%>'
        alt="up" width="19" height="7" class="space_up" border="0" /></a><br />
<img src='<%=Page.ResolveUrl("~/themes/thanhlien/images/img1.jpg")%>' alt="image"
    width="167" height="107" class="frame" /><img src='<%=Page.ResolveUrl("~/themes/thanhlien/images/img3.jpg")%>'
        alt="image" width="167" height="107" class="frame" />
<img src='<%=Page.ResolveUrl("~/themes/thanhlien/images/img1.jpg")%>' alt="image"
    width="167" height="107" class="frame" /><br />
<a href="#">
    <img src='<%=Page.ResolveUrl("~/themes/thanhlien/images/arrow_down.gif")%>' alt="down"
        width="19" height="7" class="space_down" border="0" /></a>
<img alt="" src='<%=Page.ResolveUrl("~/themes/thanhlien/images/bg_left_col2.jpg")%>' class="space" /><p>
    <%=Resources.labels.Gallery.ToString() %></p>
<div id="slideshow">
    <img src='<%=Page.ResolveUrl("~/themes/thanhlien/images/lib/img1.jpg")%>' alt="image"
        width="183" height="122" class="border" />
    <img src='<%=Page.ResolveUrl("~/themes/thanhlien/images/lib/img2.jpg")%>' alt="image"
        width="183" height="122" class="border" />
    <img src='<%=Page.ResolveUrl("~/themes/thanhlien/images/lib/img3.jpg")%>' alt="image"
        width="183" height="122" class="border" />
    <img src='<%=Page.ResolveUrl("~/themes/thanhlien/images/lib/img4.jpg")%>' alt="image"
        width="183" height="122" class="border" />
</div>

<script type="text/javascript">

    function slideSwitch() {
        var $active = $('#slideshow IMG.active');

        if ($active.length == 0) $active = $('#slideshow IMG:last');

        // use this to pull the images in the order they appear in the markup
        var $next = $active.next().length ? $active.next()
        : $('#slideshow IMG:first');

        // uncomment the 3 lines below to pull the images in random order

        // var $sibs  = $active.siblings();
        // var rndNum = Math.floor(Math.random() * $sibs.length );
        // var $next  = $( $sibs[ rndNum ] );
        $active.addClass('last-active');

        $next.css({ opacity: 0.0 })
        .addClass('active')
        .animate({ opacity: 1.0 }, 1000, function() {
            $active.removeClass('active last-active');
        });
    }

    $(function() {
        setInterval("slideSwitch()", 5000);
    });

</script>

