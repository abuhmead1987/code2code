<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InformationCustomer.aspx.cs"
    Inherits="PGFine.InformationCustomer" MasterPageFile="~/MasterPageUser/MasterPageUser.Master"
    EnableEventValidation="false" %>

<%@ Register Src="Ctrl/CtrlMainBanner.ascx" TagName="CtrlMainBanner" TagPrefix="uc1" %>
<%@ Register Src="Ctrl/CtrlRandomProduct.ascx" TagName="CtrlRandomProduct" TagPrefix="uc2" %>
<%@ Register Src="Ctrl/CtrlCardList.ascx" TagName="CtrlCardList" TagPrefix="uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script type="text/javascript">       
  function validateEmail(oSrc, args){     
    var isHasFile = false;          
    var txtEmail = $get('<%=this.txtEmailThanh.ClientID%>');   
    if(txtEmail !=null)
    {         
        isHasFile = txtEmail.value.length > 0 && txtEmail.value.length < 50;
    }
    args.IsValid = isHasFile;
  }    
     
  function validateEmailNhan(oSrc, args){     
    var isHasFile = false;          
    var txtEmail = $get('<%=this.txtEmailNhan.ClientID%>');   
    if(txtEmail !=null)
    {         
        isHasFile = txtEmail.value.length > 0 && txtEmail.value.length < 50;
    }
    args.IsValid = isHasFile;
  }    
    </script>

    <asp:Label ID="_errorLabel" runat="server" Visible="false"></asp:Label>
    <uc1:CtrlMainBanner ID="CtrlMainBanner1" runat="server" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="Pageging">
        <div runat="server" id="BannerBreakrum">
            <asp:Label ID="lbBreakrum" runat="server" Text="sản phẩm đã chọn" CssClass="Breakrum"></asp:Label>
        </div>
    </div>
    <div class="ListProduct">
        <div class="DivBgTopGioHang">
            <asp:Image ID="Image2" runat="server" ImageUrl="~/Images/bgTopThongTinNguyen.gif"
                Width="954" Height="30" />
        </div>
        <uc3:CtrlCardList ID="CtrlCardList1" runat="server" />
        <table cellpadding="0" cellspacing="0" width="1061px">
            <tr>
                <td width="50%" align="left">
                    <div style="float: left; width: 425px; margin: 10px 0px 0px 15px; height: 450px;">
                        <div class="InformationCustomer">
                            <div class="TitleCaptionInput">
                                <asp:Literal ID="ltrInformationC" runat="server"></asp:Literal><%--thông tin người thanh toán--%></div>
                        </div>
                        <div style="float: left; height: 30px; padding: 5px 0px 0px 0px;">
                            <div style="float: left; height: 30px; padding: 8px 0px 0px 30px; width: 100px;">
                                <div style="float: left; color: Red; height: 30px; font-size: 11px;">
                                    *</div>
                                <div style="float: left; color: #30302F; font-size: 12px; font-family: Arial; height: 30px;
                                    padding: 0px 0px 0px 5px; width: 80px;">
                                    <asp:Literal ID="ltrAlias" runat="server"></asp:Literal><%--Danh xưng:--%></div>
                            </div>
                            <div style="float: left; color: #30302F; font-size: 12px; font-family: Arial; padding-top: 5px;
                                height: 30px;">
                                <asp:TextBox ID="txtDanhXungThanhToan" runat="server" ValidationGroup="CheckIn" CssClass="textboxI"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="CheckIn"
                                    ControlToValidate="txtDanhXungThanhToan" CssClass="ValidateMessEmail" runat="server"
                                    ErrorMessage="**" Display="Dynamic">
                                </asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div style="float: left; height: 30px; padding: 5px 0px 0px 0px;">
                            <div style="float: left; height: 30px; padding: 8px 0px 0px 30px; width: 100px;">
                                <div style="float: left; color: Red; height: 30px; font-size: 11px;">
                                    *</div>
                                <div style="float: left; color: #30302F; font-size: 12px; font-family: Arial; height: 30px;
                                    padding: 0px 0px 0px 5px; width: 80px;">
                                    <%--Họ và tên:--%><asp:Literal ID="ltrName" runat="server"></asp:Literal></div>
                            </div>
                            <div style="float: left; color: #30302F; font-size: 12px; font-family: Arial; padding-top: 5px;
                                height: 30px;">
                                <asp:TextBox ID="txtNameThanhToan" runat="server" ValidationGroup="CheckIn" CssClass="textboxI"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="CheckIn"
                                    ControlToValidate="txtNameThanhToan" CssClass="ValidateMessEmail" runat="server"
                                    ErrorMessage="**" Display="Dynamic">
                                </asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div style="float: left; height: 30px; padding: 5px 0px 0px 0px;">
                            <div style="float: left; height: 30px; padding: 8px 0px 0px 30px; width: 100px;">
                                <div style="float: left; color: Red; height: 30px; font-size: 11px;">
                                    *</div>
                                <div style="float: left; color: #30302F; font-size: 12px; font-family: Arial; height: 30px;
                                    padding: 0px 0px 0px 5px; width: 80px;">
                                   <%-- Quân/Huyện:--%><asp:Literal ID="ltrDics" runat="server"></asp:Literal></div>
                            </div>
                            <div style="float: left; color: #30302F; font-size: 12px; font-family: Arial; padding-top: 5px;
                                height: 30px;">
                                <asp:TextBox ID="txtQuanHuyenThanhToan" runat="server" ValidationGroup="CheckIn" CssClass="textboxI"></asp:TextBox>
                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ValidationGroup="CheckIn"
                                    ControlToValidate="txtQuanHuyenThanhToan" CssClass="ValidateMessEmail" runat="server"
                                    ErrorMessage="**" Display="Dynamic">
                                </asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div style="float: left; height: 30px; padding: 5px 0px 0px 0px;">
                            <div style="float: left; height: 30px; padding: 8px 0px 0px 30px; width: 100px;">
                                <div style="float: left; color: Red; height: 30px; font-size: 11px;">
                                    *</div>
                                <div style="float: left; color: #30302F; font-size: 12px; font-family: Arial; height: 30px;
                                    padding: 0px 0px 0px 5px; width: 80px;">
                                    <%--Địa chỉ:--%><asp:Literal ID="ltrAddress" runat="server"></asp:Literal></div>
                            </div>
                            <div style="float: left; color: #30302F; font-size: 12px; font-family: Arial; padding-top: 5px;
                                height: 30px;">
                                <asp:TextBox ID="txtAddressThanhToan" runat="server" ValidationGroup="CheckIn" CssClass="textboxI"></asp:TextBox>
                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ValidationGroup="CheckIn"
                                    ControlToValidate="txtAddressThanhToan" CssClass="ValidateMessEmail" runat="server"
                                    ErrorMessage="**" Display="Dynamic">
                                </asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div style="float: left; height: 30px; padding: 5px 0px 0px 0px;">
                            <div style="float: left; height: 30px; padding: 8px 0px 0px 30px; width: 100px;">
                                <div style="float: left; color: Red; height: 30px; font-size: 11px;">
                                    *</div>
                                <div style="float: left; color: #30302F; font-size: 12px; font-family: Arial; height: 30px;
                                    padding: 0px 0px 0px 5px; width: 80px;">
                                    <%--Điện thoại:--%><asp:Literal ID="ltrPhone" runat="server"></asp:Literal></div>
                            </div>
                            <div style="float: left; color: #30302F; font-size: 12px; font-family: Arial; padding-top: 5px;
                                height: 30px;">
                                <asp:TextBox ID="txtPhoneThanhToan" ValidationGroup="CheckIn" runat="server" CssClass="textboxI"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ValidationGroup="CheckIn"
                                    ControlToValidate="txtPhoneThanhToan" CssClass="ValidateMessEmail" runat="server"
                                    ErrorMessage="**" Display="Dynamic">
                                </asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div style="float: left; height: 30px; padding: 5px 0px 0px 0px;">
                            <div style="float: left; height: 30px; padding: 8px 0px 0px 30px; width: 100px;">
                                <div style="float: left; color: Red; height: 30px; font-size: 11px;">
                                    *</div>
                                <div style="float: left; color: #30302F; font-size: 12px; font-family: Arial; height: 30px;
                                    padding: 0px 0px 0px 5px; width: 80px;">
                                    <%--ĐTDĐ:--%><asp:Literal ID="ltrTel" runat="server"></asp:Literal></div>
                            </div>
                            <div style="float: left; color: #30302F; font-size: 12px; font-family: Arial; padding-top: 5px;
                                height: 30px;">
                                <asp:TextBox ID="txtTelThanhToan" runat="server" ValidationGroup="CheckIn" CssClass="textboxI"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ValidationGroup="CheckIn"
                                    ControlToValidate="txtPhoneThanhToan" CssClass="ValidateMessEmail" runat="server"
                                    ErrorMessage="**" Display="Dynamic">
                                </asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div style="float: left; height: 30px; padding: 5px 0px 0px 0px; width: 100%;">
                            <div style="float: left; height: 30px; padding: 8px 0px 0px 30px; width: 100px;">
                                <div style="float: left; color: Red; height: 30px; font-size: 11px;">
                                    *</div>
                                <div style="float: left; color: #30302F; font-size: 12px; font-family: Arial; height: 30px;
                                    padding: 0px 0px 0px 5px;">
                                    Email:</div>
                            </div>
                            <div style="float: left; color: #30302F; font-size: 12px; font-family: Arial; padding-top: 5px;
                                height: 30px;">
                                <asp:TextBox ID="txtEmailThanh" runat="server" CssClass="textboxI" ValidationGroup="CheckIn"></asp:TextBox>
                                <asp:CustomValidator ID="CustomValidator5" runat="server" ErrorMessage="**" Display="Dynamic"
                                    CssClass="ValidateMessEmail" ValidationGroup="CheckIn" ClientValidationFunction="validateEmail"></asp:CustomValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmailThanh"
                                    ValidationExpression="[\w]+@[\w]+\.(com|net|org|co\.th|go\.th|ac\.th|or\.th|go\.th)"
                                    Display="Dynamic" ErrorMessage="**" ValidationGroup="CheckIn" CssClass="ValidateMessEmail"></asp:RegularExpressionValidator>
                            </div>
                        </div>
                        <div style="float: left; height: 30px; padding: 5px 0px 0px 0px;">
                            <div style="float: left; height: 30px; padding: 8px 0px 0px 30px; width: 100px;">
                                <div style="float: left; color: Red; height: 30px; font-size: 11px;">
                                    *</div>
                                <div style="float: left; color: #30302F; font-size: 12px; font-family: Arial; height: 30px;
                                    padding: 0px 0px 0px 5px; width: 80px;">
                                    <%--Ghi chú:--%><asp:Literal ID="ltrNote" runat="server"></asp:Literal></div>
                            </div>
                            <div style="float: left; color: #30302F; font-size: 12px; font-family: Arial; padding-top: 5px;
                                height: 30px;">
                                <asp:TextBox ID="txtDescriptionThanhToan" runat="server" ValidationGroup="CheckIn" TextMode="MultiLine" CssClass="textboxMode"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" ValidationGroup="CheckIn"
                                    ControlToValidate="txtDescriptionThanhToan" CssClass="ValidateMessEmail" runat="server"
                                    ErrorMessage="**" Display="Dynamic">
                                </asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>
                </td>
                <td width="50%" align="right">
                    <div style="float: left; width: 425px; margin: 10px 0px 0px 15px; height: 450px;">
                        <div class="InformationCustomer">
                            <div class="TitleCaptionInput">
                                <%--thông tin người nhận--%><asp:Literal ID="ltrInformationR" runat="server"></asp:Literal></div>
                            <div style="float: right; margin: 4px 5px 0px 0px;">
                                <asp:CheckBox ID="chkLike" runat="server" AutoPostBack="True" OnCheckedChanged="chkLike_CheckedChanged" />
                            </div>
                            <div style="float: right; color: #747472; font-size: 12px; font-family: Arial; margin: 7px 5px 0px 0px;">
                                <%--Giống địa chỉ thanh toán--%><asp:Literal ID="ltrLike" runat="server"></asp:Literal>
                            </div>
                        </div>
                        <div style="float: left; height: 30px; padding: 5px 0px 0px 0px;">
                            <div style="float: left; height: 30px; padding: 8px 0px 0px 30px; width: 100px;">
                                <div style="float: left; color: Red; height: 30px; font-size: 11px;">
                                    *</div>
                                <div style="float: left; color: #30302F; font-size: 12px; font-family: Arial; height: 30px;
                                    padding: 0px 0px 0px 5px; width: 80px; text-align: left;">
                                    <%--Danh xưng:--%><asp:Literal ID="ltrAlias1" runat="server"></asp:Literal></div>
                            </div>
                            <div style="float: left; color: #30302F; font-size: 12px; font-family: Arial; padding-top: 5px;
                                height: 30px;">
                                <asp:TextBox ID="txtDanhxungNhan" runat="server" ValidationGroup="CheckIn" CssClass="textboxI"></asp:TextBox>
                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator8" ValidationGroup="CheckIn"
                                    ControlToValidate="txtDanhxungNhan" CssClass="ValidateMessEmail" runat="server"
                                    ErrorMessage="**" Display="Dynamic">
                                </asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div style="float: left; height: 30px; padding: 5px 0px 0px 0px;">
                            <div style="float: left; height: 30px; padding: 8px 0px 0px 30px; width: 100px;">
                                <div style="float: left; color: Red; height: 30px; font-size: 11px;">
                                    *</div>
                                <div style="float: left; color: #30302F; font-size: 12px; font-family: Arial; height: 30px;
                                    padding: 0px 0px 0px 5px; width: 80px; text-align: left;">
                                    <%--Họ và tên:--%><asp:Literal ID="ltrName1" runat="server"></asp:Literal></div>
                            </div>
                            <div style="float: left; color: #30302F; font-size: 12px; font-family: Arial; padding-top: 5px;
                                height: 30px;">
                                <asp:TextBox ID="txtNameNhan" runat="server" ValidationGroup="CheckIn" CssClass="textboxI"></asp:TextBox>
                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator9" ValidationGroup="CheckIn"
                                    ControlToValidate="txtNameNhan" CssClass="ValidateMessEmail" runat="server"
                                    ErrorMessage="**" Display="Dynamic">
                                </asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div style="float: left; height: 30px; padding: 5px 0px 0px 0px;">
                            <div style="float: left; height: 30px; padding: 8px 0px 0px 30px; width: 100px;">
                                <div style="float: left; color: Red; height: 30px; font-size: 11px;">
                                    *</div>
                                <div style="float: left; color: #30302F; font-size: 12px; font-family: Arial; height: 30px;
                                    padding: 0px 0px 0px 5px; width: 80px; text-align: left;">
                                    <%--Quân/Huyện:--%><asp:Literal ID="ltrDics1" runat="server"></asp:Literal></div>
                            </div>
                            <div style="float: left; color: #30302F; font-size: 12px; font-family: Arial; padding-top: 5px;
                                height: 30px;">
                                <asp:TextBox ID="txtDisctNhan" runat="server" ValidationGroup="CheckIn" CssClass="textboxI"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" ValidationGroup="CheckIn"
                                    ControlToValidate="txtDisctNhan" CssClass="ValidateMessEmail" runat="server"
                                    ErrorMessage="**" Display="Dynamic">
                                </asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div style="float: left; height: 30px; padding: 5px 0px 0px 0px;">
                            <div style="float: left; height: 30px; padding: 8px 0px 0px 30px; width: 100px;">
                                <div style="float: left; color: Red; height: 30px; font-size: 11px;">
                                    *</div>
                                <div style="float: left; color: #30302F; font-size: 12px; font-family: Arial; height: 30px;
                                    padding: 0px 0px 0px 5px; width: 80px; text-align: left;">
                                    <%--Địa chỉ:--%><asp:Literal ID="ltrAddress1" runat="server"></asp:Literal></div>
                            </div>
                            <div style="float: left; color: #30302F; font-size: 12px; font-family: Arial; padding-top: 5px;
                                height: 30px;">
                                <asp:TextBox ID="txtAddressNhan" runat="server" ValidationGroup="CheckIn" CssClass="textboxI"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" ValidationGroup="CheckIn"
                                    ControlToValidate="txtAddressNhan" CssClass="ValidateMessEmail" runat="server"
                                    ErrorMessage="**" Display="Dynamic">
                                </asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div style="float: left; height: 30px; padding: 5px 0px 0px 0px;">
                            <div style="float: left; height: 30px; padding: 8px 0px 0px 30px; width: 100px;">
                                <div style="float: left; color: Red; height: 30px; font-size: 11px;">
                                    *</div>
                                <div style="float: left; color: #30302F; font-size: 12px; font-family: Arial; height: 30px;
                                    padding: 0px 0px 0px 5px; width: 80px; text-align: left;">
                                    <%--Điện thoại:--%><asp:Literal ID="ltrPhone1" runat="server"></asp:Literal></div>
                            </div>
                            <div style="float: left; color: #30302F; font-size: 12px; font-family: Arial; padding-top: 5px;
                                height: 30px;">
                                <asp:TextBox ID="txtPhoneNhan" runat="server" ValidationGroup="CheckIn" CssClass="textboxI"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator12" ValidationGroup="CheckIn"
                                    ControlToValidate="txtPhoneNhan" CssClass="ValidateMessEmail" runat="server"
                                    ErrorMessage="**" Display="Dynamic">
                                </asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div style="float: left; height: 30px; padding: 5px 0px 0px 0px;">
                            <div style="float: left; height: 30px; padding: 8px 0px 0px 30px; width: 100px;">
                                <div style="float: left; color: Red; height: 30px; font-size: 11px;">
                                    *</div>
                                <div style="float: left; color: #30302F; font-size: 12px; font-family: Arial; height: 30px;
                                    padding: 0px 0px 0px 5px; width: 80px; text-align: left;">
                                   <%-- ĐTDĐ:--%><asp:Literal ID="ltrTel1" runat="server"></asp:Literal></div>
                            </div>
                            <div style="float: left; color: #30302F; font-size: 12px; font-family: Arial; padding-top: 5px;
                                height: 30px;">
                                <asp:TextBox ID="txtTelNhan" runat="server" ValidationGroup="CheckIn" CssClass="textboxI"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator13" ValidationGroup="CheckIn"
                                    ControlToValidate="txtTelNhan" CssClass="ValidateMessEmail" runat="server"
                                    ErrorMessage="**" Display="Dynamic">
                                </asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div style="float: left; height: 30px; padding: 5px 0px 0px 0px;">
                            <div style="float: left; height: 30px; padding: 8px 0px 0px 30px; width: 100px;">
                                <div style="float: left; color: Red; height: 30px; font-size: 11px;">
                                    *</div>
                                <div style="float: left; color: #30302F; font-size: 12px; font-family: Arial; height: 30px;
                                    padding: 0px 0px 0px 5px; text-align: left;">
                                    Email:</div>
                            </div>
                            <div style="float: left; color: #30302F; font-size: 12px; font-family: Arial; padding-top: 5px;
                                height: 30px;">
                                <asp:TextBox ID="txtEmailNhan" runat="server" CssClass="textboxI"></asp:TextBox>
                                 <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="**" Display="Dynamic"
                                    CssClass="ValidateMessEmail" ValidationGroup="CheckIn" ClientValidationFunction="validateEmailNhan"></asp:CustomValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtEmailNhan"
                                    ValidationExpression="[\w]+@[\w]+\.(com|net|org|co\.th|go\.th|ac\.th|or\.th|go\.th)"
                                    Display="Dynamic" ErrorMessage="**" ValidationGroup="CheckIn" CssClass="ValidateMessEmail"></asp:RegularExpressionValidator>
                            </div>
                        </div>
                        <div style="float: left; height: 30px; padding: 5px 0px 0px 0px; text-align: right;">
                            <asp:Button ID="btContinute" runat="server" Text="Tiếp tục" CssClass="buttonInput"
                                OnClick="btContinute_Click" ValidationGroup="CheckIn" />
                        </div>
                    </div>
                </td>
            </tr>
        </table>
        <uc2:CtrlRandomProduct ID="CtrlRandomProduct1" runat="server" />
        <div class="DivUpHome">
            <div class="testUp">
                <a href="javascript:top.window.scrollTo(0,0)">
                    <asp:Label ID="lbBacktoTop" runat="server" Text="Lên đầu trang" Font-Underline="false"></asp:Label></a></div>
            <div class="ImagesUp">
                <a href="javascript:top.window.scrollTo(0,0)">
                    <asp:Image ID="Image33" runat="server" ImageUrl="~/Images/btlendautrang.gif" /></a></div>
        </div>
    </div>
</asp:Content>
