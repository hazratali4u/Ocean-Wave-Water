using System;
using System.Data;
using System.Collections;
using System.Globalization;
using System.Web.UI;
using System.Web.UI.WebControls;
using SAMS.BusinessLayer.Classes;
using SAMS.Common.Classes;
using System.Collections.Generic;
using System.Drawing;


public partial class Forms_frmOrderPOS2 : System.Web.UI.Page
{
    #region Variables

    readonly DataControl _dc = new DataControl();
    readonly DistributorController _mDist = new DistributorController();
    readonly OrderEntryController _mOrderController = new OrderEntryController();
    readonly SKUPriceDetailController _pController = new SKUPriceDetailController();

    string mop;
    DataTable _purchaseSku;

    DataTable _psiDt;


    int _saleInvId;
    decimal _cashRcd;
    decimal _ttamount;
    decimal _ntamount;
    decimal _discouunt;

    private static int _rowId;
    private System.Drawing.Printing.PrintDocument _prnDocument;
    long _saleInvoiceId = 0;
    public int PrintType;
    private readonly Font _saleFont = new Font("Times New Roman", 8, FontStyle.Bold);
    private static string HirarchyNameQuiz;
    public static string CompanyPhonNmbr;
    // for Report:
    private int CurrentY;
    private int CurrentX;
    private int leftMargin;
    private int rightMargin;
    private int topMargin;
    private int bottomMargin;
    private int InvoiceWidth;
    private int InvoiceHeight;

    private bool ReadInvoice;

    private int XNoOfuntit;
    private int YNoOfUnit;

    // for Invoice Head:
    private string InvTitle;
    private string InvSubTitle1;
    private string InvSubTitle2;
    private string InvSubTitle3;
    private string InvSubTitle4;

    // Font and Color:------------------
    // Title Font
    private Font InvTitleFont = new Font("Times New Roman", 12, FontStyle.Bold);
    // Title Font height
    private int InvTitleHeight;
    // SubTitle Font
    private Font InvSubTitleFont = new Font("Times New Roman", 10, FontStyle.Regular);
    // SubTitle Font height
    private int InvSubTitleHeight;
    // Invoice Font
    private Font InvoiceFont = new Font("Times New Roman", 8, FontStyle.Regular);
    private Font InvoiceFont2 = new Font("Times New Roman", 6, FontStyle.Bold);
    private Font InvoiceFont3 = new Font("Times New Roman", 6, FontStyle.Bold);
    private Font InvoiceFont4 = new Font("Times New Roman", 7, FontStyle.Bold);
    // Invoice Font height
    private int InvoiceFontHeight;
    // Blue Color
    private readonly SolidBrush _blueBrush = new SolidBrush(Color.Blue);
    // Red Color
    private readonly SolidBrush _redBrush = new SolidBrush(Color.Red);
    // Black Color
    private readonly SolidBrush _blackBrush = new SolidBrush(Color.Black);


    #endregion
    
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!Page.IsPostBack)
        {
            try
            {
                LoadProduct();

                txtstartDate.Text = (DateTime.Parse(Session["CurrentWorkDate"].ToString())).ToString("dd-MMM-yyyy");
                txtEndDate.Text = (DateTime.Parse(Session["CurrentWorkDate"].ToString())).ToString("dd-MMM-yyyy");
                //lblCurrentWorkingDate.Text = (DateTime.Parse(Session["CurrentWorkDate"].ToString())).ToString("dd-MMM-yyyy");

                txtGrossAmount.Attributes.Add("readonly", "readonly");
                txtBalance.Attributes.Add("readonly", "readonly");

                LoadloginDetail();

                CreateTable();

                LoadCustomerData();

                drpSkus.Focus();

                
                txtskuQty.Text = "1";
              
               
            }
            catch (Exception eee)
            {
                eee.Message.ToString();
            }
        }
    }
  
    
     protected void Calculate()
    {
        try
        {

            decimal ObjGrossSales = 0;
            decimal ObjStandardDiscount = 0;
            
            decimal amount = 0;
            
            DataTable dt = new DataTable();

            dt = (DataTable)Session["PurchaseSKU"];

            foreach (DataRow dr in dt.Rows)
            {
                

                amount = Convert.ToDecimal(dr["AMOUNT"]);

            }
            if (dt.Rows.Count > 0)
            {

                #region Recalculate Products

                foreach (DataRow dr in dt.Rows)
                {
                  
                    ObjGrossSales += decimal.Parse(_dc.chkNull_0(dr["AMOUNT"].ToString()));
                 
                    decimal TempAmount = decimal.Parse(_dc.chkNull_0(dr["AMOUNT"].ToString()));

                    dr["NET_AMOUNT"] = TempAmount;
                  
                }

                #endregion
            }
            else
            {
                #region Reversecalulate Products
                if (amount > 0)
                {

                    foreach (DataRow dr in dt.Rows)
                    {
                        ObjGrossSales += decimal.Parse(_dc.chkNull_0(dr["AMOUNT"].ToString()));

                    }

                    ObjGrossSales = 0;

                    foreach (DataRow dr in dt.Rows)
                    {

                        decimal TempAmount = 0;


                        TempAmount = decimal.Parse(_dc.chkNull_0(dr["AMOUNT"].ToString()));
                        dr["NET_AMOUNT"] = (TempAmount);

                        ObjGrossSales += decimal.Parse(_dc.chkNull_0(dr["AMOUNT"].ToString()));
                    }
                }
                #endregion
            }
            #region Set Total Values
            txtGrossAmount.Value = Convert.ToString(Math.Round(ObjGrossSales, 2));

            if (ObjGrossSales != 0)
            {
                numtxtTotalExtraDiscnt.Value = Convert.ToString(Math.Round(ObjStandardDiscount, 2));
                
                numTxtTotlAmnt.Value = Convert.ToString(Math.Round(ObjGrossSales, 2));
                txtBalance.Text = (Math.Round(Convert.ToDecimal(_dc.chkNull_0(numTxtTotlAmnt.Value)) - (Convert.ToDecimal(_dc.chkNull_0(txtCashReceived.Text))), 2)).ToString();
            }
            else
            {

               
                numTxtTotlAmnt.Value = Convert.ToString(Math.Round(ObjGrossSales, 2));
                txtBalance.Text = (Math.Round(Convert.ToDecimal(_dc.chkNull_0(numTxtTotlAmnt.Value)) - (Convert.ToDecimal(_dc.chkNull_0(txtCashReceived.Text))), 2)).ToString();

            }

            #endregion

            btnSaveOrder.Enabled = true;
            if (RblPayMode.SelectedIndex != 1)
            {

              txtCashReceived.ReadOnly = false;

            }
            else
            {
                txtCashReceived.ReadOnly = true;

            }
        }
        catch (Exception eee)
        {
            eee.Message.ToString();
        }
    }


    private bool CheckDublicateSku()
    {
        _purchaseSku = (DataTable)Session["PurchaseSKU"];
        DataRow[] foundRows = _purchaseSku.Select("SKU_ID  = '" + drpSkus.SelectedValue + "'");
        if (foundRows.Length == 0)
        {
            return true;
        }
        return false;
    }
    private void EnableDisableController(bool cValue)
    {
        try
        {
            if (cValue != true) return;
            if (txtGrossAmount.Value == "") return;
            if (decimal.Parse(txtGrossAmount.Value) <= 0) return;
            drpCustomer.Enabled = true;

        }
        catch (Exception eee)
        {
            eee.Message.ToString();
        }
    }

    private void DisableControls()
    {
        drpCustomer.Enabled = false;
        txtCashReceived.Enabled = false;
        drpSkus.Enabled = false;
        btnSaveOrder.Enabled = false;
        btnRePrint.Enabled = false;
        GrdPrintInvoice.Visible = true;
        btn_exitprint.Visible = true;
        GrdPurchase.Visible = false;
    }
    private void EnableControls()
    {

        btn_exitprint.Visible = false;
        GrdPrintInvoice.Visible = false;
        GrdPurchase.Visible = true;
        txtskuQty.Text = "1";
        btnRePrint.Enabled = true;
        drpCustomer.Enabled = true;
        txtCashReceived.Enabled = true;
        drpSkus.Enabled = true;

    }


    #region Load Main

    private void LoadCustomerData()
    {

        CustomerDataController mController = new CustomerDataController();
        //var dtCustomer = mController.SelectPrincipalCustomer(Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue);
        DataTable dtCustomer = mController.SelectPrincipalCustomer(int.Parse(Session["DISTRIBUTOR_ID"].ToString()), Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue);

        clsWebFormUtil.FillDropDownList(drpCustomer, dtCustomer, "CUSTOMER_ID", "CUSTOMER_DETAIL", true);
        Session.Add("dtCustomer", dtCustomer);
    }

    private void LoadGird()
    {
        _purchaseSku = (DataTable)Session["PurchaseSKU"];
        GrdPurchase.DataSource = _purchaseSku;
        GrdPurchase.DataBind();
    }

    //Re-Print Grid
    private void LoadGridInvoices()
    {

        DataTable pi_dt = _mOrderController.SelectCustomerInvoicePrint(int.Parse(Session["DISTRIBUTOR_ID"].ToString()), Constants.IntNullValue, 0, DateTime.Parse(txtstartDate.Text), DateTime.Parse(txtstartDate.Text));
        GrdPrintInvoice.DataSource = pi_dt;
        GrdPrintInvoice.DataBind();

    }

    

    private void LoadloginDetail()
    {
        try
        {
            SAMSUserController userControl = new SAMSUserController();
            var dt = userControl.SelectSlashUser2(int.Parse(Session["UserId"].ToString()));

          //  lbllogintimedate.Text = DateTime.Now.ToString("dd-MMM-yyyy hh:mm:ss");//DateTime.Now.ToString("MM/dd/yyyy");

            lbluserlogin.InnerHtml = dt.Rows[0]["USER_NAME"].ToString();
            lblLoacation.InnerHtml = dt.Rows[0]["DISTRIBUTOR_NAME"].ToString();
            CompanyPhonNmbr = dt.Rows[0]["CONTACT_NUMBER"].ToString(); //Location Contact Number
            HirarchyNameQuiz = dt.Rows[0]["COMPANY_NAME"].ToString();

        }
        catch (Exception eee)
        {
            eee.Message.ToString();
        }
    }


    private void LoadProduct()
    {
        try
        {

            var dtProduct = _pController.SelectDataPrice(Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, int.Parse(Session["DISTRIBUTOR_ID"].ToString()), int.Parse(Session["UserId"].ToString()), Constants.IntNullValue, 1, DateTime.Parse(Session["CurrentWorkDate"].ToString()));
            //  hfProduct.Value = GetJson(dtProduct);

            clsWebFormUtil.FillDropDownList(drpSkus, dtProduct, "SKU_ID", "SkuPriceDetail", true);
            Session.Add("Dtsku_Price", dtProduct);
        }
        catch (Exception eee)
        {
            eee.Message.ToString();
        }
    }


    public string GetJson(DataTable dt)
    {
        System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
        List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
        Dictionary<string, object> row = null;

        foreach (DataRow dr in dt.Rows)
        {
            row = new Dictionary<string, object>();
            foreach (DataColumn col in dt.Columns)
            {
                row.Add(col.ColumnName, dr[col]);
            }
            rows.Add(row);
        }
        return serializer.Serialize(rows);
    }

    #endregion

    #region Click Main
    protected void btnSignOut_Click(object sender, EventArgs e)
    {
        Session.RemoveAll();
        Response.Redirect("../Login.aspx");

    }
    protected void btnToggleMode_Click(object sender, EventArgs e)
    {
        if (btnToggleMode.Text == "SALE MODE")
        {
            btnToggleMode.Text = "REFUND MODE";
            txtskuQty.Text = "-1";
            drpSkus.Focus();
        }
        else
        {
            btnToggleMode.Text = "SALE MODE";
            txtskuQty.Text = "1";
            drpSkus.Focus();

        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {

            decimal mTradePrice = decimal.Parse(_dc.chkNull_0(txtskuPrice.Text.ToString()));

            if (mTradePrice > 0)
            {
                decimal Quantity = decimal.Parse(_dc.chkNull_0(txtskuQty.Text));

                DataTable Dtsku_Price = (DataTable)Session["Dtsku_Price"];
                DataRow[] foundRows = Dtsku_Price.Select("SKU_ID  = '" + drpSkus.SelectedItem.Value + "'");

                _purchaseSku = (DataTable)Session["PurchaseSKU"];

                if (CheckDublicateSku())
                {
                    DataRow dr = _purchaseSku.NewRow();
                    dr["SKU_ID"] = foundRows[0]["SKU_ID"];
                    dr["SKU_Code"] = foundRows[0]["SKU_CODE"];
                    dr["SKU_Name"] = foundRows[0]["SKU_NAME"];

                    dr["QUANTITY_UNIT"] = Quantity;

                    dr["UNIT_PRICE"] = mTradePrice.ToString();

                    dr["AMOUNT"] = mTradePrice * decimal.Parse(dr["QUANTITY_UNIT"].ToString());
                    dr["NET_AMOUNT"] = 0;

                    _purchaseSku.Rows.Add(dr);
                }
                else
                {
                    _purchaseSku = (DataTable)Session["PurchaseSKU"];
                    DataRow[] foundRowsexist = _purchaseSku.Select("SKU_ID  = '" + drpSkus.SelectedItem.Value + "'");//QUANTITY_UNIT


                    foundRowsexist[0]["QUANTITY_UNIT"] = decimal.Parse(foundRowsexist[0]["QUANTITY_UNIT"].ToString()) + Quantity;
                    foundRowsexist[0]["AMOUNT"] = decimal.Parse(foundRowsexist[0]["AMOUNT"].ToString()) + (mTradePrice * Quantity);
                }

                Session.Add("PurchaseSKU", _purchaseSku);
                EnableDisableController(false);
                LoadGird();
                ClearAll12();
                btnSaveOrder.Enabled = true;
                var scriptManager = ScriptManager.GetCurrent(Page);
                if (scriptManager != null) scriptManager.SetFocus(drpSkus);
                Calculate();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "msg", "alert('Please enter Price');", true);
            }
        }
        catch (Exception)
        {
            throw;
        }
        var current = ScriptManager.GetCurrent(Page);
        if (current != null) current.SetFocus(drpSkus);
    }
   
    protected void btnVoid_Click(object sender, EventArgs e)
    {

       
        ClearAll();
        ClearMasterAll();
        btnToggleMode.Enabled = true;
        drpSkus.Focus();
       
    }

    protected void btnSaveOrder_Click(object sender, EventArgs e)
    {
        try
        {
            if (decimal.Parse(_dc.chkNull_0(txtBalance.Text)) <= 0 && RblPayMode.SelectedValue == Convert.ToString(Constants.Cash_Order_Id))
            {
                string manualId = btnToggleMode.Text != "SALE MODE" ? "1" : "2";

                _purchaseSku = (DataTable)Session["PurchaseSKU"];

                if (_purchaseSku.Rows.Count > 0)
                {
                    decimal totalAmount = decimal.Parse(_dc.chkNull_0(txtGrossAmount.Value));
                    
                        _saleInvoiceId = _mOrderController.Add_Invoice(int.Parse(Session["DISTRIBUTOR_ID"].ToString())
                            , long.Parse(drpCustomer.SelectedValue), decimal.Parse(_dc.chkNull_0(txtGrossAmount.Value))
                            , 0, decimal.Parse(_dc.chkNull_0(txtCashReceived.Text))
                            , 0, totalAmount, 0, int.Parse(RblPayMode.SelectedValue.ToString()),
                             _purchaseSku, int.Parse(Session["UserId"].ToString()), decimal.Parse(_dc.chkNull_0(txtCashReceived.Text)),
                             DateTime.Parse(Session["CurrentWorkDate"].ToString()), 0, 0, 0, "");

                    if (_saleInvoiceId == -2 || _saleInvoiceId == -1)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "msg", "alert('Insertion Failed!!!.');", true);
                    }
                    else
                    {

                        if (System.Configuration.ConfigurationManager.AppSettings["IsPrint"] == "1")
                        {
                            PrintReport(1);
                        }

                        ClearMasterAll();

                        btnToggleMode.Enabled = true;
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "msg", "alert('No product added');", true);
                }
                drpSkus.Focus();
            }
            else
            {
                txtCashReceived.Focus();
                if (decimal.Parse(_dc.chkNull_0(txtCashReceived.Text)) > 0)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "msg", "alert('Please enter complete Cash');", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "msg", "alert('Please enter Cash');", true);
                }
            }
        }
        catch (Exception exp)
        {
            ClearMasterAll();

            btnToggleMode.Enabled = true;
            ExceptionPublisher.PublishException(exp);
            throw exp;
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Session.Remove("PurchaseSKU");

        Session.Remove("psi_dt");
        Response.Redirect("Home.aspx?");
    }
    #endregion

    #region Main Grid OPerations

    private void CreateTable()
    {
        _purchaseSku = new DataTable();

        _purchaseSku.Columns.Add("SKU_ID", typeof(int));
        _purchaseSku.Columns.Add("SKU_Code", typeof(string));
        _purchaseSku.Columns.Add("SKU_Name", typeof(string));
        _purchaseSku.Columns.Add("UNIT_PRICE", typeof(decimal));
        _purchaseSku.Columns.Add("QUANTITY_UNIT", typeof(decimal));
        _purchaseSku.Columns.Add("AMOUNT", typeof(decimal));
        _purchaseSku.Columns.Add("NET_AMOUNT", typeof(decimal));
        _purchaseSku.Columns.Add("TRADE_PRICE", typeof(string));

        Session.Add("PurchaseSKU", _purchaseSku);
    } 
   

   
    protected void GrdPurchase_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        _purchaseSku = (DataTable)Session["PurchaseSKU"];

        var skuId = GrdPurchase.Rows[e.RowIndex].Cells[0].Text;



        _purchaseSku.Rows.RemoveAt(e.RowIndex);

        Session.Add("PurchaseSKU", _purchaseSku);

        LoadGird();
        
        Calculate();
        btnSaveOrder.Enabled = false;
        if (GrdPurchase.Rows.Count <= 0)
        {
            txtCashReceived.Text = "";
            txtBalance.Text = "0.00";
        }
        drpSkus.Focus();
    }


    protected void GrdPrintInvoice_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        _saleInvId = Convert.ToInt32(GrdPrintInvoice.Rows[e.RowIndex].Cells[0].Text);

        var psiDt = _mOrderController.SelectCustomerInvoiceDetail(int.Parse(Session["DISTRIBUTOR_ID"].ToString()), Constants.IntNullValue, 1, _saleInvId, DateTime.Parse(txtstartDate.Text), DateTime.Parse(txtstartDate.Text));

        Session.Add("psi_dt", psiDt);

        if (_saleInvId == -2 && _saleInvId == -1) return;

        if (System.Configuration.ConfigurationManager.AppSettings["IsPrint"] == "1")
        {
            PrintReport(1);
        }
    }

    protected void GrdPrintInvoice_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.BackColor = e.Row.Cells[7].Text == "Sales Refund" ? Color.Lavender : Color.White;
    }


    #endregion


    protected void RblPayMode_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RblPayMode.SelectedIndex == 1)
        {
            txtCashReceived.Text = "";
            txtBalance.Text = "";
            txtCashReceived.ReadOnly = true;
        }
        else
        {
            txtCashReceived.ReadOnly = false;

            var scriptManager = ScriptManager.GetCurrent(Page);
            if (scriptManager != null) scriptManager.SetFocus(drpSkus);
        }
    }

    #region PrintINvoice

    private void PrintReport(int type)
    {
        try
        {
            PrintType = type;
            _prnDocument = new System.Drawing.Printing.PrintDocument();
            _prnDocument.PrinterSettings.PrinterName = System.Configuration.ConfigurationManager.AppSettings["PrinterName"];
            // The Event of 'PrintPage'
            _prnDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(prnDocument_PrintPage);
            _prnDocument.Print();
        }
        catch (Exception e)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "msg", "alert('" + e.Message + "');", true);
        }
    }

    private void prnDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
    {
        leftMargin = (int)e.MarginBounds.Left;//100
        rightMargin = (int)e.MarginBounds.Right;//215
        topMargin = (int)e.MarginBounds.Top;//100
        topMargin = 1;
        bottomMargin = (int)e.MarginBounds.Bottom;//1069
        InvoiceWidth = (int)e.MarginBounds.Width;//115
        InvoiceHeight = (int)e.MarginBounds.Height;//969

        if (PrintType != 4)
        {
            SetInvoiceHead(e.Graphics); // Draw Invoice Head
            SetInvoiceData(e.Graphics, e); // Draw Invoice Data
        }
        else if (PrintType == 4)
        {
            SetSaleReportHead(e.Graphics);
        }

        ReadInvoice = true;
    }

    private void SetInvoiceHead(Graphics g)
    {
        ReadInvoiceHead();

        if (Session["psi_dt"] != null)
        {
            _psiDt = (DataTable)Session["psi_dt"];

            if (_psiDt.Rows.Count <= 0) return;
            foreach (DataRow dr in _psiDt.Rows)
            {
                CurrentY = topMargin;
                CurrentX = leftMargin;
                const int imageHeight = 0;
                InvTitleHeight = (int)(InvTitleFont.GetHeight(g));
                InvSubTitleHeight = (int)(InvSubTitleFont.GetHeight(g));

                // Get Titles Length:
                int lenInvTitle = (int)g.MeasureString(InvTitle, InvTitleFont).Width;
                int lenInvSubTitle1 = (int)g.MeasureString(InvSubTitle1, InvSubTitleFont).Width;
                int lenInvSubTitle2 = (int)g.MeasureString(InvSubTitle2, InvSubTitleFont).Width;
                int lenInvSubTitle3 = (int)g.MeasureString(InvSubTitle3, InvSubTitleFont).Width;
                int lenInvSubTitle4 = (int)g.MeasureString(InvSubTitle4, InvSubTitleFont).Width;
                // Set Titles Left:
                int xInvTitle = CurrentX + (InvoiceWidth - lenInvTitle) / 2;
                int xInvSubTitle1 = CurrentX + (InvoiceWidth - lenInvSubTitle1) / 2;
                int xInvSubTitle2 = CurrentX + (InvoiceWidth - lenInvSubTitle2) / 2;
                int xInvSubTitle3 = CurrentX + (InvoiceWidth - lenInvSubTitle3) / 2;
                int xInvSubTitle4 = CurrentX + (InvoiceWidth - lenInvSubTitle4) / 2;

                // Draw Invoice Head:
                if (InvTitle != "")
                {
                    CurrentY = CurrentY + imageHeight;
                    g.DrawString(InvTitle, InvTitleFont, _blueBrush, xInvTitle, CurrentY);
                }
                if (InvSubTitle1 != "")
                {
                    CurrentY = CurrentY + InvTitleHeight;
                    g.DrawString(InvSubTitle1, InvSubTitleFont, _blueBrush, xInvSubTitle1, CurrentY);
                }
                if (InvSubTitle2 != "")
                {
                    CurrentY = CurrentY + InvSubTitleHeight;
                    g.DrawString(InvSubTitle2, InvSubTitleFont, _blueBrush, xInvSubTitle2, CurrentY);
                }
                long idToPrint = 0;
                var invoiceCreditHeading = "";

                var invType = dr["InvoiceType"].ToString();

                if (invType == "SaleInvoice")
                {
                    idToPrint = _saleInvId;
                    InvSubTitle3 = "Sale Invoice";//sale mode
                    invoiceCreditHeading = "INV # :";
                }
                else
                {
                    idToPrint = _saleInvId;
                    InvSubTitle3 = "Refund Invoice";
                    invoiceCreditHeading = "INV # :";
                }

                if (InvSubTitle3 != "")
                {
                    CurrentY = CurrentY + InvSubTitleHeight + 10;
                    g.DrawString(InvSubTitle3, InvSubTitleFont, _blueBrush, 10, CurrentY);
                }
                //For Payment Mode
                InvSubTitle4 = "MOP:";

                var MOP = dr["MOP"].ToString();
                if (MOP == "Cash")
                {
                    g.DrawString(InvSubTitle4 + MOP, InvSubTitleFont, _blueBrush, 160, CurrentY);
                }
                else if (MOP == "Credit")
                {
                    g.DrawString(InvSubTitle4 + MOP, InvSubTitleFont, _blueBrush, 160, CurrentY);
                }
                else
                {
                    g.DrawString(InvSubTitle4 + MOP, InvSubTitleFont, _blueBrush, 160, CurrentY);
                }
                // Draw line:
                CurrentY = CurrentY + InvSubTitleHeight + 8;
                g.DrawLine(new Pen(Brushes.Black, 2), 10, CurrentY, 300, CurrentY);

                CurrentY = CurrentY + 10;
                //   g.DrawString("DATE:" + DateTime.Now.ToString("dd-MMM-yyyy hh:mm:ss"), InvoiceFont, BlueBrush, 10, CurrentY);
                g.DrawString("DATE:" + Convert.ToDateTime(Session["Currentworkdate"]).ToString("dd-MMM-yyyy") + ' ' + DateTime.Now.ToString("hh:mm:ss"), InvoiceFont, _blueBrush, 10, CurrentY);

                string units = dr["UNITS"].ToString();
                g.DrawString("NO OF UNITS: ", InvoiceFont, _blueBrush, 160, CurrentY);

                XNoOfuntit = (int)g.MeasureString("NO OF UNITS:  ", InvoiceFont).Width + 160;
                YNoOfUnit = CurrentY;
                CurrentY = CurrentY + 15;
                g.DrawString(invoiceCreditHeading + idToPrint, InvoiceFont, _blueBrush, 10, CurrentY);
                g.DrawString("CASHIER: " + lbluserlogin.InnerHtml, InvoiceFont, _blueBrush, 160, CurrentY);

                CurrentY = CurrentY + 15;
                g.DrawLine(new Pen(Brushes.Black, 2), 10, CurrentY, 300, CurrentY);//
                CurrentY = CurrentY + 10;



                g.DrawString("CUSTOMER: " + dr["CUSTOMER"].ToString(), InvoiceFont, _blueBrush, 10, CurrentY);
                CurrentY = CurrentY + 15;
                g.DrawLine(new Pen(Brushes.Black, 2), 10, CurrentY, 300, CurrentY);

                break;
            }
        }
        else
        {
            CurrentY = topMargin;
            CurrentX = leftMargin;
            const int imageHeight = 0;
            InvTitleHeight = (int)(InvTitleFont.GetHeight(g));
            InvSubTitleHeight = (int)(InvSubTitleFont.GetHeight(g));

            // Get Titles Length:
            int lenInvTitle = (int)g.MeasureString(InvTitle, InvTitleFont).Width;
            int lenInvSubTitle1 = (int)g.MeasureString(InvSubTitle1, InvSubTitleFont).Width;
            int lenInvSubTitle2 = (int)g.MeasureString(InvSubTitle2, InvSubTitleFont).Width;
            int lenInvSubTitle3 = (int)g.MeasureString(InvSubTitle3, InvSubTitleFont).Width;
            int lenInvSubTitle4 = (int)g.MeasureString(InvSubTitle4, InvSubTitleFont).Width;
            // Set Titles Left:
            int xInvTitle = CurrentX + (InvoiceWidth - lenInvTitle) / 2;
            int xInvSubTitle1 = CurrentX + (InvoiceWidth - lenInvSubTitle1) / 2;
            int xInvSubTitle2 = CurrentX + (InvoiceWidth - lenInvSubTitle2) / 2;
            int xInvSubTitle4 = CurrentX + (InvoiceWidth - lenInvSubTitle4) / 2;

            // Draw Invoice Head:
            if (InvTitle != "")
            {
                CurrentY = CurrentY + imageHeight;
                g.DrawString(InvTitle, InvTitleFont, _blueBrush, xInvTitle, CurrentY);
            }
            if (InvSubTitle1 != "")
            {
                CurrentY = CurrentY + InvTitleHeight;
                g.DrawString(InvSubTitle1, InvSubTitleFont, _blueBrush, xInvSubTitle1, CurrentY);
            }
            if (InvSubTitle2 != "")
            {
                CurrentY = CurrentY + InvSubTitleHeight;
                g.DrawString(InvSubTitle2, InvSubTitleFont, _blueBrush, xInvSubTitle2, CurrentY);
            }
            long idToPrint = 0;
            string invoiceCreditHeading = "";
            if (btnToggleMode.Text == "SALE MODE")
            {
                idToPrint = _saleInvoiceId;
                InvSubTitle3 = "Sale Invoice";//slae mode
                invoiceCreditHeading = "INV # :";

            }

            else
            {
                //refund mode
                idToPrint = _saleInvoiceId;
                InvSubTitle3 = "Refund Invoice";
                invoiceCreditHeading = "INV # : ";
            }
            if (InvSubTitle3 != "")
            {
                CurrentY = CurrentY + InvSubTitleHeight + 10;
                g.DrawString(InvSubTitle3, InvSubTitleFont, _blueBrush, 10, CurrentY);
            }
            //For Payment Mode
            InvSubTitle4 = "MOP: ";

            g.DrawString(InvSubTitle4 + RblPayMode.SelectedItem.Text, InvSubTitleFont, _blueBrush, 160, CurrentY);

            // Draw line:
            CurrentY = CurrentY + InvSubTitleHeight + 8;
            g.DrawLine(new Pen(Brushes.Black, 2), 10, CurrentY, 300, CurrentY);

            CurrentY = CurrentY + 10;
            g.DrawString("DATE:" + Convert.ToDateTime(Session["Currentworkdate"]).ToString("dd-MMM-yyyy") + ' ' + DateTime.Now.ToString("hh:mm:ss"), InvoiceFont, _blueBrush, 10, CurrentY);
            g.DrawString("NO OF UNITS: ", InvoiceFont, _blueBrush, 160, CurrentY);
            XNoOfuntit = (int)g.MeasureString("NO OF UNITS:  ", InvoiceFont).Width + 160;
            YNoOfUnit = CurrentY;
            CurrentY = CurrentY + 15;

            g.DrawString(invoiceCreditHeading + idToPrint, InvoiceFont, _blueBrush, 10, CurrentY);
            g.DrawString("CASHIER: " + lbluserlogin.InnerHtml, InvoiceFont, _blueBrush, 160, CurrentY);

            CurrentY = CurrentY + 15;
            g.DrawLine(new Pen(Brushes.Black, 2), 10, CurrentY, 300, CurrentY);//
            CurrentY = CurrentY + 10;

            g.DrawString("CUSTOMER: " + drpCustomer.SelectedItem.Text, InvoiceFont, _blueBrush, 10, CurrentY);
            CurrentY = CurrentY + 15;
            g.DrawLine(new Pen(Brushes.Black, 2), 10, CurrentY, 300, CurrentY);
        }
    }

    private void SetSaleReportHead(Graphics g)
    {
        var dt = _mOrderController.SelectSaleReportDetail(int.Parse(Session["DISTRIBUTOR_ID"].ToString()), Constants.IntNullValue, DateTime.Parse(txtstartDate.Text), DateTime.Parse(txtEndDate.Text));

        decimal totalGrossSale = 0;
        decimal totalDiscount = 0;
        decimal totalGst = 0;
        decimal totalNetAMount = 0;
        decimal totalCredit = 0;
        totalGrossSale = Math.Round(decimal.Parse(dt.Rows[0]["TOTAL_AMOUNT"].ToString()), 2);
        totalDiscount = Math.Round(decimal.Parse(dt.Rows[0]["DISCOUNT"].ToString()), 2);
        totalGst = Math.Round(decimal.Parse(dt.Rows[0]["GST_AMOUNT"].ToString()), 2);
        totalNetAMount = Math.Round(decimal.Parse(dt.Rows[0]["NET_TOTAL"].ToString()), 2);
        totalCredit = Math.Round(decimal.Parse(dt.Rows[0]["CREDIT_AMOUNT"].ToString()), 2);
        ReadInvoiceHead();

        CurrentY = topMargin;
        CurrentX = leftMargin;
        const int imageHeight = 0;
        InvTitleHeight = (int)(InvTitleFont.GetHeight(g));
        InvSubTitleHeight = (int)(InvSubTitleFont.GetHeight(g));

        // Get Titles Length:
        int lenInvTitle = (int)g.MeasureString(InvTitle, InvTitleFont).Width;
        int lenInvSubTitle1 = (int)g.MeasureString(InvSubTitle1, InvSubTitleFont).Width;
        int lenInvSubTitle2 = (int)g.MeasureString(InvSubTitle2, InvSubTitleFont).Width;
        int lenInvSubTitle3 = (int)g.MeasureString(InvSubTitle3, InvSubTitleFont).Width;
        // Set Titles Left:
        int xInvTitle = CurrentX + (InvoiceWidth - lenInvTitle) / 2;
        int xInvSubTitle1 = CurrentX + (InvoiceWidth - lenInvSubTitle1) / 2;
        int xInvSubTitle2 = CurrentX + (InvoiceWidth - lenInvSubTitle2) / 2;
        int xInvSubTitle3 = CurrentX + (InvoiceWidth - lenInvSubTitle3) / 2;

        // Draw Invoice Head:
        if (InvTitle != "")
        {
            CurrentY = CurrentY + imageHeight;
            g.DrawString(InvTitle, InvTitleFont, _blueBrush, xInvTitle, CurrentY);
        }
        if (InvSubTitle1 != "")
        {
            CurrentY = CurrentY + InvTitleHeight;
            g.DrawString(InvSubTitle1, InvSubTitleFont, _blueBrush, xInvSubTitle1, CurrentY);
        }
        if (InvSubTitle2 != "")
        {
            CurrentY = CurrentY + InvSubTitleHeight;
            g.DrawString(InvSubTitle2, InvSubTitleFont, _blueBrush, xInvSubTitle2, CurrentY);
        }
        InvSubTitle3 = "SALES REPORT";//
        CurrentY = CurrentY + InvSubTitleHeight + 10;
        g.DrawString(InvSubTitle3, InvSubTitleFont, _blueBrush, 100, CurrentY);

        CurrentY = CurrentY + InvSubTitleHeight + 15;
        g.DrawString("From  :" + txtstartDate.Text + "   To  :" + txtEndDate.Text, InvSubTitleFont, _blueBrush, 10, CurrentY);

        // Draw line:

        // totalGrossSale=totalGrossSale-totalDiscount-totalGST;
        CurrentY = CurrentY + InvSubTitleHeight + 8;
        g.DrawLine(new Pen(Brushes.Black, 2), 10, CurrentY, 300, CurrentY);

        CurrentY = CurrentY + 20;
        g.DrawString("GROSS SALE  : ", _saleFont, _blueBrush, 30, CurrentY);
        g.DrawString(totalGrossSale.ToString(), _saleFont, _blueBrush, 200, CurrentY);
        CurrentY = CurrentY + 30;

        g.DrawString("DISCOUNT  : ", _saleFont, _blueBrush, 30, CurrentY);
        g.DrawString(totalDiscount.ToString(), _saleFont, _blueBrush, 200, CurrentY);

        CurrentY = CurrentY + 30;
        g.DrawString("GST  : ", _saleFont, _blueBrush, 30, CurrentY);
        g.DrawString(totalGst.ToString(), _saleFont, _blueBrush, 200, CurrentY);

        CurrentY = CurrentY + 30;
        g.DrawString("CREDIT  : ", _saleFont, _blueBrush, 30, CurrentY);
        g.DrawString(totalCredit.ToString(), _saleFont, _blueBrush, 200, CurrentY);

        CurrentY = CurrentY + 30;
        g.DrawString("NET SALE  : ", _saleFont, _blueBrush, 30, CurrentY);
        g.DrawString(totalNetAMount.ToString(), _saleFont, _blueBrush, 200, CurrentY);

        CurrentY = CurrentY + 30;
        g.DrawString("CASH RECIVED  : ", _saleFont, _blueBrush, 30, CurrentY);
        g.DrawString(totalNetAMount.ToString(), _saleFont, _blueBrush, 200, CurrentY);
        CurrentY = CurrentY + 30;

        g.DrawLine(new Pen(Brushes.Black, 2), 10, CurrentY, 300, CurrentY);
        CurrentY = CurrentY + 15;
        // g.DrawString("User  :" + _dc.chkNull_0(ddsalesForce.SelectedItem.ToString()), SaleFont, BlueBrush, 10, CurrentY);
        g.DrawString("Date : " + DateTime.Now.ToString("dd-MMM-yyyy"), _saleFont, _blueBrush, 200, CurrentY);
        CurrentY = CurrentY + 40;
        g.DrawString("POWERD BY:  www.fastservices.pk.", InvoiceFont3, _blackBrush, 10, CurrentY);
    }

    private void ReadInvoiceHead()
    {
        //Titles and Image of invoice:
        InvTitle = HirarchyNameQuiz;
        InvSubTitle1 = lblLoacation.InnerHtml;
        InvSubTitle2 = "PH#:  " + CompanyPhonNmbr; //lblphone.Text; 
        // InvSubTitle3 = lblphone.Text;
        //InvImage = Application.StartupPath + @"\Images\" + "InvPic.jpg";
    }

    private void SetInvoiceData(Graphics g, System.Drawing.Printing.PrintPageEventArgs e)
    {// Set Invoice Table:
        string fieldValue = "";
        decimal fieldValue2 = 0;
        int currentRecord = 0;


        // Set Table Head:
        const int xProductId = 10; //leftMargin;
                                   //  CurrentY = CurrentY + 20;//InvoiceFontHeight;
                                   //  g.DrawLine(new Pen(Brushes.Black), 10, CurrentY, 300, CurrentY);
        CurrentY = CurrentY + 10;//InvoiceFontHeight;
        g.DrawString("DESCRIPTION", InvoiceFont, _blueBrush, xProductId, CurrentY);

        int xProductName = xProductId + (int)g.MeasureString("DESCRIPTION", InvoiceFont).Width + 65;
        g.DrawString("QTY", InvoiceFont, _blueBrush, xProductName, CurrentY);


        int xUnitPrice = xProductName + (int)g.MeasureString("QTY", InvoiceFont).Width + 10;
        g.DrawString("PRICE", InvoiceFont, _blueBrush, xUnitPrice, CurrentY);

        int xQuantity = xUnitPrice + (int)g.MeasureString("PRICE", InvoiceFont).Width + 10;
        g.DrawString("TOTAL", InvoiceFont, _blueBrush, xQuantity, CurrentY);



        // Set Invoice Table:
        CurrentY = CurrentY + 20;//InvoiceFontHeight + 8;
        g.DrawLine(new Pen(Brushes.Black, 2), 10, CurrentY, 300, CurrentY);
        CurrentY = CurrentY + 10;//InvoiceFontHeight + 8;
        //while (CurrentRecord < RecordsPerPage)
        decimal numberOfUnit = 0;

        if (Session["psi_dt"] != null)
        {
            _psiDt = (DataTable)Session["psi_dt"];

            if (_psiDt.Rows.Count > 0)
            {
                foreach (DataRow dr in _psiDt.Rows)
                {

                    fieldValue = String.Format("{0:0}", dr["QUANTITY_UNIT"]);  //quantity
                    //For Refund Check
                    //decimal qty = 0;
                    //qty = Convert.ToDecimal(fieldValue);

                    g.DrawString(fieldValue, InvoiceFont, _blackBrush, xProductName + 4, CurrentY);
                    numberOfUnit += Convert.ToDecimal(dr["QUANTITY_UNIT"].ToString());
                    // CurrentY = CurrentY + 12;
                    // if (qty > 0)
                    //{
                    fieldValue = dr["SKU_NAME"].ToString();// name
                    if (fieldValue.Length > 30)
                        fieldValue = fieldValue.Remove(30, fieldValue.Length - 30);
                    g.DrawString(fieldValue, InvoiceFont2, _blackBrush, xProductId, CurrentY);
                    //}
                    //else
                    //{
                    //    fieldValue = dr["SKU_NAME"] + " " + "(Refund)";// name
                    //    if (fieldValue.Length > 30)
                    //        fieldValue = fieldValue.Remove(30, fieldValue.Length - 30);
                    //    g.DrawString(fieldValue, InvoiceFont2, _blackBrush, xProductId, CurrentY);
                    //}
                    decimal untPrice = Convert.ToDecimal(string.Format("{0:0.00}", dr["UNIT_PRICE"]));

                    // FieldValue2 = Math.Ceiling(Convert.ToDecimal((unt_price)));//Price
                    fieldValue2 = Convert.ToDecimal(untPrice);//Price

                    fieldValue = Convert.ToString(fieldValue2);
                    g.DrawString(fieldValue, InvoiceFont4, _blackBrush, xUnitPrice, CurrentY);

                    untPrice = Convert.ToDecimal(string.Format("{0:0.00}", dr["AMOUNT"]));

                    // FieldValue2 = Math.Ceiling(Convert.ToDecimal((unt_price)));//Total
                    fieldValue2 = Convert.ToDecimal(untPrice);//Total

                    fieldValue = Convert.ToString(fieldValue2);
                    g.DrawString(fieldValue, InvoiceFont4, _blackBrush, xQuantity, CurrentY);

                    CurrentY = CurrentY + 15;
                    // g.DrawLine(new Pen(Brushes.Black, 1), 10, CurrentY, 300, CurrentY);
                    //CurrentY = CurrentY + 10;
                    currentRecord++;

                    _cashRcd = Convert.ToDecimal(dr["CASH_RECIEVED"]);//CAsh Rec
                    _ttamount = Convert.ToDecimal(dr["TOTAL_AMOUNT"]);//Sub-total
                    _ntamount = Convert.ToDecimal(dr["TOTAL_NET_AMOUNT"]);//Net total
                }

            }
            if (currentRecord > 0)
            {
                if (numberOfUnit < 0)
                {
                    numberOfUnit = numberOfUnit * (-1);
                }

                g.DrawString(numberOfUnit.ToString(CultureInfo.InvariantCulture), InvoiceFont, _blackBrush, XNoOfuntit, YNoOfUnit);
                SetPrintInvoiceTotal(g);
                g.Dispose();
            }
        }
        else
        {
            foreach (GridViewRow dr in GrdPurchase.Rows)
            {

                fieldValue = dr.Cells[2].Text.ToUpper();// name
                if (fieldValue.Length > 30)
                    fieldValue = fieldValue.Remove(30, fieldValue.Length - 30);
                g.DrawString(fieldValue, InvoiceFont2, _blackBrush, xProductId, CurrentY);

                fieldValue = String.Format("{0:0}", dr.Cells[3].Text);  //quantity

                g.DrawString(fieldValue, InvoiceFont, _blackBrush, xProductName + 4, CurrentY);
                numberOfUnit += Convert.ToDecimal(dr.Cells[3].Text);

                fieldValue2 = Convert.ToDecimal(_dc.chkNull_0(dr.Cells[4].Text));//price

                fieldValue = Convert.ToString(fieldValue2);
                g.DrawString(fieldValue, InvoiceFont4, _blackBrush, xUnitPrice, CurrentY);

                fieldValue2 = Convert.ToDecimal(_dc.chkNull_0(dr.Cells[5].Text));//total

                fieldValue = Convert.ToString(fieldValue2);
                g.DrawString(fieldValue, InvoiceFont4, _blackBrush, xQuantity, CurrentY);

                CurrentY = CurrentY + 15;

                currentRecord++;

            }

            if (currentRecord > 0)
            {
                if (numberOfUnit < 0)
                {
                    numberOfUnit = numberOfUnit * (-1);
                }
                g.DrawString(numberOfUnit.ToString(), InvoiceFont, _blackBrush, XNoOfuntit, YNoOfUnit);
                SetInvoiceTotal(g);
                g.Dispose();
            }
        }
    }

    private void SetInvoiceTotal(Graphics g)
    {

        string invoiceValue = "";
        decimal invoiceValue2 = 0;
        decimal netAmount = 0;
        decimal totalAmount = decimal.Parse(_dc.chkNull_0(txtGrossAmount.Value));

        decimal balance = 0;

        netAmount = totalAmount;

        decimal resAmount = decimal.Parse(_dc.chkNull_0(txtCashReceived.Text));

        if (netAmount < 0)
        {
            balance = netAmount + resAmount;
        }
        else
        {
            balance = netAmount - resAmount;
        }

        g.DrawLine(new Pen(Brushes.Black, 2), 10, CurrentY, 300, CurrentY);
        CurrentY = CurrentY + 5;
        g.DrawString("GROSS AMOUNT:", InvoiceFont, _redBrush, 50, CurrentY);
        invoiceValue2 = Math.Ceiling(Convert.ToDecimal(_dc.chkNull_0(txtGrossAmount.Value)));
        invoiceValue = String.Format("{0:0.00}", invoiceValue2);
        g.DrawString(invoiceValue, InvoiceFont, _blackBrush, 200, CurrentY);
        CurrentY = CurrentY + 15;//InvoiceFontHeight;


        if (PrintType != 2)
        {
            CurrentY = CurrentY + 5;//InvoiceFontHeight;
            g.DrawString("CASH-PAID-IN:", InvoiceFont, _redBrush, 50, CurrentY);
            invoiceValue2 = Math.Ceiling(Convert.ToDecimal(_dc.chkNull_0(txtCashReceived.Text)));
            invoiceValue = String.Format("{0:0.00}", invoiceValue2);
            //int xInvoiceValue = xRightEdg - (int)g.MeasureString(InvoiceValue, InvoiceFont).Width;
            g.DrawString(invoiceValue, InvoiceFont, _blackBrush, 200, CurrentY);
            CurrentY = CurrentY + 15;//InvoiceFontHeight;
            if (RblPayMode.SelectedValue != "217")
            {
                CurrentY = CurrentY + 5;//InvoiceFontHeight;
                g.DrawString("BALANCE:", InvoiceFont, _redBrush, 50, CurrentY);
                invoiceValue2 = Math.Ceiling(Convert.ToDecimal(_dc.chkNull_0(balance.ToString())));
                invoiceValue = String.Format("{0:0.00}", invoiceValue2);
                g.DrawString(invoiceValue, InvoiceFont, _blackBrush, 200, CurrentY);

                CurrentY = CurrentY + 15;//InvoiceFontHeight;
            }
        }
        CurrentY = CurrentY + 25;//InvoiceFontHeight;

        g.DrawString("THANKS FOR YOUR VISIT.", InvoiceFont, _blackBrush, 80, CurrentY);
        CurrentY = CurrentY + 20;//InvoiceFontHeight;

        g.DrawString("POWERD BY:  www.fastservices.pk.", InvoiceFont3, _blackBrush, 10, CurrentY);
    }

    //For RePrint Invoice
    private void SetPrintInvoiceTotal(Graphics g)
    {
        g.DrawLine(new Pen(Brushes.Black, 2), 10, CurrentY, 300, CurrentY);
        CurrentY = CurrentY + 5;
        g.DrawString("GROSS AMOUNT:", InvoiceFont, _redBrush, 50, CurrentY);
        string invoiceValue = String.Format("{0:0.00}", _ttamount);
        g.DrawString(invoiceValue, InvoiceFont, _blackBrush, 200, CurrentY);
        CurrentY = CurrentY + 20;//InvoiceFontHeight;
                                 //g.DrawLine(new Pen(Brushes.Black, 2), 10, CurrentY, 300, CurrentY);

        if (PrintType != 2)
        {
            CurrentY = CurrentY + 5;//InvoiceFontHeight;
            g.DrawString("CASH-PAID-IN:", InvoiceFont, _redBrush, 50, CurrentY);
            invoiceValue = String.Format("{0:0.00}", _cashRcd);
            g.DrawString(invoiceValue, InvoiceFont, _blackBrush, 200, CurrentY);
            CurrentY = CurrentY + 20;//InvoiceFontHeight;
            if (mop != "Cash & Credit Card")
            {
                CurrentY = CurrentY + 5;//InvoiceFontHeight;
                g.DrawString("BALANCE:", InvoiceFont, _redBrush, 50, CurrentY);
                if (_ntamount > 0)
                {
                    invoiceValue = String.Format("{0:0.00}", _ntamount - _cashRcd);
                }

                else
                {
                    invoiceValue = String.Format("{0:0.00}", _ntamount + _cashRcd);
                }

                g.DrawString(invoiceValue, InvoiceFont, _blackBrush, 200, CurrentY);
                CurrentY = CurrentY + 20;//InvoiceFontHeight;
            }
        }
        CurrentY = CurrentY + 25;//InvoiceFontHeight;

        g.DrawString("THANKS FOR YOUR VISIT.", InvoiceFont, _blackBrush, 80, CurrentY);
        CurrentY = CurrentY + 20;//InvoiceFontHeight;

        g.DrawString("POWERD BY:  www.fastservices.pk.", InvoiceFont3, _blackBrush, 10, CurrentY);

        Session.Remove("psi_dt");
    }

    #endregion

    #region Clear Main

    private void ClearAll12()
    {
        try
        {
            // txtskuCode.Text = "";

            txtskuPrice.Text = "";
            txtskuQty.Text = btnToggleMode.Text != "SALE MODE" ? "-1" : "1";
            btnSave.ToolTip = "Add Sku";
            btnSaveOrder.Enabled = true;
            //    txtskuCode.Enabled = true;

            drpSkus.Focus();

        }
        catch (Exception eee)
        {
            eee.Message.ToString();
        }

    }

    private void ClearAll()
    {
        try
        {
            txtskuPrice.Text = "";
            txtskuQty.Text = btnToggleMode.Text != "SALE MODE" ? "-1" : "1";
            txtCashReceived.Text = "";

            txtBalance.Text = "";

            btnSave.ToolTip = "Add Sku";
            btnSaveOrder.Enabled = true;
            drpSkus.Enabled = true;
            drpSkus.Focus();

        }
        catch (Exception eee)
        {
            eee.Message.ToString();
        }

    }

    /// <summary>
    /// Clears All Controls
    /// </summary>
    private void ClearMasterAll()
    {
        try
        {
            EnableDisableController(true);
            Session.Remove("PurchaseSKU");

            Session.Remove("psi_dt");

            btnSaveOrder.Enabled = true;
            CreateTable();


            LoadGird();
            txtGrossAmount.Value = "";
           
            numTxtTotlAmnt.Value = "";
            txtCashReceived.Text = "";

            txtBalance.Text = "";

            _rowId = 0;



        }
        catch (Exception eee)
        {
            eee.Message.ToString();
        }
    }
    #endregion

    #region Sale Report


    protected void btnViewSalesReport_Click(object sender, EventArgs e)
    {


        try
        {


            SAMS.BusinessLayer.Reports.crpSalesReportPos crpReport = new SAMS.BusinessLayer.Reports.crpSalesReportPos();

            DataSet ds = null;

            ds = _mOrderController.SelectSaleReport(int.Parse(Session["DISTRIBUTOR_ID"].ToString()), int.Parse(Session["UserId"].ToString()), DateTime.Parse(txtstartDate.Text), DateTime.Parse(txtEndDate.Text + " 23:59:59"));

            crpReport.SetDataSource(ds);
            crpReport.Refresh();

            crpReport.SetParameterValue("COMPANY_NAME", HirarchyNameQuiz);
            crpReport.SetParameterValue("FROM_DATE", DateTime.Parse(txtstartDate.Text));
            crpReport.SetParameterValue("TO_DATE", DateTime.Parse(txtEndDate.Text));
            crpReport.SetParameterValue("USER_NAME", lbluserlogin.InnerHtml);
            crpReport.SetParameterValue("LOCATION", lblLoacation.InnerHtml);
            crpReport.SetParameterValue("PHONE_NUMBER", CompanyPhonNmbr);

            Session.Add("CrpReport", crpReport);
            Session.Add("ReportType", 0);
            const string url = "'Default.aspx'";
            const string script = "<script language='JavaScript' type='text/javascript'> window.open(" + url + ",\"Link\",\"toolbar=0,location=0,directories=0,status=0,menubar=0,scrollbars=1,resizable=1,width=800,height=600,left=10,top=10\");</script>";
            Type cstype = GetType();
            ClientScriptManager cs = Page.ClientScript;
            cs.RegisterStartupScript(cstype, "OpenWindow", script);
        }
        catch (Exception ex)
        {
            ex.ToString();
        }

    }


    protected void lnkSaleReport_Click(object sender, EventArgs e)
    {

        mainPOS.Attributes.Add("style", "display:none;");
        pnlSaleReport.Visible = true;
    }
    protected void btnSaleReportCancel_Click(object sender, EventArgs e)
    {
        pnlSaleReport.Visible = false;
        mainPOS.Attributes.Add("style", "display:block;");

    }

    #endregion
    protected void btnRePrint_Click(object sender, EventArgs e)
    {

        DisableControls();

        LoadGridInvoices();


    }
    protected void btn_exitprint_Click(object sender, EventArgs e)
    {

        EnableControls();
        Session.Remove("psi_dt");
        GrdPrintInvoice.DataSource = null;
        GrdPrintInvoice.DataBind();

    }
}