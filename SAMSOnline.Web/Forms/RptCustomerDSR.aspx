<%@ Page Language="C#" MasterPageFile="~/Forms/PageMaster.master" AutoEventWireup="true" CodeFile="RptCustomerDSR.aspx.cs" Inherits="Forms_RptCustomerDSR" Title="SAMS >> Customer Wise (DSR)" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cphPage">
     <script language="JavaScript" type="text/javascript">
    function ValidateForm()
	{
			
		return true;	  		
	}

    </script>
     <div id="right_data">
        <table width="100%">
            <tr>
                <td>
                    <asp:UpdatePanel id="UpdatePanel1" runat="server">
                        <contenttemplate>
<TABLE><TR><TD align=left colSpan=4>
<strong><asp:Label id="lblErrorMsg" runat="server" ForeColor="Red" Font-Bold="True"></asp:Label></strong> </TD>
</TR>
    <tr>
        <td align="left">
        </td>
        <td align="left">
            <strong><asp:Label ID="Label1" runat="server" Text="DSR" Width="82px"></asp:Label></strong></td>
        <td align="left">
        </td>
        <td align="left" style="height: 25px">
            <asp:RadioButtonList ID="RbReportType" runat="server" RepeatDirection="Horizontal" AutoPostBack="True" OnSelectedIndexChanged="RbReportType_SelectedIndexChanged">
                <asp:ListItem Selected="True">Product Wise</asp:ListItem>
                <asp:ListItem>Value Wise</asp:ListItem>
            </asp:RadioButtonList></td>
    </tr>
    <tr>
        <td align="left">
        </td>
        <td align="left">
            <strong><asp:Label ID="Label2" runat="server" Text="Report Type" Width="82px"></asp:Label></strong></td>
        <td align="left">
        </td>
        <td align="left" style="height: 25px"><asp:DropDownList id="DrpReportType" runat="server" Width="200px" CssClass="DropList" AutoPostBack="True" OnSelectedIndexChanged="drpDistributor_SelectedIndexChanged">
            <asp:ListItem>Sale</asp:ListItem>
            <asp:ListItem>Sale Return</asp:ListItem>
            <asp:ListItem>Scheme</asp:ListItem>
        </asp:DropDownList></td>
    </tr>
    <TR><TD align=left></TD>
    <td align="left">
        <strong><asp:Label ID="lbltoLocation" runat="server" CssClass="lblbox" Text="Location" Width="73px"></asp:Label></strong></td>
    <td align="left">
    </td>
    <TD style="HEIGHT: 25px" align=left><asp:DropDownList id="drpDistributor" runat="server" Width="200px" CssClass="DropList" AutoPostBack="True" OnSelectedIndexChanged="drpDistributor_SelectedIndexChanged">
    </asp:DropDownList></TD>
</TR>
    <tr>
        <td align="left">
        </td>
        <td align="left">
            <strong><asp:Label ID="lblfromLocation" runat="server" CssClass="lblbox" Text="Customer Route"
                Width="94px"></asp:Label></strong></td>
        <td align="left">
        </td>
        <td align="left" style="height: 25px">
            <asp:DropDownList ID="DrpRoute" runat="server" CssClass="DropList" Width="200px" OnSelectedIndexChanged="DrpRoute_SelectedIndexChanged">
            </asp:DropDownList></td>
    </tr>
    <tr>
        <td align="left">
        </td>
        <td align="left">
            <strong><asp:Label ID="Label6" runat="server" CssClass="lblbox" Text="Principal" Width="78px"></asp:Label></strong></td>
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
            <strong><asp:Label ID="lblNickName" runat="server" CssClass="lblbox" Text="Channel Type"
                Width="79px"></asp:Label></strong></td>
        <td align="left">
        </td>
        <td align="left" style="height: 25px">
            <asp:DropDownList ID="drpChannelType" runat="server" CssClass="DropList" Width="199px">
            </asp:DropDownList></td>
    </tr>
    <tr>
        <td align="left">
        </td>
        <td align="left">
            <strong><asp:Label ID="Label5" runat="server" CssClass="lblbox" Text="Sale Force" Width="79px"></asp:Label></strong></td>
        <td align="left">
        </td>
        <td align="left" style="height: 25px">
            <asp:DropDownList ID="DrpSaleForce" runat="server" CssClass="DropList" Width="199px">
            </asp:DropDownList></td>
    </tr>
    <tr>
        <td align="left">
        </td>
        <td align="left">
            <strong><asp:Label ID="Label3" runat="server" Height="13px" Text="From" Width="70px"></asp:Label></strong></td>
        <td align="left">
        </td>
        <td align="left" style="height: 25px">
            &nbsp;<asp:TextBox ID="txtStartDate" runat="server" CssClass="txtBox" MaxLength="10"
                onkeyup="BlockStartDateKeyPress()" Width="150px"></asp:TextBox>
            <asp:ImageButton ID="ibtnStartDate" runat="server" ImageUrl="~/App_Themes/Granite/Images/date.gif"
                Width="16px" /></td>
    </tr>
    <tr>
        <td align="left">
        </td>
        <td align="left">
            <strong><asp:Label ID="Label4" runat="server" Height="13px" Text="To" Width="80px"></asp:Label></strong></td>
        <td align="left">
        </td>
        <td align="left" style="height: 25px">
            &nbsp;<asp:TextBox ID="txtEndDate" runat="server" CssClass="txtBox " MaxLength="10"
                onkeyup="BlockEndDateKeyPress()" Width="150px"></asp:TextBox>
            <asp:ImageButton ID="ibnEndDate" runat="server" ImageUrl="~/App_Themes/Granite/Images/date.gif"
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
            <asp:CheckBox ID="CheckBox1" runat="server" Text="Is Registered Customer" Width="174px" Enabled="False" /></td>
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
            <cc1:CalendarExtender ID="CEStartDate" runat="server" Format="dd-MMM-yyyy"
                PopupButtonID="ibtnStartDate" TargetControlID="txtStartDate">
            </cc1:CalendarExtender>
            <cc1:CalendarExtender ID="CEEndDate" runat="server" Format="dd-MMM-yyyy" PopupButtonID="ibnEndDate"
                TargetControlID="txtEndDate">
            </cc1:CalendarExtender>
            </td>
    </tr>
</TABLE>
</contenttemplate>
                    </asp:UpdatePanel>
                    &nbsp; &nbsp;
        <asp:Button ID="Button2" runat="server" 
                Text="View PDF" CssClass="btn" OnClick="Button2_Click" />
                    <asp:Button ID="Button1" runat="server" 
                Text="View Excel" CssClass="btn" OnClick="Button1_Click" /></td>
            </tr>
        </table>
           </div>
</asp:Content>

