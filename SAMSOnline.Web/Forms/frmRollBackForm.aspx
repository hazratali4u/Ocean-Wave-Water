<%@ Page Language="C#" MasterPageFile="~/Forms/PageMaster.master" AutoEventWireup="true" CodeFile="frmRollBackForm.aspx.cs" Inherits="Forms_frmRollBackForm" Title="SAMS >> Rollback Transaction" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cphPage">
    <div id="right_data">
        <table width="100%">
            <tr>
                <td>
                    <div style="z-index: 101; left: 534px; width: 100px; position: absolute; top: 256px;
                        height: 100px">
                        <asp:Panel ID="Panel2" runat="server">
                            <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel2">
                                <ProgressTemplate>
                                    <asp:ImageButton ID="ImageButton1" runat="server" Height="26px" ImageUrl="~/App_Themes/Granite/Images/image003.gif"
                                        Width="27px" />
                                    Wait Update.......
                                </ProgressTemplate>
                            </asp:UpdateProgress>
                        </asp:Panel>
                    </div>
                </td>
                <td>
                    <asp:UpdatePanel id="UpdatePanel1" runat="server">
                        <contenttemplate>
<TABLE><TR><TD align=left>
<strong><asp:Label id="Label2" runat="server" Width="150px" Text="Transaction Type" CssClass="lblbox"></asp:Label></strong></TD><TD style="HEIGHT: 25px" align=left><asp:DropDownList id="DrpDocumentType" runat="server" Width="200px" CssClass="DropList" AutoPostBack="True" OnSelectedIndexChanged="DrpDocumentType_SelectedIndexChanged"><asp:ListItem Value="0">Order Entry</asp:ListItem>
<asp:ListItem Value="1">Sale Invoice</asp:ListItem>
    <asp:ListItem Value="2">Sale Return</asp:ListItem>
    <asp:ListItem Value="3">Realized Cheque</asp:ListItem>
</asp:DropDownList>&nbsp;</TD></TR><TR><TD align=left>
<strong><asp:Label id="lbltoLocation" runat="server" Width="94px" Text="Location" CssClass="lblbox"></asp:Label></strong></TD><TD style="HEIGHT: 25px" align=left><asp:DropDownList id="drpDistributor" runat="server" Width="200px" CssClass="DropList" AutoPostBack="True" OnSelectedIndexChanged="drpDistributor_SelectedIndexChanged"></asp:DropDownList></TD></TR><TR><TD align=left>
<strong><asp:Label id="Label1" runat="server" Width="94px" Text="Principal" CssClass="lblbox"></asp:Label></strong></TD><TD style="HEIGHT: 25px" align=left><asp:DropDownList id="DrpPrincipal" runat="server" Width="200px" CssClass="DropList" AutoPostBack="True" OnSelectedIndexChanged="DrpPrincipal_SelectedIndexChanged"></asp:DropDownList></TD></TR><TR><TD align=left style="height: 25px">
<strong><asp:Label id="Label6" runat="server" Width="94px" Text="Sale Force" CssClass="lblbox"></asp:Label></strong></TD><TD style="HEIGHT: 25px" align=left><asp:DropDownList id="DrpOrderBooker" runat="server" Width="200px" CssClass="DropList"></asp:DropDownList></TD></TR>
    <tr>
        <td align="left">
            <strong><asp:Label ID="Label3" runat="server" CssClass="lblbox" Text="Legend" Width="94px"></asp:Label></strong></td>
        <td align="left" style="height: 25px"><asp:DropDownList id="DrpLenged" runat="server" Width="200px" CssClass="DropList">
        </asp:DropDownList></td>
    </tr>
    <TR><TD align=right><asp:Button CssClass="btn" id="btnGetOrder" onclick="btnGetOrder_Click" runat="server" Width="100px" Font-Size="8pt" Text="Get Data" /></TD><TD style="HEIGHT: 25px" align=left>
                                        <asp:Button CssClass="btn" ID="btnPost" runat="server" Font-Size="8pt" Text="Rollback"
                                            Width="128px" OnClick="btnPost_Click" /></TD></TR>
    <tr>
        <td align="right" colspan="2">
            &nbsp;</td>
    </tr>
</TABLE>
</contenttemplate>
                    </asp:UpdatePanel>
                </td>                
            </tr>
        </table>
    <table width="100%">
        <tr>
            <td>
                <asp:UpdatePanel id="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <table style="border-right: silver thin inset; border-top: silver thin inset; border-left: silver thin inset;
                            width: 650px; border-bottom: silver thin inset">
                            <tbody>
                                <tr>
                                    <td align="left" colspan="5" style="height: 21px">
                                        <asp:Panel ID="Panel1" runat="server" Height="250px" ScrollBars="Vertical" Width="710px">
                                            <asp:GridView ID="GrdOrder" runat="server" AutoGenerateColumns="False" BackColor="White"
                                                BorderColor="White" CssClass="gridRow2" ForeColor="SteelBlue" HorizontalAlign="Center"
                                                Width="700px">
                                                <PagerSettings FirstPageText="" LastPageText="" Mode="NextPrevious" NextPageText="Next"
                                                    PreviousPageText="Previous" />
                                                <FooterStyle BackColor="White" />
                                                <RowStyle ForeColor="Black" />
                                                <Columns>
                                                    <asp:BoundField DataField="CUSTOMER_ID" HeaderText="Customer Id">
                                                        <HeaderStyle CssClass="hiddencol" />
                                                        <ItemStyle CssClass="hiddencol" />
                                                    </asp:BoundField>
                                                    <asp:TemplateField HeaderText="Select">
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="ChbInvoice" runat="server" />
                                                        </ItemTemplate>
                                                        <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" />
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="CUSTOMER_CODE" HeaderText="Code">
                                                        <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Left" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="CUSTOMER_NAME" HeaderText="Name">
                                                        <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Left" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Document_Id" HeaderText="Document Id">
                                                        <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="DOCUMENT_DATE" HeaderText="Document Date">
                                                        <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="TOTAL_AMOUNT" DataFormatString="{0:F2}" HeaderText="Gross Amount">
                                                        <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="DISCOUNT_AMOUNT" DataFormatString="{0:F2}" HeaderText="Discount">
                                                        <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="SCHEME_AMOUNT" DataFormatString="{0:F2}" HeaderText="Scheme">
                                                        <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="GST_AMOUNT" DataFormatString="{0:F2}" HeaderText="GST Amount">
                                                        <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="TOTAL_NET_AMOUNT" DataFormatString="{0:F2}" HeaderText="Net Amount">
                                                        <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Document_Id2" HeaderText="Document_Id2">
                                                        <HeaderStyle CssClass="hiddencol" />
                                                        <ItemStyle CssClass="hiddencol" />
                                                    </asp:BoundField>
                                                </Columns>
                                                <PagerStyle BackColor="Transparent" />
                                                <HeaderStyle CssClass="tblhead" />
                                                <AlternatingRowStyle BackColor="#F2F2F2" CssClass="GridAlternateRowStyle" ForeColor="#333333" />
                                            </asp:GridView><asp:GridView ID="GrdCheque" runat="server" AutoGenerateColumns="False" BackColor="White"
                                                BorderColor="White" CssClass="gridRow2" ForeColor="SteelBlue" HorizontalAlign="Center"
                                                Width="700px" Visible="False">
                                                <PagerSettings FirstPageText="" LastPageText="" Mode="NextPrevious" NextPageText="Next"
                                                    PreviousPageText="Previous" />
                                                <RowStyle ForeColor="Black" />
                                                <Columns>
                                                    <asp:BoundField DataField="CHEQUE_PROCESS_ID" HeaderText="CHEQUE_PROCESS_ID">
                                                        <HeaderStyle CssClass="hiddencol" />
                                                        <ItemStyle CssClass="hiddencol" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="CUSTOMER_ID" HeaderText="Customer Id">
                                                        <HeaderStyle CssClass="hiddencol" />
                                                        <ItemStyle CssClass="hiddencol" />
                                                    </asp:BoundField>
                                                    <asp:TemplateField HeaderText="Select">
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="ChbInvoice" runat="server" />
                                                        </ItemTemplate>
                                                        <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" />
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="CUSTOMER_CODE" HeaderText="Code">
                                                        <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Left" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="CUSTOMER_NAME" HeaderText="Name">
                                                        <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Left" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Voucher_No" HeaderText="Voucher No" >
                                                        <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="CHEQUE_NO" HeaderText="Cheque No">
                                                        <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="CHEQUE_DATE" HeaderText="Cheque Date">
                                                        <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="CHEQUE_AMOUNT" DataFormatString="{0:F2}" HeaderText="Cheque Amount">
                                                        <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center" />
                                                    </asp:BoundField>
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

