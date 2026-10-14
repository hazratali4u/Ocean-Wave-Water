<%@ Page Language="C#" MasterPageFile="~/Forms/PageMaster.master" AutoEventWireup="true"
    CodeFile="frmSaleForceAreaAssignment2.aspx.cs" Inherits="Forms_frmSaleForceAreaAssignment2"
    Title="SAMS >> Sale Force Assignment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphPage" runat="Server">
    <script language="JavaScript" type="text/javascript">
        function radioMe(e) {
            if (!e) e = window.event;
            var sender = e.target || e.srcElement;

            if (sender.nodeName != 'INPUT') return;
            var checker = sender;
            var chkBox = document.getElementById('<%= ChbAreaList2.ClientID %>');
            var chks = chkBox.getElementsByTagName('INPUT');
            for (i = 0; i < chks.length; i++) {
                if (chks[i] != checker)
                    chks[i].checked = false;
            }
        }
    </script>
    <div id="right_data">
        <table width="100%">
            <tr>
                <td>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <table>
                                <tbody>
                                    <tr>
                                        <td colspan="2">
                                            <strong>
                                           
                                                <asp:Label ID="lblmsg" runat="server" Visible="False" Width="175px" ForeColor="Red"></asp:Label></strong>&nbsp;
                                         
                                        </td>
                                        <td style="height: 17px; width: 17px;">
                                        </td>
                                        <td></td>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td align="left" style="height: 25px">
                                            <strong>
                                                <asp:Label ID="Label1" runat="server" Width="67px" Text="Locaton" CssClass="lblbox"></asp:Label></strong>
                                        </td>
                                        <td style="height: 10px">
                                            <asp:DropDownList ID="drpDistributor" runat="server" Width="200px" CssClass="DropList"
                                                AutoPostBack="True" OnSelectedIndexChanged="drpDistributor_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </td>
                                        <td style="width: 17px" ></td>
                                        <td style="height: 10px">
                                                    <strong>
                                                <asp:Label ID="Label3" runat="server" Width="67px" Text="Day" CssClass="lblbox"></asp:Label></strong>
                                        </td>
                                        <td>  <asp:DropDownList ID="drpDayofWeak" runat="server" Width="200px" CssClass="DropList"
                                                AutoPostBack="True" 
                                                onselectedindexchanged="drpDayofWeak_SelectedIndexChanged" >
                                              
                                            </asp:DropDownList>
                                            </td>
                                    </tr>

                                         


                                    <tr>
                                        <td align="left" style="height: 25px">
                                            <strong>
                                                <asp:Label ID="Label11" runat="server" Width="81px" Text="Designation" CssClass="lblbox"></asp:Label></strong>
                                        </td>
                                        <td style="height: 9px">
                                            <asp:DropDownList ID="DrpDesignation" runat="server" Width="200px" CssClass="DropList"
                                                AutoPostBack="True" OnSelectedIndexChanged="DrpDesignation_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </td>
                                         <td style="width: 25px" ></td>
                                        <td> <strong>
                                                <asp:Label ID="Label2" runat="server" Width="83px" Text="Sale Force" CssClass="lblbox"></asp:Label></strong></td>
                                                <td>  
                                                  <asp:DropDownList ID="DrpSaleForce" runat="server" Width="200px" CssClass="DropList"
                                                AutoPostBack="True" OnSelectedIndexChanged="DrpSaleForce_SelectedIndexChanged">
                                            </asp:DropDownList>
                                                
                                                </td>
                                    </tr>
                                   
                                    <tr>
                                        <td >
                                        </td>
                                        <td align="left">
                                            <asp:Button ID="btnSave" runat="server" Font-Size="8pt" OnClick="btnSave_Click" Text="Save"
                                                ValidationGroup="vg" Width="82px" CssClass="btn" Visible ="false"  />
                                        </td>
                                        <td>
                                        </td>
                                        <td></td>
                                        <td></td>
                                    </tr>
                                   
                                </tbody>
                            </table>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>
                            <table>
                                <tr>
                                    <td>
                                   
                                    </td>
                                    <td >
                                    </td>
                                    <td style="width: 102px"  align="left">
                                     
                                    </td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    
                                </tr>
                               
                                <tr>
                                    <td   >
                                           <strong>
                                       <asp:Label ID="Label4" runat="server" Width="9px" Text="Unassigned Route" 
                                               CssClass="lblbox" Visible ="False"></asp:Label></strong> 
                                    </td>
                                    <td >
                                    </td>
                                    <td > <strong>
                                       <asp:Label ID="Label5" runat="server" Width="114px" Text="Assigned Route" CssClass="lblbox"></asp:Label></strong>  <asp:CheckBox ID="ChbSelectAll" runat="server" CssClass="DropList" Font-Size="8pt"
                                            onclick="ChRouteListSelect()" Text="Select All" Width="200px" Visible ="false"  /></td>
                                     <td style ="width :10px" ></td>
                                     
                                   <td>
                                   <strong>
                                       <asp:Label ID="Label6" runat="server" Text="Unassigned Customer"></asp:Label>
                                       </strong></td>
                                    <td></td>
                                    <td><strong>
                                       <asp:Label ID="Label7" runat="server" Text="Assigned Customer"></asp:Label>
                                       </strong><asp:CheckBox ID="ChCustomer" runat="server" CssClass="DropList" Font-Size="8pt"
                                            onclick="ChCustomerListSelect()" Text="Select All" Width="200px" Visible ="false" /></td>
                                </tr>
                                <tr>
                                    <td  rowspan ="4"  >
                                        <asp:Panel ID="Panel1" runat="server" BorderColor="Silver" BorderStyle="Groove" BorderWidth="1px"
                                            Height="300px"  BackColor="White" Visible ="False">
                                          
                                        </asp:Panel>
                                    </td>
                                     <td  >
                                       <asp:Button ID="Button3"  runat="server"  Font-Size="8pt"
                                       Text=">" CssClass="btn" onclick="Button3_Click" Visible ="False" />
                                      </td>
                                    <td  align="left" rowspan="4">
                                        <asp:Panel ID="Panel3" runat="server" BorderColor="Silver" BorderStyle="Groove" BorderWidth="1px"
                                            Height="300px" ScrollBars="Vertical" Width="180px" BackColor="White">
                                            <asp:CheckBoxList ID="ChbAreaList2" runat="server" AutoPostBack="true" Visible ="True">
                                            </asp:CheckBoxList>
                                           <asp:CheckBoxList ID="ChbAreaList" runat="server" AutoPostBack="true" Visible ="False">
                                            </asp:CheckBoxList>
                                            
                                        </asp:Panel>
                                    </td>
                                    <td ></td>
                                     <td  align="left" rowspan ="4">
                                        <asp:Panel ID="Panel2" runat="server" BorderColor="Silver" BorderStyle="Groove" BorderWidth="1px"
                                            Height="300px"  Width="180px" BackColor="White">
                                            <asp:ListBox ID="ChbCustomer" runat="server" Width="180px" Height="300px" >
                                            </asp:ListBox>
                                           
                                        </asp:Panel>
                                    </td>

                                     <td  style="width: 102px" align="center">
                                       <asp:Button ID="Button9"  runat="server" Width="30px" Font-Size="8pt"
                                       Text=">" CssClass="btn" onclick="Button9_Click"  />
                                      </td>
                                       <td  align="left" rowspan ="4">
                                        <asp:Panel ID="Panel4" runat="server" BorderColor="Silver" BorderStyle="Groove" BorderWidth="1px"
                                            Height="300px"  Width="180px" BackColor="White">
                                            <asp:ListBox ID="ChbCustomer2" runat="server" Width="180px" Height="300px" >
                                            </asp:ListBox>
                                           
                                        </asp:Panel>
                                    </td>
                                    </tr>
                                    <tr>

                                    <td >
                                                            <asp:Button ID="Button1"  runat="server"  Font-Size="8pt"
                                                                Text=">>" CssClass="btn" onclick="Button1_Click"  Visible ="False"/>
                                                        </td> 
                                                        <td></td><td  style="width: 102px" align="center">
                                                            <asp:Button ID="Button10"  runat="server" Width="30px" Font-Size="8pt"
                                                                Text=">>" CssClass="btn" onclick="Button10_Click" />
                                                        </td>
                                                        </tr>
                                                         <tr>
                                                        <td  >
                                                            <asp:Button ID="Button2"  runat="server"  Font-Size="8pt"
                                                                Text="<<" CssClass="btn" onclick="Button2_Click" Visible ="False"/>
                                                        </td>
                                                        <td></td>
                                                         <td  style="width: 102px" align="center">
                                                            <asp:Button ID="Button11"  runat="server" Width="30px" Font-Size="8pt"
                                                                Text="<<" CssClass="btn" onclick="Button11_Click" />
                                                        </td>
                                                    </tr> <tr>
                                                        <td  >
                                                            <asp:Button ID="Button4"  runat="server"  Font-Size="8pt"
                                                                Text="<" CssClass="btn" onclick="Button4_Click" Visible ="False" />
                                                        </td>
                                                        <td></td>
                                                        <td  style="width: 102px" align="center">
                                                            <asp:Button ID="Button12"  runat="server" Width="30px" Font-Size="8pt"
                                                                Text="<" CssClass="btn" onclick="Button12_Click" />
                                                        </td>
                                                    </tr>
                                   
                                    
                                   <tr>
                                   <td style="width: 6px"></td>
                                     
                                    <td>
                                        
                                    </td>
                                    
                                    
                                </tr>
                                
                               
                               
                              
                            </table>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
