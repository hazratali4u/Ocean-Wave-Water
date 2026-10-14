using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using SAMS.BusinessLayer.Classes;
using SAMS.Common.Classes;

public partial class Forms_frmVoucherEntry : System.Web.UI.Page
{
    DataTable dtVoucher;
    private static int RowId = -1;
    private void LoadAccountHead()
    {
        SAMS.Common.Classes.Configuration.GetAccountHead();
        if (DrpVoucherType.SelectedIndex == 0)
        {
            AccountHeadController mAccountController = new AccountHeadController();
            DataTable dt = mAccountController.SelectAccountHead(Constants.AC_AccountHeadId, long.Parse(SAMS.Common.Classes.Configuration.CashDefaultType));
            clsWebFormUtil.FillDropDownList(drpBanks, dt, 0, 4, true);
        }
        else if (DrpVoucherType.SelectedIndex == 1)
        {
            AccountHeadController mAccountController = new AccountHeadController();
            DataTable dt = mAccountController.SelectAccountHead(Constants.AC_AccountHeadId, long.Parse(SAMS.Common.Classes.Configuration.BankDefaultType));
            clsWebFormUtil.FillDropDownList(drpBanks, dt, 0, 4, true);
        }
        else
        {
            drpBanks.Items.Clear();
            drpBanks.Items.Add(new ListItem("N/A", Constants.IntNullValue.ToString()));
        }
    }
    private void CreatTable()
    {
        dtVoucher = new DataTable();
        dtVoucher.Columns.Add("LEDGER_ID", typeof(long));
        dtVoucher.Columns.Add("Account_Head_Id", typeof(long));
        dtVoucher.Columns.Add("Account_Code", typeof(string));
        dtVoucher.Columns.Add("Account_Name", typeof(string));
        dtVoucher.Columns.Add("Debit", typeof(decimal));
        dtVoucher.Columns.Add("Credit", typeof(decimal));
        dtVoucher.Columns.Add("Remarks", typeof(string));
        dtVoucher.Columns.Add("InvoiceNo", typeof(string));
        this.Session.Add("dtVoucher", dtVoucher);

    }
    private void LoadPrincipal()
    {
        SKUPriceDetailController PController = new SKUPriceDetailController();
        DataTable m_dt = PController.SelectDataPrice(Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, int.Parse(this.Session["UserId"].ToString()), Constants.IntNullValue, 0, DateTime.Parse(this.Session["CurrentWorkDate"].ToString()));
        this.DrpPrincipal.Items.Add(new ListItem("General Entry", "0"));
        clsWebFormUtil.FillDropDownList(this.DrpPrincipal, m_dt, 0, 1);
    }
    private void LoadDistributor()
    {
        DistributorController DController = new DistributorController();
        DataTable dt = DController.SelectDistributorInfo(Constants.IntNullValue, int.Parse(this.Session["UserId"].ToString()), int.Parse(this.Session["CompanyId"].ToString()));
        clsWebFormUtil.FillDropDownList(this.drpDistributor, dt, 0, 2, true);
    }
    private void LoadAccountDetail()
    {
        AccountHeadController mAccountController = new AccountHeadController();
        DataTable dtHead = mAccountController.SelectAccountHead(Constants.AC_AccountHeadId, Constants.LongNullValue);
        clsWebFormUtil.FillListBox(this.LstAccountHead, dtHead, "ACCOUNT_HEAD", "ACCOUNT_HEAD", true);
        this.Session.Add("dtHead", dtHead);

    }
    private void ClearAll()
    {
        txtTotalCredit.Text = "0";
        txtTotalDebit.Text = "0";
        txtAccountCode.Text = "";
        txtAccountName.Text = "";
        txtRemarks.Text = "";
        txtChequeDate.Text = "";
        txtChequeNo.Text = "";
        txtDebitAmount.Text = "";
        txtCreditAmount.Text = "";
        txtAccountDes.Text = "";
        GrdOrder.DataSource = null;
        GrdOrder.DataBind();
        this.Session.Remove("dtVoucher");
        this.CreatTable();
        txtpayeesName.Text = "";
        drpDistributor.Enabled = true;
        DrpVoucherType.Enabled = true;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.LoadDistributor();
            this.LoadAccountDetail();
            this.LoadPrincipal();
            this.CreatTable();
            this.LoadAccountHead();
            txtVoucherDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            btnSave.Attributes.Add("onclick", "return ValidateForm();");
            RowId = -1;
        }
    }
    protected void DrpVoucherType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DrpVoucherType.SelectedIndex == 2)
        {
            lblChequeNo.Text = "Invoice No";
            lblChequedate.Text = "Invoice Date";
        }
        else
        {
            lblChequeNo.Text = "Cheque No";
            lblChequedate.Text = "Cheque Date";
        }
        this.ClearAll();
        this.LoadAccountHead();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        decimal TotalDebit = 0;
        decimal TotalCredit = 0;

        DataControl dc = new DataControl();
        DataTable dtHead = (DataTable)this.Session["dtHead"];
        dtVoucher = (DataTable)this.Session["dtVoucher"];
        DataRow[] foundRows = dtHead.Select("ACCOUNT_CODE  = '" + txtAccountCode.Text + "'");
        if (foundRows.Length > 0)
        {
            if (RowId >= 0)
            {
                DataRow dr = dtVoucher.Rows[RowId];
                dr["ACCOUNT_HEAD_ID"] = foundRows[0]["ACCOUNT_HEAD_ID"];
                dr["ACCOUNT_CODE"] = foundRows[0]["ACCOUNT_CODE"];
                dr["ACCOUNT_NAME"] = foundRows[0]["ACCOUNT_NAME"];
                dr["DEBIT"] = decimal.Parse(dc.chkNull_0(txtDebitAmount.Text));
                dr["CREDIT"] = decimal.Parse(dc.chkNull_0(txtCreditAmount.Text));
                dr["REMARKS"] = txtAccountDes.Text;


            }
            else
            {
                DataRow dr = dtVoucher.NewRow();
                dr["Ledger_ID"] = Constants.LongNullValue.ToString();
                dr["ACCOUNT_HEAD_ID"] = foundRows[0]["ACCOUNT_HEAD_ID"];
                dr["ACCOUNT_CODE"] = foundRows[0]["ACCOUNT_CODE"];
                dr["ACCOUNT_NAME"] = foundRows[0]["ACCOUNT_NAME"];
                dr["DEBIT"] = decimal.Parse(dc.chkNull_0(txtDebitAmount.Text));
                dr["CREDIT"] = decimal.Parse(dc.chkNull_0(txtCreditAmount.Text));
                dr["REMARKS"] = txtAccountDes.Text;
                dtVoucher.Rows.Add(dr);

            }
        }

        #region Set Total

        foreach (DataRow dr in dtVoucher.Rows)
        {
            TotalDebit += decimal.Parse(dr["DEBIT"].ToString());
            TotalCredit += decimal.Parse(dr["CREDIT"].ToString());
        }
        txtTotalDebit.Text = decimal.Round(TotalDebit, 0).ToString();
        txtTotalCredit.Text = decimal.Round(TotalCredit, 0).ToString();

        #endregion

        #region Clear Txtbox

        txtAccountCode.Text = "";
        txtAccountName.Text = "";
        txtDebitAmount.Text = "";
        txtCreditAmount.Text = "";
        RowId = -1;

        #endregion

        GrdOrder.DataSource = dtVoucher;
        GrdOrder.DataBind();
        this.Session.Add("dtVoucher", dtVoucher);
        ScriptManager.GetCurrent(Page).SetFocus(txtAccountCode);

        
    }
    protected void GrdOrder_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        decimal TotalDebit = 0;
        decimal TotalCredit = 0;
        dtVoucher = (DataTable)this.Session["dtVoucher"];
        dtVoucher.Rows.RemoveAt(e.RowIndex);

        #region Set Total

        foreach (DataRow dr in dtVoucher.Rows)
        {
            TotalDebit += decimal.Parse(dr["DEBIT"].ToString());
            TotalCredit += decimal.Parse(dr["CREDIT"].ToString());
        }
        txtTotalDebit.Text = TotalDebit.ToString();
        txtTotalCredit.Text = TotalCredit.ToString();

        #endregion

        GrdOrder.DataSource = dtVoucher;
        GrdOrder.DataBind();
        RowId = -1;
    }
    protected void GrdOrder_RowEditing(object sender, GridViewEditEventArgs e)
    {
        RowId = e.NewEditIndex;
        txtAccountCode.Text = GrdOrder.Rows[e.NewEditIndex].Cells[1].Text;
        txtAccountDes.Text = GrdOrder.Rows[e.NewEditIndex].Cells[2].Text;
        txtAccountName.Text = GrdOrder.Rows[e.NewEditIndex].Cells[5].Text;
        txtDebitAmount.Text = GrdOrder.Rows[e.NewEditIndex].Cells[3].Text;
        txtCreditAmount.Text = GrdOrder.Rows[e.NewEditIndex].Cells[4].Text;
        
    }
    protected void btnDone_Click(object sender, EventArgs e)
    {
        LedgerController mLController = new LedgerController();
        DataControl dc = new DataControl();
        dtVoucher = (DataTable)this.Session["dtVoucher"];
        DataTable dtHead = (DataTable)this.Session["dtHead"];

            decimal TotalDebit = 0;
            decimal TotalCredit = 0;

            #region Set Total

            foreach (DataRow dr in dtVoucher.Rows)
            {
                TotalDebit += decimal.Parse(dr["DEBIT"].ToString());
                TotalCredit += decimal.Parse(dr["CREDIT"].ToString());
            }
            #endregion

            if (TotalDebit != TotalCredit)
            {
                if (drpBanks.SelectedItem.Text != "N/A")
                {


                    decimal differnceAmt = TotalDebit - TotalCredit;

                    if (differnceAmt > 0)
                    {
                        DataRow dr1 = dtVoucher.NewRow();
                        DataRow[] foundSubRows = dtHead.Select("ACCOUNT_HEAD_ID  = " + drpBanks.SelectedValue.ToString());
                        dr1["Ledger_ID"] = Constants.LongNullValue.ToString();
                        dr1["ACCOUNT_HEAD_ID"] = foundSubRows[0]["ACCOUNT_HEAD_ID"];
                        dr1["ACCOUNT_CODE"] = foundSubRows[0]["ACCOUNT_CODE"];
                        dr1["ACCOUNT_NAME"] = foundSubRows[0]["ACCOUNT_NAME"];
                        dr1["REMARKS"] = txtAccountDes.Text;
                        dr1["CREDIT"] = differnceAmt;
                        dr1["DEBIT"] = 0;
                        dtVoucher.Rows.Add(dr1);

                    }
                    else if (differnceAmt < 0)
                    {
                        DataRow dr1 = dtVoucher.NewRow();
                        DataRow[] foundSubRows = dtHead.Select("ACCOUNT_HEAD_ID  = " + drpBanks.SelectedValue.ToString());
                        dr1["Ledger_ID"] = Constants.LongNullValue.ToString();
                        dr1["ACCOUNT_HEAD_ID"] = foundSubRows[0]["ACCOUNT_HEAD_ID"];
                        dr1["ACCOUNT_CODE"] = foundSubRows[0]["ACCOUNT_CODE"];
                        dr1["ACCOUNT_NAME"] = foundSubRows[0]["ACCOUNT_NAME"];
                        dr1["REMARKS"] = txtAccountDes.Text;
                        dr1["CREDIT"] = 0;
                        dr1["DEBIT"] = -(differnceAmt);
                        dtVoucher.Rows.Add(dr1);
                    }

                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('Wrong Entry');", true);
                    return;
                }
            }
         

        DateTime ChequeDate;
        DateTime  Voucherdate;

        if (txtVoucherDate.Text.Length < 10)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('Must Enter Voucher Date');", true);
            return;
        }
        else
        {
            Voucherdate = DateTime.Parse(ConvertDate.British_To_American(txtVoucherDate.Text));
        }

        if (txtChequeDate.Text.Length == 10)
        {
            ChequeDate = DateTime.Parse(ConvertDate.British_To_American(txtChequeDate.Text));

        }
        else
        {
            ChequeDate = Constants.DateNullValue;
        }
        dtVoucher = (DataTable)this.Session["dtVoucher"];

        string MaxDocumentId = mLController.SelectMaxVoucherId(int.Parse(DrpVoucherType.SelectedValue.ToString()), int.Parse(drpDistributor.SelectedValue.ToString()),Voucherdate);
        bool IsSaveVoucher  = mLController.Add_Voucher(int.Parse(drpDistributor.SelectedValue.ToString()), int.Parse(DrpPrincipal.SelectedValue.ToString()),MaxDocumentId, int.Parse(DrpVoucherType.SelectedValue.ToString()),
               Voucherdate, int.Parse(DrpPaymentMode.SelectedValue.ToString()), txtpayeesName.Text, txtRemarks.Text, ChequeDate, txtChequeNo.Text, dtVoucher, int.Parse(this.Session["UserId"].ToString()));
        if (IsSaveVoucher == true)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('Voucher No : " + MaxDocumentId + " has been Saved');", true);
            this.ClearAll();
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('Some error occur contact System Administrator');", true);
        }
        

    }
    protected void GrdOrder_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            e.Row.Cells[3].Text = txtTotalDebit.Text;
            e.Row.Cells[4].Text = txtTotalCredit.Text;
        }
    }
}
