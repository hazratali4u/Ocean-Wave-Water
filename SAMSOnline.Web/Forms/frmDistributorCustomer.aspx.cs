using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using SAMS.BusinessLayer.Classes;
using SAMS.Common.Classes;    

public partial class Forms_frmDistributorCustomer : System.Web.UI.Page
{
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
        SKUPriceDetailController PController = new SKUPriceDetailController();
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
            SAMS.Common.Classes.Configuration.SystemCurrentDateTime = (DateTime)this.Session["CurrentWorkDate"];     
            txtRegdate.Text = SAMS.Common.Classes.Configuration.SystemCurrentDateTime.ToString("dd-MMM-yyyy");
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        CustomerDataController mController = new CustomerDataController();
        if (btnSave.Text == "Save")
        {
            SETTINGS_TABLE_Controller mSettingsTableControl = new SETTINGS_TABLE_Controller();
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
                txtPhoneNo.Text, txtemail.Text, StrCode, txtCustomerName.Text, txtAddress.Text, DateTime.Parse(txtRegdate.Text));

            }
        }
        else
        {
            mController.UpdateCustomer(CustomerId, ChbIsRegister.Checked, chkIsActive.Checked,
            int.Parse(drpChannelType.SelectedValue.ToString()), int.Parse(DrpVolumeClass.SelectedValue.ToString()),
            int.Parse(DrpBusinessType.SelectedValue.ToString()), int.Parse(DrpRoute.SelectedValue.ToString()), int.Parse(DrpMarket.SelectedValue.ToString()),
            int.Parse(DrpTown.SelectedValue.ToString()), int.Parse(DrpDistributor.SelectedValue.ToString()), txtIsRegister.Text, txtContactPerson.Text,
            txtPhoneNo.Text, txtemail.Text , null, txtCustomerName.Text , txtAddress.Text, Constants.DateNullValue);
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
        txtRegdate.Text = Grid_users.Rows[e.NewEditIndex].Cells[20].Text;
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
}
