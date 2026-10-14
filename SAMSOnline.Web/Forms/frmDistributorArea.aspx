<%@ Page Language="C#" MasterPageFile="~/Forms/PageMaster.master" AutoEventWireup="true"
    CodeFile="frmDistributorArea.aspx.cs" Inherits="Forms_frmDistributorArea" Title="SAMS >> Town Hierarchy" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphPage" runat="Server">
    <div class="container" style="background-color: white">
        <script language="JavaScript" type="text/javascript">
            function ValidateArea() {
                var str;
                str = document.getElementById('<%=txtAreaName.ClientID%>').value;
                if (str == null || str.length == 0) {
                    alert('Must Enter Route Name');
                    return false;
                }
                return true;
            }
            function ValidateRoute() {
                var str;
                str = document.getElementById('<%=txtMarketName.ClientID%>').value;
                if (str == null || str.length == 0) {
                    alert('Must Enter Market Name');
                    return false;
                }
                return true;
            }
        </script>
        </div>
        <div id="right_data">
            <table>
                <tr>
                    <td>
                        <table width="100%">
                            <tr>
                                <td>
                                    <cc1:TabContainer ID="TabContainer1" runat="server" Height="375px" CssClass="Tab"
                                        Width="650px" ActiveTabIndex="1">
                                        <cc1:TabPanel ID="TabPanel1" runat="server">
                                            <HeaderTemplate>
                                                Route&nbsp;
                                            </HeaderTemplate>
                                            <ContentTemplate>
                                                <table width="100%">
                                                    <tr>
                                                        <td style="width: 100px">
                                                        </td>
                                                        <td style="width: 100px">
                                                        </td>
                                                        <td style="width: 100px">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100px">
                                                        </td>
                                                        <td style="width: 100px">
                                                            <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                                                <ContentTemplate>
                                                                    <table width="100%">
                                                                        <tbody>
                                                                            <tr>
                                                                                <td style="width: 100px">
                                                                                </td>
                                                                                <td style="width: 49px">
                                                                                </td>
                                                                                <td style="width: 100px">
                                                                                </td>
                                                                                <td style="width: 100px">
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="width: 100px">
                                                                                </td>
                                                                                <td colspan="2">
                                                                                    <strong>
                                                                                        <asp:Label ID="lblErrorMsg" runat="server" ForeColor="Red" Font-Bold="True"></asp:Label></strong>
                                                                                    <br />
                                                                                </td>
                                                                                <td style="width: 100px">
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="width: 100px; height: 28px">
                                                                                </td>
                                                                                <td style="width: 49px; height: 28px">
                                                                                    <strong>
                                                                                        <asp:Label ID="Label4" runat="server" Width="62px" Text="Location"></asp:Label></strong>
                                                                                </td>
                                                                                <td style="width: 100px; height: 28px">
                                                                                    <asp:DropDownList ID="drpDistributor" runat="server" Width="200px" CssClass="DropList"
                                                                                        OnSelectedIndexChanged="drpDistributor_SelectedIndexChanged" AutoPostBack="True">
                                                                                    </asp:DropDownList>
                                                                                </td>
                                                                                <td style="width: 100px; height: 28px">
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="width: 100px; height: 28px">
                                                                                </td>
                                                                                <td style="width: 49px; height: 28px">
                                                                                    <strong>
                                                                                        <asp:Label ID="Label3" runat="server" Width="62px" Text="Town"></asp:Label></strong>
                                                                                </td>
                                                                                <td style="width: 100px; height: 28px">
                                                                                    <asp:DropDownList ID="drpTown" runat="server" Width="200px" CssClass="DropList" OnSelectedIndexChanged="drpTown_SelectedIndexChanged"
                                                                                        AutoPostBack="True">
                                                                                    </asp:DropDownList>
                                                                                </td>
                                                                                <td style="width: 100px; height: 28px">
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="width: 100px; height: 29px">
                                                                                </td>
                                                                                <td style="width: 49px; height: 29px">
                                                                                    <strong>
                                                                                        <asp:Label ID="Label2" runat="server" Width="65px" Text="Name"></asp:Label></strong>
                                                                                </td>
                                                                                <td style="width: 100px; height: 29px">
                                                                                    <asp:TextBox ID="txtAreaName" runat="server" Width="192px" CssClass="txtBox "></asp:TextBox>
                                                                                </td>
                                                                                <td style="width: 100px; height: 29px">
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="width: 100px; height: 37px">
                                                                                </td>
                                                                                <td style="width: 49px; height: 37px" align="right">
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td style="width: 100px; height: 37px">
                                                                                    <asp:CheckBox ID="ChIsActive" runat="server" Text="Is Active" Checked="True"></asp:CheckBox>
                                                                                </td>
                                                                                <td style="width: 100px; height: 37px">
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="width: 100px; height: 37px">
                                                                                </td>
                                                                                <td style="width: 49px; height: 37px" align="right">
                                                                                </td>
                                                                                <td style="width: 100px; height: 37px">
                                                                                    <asp:Button ID="btnSaveRoute" OnClick="btnSaveRoute_Click" runat="server" Width="85px"
                                                                                        Font-Size="8pt" Text="Save" CssClass="btn" />
                                                                                </td>
                                                                                <td style="width: 100px; height: 37px">
                                                                                </td>
                                                                            </tr>
                                                                        </tbody>
                                                                    </table>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                        <td style="width: 100px">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" colspan="3">
                                                            <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:Panel ID="Panel1" runat="server" Height="150px" HorizontalAlign="Left" ScrollBars="Vertical"
                                                                        Width="100%">
                                                                        <asp:GridView ID="grdAreaData" runat="server" Width="90%" Font-Size="9pt" ForeColor="SteelBlue"
                                                                            CssClass="gridRow2" AutoGenerateColumns="False" HorizontalAlign="Center" BackColor="White"
                                                                            BorderColor="White" OnRowEditing="grdAreaData_RowEditing" OnPageIndexChanging="grdAreaData_PageIndexChanging">
                                                                            <PagerSettings FirstPageText="" LastPageText="" Mode="NextPrevious" NextPageText="Next"
                                                                                PreviousPageText="Previous"></PagerSettings>
                                                                            <RowStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid" ForeColor="Black">
                                                                            </RowStyle>
                                                                            <Columns>
                                                                                <asp:BoundField DataField="AREA_ID" HeaderText="Area Id">
                                                                                    <HeaderStyle CssClass="hiddencol"></HeaderStyle>
                                                                                    <ItemStyle HorizontalAlign="Left" BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid"
                                                                                        CssClass="hiddencol"></ItemStyle>
                                                                                </asp:BoundField>
                                                                                <asp:BoundField DataField="DISTRIBUTOR_ID" HeaderText="Distributor">
                                                                                    <HeaderStyle CssClass="hiddencol" HorizontalAlign="Left"></HeaderStyle>
                                                                                    <ItemStyle HorizontalAlign="Left" BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid"
                                                                                        CssClass="hiddencol"></ItemStyle>
                                                                                </asp:BoundField>
                                                                                <asp:BoundField DataField="TOWN_ID" HeaderText="Town Id">
                                                                                    <HeaderStyle CssClass="hiddencol"></HeaderStyle>
                                                                                    <ItemStyle HorizontalAlign="Left" BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid"
                                                                                        CssClass="hiddencol"></ItemStyle>
                                                                                </asp:BoundField>
                                                                                <asp:BoundField DataField="Distributor" HeaderText="Distributor">
                                                                                    <ItemStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid"></ItemStyle>
                                                                                    <HeaderStyle HorizontalAlign="Left" />
                                                                                </asp:BoundField>
                                                                                <asp:BoundField DataField="Town" HeaderText="Town">
                                                                                    <ItemStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid"></ItemStyle>
                                                                                    <HeaderStyle HorizontalAlign="Left" />
                                                                                </asp:BoundField>
                                                                                <asp:BoundField DataField="AREA_CODE" HeaderText="Route Code">
                                                                                    <ItemStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid"></ItemStyle>
                                                                                    <HeaderStyle HorizontalAlign="Left" />
                                                                                </asp:BoundField>
                                                                                <asp:BoundField DataField="AREA_NAME" HeaderText="Route Name">
                                                                                    <ItemStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid"></ItemStyle>
                                                                                    <HeaderStyle HorizontalAlign="Left" />
                                                                                </asp:BoundField>
                                                                                <asp:BoundField DataField="IS_ACTIVE" HeaderText="Status">
                                                                                    <ItemStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid"></ItemStyle>
                                                                                    <HeaderStyle HorizontalAlign="Left" />
                                                                                </asp:BoundField>
                                                                                <asp:CommandField ShowEditButton="True" HeaderText="Edit">
                                                                                    <ItemStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid"></ItemStyle>
                                                                                </asp:CommandField>
                                                                            </Columns>
                                                                            <FooterStyle BackColor="White"></FooterStyle>
                                                                            <PagerStyle BackColor="Transparent"></PagerStyle>
                                                                            <HeaderStyle CssClass="tblhead" ForeColor="White"></HeaderStyle>
                                                                            <AlternatingRowStyle CssClass="GridAlternateRowStyle"></AlternatingRowStyle>
                                                                        </asp:GridView>
                                                                    </asp:Panel>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                </table>
                                            </ContentTemplate>
                                        </cc1:TabPanel>
                                        <cc1:TabPanel ID="TabPanel2" runat="server">
                                            <HeaderTemplate>
                                                Market&nbsp;
                                            </HeaderTemplate>
                                            <ContentTemplate>
                                                <table width="100%">
                                                    <tr>
                                                        <td style="width: 100px">
                                                        </td>
                                                        <td align="center" style="width: 100px">
                                                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                                <ContentTemplate>
                                                                    <table width="100%">
                                                                        <tbody>
                                                                            <tr>
                                                                                <td style="width: 100px; height: 8px">
                                                                                </td>
                                                                                <td style="height: 8px" align="left" colspan="2">
                                                                                    <strong>
                                                                                        <asp:Label ID="lblErrorMsgDivsion" runat="server" ForeColor="Red" Font-Bold="True"></asp:Label>
                                                                                    </strong>
                                                                                    <br />
                                                                                </td>
                                                                                <td style="width: 100px; height: 8px">
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="width: 100px; height: 16px">
                                                                                </td>
                                                                                <td style="width: 49px; height: 28px" align="left">
                                                                                    <strong>
                                                                                        <asp:Label ID="Label1" runat="server" Width="64px" Text="Location"></asp:Label>
                                                                                    </strong>
                                                                                </td>
                                                                                <td style="height: 16px" align="left">
                                                                                    <asp:DropDownList ID="drpMDistributor" runat="server" Width="200px" AutoPostBack="True"
                                                                                        OnSelectedIndexChanged="drpMDistributor_SelectedIndexChanged" CssClass="DropList">
                                                                                    </asp:DropDownList>
                                                                                </td>
                                                                                <td style="width: 100px; height: 16px">
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="width: 100px; height: 8px">
                                                                                </td>
                                                                                <td style="width: 49px; height: 28px" align="left">
                                                                                    <strong>
                                                                                        <asp:Label ID="Label5" runat="server" Width="42px" Text="Town"></asp:Label>
                                                                                    </strong>
                                                                                </td>
                                                                                <td align="left">
                                                                                    <asp:DropDownList ID="DrpMTown" runat="server" Width="200px" AutoPostBack="True"
                                                                                        OnSelectedIndexChanged="DrpMTown_SelectedIndexChanged" CssClass="DropList">
                                                                                    </asp:DropDownList>
                                                                                </td>
                                                                                <td style="width: 100px; height: 8px">
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="width: 100px; height: 8px">
                                                                                </td>
                                                                                <td style="width: 49px; height: 28px" align="left">
                                                                                    <strong>
                                                                                        <asp:Label ID="Label6" runat="server" Width="42px" Text="Route"></asp:Label>
                                                                                    </strong>
                                                                                </td>
                                                                                <td align="left">
                                                                                    <asp:DropDownList ID="DrpRoute" runat="server" Width="200px" AutoPostBack="True"
                                                                                        OnSelectedIndexChanged="DrpRoute_SelectedIndexChanged" CssClass="DropList">
                                                                                    </asp:DropDownList>
                                                                                </td>
                                                                                <td style="width: 100px; height: 8px">
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="width: 100px; height: 8px">
                                                                                </td>
                                                                                <td style="width: 49px; height: 28px" align="left">
                                                                                    <strong>
                                                                                        <asp:Label ID="Label21" runat="server" Width="43px" Text="Name"></asp:Label>
                                                                                    </strong>
                                                                                </td>
                                                                                <td align="left">
                                                                                    <asp:TextBox ID="txtMarketName" runat="server" Width="194px" CssClass="txtBox "></asp:TextBox>
                                                                                </td>
                                                                                <td style="width: 100px; height: 8px">
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="width: 100px; height: 37px">
                                                                                </td>
                                                                                <td align="right">
                                                                                </td>
                                                                                <td align="left">
                                                                                    <asp:CheckBox ID="chMarkeIsActive" runat="server" Text="Is Active" Checked="True">
                                                                                    </asp:CheckBox>
                                                                                </td>
                                                                                <td style="width: 100px; height: 37px">
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="width: 100px; height: 37px">
                                                                                </td>
                                                                                <td align="right">
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td align="left">
                                                                                    <asp:Button ID="btnSaveMarket" OnClick="btnSaveMarket_Click" runat="server" Width="85px"
                                                                                        Font-Size="8pt" Text="Save" CssClass="btn" />
                                                                                </td>
                                                                                <td style="width: 100px; height: 37px">
                                                                                </td>
                                                                            </tr>
                                                                        </tbody>
                                                                    </table>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                        <td style="width: 100px">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" colspan="3">
                                                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:Panel ID="Panel2" runat="server" Height="130px" HorizontalAlign="Left" ScrollBars="Vertical"
                                                                        Width="100%">
                                                                        <asp:GridView ID="grdRouteData" runat="server" Width="100%" Font-Size="9pt" ForeColor="SteelBlue"
                                                                            CssClass="gridRow2" OnPageIndexChanging="grdRouteData_PageIndexChanging" OnRowEditing="grdRouteData_RowEditing"
                                                                            BorderColor="White" BackColor="White" HorizontalAlign="Center" AutoGenerateColumns="False"
                                                                            AllowPaging="True">
                                                                            <PagerSettings FirstPageText="" LastPageText="" Mode="NextPrevious" NextPageText="Next"
                                                                                PreviousPageText="Previous"></PagerSettings>
                                                                            <RowStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid" ForeColor="Black">
                                                                            </RowStyle>
                                                                            <Columns>
                                                                                <asp:BoundField DataField="ROUTE_ID" HeaderText="ROUTE_ID">
                                                                                    <HeaderStyle CssClass="hiddencol"></HeaderStyle>
                                                                                    <ItemStyle CssClass="hiddencol"></ItemStyle>
                                                                                </asp:BoundField>
                                                                                <asp:BoundField DataField="DISTRIBUTOR_ID" HeaderText="Distributor Id">
                                                                                    <HeaderStyle CssClass="hiddencol"></HeaderStyle>
                                                                                    <ItemStyle HorizontalAlign="Left" BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid"
                                                                                        CssClass="hiddencol"></ItemStyle>
                                                                                </asp:BoundField>
                                                                                <asp:BoundField DataField="AREA_ID" HeaderText="Area Id">
                                                                                    <HeaderStyle CssClass="hiddencol"></HeaderStyle>
                                                                                    <ItemStyle HorizontalAlign="Left" BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid"
                                                                                        CssClass="hiddencol"></ItemStyle>
                                                                                </asp:BoundField>
                                                                                <asp:BoundField DataField="TOWN_ID" HeaderText="Town Id">
                                                                                    <HeaderStyle CssClass="hiddencol"></HeaderStyle>
                                                                                    <ItemStyle HorizontalAlign="Left" BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid"
                                                                                        CssClass="hiddencol"></ItemStyle>
                                                                                </asp:BoundField>
                                                                                <asp:BoundField DataField="Distributor" HeaderText="Distributor">
                                                                                    <ItemStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid"></ItemStyle>
                                                                                    <HeaderStyle HorizontalAlign="Left" />
                                                                                </asp:BoundField>
                                                                                <asp:BoundField DataField="Town" HeaderText="Town">
                                                                                    <ItemStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid"></ItemStyle>
                                                                                    <HeaderStyle HorizontalAlign="Left" />
                                                                                </asp:BoundField>
                                                                                <asp:BoundField DataField="AREA_NAME" HeaderText="Route">
                                                                                    <ItemStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid"></ItemStyle>
                                                                                    <HeaderStyle HorizontalAlign="Left" />
                                                                                </asp:BoundField>
                                                                                <asp:BoundField DataField="Route_CODE" HeaderText="Market Code">
                                                                                    <ItemStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid"></ItemStyle>
                                                                                    <HeaderStyle HorizontalAlign="Left" />
                                                                                </asp:BoundField>
                                                                                <asp:BoundField DataField="Route_NAME" HeaderText="Market Name">
                                                                                    <ItemStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid"></ItemStyle>
                                                                                    <HeaderStyle HorizontalAlign="Left" />
                                                                                </asp:BoundField>
                                                                                <asp:BoundField DataField="IS_ACTIVE" HeaderText="Status">
                                                                                    <ItemStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid"></ItemStyle>
                                                                                    <HeaderStyle HorizontalAlign="Left" />
                                                                                </asp:BoundField>
                                                                                <asp:CommandField ShowEditButton="True" HeaderText="Edit">
                                                                                    <ItemStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid"></ItemStyle>
                                                                                </asp:CommandField>
                                                                            </Columns>
                                                                            <FooterStyle BackColor="White"></FooterStyle>
                                                                            <PagerStyle BackColor="Transparent"></PagerStyle>
                                                                            <HeaderStyle CssClass="tblhead" ForeColor="White"></HeaderStyle>
                                                                            <AlternatingRowStyle CssClass="GridAlternateRowStyle"></AlternatingRowStyle>
                                                                        </asp:GridView>
                                                                    </asp:Panel>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                    </tr>
                                                </table>
                                                <br />
                                                &nbsp;
                                            </ContentTemplate>
                                        </cc1:TabPanel>
                                    </cc1:TabContainer>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
</asp:Content>
