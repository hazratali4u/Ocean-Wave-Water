using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using SAMS.BusinessLayer.Classes;
using SAMS.Common.Classes;

public partial class Forms_frmChequeEntry : System.Web.UI.Page
{
    private void LoadDistributor()
    {
        DistributorController DController = new DistributorController();
        DataTable dt = DController.SelectDistributorInfo(Constants.IntNullValue, int.Parse(this.Session["UserId"].ToString()), int.Parse(this.Session["CompanyId"].ToString()));
        clsWebFormUtil.FillDropDownList(this.drpDistributor, dt, 0, 2, true);
    }
    private void LoadArea()
    {
       
            DistributorAreaController mController = new DistributorAreaController();
            DataTable dt = mController.SelectDist_Area(Constants.LongNullValue, Constants.DateNullValue, Constants.DateNullValue, int.Parse(drpDistributor.SelectedValue.ToString()), Constants.IntNullValue, null, null);
            clsWebFormUtil.FillDropDownList(DrpRoute, dt, 0, 6, true);
       
    }
    private void LoadData()
    {
        CustomerDataController mController = new CustomerDataController();

        if (DrpChequeType.SelectedIndex == 1)
        {
           
            DataTable dtCustomer = mController.SelectPrincipalCustomer(int.Parse(drpDistributor.SelectedValue.ToString()), int.Parse(DrpRoute.SelectedValue.ToString()),int.Parse(DrpRoute.SelectedValue.ToString()), int.Parse(DrpPrincipal.SelectedValue.ToString()));
            clsWebFormUtil.FillDropDownList(this.DrpCustomer, dtCustomer, 0, 4, true);
            DrpRoute.Enabled = true;
            Panel1.Enabled = false;
            
        }
        else
        {
            if (drpDistributor.Items.Count > 0)
            {

                DataTable dtCredit = mController.SelectCreditPendingInvoice(int.Parse(drpDistributor.SelectedValue.ToString()), int.Parse(DrpPrincipal.SelectedValue.ToString()), Constants.LongNullValue, int.Parse(DrpRoute.SelectedValue.ToString()));
                clsWebFormUtil.FillDropDownList(this.DrpCustomer, dtCredit, 0, 1, true);
                //DrpRoute.Enabled = false;
                //Panel1.Enabled = true;

            }
        }
    }
    private void ClearAll()
    {
        txtChequeNo.Text = "";
        txtAmount.Text = "";
        txtBankName.Text = "";
        txtStartDate.Text = "";
        Button1.Text = "Save";
        txtReceivedDate.Text = "";
        txtSlipNo.Text = "";
        txtRemarks.Text = ""; 
        
    }
    private void LoadPrincipal()
    {
        SKUPriceDetailController PController = new SKUPriceDetailController();
        DataTable m_dt = PController.SelectDataPrice(Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, int.Parse(this.Session["UserId"].ToString()), Constants.IntNullValue, 0, DateTime.Parse(this.Session["CurrentWorkDate"].ToString()));
        clsWebFormUtil.FillDropDownList(this.DrpPrincipal, m_dt, 0, 1, true);
    }
    private void LoadReceviedCheque()
    {
        if (DrpStatus.SelectedValue.ToString() != Constants.Cheque_Clear.ToString())
        {
            ChequeEntryController CController = new ChequeEntryController();
            DataTable dt = CController.SelectChequeEntry(int.Parse(DrpStatus.SelectedValue.ToString()), DateTime.Parse(this.Session["CurrentWorkDate"].ToString()), int.Parse(drpDistributor.SelectedValue.ToString()), int.Parse(DrpPrincipal.SelectedValue.ToString()), DrpChequeType.SelectedIndex);
            this.Session.Add("dt", dt);  
            GrdOrder.DataSource = dt;
            GrdOrder.DataBind();
        }
        else
        {
            GrdOrder.DataSource = null;
            GrdOrder.DataBind();
        }
    }
    private void SelectCreditInvoice()
    {
        CustomerDataController CDC = new CustomerDataController();
        GrdCredit.DataSource = null;
        if (DrpCustomer.Items.Count > 0)
        {
            DataTable dtCredit = CDC.SelectCreditPendingInvoice(int.Parse(drpDistributor.SelectedValue.ToString()), int.Parse(DrpPrincipal.SelectedValue.ToString()), long.Parse(DrpCustomer.SelectedValue.ToString()), 0);
            GrdCredit.DataSource = dtCredit;
            GrdCredit.DataBind();
        }
    }
    private void ChequeRealization()
    {
        LedgerController LController = new LedgerController();
        string MaxDocumentId = LController.SelectLedgerMaxDocumentId(Constants.Bank_Voucher, int.Parse(drpDistributor.SelectedValue.ToString()));
        decimal OfferAmount = decimal.Parse(txtAmount.Text);
        if (DrpChequeType.SelectedIndex == 0)
        {
            foreach (GridViewRow dr in GrdCredit.Rows)
            {
                CheckBox chRelized = (CheckBox)dr.Cells[0].FindControl("ChbIsAssigned");
                if (chRelized.Checked == true)
                {

                    if (decimal.Parse(dr.Cells[3].Text) >= OfferAmount)
                    {
                        LController.PostingCash_Bank_Account(Constants.Bank_Voucher, long.Parse(MaxDocumentId), 107, int.Parse(drpDistributor.SelectedValue.ToString()), 0, OfferAmount,
                        DateTime.Parse(this.Session["CurrentWorkDate"].ToString()), "Cheque Relization", DateTime.Now, int.Parse(DrpCustomer.SelectedValue.ToString()), int.Parse(DrpPrincipal.SelectedValue.ToString()),
                        txtChequeNo.Text, int.Parse(this.Session["UserId"].ToString()), long.Parse(dr.Cells[1].Text), Constants.Document_Invoice, txtSlipNo.Text, Constants.DateNullValue, 18, DrpDeliveryMan.SelectedValue.ToString());

                        LController.PostingCash_Bank_Account(Constants.Bank_Voucher, long.Parse(MaxDocumentId), long.Parse(DrpBankAccount.SelectedValue.ToString()), int.Parse(drpDistributor.SelectedValue.ToString()), OfferAmount, 0,
                        DateTime.Parse(this.Session["CurrentWorkDate"].ToString()), "Cheque Relization", DateTime.Now, int.Parse(DrpCustomer.SelectedValue.ToString()), int.Parse(DrpPrincipal.SelectedValue.ToString()),
                        txtChequeNo.Text, int.Parse(this.Session["UserId"].ToString()), long.Parse(dr.Cells[1].Text), Constants.Document_Invoice, txtSlipNo.Text, Constants.DateNullValue, 18, DrpDeliveryMan.SelectedValue.ToString());

                        OfferAmount = decimal.Parse(dr.Cells[3].Text) - OfferAmount;
                        LController.UpdateSaleInvoice(long.Parse(dr.Cells[1].Text), int.Parse(drpDistributor.SelectedValue.ToString()), OfferAmount);
                        break;
                    }
                    else if (decimal.Parse(dr.Cells[3].Text) <= OfferAmount)
                    {
                        LController.PostingCash_Bank_Account(Constants.Bank_Voucher, long.Parse(MaxDocumentId), 107, int.Parse(drpDistributor.SelectedValue.ToString()), 0, decimal.Parse(dr.Cells[3].Text),
                        DateTime.Parse(this.Session["CurrentWorkDate"].ToString()), "Cheque Relization", DateTime.Now, int.Parse(DrpCustomer.SelectedValue.ToString()), int.Parse(DrpPrincipal.SelectedValue.ToString()),
                        txtChequeNo.Text, int.Parse(this.Session["UserId"].ToString()), long.Parse(dr.Cells[1].Text), Constants.Document_Invoice, txtSlipNo.Text, Constants.DateNullValue, 18, DrpDeliveryMan.SelectedValue.ToString());

                        LController.PostingCash_Bank_Account(Constants.Bank_Voucher, long.Parse(MaxDocumentId), long.Parse(DrpBankAccount.SelectedValue.ToString()), int.Parse(drpDistributor.SelectedValue.ToString()), decimal.Parse(dr.Cells[3].Text), 0,
                        DateTime.Parse(this.Session["CurrentWorkDate"].ToString()), "Cheque Relization", DateTime.Now, int.Parse(DrpCustomer.SelectedValue.ToString()), int.Parse(DrpPrincipal.SelectedValue.ToString()),
                        txtChequeNo.Text, int.Parse(this.Session["UserId"].ToString()), long.Parse(dr.Cells[1].Text), Constants.Document_Invoice, txtSlipNo.Text, Constants.DateNullValue, 18, DrpDeliveryMan.SelectedValue.ToString());

                        OfferAmount = OfferAmount - decimal.Parse(dr.Cells[3].Text);
                        LController.UpdateSaleInvoice(long.Parse(dr.Cells[1].Text), int.Parse(drpDistributor.SelectedValue.ToString()), 0);
                    }
                }
            }
        }
        else
        {
                      
            LController.PostingCash_Bank_Account(Constants.Bank_Voucher, long.Parse(MaxDocumentId), 107, int.Parse(drpDistributor.SelectedValue.ToString()), 0, decimal.Parse(txtAmount.Text),
                DateTime.Parse(this.Session["CurrentWorkDate"].ToString()), "Cheque Advance", DateTime.Now, int.Parse(DrpCustomer.SelectedValue.ToString()), int.Parse(DrpPrincipal.SelectedValue.ToString()),
                txtChequeNo.Text, int.Parse(this.Session["UserId"].ToString()), Constants.LongNullValue, Constants.IntNullValue, txtSlipNo.Text, Constants.DateNullValue, 20, "");

            LController.PostingCash_Bank_Account(Constants.Bank_Voucher, long.Parse(MaxDocumentId),325, int.Parse(drpDistributor.SelectedValue.ToString()), decimal.Parse(txtAmount.Text), 0,
                DateTime.Parse(this.Session["CurrentWorkDate"].ToString()), "Cheque Advance", DateTime.Now, int.Parse(DrpCustomer.SelectedValue.ToString()), int.Parse(DrpPrincipal.SelectedValue.ToString()),
                txtChequeNo.Text, int.Parse(this.Session["UserId"].ToString()), Constants.LongNullValue, Constants.IntNullValue, txtSlipNo.Text, Constants.DateNullValue, 20, "");

        }

    }
    private void LoadDeliveryman()
    {
        if (drpDistributor.Items.Count > 0)
        {
            Distributor_UserController mDController = new Distributor_UserController();
            DataTable m_dt = mDController.SelectSaleForceAssignedArea(int.Parse(drpDistributor.SelectedValue.ToString()), Constants.IntNullValue, int.Parse(this.Session["CompanyId"].ToString()));
            clsWebFormUtil.FillDropDownList(this.DrpDeliveryMan, m_dt, 0, 3, true);
        }

    }
    private void LoadAccountHead()
    {
        SAMS.Common.Classes.Configuration.GetAccountHead();
        AccountHeadController mAccountController = new AccountHeadController();
        DataTable dt = mAccountController.SelectAccountHead(Constants.AC_AccountHeadId, long.Parse(SAMS.Common.Classes.Configuration.BankDefaultType));
        clsWebFormUtil.FillDropDownList(DrpBankAccount, dt, 0, 4, true);
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            DrpStatus.Items.Add(new ListItem("Cheque Received", Constants.Cheque_Pending.ToString()));
            DrpStatus.Items.Add(new ListItem("Cheque Deposit", Constants.Cheque_Deposit.ToString()));
            DrpStatus.Items.Add(new ListItem("Cheque Realize", Constants.Cheque_Clear.ToString()));
            DrpStatus.Items.Add(new ListItem("Cheque Bounce", Constants.Cheque_Bons.ToString()));
            DrpStatus.Items.Add(new ListItem("Cheque Cancel", Constants.Cheque_Cancel.ToString()));
            DrpStatus.Items.Add(new ListItem("Cheque Hold", Constants.Cheque_Hold.ToString()));
            this.LoadAccountHead(); 
            this.LoadPrincipal();
            this.LoadDistributor();
            this.LoadArea();
            this.LoadData();
            this.SelectCreditInvoice();
            this.LoadReceviedCheque();
            this.LoadDeliveryman();
            Button1.Attributes.Add("onclick", "return ValidateForm();");                  
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        ChequeEntryController CController = new ChequeEntryController();

        DateTime ChequeDate;

        if (txtStartDate.Text.Length == 10)
        {
            ChequeDate = DateTime.Parse(ConvertDate.British_To_American(txtStartDate.Text));

        }
        else
        {
            ChequeDate = DateTime.Now;
        }

        if (Button1.Text == "Save")
        {

            if (DrpStatus.SelectedIndex == 0)
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

                HFChqueProcessId.Value = CController.InsertChequeEntry(int.Parse(drpDistributor.SelectedValue.ToString()), int.Parse(DrpPrincipal.SelectedValue.ToString()), long.Parse(DrpCustomer.SelectedValue.ToString()), txtChequeNo.Text, txtBankName.Text, ChequeDate,
                    DateTime.Parse(this.Session["CurrentWorkDate"].ToString()), Constants.DateNullValue, Constants.DateNullValue, decimal.Parse(txtAmount.Text), int.Parse(DrpStatus.SelectedValue.ToString()), DateTime.Now, DrpChequeType.SelectedIndex, txtSlipNo.Text, txtRemarks.Text,long.Parse(DrpBankAccount.SelectedValue.ToString()),int.Parse(DrpDeliveryMan.SelectedValue.ToString()));

                //CController.SelectChequeEntryInvoice(long.Parse(HFChqueProcessId.Value), 1);

                foreach (GridViewRow dr in GrdCredit.Rows)
                {
                    CheckBox chRelized = (CheckBox)dr.Cells[0].FindControl("ChbIsAssigned");
                    if (chRelized.Checked == true)
                    {
                        CController.InsertChequeEntryInvoice(long.Parse(HFChqueProcessId.Value), long.Parse(dr.Cells[1].Text));
                    }
                }
            }
            
        }
        else
        {
            if (int.Parse(DrpStatus.SelectedValue.ToString()) == Constants.Cheque_Pending && txtReceivedDate.Text == DateTime.Parse(this.Session["CurrentWorkDate"].ToString()).ToString("dd/MM/yyyy"))
            {
                CController.UpdateChequeEntry(long.Parse(HFChqueProcessId.Value), int.Parse(drpDistributor.SelectedValue.ToString()), int.Parse(DrpPrincipal.SelectedValue.ToString()), long.Parse(DrpCustomer.SelectedValue.ToString()), txtChequeNo.Text, txtBankName.Text, ChequeDate, DateTime.Parse(this.Session["CurrentWorkDate"].ToString()), Constants.DateNullValue, Constants.DateNullValue,
                   decimal.Parse(txtAmount.Text), int.Parse(DrpStatus.SelectedValue.ToString()), Constants.DateNullValue, txtSlipNo.Text, DrpChequeType.SelectedIndex, txtRemarks.Text, int.Parse(DrpBankAccount.SelectedValue.ToString()), int.Parse(DrpDeliveryMan.SelectedValue.ToString()));

                CController.SelectChequeEntryInvoice(long.Parse(HFChqueProcessId.Value), 1);

                foreach (GridViewRow dr in GrdCredit.Rows)
                {
                    CheckBox chRelized = (CheckBox)dr.Cells[0].FindControl("ChbIsAssigned");
                    if (chRelized.Checked == true)
                    {
                        CController.InsertChequeEntryInvoice(long.Parse(HFChqueProcessId.Value), long.Parse(dr.Cells[1].Text));
                    }
                }
            }
            else if (int.Parse(DrpStatus.SelectedValue.ToString()) == Constants.Cheque_Deposit || int.Parse(DrpStatus.SelectedValue.ToString()) == Constants.Cheque_Hold)
            {
                CController.UpdateChequeEntry(long.Parse(HFChqueProcessId.Value), Constants.IntNullValue, Constants.IntNullValue, Constants.LongNullValue, null, null, Constants.DateNullValue, Constants.DateNullValue, DateTime.Parse(this.Session["CurrentWorkDate"].ToString()), Constants.DateNullValue,
                     Constants.DecimalNullValue, int.Parse(DrpStatus.SelectedValue.ToString()), Constants.DateNullValue, txtSlipNo.Text, DrpChequeType.SelectedIndex, txtRemarks.Text, int.Parse(DrpBankAccount.SelectedValue.ToString()), int.Parse(DrpDeliveryMan.SelectedValue.ToString()));
            }
            else if (int.Parse(DrpStatus.SelectedValue.ToString()) == Constants.Cheque_Bons || int.Parse(DrpStatus.SelectedValue.ToString()) == Constants.Cheque_Cancel)
            {
                CController.UpdateChequeEntry(long.Parse(HFChqueProcessId.Value), Constants.IntNullValue, Constants.IntNullValue, Constants.LongNullValue, null, null, Constants.DateNullValue, Constants.DateNullValue, Constants.DateNullValue, DateTime.Parse(this.Session["CurrentWorkDate"].ToString()),
                                                 Constants.DecimalNullValue, int.Parse(DrpStatus.SelectedValue.ToString()), Constants.DateNullValue, txtSlipNo.Text, DrpChequeType.SelectedIndex, txtRemarks.Text, long.Parse(DrpBankAccount.SelectedValue.ToString()), int.Parse(DrpDeliveryMan.SelectedValue.ToString()));

            }

            else if (int.Parse(DrpStatus.SelectedValue.ToString()) == Constants.Cheque_Clear)
            {

                CController.UpdateChequeEntry(long.Parse(HFChqueProcessId.Value), Constants.IntNullValue, Constants.IntNullValue, Constants.LongNullValue, null, null, Constants.DateNullValue, Constants.DateNullValue, Constants.DateNullValue, DateTime.Parse(this.Session["CurrentWorkDate"].ToString()),
                                                 Constants.DecimalNullValue, int.Parse(DrpStatus.SelectedValue.ToString()), Constants.DateNullValue, txtSlipNo.Text, DrpChequeType.SelectedIndex, txtRemarks.Text, long.Parse(DrpBankAccount.SelectedValue.ToString()), int.Parse(DrpDeliveryMan.SelectedValue.ToString()));

                CController.SelectChequeEntryInvoice(long.Parse(HFChqueProcessId.Value), 1);

                foreach (GridViewRow dr in GrdCredit.Rows)
                {
                    CheckBox chRelized = (CheckBox)dr.Cells[0].FindControl("ChbIsAssigned");
                    if (chRelized.Checked == true)
                    {
                        CController.InsertChequeEntryInvoice(long.Parse(HFChqueProcessId.Value), long.Parse(dr.Cells[1].Text));
                    }
                }

                this.ChequeRealization();
                this.LoadData();
                this.SelectCreditInvoice();

            }
            


        }

        this.ClearAll();
        this.LoadReceviedCheque();
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        this.ClearAll(); 
    }
    protected void GrdOrder_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        ChequeEntryController CController = new ChequeEntryController();
        CController.DeleteChequeEntry(long.Parse(GrdOrder.Rows[e.RowIndex].Cells[0].Text));
        this.LoadReceviedCheque();
    }
    protected void DrpCustomer_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.SelectCreditInvoice();
    }
    protected void drpDistributor_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadArea();
        this.LoadData();
        this.SelectCreditInvoice();
        this.LoadReceviedCheque();
    }
    protected void DrpPrincipal_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadData();
        this.SelectCreditInvoice();
        this.LoadReceviedCheque();
    }
    protected void GrdOrder_RowEditing(object sender, GridViewEditEventArgs e)
    {
        ChequeEntryController Ccontroller = new ChequeEntryController();
        HFChqueProcessId.Value = GrdOrder.Rows[e.NewEditIndex].Cells[0].Text;
        DrpRoute.SelectedValue = GrdOrder.Rows[e.NewEditIndex].Cells[11].Text;
        
        this.LoadData(); 
        
        DrpCustomer.SelectedValue = GrdOrder.Rows[e.NewEditIndex].Cells[1].Text;

        
        txtChequeNo.Text = GrdOrder.Rows[e.NewEditIndex].Cells[3].Text;
        txtBankName.Text = GrdOrder.Rows[e.NewEditIndex].Cells[4].Text;
        txtStartDate.Text = GrdOrder.Rows[e.NewEditIndex].Cells[5].Text;
        txtReceivedDate.Text = GrdOrder.Rows[e.NewEditIndex].Cells[6].Text;
        txtAmount.Text = GrdOrder.Rows[e.NewEditIndex].Cells[8].Text;
        txtSlipNo.Text = GrdOrder.Rows[e.NewEditIndex].Cells[9].Text;
        txtRemarks.Text = GrdOrder.Rows[e.NewEditIndex].Cells[10].Text;
        DrpBankAccount.SelectedValue = GrdOrder.Rows[e.NewEditIndex].Cells[13].Text;
        DrpDeliveryMan.SelectedValue = GrdOrder.Rows[e.NewEditIndex].Cells[14].Text;
        Button1.Text = "Update"; 
        this.SelectCreditInvoice();

        DataTable dt = Ccontroller.SelectChequeEntryInvoice(long.Parse(HFChqueProcessId.Value), 0);

        foreach (GridViewRow dr in GrdCredit.Rows)
        {
            foreach(DataRow dbr in dt.Rows)
            {
                if (long.Parse(dr.Cells[1].Text) == long.Parse(dbr["SALE_INVOICE_ID"].ToString()))
                {
                    CheckBox chRelized = (CheckBox)dr.Cells[0].FindControl("ChbIsAssigned");
                    chRelized.Checked = true;
                }
            }
            
        }
      
    }
    protected void DrpStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Button1.Text == "Save")
        {
            
            this.LoadReceviedCheque();
        }
    }
    protected void DrpRoute_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadData();
        this.SelectCreditInvoice();
    }
    protected void Button21_Click(object sender, EventArgs e)
    {
        DataTable dt = (DataTable)this.Session["dt"];
        switch (ddSearchType.SelectedIndex)
        {

            case 1:
                dt.DefaultView.RowFilter = ddSearchType.SelectedValue.ToString() + " like '%" + txtSeach.Text + "%'";
                break;
            case 2:
                dt.DefaultView.RowFilter = ddSearchType.SelectedValue.ToString() + " like '%" + txtSeach.Text + "%'";
                break;
            case 3:
                dt.DefaultView.RowFilter = ddSearchType.SelectedValue.ToString() + " like '%" + txtSeach.Text + "%'";
                break;
            case 4:
                dt.DefaultView.RowFilter = ddSearchType.SelectedValue.ToString() + " like '%" + txtSeach.Text + "%'";
                break;
            default:
                dt.DefaultView.RowFilter = "CHEQUE_NO" + " like '%" + "" + "%'";
                break;
        }
        GrdOrder.DataSource = dt.DefaultView;
        GrdOrder.DataBind();
    }
}
