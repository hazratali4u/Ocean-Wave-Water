using System;
using System.Data;
using System.Web.UI.WebControls;
using SAMS.BusinessLayer.Classes;
using SAMS.Common.Classes;

public partial class Forms_frmSaleForceShortage : System.Web.UI.Page
{
    private static int pSaleShortId;

    private void LoadDeliveryman()
    {
        if (drpDistributor.Items.Count > 0)
        {
            DrpSaleForce.Items.Clear();
            Distributor_UserController mDController = new Distributor_UserController();
            DataTable m_dt = mDController.SelectSaleForceAssignedArea(int.Parse(drpDistributor.SelectedValue.ToString()),Constants.IntNullValue, int.Parse(this.Session["CompanyId"].ToString()));
            clsWebFormUtil.FillDropDownList(this.DrpSaleForce, m_dt, 0, 3);
        }
        else
        {
            DrpSaleForce.Items.Clear();
        }
    }
    private void LoadPrincipal()
    {
        SKUPriceDetailController PController = new SKUPriceDetailController();
        DataTable m_dt = PController.SelectDataPrice(Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, int.Parse(this.Session["UserId"].ToString()), Constants.IntNullValue, 0, DateTime.Parse(this.Session["CurrentWorkDate"].ToString()));
        clsWebFormUtil.FillDropDownList(this.DrpPrincipal, m_dt, 0, 1);
    }
    private void LoadDistributor()
    {
        DistributorController DController = new DistributorController();
        DataTable dt = DController.SelectDistributorInfo(Constants.IntNullValue, int.Parse(this.Session["UserId"].ToString()), int.Parse(this.Session["CompanyId"].ToString()));
        clsWebFormUtil.FillDropDownList(this.drpDistributor, dt, 0, 2);
    }
    private void LoadGrid()
    {
        Distributor_UserController dCon = new Distributor_UserController();
        DataTable dt =  dCon.SelectSalesForceShortage(int.Parse(drpDistributor.SelectedValue.ToString()), Constants.IntNullValue, Constants.IntNullValue , DateTime.Parse(this.Session["CurrentWorkDate"].ToString()));
        GrdOrder.DataSource = dt;
        GrdOrder.DataBind(); 
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.LoadDistributor();
            this.LoadPrincipal();
            this.LoadDeliveryman();
            this.LoadGrid(); 
        }
    }
    protected void btnAddNew_Click(object sender, EventArgs e)
    {
        Distributor_UserController mController = new Distributor_UserController();
        if (btnAddNew.Text == "Save")
        {
            mController.InsertSalesForceShortage(int.Parse(drpDistributor.SelectedValue.ToString()), int.Parse(DrpPrincipal.SelectedValue.ToString()), int.Parse(DrpSaleForce.SelectedValue.ToString()), decimal.Parse(txtAmount.Text), DateTime.Parse(this.Session["CurrentWorkDate"].ToString()), txtRemarks.Text);

        }
        else
        {
            mController.UpdateSalesForceShortage(pSaleShortId,int.Parse(drpDistributor.SelectedValue.ToString()), int.Parse(DrpPrincipal.SelectedValue.ToString()), int.Parse(DrpSaleForce.SelectedValue.ToString()), decimal.Parse(txtAmount.Text), DateTime.Parse(this.Session["CurrentWorkDate"].ToString()), txtRemarks.Text);
        }
        txtAmount.Text = "";
        txtRemarks.Text = "";
        this.LoadGrid(); 
    }
    protected void GrdOrder_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
    protected void GrdOrder_RowEditing(object sender, GridViewEditEventArgs e)
    {
        pSaleShortId = int.Parse(GrdOrder.Rows[e.NewEditIndex].Cells[0].Text);
        this.DrpSaleForce.SelectedValue = GrdOrder.Rows[e.NewEditIndex].Cells[1].Text;
        this.DrpPrincipal.SelectedValue = GrdOrder.Rows[e.NewEditIndex].Cells[2].Text;
        this.txtRemarks.Text  = GrdOrder.Rows[e.NewEditIndex].Cells[5].Text;
        this.txtAmount.Text  = GrdOrder.Rows[e.NewEditIndex].Cells[6].Text;
        this.btnAddNew.Text = "Update"; 
     }
}
