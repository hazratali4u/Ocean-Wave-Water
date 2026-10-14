<%@ Page Language="C#" MasterPageFile="~/Forms/PageMaster.master" AutoEventWireup="true" CodeFile="frmAccountHead.aspx.cs" Inherits="Forms_frmAccountHead" Title="SAMS >> Chart of Account" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphPage" Runat="Server">
    <div id="right_data">
         <table width="100%">
             <tr>
                 <td>
                     <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                         <ContentTemplate>
<TABLE width="100%"><TBODY><TR><TD colSpan=2>
<strong><asp:Label id="lblErrorMsg" runat="server" ForeColor="Red" Font-Bold="True"></asp:Label></strong></TD><TD></TD><TD></TD><TD></TD><TD style="WIDTH: 11px"></TD></TR><TR><TD style="WIDTH: 121px">
<strong><asp:Label id="Label1" runat="server" Width="150px" Text="Main Account Type " CssClass="lblbox"></asp:Label></strong></TD><TD><asp:DropDownList id="ddAccountType" runat="server" Width="250px" CssClass="DropList" OnSelectedIndexChanged="ddAccountType_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList> <asp:TextBox id="txtAtypeCode" runat="server" Visible="False" Width="62px" CssClass="txtBox " MaxLength="2"></asp:TextBox>
    <asp:TextBox ID="txtAtypeName" runat="server" CssClass="txtBox " Visible="False"
        Width="170px"></asp:TextBox></TD><TD></TD><TD style="HEIGHT: 25px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </TD><TD>
        <asp:Button CssClass="btn" id="btnAccountType" onclick="btnAccountType_Click" runat="server" Width="125px" Font-Size="8pt" Text="New Account Type"></asp:Button></TD><TD style="WIDTH: 11px"></TD></TR><TR><TD style="WIDTH: 121px; HEIGHT: 35px">
        <strong><asp:Label id="Label2" runat="server" Width="150px" Text="Sub Account Type" CssClass="lblbox"></asp:Label></strong></TD><TD style="HEIGHT: 35px"><asp:DropDownList id="ddAccountSubType" runat="server" Width="250px" CssClass="DropList" OnSelectedIndexChanged="ddAccountSubType_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList> <asp:TextBox id="txtASubTypeCode" runat="server" Visible="False" Width="62px" CssClass="txtBox " MaxLength="2"></asp:TextBox>
    <asp:TextBox ID="txtSubTypeName" runat="server" CssClass="txtBox " Visible="False"
        Width="170px"></asp:TextBox></TD><TD style="HEIGHT: 35px"></TD><TD style="HEIGHT: 35px"></TD><TD style="HEIGHT: 35px"><asp:Button CssClass="btn" id="btnAccountSubType" onclick="btnAccountSubType_Click" runat="server" Width="125px" Font-Size="8pt" Text="New Sub Type"></asp:Button></TD><TD style="WIDTH: 11px; HEIGHT: 35px"></TD></TR><TR><TD style="WIDTH: 121px">
        <strong><asp:Label id="Label4" runat="server" Width="150px" Text="Detail Account Type" CssClass="lblbox"></asp:Label></strong></TD><TD><asp:DropDownList id="drpAccountTypeDetail" runat="server" Width="250px" CssClass="DropList" OnSelectedIndexChanged="drpAccountTypeDetail_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList> <asp:TextBox id="txtADetailTypeCode" runat="server" Visible="False" Width="62px" CssClass="txtBox " MaxLength="2"></asp:TextBox>
    <asp:TextBox ID="txtDetailTypeName" runat="server" CssClass="txtBox " Visible="False"
        Width="170px"></asp:TextBox></TD><TD></TD><TD style="HEIGHT: 25px"></TD><TD><asp:Button CssClass="btn" id="btnAccountDetailType" runat="server" Width="125px" Font-Size="8pt" Text="New Detail Type" OnClick="btnAccountDetailType_Click"></asp:Button></TD><TD style="WIDTH: 11px"></TD></TR><TR><TD style="WIDTH: 121px">
        <strong><asp:Label id="Label3" runat="server" Width="109px" Text="Account Head" CssClass="lblbox"></asp:Label></strong></TD><TD><asp:TextBox id="txtAccountCode" runat="server" Width="62px" CssClass="txtBox " MaxLength="4"></asp:TextBox>
            <asp:TextBox ID="txtAccountHead" runat="server" CssClass="txtBox " Width="170px"></asp:TextBox></TD><TD></TD><TD style="HEIGHT: 25px"></TD><TD></TD><TD style="WIDTH: 11px"></TD></TR><TR><TD style="WIDTH: 121px"></TD><TD style="WIDTH: 169px; HEIGHT: 26px">
                <asp:CheckBox ID="ChbIsactive" runat="server" Checked="True" Text="Is Active" /></TD><TD style="HEIGHT: 26px"></TD><TD style="HEIGHT: 26px"></TD><TD style="HEIGHT: 26px"></TD><TD style="WIDTH: 11px; HEIGHT: 26px"></TD></TR><TR><TD style="WIDTH: 121px"></TD><TD align=left><asp:Button CssClass="btn" id="btnSave" onclick="btnSave_Click" runat="server" Width="94px" Font-Size="8pt" Text="New"></asp:Button> <asp:Button CssClass="btn" id="btnCancel" onclick="btnCancel_Click" runat="server" Width="94px" Font-Size="8pt" Text="Cancel"></asp:Button></TD><TD></TD><TD></TD><TD></TD><TD style="WIDTH: 11px"></TD></TR></TBODY></TABLE>
</ContentTemplate>
                     </asp:UpdatePanel> &nbsp;
                 </td>                
             </tr>
         </table>
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                         <ContentTemplate>
<asp:GridView id="GridAccountHead" runat="server" Width="100%" ForeColor="SteelBlue" CssClass="gridRow2" OnRowEditing="GridAccountHead_RowEditing" AutoGenerateColumns="False" BackColor="White" HorizontalAlign="Center" BorderColor="White">
<PagerSettings FirstPageText="" LastPageText="" Mode="NextPrevious" NextPageText="Next" PreviousPageText="Previous"></PagerSettings>

<RowStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid" ForeColor="Black"></RowStyle>
<Columns>
<asp:BoundField DataField="Account_TypeId" HeaderText="Account_TypeId">
<HeaderStyle CssClass="hiddencol"></HeaderStyle>

<ItemStyle CssClass="hiddencol"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="AccountSub_TypeId" HeaderText="AccountSub_TypeId">
<HeaderStyle CssClass="hiddencol"></HeaderStyle>

<ItemStyle CssClass="hiddencol"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="AccountDetail_TypeId" HeaderText="AccountDetail_TypeId">
<HeaderStyle CssClass="hiddencol"></HeaderStyle>

<ItemStyle CssClass="hiddencol"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="ACCOUNT_HEAD_ID" HeaderText="ACCOUNT_HEAD_ID">
<HeaderStyle CssClass="hiddencol"></HeaderStyle>

<ItemStyle CssClass="hiddencol"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="Account_Type" HeaderText="Account Type">
<ItemStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="Account_SubType" HeaderText="Sub Type">
<ItemStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="AccountDetail_Type" HeaderText="Account Detail">
<HeaderStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid"></HeaderStyle>

<ItemStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="Account_Name" HeaderText="Account Name">
<ItemStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid"></ItemStyle>
</asp:BoundField>
<asp:CommandField ShowEditButton="True" HeaderText="Edit">
<ItemStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid"></ItemStyle>
</asp:CommandField>
</Columns>

<FooterStyle BackColor="White"></FooterStyle>

<PagerStyle BackColor="Transparent"></PagerStyle>

<HeaderStyle CssClass="tblhead" ForeColor="White"></HeaderStyle>

<AlternatingRowStyle CssClass="GridAlternateRowStyle"></AlternatingRowStyle>
</asp:GridView> 
                             <div style="z-index: 101; left: 429px; width: 100px; position: absolute; top: 431px;
                                 height: 100px">
                                 <asp:Panel ID="Panel1" runat="server">
                     <asp:UpdateProgress id="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
                         <progresstemplate>
                             <asp:ImageButton ID="ImageButton1" runat="server" Height="30px" ImageUrl="~/App_Themes/Granite/Images/image003.gif"
                                 Width="32px" />
                             Wait Updated
</progresstemplate>
                     </asp:UpdateProgress>
                                 </asp:Panel>
                             </div>
</ContentTemplate>
                     </asp:UpdatePanel>
    </div>
</asp:Content>
