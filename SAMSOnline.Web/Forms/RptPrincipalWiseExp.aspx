<%@ Page Language="C#" MasterPageFile="~/Forms/PageMaster.master" AutoEventWireup="true" CodeFile="RptPrincipalWiseExp.aspx.cs" Inherits="Forms_RptPrincipalWiseExp" Title="SAMS >> Petty Expense Summary" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="ID" runat="server" ContentPlaceHolderID="cphPage">
       
    <div id="right_data">
        <table width="100%">
            <tr>
                <td>
                    <asp:UpdatePanel id="UpdatePanel1" runat="server">
                        <contenttemplate>
<TABLE><TBODY><TR><TD align=left colSpan=4>
<asp:Label id="lblErrorMsg" runat="server" ForeColor="Red" Font-Bold="True"></asp:Label> </TD><TD style="WIDTH: 1px" align=left colSpan=1></TD></TR>
    <tr>
        <td align="left">
        </td>
        <td align="left" style="width: 90px">
           <strong><asp:Label ID="Label6" runat="server" CssClass="lblbox" Text="Report Type" Width="83px"></asp:Label></strong> </td>
        <td align="left" style="width: 1px">
        </td>
        <td align="left" style="width: 204px; height: 25px">
            <asp:RadioButtonList ID="RadioButtonList1" runat="server">
                <asp:ListItem Selected="True">Principal Wise Petty Report</asp:ListItem>
                <asp:ListItem>Branch Wise Petty Report</asp:ListItem>
            </asp:RadioButtonList></td>
        <td align="left" style="width: 1px; height: 25px">
        </td>
    </tr>
    <TR><TD align=left></TD><TD style="WIDTH: 90px" align=left>
    <strong> <asp:Label id="Label2" runat="server" Width="48px" Text="Location" CssClass="lblbox"></asp:Label></strong> </TD><TD style="WIDTH: 1px" align=left></TD><TD style="WIDTH: 204px; HEIGHT: 25px" align=left><asp:DropDownList id="DrpLocation" runat="server" Width="200px" CssClass="DropList" AutoPostBack="True"></asp:DropDownList></TD><TD style="WIDTH: 1px; HEIGHT: 25px" align=left></TD></TR><TR><TD align=left></TD><TD style="WIDTH: 90px" align=left>
    <strong> <asp:Label id="Label4" runat="server" Width="48px" Text="Principal" CssClass="lblbox"></asp:Label></strong> </TD><TD style="WIDTH: 1px" align=left></TD><TD style="WIDTH: 204px; HEIGHT: 25px" align=left><asp:DropDownList id="drpPrincipal" runat="server" Width="200px" CssClass="DropList" AutoPostBack="True"></asp:DropDownList></TD><TD style="WIDTH: 1px; HEIGHT: 25px" align=left></TD></TR><TR><TD style="HEIGHT: 2px" align=left></TD><TD style="WIDTH: 90px; HEIGHT: 2px" align=left>
    <strong> <asp:Label id="Label5" runat="server" Width="84px" Text="Account Head" CssClass="lblbox"></asp:Label></strong> </TD><TD style="WIDTH: 1px; HEIGHT: 2px" align=left></TD><TD style="WIDTH: 204px; HEIGHT: 2px" align=left><asp:CheckBox id="ChbAllAccountHead" runat="server" Text="All Account Head" AutoPostBack="True" OnCheckedChanged="ChbAllLocationType_CheckedChanged"></asp:CheckBox></TD><TD style="WIDTH: 1px; HEIGHT: 2px" align=left></TD></TR><TR><TD style="HEIGHT: 2px" align=left></TD><TD style="HEIGHT: 2px" align=left colSpan=3><asp:Panel id="Panel1" runat="server" Width="295px" Height="150px" ScrollBars="Vertical" BorderStyle="Groove" BorderWidth="1px"><asp:CheckBoxList id="LstAccountHead" runat="server" AutoPostBack="True" ></asp:CheckBoxList></asp:Panel></TD><TD style="WIDTH: 1px; HEIGHT: 2px" align=left></TD></TR><TR><TD align=left></TD><TD style="WIDTH: 90px" align=left>
    <strong> <asp:Label id="Label1" runat="server" Width="80px" Height="9px" 
        Text="From Date" CssClass="lblbox"></asp:Label></strong> </TD><TD style="WIDTH: 1px" align=left></TD><TD style="WIDTH: 204px; HEIGHT: 25px" align=left><asp:TextBox id="txtFromDate" runat="server" Width="150px" CssClass="txtBox" MaxLength="10"></asp:TextBox> <asp:ImageButton id="ImgBntFromDate" runat="server" ImageUrl="~/App_Themes/Granite/Images/date.gif"></asp:ImageButton></TD><TD style="WIDTH: 1px; HEIGHT: 25px" align=left></TD></TR><TR><TD align=left></TD><TD style="WIDTH: 90px" align=left>
    <strong> <asp:Label id="Label3" runat="server" Width="55px" Text="To Date" CssClass="lblbox"></asp:Label></strong> </TD><TD style="WIDTH: 1px" align=left></TD><TD style="WIDTH: 204px; HEIGHT: 25px" align=left><asp:TextBox id="txtToDate" runat="server" Width="150px" CssClass="txtBox" MaxLength="10"></asp:TextBox> <asp:ImageButton id="ImgBntToDate" runat="server" ImageUrl="~/App_Themes/Granite/Images/date.gif"></asp:ImageButton></TD><TD style="WIDTH: 1px; HEIGHT: 25px" align=left></TD></TR></TBODY></TABLE><cc1:CalendarExtender id="CalendarExtender1" runat="server" Format="dd-MMM-yyyy" EnableViewState="False" PopupButtonID="ImgBntFromDate" TargetControlID="txtFromDate"></cc1:CalendarExtender><cc1:CalendarExtender id="CalendarExtender2" runat="server" Format="dd-MMM-yyyy" EnableViewState="False" PopupButtonID="ImgBntToDate" TargetControlID="txtToDate"></cc1:CalendarExtender> &nbsp; 
</contenttemplate>
                    </asp:UpdatePanel>
                    <asp:Button ID="Button2" runat="server" Font-Size="8pt"
                Text="View PDF" Width="141px" OnClick="Button2_Click" CssClass="button" />
                    <asp:Button ID="Button1" runat="server" Font-Size="8pt" Text="View Excel"
                        Width="141px" OnClick="Button1_Click" CssClass="button" /></td>                
            </tr>
        </table>
           </div>
</asp:Content>