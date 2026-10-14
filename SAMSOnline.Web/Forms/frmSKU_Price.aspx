<%@ Page Language="C#" MasterPageFile="~/Forms/PageMaster.master" AutoEventWireup="true"
    CodeFile="frmSKU_Price.aspx.cs" Inherits="SKU_Price" Title="SAMS >> SKU Price" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphPage" runat="Server">
    <script language="JavaScript" type="text/javascript">
        function ValidateForm() {
            var str;
            str = document.getElementById('<%=ddskuName.ClientID%>').value;
            if (str == null || str.length == 0) {
                alert('Must Select SKU Name');
                return false;
            }
            str = document.getElementById('<%=txtFromdate.ClientID%>').value;
            if (str == null || str.length == 0) {
                alert('Must Select Price Efftive Date');
                return false;
            }
            str = document.getElementById('<%=txtTaxPrices.ClientID%>').value;
            if (str == null || str.length == 0) {
                alert('Must enter Tax Price');
                return false;
            }
            str = document.getElementById('<%=txtTradePrice.ClientID%>').value;
            if (str == null || str.length == 0) {
                alert('Must enter Trade Price');
                return false;
            }
            str = document.getElementById('<%=txtRetailPrice.ClientID%>').value;
            if (str == null || str.length == 0) {
                alert('Must enter Retail Price');
                return false;
            }
            str = document.getElementById('<%=txtDistributorPrice.ClientID%>').value;
            if (str == null || str.length == 0) {
                alert('Must enter Factory Pricet');
                return false;
            }
            return true;
        }
        function CheckBoxListSelect() {
            var chkBoxList = document.getElementById('<%= ChbDistributorList.ClientID %>');
            var chkBox = document.getElementById('<%= ChbSelectAll.ClientID %>');
            if (chkBox.checked == true) {
                var chkBoxCount = chkBoxList.getElementsByTagName("input");

                for (var i = 0; i < chkBoxCount.length; i++) {
                    chkBoxCount[i].checked = true;
                }
            }
            else {
                var chkBoxCount = chkBoxList.getElementsByTagName("input");

                for (var i = 0; i < chkBoxCount.length; i++) {
                    chkBoxCount[i].checked = false;
                }
            }

        }
    </script>
    <div id="right_data">
        <table width="100%">
            <tr>
                <td>
                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                        <ContentTemplate>
                            <table width="100%">
                                <tbody>
                                    <tr>
                                        <td colspan="2">
                                            <strong>
                                                <asp:Label ID="lblErrorMsg" runat="server" ForeColor="Red" Font-Bold="True"></asp:Label></strong>
                                        </td>
                                        <td colspan="1">
                                        </td>
                                        <td colspan="1">
                                        </td>
                                        <td colspan="1">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 106px; height: 18px;" align="left">
                                            <strong>
                                                <asp:Label ID="Label1" runat="server" Width="103px" Text="Principal Name" CssClass="lblbox"></asp:Label></strong>
                                        </td>
                                        <td align="left" style="width: 298px; height: 18px">
                                            <asp:DropDownList ID="ddskuPrincipal" runat="server" Width="200px" CssClass="DropList"
                                                AutoPostBack="True" OnSelectedIndexChanged="ddskuPrincipal_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </td>
                                        <td align="left" style="height: 18px">
                                            <strong>
                                                <asp:Label ID="Label12" runat="server" CssClass="lblbox" Width="60px"></asp:Label></strong>
                                        </td>
                                        <td align="left" rowspan="11" style="border-right: darkgray 1px ridge; border-top: darkgray 1px ridge;
                                            border-left: darkgray 1px ridge; border-bottom: darkgray 1px ridge">
                                            <table>
                                                <tr>
                                                    <td class="tblhead">
                                                        <strong>
                                                            <asp:Label ID="Label11" runat="server" CssClass="tblhead" Text="Location Name" Width="121px"
                                                                Font-Bold="True" ForeColor="White"></asp:Label></strong>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:CheckBox ID="ChbSelectAll" runat="server" Text="Select All" Width="100px" onclick="CheckBoxListSelect()"
                                                            CssClass="DropList" Font-Size="8pt" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 100px">
                                                        <asp:Panel ID="Panel1" runat="server" BackColor="White" BorderColor="Silver" BorderStyle="Groove"
                                                            BorderWidth="1px" Height="220px" ScrollBars="Vertical" Width="200px">
                                                            <asp:CheckBoxList ID="ChbDistributorList" runat="server" Font-Size="8pt" Width="174px">
                                                            </asp:CheckBoxList>
                                                        </asp:Panel>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td style="height: 18px">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 106px" align="left">
                                            <strong>
                                                <asp:Label ID="Label2" runat="server" Width="101px" Text="Division Name" CssClass="lblbox"></asp:Label></strong>
                                        </td>
                                        <td align="left" style="width: 298px">
                                            <asp:DropDownList ID="ddskuDivision" runat="server" Width="200px" CssClass="DropList"
                                                AutoPostBack="True" OnSelectedIndexChanged="ddskuDivision_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </td>
                                        <td align="left">
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 106px" align="left">
                                            <strong>
                                                <asp:Label ID="Label7" runat="server" Width="101px" Text="SKU Category" CssClass="lblbox"></asp:Label></strong>
                                        </td>
                                        <td align="left">
                                            <asp:DropDownList ID="ddskuCategory" runat="server" Width="200px" CssClass="DropList"
                                                AutoPostBack="True" OnSelectedIndexChanged="ddskuCategory_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </td>
                                        <td align="left">
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 106px" align="left">
                                            <strong>
                                                <asp:Label ID="Label9" runat="server" Width="101px" Text="SKU Brand" CssClass="lblbox"></asp:Label></strong>
                                        </td>
                                        <td align="left">
                                            <asp:DropDownList ID="ddskuBrand" runat="server" Width="200px" CssClass="DropList"
                                                AutoPostBack="True" OnSelectedIndexChanged="ddskuBrand_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </td>
                                        <td align="left">
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 106px; height: 18px" align="left">
                                            <strong>
                                                <asp:Label ID="Label6" runat="server" Width="100px" Text="SKU Name"></asp:Label></strong>
                                        </td>
                                        <td align="left">
                                            <asp:DropDownList ID="ddskuName" runat="server" Width="200px" CssClass="DropList"
                                                AutoPostBack="True" OnSelectedIndexChanged="ddskuName_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </td>
                                        <td align="left" style="width: 201px; height: 18px">
                                        </td>
                                        <td style="width: 201px; height: 18px">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 106px" align="left">
                                            <strong>
                                                <asp:Label ID="Label8" runat="server" Width="100px" Text="Date Effected"></asp:Label></strong>
                                        </td>
                                        <td style="width: 298px" align="left">
                                            <asp:TextBox Style="text-align: justify" ID="txtFromdate" TabIndex="2" runat="server"
                                                Width="193px" CssClass="txtBox" MaxLength="1" ValidationGroup="MKE"></asp:TextBox>
                                            <asp:ImageButton ID="ImgBntFromCalc" runat="server" CausesValidation="False" ImageUrl="~/App_Themes/Granite/Images/date.gif">
                                            </asp:ImageButton><cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtFromdate"
                                                PopupButtonID="ImgBntFromCalc" Format="dd-MMM-yyyy">
                                            </cc1:CalendarExtender>
                                        </td>
                                        <td align="left" style="width: 201px">
                                        </td>
                                        <td style="width: 201px" align="left">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left">
                                            <strong>
                                                <asp:Label ID="Label10" runat="server" Width="90px" Text="Factory Price" CssClass="lblbox"></asp:Label></strong>
                                        </td>
                                        <td style="width: 298px" align="left">
                                            <asp:TextBox ID="txtDistributorPrice" runat="server" Width="193px" CssClass="txtBox "
                                                MaxLength="8"></asp:TextBox>
                                        </td>
                                        <td align="left" style="width: 201px">
                                        </td>
                                        <td style="width: 201px" align="left">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left">
                                            <strong>
                                                <asp:Label ID="Label3" runat="server" Width="101px" Text="Trade Price" CssClass="lblbox"></asp:Label></strong>
                                        </td>
                                        <td style="width: 298px" align="left">
                                            <asp:TextBox ID="txtTradePrice" runat="server" Width="192px" CssClass="txtBox " MaxLength="8"></asp:TextBox>
                                        </td>
                                        <td align="left" style="width: 201px">
                                        </td>
                                        <td style="width: 201px" align="left">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 106px" align="left">
                                            <strong>
                                                <asp:Label ID="Label4" runat="server" Width="103px" Text="Retail Price" CssClass="lblbox"></asp:Label></strong>
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtRetailPrice" runat="server" Width="192px" CssClass="txtBox "
                                                MaxLength="8"></asp:TextBox>
                                        </td>
                                        <td align="left" style="width: 201px">
                                        </td>
                                        <td style="width: 201px" align="left">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 106px; height: 12px" align="left">
                                            <strong>
                                                <asp:Label ID="Label5" runat="server" Width="102px" Text="G.S.T (%)" CssClass="lblbox"></asp:Label></strong>
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtTaxPrices" runat="server" Width="192px" CssClass="txtBox " MaxLength="8"></asp:TextBox>
                                        </td>
                                        <td align="left" style="width: 201px; height: 12px">
                                        </td>
                                        <td style="width: 201px; height: 12px" align="left">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" style="width: 106px; height: 12px">
                                            <strong>
                                                <asp:Label ID="Label14" runat="server" CssClass="lblbox" Text="S.E.D (%)" Width="102px"></asp:Label></strong>
                                        </td>
                                        <td align="left" style="width: 298px; height: 12px">
                                            <asp:TextBox ID="txtSADTax" runat="server" CssClass="txtBox " MaxLength="8" Width="192px"></asp:TextBox>
                                        </td>
                                        <td align="left" style="width: 201px; height: 12px">
                                        </td>
                                        <td align="left" style="width: 201px; height: 12px">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 106px">
                                        </td>
                                        <td align="left" style="width: 298px">
                                            <asp:Button ID="btnSave" OnClick="btnSave_Click" runat="server" Width="90px" Font-Size="8pt"
                                                Text="Save" ValidationGroup="vg" CssClass="btn" />&nbsp;
                                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txtTaxPrices"
                                                FilterType="Custom" ValidChars="0123456789.">
                                            </cc1:FilteredTextBoxExtender>
                                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="txtTradePrice"
                                                FilterType="Custom" ValidChars=".0123456789">
                                            </cc1:FilteredTextBoxExtender>
                                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" TargetControlID="txtRetailPrice"
                                                FilterType="Custom" ValidChars=".0123456789">
                                            </cc1:FilteredTextBoxExtender>
                                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server" TargetControlID="txtDistributorPrice"
                                                FilterType="Custom" ValidChars=".0123456789">
                                            </cc1:FilteredTextBoxExtender>
                                        </td>
                                        <td align="left">
                                        </td>
                                        <td align="left">
                                        </td>
                                        <td align="left">
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                            <div style="z-index: 101; left: 465px; width: 100px; position: absolute; top: 323px;
                                height: 100px">
                                &nbsp;<asp:Panel ID="Panel21" runat="server">
                                    <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel3">
                                        <ProgressTemplate>
                                            <asp:ImageButton ID="ImageButton1" runat="server" Height="26px" ImageUrl="~/App_Themes/Granite/Images/image003.gif"
                                                Width="23px" />
                                            Wait Update
                                        </ProgressTemplate>
                                    </asp:UpdateProgress>
                                </asp:Panel>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
        </table>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:Panel ID="Panel2" runat="server" Height="200px" ScrollBars="Vertical" Width="100%">
                    <asp:GridView ID="Grid_pricedetails" runat="server" Width="99%" ForeColor="SteelBlue"
                        HorizontalAlign="Center" BorderColor="White" BackColor="White" AutoGenerateColumns="False">
                        <PagerSettings FirstPageText="" LastPageText="" Mode="NextPrevious" NextPageText="Next"
                            PreviousPageText="Previous"></PagerSettings>
                        <RowStyle ForeColor="Black"></RowStyle>
                        <Columns>
                            <asp:BoundField DataField="distributor_name" HeaderText="Location">
                                <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="SKU_CODE" HeaderText="SKU Code">
                                <ItemStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid"></ItemStyle>
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="SKU_NAME" HeaderText="SKU Name">
                                <ItemStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid"></ItemStyle>
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="GST_ON" HeaderText="GST">
                                <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="DISTRIBUTOR_PRICE" HeaderText="Factory Price" DataFormatString="{0:F2}">
                                <ItemStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid"></ItemStyle>
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="TRADE_PRICE" HeaderText="Trade Price" DataFormatString="{0:F2}">
                                <ItemStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid"></ItemStyle>
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="RETAIL_PRICE" HeaderText="Retail Price" DataFormatString="{0:F2}">
                                <ItemStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid"></ItemStyle>
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="TAX_PRICE" HeaderText="GST (%)" DataFormatString="{0:F2}">
                                <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                <ItemStyle BorderColor="DarkGray" BorderWidth="1px" BorderStyle="Solid"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="SED_TAX" DataFormatString="{0:F2}" HeaderText="SED (%)">
                                <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="DATE_EFFECTED" HeaderText="Date Effected">
                                <ItemStyle BackColor="Transparent" BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid">
                                </ItemStyle>
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                        </Columns>
                        <HeaderStyle CssClass="tblhead" ForeColor="White"></HeaderStyle>
                        <AlternatingRowStyle CssClass="GridAlternateRowStyle"></AlternatingRowStyle>
                    </asp:GridView>
                </asp:Panel>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
