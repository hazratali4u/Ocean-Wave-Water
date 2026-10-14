<%@ Page Language="C#" MasterPageFile="~/Forms/PageMaster.master" AutoEventWireup="true" CodeFile="RptCustomerInvoiceReport.aspx.cs" Inherits="Forms_RptCustomerInvoiceReport" Title="SAMS >> Customer Invoice Wise Sales" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cphPage">
     <script language="JavaScript" type="text/javascript">
    function ValidateForm()
	{
			
		return true;	  		
	}

	function onCalendarShown1() {
	    var cal = $find("calendar1");
	    cal._switchMode("months", true);
	    if (cal._monthsBody) {
	        for (var i = 0; i < cal._monthsBody.rows.length; i++) {
	            var row = cal._monthsBody.rows[i];
	            for (var j = 0; j < row.cells.length; j++) {
	                Sys.UI.DomEvent.addHandler(row.cells[j].firstChild, "click", call1);
	            }
	        }
	    }
	}

	function call1(eventElement) {
	    var target = eventElement.target;
	    switch (target.mode) {
	        case "month":
	            var cal = $find("calendar1");
	            cal._visibleDate = target.date;
	            cal.set_selectedDate(target.date);
	            cal._switchMonth(target.date);
	            cal._blur.post(true);
	            cal.raiseDateSelectionChanged();
	            break;
	    }
	}

	function onCalendarHidden1() {
	    var cal = $find("calendar1");

	    if (cal._monthsBody) {
	        for (var i = 0; i < cal._monthsBody.rows.length; i++) {
	            var row = cal._monthsBody.rows[i];
	            for (var j = 0; j < row.cells.length; j++) {
	                Sys.UI.DomEvent.removeHandler(row.cells[j].firstChild, "click", call1);
	            }
	        }
	    }
	}	
    </script>
     <div id="right_data">
        <table width="100%">
            <tr>
                <td>
                    <asp:UpdatePanel id="UpdatePanel1" runat="server">
                        <contenttemplate>
<TABLE>
    <tr>
        <td align="left">
        </td>
        <td align="left" colspan="3">
        </td>
    </tr>
    <tr>
        <td align="left">
        </td>
        <td align="left">
            <strong><asp:Label ID="Label6" runat="server" CssClass="lblbox" Text="Principal" Width="70px"></asp:Label></strong></td>
        <td align="left">
        </td>
        <td align="left" style="height: 25px">
            <asp:DropDownList id="DrpPrincipal" runat="server" Width="200px" CssClass="DropList">
            </asp:DropDownList></td>
    </tr>
    <tr>
        <td align="left">
        </td>
        <td align="left">
            <strong><asp:Label ID="lbltoLocation" runat="server" CssClass="lblbox" Text="Location" Width="94px"></asp:Label></strong></td>
        <td align="left">
        </td>
        <td align="left" style="height: 25px">
            <asp:DropDownList ID="drpDistributor" runat="server" CssClass="DropList" Width="200px">
            </asp:DropDownList></td>
    </tr>
    <tr>
        <td align="left">
        </td>
        <td align="left">
            <strong><asp:Label ID="Label1" runat="server" Text="SKU" Width="94px"></asp:Label></strong></td>
        <td align="left">
        </td>
        <td align="left" style="height: 25px">
            <asp:DropDownList ID="ddlSKU" runat="server" Width="200px">
            </asp:DropDownList></td>
    </tr>
    <tr>
        <td align="left">
        </td>
        <td align="left">
            <strong><asp:Label ID="Label3" runat="server" Height="13px" Text="For Month" Width="77px"></asp:Label></strong></td>
        <td align="left">
        </td>
        <td align="left" style="height: 25px">
            <asp:TextBox ID="txtStartDate" runat="server" CssClass="txtBox" MaxLength="10"
                onkeyup="BlockStartDateKeyPress()" Width="150px"></asp:TextBox>
            <asp:ImageButton ID="ibtnStartDate" runat="server" ImageUrl="~/App_Themes/Granite/Images/date.gif"
                Width="16px" /></td>
    </tr>    
    <tr>
        <td align="left">
        </td>
        <td align="left">
        </td>
        <td align="left">
        </td>
        <td align="left" style="height: 25px">
            <asp:RadioButtonList ID="RblCustomer" runat="server" OnSelectedIndexChanged="RblCustomer_SelectedIndexChanged" AutoPostBack="true">
                <asp:ListItem Selected="True">Show All Customer</asp:ListItem>
                <asp:ListItem>Individulal Customer</asp:ListItem>
            </asp:RadioButtonList></td>
    </tr>
    <tr>
        <td align="left">
            </td>
        <td align="left">
        </td>
        <td align="left">
        </td>
        <td align="left" style="height: 25px">
            <%@ register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
            <cc1:CalendarExtender ID="CEStartDate" runat="server" BehaviorID="calendar1" OnClientShown="onCalendarShown1" OnClientHidden="onCalendarHidden1" Format="MMM-yyyy"
                PopupButtonID="ibtnStartDate" TargetControlID="txtStartDate">
            </cc1:CalendarExtender>            
            </td>
    </tr>
</TABLE>
                            &nbsp;
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
                            width: 95%; border-bottom: silver thin inset; background-color: silver">
                            <tbody>
                                <tr>
                                    <td align="left" style="height: 21px">
                                        <strong><asp:Label ID="Label10" runat="server" Text="Select Searching Type" Width="127px"></asp:Label></strong>
                                    </td>
                                    <td align="left" style="width: 170px; height: 21px">
                                        <asp:DropDownList ID="ddSearchType" runat="server" CssClass="DropList" Width="195px">
                                            <asp:ListItem Value="CUSTOMER_NAME">Customer Name</asp:ListItem>
                                            <asp:ListItem Value="ADDRESS">Address</asp:ListItem>
                                            <asp:ListItem Value="Distributor_NAME">Location</asp:ListItem>
                                            <asp:ListItem Value="AREA_NAME">Route Name</asp:ListItem>
                                            <asp:ListItem Value="SLASH_DESC">Channel Type</asp:ListItem>
                                            <asp:ListItem Value="CUSTOMER_CODE">Customer Code</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td align="right">
                                        &nbsp;Value%</td>
                                    <td align="left" style="width: 224px; height: 21px">
                                        <asp:TextBox ID="txtSeach" runat="server" CssClass="txtBox " Width="200px"></asp:TextBox>
                                    </td>
                                    <td align="left" style="height: 21px" width="250">
                                        <asp:Button ID="btnFilter" runat="server" OnClick="btnFilter_Click" Text="Filter" Enabled="false"
                                            CssClass="btn" />
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                        <asp:Panel ID="Panel2" runat="server" Height="169px" ScrollBars="Vertical" Width="95%">
                            <asp:GridView ID="Grid_users" runat="server" AutoGenerateColumns="False" BackColor="White"
                                BorderColor="White" CssClass="gridRow2" ForeColor="SteelBlue" HorizontalAlign="Center" Width="99%">
                                <PagerSettings FirstPageText="" LastPageText="" Mode="NextPrevious" NextPageText="Next"
                                    PreviousPageText="Previous" />
                                <RowStyle ForeColor="Black" />
                                <Columns>
                                    <asp:TemplateField HeaderText="Select">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="ChbCustomer" runat="server" />
                                        </ItemTemplate>
                                        <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="CUSTOMER_ID" HeaderText="CUSTOMER_ID">
                                        <HeaderStyle CssClass="hiddencol" />
                                        <ItemStyle CssClass="hiddencol" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Distributor_id" HeaderText="Distributor_id">
                                        <HeaderStyle CssClass="hiddencol" />
                                        <ItemStyle CssClass="hiddencol" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="CUSTOMER_CODE" HeaderText="Code">
                                        <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="CUSTOMER_NAME" HeaderText="Name">
                                        <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Distributor_Name" HeaderText="Location">
                                        <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="AREA_NAME" HeaderText="Route">
                                        <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ADDRESS" HeaderText="ADDRESS">
                                        <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ChannelType" HeaderText="Channel Type">
                                        <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Left" />
                                    </asp:BoundField>
                                </Columns>
                                <FooterStyle BackColor="White" />
                                <PagerStyle BackColor="Transparent" />
                                <HeaderStyle CssClass="tblhead" />
                                <AlternatingRowStyle BackColor="#F2F2F2" CssClass="GridAlternateRowStyle" ForeColor="#333333" />
                            </asp:GridView>
                        </asp:Panel>
                    </ContentTemplate>
                </asp:UpdatePanel>
                    <asp:Button ID="BtnViewPdf" runat="server" OnClick="BtnViewPdf_Click"
                        Text="View PDF" CssClass="btn" />
                <asp:Button ID="btnViewExcel" runat="server" 
                Text="View Excel" CssClass="btn" OnClick="btnViewExcel_Click" />
            
            </td>
        </tr>
    </table>
    </div>
</asp:Content>
