<%@ Page Language="C#" MasterPageFile="~/Forms/PageMaster.master" AutoEventWireup="true" CodeFile="frmRawMaterial.aspx.cs" Inherits="Forms_frmRawMaterial" Title="SAMS >> Raw Material Issuance" %>
<%@ Register Assembly="AjaxControlToolkit"   Namespace="AjaxControlToolkit"    TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cphPage">
   
      <script language="JavaScript" type="text/javascript">
     
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
    var stroption  = document.getElementById("<%= txtskuName.ClientID %>").value;
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
                        <div style="z-index: 101; left: 10px; width: 100px; position: absolute; top: 250px;height: 100px">
<asp:Panel ID="Panel1" runat="server" BackColor="#92BB55" BorderColor="#92BB55" 
            BorderStyle="Groove" BorderWidth="1px" CssClass="hiddencol" Height="170px" 
            Width="250px">
            SKU List<br />
            <asp:ListBox ID="lstCode" runat="server" Height="151px" 
                onkeyup="SelectCode(event)" SelectionMode="Multiple" Width="239px">
            </asp:ListBox>
        </asp:Panel>
        </div>
                        <table width="100%">
                            <tr>
                                <td style="width:10%" align="right">
                                    <strong><asp:Label ID="Label2" runat="server" Text="Transaction No:"></asp:Label></strong>
                                </td>
                                <td style="width:1%"></td>
                                <td style="width:89%">
                                    <asp:DropDownList ID="ddlDocumentNo" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlDocumentNo_SelectedIndexChanged" Width="200px">            
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td style="width:10%" align="right">
                                    <strong><asp:Label ID="lblfromLocation" runat="server" Text="Location:" Width="94px"></asp:Label></strong>
                                </td>
                                <td style="width:1%"></td>
                                <td style="width:89%">
                                    <asp:DropDownList ID="drpDistributor" runat="server" AutoPostBack="True" Width="200px">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td style="width:10%" align="right">
                                    <strong><asp:Label ID="lbltoLocation" runat="server" CssClass="lblbox" Text="Principal:" Width="94px"></asp:Label></strong>
                                </td>
                                <td style="width:1%"></td>
                                <td style="width:89%">
                                    <asp:DropDownList ID="drpPrincipal" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drpPrincipal_SelectedIndexChanged" Width="200px">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            
                        </table>                        
</contenttemplate>
                    </asp:UpdatePanel>
                </td>
                
            </tr>
        </table>
        <table width="100%">
        <tr>
            <td>
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                        <table width="50%">
                        <tr>
                                <td align="left" colspan="4">&nbsp;</td>
                            </tr>
                            <tr>
                                <td >
                                    <strong><asp:Label ID="lblskuCode" runat="server" CssClass="tblhead" Font-Bold="True"
                                        ForeColor="White" Height="16px" Text="SKU Code" Width="88px"></asp:Label></strong></td>
                                <td >
                                    <strong><asp:Label ID="lblskuname" runat="server" CssClass="tblhead" Font-Bold="True"
                                        ForeColor="White" Height="16px" Text="SKU Name" Width="206px"></asp:Label></strong></td>
                                <td >
                                    <strong><asp:Label ID="lblquantity" runat="server" CssClass="tblhead" Width="73px"
                                        Font-Bold="True" ForeColor="White" Height="16px" Text="Quantity" ></asp:Label></strong></td>
                                <td>
                                    <strong><asp:Label ID="Label41" runat="server" CssClass="tblhead" Font-Bold="True"
                                        ForeColor="White" Height="16px" Text="Add SKU" Width="90px" ></asp:Label></strong></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:TextBox ID="txtskuCode" runat="server" onkeyup="SearchList()" Width="83px"></asp:TextBox></td>
                                <td>
                                    <asp:TextBox ID="txtskuName" runat="server" Enabled="False" Font-Bold="True" Width="200px"></asp:TextBox></td>
                                <td>
                                    <asp:TextBox ID="txtQuantity" runat="server" CssClass="txtBox " onfocus="SearchedCode()" Width="70px"></asp:TextBox></td>
                                <td>
                                    <asp:Button CssClass="btn" ID="btnSave" runat="server" AccessKey="A" OnClick="btnSave_Click"
                                        Text="Add Sku" ValidationGroup="vg" Width="100px" /></td>
                            </tr>
                            <tr>
                                <td align="left" colspan="4">
                                    <asp:Panel ID="Panel2" runat="server" BorderColor="Silver" BorderStyle="Groove" BorderWidth="1px"
                                        Height="130px" ScrollBars="Vertical" Width="510px">
                                        <asp:GridView ID="GrdPurchase" runat="server" AutoGenerateColumns="False" BackColor="White"
                                            BorderColor="White" ForeColor="SteelBlue" HorizontalAlign="Center"
                                            OnRowDeleting="GrdPurchase_RowDeleting" OnRowEditing="GrdPurchase_RowEditing"
                                            ShowHeader="False" Width="490px">
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
                                                        Width="83px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="SKU_NAME" HeaderText="SKU Name">
                                                    <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="2px" HorizontalAlign="Left"
                                                        Width="200px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Quantity" HeaderText="Quantity">
                                                    <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="2px" HorizontalAlign="Right"
                                                        Width="70px" />
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
                            <tr>
                                <td align="left" colspan="4">&nbsp;</td>
                            </tr>
                        </table>
<asp:Button CssClass="btn" accessKey="S" id="Button1" onclick="Button1_Click" runat="server" Width="119px" Font-Size="8pt" Text="Save Document" UseSubmitBehavior="False"></asp:Button>
                <asp:Button CssClass="btn" accessKey="C" id="Button2" onclick="Button2_Click" runat="server" Width="120px" Font-Size="8pt" Text="Cancel" UseSubmitBehavior="False"></asp:Button>
                                    <strong><asp:Label ID="Label7" runat="server" CssClass="tblhead" Font-Bold="True"
                                        ForeColor="White" Height="16px" Text="Total Quantity" Width="103px"></asp:Label></strong>
                                    <asp:TextBox ID="txtTotalQuantity" runat="server" onkeyup="SearchList()"
                                        ReadOnly="True" Width="88px"></asp:TextBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            
        </tr>
    </table>
    </div>
    
   
</asp:Content>



