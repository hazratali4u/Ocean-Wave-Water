using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using SAMS.BusinessLayer.Classes;
using SAMS.Common.Classes;
    
public partial class Forms_frmTargetEntry : System.Web.UI.Page
{
    private static long TargetId;

    private void LoadDistributor()
    {
        DistributorController DController = new DistributorController();
        DataTable dt = DController.SelectDistributorInfo(Constants.IntNullValue, int.Parse(this.Session["UserId"].ToString()), int.Parse(this.Session["CompanyId"].ToString()));
        clsWebFormUtil.FillDropDownList(this.drpDistributor, dt, 0, 2, true);
    }
    private void LoadTargetForId()
    {
        if (drpDistributor.Items.Count > 0)
        {

            Distributor_UserController Du = new Distributor_UserController();
            DataTable dt = Du.SelectDistributorUser(Constants.SALES_FORCE_DELIVERYMAN, int.Parse(drpDistributor.SelectedValue.ToString()), int.Parse(this.Session["CompanyId"].ToString()));
            clsWebFormUtil.FillDropDownList(DrpTargetFor, dt, 0, 6, true);
        }
    }
    private void LoadPrincipal()
    {
        SKUPriceDetailController PController = new SKUPriceDetailController();
        DataTable m_dt = PController.SelectDataPrice(Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, int.Parse(this.Session["UserId"].ToString()), Constants.IntNullValue, 0, DateTime.Parse(this.Session["CurrentWorkDate"].ToString()));
        clsWebFormUtil.FillDropDownList(this.drpPrincipal, m_dt, 0, 1, true);
    }
    private void LoadSKUDetail()
    {
        SKUPriceDetailController PController = new SKUPriceDetailController();
        if (drpPrincipal.Items.Count  > 0)
        {
            DataTable Dtsku_Price = PController.SelectDataPrice(int.Parse(drpPrincipal.SelectedValue.ToString()), Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, int.Parse(drpDistributor.SelectedValue.ToString())   , int.Parse(this.Session["UserId"].ToString()), Constants.IntNullValue, 2, DateTime.Parse(this.Session["CurrentWorkDate"].ToString()));
            clsWebFormUtil.FillListBox(this.lstCode, Dtsku_Price, 10, 10, true);
            this.Session.Add("Dtsku_Price", Dtsku_Price);
                       
        }
    }
    private void LoadGird()
    {
        if (txtFromdate.Text.Length > 1 && drpDistributor.Items.Count > 0 && DrpTargetFor.Items.Count > 0 && drpPrincipal.Items.Count > 0)
        {
            decimal TotalValue = 0;
            TargetController TG = new TargetController();
            DataTable dt = TG.SelectTarget(DateTime.Parse(txtFromdate.Text), int.Parse(DrpTargetType.SelectedValue.ToString()), int.Parse(DrpTargetFor.SelectedValue.ToString()), int.Parse(drpDistributor.SelectedValue.ToString()), int.Parse(drpPrincipal.SelectedValue.ToString()));
            GrdPurchase.DataSource = dt;
            GrdPurchase.DataBind();
            foreach (DataRow dr in dt.Rows)
            {
                TotalValue += decimal.Parse(dr["AMOUNT"].ToString());
              
            }
            txtTotalAmt.Text = decimal.Round(TotalValue, 2).ToString();
           
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert(' Some Selection is Wrong');", true); 
        }
    }
    private void ClearAll()
    {
        txtskuCode.Text = "";
        txtskuName.Text = "";
        txtUnitRate.Text = "";
        txtQuantity.Text = "";
        btnSave.Text = "Save";
        txtskuCode.Enabled = true;
        
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.LoadDistributor();
            this.LoadTargetForId();
            this.LoadPrincipal();
            this.LoadSKUDetail();
            btnSave.Attributes.Add("onclick", "return ValidateForm();");
        }
    }
    protected void ChbBatchNo_CheckedChanged(object sender, EventArgs e)
    {

    }
    protected void GrdPurchase_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        TargetController TG = new TargetController();
        TG.UpdateTarget(long.Parse(GrdPurchase.Rows[e.RowIndex].Cells[0].Text), int.Parse(drpDistributor.SelectedValue.ToString()), Constants.DecimalNullValue, Constants.IntNullValue, false);
        this.LoadGird();         
    }
    protected void GrdPurchase_RowEditing(object sender, GridViewEditEventArgs e)
    {
        TargetId = long.Parse(GrdPurchase.Rows[e.NewEditIndex].Cells[0].Text);
        txtskuCode.Text = GrdPurchase.Rows[e.NewEditIndex].Cells[2].Text;
        txtskuName.Text = GrdPurchase.Rows[e.NewEditIndex].Cells[3].Text;
        txtQuantity.Text = GrdPurchase.Rows[e.NewEditIndex].Cells[4].Text;
        txtUnitRate.Text = GrdPurchase.Rows[e.NewEditIndex].Cells[5].Text;
        btnSave.Text = "Update";
        txtskuCode.Enabled = false;
         
    }
    protected void drpDistributor_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadSKUDetail();
        LoadTargetForId();
       
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        TargetController TG = new TargetController();
        DataTable Dtsku_Price = (DataTable)this.Session["Dtsku_Price"];
        DataRow[] foundRows = Dtsku_Price.Select("SKU_CODE  = '" + txtskuCode.Text + "'");
        if (foundRows.Length > 0)
        {
            if (btnSave.Text == "Save")
            {
                TG.InsertTarget(int.Parse(drpDistributor.SelectedValue.ToString()), DateTime.Parse(txtFromdate.Text), int.Parse(DrpTargetType.SelectedValue.ToString()), int.Parse(DrpTargetFor.SelectedValue.ToString()),
                    int.Parse(foundRows[0]["SKU_ID"].ToString()), decimal.Parse(foundRows[0]["TRADE_PRICE"].ToString()), int.Parse(txtQuantity.Text), int.Parse(drpPrincipal.SelectedValue.ToString()), int.Parse(this.Session["UserId"].ToString()));
            }
            else
            {
                TG.UpdateTarget(TargetId, int.Parse(drpDistributor.SelectedValue.ToString()), decimal.Parse(txtUnitRate.Text), int.Parse(txtQuantity.Text), true);              
            }

        }
        this.LoadGird();
        this.ClearAll();
        ScriptManager.GetCurrent(Page).SetFocus(txtskuCode); 
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        
               
    }
    protected void DrpTargetFor_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadGird(); 
    }
    protected void btnTarget_Click(object sender, EventArgs e)
    {
        this.LoadGird(); 
    }
    protected void drpPrincipal_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadSKUDetail();
    }

}
