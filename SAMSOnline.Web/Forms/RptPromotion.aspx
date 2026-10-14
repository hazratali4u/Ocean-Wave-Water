<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RptPromotion.aspx.cs" Inherits="Forms_RptPromotion" MasterPageFile ="~/Forms/PageMaster.master" Title="SAMS >> Promotion Report" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="ID" runat="server" ContentPlaceHolderID="cphPage">
<div id="right_data">
   <table width="100%">
            <tr>
                <td>
                    <asp:UpdatePanel id="UpdatePanel1" runat="server">
                        <contenttemplate>
<TABLE><TBODY><TR><TD align=left colSpan=4>
<strong><asp:Label id="lblErrorMsg" runat="server" ForeColor="Red" Font-Bold="True"></asp:Label></strong> </TD><TD style="WIDTH: 1px" align=left colSpan=1></TD></TR><TR><TD align=left></TD><TD style="WIDTH: 90px" align=left>
<strong><asp:Label id="Label5" runat="server" Width="120px" Height="18px" Text="Promotion Type" CssClass="lblbox"></asp:Label></strong></TD><TD style="WIDTH: 1px" align=left></TD><TD style="WIDTH: 204px; HEIGHT: 25px" align=left><asp:RadioButtonList id="rbPromotionType" runat="server" Width="199px" Height="15px" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged" RepeatDirection="Horizontal"><asp:ListItem Value="1">Active</asp:ListItem>
<asp:ListItem Value="0">InActive</asp:ListItem>
</asp:RadioButtonList></TD><TD style="WIDTH: 1px; HEIGHT: 25px" align=left></TD></TR><TR><TD align=left></TD><TD style="WIDTH: 90px" align=left>
<strong><asp:Label id="Label2" runat="server" Width="48px" Text="Location" CssClass="lblbox"></asp:Label></strong></TD><TD style="WIDTH: 1px" align=left></TD><TD style="WIDTH: 204px; HEIGHT: 25px" align=left><asp:DropDownList id="DrpLocation" runat="server" Width="200px" CssClass="DropList" AutoPostBack="True"></asp:DropDownList></TD><TD style="WIDTH: 1px; HEIGHT: 25px" align=left></TD></TR><TR><TD style="HEIGHT: 2px" align=left></TD><TD style="WIDTH: 90px; HEIGHT: 2px" align=left>
<strong><asp:Label id="Label4" runat="server" Width="48px" Text="Principal" CssClass="lblbox"></asp:Label></strong></TD><TD style="WIDTH: 1px; HEIGHT: 2px" align=left></TD><TD style="WIDTH: 204px; HEIGHT: 2px" align=left><asp:DropDownList id="drpPrincipal" runat="server" Width="200px" CssClass="DropList" AutoPostBack="True"></asp:DropDownList></TD><TD style="WIDTH: 1px; HEIGHT: 2px" align=left></TD></TR><TR><TD align=left></TD><TD style="WIDTH: 90px" align=left>
<strong><asp:Label id="Label1" runat="server" Width="120px" Height="9px" Text="From Date" CssClass="lblbox"></asp:Label></strong></TD><TD style="WIDTH: 1px" align=left></TD><TD style="WIDTH: 204px; HEIGHT: 25px" align=left><asp:TextBox id="txtFromDate" runat="server" Width="150px" CssClass="txtBox" MaxLength="10"></asp:TextBox> <asp:ImageButton id="ImgBntFromDate" runat="server" ImageUrl="~/App_Themes/Granite/Images/date.gif"></asp:ImageButton></TD><TD style="WIDTH: 1px; HEIGHT: 25px" align=left></TD></TR><TR><TD align=left></TD><TD style="WIDTH: 90px" align=left>
<strong><asp:Label id="Label3" runat="server" Width="120px" Text="To Date" CssClass="lblbox"></asp:Label></strong></TD><TD style="WIDTH: 1px" align=left></TD><TD style="WIDTH: 204px; HEIGHT: 25px" align=left><asp:TextBox id="txtToDate" runat="server" Width="150px" CssClass="txtBox" MaxLength="10"></asp:TextBox> <asp:ImageButton id="ImgBntToDate" runat="server" ImageUrl="~/App_Themes/Granite/Images/date.gif"></asp:ImageButton></TD><TD style="WIDTH: 1px; HEIGHT: 25px" align=left></TD></TR></TBODY></TABLE><cc1:CalendarExtender id="CalendarExtender1" runat="server" Format="dd-MMM-yyyy" EnableViewState="False" PopupButtonID="ImgBntFromDate" TargetControlID="txtFromDate"></cc1:CalendarExtender><cc1:CalendarExtender id="CalendarExtender2" runat="server" Format="dd-MMM-yyyy" EnableViewState="False" PopupButtonID="ImgBntToDate" TargetControlID="txtToDate"></cc1:CalendarExtender> &nbsp; 
</contenttemplate>
                    </asp:UpdatePanel>
                    <asp:Button ID="Button2" runat="server" 
                Text="View PDF" CssClass="btn" OnClick="Button2_Click" />
                    <asp:Button ID="Button1" runat="server"  Text="View Excel"
                        CssClass="btn" OnClick="Button1_Click" /></td>
            </tr>
        </table>
</div>
</asp:Content>
