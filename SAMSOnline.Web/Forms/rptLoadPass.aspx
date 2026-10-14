<%@ Page Language="C#" AutoEventWireup="true" CodeFile="rptLoadPass.aspx.cs" Inherits="Forms_rptLoadPass"
    MasterPageFile="~/Forms/PageMaster.master" Title="SAMS >> Load Pass Summary" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="content1" runat="server" ContentPlaceHolderID="cphPage">
    <div id="right_data">
        <table width="100%">
            <tr>
                <td>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <table>
                                <tbody>
                                    <tr>
                                        <td align="left" colspan="4">
                                            <strong>
                                                <asp:Label ID="lblErrorMsg" runat="server" ForeColor="Red" Font-Bold="True"></asp:Label></strong>
                                        </td>
                                        <td style="width: 1px" align="left" colspan="1">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" style="width: 1px; height: 1px">
                                        </td>
                                        <td align="left" style="width: 29px; height: 1px">
                                        </td>
                                        <td align="left" style="width: 1px; height: 1px">
                                        </td>
                                        <td align="left" style="width: 203px; height: 1px">
                                        </td>
                                        <td align="left" style="width: 1px; height: 1px">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 25px;" align="left">
                                            &nbsp;
                                        </td>
                                        <td style="height: 25px;" align="left">
                                            &nbsp;
                                        </td>
                                        <td style="height: 25px;" align="left">
                                            &nbsp;
                                        </td>
                                        <td style="height: 25px" align="left">
                                            <asp:RadioButtonList ID="rblReport" runat="server" AutoPostBack="True" OnSelectedIndexChanged="rblReport_SelectedIndexChanged"
                                                RepeatDirection="Horizontal" Width="350px">
                                                <asp:ListItem Selected="True" Value="0">Customer Wise</asp:ListItem>
                                                <asp:ListItem>Delivery Man Wise</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                        <td style="height: 25px" align="left">
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" style="height: 25px;">
                                        </td>
                                        <td align="left" style="height: 25px">
                                            <strong>
                                                <asp:Label ID="Label2" runat="server" CssClass="lblbox" Text="Location" Width="48px"
                                                    Enabled="False"></asp:Label></strong>
                                        </td>
                                        <td align="left" style="height: 25px;">
                                        </td>
                                        <td align="left" style="height: 25px">
                                            <asp:DropDownList ID="DrpLocation" runat="server" Width="210px" AutoPostBack="True"
                                                OnSelectedIndexChanged="DrpLocation_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </td>
                                        <td align="left" style="height: 25px">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" style="width: 1px; height: 25px">
                                        </td>
                                        <td align="left" style="height: 25px">
                                            <strong>
                                                <asp:Label ID="lbltoLocation" runat="server" Text="Principal" Width="95px"></asp:Label>
                                            </strong>
                                        </td>
                                        <td align="left" style="width: 1px; height: 25px">
                                        </td>
                                        <td align="left" style="width: 203px; height: 25px">
                                            <asp:DropDownList ID="drpPrincipal" runat="server" Width="210px">
                                            </asp:DropDownList>
                                        </td>
                                        <td align="left" style="width: 1px; height: 25px">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 1px;" align="left">
                                        </td>
                                        <td style="height: 25px" align="left">
                                            <strong>
                                                <asp:Label ID="lblSalesMan" runat="server" Width="95px" Text="Deliveryman"></asp:Label></strong>
                                        </td>
                                        <td style="width: 1px" align="left">
                                        </td>
                                        <td style="width: 203px; height: 25px" align="left">
                                            <asp:DropDownList ID="DrpOrderBooker" runat="server" Width="210px">
                                            </asp:DropDownList>
                                        </td>
                                        <td style="width: 1px; height: 25px" align="left">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" style="width: 1px; height: 25px">
                                        </td>
                                        <td align="left" style="height: 25px">
                                            <strong>
                                                <asp:Label ID="Label1" runat="server" CssClass="lblbox" Text="Date" Width="59px"></asp:Label>
                                            </strong>
                                        </td>
                                        <td align="left" style="width: 1px; height: 25px">
                                        </td>
                                        <td align="left" style="width: 203px; height: 25px">
                                            <asp:TextBox ID="txtFromDate" runat="server" CssClass="txtBox" MaxLength="10" Width="205px"></asp:TextBox>
                                            <asp:ImageButton ID="ImgBntFromCalc" runat="server" ImageUrl="~/App_Themes/Granite/Images/date.gif" />
                                        </td>
                                        <td align="left" style="width: 1px; height: 25px">
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" EnableViewState="False"
                                Format="dd-MMM-yyyy" PopupButtonID="ImgBntFromCalc" TargetControlID="txtFromDate">
                            </cc1:CalendarExtender>
                            &nbsp;
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <asp:Button ID="Button2" runat="server" Text="View PDF" CssClass="btn" OnClick="Button2_Click" />
                    <asp:Button ID="Button1" runat="server" Text="View Excel" CssClass="btn" OnClick="Button1_Click" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
