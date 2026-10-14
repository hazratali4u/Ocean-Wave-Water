using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using SAMS.BusinessLayer.Classes;
using SAMS.Common.Classes;

public partial class Forms_frmVoucherEditing : System.Web.UI.Page
{
    DataTable dtVoucher;
    private static int RowId = -1;

    private void CreatTable()
    {
        dtVoucher = new DataTable();
        dtVoucher.Columns.Add("Account_Head_Id", typeof(long));
        dtVoucher.Columns.Add("Account_Code", typeof(string));
        dtVoucher.Columns.Add("Account_Name", typeof(string));
        dtVoucher.Columns.Add("Debit", typeof(decimal));
        dtVoucher.Columns.Add("Credit", typeof(decimal));
        dtVoucher.Columns.Add("Remarks", typeof(string));
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
    private void LoadEditVoucher()
    {
        LedgerController LController = new LedgerController();
        DataTable dtVoucher = (DataTable)this.Session["dtVoucher"];

        DataTable dt = LController.SelectVoucherNo(Constants.DateNullValue, int.Parse(drpDistributor.SelectedValue.ToString()), int.Parse(DrpVoucherType.SelectedValue.ToString()), int.Parse(this.Session["UserId"].ToString()), txtVoucherNo.Text);
        if (dt.Rows.Count > 0)
        {
            DrpPrincipal.SelectedValue = dt.Rows[0]["PRINCIPAL_ID"].ToString();
            drpDistributor.SelectedValue = dt.Rows[0]["DISTRIBUTOR_ID"].ToString();
            DrpVoucherType.SelectedValue = dt.Rows[0]["VOUCHER_TYPE_ID"].ToString();
            DrpPaymentMode.SelectedValue = dt.Rows[0]["PAYMENT_MODE"].ToString();
            txtVoucherDate.Text = DateTime.Parse(dt.Rows[0]["VOUCHER_DATE"].ToString()).ToString("dd/MM/yyyy");
            if (dt.Rows[0]["CHEQUE_DATE"].ToString().Length > 10)
            {
                txtChequeDate.Text = DateTime.Parse(dt.Rows[0]["CHEQUE_DATE"].ToString()).ToString("dd/MM/yyyy");
            }
            txtChequeNo.Text = dt.Rows[0]["CHEQUE_NO"].ToString();
            txtRemarks.Text = dt.Rows[0]["REMARKS"].ToString();
            txtpayeesName.Text = dt.Rows[0]["PAYEES_NAME"].ToString();

            dtVoucher = LController.SelectVoucherDetail(int.Parse(drpDistributor.SelectedValue.ToString()),txtVoucherNo.Text,int.Parse(DrpVoucherType.SelectedValue.ToString()));

            this.Session.Add("dtVoucher", dtVoucher);
            GrdOrder.DataSource = dtVoucher;
            GrdOrder.DataBind();
                        
        }

    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.LoadDistributor();
            this.LoadAccountDetail();
            this.LoadPrincipal();
            this.LoadTreeView();
            this.CreatTable();
            this.txtVoucherNo.Text = this.Session["VoucherNo"].ToString();
            this.drpDistributor.SelectedValue = this.Session["DistributorId"].ToString();
            this.DrpVoucherType.SelectedValue = this.Session["VoucherTypeId"].ToString();
            if (int.Parse(this.DrpVoucherType.SelectedValue.ToString()) == Constants.Journal_Voucher)
            {
                lblChequeNo.Text = "Invoice No";
                lblChequedate.Text = "Invoice Date"; 
            }

            this.LoadEditVoucher();

            btnSave.Attributes.Add("onclick", "return ValidateForm();");

            AppMaster master = new AppMaster();
            master = (AppMaster)this.Master;
            Panel panel = new Panel();
            panel = master.FindControl("searchpanel") as Panel;
            panel.Visible = true;
            RowId = -1;

            this.Session.Remove("VoucherNo");
            this.Session.Remove("DistributorId");
            this.Session.Remove("VoucherTypeId");
        }
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
        decimal TotalDebit = 0;
        decimal TotalCredit = 0;
        dtVoucher = (DataTable)this.Session["dtVoucher"];

        #region Set Total

        foreach (DataRow dr in dtVoucher.Rows)
        {
            TotalDebit += decimal.Parse(dr["DEBIT"].ToString());
            TotalCredit += decimal.Parse(dr["CREDIT"].ToString());
        }
        #endregion

        if (TotalDebit == TotalCredit)
        {
            LedgerController mLController = new LedgerController();
            DataControl dc = new DataControl();
            DateTime ChequeDate;
            DateTime Voucherdate;
            Voucherdate = DateTime.Parse(ConvertDate.British_To_American(txtVoucherDate.Text));

            if (txtChequeDate.Text.Length == 10)
            {
                ChequeDate = DateTime.Parse(ConvertDate.British_To_American(txtChequeDate.Text));

            }
            else
            {
                ChequeDate = Constants.DateNullValue;
            }
            dtVoucher = (DataTable)this.Session["dtVoucher"];

            string MaxDocumentId = txtVoucherNo.Text;
            mLController.Add_Voucher(int.Parse(drpDistributor.SelectedValue.ToString()), int.Parse(DrpPrincipal.SelectedValue.ToString()), MaxDocumentId, int.Parse(DrpVoucherType.SelectedValue.ToString()),
                   Voucherdate, int.Parse(DrpPaymentMode.SelectedValue.ToString()), txtpayeesName.Text, txtRemarks.Text, ChequeDate, txtChequeNo.Text, dtVoucher, int.Parse(this.Session["UserId"].ToString()));

            Response.Redirect("~/Forms/frmLedgerViewData.aspx?Status=" + false);
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('Debit Must Equal To Credit Balance');", true);
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

    private void LoadTreeView()
    {
        AppMaster myMaster;
        TreeView tr;
        Label lblUserId;
        Label lblCurrentWorkDate;

        myMaster = (AppMaster)this.Master;
        tr = myMaster.FindControl("tr") as TreeView;
        lblUserId = myMaster.FindControl("Label1") as Label;
        lblUserId.Text = this.Session["UserName"].ToString();
        lblCurrentWorkDate = myMaster.FindControl("lblCurrentWorkDate") as Label;
        lblCurrentWorkDate.Text = ((DateTime)this.Session["CurrentWorkDate"]).ToShortDateString();
        tr.Nodes.Clear();
        TreeNode trMaster = (TreeNode)this.Session["trMaster"];
        tr.Nodes.Add(trMaster);
        tr.CollapseAll();
        if (Session["TreeViewState"] == null)
        {
            // Record the TreeView's current expand/collapse state.
            Dictionary<string, bool> SelectedNode = new Dictionary<string, bool>();
            SaveTreeViewState(tr.Nodes, SelectedNode);
            Session["TreeViewState"] = SelectedNode;
        }
        else
        {
            // Apply the recorded expand/collapse state to the TreeView.
            Dictionary<string, bool> SelectedNode = (Dictionary<string, bool>)Session["TreeViewState"];
            RestoreTreeViewState(tr.Nodes, SelectedNode);
        }

    }
    private void SaveTreeViewState(TreeNodeCollection nodes, Dictionary<string, bool> SelectedNode)
    {
        // Recursivley record all expanded nodes in the List.
        foreach (TreeNode node in nodes)
        {
            if (node.ChildNodes != null && node.ChildNodes.Count != 0)
            {
                if (node.Expanded.HasValue && node.Expanded == true && !String.IsNullOrEmpty(node.Text))
                    SelectedNode.Add(node.Text, true);
                else
                    SelectedNode.Add(node.Text, false);
                SaveTreeViewState(node.ChildNodes, SelectedNode);
            }
        }
    }
    private void RestoreTreeViewState(TreeNodeCollection nodes, Dictionary<string, bool> SelectedNode)
    {
        foreach (TreeNode node in nodes)
        {
            if (Session["SelectedNode"].ToString() == node.ValuePath)
            {
                node.ImageUrl = "~/App_Themes/Granite/Images/Entry_down.gif";
                node.Selected = true;
            }
            else
            {
                node.ImageUrl = "~/App_Themes/Granite/Images/Entry.gif";
            }

            // Restore the state of one node.
            foreach (KeyValuePair<string, bool> pair in SelectedNode)
            {
                if (pair.Key == node.Text && pair.Value == true)
                {
                    node.Expand();
                }
                else if (pair.Key == node.Text && pair.Value == false)
                {
                    node.Collapse();
                }
                if (node.ChildNodes != null && node.ChildNodes.Count != 0)
                    RestoreTreeViewState(node.ChildNodes, SelectedNode);
            }
        }
    }
}
