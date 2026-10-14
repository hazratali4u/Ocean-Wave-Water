using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using SAMS.BusinessLayer.Classes;
using SAMS.Common.Classes;

public partial class Forms_frmAdvanceSecurity : System.Web.UI.Page
{

    #region

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.LoadDistributor();
            this.LoadArea();
            this.LoadDeliveryman();
            this.LoadPrincipal();
            this.LoadCustomerData();
            this.LoadSKUDetail();
            this.LoadGrid();
            //  this.LoadInfoGrid();

            DateTime pOrderDate = DateTime.Parse(this.Session["CurrentWorkDate"].ToString()).AddDays(1);
        }
    }
    private void LoadInfoGrid()
    {
        DocumentPrintController DPrint = new DocumentPrintController();
        DataTable dt1 = DPrint.SelectTownWiseSales2(int.Parse(drpDistributor.SelectedValue.ToString()), int.Parse(DrpPrincipal.SelectedValue.ToString()), Constants.IntNullValue, Convert.ToInt32(DrpRoute.SelectedValue), Convert.ToInt32(ddlCustomer.SelectedValue));
        gvInfo.DataSource = dt1;
        gvInfo.DataBind();

    }
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
            DataTable dt = mController.SelectDist_Area(Constants.LongNullValue, Constants.DateNullValue, Constants.DateNullValue, int.Parse(drpDistributor.SelectedValue.ToString()),Constants.IntNullValue, null, null);
            clsWebFormUtil.FillDropDownList(DrpRoute, dt, 0, 6, true);
        }
        else
        {
            DrpRoute.Items.Clear();
        }
    }
    private void LoadPrincipal()
    {
        //{
    //    SKUPriceDetailController PController = new SKUPriceDetailController();
    //    DataTable m_dt = PController.SelectDataPrice(Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, int.Parse(this.Session["UserId"].ToString()), Constants.IntNullValue, 0, DateTime.Parse(this.Session["CurrentWorkDate"].ToString()));
    //    clsWebFormUtil.FillDropDownList(this.DrpPrincipal, m_dt, 0, 1, true);


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
    private void LoadCustomerData()
    {
        if (drpDistributor.Items.Count > 0 && DrpRoute.Items.Count > 0)
        {
            CustomerDataController mController = new CustomerDataController();
            DataTable dtCustomer = mController.SelectPrincipalCustomer(int.Parse(drpDistributor.SelectedValue.ToString()), int.Parse(DrpRoute.SelectedValue.ToString()), Constants.IntNullValue, Constants.IntNullValue);
            // DataTable dtCustomer = mController.SelectPrincipalCustomer(int.Parse(drpDistributor.SelectedValue.ToString ()), int.Parse(DrpPrincipal.SelectedValue.ToString ()),Convert.ToDateTime(this.Session["CurrentWorkDate"].ToString()));
            // DataTable dtCustomer = mController.SelectPrincipalCustomer(int.Parse(drpDistributor.SelectedValue.ToString()), int.Parse(DrpPrincipal.SelectedValue.ToString()), DateTime.Parse(this.Session["CurrentWorkDate"].ToString()));
            clsWebFormUtil.FillDropDownList(this.ddlCustomer, dtCustomer, "CUSTOMER_ID", "CUSTOMER_NAME", true);
        }
    }
    private void LoadSKUDetail()
    {
        SKUPriceDetailController PController = new SKUPriceDetailController();
        if (DrpPrincipal.Items.Count > 0)
        {
            //ddlSKU.Items.Clear();
            //ddlSKU.Items.Add("All");
            DataTable Dtsku_Price = PController.SelectDataPrice(int.Parse(DrpPrincipal.SelectedValue), Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, int.Parse(drpDistributor.SelectedValue), int.Parse(this.Session["UserId"].ToString()), Constants.IntNullValue, 1, DateTime.Parse(this.Session["CurrentWorkDate"].ToString()));
            clsWebFormUtil.FillDropDownList(this.ddlSKU, Dtsku_Price, "SKU_ID", "SkuDetail", true);
        }
    }
    private void LoadGrid()
    {
        CustomerDataController CustCtl = new CustomerDataController();
        DataTable dtSecurity;
        // DataTable dtSecurity = CustCtl.GetCustomerSecurity(Convert.ToInt32(drpDistributor.SelectedValue), Convert.ToInt32(DrpPrincipal.SelectedValue), Convert.ToDateTime(Session["CurrentWorkDate"]), Convert.ToInt64(DrpRoute.SelectedValue), Convert.ToInt64(ddlCustomer.SelectedValue), Convert.ToInt32(DrpDeliveryMan.SelectedValue),rblTransactionType.SelectedIndex);Convert .ToInt32 (ddlSKU .SelectedValue )

        dtSecurity = CustCtl.GetCustomerSecurity2(Convert.ToInt32(drpDistributor.SelectedValue), Convert.ToInt32(DrpPrincipal.SelectedValue), Convert.ToDateTime(Session["CurrentWorkDate"]), Convert.ToInt64(DrpRoute.SelectedValue), Convert.ToInt64(ddlCustomer.SelectedValue), Convert.ToInt32(DrpDeliveryMan.SelectedValue), rblTransactionType.SelectedIndex, Constants.IntNullValue);


        gvSecurity.DataSource = dtSecurity;
        gvSecurity.DataBind();
    }
    #endregion
  
    #region Sel/INdex Change

    protected void DrpPrincipal_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadGrid();
    }
    protected void DrpDeliveryMan_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadGrid();
    }
    protected void ddlCustomer_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadGrid();
        if (int.Parse(rblTransactionType.SelectedItem.Value.ToString()) == 1)
        {
            this.LoadInfoGrid();
        }
    }
    protected void rblTransactionType_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadGrid();
        if (int.Parse(rblTransactionType.SelectedItem.Value.ToString()) == 1)
        {
            gvInfo.Visible = true;
            this.LoadInfoGrid();
        }
        else
        {
            gvInfo.Visible = false;
        }
    }
    protected void ddlSKU_SelectedIndexChanged(object sender, EventArgs e)
    {
        //by safdar
        this.LoadGrid();
    }
    protected void drpDistributor_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadArea();
        this.LoadDeliveryman();
        this.LoadCustomerData();
        this.LoadSKUDetail();
        this.LoadGrid();
        
    }
    protected void DrpRoute_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadDeliveryman();
        this.LoadCustomerData();
        this.LoadGrid();
    }

    #endregion

    #region Grid Operations

    protected void gvSecurity_RowEditing(object sender, GridViewEditEventArgs e)
    {
        hfCUSTOMER_SECURITY_ID.Value = gvSecurity.Rows[e.NewEditIndex].Cells[0].Text;
        txtNoOfBottles.Text = gvSecurity.Rows[e.NewEditIndex].Cells[4].Text;
        txtAmount.Text = gvSecurity.Rows[e.NewEditIndex].Cells[5].Text;
        txtRate.Text = gvSecurity.Rows[e.NewEditIndex].Cells[6].Text;
        txtRemarks.Text = gvSecurity.Rows[e.NewEditIndex].Cells[7].Text;
        ddlSKU.SelectedValue = gvSecurity.Rows[e.NewEditIndex].Cells[8].Text;
        btnSave.Text = "Update";

    }
    protected void gvSecurity_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        CustomerDataController CustCtl = new CustomerDataController();
        DataControl DC = new DataControl();
        decimal Rate = Constants.DecimalNullValue;

        try
        {
            Rate = Convert.ToDecimal(DC.chkNull_0(gvSecurity.Rows[e.RowIndex].Cells[6].Text));
        }
        catch (Exception ex)
        {
            Rate = Constants.DecimalNullValue;
        }
        

        if (CustCtl.UpdateCustomerSecurity(Convert.ToInt64(DC.chkNull_0(gvSecurity.Rows[e.RowIndex].Cells[0].Text)), Convert.ToInt32(drpDistributor.SelectedValue), Convert.ToInt32(DrpPrincipal.SelectedValue), Convert.ToInt64(DrpRoute.SelectedValue), Convert.ToInt64(ddlCustomer.SelectedValue), Convert.ToInt32(DrpDeliveryMan.SelectedValue), Convert.ToInt32(DC.chkNull_0(gvSecurity.Rows[e.RowIndex].Cells[4].Text)), Convert.ToDecimal(DC.chkNull_0(gvSecurity.Rows[e.RowIndex].Cells[5].Text)), Convert.ToInt32(DC.chkNull_0(gvSecurity.Rows[e.RowIndex].Cells[8].Text)), gvSecurity.Rows[e.RowIndex].Cells[7].Text, rblTransactionType.SelectedIndex, Convert.ToInt32(Session["UserID"]), false, Rate))
        {
            txtNoOfBottles.Text = string.Empty;
            txtAmount.Text = string.Empty;
            txtRate.Text = string.Empty;
            txtRemarks.Text = string.Empty;
            btnSave.Text = "Save";
            this.LoadGrid();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('Security updated successfully.');", true);
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('Some error occured.');", true);
        }
    }

    #endregion

    protected void btnSave_Click(object sender, EventArgs e)
    {
        CustomerDataController CustCtl = new CustomerDataController();
        DataControl DC = new DataControl();
        if (DC.chkNull_0(txtAmount.Text) == "0" && DC.chkNull_0(txtNoOfBottles.Text) == "0")
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('Enter No Of Bottles or Security Amount');", true);
            return;
        }
        if (btnSave.Text == "Save")
        {
            if (CustCtl.InsertCustomerSecurity(Convert.ToInt32(drpDistributor.SelectedValue), Convert.ToInt32(DrpPrincipal.SelectedValue), Convert.ToDateTime(Session["CurrentWorkDate"]), Convert.ToInt64(DrpRoute.SelectedValue), Convert.ToInt64(ddlCustomer.SelectedValue), Convert.ToInt32(DrpDeliveryMan.SelectedValue), Convert.ToInt32(DC.chkNull_0(txtNoOfBottles.Text)), Convert.ToDecimal(DC.chkNull_0(txtAmount.Text)),
               Convert.ToInt32(ddlSKU.Text), txtRemarks.Text, rblTransactionType.SelectedIndex, Convert.ToInt32(Session["UserID"]), Convert.ToDecimal(DC.chkNull_0(txtRate.Text))))
            {
                txtNoOfBottles.Text = string.Empty;
                txtAmount.Text = string.Empty;
                txtRemarks.Text = string.Empty;
                txtRate.Text = string.Empty;
                this.LoadGrid();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('Security Saved successfully.');", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('Some error occured.');", true);
            }
        }
        else
        {
            if (CustCtl.UpdateCustomerSecurity(Convert.ToInt64(DC.chkNull_0(hfCUSTOMER_SECURITY_ID.Value)), Convert.ToInt32(drpDistributor.SelectedValue), Convert.ToInt32(DrpPrincipal.SelectedValue), Convert.ToInt64(DrpRoute.SelectedValue), Convert.ToInt64(ddlCustomer.SelectedValue), Convert.ToInt32(DrpDeliveryMan.SelectedValue), Convert.ToInt32(DC.chkNull_0(txtNoOfBottles.Text)), Convert.ToDecimal(DC.chkNull_0(txtAmount.Text))
               , Convert.ToInt32(ddlSKU.SelectedValue), txtRemarks.Text, rblTransactionType.SelectedIndex, Convert.ToInt32(Session["UserID"]), true, Convert.ToDecimal(DC.chkNull_0(txtRate.Text))))
            {
                txtNoOfBottles.Text = string.Empty;
                txtAmount.Text = string.Empty;
                txtRemarks.Text = string.Empty;
                txtRate.Text = string.Empty;
                btnSave.Text = "Save";
                this.LoadGrid();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('Security updated successfully.');", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('Some error occured.');", true);
            }
        }
        if (int.Parse(rblTransactionType.SelectedItem.Value.ToString()) == 1)
        {
            gvInfo.Visible = true;
            this.LoadInfoGrid();
        }
        else
        {
            gvInfo.Visible = false;
        }
    }

}
