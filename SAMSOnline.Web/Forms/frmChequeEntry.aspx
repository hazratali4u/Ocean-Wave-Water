<%@ Page Language="C#" MasterPageFile="~/Forms/PageMaster.master" AutoEventWireup="true"
    CodeFile="frmChequeEntry.aspx.cs" Inherits="Forms_frmChequeEntry" Title="SAMS >> Cheque Entry" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
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
        <table width="100%">
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
                                        <td align="left" style="width: 42px">
                                            &nbsp;
                                        </td>
                                        <td align="left" colspan="1" style="width: 74px">
                                        </td>
                                        <td align="left" colspan="1" style="width: 201px">
                                        </td>
                                        <td align="left" colspan="1">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" style="height: 17px">
                                            <strong>
                                                <asp:Label ID="Label12" runat="server" CssClass="lblbox" Text="Cheque Type" Width="84px"></asp:Label></strong>
                                        </td>
                                        <td align="left" style="width: 201px; height: 17px;">
                                            <asp:DropDownList ID="DrpChequeType" runat="server" Width="226px" CssClass="DropList">
                                                <asp:ListItem>Cheque Realized</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td align="left" style="width: 42px; height: 17px;">
                                            &nbsp;
                                        </td>
                                        <td align="left" style="width: 74px; height: 17px;">
                                            <strong>
                                                <asp:Label ID="Label7" runat="server" CssClass="lblbox" Text="Sale Force" 
                                                Width="127px" Height="16px"></asp:Label>
                                            </strong>
                                        </td>
                                        <td align="left" style="width: 201px; height: 17px;">
                                            <asp:DropDownList ID="DrpDeliveryMan" runat="server" Width="240px" CssClass="DropList"
                                                OnSelectedIndexChanged="DrpCustomer_SelectedIndexChanged" AutoPostBack="True">
                                            </asp:DropDownList>
                                        </td>
                                        <td align="left" style="height: 17px">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" style="height: 17px">
                                            <strong>
                                                <asp:Label ID="lblfromLocation" runat="server" Width="94px" Text="Location" CssClass="lblbox"></asp:Label></strong>
                                        </td>
                                        <td align="left" style="width: 201px; height: 17px">
                                            <asp:DropDownList ID="drpDistributor" runat="server" Width="226px" CssClass="DropList"
                                                OnSelectedIndexChanged="drpDistributor_SelectedIndexChanged" AutoPostBack="True">
                                            </asp:DropDownList>
                                        </td>
                                        <td align="left" style="width: 42px; height: 17px">
                                            &nbsp;
                                        </td>
                                        <td align="left" style="width: 74px; height: 17px">
                                            <strong>
                                                <asp:Label ID="Label11" runat="server" CssClass="lblbox" Text="Route" 
                                                Width="125px" Height="16px"></asp:Label>
                                            </strong>
                                        </td>
                                        <td align="left" style="width: 201px; height: 17px">
                                            <asp:DropDownList ID="DrpRoute" runat="server" Width="240px" CssClass="DropList"
                                                AutoPostBack="True" OnSelectedIndexChanged="DrpRoute_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </td>
                                        <td align="left" style="height: 17px">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" style="height: 17px">
                                            <strong>
                                                <asp:Label ID="Label8" runat="server" CssClass="lblbox" Text="Principal" Width="89px"></asp:Label></strong>
                                        </td>
                                        <td align="left" style="width: 201px; height: 17px">
                                            <asp:DropDownList ID="DrpPrincipal" runat="server" Width="226px" CssClass="DropList"
                                                AutoPostBack="True" OnSelectedIndexChanged="DrpPrincipal_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </td>
                                        <td align="left" style="width: 42px; height: 17px">
                                            &nbsp;
                                        </td>
                                        <td align="left" style="width: 74px; height: 17px">
                                            <strong>
                                                <asp:Label ID="Label4" runat="server" CssClass="lblbox" Text="Customer" 
                                                Width="118px"></asp:Label>
                                            </strong>
                                        </td>
                                        <td align="left" style="width: 201px; height: 17px">
                                            <asp:DropDownList ID="DrpCustomer" runat="server" Width="240px" CssClass="DropList"
                                                OnSelectedIndexChanged="DrpCustomer_SelectedIndexChanged" AutoPostBack="True">
                                            </asp:DropDownList>
                                        </td>
                                        <td align="left" style="height: 17px">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left">
                                            <strong>
                                                <asp:Label ID="Label10" runat="server" CssClass="lblbox" Text="Status" Width="86px"></asp:Label></strong>
                                        </td>
                                        <td align="left" style="width: 201px">
                                            <asp:DropDownList ID="DrpStatus" runat="server" Width="226px" CssClass="DropList"
                                                AutoPostBack="True" OnSelectedIndexChanged="DrpStatus_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </td>
                                        <td align="left" rowspan="11" style="width: 42px">
                                            &nbsp;
                                        </td>
                                        <td align="right" colspan="2" rowspan="11">
                                            <asp:Panel ID="Panel1" runat="server" BorderColor="Silver" BorderStyle="Groove" BorderWidth="1px"
                                                Height="200px" ScrollBars="Vertical" Width="320px">
                                                <asp:GridView ID="GrdCredit" runat="server" AutoGenerateColumns="False" BackColor="White"
                                                    BorderColor="White" CssClass="gridRow2" ForeColor="SteelBlue" HorizontalAlign="Center"
                                                    Width="304px">
                                                    <PagerSettings FirstPageText="" LastPageText="" Mode="NextPrevious" NextPageText="Next"
                                                        PreviousPageText="Previous" />
                                                    <RowStyle ForeColor="Black" />
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Select">
                                                            <ItemTemplate>
                                                                <asp:CheckBox ID="ChbIsAssigned" runat="server" Width="14px" />
                                                            </ItemTemplate>
                                                            <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" />
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="SALE_INVOICE_ID" HeaderText="Invoice No">
                                                            <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="DOCUMENT_DATE" HeaderText="Invoice Date">
                                                            <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="CURRENT_CREDIT_AMOUNT" DataFormatString="{0:F2}" HeaderText="Credit Amount">
                                                            <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="DELIVERYMAN_ID" HeaderText="DELIVERYMAN_ID">
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
                                        </td>
                                        <td align="left" rowspan="11">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left">
                                            <strong>
                                                <asp:Label ID="Label14" runat="server" CssClass="lblbox" Text="Deposit Account" Width="98px"></asp:Label></strong>
                                        </td>
                                        <td align="left">
                                            <asp:DropDownList ID="DrpBankAccount" runat="server" Width="226px" CssClass="DropList"
                                                AutoPostBack="True" OnSelectedIndexChanged="DrpStatus_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left">
                                            <strong>
                                                <asp:Label ID="Label5" runat="server" Width="94px" Text="Chque No" CssClass="lblbox"></asp:Label></strong>
                                        </td>
                                        <td align="left">
                                            <strong>
                                                <asp:Label ID="Label3" runat="server" CssClass="lblbox" Text="Bank Name" Width="94px"></asp:Label></strong>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left">
                                            <asp:TextBox ID="txtChequeNo" runat="server" Width="94px" CssClass="txtBox"></asp:TextBox>
                                        </td>
                                        <td valign="top" align="left">
                                            <asp:TextBox ID="txtBankName" runat="server" CssClass="txtBox" Width="192px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" valign="top">
                                            <strong>
                                                <asp:Label ID="Label13" runat="server" CssClass="lblbox" Text="Remarks" Width="94px"></asp:Label></strong>
                                        </td>
                                        <td align="left" style="width: 201px" valign="top">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" colspan="2" valign="top">
                                            <asp:TextBox ID="txtRemarks" runat="server" CssClass="txtBox" Width="298px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" valign="top">
                                            <strong>
                                                <asp:Label ID="Label6" runat="server" Width="74px" Text="Chq Amount" CssClass="lblbox"></asp:Label></strong>
                                        </td>
                                        <td valign="top" align="left" style="width: 201px">
                                            <strong>
                                                <asp:Label ID="Label9" runat="server" CssClass="lblbox" Text="Cheque Date" Width="73px"></asp:Label></strong>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" valign="top">
                                            <asp:TextBox ID="txtAmount" runat="server" Width="94px" CssClass="txtBox "></asp:TextBox>
                                        </td>
                                        <td align="left" valign="top" style="width: 201px">
                                            <asp:TextBox ID="txtStartDate" runat="server" CssClass="txtBox " Width="132px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" valign="top">
                                            <strong>
                                                <asp:Label ID="Label2" runat="server" CssClass="lblbox" Text="Slip No" Width="96px"></asp:Label></strong>
                                        </td>
                                        <td align="left" style="width: 201px" valign="top">
                                            <strong>
                                                <asp:Label ID="Label1" runat="server" CssClass="lblbox" Text="Recevied Date" Width="100px"></asp:Label></strong>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" valign="top">
                                            <asp:TextBox ID="txtSlipNo" runat="server" CssClass="txtBox " Width="94px"></asp:TextBox>
                                        </td>
                                        <td align="left" style="width: 201px" valign="top">
                                            <asp:TextBox ID="txtReceivedDate" runat="server" CssClass="txtBox " Width="128px"
                                                ReadOnly="True"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" valign="top">
                                            <asp:Button CssClass="btn" AccessKey="S" ID="Button1" OnClick="Button1_Click" runat="server"
                                                Width="102px" Font-Size="8pt" Text="Save"></asp:Button>
                                        </td>
                                        <td align="left" valign="top" style="width: 201px">
                                            <asp:Button CssClass="btn" AccessKey="C" ID="Button2" runat="server" Width="120px"
                                                Font-Size="8pt" Text="Cancel" OnClick="Button2_Click"></asp:Button>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" FilterType="Custom"
                                ValidChars="0123456789." TargetControlID="txtAmount">
                            </cc1:FilteredTextBoxExtender>
                            <cc1:MaskedEditExtender ID="MaskedEditExtender2" runat="server" Mask="99/99/9999"
                                MaskType="Date" TargetControlID="txtStartDate">
                            </cc1:MaskedEditExtender>
                            <asp:HiddenField ID="HFChqueProcessId" runat="server" />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
        </table>
        <table width="100%">
            <tr>
                <td>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <table style="border-right: silver thin inset; border-top: silver thin inset; border-left: silver thin inset;
                                width: 650px; border-bottom: silver thin inset">
                                <tbody>
                                    <tr>
                                        <td align="left" colspan="5" style="height: 20px">
                                            <asp:Panel ID="Panel12" runat="server" Height="200px" ScrollBars="Vertical" Width="750px">
                                                <table style="border-right: silver thin inset; border-top: silver thin inset; border-left: silver thin inset;
                                                    border-bottom: silver thin inset; background-color: silver" width="100%">
                                                    <tbody>
                                                        <tr>
                                                            <td align="left" style="height: 21px">
                                                                <strong>
                                                                    <asp:Label ID="Label110" runat="server" Text="Select Searching Type" Width="154px"></asp:Label></strong>
                                                            </td>
                                                            <td align="left" style="width: 170px; height: 21px">
                                                                <asp:DropDownList ID="ddSearchType" runat="server" CssClass="DropList" Width="200px">
                                                                    <asp:ListItem Value="CHEQUE_NO">All Records</asp:ListItem>
                                                                    <asp:ListItem Value="CUSTOMER_NAME">Customer</asp:ListItem>
                                                                    <asp:ListItem Value="BANK_NAME">Bank Name</asp:ListItem>
                                                                    <asp:ListItem Value="SlipNo">Slip No</asp:ListItem>
                                                                    <asp:ListItem Value="account_name">Deposit Account </asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td align="left" style="width: 224px; height: 21px">
                                                                <asp:TextBox ID="txtSeach" runat="server" CssClass="txtBox " Width="200px"></asp:TextBox>
                                                            </td>
                                                            <td align="left" style="width: 250px; height: 21px">
                                                                <asp:Button CssClass="btn" ID="Button21" runat="server" Font-Size="8pt" OnClick="Button21_Click"
                                                                    Text="Filter" Width="85px" />
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                                <asp:GridView ID="GrdOrder" runat="server" AutoGenerateColumns="False" BackColor="White"
                                                    BorderColor="White" CssClass="gridRow2" ForeColor="SteelBlue" HorizontalAlign="Center"
                                                    OnRowDeleting="GrdOrder_RowDeleting" Width="100%" OnRowEditing="GrdOrder_RowEditing">
                                                    <PagerSettings FirstPageText="" LastPageText="" Mode="NextPrevious" NextPageText="Next"
                                                        PreviousPageText="Previous" />
                                                    <RowStyle ForeColor="Black" />
                                                    <Columns>
                                                        <asp:BoundField DataField="CHEQUE_PROCESS_ID" HeaderText="CHEQUE_PROCESS_ID">
                                                            <HeaderStyle CssClass="hiddencol" />
                                                            <ItemStyle CssClass="hiddencol" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="CUSTOMER_ID" HeaderText="CUSTOMER_ID">
                                                            <HeaderStyle CssClass="hiddencol" />
                                                            <ItemStyle CssClass="hiddencol" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="CUSTOMER_NAME" HeaderText="Customer">
                                                            <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Left" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="CHEQUE_NO" HeaderText="Chq. No">
                                                            <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Left" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="BANK_NAME" HeaderText="Bank Name">
                                                            <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="CHEQUE_DATE" HeaderText="Chq.Date">
                                                            <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="RECEIVED_DATE" HeaderText="Received Date">
                                                            <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="DEPOSIT_DATE" HeaderText="Deposit Date">
                                                            <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="CHEQUE_AMOUNT" DataFormatString="{0:F2}" HeaderText="Chq.Amount">
                                                            <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Right" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="SlipNo" HeaderText="Slip No">
                                                            <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Remarks" HeaderText="Remarks">
                                                            <HeaderStyle CssClass="hiddencol" />
                                                            <ItemStyle CssClass="hiddencol" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="area_id" HeaderText="area_id">
                                                            <HeaderStyle CssClass="hiddencol" />
                                                            <ItemStyle CssClass="hiddencol" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="account_name" HeaderText="Deposit Account">
                                                            <ControlStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" />
                                                            <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="account_head_id" HeaderText="account_head_id">
                                                            <HeaderStyle CssClass="hiddencol" />
                                                            <ItemStyle CssClass="hiddencol" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="DeliveryManID" HeaderText="DeliveryManID">
                                                            <HeaderStyle CssClass="hiddencol" />
                                                            <ItemStyle CssClass="hiddencol" />
                                                        </asp:BoundField>
                                                        <asp:CommandField HeaderText="Edit" ShowEditButton="True">
                                                            <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center" />
                                                        </asp:CommandField>
                                                    </Columns>
                                                    <FooterStyle BackColor="White" />
                                                    <PagerStyle BackColor="Transparent" />
                                                    <HeaderStyle CssClass="tblhead" />
                                                    <AlternatingRowStyle BackColor="#F2F2F2" CssClass="GridAlternateRowStyle" ForeColor="#333333" />
                                                </asp:GridView>
                                            </asp:Panel>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
