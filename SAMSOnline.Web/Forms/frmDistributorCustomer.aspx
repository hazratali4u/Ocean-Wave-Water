<%@ Page Language="C#" MasterPageFile="~/Forms/PageMaster.master" AutoEventWireup="true"
    CodeFile="frmDistributorCustomer.aspx.cs" Inherits="Forms_frmDistributorCustomer"
    Title="SAMS >>  New Customer" %>

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
        <table width="100%">
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
                                            <asp:TextBox ID="txtRegdate" runat="server" Width="200px" CssClass="txtBox" ReadOnly="True"></asp:TextBox>
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
                                        <td style="width: 1px">
                                        </td>
                                        <td align="left" colspan="2" rowspan="4">
                                            <asp:Panel ID="Panel1" runat="server" Width="100%" Height="105px" ScrollBars="Vertical"
                                                BorderColor="Black" BorderStyle="Solid" BorderWidth="1px">
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
                                                                <asp:TextBox ID="txtCreditLimit" runat="server" Width="83px" CssClass="txtBox"></asp:TextBox>
                                                            </ItemTemplate>
                                                            <ItemStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid" Width="100px">
                                                            </ItemStyle>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Credit Days">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtCreditDays" runat="server" CssClass="txtBox " Width="49px"></asp:TextBox>
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
                                        <td style="width: 1px; height: 25px">
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
                                                Text="Save" ValidationGroup="vg" CssClass="btn" />&nbsp;
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
    </div>
</asp:Content>
