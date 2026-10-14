<%@ page language="C#" masterpagefile="~/Forms/PageMaster.master" autoeventwireup="true" CodeFile = "frmPromotionWizardStep3Slab.aspx.cs" inherits="Forms_frmPromotionWizardStep3Slab" title="SAMS >> Promotion Wizard Step 3" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphPage" Runat="Server">
   
    <script language="JavaScript" type="text/javascript">
        function ValidateForm()
		{
			var str;
			if(document.getElementById('<%=rbSKUGroup.ClientID%>').checked == true)
			{
				str = document.getElementById('<%=ddSKUSelectedGroup.ClientID%>').value;
				if(str == null || str.length == 0)
				{
					alert('Must select SKU Group');
					return false;
				}
			}
						
			if(document.getElementById('<%=chIsMultiple.ClientID%>').checked == true)
			{
				str  = document.getElementById('<%=txtMultipleOf.ClientID%>').value;
				if(str == null || str.length == 0)
				{
					alert('Must enter Multiple of');
					return false;
				}
			}
			str  = document.getElementById('<%=txtFrom.ClientID%>').value; 
			if(str == null || str.length == 0)
			{
				alert('Must enter From Range');
				return false;
			}
			str  = document.getElementById('<%=txtTo.ClientID%>').value; 
			if(str == null || str.length == 0)
			{
				alert('Must enter To Range');
				return false;
			}
			if( !(document.getElementById('<%=chDiscount.ClientID%>').checked || document.getElementById('<%=chSKU.ClientID%>').checked) )
			{
				alert('Must Supply values either of Discount or SKU or both'); 
				return false;
			}
			if(document.getElementById('<%=chDiscount.ClientID%>').checked)
			{
			    if(document.getElementById('<%=rbtnDiscount.ClientID%>').index == 0)
				{
				    str = document.getElementById('<%=txtDiscountRate.ClientID%>').value;
					if(str == null || str.length == 0)
					{
						alert('Must enter Discount Rate');
						return false;
					}
					var num = parseFloat(str);
					if(num >= 100.0)
					{
						alert('Discount Rate must not be greater than 100');
						return false;
					}
				}
				if(document.getElementById('<%=rbtnDiscount.ClientID%>').index == 1)
				{
					str = document.getElementById('<%=txtDiscountAmount.ClientID%>').value;
					if(str == null || str.length == 0)
					{
						alert('Must enter Discount Amount');
						return false;
					}
				} 
			}
			return true;			
		}
</script>
    
    <div id="right_data">
        <table width="100%">
            <tr>
                <td>
        <asp:UpdatePanel id="UpdatePanel2" runat="server">
            <contenttemplate>
                <table>
                    <tr>
                        <td align="left">
                            <asp:RadioButton id="rbSKUHierarchy" runat="server" Width="139px" Text="By SKU Hierarchy" OnCheckedChanged="rbSKUHierarchy_CheckedChanged" Checked="True" AutoPostBack="True"></asp:RadioButton></td>
                        <td align="left">
                        </td>
                        <td>
                            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                        </td>
                        <td align="left" colspan="2">
                           <strong> <asp:Label id="lblPromotionOffer" runat="server" Width="120px" CssClass="entryErrorMessage"> Promotion Offer</asp:Label></strong></td>
                    </tr>
                    <tr>
                        <td align="left" style="height: 20px">
                            <strong><asp:Label id="lblSKUCatagory" runat="server" Width="100px" Text="SKU Category" CssClass="lblbox"></asp:Label></strong></td>
                        <td align="left">
                            <asp:DropDownList id="ddSKUCatagory" runat="server" Width="175px" AutoPostBack="True" CssClass="DropList" OnSelectedIndexChanged="ddSKUCatagory_SelectedIndexChanged">
                                </asp:DropDownList></td>
                        <td>
                        </td>
                        <td align="left" colspan="2" rowspan="9">
                            <asp:Panel ID="Panel1" runat="server" BorderColor="Gray" BorderStyle="Groove" BorderWidth="1px"
                                Height="100%" Width="100%">
                                <table>
                                    <tr>
                                        <td style="width: 100px">
                            <asp:CheckBox id="chDiscount" runat="server" Font-Size="8pt" Text="Discount" OnCheckedChanged="chDiscount_CheckedChanged" AutoPostBack="True" Width="95px"></asp:CheckBox></td>
                                        <td style="width: 100px">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td rowspan="2" style="width: 100px">
                            <asp:RadioButtonList id="rbtnDiscount" runat="server" Width="128px" Font-Size="8pt" AutoPostBack="True" CssClass="lblbox" OnSelectedIndexChanged="rbtnDiscount_SelectedIndexChanged" Height="34px"><asp:ListItem Value="0">Discount Rate</asp:ListItem>
<asp:ListItem Value="1">Discount Amount</asp:ListItem>
</asp:RadioButtonList></td>
                                        <td style="width: 100px">
                            <asp:TextBox id="txtDiscountRate" runat="server" Width="168px" CssClass="txtBox" Enabled="False"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 100px">
                            <asp:TextBox id="txtDiscountAmount" runat="server" Width="168px" CssClass="txtBox " Enabled="False"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 100px">
                            <asp:CheckBox id="chSKU" runat="server" Width="49px" Font-Size="8pt" Text="SKU"></asp:CheckBox></td>
                                        <td style="width: 100px">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 100px">
                            <strong><asp:Label id="lblSKUCategory2" runat="server" Width="101px" CssClass="lblbox">SKU Category</asp:Label></strong></td>
                                        <td style="width: 100px">
                            <asp:DropDownList id="ddPromotionCatagory" runat="server" Width="174px" AutoPostBack="True" CssClass="DropList" OnSelectedIndexChanged="ddPromotionCatagory_SelectedIndexChanged">
                                                </asp:DropDownList></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 100px">
                            <strong><asp:Label id="lblSKU2" runat="server" Width="61px" CssClass="lblbox">SKU</asp:Label></strong></td>
                                        <td style="width: 100px">
                            <asp:DropDownList id="ddPromotionSKU" runat="server" Width="174px" AutoPostBack="True" CssClass="DropList">
                                                </asp:DropDownList></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 100px">
                            <strong><asp:Label id="lblQuantity2" runat="server" Width="99px" CssClass="lblbox"> Quantity</asp:Label></strong></td>
                                        <td style="width: 100px">
                            <asp:TextBox id="txtPromotionQuantity" runat="server" Width="168px" CssClass="txtBox "></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 100px">
                                        </td>
                                        <td style="width: 100px">
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" style="height: 20px">
                            <strong><asp:Label id="lblSKUBrand" runat="server" Width="100px" Text="SKU Brand" CssClass="lblbox"></asp:Label></strong></td>
                        <td align="left" style="height: 18px">
                            <asp:DropDownList id="ddSKUBrand" runat="server" Width="175px" AutoPostBack="True" CssClass="DropList" OnSelectedIndexChanged="ddSKUBrand_SelectedIndexChanged">
                                </asp:DropDownList></td>
                        <td style="height: 18px">
                        </td>
                    </tr>
                    <tr>
                        <td align="left" style="height: 20px">
                            <strong><asp:Label id="lblSKU" runat="server" Width="100px" Text="SKU" CssClass="lblbox"></asp:Label></strong></td>
                        <td align="left">
                            <asp:DropDownList id="ddSKU" runat="server" Width="175px" AutoPostBack="True" CssClass="DropList">
                                </asp:DropDownList></td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:RadioButton id="rbSKUGroup" runat="server" Width="139px" Text="By SKU Group" OnCheckedChanged="rbSKUGroup_CheckedChanged" AutoPostBack="True"></asp:RadioButton></td>
                        <td align="left">
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" style="height: 20px">
                            <strong><asp:Label id="lblSKUGroup" runat="server" Width="100px" Text="SKU Group" CssClass="lblbox"></asp:Label></strong></td>
                        <td align="left">
                            <asp:DropDownList id="ddSKUSelectedGroup" runat="server" Width="175px" CssClass="DropList" Enabled="False">
                                </asp:DropDownList></td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" style="height: 20px">
                            <strong><asp:Label id="lblSlabOn" runat="server" Width="100px" Text="Slab On" CssClass="lblbox"></asp:Label></strong></td>
                        <td align="left">
                            <asp:DropDownList id="ddSlabOn" runat="server" Width="175px" AutoPostBack="True" CssClass="DropList" OnSelectedIndexChanged="ddSlabOn_SelectedIndexChanged">
                                    <asp:ListItem Value="82">Quantity</asp:ListItem>
                                    <asp:ListItem Value="83">Amount</asp:ListItem>
                                </asp:DropDownList></td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" style="height: 20px">
                            <asp:CheckBox id="chIsMultiple" runat="server" Text="Is Multiple" OnCheckedChanged="chIsMultiple_CheckedChanged" AutoPostBack="True"></asp:CheckBox></td>
                        <td align="left">
                            <asp:TextBox id="txtMultipleOf" runat="server" Width="168px" CssClass="txtBox" Enabled="False"></asp:TextBox></td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" style="height: 20px">
                            <strong><asp:Label id="lblfromquantity" runat="server" Width="100px" Text="From Quantity" CssClass="lblbox"></asp:Label></strong></td>
                        <td align="left">
                            <asp:TextBox id="txtFrom" runat="server" Width="168px" CssClass="txtBox"></asp:TextBox></td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" style="height: 20px">
                            <strong><asp:Label id="lblToQuantity" runat="server" Width="100px" Text="To Quantity" CssClass="lblbox"></asp:Label></strong></td>
                        <td align="left">
                            <asp:TextBox id="txtTo" runat="server" Width="168px" CssClass="txtBox"></asp:TextBox></td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" style="height: 10px">
                        </td>
                        <td align="left">
                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txtFrom" FilterType = "Custom" ValidChars = "0123456789." >
                            </cc1:FilteredTextBoxExtender>
                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" TargetControlID="txtDiscountAmount" FilterType ="Custom" ValidChars = "0123456789.">
                            </cc1:FilteredTextBoxExtender>
                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server" TargetControlID="txtMultipleOf" FilterType ="Custom" ValidChars ="0123456789.">
                            </cc1:FilteredTextBoxExtender>
                        </td>
                        <td>
                            &nbsp;</td>
                        <td>
                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="txtTo" FilterType = "Custom" ValidChars = "0123456789." >
                            </cc1:FilteredTextBoxExtender>
                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server" TargetControlID="txtPromotionQuantity" FilterType ="Numbers">
                            </cc1:FilteredTextBoxExtender>
                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender6" runat="server" TargetControlID="txtDiscountRate" FilterType = "Custom" ValidChars = "0123456789.">
                            </cc1:FilteredTextBoxExtender>
                            &nbsp;
                            &nbsp;&nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Button id="btnAddtoSlab" onclick="btnAddtoSlab_Click" runat="server" Width="116px" Font-Size="8pt" Text="Add To Slab" ValidationGroup="vg" CssClass="btn" /> </td>
                        <td align="left">
                            <asp:Button id="btnCreateNewSlab" onclick="btnCreateNewSlab_Click" runat="server" Width="132px" Font-Size="8pt" Text="Create New Slab" ValidationGroup="vg" CausesValidation="False" CssClass="btn" /> </td>
                        <td>
                        </td>
                        <td align="right">
                            <asp:Button id="btnBack" onclick="btnBack_Click" runat="server" Width="90px" Font-Size="8pt" Text="Back" ValidationGroup="vg" CausesValidation="False" CssClass="btn" />&nbsp;</td>
                        <td align="left">
                            <asp:Button id="btnNext" onclick="btnNext_Click" runat="server" Width="90px" Font-Size="8pt" Text="Next" ValidationGroup="vg" CausesValidation="False" CssClass="btn" /> </td>
                    </tr>
                </table>
</contenttemplate>
                    </asp:UpdatePanel>  
                </td>                
            </tr>
        </table>        
        <asp:UpdatePanel id="UpdatePanel1" runat="server">
            <contenttemplate>
<asp:GridView id="grdSlab" runat="server" Width="94%" ForeColor="SteelBlue" CssClass="gridRow2" BorderColor="White" OnRowDeleting="grdSlab_RowDeleting" AutoGenerateColumns="False" HorizontalAlign="Center" BackColor="White" OnRowEditing="grdSlab_RowEditing">
<PagerSettings FirstPageText="" LastPageText="" Mode="NextPrevious" NextPageText="Next" PreviousPageText="Previous"></PagerSettings>

<RowStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid" ForeColor="Black"></RowStyle>
<Columns>
<asp:BoundField DataField="SLAB_NO" HeaderText="SLAB_NO">
<HeaderStyle CssClass="hiddencol"></HeaderStyle>

<ItemStyle CssClass="hiddencol"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="SLAB NO" HeaderText="Slab No">
<ItemStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="Is_Multiple" HeaderText="Is Multiple"></asp:BoundField>
<asp:BoundField DataField="Multiple_of" HeaderText="Multiple Of">
<ItemStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="SKU" HeaderText="SKU">
<ItemStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="UOM" HeaderText="UOM" Visible="False">
<ItemStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="Slab On" HeaderText="Slab On">
<ItemStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="From" HeaderText="From">
<ItemStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="To" HeaderText="To">
<ItemStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="Discount" HeaderText="Discount">
<ItemStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="SKU Offer" HeaderText="SKU Offer">
<ItemStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="SKU Quantity" HeaderText="SKU Quantity">
<ItemStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid"></ItemStyle>
</asp:BoundField>
<asp:CommandField ShowEditButton="True" HeaderText="Edit">
<ItemStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid"></ItemStyle>
</asp:CommandField>
<asp:TemplateField HeaderText="Delete"><ItemTemplate>
<asp:LinkButton id="btnDelete" runat="server" Text="Delete" OnClientClick="javascript:return confirm('Are you sure you want to Delete?');return false;" CommandName="Delete"></asp:LinkButton> 
</ItemTemplate>

<ItemStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid"></ItemStyle>
</asp:TemplateField>
</Columns>

<FooterStyle BackColor="White"></FooterStyle>

<PagerStyle BackColor="Transparent"></PagerStyle>

<HeaderStyle CssClass="tblhead" ForeColor="White"></HeaderStyle>

<AlternatingRowStyle CssClass="GridAlternateRowStyle"></AlternatingRowStyle>
</asp:GridView> 
</contenttemplate>
        </asp:UpdatePanel>
        </div>	
</asp:Content>
