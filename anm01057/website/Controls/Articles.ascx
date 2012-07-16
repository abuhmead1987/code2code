<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Articles.ascx.cs" Inherits="Controls_Articles" %>
<%@ Register Src="SearchMenu.ascx" TagName="SearchMenu" TagPrefix="uc1" %>
<%@ Register Src="SideMenu.ascx" TagName="SideMenu" TagPrefix="uc1" %>
<%@ Register Src="ArchiveMenu.ascx" TagName="ArchiveMenu" TagPrefix="uc1" %>
<%@ Register Src="RecentArticles.ascx" TagName="RecentArticles" TagPrefix="uc1" %>
<%@ Register Src="RecentComments.ascx" TagName="RecentComments" TagPrefix="uc1" %>
<%@ Register Src="TagBox.ascx" TagName="TagBox" TagPrefix="uc1" %>
<%@ Register Src="UsersOnline.ascx" TagName="UsersOnline" TagPrefix="uc1" %>
<%@ Register Src="Validators.ascx" TagName="Validators" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%@ Import Namespace="anm_utility" %>

<div id="anmcontent" class="anmcontent">
    <% Response.Write(Navigation()); %>
    <asp:GridView ID="GridView1" DataSourceID="SqlDataSource1" runat="server" AllowPaging="False"
        ShowHeader="false" BorderStyle="None" RowStyle-BorderStyle="None" RowStyle-BorderColor="#cccccc"
        AutoGenerateColumns="False" DataKeyNames="idnews" BorderWidth="0" Width="100%"
        GridLines="None">
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <div class="post">
                        <h1 class="title">
                            <%# Eval("Title")%>
                            <span class="right">
                                <%# Edit()%></span></h1>
                        <div class="anmbyline">
                            <%# PostedBy(Eval("Author").ToString(), Eval("date").ToString(), Eval("postedby").ToString())%></div>
                        <div class="postcontent">
                            <asp:HyperLink ID="HLimage" NavigateUrl='<%# "~/images/full_" + Eval("image") %>'
                                Visible='<%# ViewImage(Eval("image").ToString())%>' Target="_blank" runat="server"><%# ShowImage(Eval("image").ToString())%></asp:HyperLink><%# Eval("News").ToString() %></div>
                        
                        <span>
                        <%# BuyNow(Eval("idnews").ToString()) %>
                        </span>

                        <div class="meta">
                            <%# TagNews(Eval("tags").ToString())%>
                            ||
                            <asp:Literal runat="server" Text="<%$ Resources:language, Category%>" />:
                            <%# Category(Eval("idcategory").ToString(), Eval("date").ToString())%>
                            ||<br />
                            <span class="links">
                                <%# Comments(Eval("idnews").ToString(), Eval("commentcheck").ToString(), Eval("comments").ToString(), Eval("title").ToString())%></span>
                            <%# Description(Eval("summary").ToString(), Eval("news").ToString(), Eval("title").ToString())%>
                            <%# ViewArticle(Eval("published").ToString(), Eval("date").ToString())%>
                            <%# SetleaveClink(Eval("idnews").ToString(), Eval("title").ToString())%>
                            <br />
                            <div class="addthis_toolbox addthis_default_style ">
                                <a class="addthis_button_google_plusone"></a><a href="http://www.addthis.com/bookmark.php?v=250&amp;pubid=allnewsmanager"
                                    class="addthis_button_compact">
                                    <asp:Literal ID="litaddthis" runat="server" Text="<%$ Resources:language, Share%>" /></a>
                            </div>
                        </div>
                    </div>
                    <%# SetRelatedContent(Eval("idcategory").ToString(), Eval("title").ToString(), Eval("idnews").ToString())%>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <div class="right">
        <asp:HyperLink ID="HLContentArchive" Text="<%$ Resources:language, ContentArchive%>"
            runat="server"></asp:HyperLink></div>
    <br />
    <br />
    <a name="comments"></a>
    <asp:UpdatePanel ID="PnlComments" Visible="false" runat="server">
        <ContentTemplate>
            <asp:UpdateProgress runat="server" ID="uProgress">
                <ProgressTemplate>
                    <asp:Image ID="imgLoader" ImageUrl="~/images/ajax-loader.gif" alt="Please Wait..."
                        runat="server" />
                </ProgressTemplate>
            </asp:UpdateProgress>
            <asp:HyperLink ID="HLAdminComm" Font-Bold="true" runat="server"></asp:HyperLink>
            <asp:HyperLink ID="HLleaveComment" Text="<%$ Resources:language, Leavecomment%>"
                runat="server"></asp:HyperLink>
            <asp:GridView ID="GridView2" runat="server" GridLines="None" AutoGenerateColumns="False"
                Width="99%" CssClass="BoxComments" AlternatingRowStyle-CssClass="commentpostalt"
                RowStyle-CssClass="commentpost" DataSourceID="SqlDataSource2" DataKeyNames="idcomment"
                CellPadding="5">
                <Columns>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:Literal runat="server" Text="<%$ Resources:language, Comments%>" />:</HeaderTemplate>
                        <ItemTemplate>
                            <div class="commentheader">
                                <a name='<%# "comment" +(Eval("idcomment").ToString()) %>'></a>
                                <div class="right">
                                    <asp:HyperLink ID="HLreport" NavigateUrl='<%# "~/default.aspx?p=report&amp;idc=" + Eval("idcomment") + "&amp;idn=" + Eval("idnews") %>'
                                        Text="<%$ Resources:language, report%>" runat="server"></asp:HyperLink>
                                    -
                                    <asp:HyperLink ID="HyperLink1" NavigateUrl='<%# GetCommentUrl(Eval("idcomment").ToString())%>'
                                        Text="#" rel='nofollow' runat="server"></asp:HyperLink><br />
                                    <asp:LinkButton ID="LinkButton2" OnClientClick='<%# string.Format("return Quote(\"{0}\", \"{1}\");", Eval("comment").ToString(), Eval("commentator")) %>'
                                        Visible='<%# CheckBBCode() %>' Text="<%$ Resources:language, Quote%>" runat="server"></asp:LinkButton></div>
                                <div class="right">
                                    <asp:LinkButton ID="LinkButton1" CommandArgument='<%# Eval("idcomment") + "," + Eval("idnews") + "," + Eval("approved") %>'
                                        OnClientClick="return confirm('Are you sure to delete this comment ?')" Text="<%$ Resources:language, Delete %>"
                                        Visible='<%# IsAdmin() %>' Font-Bold="true" runat="server" OnCommand="DeleteComment_Command" />
                                    <%# EditComment(Eval("idcomment").ToString(),Eval("idnews").ToString())%></div>
                                <div class="left">
                                    <asp:Image ID="Image1" ImageUrl='<%# GetAvatar(Eval("commentator").ToString())%>'
                                        AlternateText="User Avatar" runat="server" />
                                </div>
                                <div>
                                    &nbsp;<i><asp:Literal ID="Literal2" runat="server" Text="<%$ Resources:language, by%>" /></i>
                                    <%# Eval("commentator").ToString()%></div>
                                <div>
                                    &nbsp;<i><%# ViewDate(Eval("date").ToString())%></i></div>
                            </div>
                            <div class="commenttext">
                                <asp:Literal ID="commenttext" Text='<%# Eval("comment")%>' runat="server"></asp:Literal>
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <EmptyDataTemplate>
                    <%# NoComments()%>
                </EmptyDataTemplate>
                <HeaderStyle CssClass="post_title" />
            </asp:GridView>
            <asp:Literal ID="LTpagelink" runat="server"></asp:Literal>
            <div class="right">
                <p>
                    <asp:HyperLink ID="HLrssComments" runat="server">
                        <asp:Image ID="imgRssIcon" AlternateText="rss icon" runat="server" /></asp:HyperLink>
                    <asp:HyperLink ID="HLsubscribeCom" runat="server"></asp:HyperLink>
                </p>
            </div>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:anmcs %>"
                SelectCommand="anm_getNewsById" SelectCommandType="StoredProcedure">
                <SelectParameters>
                    <asp:Parameter Name="idnews" Type="Int32" />
                </SelectParameters>
            </asp:SqlDataSource>
            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:anmcs %>"
                SelectCommand="anm_GetPCommentsByIdnPaged" SelectCommandType="StoredProcedure">
                <SelectParameters>
                    <asp:Parameter Name="idnews" Type="Int32" />
                    <asp:Parameter Name="startRowIndex" Type="Int32" />
                    <asp:Parameter Name="maximumRows" Type="Int32" />
                </SelectParameters>
            </asp:SqlDataSource>
        </ContentTemplate>
    </asp:UpdatePanel>
    <br />
    <a name="response"></a>
    <asp:Panel ID="PnlSendComment" Visible="false" CssClass="SendComment" runat="server">
        <asp:Label ID="Literal1" Font-Bold="true" runat="server" Text="<%$ Resources:language, Leavecomment%>" />:<hr />
        <textarea id="commentarea" name="commentarea" style="width: 94%; height: 80px;" rows="10"
            cols="20" onkeydown="limitText(commentarea,countdown,2000);" onkeyup="limitText(commentarea,countdown,2000);"></textarea>
        <script src="<%=UrlJQuery()%>" type="text/javascript">
        </script>
        <script src="<%=UrlJqBBCode()%>" type='text/javascript'></script>
        <asp:Panel ID="PanelBBcode" runat="server">
            <script type="text/javascript">
                $(document).ready(function () {
                    $("#commentarea").bbcode({ tag_bold: true, tag_italic: true, tag_underline: true, tag_link: true, tag_image: true, button_image: true });
                });
            </script>
        </asp:Panel>
        <script language="javascript" type="text/javascript">
                        //<![CDATA[
            function limitText(limitField, limitCount, limitNum) {
                if (limitField.value.length > limitNum) {
                    limitField.value = limitField.value.substring(0, limitNum);
                } else {
                    limitCount.value = limitNum - limitField.value.length;
                }
            }
            function Encode() {
                var value = (document.getElementById('commentarea').value);
                value = value.replace(/&/g, '&amp;');
                value = value.replace(/</g, '&lt;');
                value = value.replace(/>/g, '&gt;');
                document.getElementById('commentarea').value = value;
            }
            function Quote(text, author) {
                if (navigator.appName == 'Microsoft Internet Explorer') {
                    $('#commentarea').html($('#commentarea').val() + '[QUOTE=' + author + ']' + stripquote(text) + '[/QUOTE]<br />');
                }
                else {
                    $('#commentarea').html($('#commentarea').val() + '[QUOTE=' + author + ']' + stripquote(text) + '[/QUOTE]\n');
                }
                window.location.hash = "response";
            }
            function stripquote(txt) {
                txt = txt.replace(/<blockquote(\s[^>]*)?>.*?<\/blockquote>/ig, "");
                return txt;
            }
                        //]]>
        </script>
        <br />
        <input type="text" name="countdown" size="3" value="2000" />
        <asp:Label ID="lblchrleft" runat="server"></asp:Label><br />
        <asp:Label ID="lblerror" ForeColor="Red" runat="server" Visible="false"></asp:Label>
        <asp:Panel ID="Panelcomm" Visible="false" ForeColor="Red" runat="server">
            <div class="highlight">
                <asp:Literal runat="server" Text="<%$ Resources:language, Sendcomment%>" />
                <asp:HyperLink ID="HyperLink4" Text="<%$ Resources:language, Register%>" runat="server"></asp:HyperLink>
                <asp:Literal runat="server" Text="<%$ Resources:language, and%>" />
                <asp:HyperLink ID="HyperLink5" Text="<%$ Resources:language, login%>" runat="server"></asp:HyperLink>.</div>
        </asp:Panel>
        <asp:UpdatePanel ID="UpdatePanel1" Visible="false" runat="server">
            <ContentTemplate>
                <asp:Image ID="imgcaptcha" AlternateText="Captcha" runat="server" /><br />
                <asp:LinkButton ID="LBcaptcha" runat="server" Text="<%$ Resources:language, Generateimage%>"
                    OnClick="LBcaptcha_Click"></asp:LinkButton>
            </ContentTemplate>
        </asp:UpdatePanel>
        <br />
        <asp:Label ID="lblcaptcha" runat="server" Visible="false" Text="<%$ Resources:language, Typeletters%>"></asp:Label>
        <asp:TextBox ID="txtcaptcha" Visible="false" Width="50px" runat="server"></asp:TextBox>
        <asp:Label ID="errorcaptcha" runat="server" ForeColor="Red" Text="<%$ Resources:language, Typeletterserror%>"
            Visible="false"></asp:Label><br />
        <asp:Button ID="btnSendC" runat="server" Text="<%$ Resources:language, SendComm%>"
            Height="23px" Width="117px" OnClick="SendComment" OnClientClick="Encode()" /><br />
        <br />
    </asp:Panel>
</div>
<div id="anmsidebar" class="anmsidebar">
    <uc1:SearchMenu ID="SearchMenu1" runat="server" />
    <uc1:SideMenu ID="SideMenu1" runat="server" />
    <uc1:ArchiveMenu ID="ArchiveMenu1" runat="server" />
    <uc1:TagBox ID="TagBox" runat="server" />
    <uc1:RecentArticles ID="RecentArticles1" runat="server" />
    <uc1:RecentComments ID="RecentComments1" runat="server" />
    <uc1:UsersOnline ID="UsersOnline1" runat="server" />
    <br />
    <uc1:Validators ID="Validators1" runat="server" />
    <script type="text/javascript" src="http://s7.addthis.com/js/250/addthis_widget.js#pubid=allnewsmanager"></script>
    <script type="text/javascript" src="https://apis.google.com/js/plusone.js"></script>
</div>
