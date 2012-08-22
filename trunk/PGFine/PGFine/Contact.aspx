<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.Master" AutoEventWireup="true"
    CodeBehind="Contact.aspx.cs" Inherits="PGFine.Contact" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- START PRIMARY SECTION -->
    <div id="primary" class="inner group">
        <div class="layout-sidebar-right group">
            <!-- START CONTENT -->
            <div id="content" role="main" class="group">
                <h2>
                    Get in Touch</h2>
                <div id="post-73" class="post-73 page type-page status-publish hentry group">
                    <div id="contact-form-contact-page" class="contact-form">
                        <div class="usermessagea">
                        </div>                       
                            <ul>
                                <li class="text-field">
                                    <label for="name-contact-page">
                                        <span class="label">Name</span>
                                    </label>
                                    <input type="text" name="name" id="name-contact-page" class="required" value="" />
                                    <div class="msg-error">
                                    </div>
                                </li>
                                <li class="text-field">
                                    <label for="email-contact-page">
                                        <span class="label">Email</span>
                                    </label>
                                    <input type="text" name="email" id="email-contact-page" class="required email-validate"
                                        value="" />
                                    <div class="msg-error">
                                    </div>
                                </li>
                                <li class="textarea-field">
                                    <label for="message-contact-page">
                                        <span class="label">Message</span>
                                    </label>
                                    <textarea name="message" id="message-contact-page" rows="8" cols="30" class="required"></textarea>
                                    <div class="msg-error">
                                    </div>
                                </li>
                                <li class="submit-button">
                                    <input type="hidden" name="action" value="sendmail" id="action" />
                                    <input type="submit" name="sendemail" value="send message" class="sendmail alignright" />
                                </li>
                            </ul>                       
                    </div>
                    <script type="text/javascript">
                        var error_messages = {
                            name: "Insert the name",
                            email: "Insert a valid email",
                            message: "Insert a message"
                        };
                    </script>
                </div>
                <div id="comments">
                    <!--<p class="nocomments">&nbsp;</p>-->
                </div>
                <!-- #comments -->
            </div>
            <!-- END CONTENT -->
            <!-- START SIDEBAR -->
            <div id="sidebar" class="group">
                <div id="text-4" class="widget-1 widget-first widget widget_text">
                    <h3>
                        Customer support</h3>
                    <div class="textwidget">
                        <p>
                            Sed velit arcu, lobortis sit amet condimentum vitae, congue sit amet est. Donec
                            pharetra quam a odio porttitor lobortis in in massa. Phasellus viverra placerat
                            nunc eget tempor.<br />
                            <br />
                        </p>
                    </div>
                </div>
                <div id="text-image-5" class="widget-2 widget-last widget text-image">
                    <h3>
                        Gift Card</h3>
                    <div class="text-image" style="text-align: left">
                        <img src="images/giftcard2.jpg" alt="Gift Card" /></div>
                    <p>
                        Mauris porta ligula sed ante imperdiet quis dignissim purus tempus. <strong>Aenean massa
                            erat</strong>, vehicula et facilisis malesuada, <a href="#">ultrices eget</a>
                        augue.
                    </p>
                </div>
            </div>
            <!-- END SIDEBAR -->
        </div>
        <!-- START EXTRA CONTENT -->
        <!-- END EXTRA CONTENT -->
    </div>
    <!-- END PRIMARY SECTION -->

</asp:Content>
