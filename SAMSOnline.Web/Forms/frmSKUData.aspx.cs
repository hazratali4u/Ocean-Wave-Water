using System;
using System.Data;
using System.Web.UI.WebControls;
using SAMS.BusinessLayer.Classes;
using SAMS.Common.Classes;    

public partial class Forms_frmSKUData : System.Web.UI.Page
{

    SKUsController mController = new SKUsController();
    DataControl dc = new DataControl(); 
    SkuHierarchyController mHer_Controller = new SkuHierarchyController();

    private  DataTable m_dt,m_SKUDt;
    private static int m_sku_id;
    private void Populate_drpSKUCompany()
    {
        m_dt = mHer_Controller.SelectSkuHierarchy(Constants.SKUPrincipal, Constants.IntNullValue, Constants.IntNullValue, null, null, true, int.Parse(this.Session["CompanyId"].ToString()));
        clsWebFormUtil.FillDropDownList(this.ddskuPrincipal, m_dt, 0, 3, true);
    }
    private void Populate_drpSKUDivisions()
    {
        if (ddskuPrincipal.Items.Count > 0)
        {
            string strSKUCompanyID = this.ddskuPrincipal.SelectedItem.Value;

            if (int.Parse(strSKUCompanyID) > 0)
            {
                m_dt = mHer_Controller.SelectSkuHierarchy(Constants.SKUDivision, Constants.IntNullValue, int.Parse(strSKUCompanyID), null, null, true, int.Parse(this.Session["CompanyId"].ToString()));
                clsWebFormUtil.FillDropDownList(this.ddskudivision, m_dt, 0, 3, true);
            }
        }
        else
        {
            ddskudivision.Items.Clear();   
        }
    }
    private void Populate_drpSKUCategory()
    {
        if (ddskudivision.Items.Count > 0)
        {
            string strSKUDivisionID = this.ddskudivision.SelectedItem.Value;

            if (int.Parse(strSKUDivisionID) > 0)
            {
                m_dt = mHer_Controller.SelectSkuHierarchy(Constants.SKUCategory, Constants.IntNullValue, int.Parse(strSKUDivisionID), null, null, true, int.Parse(this.Session["CompanyId"].ToString()));
                clsWebFormUtil.FillDropDownList(this.ddskucategory, m_dt, 0, 3, true);
            }
        }
        else
        {
            ddskucategory.Items.Clear();   
        }
    }
    private void Populate_drpSKUBrand()
    {
        if (ddskucategory.Items.Count > 0)
        {
            string strSKUCategoryID = this.ddskucategory.SelectedItem.Value;

            if (int.Parse(strSKUCategoryID) > 0)
            {
                m_dt = mHer_Controller.SelectSkuHierarchy(Constants.SKUBrand, Constants.IntNullValue, int.Parse(strSKUCategoryID), null, null, true, int.Parse(this.Session["CompanyId"].ToString()));
                clsWebFormUtil.FillDropDownList(this.ddskuBrand, m_dt, 0, 3, true);
            }
        }
        else
        {
            ddskuBrand.Items.Clear();   
        }
    }
    private void LoadGrid()
    {
        m_SKUDt = (DataTable)this.Session["m_SKUDt"];

        switch (ddSearchType.SelectedIndex)
        {
            
            case 1:
                m_SKUDt.DefaultView.RowFilter = ddSearchType.SelectedValue.ToString() + " like '%" + txtSeach.Text + "%'";
                break;
            case 2:
                m_SKUDt.DefaultView.RowFilter = ddSearchType.SelectedValue.ToString() + " like '%" + txtSeach.Text + "%'";
                break;
            case 3:
                m_SKUDt.DefaultView.RowFilter = ddSearchType.SelectedValue.ToString() + " like '%" + txtSeach.Text + "%'";
                break;
            case 4:
                m_SKUDt.DefaultView.RowFilter = ddSearchType.SelectedValue.ToString() + " like '%" + txtSeach.Text + "%'";
                break;
            default:
                m_SKUDt.DefaultView.RowFilter = "SKU_CODE" + " like '%" + "" + "%'";
                break; 
        }
        grdSKUData.DataSource = m_SKUDt.DefaultView;   
        grdSKUData.DataBind();
       }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
           
            Populate_drpSKUCompany();
            Populate_drpSKUDivisions();
            Populate_drpSKUCategory();
            Populate_drpSKUBrand();
            LoadData();
            LoadGrid();
        }
    }
    private void LoadData()
    {
        SkuController mSKUController = new SkuController();
        m_SKUDt = mSKUController.SelectSkuInfo(int.Parse(ddskuPrincipal.SelectedValue.ToString()),int.Parse(ddskudivision.SelectedValue.ToString()),int.Parse(ddskucategory.SelectedValue.ToString()),Constants.IntNullValue,int.Parse(this.Session["CompanyId"].ToString()));
        this.Session.Add("m_SKUDt", m_SKUDt);  
    }
    private void CLearAll()
    {
        //txtgstrate.Text = "";
        txtpacksize.Text = "";
        txtskucode.Text = "";
        txtunitincase.Text = "";
        txtskuname.Text = "";
        btnSave.Text = "Save";
        this.LoadData();
        this.LoadGrid(); 
    }
    protected void ddskuPrincipal_SelectedIndexChanged(object sender, EventArgs e)
    {
        Populate_drpSKUDivisions();
        Populate_drpSKUCategory();
        Populate_drpSKUBrand();
        this.LoadData();
        this.LoadGrid();        
    }
    protected void ddskudivision_SelectedIndexChanged(object sender, EventArgs e)
    {
        Populate_drpSKUCategory();
        Populate_drpSKUBrand();
        this.LoadData();
        this.LoadGrid();
    }
    protected void ddskucategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        Populate_drpSKUBrand();
        this.LoadData();
        this.LoadGrid();
        
    }
    protected void grdSKUData_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        this.grdSKUData.PageIndex = e.NewPageIndex;
        this.LoadGrid();
       
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
       bool IsExemted = true;
       char Gst_On = 'E';
       if (txtpacksize.Text.Length <= 0)
       {
           lblErrorMsg.Text = "Must Enter SKU Packsize";
           return; 
       }
       if (txtskucode.Text.Length <= 0)
       {
           lblErrorMsg.Text = "Must Enter SKU Code";
           return;
       }
       if (txtskuname.Text.Length <= 0)
       {
           lblErrorMsg.Text = "Must Enter SKU Name";
           return;
       }
       if(btnSave.Text == "Save") 
       {
           mController.InsertSKUS(IsExemted, true, char.Parse(DrpSKUTaxType.SelectedValue.ToString()),int.Parse(ddskuPrincipal.SelectedValue.ToString()),int.Parse(ddskudivision.SelectedValue.ToString()), int.Parse(ddskucategory.SelectedValue.ToString()),
           int.Parse(ddskuBrand.SelectedValue.ToString()), Constants.IntNullValue, 0,0,short.Parse(dc.chkNull_0(txtunitincase.Text)),
           txtskucode.Text.ToUpper(), txtskuname.Text, null, txtpacksize.Text, int.Parse(this.Session["UserId"].ToString()), int.Parse(this.Session["CompanyId"].ToString()));
           this.CLearAll();  
       }
       else if (btnSave.Text == "Update")
       {
           mController.UpdateSKUS(IsExemted, true, char.Parse(DrpSKUTaxType.SelectedValue.ToString()), int.Parse(ddskuPrincipal.SelectedValue.ToString()), int.Parse(ddskudivision.SelectedValue.ToString()),
           int.Parse(ddskucategory.SelectedValue.ToString()), int.Parse(ddskuBrand.SelectedValue.ToString()),Constants.IntNullValue, 0
           , 0, short.Parse(dc.chkNull_0(txtunitincase.Text)), m_sku_id, txtskucode.Text.ToUpper(), txtskuname.Text, null, txtpacksize.Text, int.Parse(this.Session["UserId"].ToString()), int.Parse(this.Session["CompanyId"].ToString()));
           this.CLearAll();
       }
       this.LoadData(); 
        
    }
    protected void grdSKUData_RowEditing(object sender, GridViewEditEventArgs e)
    {
        ddskuPrincipal.SelectedValue = grdSKUData.Rows[e.NewEditIndex].Cells[0].Text;
        this.Populate_drpSKUDivisions(); 
        ddskudivision.SelectedValue = grdSKUData.Rows[e.NewEditIndex].Cells[1].Text;
        this.Populate_drpSKUCategory();
        ddskucategory.SelectedValue = grdSKUData.Rows[e.NewEditIndex].Cells[2].Text;
        this.Populate_drpSKUBrand();
        ddskuBrand.SelectedValue = grdSKUData.Rows[e.NewEditIndex].Cells[3].Text;
        m_sku_id = int.Parse(grdSKUData.Rows[e.NewEditIndex].Cells[4].Text);
        txtskucode.Text = grdSKUData.Rows[e.NewEditIndex].Cells[9].Text;
        txtskuname.Text = grdSKUData.Rows[e.NewEditIndex].Cells[10].Text;
        txtpacksize.Text = grdSKUData.Rows[e.NewEditIndex].Cells[11].Text;
        txtunitincase.Text = grdSKUData.Rows[e.NewEditIndex].Cells[12].Text;
        //txtgstrate.Text = grdSKUData.Rows[e.NewEditIndex].Cells[13].Text;
        
        
        btnSave.Text = "Update";
    }
    protected void grdSKUData_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        
        bool IsExemted = bool.Parse(grdSKUData.Rows[e.RowIndex].Cells[14].Text);
        string result = mController.UpdateSKUS(IsExemted, false,Constants.CharNullValue, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue,Constants.IntNullValue,
        Constants.DecimalNullValue, Constants.DecimalNullValue, Constants.ShortNullValue, int.Parse(grdSKUData.Rows[e.RowIndex].Cells[4].Text), null, null, null, null, int.Parse(this.Session["UserId"].ToString()), int.Parse(this.Session["CompanyId"].ToString()));
        this.LoadData();
        this.LoadGrid(); 
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
       this.LoadGrid();
    }

}
