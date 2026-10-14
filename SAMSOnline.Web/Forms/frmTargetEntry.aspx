<%@ Page Language="C#" MasterPageFile="~/Forms/PageMaster.master" AutoEventWireup="true" CodeFile="frmTargetEntry.aspx.cs" Inherits="Forms_frmTargetEntry" Title="SAMS >> Target Entry" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cphPage">    
      <script language="JavaScript" type="text/javascript">
 function ConfirmDelete()
 {
	    if( confirm("Do you want to Cancel this record?")==true)
		return true;
		
	    else
	    {
	    return false;
	    }
 }
    
 function ValidateForm()
 {
		var str;
    
		str  = document.getElementById('<%=txtskuName.ClientID%>').value; 
		if(str == null || str.length == 0)
		{
			alert('Must Select SKU Name');
			return false;
		}
		str  = document.getElementById('<%=txtQuantity.ClientID%>').value; 
		if(str == null || str.length == 0)
		{
			alert('Must Enter Quantity');
			return false;
		}
		str  = document.getElementById('<%=txtFromdate.ClientID%>').value; 
		if(str == null || str.length <= 1)
		{
			alert('Must Select Target Month');
			return false;
		}
		str  = document.getElementById('<%=drpPrincipal.ClientID%>').value; 
		if(str == null || str.length == 0)
		{
			alert('Must Select Principal');
			return false;
		}
		str  = document.getElementById('<%=drpDistributor.ClientID%>').value; 
		if(str == null || str.length == 0)
		{
			alert('Must Select Distributor');
			return false;
		}
		str  = document.getElementById('<%=DrpTargetFor.ClientID%>').value; 
		if(str == null || str.length == 0)
		{
			alert('Must Select Target For');
			return false;
		}
        return true;
 }
 function SearchList()
 {
     var l =  document.getElementById('<%= lstCode.ClientID %>');
     var tb = document.getElementById('<%= txtskuCode.ClientID %>');

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
 function SearchedCode()
 {
    var l =  document.getElementById('<%= lstCode.ClientID %>');
    var str;
    for (var i=0; i < l.options.length; i++)
    {
        if(l.options[i].selected)
        {
           str = l.options[i].value;
           ClearSelection(l);
           break;
        }
        else
        {
            str = "";
        }
    }
    var stroption  = document.getElementById("<%= txtskuName.ClientID %>").value;
    if(str.length > 0)
    {
        document.getElementById("<%= txtskuCode.ClientID %>").value =  str.substring(0,str.indexOf('-'));
        document.getElementById("<%= txtskuName.ClientID %>").value =  str.substring(str.indexOf('-') + 1,str.indexOf(':'));
        document.getElementById("<%= txtUnitRate.ClientID %>").value =  str.substring(str.indexOf(':') + 1);
         document.getElementById("<%= Panel1.ClientID %>").className = "hiddencol";    
    }
    else if(stroption.length == 0)
    {
       document.getElementById("<%= Panel1.ClientID %>").className = "Displaycol";
       document.getElementById("<%= lstCode.ClientID %>").focus();
    }
    
 }
 function SelectCode(e)
 {
      if(e.keyCode == 13)
      {
        var str  = document.getElementById("<%= lstCode.ClientID %>").value;
        document.getElementById("<%= txtskuCode.ClientID %>").value =  str.substring(0,str.indexOf('-'));
        document.getElementById("<%= txtskuName.ClientID %>").value =  str.substring(str.indexOf('-') + 1,str.indexOf(':'));
        document.getElementById("<%= txtUnitRate.ClientID %>").value =  str.substring(str.indexOf(':') + 1);
         document.getElementById("<%= Panel1.ClientID %>").className = "hiddencol";
        document.getElementById("<%= txtQuantity.ClientID %>").focus();
      }
 }
 function ClearSelection(lb)
 {
    lb.selectedIndex = -1;
 }
 
  </script>
    <div id="right_data">
        <table width="100%">
            <tr>
                <td align="left">
                    <asp:UpdatePanel id="UpdatePanel2" runat="server">
                        <contenttemplate>
<TABLE><TBODY>
    <tr>
        <td align="left" style="height: 25px">
            <strong> <asp:Label ID="Label6" runat="server" Height="14px" Text="Distributor"
                Width="98px"></asp:Label></strong> </td>
        <td style="height: 25px">
            <asp:DropDownList ID="drpDistributor" runat="server" CssClass="DropList" Width="170px" OnSelectedIndexChanged="drpDistributor_SelectedIndexChanged" AutoPostBack="True">
            </asp:DropDownList></td>
        <td style="height: 25px">
        </td>
        <td align="center" colspan="1" rowspan="6" style="width: 316px" valign="top">
            <strong> <asp:Label ID="Label4" runat="server" CssClass="lblbox" Width="250px" Height="3px"></asp:Label></strong> <asp:Panel ID="Panel1" runat="server" BackColor="Silver" BorderColor="Silver" BorderStyle="Groove"
            BorderWidth="1px" Height="130px" Width="250px" CssClass="hiddencol">
                SKU List<br />
        <asp:ListBox ID="lstCode" runat="server" Height="116px" onkeyup="SelectCode(event)"
                SelectionMode="Multiple" Width="245px"></asp:ListBox></asp:Panel>
        </td>
    </tr>
    <TR>
    <TD align=left style="height: 25px">
    <strong> <asp:Label id="Label2" runat="server" Width="150px" Text="Target For Type" CssClass="lblbox" Height="14px"></asp:Label></strong> </TD><TD style="height: 25px"><asp:DropDownList id="DrpTargetType" runat="server" Width="170px">                    
                    <asp:ListItem Value="97">Delivery Man</asp:ListItem>                    
</asp:DropDownList></TD>
    <td style="height: 25px">
        <strong> <asp:Label ID="Label5" runat="server" CssClass="lblbox" Width="50px"></asp:Label></strong> </td>
</TR>
<TR><TD align=left style="height: 25px">
<strong> <asp:Label id="lblDocumentNo" runat="server" Width="76px" Text="Target For" CssClass="lblbox"></asp:Label></strong> </TD><TD style="height: 25px"><asp:DropDownList id="DrpTargetFor" runat="server" Width="170px" CssClass="DropList"></asp:DropDownList></TD>
                    <td style="height: 25px">
                    </td>
                </TR>
    <tr>        
        <td align="left" style="height: 25px">
            <strong> <asp:Label id="lbltoLocation" runat="server" Width="71px" Text="Principal" CssClass="lblbox"></asp:Label></strong> </td>
        <td style="height: 25px">
            <asp:DropDownList id="drpPrincipal" runat="server" Width="170px" CssClass="DropList" AutoPostBack="True" OnSelectedIndexChanged="drpPrincipal_SelectedIndexChanged"></asp:DropDownList></td>
        <td style="height: 25px">
            </td>
    </tr>
    <tr>
       
        <td align="left" style="height: 25px">
            <strong> <asp:Label id="Label1" runat="server" Width="72px" Text="For Month" CssClass="lblbox"></asp:Label></strong> </td>
        <td style="height: 25px">
            <asp:TextBox id="txtFromdate" runat="server" Width="161px" CssClass="txtBox" MaxLength="1"></asp:TextBox></td>
        <td style="height: 25px">
            <asp:ImageButton ID="ibtnStartDate" runat="server" ImageUrl="~/App_Themes/Granite/Images/date.gif"
                Width="16px" /></td>
    </tr>
    <tr>
        
        <td align="left" style="height: 25px" valign="top">
            </td>
        <td style="width: 1px; height: 25px;" valign="top">
            <%@ register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit"
                    tagprefix="cc1" %>
            <cc1:CalendarExtender ID="CEStartDate" runat="server" Format="MMM-yyyy" PopupButtonID="ibtnStartDate"
                TargetControlID="txtFromdate">
            </cc1:CalendarExtender><asp:Button ID="btnTarget" runat="server" Font-Size="8pt"
                                        Text="View Target" ValidationGroup="vg" Width="95px" OnClick="btnTarget_Click" CssClass="btn" /></td>
        <td style="width: 1px; height: 25px;" valign="top">
        </td>
    </tr>
</TBODY></TABLE>
</contenttemplate>
                    </asp:UpdatePanel>
                </td>               
            </tr>
        </table>        
    <table width="100%">
        <tr>
            <td>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <table width="100%">
                            <tr>
                                <td style="width:82px;">
                                    <strong> <asp:Label ID="lblskuCode" runat="server" CssClass="tblhead" Font-Bold="True"
                                        ForeColor="White" Width="75px" Text="  SKU Code"></asp:Label></strong> </td>
                                <td style="width:200px;">
                                    <strong> <asp:Label ID="lblskuname" runat="server" CssClass="tblhead" Font-Bold="True"
                                        ForeColor="White" Text="   SKU Name" Width="195px"></asp:Label></strong> </td>
                                <td style="width:62px;">
                                    <strong> <asp:Label ID="lblquantity" runat="server" CssClass="tblhead"
                                        Font-Bold="True" ForeColor="White" Height="16px" Text="Quantity" Width="62px"></asp:Label></strong> </td>
                                <td style="width:70px;">
                                    <strong> <asp:Label ID="lblFreeSKU" runat="server" CssClass="tblhead" Font-Bold="True"
                                        ForeColor="White" Height="16px" Text="SKU Rate" Width="70px"></asp:Label></strong> </td>
                                <td style="width:70px;">
                                    <strong> <asp:Label ID="lblBatchNo" runat="server"  CssClass="tblhead" Font-Bold="True"
                                        ForeColor="White" Height="16px" Text="Amount" Width="70px"></asp:Label></strong> </td>
                                <td>
                                    <strong> <asp:Label ID="Label41" runat="server" CssClass="tblhead" Font-Bold="True"
                                        ForeColor="White" Height="16px" Text="Add SKU" Width="85px"></asp:Label></strong> </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:TextBox ID="txtskuCode" runat="server" CssClass="txtBox" onkeyup="SearchList()"
                                        Width="82px"></asp:TextBox></td>
                                <td style="width:200px;">
                                    <asp:TextBox ID="txtskuName" runat="server" CssClass="txtBox" Enabled="False" Font-Bold="True"
                                        Width="200px"></asp:TextBox></td>
                                <td>
                                    <asp:TextBox ID="txtQuantity" runat="server" CssClass="txtBox " onfocus="SearchedCode()"
                                        Width="70px"></asp:TextBox></td>
                                <td>
                                    <asp:TextBox ID="txtUnitRate" runat="server" CssClass="txtBox" Enabled="False" Width="73px">0</asp:TextBox></td>
                                <td>
                                    <asp:TextBox ID="txtBatchNo" runat="server"  Enabled="False" Width="76px">N/A</asp:TextBox></td>
                                <td>
                                    <asp:Button ID="btnSave" runat="server" AccessKey="A" Font-Size="8pt" OnClick="btnSave_Click" CssClass="btn"
                                        Text="Save" ValidationGroup="vg" Width="95px" /></td>
                            </tr>
                            <tr>
                                <td colspan="6">
                                    <asp:Panel ID="Panel2" runat="server" BorderColor="Silver" BorderStyle="Groove" BorderWidth="1px"
                                        Height="180px" ScrollBars="Vertical" Width="640px" DefaultButton="btnSave">
                                        <asp:GridView ID="GrdPurchase" runat="server" AutoGenerateColumns="False" BackColor="White"
                                            BorderColor="White" CssClass="gridRow2" ForeColor="SteelBlue" HorizontalAlign="Center"
                                            OnRowDeleting="GrdPurchase_RowDeleting" OnRowEditing="GrdPurchase_RowEditing"
                                            ShowHeader="False" Width="620px">
                                            <PagerSettings FirstPageText="" LastPageText="" Mode="NextPrevious" NextPageText="Next"
                                                PreviousPageText="Previous" />
                                            <RowStyle ForeColor="Black" />
                                            <Columns>
                                                <asp:BoundField DataField="TARGET_ID" HeaderText="TARGET_ID">
                                                    <HeaderStyle CssClass="hiddencol" />
                                                    <ItemStyle CssClass="hiddencol" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="SKU_ID" HeaderText="SKU_ID">
                                                    <HeaderStyle CssClass="hiddencol" />
                                                    <ItemStyle CssClass="hiddencol" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="SKU_CODE" HeaderText="SKU Code">
                                                    <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="2px" HorizontalAlign="Left"
                                                        Width="85px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="SKU_NAME" HeaderText="SKU Name">
                                                    <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="2px" HorizontalAlign="Left"
                                                        Width="205px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="QUANTITY" HeaderText="Quantity">
                                                    <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="2px" HorizontalAlign="Right"
                                                        Width="75px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="UNIT_PRICE" HeaderText="Rate" DataFormatString="{0:F2}">
                                                    <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="2px" HorizontalAlign="Right"
                                                        Width="75px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="AMOUNT" HeaderText="Amount" DataFormatString="{0:F2}">
                                                    <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Right" />
                                                </asp:BoundField>
                                                <asp:CommandField HeaderText="Edit" ShowEditButton="True">
                                                    <ItemStyle BorderColor="Silver" BorderWidth="1px" Width="40px" />
                                                </asp:CommandField>
                                                <asp:TemplateField HeaderText="Delete">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="btnDelete" runat="server" CommandName="Delete" OnClientClick="javascript:return confirm('Are you sure you want to Delete?');return false;"
                                                            Text="Delete"></asp:LinkButton>
                                                    </ItemTemplate>
                                                    <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="2px" Width="45px" />
                                                </asp:TemplateField>
                                            </Columns>
                                            <FooterStyle BackColor="White" />
                                            <PagerStyle BackColor="Transparent" />
                                            <HeaderStyle CssClass="tblhead" />
                                            <AlternatingRowStyle BackColor="#F2F2F2" CssClass="GridAlternateRowStyle" ForeColor="#333333" />
                                        </asp:GridView>
                                    </asp:Panel>
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 12px">
                                </td>
                                <td style="height: 12px">
                                </td>
                                <td align="right">
                                    </td>
                                <td style="height: 12px">
                                    </td>
                                <td style="height: 12px">
                                    <strong> <asp:Label ID="Label3" runat="server" CssClass="tblhead" Font-Bold="True"
                                        ForeColor="White" Height="16px" Text="Total Value" Width="70px"></asp:Label></strong> </td>
                                <td colspan="2" align="left">
                                    <asp:TextBox ID="txtTotalAmt" runat="server" CssClass="txtBox" Width="95px" ReadOnly="True"></asp:TextBox></td>
                            </tr>
                        </table>
                        &nbsp;
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
    </div>
    
   
</asp:Content>

