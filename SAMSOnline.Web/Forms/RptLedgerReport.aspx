<%@ Page Language="C#" MasterPageFile="~/Forms/AppMaster.master" AutoEventWireup="true" CodeFile="RptLedgerReport.aspx.cs" Inherits="Forms_RptLedgerReport" Title="SAMS >> General Ledger" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="mainCopy">
    <div class="container" style="background-color: white">
    
        <h2>
            &nbsp; General Ledger</h2>
    </div>
     <script language="JavaScript" type="text/javascript">
    
    function SearchedCode()
    {
        var str  
        var stroption
        str  = document.getElementById("<%= LstAccountHead.ClientID %>").value;
        stroption = document.getElementById("<%= txtAccountCode.ClientID %>").value;
        
         if(str.length > 0)
         {      
                document.getElementById("<%= txtAccountCode.ClientID %>").value =  str.substring(str.indexOf('~') + 1);
                document.getElementById("<%= txtAccountName.ClientID %>").value =  str.substring(0,str.indexOf('~'));
                document.getElementById("<%= Panel3.ClientID %>").className = "hiddencol";
        
         }
         else if(stroption.length == 0)
         {
                document.getElementById("<%= Panel3.ClientID %>").className = "Displaycol";
                document.getElementById("<%= LstAccountHead.ClientID %>").focus();
         }
         ClearSelection(document.getElementById('<%= LstAccountHead.ClientID %>'));
    
     }
	function SearchList()
    {
         var l =  document.getElementById('<%= LstAccountHead.ClientID %>');
         var tb = document.getElementById('<%= txtAccountCode.ClientID %>');
        
            if(tb.value == "")
            {
                ClearSelection(l);
            }
            else
            {
                for (var i=0; i < l.options.length; i++)
                {
                    if (l.options[i].value.toLowerCase().match(tb.value.toLowerCase()))
                    {
                        l.options[i].selected = true;
                        return false;
                    }
                    else
                    {
                        ClearSelection(l);
                    }
                }
           }
    }
    function ClearSelection(lb)
    {
        lb.selectedIndex = -1;
    }
    function SelectCode(e)
    {
      if(e.keyCode == 13)
      {
        var str  = document.getElementById("<%= LstAccountHead.ClientID %>").value;
        document.getElementById("<%= txtAccountName.ClientID %>").value =  str.substring(0,str.indexOf('~')); 
        document.getElementById("<%= txtAccountCode.ClientID %>").value =  str.substring(str.indexOf('~') + 1);
        document.getElementById("<%= Panel3.ClientID %>").className = "hiddencol";
        document.getElementById("<%= Button2.ClientID %>").focus();
      }
    }
    </script>
     <div class="container">
        <table width="100%">
            <tr>
                <td>
                </td>
                <td align="center">
                    <div style="left: 400px; position: absolute; top: 195px; height: 248px">
                        <asp:Panel ID="Panel3" runat="server" BackColor="Silver" BorderColor="White" BorderStyle="Inset"
                            BorderWidth="1px" CssClass="hiddencol" Height="237px" Width="327px">
                            <table style="border-right: #ffffff thin groove; border-top: #ffffff thin groove;
                                border-left: #ffffff thin groove; width: 99%; border-bottom: #ffffff thin groove">
                                <tbody>
                                    <tr>
                                        <td align="left" colspan="2" style="border-bottom: black thin solid">
                                            &nbsp;Select A<strong>ccount Head from List</strong></td>
                                        <td align="right" style="border-bottom: black thin solid" valign="top">
                                            <asp:Button ID="Button5" runat="server" AccessKey="S" BorderStyle="Groove" BorderWidth="1px"
                                                Font-Size="8pt" Height="16px" Text="X" Width="21px" /></td>
                                    </tr>
                                </tbody>
                            </table>
                            <asp:ListBox ID="LstAccountHead" runat="server" CssClass="DropList" Height="206px"
                                onkeyup="SelectCode(event)" Width="314px"></asp:ListBox></asp:Panel>
                        &nbsp; &nbsp;&nbsp;
                    </div>
                    <asp:UpdatePanel id="UpdatePanel1" runat="server">
                        <contenttemplate>
<TABLE><TR><TD align=left colSpan=4><asp:Label id="lblErrorMsg" runat="server" ForeColor="Red" Font-Bold="True"></asp:Label> </TD>
</TR>
    <tr>
        <td align="left">
        </td>
        <td align="left">
        </td>
        <td align="left">
        </td>
        <td align="left" style="height: 25px">
            <asp:RadioButtonList ID="rbPosted" runat="server" RepeatDirection="Horizontal">
                <asp:ListItem Selected="True">Posted Ledger</asp:ListItem>
                <asp:ListItem>Un Posted Ledger</asp:ListItem>
            </asp:RadioButtonList></td>
    </tr>
    <TR><TD align=left></TD>
    <td align="left">
        <asp:Label ID="lbltoLocation" runat="server" CssClass="lblbox" Text="Location" Width="73px"></asp:Label></td>
    <td align="left">
    </td>
    <TD style="HEIGHT: 25px" align=left><asp:DropDownList id="drpDistributor" runat="server" Width="200px" CssClass="DropList">
    </asp:DropDownList></TD>
</TR>
    <tr>
        <td align="left">
        </td>
        <td align="left">
            <asp:Label ID="Label6" runat="server" CssClass="lblbox" Text="Principal" Width="78px"></asp:Label></td>
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
            <asp:Label ID="Label3" runat="server" Height="13px" Text="From Date" Width="70px"></asp:Label></td>
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
            <asp:Label ID="Label4" runat="server" Height="13px" Text="To Date" Width="80px"></asp:Label></td>
        <td align="left">
        </td>
        <td align="left" style="height: 25px">
            <asp:TextBox ID="txtEndDate" runat="server" CssClass="txtBox " MaxLength="10"
                onkeyup="BlockEndDateKeyPress()" Width="150px"></asp:TextBox>
            <asp:ImageButton ID="ibnEndDate" runat="server" ImageUrl="~/App_Themes/Granite/Images/date.gif"
                Width="16px" /></td>
    </tr>
    <tr>
        <td align="left">
        </td>
        <td align="left">
            <asp:Label ID="Label1" runat="server" CssClass="lblbox" Text="Account Head" Width="78px"></asp:Label></td>
        <td align="left">
        </td>
        <td align="left" style="height: 25px">
            <asp:TextBox ID="txtAccountCode"  runat="server" CssClass="txtBox" Width="191px" onkeyup  = "SearchList()"></asp:TextBox></td>
    </tr>
    <tr>
        <td align="left">
        </td>
        <td align="left" colspan="3">
            <asp:TextBox ID="txtAccountName" runat="server" CssClass="txtBox" Width="277px" onfocus="SearchedCode()"></asp:TextBox></td>
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
        <asp:Button ID="Button2" runat="server" Font-Size="8pt"
                Text="View PDF" Width="141px" OnClick="Button2_Click1" />
                    <asp:Button ID="Button1" runat="server" Font-Size="8pt"
                Text="View Excel" Width="141px" OnClick="Button1_Click" /></td>
                <td>
                </td>
            </tr>
        </table>
         &nbsp;
        
           </div>
    <div class="container">
        &nbsp;</div>
    
   
</asp:Content>
