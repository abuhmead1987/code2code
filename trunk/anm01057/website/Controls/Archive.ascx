<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Archive.ascx.cs" Inherits="Controls_Archive" %>

            <hr />
            <p class="right highlight" style="max-width:300px">
                <asp:Literal ID="LitFbc" runat="server" Text="<%$ Resources:language, Filterbycat%>" />: 
                <asp:DropDownList ID="DDcat" OnSelectedIndexChanged="ddcat_SelectedIndexChanged" AutoPostBack="true" runat="server"></asp:DropDownList> <br />
            </p>
            <div style="padding: 5px 5px 15px 10px">
            <% Response.Write(GetArchiveMenu()); %>
            </div>
            <hr /><p class="highlight"><asp:Label ID="lblmeseanno" runat="server" Text="Label"></asp:Label></p>
            <asp:GridView ID="GridView1" runat="server" ShowHeader="False" 
                BorderWidth="0px" AlternatingRowStyle-CssClass="archiverowalt" GridLines="None"
                AutoGenerateColumns="False" DataKeyNames="idnews" Width="100%" PageSize="50" 
                DataSourceID="SqlDataSource10" AllowPaging="True" EnableModelValidation="True">
            <PagerSettings Mode="NumericFirstLast" />
            <PagerStyle HorizontalAlign="Center" BorderWidth="1px" Font-Size="13px" />
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <div class="right" style="padding:4px 4px 4px 10px;">
                                <%# ViewDate(Eval("date").ToString())%>
                            </div>
		                    <div style="padding:4px 1px 4px 10px;">
                                <asp:HyperLink ID="HyperLink1" NavigateUrl='<%# "~/articles/" + Eval("idnews") + "/" + RNA(Eval("title").ToString()) + ".aspx" %>' runat="server"><%# Eval("Title")%></asp:HyperLink>
	                        </div>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <EmptyDataTemplate>
                    <br /> - No results.
                </EmptyDataTemplate>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource10" runat="server" 
                ConnectionString="<%$ ConnectionStrings:anmcs %>" 
                SelectCommand="anm_archiveAllNewsByDate" SelectCommandType="StoredProcedure">
                <SelectParameters>
                    <asp:QueryStringParameter Name="year" 
                        QueryStringField="year" Type="Int32" />
                    <asp:QueryStringParameter Name="month" 
                        QueryStringField="month" Type="Int32" />
                </SelectParameters>
            </asp:SqlDataSource>
            <asp:SqlDataSource ID="SqlDataSource9" runat="server" 
                ConnectionString="<%$ ConnectionStrings:anmcs %>" 
                SelectCommand="anm_archiveAllNewsByCatDate" SelectCommandType="StoredProcedure">
                <SelectParameters>
                    <asp:QueryStringParameter Name="idcategory" 
                        QueryStringField="category" Type="Int32" />
                    <asp:QueryStringParameter Name="year" 
                        QueryStringField="year" Type="Int32" />
                    <asp:QueryStringParameter Name="month" 
                        QueryStringField="month" Type="Int32" />         
                </SelectParameters>
            </asp:SqlDataSource><br />