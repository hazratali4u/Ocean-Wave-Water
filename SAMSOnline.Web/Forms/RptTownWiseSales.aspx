<%@ Page Language="C#" MasterPageFile="~/Forms/PageMaster.master" AutoEventWireup="true" CodeFile="RptTownWiseSales.aspx.cs" Inherits="Forms_RptTownWiseSales" Title="SAMS >> Town Wise Sales" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cphPage">
    
     <script language="JavaScript" type="text/javascript">
    function ValidateForm()
	{
			
		return true;	  		
	}

    </script>
     <div id="right_data">
        <table width="100%">
            <tr>
                <td>
                    <asp:UpdatePanel id="UpdatePanel1" runat="server">
                        <contenttemplate>
                        <table>
                            <tr>
                                <td style="width:10%" align="right">
                                    <strong><asp:Label ID="lbltoLocation" runat="server" Text="Location:"></asp:Label></strong>
                                </td>
                                <td style="width:1%"></td>
                                <td style="width:89%">
                                    <asp:DropDownList id="drpDistributor" runat="server" Width="200px"></asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td style="width:10%" align="right">
                                    <strong><asp:Label ID="Label2" runat="server" Text="Principal:"></asp:Label></strong>
                                </td>
                                <td style="width:1%"></td>
                                <td style="width:89%">
                                    <asp:DropDownList id="DrpPrincipal" runat="server" Width="200px"></asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td style="width:10%" align="right">
                                    <strong><asp:Label ID="Label1" runat="server" Text="SKU:"></asp:Label></strong>
                                </td>
                                <td style="width:1%"></td>
                                <td style="width:89%">
                                    <asp:DropDownList id="ddlSKU" runat="server" Width="200px"></asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td style="width:10%" align="right">
                                    <strong><asp:Label ID="Label3" runat="server" Text="Area:"></asp:Label></strong>
                                </td>
                                <td style="width:1%"></td>
                                <td style="width:89%">
                                    <asp:DropDownList id="ddlTown" runat="server" Width="200px"></asp:DropDownList>
                                </td>
                            </tr>
                        </table>
</contenttemplate>
                    </asp:UpdatePanel>
                    <br />
        <asp:Button ID="Button2" runat="server" 
                Text="View PDF" CssClass="btn" OnClick="Button2_Click" />
                    <asp:Button ID="Button1" runat="server" 
                Text="View Excel" CssClass="btn" OnClick="Button1_Click" /></td>
            </tr>
        </table>
     </div>
</asp:Content>

