<%@ Page Language="C#" MasterPageFile="~/Forms/PageMaster.master" AutoEventWireup="true"
    CodeFile="frmOrderEntryStep1.aspx.cs" Inherits="Forms_frmOrderEntryStep1" Title="SAMS >> Order/Invoice" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cphPage">
    <div id="right_data">
        <table width="100%">
            <tr>
                <td>
                    <div style="z-index: 101; left: 484px; width: 100px; position: absolute; top: 236px;
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
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <table>
                                <tr>
                                    <td align="left">
                                        <strong>
                                            <asp:Label ID="Label2" runat="server" Width="120px" Text="Transaction Type" CssClass="lblbox"></asp:Label></strong>
                                    </td>
                                    <td style="height: 25px; width: 238px;" align="left">
                                        <asp:DropDownList ID="DrpDocumentType" runat="server" Width="200px" AutoPostBack="True"
                                            OnSelectedIndexChanged="DrpDocumentType_SelectedIndexChanged">
                                            <%--<asp:ListItem Value="0">Order Entry</asp:ListItem>--%>
                                            <asp:ListItem Value="1">Sale Return</asp:ListItem>
                                            <%--<asp:ListItem Value="2">Empty In</asp:ListItem>--%>
                                            <asp:ListItem Value="3">Spot Sale</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <strong>
                                            <asp:Label ID="lbltoLocation" runat="server" Width="94px" Text="Location" CssClass="lblbox"></asp:Label></strong>
                                    </td>
                                    <td style="height: 25px; width: 238px;" align="left">
                                        <asp:DropDownList ID="drpDistributor" runat="server" Width="200px" CssClass="DropList"
                                            AutoPostBack="True" OnSelectedIndexChanged="drpDistributor_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <strong>
                                            <asp:Label ID="lblfromLocation" runat="server" Width="120px" Text="Customer Route"
                                                CssClass="lblbox" Visible ="false"></asp:Label></strong>
                                                 <strong>
                                            <asp:Label ID="lblDAy" runat="server" Width="120px" Text="Day"
                                                CssClass="lblbox"></asp:Label></strong>
                                    </td>
                                    <td style="height: 25px; width: 238px;" align="left">
                                        <asp:DropDownList ID="DrpRoute" runat="server" Width="200px" CssClass="DropList"
                                            AutoPostBack="True" OnSelectedIndexChanged="DrpRoute_SelectedIndexChanged" Visible="false">
                                        </asp:DropDownList>


                                        <asp:DropDownList ID="drpDayofWeak" runat="server" Width="200px" CssClass="DropList"
                                                AutoPostBack="True" OnSelectedIndexChanged="drpDayofWeak_SelectedIndexChanged">
                                              
                                            </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <strong>
                                            <asp:Label ID="Label6" runat="server" Width="94px" Text="Order Booker" CssClass="lblbox" Visible="false"></asp:Label></strong>
                                    </td>
                                    <td >
                                        <asp:DropDownList ID="DrpOrderBooker" runat="server" Width="200px" CssClass="DropList" Visible ="false" >
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <strong>
                                            <asp:Label ID="Label5" runat="server" Width="94px" Text="Sale Force" CssClass="lblbox"></asp:Label></strong>
                                    </td>
                                    <td style="height: 25px; width: 238px;" align="left">
                                        <asp:DropDownList ID="DrpDeliveryMan" runat="server" Width="200px" CssClass="DropList">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <strong>
                                            <asp:Label ID="Label1" runat="server" Width="94px" Text="Principal" CssClass="lblbox"></asp:Label></strong>
                                    </td>
                                    <td style="height: 25px; width: 238px;" align="left">
                                        <asp:DropDownList ID="DrpPrincipal" runat="server" Width="200px" CssClass="DropList">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <strong>
                                            <asp:Label ID="Label7" runat="server" CssClass="lblbox" Text="Working Date" Width="94px"></asp:Label></strong>
                                    </td>
                                    <td align="left" style="width: 238px; height: 25px">
                                        <asp:TextBox ID="txtToDate" runat="server" CssClass="txtBox" MaxLength="10" Width="180px"></asp:TextBox><asp:ImageButton
                                            ID="ImgBntToDate" runat="server" ImageUrl="~/App_Themes/Granite/Images/date.gif" />
                                        <cc1:CalendarExtender ID="CalendarExtender2" runat="server" EnableViewState="False"
                                            Format="dd-MMM-yyyy" PopupButtonID="ImgBntToDate" TargetControlID="txtToDate">
                                        </cc1:CalendarExtender>
                                        <%@register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1"%>
                                     
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <strong>
                                            <asp:Label ID="Label4" runat="server" CssClass="lblbox" Text="Quantity Type" Width="94px"
                                                Visible="false"></asp:Label><strong>
                                    </td>
                                    <td align="left" style="height: 25px;">
                                        <asp:RadioButtonList ID="RbUnitType" runat="server" RepeatDirection="Horizontal"
                                            Width="300px" Visible="false">
                                            <asp:ListItem Selected="True">Quantity In Unit</asp:ListItem>
                                            <asp:ListItem>Quantity In Ctns</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Button ID="btnGetOrder" OnClick="btnGetOrder_Click" runat="server" Width="100px"
                                            Font-Size="8pt" Text="Get Order" CssClass="btn" />
                                    </td>
                                    <td style="height: 25px; width: 238px;" align="left">
                                        <asp:Button ID="btnNext" OnClick="btnNext_Click" runat="server" Width="100px" Font-Size="8pt"
                                            Text="Next" CssClass="btn"></asp:Button>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" colspan="2">
                                        <asp:GridView ID="GrdFreeSKU" runat="server" AutoGenerateColumns="False" BackColor="White"
                                            BorderColor="White" CssClass="gridRow2" ForeColor="Red" Height="57px" HorizontalAlign="Center"
                                            Visible="False" Width="100%">
                                            <PagerSettings FirstPageText="" LastPageText="" Mode="NextPrevious" NextPageText="Next"
                                                PreviousPageText="Previous" />
                                            <RowStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" ForeColor="Black" />
                                            <Columns>
                                                <asp:BoundField DataField="SALE_ORDER_ID" HeaderText="Order Id">
                                                    <HeaderStyle HorizontalAlign="Left" />
                                                    <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Left" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="SKU_Code" HeaderText="SKU Code">
                                                    <HeaderStyle HorizontalAlign="Left" />
                                                    <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Left"
                                                        Width="80px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="QUANTITY_UNIT" HeaderText="Order Qty">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="BALANCE" HeaderText="Stock">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center"
                                                        Width="50px" />
                                                </asp:BoundField>
                                            </Columns>
                                            <FooterStyle BackColor="White" />
                                            <PagerStyle BackColor="Transparent" />
                                            <HeaderStyle BackColor="Red" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px"
                                                ForeColor="Black" />
                                        </asp:GridView>
                                    </td>
                                </tr>
                            </table>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
                <td>
                </td>
            </tr>
        </table>
        <table width="100%">
            <tr>
                <td style="height: 173px;" valign="top">
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>
                            <table style="border-right: silver thin inset; border-top: silver thin inset; border-left: silver thin inset;
                                width: 650px; border-bottom: silver thin inset">
                                <tbody>
                                    <tr>
                                        <td align="left" style="border-right: darkgray 1px solid; border-top: darkgray 1px solid;
                                            border-left: darkgray 1px solid; width: 4px; border-bottom: darkgray 1px solid;
                                            height: 21px; background-color: silver">
                                            <asp:CheckBox ID="CheckBox1" runat="server" OnCheckedChanged="CheckBox1_CheckedChanged"
                                                Text="Select All" Width="103px" AutoPostBack="True" />
                                        </td>
                                        <td align="left" style="border-right: darkgray 1px solid; border-top: darkgray 1px solid;
                                            border-left: darkgray 1px solid; width: 4px; border-bottom: darkgray 1px solid;
                                            height: 21px; background-color: silver">
                                            <strong>
                                                <asp:Label ID="Label3" runat="server" Text="Payment Mode" Width="100px"></asp:Label></strong>
                                        </td>
                                        <td align="left" style="border-right: darkgray 1px solid; border-top: darkgray 1px solid;
                                            border-left: darkgray 1px solid; width: 4px; border-bottom: darkgray 1px solid;
                                            height: 21px; background-color: silver">
                                            <asp:DropDownList ID="ddSearchType" runat="server" CssClass="DropList" Width="176px">
                                                <asp:ListItem Value="214">Cash</asp:ListItem>
                                                <asp:ListItem Value="215">Credit</asp:ListItem>
                                                <asp:ListItem Value="216">Advance</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td align="left" style="border-right: darkgray 1px solid; border-top: darkgray 1px solid;
                                            border-left: darkgray 1px solid; width: 4px; border-bottom: darkgray 1px solid;
                                            height: 21px; background-color: silver">
                                            <asp:Button ID="btnPost" runat="server" Font-Size="8pt" Text="Convet to Invoice"
                                                Width="128px" OnClick="btnPost_Click" CssClass="btn" />
                                        </td>
                                        <td align="left" style="border-right: darkgray 1px solid; border-top: darkgray 1px solid;
                                            border-left: darkgray 1px solid; width: 4px; border-bottom: darkgray 1px solid;
                                            height: 21px; background-color: silver" width="250">
                                            <asp:Button ID="btnPrint" runat="server" Font-Size="8pt" Text="Print Invoice" Width="104px"
                                                CssClass="btn" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" colspan="5" style="height: 21px">
                                            <asp:Panel ID="Panel1" runat="server" Height="180px" ScrollBars="Vertical" Width="710px">
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
                                                        <asp:BoundField DataField="SALE_ORDER_ID" HeaderText="Sale Order Id">
                                                            <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="DOCUMENT_DATE" HeaderText="Order Date">
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
                                                        <asp:BoundField DataField="DELIVERYMAN_ID" HeaderText="DELIVERYMAN_ID">
                                                            <HeaderStyle CssClass="hiddencol" />
                                                            <ItemStyle CssClass="hiddencol" />
                                                        </asp:BoundField>
                                                    </Columns>
                                                    <PagerStyle BackColor="Transparent" />
                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass="tblhead" />
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
