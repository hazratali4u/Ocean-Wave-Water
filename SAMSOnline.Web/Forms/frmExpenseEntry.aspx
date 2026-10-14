<%@ Page Language="C#" MasterPageFile="~/Forms/PageMaster.master" AutoEventWireup="true"
    CodeFile="frmExpenseEntry.aspx.cs" Inherits="Forms_frmExpenseEntry" Title="SAMS >> Petty Expense Entry" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cphPage">
    <script language="JavaScript" type="text/javascript">

        function pageLoad() {
            var ChkBox = document.getElementById("<%= cbSalePerson.ClientID%>");
            if (ChkBox.checked) {
                document.getElementById("<%= lblSalePerson.ClientID%>").className = "Displaycol";
                document.getElementById("<%= ddlSalePerson.ClientID%>").className = "Displaycol";
            }
            else {
                document.getElementById("<%= lblSalePerson.ClientID%>").className = "hiddencol";
                document.getElementById("<%= ddlSalePerson.ClientID%>").className = "hiddencol";
            }
        }

        function ValidateForm() {
            var str;
            str = document.getElementById("<%= txtAmount.ClientID %>").value;
            if (str == null || str.length == 0) {
                alert('Must enter Amount');
                return false;
            }

        }

        function ShowHideSalePerson() {
            var ChkBox = document.getElementById("<%= cbSalePerson.ClientID%>");
            if (ChkBox.checked) {
                document.getElementById("<%= lblSalePerson.ClientID%>").className = "Displaycol";
                document.getElementById("<%= ddlSalePerson.ClientID%>").className = "Displaycol";
            }
            else {
                document.getElementById("<%= lblSalePerson.ClientID%>").className = "hiddencol";
                document.getElementById("<%= ddlSalePerson.ClientID%>").className = "hiddencol";
            }
        }
 
    </script>
    <div id="right_data">
        <div style="z-index: 101; left: 377px; width: 100px; position: absolute; top: 137px;
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
        <table width="100%">
            <tr>
                <td>
                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                        <ContentTemplate>
                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" FilterType="Custom"
                                TargetControlID="txtAmount" ValidChars="0123456789.">
                            </cc1:FilteredTextBoxExtender>
                            <asp:Panel ID="Panel1" runat="server" DefaultButton="btnAddNew">
                                <table>
                                    <tr>
                                        <td style="width: 20%;" align="right">
                                        </td>
                                        <td align="left" style="width: 1%;">
                                        </td>
                                        <td style="width: 79%">
                                            <asp:CheckBox ID="cbSalePerson" runat="server" Text="Sale Person Wise" onclick="ShowHideSalePerson()" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 20%;" align="right">
                                            <strong>
                                                <asp:Label ID="Label2" runat="server" Text="Voucher No:" CssClass="lblbox"></asp:Label></strong>
                                        </td>
                                        <td align="left" style="width: 1%;">
                                            &nbsp;
                                        </td>
                                        <td style="width: 79%">
                                            <asp:DropDownList ID="DrpVoucherNo" runat="server" Width="250px" CssClass="DropList"
                                                AutoPostBack="True" OnSelectedIndexChanged="DrpVoucherNo_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" style="width: 20%;">
                                            <strong>
                                                <asp:Label ID="lblfromLocation" runat="server" Text="Location:"></asp:Label></strong>
                                        </td>
                                        <td align="left" style="width: 1%;">
                                            &nbsp;
                                        </td>
                                        <td style="width: 79%">
                                            <asp:DropDownList ID="drpDistributor" runat="server" Width="250px" CssClass="DropList">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 20%;" align="right">
                                            <strong>
                                                <asp:Label ID="Label8" runat="server" CssClass="lblbox" Text="Principal:"></asp:Label></strong>
                                        </td>
                                        <td align="left" style="width: 1%;">
                                            &nbsp;
                                        </td>
                                        <td style="width: 79%">
                                            <asp:DropDownList ID="DrpPrincipal" runat="server" Width="250px">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" style="width: 20%;">
                                            <strong>
                                                <asp:Label ID="Label3" runat="server" Text="Account Type:"></asp:Label></strong>
                                        </td>
                                        <td align="left" style="width: 1%;">
                                            &nbsp;
                                        </td>
                                        <td style="width: 79%">
                                            <asp:DropDownList ID="DrpMasterHead" runat="server" Width="250px" CssClass="DropList"
                                                AutoPostBack="True" OnSelectedIndexChanged="DrpMasterHead_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" style="width: 20%;">
                                            <strong>
                                                <asp:Label ID="Label1" runat="server" Text="Account Head:"></asp:Label></strong>
                                        </td>
                                        <td align="left" style="width: 1%;">
                                            &nbsp;
                                        </td>
                                        <td style="width: 79%">
                                            <asp:DropDownList ID="DrpAccountHead" runat="server" Width="250px">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" style="width: 20%;">
                                            <strong>
                                                <asp:Label ID="lblSalePerson" runat="server" Text="Sale Person:" CssClass="hiddencol"></asp:Label></strong>
                                        </td>
                                        <td align="left" style="width: 1%;">
                                            &nbsp;
                                        </td>
                                        <td align="left" style="width: 79%;">
                                            <asp:DropDownList ID="ddlSalePerson" runat="server" Width="250px" CssClass="hiddencol">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" style="width: 20%;">
                                            <strong>
                                                <asp:Label ID="Label9" runat="server" CssClass="lblbox" Text="Remarks:"></asp:Label></strong>
                                        </td>
                                        <td align="left" style="width: 1%;">
                                            &nbsp;
                                        </td>
                                        <td align="left" style="width: 79%;">
                                            <asp:TextBox ID="txtRemarks" runat="server" CssClass="txtBox " Width="243px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" style="height: 20px">
                                            <strong>
                                                <asp:Label ID="Label6" runat="server" Text="Amount:" CssClass="lblbox"></asp:Label></strong>
                                        </td>
                                        <td align="left" style="height: 20px">
                                            &nbsp;
                                        </td>
                                        <td align="left" style="height: 20px">
                                            <asp:TextBox ID="txtAmount" runat="server" Width="107px" CssClass="txtBox "></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 20%" align="left">
                                        </td>
                                        <td align="left" style="width: 1%">
                                            &nbsp;
                                        </td>
                                        <td align="left" colspan="1" style="width: 79%;">
                                            <asp:Button CssClass="btn" ID="btnAddNew" runat="server" AccessKey="S" Font-Size="8pt"
                                                OnClick="btnAddNew_Click" Text="Add" Width="95px" />
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                            <asp:Panel ID="Panel12" runat="server" Height="136px" ScrollBars="Vertical" Width="620px"
                                BorderColor="Gray" BorderStyle="Groove" BorderWidth="1px">
                                <asp:GridView ID="GrdOrder" runat="server" AutoGenerateColumns="False" BackColor="White"
                                    BorderColor="White" CaptionAlign="Left" CssClass="gridRow2" ForeColor="SteelBlue"
                                    HorizontalAlign="Center" OnRowDeleting="GrdOrder_RowDeleting" OnRowEditing="GrdOrder_RowEditing"
                                    Width="600px">
                                    <PagerSettings FirstPageText="" LastPageText="" Mode="NextPrevious" NextPageText="Next"
                                        PreviousPageText="Previous" />
                                    <RowStyle ForeColor="Black" />
                                    <Columns>
                                        <asp:BoundField DataField="Account_Head_Id" HeaderText="Account Head Id">
                                            <FooterStyle CssClass="hiddencol" />
                                            <HeaderStyle CssClass="hiddencol" />
                                            <ItemStyle CssClass="hiddencol" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Account_Name" HeaderText="Account Head">
                                            <FooterStyle CssClass="hiddencol" />
                                            <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Left" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Remarks" HeaderText="Remarks">
                                            <FooterStyle HorizontalAlign="Right" />
                                            <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Left" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="debit" DataFormatString="{0:F2}" FooterText="Total" HeaderText="Amount">
                                            <FooterStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Right" />
                                            <HeaderStyle HorizontalAlign="Right" />
                                            <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Right" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="SalePersonID" HeaderText="Sale Person ID">
                                            <FooterStyle CssClass="hiddencol" />
                                            <HeaderStyle CssClass="hiddencol" />
                                            <ItemStyle CssClass="hiddencol" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Account_Parent_Id" HeaderText="Account Parent Id">
                                            <FooterStyle CssClass="hiddencol" />
                                            <HeaderStyle CssClass="hiddencol" />
                                            <ItemStyle CssClass="hiddencol" />
                                        </asp:BoundField>
                                        <asp:CommandField HeaderText="Edit" ShowEditButton="True">
                                            <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" Width="47px" />
                                        </asp:CommandField>
                                        <asp:TemplateField HeaderText="Delete">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="btnDelete" runat="server" CommandName="Delete" OnClientClick="javascript:return confirm('Are you sure you want to Delete?');return false;"
                                                    Text="Delete"></asp:LinkButton>
                                            </ItemTemplate>
                                            <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" Width="46px" />
                                        </asp:TemplateField>
                                    </Columns>
                                    <FooterStyle BackColor="White" />
                                    <PagerStyle BackColor="Transparent" />
                                    <HeaderStyle CssClass="tblhead" />
                                    <AlternatingRowStyle BackColor="#F2F2F2" CssClass="GridAlternateRowStyle" ForeColor="#333333" />
                                </asp:GridView>
                            </asp:Panel>
                            <asp:Button CssClass="btn" ID="btnSave" runat="server" Font-Size="8pt" OnClick="btnSave_Click"
                                Text="Save" Width="117px" />
                            <strong>
                                <asp:Label ID="Label61" runat="server" CssClass="lblbox" Text="Amount" Width="63px"></asp:Label></strong>
                            <asp:TextBox ID="txtMainCash" runat="server" CssClass="txtBox " ReadOnly="True"></asp:TextBox>&nbsp;
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <strong>
                        <asp:Label ID="lblRowId" runat="server" Text="Label" Visible="False"></asp:Label></strong>
                    &nbsp;
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
