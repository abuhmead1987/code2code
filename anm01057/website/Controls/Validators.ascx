<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Validators.ascx.cs" Inherits="Controls_Validators" %>
              <asp:Panel ID="PnlValidators" Visible="false" HorizontalAlign="Center" runat="server">
                  <asp:HyperLink ID="HLvalidHtml" NavigateUrl="http://validator.w3.org/check?uri=referer" runat="server">
                      <asp:Image ID="ImgHtml" ImageUrl="~/images/valid-xhtml10.png" AlternateText="Valid XHTML 1.0 Transitional" BorderWidth="0" Width="60" runat="server" />
                  </asp:HyperLink>                
                  <asp:HyperLink ID="HLvalidCSS" NavigateUrl="http://jigsaw.w3.org/css-validator/check/referer" runat="server">
                      <asp:Image ID="ImgCSS" ImageUrl="~/images/vcss.gif" AlternateText="Valid CSS" BorderWidth="0" Width="60" runat="server" />
                  </asp:HyperLink>
                <asp:HyperLink ID="Hlvalidrss" runat="server">
                    <asp:Image ID="ImgRss" ImageUrl="~/images/valid-rss-rogers.png" AlternateText="[Valid RSS]" BorderWidth="0" Width="60" runat="server" /></asp:HyperLink>                
              </asp:Panel>