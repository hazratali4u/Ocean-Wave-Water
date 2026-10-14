<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/PageMaster.master" AutoEventWireup="true"
    CodeFile="frmEmployeeSalary.aspx.cs" Inherits="Forms_frmEmployeeSalary" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPage" runat="Server">
    <script language="javascript" type="text/javascript">


        function ValidateForm() {
            var str;

            str = document.getElementById('<%=txtBasicSalary.ClientID%>').value;
            if (str == null || str.length == 0) {
                alert('Must Enter Basic Salary Amount!');
                return false;
            }
            str = document.getElementById('<%=txtSalaryDays.ClientID%>').value;
            if (str == null || str.length == 0) {
                alert('Must Enter Salary Days!');
                return false;
            }

            return true;
        }
    </script>
    <div id="right_data">
        <asp:UpdatePanel ID="pnl_head" runat="server">
            <ContentTemplate>
                <table>
                    <tr>
                        <td style="width: 110px; height: 15px" align="left">
                            <strong>
                                <label id="lbldesignationID">
                                </label>
                                Location</strong>
                        </td>
                        <td style="width: 175px; height: 15px">
                            <asp:DropDownList ID="DrpDistributor" runat="server" Width="250px" CssClass="DropList"
                                AutoPostBack="True" OnSelectedIndexChanged="DrpDistributor_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 110px; height: 15px">
                            <strong>
                                <label id="Label4">
                                    Designation</label></strong>
                        </td>
                        <td style="width: 175px; height: 15px">
                            <asp:DropDownList ID="DrpDesignation" runat="server" Width="250px" CssClass="DropList"
                                AutoPostBack="True" OnSelectedIndexChanged="DrpDesignation_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 110px; height: 15px">
                            <strong>
                                <label id="Label1">
                                    Employee</label></strong>
                        </td>
                        <td style="width: 175px; height: 15px">
                            <asp:DropDownList ID="DrpEmployee" runat="server" Width="250px" CssClass="DropList"
                                AutoPostBack="True" OnSelectedIndexChanged="DrpEmployee_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:HiddenField ID="hdnSalaryID" runat="server" Visible="false" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 110px; height: 15px">
                            <strong>
                                <label id="Label3">
                                    Basic Salary</label></strong>
                        </td>
                        <td style="width: 175px; height: 15px">
<%@ register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
                            <strong>
                                <asp:TextBox ID="txtBasicSalary" Width="100px" runat="server" CssClass="txtBox"></asp:TextBox>
                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" ValidChars=".0123456789"
                                    TargetControlID="txtBasicSalary" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 90px; height: 15px">
                            <strong>
                                <label id="Label5">
                                    Salary Days</label></strong>
                        </td>
                        <td style="width: 175px; height: 15px" colspan="2">
                            <asp:TextBox ID="txtSalaryDays" Width="60px" runat="server" CssClass="txtBox"></asp:TextBox>
                            <cc1:FilteredTextBoxExtender runat="server" FilterType="Numbers" TargetControlID="txtSalaryDays" />
                            <asp:RangeValidator ID="RangeValidator1" runat="server" MinimumValue="1" MaximumValue="31" Display="Dynamic" Type="Integer" 
                                ControlToValidate="txtSalaryDays" ValidationGroup="chkRange" ErrorMessage="The value must be from 1 to 31!"></asp:RangeValidator>
                        </td>
                        <td>
                        </td>
                    </tr>
                </table>
                <br />
                <table>
                    <tr>
                        <td>
                            <asp:Panel ID="pnl_Allowances" runat="server" Height="200px">
                                <fieldset>
                                    <legend align="left">Allowances</legend>
                                    <table>
                                        <tr>
                                            <td>
                                                <label>Allowance Type</label>
                                            </td>
                                            <td>
                                                 <asp:DropDownList ID="DrpAllowanceType" Width="200px" AutoPostBack="true"
                                                 OnSelectedIndexChanged="DrpAllowanceType_SelectedIndexChanged" runat="server"></asp:DropDownList>
                                            </td>
                                        </tr>
                                    </table>
                                    <table>
                                        <tr class="tblhead">
                                            <td>
                                                <label id="lblAllowanceDesc" style="color: white">
                                                    Description</label>
                                            </td>
                                            <td>
                                                <label id="lblAllowanceAmount" style="color: white">
                                                    Amount</label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:DropDownList ID="DrpAllowance" runat="server" Width="200px" CssClass="DropList"
                                                    AutoPostBack="True" OnSelectedIndexChanged="DrpAllowance_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtAllowanceAmount" runat="server" Text="" Width="100px" CssClass="txtBox"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:Button ID="btnAdd_Allowance" runat="server" Text="Add" CssClass="btn" Width="80px"
                                                    OnClick="btnAdd_Allowance_Click"></asp:Button>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="3">
                                                <asp:GridView ID="Grid_Allowances" runat="server" Width="99%" ForeColor="SteelBlue"
                                                    CssClass="gridRow2" BorderColor="White" HorizontalAlign="Center" AutoGenerateColumns="False"
                                                    BackColor="White" OnRowEditing="Grid_Allowances_RowEditing" OnRowDeleting="Grid_Allowances_RowDeleting"
                                                    PageSize="15">
                                                    <PagerSettings FirstPageText="" LastPageText="" Mode="NextPrevious" NextPageText="Next"
                                                        PreviousPageText="Previous"></PagerSettings>
                                                    <Columns>
                                                        <asp:BoundField DataField="ALLOWANCE_ID" HeaderText="ALLOWANCE ID">
                                                            <HeaderStyle CssClass="hiddencol"></HeaderStyle>
                                                            <ItemStyle CssClass="hiddencol"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="ALLOWANCE_DESC" HeaderText="ALLOWANCE DESC">
                                                            <HeaderStyle CssClass="hiddencol"></HeaderStyle>
                                                            <ItemStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid" Width="120px">
                                                            </ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="ALLOWANCE_AMOUNT" HeaderText="ALLOWANCE AMOUNT">
                                                            <HeaderStyle CssClass="hiddencol"></HeaderStyle>
                                                            <ItemStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid" Width="60px">
                                                            </ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="ALLOWANCE_TYPE_ID" HeaderText="ALLOWANCE TYPE ID">
                                                            <HeaderStyle CssClass="hiddencol"></HeaderStyle>
                                                            <ItemStyle CssClass="hiddencol"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:CommandField ShowEditButton="True" HeaderText="Edit">
                                                            <HeaderStyle CssClass="hiddencol"></HeaderStyle>
                                                            <ItemStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid" Width="20px">
                                                            </ItemStyle>
                                                        </asp:CommandField>
                                                        <asp:TemplateField HeaderText="Delete">
                                                            <HeaderStyle CssClass="hiddencol"></HeaderStyle>
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="btnDelete" runat="server" Text="Delete" OnClientClick="javascript:return confirm('Are you sure you want to Delete?');return false;"
                                                                    CommandName="Delete"></asp:LinkButton>
                                                            </ItemTemplate>
                                                            <ItemStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid" Width="20px">
                                                            </ItemStyle>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                    </table>
                                </fieldset>
                            </asp:Panel>
                        </td>
                        <td>
                            <asp:Panel ID="pnl_Deductions" runat="server" Height="200px">
                                <fieldset>
                                    <legend align="left">Deductions</legend>
                                    <table>
                                        <tr>
                                            <td>
                                                <label>Deduction Type</label>
                                            </td>
                                            <td>
                                                 <asp:DropDownList ID="DrpDeductionType" Width="200px" AutoPostBack="true"
                                                 OnSelectedIndexChanged="DrpDeductionType_SelectedIndexChanged" runat="server"></asp:DropDownList>
                                            </td>
                                        </tr>
                                    </table>
                                    <table>
                                        <tr class="tblhead">
                                            <td>
                                                <label id="lblDeductionDesc" style="color: white">
                                                    Description</label>
                                            </td>
                                            <td>
                                                <label id="lblDate" style="color: white">
                                                    Date</label>
                                            </td>
                                            <td>
                                                <label id="lblDeductionAmount" style="color: white">
                                                    Amount</label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:DropDownList ID="DrpDeduction" runat="server" Width="200px" CssClass="DropList"
                                                    AutoPostBack="True" OnSelectedIndexChanged="DrpDeduction_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                            
                                                <asp:TextBox ID="txtDeuductionDate" runat="server" Enabled="False" Width="100px"
                                                    CssClass="txtBox" MaxLength="10"></asp:TextBox>
                                                <asp:ImageButton ID="ibtnDeductionDate" runat="server" Width="16px" ImageUrl="~/App_Themes/Granite/Images/date.gif">
                                                </asp:ImageButton>
                                                <cc1:CalendarExtender ID="CEStartDate" runat="server" TargetControlID="txtDeuductionDate"
                                                    PopupButtonID="ibtnDeductionDate" Format="dd-MMM-yyyy">
                                                </cc1:CalendarExtender>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtDeductionAmount" runat="server" Text="" Width="100px" CssClass="txtBox"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:Button ID="btnAdd_Deduction" runat="server" Text="Add" CssClass="btn" Width="80px"
                                                    OnClick="btnAdd_Deduction_Click"></asp:Button>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4">
                                                <asp:GridView ID="Grid_Deductions" runat="server" Width="99%" ForeColor="SteelBlue"
                                                    CssClass="gridRow2" BorderColor="White" HorizontalAlign="Center" AutoGenerateColumns="False"
                                                    BackColor="White" OnRowEditing="Grid_Deductions_RowEditing" OnRowDeleting="Grid_Deductions_RowDeleting"
                                                    AllowPaging="false">
                                                    <PagerSettings FirstPageText="" LastPageText="" Mode="NextPrevious" NextPageText="Next"
                                                        PreviousPageText="Previous"></PagerSettings>
                                                    <Columns>
                                                        <asp:BoundField DataField="DEDUCTION_ID" HeaderText="DEDUCTION ID">
                                                            <HeaderStyle CssClass="hiddencol"></HeaderStyle>
                                                            <ItemStyle CssClass="hiddencol"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="DEDUCTION_DESC" HeaderText="DEDUCTION DESC">
                                                            <HeaderStyle CssClass="hiddencol"></HeaderStyle>
                                                            <ItemStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid" Width="120px">
                                                            </ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="DEDUCTION_DATE" HeaderText="DEDUCTION DATE" DataFormatString="{0:dd-MMM-yyyy}">
                                                            <HeaderStyle CssClass="hiddencol"></HeaderStyle>
                                                            <ItemStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid" Width="70px">
                                                            </ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="DEDUCTION_AMOUNT" HeaderText="DEDUCTION AMOUNT">
                                                            <HeaderStyle CssClass="hiddencol"></HeaderStyle>
                                                            <ItemStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid" Width="60px">
                                                            </ItemStyle>
                                                        </asp:BoundField>
                                                          <asp:BoundField DataField="DEDUCTION_TYPE_ID" HeaderText="DEDUCTION TYPE ID">
                                                            <HeaderStyle CssClass="hiddencol"></HeaderStyle>
                                                            <ItemStyle CssClass="hiddencol"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:CommandField ShowEditButton="True" HeaderText="Edit">
                                                            <HeaderStyle CssClass="hiddencol"></HeaderStyle>
                                                            <ItemStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid" Width="20px">
                                                            </ItemStyle>
                                                        </asp:CommandField>
                                                        <asp:TemplateField HeaderText="Delete">
                                                            <HeaderStyle CssClass="hiddencol"></HeaderStyle>
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="btnDelete" runat="server" Text="Delete" OnClientClick="javascript:return confirm('Are you sure you want to Delete?');return false;"
                                                                    CommandName="Delete"></asp:LinkButton>
                                                            </ItemTemplate>
                                                            <ItemStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid" Width="20px">
                                                            </ItemStyle>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                    </table>
                                </fieldset>
                            </asp:Panel>
                        </td>
                    </tr>
                </table>
                <table>
                    <tr>
                        <td>
                            <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn" Width="90px" OnClick="btnSave_Click"
                                ValidationGroup="chkRange" CausesValidation="true"/>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
        <div style="z-index: 101; left: 50%; width: 100px; position: absolute; top: 90px;
            height: 100px">
            <asp:Panel ID="Panel21" runat="server">
                <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                    <ProgressTemplate>
                        <asp:ImageButton ID="ImageButton1" runat="server" Height="26px" ImageUrl="~/App_Themes/Granite/Images/image003.gif"
                            Width="23px" />
                        Wait Update
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </asp:Panel>
        </div>
    </div>
</asp:Content>
