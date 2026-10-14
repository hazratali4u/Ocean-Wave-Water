<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/PageMaster.master" AutoEventWireup="true"
    CodeFile="RptCashSale-Recovery.aspx.cs" Inherits="Forms_RptCashSale_Recovery" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHeadPage" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPage" runat="Server">
    <div id="right_data">
        <asp:UpdatePanel ID="up_1" runat="server">
            <ContentTemplate>
                <table>
                    <tr>
                        <td align="left">
                        </td>
                        <td align="left">
                            <strong>
                                <asp:Label ID="lbltoLocation" runat="server" Width="94px" Text="Location" CssClass="lblbox"></asp:Label></strong>
                        </td>
                        <td align="left">
                        </td>
                        <td style="height: 25px" align="left">
                            <asp:DropDownList ID="drpDistributor" runat="server" Width="200px" CssClass="DropList">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                        </td>
                        <td align="left">
                            <strong>
                                <asp:Label ID="Label6" runat="server" Width="78px" Text="Principal" CssClass="lblbox"></asp:Label></strong>
                        </td>
                        <td align="left">
                        </td>
                        <td style="height: 25px" align="left">
                            <asp:DropDownList ID="DrpPrincipal" runat="server" Width="200px" CssClass="DropList">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                        </td>
                        <td align="left">
                            <strong>
                                <asp:Label ID="lbl_fromdate" runat="server" Width="90px" Height="13px" Text="From Date"></asp:Label></strong>
                        </td>
                        <td align="left">
                        </td>
                        <td style="height: 25px" align="left">
                            <asp:TextBox ID="txtStartDate" onkeyup="BlockStartDateKeyPress()" runat="server"
                                Width="170px" CssClass="txtBox" MaxLength="10"></asp:TextBox>
                            <asp:ImageButton ID="ibtnStartDate" runat="server" Width="16px" ImageUrl="~/App_Themes/Granite/Images/date.gif">
                            </asp:ImageButton>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                        </td>
                        <td align="left">
                            <strong>
                                <asp:Label ID="lbl_todate" runat="server" Width="80px" Height="13px" Text="To Date"></asp:Label></strong>
                        </td>
                        <td align="left">
                        </td>
                        <td style="height: 25px" align="left">
                            <asp:TextBox ID="txtEndDate" onkeyup="BlockEndDateKeyPress()" runat="server"
                                Width="170px" CssClass="txtBox " MaxLength="10"></asp:TextBox>
                            <asp:ImageButton ID="ibnEndDate" runat="server" Width="16px" ImageUrl="~/App_Themes/Granite/Images/date.gif">
                            </asp:ImageButton>
                        </td>
                        <td style="height: 25px" align="left">
                            <%@ register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
                            <cc1:CalendarExtender ID="CEStartDate" runat="server" TargetControlID="txtStartDate"
                                PopupButtonID="ibtnStartDate" Format="dd-MMM-yyyy">
                            </cc1:CalendarExtender>
                            <cc1:CalendarExtender ID="CEEndDate" runat="server" TargetControlID="txtEndDate"
                                PopupButtonID="ibnEndDate" Format="dd-MMM-yyyy">
                            </cc1:CalendarExtender>
                        </td>
                    </tr>
                </table>
                <br />
            </ContentTemplate>
        </asp:UpdatePanel>
        &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button CssClass="btn" ID="btn_ViewReport" runat="server" Text="View PDF" OnClick="btn_ViewReport_Click" />
        <asp:Button CssClass="btn" ID="btn_ViewExcel" runat="server" Text="View Excel" OnClick="btn_ViewExcel_Click" />
    </div>
</asp:Content>
