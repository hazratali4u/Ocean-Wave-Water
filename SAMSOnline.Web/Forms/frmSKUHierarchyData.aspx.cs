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
using SAMS.Common.Classes;
using SAMS.BusinessLayer.Classes;    

public partial class frmSKUHierarchyData : System.Web.UI.Page
{
    SkuHierarchyController mController = new SkuHierarchyController();
    static int PrincipalId;
    static int DivisionId;
    static int CategoryId;
    static int BrandId;
    private void LoadPrincipal()
    {
        DataTable dt = mController.SelectSkuHierarchy(Constants.SKUPrincipal, int.Parse(this.Session["CompanyId"].ToString()));
        GrdPrincipal.DataSource = dt;
        GrdPrincipal.Columns[0].Visible = true;
        GrdPrincipal.DataBind();
        GrdPrincipal.Columns[0].Visible = false;
        clsWebFormUtil.FillDropDownList(this.dddivisonPrincipal, dt, 0, 3, true);
        clsWebFormUtil.FillDropDownList(this.DrpCategoryPrincipal, dt, 0, 3, true);
        clsWebFormUtil.FillDropDownList(this.DrpBrandPrincipal, dt, 0, 3, true);
    }
    private void LoadDivision()
    {
        DataTable dt = mController.SelectSkuHierarchy(Constants.SKUDivision, Constants.IntNullValue,int.Parse(dddivisonPrincipal.SelectedValue.ToString()), null, null, true, int.Parse(this.Session["CompanyId"].ToString()));
        GrdDivision.DataSource = dt;
        GrdDivision.Columns[0].Visible = true;
        GrdDivision.DataBind();
        GrdDivision.Columns[0].Visible = false;
        
    }
    private void LoadCategoryDivision()
    {
        DataTable dt = mController.SelectSkuHierarchy(Constants.SKUDivision, Constants.IntNullValue, int.Parse(DrpCategoryPrincipal.SelectedValue.ToString()), null, null, true, int.Parse(this.Session["CompanyId"].ToString()));
        clsWebFormUtil.FillDropDownList(this.ddCategoryDivision, dt, 0, 3, true);
    }
    private void LoadCategroy()
    {
        if (ddCategoryDivision.Items.Count > 0)
        {
            DataTable dt = mController.SelectSkuHierarchy(Constants.SKUCategory, Constants.IntNullValue, int.Parse(ddCategoryDivision.SelectedValue.ToString()), null, null, true, int.Parse(this.Session["CompanyId"].ToString()));
            GrdCategory.DataSource = dt;
            GrdCategory.Columns[0].Visible = true;
            GrdCategory.DataBind();
            GrdCategory.Columns[0].Visible = false;
        }
    }
    private void LoadBrandDivision()
    {
        if (DrpBrandPrincipal.Items.Count > 0)
        {
            DataTable dt = mController.SelectSkuHierarchy(Constants.SKUDivision, Constants.IntNullValue, int.Parse(DrpBrandPrincipal.SelectedValue.ToString()), null, null, true, int.Parse(this.Session["CompanyId"].ToString()));
            clsWebFormUtil.FillDropDownList(this.DrpBrandDivision, dt, 0, 3, true);
        }
    }
    private void LoadBrandCategory()
    {
        if (DrpBrandDivision.Items.Count > 0)
        {
            DataTable dt = mController.SelectSkuHierarchy(Constants.SKUCategory, Constants.IntNullValue, int.Parse(DrpBrandDivision.SelectedValue.ToString()), null, null, true, int.Parse(this.Session["CompanyId"].ToString()));
            clsWebFormUtil.FillDropDownList(this.ddBrandCategory, dt, 0, 3, true);
        }
    }
    private void LoadBrand()
    {
        if (ddBrandCategory.Items.Count > 0)
        {
            DataTable dt = mController.SelectSkuHierarchy(Constants.SKUBrand, Constants.IntNullValue, int.Parse(ddBrandCategory.SelectedValue.ToString()), null, null, true, int.Parse(this.Session["CompanyId"].ToString()));
            GrdBrand.DataSource = dt;
            GrdBrand.Columns[0].Visible = true;
            GrdBrand.DataBind();
            GrdBrand.Columns[0].Visible = false;
        }      
    }
    private string GetAutoCode(string PreeFix,int CodeType)
    {
        SETTINGS_TABLE_Controller AutoCode = new SETTINGS_TABLE_Controller();
        return AutoCode.GetAutoCode(PreeFix, CodeType, Constants.LongNullValue);
    }
    private void SetAutoCode(string PreeFix, long CValue)
    {
        SETTINGS_TABLE_Controller AutoCode = new SETTINGS_TABLE_Controller();
        string result = AutoCode.GetAutoCode(PreeFix, 1, CValue);
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.LoadPrincipal();
            this.LoadDivision();
            this.LoadCategoryDivision();
            this.LoadBrandDivision();
            this.LoadCategroy();
            this.LoadBrandCategory(); 
            this.LoadBrand();
            TabContainer1.ActiveTabIndex = 0; 
        }
    }
    protected void btnSavePrincipal_Click(object sender, EventArgs e)
    {
        lblErrorMsg.Text = "";
        if (btnSavePrincipal.Text == "New")
        {
            txtPrincipalCode.Text = this.GetAutoCode("SC",0);
            txtPrincipalName.Enabled = true;
            txtPrincipalName.Focus();
            btnSavePrincipal.Text = "Save";
            ScriptManager.GetCurrent(Page).SetFocus(txtPrincipalName); 
        }
        else if (btnSavePrincipal.Text == "Save")
        {
            if (txtPrincipalName.Text.Length == 0)
            {
                lblErrorMsg.Text = "Must Enter Principal Name";
                return; 
            }
            mController.InsertHierarchy(Constants.SKUPrincipal, Constants.IntNullValue, txtPrincipalCode.Text, txtPrincipalName.Text, null, true, int.Parse(this.Session["CompanyId"].ToString()),ChIsMunalDiscount.Checked);
                this.SetAutoCode("SC", long.Parse(txtPrincipalCode.Text.Substring(2)));
                btnSavePrincipal.Text = "New";
                txtPrincipalCode.Text = "";
                txtPrincipalName.Text = "";
                txtPrincipalName.Enabled = false;
                this.LoadPrincipal();
            
        }
        else if (btnSavePrincipal.Text == "Update")
        {
            if (txtPrincipalName.Text.Length == 0)
            {
                lblErrorMsg.Text = "Must Enter Principal Name";
                return;
            }
            mController.UpdateHierarchy(Constants.SKUPrincipal, PrincipalId, Constants.IntNullValue, txtPrincipalCode.Text, txtPrincipalName.Text, null, true, int.Parse(this.Session["CompanyId"].ToString()),ChIsMunalDiscount.Checked);
            btnSavePrincipal.Text = "New";
            txtPrincipalCode.Text = "";
            txtPrincipalName.Text = "";
            txtPrincipalName.Enabled = false;
            this.LoadPrincipal(); 
        }
      
    }
    protected void GrdPrincipal_RowEditing(object sender, GridViewEditEventArgs e)
    {
        PrincipalId = int.Parse(GrdPrincipal.Rows[e.NewEditIndex].Cells[0].Text);
        txtPrincipalCode.Text  = GrdPrincipal.Rows[e.NewEditIndex].Cells[1].Text;
        txtPrincipalName.Text  = GrdPrincipal.Rows[e.NewEditIndex].Cells[2].Text;
        txtPrincipalName.Enabled = true;   
        btnSavePrincipal.Text = "Update"; 
    }
    protected void GrdPrincipal_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        PrincipalId = int.Parse(GrdPrincipal.Rows[e.RowIndex].Cells[0].Text);
        DataTable dt  =  mController.SelectSkuHierarchy(Constants.SKUDivision, PrincipalId);
        if (dt.Rows.Count > 0)
        {
            lblErrorMsg.Text = "Wrong Command: first delete associated division"; 
        }
        else
        {
            mController.UpdateHierarchy(Constants.SKUPrincipal, PrincipalId, Constants.IntNullValue, null, null, null, false, int.Parse(this.Session["CompanyId"].ToString()));
            this.LoadPrincipal();
            lblErrorMsg.Text = "";
        }
    }
    protected void btnSaveDivison_Click(object sender, EventArgs e)
    {
        if (btnSaveDivison.Text == "New")
        {
            txtDivisionCode.Text = this.GetAutoCode("DV", 0);
            txtDivisionName.Enabled = true;
            txtDivisionName.Focus();
            btnSaveDivison.Text = "Save";
            ScriptManager.GetCurrent(Page).SetFocus(dddivisonPrincipal); 
        }
        else if (btnSaveDivison.Text == "Save")
        {
            if (txtDivisionName.Text.Length == 0)
            {
                lblErrorMsgDivsion.Text = "Must Entry Division Name";
                return; 
            }
            mController.InsertHierarchy(Constants.SKUDivision, int.Parse(dddivisonPrincipal.SelectedValue.ToString()), txtDivisionCode.Text, txtDivisionName.Text, null, true, int.Parse(this.Session["CompanyId"].ToString()));
                this.SetAutoCode("DV", long.Parse(txtDivisionCode.Text.Substring(2)));
                btnSaveDivison.Text = "New";
                txtDivisionCode.Text = "";
                txtDivisionName.Text = "";
                txtDivisionName.Enabled = false;
                this.LoadDivision();
                lblErrorMsgDivsion.Text = ""; 
            
        }
        else if (btnSaveDivison.Text == "Update")
        {
            if (txtDivisionName.Text.Length == 0)
            {
                lblErrorMsgDivsion.Text = "Must Enter Division Name";
                return;
            }
            mController.UpdateHierarchy(Constants.SKUDivision, DivisionId, int.Parse(dddivisonPrincipal.SelectedValue.ToString()), txtDivisionCode.Text, txtDivisionName.Text, null, true, int.Parse(this.Session["CompanyId"].ToString()));
            btnSaveDivison.Text = "New";
            txtDivisionName.Text = "";
            txtDivisionName.Text = "";
            txtDivisionName.Enabled = false;
            this.LoadDivision();
        }
      
    }
    protected void GrdDivision_RowEditing(object sender, GridViewEditEventArgs e)
    {
        DivisionId = int.Parse(GrdDivision.Rows[e.NewEditIndex].Cells[0].Text);
        txtDivisionCode.Text = GrdDivision.Rows[e.NewEditIndex].Cells[1].Text;
        txtDivisionName.Text = GrdDivision.Rows[e.NewEditIndex].Cells[2].Text;
        txtDivisionName.Enabled = true;
        btnSaveDivison.Text = "Update";
    }
    protected void GrdDivision_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        DivisionId = int.Parse(GrdDivision.Rows[e.RowIndex].Cells[0].Text);
        DataTable dt = mController.SelectSkuHierarchy(Constants.SKUCategory, DivisionId);
         if (dt.Rows.Count > 0)
         {
             lblErrorMsgDivsion.Text = "Wrong Command: first delete associated category";
         }
         else
         {
             mController.UpdateHierarchy(Constants.SKUDivision, DivisionId, Constants.IntNullValue, null, null, null, false, int.Parse(this.Session["CompanyId"].ToString()));
             this.LoadDivision();
             lblErrorMsgDivsion.Text = ""; 
         }
    }
    protected void btnSaveCategory_Click(object sender, EventArgs e)
    {
        lblErrorMsgCategory.Text = "";
        if (btnSaveCategory.Text == "New")
        {
            txtCategoryCode.Text = this.GetAutoCode("CA", 0);
            txtCategoryName.Enabled = true;
            txtCategoryName.Focus();
            btnSaveCategory.Text = "Save";
            ScriptManager.GetCurrent(Page).SetFocus(ddCategoryDivision); 
        }
        else if (btnSaveCategory.Text == "Save")
        {
            if (txtCategoryName.Text.Length <= 0)
            {
                lblErrorMsgCategory.Text = "Must Enter Category";
                return; 
            }
            mController.InsertHierarchy(Constants.SKUCategory, int.Parse(ddCategoryDivision.SelectedValue.ToString()), txtCategoryCode.Text, txtCategoryName.Text, null, true, int.Parse(this.Session["CompanyId"].ToString()));
                this.SetAutoCode("CA", long.Parse(txtCategoryCode.Text.Substring(2)));
                btnSaveCategory.Text = "New";
                txtCategoryCode.Text = "";
                txtCategoryName.Text = "";
                txtCategoryName.Enabled = false;
                this.LoadCategroy();
                lblErrorMsgCategory.Text = "";
            
        }
        else if (btnSaveCategory.Text == "Update")
        {
            if (txtCategoryName.Text.Length <= 0)
            {
                lblErrorMsgCategory.Text = "Must Enter Category";
                return;
            }
            mController.UpdateHierarchy(Constants.SKUCategory, CategoryId, int.Parse(ddCategoryDivision.SelectedValue.ToString()), txtCategoryCode.Text, txtCategoryName.Text, null, true, int.Parse(this.Session["CompanyId"].ToString()));
            btnSaveCategory.Text = "New";
            txtCategoryCode.Text = "";
            txtCategoryName.Text = "";
            txtCategoryName.Enabled = false;
            this.LoadCategroy(); 
        }
    }
    protected void GrdCategory_RowEditing(object sender, GridViewEditEventArgs e)
    {
        //ddCategoryDivision.SelectedValue = GrdCategory.Rows[e.NewEditIndex].Cells[1].Text;
        CategoryId = int.Parse(GrdCategory.Rows[e.NewEditIndex].Cells[0].Text);
        txtCategoryCode.Text = GrdCategory.Rows[e.NewEditIndex].Cells[1].Text;
        txtCategoryName.Text = GrdCategory.Rows[e.NewEditIndex].Cells[2].Text;
        txtCategoryName.Enabled = true;
        btnSaveCategory.Text = "Update";
    }
    protected void GrdCategory_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        CategoryId = int.Parse(GrdCategory.Rows[e.RowIndex].Cells[0].Text);
        DataTable dt = mController.SelectSkuHierarchy(Constants.SKUBrand, CategoryId);
        if (dt.Rows.Count > 0)
        {
            lblErrorMsgCategory.Text = "Wrong Command: first delete associated Brand";
        }
        else
        {
            mController.UpdateHierarchy(Constants.SKUCategory, CategoryId, Constants.IntNullValue, null, null, null, false, int.Parse(this.Session["CompanyId"].ToString()));
            this.LoadCategroy(); 
        }
    }
    protected void btnSaveBrand_Click(object sender, EventArgs e)
    {
        lblErrorMsgBrand.Text = "";
        if (btnSaveBrand.Text == "New")
        {
            txtBrandCode.Text = this.GetAutoCode("BN", 0);
            txtBrandName.Enabled = true;
            txtBrandName.Focus();
            btnSaveBrand.Text = "Save";
            ScriptManager.GetCurrent(Page).SetFocus(ddBrandCategory); 
        }
        else if (btnSaveBrand.Text == "Save")
        {
            if (txtBrandName.Text.Length == 0)
            {
                lblErrorMsgBrand.Text = "Must Enter Brand";
                return;
            }
            mController.InsertHierarchy(Constants.SKUBrand, int.Parse(ddBrandCategory.SelectedValue.ToString()), txtBrandCode.Text, txtBrandName.Text, null, true,int.Parse(this.Session["CompanyId"].ToString()));
                this.SetAutoCode("BN", long.Parse(txtBrandCode.Text.Substring(2)));
                btnSaveBrand.Text = "New";
                txtBrandCode.Text = "";
                txtBrandName.Text = "";
                txtBrandName.Enabled = false;
                this.LoadBrand();
                lblErrorMsgBrand.Text = "";
        }
        else if (btnSaveBrand.Text == "Update")
        {
            if (txtBrandName.Text.Length == 0)
            {
                lblErrorMsgBrand.Text = "Must Enter Brand";
                return; 
            }
            mController.UpdateHierarchy(Constants.SKUBrand, BrandId, int.Parse(ddBrandCategory.SelectedValue.ToString()), txtBrandCode.Text, txtBrandName.Text, null, true, int.Parse(this.Session["CompanyId"].ToString()));
            btnSaveBrand.Text = "New";
            txtBrandCode.Text = "";
            txtBrandName.Text = "";
            txtBrandName.Enabled = false;
            this.LoadBrand();
        }
    }
    protected void GrdBrand_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        this.GrdBrand.PageIndex = e.NewPageIndex;
        this.LoadBrand();
    }
    protected void GrdCategory_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        this.GrdCategory.PageIndex = e.NewPageIndex;
        this.LoadCategroy();
    }
    protected void GrdDivision_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        this.GrdDivision.PageIndex = e.NewPageIndex;
        this.LoadDivision();
    }
    protected void GrdPrincipal_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        this.GrdPrincipal.PageIndex = e.NewPageIndex;
        this.LoadPrincipal();
        
    }
    protected void GrdBrand_RowEditing(object sender, GridViewEditEventArgs e)
    {
        BrandId = int.Parse(GrdBrand.Rows[e.NewEditIndex].Cells[0].Text);
        txtBrandCode.Text = GrdBrand.Rows[e.NewEditIndex].Cells[1].Text;
        txtBrandName.Text = GrdBrand.Rows[e.NewEditIndex].Cells[2].Text;
        txtBrandName.Enabled = true;
        btnSaveBrand.Text = "Update";
    }
    protected void GrdBrand_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        SkuController msku = new SkuController(); 
        BrandId = int.Parse(GrdBrand.Rows[e.RowIndex].Cells[0].Text);
        DataTable dt = msku.SelectSkuInfo(Constants.IntNullValue,Constants.IntNullValue,Constants.IntNullValue,BrandId,Constants.IntNullValue);
        if (dt.Rows.Count > 0)
        {
            lblErrorMsgBrand.Text = "Wrong Command: first delete associated SKUS";
        }
        else
        {
            mController.UpdateHierarchy(Constants.SKUBrand, BrandId, Constants.IntNullValue, null, null, null, false, int.Parse(this.Session["CompanyId"].ToString()));
            this.LoadBrand();
        }       
    }
    protected void dddivisonPrincipal_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadDivision();
    }
    protected void DrpCategoryPrincipal_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadCategoryDivision();
        this.LoadCategroy();
    }
    protected void ddCategoryDivision_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadCategroy();
    }
    protected void DrpBrandPrincipal_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadBrandDivision();
        this.LoadBrandCategory();
        this.LoadBrand(); 
    }
    protected void DrpBrandDivision_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadBrandCategory();
        this.LoadBrand(); 
    }
    protected void ddBrandCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
       this.LoadBrand(); 
    }

}
