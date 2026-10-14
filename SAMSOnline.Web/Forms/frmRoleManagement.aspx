<%@ Page Language="C#" MasterPageFile="~/Forms/PageMaster.master" AutoEventWireup="true" CodeFile="frmRoleManagement.aspx.cs" Inherits="frmRoleManagement" Title="SAMS >> Role Management" %>

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
                                        <td style="width: 82px;">
                                            <strong>
                                                <asp:Label ID="lblmsg" runat="server" Visible="False" Width="114px" ForeColor="Red"></asp:Label></strong></td>
                                        <td>&nbsp; </td>
                                        <td style="height: 17px"></td>
                                    </tr>
                                    <tr>
                                        <td style="width:115px;">
                                            <strong>
                                                Role Description</strong></td>
                                        <td>
                                            <asp:DropDownList ID="ddRole" runat="server" Width="200px" CssClass="DropList" AutoPostBack="True" OnSelectedIndexChanged="ddRole_SelectedIndexChanged"></asp:DropDownList>
                                            <asp:TextBox ID="TextBox1" runat="server" Visible="False" Width="200px" CssClass="txtBox " Enabled="False"></asp:TextBox>&nbsp;&nbsp;<asp:Button ID="btnNew" OnClick="btnNew_Click" runat="server" Width="55px" Font-Size="8pt" Text="New" CssClass="btn" /></td>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <strong>
                                                Module 1st Layer</strong></td>
                                        <td>
                                            <asp:DropDownList ID="DrpModule1stLayer" runat="server" Width="200px" CssClass="DropList" AutoPostBack="True" OnSelectedIndexChanged="DrpModule1stLayer_SelectedIndexChanged"></asp:DropDownList></td>
                                    </tr>
                                    <tr>
                                        <td style="height: 24px">
                                            <strong>
                                                Module 2nd Layer</strong></td>
                                        <td>
                                            <asp:DropDownList ID="DrpModule2ndLayer" runat="server" Width="200px" CssClass="DropList" AutoPostBack="True" OnSelectedIndexChanged="DrpModule2ndLayer_SelectedIndexChanged"></asp:DropDownList></td>
                                    </tr>
                                    <tr>
                                        <td style="height: 16px">
                                            <strong>
                                                Module 3rd Layer</strong></td>
                                        <td>
                                            <asp:DropDownList ID="DrpModule3rdLayer" runat="server" Width="200px" CssClass="DropList" AutoPostBack="True" OnSelectedIndexChanged="DrpModule3rdLayer_SelectedIndexChanged"></asp:DropDownList></td>
                                    </tr>
                                    <tr>
                                        <td style="height: 16px">&nbsp;</td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" align="center">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <strong>
                                            <asp:Label ID="Label4" runat="server" CssClass="lblbox"
                                                Text="Module Assignment" Width="142px"></asp:Label>
                                        </strong>&nbsp; </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" style="height: 182px">
                                            <table>
                                                <tbody>
                                                    <tr>
                                                        <td style="width: 150px">
                                                            <asp:ListBox ID="lstUnAssignModule" runat="server" CssClass="DropList"
                                                                Height="200px" Width="200px"></asp:ListBox>
                                                        </td>

                                                        <td style="width: 50px" align="center" valign="middle">
                                                            <asp:Button ID="Button1" runat="server" CssClass="btn" Font-Size="8pt"
                                                                OnClick="Button1_Click" Text="&gt;" Width="30px" />
                                                            <br />
                                                            <br />
                                                            <asp:Button ID="Button2" runat="server" CssClass="btn" Font-Size="8pt"
                                                                OnClick="Button2_Click" Text="&lt;" Width="30px" />
                                                        </td>

                                                        <td style="width: 150px">
                                                            <asp:ListBox ID="lstAssignModule" runat="server" CssClass="DropList"
                                                                Height="200px" Width="200px"></asp:ListBox>
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
            <tr>
                <td colspan="3">
                    <asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="UpdatePanel1" runat="server">
                        <ProgressTemplate>
                            Data saving in Progress……..
                        </ProgressTemplate>

                    </asp:UpdateProgress>
                </td>
            </tr>
        </table>

    </div>

</asp:Content>

