using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using SAMS.BusinessLayer.Classes;
using SAMS.Common.Classes;    

public partial class Forms_frmPysicalStockteken : System.Web.UI.Page
{
    DataTable PurchaseSKU;
    DataControl dc = new DataControl();
    private static int RowNo;
    private void LoadPrincipal()
    {
        SKUPriceDetailController PController = new SKUPriceDetailController();
        DataTable m_dt = PController.SelectDataPrice(Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, int.Parse(this.Session["UserId"].ToString()), Constants.IntNullValue, 0, DateTime.Parse(this.Session["CurrentWorkDate"].ToString()));
        clsWebFormUtil.FillDropDownList(this.drpPrincipal, m_dt, 0, 1, true);
    }
    private void LoadDistributor()
    {
        DistributorController DController = new DistributorController();
        DataTable dt = DController.SelectDistributorInfo(Constants.IntNullValue, int.Parse(this.Session["UserId"].ToString()), int.Parse(this.Session["CompanyId"].ToString()));
        clsWebFormUtil.FillDropDownList(this.drpDistributor, dt, 0, 2, true);
    }
    private void LoadSKUDetail()
    {
        if (drpPrincipal.Items.Count > 0)
        {
            SKUPriceDetailController PController = new SKUPriceDetailController();
            DataTable Dtsku_Price = PController.SelectDataPrice(int.Parse(drpPrincipal.SelectedValue.ToString()), Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, int.Parse(this.Session["DISTRIBUTOR_ID"].ToString()), int.Parse(this.Session["UserId"].ToString()), Constants.IntNullValue, 1, DateTime.Parse(this.Session["CurrentWorkDate"].ToString()));
            clsWebFormUtil.FillListBox(this.lstCode, Dtsku_Price, 10, 10, true);
            this.Session.Add("Dtsku_Price", Dtsku_Price);
            
        }
    }
    private void LoadGird()
    {
        ControllerPaysical MController = new ControllerPaysical();
        DataTable dt = MController.SelectPysicalStock(int.Parse(drpDistributor.SelectedValue.ToString()),0,int.Parse(drpPrincipal.SelectedValue.ToString()));
        GrdPurchase.DataSource = dt;
        GrdPurchase.DataBind();  
    }
    private void ClearAll()
    {
        txtskuCode.Text = "";
        txtskuName.Text = "";
        txtQuantity.Text = "";
        txtusaleableqty.Text = ""; 
        txtUnitRate.Text = "0";
        txtskuCode.Enabled = true;
        btnSave.Text = "Save";
       
    }
    private bool CheckDublicateSKU()
    {
        DataControl dc = new DataControl();
        DataTable Dtsku_Price = (DataTable)this.Session["Dtsku_Price"];
        PurchaseSKU = (DataTable)this.Session["PurchaseSKU"];
        DataRow[] foundRows = PurchaseSKU.Select("SKU_CODE  = '" + txtskuCode.Text + "'");
        if (foundRows.Length == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.LoadPrincipal();
            this.LoadDistributor();
            this.LoadSKUDetail();
            this.LoadGird();            
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        DataTable Dtsku_Price = (DataTable)this.Session["Dtsku_Price"];
        PurchaseSKU = (DataTable)this.Session["PurchaseSKU"];
        DataRow[] foundRows = Dtsku_Price.Select("SKU_CODE  = '" + txtskuCode.Text + "'");
        DataControl dc = new DataControl();
 
        if (foundRows.Length > 0)
        {

            ControllerPaysical MController = new ControllerPaysical();
            if (btnSave.Text == "Save")
            {
                MController.InsertPysicalStock(int.Parse(drpDistributor.SelectedValue.ToString()), DateTime.Parse(this.Session["CurrentWorkDate"].ToString()), int.Parse(foundRows[0]["SKU_ID"].ToString()), int.Parse(dc.chkNull_0(txtQuantity.Text)),int.Parse(dc.chkNull_0(txtusaleableqty.Text)),decimal.Parse(txtUnitRate.Text), 0, int.Parse(drpPrincipal.SelectedValue.ToString()));
            }
            else
            {
                MController.UpdatePysicalStock(int.Parse(drpDistributor.SelectedValue.ToString()), DateTime.Parse(this.Session["CurrentWorkDate"].ToString()), int.Parse(foundRows[0]["SKU_ID"].ToString()), int.Parse(dc.chkNull_0(txtQuantity.Text)), int.Parse(dc.chkNull_0(txtusaleableqty.Text)), decimal.Parse(txtUnitRate.Text), 0, int.Parse(drpPrincipal.SelectedValue.ToString()));
                
            }
            this.LoadGird();
            this.ClearAll();
            ScriptManager.GetCurrent(Page).SetFocus(txtskuCode);
        }
    }
    protected void GrdPurchase_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        ControllerPaysical MController = new ControllerPaysical();
        MController.DELETEPysicalStock(int.Parse(drpDistributor.SelectedValue.ToString()), DateTime.Parse(this.Session["CurrentWorkDate"].ToString()),int.Parse(GrdPurchase.Rows[e.RowIndex].Cells[0].Text));
        this.LoadGird();

    }
    protected void GrdPurchase_RowEditing(object sender, GridViewEditEventArgs e)
    {
        RowNo = e.NewEditIndex;
        txtskuCode.Text = GrdPurchase.Rows[e.NewEditIndex].Cells[1].Text;
        txtskuName.Text = GrdPurchase.Rows[e.NewEditIndex].Cells[2].Text;
        txtQuantity.Text = GrdPurchase.Rows[e.NewEditIndex].Cells[3].Text;
        txtusaleableqty.Text = GrdPurchase.Rows[e.NewEditIndex].Cells[4].Text;
        txtUnitRate.Text = GrdPurchase.Rows[e.NewEditIndex].Cells[5].Text;
        txtQuantity.Focus();
        btnSave.Text = "Update Sku"; 
    }
    protected void drpPrincipal_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadGird();
        this.LoadSKUDetail();
    }
}
