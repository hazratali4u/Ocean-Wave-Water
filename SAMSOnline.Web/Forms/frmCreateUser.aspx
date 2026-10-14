<%@ Page Language="C#" MasterPageFile="~/Forms/PageMaster.master" AutoEventWireup="true"
    CodeFile="frmCreateUser.aspx.cs" Inherits="Forms_frmCreateUser" Title="SAMS >> User Login" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cphPage">
    <script language="JavaScript" type="text/javascript">
        function ValidateForm() {
            var str;

            str = document.getElementById('<%=txtLoginId.ClientID%>').value;
            if (str == null || str.length == 0) {
                alert('Must enter Login Id');
                return false;
            }
            str = document.getElementById('<%=txtpassword.ClientID%>').value;
            if (str == null || str.length == 0) {
                alert('Must enter Password');
                return false;
            }
            return true;
        }
    </script>
    <div id="right_data">
        <table width="100%">
            <tr>
                <td>
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>
                            <table>
                                <tbody>
                                    <tr>
                                        <td colspan="2">
                                            <strong>
                                                <asp:Label ID="lblErrorMsg" runat="server" ForeColor="Red" Font-Bold="True"></asp:Label></strong>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <strong>
                                                <asp:Label ID="lbldesignationID" runat="server" Width="97px" Text="Base Location"
                                                    CssClass="lblbox"></asp:Label></strong>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddDistributorId" runat="server" Width="205px" CssClass="DropList"
                                                OnSelectedIndexChanged="ddDistributorId_SelectedIndexChanged" AutoPostBack="True">
                                            </asp:DropDownList>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <strong>
                                                <asp:Label ID="Label1" runat="server" Width="69px" Text="Name" CssClass="lblbox"></asp:Label></strong>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="DrpUser" runat="server" Width="205px" CssClass="DropList">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <strong>
                                                <asp:Label ID="lblNickName" runat="server" Width="68px" Text="Roles" CssClass="lblbox"></asp:Label></strong>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddRole" runat="server" Width="205px" CssClass="DropList">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <strong>
                                                <asp:Label ID="Label3" runat="server" Width="82px" Text="Login Id" CssClass="lblbox"></asp:Label></strong>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtLoginId" runat="server" Width="200px" CssClass="txtBox "></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <strong>
                                                <asp:Label ID="Label2" runat="server" Width="69px" Text="Password" CssClass="lblbox"></asp:Label></strong>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtpassword" runat="server" Width="200px" CssClass="txtBox " TextMode="Password"
                                                MaxLength="20"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            <asp:CheckBox ID="chkIsActive" runat="server" Width="93px" Text="IsActive" Checked="True">
                                            </asp:CheckBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="1" align="right">
                                        </td>
                                        <td>
                                            &nbsp;
                                            <asp:Button ID="btnSave" OnClick="btnSave_Click" runat="server" Width="82px" Font-Size="8pt"
                                                Text="Save" ValidationGroup="vg" CssClass="btn" />
                                            <asp:Button ID="Button1" OnClick="Button1_Click" runat="server" Width="73px" Font-Size="8pt"
                                                Text="Cancel" CssClass="btn" />
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
        </table>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div style="z-index: 101; left: 481px; width: 100px; position: absolute; top: 282px;
                    height: 100px" id="DIV1">
                    <asp:UpdateProgress ID="UpdateProgress5" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
                        <ProgressTemplate>
                            <asp:ImageButton ID="ImageButton1" runat="server" Height="23px" ImageUrl="~/App_Themes/Granite/Images/image003.gif"
                                Width="26px" />&nbsp; Loading....
                        </ProgressTemplate>
                    </asp:UpdateProgress>
                </div>
                <table style="border-right: silver thin inset; border-top: silver thin inset; border-left: silver thin inset;
                    border-bottom: silver thin inset; background-color: silver">
                    <tbody>
                        <tr>
                            <td align="left" style="height: 21px">
                                <strong>
                                    <asp:Label ID="Label10" runat="server" Text="Select Searching Type" Width="153px"></asp:Label></strong>
                            </td>
                            <td align="left" style="width: 170px; height: 21px">
                                <asp:DropDownList ID="ddSearchType" runat="server" CssClass="DropList" Width="200px">
                                    <asp:ListItem Value="SKU_code">All Records</asp:ListItem>
                                    <asp:ListItem Value="USER_NAME">User Name</asp:ListItem>
                                    <asp:ListItem Value="LOGIN_ID">Login</asp:ListItem>
                                    <asp:ListItem Value="role_name">Role</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td align="left" style="width: 224px; height: 21px">
                                <asp:TextBox ID="txtSeach" runat="server" CssClass="txtBox " Width="200px"></asp:TextBox>
                            </td>
                            <td align="left" style="width: 250px; height: 21px">
                                <asp:Button ID="Button2" runat="server" Font-Size="8pt" OnClick="Button2_Click" Text="Filter"
                                    Width="85px" CssClass="btn" />
                            </td>
                        </tr>
                    </tbody>
                </table>
                <asp:Panel ID="Panel1" runat="server" Height="250px" ScrollBars="Vertical" Width="100%">
                    <asp:GridView ID="Grid_users" runat="server" Width="99%" ForeColor="SteelBlue" CssClass="gridRow2"
                        OnRowEditing="Grid_users_RowEditing" OnPageIndexChanging="Grid_users_PageIndexChanging"
                        BorderColor="White" BackColor="White" AutoGenerateColumns="False" HorizontalAlign="Center">
                        <PagerSettings FirstPageText="" LastPageText="" Mode="NextPrevious" NextPageText="Next"
                            PreviousPageText="Previous"></PagerSettings>
                        <RowStyle ForeColor="Black"></RowStyle>
                        <Columns>
                            <asp:BoundField DataField="USER_ID" HeaderText="User Id">
                                <HeaderStyle CssClass="hiddencol"></HeaderStyle>
                                <ItemStyle CssClass="hiddencol"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="Distributor_ID" HeaderText="Distributor">
                                <HeaderStyle CssClass="hiddencol" />
                                <ItemStyle CssClass="hiddencol " />
                            </asp:BoundField>
                            <asp:BoundField DataField="USER_CODE" HeaderText="Code">
                                <ItemStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="USER_NAME" HeaderText="Name">
                                <ItemStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="LOGIN_ID" HeaderText="Login">
                                <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="PASSWORD" HeaderText="Password">
                                <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="role_name" HeaderText="Role">
                                <ItemStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="IS_ACTIVE" HeaderText="Status">
                                <ItemStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="ROLE_ID" HeaderText="ROLE_ID">
                                <HeaderStyle CssClass="hiddencol"></HeaderStyle>
                                <ItemStyle CssClass="hiddencol"></ItemStyle>
                            </asp:BoundField>
                            <asp:CommandField ShowEditButton="True" HeaderText="Edit">
                                <ItemStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid"></ItemStyle>
                            </asp:CommandField>
                        </Columns>
                        <FooterStyle BackColor="White"></FooterStyle>
                        <PagerStyle BackColor="Transparent"></PagerStyle>
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass="tblhead" Font-Bold="True"
                            ForeColor="White"></HeaderStyle>
                        <AlternatingRowStyle BackColor="#F2F2F2" CssClass="GridAlternateRowStyle" ForeColor="#333333">
                        </AlternatingRowStyle>
                    </asp:GridView>
                </asp:Panel>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
