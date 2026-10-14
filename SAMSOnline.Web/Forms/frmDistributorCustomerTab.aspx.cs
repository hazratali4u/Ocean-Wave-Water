using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using SAMS.BusinessLayer.Classes;
using SAMS.Common.Classes;    

public partial class Forms_frmDistributorCustomerTab : System.Web.UI.Page
{


    #region Cutomer
    private static long CustomerId;
    private static string StrCode;

    private void LoadDistributor()
    {
        DistributorController mController = new DistributorController();
        DataTable dt = mController.SelectDistributorInfo(Constants.IntNullValue, int.Parse(this.Session["UserId"].ToString()), int.Parse(this.Session["CompanyId"].ToString()));      
        clsWebFormUtil.FillDropDownList(DrpDistributor, dt, 0, 2, true);

    }
    protected void LoadTown()
    {
        if (DrpDistributor.Items.Count > 0)
        {
            GeoHierarchyController gController = new GeoHierarchyController();
            DataTable dt = gController.SelectGeoHierarchy(int.Parse(DrpDistributor.SelectedValue.ToString()));
            clsWebFormUtil.FillDropDownList(DrpTown, dt, 0, 1, true);
        }       
    }
    private void LoadArea()
    {
        if (DrpDistributor.Items.Count > 0 && DrpTown.Items.Count > 0)
        {
            DistributorAreaController mController = new DistributorAreaController();
            DataTable dt = mController.SelectDist_Area(Constants.LongNullValue, Constants.DateNullValue, Constants.DateNullValue, int.Parse(DrpDistributor.SelectedValue.ToString()), int.Parse(DrpTown.SelectedValue.ToString()), null, null);
            clsWebFormUtil.FillDropDownList(DrpRoute, dt, 0, 6, true);
        }
    }
    private void LoadRoute()
    {
        if (DrpDistributor.Items.Count > 0 && DrpTown.Items.Count > 0 && DrpRoute.Items.Count > 0)
        {
            DistributorRouteController gController = new DistributorRouteController();
            DataTable dt = gController.SelectDistributorRoute(Constants.LongNullValue,int.Parse(DrpDistributor.SelectedValue.ToString()),int.Parse(DrpTown.SelectedValue.ToString()),long.Parse(DrpRoute.SelectedValue.ToString()));               
            clsWebFormUtil.FillDropDownList(DrpMarket, dt, 0, 8, true);

        }
        else
        {
            DrpMarket.Items.Clear();   
        }
    }
    private void ClearAll()
    {
        txtCustomerName.Text = "";
        txtContactPerson.Text = "";
        txtAddress.Text = "";
        txtemail.Text = "";
        txtPhoneNo.Text = "";
        txtSeach.Text = "";
        txtIsRegister.Text = "";
        btnSave.Text = "Save";
        Grid_users.DataSource = null;
        Grid_users.DataBind();
        this.LoadPrincipal();
        DrpDistributor.Enabled = true ;
        txtRefferedBy.Text = "";
        txtRegdate.Text = SAMS.Common.Classes.Configuration.SystemCurrentDateTime.ToString("dd-MMM-yyyy");
    }
    private void LoadCustomer()
    {
        if (DrpDistributor.Items.Count > 0 && DrpTown.Items.Count > 0 && DrpRoute.Items.Count > 0 && DrpMarket.Items.Count > 0 )
        {
            CustomerDataController mController = new CustomerDataController();
            DataTable  dt = mController.UspSelectCustomer(int.Parse(DrpDistributor.SelectedValue.ToString()), ddSearchType.SelectedValue.ToString(), txtSeach.Text);     
            this.Grid_users.DataSource = dt;
            this.Grid_users.DataBind();  
        }
    }
    private void LoadChannelType()
    {
        SLASHCodesController mController = new SLASHCodesController();
        DataTable dt = mController.SelectSlashCodes(Constants.IntNullValue, null, Constants.CustomerChannelType, null, Constants.IntNullValue, bool.Parse("True"));
        clsWebFormUtil.FillDropDownList(drpChannelType, dt, 0, 2, true);

    }
    private void LoadPrincipal()
    {
        var PController = new SKUPriceDetailController();
        DataTable m_dt = PController.SelectDataPrice(Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, int.Parse(this.Session["UserId"].ToString()), Constants.IntNullValue, 0, DateTime.Parse(this.Session["CurrentWorkDate"].ToString()));
        GrdCreditLimit.DataSource = m_dt;
        GrdCreditLimit.DataBind();
    }
    private void LoadBusinessType()
    {
        SLASHCodesController mController = new SLASHCodesController();
        DataTable dt = mController.SelectSlashCodes(Constants.IntNullValue, null, Constants.CustomerTypeBusiness, null, Constants.IntNullValue, bool.Parse("True"));
        clsWebFormUtil.FillDropDownList(DrpBusinessType, dt, 0, 2, true);

    }
    private void LoadVolumeType()
    {
        SLASHCodesController mController = new SLASHCodesController();
        DataTable dt = mController.SelectSlashCodes(Constants.IntNullValue, null, Constants.CustomerVolumeClassType, null, Constants.IntNullValue, bool.Parse("True"));
        clsWebFormUtil.FillDropDownList(DrpVolumeClass, dt, 0, 2, true);

    }
    private void UpdateCustomerPrincipalCredit()
    {
        CustomerDataController mCustomer = new CustomerDataController();
        DataControl dc = new DataControl();
        mCustomer.UpdateCustomerCreditLimit(int.Parse(DrpDistributor.SelectedValue.ToString()), CustomerId, Constants.IntNullValue, Constants.DecimalNullValue);
        for (int i = 0; i < GrdCreditLimit.Rows.Count; i++)
        {
            TextBox txtCrLimit = (TextBox)GrdCreditLimit.Rows[i].FindControl("txtCreditLimit");
            TextBox txtCrDays = (TextBox)GrdCreditLimit.Rows[i].FindControl("txtCreditDays");
            if (decimal.Parse(dc.chkNull_0(txtCrLimit.Text)) > 0)
            {
                mCustomer.InsertCustomerCreditLimit(int.Parse(DrpDistributor.SelectedValue.ToString()), CustomerId, int.Parse(GrdCreditLimit.Rows[i].Cells[0].Text), decimal.Parse(txtCrLimit.Text),int.Parse(txtCrDays.Text));
            }
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.LoadPrincipal(); 
            this.LoadDistributor();
            this.LoadTown();
            this.LoadArea();
            this.LoadRoute();
            this.LoadChannelType();
            this.LoadBusinessType();
            this.LoadVolumeType();
            btnSave.Attributes.Add("onclick", "return ValidateForm()");
            Button2.Attributes.Add("onclick", "return SearchRecord()");
            Configuration.SystemCurrentDateTime = (DateTime)this.Session["CurrentWorkDate"];
            txtRegdate.Text = Configuration.SystemCurrentDateTime.ToString("dd-MMM-yyyy");


           // Security Tab
            this.LoadDistributor2();
            this.LoadArea2();
            this.LoadDeliveryman2();
            this.LoadPrincipal2();
            this.LoadCustomerData2();
            this.LoadSkuDetail2();
            this.LoadGrid2();
         
         
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        var mController = new CustomerDataController();
        if (btnSave.Text == "Save")
        {
            var mSettingsTableControl = new SETTINGS_TABLE_Controller();
            DataTable dtSettingsTable = mSettingsTableControl.Select_SETTINGS_TABLE("CUSTOMER", "CUSTOMER_ID", int.Parse(DrpDistributor.SelectedValue.ToString()));

            if (dtSettingsTable.Rows.Count > 0)
            {
                CustomerId = long.Parse(dtSettingsTable.Rows[0]["Value"].ToString()) + 1;
                if (CustomerId.ToString().Length == 1)
                {
                    StrCode = "OT0000" + CustomerId.ToString();
                }
                else if (CustomerId.ToString().Length == 2)
                {
                    StrCode = "OT000" + CustomerId.ToString();
                }
                else if (CustomerId.ToString().Length == 3)
                {
                    StrCode = "OT00" + CustomerId.ToString();
                }
                else if (CustomerId.ToString().Length == 4)
                {
                    StrCode = "OT0" + CustomerId.ToString();
                }
                else if (CustomerId.ToString().Length == 5)
                {
                    StrCode = "OT" + CustomerId.ToString();
                }
                mController.InsertCustomer(CustomerId, ChbIsRegister.Checked, chkIsActive.Checked,
                int.Parse(drpChannelType.SelectedValue.ToString()), int.Parse(DrpVolumeClass.SelectedValue.ToString()),
                int.Parse(DrpBusinessType.SelectedValue.ToString()), int.Parse(DrpRoute.SelectedValue.ToString()), int.Parse(DrpMarket.SelectedValue.ToString()),
                int.Parse(DrpTown.SelectedValue.ToString()), int.Parse(DrpDistributor.SelectedValue.ToString()), txtIsRegister.Text, txtContactPerson.Text,
                txtPhoneNo.Text, txtemail.Text, StrCode, txtCustomerName.Text, txtAddress.Text, DateTime.Parse(txtRegdate.Text), int .Parse (DrpCustomerType .SelectedValue) ,txtRefferedBy .Text);

            }
        }
        else
        {
            mController.UpdateCustomer(CustomerId, ChbIsRegister.Checked, chkIsActive.Checked,
            int.Parse(drpChannelType.SelectedValue.ToString()), int.Parse(DrpVolumeClass.SelectedValue.ToString()),
            int.Parse(DrpBusinessType.SelectedValue.ToString()), int.Parse(DrpRoute.SelectedValue.ToString()), int.Parse(DrpMarket.SelectedValue.ToString()),
            int.Parse(DrpTown.SelectedValue.ToString()), int.Parse(DrpDistributor.SelectedValue.ToString()), txtIsRegister.Text, txtContactPerson.Text,
            txtPhoneNo.Text, txtemail.Text, null, txtCustomerName.Text, txtAddress.Text, DateTime.Parse(txtRegdate.Text), int.Parse(DrpCustomerType.SelectedValue), txtRefferedBy.Text);
        }
        this.UpdateCustomerPrincipalCredit();
        ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('Record Update');", true);
        this.ClearAll();
     }
    protected void DrpDistributor_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadTown();
        this.LoadArea();
        this.LoadRoute();
    }
    protected void DrpTown_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadArea();
        this.LoadRoute();
    }
    protected void DrpRoute_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadRoute();
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        this.LoadCustomer(); 
    }
    protected void Grid_users_RowEditing(object sender, GridViewEditEventArgs e)
    {
        
        CustomerId = int.Parse(Grid_users.Rows[e.NewEditIndex].Cells[0].Text);
        DrpDistributor.SelectedValue = Grid_users.Rows[e.NewEditIndex].Cells[1].Text;
        DrpBusinessType.SelectedValue = Grid_users.Rows[e.NewEditIndex].Cells[2].Text;
        DrpVolumeClass.SelectedValue = Grid_users.Rows[e.NewEditIndex].Cells[3].Text;
        drpChannelType.SelectedValue = Grid_users.Rows[e.NewEditIndex].Cells[4].Text;
        this.LoadTown();  
        DrpTown.SelectedValue =  Grid_users.Rows[e.NewEditIndex].Cells[5].Text;
        this.LoadArea();
        DrpRoute.SelectedValue = Grid_users.Rows[e.NewEditIndex].Cells[6].Text;
        this.LoadRoute();
        DrpMarket.SelectedValue = Grid_users.Rows[e.NewEditIndex].Cells[7].Text;
        DrpCustomerType.SelectedValue = Grid_users.Rows[e.NewEditIndex].Cells[21].Text.Replace("&nbsp;", "1");
        txtRefferedBy.Text = Grid_users.Rows[e.NewEditIndex].Cells[22].Text.Replace("&nbsp;", "");
        txtCustomerName.Text = Grid_users.Rows[e.NewEditIndex].Cells[9].Text.Replace("amp;", "");
        txtContactPerson.Text = Grid_users.Rows[e.NewEditIndex].Cells[10].Text.Replace("&nbsp;", "");
        txtPhoneNo.Text = Grid_users.Rows[e.NewEditIndex].Cells[11].Text.Replace("&nbsp;", "");
        txtemail.Text = Grid_users.Rows[e.NewEditIndex].Cells[12].Text.Replace("&nbsp;", "");
        txtAddress.Text = Grid_users.Rows[e.NewEditIndex].Cells[13].Text.Replace("&nbsp;", "");
        txtIsRegister.Text = Grid_users.Rows[e.NewEditIndex].Cells[14].Text.Replace("&nbsp;", "");
        if (Grid_users.Rows[e.NewEditIndex].Cells[14].Text.Trim() == "&nbsp;")
        {
            txtIsRegister.Text = "";
            ChbIsRegister.Checked = false;
        }
        else
        {
            ChbIsRegister.Checked = true;
            txtIsRegister.Text = Grid_users.Rows[e.NewEditIndex].Cells[14].Text;
        }
        chkIsActive.Checked = bool.Parse(Grid_users.Rows[e.NewEditIndex].Cells[19].Text);
        txtRegdate.Text = DateTime .Parse (Grid_users.Rows[e.NewEditIndex].Cells[20].Text).ToString ("dd-MMM-yyyy");
        CustomerDataController mCustomer = new CustomerDataController();

        for (int i = 0; i < GrdCreditLimit.Rows.Count; i++)
        {
            DataTable dtCLimit = mCustomer.SelectCustomerCreditLimit(int.Parse(DrpDistributor.SelectedValue.ToString()), CustomerId, int.Parse(GrdCreditLimit.Rows[i].Cells[0].Text));
            if (dtCLimit.Rows.Count > 0)
            {
                TextBox txtCLimit = (TextBox)GrdCreditLimit.Rows[i].FindControl("txtCreditLimit");
                TextBox txtCRDays = (TextBox)GrdCreditLimit.Rows[i].FindControl("txtCreditDays");

                txtCLimit.Text = dtCLimit.Rows[0]["CREDITLIMIT_VALUE"].ToString();
                txtCRDays.Text = dtCLimit.Rows[0]["CREDIT_DAYS"].ToString();
            }
            else
            {
                TextBox txtCLimit = (TextBox)GrdCreditLimit.Rows[i].FindControl("txtCreditLimit");
                TextBox txtCRDays = (TextBox)GrdCreditLimit.Rows[i].FindControl("txtCreditDays");

                txtCLimit.Text = "0";
                txtCRDays.Text = "0";
            }
        }
        btnSave.Text = "Update";
        DrpDistributor.Enabled = false;
                
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        this.ClearAll(); 
    }
    protected void Grid_users_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        Grid_users.PageIndex = e.NewPageIndex;
        this.LoadCustomer(); 
    }
    protected void ChbIsRegister_CheckedChanged(object sender, EventArgs e)
    {
        if (ChbIsRegister.Checked == true)
        {
            txtIsRegister.Text = "";
            txtIsRegister.Enabled = true;
        }
        else
        {
            txtIsRegister.Text = "";
            txtIsRegister.Enabled = false;
        }
    }

    #endregion


    #region Security Tab

    #region

    //protected void Page_Load(object sender, EventArgs e)
    // {
    //     if (!Page.IsPostBack)
    //     {
    //         this.LoadDistributor();
    //         this.LoadArea();
    //         this.LoadDeliveryman();
    //         this.LoadPrincipal();
    //         this.LoadCustomerData();
    //         this.LoadSKUDetail();
    //         this.LoadGrid();
    //         //  this.LoadInfoGrid();

    //         DateTime pOrderDate = DateTime.Parse(this.Session["CurrentWorkDate"].ToString()).AddDays(1);
    //     }
    // }
    private void LoadInfoGrid2()
    {
        DocumentPrintController DPrint = new DocumentPrintController();
        DataTable dt1 = DPrint.SelectTownWiseSales2(int.Parse(drpDistributor2.SelectedValue.ToString()), int.Parse(DrpPrincipal2.SelectedValue.ToString()), Constants.IntNullValue, Convert.ToInt32(DrpRoute2.SelectedValue), Convert.ToInt32(ddlCustomer2.SelectedValue));
        gvInfo.DataSource = dt1;
        gvInfo.DataBind();

    }
    private void LoadDistributor2()
    {
        DistributorController DController = new DistributorController();
        DataTable dt = DController.SelectDistributorInfo(Constants.IntNullValue, int.Parse(this.Session["UserId"].ToString()), int.Parse(this.Session["CompanyId"].ToString()));
        clsWebFormUtil.FillDropDownList(this.drpDistributor2, dt, 0, 2, true);
    }
    private void LoadArea2()
    {
        if (drpDistributor2.Items.Count > 0)
        {
            DistributorAreaController mController = new DistributorAreaController();
            DataTable dt = mController.SelectDist_Area(Constants.LongNullValue, Constants.DateNullValue, Constants.DateNullValue, int.Parse(drpDistributor2.SelectedValue.ToString()), Constants.IntNullValue, null, null);
            clsWebFormUtil.FillDropDownList(DrpRoute2, dt, 0, 6, true);
        }
        else
        {
            DrpRoute2.Items.Clear();
        }
    }
    private void LoadPrincipal2()
    {
        //{
        //    SKUPriceDetailController PController = new SKUPriceDetailController();
        //    DataTable m_dt = PController.SelectDataPrice(Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, int.Parse(this.Session["UserId"].ToString()), Constants.IntNullValue, 0, DateTime.Parse(this.Session["CurrentWorkDate"].ToString()));
        //    clsWebFormUtil.FillDropDownList(this.DrpPrincipal, m_dt, 0, 1, true);


        SKUPriceDetailController PController = new SKUPriceDetailController();
        DataTable m_dt = PController.SelectDataPrice(Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, int.Parse(this.Session["UserId"].ToString()), Constants.IntNullValue, 0, DateTime.Parse(this.Session["CurrentWorkDate"].ToString()));
        clsWebFormUtil.FillDropDownList(this.DrpPrincipal2, m_dt, 0, 1, true);


    }
    private void LoadDeliveryman2()
    {
        if (drpDistributor2.Items.Count > 0 && DrpRoute2.Items.Count > 0)
        {
            var mDController = new Distributor_UserController();
            var mDt = mDController.SelectSaleForceAssignedArea(int.Parse(drpDistributor2.SelectedValue.ToString()), int.Parse(DrpRoute2.SelectedValue.ToString()), int.Parse(this.Session["CompanyId"].ToString()));
            clsWebFormUtil.FillDropDownList(this.DrpDeliveryMan2, mDt, 0, 3, true);
        }
        else
        {
            DrpDeliveryMan2.Items.Clear();
        }
    }
    private void LoadCustomerData2()
    {
        if (drpDistributor2.Items.Count > 0 && DrpRoute2.Items.Count > 0)
        {
            var mController = new CustomerDataController();
            DataTable dtCustomer2 = mController.SelectPrincipalCustomer(int.Parse(drpDistributor2.SelectedValue.ToString()), Constants.IntNullValue, int.Parse(DrpRoute2.SelectedValue.ToString()),int.Parse(DrpPrincipal2 .SelectedValue ));
            clsWebFormUtil.FillDropDownList(this.ddlCustomer2, dtCustomer2, "CUSTOMER_ID", "CUSTOMER_NAME", true);
        }
    }
    private void LoadSkuDetail2()
    {
        var pController = new SKUPriceDetailController();
        if (DrpPrincipal2.Items.Count > 0)
        {
            //ddlSKU.Items.Clear();
            //ddlSKU.Items.Add("All");
            var dtskuPrice2 = pController.SelectDataPrice(int.Parse(DrpPrincipal2.SelectedValue), Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, int.Parse(drpDistributor2.SelectedValue), int.Parse(this.Session["UserId"].ToString()), Constants.IntNullValue, 1, DateTime.Parse(this.Session["CurrentWorkDate"].ToString()));
            clsWebFormUtil.FillDropDownList(this.ddlSKU2, dtskuPrice2, "SKU_ID", "SkuDetail", true);
        }
    }
    private void LoadGrid2()
    {
        if (drpDistributor2.Items.Count > 0 && drpDistributor2.Items.Count > 0 && DrpPrincipal2.Items.Count > 0 &&
            DrpRoute2.Items.Count > 0 && ddlCustomer2.Items.Count > 0 && DrpDeliveryMan2.Items.Count > 0)
        {
            var custCtl = new CustomerDataController();
            var dtSecurity = custCtl.GetCustomerSecurity2(
                Convert.ToInt32(drpDistributor2.SelectedValue),
                Convert.ToInt32(DrpPrincipal2.SelectedValue),
                Convert.ToDateTime(Session["CurrentWorkDate"]),
                Convert.ToInt64(DrpRoute2.SelectedValue),
                Convert.ToInt64(ddlCustomer2.SelectedValue),
                Convert.ToInt32(DrpDeliveryMan2.SelectedValue),
                rblTransactionType.SelectedIndex,
                Constants.IntNullValue);
            gvSecurity.DataSource = dtSecurity;
            gvSecurity.DataBind();
        }
    }
    #endregion


    #region Sel/INdex Change

    protected void DrpPrincipal2_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadGrid2();
    }
    protected void DrpDeliveryMan2_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadGrid2();
    }
    protected void ddlCustomer2_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadGrid2();
        if (int.Parse(rblTransactionType.SelectedItem.Value.ToString()) == 1)
        {
            this.LoadInfoGrid2();
        }
    }
    protected void rblTransactionType_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadGrid2();
        if (int.Parse(rblTransactionType.SelectedItem.Value.ToString()) == 1)
        {
            gvInfo.Visible = true;
            this.LoadInfoGrid2();
        }
        else
        {
            gvInfo.Visible = false;
        }
    }
    protected void ddlSKU2_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblReffileRate.Text = "Rate";
        txtAmount2.Enabled = true;
        //by safdar
        this.LoadGrid2();
        if (int.Parse (ddlSKU2.SelectedValue) == 11)
        {// mean water 19ltr
            lblReffileRate.Text = "Reffiling Rate";
        }
        if (int.Parse(ddlSKU2.SelectedValue) == 8 || int.Parse(ddlSKU2.SelectedValue) == 9 || int.Parse(ddlSKU2.SelectedValue) == 10 || int.Parse(ddlSKU2.SelectedValue) == 12 || int.Parse(ddlSKU2.SelectedValue) == 13 || int.Parse(ddlSKU2.SelectedValue) == 14)
        {
            txtAmount2.Enabled = false;
        }


    }
    protected void drpDistributor2_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadArea2();
        this.LoadDeliveryman2();
        this.LoadCustomerData2();
        this.LoadSkuDetail2();
        this.LoadGrid2();

    }
    protected void DrpRoute2_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadDeliveryman2();
        this.LoadCustomerData2();
        this.LoadGrid2();
    }

    #endregion


    #region Grid Operations

    protected void gvSecurity_RowEditing(object sender, GridViewEditEventArgs e)
    {
        hfCUSTOMER_SECURITY_ID.Value = gvSecurity.Rows[e.NewEditIndex].Cells[0].Text;
        txtNoOfBottles.Text = gvSecurity.Rows[e.NewEditIndex].Cells[4].Text;
        txtAmount2.Text = gvSecurity.Rows[e.NewEditIndex].Cells[5].Text;
        txtRate2.Text = gvSecurity.Rows[e.NewEditIndex].Cells[6].Text;
        txtRemarks.Text = gvSecurity.Rows[e.NewEditIndex].Cells[7].Text;
        ddlSKU2.SelectedValue = gvSecurity.Rows[e.NewEditIndex].Cells[8].Text;
        if (gvSecurity.Rows[e.NewEditIndex].Cells[9].Text.Trim() == "True" || gvSecurity.Rows[e.NewEditIndex].Cells[9].Text.Trim() == "&nbsp;")
        {

            chbIsPermanent.Checked = true;
        }
        else
        {
            chbIsPermanent.Checked = false;
        }

        txtDocumentNo.Text = gvSecurity.Rows[e.NewEditIndex].Cells[10].Text.Replace("&nbsp;", "");


        btnSave2.Text = "Update";

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


        if (CustCtl.UpdateCustomerSecurity(Convert.ToInt64(DC.chkNull_0(gvSecurity.Rows[e.RowIndex].Cells[0].Text)), Convert.ToInt32(drpDistributor2.SelectedValue), Convert.ToInt32(DrpPrincipal2.SelectedValue), Convert.ToInt64(DrpRoute.SelectedValue), Convert.ToInt64(ddlCustomer2.SelectedValue), Convert.ToInt32(DrpDeliveryMan2.SelectedValue), Convert.ToInt32(DC.chkNull_0(gvSecurity.Rows[e.RowIndex].Cells[4].Text)), Convert.ToDecimal(DC.chkNull_0(gvSecurity.Rows[e.RowIndex].Cells[5].Text)), Convert.ToInt32(DC.chkNull_0(gvSecurity.Rows[e.RowIndex].Cells[8].Text)), gvSecurity.Rows[e.RowIndex].Cells[7].Text, rblTransactionType.SelectedIndex, Convert.ToInt32(Session["UserID"]), false, Rate, chbIsPermanent.Checked, txtDocumentNo.Text))
        {
            txtNoOfBottles.Text = string.Empty;
            txtAmount2.Text = string.Empty;
            txtRate2.Text = string.Empty;
            txtRemarks.Text = string.Empty;
            btnSave2.Text = "Save";
            this.LoadGrid2();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('Security updated successfully.');", true);
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('Some error occured.');", true);
        }
    }

    #endregion

    protected void btnSave2_Click(object sender, EventArgs e)
    {
        CustomerDataController CustCtl = new CustomerDataController();
        DataControl DC = new DataControl();
        if ((txtAmount2.Text) == "")//|| int .Parse (txtAmount2 .Text) < 0  )
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('Enter Security Amount');", true);
            return;
        }
        if (txtNoOfBottles.Text == "" || int.Parse(txtNoOfBottles.Text) < 0)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('Enter No Of Bottles');", true);
            return;
        }
        if (btnSave2.Text == "Save")
        {
            if (CustCtl.InsertCustomerSecurity(Convert.ToInt32(drpDistributor2.SelectedValue), Convert.ToInt32(DrpPrincipal2.SelectedValue), Convert.ToDateTime(Session["CurrentWorkDate"]), Convert.ToInt64(DrpRoute2.SelectedValue), Convert.ToInt64(ddlCustomer2.SelectedValue), Convert.ToInt32(DrpDeliveryMan2.SelectedValue), Convert.ToInt32(DC.chkNull_0(txtNoOfBottles.Text)), Convert.ToDecimal(DC.chkNull_0(txtAmount2.Text)),
               Convert.ToInt32(ddlSKU2.Text), txtRemarks.Text, rblTransactionType.SelectedIndex, Convert.ToInt32(Session["UserID"]), Convert.ToDecimal(DC.chkNull_0(txtRate2.Text)), chbIsPermanent.Checked, txtDocumentNo.Text))
            {
                txtNoOfBottles.Text = string.Empty;
                txtAmount2.Text = string.Empty;
                txtRemarks.Text = string.Empty;
                txtRate2.Text = string.Empty;
                txtDocumentNo.Text = string.Empty;
                this.LoadGrid2();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('Security Saved successfully.');", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('Some error occured.');", true);
            }
        }
        else
        {
            if (CustCtl.UpdateCustomerSecurity(Convert.ToInt64(DC.chkNull_0(hfCUSTOMER_SECURITY_ID.Value)), Convert.ToInt32(drpDistributor2.SelectedValue), Convert.ToInt32(DrpPrincipal2.SelectedValue), Convert.ToInt64(DrpRoute2.SelectedValue), Convert.ToInt64(ddlCustomer2.SelectedValue), Convert.ToInt32(DrpDeliveryMan2.SelectedValue), Convert.ToInt32(DC.chkNull_0(txtNoOfBottles.Text)), Convert.ToDecimal(DC.chkNull_0(txtAmount2.Text))
               , Convert.ToInt32(ddlSKU2.SelectedValue), txtRemarks.Text, rblTransactionType.SelectedIndex, Convert.ToInt32(Session["UserID"]), true, Convert.ToDecimal(DC.chkNull_0(txtRate2.Text)), chbIsPermanent.Checked, txtDocumentNo.Text))
            {
                txtNoOfBottles.Text = string.Empty;
                txtAmount2.Text = string.Empty;
                txtRemarks.Text = string.Empty;
                txtRate2.Text = string.Empty;
                txtDocumentNo.Text = string.Empty;
                btnSave2.Text = "Save";
                this.LoadGrid2();
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
            this.LoadInfoGrid2();
        }
        else
        {
            gvInfo.Visible = false;
        }
    }
   

    #endregion

}
