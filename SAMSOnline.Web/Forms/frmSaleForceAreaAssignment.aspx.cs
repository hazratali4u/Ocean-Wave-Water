using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using SAMS.BusinessLayer.Classes;
using SAMS.Common.Classes;
    
public partial class Forms_frmSaleForceAreaAssignment : System.Web.UI.Page
{
    Distributor_UserController UController = new Distributor_UserController();
   
    private void LoadDesignation()
    {
        SLASHCodesController mController = new SLASHCodesController();
        DataTable m_dt = mController.SelectSlashCodes(Constants.IntNullValue, null, Constants.SaleForce, null, Constants.IntNullValue, true);
        for (int i = 0; i < m_dt.Rows.Count; i++)
        {
            if (int.Parse(m_dt.Rows[i]["REF_ID"].ToString()) == Constants.SALES_FORCE_ORDERBOOKER || int.Parse(m_dt.Rows[i]["REF_ID"].ToString()) == Constants.SALES_FORCE_DELIVERYMAN ||  int.Parse(m_dt.Rows[i]["REF_ID"].ToString()) == Constants.SALES_FORCE_SALESPERSON)
            {
                DrpDesignation.Items.Add(new ListItem(m_dt.Rows[i]["SLASH_DESC"].ToString(), m_dt.Rows[i]["REF_ID"].ToString()));          
            }
        }
        
    }
    private void LoadDISTRIBUTOR()
    {
        DistributorController mController = new DistributorController();
        DataTable dtDistributor = mController.SelectDistributorInfo(Constants.IntNullValue, int.Parse(this.Session["UserId"].ToString()), int.Parse(this.Session["CompanyId"].ToString()));
        clsWebFormUtil.FillDropDownList(drpDistributor, dtDistributor, 0, 2, true);
              
    }
    protected void LoadGrid()
    {
        if (drpDistributor.Items.Count > 0 && DrpDesignation.Items.Count > 0 )
        {
            DataTable dt = UController.SelectDistributorUser(int.Parse(DrpDesignation.SelectedValue.ToString()), int.Parse(drpDistributor.SelectedValue.ToString()), int.Parse(this.Session["CompanyId"].ToString()));
            clsWebFormUtil.FillDropDownList(this.DrpSaleForce, dt, 0, 6, true);    
        }
    }
    private void LoadArea()
    {
        if (drpDistributor.Items.Count > 0)
        {
            DistributorAreaController gController = new DistributorAreaController();
            DataTable dt = gController.SelectDist_Area(Constants.LongNullValue,Constants.DateNullValue,Constants.DateNullValue,int.Parse(drpDistributor.SelectedValue.ToString()),Constants.IntNullValue,null,null);          
            clsWebFormUtil.FillListBox(ChbAreaList, dt, 0, 6, true);
        }
    }
    private void LoadPrincipal()
    {
        SKUPriceDetailController PController = new SKUPriceDetailController();
        DataTable m_dt = PController.SelectDataPrice(Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, int.Parse(this.Session["UserId"].ToString()), Constants.IntNullValue, 0, DateTime.Parse(this.Session["CurrentWorkDate"].ToString()));
        clsWebFormUtil.FillListBox(this.ChbPrincipal, m_dt, 0, 1, true);
    }
    private void LoadAssisgned()
    {
        for (int nInner = 0; nInner < this.ChbAreaList.Items.Count; nInner++)
        {
            ChbAreaList.Items[nInner].Selected = false;
        }
        for (int nInner = 0; nInner < this.ChbPrincipal.Items.Count; nInner++)
        {
            ChbPrincipal.Items[nInner].Selected = false;
        }
              
        if (DrpSaleForce.Items.Count > 0)
        {
            #region Select Assign Area

            DataTable dtArea = UController.SelectSalesForceArea(int.Parse(drpDistributor.SelectedValue.ToString()), int.Parse(DrpSaleForce.SelectedValue.ToString()), Constants.LongNullValue);

            for (int nOuter = 0; nOuter < dtArea.Rows.Count; nOuter++)
            {
                int AreaId = int.Parse(dtArea.Rows[nOuter]["Area_Id"].ToString());

                for (int nInner = 0; nInner < this.ChbAreaList.Items.Count; nInner++)
                {
                    if (int.Parse(ChbAreaList.Items[nInner].Value) == AreaId)
                    {
                        ChbAreaList.Items[nInner].Selected = true;
                        break;
                    }
                }
            }
            #endregion

            #region Select Assign Principal

            DataTable dtPrincipal = UController.SelectSalesForcePrincipal(int.Parse(drpDistributor.SelectedValue.ToString()), int.Parse(DrpSaleForce.SelectedValue.ToString()), Constants.IntNullValue);

            for (int nOuter = 0; nOuter < dtPrincipal.Rows.Count; nOuter++)
            {
                int PrincipalId = int.Parse(dtPrincipal.Rows[nOuter]["PRINCIPAL_ID"].ToString());

                for (int nInner = 0; nInner < this.ChbPrincipal.Items.Count; nInner++)
                {
                    if (int.Parse(ChbPrincipal.Items[nInner].Value) == PrincipalId)
                    {
                        ChbPrincipal.Items[nInner].Selected = true;
                        break;
                    }
                }
            }
            #endregion
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.LoadDISTRIBUTOR();
            this.LoadDesignation();
            this.LoadGrid();
            this.LoadArea();
            this.LoadPrincipal();
            this.LoadAssisgned();
         }
    }
    protected void drpDistributor_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadGrid();
        this.LoadArea();
        this.LoadAssisgned();
    }
    protected void DrpDesignation_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadGrid();
        this.LoadAssisgned();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {

        UController.UpdateSalesForceArea(int.Parse(drpDistributor.SelectedValue.ToString()), int.Parse(DrpSaleForce.SelectedValue.ToString()));
        
        for (int i = 0; i < ChbAreaList.Items.Count; i++)
        {
            if (ChbAreaList.Items[i].Selected == true)
            {
                UController.InsertSalesForceArea(int.Parse(drpDistributor.SelectedValue.ToString()), int.Parse(DrpSaleForce.SelectedValue.ToString()),int.Parse(ChbAreaList.Items[i].Value.ToString()));
            }
        }
        
        UController.UpdateSalesForcePrincipal(int.Parse(drpDistributor.SelectedValue.ToString()), int.Parse(DrpSaleForce.SelectedValue.ToString()));

        for (int i = 0; i < ChbPrincipal.Items.Count; i++)
        {
            if (ChbPrincipal.Items[i].Selected == true)
            {
                UController.InsertSalesForcePrincipal(int.Parse(drpDistributor.SelectedValue.ToString()), int.Parse(DrpSaleForce.SelectedValue.ToString()), int.Parse(ChbPrincipal.Items[i].Value.ToString()));
            }
        }
     }
    protected void DrpSaleForce_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadAssisgned();
    }

}
