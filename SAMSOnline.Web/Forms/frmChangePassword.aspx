<%@ Page Language="C#" MasterPageFile="~/Forms/PageMaster.master" AutoEventWireup="true" CodeFile="frmChangePassword.aspx.cs" Inherits="Forms_fmChangePassword" Title="SAMS >> Change Password" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID = "content1" runat = "server" ContentPlaceHolderID ="cphPage">
  <script language="JavaScript" type="text/javascript">
  
   function ValidatePassword()
 {
		
		var strCurrentPassword;
		var strNewPassword    ;
		var strChangePassword ;
		
		strCurrentPassword  = document.getElementById('<%=txtCurrentPassword.ClientID%>').value; 
		if(strCurrentPassword == null || strCurrentPassword.length == 0)
		{
			alert('Must Enter Current Password ');
			return false;
		}
		strNewPassword  = document.getElementById('<%=txtNewPassword.ClientID%>').value; 
		if(strNewPassword == null || strNewPassword.length == 0)
		{
			alert('Must Enter New Password ');
			return false;
		}
		strChangePassword  = document.getElementById('<%=txtConfirmNewPassword.ClientID%>').value; 
		if(strChangePassword == null || strChangePassword.length == 0)
		{
			alert('Must Enter Confirm New Password ');
			return false;
		}
		if(strNewPassword == strChangePassword)
		{
		    return true;
		}
		else
		{  
		  alert('New Password does not match');
		  return false;
		}
		
        return true;
 }
   function ValidateCurrentPassword()
   {
      alert('Current Password is wrong ');
      return true;
   } 
   </script>
     <div id="right_data">
        <table width="100%">
            <tr>
                <td >
                    <asp:UpdatePanel id="UpdatePanel1" runat="server">
                        <contenttemplate>
<TABLE style="HEIGHT: 117px"><TBODY><TR><TD style="HEIGHT: 12px" align=left colSpan=4><asp:Label id="lblErrorMsg" runat="server" ForeColor="Red" Font-Bold="True" Width="312px"></asp:Label> </TD><TD style="WIDTH: 1px; HEIGHT: 12px" align=left colSpan=1></TD></TR><TR><TD style="WIDTH: 1px; HEIGHT: 1px" align=left></TD></TR><TR><TD style="WIDTH: 1px" align=left></TD><TD style="WIDTH: 29px" align=left>
<strong><asp:Label id="Label2" runat="server" Width="122px" Text="Current Password" CssClass="lblbox"></asp:Label></strong> </TD><TD style="WIDTH: 1px" align=left></TD><TD style="WIDTH: 203px; HEIGHT: 25px" align=left>
    <asp:TextBox id="txtCurrentPassword" runat="server" Width="153px" 
        CssClass="txtBox" MaxLength="20" TextMode="Password"></asp:TextBox></TD><TD style="WIDTH: 1px; HEIGHT: 25px" align=left></TD></TR><TR><TD style="WIDTH: 1px; HEIGHT: 25px" align=left></TD><TD style="WIDTH: 29px; HEIGHT: 25px" align=left>
<strong> <asp:Label id="lbltoLocation" runat="server" Width="121px" Text="New Password" CssClass="lblbox"></asp:Label></strong> </TD><TD style="WIDTH: 1px; HEIGHT: 25px" align=left></TD><TD style="WIDTH: 203px; HEIGHT: 25px" align=left>
    <asp:TextBox id="txtNewPassword" runat="server" Width="153px" CssClass="txtBox" 
        MaxLength="20" TextMode="Password"></asp:TextBox></TD><TD style="WIDTH: 1px; HEIGHT: 25px" align=left></TD></TR><TR><TD style="WIDTH: 1px; HEIGHT: 25px" align=left></TD><TD style="WIDTH: 29px; HEIGHT: 25px" align=left>
<strong> <asp:Label id="Label1" runat="server" Width="180px" Text="Confirm New Password" ></asp:Label></strong> </TD><TD style="WIDTH: 1px; HEIGHT: 25px" align=left></TD><TD style="WIDTH: 203px; HEIGHT: 25px" align=left>
    <asp:TextBox id="txtConfirmNewPassword" runat="server" Width="153px" 
        CssClass="txtBox" MaxLength="20" TextMode="Password"></asp:TextBox></TD><TD style="WIDTH: 1px; HEIGHT: 25px" align=left></TD></TR><TR><TD style="WIDTH: 1px; HEIGHT: 25px" align=left></TD></TR></TBODY></TABLE>&nbsp;&nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                            &nbsp; &nbsp; &nbsp; &nbsp;<asp:Button ID="btnSave" runat="server" Font-Size="8pt"
                Text="Save" Width="71px" OnClick="btnSave_Click1" CssClass="button" />
                            <asp:Button ID="btnCancel" runat="server" Font-Size="8pt" Text="Cancel"
                        Width="71px" OnClick="btnCancel_Click" CssClass="button" />
                            &nbsp;
</contenttemplate>
                    </asp:UpdatePanel>                 &nbsp;
                    <asp:TextBox ID="hiddenPassword" runat="server" Visible="False" Width="97px"></asp:TextBox>
                    &nbsp;
                    &nbsp; &nbsp; &nbsp;&nbsp;&nbsp;<br />
                    &nbsp;&nbsp; &nbsp;
                </td>
                
            </tr>
        </table>
    </div>
</asp:Content>




