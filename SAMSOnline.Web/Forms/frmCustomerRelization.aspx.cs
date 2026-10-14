using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using SAMS.BusinessLayer.Classes;
using SAMS.Common.Classes;


public partial class Forms_frmCustomerRelization : System.Web.UI.Page
{
    private void LoadDistributor()
    {
        DistributorController DController = new DistributorController();
        DataTable dt = DController.SelectDistributorInfo(Constants.IntNullValue, int.Parse(this.Session["UserId"].ToString()), int.Parse(this.Session["CompanyId"].ToString()));
        clsWebFormUtil.FillDropDownList(this.drpDistributor, dt, 0, 2, true);
    }
    private void LoadArea()
    {
        if (DrpAccountType.SelectedIndex == 1)
        {
            DrpRoute.Items.Clear();
            DrpRoute.Enabled = false;  
        }
        else
        {
            DistributorAreaController mController = new DistributorAreaController();
            DataTable dt = mController.SelectDist_Area(Constants.LongNullValue, Constants.DateNullValue, Constants.DateNullValue, int.Parse(drpDistributor.SelectedValue.ToString()), Constants.IntNullValue, null, null);
            clsWebFormUtil.FillDropDownList(DrpRoute, dt, 0, 6, true);
            DrpRoute.Enabled = true;  
        }
    }
    private void LoadData()
    {
        if (drpDistributor.Items.Count > 0)
        {
            CustomerDataController mController = new CustomerDataController();

            if (DrpAccountType.SelectedIndex == 0 ||  DrpAccountType.SelectedIndex == 3 || DrpAccountType.SelectedIndex == 4)
            {
                DataTable dtCredit = mController.SelectCreditPendingInvoice(int.Parse(drpDistributor.SelectedValue.ToString()), int.Parse(DrpPrincipal.SelectedValue.ToString()), Constants.LongNullValue,int.Parse(DrpRoute.SelectedValue.ToString()));
                clsWebFormUtil.FillDropDownList(this.DrpCustomer, dtCredit, 0, 1, true);
                                               
            }
            else if (DrpAccountType.SelectedIndex == 1 || DrpAccountType.SelectedIndex == 5 || DrpAccountType.SelectedIndex == 7)
            {
                DataTable dt = mController.SelectPrincipalCustomer(int.Parse(drpDistributor.SelectedValue.ToString()), int.Parse(DrpRoute.SelectedValue.ToString()), Constants.IntNullValue, int.Parse(DrpPrincipal.SelectedValue.ToString()));
                clsWebFormUtil.FillDropDownList(this.DrpCustomer, dt, 0, 4, true);
            }
        }
    }
    private void ClearAll()
    {
        txtChequeNo.Text = "";
        txtAmount.Text = "";
        txtRemarks.Text = "";
        txtSlipNo.Text = "";
    }
    private void LoadGrid()
    {
        if (drpDistributor.Items.Count > 0)
        {
            LedgerController LController = new LedgerController();
            DataTable dt = LController.SelectBankCashTransction(int.Parse(drpDistributor.SelectedValue.ToString()), Constants.IntNullValue, int.Parse(DrpAccountType.SelectedValue.ToString()),
                DateTime.Parse(this.Session["CurrentWorkDate"].ToString()), DateTime.Parse(this.Session["CurrentWorkDate"].ToString()));
            GrdOrder.DataSource = dt;
            GrdOrder.DataBind();
        }
    }
    private void LoadAccountHead()
    {
        if (DrpAccountType.SelectedIndex == 0 )
        {
            AccountHeadController mAccountController = new AccountHeadController();
            DataTable dt = mAccountController.SelectAccountHead(Constants.AC_AccountHeadId, long.Parse(SAMS.Common.Classes.Configuration.CashDefaultType));
            clsWebFormUtil.FillDropDownList(DrpAccountDetail, dt, 0, 4, true);
        }
        else if (DrpAccountType.SelectedIndex == 2)
        {
            DrpAccountDetail.Items.Clear();
            DrpAccountDetail.Items.Add(new ListItem("Tax Deducted By Parties", "127"));
        }
        else
        {
            AccountHeadController mAccountController = new AccountHeadController();
            DataTable dt = mAccountController.SelectAccountHead(Constants.AC_AccountHeadId, long.Parse(SAMS.Common.Classes.Configuration.BankDefaultType));
            clsWebFormUtil.FillDropDownList(DrpAccountDetail, dt, 0, 4, true);
        }

    }
    private void LoadPrincipal()
    {
        SKUPriceDetailController PController = new SKUPriceDetailController();
        DataTable m_dt = PController.SelectDataPrice(Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, int.Parse(this.Session["UserId"].ToString()), Constants.IntNullValue, 0, DateTime.Parse(this.Session["CurrentWorkDate"].ToString()));
        clsWebFormUtil.FillDropDownList(this.DrpPrincipal, m_dt, 0, 1, true);
    }
    private void ChequeRealization()
    {
        LedgerController LController = new LedgerController();
        string MaxDocumentId = LController.SelectLedgerMaxDocumentId(Constants.Bank_Voucher, int.Parse(drpDistributor.SelectedValue.ToString()));
        decimal OfferAmount = decimal.Parse(txtAmount.Text);
        foreach (GridViewRow dr in GrdCredit.Rows)
        {
            CheckBox chRelized = (CheckBox)dr.Cells[0].FindControl("ChbIsAssigned");
            if (chRelized.Checked == true)
            {

                if (decimal.Parse(dr.Cells[3].Text) >= OfferAmount)
                {
                    LController.PostingCash_Bank_Account(Constants.Bank_Voucher, long.Parse(MaxDocumentId), long.Parse(SAMS.Common.Classes.Configuration.AccountReceivable), int.Parse(drpDistributor.SelectedValue.ToString()), 0, OfferAmount,
                    DateTime.Parse(this.Session["CurrentWorkDate"].ToString()), txtRemarks.Text, DateTime.Now, int.Parse(DrpCustomer.SelectedValue.ToString()), int.Parse(DrpPrincipal.SelectedValue.ToString()),
                    txtChequeNo.Text, int.Parse(this.Session["UserId"].ToString()), long.Parse(dr.Cells[5].Text), Constants.Document_Invoice, txtSlipNo.Text, Constants.DateNullValue, 18, DrpDeliveryMan.SelectedValue.ToString());

                    LController.PostingCash_Bank_Account(Constants.Bank_Voucher, long.Parse(MaxDocumentId), long.Parse(DrpAccountDetail.SelectedValue.ToString()), int.Parse(drpDistributor.SelectedValue.ToString()), OfferAmount, 0,
                    DateTime.Parse(this.Session["CurrentWorkDate"].ToString()), txtRemarks.Text, DateTime.Now, int.Parse(DrpCustomer.SelectedValue.ToString()), int.Parse(DrpPrincipal.SelectedValue.ToString()),
                    txtChequeNo.Text, int.Parse(this.Session["UserId"].ToString()), long.Parse(dr.Cells[5].Text), Constants.Document_Invoice, txtSlipNo.Text, Constants.DateNullValue, 18, DrpDeliveryMan.SelectedValue.ToString());

                    OfferAmount = decimal.Parse(dr.Cells[3].Text) - OfferAmount;
                    LController.UpdateSaleInvoice(long.Parse(dr.Cells[5].Text), int.Parse(drpDistributor.SelectedValue.ToString()), OfferAmount);
                    break;
                }
                else if (decimal.Parse(dr.Cells[3].Text) <= OfferAmount)
                {
                    LController.PostingCash_Bank_Account(Constants.Bank_Voucher, long.Parse(MaxDocumentId), long.Parse(SAMS.Common.Classes.Configuration.AccountReceivable), int.Parse(drpDistributor.SelectedValue.ToString()), 0, decimal.Parse(dr.Cells[3].Text),
                    DateTime.Parse(this.Session["CurrentWorkDate"].ToString()), txtRemarks.Text, DateTime.Now, int.Parse(DrpCustomer.SelectedValue.ToString()), int.Parse(DrpPrincipal.SelectedValue.ToString()),
                    txtChequeNo.Text, int.Parse(this.Session["UserId"].ToString()), long.Parse(dr.Cells[5].Text), Constants.Document_Invoice, txtSlipNo.Text, Constants.DateNullValue, 18, DrpDeliveryMan.SelectedValue.ToString());

                    LController.PostingCash_Bank_Account(Constants.Bank_Voucher, long.Parse(MaxDocumentId), long.Parse(DrpAccountDetail.SelectedValue.ToString()), int.Parse(drpDistributor.SelectedValue.ToString()), decimal.Parse(dr.Cells[3].Text), 0,
                    DateTime.Parse(this.Session["CurrentWorkDate"].ToString()), txtRemarks.Text, DateTime.Now, int.Parse(DrpCustomer.SelectedValue.ToString()), int.Parse(DrpPrincipal.SelectedValue.ToString()),
                    txtChequeNo.Text, int.Parse(this.Session["UserId"].ToString()), long.Parse(dr.Cells[5].Text), Constants.Document_Invoice, txtSlipNo.Text, Constants.DateNullValue, 18, DrpDeliveryMan.SelectedValue.ToString());

                    OfferAmount = OfferAmount - decimal.Parse(dr.Cells[3].Text);
                    LController.UpdateSaleInvoice(long.Parse(dr.Cells[5].Text), int.Parse(drpDistributor.SelectedValue.ToString()), 0);
                }
            }
        }

    }
    private void CashRealization()
    {
        LedgerController LController = new LedgerController();
        string MaxDocumentId = LController.SelectLedgerMaxDocumentId(Constants.Cash_Voucher, int.Parse(drpDistributor.SelectedValue.ToString()));
        decimal OfferAmount = decimal.Parse(txtAmount.Text);
        foreach (GridViewRow dr in GrdCredit.Rows)
        {
            CheckBox chRelized = (CheckBox)dr.Cells[0].FindControl("ChbIsAssigned");
            if (chRelized.Checked == true)
            {

                if (decimal.Parse(dr.Cells[3].Text) >= OfferAmount)
                {
                    LController.PostingCash_Bank_Account(Constants.Cash_Voucher, long.Parse(MaxDocumentId), long.Parse(SAMS.Common.Classes.Configuration.AccountReceivable), int.Parse(drpDistributor.SelectedValue.ToString()), 0, OfferAmount,
                    DateTime.Parse(this.Session["CurrentWorkDate"].ToString()), txtRemarks.Text, DateTime.Now, int.Parse(DrpCustomer.SelectedValue.ToString()), int.Parse(DrpPrincipal.SelectedValue.ToString()),
                    txtChequeNo.Text, int.Parse(this.Session["UserId"].ToString()), long.Parse(dr.Cells[5].Text), Constants.Document_Invoice, txtSlipNo.Text, Constants.DateNullValue, 19, DrpDeliveryMan.SelectedValue.ToString());

                    LController.PostingCash_Bank_Account(Constants.Cash_Voucher, long.Parse(MaxDocumentId), long.Parse(DrpAccountDetail.SelectedValue.ToString()), int.Parse(drpDistributor.SelectedValue.ToString()), OfferAmount, 0,
                    DateTime.Parse(this.Session["CurrentWorkDate"].ToString()), txtRemarks.Text, DateTime.Now, int.Parse(DrpCustomer.SelectedValue.ToString()), int.Parse(DrpPrincipal.SelectedValue.ToString()),
                    txtChequeNo.Text, int.Parse(this.Session["UserId"].ToString()), long.Parse(dr.Cells[5].Text), Constants.Document_Invoice, txtSlipNo.Text, Constants.DateNullValue, 19, DrpDeliveryMan.SelectedValue.ToString());

                    OfferAmount = decimal.Parse(dr.Cells[3].Text) - OfferAmount;
                    LController.UpdateSaleInvoice(long.Parse(dr.Cells[5].Text), int.Parse(drpDistributor.SelectedValue.ToString()), OfferAmount);
                    break;
                }
                else if (decimal.Parse(dr.Cells[3].Text) <= OfferAmount)
                {
                    LController.PostingCash_Bank_Account(Constants.Cash_Voucher, long.Parse(MaxDocumentId), long.Parse(SAMS.Common.Classes.Configuration.AccountReceivable), int.Parse(drpDistributor.SelectedValue.ToString()), 0, decimal.Parse(dr.Cells[3].Text),
                    DateTime.Parse(this.Session["CurrentWorkDate"].ToString()), txtRemarks.Text, DateTime.Now, int.Parse(DrpCustomer.SelectedValue.ToString()), int.Parse(DrpPrincipal.SelectedValue.ToString()),
                    txtChequeNo.Text, int.Parse(this.Session["UserId"].ToString()), long.Parse(dr.Cells[5].Text), Constants.Document_Invoice, txtSlipNo.Text, Constants.DateNullValue, 19, DrpDeliveryMan.SelectedValue.ToString());

                    LController.PostingCash_Bank_Account(Constants.Cash_Voucher, long.Parse(MaxDocumentId), long.Parse(DrpAccountDetail.SelectedValue.ToString()), int.Parse(drpDistributor.SelectedValue.ToString()), decimal.Parse(dr.Cells[3].Text), 0,
                    DateTime.Parse(this.Session["CurrentWorkDate"].ToString()), txtRemarks.Text, DateTime.Now, int.Parse(DrpCustomer.SelectedValue.ToString()), int.Parse(DrpPrincipal.SelectedValue.ToString()),
                    txtChequeNo.Text, int.Parse(this.Session["UserId"].ToString()), long.Parse(dr.Cells[5].Text), Constants.Document_Invoice, txtSlipNo.Text, Constants.DateNullValue, 19, DrpDeliveryMan.SelectedValue.ToString());

                    OfferAmount = OfferAmount - decimal.Parse(dr.Cells[3].Text);
                    LController.UpdateSaleInvoice(long.Parse(dr.Cells[5].Text), int.Parse(drpDistributor.SelectedValue.ToString()), 0);
                }
            }
        }

    }
    private void ChequeAdvance()
    {
        LedgerController LController = new LedgerController();
        CustomerDataController CDC = new CustomerDataController();
        string MaxDocumentId = LController.SelectLedgerMaxDocumentId(Constants.Bank_Voucher, int.Parse(drpDistributor.SelectedValue.ToString()));

        LController.PostingCash_Bank_Account(Constants.Bank_Voucher, long.Parse(MaxDocumentId), long.Parse(SAMS.Common.Classes.Configuration.AccountReceivable), int.Parse(drpDistributor.SelectedValue.ToString()), 0, decimal.Parse(txtAmount.Text),
            DateTime.Parse(this.Session["CurrentWorkDate"].ToString()), txtRemarks.Text, DateTime.Now, int.Parse(DrpCustomer.SelectedValue.ToString()), int.Parse(DrpPrincipal.SelectedValue.ToString()),
            txtChequeNo.Text, int.Parse(this.Session["UserId"].ToString()), Constants.LongNullValue, Constants.IntNullValue, txtSlipNo.Text, Constants.DateNullValue, 20, "");

        LController.PostingCash_Bank_Account(Constants.Bank_Voucher, long.Parse(MaxDocumentId), long.Parse(DrpAccountDetail.SelectedValue.ToString()), int.Parse(drpDistributor.SelectedValue.ToString()), decimal.Parse(txtAmount.Text), 0,
            DateTime.Parse(this.Session["CurrentWorkDate"].ToString()), txtRemarks.Text, DateTime.Now, int.Parse(DrpCustomer.SelectedValue.ToString()), int.Parse(DrpPrincipal.SelectedValue.ToString()),
            txtChequeNo.Text, int.Parse(this.Session["UserId"].ToString()), Constants.LongNullValue, Constants.IntNullValue, txtSlipNo.Text, Constants.DateNullValue, 20, "");

    }
    private void CashAdvance()
    {
        LedgerController LController = new LedgerController();
        CustomerDataController CDC = new CustomerDataController();
        string MaxDocumentId = LController.SelectLedgerMaxDocumentId(Constants.Cash_Voucher, int.Parse(drpDistributor.SelectedValue.ToString()));
        
        LController.PostingCash_Bank_Account(Constants.Cash_Voucher, long.Parse(MaxDocumentId), long.Parse(DrpAccountDetail.SelectedValue.ToString()), int.Parse(drpDistributor.SelectedValue.ToString()), decimal.Parse(txtAmount.Text), 0,
            DateTime.Parse(this.Session["CurrentWorkDate"].ToString()), txtRemarks.Text, DateTime.Now,-1, int.Parse(DrpPrincipal.SelectedValue.ToString()),
            txtChequeNo.Text, int.Parse(this.Session["UserId"].ToString()), 0, 0, null, Constants.DateNullValue, 21,DrpDeliveryMan.SelectedValue.ToString());

    }
    private void BankDeposit()
    {
        LedgerController LController = new LedgerController();
        string MaxDocumentId = LController.SelectLedgerMaxDocumentId(Constants.Bank_Voucher, int.Parse(drpDistributor.SelectedValue.ToString()));

        LController.PostingCash_Bank_Account(Constants.Bank_Voucher, long.Parse(MaxDocumentId), long.Parse(SAMS.Common.Classes.Configuration.CashDefault), int.Parse(drpDistributor.SelectedValue.ToString()), 0, decimal.Parse(txtAmount.Text),
                 DateTime.Parse(this.Session["CurrentWorkDate"].ToString()), txtRemarks.Text, DateTime.Now, Constants.IntNullValue, int.Parse(DrpPrincipal.SelectedValue.ToString()),
                 txtChequeNo.Text, int.Parse(this.Session["UserId"].ToString()), Constants.LongNullValue, Constants.IntNullValue, txtSlipNo.Text, Constants.DateNullValue, 22, "");

        LController.PostingCash_Bank_Account(Constants.Bank_Voucher, long.Parse(MaxDocumentId), long.Parse(DrpAccountDetail.SelectedValue.ToString()), int.Parse(drpDistributor.SelectedValue.ToString()), decimal.Parse(txtAmount.Text), 0,
            DateTime.Parse(this.Session["CurrentWorkDate"].ToString()), txtRemarks.Text, DateTime.Now, Constants.IntNullValue, int.Parse(DrpPrincipal.SelectedValue.ToString()),
            txtChequeNo.Text, int.Parse(this.Session["UserId"].ToString()), Constants.LongNullValue, Constants.IntNullValue, txtSlipNo.Text, Constants.DateNullValue, 22, "");


    }
    private void LoadDeliveryman()
    {
        if (drpDistributor.Items.Count > 0)
        {
            Distributor_UserController mDController = new Distributor_UserController();
            DataTable m_dt = mDController.SelectSaleForceAssignedArea(int.Parse(drpDistributor.SelectedValue.ToString()),Constants.IntNullValue,int.Parse(this.Session["CompanyId"].ToString()));
            clsWebFormUtil.FillDropDownList(this.DrpDeliveryMan, m_dt, 0, 3, true);
        }
       
    }
    private void SelectCreditInvoice()
    {
        CustomerDataController CDC = new CustomerDataController();
        if (DrpCustomer.Items.Count > 0)
        {
            DataTable dtCredit = CDC.SelectCreditPendingInvoice(int.Parse(drpDistributor.SelectedValue.ToString()), int.Parse(DrpPrincipal.SelectedValue.ToString()), long.Parse(DrpCustomer.SelectedValue.ToString()),0);
            GrdCredit.DataSource = dtCredit;
            GrdCredit.DataBind();

            decimal TotalAmount = 0;
            foreach (GridViewRow gvr in GrdCredit.Rows)
            {
                TotalAmount += Convert.ToDecimal(gvr.Cells[3].Text);
            }

            txtTotalAmount.Text = TotalAmount.ToString();
        }
    }
    private void IncomeTax()
    {


        LedgerController LController = new LedgerController();
        string MaxDocumentId = LController.SelectLedgerMaxDocumentId(Constants.Journal_Voucher, int.Parse(drpDistributor.SelectedValue.ToString()));
        decimal OfferAmount = decimal.Parse(txtAmount.Text);
        foreach (GridViewRow dr in GrdCredit.Rows)
        {
            CheckBox chRelized = (CheckBox)dr.Cells[0].FindControl("ChbIsAssigned");
            if (chRelized.Checked == true)
            {

                if (decimal.Parse(dr.Cells[3].Text) >= OfferAmount)
                {
                    LController.PostingCash_Bank_Account(Constants.Journal_Voucher, long.Parse(MaxDocumentId), long.Parse(SAMS.Common.Classes.Configuration.AccountReceivable), int.Parse(drpDistributor.SelectedValue.ToString()), 0, OfferAmount,
                    DateTime.Parse(this.Session["CurrentWorkDate"].ToString()), txtRemarks.Text, DateTime.Now, int.Parse(DrpCustomer.SelectedValue.ToString()), int.Parse(DrpPrincipal.SelectedValue.ToString()),
                    txtChequeNo.Text, int.Parse(this.Session["UserId"].ToString()), long.Parse(dr.Cells[5].Text), Constants.Document_Invoice, txtSlipNo.Text, Constants.DateNullValue, int.Parse(DrpAccountType.SelectedValue.ToString()), DrpDeliveryMan.SelectedValue.ToString());

                    LController.PostingCash_Bank_Account(Constants.Journal_Voucher, long.Parse(MaxDocumentId), long.Parse(DrpAccountDetail.SelectedValue.ToString()), int.Parse(drpDistributor.SelectedValue.ToString()), OfferAmount, 0,
                    DateTime.Parse(this.Session["CurrentWorkDate"].ToString()), txtRemarks.Text, DateTime.Now, int.Parse(DrpCustomer.SelectedValue.ToString()), int.Parse(DrpPrincipal.SelectedValue.ToString()),
                    txtChequeNo.Text, int.Parse(this.Session["UserId"].ToString()), long.Parse(dr.Cells[5].Text), Constants.Document_Invoice, txtSlipNo.Text, Constants.DateNullValue, int.Parse(DrpAccountType.SelectedValue.ToString()), DrpDeliveryMan.SelectedValue.ToString());

                    OfferAmount = decimal.Parse(dr.Cells[3].Text) - OfferAmount;
                    LController.UpdateSaleInvoice(long.Parse(dr.Cells[5].Text), int.Parse(drpDistributor.SelectedValue.ToString()), OfferAmount);
                    break;
                }
                else if (decimal.Parse(dr.Cells[3].Text) <= OfferAmount)
                {
                    LController.PostingCash_Bank_Account(Constants.Journal_Voucher, long.Parse(MaxDocumentId), long.Parse(SAMS.Common.Classes.Configuration.AccountReceivable), int.Parse(drpDistributor.SelectedValue.ToString()), 0, decimal.Parse(dr.Cells[3].Text),
                    DateTime.Parse(this.Session["CurrentWorkDate"].ToString()), txtRemarks.Text, DateTime.Now, int.Parse(DrpCustomer.SelectedValue.ToString()), int.Parse(DrpPrincipal.SelectedValue.ToString()),
                    txtChequeNo.Text, int.Parse(this.Session["UserId"].ToString()), long.Parse(dr.Cells[5].Text), Constants.Document_Invoice, txtSlipNo.Text, Constants.DateNullValue, int.Parse(DrpAccountType.SelectedValue.ToString()), DrpDeliveryMan.SelectedValue.ToString());

                    LController.PostingCash_Bank_Account(Constants.Journal_Voucher, long.Parse(MaxDocumentId), long.Parse(DrpAccountDetail.SelectedValue.ToString()), int.Parse(drpDistributor.SelectedValue.ToString()), decimal.Parse(dr.Cells[3].Text), 0,
                    DateTime.Parse(this.Session["CurrentWorkDate"].ToString()), txtRemarks.Text, DateTime.Now, int.Parse(DrpCustomer.SelectedValue.ToString()), int.Parse(DrpPrincipal.SelectedValue.ToString()),
                    txtChequeNo.Text, int.Parse(this.Session["UserId"].ToString()), long.Parse(dr.Cells[5].Text), Constants.Document_Invoice, txtSlipNo.Text, Constants.DateNullValue, int.Parse(DrpAccountType.SelectedValue.ToString()), DrpDeliveryMan.SelectedValue.ToString());

                    OfferAmount = OfferAmount - decimal.Parse(dr.Cells[3].Text);
                    LController.UpdateSaleInvoice(long.Parse(dr.Cells[5].Text), int.Parse(drpDistributor.SelectedValue.ToString()), 0);
                }
            }
        }

    }
    private void AdvanceReturn()
    {


        LedgerController LController = new LedgerController();
        CustomerDataController CDC = new CustomerDataController();
        string MaxDocumentId = LController.SelectLedgerMaxDocumentId(Constants.Cash_Voucher, int.Parse(drpDistributor.SelectedValue.ToString()));

        LController.PostingCash_Bank_Account(Constants.Cash_Voucher, long.Parse(MaxDocumentId), long.Parse(SAMS.Common.Classes.Configuration.AccountReceivable), int.Parse(drpDistributor.SelectedValue.ToString()),decimal.Parse(txtAmount.Text),0,
                 DateTime.Parse(this.Session["CurrentWorkDate"].ToString()), txtRemarks.Text, DateTime.Now, int.Parse(DrpCustomer.SelectedValue.ToString()), int.Parse(DrpPrincipal.SelectedValue.ToString()),
                 txtChequeNo.Text, int.Parse(this.Session["UserId"].ToString()), Constants.LongNullValue, Constants.IntNullValue, txtSlipNo.Text, Constants.DateNullValue, 29, "");

        LController.PostingCash_Bank_Account(Constants.Cash_Voucher, long.Parse(MaxDocumentId), long.Parse(DrpAccountDetail.SelectedValue.ToString()), int.Parse(drpDistributor.SelectedValue.ToString()), 0,decimal.Parse(txtAmount.Text),
            DateTime.Parse(this.Session["CurrentWorkDate"].ToString()), txtRemarks.Text, DateTime.Now, int.Parse(DrpCustomer.SelectedValue.ToString()), int.Parse(DrpPrincipal.SelectedValue.ToString()),
            txtChequeNo.Text, int.Parse(this.Session["UserId"].ToString()), Constants.LongNullValue, Constants.IntNullValue, txtSlipNo.Text, Constants.DateNullValue, 29, "");


        
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            SAMS.Common.Classes.Configuration.GetAccountHead();
            this.LoadPrincipal();
            this.LoadDistributor();
            this.LoadArea();
            this.LoadData();
            this.LoadAccountHead();
            this.LoadGrid();
            this.LoadDeliveryman();
            this.SelectCreditInvoice();
            Button1.Attributes.Add("onclick", "return ValidateForm();");
        }

    }
    protected void drpDistributor_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadArea();
        this.LoadData();
        this.LoadGrid();
        this.LoadDeliveryman();
    }
    protected void DrpRoute_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadData();
        this.SelectCreditInvoice();
       
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (DrpAccountType.SelectedIndex == 0)
        {
            int InvoiceCount = Constants.IntNullValue;
            foreach (GridViewRow dr in GrdCredit.Rows)
            {
                CheckBox chRelized = (CheckBox)dr.Cells[0].FindControl("ChbIsAssigned");
                if (chRelized.Checked == true)
                {
                    InvoiceCount++;
                    break;
                }
            }

            if (InvoiceCount == Constants.IntNullValue)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('Must Select Invoice');", true);
                return;
            }
            this.CashRealization();
            this.SelectCreditInvoice();
        }
        else if (DrpAccountType.SelectedIndex == 1)
        {
            this.BankDeposit();
        }
        else
        {
            this.IncomeTax();
            this.SelectCreditInvoice();
            
        }
        this.ClearAll();
        this.LoadGrid();
    }
    protected void DrpAccountType_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadAccountHead();
        this.LoadGrid();
    }
    protected void DrpAccountDetail_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadGrid();

    }
    protected void GrdOrder_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        LedgerController LController = new LedgerController();
        DataControl dc = new DataControl();

        LController.DeleteCashBankTransction(int.Parse(drpDistributor.SelectedValue.ToString()), int.Parse(dc.chkNull_0(GrdOrder.Rows[e.RowIndex].Cells[2].Text)),
        int.Parse(dc.chkNull_0(GrdOrder.Rows[e.RowIndex].Cells[7].Text)), long.Parse(dc.chkNull_0(GrdOrder.Rows[e.RowIndex].Cells[10].Text.Replace("&nbsp;", ""))), decimal.Parse(dc.chkNull_0(GrdOrder.Rows[e.RowIndex].Cells[8].Text)));
        this.LoadGrid();
        this.SelectCreditInvoice();
    }
    protected void DrpTranType_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void DrpAccountType_SelectedIndexChanged1(object sender, EventArgs e)
    {
        
        this.LoadAccountHead();
        this.LoadGrid();

        if (DrpAccountType.SelectedIndex == 1)
        {
            Panel1.Visible = false;
            DrpRoute.Enabled = false;
            DrpDeliveryMan.Enabled = false;
            DrpCustomer.Enabled = false;
        }
        else

        {
            this.LoadArea();
            this.LoadData();
            this.SelectCreditInvoice();
            Panel1.Visible = true;
            DrpDeliveryMan.Enabled = true;
            DrpCustomer.Enabled = true;
        }
    }
    protected void DrpCustomer_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.SelectCreditInvoice();
    }
    protected void Button2_Click(object sender, EventArgs e)
    {

    }
    protected void DrpPrincipal_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadData();
        this.SelectCreditInvoice();
    }
}
