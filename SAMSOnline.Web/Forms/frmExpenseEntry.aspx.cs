using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using SAMS.BusinessLayer.Classes;
using SAMS.Common.Classes;    

public partial class Forms_frmExpenseEntry : System.Web.UI.Page
{
    private void LoadDistributor()
    {
        DistributorController DController = new DistributorController();
        DataTable dt = DController.SelectDistributorInfo(Constants.IntNullValue, int.Parse(this.Session["UserId"].ToString()), int.Parse(this.Session["CompanyId"].ToString()));
        clsWebFormUtil.FillDropDownList(this.drpDistributor, dt, 0, 2, true);
    }
    private void LoadAccountParent()
    {
        SAMS.Common.Classes.Configuration.GetAccountHead();
        AccountHeadController mAccountController = new AccountHeadController();
        DataTable dt = mAccountController.SelectAccountHead(Constants.AC_DetailTypeId, long.Parse(SAMS.Common.Classes.Configuration.ExpensDefaultType));
        clsWebFormUtil.FillDropDownList(DrpMasterHead, dt, 0, 4, true);
    }
    private void LoadAccountHead()
    {
        if (DrpMasterHead.Items.Count > 0)
        {
            AccountHeadController mAccountController = new AccountHeadController();
            DataTable dt = mAccountController.SelectAccountHead(Constants.AC_AccountHeadId, long.Parse(DrpMasterHead.SelectedValue.ToString()));
            clsWebFormUtil.FillDropDownList(DrpAccountHead, dt, 0, 4, true);
        }
    }
    private void LoadPrincipal()
    {
        SKUPriceDetailController PController = new SKUPriceDetailController();
        DataTable m_dt = PController.SelectDataPrice(Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, int.Parse(this.Session["UserId"].ToString()), Constants.IntNullValue, 0, DateTime.Parse(this.Session["CurrentWorkDate"].ToString()));        
        clsWebFormUtil.FillDropDownList(this.DrpPrincipal, m_dt, 0,1);
    }
    private void LoadSalePerson()
    {
        if (drpDistributor.Items.Count > 0)
        {
            Distributor_UserController mDController = new Distributor_UserController();
            DataTable m_dt = mDController.SelectSaleForceAssignedArea(int.Parse(drpDistributor.SelectedValue.ToString()), Constants.IntNullValue, int.Parse(this.Session["CompanyId"].ToString()));
            clsWebFormUtil.FillDropDownList(this.ddlSalePerson, m_dt, 0, 3);
        }
    }
    private void CreatTable()
    {
        DataTable  dtVoucher = new DataTable();
        dtVoucher.Columns.Add("Account_Head_Id", typeof(long));
        dtVoucher.Columns.Add("Account_Parent_Id", typeof(int));
        dtVoucher.Columns.Add("Account_Code", typeof(string));
        dtVoucher.Columns.Add("Account_Name", typeof(string));
        dtVoucher.Columns.Add("Debit", typeof(decimal));
        dtVoucher.Columns.Add("Credit", typeof(decimal));
        dtVoucher.Columns.Add("Remarks", typeof(string));
        dtVoucher.Columns.Add("SalePersonID", typeof(int));
        this.Session.Add("dtVoucher", dtVoucher);

    }
    private void LoadVoucherNo()
    {
        LedgerController LController = new LedgerController();
        DataTable  dt  = LController.SelectVoucherNo(((DateTime)this.Session["CurrentWorkDate"]), int.Parse(drpDistributor.SelectedValue.ToString()), Constants.Journal_Voucher, int.Parse(this.Session["UserId"].ToString()),null);
        DrpVoucherNo.Items.Clear();
        DrpVoucherNo.Items.Add(new ListItem("New", "0"));
        clsWebFormUtil.FillDropDownList(DrpVoucherNo, dt, 3, 3);   
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.LoadDistributor();
            this.LoadAccountParent();
            this.LoadAccountHead();
            this.LoadPrincipal();
            this.CreatTable();
            this.LoadVoucherNo();
            this.LoadSalePerson();
            btnAddNew.Attributes.Add("onclick", "return ValidateForm();");
            ScriptManager.GetCurrent(Page).SetFocus(drpDistributor);
            lblRowId.Text = "-1"; 
        }
    }
    protected void GrdOrder_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        DataTable  dtVoucher = (DataTable)this.Session["dtVoucher"];
        dtVoucher.Rows.RemoveAt(e.RowIndex);
        GrdOrder.DataSource = dtVoucher;
        GrdOrder.DataBind();
        lblRowId.Text = "-1";

        decimal TotalDebit = 0;

        foreach (DataRow dr in dtVoucher.Rows)
        {
            TotalDebit += decimal.Parse(dr["DEBIT"].ToString());
        }
        txtMainCash.Text = TotalDebit.ToString();
  
    }
    protected void GrdOrder_RowEditing(object sender, GridViewEditEventArgs e)
    {
        DrpMasterHead.SelectedValue = GrdOrder.Rows[e.NewEditIndex].Cells[5].Text;
        this.LoadAccountHead();
        lblRowId.Text  = e.NewEditIndex.ToString();
        DrpAccountHead.SelectedValue = GrdOrder.Rows[e.NewEditIndex].Cells[0].Text;
        txtRemarks.Text = GrdOrder.Rows[e.NewEditIndex].Cells[2].Text.Replace("&nbsp;","");
        txtAmount.Text = GrdOrder.Rows[e.NewEditIndex].Cells[3].Text;
       
    }
    protected void btnAddNew_Click(object sender, EventArgs e)
    {
        DataControl dc = new DataControl();
        DataTable  dtVoucher = (DataTable)this.Session["dtVoucher"];
        if (lblRowId.Text == "-1")
        {
            DataRow dr = dtVoucher.NewRow();
            dr["ACCOUNT_HEAD_ID"] = DrpAccountHead.SelectedValue.ToString();
            dr["Account_Parent_Id"] = DrpMasterHead.SelectedValue;
            dr["ACCOUNT_NAME"] = DrpAccountHead.SelectedItem.Text;
            dr["DEBIT"] = decimal.Parse(dc.chkNull_0(txtAmount.Text));
            dr["Credit"] = "0";
            dr["REMARKS"] = txtRemarks.Text;
            if (cbSalePerson.Checked)
            {
                dr["SalePersonID"] = Convert.ToInt32(ddlSalePerson.SelectedValue);
            }
            else
            {
                dr["SalePersonID"] = Constants.IntNullValue;
            }
            dtVoucher.Rows.Add(dr);
        }
        else
        {
            DataRow dr = dtVoucher.Rows[int.Parse(lblRowId.Text)];
            dr["ACCOUNT_HEAD_ID"] = DrpAccountHead.SelectedValue.ToString();
            dr["Account_Parent_Id"] = DrpMasterHead.SelectedValue;
            dr["ACCOUNT_NAME"] = DrpAccountHead.SelectedItem.Text;
            dr["DEBIT"] = decimal.Parse(dc.chkNull_0(txtAmount.Text));
            dr["Credit"] = "0";
            dr["REMARKS"] = txtRemarks.Text;
            if (cbSalePerson.Checked)
            {
                dr["SalePersonID"] = Convert.ToInt32(ddlSalePerson.SelectedValue);
            }
            else
            {
                dr["SalePersonID"] = Constants.IntNullValue;
            }
        }

        cbSalePerson.Enabled = false;
        
        GrdOrder.DataSource = dtVoucher;
        GrdOrder.DataBind();
        txtAmount.Text = "";
        txtRemarks.Text = "";
        lblRowId.Text = "-1";
        ScriptManager.GetCurrent(Page).SetFocus(DrpAccountHead);
        
        decimal TotalDebit = 0;

        foreach (DataRow dr in dtVoucher.Rows)
        {
            TotalDebit += decimal.Parse(dr["DEBIT"].ToString());
        }
        txtMainCash.Text = TotalDebit.ToString();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        LedgerController mLController = new LedgerController();
        SAMS.Common.Classes.Configuration.GetAccountHead();
        DataControl dc = new DataControl();
        DataTable dtVoucher = (DataTable)this.Session["dtVoucher"];
        bool IsSaveVoucher;
        string MaxDocumentId;
        if (btnSave.Text == "Save")
        {
        #region Add Voucher
        if (dtVoucher.Rows.Count > 0)
        {
            DataRow dr = dtVoucher.NewRow();
            dr["ACCOUNT_HEAD_ID"] = SAMS.Common.Classes.Configuration.PeatyCash;
            dr["ACCOUNT_NAME"] = "Peatty Cash";
            dr["DEBIT"] = 0;
            dr["Credit"] = decimal.Parse(dc.chkNull_0(txtMainCash.Text));
            dr["REMARKS"] = "Patty Cash Credit";
            dtVoucher.Rows.Add(dr);
            if (DrpVoucherNo.SelectedValue.ToString() == "0")
            {
                MaxDocumentId = mLController.SelectMaxVoucherId(Constants.Journal_Voucher, int.Parse(drpDistributor.SelectedValue.ToString()), ((DateTime)this.Session["CurrentWorkDate"]));               
                
            }
            else
            {
                MaxDocumentId = DrpVoucherNo.SelectedValue.ToString();                
            }

            if (cbSalePerson.Checked)
            {
                IsSaveVoucher = mLController.Add_VoucherSalePersonWise(int.Parse(drpDistributor.SelectedValue.ToString()), int.Parse(DrpPrincipal.SelectedValue.ToString()), MaxDocumentId, Constants.Journal_Voucher,
                       ((DateTime)this.Session["CurrentWorkDate"]), Constants.Document_Petty_Cash, null, "Petty Voucher", Constants.DateNullValue, null, dtVoucher, int.Parse(this.Session["UserId"].ToString()), Convert.ToInt32(ddlSalePerson.SelectedValue));
            }
            else
            {
                IsSaveVoucher = mLController.Add_Voucher(int.Parse(drpDistributor.SelectedValue.ToString()), int.Parse(DrpPrincipal.SelectedValue.ToString()), MaxDocumentId, Constants.Journal_Voucher,
                       ((DateTime)this.Session["CurrentWorkDate"]), Constants.Document_Petty_Cash, null, "Petty Voucher", Constants.DateNullValue, null, dtVoucher, int.Parse(this.Session["UserId"].ToString()));
            }

            #region on save check
            if (IsSaveVoucher == true)
            {
                dtVoucher.Rows.Clear();   
                GrdOrder.DataSource = null;
                GrdOrder.DataBind();
                txtAmount.Text = "";
                btnSave.Text = "Save";
                txtRemarks.Text = "";
                lblRowId.Text = "-1";
                cbSalePerson.Enabled = true;
                cbSalePerson.Checked = false;
                ScriptManager.GetCurrent(Page).SetFocus(DrpAccountHead);

                decimal TotalDebit = 0;

                foreach (DataRow dr1 in dtVoucher.Rows)
                {
                    TotalDebit += decimal.Parse(dr1["DEBIT"].ToString());
                }
                txtMainCash.Text = TotalDebit.ToString();
                this.LoadVoucherNo();

            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('Some Error in Voucher')", true);
                return;
            }
            #endregion
        }
        #endregion
        }
      
    }
    protected void DrpVoucherNo_SelectedIndexChanged(object sender, EventArgs e)
    {       
        LedgerController LController = new LedgerController();
        DataTable dtVoucher = (DataTable)this.Session["dtVoucher"];

        if (DrpVoucherNo.SelectedValue.ToString() != "0")
        {
            dtVoucher = LController.SelectVoucherDetail(int.Parse(drpDistributor.SelectedValue.ToString()), DrpVoucherNo.SelectedValue.ToString(), Constants.Journal_Voucher);
            for (int i = 0; i < dtVoucher.Rows.Count; i++)
            {
                if (Decimal.Parse(dtVoucher.Rows[i]["CREDIT"].ToString()) > 0)
                {
                    dtVoucher.Rows.RemoveAt(i);
                }
            }

            decimal TotalDebit = 0;

            foreach (DataRow dr1 in dtVoucher.Rows)
            {
                TotalDebit += decimal.Parse(dr1["DEBIT"].ToString());
            }
            txtMainCash.Text = TotalDebit.ToString();

            cbSalePerson.Enabled = false;
            if (dtVoucher.Rows.Count > 0)
            {
                if (dtVoucher.Rows[0]["SalePersonID"].ToString() != "")
                {
                    cbSalePerson.Checked = true;
                    ddlSalePerson.SelectedValue = dtVoucher.Rows[0]["SalePersonID"].ToString();
                }
                else
                {
                    cbSalePerson.Checked = false;
                }
            }
            this.Session.Add("dtVoucher", dtVoucher);
            GrdOrder.DataSource = dtVoucher;
            GrdOrder.DataBind();

        }
        else
        {
            dtVoucher.Rows.Clear();  
            GrdOrder.DataSource = null;
            GrdOrder.DataBind();
            cbSalePerson.Enabled = true;
            cbSalePerson.Checked = false;
        }
        lblRowId.Text = "0";
        this.Session.Add("dtVoucher", dtVoucher);
       
    }
    protected void DrpMasterHead_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadAccountHead(); 
    }
   
}
