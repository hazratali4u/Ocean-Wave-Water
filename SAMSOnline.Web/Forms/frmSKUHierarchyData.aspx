<%@ Page Language="C#" MasterPageFile="~/Forms/PageMaster.master" AutoEventWireup="true" CodeFile="frmSKUHierarchyData.aspx.cs" Inherits="frmSKUHierarchyData" Title="SAMS >> SKU Hierarchy" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphPage" Runat="Server">
 
      <div id="right_data">
         <table>
            <tr>
                 
                 <td>
         <table width="100%">
             <tr>
                 <td>
                     <cc1:TabContainer ID="TabContainer1" runat="server"  Height="400px" CssClass="Tab"
                         Width="650px" ActiveTabIndex="0">
                         <cc1:TabPanel ID="TabPanel1" runat="server">
                                <HeaderTemplate>
                                 Principal
                             
</HeaderTemplate>
                             <ContentTemplate>
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
                                             <asp:UpdatePanel id="UpdatePanel6" runat="server">
                                                 <contenttemplate>
<TABLE width="100%"><TBODY><TR><TD style="WIDTH: 100px"></TD><TD style="WIDTH: 49px"></TD><TD style="WIDTH: 100px"></TD><TD style="WIDTH: 100px"></TD></TR><TR><TD style="WIDTH: 100px"></TD><TD colSpan=2>
<strong> <asp:Label id="lblErrorMsg" runat="server" ForeColor="Red" Font-Bold="True"></asp:Label></strong><BR /></TD><TD style="WIDTH: 100px"></TD></TR><TR><TD style="WIDTH: 100px"></TD><TD></TD><TD style="WIDTH: 100px"><BR /></TD><TD style="WIDTH: 100px"></TD></TR><TR><TD style="WIDTH: 100px; HEIGHT: 28px"></TD><TD style="WIDTH: 49px; HEIGHT: 28px">
<strong><asp:Label id="Label1" runat="server" Width="90px" Text="Principal Code"></asp:Label></strong> </TD><TD style="WIDTH: 100px; HEIGHT: 28px"><asp:TextBox id="txtPrincipalCode" runat="server" Width="200px" Enabled="False" CssClass="txtBox "></asp:TextBox> </TD><TD style="WIDTH: 100px; HEIGHT: 28px"></TD></TR><TR><TD style="WIDTH: 100px; HEIGHT: 29px"></TD><TD style="WIDTH: 49px; HEIGHT: 29px">
<strong><asp:Label id="Label2" runat="server" Width="96px" Text="Principal Name"></asp:Label> </strong></TD><TD style="WIDTH: 100px; HEIGHT: 29px"><asp:TextBox id="txtPrincipalName" runat="server" Width="200px" Enabled="False" CssClass="txtBox "></asp:TextBox> </TD><TD style="WIDTH: 100px; HEIGHT: 29px"></TD></TR>
    <tr>
        <td style="width: 100px; height: 37px">
        </td>
        <td align="left" style="width: 49px; height: 37px">
        </td>
        <td style="width: 100px; height: 37px">
            <asp:CheckBox ID="ChIsMunalDiscount" runat="server" Text="Is Manual Dicount" Width="190px" />
        </td>
        <td style="width: 100px; height: 37px">
        </td>
    </tr>
    <TR><TD style="WIDTH: 100px; HEIGHT: 37px"></TD><TD style="WIDTH: 49px; HEIGHT: 37px" align=right>&nbsp;</TD><TD style="WIDTH: 100px; HEIGHT: 37px">
    <asp:Button id="btnSavePrincipal" onclick="btnSavePrincipal_Click" runat="server" Width="85px" Font-Size="8pt" Text="New" CssClass="btn" /> </TD><TD style="WIDTH: 100px; HEIGHT: 37px"></TD></TR></TBODY></TABLE>
</contenttemplate>
                                             </asp:UpdatePanel>
                                             <asp:UpdateProgress id="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel6"><progresstemplate>
<asp:ImageButton id="ImageButton1" runat="server" Width="33px" Height="31px" ImageUrl="~/App_Themes/Granite/Images/image003.gif"></asp:ImageButton> 
</progresstemplate>
                                             </asp:UpdateProgress></td>
                                         <td style="width: 100px">
                                         </td>
                                     </tr>
                                     <tr>
                                         <td colspan="3">
                                             <asp:Panel ID="Panel1" runat="server" Height="200px" ScrollBars="Vertical" Width="100%">
                                             <asp:UpdatePanel id="UpdatePanel5" runat="server">
                                                 <contenttemplate>
<asp:GridView id="GrdPrincipal" runat="server" Width="90%" Font-Size="9pt" ForeColor="SteelBlue" CssClass="gridRow2" BorderColor="White" BackColor="White" HorizontalAlign="Center" AutoGenerateColumns="False" OnRowEditing="GrdPrincipal_RowEditing" OnRowDeleting="GrdPrincipal_RowDeleting" OnPageIndexChanging="GrdPrincipal_PageIndexChanging">
<PagerSettings FirstPageText="" LastPageText="" Mode="NextPrevious" NextPageText="Next" PreviousPageText="Previous"></PagerSettings>

<RowStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid" ForeColor="Black"></RowStyle>
<Columns>
<asp:BoundField DataField="SKU_HIE_ID" HeaderText="Id" Visible="False">
<ItemStyle HorizontalAlign="Left" BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="SKU_HIE_CODE" HeaderText="Code">
<HeaderStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid" HorizontalAlign="Left"></HeaderStyle>

<ItemStyle HorizontalAlign="Left" BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="SKU_HIE_NAME" HeaderText="Name">
<ItemStyle HorizontalAlign="Left" BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid"></ItemStyle>
    <HeaderStyle HorizontalAlign="Left" />
</asp:BoundField>
<asp:CommandField ShowEditButton="True" HeaderText="Edit">
<ItemStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid"></ItemStyle>
</asp:CommandField>
<asp:TemplateField HeaderText="Delete"><ItemTemplate>
                                                             <asp:LinkButton ID="btnDelete" runat="server" CommandName="Delete" OnClientClick="javascript:return confirm('Are you sure you want to Delete?');return false;"
                                                                 Text="Delete"></asp:LinkButton>
                                                         
</ItemTemplate>

<ItemStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid"></ItemStyle>
</asp:TemplateField>
</Columns>

<FooterStyle BackColor="White"></FooterStyle>

<PagerStyle BackColor="Transparent"></PagerStyle>

<HeaderStyle CssClass="tblhead" ForeColor="White"></HeaderStyle>

<AlternatingRowStyle CssClass="GridAlternateRowStyle"></AlternatingRowStyle>
</asp:GridView> 
</contenttemplate>
                                             </asp:UpdatePanel>
                                             </asp:Panel>
                                             &nbsp;&nbsp;
                                         </td>
                                     </tr>
                                 </table>
                             
</ContentTemplate>
                         </cc1:TabPanel>
                         <cc1:TabPanel ID="TabPanel2" runat="server">
                             <HeaderTemplate>
                                 Division
                             
</HeaderTemplate>
                             <ContentTemplate>
<table width="100%"><tr><td style="width: 100px;"></td><td align="center"><asp:UpdatePanel ID="UpdatePanel2" runat="server"><ContentTemplate>
<TABLE width="100%"><TBODY><TR><TD style="WIDTH: 100px; HEIGHT: 8px"></TD><TD style="HEIGHT: 8px" align=left colSpan=2>
<strong><asp:Label id="lblErrorMsgDivsion" runat="server" ForeColor="Red" Font-Bold="True"></asp:Label></strong><BR /></TD><TD style="WIDTH: 100px; HEIGHT: 8px"></TD></TR><TR><TD style="WIDTH: 100px; HEIGHT: 8px"></TD><TD style="WIDTH: 159px; HEIGHT: 8px"></TD><TD style="WIDTH: 100px; HEIGHT: 8px"></TD><TD style="WIDTH: 100px; HEIGHT: 8px"></TD></TR><TR><TD style="WIDTH: 100px; HEIGHT: 23px"></TD><TD style="WIDTH: 159px" align=left>
<strong><asp:Label id="Label3" runat="server" Width="80px" Text="Principal"></asp:Label> </strong>&nbsp;</TD><TD style="WIDTH: 100px; HEIGHT: 28px"><asp:DropDownList id="dddivisonPrincipal" runat="server" Width="200px" CssClass="DropList" AutoPostBack="True" OnSelectedIndexChanged="dddivisonPrincipal_SelectedIndexChanged">
                                             </asp:DropDownList> </TD><TD style="WIDTH: 100px; HEIGHT: 23px"></TD></TR><TR><TD style="WIDTH: 100px; HEIGHT: 28px"></TD><TD style="WIDTH: 159px; HEIGHT: 28px" align=left>
                                             <strong><asp:Label id="Label12" runat="server" Width="80px" Text="Division Code"></asp:Label></strong></TD><TD style="WIDTH: 100px; HEIGHT: 28px"><asp:TextBox id="txtDivisionCode" runat="server" Width="194px" Enabled="False" CssClass="txtBox "></asp:TextBox> </TD><TD style="WIDTH: 100px; HEIGHT: 28px"></TD></TR><TR><TD style="WIDTH: 100px; HEIGHT: 29px"></TD><TD style="WIDTH: 159px; HEIGHT: 29px" align=left>
                                             <strong><asp:Label id="Label21" runat="server" Width="85px" Text="Division Name"></asp:Label></strong> </TD><TD style="WIDTH: 100px; HEIGHT: 29px"><asp:TextBox id="txtDivisionName" runat="server" Width="194px" Enabled="False" CssClass="txtBox "></asp:TextBox> </TD><TD style="WIDTH: 100px; HEIGHT: 29px"></TD></TR><TR><TD style="WIDTH: 100px; HEIGHT: 37px"></TD><TD style="WIDTH: 159px; HEIGHT: 37px" align=right>&nbsp;</TD><TD style="WIDTH: 100px; HEIGHT: 37px" align=left>
                                             <asp:Button id="btnSaveDivison" onclick="btnSaveDivison_Click" runat="server" Width="85px" Font-Size="8pt" Text="New" CssClass="btn" /> </TD><TD style="WIDTH: 100px; HEIGHT: 37px"></TD></TR></TBODY></TABLE>
</ContentTemplate>
</asp:UpdatePanel> 
    <asp:UpdateProgress id="UpdateProgress2" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
        <progresstemplate>
<asp:Image id="Image2" runat="server" Width="30px" Height="28px" ImageUrl="~/App_Themes/Granite/Images/image003.gif"></asp:Image>&nbsp; Loading ......... 
</progresstemplate>
    </asp:UpdateProgress></td><td style="width: 100px;"></td></tr><tr><td align="center" colspan="3">
        <asp:Panel ID="Panel2" runat="server" Height="200px" ScrollBars="Vertical" Width="100%">
            <asp:UpdatePanel id="UpdatePanel1" runat="server"><contenttemplate>
<asp:GridView id="GrdDivision" runat="server" Width="90%" Font-Size="9pt" ForeColor="SteelBlue" CssClass="gridRow2" BorderColor="White" BackColor="White" HorizontalAlign="Center" AutoGenerateColumns="False" OnRowEditing="GrdDivision_RowEditing" OnRowDeleting="GrdDivision_RowDeleting" OnPageIndexChanging="GrdDivision_PageIndexChanging">
<PagerSettings FirstPageText="" LastPageText="" Mode="NextPrevious" NextPageText="Next" PreviousPageText="Previous"></PagerSettings>

<RowStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid" ForeColor="Black"></RowStyle>
<Columns>
<asp:BoundField DataField="SKU_HIE_ID" HeaderText="Id" Visible="False">
<ItemStyle HorizontalAlign="Left" BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="SKU_HIE_CODE" HeaderText="Code">
<ItemStyle HorizontalAlign="Left" BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid"></ItemStyle>
    <HeaderStyle HorizontalAlign="Left" />
</asp:BoundField>
<asp:BoundField DataField="SKU_HIE_NAME" HeaderText="Name">
<ItemStyle HorizontalAlign="Left" BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid"></ItemStyle>
    <HeaderStyle HorizontalAlign="Left" />
</asp:BoundField>
<asp:CommandField ShowEditButton="True" HeaderText="Edit">
<ItemStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid"></ItemStyle>
</asp:CommandField>
<asp:TemplateField HeaderText="Delete"><ItemTemplate>
                                                             <asp:LinkButton ID="btnDelete" runat="server" CommandName="Delete" OnClientClick="javascript:return confirm('Are you sure you want to Delete?');return false;"
                                                                 Text="Delete"></asp:LinkButton>
                                                         
</ItemTemplate>

<ItemStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid"></ItemStyle>
</asp:TemplateField>
</Columns>

<FooterStyle BackColor="White"></FooterStyle>

<PagerStyle BackColor="Transparent"></PagerStyle>

<HeaderStyle CssClass="tblhead" ForeColor="White"></HeaderStyle>

<AlternatingRowStyle CssClass="GridAlternateRowStyle"></AlternatingRowStyle>
</asp:GridView> 
</contenttemplate>
</asp:UpdatePanel> 
        </asp:Panel>
        &nbsp;
    </td></tr></table><br />&nbsp; 
</ContentTemplate>
                         </cc1:TabPanel>
                         <cc1:TabPanel ID="TabPanel3" runat="server">
                             <HeaderTemplate>
                                 Category
                             
</HeaderTemplate>
                             <ContentTemplate>
                                 <table width="100%">
                                     <tr>
                                         <td style="width: 100px">
                                         </td>
                                         <td align="center" style="width: 100px">
                                             <asp:UpdatePanel ID="UpdatePanel21" runat="server">
                                                 <ContentTemplate>
<TABLE width="100%"><TBODY><TR><TD style="WIDTH: 100px; HEIGHT: 16px"></TD><TD style="HEIGHT: 16px" align=left colSpan=2><BR />
<strong><asp:Label id="lblErrorMsgCategory" runat="server" ForeColor="Red" Font-Bold="True"></asp:Label></strong></TD><TD style="WIDTH: 100px; HEIGHT: 16px"></TD></TR><TR><TD style="WIDTH: 100px; HEIGHT: 8px"></TD><TD style="WIDTH: 69px; HEIGHT: 8px"></TD><TD style="WIDTH: 100px; HEIGHT: 8px"></TD><TD style="WIDTH: 100px; HEIGHT: 8px"></TD></TR>
    <tr>
        <td style="width: 100px; height: 21px">
        </td>
        <td align="left" style="width: 69px; height: 21px">
            <strong><asp:Label ID="Label5" runat="server" Text="Principal" Width="80px"></asp:Label></strong></td>
        <td style="width: 100px; height: 28px">
            <asp:DropDownList id="DrpCategoryPrincipal" runat="server" Width="200px" CssClass="DropList" AutoPostBack="True" OnSelectedIndexChanged="DrpCategoryPrincipal_SelectedIndexChanged">
            </asp:DropDownList></td>
        <td style="width: 100px; height: 21px">
        </td>
    </tr>
    <TR><TD style="WIDTH: 100px; HEIGHT: 21px"></TD><TD style="WIDTH: 69px; HEIGHT: 21px" align=left>
    <strong><asp:Label id="Label4" runat="server" Width="80px" Text="Division"></asp:Label> </strong></TD><TD style="WIDTH: 100px; HEIGHT: 28px"><asp:DropDownList id="ddCategoryDivision" runat="server" Width="200px" CssClass="DropList" AutoPostBack="True" OnSelectedIndexChanged="ddCategoryDivision_SelectedIndexChanged">
                                             </asp:DropDownList> </TD><TD style="WIDTH: 100px; HEIGHT: 21px"></TD></TR><TR><TD style="WIDTH: 100px; HEIGHT: 28px"></TD><TD style="WIDTH: 69px; HEIGHT: 28px" align=left>
                                             <strong><asp:Label id="Label121" runat="server" Width="90px" Text="Category Code"></asp:Label></strong> </TD><TD style="WIDTH: 100px; HEIGHT: 28px"><asp:TextBox id="txtCategoryCode" runat="server" Width="194px" Enabled="False" CssClass="txtBox "></asp:TextBox> </TD><TD style="WIDTH: 100px; HEIGHT: 28px"></TD></TR><TR><TD style="WIDTH: 100px; HEIGHT: 29px"></TD><TD style="WIDTH: 69px; HEIGHT: 29px" align=left>
                                             <strong><asp:Label id="Label211" runat="server" Width="90px" Text="Category Name"></asp:Label> </strong></TD><TD style="WIDTH: 100px; HEIGHT: 29px"><asp:TextBox id="txtCategoryName" runat="server" Width="194px" Enabled="False" CssClass="txtBox "></asp:TextBox> </TD><TD style="WIDTH: 100px; HEIGHT: 29px"></TD></TR><TR><TD style="WIDTH: 100px; HEIGHT: 37px"></TD><TD style="WIDTH: 69px; HEIGHT: 37px" align=right>&nbsp;</TD><TD style="WIDTH: 100px; HEIGHT: 37px" align=left>
                                             <asp:Button id="btnSaveCategory" onclick="btnSaveCategory_Click" runat="server" Width="85px" Font-Size="8pt" Text="New" CssClass="btn" /> </TD><TD style="WIDTH: 100px; HEIGHT: 37px"></TD></TR></TBODY></TABLE>
</ContentTemplate>
                                             </asp:UpdatePanel><asp:UpdateProgress id="UpdateProgress3" runat="server" AssociatedUpdatePanelID="UpdatePanel21"><progresstemplate>
<asp:Image id="Image3" runat="server" Width="30px" Height="28px" ImageUrl="~/App_Themes/Granite/Images/image003.gif"></asp:Image>&nbsp; Loading ......... 
</progresstemplate>
                                             </asp:UpdateProgress>
                                         </td>
                                         <td style="width: 100px">
                                         </td>
                                     </tr>
                                     <tr>
                                         <td align="center" colspan="3">
                                             <asp:Panel ID="Panel3" runat="server" Height="200px" ScrollBars="Vertical" Width="100%">
                                             <asp:UpdatePanel id="UpdatePanel7" runat="server">
                                                 <contenttemplate>
<asp:GridView id="GrdCategory" runat="server" Width="90%" Font-Size="9pt" ForeColor="SteelBlue" CssClass="gridRow2" BorderColor="White" BackColor="White" HorizontalAlign="Center" AutoGenerateColumns="False" OnRowEditing="GrdCategory_RowEditing" OnRowDeleting="GrdCategory_RowDeleting" OnPageIndexChanging="GrdCategory_PageIndexChanging">
<PagerSettings FirstPageText="" LastPageText="" Mode="NextPrevious" NextPageText="Next" PreviousPageText="Previous"></PagerSettings>

<RowStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid" ForeColor="Black"></RowStyle>
<Columns>
<asp:BoundField DataField="SKU_HIE_ID" HeaderText="Id" Visible="False">
<ItemStyle HorizontalAlign="Left" BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="SKU_HIE_CODE" HeaderText="Code">
<ItemStyle HorizontalAlign="Left" BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid"></ItemStyle>
    <HeaderStyle HorizontalAlign="Left" />
</asp:BoundField>
<asp:BoundField DataField="SKU_HIE_NAME" HeaderText="Name">
<ItemStyle HorizontalAlign="Left" BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid"></ItemStyle>
    <HeaderStyle HorizontalAlign="Left" />
</asp:BoundField>
<asp:CommandField ShowEditButton="True" HeaderText="Edit">
<ItemStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid"></ItemStyle>
</asp:CommandField>
<asp:TemplateField HeaderText="Delete"><ItemTemplate>
                                                 <asp:LinkButton ID="btnDelete" runat="server" CommandName="Delete" OnClientClick="javascript:return confirm('Are you sure you want to Delete?');return false;"
                                                     Text="Delete"></asp:LinkButton>
                                             
</ItemTemplate>

<ItemStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid"></ItemStyle>
</asp:TemplateField>
</Columns>

<FooterStyle BackColor="White"></FooterStyle>

<PagerStyle BackColor="Transparent"></PagerStyle>

<HeaderStyle CssClass="tblhead" ForeColor="White"></HeaderStyle>

<AlternatingRowStyle CssClass="GridAlternateRowStyle"></AlternatingRowStyle>
</asp:GridView> 
</contenttemplate>
                                             </asp:UpdatePanel>
                                             </asp:Panel>
                                             &nbsp;
                                         </td>
                                     </tr>
                                 </table>
                                 &nbsp;&nbsp;
                             
</ContentTemplate>
                         </cc1:TabPanel>
                         <cc1:TabPanel ID="TabPanel4" runat="server">
                             <HeaderTemplate>
                                 Brand
                             
</HeaderTemplate>
                             <ContentTemplate>
                                 <table width="100%">
                                     <tr>
                                         <td style="width: 100px">
                                         </td>
                                         <td align="center" style="width: 100px">
                                             <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                                 <ContentTemplate>
<TABLE width="100%"><TBODY><TR><TD colSpan=2>
<strong><asp:Label id="lblErrorMsgBrand" runat="server" ForeColor="Red" Font-Bold="True"></asp:Label></strong><BR /></TD><TD style="WIDTH: 100px"></TD></TR><TR><TD style="height: 25px;" align="left">
    <strong><asp:Label ID="Label6" runat="server" Text="Principal" Width="80px"></asp:Label></strong></TD><TD style="WIDTH: 100px"><asp:DropDownList id="DrpBrandPrincipal" runat="server" Width="200px" CssClass="DropList" AutoPostBack="True" OnSelectedIndexChanged="DrpBrandPrincipal_SelectedIndexChanged">
</asp:DropDownList></TD><TD style="WIDTH: 100px"></TD></TR>
    <tr>
        <td align="left" style="height: 21px">
            <strong><asp:Label ID="Label10" runat="server" Text="Division" Width="64px"></asp:Label></strong></td>        <td style="height: 25px">
            <asp:DropDownList id="DrpBrandDivision" runat="server" Width="200px" CssClass="DropList" AutoPostBack="True" OnSelectedIndexChanged="DrpBrandDivision_SelectedIndexChanged">
            </asp:DropDownList></td>
        <td style="width: 100px; height: 21px">
        </td>
    </tr>
    <TR><TD style="HEIGHT: 25px" align=left>
    <strong><asp:Label id="Label9" runat="server" Width="80px" Text="Category"></asp:Label></strong></TD><TD style="WIDTH: 100px; HEIGHT: 28px"><asp:DropDownList id="ddBrandCategory" runat="server" Width="200px" CssClass="DropList" AutoPostBack="True" OnSelectedIndexChanged="ddBrandCategory_SelectedIndexChanged">
                                                                 </asp:DropDownList></TD><TD style="WIDTH: 100px; HEIGHT: 28px"></TD></TR><TR><TD style="WIDTH: 100px; HEIGHT: 28px" align=left>
                                                                 <strong><asp:Label id="Label7" runat="server" Width="90px" Text="Brand Code"></asp:Label></strong></TD><TD style="WIDTH: 100px; HEIGHT: 28px"><asp:TextBox id="txtBrandCode" runat="server" Width="194px" Enabled="False" CssClass="txtBox "></asp:TextBox> </TD><TD style="WIDTH: 100px; HEIGHT: 28px"></TD></TR><TR><TD style="WIDTH: 100px; HEIGHT: 29px" align=left>
                                                                 <strong><asp:Label id="Label8" runat="server" Width="90px" Text="Brand Name"></asp:Label></strong></TD><TD style="WIDTH: 100px; HEIGHT: 29px"><asp:TextBox id="txtBrandName" runat="server" Width="194px" Enabled="False" CssClass="txtBox "></asp:TextBox> </TD><TD style="WIDTH: 100px; HEIGHT: 29px"></TD></TR><TR><TD style="WIDTH: 100px; HEIGHT: 37px"></TD><TD style="WIDTH: 100px; HEIGHT: 37px" align=left>
                                                                 <asp:Button id="btnSaveBrand" onclick="btnSaveBrand_Click" runat="server" Width="85px" Font-Size="8pt" Text="New" AccessKey="B" CssClass="btn" /> </TD><TD style="WIDTH: 100px; HEIGHT: 37px"></TD></TR></TBODY></TABLE>
</ContentTemplate>
                                             </asp:UpdatePanel><asp:UpdateProgress id="UpdateProgress4" runat="server" AssociatedUpdatePanelID="UpdatePanel4"><progresstemplate>
<asp:Image id="Image4" runat="server" Width="24px" Height="23px" ImageUrl="~/App_Themes/Granite/Images/image003.gif"></asp:Image>&nbsp; Loading..... 
</progresstemplate>
                                             </asp:UpdateProgress>
                                         </td>
                                         <td style="width: 100px">
                                         </td>
                                     </tr>
                                     <tr>
                                         <td align="center" colspan="3">
                                             &nbsp;<asp:Panel ID="Panel4" runat="server" Height="150px" ScrollBars="Vertical"
                                                 Width="100%">
                                             <asp:UpdatePanel id="UpdatePanel8" runat="server">
                                                 <contenttemplate>
<asp:GridView id="GrdBrand" runat="server" Width="90%" Font-Size="9pt" ForeColor="SteelBlue" CssClass="gridRow2" BorderColor="White" BackColor="White" HorizontalAlign="Center" AutoGenerateColumns="False" OnRowEditing="GrdBrand_RowEditing" OnRowDeleting="GrdBrand_RowDeleting" OnPageIndexChanging="GrdBrand_PageIndexChanging">
<PagerSettings FirstPageText="" LastPageText="" Mode="NextPrevious" NextPageText="Next" PreviousPageText="Previous"></PagerSettings>

<RowStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid" ForeColor="Black"></RowStyle>
<Columns>
<asp:BoundField DataField="SKU_HIE_ID" HeaderText="Id" Visible="False">
<ItemStyle HorizontalAlign="Left" BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="SKU_HIE_CODE" HeaderText="Code">
<ItemStyle HorizontalAlign="Left" BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid"></ItemStyle>
    <HeaderStyle HorizontalAlign="Left" />
</asp:BoundField>
<asp:BoundField DataField="SKU_HIE_NAME" HeaderText="Name">
<ItemStyle HorizontalAlign="Left" BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid"></ItemStyle>
    <HeaderStyle HorizontalAlign="Left" />
</asp:BoundField>
<asp:CommandField ShowEditButton="True" HeaderText="Edit">
<ItemStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid"></ItemStyle>
</asp:CommandField>
<asp:TemplateField HeaderText="Delete"><ItemTemplate>
                                                 <asp:LinkButton ID="btnDelete" runat="server" CommandName="Delete" OnClientClick="javascript:return confirm('Are you sure you want to Delete?');return false;"
                                                     Text="Delete"></asp:LinkButton>
                                             
</ItemTemplate>

<ItemStyle BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid"></ItemStyle>
</asp:TemplateField>
</Columns>

<FooterStyle BackColor="White"></FooterStyle>

<PagerStyle BackColor="Transparent"></PagerStyle>

<HeaderStyle CssClass="tblhead" ForeColor="White"></HeaderStyle>

<AlternatingRowStyle CssClass="GridAlternateRowStyle"></AlternatingRowStyle>
</asp:GridView> 
</contenttemplate>
                                             </asp:UpdatePanel>
                                             </asp:Panel>
                                         </td>
                                     </tr>
                                 </table>
                             
</ContentTemplate>
                         </cc1:TabPanel>
                     </cc1:TabContainer></td>
             </tr>
         </table>
                 </td>
                
             </tr>
           
         </table>
     </div>
</asp:Content>

