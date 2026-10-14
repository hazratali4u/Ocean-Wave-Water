using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using SAMS.BusinessLayer.Classes;
using SAMS.Common.Classes;    

public partial class SKU_Price : System.Web.UI.Page
{    
    private void Populate_drpSKUCompany()
    {
        SkuHierarchyController mHer_Controller = new SkuHierarchyController();
        DataTable m_dt = mHer_Controller.SelectSkuHierarchy(Constants.SKUPrincipal, Constants.IntNullValue, Constants.IntNullValue, null, null, true, int.Parse(this.Session["CompanyId"].ToString()));
        clsWebFormUtil.FillDropDownList(this.ddskuPrincipal, m_dt, 0, 3, true);
    }
    private void Populate_drpSKUDivisions()
    {
        if (ddskuPrincipal.Items.Count > 0)
        {
            SkuHierarchyController mHer_Controller = new SkuHierarchyController();
            string strSKUCompanyID = this.ddskuPrincipal.SelectedItem.Value;

            if (int.Parse(strSKUCompanyID) > 0)
            {
                DataTable m_dt = mHer_Controller.SelectSkuHierarchy(Constants.SKUDivision, Constants.IntNullValue, int.Parse(strSKUCompanyID), null, null, true, int.Parse(this.Session["CompanyId"].ToString()));
                clsWebFormUtil.FillDropDownList(this.ddskuDivision, m_dt, 0, 3, true);
            }
        }
    }
    private void Populate_drpSKUCategory()
    {
        if (ddskuDivision.Items.Count > 0)
        {
            SkuHierarchyController mHer_Controller = new SkuHierarchyController();
            string strSKUDivisionID = this.ddskuDivision.SelectedItem.Value;

            if (int.Parse(strSKUDivisionID) > 0)
            {
                DataTable m_dt = mHer_Controller.SelectSkuHierarchy(Constants.SKUCategory, Constants.IntNullValue, int.Parse(strSKUDivisionID), null, null, true, int.Parse(this.Session["CompanyId"].ToString()));
                clsWebFormUtil.FillDropDownList(this.ddskuCategory, m_dt, 0, 3, true);
            }
        }
    }
    private void Populate_drpSKUBrand()
    {
        if (ddskuCategory.Items.Count > 0)
        {
            SkuHierarchyController mHer_Controller = new SkuHierarchyController();
            string strSKUCategoryID = this.ddskuCategory.SelectedItem.Value;

            if (int.Parse(strSKUCategoryID) > 0)
            {
                DataTable m_dt = mHer_Controller.SelectSkuHierarchy(Constants.SKUBrand, Constants.IntNullValue, int.Parse(strSKUCategoryID), null, null, true, int.Parse(this.Session["CompanyId"].ToString()));
                clsWebFormUtil.FillDropDownList(this.ddskuBrand, m_dt, 0, 3, true);
            }
        }
    }
    private void LoadSKUS()
    {
        if (ddskuBrand.Items.Count > 0)
        {
            SkuController mSKUController = new SkuController();
            int compid = int.Parse(ddskuPrincipal.SelectedItem.Value);
            int divid = int.Parse(ddskuDivision.SelectedItem.Value);
            int catid = int.Parse(ddskuCategory.SelectedItem.Value);
            int barandid = int.Parse(ddskuBrand.SelectedItem.Value);
            int varid = Constants.IntNullValue;

            DataTable m_dt = mSKUController.SelectSkuInfo(compid, divid, catid, barandid, varid);
            clsWebFormUtil.FillDropDownList(this.ddskuName, m_dt, 0, 18, true);
        }     
    }
    private void LoadGrid()
    {
        SkuController mSKUController = new SkuController();
        if (ddskuName.Items.Count > 0)
        {
            DataTable dtsku = mSKUController.SelectSKuCurrentPrice(Constants.IntNullValue,int.Parse(this.Session["CompanyId"].ToString()), Constants.IntNullValue,
                Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue,
                int.Parse(ddskuName.SelectedValue.ToString()));
            Grid_pricedetails.DataSource = dtsku.DefaultView;
            Grid_pricedetails.DataBind();
        }
        
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Populate_drpSKUCompany();
            Populate_drpSKUDivisions();
            Populate_drpSKUCategory();
            Populate_drpSKUBrand();
            LoadSKUS();
            LoadGrid();
            LoadDistributor();
            btnSave.Attributes.Add("onclick", "return ValidateForm()");
        }
    }
    private void LoadDistributor()
    {
        DistributorController DController = new DistributorController();
        DataTable dt = DController.SelectDistributorInfo(Constants.IntNullValue, int.Parse(this.Session["UserId"].ToString()), int.Parse(this.Session["CompanyId"].ToString()));
        clsWebFormUtil.FillListBox(ChbDistributorList, dt, 0, 2, true);
    }
    protected void ddskuPrincipal_SelectedIndexChanged(object sender, EventArgs e)
    {
        Populate_drpSKUDivisions();
        Populate_drpSKUCategory();
        Populate_drpSKUBrand();
        LoadSKUS();
        LoadGrid();
    } 
    protected void ddskuDivision_SelectedIndexChanged(object sender, EventArgs e)
    {
        Populate_drpSKUCategory();
        Populate_drpSKUBrand();
        LoadSKUS();
        LoadGrid();
    }
    protected void ddskuCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        Populate_drpSKUBrand();
        LoadSKUS();
        LoadGrid();
    }
    protected void ddskuBrand_SelectedIndexChanged(object sender, EventArgs e)
    {
         LoadSKUS();
         LoadGrid();
    }    
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (btnSave.Text == "Save")
        {
            SkuController mPriceController = new SkuController();
            DataControl dc = new DataControl();
            for(int i  = 0;i<ChbDistributorList.Items.Count;i++)   
            {
                if(ChbDistributorList.Items[i].Selected == true)
                {
                    mPriceController.InsertSKU_PRICES(int.Parse(ChbDistributorList.Items[i].Value), int.Parse(ddskuName.SelectedValue.ToString()), 1, decimal.Parse(dc.chkNull_0(txtDistributorPrice.Text)), decimal.Parse(dc.chkNull_0(txtTaxPrices.Text)), decimal.Parse(dc.chkNull_0(txtDistributorPrice.Text)), decimal.Parse(dc.chkNull_0(txtTradePrice.Text)), decimal.Parse(dc.chkNull_0(txtRetailPrice.Text)), DateTime.Parse(txtFromdate.Text),decimal.Parse(dc.chkNull_0(txtSADTax.Text)));
                }
            }
                    
           
            this.LoadGrid();
            //txtTaxPrices.Text = "";
            txtRetailPrice.Text = "";
            txtTradePrice.Text = "";
            txtDistributorPrice.Text = ""; 
        }
    }
    protected void Grid_pricedetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }
    protected void Grid_pricedetails_RowEditing(object sender, GridViewEditEventArgs e)
    {

    }
    protected void ddskuName_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadGrid(); 
    }

}
