<%@ Page Language="C#" MasterPageFile="~/Forms/PageMaster.master" AutoEventWireup="true" CodeFile="frmSaleForceShortage.aspx.cs" Inherits="Forms_frmSaleForceShortage" Title="SAMS >>  Sale Force Shortage" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cphPage">   
      <script language="JavaScript" type="text/javascript">
    
    function ValidateForm()
    {
        var str;
        str  =  document.getElementById("<%= txtAmount.ClientID %>").value;
        if(str == null || str.length == 0)
		{
			alert('Must enter Amount');
			return false;
		}
		
    }
 
  </script>
    <div id="right_data">
        <table width="100%">
            <tr>
                <td style="width: 100px;">
                    <div style="z-index: 101; left: 332px; width: 100px; position: absolute; top: 274px;
                        height: 83px">
                        &nbsp;<asp:Panel ID="Panel21" runat="server">
                            <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel3">
                                <ProgressTemplate>
                                    <asp:ImageButton ID="ImageButton1" runat="server" Height="26px" ImageUrl="~/App_Themes/Granite/Images/image003.gif"
                                        Width="23px" />
                                    Wait Update
                                </ProgressTemplate>
                            </asp:UpdateProgress>
                        </asp:Panel>
                    </div>
                </td>
                <td>
                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                        <ContentTemplate>
                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" FilterType="Custom"
                                 TargetControlID="txtAmount" ValidChars="0123456789.">
                            </cc1:FilteredTextBoxExtender>
                            <asp:Panel ID="Panel1" runat="server" DefaultButton="btnAddNew">
                            <table>
                                <tr>
                                    <td align="left" style="height: 20px">
                                        <strong><asp:Label ID="lblfromLocation" runat="server" CssClass="lblbox" Text="Location"
                                            Width="65px"></asp:Label></strong></td>
                                    <td style="width: 100px"><asp:DropDownList id="drpDistributor" runat="server" Width="250px" CssClass="DropList">
                                    </asp:DropDownList></td>
                                </tr>
                                <tr>
                                    <td style="height: 20px;" align="left">
            <strong><asp:Label ID="Label8" runat="server" CssClass="lblbox" Text="Principal" Width="68px"></asp:Label></strong></td>
                                    <td style="width: 100px">
            <asp:DropDownList id="DrpPrincipal" runat="server" Width="250px" CssClass="DropList">
            </asp:DropDownList></td>
                                </tr>
                                <tr>
                                    <td align="left" style="height: 20px">
                                        <strong><asp:Label ID="Label2" runat="server" CssClass="lblbox" Text="Sale Force" Width="73px"></asp:Label></strong></td>
                                    <td style="width: 100px">
                                        <asp:DropDownList ID="DrpSaleForce" runat="server" CssClass="DropList" Width="250px">
                                        </asp:DropDownList></td>
                                </tr>
                                <tr>
                                    <td align="left" style="height: 20px">
            <strong><asp:Label ID="Label9" runat="server" CssClass="lblbox" Text="Remarks" Width="71px"></asp:Label></strong></td>
                                    <td align="left" style="height: 20px">
            <asp:TextBox ID="txtRemarks" runat="server" CssClass="txtBox " Width="243px"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td align="left" style="height: 20px">
            <strong><asp:Label id="Label6" runat="server" Width="63px" Text="Amount" CssClass="lblbox"></asp:Label></strong></td>
                                    <td align="left" style="height: 20px">
            <asp:TextBox id="txtAmount" runat="server" Width="107px" CssClass="txtBox "></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td style="width: 100px" align="left">
            </td>
                                    <td align="left" colspan="1" style="height: 20px">
            <asp:Button CssClass="btn" ID="btnAddNew" runat="server" AccessKey="S" Font-Size="8pt" OnClick="btnAddNew_Click"
                Text="Save" Width="95px" /></td>
                                </tr>
                            </table>
                            </asp:Panel>
                            &nbsp;&nbsp;
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <strong><asp:Label ID="lblRowId" runat="server" Text="Label" Visible="False"></asp:Label></strong>
                </td>
            </tr>
        </table>        
    <table width="100%">
        <tr>
            <td>
              <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:Panel ID="Panel12" runat="server" Height="136px" ScrollBars="Vertical" Width="620px" BorderColor="Gray" BorderStyle="Groove" BorderWidth="1px">
                    <asp:GridView ID="GrdOrder" runat="server" AutoGenerateColumns="False" BackColor="White"
                        BorderColor="White" CaptionAlign="Left" CssClass="gridRow2" ForeColor="SteelBlue"
                        HorizontalAlign="Center" OnRowDeleting="GrdOrder_RowDeleting"
                        OnRowEditing="GrdOrder_RowEditing" Width="600px">
                        <PagerSettings FirstPageText="" LastPageText="" Mode="NextPrevious" NextPageText="Next"
                            PreviousPageText="Previous" />
                        <RowStyle ForeColor="Black" />
                        <Columns>
                            <asp:BoundField DataField="SALE_FORCE_SHORT_ID" HeaderText="Account Head Id">
                                <FooterStyle CssClass="hiddencol" />
                                <HeaderStyle CssClass="hiddencol" />
                                <ItemStyle CssClass="hiddencol" />
                            </asp:BoundField>
                            <asp:BoundField DataField="SALE_FORCE_ID" HeaderText="SALE_FORCE_ID">
                                <HeaderStyle CssClass="hiddencol" />
                                <ItemStyle CssClass="hiddencol" />
                            </asp:BoundField>
                            <asp:BoundField DataField="PRINCIPAL_ID" HeaderText="PRINCIPAL_ID">
                                <HeaderStyle CssClass="hiddencol" />
                                <ItemStyle CssClass="hiddencol" />
                            </asp:BoundField>
                            <asp:BoundField DataField="SKU_HIE_NAME" HeaderText="Principal">
                                <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="USER_NAME" HeaderText="Sale Force">
                                <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Remarks" HeaderText="Remarks">
                                <FooterStyle HorizontalAlign="Right" />
                                <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="AMOUNT" DataFormatString="{0:F2}" FooterText="Total" HeaderText="Amount">
                                <FooterStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Right" />
                                <HeaderStyle HorizontalAlign="Right" />
                                <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Right" />
                            </asp:BoundField>
                            <asp:CommandField HeaderText="Edit" ShowEditButton="True">
                                <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" Width="47px" />
                            </asp:CommandField>
                        </Columns>
                        <FooterStyle BackColor="White" />
                        <PagerStyle BackColor="Transparent" />
                        <HeaderStyle  CssClass="tblhead" />
                        <AlternatingRowStyle BackColor="#F2F2F2" CssClass="GridAlternateRowStyle" ForeColor="#333333" />
                    </asp:GridView> 
                </asp:Panel>      
            </ContentTemplate>
        </asp:UpdatePanel>        
             </td>
        </tr>
    </table>
    </div>
</asp:Content>

