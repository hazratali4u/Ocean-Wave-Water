<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeFile="frmOrderPOS2.aspx.cs"
    Inherits="Forms_frmOrderPOS2" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">


    <title>CORN :: Point Of Sale</title>

    <link href="../OrderPOS/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../OrderPOS/css/bootstrap.css" rel="stylesheet" type="text/css" />
    <link href="../OrderPOS/css/POStemplate.css" rel="stylesheet" type="text/css" />
    <link href="../OrderPOS/css/font-awesome.min.css" rel="stylesheet" type="text/css" />


    <link rel="shortcut icon" href="../images/favicon.ico" />
    <script src="../OrderPOS/js/jquery-1.10.2.js" type="text/javascript"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.0/jquery.min.js" type="text/javascript"></script>
    <script src="../js/bootstrap.min.js" type="text/javascript"></script>

    <script type="text/javascript" src="../JS/jquery-1.6.1.min.js"></script>
    <script src="../JS/jquery.searchabledropdown-1.0.8.min.js" type="text/javascript"></script>
</head>
<body>
    <script type="text/javascript" language="javascript">
        function pageLoad() {
            $("select").searchable();
            SearchProduct();
        }
        function onlyNumbers(txt, event) {
            var charCode = (event.which) ? event.which : event.keyCode;

            if (charCode == 9 || charCode == 8) {
                return true;
            }
            if (charCode == 46) {
                return false;
            }
            if (charCode == 31 || charCode < 48 || charCode > 57)
                return false;

            return true;
        }
        function onlyDotsAndNumbers(txt, event) {
            var charCode = (event.which) ? event.which : event.keyCode;

            if (charCode == 9 || charCode == 8) {
                return true;
            }
            if (charCode == 46) {
                if (txt.value.indexOf(".") < 0)
                    return true;
                return false;
            }
            if (charCode == 31 || charCode < 48 || charCode > 57)
                return false;
            return true;
        }

        function CalculateNetAndBalance() {

            var gross = document.getElementById("<%= txtGrossAmount.ClientID %>").value;
            var disc = document.getElementById("<%= numtxtTotalExtraDiscnt.ClientID %>").value;
            var tax = document.getElementById("<%= numTxtTotalGST.ClientID %>").value;
            var totalamount = document.getElementById("<%= numTxtTotlAmnt.ClientID %>").value;
            var paydamount = document.getElementById("<%= txtCashReceived.ClientID %>").value;
            var balance = document.getElementById("<%= txtBalance.ClientID%>").value;

            if (document.getElementById("<%= btnToggleMode.ClientID %>").value == 'SALE MODE') {


                if (gross > 0) {
                }
                else {
                    gross = 0;
                }
                if (disc > 0) {
                }
                else {
                    disc = 0;
                }

                if (tax > 0) {
                }
                else {
                    tax = 0;
                }

                if (totalamount > 0) {
                }
                else {
                    totalamount = 0;
                }

                if (paydamount > 0) {
                }
                else {
                    paydamount = 0;
                }



                setTimeout(function () {

                    document.getElementById("<%= numTxtTotlAmnt.ClientID %>").value = (parseFloat(gross) - parseFloat(disc) + parseFloat(tax)).toFixed(2);

                }, 10);


                setTimeout(function () {
                    document.getElementById("<%= txtBalance.ClientID%>").value = ((parseFloat(gross) - parseFloat(disc) + parseFloat(tax)) - parseFloat(paydamount)).toFixed(2);
                }, 10);


            }
            else {
                if (gross < 0) {
                }
                else if (gross > 0) {
                }
                else {
                    gross = 0;
                }
                if (disc > 0) {
                }
                else if (disc < 0) {
                }
                else {
                    disc = 0;
                }

                if (tax > 0) {
                }
                else {
                    tax = 0;
                }

                if ((totalamount < 0) && (disc < 0)) {
                    setTimeout(function () {

                        document.getElementById("<%= numTxtTotlAmnt.ClientID %>").value = (parseFloat(gross) - parseFloat(disc) + parseFloat(tax)).toFixed(2);

                    }, 10);
                }
                else if ((totalamount > 0) && (disc < 0)) {
                    setTimeout(function () {

                        document.getElementById("<%= numTxtTotlAmnt.ClientID %>").value = (parseFloat(gross) + parseFloat(disc) - parseFloat(tax)).toFixed(2);

                        }, 10);
                    }
                    else if ((totalamount < 0) && (disc > 0)) {
                        setTimeout(function () {

                            document.getElementById("<%= numTxtTotlAmnt.ClientID %>").value = (parseFloat(gross) + parseFloat(disc) - parseFloat(tax)).toFixed(2);

                    }, 10);
                }
                else if (totalamount > 0) {
                    setTimeout(function () {

                        document.getElementById("<%= numTxtTotlAmnt.ClientID %>").value = (parseFloat(gross) - parseFloat(disc) + parseFloat(tax)).toFixed(2);

                    }, 10);
                }
                else {
                    totalamount = 0;
                }

    if ((paydamount > 0) && (totalamount < 0)) {
        setTimeout(function () {
            document.getElementById("<%= txtBalance.ClientID%>").value = ((parseFloat(gross) + parseFloat(disc) - parseFloat(tax)) + parseFloat(paydamount)).toFixed(2);
        }, 10);
    }
    else if ((paydamount > 0) && (totalamount > 0)) {
        setTimeout(function () {
            document.getElementById("<%= txtBalance.ClientID%>").value = ((parseFloat(gross) - parseFloat(disc) + parseFloat(tax)) - parseFloat(paydamount)).toFixed(2);
        }, 10);
    }
    else {
        paydamount = 0;
    }
}
}
function ProductSelected(source, eventArgs) {
    var skuDetail = eventArgs.get_text();

    document.getElementById("<%=drpSkus.ClientID %>").value = skuDetail;

    SearchProduct();
}
function SearchProduct() {

    var unitprice = $('#<%=drpSkus.ClientID %> option:selected').text();

    unitprice = unitprice.substring(unitprice.indexOf(':') + 1);

    //skuDetail = skuDetail.substring(0, skuDetail.indexOf(':'));

    document.getElementById("<%=txtskuPrice.ClientID%>").value = unitprice;
    //  document.getElementById("<%= txtskuQty.ClientID %>").focus();
}
        function ValidateForm() {
            var str;

            str = document.getElementById('<%=txtskuQty.ClientID%>').value;
            if (str == null || str.length == 0) {
                alert('Must Enter Quantity');
                return false;
            }

            return true;
        }



        function SetFocusTocashRecived(e) {
            var key = e.charCode ? e.charCode : e.keyCode ? e.keyCode : 0;
            if (key == 13) {
                e.preventDefault();
                CalculateNetAndBalance();
                setTimeout(function () { document.getElementById("<%= numtxtTotalExtraDiscnt.ClientID %>").focus(); }, 10);

            }
        }

        function SetFocusTocode(e) {

            onlyNumbers(this, e);
            if (e.keyCode == 13) {
                document.getElementById("<%= drpSkus.ClientID %>").focus();
        }
        if (document.getElementById("<%= btnToggleMode.ClientID %>").value == 'SALE MODE') {
                if (document.getElementById("<%= txtskuQty.ClientID %>").value == '-') {

                alert('- is not allowed in sale mode!');
                document.getElementById("<%= txtskuQty.ClientID %>").value = '';
                }
            }
        }
        function CalculateDiscount(e) {
            var key = e.charCode ? e.charCode : e.keyCode ? e.keyCode : 0;
            if (key == 13) {

                e.preventDefault();
                CalculateNetAndBalance();
                //setTimeout(function () { document.getElementById("= txtAuthorisedBy.ClientID %>").focus(); }, 10);
            }
        }

        function FocusToCash(e) {
            var key = e.charCode ? e.charCode : e.keyCode ? e.keyCode : 0;
            if (key == 13) {
                e.preventDefault();
                CalculateNetAndBalance();
                setTimeout(function () { document.getElementById("<%= txtCashReceived.ClientID %>").focus(); }, 10);

        }
    }

    function CalculateBalance(e) {
        var key = e.charCode ? e.charCode : e.keyCode ? e.keyCode : 0;
        if (key == 13) {
            e.preventDefault();
            CalculateNetAndBalance();
            setTimeout(function () { document.getElementById("<%= btnSaveOrder.ClientID %>").focus(); }, 10);
        }
    }

    </script>
    <form runat="server" id="mainForm">


        <asp:ScriptManager ID="MainScriptManager" runat="server" />


        <asp:UpdatePanel ID="upSaleReport" runat="server">
            <ContentTemplate>
                <asp:Panel ID="pnlSaleReport" runat="server" Visible="false" Style="margin-top: 50px;"
                    ScrollBars="Auto" Height="100% ">
                    <div class="employee-infomation">
                        <div class="modal-dialog">
                            <div class="modal-content">
                                <div class="modal-header">
                                    <h1 class="modal-title" id="H3">
                                        <span></span>Sale Report</h1>
                                </div>
                                <div class="modal-body">

                                    <div class="row">
                                        <div class="col-md-5 padding-5">
                                            <label>
                                                <span class="fa fa-caret-right rgt_cart"></span>From Date</label>
                                            <asp:TextBox ID="txtstartDate" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                        <div class="col-md-1 padding-calender">
                                            <asp:ImageButton ID="ibnstartDate" runat="server" Width="16px" ImageUrl="~/App_Themes/Granite/Images/date.gif"></asp:ImageButton>
                                            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtstartDate"
                                                PopupButtonID="ibnstartDate" Format="dd-MMM-yyyy" PopupPosition="BottomRight"
                                                OnClientShown="calendarShown">
                                            </cc1:CalendarExtender>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-5 padding-5">
                                            <label>
                                                <span class="fa fa-caret-right rgt_cart"></span>To Date</label>
                                            <asp:TextBox ID="txtEndDate" runat="server" CssClass="form-control" MaxLength="10"></asp:TextBox>
                                        </div>
                                        <div class="col-md-1  padding-calender">
                                            <asp:ImageButton ID="ibnEndDate" runat="server" Width="16px" ImageUrl="~/App_Themes/Granite/Images/date.gif"></asp:ImageButton>
                                            <cc1:CalendarExtender ID="CEEndDate" runat="server" TargetControlID="txtEndDate"
                                                OnClientShown="calendarShown" PopupButtonID="ibnEndDate" Format="dd-MMM-yyyy"
                                                PopupPosition="BottomRight">
                                            </cc1:CalendarExtender>
                                        </div>
                                    </div>
                                </div>
                                <div class="modal-footer">
                                    <asp:Button runat="server" ID="btnViewSalesReport" Text="View Pdf" CssClass="btn btn-primary"
                                        OnClick="btnViewSalesReport_Click" />
                                    <asp:Button runat="server" ID="btnSaleReportCancel" CssClass="btn btn-danger" Text="Close"
                                        OnClick="btnSaleReportCancel_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                </asp:Panel>
            </ContentTemplate>
            <Triggers>
                <asp:PostBackTrigger ControlID="btnViewSalesReport" />
            </Triggers>
        </asp:UpdatePanel>

        <asp:UpdatePanel ID="up_pnl1" runat="server">
            <ContentTemplate>


                <div style="z-index: 100001; left: 600px; width: 100px; position: absolute; top: 250px; height: 100px">
                    <asp:Panel ID="Panel21" runat="server">
                        <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="up_pnl1">
                            <ProgressTemplate>
                                <asp:ImageButton ID="ImageButton2" runat="server" Height="100px" ImageUrl="~/OrderPOS/images/ajax-loader1.gif"
                                    Width="100px" />
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                    </asp:Panel>
                </div>
                <div class="page-wrapper" id="mainPOS" runat="server">
                    <div class="container page-contents">
                        <div class="header_wrapper">
                            <div class="container">
                                <div class="header row">
                                    <div class="col-md-10 headercolor">
                                        <div class="logo">
                                            <%--  <img src="../OrderPOS/images/logo1.png" class="pull-left" alt="" />--%>
                                            <img src="../images/favicon2.ico" class="pull-left" alt="" />

                                            <span>SAMS</span>
                                        </div>
                                    </div>
                                    <div class="col-md-2 headercol" style="padding-top: 12px;">
                                        <div class="input-group">
                                            <div class="dropdown">
                                                <button id="dropdownMenu1">
                                                    Welcome:
                                                    <label id="lbluserlogin" runat="server" />
                                                    <label id="lblLoacation" runat="server" visible="false" />
                                                </button>
                                                <asp:LinkButton runat="server" ID="btnCancel" CssClass="btn btn-default"
                                                    Text="Exit" OnClick="btnCancel_Click">
                                                </asp:LinkButton>
                                            </div>
                                        </div>
                                    </div>

                                    <div style="display: none;">
                                        <asp:Button ID="btnToggleMode" class="btn-group btn-group-sm btn btn-default" runat="server"
                                            Text="SALE MODE" OnClick="btnToggleMode_Click" />
                                    </div>

                                </div>
                            </div>
                        </div>
                        <div class="">
                            <div class="header_wrapper">
                                <div class="container padding">
                                    <div class=" row second_bar color_bg">

                                        <div class="col-md-5 color">
                                            <div class="input-group">
                                                <div class="field_text">
                                                    CUSTOMER
                                                </div>
                                                <div class="dropdown open">
                                                    <asp:DropDownList ID="drpCustomer" runat="server"
                                                        CssClass="btn btn-default dropdown-toggle" data-toggle="dropdown">
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-1">
                                        </div>
                                        <div class="col-md-2 color">
                                            <div class="input-group">
                                                <div class="field_text">
                                                    PAYMENT MODE
                                                </div>
                                                <div style="margin-top: 6px;" align="center">
                                                    <asp:RadioButtonList ID="RblPayMode" runat="server" Font-Size="Medium"
                                                        RepeatDirection="Horizontal" class="control-label input-group"
                                                        OnSelectedIndexChanged="RblPayMode_SelectedIndexChanged" AutoPostBack="true">
                                                        <asp:ListItem Selected="True" Value="214">Cash</asp:ListItem>
                                                        <asp:ListItem Value="215">Credit</asp:ListItem>
                                                    </asp:RadioButtonList>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-1">
                                        </div>
                                        <div class="col-md-3">
                                            <nav class="navbar navbar-default" role="navigation">
                                                <div class="container-fluid">
                                            <div class="navbar-header">
                                            <button class="navbar-toggle" data-target="#bs-example-navbar-collapse-1" data-toggle="collapse"
                                                 type="button">
                                                <span class="sr-only">Toggle navigation</span>
                                                <span class="icon-bar"></span>
                                                <span class="icon-bar"></span>
                                                <span class="icon-bar"></span>
                                                </button>
                                            <div id="bs-example-navbar-collapse-1" class="collapse navbar-collapse">
                                            <ul class="nav navbar-nav">
                                               
                                          
                                            
                                                  <li>
                                         
                                                    <asp:LinkButton runat="server" ID="btnRePrint" OnClick="btnRePrint_Click" >RePrint</asp:LinkButton>
                                            </li>
                                                <li>
                                              <asp:LinkButton runat="server" ID="btn_exitprint" OnClick="btn_exitprint_Click"
                                                     Visible="false">Exit</asp:LinkButton>
                                            </li>
                                            </ul>
                                            </div>
                                            </div>
                                           </div>
                                        </div>
                                    </div>
                                    <!--seocnd_bar-->
                                </div>
                            </div>
                            <div class="container padding">
                                <div class="row body">
                                    <div class="col-md-9 ">
                                        <div class="col-md-12 padding_right">
                                            <div class="body_color">
                                                <div class="inter_body">
                                                    <div class="col-md-5 ">
                                                        <div class="input-group">
                                                            <div class="text">
                                                                SKU Description
                                                            </div>

                                                            <asp:DropDownList ID="drpSkus" runat="server" Width="100%"
                                                                CssClass="btn btn-default dropdown-toggle" onchange="SearchProduct();">
                                                            </asp:DropDownList>

                                                            <asp:HiddenField runat="server" ID="hfProduct" Value="0" />
                                                        </div>
                                                    </div>

                                                    <div class="col-md-2 ">
                                                        <div class="input-group">
                                                            <div class="text">
                                                                Quantity
                                                            </div>
                                                            <asp:TextBox ID="txtskuQty" onkeypress="SetFocusTocode(event)" onblur="CalculateNetAndBalance();"
                                                                class="form-control" runat="server" />
                                                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" FilterType="Custom"
                                                                ValidChars="-0123456789." TargetControlID="txtskuQty" />
                                                        </div>
                                                    </div>

                                                    <div class="col-md-2 ">
                                                        <div class="input-group">
                                                            <div class="text">
                                                                Unit Price
                                                            </div>
                                                            <asp:TextBox ID="txtskuPrice" class="form-control" runat="server" />
                                                        </div>
                                                    </div>

                                                    <div class="col-md-2 ">
                                                        <div class="input-group">
                                                            <div class="text">
                                                                Amount
                                                            </div>
                                                            <asp:TextBox ID="txtskuAmount" Enabled="False" class="form-control" Style="background: #733131;"
                                                                runat="server" />

                                                        </div>
                                                    </div>
                                                    <div class="col-md-1 ">
                                                        <div class="input-group">
                                                            <div class="text" style="color: #cd5c5c;">
                                                                ..................
                                                            </div>

                                                            <asp:LinkButton runat="server" ID="btnSave" Text="Add" ToolTip="Add Sku"
                                                                OnClick="btnSave_Click" class="btn btn-default btn-group" Width="100%"></asp:LinkButton>
                                                        </div>

                                                    </div>

                                                </div>
                                                <div class="col-md-12 textareaclass">
                                                    <div class="input-group">
                                                        <%--<textarea type="text" width="100%" cols="150" rows="10" class="form-control"></textarea>--%>
                                                        <asp:Panel ID="Panel2" runat="server" Height="228px" ScrollBars="Vertical" Width="100%"
                                                            CssClass="form-control">
                                                            <asp:Label ID="lblfound" ForeColor="Chocolate" runat="server"></asp:Label>
                                                            <asp:GridView ID="GrdPurchase" runat="server" BackColor="White" HorizontalAlign="Center"
                                                                AutoGenerateColumns="False" ShowHeader="False" OnRowDeleting="GrdPurchase_RowDeleting"
                                                                Width="100%" EnableModelValidation="True"
                                                                CssClass="table table-striped table-bordered table-hover table-condensed cf">
                                                                <Columns>
                                                                    <asp:BoundField DataField="SKU_ID" HeaderText="SKU_ID">
                                                                        <FooterStyle VerticalAlign="Middle" />
                                                                        <HeaderStyle CssClass="HidePanel" VerticalAlign="Middle"></HeaderStyle>
                                                                        <ItemStyle CssClass="HidePanel" VerticalAlign="Middle"></ItemStyle>
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="SKU_CODE" HeaderText="SKU Code">
                                                                        <FooterStyle VerticalAlign="Middle" />
                                                                        <HeaderStyle VerticalAlign="Middle" />
                                                                        <ItemStyle HorizontalAlign="Left" Width="128px"></ItemStyle>
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="SKU_NAME" HeaderText="SKU Name">
                                                                        <FooterStyle VerticalAlign="Middle" />
                                                                        <HeaderStyle VerticalAlign="Middle" />
                                                                        <ItemStyle HorizontalAlign="Left" Width="270px"></ItemStyle>
                                                                    </asp:BoundField>

                                                                    <asp:BoundField DataField="QUANTITY_UNIT" HeaderText="QUANTITY_UNIT">
                                                                        <ItemStyle HorizontalAlign="Left" Width="80px" />
                                                                    </asp:BoundField>

                                                                    <asp:BoundField DataField="UNIT_PRICE" HeaderText="PRICE" DataFormatString="{0:F2}">
                                                                        <ItemStyle HorizontalAlign="Right" Width="90px"></ItemStyle>
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="AMOUNT" HeaderText="Amount" DataFormatString="{0:F2}">
                                                                        <ItemStyle HorizontalAlign="Right" Width="65px"></ItemStyle>
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="NET_AMOUNT">
                                                                        <HeaderStyle CssClass="HidePanel"></HeaderStyle>
                                                                        <ItemStyle CssClass="HidePanel"></ItemStyle>
                                                                    </asp:BoundField>

                                                                    <asp:TemplateField HeaderText="Delete">
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="btnDelete" runat="server" BorderColor="Red" Text="Delete" CommandName="Delete"></asp:LinkButton>
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Center" Width="30px"></ItemStyle>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                            </asp:GridView>

                                                            <asp:GridView ID="GrdPrintInvoice" runat="server"
                                                                BackColor="White" HorizontalAlign="Center" AutoGenerateColumns="False"
                                                                Width="100%" OnRowDeleting="GrdPrintInvoice_RowDeleting"
                                                                OnRowDataBound="GrdPrintInvoice_RowDataBound" Visible="false"
                                                                CssClass="table table-striped table-bordered table-hover table-condensed cf">
                                                                <HeaderStyle HorizontalAlign="Left" BorderStyle="Solid" BackColor="Beige" Height="30px"
                                                                    VerticalAlign="Middle" Font-Bold="true" Font-Size="14px" />

                                                                <Columns>
                                                                    <asp:BoundField DataField="SALE_INVOICE_ID" HeaderText="Invoice Id">
                                                                        <FooterStyle VerticalAlign="Middle" />
                                                                        <ItemStyle HorizontalAlign="Left" Width="60px"></ItemStyle>
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="CUSTOMER" HeaderText="Customer">
                                                                        <FooterStyle VerticalAlign="Middle" />
                                                                        <ItemStyle HorizontalAlign="Left" Width="100px"></ItemStyle>
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="TOTAL_AMOUNT" HeaderText="Gross Sale" DataFormatString="{0:F2}">
                                                                        <ItemStyle HorizontalAlign="Left"
                                                                            Width="100px"></ItemStyle>
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="EXTRA_DISCOUNT_AMOUNT">
                                                                        <ItemStyle CssClass="HidePanel"></ItemStyle>
                                                                        <HeaderStyle CssClass="HidePanel"></HeaderStyle>
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="GST_AMOUNT">
                                                                        <ItemStyle CssClass="HidePanel"></ItemStyle>
                                                                        <HeaderStyle CssClass="HidePanel"></HeaderStyle>
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="STANDARD_DISCOUNT_AMOUNT" HeaderText="Cash Received" DataFormatString="{0:F2}">
                                                                        <ItemStyle HorizontalAlign="Left"
                                                                            Width="100px"></ItemStyle>
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="TOTAL_NET_AMOUNT" HeaderText="Net Amount" DataFormatString="{0:F2}">
                                                                        <ItemStyle HorizontalAlign="Left"
                                                                            Width="100px"></ItemStyle>
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="TYPE" HeaderText="Type" DataFormatString="{0:F2}">
                                                                        <ItemStyle HorizontalAlign="Left"
                                                                            ForeColor="brown" Width="80px"></ItemStyle>
                                                                    </asp:BoundField>
                                                                    <asp:TemplateField>
                                                                        <ItemStyle HorizontalAlign="Center"
                                                                            Width="20px"></ItemStyle>
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkbtn_print" runat="server" Text="Print" ForeColor="Blue" CommandName="Delete"></asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                                <RowStyle Height="25px" />
                                                            </asp:GridView>

                                                        </asp:Panel>
                                                    </div>
                                                </div>
                                                <div class="clearfix">
                                                </div>
                                            </div>
                                            <div class="bottom">
                                                <asp:LinkButton ID="lnkSaleReport" runat="server" OnClick="lnkSaleReport_Click">
                                            <div class="col-md-2 color_bottom1 margin">
                                            
                                           <div class="col-md-2">
                                                    </div>
                                                <img src="../OrderPOS/images/icon.png" class="img-responsive" alt="" />
                                                <h2>
                                                    SALE REPORT</h2>
                                                
                                            </div>
                                                </asp:LinkButton>
                                                <div class="col-md-10">
                                                </div>

                                                <div class="clearfix">
                                                </div>
                                            </div>
                                        </div>
                                        <!--12-->
                                    </div>
                                    <!--10-->
                                    <div class="aside col-md-3 ">
                                        <div class="col-md-12 ">
                                            <div class="col-md-12 ">
                                                <h4>Gross Sale</h4>
                                                <div class="input-group">
                                                    <input type="text" id="txtGrossAmount" value="0.00" readonly="readonly" runat="server"
                                                        class="form-control value" />
                                                </div>
                                            </div>
                                            <div class="col-md-6 " style="display: none;">
                                                <div class="input_padding">
                                                    <h4>Discount</h4>
                                                    <div class="input-group">
                                                        <input type="text" id="numtxtTotalExtraDiscnt" readonly="readonly" runat="server"
                                                            class="form-control" />
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-6 " style="display: none;">
                                                <h4>Authorize by</h4>
                                                <div class="input-group">
                                                    <input type="text" id="txtAuthorisedBy" class="form-control" runat="server" onkeypress="FocusToCash(event)" />
                                                </div>
                                            </div>
                                            <div class="col-md-12 " style="display: none;">
                                                <h4>Sale Tax</h4>
                                                <div class="input-group">
                                                    <input type="text" id="numTxtTotalGST" runat="server" class="form-control" />
                                                </div>
                                            </div>
                                            <div class="col-md-12 ">
                                                <h4>Cash Received</h4>
                                                <div class="input-group">
                                                    <asp:TextBox type="text" ID="txtCashReceived" onkeypress="CalculateBalance(event)"
                                                        onblur="CalculateNetAndBalance();" onkeyup="CalculateNetAndBalance();" runat="server" class="form-control" />
                                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server" FilterType="Custom"
                                                        ValidChars="0123456789." TargetControlID="txtCashReceived" />
                                                </div>
                                            </div>
                                            <div class="col-md-12 " style="display: none;">
                                                <h4>Net Amount</h4>
                                                <div class="input-group">
                                                    <input type="text" id="numTxtTotlAmnt" runat="server" class="form-control" />
                                                </div>
                                            </div>
                                            <div class="col-md-12 ">
                                                <h4>Balance</h4>
                                                <div class="input-group">
                                                    <asp:TextBox ID="txtBalance" type="text" class="form-control" runat="server"></asp:TextBox>
                                                </div>
                                            </div>

                                            <div class="col-md-12 ">
                                                <div class="payment">
                                                    <div class="btn-group">
                                                        <asp:LinkButton runat="server" class="btn btn-default btn-group btn-group-lg" ID="btnSaveOrder"
                                                            OnClick="btnSaveOrder_Click" Enabled="false" Text="SAVE">
                                                        </asp:LinkButton>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="col-md-12 ">
                                                <div class="void">
                                                    <div class="btn-group">
                                                        <asp:LinkButton ID="btnVoid" class="btn btn-default btn-group" runat="server" OnClick="btnVoid_Click"
                                                            Text="VOID">
                                                        </asp:LinkButton>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-12 ">
                                                <h4 style="color: #2a3542;">.</h4>
                                                <div class="input-group" style="color: #2a3542;">
                                                    <input id="TextBox1" type="text" style="color: #2a3542; background-color: #2a3542; border-color: #2a3542;"
                                                        class="form-control"></input>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-9">
                                        <div class="footer index">
                                            <div class="col-md-12 fast">
                                                <h1 class="copy2">FAST SERVICES</h1>
                                                <div class=" copy">
                                                    The Inteligent Solution <span class="pull-right">Copyright 2014 - All right Reserved</span>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
