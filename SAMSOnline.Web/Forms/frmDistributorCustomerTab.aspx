<%@ Page Language="C#" MasterPageFile="~/Forms/PageMaster.master" AutoEventWireup="true"
    CodeFile="frmDistributorCustomerTab.aspx.cs" Inherits="Forms_frmDistributorCustomerTab"
    Title="SAMS >>  New Customer" %>

<%@Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cphPage">
    <script language="JavaScript" type="text/javascript">
        function ValidateForm() {
            var str;
            str = document.getElementById('<%=txtCustomerName.ClientID%>').value;
            if (str == null || str.length == 0) {
                alert('Must enter Customer Name');
                return false;
            }
            str = document.getElementById('<%=txtContactPerson.ClientID%>').value;
            if (str == null || str.length == 0) {
                alert('Must enter Contact Person Name');
                return false;
            }
            str = document.getElementById('<%=txtAddress.ClientID%>').value;
            if (str == null || str.length == 0) {
                alert('Must enter Address');
                return false;
            }
            str = document.getElementById('<%=txtemail.ClientID%>').value;
            if (str == null || str.length == 0) {
                alert('Must enter email Address');
                return false;
            }

            str = document.getElementById('<%=txtPhoneNo.ClientID%>').value;
            if (str == null || str.length == 0) {
                alert('Must enter Phone No');
                return false;
            }
            str = document.getElementById('<%=txtRegdate.ClientID%>').value;
            if (str == null || str.length == 0) {
                alert('Must enter Register Date');
                return false;
            }
            return true;
        }
        function SearchRecord() {
            var str;
            str = document.getElementById('<%=txtSeach.ClientID%>').value;
            if (str == null || str.length == 0) {
                alert('Must enter Key Word for Searching');
                return false;
            }
            return true;
        }
	

    </script>
    <div id="right_data">
        <cc1:TabContainer ID="TabContainer1" runat="server" CssClass="Tab" ActiveTabIndex="0">
            <cc1:TabPanel ID="TabPanel1" runat="server">
                <HeaderTemplate>
                    Customer&nbsp;
                </HeaderTemplate>
                <ContentTemplate>
                    <table width="100%">
                        <tr>
                            <td style="height: 25px">
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                    <ContentTemplate>
                                        <table>
                                            <tbody>
                                                <tr>
                                                    <td style="width: 143px" align="left">
                                                    </td>
                                                    <td style="width: 175px">
                                                        <strong>
                                                            <asp:Label ID="lblErrorMsg" runat="server" ForeColor="Red" Font-Bold="True"></asp:Label></strong>
                                                    </td>
                                                    <td style="width: 1px">
                                                    </td>
                                                    <td align="left">
                                                    </td>
                                                    <td style="width: 219px">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 25px" align="left">
                                                        <strong>
                                                            <asp:Label ID="Label7" runat="server" Width="77px" Text="Location" CssClass="lblbox"></asp:Label></strong>
                                                    </td>
                                                    <td style="width: 175px">
                                                        <asp:DropDownList ID="DrpDistributor" runat="server" Width="205px" CssClass="DropList"
                                                            OnSelectedIndexChanged="DrpDistributor_SelectedIndexChanged" AutoPostBack="True">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td style="width: 1px">
                                                    </td>
                                                    <td align="left">
                                                        <strong>
                                                            <asp:Label ID="Label4" runat="server" Width="56px" Text="Town" CssClass="lblbox"></asp:Label></strong>
                                                    </td>
                                                    <td style="width: 219px">
                                                        <asp:DropDownList ID="DrpTown" runat="server" Width="205px" CssClass="DropList" OnSelectedIndexChanged="DrpTown_SelectedIndexChanged"
                                                            AutoPostBack="True">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 25px" align="left">
                                                        <strong>
                                                            <asp:Label ID="Label2" runat="server" Width="78px" Text="Route" CssClass="lblbox"></asp:Label></strong>
                                                    </td>
                                                    <td style="width: 175px; height: 12px">
                                                        <asp:DropDownList ID="DrpRoute" runat="server" Width="205px" CssClass="DropList"
                                                            OnSelectedIndexChanged="DrpRoute_SelectedIndexChanged" AutoPostBack="True">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td style="width: 1px; height: 12px">
                                                    </td>
                                                    <td style="height: 12px" align="left">
                                                        <strong>
                                                            <asp:Label ID="Label5" runat="server" Width="59px" Text="Market" CssClass="lblbox"></asp:Label></strong>
                                                    </td>
                                                    <td style="height: 12px; width: 219px;">
                                                        <asp:DropDownList ID="DrpMarket" runat="server" Width="206px" CssClass="DropList">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 25px" align="left">
                                                        <strong>
                                                            <asp:Label ID="lblNickName" runat="server" Width="79px" Text="Channel Type" CssClass="lblbox"></asp:Label></strong>
                                                    </td>
                                                    <td style="width: 175px">
                                                        <asp:DropDownList ID="drpChannelType" runat="server" Width="205px" CssClass="DropList">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td style="width: 1px">
                                                    </td>
                                                    <td align="left">
                                                        <strong>
                                                            <asp:Label ID="lblMobileNo" runat="server" Width="96px" Text="Business Type" CssClass="lblbox"></asp:Label></strong>
                                                    </td>
                                                    <td style="width: 219px">
                                                        <asp:DropDownList ID="DrpBusinessType" runat="server" Width="206px" CssClass="DropList">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 26px" align="left">
                                                        <strong>
                                                            <asp:Label ID="Label3" runat="server" Width="101px" Text="Promotion Class" CssClass="lblbox"></asp:Label></strong>
                                                    </td>
                                                    <td style="width: 175px; height: 26px">
                                                        <asp:DropDownList ID="DrpVolumeClass" runat="server" Width="205px" CssClass="DropList">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td style="width: 1px; height: 26px" valign="top">
                                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                    </td>
                                                    <td align="left">
                                                        <asp:CheckBox ID="ChbIsRegister" runat="server" Text="Is Register" OnCheckedChanged="ChbIsRegister_CheckedChanged"
                                                            AutoPostBack="True"></asp:CheckBox>
                                                    </td>
                                                    <td style="height: 26px; width: 219px;">
                                                        <asp:TextBox ID="txtIsRegister" runat="server" Width="200px" CssClass="txtBox " Enabled="False"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 26px" align="left">
                                                        <strong>
                                                            <asp:Label ID="Label1" runat="server" Width="51px" Text="Name" CssClass="lblbox"></asp:Label></strong>
                                                    </td>
                                                    <td style="width: 175px; height: 26px">
                                                        <asp:TextBox ID="txtCustomerName" runat="server" Width="200px" CssClass="txtBox"></asp:TextBox>
                                                    </td>
                                                    <td style="width: 1px; height: 26px" valign="top">
                                                    </td>
                                                    <td align="left">
                                                        <strong>
                                                            <asp:Label ID="lbldesignationID" runat="server" Width="80px" Text="Register Date"
                                                                CssClass="lblbox"></asp:Label></strong>
                                                    </td>
                                                    <td style="height: 26px; width: 219px;">
                                                        <asp:TextBox ID="txtRegdate" runat="server" CssClass="txtBox" MaxLength="10" Width="150px"></asp:TextBox><asp:ImageButton
                                            ID="ImgBntToDate" runat="server" ImageUrl="~/App_Themes/Granite/Images/date.gif" />
                                        <cc1:CalendarExtender ID="CalendarExtender2" runat="server" EnableViewState="False"
                                            Format="dd-MMM-yyyy" PopupButtonID="ImgBntToDate" TargetControlID="txtRegdate">
                                        </cc1:CalendarExtender>
                                                       
                                                       
                                                       
                                                       
                                                       <%-- <asp:TextBox ID="txtRegdate" runat="server" CssClass="txtBox" Width="150px" AutoPostBack="true"></asp:TextBox>
                                                        <cc1:MaskedEditExtender ID="MaskedEditExtender2" runat="server" Mask="99/99/9999"
                                                            MaskType="Date" TargetControlID="txtRegdate">
                                                        </cc1:MaskedEditExtender>--%>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 25px" align="left">
                                                        <strong>
                                                            <asp:Label ID="Label19" runat="server" Text="Reffered By" CssClass="lblbox"></asp:Label></strong>
                                                    </td>
                                                    <td style="width: 175px">
                                                        <asp:TextBox ID="txtRefferedBy" runat="server" Width="200px" CssClass="txtBox " MaxLength="255"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td style="width: 1px">
                                                        <strong>
                                                            <asp:Label ID="Label18" runat="server" Width="44px" Text="Customer Type" CssClass="lblbox"></asp:Label></strong>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="DrpCustomerType" runat="server" Width="205px" CssClass="DropList">
                                                            <asp:ListItem Value="1" Selected="True">Monthly</asp:ListItem>
                                                            <asp:ListItem Value="2">Cash on Delivery</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 25px" align="left">
                                                        <strong>
                                                            <asp:Label ID="lblAddress1" runat="server" Width="44px" Text="Address " CssClass="lblbox"></asp:Label></strong>
                                                    </td>
                                                    <td style="width: 175px">
                                                        <asp:TextBox ID="txtAddress" runat="server" Width="200px" CssClass="txtBox " MaxLength="255"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td align="left" colspan="2" rowspan="4">
                                                        <asp:Panel ID="Panel1" runat="server" Width="100%" Height="105px" BorderColor="Black"
                                                            BorderStyle="Solid" BorderWidth="1px">
                                                            <asp:GridView ID="GrdCreditLimit" runat="server" Width="100%" ForeColor="Silver"
                                                                CssClass="gridRow2" HorizontalAlign="Center" AutoGenerateColumns="False" BackColor="White"
                                                                BorderColor="White">
                                                                <PagerSettings FirstPageText="" LastPageText="" Mode="NextPrevious" NextPageText="Next"
                                                                    PreviousPageText="Previous"></PagerSettings>
                                                                <RowStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid" ForeColor="Black">
                                                                </RowStyle>
                                                                <Columns>
                                                                    <asp:BoundField DataField="Company_Id" HeaderText="Company_Id">
                                                                        <HeaderStyle CssClass="hiddencol"></HeaderStyle>
                                                                        <ItemStyle CssClass="hiddencol"></ItemStyle>
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="Company_Name" HeaderText="Principal">
                                                                        <ItemStyle HorizontalAlign="Left" BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid">
                                                                        </ItemStyle>
                                                                    </asp:BoundField>
                                                                    <asp:TemplateField HeaderText="Credit Limit">
                                                                        <ItemTemplate>
                                                                            <asp:TextBox ID="txtCreditLimit" runat="server" Width="90px" CssClass="txtBox"></asp:TextBox>
                                                                        </ItemTemplate>
                                                                        <ItemStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid" Width="100px">
                                                                        </ItemStyle>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Credit Days">
                                                                        <ItemTemplate>
                                                                            <asp:TextBox ID="txtCreditDays" runat="server" CssClass="txtBox " Width="90px"></asp:TextBox>
                                                                        </ItemTemplate>
                                                                        <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" />
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                                <FooterStyle BackColor="White"></FooterStyle>
                                                                <PagerStyle BackColor="Transparent"></PagerStyle>
                                                                <HeaderStyle CssClass="tblhead"></HeaderStyle>
                                                            </asp:GridView>
                                                        </asp:Panel>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 25px" align="left">
                                                        <strong>
                                                            <asp:Label ID="Label6" runat="server" Width="106px" Text="Contact Person" CssClass="lblbox"></asp:Label></strong>
                                                    </td>
                                                    <td style="width: 175px; height: 25px">
                                                        <asp:TextBox ID="txtContactPerson" runat="server" Width="200px" CssClass="txtBox"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 25px" align="left">
                                                        <strong>
                                                            <asp:Label ID="lblPhNo" runat="server" Width="100px" Text="Phone No" CssClass="lblbox"></asp:Label></strong>
                                                    </td>
                                                    <td style="width: 175px; height: 25px">
                                                        <asp:TextBox ID="txtPhoneNo" runat="server" Width="200px" CssClass="txtBox "></asp:TextBox>
                                                    </td>
                                                    <td style="width: 1px; height: 25px">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 25px" align="left">
                                                        <strong>
                                                            <asp:Label ID="lblEmail" runat="server" Width="87px" Text="Email Address" CssClass="lblbox"></asp:Label></strong>
                                                    </td>
                                                    <td style="width: 175px; height: 25px">
                                                        <asp:TextBox ID="txtemail" runat="server" Width="200px" CssClass="txtBox "></asp:TextBox>
                                                    </td>
                                                    <td style="width: 1px; height: 25px">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 143px" align="left">
                                                    </td>
                                                    <td style="width: 175px">
                                                        <asp:Button ID="btnSave" OnClick="btnSave_Click" runat="server" Width="80px" Font-Size="8pt"
                                                            Text="Save" CssClass="btn" />&nbsp;
                                                        <asp:Button ID="Button1" OnClick="Button1_Click" runat="server" Width="80px" Font-Size="8pt"
                                                            Text="Cancel" CssClass="btn" />
                                                    </td>
                                                    <td style="width: 1px">
                                                    </td>
                                                    <td>
                                                        <asp:CheckBox ID="chkIsActive" runat="server" Width="93px" Text="IsActive" Checked="True">
                                                        </asp:CheckBox>
                                                    </td>
                                                    <td style="width: 219px">
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                <div style="z-index: 101; left: 410px; width: 100px; position: absolute; top: 281px;
                                    height: 100px">
                                    &nbsp;<asp:Panel ID="Panel21" runat="server">
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
                        </tr>
                    </table>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <table style="border-right: silver thin inset; border-top: silver thin inset; border-left: silver thin inset;
                                width: 100%; border-bottom: silver thin inset; background-color: silver">
                                <tbody>
                                    <tr>
                                        <td style="height: 21px" align="left">
                                            <strong>
                                                <asp:Label ID="Label10" runat="server" Width="153px" Text="Select Searching Type"></asp:Label></strong>
                                        </td>
                                        <td style="width: 170px; height: 21px" align="left">
                                            <asp:DropDownList ID="ddSearchType" runat="server" Width="200px" CssClass="DropList">
                                                <asp:ListItem Value="CUSTOMER_CODE">Customer Code</asp:ListItem>
                                                <asp:ListItem Value="CUSTOMER_NAME">Customer Name</asp:ListItem>
                                                <asp:ListItem Value="CONTACT_PERSON">Contact Person</asp:ListItem>
                                                <asp:ListItem Value="CONTACT_NUMBER">Contact Number</asp:ListItem>
                                                <asp:ListItem Value="ADDRESS">Address</asp:ListItem>
                                                <asp:ListItem Value="EMAIL_ADDRESS">Email Address</asp:ListItem>
                                                <asp:ListItem Value="GEO_NAME">Town Name</asp:ListItem>
                                                <asp:ListItem Value="AREA_NAME">Route Name</asp:ListItem>
                                                <asp:ListItem Value="ROUTE_NAME">Market Name</asp:ListItem>
                                                <asp:ListItem Value="SLASH_DESC">Channel Type</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td style="width: 224px; height: 21px" align="left">
                                            <asp:TextBox ID="txtSeach" runat="server" Width="200px" CssClass="txtBox "></asp:TextBox>
                                        </td>
                                        <td style="height: 21px" align="left" width="250">
                                            <asp:Button ID="Button2" OnClick="Button2_Click" runat="server" Width="85px" Font-Size="8pt"
                                                Text="Filter" CssClass="btn" />
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                            <asp:Panel ID="Panel2" runat="server" Height="200px" ScrollBars="Vertical" Width="100%">
                                <asp:GridView ID="Grid_users" runat="server" Width="99%" ForeColor="SteelBlue" CssClass="gridRow2"
                                    OnRowEditing="Grid_users_RowEditing" BorderColor="White" BackColor="White" AutoGenerateColumns="False"
                                    HorizontalAlign="Center">
                                    <PagerSettings FirstPageText="" LastPageText="" Mode="NextPrevious" NextPageText="Next"
                                        PreviousPageText="Previous"></PagerSettings>
                                    <RowStyle ForeColor="Black"></RowStyle>
                                    <Columns>
                                        <asp:BoundField DataField="CUSTOMER_ID" HeaderText="Customer Id">
                                            <HeaderStyle CssClass="hiddencol"></HeaderStyle>
                                            <ItemStyle CssClass="hiddencol"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:BoundField DataField="DISTRIBUTOR_ID" HeaderText="DISTRIBUTOR_ID">
                                            <HeaderStyle CssClass="hiddencol"></HeaderStyle>
                                            <ItemStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid" CssClass="hiddencol">
                                            </ItemStyle>
                                        </asp:BoundField>
                                        <asp:BoundField DataField="BUSINESS_TYPE_ID" HeaderText="BUSINESS_TYPE_ID">
                                            <HeaderStyle CssClass="hiddencol"></HeaderStyle>
                                            <ItemStyle CssClass="hiddencol"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:BoundField DataField="PROMOTION_CLASS" HeaderText="PROMOTION_CLASS">
                                            <HeaderStyle CssClass="hiddencol"></HeaderStyle>
                                            <ItemStyle CssClass="hiddencol"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:BoundField DataField="CHANNEL_TYPE_ID" HeaderText="CHANNEL_TYPE_ID">
                                            <HeaderStyle CssClass="hiddencol"></HeaderStyle>
                                            <ItemStyle CssClass="hiddencol"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:BoundField DataField="TOWN_ID" HeaderText="TOWN_ID">
                                            <HeaderStyle CssClass="hiddencol"></HeaderStyle>
                                            <ItemStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid" CssClass="hiddencol">
                                            </ItemStyle>
                                        </asp:BoundField>
                                        <asp:BoundField DataField="AREA_ID" HeaderText="AREA_ID">
                                            <HeaderStyle CssClass="hiddencol"></HeaderStyle>
                                            <ItemStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid" CssClass="hiddencol">
                                            </ItemStyle>
                                        </asp:BoundField>
                                        <asp:BoundField DataField="ROUTE_ID" HeaderText="ROUTE_ID">
                                            <HeaderStyle CssClass="hiddencol"></HeaderStyle>
                                            <ItemStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid" CssClass="hiddencol">
                                            </ItemStyle>
                                        </asp:BoundField>
                                        <asp:BoundField DataField="CUSTOMER_CODE" HeaderText="Code">
                                            <ItemStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:BoundField DataField="CUSTOMER_NAME" HeaderText="Name">
                                            <ItemStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:BoundField DataField="CONTACT_PERSON" HeaderText="Contact Person">
                                            <HeaderStyle CssClass="hiddencol"></HeaderStyle>
                                            <ItemStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid" CssClass="hiddencol">
                                            </ItemStyle>
                                        </asp:BoundField>
                                        <asp:BoundField DataField="CONTACT_NUMBER" HeaderText="Contact Number">
                                            <ItemStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:BoundField DataField="EMAIL_ADDRESS" HeaderText="Email">
                                            <HeaderStyle CssClass="hiddencol"></HeaderStyle>
                                            <ItemStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid" CssClass="hiddencol">
                                            </ItemStyle>
                                        </asp:BoundField>
                                        <asp:BoundField DataField="ADDRESS" HeaderText="ADDRESS">
                                            <ItemStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:BoundField DataField="GST_NUMBER" HeaderText="Gst No">
                                            <HeaderStyle CssClass="hiddencol"></HeaderStyle>
                                            <ItemStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid" CssClass="hiddencol">
                                            </ItemStyle>
                                        </asp:BoundField>
                                        <asp:BoundField DataField="ChannelType" HeaderText="Channel Type">
                                            <ItemStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:BoundField DataField="GEO_NAME" HeaderText="Town">
                                            <ItemStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:BoundField DataField="AREA_NAME" HeaderText="Route">
                                            <ItemStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:BoundField DataField="ROUTE_NAME" HeaderText="Market">
                                            <ItemStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:BoundField DataField="IS_ACTIVE" HeaderText="Status">
                                            <ItemStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:BoundField DataField="REGDATE">
                                            <HeaderStyle CssClass="hiddencol"></HeaderStyle>
                                            <ItemStyle CssClass="hiddencol"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:BoundField DataField="CUSTOMER_TYPE_ID" HeaderText="ROUTE_ID">
                                            <HeaderStyle CssClass="hiddencol"></HeaderStyle>
                                            <ItemStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid" CssClass="hiddencol">
                                            </ItemStyle>
                                        </asp:BoundField>
                                        <asp:BoundField DataField="REFFERED_BY" HeaderText="REFFERED_BY">
                                            <HeaderStyle CssClass="hiddencol"></HeaderStyle>
                                            <ItemStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid" CssClass="hiddencol">
                                            </ItemStyle>
                                        </asp:BoundField>
                                        <asp:CommandField ShowEditButton="True" HeaderText="Edit">
                                            <ItemStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid"></ItemStyle>
                                        </asp:CommandField>
                                    </Columns>
                                    <FooterStyle BackColor="White"></FooterStyle>
                                    <PagerStyle BackColor="Transparent"></PagerStyle>
                                    <HeaderStyle CssClass="tblhead" ForeColor="White"></HeaderStyle>
                                    <AlternatingRowStyle BackColor="#F2F2F2" CssClass="GridAlternateRowStyle" ForeColor="#333333">
                                    </AlternatingRowStyle>
                                </asp:GridView>
                            </asp:Panel>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </ContentTemplate>
            </cc1:TabPanel>
            <cc1:TabPanel ID="TabPanel2" runat="server">
                <HeaderTemplate>
                    Security&nbsp;
                </HeaderTemplate>
                <ContentTemplate>
                    <div id="Div1">
                        <table width="100%">
                            <tr>
                                <td style="height: 25px">
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <div style="z-index: 101; left: 484px; width: 100px; position: absolute; top: 254px;
                                        height: 100px">
                                        <asp:Panel ID="Panel3" runat="server">
                                            <asp:UpdateProgress ID="UpdateProgress2" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
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
                                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                        <ContentTemplate>
                                            <table width="100%">
                                                <tr>
                                                    <td style="width: 100%; padding-left: 60px;" colspan="3">
                                                        <fieldset style="width: 255px;">
                                                            <asp:RadioButtonList ID="rblTransactionType" runat="server" RepeatDirection="Horizontal"
                                                                AutoPostBack="True" OnSelectedIndexChanged="rblTransactionType_SelectedIndexChanged"
                                                                Width="250px">
                                                                <asp:ListItem Text="Received" Value="0" Selected="True"></asp:ListItem>
                                                                <asp:ListItem Text="Return" Value="1"></asp:ListItem>
                                                            </asp:RadioButtonList>
                                                            <legend></legend>
                                                        </fieldset>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="3">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 12%" align="right">
                                                        <strong>
                                                            <asp:Label ID="lbltoLocation2" runat="server" Width="94px" Text="Location:"></asp:Label></strong>
                                                    </td>
                                                    <td style="width: 1%">
                                                    </td>
                                                    <td style="width: 87%">
                                                        <asp:DropDownList ID="drpDistributor2" runat="server" Width="200px" CssClass="DropList"
                                                            AutoPostBack="True" OnSelectedIndexChanged="drpDistributor2_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 12%" align="right">
                                                        <strong>
                                                            <asp:Label ID="Label8" runat="server" Width="94px" Text="Principal:"></asp:Label></strong>
                                                    </td>
                                                    <td style="width: 1%">
                                                    </td>
                                                    <td style="width: 87%">
                                                        <asp:DropDownList ID="DrpPrincipal2" runat="server" Width="200px" AutoPostBack="True"
                                                            OnSelectedIndexChanged="DrpPrincipal2_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 12%" align="right">
                                                        <strong>
                                                            <asp:Label ID="Label9" runat="server" Text="Customer Route:"></asp:Label></strong>
                                                    </td>
                                                    <td style="width: 1%">
                                                    </td>
                                                    <td style="width: 87%">
                                                        <asp:DropDownList ID="DrpRoute2" runat="server" Width="200px" CssClass="DropList"
                                                            AutoPostBack="True" OnSelectedIndexChanged="DrpRoute2_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 12%" align="right">
                                                        <strong>
                                                            <asp:Label ID="Label11" runat="server" Text="Customer:"></asp:Label></strong>
                                                    </td>
                                                    <td style="width: 1%">
                                                    </td>
                                                    <td style="width: 87%">
                                                        <asp:DropDownList ID="ddlCustomer2" runat="server" Width="200px" AutoPostBack="True"
                                                            OnSelectedIndexChanged="ddlCustomer2_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 12%" align="right">
                                                        <strong>
                                                            <asp:Label ID="Label12" runat="server" Text="Sale Force:"></asp:Label></strong>
                                                    </td>
                                                    <td style="width: 1%">
                                                    </td>
                                                    <td style="width: 87%">
                                                        <asp:DropDownList ID="DrpDeliveryMan2" runat="server" Width="200px" CssClass="DropList"
                                                            AutoPostBack="True" OnSelectedIndexChanged="DrpDeliveryMan2_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 12%" align="right">
                                                        <strong>
                                                            <asp:Label ID="Label13" runat="server" Text="SKU:"></asp:Label></strong>
                                                    </td>
                                                    <td style="width: 1%">
                                                    </td>
                                                    <td style="width: 87%">
                                                        <asp:DropDownList ID="ddlSKU2" runat="server" Width="200px" AutoPostBack="True" OnSelectedIndexChanged="ddlSKU2_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 12%" align="right">
                                                        <strong>
                                                            <asp:Label ID="Label20" runat="server" Text="Document No:"></asp:Label></strong>
                                                    </td>
                                                    <td style="width: 1%">
                                                    </td>
                                                    <td style="width: 87%">
                                                        <asp:TextBox ID="txtDocumentNo" runat="server" Width="200px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 12%" align="right">
                                                        <strong>
                                                            <asp:Label ID="lblReffileRate" runat="server" Text="Refilling Rate:"></asp:Label></strong>
                                                    </td>
                                                    <td style="width: 1%">
                                                    </td>
                                                    <td style="width: 87%">
                                                        <asp:TextBox ID="txtRate2" runat="server" Width="200px"></asp:TextBox>
                                                        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" FilterType="Custom"
                                                            ValidChars="0123456789." TargetControlID="txtRate2">
                                                        </cc1:FilteredTextBoxExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 12%" align="right">
                                                        <strong>
                                                            <asp:Label ID="Label15" runat="server" Text="Quantity:"></asp:Label></strong>
                                                    </td>
                                                    <td style="width: 1%">
                                                    </td>
                                                    <td style="width: 87%">
                                                        <asp:TextBox ID="txtNoOfBottles" runat="server" Width="200px"></asp:TextBox>
                                                        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" FilterType="Custom"
                                                            ValidChars="0123456789" TargetControlID="txtNoOfBottles">
                                                        </cc1:FilteredTextBoxExtender>
                                                        <asp:CheckBox ID="chbIsPermanent" runat="server" Text="Is Permanent" AutoPostBack="True"
                                                            Checked="true"></asp:CheckBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 12%" align="right">
                                                        <strong>
                                                            <asp:Label ID="Label16" runat="server" Text="Security Amount:"></asp:Label></strong>
                                                    </td>
                                                    <td style="width: 1%">
                                                    </td>
                                                    <td style="width: 87%">
                                                        <asp:TextBox ID="txtAmount2" runat="server" Width="200px"></asp:TextBox>
                                                        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" FilterType="Custom"
                                                            ValidChars="0123456789." TargetControlID="txtAmount2">
                                                        </cc1:FilteredTextBoxExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 12%" align="right">
                                                        <strong>
                                                            <asp:Label ID="Label17" runat="server" Text="Remarks:"></asp:Label></strong>
                                                    </td>
                                                    <td style="width: 1%">
                                                    </td>
                                                    <td style="width: 87%">
                                                        <asp:TextBox ID="txtRemarks" runat="server" Width="200px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 12%; height: 42px;" align="right">
                                                    </td>
                                                    <td style="width: 1%; height: 42px;">
                                                    </td>
                                                    <td style="width: 87%; height: 42px;">
                                                        <br />
                                                        <asp:Button ID="btnSave2" runat="server" CssClass="button" Text="Save" OnClick="btnSave2_Click"
                                                            Width="85px" />&nbsp;&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 100%" colspan="3">
                                                        <asp:HiddenField ID="hfCUSTOMER_SECURITY_ID" runat="server" />
                                                        <br />
                                                        <asp:Panel ID="Panel4" runat="server" Width="700px" Height="200px" ScrollBars="Vertical"
                                                            BorderColor="Silver" BorderStyle="Groove" BorderWidth="1px">
                                                            <asp:GridView Width="99%" ID="gvSecurity" runat="server" ForeColor="SteelBlue" BackColor="White"
                                                                HorizontalAlign="Center" AutoGenerateColumns="False" BorderColor="White" OnRowDeleting="gvSecurity_RowDeleting"
                                                                OnRowEditing="gvSecurity_RowEditing">
                                                                <RowStyle ForeColor="Black"></RowStyle>
                                                                <Columns>
                                                                    <asp:BoundField DataField="CUSTOMER_SECURITY_ID" HeaderText="CUSTOMER_SECURITY_ID">
                                                                        <HeaderStyle CssClass="hiddencol"></HeaderStyle>
                                                                        <ItemStyle CssClass="hiddencol"></ItemStyle>
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="CUSTOMER_NAME" HeaderText="Customer">
                                                                        <ItemStyle HorizontalAlign="Left" BorderColor="Silver" BorderWidth="2px" BorderStyle="Solid"
                                                                            Width="150px"></ItemStyle>
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="USER_NAME" HeaderText="Sale Force">
                                                                        <ItemStyle HorizontalAlign="Left" BorderColor="Silver" BorderWidth="2px" BorderStyle="Solid"
                                                                            Width="100px"></ItemStyle>
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="SKU_NAME" HeaderText="SKU">
                                                                        <ItemStyle BorderColor="Silver" BorderWidth="2px" BorderStyle="Solid" Width="120px">
                                                                        </ItemStyle>
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="NoOfBottles" HeaderText="Quantity">
                                                                        <ItemStyle HorizontalAlign="Right" BorderColor="Silver" BorderWidth="2px" BorderStyle="Solid"
                                                                            Width="70px"></ItemStyle>
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="SECURITY_AMOUNT" HeaderText="Security Amount" DataFormatString="{0:F2}">
                                                                        <ItemStyle HorizontalAlign="Right" BorderColor="Silver" BorderWidth="2px" BorderStyle="Solid"
                                                                            Width="70px"></ItemStyle>
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="RATE" HeaderText="Rate" DataFormatString="{0:F2}">
                                                                        <ItemStyle HorizontalAlign="Right" BorderColor="Silver" BorderWidth="2px" BorderStyle="Solid"
                                                                            Width="50px"></ItemStyle>
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="REMARKS" HeaderText="Remarks">
                                                                        <ItemStyle BorderColor="Silver" BorderWidth="2px" BorderStyle="Solid" Width="120px">
                                                                        </ItemStyle>
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="SKU_ID" HeaderText="SKU_ID">
                                                                        <HeaderStyle CssClass="hiddencol"></HeaderStyle>
                                                                        <ItemStyle CssClass="hiddencol"></ItemStyle>
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="is_permanent" HeaderText="SKU_ID">
                                                                        <HeaderStyle CssClass="hiddencol"></HeaderStyle>
                                                                        <ItemStyle CssClass="hiddencol"></ItemStyle>
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="DOCUMENT_NO" HeaderText="DOCUMENT_NO">
                                                                        <HeaderStyle CssClass="hiddencol"></HeaderStyle>
                                                                        <ItemStyle CssClass="hiddencol"></ItemStyle>
                                                                    </asp:BoundField>
                                                                    <asp:CommandField ShowEditButton="True" HeaderText="Edit">
                                                                        <ItemStyle BorderColor="Silver" BorderWidth="1px" Width="40px"></ItemStyle>
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                    </asp:CommandField>
                                                                    <asp:TemplateField HeaderText="Delete">
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="btnDelete" runat="server" Text="Delete" OnClientClick="javascript:return confirm('Are you sure you want to Delete?');return false;"
                                                                                CommandName="Delete"></asp:LinkButton>
                                                                        </ItemTemplate>
                                                                        <ItemStyle BorderColor="Silver" BorderWidth="2px" BorderStyle="Solid" Width="45px">
                                                                        </ItemStyle>
                                                                        <HeaderStyle HorizontalAlign="Center" />
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
                                                <tr>
                                                    <td colspan="3">
                                                        <div style="z-index: 201; overflow: hidden; left: 404px; width: 500px; position: absolute;
                                                            top: 166px; height: 201px">
                                                            <asp:Panel ID="Panel5" runat="server" BorderColor="Silver" BorderStyle="Groove" BorderWidth="1px"
                                                                Height="196px">
                                                                <asp:GridView ID="gvInfo" runat="server" ForeColor="SteelBlue" BackColor="White"
                                                                    HorizontalAlign="Center" AutoGenerateColumns="False" BorderColor="gray" CssClass="gridRow2"
                                                                    Visible="true" AllowSorting="false" Style="overflow: hidden;" VerticalScrollBarVisibility="Hidden"
                                                                    HorizontalScrollBarVisibility="Hidden">
                                                                    <RowStyle ForeColor="Black"></RowStyle>
                                                                    <HeaderStyle ForeColor="SteelBlue" Font-Bold="True" BackColor="#52791B"></HeaderStyle>
                                                                    <Columns>
                                                                        <asp:BoundField DataField="DOCUMENT_DATE" HeaderText="Date">
                                                                            <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="2px" Width="200px" />
                                                                            <HeaderStyle HorizontalAlign="Left" />
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="SKU_NAME" HeaderText="SKU Name">
                                                                            <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="2px" Width="350px" />
                                                                            <HeaderStyle HorizontalAlign="Left" />
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="NoOfBottles" HeaderText="Quantity" DataFormatString="{0:F2}">
                                                                            <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="2px" HorizontalAlign="Right"
                                                                                Width="90px" />
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="SECURITY_AMOUNT" HeaderText="Amount" DataFormatString="{0:F2}">
                                                                            <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="2px" HorizontalAlign="Right"
                                                                                Width="150px" />
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="SECURITY" HeaderText="NET Security Amount">
                                                                            <HeaderStyle CssClass="hiddencol"></HeaderStyle>
                                                                            <ItemStyle CssClass="hiddencol"></ItemStyle>
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="Is_Permanent" HeaderText="Status">
                                                                            <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="2px" HorizontalAlign="Right"
                                                                                Width="150px" />
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                        </asp:BoundField>
                                                                    </Columns>
                                                                </asp:GridView>
                                                            </asp:Panel>
                                                        </div>
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
                    </div>
                </ContentTemplate>
            </cc1:TabPanel>
       </cc1:TabContainer>
    </div>
</asp:Content>
