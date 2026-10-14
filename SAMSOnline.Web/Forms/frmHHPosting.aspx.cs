using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using SAMS.BusinessLayer.Classes;

public partial class Forms_frmHHPosting : System.Web.UI.Page
{
    HHPostingController postingController = new HHPostingController();
    GeoHierarchyController geoHeierarchycontroller = new GeoHierarchyController();
    Distributor_UserController distController = new Distributor_UserController();
    DataTable dt_SalesForce = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.chkSelectAll.Visible = false;
            LoadSalesForce();
            LoadDilveryMan();
            this.GridSalesOrder.Attributes.Add("onclick", "document.getElementById('hiddenField').value = this.rowIndex;");
        }
    }
    public void LoadSalesForce()
    {
        int Distributor_ID = Convert.ToInt32(this.Session["DISTRIBUTOR_ID"]);
        dt_SalesForce = distController.SelectDistributorSalesForceType(Distributor_ID, 35);

        this.ddSalesForce.DataSource = dt_SalesForce;
        this.ddSalesForce.DataTextField = "USER_NAME";
        this.ddSalesForce.DataValueField = "USER_ID";
        this.ddSalesForce.DataBind();
    }
    //public void LoadArea()
    //{
    //    DataTable dt = geoHeierarchycontroller.SelectGeoHierarchyforPosting(Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue,
    //    null, null, true, Constants.IntNullValue, Constants.Town, Constants.IntNullValue, Constants.DateNullValue, Constants.DateNullValue);
    //    this.ddArea.DataSource = dt;
    //    this.ddArea.DataTextField = "GEO_NAME";
    //    this.ddArea.DataValueField = "GEO_ID";
    //    this.ddArea.DataBind();
    //}
    public void LoadDilveryMan()
    {

        DataTable DilveryMan = new DataTable();
        int Distributor_ID = Convert.ToInt32(this.Session["DISTRIBUTOR_ID"]);
        DilveryMan = distController.SelectDistributorSalesForceType(Distributor_ID, 36);
        this.ddDilverMan.DataSource = DilveryMan;
        this.ddDilverMan.DataTextField = "USER_NAME";
        this.ddDilverMan.DataValueField = "USER_ID";
        this.ddDilverMan.DataBind();
    }
    public void GetOrders()
    {
        try
        {
            DataTable dt = postingController.GetOrders(Convert.ToInt32(ddSalesForce.SelectedValue.ToString()), 1);
            if (dt.Rows.Count > 0)
            {
                this.DivGrid.Visible = true;
                this.chkSelectAll.Visible = true;
                this.ddDilverMan.Enabled = true;
                this.btnSave.Enabled = true;
                this.ddDilverMan.Enabled = true;
                this.btnSave.Enabled = true;
                this.GridSalesOrder.DataSource = dt;
                this.GridSalesOrder.DataBind();
            }
            else
            {
                this.DivGrid.Visible = false;
                this.GridSalesOrder.DataSource = null;
                this.GridSalesOrder.DataBind();
                this.chkSelectAll.Checked = false;
                this.chkSelectAll.Visible = false;
            }
        }
        catch (Exception ex)
        {
            ex.ToString();
        }
    }
    protected void btnGetOrders_Click(object sender, EventArgs e)
    {
        GetOrders();
    }
    protected void AssignDilveryMan()
    {
        try
        {
            DataTable dt = new DataTable();
            int hhSaleOrderID = 0;
            string UserID = this.Session["UserId"].ToString();

            for (int i = 0; i < GridSalesOrder.Rows.Count; i++)
            {
                CheckBox ChbSelect = (CheckBox)GridSalesOrder.Rows[i].Cells[0].FindControl("ChbSelect");
                if (ChbSelect.Checked == true)
                {
                    hhSaleOrderID = Convert.ToInt32(GridSalesOrder.Rows[i].Cells[2].Text);
                    bool var = postingController.InsertSaleOrderMaster(hhSaleOrderID, Convert.ToInt32(ddSalesForce.SelectedValue.ToString()), Convert.ToInt32(ddDilverMan.SelectedValue.ToString()), Convert.ToInt32(DrpOrderType.SelectedValue.ToString()), Convert.ToInt32(UserID));
                }
            }

        }
        catch (Exception ex)
        {
            ex.ToString();
        }
    }
    protected void GridSalesOrder_SelectedIndexChanged(object sender, EventArgs e)
    { }
    protected void chkSelectAll_CheckedChanged(object sender, EventArgs e)
    {
        if (chkSelectAll.Checked == true)
        {
            for (int i = 0; i < this.GridSalesOrder.Rows.Count; i++)
            {
                CheckBox ChbSelect = (CheckBox)GridSalesOrder.Rows[i].Cells[0].FindControl("ChbSelect");
                ChbSelect.Checked = true;

            }
        }
        if (chkSelectAll.Checked == false)
        {
            for (int i = 0; i < this.GridSalesOrder.Rows.Count; i++)
            {
                CheckBox ChbSelect = (CheckBox)GridSalesOrder.Rows[i].Cells[0].FindControl("ChbSelect");
                ChbSelect.Checked = false;
            }
        }
    }
    protected void btnGetOrders_Click1(object sender, EventArgs e)
    {
        GetOrders();

    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        AssignDilveryMan();
        GetOrders();
    }
    protected void GridSalesOrder_PageIndexChanging1(object sender, GridViewPageEventArgs e)
    {
        this.GridSalesOrder.PageIndex = e.NewPageIndex;
        GetOrders();
    }
    protected void ddSalesForce_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
