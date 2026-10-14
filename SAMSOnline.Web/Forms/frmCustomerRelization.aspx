<%@ Page Language="C#" MasterPageFile="~/Forms/PageMaster.master" AutoEventWireup="true"
    CodeFile="frmCustomerRelization.aspx.cs" Inherits="Forms_frmCustomerRelization"
    Title="SAMS >> Bank Transaction" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cphPage">
    <script language="JavaScript" type="text/javascript">

        function ValidateForm() {
            var str;
            str = document.getElementById("<%= txtAmount.ClientID %>").value;
            if (str == null || str.length == 0) {
                alert('Must enter Amount');
                return false;
            }

        }
 
    </script>
    <div id="right_data">
        <table width="75%">
            <tr>
                <td>
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server" RenderMode="Inline">
                        <ContentTemplate>
                            <table>
                                <tbody>
                                    <tr>
                                        <td align="left" colspan="2">
                                            <strong>
                                                <asp:Label ID="lblErrorMsg" runat="server" ForeColor="Red" Font-Bold="True"></asp:Label></strong>
                                        </td>
                                        <td align="left" colspan="1" style="width: 201px">
                                        </td>
                                        <td align="left" colspan="1" style="width: 201px">
                                        </td>
                                        <td align="left" colspan="1" style="width: 201px">
                                        </td>
                                        <td align="left" colspan="1">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left">
                                            <strong>
                                                <asp:Label ID="lblfromLocation" runat="server" Width="94px" Text="Location" CssClass="lblbox"></asp:Label></strong>
                                        </td>
                                        <td align="left" style="width: 201px">
                                            <asp:DropDownList ID="drpDistributor" runat="server" Width="200px" CssClass="DropList"
                                                OnSelectedIndexChanged="drpDistributor_SelectedIndexChanged" AutoPostBack="True">
                                            </asp:DropDownList>
                                        </td>
                                        <td align="left" style="width: 201px">
                                        </td>
                                        <td align="left" style="width: 201px">
                                            <strong>
                                                <asp:Label ID="Label10" runat="server" CssClass="lblbox" Text="Sale Force" Width="100px"></asp:Label></strong>
                                        </td>
                                        <td align="left" style="width: 201px">
                                            <asp:DropDownList ID="DrpDeliveryMan" runat="server" Width="198px" CssClass="DropList"
                                                OnSelectedIndexChanged="DrpAccountDetail_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </td>
                                        <td align="left">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left">
                                            <strong>
                                                <asp:Label ID="Label8" runat="server" CssClass="lblbox" Text="Principal" Width="89px"></asp:Label></strong>
                                        </td>
                                        <td align="left" style="width: 201px">
                                            <asp:DropDownList ID="DrpPrincipal" runat="server" Width="200px" CssClass="DropList"
                                                AutoPostBack="True" OnSelectedIndexChanged="DrpPrincipal_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </td>
                                        <td align="left" style="width: 201px">
                                        </td>
                                        <td align="left" style="width: 201px">
                                            <strong>
                                                <asp:Label ID="Label2" runat="server" CssClass="lblbox" Text="Route" Width="58px"></asp:Label></strong>
                                        </td>
                                        <td align="left" style="width: 201px">
                                            <asp:DropDownList ID="DrpRoute" runat="server" Width="198px" CssClass="DropList"
                                                AutoPostBack="True" OnSelectedIndexChanged="DrpRoute_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </td>
                                        <td align="left">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left">
                                            <strong>
                                                <asp:Label ID="Label1" runat="server" Width="99px" Text="Account Type" CssClass="lblbox"></asp:Label></strong>
                                        </td>
                                        <td align="left" style="width: 201px">
                                            <asp:DropDownList ID="DrpAccountType" runat="server" Width="200px" CssClass="DropList"
                                                OnSelectedIndexChanged="DrpAccountType_SelectedIndexChanged1" AutoPostBack="True">
                                                <asp:ListItem Value="19">Cash Realization</asp:ListItem>
                                                <asp:ListItem Value="22">Bank Deposit</asp:ListItem>
                                                <asp:ListItem Value="23">Income Tax</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td align="left" style="width: 201px">
                                            <strong>
                                                <asp:Label ID="lblDocumentNo" runat="server" Width="25px" Text="" CssClass="lblbox"></asp:Label></strong>
                                        </td>
                                        <td align="left" style="width: 201px">
                                            <strong>
                                                <asp:Label ID="Label4" runat="server" Width="35px" Text="Customer" CssClass="lblbox"></asp:Label></strong>
                                        </td>
                                        <td align="left" style="width: 201px">
                                            <asp:DropDownList ID="DrpCustomer" runat="server" Width="198px" CssClass="DropList"
                                                OnSelectedIndexChanged="DrpCustomer_SelectedIndexChanged" AutoPostBack="True">
                                            </asp:DropDownList>
                                        </td>
                                        <td align="left" rowspan="8">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left">
                                            <strong>
                                                <asp:Label ID="Label7" runat="server" CssClass="lblbox" Text="Account" Width="97px"></asp:Label></strong>
                                        </td>
                                        <td style="width: 201px">
                                            <asp:DropDownList ID="DrpAccountDetail" runat="server" Width="200px" CssClass="DropList"
                                                OnSelectedIndexChanged="DrpAccountDetail_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </td>
                                        <td style="width: 201px">
                                        </td>
                                        <td align="left" colspan="2" rowspan="8" valign="middle">
                                            <asp:Panel ID="Panel1" runat="server" Height="150px" Width="405px" BorderColor="Silver"
                                                BorderStyle="Groove" BorderWidth="1px" ScrollBars="Vertical">
                                                <asp:GridView ID="GrdCredit" runat="server" AutoGenerateColumns="False" BackColor="White"
                                                    BorderColor="White" CssClass="gridRow2" ForeColor="SteelBlue" HorizontalAlign="Center"
                                                    Width="385px" OnRowDeleting="GrdOrder_RowDeleting">
                                                    <PagerSettings FirstPageText="" LastPageText="" Mode="NextPrevious" NextPageText="Next"
                                                        PreviousPageText="Previous" />
                                                    <RowStyle ForeColor="Black" />
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Select">
                                                            <ItemTemplate>
                                                                <asp:CheckBox ID="ChbIsAssigned" runat="server" Width="16px" />
                                                            </ItemTemplate>
                                                            <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" />
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="BILL_NO" HeaderText="Invoice No">
                                                            <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="DOCUMENT_DATE" HeaderText="Invoice Date">
                                                            <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="CURRENT_CREDIT_AMOUNT" HeaderText="Credit Amount" DataFormatString="{0:F2}">
                                                            <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="right" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="DELIVERYMAN_ID" HeaderText="DELIVERYMAN_ID">
                                                            <HeaderStyle CssClass="hiddencol" />
                                                            <ItemStyle CssClass="hiddencol" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="SALE_INVOICE_ID" HeaderText="SALE_INVOICE_ID">
                                                            <HeaderStyle CssClass="hiddencol" />
                                                            <ItemStyle CssClass="hiddencol" />
                                                        </asp:BoundField>
                                                    </Columns>
                                                    <FooterStyle BackColor="White" />
                                                    <PagerStyle BackColor="Transparent" />
                                                    <HeaderStyle CssClass="tblhead" />
                                                    <AlternatingRowStyle BackColor="#F2F2F2" CssClass="GridAlternateRowStyle" ForeColor="#333333" />
                                                </asp:GridView>
                                            </asp:Panel>
                                            &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            &nbsp;&nbsp; <strong>Total Credit:</strong>&nbsp;&nbsp;
                                            <asp:TextBox ID="txtTotalAmount" runat="server" Enabled="false"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left">
                                            <strong>
                                                <asp:Label ID="Label5" runat="server" Width="94px" Text="Chque No" CssClass="lblbox"></asp:Label></strong>
                                        </td>
                                        <td style="width: 201px" valign="top" align="left">
                                            &nbsp;<strong><asp:Label ID="Label3" runat="server" CssClass="lblbox" Text="Slip No"
                                                Width="94px"></asp:Label></strong>
                                        </td>
                                        <td align="left" valign="top" style="width: 201px">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" valign="top">
                                            <asp:TextBox ID="txtChequeNo" runat="server" Width="94px" CssClass="txtBox"></asp:TextBox>
                                        </td>
                                        <td valign="top" align="left" style="width: 201px">
                                            <asp:TextBox ID="txtSlipNo" runat="server" CssClass="txtBox" Width="94px"></asp:TextBox>
                                        </td>
                                        <td align="left" valign="top" style="width: 201px">
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" valign="top">
                                            <strong>
                                                <asp:Label ID="Label6" runat="server" Width="74px" Text="Amount" CssClass="lblbox"></asp:Label></strong>
                                        </td>
                                        <td align="left" valign="top" style="width: 201px">
                                            <strong>
                                                <asp:Label ID="Label9" runat="server" CssClass="lblbox" Text="Remarks" Width="73px"></asp:Label></strong>
                                        </td>
                                        <td align="left" style="width: 201px" valign="top">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" valign="top">
                                            <asp:TextBox ID="txtAmount" runat="server" Width="94px" CssClass="txtBox "></asp:TextBox>
                                        </td>
                                        <td align="left" valign="top" style="width: 201px">
                                            <asp:TextBox ID="txtRemarks" runat="server" CssClass="txtBox " Width="194px"></asp:TextBox>
                                        </td>
                                        <td align="left" valign="top" style="width: 201px">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" colspan="2" valign="top" style="height: 20px">
                                        </td>
                                        <td align="left" valign="top" style="width: 201px; height: 20px">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" colspan="2">
                                        </td>
                                        <td align="left" colspan="1" style="width: 201px">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 36px" align="left">
                                            <asp:Button CssClass="btn" AccessKey="S" ID="Button1" OnClick="Button1_Click" runat="server"
                                                Width="102px" Text="Save"></asp:Button>
                                        </td>
                                        <td style="width: 201px; height: 36px" valign="middle" align="left">
                                            <asp:Button CssClass="btn" AccessKey="C" ID="Button2" runat="server" Width="120px"
                                                Text="Cancel" OnClick="Button2_Click"></asp:Button>
                                            <div style="z-index: 101; left: 487px; width: 100px; position: absolute; top: 308px;
                                                height: 100px">
                                                <asp:Panel ID="Panel21" runat="server">
                                                    <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel2">
                                                        <ProgressTemplate>
                                                            <asp:ImageButton ID="ImageButton1" runat="server" Height="26px" ImageUrl="~/App_Themes/Granite/Images/image003.gif"
                                                                Width="23px" />
                                                            Wait Update
                                                        </ProgressTemplate>
                                                    </asp:UpdateProgress>
                                                </asp:Panel>
                                            </div>
                                        </td>
                                        <td align="left" style="width: 201px; height: 36px" valign="middle">
                                        </td>
                                        <td align="left" style="width: 201px; height: 36px" valign="middle">
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                            &nbsp;
                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                                FilterType="Custom" ValidChars="0123456789." TargetControlID="txtAmount">
                            </ajaxToolkit:FilteredTextBoxExtender>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="DrpRoute" EventName="SelectedIndexChanged">
                            </asp:AsyncPostBackTrigger>
                        </Triggers>
                    </asp:UpdatePanel>
                </td>
            </tr>
        </table>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <table style="border-right: silver thin inset; border-top: silver thin inset; border-left: silver thin inset;
                    width: 650px; border-bottom: silver thin inset">
                    <tbody>
                        <tr>
                            <td align="left" colspan="5" style="height: 20px">
                                <asp:Panel ID="Panel12" runat="server" Height="200px" ScrollBars="Vertical" Width="750px">
                                    <asp:GridView ID="GrdOrder" runat="server" AutoGenerateColumns="False" BackColor="White"
                                        BorderColor="White" CssClass="gridRow2" ForeColor="SteelBlue" HorizontalAlign="Center"
                                        Width="728px" OnRowDeleting="GrdOrder_RowDeleting">
                                        <PagerSettings FirstPageText="" LastPageText="" Mode="NextPrevious" NextPageText="Next"
                                            PreviousPageText="Previous" />
                                        <RowStyle ForeColor="Black" />
                                        <Columns>
                                            <asp:BoundField DataField="CUSTOMER_ID" HeaderText="CUSTOMER_ID">
                                                <HeaderStyle CssClass="hiddencol" />
                                                <ItemStyle CssClass="hiddencol" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="PRINCIPAL_ID" HeaderText="PRINCIPAL_ID">
                                                <HeaderStyle CssClass="hiddencol" />
                                                <ItemStyle CssClass="hiddencol" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="voucher_type_id" HeaderText="voucher_type_id">
                                                <HeaderStyle CssClass="hiddencol" />
                                                <ItemStyle CssClass="hiddencol" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="SKU_HIE_NAME" HeaderText="Principal">
                                                <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="CUSTOMER_NAME" HeaderText="Customer">
                                                <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="BILL_NO" HeaderText="Document No">
                                                <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Ledger_date" HeaderText="Ledger Date">
                                                <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Voucher_no" HeaderText="Voucher No">
                                                <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Balance" HeaderText="Amount" DataFormatString="{0:F2}">
                                                <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Remarks" HeaderText="Remarks">
                                                <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Document_no" HeaderText="Document_no">
                                                <HeaderStyle CssClass="hiddencol" />
                                                <ItemStyle CssClass="hiddencol" />
                                            </asp:BoundField>
                                            <asp:TemplateField HeaderText="Delete">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="btnDelete" runat="server" CommandName="Delete" OnClientClick="javascript:return confirm('Are you sure you want to Delete?');return false;"
                                                        Text="Delete"></asp:LinkButton>
                                                </ItemTemplate>
                                                <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" />
                                            </asp:TemplateField>
                                        </Columns>
                                        <FooterStyle BackColor="White" />
                                        <PagerStyle BackColor="Transparent" />
                                        <HeaderStyle CssClass="tblhead" />
                                        <AlternatingRowStyle BackColor="#F2F2F2" CssClass="GridAlternateRowStyle" ForeColor="#333333" />
                                    </asp:GridView>
                                    &nbsp; &nbsp;
                                </asp:Panel>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
