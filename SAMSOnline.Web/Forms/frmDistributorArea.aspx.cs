using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using SAMS.BusinessLayer.Classes;
using SAMS.Common.Classes;

public partial class Forms_frmDistributorArea : System.Web.UI.Page
{
    static long Area_Id;
    static long Route_id;
    static string strcode = "";

    private void LoadDISTRIBUTOR()
    {
        DistributorController mController = new DistributorController();
        DataTable dtDistributor = mController.SelectDistributorInfo(Constants.IntNullValue, int.Parse(this.Session["UserId"].ToString()), int.Parse(this.Session["CompanyId"].ToString()));
        clsWebFormUtil.FillDropDownList(drpDistributor, dtDistributor, 0, 2, true);
        clsWebFormUtil.FillDropDownList(drpMDistributor, dtDistributor, 0, 2, true);
    }
    private void LoadTown()
    {
        if (drpDistributor.Items.Count > 0)
        {
            GeoHierarchyController gController = new GeoHierarchyController();
            DataTable dt = gController.SelectAssignTown(Constants.IntNullValue,int.Parse(drpDistributor.SelectedValue.ToString()), 1);
            clsWebFormUtil.FillDropDownList(drpTown, dt, 0, 1, true);
        }

    }
    private void LoadMTown()
    {
        if (drpMDistributor.Items.Count > 0)
        {
            GeoHierarchyController gController = new GeoHierarchyController();
            DataTable dt = gController.SelectAssignTown(Constants.IntNullValue,int.Parse(drpMDistributor.SelectedValue.ToString()), 1);
            clsWebFormUtil.FillDropDownList(DrpMTown, dt, 0, 1, true);
        }
    }
    private void LoadAREA()
    {
        if (drpMDistributor.Items.Count > 0 && DrpMTown.Items.Count > 0)
        {
            DistributorAreaController mController = new DistributorAreaController();
            DataTable dt = mController.SelectDist_Area(Constants.LongNullValue, Constants.DateNullValue, Constants.DateNullValue, int.Parse(drpMDistributor.SelectedValue.ToString()), int.Parse(DrpMTown.SelectedValue.ToString()), null, null);
            clsWebFormUtil.FillDropDownList(DrpRoute, dt, 0, 6, true);
        }
    }
    private void LoadGrid()
    {
        if (drpDistributor.Items.Count > 0 && drpTown.Items.Count > 0)
        {
            DistributorAreaController mController = new DistributorAreaController();
            DataTable dt = mController.SelectDist_Area(Constants.LongNullValue, Constants.DateNullValue, Constants.DateNullValue, int.Parse(drpDistributor.SelectedValue.ToString()), int.Parse(drpTown.SelectedValue.ToString()), null, null);
            grdAreaData.DataSource = dt;
            grdAreaData.DataBind();
        }
    }
    private void LoadMarketGrid()
    {
        if (drpMDistributor.Items.Count > 0 && DrpMTown.Items.Count > 0 && DrpRoute.Items.Count > 0)
        {
            DistributorRouteController mController = new DistributorRouteController();
            DataTable dt = mController.SelectDistributorRoute(Constants.LongNullValue, int.Parse(drpMDistributor.SelectedValue.ToString()), int.Parse(DrpMTown.SelectedValue.ToString()), long.Parse(DrpRoute.SelectedValue.ToString()));
            grdRouteData.DataSource = dt;
            grdRouteData.DataBind();
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!Page.IsPostBack)
        {
            this.LoadDISTRIBUTOR();
            this.LoadTown();
            this.LoadGrid();
            this.LoadMTown();
            this.LoadAREA();
            this.LoadMarketGrid();
            btnSaveRoute.Attributes.Add("onclick", "return ValidateArea()");
            btnSaveMarket.Attributes.Add("onclick", "return ValidateRoute()");

        }
    }
    protected void btnSaveRoute_Click(object sender, EventArgs e)
    {
        DistributorAreaController mController = new DistributorAreaController();
        if (btnSaveRoute.Text == "Save")
        {
            SETTINGS_TABLE_Controller mSettingsTableControl = new SETTINGS_TABLE_Controller();
            DataTable dtSettingsTable = mSettingsTableControl.Select_SETTINGS_TABLE("DISTRIBUTOR_AREA", "AREA_ID", int.Parse(drpDistributor.SelectedValue.ToString()));

            if (dtSettingsTable.Rows.Count > 0)
            {
                Area_Id = long.Parse(dtSettingsTable.Rows[0]["Value"].ToString()) + 1;
                if (Area_Id.ToString().Length == 1)
                {
                    strcode = "RT" + "00" + Area_Id.ToString();
                }
                else if (Area_Id.ToString().Length == 2)
                {
                    strcode = "RT" + "0" + Area_Id.ToString();
                }
                else if (Area_Id.ToString().Length == 3)
                {
                    strcode = "RT" + Area_Id.ToString();
                }

                mController.insertDisct_Area(long.Parse(Area_Id.ToString()), bool.Parse("true"), int.Parse(drpDistributor.SelectedValue.ToString()), int.Parse(drpTown.SelectedValue.ToString()), txtAreaName.Text, strcode);

            }
        }
        else if (btnSaveRoute.Text == "Update")
        {
            mController.UpdateDisct_Area(Area_Id, ChIsActive.Checked, System.DateTime.Now, System.DateTime.Now, int.Parse(drpDistributor.SelectedValue.ToString()), int.Parse(drpTown.SelectedValue.ToString()), txtAreaName.Text, strcode);

        }
        this.LoadAREA();
        this.LoadGrid();
        drpDistributor.Enabled = true;
        drpTown.Enabled = true;
        txtAreaName.Text = "";
        btnSaveRoute.Text = "Save";
    }
    protected void drpDistributor_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadTown();
        this.LoadGrid();
    }
    protected void drpTown_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadGrid();
    }
    protected void grdAreaData_RowEditing(object sender, GridViewEditEventArgs e)
    {
        Area_Id = long.Parse(grdAreaData.Rows[e.NewEditIndex].Cells[0].Text);
        int TownId = int.Parse(grdAreaData.Rows[e.NewEditIndex].Cells[2].Text);
        for (int i = 0; drpTown.Items.Count > 0; i++)
        {
            if (int.Parse(drpTown.Items[i].Value.ToString()) == TownId)
            {
                drpTown.Items[i].Selected = true;
                break;
            }
        }
        strcode = grdAreaData.Rows[e.NewEditIndex].Cells[5].Text;
        txtAreaName.Text = grdAreaData.Rows[e.NewEditIndex].Cells[6].Text;
        ChIsActive.Checked = bool.Parse(grdAreaData.Rows[e.NewEditIndex].Cells[7].Text);
        drpDistributor.Enabled = false;
        drpTown.Enabled = false;
        btnSaveRoute.Text = "Update";
    }
    protected void btnSaveMarket_Click(object sender, EventArgs e)
    {
        DistributorRouteController mController = new DistributorRouteController();
        if (btnSaveMarket.Text == "Save")
        {
            SETTINGS_TABLE_Controller mSettingsTableControl = new SETTINGS_TABLE_Controller();
            DataTable dtSettingsTable = mSettingsTableControl.Select_SETTINGS_TABLE("DISTRIBUTOR_ROUTE", "ROUTE_ID", int.Parse(drpMDistributor.SelectedValue.ToString()));

            if (dtSettingsTable.Rows.Count > 0)
            {
                Route_id = long.Parse(dtSettingsTable.Rows[0]["Value"].ToString()) + 1;
                if (Route_id.ToString().Length == 1)
                {
                    strcode = "MR" + "00" + Route_id.ToString();
                }
                else if (Route_id.ToString().Length == 2)
                {
                    strcode = "MR" + "0" + Route_id.ToString();
                }
                else if (Route_id.ToString().Length == 3)
                {
                    strcode = "MR" + Route_id.ToString();
                }
                mController.InsertDistributorRoute(Route_id, int.Parse(drpMDistributor.SelectedValue.ToString()), int.Parse(DrpMTown.SelectedValue.ToString()), int.Parse(DrpRoute.SelectedValue.ToString()), strcode, txtMarketName.Text, true);

            }
        }
        else
        {
            mController.UpdateDistributorRoute(Route_id, int.Parse(drpMDistributor.SelectedValue.ToString()), int.Parse(DrpMTown.SelectedValue.ToString()), int.Parse(DrpRoute.SelectedValue.ToString()), strcode, txtMarketName.Text, chMarkeIsActive.Checked);

        }
        drpMDistributor.Enabled = true;
        drpMDistributor.Enabled = true;
        DrpMTown.Enabled = true;
        DrpRoute.Enabled = true;
        btnSaveMarket.Text = "Save";
        txtMarketName.Text = "";
        this.LoadMarketGrid();
    }
    protected void drpMDistributor_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadMTown();
        this.LoadAREA();
        this.LoadMarketGrid();
    }
    protected void DrpMTown_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadAREA();
        this.LoadMarketGrid();
    }
    protected void grdRouteData_RowEditing(object sender, GridViewEditEventArgs e)
    {
        Route_id = long.Parse(grdRouteData.Rows[e.NewEditIndex].Cells[0].Text);
        strcode = grdRouteData.Rows[e.NewEditIndex].Cells[7].Text;
        txtMarketName.Text = grdRouteData.Rows[e.NewEditIndex].Cells[8].Text;
        chMarkeIsActive.Checked = bool.Parse(grdRouteData.Rows[e.NewEditIndex].Cells[9].Text);
        drpMDistributor.Enabled = false;
        drpMDistributor.Enabled = false;
        DrpMTown.Enabled = false;
         DrpRoute.Enabled = false;
        btnSaveMarket.Text = "Update";
    }
    protected void DrpRoute_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadMarketGrid();
    }
    protected void grdRouteData_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdRouteData.PageIndex = e.NewPageIndex;
        this.LoadMarketGrid();
    }
    protected void grdAreaData_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdAreaData.PageIndex = e.NewPageIndex;
        this.LoadGrid();
    }

}
