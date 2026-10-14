<%@ Page Language="C#" AutoEventWireup="true" CodeFile="rptBankDepositSlipDetail.aspx.cs" Inherits="Forms_rptBankDepositSlipDetail" MasterPageFile ="~/Forms/AppMaster.master" Title="SAMS >> Deposit Slip Detail" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID = "content1" runat = "server" ContentPlaceHolderID ="mainCopy">
<div class="container" style="background-color: white">
    
        <h2>
            &nbsp; Deposit Slip Detail</h2>
    </div>
    
     <div class="container">
        <table width="100%">
            <tr>
                <td style="height: 184px">
                </td>
                <td align="center" style="height: 184px">
                    <asp:UpdatePanel id="UpdatePanel1" runat="server">
                        <contenttemplate>
<TABLE><TBODY><TR><TD align=left colSpan=4><asp:Label id="lblErrorMsg" runat="server" ForeColor="Red" Font-Bold="True"></asp:Label> </TD><TD style="WIDTH: 1px" align=left colSpan=1></TD></TR><TR><TD style="WIDTH: 1px; HEIGHT: 1px" align=left></TD><TD style="WIDTH: 29px; HEIGHT: 1px" align=left><asp:Label id="Label2" runat="server" Width="48px" Text="Location" CssClass="lblbox"></asp:Label></TD><TD style="WIDTH: 1px; HEIGHT: 1px" align=left></TD><TD style="WIDTH: 203px; HEIGHT: 1px" align=left><asp:DropDownList id="DrpLocation" runat="server" Width="210px" CssClass="DropList" AutoPostBack="True"></asp:DropDownList></TD><TD style="WIDTH: 1px; HEIGHT: 1px" align=left></TD></TR><TR><TD style="WIDTH: 1px" align=left></TD><TD style="WIDTH: 29px" align=left>
    <asp:Label ID="lbltoLocation" runat="server" CssClass="lblbox" Text="Principal" Width="61px"></asp:Label></TD><TD style="WIDTH: 1px" align=left></TD><TD style="WIDTH: 203px; HEIGHT: 25px" align=left><asp:DropDownList id="drpPrincipal" runat="server" Width="210px" CssClass="DropList" AutoPostBack="True">
</asp:DropDownList></TD><TD style="WIDTH: 1px; HEIGHT: 25px" align=left></TD></TR><TR><TD style="WIDTH: 1px; HEIGHT: 25px" align=left></TD><TD style="WIDTH: 29px; HEIGHT: 25px" align=left><asp:Label id="Label4" runat="server" Width="61px" Text="Account" CssClass="lblbox"></asp:Label></TD><TD style="WIDTH: 1px; HEIGHT: 25px" align=left></TD><TD style="WIDTH: 203px; HEIGHT: 25px" align=left><asp:DropDownList id="drpAccount" runat="server" Width="210px" CssClass="DropList" AutoPostBack="True"></asp:DropDownList></TD><TD style="WIDTH: 1px; HEIGHT: 25px" align=left></TD></TR><TR><TD style="WIDTH: 1px; HEIGHT: 25px" align=left></TD><TD style="WIDTH: 29px; HEIGHT: 25px" align=left><asp:Label id="Label1" runat="server" Width="59px" Text="From Date" CssClass="lblbox"></asp:Label></TD><TD style="WIDTH: 1px; HEIGHT: 25px" align=left></TD><TD style="WIDTH: 203px; HEIGHT: 25px" align=left><asp:TextBox id="txtFromDate" runat="server" Width="153px" CssClass="txtBox" MaxLength="10"></asp:TextBox> <asp:ImageButton id="ImgBntFromCalc" runat="server" ImageUrl="~/App_Themes/Granite/Images/date.gif"></asp:ImageButton></TD><TD style="WIDTH: 1px; HEIGHT: 25px" align=left></TD></TR><TR><TD style="WIDTH: 1px; HEIGHT: 25px" align=left></TD><TD style="WIDTH: 29px; HEIGHT: 25px" align=left><asp:Label id="Label3" runat="server" Width="57px" Text="To  Date" CssClass="lblbox"></asp:Label></TD><TD style="WIDTH: 1px; HEIGHT: 25px" align=left></TD><TD style="WIDTH: 203px; HEIGHT: 25px" align=left><asp:TextBox id="txtToDate" runat="server" Width="153px" CssClass="txtBox" MaxLength="10"></asp:TextBox> <asp:ImageButton id="ImgToDate" runat="server" ImageUrl="~/App_Themes/Granite/Images/date.gif"></asp:ImageButton></TD><TD style="WIDTH: 1px; HEIGHT: 25px" align=left></TD></TR></TBODY></TABLE>  
                            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" EnableViewState="False"
                                Format="dd-MMM-yyyy" PopupButtonID="ImgBntFromCalc" TargetControlID="txtFromDate">
                            </cc1:CalendarExtender>
                            <cc1:CalendarExtender ID="CalendarExtender2" runat="server" EnableViewState="False"
                                Format="dd-MMM-yyyy" PopupButtonID="ImgToDate" TargetControlID="txtToDate">
                            </cc1:CalendarExtender>
</contenttemplate>
                    </asp:UpdatePanel>                 &nbsp; &nbsp;&nbsp;<br />
                    <asp:Button ID="Button2" runat="server" Font-Size="8pt"
                Text="View PDF" Width="141px" OnClick="Button2_Click" />
                    <asp:Button ID="Button1" runat="server" Font-Size="8pt" Text="View Excel"
                        Width="141px" OnClick="Button1_Click" /></td>
                <td style="height: 184px">
                </td>
            </tr>
        </table>
        
           </div>
     <div class="container">
        &nbsp;</div>

</asp:Content>
