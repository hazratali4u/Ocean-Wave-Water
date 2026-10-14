<%@ Page Language="C#" MasterPageFile="~/Forms/AppMaster.master" AutoEventWireup="true" CodeFile="frmTest.aspx.cs" Inherits="Forms_frmTest" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="mainCopy" Runat="Server">

    <div class="container" style="background-color: white">
    
        <h2>
            &nbsp; Bank Transaction
        </h2>
    </div>
     <script type="text/javascript">       
               
        function pageLoad()
        {
            var manager = Sys.WebForms.PageRequestManager.getInstance();
            manager.add_beginRequest(OnBeginRequest);
            manager.add_endRequest(OnEndRequest);
        }
        var GlobalSubmitButtonID="btnSubmit";
        var SubmitButtonID;
        var AnexElementID;
        function OnBeginRequest(sender, args) 
        {
            SubmitButtonID = args.get_postBackElement().id.toLowerCase();
            if (SubmitButtonID === GlobalSubmitButtonID.toLowerCase())
            { 
                AnexElementID=$find("AnimationExtender1");
                AnexElementID.OnClick();
            }
        }

        function OnEndRequest(sender, args) 
        {
            if (SubmitButtonID === GlobalSubmitButtonID.toLowerCase())
            {
                //$get(GlobalSubmitButtonID).disabled = false;
            }
        }
   
                 
    </script>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>


         <table style="border-right: silver thin inset; border-top: silver thin inset; border-left: silver thin inset;
                width: 100%; border-bottom: silver thin inset; background-color: silver">
                <tbody>
                    <tr>
                        <td align="left" style="height: 21px">
                            <asp:Label ID="Label10" runat="server" Text="Select Searching Type" Width="127px"></asp:Label>
                        </td>
                        <td align="left" style="width: 170px; height: 21px">
                            <asp:DropDownList ID="ddSearchType" runat="server" CssClass="DropList" Width="195px">
                                <asp:ListItem Value="CUSTOMER_NAME">Customer Name</asp:ListItem>
                                <asp:ListItem Value="ADDRESS">Address</asp:ListItem>
                                <asp:ListItem Value="Distributor_NAME">Location</asp:ListItem>
                                <asp:ListItem Value="AREA_NAME">Route Name</asp:ListItem>
                                <asp:ListItem Value="SLASH_DESC">Channel Type</asp:ListItem>
                                <asp:ListItem Value="CUSTOMER_CODE">Customer Code</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td align="right">
                            &nbsp;Value%</td>
                        <td align="left" style="width: 224px; height: 21px">
                            <asp:TextBox ID="txtSeach" runat="server" CssClass="txtBox " Width="200px" OnTextChanged="txtSeach_TextChanged" EnableViewState="False"></asp:TextBox>
                        </td>
                        <td align="left" style="height: 21px" width="250">
                            &nbsp;<asp:Button ID="Button2" runat="server" Font-Size="8pt" Text="Filter"
                                Width="85px" OnClick="Button2_Click" /></td>
                    </tr>
                </tbody>
            </table>
                <asp:GridView ID="Grid_users" runat="server" AutoGenerateColumns="False" BackColor="White"
                    BorderColor="White" CssClass="gridRow2" ForeColor="SteelBlue" HorizontalAlign="Center"
                    Width="99%">
                    <PagerSettings FirstPageText="" LastPageText="" Mode="NextPrevious" NextPageText="Next"
                        PreviousPageText="Previous" />
                    <RowStyle ForeColor="Black" />
                    <Columns>
                        <asp:TemplateField HeaderText="Select">
                            <ItemTemplate>
                                <asp:CheckBox ID="ChbCustomer" runat="server" />
                            </ItemTemplate>
                            <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="CUSTOMER_ID" HeaderText="CUSTOMER_ID">
                            <HeaderStyle CssClass="hiddencol" />
                            <ItemStyle CssClass="hiddencol" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Distributor_id" HeaderText="Distributor_id">
                            <HeaderStyle CssClass="hiddencol" />
                            <ItemStyle CssClass="hiddencol" />
                        </asp:BoundField>
                        <asp:BoundField DataField="CUSTOMER_CODE" HeaderText="Code">
                            <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="CUSTOMER_NAME" HeaderText="Name">
                            <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Distributor_Name" HeaderText="Location">
                            <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="AREA_NAME" HeaderText="Route">
                            <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ADDRESS" HeaderText="ADDRESS">
                            <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ChannelType" HeaderText="Channel Type">
                            <ItemStyle BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Left" />
                        </asp:BoundField>
                    </Columns>
                    <FooterStyle BackColor="White" />
                    <PagerStyle BackColor="Transparent" />
                    <HeaderStyle BackColor="#007395" Font-Bold="True" ForeColor="White" HorizontalAlign="Center"
                        VerticalAlign="Middle" />
                    <AlternatingRowStyle BackColor="#F2F2F2" CssClass="GridAlternateRowStyle" ForeColor="#333333" />
                </asp:GridView>
            &nbsp;&nbsp;
        </ContentTemplate>
    </asp:UpdatePanel>
   
    &nbsp;
    
    </asp:Content>

