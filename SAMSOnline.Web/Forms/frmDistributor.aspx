<%@ page language="C#" masterpagefile="~/Forms/PageMaster.master" autoeventwireup="true" CodeFile = "frmDistributor.aspx.cs" inherits="Forms_frmDistributor" title="SAMS >> New Location" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cphPage">
    
       <script language="JavaScript" type="text/javascript">
        function ValidateForm()
		{
			var str;
			str  = document.getElementById('<%=txtDistributorCode.ClientID%>').value; 
			if(str == null || str.length == 0)
			{
				alert('Must enter Distributor Code');
				return false;
			}
			str  = document.getElementById('<%=txtDistributorName.ClientID%>').value; 
			if(str == null || str.length == 0)
			{
				alert('Must enter Distributor Name');
				return false;
			}
			str  = document.getElementById('<%=txtPhoneNo.ClientID%>').value; 
			if(str == null || str.length == 0)
			{
				alert('Must enter phone');
				return false;
			}
			str  = document.getElementById('<%=txtcontactperson.ClientID%>').value; 
			if(str == null || str.length == 0)
			{
				alert('Must enter Contact Person Name');
				return false;
			}
		
			str  = document.getElementById('<%=txtAddress2.ClientID%>').value; 
			if(str == null || str.length == 0)
			{
				alert('Must enter Email Address');
				return false;
			}
			str  = document.getElementById('<%=txtAddress1.ClientID%>').value; 
			if(str == null || str.length == 0)
			{
				alert('Must enter Address');
				return false;
			}
			str  = document.getElementById('<%=txtpassword.ClientID%>').value; 
			if(str == null || str.length == 0)
			{
				alert('Must enter Fax No');
				return false;
			}
			return true;		
		}
    </script>
    <div id="right_data">
        <table width="100%">
            <tr>
               
                <td style="width: 102px">
                    <asp:UpdatePanel id="UpdatePanel12" runat="server">
                        <contenttemplate>
<TABLE><TBODY><TR><TD style="HEIGHT: 25px" align=left colSpan=4>
<strong><asp:Label id="lblErrorMsg" runat="server" ForeColor="Red" Font-Bold="True"></asp:Label></strong> </TD><TD></TD></TR><TR><TD style="HEIGHT: 25px" align=left>
<strong><asp:Label id="Label3" runat="server" Width="83px" Text="Company" CssClass="lblbox"></asp:Label></strong></TD><TD style="HEIGHT: 25px"><asp:DropDownList id="DrpCompanyName" runat="server" Width="209px" CssClass="DropList" AutoPostBack="True" OnSelectedIndexChanged="ddDistributorType_SelectedIndexChanged"></asp:DropDownList></TD><TD style="HEIGHT: 25px">&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </TD><TD style="HEIGHT: 25px" align=left>
<strong><asp:Label id="lbldesignationID" runat="server" Width="80px" Text="Location Type" CssClass="lblbox"></asp:Label></strong></TD><TD style="height: 25px"><asp:DropDownList id="ddDistributorType" runat="server" Width="208px" CssClass="DropList" OnSelectedIndexChanged="ddDistributorType_SelectedIndexChanged"></asp:DropDownList></TD></TR><TR><TD style="height: 25px;" align=left>
<strong><asp:Label id="Label1" runat="server" Width="77px" Text="Code" CssClass="lblbox"></asp:Label></strong></TD><TD style="WIDTH: 200px"><asp:TextBox id="txtDistributorCode" runat="server" Width="200px" CssClass="txtBox "></asp:TextBox></TD><TD style="HEIGHT: 25px"></TD><TD align=left>
<strong><asp:Label id="lblNickName" runat="server" Width="69px" Text="Name" CssClass="lblbox"></asp:Label></strong></TD><TD style="height: 25px;"><asp:TextBox id="txtDistributorName" runat="server" Width="200px" CssClass="txtBox "></asp:TextBox></TD></TR><TR><TD style="height: 25px;" align=left>
<strong><asp:Label id="Label4" runat="server" Width="96px" Text="Contact Person" CssClass="lblbox"></asp:Label></strong></TD><TD style="WIDTH: 200px"><asp:TextBox id="txtcontactperson" runat="server" Width="200px" CssClass="txtBox "></asp:TextBox></TD><TD style="HEIGHT: 25px"></TD><TD align=left>
<strong><asp:Label id="lblPhNo" runat="server" Width="76px" Text="Phone No" CssClass="lblbox"></asp:Label></strong></TD><TD style="height: 25px;"><asp:TextBox id="txtPhoneNo" runat="server" Width="200px" CssClass="txtBox "></asp:TextBox></TD></TR>
    <tr>
        <td align="left" style="height: 25px">
            <strong><asp:Label id="lblAddress2" runat="server" Width="80px" Text="Address" CssClass="lblbox"></asp:Label></strong></td>
        <td colspan="4" style="height: 25px">
        <asp:TextBox id="txtAddress1" runat="server" Width="540px"></asp:TextBox></td>
    </tr>
    <TR><TD style="HEIGHT: 25px" align=left>
            <strong><asp:Label id="lblAddress1" runat="server" Width="91px" Text="Email Address" CssClass="lblbox"></asp:Label></strong></TD><TD style="WIDTH: 200px; HEIGHT: 26px">
            <asp:TextBox id="txtAddress2" runat="server" Width="200px" CssClass="txtBox "></asp:TextBox></TD><TD style="HEIGHT: 25px"></TD><TD style="HEIGHT: 25px" align=left><asp:CheckBox id="CheckBox1" runat="server" Width="97px" Text="Is Registered" AutoPostBack="True" OnCheckedChanged="CheckBox1_CheckedChanged"></asp:CheckBox></TD><TD style="HEIGHT: 25px"><asp:TextBox id="txtgstno" runat="server" Width="200px" CssClass="txtBox " Enabled="False"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 143px; HEIGHT: 32px" align=left></TD><TD style="WIDTH: 200px; HEIGHT: 32px">
            <asp:Button id="btnSave" onclick="btnSave_Click" runat="server" Width="84px" Font-Size="8pt" Text="Save" ValidationGroup="vg" CssClass="btn" />
             <asp:Button id="Button1" onclick="Button1_Click" runat="server" Width="83px" Font-Size="8pt" Text="Cancel" CssClass="btn" />  </TD><TD style="WIDTH: 1px; HEIGHT: 32px"></TD><TD style="HEIGHT: 32px">
             <strong><asp:Label id="Label2" runat="server" Width="69px" Text="Fax No" Visible="False"></asp:Label></strong></TD><TD style="WIDTH: 237px; HEIGHT: 32px"><asp:TextBox id="txtpassword" runat="server" Width="200px" CssClass="txtBox " Visible="False"></asp:TextBox></TD></TR></TBODY></TABLE>
</contenttemplate>
                    </asp:UpdatePanel></td>
               
            </tr>
        </table>
        
        <asp:UpdatePanel id="UpdatePanel1" runat="server">
            <contenttemplate>
<TABLE style="BORDER-RIGHT: silver thin inset; BORDER-TOP: silver thin inset; BORDER-LEFT: silver thin inset; BORDER-BOTTOM: silver thin inset; BACKGROUND-COLOR: silver"><TBODY><TR><TD style="HEIGHT: 21px" align=left>
<strong><asp:Label id="Label10" runat="server" Width="153px" Text="Select Searching Type"></asp:Label></strong> </TD><TD style="WIDTH: 170px; HEIGHT: 21px" align=left><asp:DropDownList id="ddSearchType" runat="server" Width="200px" CssClass="DropList"><asp:ListItem Value="SKU_code">All Records</asp:ListItem>
<asp:ListItem Value="Distributor_Code">Distributor Code</asp:ListItem>
<asp:ListItem Value="Distributor_Name">Distributor Name</asp:ListItem>
<asp:ListItem Value="Contact_Person">Contact Person</asp:ListItem>
<asp:ListItem Value="CONTACT_NUMBER">Contact No</asp:ListItem>
    <asp:ListItem Value="TYPENAME">Distributor Type</asp:ListItem>
</asp:DropDownList> </TD><TD style="WIDTH: 224px; HEIGHT: 21px" align=left><asp:TextBox id="txtSeach" runat="server" Width="200px" CssClass="txtBox "></asp:TextBox> </TD><TD style="HEIGHT: 21px" align=left width=250>
<asp:Button id="Button2" onclick="Button2_Click" runat="server" Width="85px" Font-Size="8pt" Text="Filter" CssClass="btn" /> </TD></TR></TBODY></TABLE>
                <asp:Panel ID="Panel1" runat="server" Height="200px" ScrollBars="Vertical" Width="100%">
                    <asp:GridView id="GridDistributor" runat="server" Width="99%" ForeColor="SteelBlue" CssClass="gridRow2" AutoGenerateColumns="False" BackColor="White" BorderColor="White" OnPageIndexChanging="GridDistributor_PageIndexChanging" OnRowEditing="GridDistributor_RowEditing" HorizontalAlign="Center" OnRowDeleting="GridDistributor_RowDeleting">
<PagerSettings FirstPageText="" LastPageText="" Mode="NextPrevious" NextPageText="Next" PreviousPageText="Previous"></PagerSettings>

<RowStyle ForeColor="Black"></RowStyle>
<Columns>
<asp:BoundField DataField="DISTRIBUTOR_ID" HeaderText="DISTRIBUTOR_ID" Visible="False"></asp:BoundField>
<asp:BoundField DataField="IS_REGISTERED" HeaderText="IS_REGISTERED" Visible="False"></asp:BoundField>
<asp:BoundField DataField="SUBZONE_ID" HeaderText="SUBZONE_ID" Visible="False"></asp:BoundField>
<asp:BoundField DataField="ADDRESS2" HeaderText="ADDRESS2" Visible="False"></asp:BoundField>
<asp:BoundField DataField="DISTRIBUTOR_CODE" HeaderText="Code">
    <HeaderStyle HorizontalAlign="Left" />
    <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" />
</asp:BoundField>
<asp:BoundField DataField="DISTRIBUTOR_NAME" HeaderText="Name">
    <HeaderStyle HorizontalAlign="Left" />
    <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" />
</asp:BoundField>
<asp:BoundField DataField="TYPENAME" HeaderText="Type">
    <HeaderStyle HorizontalAlign="Left" />
    <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" />
</asp:BoundField>
<asp:BoundField DataField="ADDRESS1" HeaderText="Address">
    <HeaderStyle HorizontalAlign="Left" />
    <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" />
</asp:BoundField>
<asp:BoundField DataField="CONTACT_PERSON" HeaderText="Cantact Person">
    <HeaderStyle HorizontalAlign="Left" />
    <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" />
</asp:BoundField>
<asp:BoundField DataField="CONTACT_NUMBER" HeaderText="Contact Number">
    <HeaderStyle HorizontalAlign="Left" />
    <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" />
</asp:BoundField>
<asp:BoundField DataField="GST_NUMBER" HeaderText="Gst Number">
    <HeaderStyle HorizontalAlign="Left" />
    <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" />
</asp:BoundField>
<asp:BoundField DataField="COMPANY_ID" HeaderText="COMPANY_ID" Visible="False">
    <HeaderStyle HorizontalAlign="Left" />
</asp:BoundField>
<asp:CommandField ShowEditButton="True" HeaderText="Edit"></asp:CommandField>
<asp:TemplateField HeaderText="Delete"><ItemTemplate>
<asp:LinkButton id="btnDelete" runat="server" Text="Delete" CommandName="Delete" OnClientClick="javascript:return confirm('Are you sure you want to Delete?');return false;"></asp:LinkButton> 
</ItemTemplate>
</asp:TemplateField>
</Columns>

<FooterStyle BackColor="White"></FooterStyle>

<PagerStyle BackColor="Transparent"></PagerStyle>

<HeaderStyle CssClass="tblhead" ForeColor="White"></HeaderStyle>

<AlternatingRowStyle BackColor="#F2F2F2" CssClass="GridAlternateRowStyle" ForeColor="#333333"></AlternatingRowStyle>
</asp:GridView> 
                </asp:Panel>
</contenttemplate>
        </asp:UpdatePanel>
        
    </div>
    
   
</asp:Content>

