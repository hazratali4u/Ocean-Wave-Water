<%@ Page Language="C#" MasterPageFile="~/Forms/AppMaster.master" AutoEventWireup="true" CodeFile="SamsLogin.aspx.cs" Inherits="Forms_SamsLogin" Title="Sams Main " %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="mainCopy" Runat="Server">
<script language="JavaScript" type="text/javascript" >
           javascript:window.history.forward(1);        
           
</script>
   <div class="container" style="background-color: white">
        <h2>
            &nbsp; 
            <asp:Label ID="Label1" runat="server"></asp:Label></h2>
    </div>
    <script language="JavaScript" type="text/javascript">
        function ConfirmCancel()
		{
		    if( confirm("Are you sure? You want to Day Close?")==true)
		    return true;
		
		    else
		    {return false;}
		}
	</script>
    <%--<asp:UpdatePanel id="UpdatePanel2" runat="server">
                        <contenttemplate>--%>
    <div class="container">
           <table width="100%">
            <tr>
                <td style="width: 100px">
                </td>
                <td style="width: 100px">
                </td>
                <td style="width: 100px">
                </td>
            </tr>
            <tr>
                <td style="width: 100px">
                </td>
                <td style="width: 100px">
                    <asp:Panel ID="Panel1" runat="server" Height="100%" Width="100%">
                    <table>
                            <tr>
                                <td style="width: 100px">
                     
                        &nbsp;
                                    <asp:Panel ID="Panel2" runat="server" BackImageUrl="~/App_Themes/Granite/Images/login01.gif"
                                        Height="60px" Width="150px">
                                    </asp:Panel>
                                    
                    
<TABLE cellSpacing=0 cellPadding=0 width="90%" align=center border=0><TBODY><TR><TD style="HEIGHT: 13px" vAlign=bottom colSpan=3 align="center">
    <asp:Label ID="lblErrorMsg" runat="server" Text="Label" Visible="False" Width="220px" ForeColor="Red"></asp:Label></TD></TR><TR><TD align=left style="width: 74px; height: 10px; font-size: 8pt;">
        Login ID:<br />
        <br />
        Password:</TD><TD class="txtsmalllogin" vAlign=middle align=right colSpan=2 style="width: 166px; height: 10px;">
    <asp:TextBox ID="txtLogin" runat="server" Width="145px"></asp:TextBox><br />
            <br />
            <asp:TextBox id="txtPassword" runat="Server" Width="145px" CssClass="txtlogin" TextMode="password"></asp:TextBox></TD></TR><TR><TD style="HEIGHT: 30px; width: 74px; font-size: 8pt;" align=right>
        &nbsp;&nbsp;&nbsp;</TD><TD style="HEIGHT: 30px; width: 166px;" class="txtsmalllogin" vAlign=middle align=center colSpan=2><asp:ImageButton id="btnSignin02" runat="Server" CssClass="btnlogin" ImageUrl="~/App_Themes/Granite/Images/btn_loginT.jpg" OnClick="btnSignin02_Click" ></asp:ImageButton></TD></TR><TR><TD align=right style="width: 74px; height: 4px;">&nbsp;</TD><TD vAlign=middle colSpan=2 style="width: 166px; height: 4px">
    &nbsp;</TD></TR></TBODY></TABLE>
 

                                </td>
                            </tr>
                            <tr>
                                <td style="width: 100px">
                                    </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </td>
                <td style="width: 100px">
                </td>
            </tr>
            <tr>
                <td colspan="3" align="center">
                    &nbsp;</td>
            </tr>
        </table>
    </div>
<%--</contenttemplate>
                </asp:UpdatePanel>--%>

</asp:Content>



