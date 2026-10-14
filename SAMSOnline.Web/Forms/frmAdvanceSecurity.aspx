<%@ Page Language="C#" MasterPageFile="~/Forms/PageMaster.master" AutoEventWireup="true"
    CodeFile="frmAdvanceSecurity.aspx.cs" Inherits="Forms_frmAdvanceSecurity" Title="SAMS >> Advance Security" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cphPage">
    <div id="right_data">
        <table width="100%">
            <tr>
                <td>
                    <div style="z-index: 101; left: 484px; width: 100px; position: absolute; top: 254px;
                        height: 100px">
                        <asp:Panel ID="Panel2" runat="server">
                            <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
                                <ProgressTemplate>
                                    <asp:ImageButton ID="ImageButton1" runat="server" Height="26px" ImageUrl="~/App_Themes/Granite/Images/image003.gif"
                                        Width="27px" />
                                    Wait Update.......
                                </ProgressTemplate>
                            </asp:UpdateProgress>
                        </asp:Panel>
                    </div>

                </td>
                <td>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <table width="100%">
                                <tr>
                                    <td style="width: 100%; padding-left: 60px;" colspan="3">
                                        <fieldset style="width: 255px;">
                                            <asp:RadioButtonList ID="rblTransactionType" runat="server" RepeatDirection="Horizontal"
                                                AutoPostBack="True" OnSelectedIndexChanged="rblTransactionType_SelectedIndexChanged"
                                                Width="250px">
                                                <asp:ListItem Text="Received" Value="0" Selected="True"></asp:ListItem>
                                                <asp:ListItem Text="Return" Value="1"></asp:ListItem>
                                            </asp:RadioButtonList>
                                            <legend></legend>
                                        </fieldset>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="3">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 12%" align="right">
                                        <strong>
                                            <asp:Label ID="lbltoLocation" runat="server" Width="94px" Text="Location:"></asp:Label></strong>
                                    </td>
                                    <td style="width: 1%">
                                    </td>
                                    <td style="width: 87%">
                                        <asp:DropDownList ID="drpDistributor" runat="server" Width="200px" CssClass="DropList"
                                            AutoPostBack="True" OnSelectedIndexChanged="drpDistributor_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 12%" align="right">
                                        <strong>
                                            <asp:Label ID="Label2" runat="server" Width="94px" Text="Principal:"></asp:Label></strong>
                                    </td>
                                    <td style="width: 1%">
                                    </td>
                                    <td style="width: 87%">
                                        <asp:DropDownList ID="DrpPrincipal" runat="server" Width="200px" AutoPostBack="True"
                                            OnSelectedIndexChanged="DrpPrincipal_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 12%" align="right">
                                        <strong>
                                            <asp:Label ID="Label1" runat="server" Text="Customer Route:"></asp:Label></strong>
                                    </td>
                                    <td style="width: 1%">
                                    </td>
                                    <td style="width: 87%">
                                        <asp:DropDownList ID="DrpRoute" runat="server" Width="200px" CssClass="DropList"
                                            AutoPostBack="True" OnSelectedIndexChanged="DrpRoute_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 12%" align="right">
                                        <strong>
                                            <asp:Label ID="Label4" runat="server" Text="Customer:"></asp:Label></strong>
                                    </td>
                                    <td style="width: 1%">
                                    </td>
                                    <td style="width: 87%">
                                        <asp:DropDownList ID="ddlCustomer" runat="server" Width="200px" AutoPostBack="True"
                                            OnSelectedIndexChanged="ddlCustomer_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 12%" align="right">
                                        <strong>
                                            <asp:Label ID="Label3" runat="server" Text="Sale Force:"></asp:Label></strong>
                                    </td>
                                    <td style="width: 1%">
                                    </td>
                                    <td style="width: 87%">
                                        <asp:DropDownList ID="DrpDeliveryMan" runat="server" Width="200px" CssClass="DropList"
                                            AutoPostBack="True" OnSelectedIndexChanged="DrpDeliveryMan_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 12%" align="right">
                                        <strong>
                                            <asp:Label ID="Label8" runat="server" Text="SKU:"></asp:Label></strong>
                                    </td>
                                    <td style="width: 1%">
                                    </td>
                                    <td style="width: 87%">
                                        <asp:DropDownList ID="ddlSKU" runat="server" Width="200px" AutoPostBack="True" OnSelectedIndexChanged="ddlSKU_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 12%" align="right">
                                        <strong>
                                            <asp:Label ID="Label9" runat="server" Text="Customer Rate:"></asp:Label></strong>
                                    </td>
                                    <td style="width: 1%">
                                    </td>
                                    <td style="width: 87%">
                                        <asp:TextBox ID="txtRate" runat="server" Width="200px"></asp:TextBox>
                                        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" FilterType="Custom"
                                            ValidChars="0123456789." TargetControlID="txtRate">
                                        </cc1:FilteredTextBoxExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 12%" align="right">
                                        <strong>
                                            <asp:Label ID="Label5" runat="server" Text="Quantity:"></asp:Label></strong>
                                    </td>
                                    <td style="width: 1%">
                                    </td>
                                    <td style="width: 87%">
                                        <asp:TextBox ID="txtNoOfBottles" runat="server" Width="200px"></asp:TextBox>
                                        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" FilterType="Custom"
                                            ValidChars="0123456789" TargetControlID="txtNoOfBottles">
                                        </cc1:FilteredTextBoxExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 12%" align="right">
                                        <strong>
                                            <asp:Label ID="Label6" runat="server" Text="Security Amount:"></asp:Label></strong>
                                    </td>
                                    <td style="width: 1%">
                                    </td>
                                    <td style="width: 87%">
                                        <asp:TextBox ID="txtAmount" runat="server" Width="200px"></asp:TextBox>
                                        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" FilterType="Custom"
                                            ValidChars="0123456789." TargetControlID="txtAmount">
                                        </cc1:FilteredTextBoxExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 12%" align="right">
                                        <strong>
                                            <asp:Label ID="Label7" runat="server" Text="Remarks:"></asp:Label></strong>
                                    </td>
                                    <td style="width: 1%">
                                    </td>
                                    <td style="width: 87%">
                                        <asp:TextBox ID="txtRemarks" runat="server" Width="200px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 12%; height: 42px;" align="right">
                                    </td>
                                    <td style="width: 1%; height: 42px;">
                                    </td>
                                    <td style="width: 87%; height: 42px;">
                                        <br />
                                        <asp:Button ID="btnSave" runat="server" CssClass="button" Text="Save" OnClick="btnSave_Click"
                                            Width="85px" />&nbsp;&nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 100%" colspan="3">
                                        <asp:HiddenField ID="hfCUSTOMER_SECURITY_ID" runat="server" />
                                        <br />
                                        <asp:Panel ID="Panel1" runat="server" Width="700px" Height="200px" ScrollBars="Vertical"
                                            BorderColor="Silver" BorderStyle="Groove" BorderWidth="1px">
                                            <asp:GridView Width="99%" ID="gvSecurity" runat="server" ForeColor="SteelBlue" BackColor="White"
                                                HorizontalAlign="Center" AutoGenerateColumns="False" BorderColor="White" OnRowDeleting="gvSecurity_RowDeleting"
                                                OnRowEditing="gvSecurity_RowEditing">
                                                <RowStyle ForeColor="Black"></RowStyle>
                                                <Columns>
                                                    <asp:BoundField DataField="CUSTOMER_SECURITY_ID" HeaderText="CUSTOMER_SECURITY_ID">
                                                        <HeaderStyle CssClass="hiddencol"></HeaderStyle>
                                                        <ItemStyle CssClass="hiddencol"></ItemStyle>
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="CUSTOMER_NAME" HeaderText="Customer">
                                                        <ItemStyle HorizontalAlign="Left" BorderColor="Silver" BorderWidth="2px" BorderStyle="Solid"
                                                            Width="150px"></ItemStyle>
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="USER_NAME" HeaderText="Sale Force">
                                                        <ItemStyle HorizontalAlign="Left" BorderColor="Silver" BorderWidth="2px" BorderStyle="Solid"
                                                            Width="100px"></ItemStyle>
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="SKU_NAME" HeaderText="SKU">
                                                        <ItemStyle BorderColor="Silver" BorderWidth="2px" BorderStyle="Solid" Width="120px">
                                                        </ItemStyle>
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="NoOfBottles" HeaderText="Quantity">
                                                        <ItemStyle HorizontalAlign="Right" BorderColor="Silver" BorderWidth="2px" BorderStyle="Solid"
                                                            Width="70px"></ItemStyle>
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="SECURITY_AMOUNT" HeaderText="Security Amount" DataFormatString="{0:F2}">
                                                        <ItemStyle HorizontalAlign="Right" BorderColor="Silver" BorderWidth="2px" BorderStyle="Solid"
                                                            Width="70px"></ItemStyle>
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="RATE" HeaderText="Rate" DataFormatString="{0:F2}">
                                                        <ItemStyle HorizontalAlign="Right" BorderColor="Silver" BorderWidth="2px" BorderStyle="Solid"
                                                            Width="50px"></ItemStyle>
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="REMARKS" HeaderText="Remarks">
                                                        <ItemStyle BorderColor="Silver" BorderWidth="2px" BorderStyle="Solid" Width="120px">
                                                        </ItemStyle>
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="SKU_ID" HeaderText="SKU_ID">
                                                        <HeaderStyle CssClass="hiddencol"></HeaderStyle>
                                                        <ItemStyle CssClass="hiddencol"></ItemStyle>
                                                    </asp:BoundField>
                                                    <asp:CommandField ShowEditButton="True" HeaderText="Edit">
                                                        <ItemStyle BorderColor="Silver" BorderWidth="1px" Width="40px"></ItemStyle>
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                    </asp:CommandField>
                                                    <asp:TemplateField HeaderText="Delete">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="btnDelete" runat="server" Text="Delete" OnClientClick="javascript:return confirm('Are you sure you want to Delete?');return false;"
                                                                CommandName="Delete"></asp:LinkButton>
                                                        </ItemTemplate>
                                                        <ItemStyle BorderColor="Silver" BorderWidth="2px" BorderStyle="Solid" Width="45px">
                                                        </ItemStyle>
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                    </asp:TemplateField>
                                                </Columns>
                                                <FooterStyle BackColor="White"></FooterStyle>
                                                <PagerStyle BackColor="Transparent"></PagerStyle>
                                                <HeaderStyle CssClass="tblhead" ForeColor="White"></HeaderStyle>
                                                <AlternatingRowStyle BackColor="#F2F2F2" CssClass="GridAlternateRowStyle" ForeColor="#333333">
                                                </AlternatingRowStyle>
                                            </asp:GridView>
                                        </asp:Panel>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="3">
                                         <div style="z-index: 201; overflow:hidden; left: 404px; width: 338px; position: absolute; top: 166px;
                        height: 201px" >
                        
                           <asp:Panel ID="Panel3" runat="server" BorderColor="Silver" BorderStyle="Groove" 
                                            BorderWidth="0px"    Width="327px" Height="196px">

                                            <asp:GridView ID="gvInfo" runat="server" ForeColor="SteelBlue" BackColor="White"
                                                HorizontalAlign="Center" AutoGenerateColumns="False" BorderColor="White"                                            
                                                Visible="False" AllowSorting="false" Width="312px" style="overflow:hidden;" VerticalScrollBarVisibility="Hidden" HorizontalScrollBarVisibility="Hidden">
                                               <RowStyle ForeColor="Black"></RowStyle>
                                                <Columns>
                                                    <asp:BoundField DataField="SKU_NAME" HeaderText="SKU Name" >
                                                    <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="2px" 
                                                        Width="120px" />
                                                        <HeaderStyle HorizontalAlign="Left" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="NoOfBottles" HeaderText="Quantity" DataFormatString="{0:F2}">
                                                    <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="2px" 
                                                        HorizontalAlign="Right" Width="70px" />
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="SECURITY_AMOUNT" HeaderText="Amount" DataFormatString="{0:F2}" >
                                                    <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="2px" 
                                                        HorizontalAlign="Right" Width="70px" />
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="SECURITY" 
                                                        HeaderText="NET Security Amount">
                                                    <HeaderStyle CssClass="hiddencol"></HeaderStyle>
                                                        <ItemStyle CssClass="hiddencol"></ItemStyle>
                                                    
                                                    </asp:BoundField>
                                                </Columns>
                                            </asp:GridView>
                                        </asp:Panel>
                                        
                    </div>

                                    </td>
                                </tr>
                            </table>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
                <td>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
