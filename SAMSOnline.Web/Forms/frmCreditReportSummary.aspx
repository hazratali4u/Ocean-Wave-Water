<%@ Page Language="C#" MasterPageFile="~/Forms/PageMaster.master" AutoEventWireup="true" CodeFile="frmCreditReportSummary.aspx.cs" Inherits="Forms_frmCreditReportSummary" Title="SAMS >> Credit Report" %>
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
        <td align="left" colspan="4">
            <asp:RadioButtonList ID="rbtSotBy" runat="server" Width="250px" RepeatDirection="Horizontal">
                <asp:ListItem Selected="True">Credit Report</asp:ListItem>
                <asp:ListItem>Credit Limit</asp:ListItem>
            </asp:RadioButtonList></td>
    </tr>
    <tr>
        <td align="left">
        </td>
        <td align="left">
        <strong><asp:Label ID="lbltoLocation" runat="server" CssClass="lblbox" Text="Location" Width="94px"></asp:Label></strong></td>
        <td align="left">
        </td>
        <td align="left" style="height: 25px">
            <asp:DropDownList id="drpDistributor" runat="server" Width="200px" CssClass="DropList" OnSelectedIndexChanged="drpDistributor_SelectedIndexChanged" AutoPostBack="True">
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
            <strong><asp:Label ID="Label5" runat="server" CssClass="lblbox" Text="T.S.O" Width="79px"></asp:Label></strong></td>
        <td align="left">
        </td>
        <td align="left" style="height: 25px">
            <asp:DropDownList ID="DrpOrderBooker" runat="server" CssClass="DropList" Width="200px">
            </asp:DropDownList></td>
    </tr>
    <tr>
        <td align="left">
        </td>
        <td align="left">
            <strong><asp:Label ID="Label1" runat="server" CssClass="lblbox" Text="Sale Force" Width="94px"></asp:Label></strong></td>
        <td align="left">
        </td>
        <td align="left" style="height: 25px">
            <asp:DropDownList ID="DrpDeliveryMan" runat="server" CssClass="DropList" Width="200px">
            </asp:DropDownList></td>
    </tr>
    <tr>
        <td align="left">
        </td>
        <td align="left">
            <strong><asp:Label ID="Label3" runat="server" Height="13px" Text="From Date" Width="76px"></asp:Label></strong></td>
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
            <strong><asp:Label ID="Label4" runat="server" Height="13px" Text="To Date" Width="80px"></asp:Label></strong></td>
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
