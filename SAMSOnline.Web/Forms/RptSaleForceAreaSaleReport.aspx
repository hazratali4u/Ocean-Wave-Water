<%@ Page Language="C#" MasterPageFile="~/Forms/PageMaster.master" AutoEventWireup="true"
    CodeFile="RptSaleForceAreaSaleReport.aspx.cs" Inherits="Forms_RptSaleForceAreaSaleReport"
    Title="SAMS >> Sale Force Assignment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphPage" runat="Server">
   
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
                                        <td> <strong>
                                                <asp:Label ID="Label2" runat="server" Width="83px" Text="Sale Force" CssClass="lblbox"></asp:Label></strong></td>
                                                <td>  
                                                  <asp:DropDownList ID="DrpSaleForce" runat="server" Width="200px" CssClass="DropList"
                                                AutoPostBack="True" OnSelectedIndexChanged="DrpSaleForce_SelectedIndexChanged">
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
                                         <td><strong>
                                                <asp:Label ID="Label5" runat="server" Width="81px" Text="Working Date" CssClass="lblbox"></asp:Label></strong>
                                                </td>
                                            <td> 
                                              <%@ register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
                                            
                                             <asp:TextBox ID="txtToDate" runat="server" CssClass="txtBox" MaxLength="10" Width="180px"></asp:TextBox><asp:ImageButton
                                            ID="ImgBntToDate" runat="server" ImageUrl="~/App_Themes/Granite/Images/date.gif" />
                                        <cc1:CalendarExtender ID="CalendarExtender2" runat="server" EnableViewState="False"
                                            Format="dd-MMM-yyyy" PopupButtonID="ImgBntToDate" TargetControlID="txtToDate">
                                        </cc1:CalendarExtender></td>
                                    </tr>
                                    <tr>



                                    <td><strong>
                                                <asp:Label ID="Label4" runat="server" Width="81px" Text="Sku" CssClass="lblbox"></asp:Label></strong></td>
                                    <td>                                           
                                     <asp:DropDownList ID="DrpSku" runat="server" Width="200px" CssClass="DropList"
                                                AutoPostBack="True" >
                                            </asp:DropDownList>
                                            <td></td>
                                           
                                        <td style="height: 10px">
                                                    <strong>
                                                <asp:Label ID="Label3" runat="server" Width="67px" Text="Day" CssClass="lblbox" Visible ="false" ></asp:Label></strong>
                                        </td>
                                        <td>  <asp:DropDownList ID="drpDayofWeak" runat="server" Width="200px" CssClass="DropList"
                                                AutoPostBack="True" Visible="false" 
                                                onselectedindexchanged="drpDayofWeak_SelectedIndexChanged" >
                                              
                                            </asp:DropDownList></td>
                                    
                                    </tr>
                                   
                                    
                               
                              
                            </table>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <table >
                    <tr >
                    <td style ="width :80px">
                    
                    
                    </td>
                    <td> <asp:Button ID="btnSave" runat="server" Font-Size="8pt" OnClick="btnSave_Click" Text="Save"
                                                ValidationGroup="vg" Width="82px" CssClass="btn" Visible ="true"  /></td>
                    
                    </tr>
                    
                    
                    </table>
                    </td>
               
            </tr>
        </table>
    </div>
</asp:Content>
