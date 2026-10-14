<%@ Page Language="C#" MasterPageFile="~/Forms/PageMaster.master" AutoEventWireup="true"
    CodeFile="frmOrderEntry.aspx.cs" Inherits="Forms_frmOrderEntry" Title="SAMS >> Order/Invoice" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cphPage">
<script type="text/javascript" src="../JS/jquery-1.6.1.min.js"></script>
<script type="text/javascript" src="../JS/jquery.searchabledropdown-1.0.8.min.js"></script>

  <script language="JavaScript" type="text/javascript">
      function pageLoad() {
          $("select").searchable();
      }
     
        function ValidateValue(inputtxt) {
            var decimal = /^[0-9]+(\.[0-9]+)+$/;
            var int = /^[0-9]/;

            var completevalue = inputtxt.value;
            var splitvalues = completevalue.split(".");

            // check for decimal points ans if greater then 1 point stop and turn default values
            if (splitvalues[2] != null) {
                document.getElementById('<%=numTxtTotalHalfScheme.ClientID%>').value = '0.0000';
                return;
            }


            if (inputtxt.value.match(decimal) || inputtxt.value.match(int)) {
                return true;
            }
            else {
                document.getElementById('<%=numTxtTotalHalfScheme.ClientID%>').value = '0.0000';
                this.focus();
            }
        }

        function ValidateForm() {
            var str;

            str = document.getElementById('<%=txtskuName.ClientID%>').value;
            if (str == null || str.length == 0) {
                alert('Must Select SKU Name');
                return false;
            }

            str = document.getElementById('<%=txtQuantity.ClientID%>').value;
            if (str == null || str.length == 0) {
                alert('Must Enter Quantity');
                return false;
            }

            var DBrate = document.getElementById("<%= Hdntxtunitrate.ClientID %>").value;
            var RateFrom = document.getElementById("<%= HdnRateFrom.ClientID %>").value;
            var UserRate = document.getElementById("<%= txtUnitRate.ClientID %>").value;
            UserRate = parseFloat(UserRate);

            if (RateFrom == 'CS') {
                if (UserRate >= DBrate) {

                    return true;

                }
              <%-- 
//                else {
//                    alert('Must Enter Valid Rate');
//                    document.getElementById("<%= txtUnitRate.ClientID %>").focus();
//                    return false;
//                } 
//               
 --%>
                return true;
               
            }

       
            
        }
        function SearcSKUList(e) {
            var l = document.getElementById('<%= lstCode.ClientID %>');
            var tb = document.getElementById('<%= txtskuCode.ClientID %>');
            if (e.keyCode == 27) {
                document.getElementById("<%= numTxtTotalHalfScheme.ClientID %>").focus();
            }
            else {
                if (tb.value == "") {
                    ClearSelection(l);
                }
                else {
                    for (var i = 0; i < l.options.length; i++) {
                        if (l.options[i].value.toLowerCase().match(tb.value.toLowerCase())) {
                            l.options[i].selected = true;
                            return false;
                        }
                        else {
                            ClearSelection(l);
                        }
                    }
                }
            }
        }
        function SearchList() {
            var l = document.getElementById('<%= ListCustomer.ClientID %>');
            var tb = document.getElementById('<%= DrpCustomer.ClientID %>');




            if (tb.value == "") {
                ClearSelection(l);
            }
            else {
                for (var i = 0; i < l.options.length; i++) {
                    if (l.options[i].value.toLowerCase().match(tb.value.toLowerCase())) {
                        tb.options[i].selected = true;
                        return false;
                    }
                    else {
                        ClearSelection(l);
                    }
                }
            }
        }
        function SearchedCode() {
            var str
            var stroption
            var code;
            str = document.getElementById("<%= ListCustomer.ClientID %>").value;
            stroption = document.getElementById("<%= DrpCustomer.ClientID %>").value;

            if (str.length > 0) {
                code = str.substring(str.indexOf('| ') + 2)
                code = code.substring(0, code.indexOf('|') - 1);
                document.getElementById("<%= txtOutletCode.ClientID %>").value = 'OT' + code;
                document.getElementById("<%= txtOutletName.ClientID %>").value = str.substring(0, str.indexOf('|'));
                document.getElementById("<%= Panel1.ClientID %>").className = "hiddencol";

            }
            else if (stroption.length == 0) {
                document.getElementById("<%= Panel1.ClientID %>").className = "Displaycol";
                document.getElementById("<%= ListCustomer.ClientID %>").focus();
            }
            ClearSelection(document.getElementById('<%= ListCustomer.ClientID %>'));

        }
        function SearchSKUCode() {
            var str = document.getElementById("<%= lstCode.ClientID %>").value;
            var stroption = document.getElementById("<%= txtskuCode.ClientID %>").value;
            if (str.length > 0) {
                document.getElementById("<%= txtskuCode.ClientID %>").value = str.substring(0, str.indexOf('-'));
                document.getElementById("<%= txtskuName.ClientID %>").value = str.substring(str.indexOf('-') + 1, str.indexOf(':'));
                document.getElementById("<%= txtUnitRate.ClientID %>").value = str.substring(str.indexOf(':') + 1, str.indexOf('|'));
                document.getElementById("<%= Hdntxtunitrate.ClientID %>").value = str.substring(str.indexOf(':') + 1, str.indexOf('|'));
                document.getElementById("<%= HdnRateFrom.ClientID %>").value = str.substring(str.indexOf('|') + 1);
                document.getElementById("<%= Panel3.ClientID %>").className = "hiddencol";

            }
            else if (stroption.length == 0) {
                document.getElementById("<%= Panel3.ClientID %>").className = "Displaycol";
                document.getElementById("<%= lstCode.ClientID %>").focus();
            }
            ClearSelection(document.getElementById('<%= lstCode.ClientID %>'));

        }
        function SelectSkuCode(e) {
            var key = e.charCode ? e.charCode : e.keyCode ? e.keyCode : 0;
            if (key == 13) {
                e.preventDefault();
                var str = document.getElementById("<%= lstCode.ClientID %>").value;
             

                var code;   
                
                document.getElementById("<%= txtskuCode.ClientID %>").value = str.substring(0, str.indexOf('-'));
                document.getElementById("<%= txtskuName.ClientID %>").value = str.substring(str.indexOf('-') + 1, str.indexOf(':'));
              
                document.getElementById("<%= txtUnitRate.ClientID %>").value = str.substring(str.indexOf(':') + 1);
               
            
                document.getElementById("<%= Panel3.ClientID %>").className = "hiddencol";
                document.getElementById("<%= txtQuantity.ClientID %>").focus();
            }
        }
        function SelectCode(e) {
            var key = e.charCode ? e.charCode : e.keyCode ? e.keyCode : 0;
            if (key == 13) {
                e.preventDefault();
                var str = document.getElementById("<%= ListCustomer.ClientID %>").value;
                code = str.substring(str.indexOf('| ') + 2)
                code = code.substring(0, code.indexOf('|') - 1);
                document.getElementById("<%= DrpCustomer.ClientID %>").value = 'OT' + code;
               document.getElementById("<%= txtOutletName.ClientID %>").value = str.substring(0, str.indexOf('|'));
                document.getElementById("<%= Panel1.ClientID %>").className = "hiddencol";
                document.getElementById("<%= txtQuantity.ClientID %>").focus();
            }
        }
        function ClearSelection(lb) {
            lb.selectedIndex = -1;
        }
 
    </script>
    <div id="right_data">
        <table width="100%">
            <tr>
                <td>
                    <div style="left: 120px; position: absolute; top: 150px;">
                        <asp:Panel ID="Panel1" runat="server" Width="327px" Height="237px" BorderWidth="1px"
                            BorderStyle="Inset" BorderColor="White" BackColor="Silver" CssClass="hiddencol">
                            <table style="border-right: #ffffff thin groove; border-top: #ffffff thin groove;
                                border-left: #ffffff thin groove; width: 99%; border-bottom: #ffffff thin groove">
                                <tbody>
                                    <tr>
                                        <td style="border-bottom: black thin solid" align="left" colspan="2">
                                            &nbsp;<strong>Select Customer from List Press Enter</strong>
                                        </td>
                                        <td style="border-bottom: black thin solid" valign="top" align="right">
                                            <asp:Button AccessKey="S" ID="Button4" runat="server" Width="21px" Height="16px"
                                                Font-Size="8pt" Text="X" BorderWidth="1px" BorderStyle="Groove"></asp:Button>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                            <asp:ListBox ID="ListCustomer" onkeydown="SelectCode(event)" runat="server" Width="95%"
                                Height="87%"></asp:ListBox>
                        </asp:Panel>
                        <asp:UpdatePanel ID="upProd" runat="server">
                        <ContentTemplate>
                        
                        <div style="left: -100px; position: absolute; top: 70px; height: 248px;">
                            <asp:Panel ID="Panel3" runat="server" Width="327px" Height="237px" BorderWidth="1px"
                                BorderStyle="Inset" BorderColor="White" BackColor="Silver" CssClass="hiddencol">
                                <table style="border-right: #ffffff thin groove; border-top: #ffffff thin groove;
                                    border-left: #ffffff thin groove; width: 99%; border-bottom: #ffffff thin groove">
                                    <tbody>
                                        <tr>
                                            <td style="border-bottom: black thin solid" align="left" colspan="2">
                                                &nbsp;<strong>Select SKU from List Press Enter</strong>
                                            </td>
                                            <td style="border-bottom: black thin solid" valign="top" align="right">
                                                <asp:Button ID="Button5" runat="server" AccessKey="S" BorderStyle="Groove" BorderWidth="1px"
                                                    Font-Size="8pt" Height="16px" Text="X" Width="21px" />
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>

                                <asp:ListBox ID="lstCode" onkeydown="SelectSkuCode(event)" runat="server" Width="95%"
                                    Height="87%" SelectionMode="Multiple"></asp:ListBox>
                            </asp:Panel>
                            &nbsp;

                        </div>

                        </ContentTemplate>
                        </asp:UpdatePanel>

                    </div>
                    <div style="z-index: 101; left: 700px; width: 100px; position: absolute; top: 291px;
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
                    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                        <ContentTemplate>
                            <table>
                                <tr>
                                    <td align="left" valign="top">
                                        <strong>
                                            <asp:Label ID="lblDocumentNo" runat="server" Text="Transaction No" Width="100px"></asp:Label></strong>
                                    </td>
                                    <td align="left" colspan="2" valign="top">
                                        <asp:DropDownList ID="drpDocumentNo" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drpDocumentNo_SelectedIndexChanged"
                                            Width="231px">
                                        </asp:DropDownList>
                                    </td>
                                    <td align="left" colspan="1" valign="top">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" valign="top">
                                        <strong>
                                            <asp:Label ID="lblBillNo" runat="server" Text="Bill No" Width="100px"></asp:Label></strong>
                                    </td>
                                    <td align="left" colspan="2" valign="top">
                                        <asp:TextBox ID="txtBillNo" runat="server" MaxLength="50" Width ="225px"></asp:TextBox>
                                    </td>
                                    <td align="left" colspan="1" valign="top">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" valign="middle">
                                        <strong>
                                            <asp:Label ID="Label11" runat="server" Text="Transaction Type" Width="120px"></asp:Label></strong>
                                    </td>
                                    <td align="left" colspan="2" valign="top">
                                        <asp:RadioButtonList ID="RblPayMode" runat="server" Height="1px" RepeatDirection="Horizontal"
                                            Width="190px">
                                        </asp:RadioButtonList>
                                    </td>
                                    <td align="left" colspan="1" valign="top">
                                    </td>
                                </tr>
                                <tr>
                                   <td> <strong>
                                            <asp:Label ID="Label6" runat="server" Text="Sale Force" Width="120px"></asp:Label></strong></td>
                                    <td >
                                        <asp:TextBox ID="txtprincipal" runat="server" CssClass="txtBox " onkeyup="SearchList()"
                                            ReadOnly="True" Width="222px" Visible ="true"></asp:TextBox>
                                       
                                        <asp:TextBox ID="txtDeliveryMan" runat="server" CssClass="txtBox " 
                                             ReadOnly="True" Width="180px" Visible ="true" ></asp:TextBox>
                                    </td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td align="left" style="height: 23px">
                                        <strong>
                                            <asp:Label ID="Label1" runat="server" CssClass="lblbox" Text="Customer" Width="74px"></asp:Label></strong>
                                    </td>
                                    <td align="left" style="height: 23px">
                                        <asp:TextBox ID="txtOutletCode" runat="server" CssClass="txtBox " onkeyup="SearchList()"
                                            Width="76px"  Visible="false"></asp:TextBox>
                                        <asp:DropDownList ID="DrpCustomer" runat="server" Width="415px" 
                                            onselectedindexchanged="DrpCustomer_SelectedIndexChanged" 
                                            AutoPostBack ="true" onkeyup="SearchList()" >
                                        </asp:DropDownList>
                                    <%--</td>
                                    <td align="left" style="height: 23px">--%>
                                        <asp:TextBox ID="txtOutletName" runat="server" CssClass="txtBox " onfocus="SearchedCode()"
                                            Width="192px" Visible="false"></asp:TextBox>
                                    </td>
                                    <td align="left" style="height: 23px; width: 162px;">
                                        <asp:TextBox ID="txtDiscountType" runat="server" CssClass="txtBox " onkeyup="SearchList()"
                                            ReadOnly="True" Width="138px">Manual Discount</asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                    </td>
                                    <td align="left" colspan="2" valign="top">
                                    </td>
                                    <td align="left" colspan="1" valign="top">
                                    </td>
                                </tr>
                            </table>
                            &nbsp;
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Panel ID="Panel5" runat="server" DefaultButton="btnSave">
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <table>
                                    <tbody>
                                        <tr>
                                            <td style="height: 16px" class="tblhead">
                                                <asp:Label ID="lblskuCode" runat="server" Width="74px" Height="16px" Font-Bold="True"
                                                    Text="  SKU Code"></asp:Label>
                                            </td>
                                            <td style="height: 16px" class="tblhead">
                                                <asp:Label ID="lblskuname" runat="server" Width="187px" Height="16px" Font-Bold="True"
                                                    Text="   SKU Name"></asp:Label>
                                            </td>
                                            <td style="height: 16px" class="tblhead">
                                                <asp:Label ID="Label3" runat="server" Width="61px" Height="16px" Font-Bold="True"
                                                    Text="Sold Qty"></asp:Label>
                                            </td>
                                            <td style="height: 16px" class="tblhead">
                                                <asp:Label ID="lblquantity" runat="server" Width="62px" Height="16px" Font-Bold="True"
                                                    Text="Price"></asp:Label>
                                            </td>
                                            <td style="height: 16px" align="center" class="tblhead">
                                                <asp:Label ID="Label7" runat="server" Width="100%" Height="16px" Font-Bold="True"
                                                    Text="Empty Qty"></asp:Label>
                                            </td>
                                            <td style="height: 16px" class="tblhead">
                                                <asp:Label ID="Label2" runat="server" Width="100%" Height="16px" ForeColor="White"
                                                    Font-Bold="True" Text="Amount"></asp:Label>
                                            </td>
                                            <td style="height: 16px" class="tblhead">
                                                <asp:Label ID="Label4" runat="server" Width="100%" Height="16px" ForeColor="White"
                                                    Font-Bold="True" Text="Add SKU"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:TextBox ID="txtskuCode" onkeyup="SearcSKUList(event)" runat="server" Width="68px"
                                                    CssClass="txtBox"  ></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtskuName" runat="server" Width="181px" Font-Bold="True" CssClass="txtBox"
                                                    Enabled="False"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtQuantity" onfocus="SearchSKUCode()" runat="server" Width="55px"
                                                    CssClass="txtBox "></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtUnitRate" runat="server" Width="56px"></asp:TextBox>
                                                <asp:HiddenField ID="Hdntxtunitrate" Value="" runat="server" />
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtEmpty" onfocus="SearchSKUCode()" runat="server" Width="62px"></asp:TextBox>
                                                <asp:HiddenField ID="HdnRateFrom" runat="server" />
                                            </td>
                                            <td>
                                                <asp:TextBox ID="TextBox1" onfocus="SearchSKUCode()" runat="server" Width="72px"
                                                    CssClass="txtBoxnNum" Enabled="False"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:Button AccessKey="A" ID="btnSave" OnClick="btnSave_Click" runat="server" Width="100px"
                                                    Font-Size="8pt" Text="Add Sku" ValidationGroup="vg" CssClass="btn"></asp:Button>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" colspan="7">
                                                <asp:Panel ID="Panel2" runat="server" Width="680px" Height="130px" ScrollBars="Vertical"
                                                    BorderColor="Silver" BorderStyle="Groove" BorderWidth="1px">
                                                    <asp:GridView ID="GrdPurchase" runat="server" ForeColor="SteelBlue" CssClass="gridRow2"
                                                        BackColor="White" HorizontalAlign="Center" AutoGenerateColumns="False" BorderColor="White"
                                                        ShowHeader="False" OnRowDeleting="GrdPurchase_RowDeleting" OnRowEditing="GrdPurchase_RowEditing">
                                                        <PagerSettings FirstPageText="" LastPageText="" Mode="NextPrevious" NextPageText="Next"
                                                            PreviousPageText="Previous"></PagerSettings>
                                                        <RowStyle ForeColor="Black"></RowStyle>
                                                        <Columns>
                                                            <asp:BoundField DataField="SKU_ID" HeaderText="SKU_ID">
                                                                <HeaderStyle CssClass="hiddencol"></HeaderStyle>
                                                                <ItemStyle CssClass="hiddencol"></ItemStyle>
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="SKU_CODE" HeaderText="SKU Code">
                                                                <ItemStyle HorizontalAlign="Left" BorderColor="Silver" BorderWidth="2px" BorderStyle="Solid"
                                                                    Width="75px"></ItemStyle>
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="SKU_NAME" HeaderText="SKU Name">
                                                                <ItemStyle HorizontalAlign="Left" BorderColor="Silver" BorderWidth="2px" BorderStyle="Solid"
                                                                    Width="200px"></ItemStyle>
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="QUANTITY_UNIT" HeaderText="Quantity">
                                                                <ItemStyle HorizontalAlign="Right" BorderColor="Silver" BorderWidth="2px" BorderStyle="Solid"
                                                                    Width="65px"></ItemStyle>
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="UNIT_PRICE" HeaderText="PRICE" DataFormatString="{0:F2}">
                                                                <ItemStyle HorizontalAlign="Right" BorderColor="Silver" BorderWidth="2px" BorderStyle="Solid"
                                                                    Width="65px"></ItemStyle>
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="SED_AMOUNT" HeaderText="SED_AMOUNT">
                                                                <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" Width="70px" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="Amount" HeaderText="Amount" DataFormatString="{0:F2}">
                                                                <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Right"
                                                                    Width="80px" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="QUANTITY_CTN" HeaderText="QUANTITY_CTN">
                                                                <HeaderStyle CssClass="hiddencol" />
                                                                <ItemStyle CssClass="hiddencol" />
                                                            </asp:BoundField>
                                                            <asp:CommandField ShowEditButton="True" HeaderText="Edit">
                                                                <ItemStyle BorderColor="Silver" BorderWidth="1px" Width="40px"></ItemStyle>
                                                            </asp:CommandField>
                                                            <asp:TemplateField HeaderText="Delete">
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="btnDelete" runat="server" Text="Delete" OnClientClick="javascript:return confirm('Are you sure you want to Delete?');return false;"
                                                                        CommandName="Delete"></asp:LinkButton>
                                                                </ItemTemplate>
                                                                <ItemStyle BorderColor="Silver" BorderWidth="2px" BorderStyle="Solid" Width="45px">
                                                                </ItemStyle>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                        <FooterStyle BackColor="White"></FooterStyle>
                                                        <PagerStyle BackColor="Transparent"></PagerStyle>
                                                        <HeaderStyle CssClass="tblhead" ForeColor="White"></HeaderStyle>
                                                        <AlternatingRowStyle BackColor="#F2F2F2" CssClass="GridAlternateRowStyle" ForeColor="#333333">
                                                        </AlternatingRowStyle>
                                                    </asp:GridView>
                                                </asp:Panel>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </asp:Panel>
                </td>
            </tr>
        </table>
        <table width="100%">
            <tr>
                <td style="height: 226px">
                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                        <ContentTemplate>
                            <table>
                                <tbody>
                                    <tr>
                                        <td valign="top" align="left" colspan="2" rowspan="6">
                                            <strong>
                                                <asp:Label ID="Label10" runat="server" Width="60px" Text="Free SKU" CssClass="lblbox"></asp:Label></strong><asp:Panel
                                                    ID="Panel4" runat="server" Width="350px" Height="100px" BorderColor="Silver"
                                                    BorderStyle="Groove" BorderWidth="1px">
                                                    <asp:GridView ID="GrdFreeSKU" runat="server" Width="100%" ForeColor="Silver" CssClass="gridRow2"
                                                        BorderColor="White" BackColor="White" AutoGenerateColumns="False" HorizontalAlign="Center">
                                                        <PagerSettings FirstPageText="" LastPageText="" Mode="NextPrevious" NextPageText="Next"
                                                            PreviousPageText="Previous"></PagerSettings>
                                                        <RowStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid" ForeColor="Black">
                                                        </RowStyle>
                                                        <Columns>
                                                            <asp:BoundField DataField="SKU_ID" HeaderText="SKU_ID">
                                                                <HeaderStyle CssClass="hiddencol"></HeaderStyle>
                                                                <ItemStyle CssClass="hiddencol"></ItemStyle>
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="SKU_Code" HeaderText="SKU Code">
                                                                <ItemStyle Width="80px" BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px">
                                                                </ItemStyle>
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="SKU_Name" HeaderText="SKU Name">
                                                                <ItemStyle Width="200px" BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px">
                                                                </ItemStyle>
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="Quantity" HeaderText="Qty">
                                                                <ItemStyle Width="50px" BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px">
                                                                </ItemStyle>
                                                            </asp:BoundField>
                                                        </Columns>
                                                        <FooterStyle BackColor="White"></FooterStyle>
                                                        <PagerStyle BackColor="Transparent"></PagerStyle>
                                                        <HeaderStyle BackColor="Silver" BorderColor="Black" BorderWidth="1px" BorderStyle="Solid"
                                                            ForeColor="Black"></HeaderStyle>
                                                    </asp:GridView>
                                                </asp:Panel>
                                        </td>
                                        <td style="height: 20px; width: 35px;" align="left">
                                        </td>
                                        <td style="height: 20px; width: 20px;" align="left">
                                            <strong>
                                                <asp:Label ID="lblDocumentNo1" runat="server" Width="94px" Text="Gross Sale" CssClass="lblbox"></asp:Label></strong>
                                        </td>
                                        <td style="width: 7px; height: 20px">
                                            <asp:TextBox ID="txtGrossAmount" runat="server" Width="150px" ForeColor="Black" Font-Bold="True"
                                                CssClass="txtBoxnNum" ReadOnly="True"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" style="width: 35px">
                                        </td>
                                        <td align="left" style="width: 20px">
                                            <strong>
                                                <asp:Label ID="lblfromLocation1" runat="server" Width="130px" Text="Discount"></asp:Label></strong>
                                        </td>
                                        <td style="width: 7px">
                                            <asp:TextBox ID="numtxtTotalExtraDiscnt" runat="server" Width="150px" ForeColor="Black"
                                                Font-Bold="True" CssClass="txtBoxnNum" ReadOnly="True">0.00</asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 18px; width: 35px;" align="left">
                                        </td>
                                        <td style="height: 18px; width: 20px;" align="left">
                                            <strong>
                                                <asp:Label ID="Label51" runat="server" Width="130px" Text="Distributor Discount"
                                                    Visible="false"></asp:Label></strong>
                                        </td>
                                        <td style="width: 7px; height: 18px">
                                            <asp:TextBox ID="numTxtTotalStndrdDiscnt" runat="server" Width="150px" ForeColor="Black"
                                                Font-Bold="True" Visible="false" ReadOnly="True"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 18px; width: 35px;" align="left">
                                        </td>
                                        <td style="height: 18px; width: 20px;" align="left">
                                            <strong>
                                                <asp:Label ID="lblHalfScheme" runat="server" Width="110px" Text="Half Scheme" Visible="false"></asp:Label></strong>
                                        </td>
                                        <td style="width: 7px; height: 18px">
                                            <asp:TextBox onblur="ValidateValue(this)" ID="numTxtTotalHalfScheme" runat="server"
                                                Width="150px" Visible="false" ForeColor="Black" Font-Bold="True" CssClass="txtBoxnNum"
                                                __designer:wfdid="w2">0.0000</asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 35px; height: 20px" valign="top">
                                        </td>
                                        <td style="width: 20px; height: 20px" align="left">
                                            <strong>
                                                <asp:Label ID="Label81" runat="server" Width="93px" Text="GST Amount" CssClass="lblbox"></asp:Label></strong>
                                        </td>
                                        <td style="width: 7px; height: 20px" align="right">
                                            <asp:TextBox ID="numTxtTotalGST" runat="server" Width="150px" ForeColor="Black" Font-Bold="True"
                                                CssClass="txtBoxnNum" ReadOnly="True"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 35px; height: 20px" valign="top">
                                        </td>
                                        <td style="width: 20px; height: 20px" align="left">
                                            <strong>
                                                <asp:Label ID="Label91" runat="server" Width="105px" Text="Net Amount" CssClass="lblbox"></asp:Label></strong>
                                        </td>
                                        <td style="width: 7px; height: 20px" align="right">
                                            <asp:TextBox ID="numTxtTotlAmnt" runat="server" Width="150px" ForeColor="Black" Font-Bold="True"
                                                CssClass="txtBoxnNum" ReadOnly="True"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" colspan="2">
                                            <table>
                                                <tbody>
                                                    <tr>
                                                        <td style="width: 100px; height: 21px">
                                                            <asp:Button AccessKey="C" ID="btnCalculate" TabIndex="100" OnClick="btnCalculate_Click"
                                                                runat="server" Width="100px" Font-Size="8pt" Text="Calculate" Enabled="False"
                                                                CssClass="btn"></asp:Button>
                                                        </td>
                                                        <td style="width: 100px; height: 21px">
                                                            <asp:Button AccessKey="S" ID="btnSaveOrder" TabIndex="101" OnClick="btnSaveOrder_Click"
                                                                runat="server" Width="110px" Font-Size="8pt" Text="Save Order" Enabled="False"
                                                                CssClass="btn"></asp:Button>
                                                        </td>
                                                        <td style="width: 100px; height: 21px">
                                                            <asp:Button AccessKey="H" ID="btnCancel" TabIndex="102" OnClick="Button2_Click" runat="server"
                                                                Width="110px" Font-Size="8pt" Text="Home" CssClass="btn"></asp:Button>
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </td>
                                       
                                       
                                            <strong>
                                                <asp:Label ID="Label5" runat="server" Width="105px" Text="Cash Received" CssClass="lblbox" Visible="false"></asp:Label></strong>
                                      
                                            <asp:TextBox ID="txtCashReceived" runat="server" Width="150px" ForeColor="Black"
                                                Font-Bold="True" CssClass="txtBoxnNum" Enabled="False" Visible="false"></asp:TextBox>
                                       
                                    </tr>
                                </tbody>
                            </table>
                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                                TargetControlID="numTxtTotalHalfScheme" ValidChars="0123456789.">
                            </ajaxToolkit:FilteredTextBoxExtender>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
