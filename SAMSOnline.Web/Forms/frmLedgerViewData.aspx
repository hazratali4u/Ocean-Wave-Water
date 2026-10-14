<%@ Page Language="C#" MasterPageFile="~/Forms/PageMaster.master" AutoEventWireup="true" CodeFile="frmLedgerViewData.aspx.cs" Inherits="Forms_frmLedgerViewData" Title="SAMS >> Voucher View" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cphPage">
    <div id="right_data">
        <table width="100%">
            <tr>
                <td >
                    <table>
                                <tr>
                                    <td align="left" style="width: 100px">
                                        <strong><asp:Label id="lbltoLocation" runat="server" Width="67px" Text="Location" CssClass="lblbox"></asp:Label></strong></td>
                                    <td style="width: 100px">
        <asp:DropDownList id="drpDistributor" runat="server" Width="200px" CssClass="DropList"></asp:DropDownList></td>
                                    <td style="height: 25px;">
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" style="width: 100px">
                                        <strong><asp:Label ID="Label3" runat="server" CssClass="lblbox" Text="Voucher Type" Width="104px"></asp:Label></strong></td>
                                    <td style="width: 100px">
                                        <asp:DropDownList id="DrpVoucherType" runat="server" Width="200px" CssClass="DropList">
                                            <asp:ListItem Value="14">Cash Voucher</asp:ListItem>
                                            <asp:ListItem Value="15">Bank Voucher</asp:ListItem>
                                            <asp:ListItem Value="16">Journal Voucher</asp:ListItem>
                                        </asp:DropDownList></td>
                                    <td style="height: 25px;">
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" style="width: 100px" valign="middle">
                                        <strong><asp:Label ID="Label4" runat="server" Height="13px" Text="From Date" Width="70px"></asp:Label></strong></td>
                                    <td style="width: 100px" align="left">
                                        <asp:TextBox ID="txtStartDate" runat="server" CssClass="txtBox" MaxLength="10" onkeyup="BlockStartDateKeyPress()"
                                            Width="190px"></asp:TextBox></td>
                                    <td align="left" style="height: 25px;">
                                        <asp:ImageButton ID="ibtnStartDate" runat="server" ImageUrl="~/App_Themes/Granite/Images/date.gif"
                                            Width="16px" /></td>
                                </tr>
                        <tr>
                            <td align="left" style="width: 100px" valign="middle">
                                <strong><asp:Label ID="Label5" runat="server" Height="13px" Text="To Date" Width="80px"></asp:Label></strong></td>
                            <td align="left" style="width: 100px">
                                <asp:TextBox ID="txtEndDate" runat="server" CssClass="txtBox " MaxLength="10" onkeyup="BlockEndDateKeyPress()"
                                    Width="191px"></asp:TextBox></td>
                            <td align="left" style="height: 25px">
                                <asp:ImageButton ID="ibnEndDate" runat="server" ImageUrl="~/App_Themes/Granite/Images/date.gif"
                                    Width="16px" /></td>
                        </tr>
                                <tr>
                                    <td align="left" style="width: 100px; height: 12px;" valign="top">
                                        &nbsp;
                                        <strong><asp:Label ID="Label1" runat="server" CssClass="lblbox" Text="Status " Width="90px"></asp:Label></strong></td>
                                    <td style="width: 100px; height: 12px;" align="left">
                                        <asp:RadioButtonList ID="RbdList" runat="server" Width="150px" AutoPostBack="True" OnSelectedIndexChanged="RbdList_SelectedIndexChanged">
                                            <asp:ListItem Selected="True" Value="FALSE">Un Post Voucher</asp:ListItem>
                                            <asp:ListItem Value="TRUE">Post Voucher</asp:ListItem>
                                        </asp:RadioButtonList></td>
                                    <td align="left" style="height: 25px;">
                                    </td>
                                </tr>
                            </table>
                    <cc1:CalendarExtender ID="CEStartDate" runat="server" Format="dd-MMM-yyyy" PopupButtonID="ibtnStartDate"
                        TargetControlID="txtStartDate">
                    </cc1:CalendarExtender>
                    <cc1:CalendarExtender ID="CEEndDate" runat="server" Format="dd-MMM-yyyy" PopupButtonID="ibnEndDate"
                        TargetControlID="txtEndDate">
                    </cc1:CalendarExtender>
                </td>
            </tr>
        </table>
        <table width="100%">
        <tr>
            <td >
                <table width="300">
                    <tr>
                        <td style="width: 100px">
                            <asp:CheckBox ID="ChbSelect" runat="server" Text="All Select" Width="115px" AutoPostBack="True" OnCheckedChanged="ChbSelect_CheckedChanged" /></td>
                        <td style="width: 100px">
                    <asp:Button CssClass="btn" ID="btnView" runat="server" OnClick="btnView_Click" Text="View"
                        Width="107px" /></td>
                        <td style="width: 100px">
                    <asp:Button CssClass="btn" ID="btnPost" runat="server" Font-Size="8pt" Text="Post Voucher"
                        Width="108px" OnClick="btnPost_Click" /></td>
                        <td>
                            <asp:Button CssClass="btn" ID="btnDelete" runat="server" Font-Size="8pt" Text="Delete Voucher"
                        Width="108px" OnClick="btnDelete_Click" /></td>
                    </tr>
                </table>
                        <table style="border-right: silver thin inset; border-top: silver thin inset; border-left: silver thin inset;
                            width: 650px; border-bottom: silver thin inset; height: 251px;">
                            <tbody>
                                <tr>
                                    <td align="left" colspan="5" style="height: 21px">
                                        <asp:Panel ID="Panel1" runat="server" Height="250px" ScrollBars="Vertical" Width="750px">
                                            <asp:GridView ID="GrdLedger" runat="server" AutoGenerateColumns="False" BackColor="White"
                                                BorderColor="White" CssClass="gridRow2" ForeColor="SteelBlue" HorizontalAlign="Center"
                                                Width="728px" OnRowEditing="GrdLedger_RowEditing" OnRowDeleting="GrdLedger_RowDeleting">
                                                <PagerSettings FirstPageText="" LastPageText="" Mode="NextPrevious" NextPageText="Next"
                                                    PreviousPageText="Previous" />
                                                <FooterStyle BackColor="White" />
                                                <RowStyle ForeColor="Black" />
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Voucher">
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="ChbSelect" runat="server" />
                                                        </ItemTemplate>
                                                        <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center" />
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="VOUCHER_NO" HeaderText="Voucher No">
                                                        <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Ledger_date" HeaderText="Voucher Date" >
                                                        <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Remarks" HeaderText="Remarks" >
                                                        <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="VOUCHER_TYPE_ID" HeaderText="VOUCHER_TYPE_ID" >
                                                        <HeaderStyle CssClass="hiddencol" />
                                                        <ItemStyle CssClass="hiddencol" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="VOUCHER_DATE" HeaderText="VOUCHER_DATE">
                                                        <HeaderStyle CssClass="hiddencol" />
                                                        <ItemStyle CssClass="hiddencol" />
                                                    </asp:BoundField>
                                                    <asp:CommandField HeaderText="Print" ShowEditButton="True" EditText="Print">
                                                        <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" />
                                                    </asp:CommandField>
                                                    <asp:TemplateField HeaderText="Edit">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="btnDelete" runat="server" CommandName="Delete" OnClientClick="javascript:return confirm('Are you sure you want to Edit?');return false;"
                                                                Text="Edit"></asp:LinkButton>
                                                        </ItemTemplate>
                                                        <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" />
                                                    </asp:TemplateField>
                                                </Columns>
                                                <PagerStyle BackColor="Transparent" />
                                                <HeaderStyle  CssClass="tblhead" />
                                                <AlternatingRowStyle BackColor="#F2F2F2" CssClass="GridAlternateRowStyle" ForeColor="#333333" />
                                            </asp:GridView>
                                        </asp:Panel>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
            </td>
        </tr>
    </table>
    </div>
    
   
</asp:Content>

