<%@ Page Title="Stock Issue/Return" Language="C#" MasterPageFile="~/Forms/PageMaster.master"
    AutoEventWireup="true" CodeFile="frmStockIssueReturn.aspx.cs" Inherits="Forms_frmStockIssueReturn" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphPage" runat="Server">
<script language="javascript" type="text/javascript">

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

        return true;
    }

    function SearchSKUCode() {
        var str = document.getElementById("<%= lstCode.ClientID %>").value;
        var stroption = document.getElementById("<%= txtskuCode.ClientID %>").value;

        if (str.length > 0) {
            document.getElementById("<%= txtskuCode.ClientID %>").value = str.substring(0, str.indexOf('-'));
            document.getElementById("<%= txtskuName.ClientID %>").value = str.substring(str.indexOf('-') + 1, str.indexOf(':'));
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
            document.getElementById("<%= Panel3.ClientID %>").className = "hiddencol";

            document.getElementById("<%= txtQuantity.ClientID %>").focus();
        }
    }

    function SearcSKUList(e) {
        var l = document.getElementById('<%= lstCode.ClientID %>');
        var tb = document.getElementById('<%= txtskuCode.ClientID %>');
        if (e.keyCode == 27) {
            
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

</script>
    <div id="right_data">

    <table width="100%">
            <tr>
                <td>
                    <div style="left: 120px; position: absolute; top: 150px;">
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
                    </div>
                </td>
            </tr>
        </table>


        <table width="100%">
            <tr>
                <td>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <table>
                                <tr>
                                    <td align="left" valign="top">
                                        <strong>
                                            <asp:Label ID="lblDocumentNo" runat="server" Text="Transaction No" Width="100px"></asp:Label></strong>
                                    </td>
                                    <td align="left" colspan="2" valign="top">
                                        <asp:DropDownList ID="drpDocumentNo" runat="server" AutoPostBack="True" TabIndex="4" OnSelectedIndexChanged="drpDocumentNo_SelectedIndexChanged"
                                            Width="200px" >
                                        </asp:DropDownList>
                                    </td>
                                    <td align="left" colspan="1" valign="top">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <strong>
                                            <asp:Label ID="lblfromLocation" runat="server" Width="120px" Text="Route"
                                                CssClass="lblbox"></asp:Label></strong>
                                    </td>
                                    <td style="height: 25px; width: 238px;" align="left">
                                        <asp:DropDownList ID="DrpRoute" runat="server" Width="200px" CssClass="DropList" TabIndex="1"
                                            AutoPostBack="True">
                                            <%--    OnSelectedIndexChanged="DrpRoute_SelectedIndexChanged"--%>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <strong>
                                            <asp:Label ID="Label5" runat="server" Width="94px" Text="Delivery Man" CssClass="lblbox"></asp:Label></strong>
                                    </td>
                                    <td style="height: 25px; width: 238px;" align="left">
                                        <asp:DropDownList ID="DrpDeliveryMan" runat="server" Width="200px" CssClass="DropList" TabIndex="2">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <strong>
                                            <asp:Label ID="Label1" runat="server" Width="94px" Text="Principal" CssClass="lblbox"></asp:Label></strong>
                                    </td>
                                    <td style="height: 25px; width: 238px;" align="left">
                                        <asp:DropDownList ID="DrpPrincipal" runat="server" Width="200px" TabIndex="3"
                                            CssClass="DropList" onselectedindexchanged="DrpPrincipal_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <strong>
                                            <asp:Label ID="lbltoLocation" runat="server" Width="94px" Text="Location" CssClass="lblbox"></asp:Label></strong>
                                    </td>
                                    <td style="height: 25px; width: 238px;" align="left">
                                        <asp:DropDownList ID="drpDistributor" runat="server" Width="200px" CssClass="DropList" TabIndex="0"
                                            AutoPostBack="True" 
                                            onselectedindexchanged="drpDistributor_SelectedIndexChanged">
                                            <%--OnSelectedIndexChanged="drpDistributor_SelectedIndexChanged"--%>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                            </table>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
        </table>


        <table width="100%">
            <tr>
                <td style="height: 173px;" valign="top">
                    <asp:Panel ID="Panel5" runat="server" DefaultButton="btnSave">
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                            <ContentTemplate>
                                <table style="border-right: silver thin inset; border-top: silver thin inset; border-left: silver thin inset;
                                    width: 650px; border-bottom: silver thin inset">
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
                                                    Text="Issued"></asp:Label>
                                            </td>
                                            <td style="height: 16px" class="tblhead">
                                                <asp:Label ID="lblquantity" runat="server" Width="62px" Height="16px" Font-Bold="True"
                                                    Text="Return"></asp:Label>
                                            </td>
                                            <td style="height: 16px" class="tblhead">
                                                <asp:Label ID="Label2" runat="server" Width="100%" Height="16px" ForeColor="White"
                                                    Font-Bold="True" Text="Sold"></asp:Label>
                                            </td>
                                            <td style="height: 16px" class="tblhead">
                                                <asp:Label ID="Label4" runat="server" Width="100%" Height="16px" ForeColor="White"
                                                    Font-Bold="True" Text="Add SKU"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:TextBox ID="txtskuCode" onkeyup="SearcSKUList(event)" runat="server" Width="74px" TabIndex="5"
                                                    CssClass="txtBox"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtskuName" runat="server" Width="181px" Font-Bold="True" CssClass="txtBox" TabIndex="6"
                                                    Enabled="False"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtQuantity" onfocus="SearchSKUCode()" runat="server" Width="55px" TabIndex="7"
                                                    CssClass="txtBox " ontextchanged="txtQuantity_TextChanged"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtReturn" onfocus="SearchSKUCode()" runat="server" TabIndex="8"
                                                    Width="62px" ontextchanged="txtReturn_TextChanged" AutoPostBack="True"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtSold" onfocus="SearchSKUCode()" runat="server" Width="72px" TabIndex="9"
                                                    CssClass="txtBoxnNum" Enabled="False"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:Button AccessKey="A" ID="btnSave" runat="server" Width="100px" Font-Size="8pt" TabIndex="10"
                                                    Text="Add Sku" ValidationGroup="vg" CssClass="btn" onclick="btnSave_Click"></asp:Button>
                                                <%--OnClick="btnSave_Click"--%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" colspan="7">
                                                <asp:Panel ID="Panel1" runat="server" Width="640px" Height="130px" ScrollBars="Vertical"
                                                    BorderColor="Silver" BorderStyle="Groove" BorderWidth="1px">
                                                    <asp:GridView ID="GrdPurchase" runat="server" ForeColor="SteelBlue" CssClass="gridRow2"
                                                        BackColor="White" HorizontalAlign="Center" AutoGenerateColumns="False" BorderColor="White"
                                                        ShowHeader="False" onrowdeleting="GrdPurchase_RowDeleting1" 
                                                        onrowediting="GrdPurchase_RowEditing">
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

                                                            <%-- <asp:BoundField DataField="UNIT_PRICE" HeaderText="PRICE" DataFormatString="{0:F2}">
                                                                <ItemStyle HorizontalAlign="Right" BorderColor="Silver" BorderWidth="2px" BorderStyle="Solid"
                                                                    Width="65px"></ItemStyle>
                                                            </asp:BoundField>--%>
                                                            
                                                            <asp:BoundField DataField="SED_AMOUNT" HeaderText="SED_AMOUNT">
                                                                <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" Width="70px" />
                                                            </asp:BoundField>

                                                            <asp:BoundField DataField="Amount" HeaderText="Amount" DataFormatString="{0:F2}">
                                                                <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Right"
                                                                    Width="80px" />
                                                            </asp:BoundField>
                                                           <%-- <asp:BoundField DataField="QUANTITY_CTN" HeaderText="QUANTITY_CTN">
                                                                <HeaderStyle CssClass="hiddencol" />
                                                                <ItemStyle CssClass="hiddencol" />
                                                            </asp:BoundField>--%>
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
                                    
                                    <tr>
                                        <td style="width: 100px; height: 21px">
                                            <asp:Button ID="btnSaveOrder" runat="server" AccessKey="S" CssClass="btn" 
                                                Font-Size="8pt" TabIndex="101" Text="Save Order" 
                                                Width="110px" onclick="btnSaveOrder_Click" />
                                            <%-- OnClick="btnSaveOrder_Click"--%>
                                        </td>
                                        <td style="width: 100px; height: 21px">
                                            <asp:Button ID="btnCancel" runat="server" AccessKey="H" CssClass="btn" 
                                                Font-Size="8pt" TabIndex="102" Text="Cancel" Width="110px" />
                                            <%--OnClick="Button2_Click"--%>
                                        </td>
                                    </tr>
                                </table>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </asp:Panel>
    &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
                </td>
            </tr>
        </table>
    </div>


</asp:Content>
