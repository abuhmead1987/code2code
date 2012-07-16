<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AdminLayout.ascx.cs" Inherits="Controls_AdminLayout" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register src="AdminMenu.ascx" tagname="AdminMenu" tagprefix="uc1" %>

    <uc1:AdminMenu ID="AdminMenu1" runat="server" />
<div style="padding:5px">
    <asp:Label ID="Label1" runat="server" Font-Size="14px" Font-Bold="true" Text="<%$ Resources:language, ChooseSiteWidth%>"></asp:Label><br />
    <asp:Literal runat="server" Text="<%$ Resources:language, asperc%>" /> <asp:CheckBox ID="CheckBox7" runat="server" oncheckedchanged="CheckBox7_CheckedChanged" Autopostback="True"/><br />
    <asp:Literal runat="server" Text="<%$ Resources:language, aspx%>" /> <asp:CheckBox ID="CheckBox8" runat="server" oncheckedchanged="CheckBox8_CheckedChanged" Autopostback="True"/><br />
            <asp:SliderExtender ID="SliderExtender1" TargetControlID="txtValue" EnableHandleAnimation="true" BoundControlID="txtWidth" Minimum="60" Maximum="100" runat="server">
            </asp:SliderExtender>
    <asp:TextBox ID="txtValue" runat="server" />
            <asp:SliderExtender ID="SliderExtender2" TargetControlID="txtValue2" EnableHandleAnimation="true" BoundControlID="txtWidth2" Minimum="810" Maximum="1600" runat="server">
            </asp:SliderExtender>
    <asp:TextBox ID="txtValue2" runat="server" />
    <asp:TextBox ID="txtWidth" Width="23px" runat="server"></asp:TextBox><asp:Label ID="Label2" runat="server" Text="%"></asp:Label><br />
    <asp:TextBox ID="txtWidth2" Width="30px" runat="server"></asp:TextBox><asp:Label ID="Label3" runat="server" Text="px"></asp:Label><br />
    <asp:Label ID="Label4" runat="server" Font-Size="14px" Font-Bold="true" Text="<%$ Resources:language, ChooseTemplate %>" ></asp:Label> <asp:DropDownList ID="template" runat="server" 
            DataSourceID="SqlDataSource1" DataTextField="name" DataValueField="Template" >
              </asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:anmcs %>" 
            SelectCommand="anm_getTemplates" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
        <br /><br />
    <asp:Label ID="Label5" runat="server" Font-Size="14px" Font-Bold="true" Text="<%$ Resources:language, ChooseBGColor %>"></asp:Label> 
       <asp:textbox id="txtBGC" runat="server" columns="7" maxlength="7" />
       <asp:imagebutton id="ImageButton1" runat="server" imageurl="~/images/icon_colorpicker.gif" />
       <asp:colorpickerextender id="cpe" runat="server"
             targetcontrolid="txtBGC"
             samplecontrolid="ImageButton1"
             popupbuttonid="ImageButton1" />
    <br /><br />
    <asp:Label Visible="false" ID="Label6" runat="server" Font-Size="14px" Font-Bold="true" Text="<%$ Resources:language, ChooseHeadBG %>"></asp:Label>
       <asp:textbox Visible="false" id="txtHBGC" runat="server" columns="7" maxlength="7" />
       <asp:imagebutton Visible="false" id="ImageButton2" runat="server" imageurl="~/images/icon_colorpicker.gif" />
       <asp:colorpickerextender id="Colorpickerextender1" runat="server"
             targetcontrolid="txtHBGC"
             samplecontrolid="ImageButton2"
             popupbuttonid="ImageButton2" />
    <br /><br />

    <asp:Label ID="Label7" runat="server" Font-Size="14px" Font-Bold="true" Text="<%$ Resources:language, ChooseArtImageWidth%>"></asp:Label><br />
            <asp:SliderExtender ID="SliderExtender3" TargetControlID="txtValue3" EnableHandleAnimation="true" BoundControlID="txtWidth3" Minimum="10" Maximum="900" runat="server">
            </asp:SliderExtender>
    <asp:TextBox ID="txtValue3" runat="server" />
    <asp:TextBox ID="txtWidth3" Width="23px" runat="server"></asp:TextBox><asp:Label ID="Label8" runat="server" Text="px"></asp:Label><br />

<asp:Button ID="UpdateSettings" runat="server" Text="<%$ Resources:language, Update %>" 
        onclick="UpdateSettings_Click" /><br />
<asp:Label ID="lblerror" runat="server" ForeColor="Red" Visible="false"></asp:Label>
</div>