<%@ Page Language="C#" MasterPageFile="~/Forms/AppMaster.master" AutoEventWireup="true" CodeFile="frmVoucherEditing.aspx.cs" Inherits="Forms_frmVoucherEditing" Title="Untitled Page" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="mainCopy" Runat="Server">
   <script language="JavaScript" type="text/javascript">
    function ValidateForm()
    {
        var str;
        str  =  document.getElementById("<%= txtAccountCode.ClientID %>").value;
        if(str == null || str.length == 0)
		{
			alert('Must enter Account Code');
			return false;
		}
		str  =  document.getElementById("<%= txtAccountName.ClientID %>").value;
		if(str == null || str.length == 0)
		{
			alert('Wrong Account Code');
			return false;
		}
	    str  =  document.getElementById("<%= txtVoucherDate.ClientID %>").value;
		if(str == null || str.length < 9)
		{
			alert('Must Enter Voucher Date');
			return false;
		}
        var Debit = document.getElementById("<%= txtDebitAmount.ClientID %>").value;
        var Credit = document.getElementById("<%= txtCreditAmount.ClientID %>").value;
        
        if(Debit.length == 0 && Credit.length == 0)
        {
            alert('Debit or Credit Must Enter');
            return false;
        }  
        
        if(Debit > 0 && Credit > 0)
        {
            alert('Only Debit or Credit Can Enter');
            return false;
        }
        return true;
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

 function SelectCode(e)
 {
      if(e.keyCode == 13)
      {
        var str  = document.getElementById("<%= LstAccountHead.ClientID %>").value;
        document.getElementById("<%= txtAccountCode.ClientID %>").value =  str.substring(0,str.indexOf('~')); 
        document.getElementById("<%= txtAccountName.ClientID %>").value =  str.substring(str.indexOf('~') + 1);
        document.getElementById("<%= Panel3.ClientID %>").className = "hiddencol";
        document.getElementById("<%= txtAccountDes.ClientID %>").focus();
      }
 }
 function ClearSelection(lb)
 {
    lb.selectedIndex = -1;
 }

  </script>
 <div>
     <div class="container" style="background-color: white">
         <h2>
             &nbsp; Voucher Entry</h2>
     </div>
     <div class="container">
         <table width="100%">
             <tr>
                 <td style="height: 13px">
                 </td>
                 <td align="center" style="height: 13px">
                     <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                         <ContentTemplate>
                             <table>
                                 <tr>
                                     <td align="left" style="width: 84px">
                                         <asp:Label ID="Label4" runat="server" CssClass="lblbox" Text="Location" Width="61px"></asp:Label></td>
                                     <td align="left" style="height: 20px;">
                                         <asp:DropDownList ID="drpDistributor" runat="server" CssClass="DropList" Width="206px" Enabled="False">
                                         </asp:DropDownList></td>
                                     <td align="left">
                                     </td>
                                     <td align="left">
                                         <asp:Label ID="Label5" runat="server" CssClass="lblbox" Text="Voucher Type" Width="83px"></asp:Label></td>
                                     <td align="left">
                                         <asp:DropDownList ID="DrpVoucherType" runat="server" AutoPostBack="True" CssClass="DropList" Width="205px" Enabled="False">
                                             <asp:ListItem Value="14">Cash Voucher</asp:ListItem>
                                             <asp:ListItem Value="15">Bank Voucher</asp:ListItem>
                                             <asp:ListItem Value="16">Journal Voucher</asp:ListItem>
                                         </asp:DropDownList></td>
                                 </tr>
                                 <tr>
                                     <td align="left" style="width: 84px">
                                         <asp:Label ID="Label1" runat="server" CssClass="lblbox" Text="Voucher No" Width="76px"></asp:Label></td>
                                     <td align="left" style="height: 20px;">
                                         <asp:TextBox ID="txtVoucherNo" runat="server" CssClass="txtBox " onkeyup="SearchList()" Width="200px" Enabled="False"></asp:TextBox></td>
                                     <td align="left" style="height: 18px">
                                     </td>
                                     <td align="left" style="height: 18px">
                                         <asp:Label ID="Label6" runat="server" CssClass="lblbox" Text="Voucher Date" Width="76px"></asp:Label></td>
                                     <td align="left" style="height: 18px">
                                         <asp:TextBox ID="txtVoucherDate" runat="server" CssClass="txtBox " Width="200px" Enabled="False"></asp:TextBox></td>
                                 </tr>
                                 <tr>
                                     <td align="left" style="width: 84px">
                                         <asp:Label ID="Label2" runat="server" CssClass="lblbox" Text="Principal" Width="72px"></asp:Label></td>
                                     <td align="left" style="height: 20px;">
                                         <asp:DropDownList ID="DrpPrincipal" runat="server" CssClass="DropList" Width="206px">
                                         </asp:DropDownList></td>
                                     <td align="left">
                                     </td>
                                     <td align="left">
                                         <asp:Label ID="Label9" runat="server" CssClass="lblbox" Text="Payment Mode"
                                             Width="91px"></asp:Label></td>
                                     <td align="left" style="height: 20px">
                                         <asp:DropDownList ID="DrpPaymentMode" runat="server" CssClass="DropList" Width="206px">
                                             <asp:ListItem Value="19">Cash</asp:ListItem>
                                             <asp:ListItem Value="18">Cheque</asp:ListItem>
                                             <asp:ListItem Value="21">Pay Order</asp:ListItem>
                                             <asp:ListItem Value="27">Petty Voucher</asp:ListItem>
                                         </asp:DropDownList></td>
                                 </tr>
                                 <tr>
                                     <td align="left" style="width: 84px">
                                         <asp:Label ID="lblChequeNo" runat="server" CssClass="lblbox" Text="Cheque No" Width="76px"></asp:Label></td>
                                     <td align="left" style="height: 20px;">
                                         <asp:TextBox ID="txtChequeNo" runat="server" CssClass="txtBox " 
                                             Width="200px"></asp:TextBox></td>
                                     <td align="left" style="height: 20px">
                                     </td>
                                     <td align="left" style="height: 20px">
                                         <asp:Label ID="lblChequedate" runat="server" CssClass="lblbox" Text="Cheque Date"
                                             Width="93px"></asp:Label></td>
                                     <td align="left" style="height: 20px">
                                         <asp:TextBox ID="txtChequeDate" runat="server" CssClass="txtBox " onkeyup="SearchList()"
                                             Width="200px"></asp:TextBox></td>
                                 </tr>
                                 <tr>
                                     <td align="left" style="width: 84px">
                                         <asp:Label ID="Label3" runat="server" CssClass="lblbox" Text="Narration" Width="85px"></asp:Label></td>
                                     <td align="left" colspan="4" style="height: 20px">
                                         <asp:TextBox ID="txtRemarks" runat="server" CssClass="txtBox " 
                                             Width="508px"></asp:TextBox></td>
                                 </tr>
                                 <tr>
                                     <td align="left" style="width: 84px">
                                         <asp:Label ID="Label10" runat="server" CssClass="lblbox" Text="Payee's Name" Width="91px"></asp:Label></td>
                                     <td align="left" style="height: 20px">
                                         <asp:TextBox ID="txtpayeesName" runat="server" CssClass="txtBox " Width="200px"></asp:TextBox></td>
                                     <td align="left" style="height: 20px">
                                     </td>
                                     <td align="left" style="height: 20px">
                                         <asp:Label ID="Label7" runat="server" CssClass="lblbox" Text="Account Head" Width="91px"></asp:Label></td>
                                     <td align="left" style="height: 20px">
                                         <asp:TextBox ID="txtAccountName" runat="server" CssClass="txtBox " Enabled="False"
                                             Font-Bold="False" ForeColor="Black" Width="200px"></asp:TextBox></td>
                                 </tr>
                             </table>
                             &nbsp; &nbsp;
                             <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" Mask="99/99/9999"
                                 MaskType="Date" TargetControlID="txtChequeDate">
                             </cc1:MaskedEditExtender>
                             &nbsp;
                             <cc1:MaskedEditExtender ID="MaskedEditExtender2" runat="server" Mask="99/99/9999"
                                 MaskType="Date" TargetControlID="txtVoucherDate">
                             </cc1:MaskedEditExtender>
                             <asp:TextBox ID="txtTotalDebit" runat="server" CssClass="hiddencol" Width="100px"></asp:TextBox><asp:TextBox
                                 ID="txtTotalCredit" runat="server" CssClass="hiddencol" Width="73px"></asp:TextBox>
                             &nbsp;
                             &nbsp; &nbsp;
                         </ContentTemplate>
                     </asp:UpdatePanel>
                     &nbsp;</td>
                 <td style="height: 13px">
                 </td>
             </tr>
         </table>
     </div>
     <div class="container">
         <table width="100%">
             <tr>
                 <td style="width: 100px">
                 </td>
                 <td align="center">
                     <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                         <ContentTemplate>
                             <table cellpadding="0" cellspacing="0" style="border-right: #007395 1px solid; border-top: #007395 1px solid; border-left: #007395 1px solid; border-bottom: #007395 1px solid">
                                 <tr>
                                     <td style="height: 16px">
                                         <asp:Label ID="lblskuCode" runat="server" BackColor="#007395" Font-Bold="True" ForeColor="White"
                                             Height="16px" Text="Account Code" Width="126px"></asp:Label></td>
                                     <td style="height: 16px">
                                         <asp:Label ID="lblskuname" runat="server" BackColor="#007395" Font-Bold="True" ForeColor="White"
                                             Height="16px" Text="Description" Width="236px"></asp:Label></td>
                                     <td style="height: 16px">
                                         <asp:Label ID="Label11" runat="server" BackColor="#007395" Font-Bold="True" ForeColor="White"
                                             Height="16px" Text="Debit" Width="116px"></asp:Label></td>
                                     <td style="height: 16px">
                                         <asp:Label ID="Label12" runat="server" BackColor="#007395" Font-Bold="True" ForeColor="White"
                                             Height="16px" Text="Credit" Width="118px"></asp:Label></td>
                                     <td style="height: 16px">
                                     </td>
                                     <td style="height: 16px">
                                         <asp:Button ID="btnSave" runat="server" Font-Size="X-Small" OnClick="btnSave_Click" Text="Slip No"
                                             Width="112px" BackColor="#007395" BorderStyle="None" Font-Bold="True" ForeColor="White" Height="16px" /></td>
                                 </tr>
                                 <tr>
                                     <td style="height: 12px">
                                         <asp:TextBox ID="txtAccountCode" runat="server" CssClass="txtBox " onkeyup="SearchList()"
                                             Width="120px"></asp:TextBox></td>
                                     <td colspan="1" rowspan="1">
                                         <asp:TextBox ID="txtAccountDes" runat="server" CssClass="txtBox " onfocus="SearchedCode();"  Width="230px"></asp:TextBox></td>
                                     <td style="height: 12px">
                                         <asp:TextBox ID="txtDebitAmount" runat="server" CssClass="txtBox " 
                                             Width="110px"></asp:TextBox></td>
                                     <td style="height: 12px">
                                         <asp:TextBox ID="txtCreditAmount" runat="server" CssClass="txtBox " Width="110px"></asp:TextBox></td>
                                     <td style="height: 12px">
                                     </td>
                                     <td style="height: 12px">
                                         <asp:TextBox ID="TextBox1" runat="server" CssClass="txtBox " Width="105px" Enabled="False"></asp:TextBox></td>
                                 </tr>
                                 <tr>
                                     <td align="center" colspan="6" rowspan="1">
                                         <asp:GridView ID="GrdOrder" runat="server" AutoGenerateColumns="False" BackColor="White"
                                             BorderColor="White" CaptionAlign="Left" CssClass="gridRow2" ForeColor="SteelBlue"
                                             HorizontalAlign="Center" OnRowDataBound="GrdOrder_RowDataBound" OnRowDeleting="GrdOrder_RowDeleting"
                                             OnRowEditing="GrdOrder_RowEditing" ShowFooter="True" ShowHeader="False" Width="714px">
                                             <PagerSettings FirstPageText="" LastPageText="" Mode="NextPrevious" NextPageText="Next"
                                                 PreviousPageText="Previous" />
                                             <RowStyle ForeColor="Black" />
                                             <Columns>
                                                 <asp:BoundField DataField="Account_Head_Id" HeaderText="Account Head Id">
                                                     <FooterStyle CssClass="hiddencol" />
                                                     <HeaderStyle CssClass="hiddencol" />
                                                     <ItemStyle CssClass="hiddencol" />
                                                 </asp:BoundField>
                                                 <asp:BoundField DataField="Account_Code" HeaderText="Account Code">
                                                     <FooterStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" />
                                                     <HeaderStyle HorizontalAlign="Left" />
                                                     <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Left"
                                                         Width="105px" />
                                                 </asp:BoundField>
                                                 <asp:BoundField DataField="REMARKS" HeaderText="Account Description">
                                                     <FooterStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Right" />
                                                     <HeaderStyle HorizontalAlign="Left" />
                                                     <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Left"
                                                         Width="200px" />
                                                 </asp:BoundField>
                                                 <asp:BoundField DataField="debit" DataFormatString="{0:F2}" HeaderText="Debit">
                                                     <FooterStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Right" />
                                                     <HeaderStyle HorizontalAlign="Right" />
                                                     <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Right"
                                                         Width="100px" />
                                                 </asp:BoundField>
                                                 <asp:BoundField DataField="credit" DataFormatString="{0:F2}" HeaderText="Credit">
                                                     <FooterStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Right" />
                                                     <HeaderStyle HorizontalAlign="Right" />
                                                     <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Right"
                                                         Width="100px" />
                                                 </asp:BoundField>
                                                 <asp:BoundField DataField="Account_Name">
                                                     <HeaderStyle CssClass="hiddencol" />
                                                     <ItemStyle CssClass="hiddencol" />
                                                     <FooterStyle CssClass="hiddencol" />
                                                 </asp:BoundField>
                                                 <asp:CommandField HeaderText="Edit" ShowEditButton="True">
                                                     <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" Width="47px" />
                                                 </asp:CommandField>
                                                 <asp:TemplateField HeaderText="Delete">
                                                     <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" Width="46px" />
                                                     <ItemTemplate>
                                                         <asp:LinkButton ID="btnDelete" runat="server" CommandName="Delete" OnClientClick="javascript:return confirm('Are you sure you want to Delete?');return false;"
                                                             Text="Delete"></asp:LinkButton>
                                                     </ItemTemplate>
                                                 </asp:TemplateField>
                                             </Columns>
                                             <FooterStyle BackColor="White" />
                                             <PagerStyle BackColor="Transparent" />
                                             <HeaderStyle BackColor="#007395" Font-Bold="True" ForeColor="White" HorizontalAlign="Center"
                                                 VerticalAlign="Middle" />
                                             <AlternatingRowStyle BackColor="#F2F2F2" CssClass="GridAlternateRowStyle" ForeColor="#333333" />
                                         </asp:GridView>
                                         <div style="left: 409px; position: absolute; top: 152px; height: 352px; width: 352px;">
                                             <asp:Panel ID="Panel3" runat="server" BackColor="Silver" BorderColor="White" BorderStyle="Inset"
                                                 BorderWidth="1px" CssClass="hiddencol" Height="357px" Width="349px">
                                                 <table style="border-right: #ffffff thin groove; border-top: #ffffff thin groove;
                                                     border-left: #ffffff thin groove; width: 99%; border-bottom: #ffffff thin groove">
                                                     <tbody>
                                                         <tr>
                                                             <td align="left" colspan="2" style="border-bottom: black thin solid">
                                                                 &nbsp;Select A<strong>ccount Head from List</strong></td>
                                                             <td align="right" style="border-bottom: black thin solid" valign="top">
                                                                 <asp:Button ID="Button5" runat="server" BorderStyle="Groove" BorderWidth="1px" Font-Size="8pt"
                                                                     Height="16px" Text="X" Width="21px" /></td>
                                                         </tr>
                                                     </tbody>
                                                 </table>
                                                 <asp:ListBox ID="LstAccountHead" runat="server" CssClass="DropList" Height="326px"
                                                     onkeyup="SelectCode(event)" Width="346px"></asp:ListBox></asp:Panel>
                                             &nbsp; &nbsp;&nbsp;
                                         </div>
                                         &nbsp;&nbsp;</td>
                                 </tr>
                                 <tr>
                                     <td align="center" colspan="6">
                                         <asp:Button ID="btnDone" runat="server" AccessKey="S" Font-Size="8pt" OnClick="btnDone_Click"
                                             Text="Update" Width="105px" /></td>
                                 </tr>
                             </table>
                             <br />
                             <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" FilterType="Custom"
                                 TargetControlID="txtCreditAmount" ValidChars=".0123456789">
                             </cc1:FilteredTextBoxExtender>
                             <div style="z-index: 101; left: 499px; width: 100px; position: absolute; top: 238px;
                                 height: 100px">
                                 <asp:Panel ID="Panel21" runat="server">
                                     <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel2">
                                         <ProgressTemplate>
                                             <asp:ImageButton ID="ImageButton1" runat="server" Height="26px" ImageUrl="~/App_Themes/Granite/Images/image003.gif"
                                                 Width="23px" />
                                             Wait Update
                                         </ProgressTemplate>
                                     </asp:UpdateProgress>
                                 </asp:Panel>
                             </div>
                             <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" FilterType="Custom"
                                 TargetControlID="txtDebitAmount" ValidChars="0123456789.">
                             </cc1:FilteredTextBoxExtender>
                             &nbsp;
                         </ContentTemplate>
                     </asp:UpdatePanel>
                 </td>
                 <td style="width: 100px">
                 </td>
             </tr>
         </table>
     </div>
            <br />
  </div>


</asp:Content>

