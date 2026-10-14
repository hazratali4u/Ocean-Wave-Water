<%@ Page Language="C#" MasterPageFile="~/Forms/PageMaster.master" AutoEventWireup="true" CodeFile="frmDayCloseStatus.aspx.cs" Inherits="Forms_frmDayCloseStatus" Title="SAMS >> Data Update Status" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphPage" Runat="Server">
<script language="JavaScript" type="text/javascript" >
           javascript:window.history.forward(1);        
           
</script>
    <script language="JavaScript" type="text/javascript">
        function ConfirmCancel()
		{
		    if( confirm("Are you sure? You want to Day Close?")==true)
		    return true;
		
		    else
		    {return false;}
		}
	</script>
    <div id="right_data">
           <table width="100%">          
            <tr>
                <td align="center">
                    <asp:GridView ID="Grid_Hierarchy" runat="server" AutoGenerateColumns="False" BackColor="White"
                        BorderColor="White" CssClass="gridRow2" ForeColor="SteelBlue"
                        HorizontalAlign="Center" Width="90%">
                        <PagerSettings FirstPageText="" LastPageText="" Mode="NextPrevious" NextPageText="Next"
                            PreviousPageText="Previous" />
                        <RowStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" ForeColor="Black" />
                        <Columns>
                            <asp:BoundField DataField="DISTRIBUTOR_NAME" HeaderText="Location Name" >
                                <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Left" />
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="CONTACT_PERSON" HeaderText="Contact Person" >
                                <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Left" />
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="CONTACT_NUMBER" HeaderText="Contact Number" >
                                <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Left" />
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="CLOSING_DATE" HeaderText="Last Day Close">
                                <ItemStyle ForeColor="Red" BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Left" />
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                        </Columns>
                        <FooterStyle BackColor="White" />
                        <PagerStyle BackColor="Transparent" />
                        <HeaderStyle CssClass="tblhead" />
                        <AlternatingRowStyle CssClass="GridAlternateRowStyle" />
                    </asp:GridView>                    
                </td>
            </tr>
            <tr>
                <td align="center">
                <asp:Button ID="Button1" runat="server"  OnClick="Button1_Click" Text="Day Close"
                        Visible="False" CssClass="btn" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
