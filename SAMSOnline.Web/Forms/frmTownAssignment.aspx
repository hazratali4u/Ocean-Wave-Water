<%@ page language="C#" masterpagefile="~/Forms/PageMaster.master" autoeventwireup="true" CodeFile = "frmTownAssignment.aspx.cs" inherits="Forms_frmTownAssignment" title="SAMS >> Town Assignment" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphPage" Runat="Server">
    
    <div id="right_data">
        <table width="100%">
            <tr>
                <td>
                
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
<TABLE><TBODY><TR>
    <td colspan="2" align="left">
        <strong><asp:Label id="lblmsg" runat="server" Visible="False" Width="175px" ForeColor="Red"></asp:Label></strong>&nbsp;
    </td>
    <TD style="HEIGHT: 17px"></TD></TR><TR><TD style="HEIGHT: 25px;" align="left">
    <strong><asp:Label id="Label1" runat="server" Width="58px" Text="Locaton" CssClass="lblbox"></asp:Label></strong></TD><TD align="left"><asp:DropDownList id="drpDistributor" runat="server" Width="200px" CssClass="DropList" AutoPostBack="True" OnSelectedIndexChanged="drpDistributor_SelectedIndexChanged"></asp:DropDownList></TD><TD style="HEIGHT: 10px"></TD></TR><TR><TD style="HEIGHT: 25px;" align="left">
    <strong><asp:Label id="Label11" runat="server" Width="56px" Text="Region" CssClass="lblbox"></asp:Label></strong></TD><TD align="left"><asp:DropDownList id="ddRegion" runat="server" Width="200px" CssClass="DropList" AutoPostBack="True" OnSelectedIndexChanged="ddRegion_SelectedIndexChanged"></asp:DropDownList></TD></TR><TR><TD style="HEIGHT: 25px" align="left">
    <strong><asp:Label id="Label2" runat="server" Width="43px" Text="Zone" CssClass="lblbox"></asp:Label></strong></TD><TD align="left"><asp:DropDownList id="ddZone" runat="server" Width="200px" CssClass="DropList" AutoPostBack="True" OnSelectedIndexChanged="ddZone_SelectedIndexChanged"></asp:DropDownList></TD></TR><TR><TD style="HEIGHT: 25px" align="left">
    <strong><asp:Label id="Label3" runat="server" Width="51px" Text="Territory" CssClass="lblbox"></asp:Label></strong></TD><TD align="left"><asp:DropDownList id="ddTerritory" runat="server" Width="200px" CssClass="DropList" AutoPostBack="True" OnSelectedIndexChanged="ddTerritory_SelectedIndexChanged"></asp:DropDownList></TD></TR></TBODY></TABLE>
</ContentTemplate>
                    </asp:UpdatePanel>
                </td>
                
            </tr>
        </table>
      
        <table width="100%">
            <tr>
                <td>
                    <asp:UpdatePanel id="UpdatePanel2" runat="server"><contenttemplate>
<TABLE><TR><TD style="WIDTH: 100px" rowSpan=1>
<strong><asp:Label id="Label4" runat="server" Width="142px" Text="Unassigned Town" CssClass="lblbox"></asp:Label></strong></TD><TD style="WIDTH: 102px" vAlign=bottom align=center></TD><TD style="WIDTH: 102px" rowSpan=1>
<strong><asp:Label id="Label6" runat="server" Text="Assigned Town"></asp:Label></strong></TD>
</TR>

<tr>
    <td style="width: 100px">
        <asp:ListBox id="lstUnAssignTown" runat="server" Width="150px" Height="200px"></asp:ListBox>
    </td>
<td valign="middle" align="center">

    <asp:Button id="Button1" onclick="Button1_Click" runat="server" Width="30px" Font-Size="8pt" Text=">" CssClass="btn" /> 
    <br />
    <br />
    <asp:Button id="Button3" onclick="Button3_Click" runat="server" Width="30px" Font-Size="8pt" Text=">>" CssClass="btn" /> 
    <br />
    <br />
    <asp:Button id="Button4" onclick="Button4_Click" runat="server" Width="30px" Font-Size="8pt" Text="<<" CssClass="btn" />
    <br />
    <br />
    <asp:Button id="Button2" onclick="Button2_Click" runat="server" Width="30px" Font-Size="8pt" Text="<" CssClass="btn"/>
</td>
<td style="width: 102px">
    <asp:ListBox id="lstAssignTown" runat="server" Width="150px" Height="200px"></asp:ListBox>
</td>
</tr>

</TABLE>
</contenttemplate>
                    </asp:UpdatePanel>
                </td>                
            </tr>
            
        </table>
    </div>

</asp:Content>
