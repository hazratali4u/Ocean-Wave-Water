using System;
using System.Data;
using System.Web.UI;
using SAMS.BusinessLayer.Classes;
using SAMS.Common.Classes;

public partial class Forms_frmTownAssignment : System.Web.UI.Page
{

    private void LoadDistributor()
    {
        DistributorController mController = new DistributorController();
        DataTable dt = mController.SelectDistributor(Constants.IntNullValue, Constants.IntNullValue, int.Parse(this.Session["CompanyId"].ToString()));
        clsWebFormUtil.FillDropDownList(drpDistributor, dt, 1, 3, true);

    }
    protected void LoadRegion()
    {
        GeoHierarchyController gController = new GeoHierarchyController();
        DataTable dt = gController.SelectGeoHierarchy(Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, null, null, true, Constants.IntNullValue, Constants.Region, Constants.IntNullValue, Constants.DateNullValue, Constants.DateNullValue, int.Parse(this.Session["CompanyId"].ToString()));
        dt.DefaultView.Sort = "GEO_ID";
        ddRegion.DataSource = dt.DefaultView;
        ddRegion.DataTextField = "GEO_NAME";
        ddRegion.DataValueField = "GEO_ID";
        ddRegion.DataBind();
    }
    protected void LoadZone()
    {
        if (ddRegion.Items.Count > 0)
        {
            GeoHierarchyController gController = new GeoHierarchyController();
            DataTable dt = gController.SelectGeoHierarchy(Constants.IntNullValue, Constants.IntNullValue, Convert.ToInt32(ddRegion.SelectedValue.ToString()), null, null, true, Constants.IntNullValue, Constants.Zone, Constants.IntNullValue, Constants.DateNullValue, Constants.DateNullValue, int.Parse(this.Session["CompanyId"].ToString()));
            ddZone.DataSource = dt;
            ddZone.DataTextField = "GEO_NAME";
            ddZone.DataValueField = "GEO_ID";
            ddZone.DataBind();
        }
    }
    protected void LoadTerritory()
    {
        if (ddZone.Items.Count > 0)
        {
            GeoHierarchyController gController = new GeoHierarchyController();
            DataTable dt = gController.SelectGeoHierarchy(Constants.IntNullValue, Constants.IntNullValue, Convert.ToInt32(ddZone.SelectedValue.ToString()), null, null, true, Constants.IntNullValue, Constants.Territory, Constants.IntNullValue, Constants.DateNullValue, Constants.DateNullValue, int.Parse(this.Session["CompanyId"].ToString()));
            ddTerritory.DataSource = dt;
            ddTerritory.DataTextField = "GEO_NAME";
            ddTerritory.DataValueField = "GEO_ID";
            ddTerritory.DataBind();
        }
        else
        {
            this.ddTerritory.Items.Clear();
        }
    }
    private void LoadUnAssignTown()
    {
        if (ddTerritory.Items.Count > 0 && drpDistributor.Items.Count > 0)
        {
            GeoHierarchyController gController = new GeoHierarchyController();
            DataTable dt = gController.SelectAssignTown(int.Parse(ddTerritory.SelectedValue.ToString()), int.Parse(drpDistributor.SelectedValue.ToString()), 0);
            clsWebFormUtil.FillListBox(lstUnAssignTown, dt, 0, 1, true);
        }
        else
        {
            lstUnAssignTown.Items.Clear();
        }

    }
    private void LoadAssignTown()
    {

        if (ddTerritory.Items.Count > 0 && drpDistributor.Items.Count > 0)
        {
            GeoHierarchyController gController = new GeoHierarchyController();
            DataTable dt = gController.SelectAssignTown(int.Parse(ddTerritory.SelectedValue.ToString()), int.Parse(drpDistributor.SelectedValue.ToString()), 1);
            clsWebFormUtil.FillListBox(lstAssignTown, dt, 0, 1, true);
        }
        else
        {
            lstAssignTown.Items.Clear();
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.LoadDistributor();
            this.LoadRegion();
            this.LoadZone();
            this.LoadTerritory();
            this.LoadUnAssignTown();
            this.LoadAssignTown();

        }
    }
    protected void ddRegion_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadZone();
        this.LoadTerritory();
        this.LoadUnAssignTown();
        this.LoadAssignTown();

    }
    protected void ddZone_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadTerritory();
        this.LoadUnAssignTown();
        this.LoadAssignTown();
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        DistributorTownController mTownController = new DistributorTownController();
        if (drpDistributor.Items.Count > 0)
        {
            for (int i = 0; i < lstUnAssignTown.Items.Count; i++)
            {

                mTownController.InsertDistributorTown(int.Parse(drpDistributor.SelectedValue.ToString()), int.Parse(lstUnAssignTown.Items[i].Value), bool.Parse("True"), 1, null, int.Parse(this.Session["UserId"].ToString()));

            }
        }
        this.LoadUnAssignTown();
        this.LoadAssignTown();

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        DistributorTownController mTownController = new DistributorTownController();
        for (int i = 0; i < lstUnAssignTown.Items.Count; i++)
        {
            if (lstUnAssignTown.Items[i].Selected == true && drpDistributor.Items.Count > 0)
            {
                mTownController.InsertDistributorTown(int.Parse(drpDistributor.SelectedValue.ToString()), int.Parse(lstUnAssignTown.Items[i].Value), bool.Parse("True"), 1, null, int.Parse(this.Session["UserId"].ToString()));
            }
        }
        this.LoadUnAssignTown();
        this.LoadAssignTown();
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        DistributorTownController mTownController = new DistributorTownController();
        for (int i = 0; i < lstAssignTown.Items.Count; i++)
        {
            if (lstAssignTown.Items[i].Selected == true && drpDistributor.Items.Count > 0)
            {
                mTownController.DeletedDistributorTown(int.Parse(drpDistributor.SelectedValue.ToString()), int.Parse(lstAssignTown.Items[i].Value));
            }
        }
        this.LoadUnAssignTown();
        this.LoadAssignTown();
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        DistributorTownController mTownController = new DistributorTownController();
        if (drpDistributor.Items.Count > 0)
        {
            for (int i = 0; i < lstAssignTown.Items.Count; i++)
            {

                mTownController.DeletedDistributorTown(int.Parse(drpDistributor.SelectedValue.ToString()), int.Parse(lstAssignTown.Items[i].Value));

            }
        }
        this.LoadUnAssignTown();
        this.LoadAssignTown();

    }
    protected void drpDistributor_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadUnAssignTown();
        this.LoadAssignTown();
    }
    protected void ddTerritory_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadUnAssignTown();
        this.LoadAssignTown();
    }

}
