<%@ Page Language="C#" MasterPageFile="~/Forms/PageMaster.master" AutoEventWireup="true"
    CodeFile="frmBrandAssignment.aspx.cs" Inherits="Forms_frmBrandAssignment" Title="SAMS >> Principal Assignment" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
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
                                        <td style="width: 124px; height: 17px">
                                            <strong>
                                                <asp:Label ID="lblmsg" runat="server" Visible="False" Width="114px" ForeColor="Red"></asp:Label></strong>
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td style="height: 17px">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <strong>
                                                <asp:Label ID="Label5" runat="server" Width="52px" Text="User" CssClass="lblbox"></asp:Label></strong>
                                            &nbsp;&nbsp;
                                        </td>
                                        <td style="height: 10px">
                                            <asp:DropDownList ID="ddRole" runat="server" Width="200px" CssClass="DropList" AutoPostBack="True"
                                                OnSelectedIndexChanged="ddUser_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </td>
                                        <td style="height: 10px">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" colspan="2">
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <table>
                                                <tbody>
                                                    <tr>
                                                        <td style="width: 100px" rowspan="4">
                                                            <asp:ListBox ID="lstUnAssignBrand" runat="server" Width="200px" Height="200px" CssClass="DropList">
                                                            </asp:ListBox>
                                                            <div style="z-index: 101; left: 284px; width: 100px; position: absolute; top: 245px;
                                                                height: 100px">
                                                                <asp:Panel ID="Panel1" runat="server">
                                                                    <asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="UpdatePanel1" runat="server">
                                                                        <ProgressTemplate>
                                                                            &nbsp;<asp:ImageButton ID="ImageButton1" runat="server" Height="33px" ImageUrl="~/App_Themes/Granite/Images/image003.gif"
                                                                                Width="31px" />
                                                                        </ProgressTemplate>
                                                                    </asp:UpdateProgress>
                                                                </asp:Panel>
                                                            </div>
                                                        </td>
                                                        <td align="center" style="width: 75px">
                                                            <asp:Button ID="Button3" OnClick="Button3_Click" runat="server" Width="30px" Font-Size="8pt"
                                                                Text=">" CssClass="btn" />
                                                        </td>
                                                        <td style="width: 102px" rowspan="4">
                                                            <asp:ListBox ID="lstAssignBrand" runat="server" Width="200px" Height="200px" CssClass="DropList">
                                                            </asp:ListBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center" style="width: 75px">
                                                            <asp:Button ID="Button1" OnClick="Button1_Click" runat="server" Width="30px" Font-Size="8pt"
                                                                Text=">>" CssClass="btn" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center" style="width: 75px">
                                                            <asp:Button ID="Button2" OnClick="Button2_Click" runat="server" Width="30px" Font-Size="8pt"
                                                                Text="<<" CssClass="btn" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center" style="width: 75px">
                                                            <asp:Button ID="Button4" OnClick="Button4_Click" runat="server" Width="30px" Font-Size="8pt"
                                                                Text="<" CssClass="btn" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td rowspan="1">
                                                        </td>
                                                        <td style="width: 75px; height: 24px">
                                                        </td>
                                                        <td rowspan="1">
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
