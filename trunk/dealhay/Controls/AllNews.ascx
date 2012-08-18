<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AllNews.ascx.cs" Inherits="Controls_AllNews" %>

	    <%@ Register src="SearchMenu.ascx" tagname="SearchMenu" tagprefix="uc1" %>
	    <%@ Register src="SideMenu.ascx" tagname="SideMenu" tagprefix="uc1" %>
	    <%@ Register src="ArchiveMenu.ascx" tagname="ArchiveMenu" tagprefix="uc1" %>
	    <%@ Register src="RecentArticles.ascx" tagname="RecentArticles" tagprefix="uc1" %>
	    <%@ Register src="RecentComments.ascx" tagname="RecentComments" tagprefix="uc1" %>
	    <%@ Register src="TagBox.ascx" tagname="TagBox" tagprefix="uc1" %>
        <%@ Register src="UsersOnline.ascx" tagname="UsersOnline" tagprefix="uc1" %>
        <%@ Register src="Validators.ascx" tagname="Validators" tagprefix="uc1" %>
        <div id="anmcontent" class="anmcontent">
    <% Response.Write(Navigation()); %>
    <% Response.Write(HomeSlideshow()); %>
            <asp:Label ID="lblauthor" runat="server"></asp:Label>
            <div class="center highlight">
                <asp:Label ID="lblYear" Text="<%$ Resources:language, Year%>" Visible="false" Font-Bold="true" runat="server"></asp:Label> <asp:DropDownList ID="ddYear" runat="server" Visible="false" onselectedindexchanged="ddYear_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList> 
                <asp:Label ID="lblMonth" Text="<%$ Resources:language, Month%>" Visible="false" Font-Bold="true" runat="server"></asp:Label> <asp:DropDownList ID="ddMonth" runat="server" Visible="false" onselectedindexchanged="ddMonth_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
            </div>
            <asp:GridView ID="GridView3" runat="server" AllowPaging="True" ShowHeader="false" RowStyle-BorderStyle="None" GridLines="None" 
                AutoGenerateColumns="False" DataKeyNames="idnews" CssClass="highlightpost" Width="99%" PageSize="5">
                <PagerSettings Mode="NextPrevious" NextPageText="<%$ Resources:language, OlderEntries %>" PreviousPageText="<%$ Resources:language, NewerEntries %>" />
                <PagerStyle HorizontalAlign="Center" />
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
		                    <div class="post">
                                <h3 class="title"><asp:HyperLink ID="HLT" NavigateUrl='<%# "~/articles/" + Eval("idnews") + "/" + RNA(Eval("title").ToString()) + ".aspx" %>' runat="server"><%# Eval("Title")%></asp:HyperLink> <span class="right"><%# Edit(Eval("idnews").ToString())%></span></h3>
          	                    <div class="anmbyline"><%# PostedBy(Eval("Author").ToString(), Eval("date").ToString(), Eval("postedby").ToString())%></div>
				                    <div class="postcontent"><asp:HyperLink ID="HyperLink1" NavigateUrl='<%# "~/articles/" + Eval("idnews") + "/" + RNA(Eval("title").ToString()) + ".aspx" %>' runat="server"><%# ShowImage(Eval("image").ToString())%></asp:HyperLink><%# ViewNews(Eval("Summary").ToString(), Eval("News").ToString())%></div>
			                    <div class="meta">
			                        <span class="links"><%# ReadMore(Eval("summary").ToString(), Eval("idnews").ToString(), Eval("title").ToString(), Eval("commentcheck").ToString())%> <%# Comments(Eval("idnews").ToString(), Eval("commentcheck").ToString(), Eval("comments").ToString(), Eval("title").ToString())%></span><br />
                                    <div class="addthis_toolbox addthis_default_style "></div>                
                                </div>
	                        </div>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource5" runat="server" 
                ConnectionString="<%$ ConnectionStrings:anmcs %>" 
                SelectCommand="anm_showAllNewsByCat" SelectCommandType="StoredProcedure">
                <SelectParameters>
                    <asp:QueryStringParameter Name="idcategory" 
                        QueryStringField="category" Type="Int32" />
                    <asp:Parameter Name="highlight" Type="Boolean" DefaultValue="True" />
                    <asp:Parameter Name="sidenews" Type="Boolean" DefaultValue="False" /> 
                </SelectParameters>
            </asp:SqlDataSource>
            <asp:SqlDataSource ID="SqlDataSource6" runat="server" 
                ConnectionString="<%$ ConnectionStrings:anmcs %>" 
                SelectCommand="anm_showAllNews" SelectCommandType="StoredProcedure">
                <SelectParameters>
                    <asp:Parameter Name="highlight" Type="Boolean" DefaultValue="True" />
                    <asp:Parameter Name="sidenews" Type="Boolean" DefaultValue="False" />      
                </SelectParameters>
            </asp:SqlDataSource>
            <asp:SqlDataSource ID="SqlDataSource11" runat="server" 
                ConnectionString="<%$ ConnectionStrings:anmcs %>" 
                SelectCommand="anm_showAllNewsByCatDate" SelectCommandType="StoredProcedure">
                <SelectParameters>
                    <asp:QueryStringParameter Name="idcategory" 
                        QueryStringField="category" Type="Int32" />
                    <asp:QueryStringParameter Name="year" 
                        QueryStringField="year" Type="Int32" />
                    <asp:QueryStringParameter Name="month" 
                        QueryStringField="month" Type="Int32" />
                    <asp:Parameter Name="highlight" Type="Boolean" DefaultValue="True" />
                    <asp:Parameter Name="sidenews" Type="Boolean" DefaultValue="False" />               
                </SelectParameters>
            </asp:SqlDataSource>
            <asp:SqlDataSource ID="SqlDataSource12" runat="server" 
                ConnectionString="<%$ ConnectionStrings:anmcs %>" 
                SelectCommand="anm_showAllNewsByDate" SelectCommandType="StoredProcedure">
                <SelectParameters>
                    <asp:QueryStringParameter Name="year" 
                        QueryStringField="year" Type="Int32" />
                    <asp:QueryStringParameter Name="month" 
                        QueryStringField="month" Type="Int32" />
                    <asp:Parameter Name="highlight" Type="Boolean" DefaultValue="True" />
                    <asp:Parameter Name="sidenews" Type="Boolean" DefaultValue="False" />     
                </SelectParameters>        
            </asp:SqlDataSource>

    <% Response.Write(PagedArticles()); %>
    <asp:Literal ID="LTpagelink" Visible="true" runat="server"></asp:Literal>
    <div class="right"><asp:HyperLink ID="HLContentArchive" Text="<%$ Resources:language, ContentArchive%>" runat="server"></asp:HyperLink></div><br /><br />
        </div>
	    <div id="anmsidebar" class="anmsidebar">
			        <uc1:SearchMenu ID="SearchMenu1" runat="server" />
			        <uc1:SideMenu ID="SideMenu1" runat="server" />
			        <uc1:ArchiveMenu ID="ArchiveMenu1" runat="server" />  
            <br />
            <asp:GridView ID="GridView4" runat="server" AllowPaging="True" ShowHeader="false" RowStyle-BorderStyle="None" CssClass="highlightpost" GridLines="None" 
                AutoGenerateColumns="False" DataKeyNames="idnews" Width="100%" PageSize="5">
                <PagerSettings Mode="NextPrevious" NextPageText="<%$ Resources:language, OlderEntries %>" PreviousPageText="<%$ Resources:language, NewerEntries %>" />
                <PagerStyle HorizontalAlign="Center" />                
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                                <h3 class="title"><asp:HyperLink ID="HLT" NavigateUrl='<%# "~/articles/" + Eval("idnews") + "/" + RNA(Eval("title").ToString()) + ".aspx" %>' runat="server"><%# Eval("Title")%></asp:HyperLink> <span class="right"><%# Edit(Eval("idnews").ToString())%></span></h3>
          	                    <div class="anmbyline"><%# PostedBy(Eval("Author").ToString(), Eval("date").ToString(), Eval("postedby").ToString())%></div>
				                    <p><asp:HyperLink ID="HyperLink1" NavigateUrl='<%# "~/articles/" + Eval("idnews") + "/" + RNA(Eval("title").ToString()) + ".aspx" %>' runat="server"><%# ShowImage2(Eval("image").ToString())%></asp:HyperLink><br /><%# ViewNews(Eval("Summary").ToString(), Eval("News").ToString())%></p>
			                        <p><%# ReadMore(Eval("summary").ToString(), Eval("idnews").ToString(), Eval("title").ToString(), Eval("commentcheck").ToString())%> <%# Comments(Eval("idnews").ToString(), Eval("commentcheck").ToString(), Eval("comments").ToString(), Eval("title").ToString())%></p>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>      
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource7" runat="server" 
                ConnectionString="<%$ ConnectionStrings:anmcs %>" 
                SelectCommand="anm_showAllNewsByCat" SelectCommandType="StoredProcedure">
                <SelectParameters>
                    <asp:QueryStringParameter Name="idcategory" 
                        QueryStringField="category" Type="Int32" />
                    <asp:Parameter Name="highlight" Type="Boolean" DefaultValue="True" />
                    <asp:Parameter Name="sidenews" Type="Boolean" DefaultValue="True" />  
                </SelectParameters>
            </asp:SqlDataSource>
            <asp:SqlDataSource ID="SqlDataSource8" runat="server" 
                ConnectionString="<%$ ConnectionStrings:anmcs %>" 
                SelectCommand="anm_showAllNews" SelectCommandType="StoredProcedure">
                <SelectParameters>
                    <asp:Parameter Name="highlight" Type="Boolean" DefaultValue="True" />
                    <asp:Parameter Name="sidenews" Type="Boolean" DefaultValue="True" />      
                </SelectParameters>
            </asp:SqlDataSource>
            <asp:SqlDataSource ID="SqlDataSource13" runat="server" 
                ConnectionString="<%$ ConnectionStrings:anmcs %>" 
                SelectCommand="anm_showAllNewsByCatDate" SelectCommandType="StoredProcedure">
                <SelectParameters>
                    <asp:QueryStringParameter Name="idcategory" 
                        QueryStringField="category" Type="Int32" />
                    <asp:QueryStringParameter Name="year" 
                        QueryStringField="year" Type="Int32" />
                    <asp:QueryStringParameter Name="month" 
                        QueryStringField="month" Type="Int32" />
                    <asp:Parameter Name="highlight" Type="Boolean" DefaultValue="True" />
                    <asp:Parameter Name="sidenews" Type="Boolean" DefaultValue="True" />             
                </SelectParameters>
            </asp:SqlDataSource>
            <asp:SqlDataSource ID="SqlDataSource14" runat="server" 
                ConnectionString="<%$ ConnectionStrings:anmcs %>" 
                SelectCommand="anm_showAllNewsByDate" SelectCommandType="StoredProcedure">
                <SelectParameters>
                    <asp:QueryStringParameter Name="year" 
                        QueryStringField="year" Type="Int32" />
                    <asp:QueryStringParameter Name="month" 
                        QueryStringField="month" Type="Int32" />
                    <asp:Parameter Name="highlight" Type="Boolean" DefaultValue="True" />
                    <asp:Parameter Name="sidenews" Type="Boolean" DefaultValue="True" />  
                </SelectParameters>        
            </asp:SqlDataSource>    
            <asp:GridView ID="GridView2" runat="server" AllowPaging="True" ShowHeader="false" GridLines="None" 
                AutoGenerateColumns="False" DataKeyNames="idnews" Width="100%" PageSize="5">
                <PagerSettings Mode="NextPrevious" NextPageText="<%$ Resources:language, OlderEntries %>" PreviousPageText="<%$ Resources:language, NewerEntries %>" />
                <PagerStyle HorizontalAlign="Center" />                
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                                <h3 class="title"><asp:HyperLink ID="HLT" NavigateUrl='<%# "~/articles/" + Eval("idnews") + "/" + RNA(Eval("title").ToString()) + ".aspx" %>' runat="server"><%# Eval("Title")%></asp:HyperLink> <span class="right"><%# Edit(Eval("idnews").ToString())%></span></h3>
          	                    <div class="anmbyline"><%# PostedBy(Eval("Author").ToString(), Eval("date").ToString(), Eval("postedby").ToString())%></div>
				                    <p><asp:HyperLink ID="HyperLink1" NavigateUrl='<%# "~/articles/" + Eval("idnews") + "/" + RNA(Eval("title").ToString()) + ".aspx" %>' runat="server"><%# ShowImage2(Eval("image").ToString())%></asp:HyperLink><br /><%# ViewNews(Eval("Summary").ToString(), Eval("News").ToString())%></p>
			                        <p><%# ReadMore(Eval("summary").ToString(), Eval("idnews").ToString(), Eval("title").ToString(), Eval("commentcheck").ToString())%> <%# Comments(Eval("idnews").ToString(), Eval("commentcheck").ToString(), Eval("comments").ToString(), Eval("title").ToString())%></p>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>      
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource3" runat="server" 
                ConnectionString="<%$ ConnectionStrings:anmcs %>" 
                SelectCommand="anm_showAllNewsByCat" SelectCommandType="StoredProcedure">
                <SelectParameters>
                    <asp:QueryStringParameter Name="idcategory" 
                        QueryStringField="category" Type="Int32" />
                    <asp:Parameter Name="highlight" Type="Boolean" DefaultValue="False" />
                    <asp:Parameter Name="sidenews" Type="Boolean" DefaultValue="True" />  
                </SelectParameters>
            </asp:SqlDataSource>
            <asp:SqlDataSource ID="SqlDataSource4" runat="server" 
                ConnectionString="<%$ ConnectionStrings:anmcs %>" 
                SelectCommand="anm_showAllNews" SelectCommandType="StoredProcedure">
                <SelectParameters>
                    <asp:Parameter Name="highlight" Type="Boolean" DefaultValue="False" />
                    <asp:Parameter Name="sidenews" Type="Boolean" DefaultValue="True" />      
                </SelectParameters>
            </asp:SqlDataSource>
            <asp:SqlDataSource ID="SqlDataSource15" runat="server" 
                ConnectionString="<%$ ConnectionStrings:anmcs %>" 
                SelectCommand="anm_showAllNewsByCatDate" SelectCommandType="StoredProcedure">
                <SelectParameters>
                    <asp:QueryStringParameter Name="idcategory" 
                        QueryStringField="category" Type="Int32" />
                    <asp:QueryStringParameter Name="year" 
                        QueryStringField="year" Type="Int32" />
                    <asp:QueryStringParameter Name="month" 
                        QueryStringField="month" Type="Int32" />
                    <asp:Parameter Name="highlight" Type="Boolean" DefaultValue="False" />
                    <asp:Parameter Name="sidenews" Type="Boolean" DefaultValue="True" />
                </SelectParameters>
            </asp:SqlDataSource>
            <asp:SqlDataSource ID="SqlDataSource16" runat="server" 
                ConnectionString="<%$ ConnectionStrings:anmcs %>" 
                SelectCommand="anm_showAllNewsByDate" SelectCommandType="StoredProcedure">
                <SelectParameters>
                    <asp:QueryStringParameter Name="year" 
                        QueryStringField="year" Type="Int32" />
                    <asp:QueryStringParameter Name="month" 
                        QueryStringField="month" Type="Int32" />
                    <asp:Parameter Name="highlight" Type="Boolean" DefaultValue="False" />
                    <asp:Parameter Name="sidenews" Type="Boolean" DefaultValue="True" />                
                </SelectParameters>        
            </asp:SqlDataSource>
			        <uc1:TagBox ID="TagBox" runat="server" />
			        <uc1:RecentArticles ID="RecentArticles1" runat="server" />
			        <uc1:RecentComments ID="RecentComments1" runat="server" />
                    <uc1:UsersOnline ID="UsersOnline1" runat="server" /><br />
                    <uc1:Validators ID="Validators1" runat="server" />
	    </div>
<script src="<%=UrlJQuery()%>" type="text/javascript" charset="utf-8"></script>
<script type="text/javascript">
//<![CDATA[
    /* Slide Show */
    $(document).ready(function () {
        $('#slideShowItems div').hide().css({ position: 'absolute', width: '100%' });

        var currentSlide = -1;
        var prevSlide = null;
        var slides = $('#slideShowItems div');
        var interval = null;
        var FADE_SPEED = 500;
        var DELAY_SPEED = 10000;

        var html = '<ul id="slideShowCount">'

        for (var i = slides.length - 1; i >= 0; i--) {
            html += '<li id="slide' + i + '" class="slide"><span>' + (i + 1) + '</span></li>';
        }

        html += '</ul>';
        $('#slideShow').after(html);

        for (var i = slides.length - 1; i >= 0; i--) {
            $('#slide' + i).bind("click", { index: i }, function (event) {
                currentSlide = event.data.index;
                gotoSlide(event.data.index);
            });
        };

        if (slides.length <= 1) {
            $('.slide').hide();
        }

        nextSlide();

        function nextSlide() {

            if (currentSlide >= slides.length - 1) {
                currentSlide = 0;
            } else {
                currentSlide++
            }

            gotoSlide(currentSlide);

        }

        function gotoSlide(slideNum) {

            if (slideNum != prevSlide) {

                if (prevSlide != null) {
                    $(slides[prevSlide]).stop().hide();
                    $('#slide' + prevSlide).removeClass('selectedTab');
                }

                $('#slide' + currentSlide).addClass('selectedTab');


                $('#slide' + slideNum).addClass('selectedTab');
                $('#slide' + prevSlide).removeClass('selectedTab');

                $(slides[slideNum]).stop().slideDown(FADE_SPEED, function () {
                    $(this).css({ opacity: 1 });
                    if (jQuery.browser.msie) {
                        this.style.removeAttribute('filter');
                    }
                });

                prevSlide = currentSlide;

                if (interval != null) {
                    clearInterval(interval);
                }
                interval = setInterval(nextSlide, DELAY_SPEED);
            }
        }
    });
//]]>
</script>
<script type="text/javascript" src="http://s7.addthis.com/js/250/addthis_widget.js#pubid=allnewsmanager"></script>
