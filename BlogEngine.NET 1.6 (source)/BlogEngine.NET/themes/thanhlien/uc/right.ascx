<%@ Control Language="C#" AutoEventWireup="true" CodeFile="right.ascx.cs" Inherits="themes_thanhlien_uc_right" %>
<%@ Register Src="newsletter.ascx" TagName="newsletter" TagPrefix="uc1" %>
<img src='<%=Page.ResolveUrl("~/themes/thanhlien/images/header_khuyenmai.jpg")%>'
    alt="Tin khuyến mãi" width="201" height="41" />
<ul>
    <li>Đặt phòng khách sạn tặng Vé xem phim hoặc Phiếu mua sắm. Áp dụng đến 31/11, với
        mỗi đặt phòng trên 1,500,000 vnd.</li>
    <li>Tháng giá tốt Áp dụng đến 31/12/2009, giảm giá tới mức thấp nhất thị trường với
        hơn 300 khách sạn trên khắp Vn.</li>
    <li>Ưu đãi cho cán bộ thư kí, nhân sự. Áp dụng đến 31/12, ưu đãi hấp dẫn cho mọi cán
        bộ nhân sự, thư kí.</li></ul>
<p class="dangky">
    &nbsp;<uc1:newsletter ID="newsletter1" runat="server" />
    <p>
        <img src='<%=Page.ResolveUrl("~/themes/thanhlien/images/header_hotro.jpg")%>' alt="Hỗ trợ trực tuyến"
            width="190" height="61" />
            
        <asp:DataList ID="lstContact" runat="server" CssClass="lstContact">
            <ItemTemplate>
                <a href='<%#XPath("@id") %>'>
                    <img src='<%=Page.ResolveUrl("~/themes/thanhlien/images/icon_chat.jpg")%>' width="144"
                        height="29" border="0" alt="" /></a><br />
                <%#XPath("@name") %>
            </ItemTemplate>
        </asp:DataList>
        
        <div style="margin-left:10px">
            <img src='<%=Page.ResolveUrl("~/themes/thanhlien/images/bg_right_col.jpg")%>' width="190px"
                height="29" alt=""/>
            <p class="center">
                <a href="http://weather.yahoo.com/vietnam/ha-noi/hanoi-1236594?unit=c" target="_blank">
                    <img src='<%=Page.ResolveUrl("~/themes/thanhlien/images/btn_dubao.gif")%>' alt="Dự báo thời tiết"
                        width="148" height="24" border="0" /></a></p>
        </div>
