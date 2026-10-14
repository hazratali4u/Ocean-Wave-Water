<%@ Page Language="C#" MasterPageFile="~/Forms/PageMaster.master" AutoEventWireup="true" CodeFile="frmOpeningStock.aspx.cs" Inherits="Forms_frmOpeningStock" Title="SAMS >> Stock Adjustment" %>
<%@ Register Assembly="AjaxControlToolkit"   Namespace="AjaxControlToolkit"    TagPrefix="ajaxToolkit" %>
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
    var stroption  = document.getElementById("<%= txtskuCode.ClientID %>").value;
    if(str.length > 0)
    {
        document.getElementById("<%= txtskuCode.ClientID %>").value = str.substring(0,str.indexOf('-'));
        document.getElementById("<%= txtskuName.ClientID %>").value =  str.substring(str.indexOf('-') + 1);
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
        document.getElementById("<%= txtskuCode.ClientID %>").value = str.substring(0,str.indexOf('-'));
        document.getElementById("<%= txtskuName.ClientID %>").value =  str.substring(str.indexOf('-') + 1);
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
                <td>
                    <asp:UpdatePanel id="UpdatePanel2" runat="server">
                        <contenttemplate>
<TABLE><TBODY>
<TR><TD align=left colspan="2"><strong>
    <asp:Label ID="lblErrorMsg" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
    </strong></TD><TD align=left colSpan=1>
        &nbsp; &nbsp; &nbsp; &nbsp; </TD>
    <td colspan="1" rowspan="7" style="width: 316px" valign="middle">
        <strong>
        <asp:Label ID="Label4" runat="server" CssClass="lblbox" Height="8px" 
            Width="239px"></asp:Label>
        </strong>&nbsp; &nbsp;&nbsp;
        <asp:Panel ID="Panel1" runat="server" BackColor="Silver" BorderColor="Silver" 
            BorderStyle="Groove" BorderWidth="1px" CssClass="hiddencol" Height="170px" 
            Width="250px">
            <strong>
            <asp:Label ID="Label3" runat="server" CssClass="lblbox" Width="170px">Select 
            from SKU List</asp:Label>
            </strong>
            <br />
            <asp:ListBox ID="lstCode" runat="server" Height="154px" 
                onkeyup="SelectCode(event)" SelectionMode="Multiple" Width="245px">
            </asp:ListBox>
        </asp:Panel>
    </td>
</TR><TR><TD style="height: 25px;" align=left><strong>
        <asp:Label ID="Label2" runat="server" CssClass="lblbox" Height="14px" 
            Text="Transaction Type" Width="120px"></asp:Label>
        </strong></TD><TD style="height: 25px">
            <asp:DropDownList ID="DrpDocumentType" runat="server" AutoPostBack="True" 
                CssClass="DropList" 
                OnSelectedIndexChanged="DrpDocumentType_SelectedIndexChanged" Width="200px">
                <asp:ListItem Value="7">Opening Stock</asp:ListItem>
                <asp:ListItem Value="8">Short</asp:ListItem>
                <asp:ListItem Value="9">Execes</asp:ListItem>
            </asp:DropDownList>
        </TD><TD style="height: 25px"><strong>
            <asp:Label ID="Label5" runat="server" CssClass="lblbox" Width="50px"></asp:Label>
            </strong></TD>
</TR><TR><TD align=left style="height: 25px"><strong>
        <asp:Label ID="lblDocumentNo" runat="server" CssClass="lblbox" 
            Text="Document No" Width="94px"></asp:Label>
        </strong></TD><TD style="height: 25px">
            <asp:DropDownList ID="drpDocumentNo" runat="server" AutoPostBack="True" 
                CssClass="DropList" OnSelectedIndexChanged="drpDocumentNo_SelectedIndexChanged" 
                Width="200px">
            </asp:DropDownList>
        </TD><TD style="height: 25px"></TD>
                </TR>
    <tr>
        <td align="left" style="height: 25px">
            <strong>
            <asp:Label ID="lbltoLocation" runat="server" CssClass="lblbox" Text="Principal" 
                Width="94px"></asp:Label>
            </strong>
        </td>
        <td style="height: 25px">
            <asp:DropDownList ID="drpPrincipal" runat="server" AutoPostBack="True" 
                CssClass="DropList" OnSelectedIndexChanged="drpPrincipal_SelectedIndexChanged" 
                Width="200px">
            </asp:DropDownList>
        </td>
        <td style="height: 25px">
            </td>
    </tr>
    <tr>
        <td align="left" style="height: 25px">
            <strong>
            <asp:Label ID="lblfromLocation" runat="server" CssClass="lblbox" 
                Text="Location" Width="94px"></asp:Label>
            </strong>
        </td>
        <td style="height: 25px">
            <asp:DropDownList ID="drpDistributor" runat="server" AutoPostBack="True" 
                CssClass="DropList" 
                OnSelectedIndexChanged="drpDistributor_SelectedIndexChanged" Width="200px">
            </asp:DropDownList>
        </td>
        <td style="height: 25px">
            </td>
    </tr>
    <TR><TD style="HEIGHT: 25px" align=left><strong>
        <asp:Label ID="Label1" runat="server" CssClass="lblbox" Text="Remarks" 
            Width="94px"></asp:Label>
        </strong></TD><TD style="HEIGHT: 25px">
            <asp:TextBox ID="txtDocumentNo" runat="server" CssClass="txtBox" Width="195px"></asp:TextBox>
        </TD><TD style="HEIGHT: 25px">
            </TD>
                </TR>
    <tr>
        <td align="left" style="height: 25px;" valign="top">
            <asp:CheckBox ID="ChbBatchNo" runat="server" AutoPostBack="True" 
                OnCheckedChanged="ChbBatchNo_CheckedChanged" Text="Batch No" Width="77px" />
        </td>
        <td style="height: 25px; width: 1px;" valign="top">
            <asp:CheckBox ID="ChbFreeSKU" runat="server" AutoPostBack="True" OnCheckedChanged="ChbFreeSKU_CheckedChanged"
                Text="Apply Free SKU" Width="146px" /></td>
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
                                <td style="width:72px">
                                    <strong><asp:Label ID="lblskuCode" runat="server" CssClass="tblhead" Font-Bold="True"
                                        ForeColor="White" Height="16px" Text="SKU Code" Width="78px"></asp:Label></strong></td>
                                <td style="width:200px">
                                    <strong><asp:Label ID="lblskuname" runat="server" CssClass="tblhead" Font-Bold="True"
                                        ForeColor="White" Height="16px" Text="SKU Name" Width="195px"></asp:Label></strong></td>
                                <td style="width:70px">
                                    <strong><asp:Label ID="lblquantity" runat="server" CssClass="tblhead"
                                        Font-Bold="True" ForeColor="White" Height="16px" Text="Quantity" Width="65px"></asp:Label></strong></td>
                                <td style="width:70px">
                                    <strong><asp:Label ID="lblFreeSKU" runat="server" CssClass="tblhead" Font-Bold="True"
                                        ForeColor="White" Height="16px" Text="Free SKU" Width="65px" Enabled="False"></asp:Label></strong></td>
                                <td style="width:80px">
                                    <strong><asp:Label ID="lblBatchNo" runat="server" CssClass="tblhead" Font-Bold="True"
                                        ForeColor="White" Height="16px" Text="Batch No" Width="75px" Enabled="False"></asp:Label></strong></td>
                                <td>
                                    <strong><asp:Label ID="Label41" runat="server" CssClass="tblhead" Font-Bold="True"
                                        ForeColor="White" Height="16px" Text="Add SKU" Width="85px"></asp:Label></strong></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:TextBox ID="txtskuCode" runat="server" onkeyup="SearchList()"
                                        Width="82px"></asp:TextBox></td>
                                <td>
                                    <asp:TextBox ID="txtskuName" runat="server" Enabled="False" Font-Bold="True"
                                        Width="200px"></asp:TextBox></td>
                                <td>
                                    <asp:TextBox ID="txtQuantity" runat="server" onfocus="SearchedCode()"
                                        Width="70px"></asp:TextBox></td>
                                <td>
                                    <asp:TextBox ID="txtFreeSKU" runat="server" Enabled="False" Width="70px">0</asp:TextBox></td>
                                <td>
                                    <asp:TextBox ID="txtBatchNo" runat="server" Enabled="False" Width="80px">N/A</asp:TextBox></td>
                                <td>
                                    <asp:Button CssClass="btn" ID="btnSave" runat="server" AccessKey="A" Font-Size="8pt" OnClick="btnSave_Click"
                                        Text="Add Sku" ValidationGroup="vg" Width="95px" /></td>
                            </tr>
                            <tr>
                                <td align="left" colspan="6">
                                    <asp:Panel ID="Panel2" runat="server" BorderColor="Silver" BorderStyle="Groove" BorderWidth="1px"
                                        Height="140px" ScrollBars="Vertical" Width="640px">
                                        <asp:GridView ID="GrdPurchase" runat="server" AutoGenerateColumns="False" BackColor="White"
                                            BorderColor="White" CssClass="gridRow2" ForeColor="SteelBlue" HorizontalAlign="Center"
                                            OnRowDeleting="GrdPurchase_RowDeleting" OnRowEditing="GrdPurchase_RowEditing"
                                            ShowHeader="False" Width="620px">
                                            <PagerSettings FirstPageText="" LastPageText="" Mode="NextPrevious" NextPageText="Next"
                                                PreviousPageText="Previous" />
                                            <RowStyle ForeColor="Black" />
                                            <Columns>
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
                                                <asp:BoundField DataField="Quantity" HeaderText="Quantity">
                                                    <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="2px" HorizontalAlign="Right"
                                                        Width="75px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="FREE_SKU" HeaderText="Free SKU">
                                                    <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="2px" HorizontalAlign="Right"
                                                        Width="75px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="BATCH_NO" HeaderText="BatchNo">
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
                                            <HeaderStyle BackColor="#007395" Font-Bold="True" ForeColor="White" HorizontalAlign="Center"
                                                VerticalAlign="Middle" />
                                            <AlternatingRowStyle BackColor="#F2F2F2" CssClass="GridAlternateRowStyle" ForeColor="#333333" />
                                        </asp:GridView>
                                    </asp:Panel>
                                </td>
                            </tr>
                        </table>
<asp:Button CssClass="btn" accessKey="S" id="Button1" onclick="Button1_Click" runat="server" Width="119px" Font-Size="8pt" Text="Save Document" UseSubmitBehavior="False"></asp:Button>
                <asp:Button CssClass="btn" accessKey="C" id="Button2" onclick="Button2_Click" runat="server" Width="120px" Font-Size="8pt" Text="Cancel" UseSubmitBehavior="False"></asp:Button>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>            
        </tr>
    </table>
    </div>   
</asp:Content>

