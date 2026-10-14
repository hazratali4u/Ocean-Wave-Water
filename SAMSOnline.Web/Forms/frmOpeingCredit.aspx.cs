using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using SAMS.BusinessLayer.Classes;
using SAMS.Common.Classes;
    
public partial class Forms_frmOpeingCredit : System.Web.UI.Page
{
    private void LoadDistributor()
    {
        DistributorController DController = new DistributorController();
        DataTable dt = DController.SelectDistributorInfo(Constants.IntNullValue, int.Parse(this.Session["UserId"].ToString()), int.Parse(this.Session["CompanyId"].ToString()));
        clsWebFormUtil.FillDropDownList(this.drpDistributor, dt, 0, 2, true);
    }
    private void LoadArea()
    {
        if (drpDistributor.Items.Count > 0)
        {
            DistributorAreaController mController = new DistributorAreaController();
            DataTable dt = mController.SelectDist_Area(Constants.LongNullValue, Constants.DateNullValue, Constants.DateNullValue, int.Parse(drpDistributor.SelectedValue.ToString()), Constants.IntNullValue, null, null);
            clsWebFormUtil.FillDropDownList(DrpRoute, dt, 0, 6, true);
        }
        else
        {
            DrpRoute.Items.Clear();
        }
    }
    private void LoadData()
    {
        if (drpDistributor.Items.Count > 0 && DrpRoute.Items.Count > 0)
        {
            CustomerDataController mController = new CustomerDataController();
            DataTable dt = mController.SelectPrincipalCustomer(int.Parse(drpDistributor.SelectedValue.ToString()), int.Parse(DrpRoute.SelectedValue.ToString()), Constants.IntNullValue, int.Parse(DrpPrincipal.SelectedValue.ToString()));
            clsWebFormUtil.FillListBox(this.ListCustomer, dt, "CUSTOMER_DETAIL", "CUSTOMER_DETAIL", true);
            this.Session.Add("dt", dt);
        }
    }
    private void ClearAll()
    {
        txtChequeNo.Text = "";
        txtOutletCode.Text = "";
        txtAmount.Text = "";
        txtOutletName.Text = "";
        txtRemarks.Text = "";
        Button1.Text = "Save";
        txtOutletCode.Focus();

    }
    private void LoadPrincipal()
    {
        SKUPriceDetailController PController = new SKUPriceDetailController();
        DataTable m_dt = PController.SelectDataPrice(Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, int.Parse(this.Session["UserId"].ToString()), Constants.IntNullValue, 0, DateTime.Parse(this.Session["CurrentWorkDate"].ToString()));
        clsWebFormUtil.FillDropDownList(this.DrpPrincipal, m_dt, 0, 1, true);
    }  
    private void LoadDeliveryman()
    {
        if (drpDistributor.Items.Count > 0 && DrpRoute.Items.Count > 0)
        {
            Distributor_UserController mDController = new Distributor_UserController();
            DataTable m_dt = mDController.SelectSaleForceAssignedArea(int.Parse(drpDistributor.SelectedValue.ToString()), int.Parse(DrpRoute.SelectedValue.ToString()), int.Parse(this.Session["CompanyId"].ToString()));
            clsWebFormUtil.FillDropDownList(this.DrpDeliveryMan, m_dt, 0, 3, true);
        }
        else
        {
            DrpDeliveryMan.Items.Clear();
        }
    }
    private void LoadOpeningCredit()
    {
        if (drpDistributor.Items.Count > 0)
        {
            CustomerDataController cdc = new CustomerDataController();
            DataTable dt = cdc.SelectOpeningCredit(int.Parse(drpDistributor.SelectedValue.ToString()));
            GrdOrder.DataSource = dt;
            GrdOrder.DataBind();
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.LoadPrincipal();
            this.LoadDistributor();
            this.LoadArea();
            this.LoadData();           
            this.LoadDeliveryman();
            this.LoadOpeningCredit();
            Button1.Attributes.Add("onclick", "return ValidateForm()");
            DateTime pOrderDate = DateTime.Parse(this.Session["CurrentWorkDate"].ToString()).AddDays(1);
            txtFromdate .Text  = pOrderDate.ToString("dd-MMM-yyyy"); 
        }
    }
    protected void drpDistributor_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadArea();
        this.LoadData();
        this.LoadDeliveryman();
        this.LoadOpeningCredit();
    }
    protected void DrpRoute_SelectedIndexChanged(object sender, EventArgs e)
    {
       this.LoadData();
       this.LoadDeliveryman(); 
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        LedgerController LedgerCtl = new LedgerController();
        if (Button1.Text == "Update")
        {
            LedgerCtl.DeleteOpeningCredit(Convert.ToInt32(drpDistributor.SelectedValue), Convert.ToInt32(hfPrincipalID.Value), Convert.ToInt32(hfLegendID.Value), Convert.ToDateTime(txtFromdate.Text), Convert.ToInt32(hfCustomerID.Value), Convert.ToInt64(hfSaleInvoiceID.Value), Convert.ToInt32(this.Session["UserId"]));
        }


        OrderEntryController or = new OrderEntryController();
        DataTable dtCustomer = (DataTable)this.Session["dt"];
        DataRow[] foundRows = dtCustomer.Select("CUSTOMER_CODE  = '" + txtOutletCode.Text.Trim() + "'");
        if (foundRows.Length > 0)
        {
            or.OpeningCredit(int.Parse(drpDistributor.SelectedValue.ToString()), int.Parse(foundRows[0]["TOWN_ID"].ToString()), int.Parse(DrpRoute.SelectedValue.ToString()),
            DateTime.Parse(txtFromdate.Text),int.Parse(DrpPrincipal.SelectedValue.ToString()), long.Parse(foundRows[0]["CUSTOMER_ID"].ToString()), long.Parse(foundRows[0]["CUSTOMER_ID"].ToString()),
            -1, int.Parse(DrpDeliveryMan.SelectedValue.ToString()), decimal.Parse(txtAmount.Text), int.Parse(this.Session["UserId"].ToString()), txtChequeNo.Text,txtRemarks .Text );
            this.ClearAll();
            this.LoadOpeningCredit();
        }
        ScriptManager.GetCurrent(Page).SetFocus(txtOutletCode);   
       
    }
    protected void DrpPrincipal_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadData();
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        this.ClearAll();
    }


    protected void GrdOrder_RowEditing(object sender, GridViewEditEventArgs e)
    {
      //  DrpCreditType.SelectedValue = GrdOrder.Rows[e.NewEditIndex].Cells[7].Text;
        DrpPrincipal.SelectedValue = GrdOrder.Rows[e.NewEditIndex].Cells[1].Text;
        txtFromdate.Text = Convert.ToDateTime(GrdOrder.Rows[e.NewEditIndex].Cells[9].Text).ToString("dd-MMM-yyyy");
        txtOutletCode.Text = GrdOrder.Rows[e.NewEditIndex].Cells[8].Text;
        txtOutletName.Text = GrdOrder.Rows[e.NewEditIndex].Cells[3].Text;
        txtChequeNo.Text = GrdOrder.Rows[e.NewEditIndex].Cells[5].Text;
        txtAmount.Text = GrdOrder.Rows[e.NewEditIndex].Cells[6].Text;
        txtRemarks.Text = GrdOrder.Rows[e.NewEditIndex].Cells[12].Text;
        Button1.Text = "Update";

        DrpRoute.SelectedValue = GrdOrder.Rows[e.NewEditIndex].Cells[11].Text;
        hfLegendID.Value = GrdOrder.Rows[e.NewEditIndex].Cells[7].Text;
        hfPrincipalID.Value = GrdOrder.Rows[e.NewEditIndex].Cells[1].Text;
        hfCustomerID.Value = GrdOrder.Rows[e.NewEditIndex].Cells[0].Text;
        hfSaleInvoiceID.Value = GrdOrder.Rows[e.NewEditIndex].Cells[10].Text;
        this.LoadData();
        this.LoadDeliveryman();
        //   ImgBntFromCalc.Enabled = true;


    }

    protected void GrdOrder_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        hfLegendID.Value = GrdOrder.Rows[e.RowIndex].Cells[7].Text;
        hfPrincipalID.Value = GrdOrder.Rows[e.RowIndex].Cells[1].Text;
        hfCustomerID.Value = GrdOrder.Rows[e.RowIndex].Cells[0].Text;
        hfSaleInvoiceID.Value = GrdOrder.Rows[e.RowIndex].Cells[10].Text;

        LedgerController LedgerCtl = new LedgerController();
        if (LedgerCtl.DeleteOpeningCredit(Convert.ToInt32(drpDistributor.SelectedValue), Convert.ToInt32(hfPrincipalID.Value), Convert.ToInt32(hfLegendID.Value), Convert.ToDateTime(txtFromdate.Text), Convert.ToInt32(hfCustomerID.Value), Convert.ToInt64(hfSaleInvoiceID.Value), Convert.ToInt32(this.Session["UserId"])))
        {
            this.ClearAll();
            this.LoadOpeningCredit();
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('Some error occured. Opening Credit not deleted.');", true);
        }

    }

}
