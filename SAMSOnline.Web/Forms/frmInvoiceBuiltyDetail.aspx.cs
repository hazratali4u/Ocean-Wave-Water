using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using SAMS.BusinessLayer.Classes;
using SAMS.Common.Classes;
    
public partial class Forms_frmInvoiceBuiltyDetail : System.Web.UI.Page
{
    private void LoadTransporter()
    {
        DataTable dt =  DistributorController.SelectTranspoter();
        clsWebFormUtil.FillDropDownList(DrpTransporter, dt, 0, 1);
          
    }
    private void LoadDistributor()
    {
        DistributorController DController = new DistributorController();
        DataTable dt = DController.SelectDistributorInfo(Constants.IntNullValue, int.Parse(this.Session["UserId"].ToString()), int.Parse(this.Session["CompanyId"].ToString()));
        clsWebFormUtil.FillDropDownList(this.drpDistributor, dt, 0, 2, true);
    }
    private void LoadPrincipal()
    {
        SKUPriceDetailController PController = new SKUPriceDetailController();
        DataTable m_dt = PController.SelectDataPrice(Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, int.Parse(this.Session["UserId"].ToString()), Constants.IntNullValue, 0, DateTime.Parse(this.Session["CurrentWorkDate"].ToString()));
        clsWebFormUtil.FillDropDownList(this.DrpPrincipal, m_dt, 0, 1);
    }
    private void LoadCustomer()
    {
        if (drpDistributor.Items.Count > 0)
        {
            CustomerDataController mController = new CustomerDataController();
            DataTable dtCustomer = mController.SelectPrincipalCustomer(int.Parse(drpDistributor.SelectedValue.ToString()), int.Parse(DrpPrincipal.SelectedValue.ToString()), DateTime.Parse(this.Session["CurrentWorkDate"].ToString()));
            clsWebFormUtil.FillDropDownList(this.DrpCustomer, dtCustomer, 0, 4, true);
            if (dtCustomer.Rows.Count > 0)
            {
                DrpInvoiceNo.Items.Clear();   
                DataRow[] foundRows = dtCustomer.Select("Customer_id  = " + DrpCustomer.SelectedValue);
                for (int i = 0; i < foundRows.Length; i++)
                {
                    DrpInvoiceNo.Items.Add(new ListItem(foundRows[i]["Sale_Invoice_Id"].ToString(), foundRows[i]["Sale_Invoice_Id"].ToString()));

                }
                this.Session.Add("dtCustomer", dtCustomer);
            }
        }
        else
        {
            DrpCustomer.Items.Clear();
        }
    }
    private void LoadGrid()
    {
        if (drpDistributor.Items.Count > 0)
        {
            LedgerController LController = new LedgerController();
            DataTable dt = LController.SelectBankCashTransction(int.Parse(drpDistributor.SelectedValue.ToString()), Constants.IntNullValue, Constants.Builty_Exp ,
                DateTime.Parse(this.Session["CurrentWorkDate"].ToString()), DateTime.Parse(this.Session["CurrentWorkDate"].ToString()));
            GrdOrder.DataSource = dt;
            GrdOrder.DataBind();
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.LoadDistributor();
            this.LoadPrincipal();
            this.LoadCustomer();
            this.LoadTransporter();
            this.LoadGrid();
        }
    }
    protected void btnAddNew_Click(object sender, EventArgs e)
    {
        LedgerController LController = new LedgerController();
        SAMS.Common.Classes.Configuration.GetAccountHead();
     
        string MaxDocumentId = LController.SelectLedgerMaxDocumentId(Constants.Journal_Voucher, int.Parse(drpDistributor.SelectedValue.ToString()));

        LController.PostingCash_Bank_Account(Constants.Journal_Voucher, long.Parse(MaxDocumentId), long.Parse(SAMS.Common.Classes.Configuration.BuiltyExp.ToString()) , int.Parse(drpDistributor.SelectedValue.ToString()), decimal.Parse(txtAmount.Text), 0,
               DateTime.Parse(this.Session["CurrentWorkDate"].ToString()), txtRemarks.Text , DateTime.Now, int.Parse(DrpCustomer.SelectedValue.ToString()), int.Parse(DrpPrincipal.SelectedValue.ToString()),
                null, int.Parse(this.Session["UserId"].ToString()), int.Parse(DrpInvoiceNo.SelectedValue.ToString()), Constants.Document_Invoice, null, Constants.DateNullValue, Constants.Builty_Exp, DrpTransporter.SelectedValue.ToString());
        this.LoadGrid();
        txtAmount.Text = "";
        txtRemarks.Text = ""; 
    }
    protected void DrpCustomer_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataTable dtCustomer = (DataTable)this.Session["dtCustomer"];
        
        DrpInvoiceNo.Items.Clear();   
        
        DataRow[] foundRows = dtCustomer.Select("Customer_id  = " + DrpCustomer.SelectedValue);
        
        for (int i = 0; i < foundRows.Length; i++)
        {
            DrpInvoiceNo.Items.Add(new ListItem(foundRows[i]["Sale_Invoice_Id"].ToString(), foundRows[i]["Sale_Invoice_Id"].ToString()));

        }
 
    }
    protected void GrdOrder_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        LedgerController LController = new LedgerController();
        DataControl dc = new DataControl();

        LController.DeleteWareHouseLedger(int.Parse(drpDistributor.SelectedValue.ToString()), int.Parse(dc.chkNull_0(GrdOrder.Rows[e.RowIndex].Cells[2].Text)),
        int.Parse(dc.chkNull_0(GrdOrder.Rows[e.RowIndex].Cells[7].Text)), Constants.LongNullValue, decimal.Parse(dc.chkNull_0(GrdOrder.Rows[e.RowIndex].Cells[8].Text)));
        this.LoadGrid();
        
    }
    protected void drpDistributor_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadCustomer(); 
        this.LoadGrid();
    }
    protected void DrpPrincipal_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadCustomer(); 
    }
}
