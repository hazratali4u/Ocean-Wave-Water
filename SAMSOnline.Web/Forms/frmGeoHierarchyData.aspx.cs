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
using SAMS.BusinessLayer.Classes;
using SAMS.Common.Classes;
    
public partial class Forms_frmGeoHierarchyData : System.Web.UI.Page
{
    GeoHierarchyController GControler = new GeoHierarchyController();
    private static int RegionId, ZoneId, TerritoryId, TownId;

    protected void LoadRegion()
    {
        DataTable dt = GControler.SelectGeoHierarchy(Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, null, null, true, Constants.IntNullValue, Constants.Region, Constants.IntNullValue, Constants.DateNullValue, Constants.DateNullValue, int.Parse(this.Session["CompanyId"].ToString()));
        clsWebFormUtil.FillDropDownList(this.DrpRegion, dt, 0, 4, true);
        clsWebFormUtil.FillDropDownList(this.drpRegionTerritory, dt, 0, 4, true);
        clsWebFormUtil.FillDropDownList(this.DrpTownRegion, dt, 0, 4, true);   
        grdRegionData.DataSource = dt;
        grdRegionData.DataBind();  
    }
    protected void LoadZone()
    {
        if (DrpRegion.Items.Count > 0)
        {
            DataTable dt = GControler.SelectGeoHierarchy(Constants.IntNullValue, Constants.IntNullValue, int.Parse(DrpRegion.SelectedValue.ToString()), null, null, true, Constants.IntNullValue, Constants.Zone, Constants.IntNullValue, Constants.DateNullValue, Constants.DateNullValue, int.Parse(this.Session["CompanyId"].ToString()));
            grdZoneData.DataSource = dt;
            grdZoneData.DataBind();
        }
    }
    private void LoadTerritoryZone()
    {
        if (drpRegionTerritory.Items.Count > 0)
        {
            DataTable dt = GControler.SelectGeoHierarchy(Constants.IntNullValue, Constants.IntNullValue, int.Parse(drpRegionTerritory.SelectedValue.ToString()), null, null, true, Constants.IntNullValue, Constants.Zone, Constants.IntNullValue, Constants.DateNullValue, Constants.DateNullValue, int.Parse(this.Session["CompanyId"].ToString()));
            clsWebFormUtil.FillDropDownList(this.DrpZone, dt, 0, 4, true);
           
        }
    }
    private void LoadTownZone()
    {
        if (DrpTownRegion.Items.Count > 0)
        {
            DataTable dt = GControler.SelectGeoHierarchy(Constants.IntNullValue, Constants.IntNullValue, int.Parse(DrpTownRegion.SelectedValue.ToString()), null, null, true, Constants.IntNullValue, Constants.Zone, Constants.IntNullValue, Constants.DateNullValue, Constants.DateNullValue, int.Parse(this.Session["CompanyId"].ToString()));
            clsWebFormUtil.FillDropDownList(this.DrpTownZone, dt, 0, 4, true);
            
        }
    }
    private void LoadTownTerritory()
    {
        if (DrpTownZone.Items.Count > 0)
        {
            DataTable dt = GControler.SelectGeoHierarchy(Constants.IntNullValue, Constants.IntNullValue, int.Parse(DrpTownZone.SelectedValue.ToString()), null, null, true, Constants.IntNullValue, Constants.Territory, Constants.IntNullValue, Constants.DateNullValue, Constants.DateNullValue, int.Parse(this.Session["CompanyId"].ToString()));
            clsWebFormUtil.FillDropDownList(this.DrpTerritory, dt, 0, 4, true);
            grdZoneData.DataSource = dt;
            grdZoneData.DataBind();
        }
    }
    protected void LoadTerritory()
    {
        if (DrpZone.Items.Count > 0)
        {
            DataTable dt = GControler.SelectGeoHierarchy(Constants.IntNullValue, Constants.IntNullValue, int.Parse(DrpZone.SelectedValue.ToString()), null, null, true, Constants.IntNullValue, Constants.Territory, Constants.IntNullValue, Constants.DateNullValue, Constants.DateNullValue, int.Parse(this.Session["CompanyId"].ToString()));
            grdTerritoryData.DataSource = dt;
            grdTerritoryData.DataBind();
        }
    }
    protected void LoadTown()
    {
        if (DrpTerritory.Items.Count > 0)
        {
            DataTable dt = GControler.SelectGeoHierarchy(Constants.IntNullValue, Constants.IntNullValue, int.Parse(DrpTerritory.SelectedValue.ToString()), null, null, true, Constants.IntNullValue, Constants.Town, Constants.IntNullValue, Constants.DateNullValue, Constants.DateNullValue, int.Parse(this.Session["CompanyId"].ToString()));
            grdTownData.DataSource = dt;
            grdTownData.DataBind();
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.LoadRegion();
            this.LoadZone();
            this.LoadTerritoryZone();
            this.LoadTerritory();
            this.LoadTownZone(); 
            this.LoadTownTerritory();
            this.LoadTown();
          
            SAMS.Common.Classes.Configuration.DistributorId = 1;
            btnRegionSave.Attributes.Add("onclick", "return ValidatRegion()");
            btnSaveZone.Attributes.Add("onclick", "return ValidatZone()");
            btnSaveTerritory.Attributes.Add("onclick", "return ValidateTerritory()");
            btnSaveTown.Attributes.Add("onclick", "return ValidateTown()");
                    
        }

    }
    protected void btnRegionSave_Click(object sender, EventArgs e)
    {
        if (btnRegionSave.Text == "Save")
        {
            string InsertValue = GControler.InsertHierarchy(Constants.IntNullValue, txtRegionCode.Text, txtRegionName.Text, true,true, Constants.IntNullValue, int.Parse(this.Session["CompanyId"].ToString()), Constants.Region,int.Parse(this.Session["UserId"].ToString()), SAMS.Common.Classes.Configuration.DistributorId, null);
        }
        else
        {
            GControler.UpdateHierarchy(RegionId, Constants.IntNullValue, txtRegionCode.Text, txtRegionName.Text, true, ChIsActive.Checked, Constants.IntNullValue, int.Parse(this.Session["CompanyId"].ToString()), Constants.Region, int.Parse(this.Session["UserId"].ToString()), SAMS.Common.Classes.Configuration.DistributorId, null);
        }
        this.LoadRegion(); 
        txtRegionCode.Text = "";
        txtRegionName.Text = "";
        btnRegionSave.Text = "Save"; 
    }
    protected void grdRegionData_RowEditing(object sender, GridViewEditEventArgs e)
    {
        RegionId = int.Parse(grdRegionData.Rows[e.NewEditIndex].Cells[0].Text);
        txtRegionCode.Text  = grdRegionData.Rows[e.NewEditIndex].Cells[1].Text;
        txtRegionName.Text  = grdRegionData.Rows[e.NewEditIndex].Cells[2].Text;
        ChIsActive.Checked = bool.Parse(grdRegionData.Rows[e.NewEditIndex].Cells[3].Text);   
        btnRegionSave.Text = "Update"; 
    }
    protected void btnSaveZone_Click(object sender, EventArgs e)
    {
        if (btnSaveZone.Text == "Save")
        {
            string InsertValue = GControler.InsertHierarchy(int.Parse(DrpRegion.SelectedValue.ToString()), txtZoneCode.Text, txtZoneName.Text, true, true , Constants.IntNullValue, int.Parse(this.Session["CompanyId"].ToString()), Constants.Zone, int.Parse(this.Session["UserId"].ToString()), SAMS.Common.Classes.Configuration.DistributorId, null);
        }
        else
        {
            GControler.UpdateHierarchy(ZoneId, int.Parse(DrpRegion.SelectedValue.ToString()), txtZoneCode.Text, txtZoneName.Text, true, chbIsZoneActive.Checked, Constants.IntNullValue, int.Parse(this.Session["CompanyId"].ToString()), Constants.Zone, int.Parse(this.Session["UserId"].ToString()), SAMS.Common.Classes.Configuration.DistributorId, null);
        }
        this.LoadZone();
        this.LoadTerritoryZone();
        this.LoadTownZone(); 
        txtZoneCode.Text = "";
        txtZoneName.Text = "";
        btnSaveZone.Text = "Save"; 
 
    }
    protected void DrpRegion_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadZone(); 
    }
    protected void grdZoneData_RowEditing(object sender, GridViewEditEventArgs e)
    {
        ZoneId = int.Parse(grdZoneData.Rows[e.NewEditIndex].Cells[1].Text);
        txtZoneCode.Text = grdZoneData.Rows[e.NewEditIndex].Cells[2].Text;
        txtZoneName.Text = grdZoneData.Rows[e.NewEditIndex].Cells[3].Text;
        chbIsZoneActive.Checked = bool.Parse(grdZoneData.Rows[e.NewEditIndex].Cells[4].Text);
        btnSaveZone.Text = "Update";
    }
    protected void grdTerritoryData_RowEditing(object sender, GridViewEditEventArgs e)
    {
        TerritoryId = int.Parse(grdTerritoryData.Rows[e.NewEditIndex].Cells[1].Text);
        txtTerritoryCode.Text = grdTerritoryData.Rows[e.NewEditIndex].Cells[2].Text;
        txtTerritoryName.Text = grdTerritoryData.Rows[e.NewEditIndex].Cells[3].Text;
        chbIsTerritoryActive.Checked = bool.Parse(grdTerritoryData.Rows[e.NewEditIndex].Cells[4].Text);
        btnSaveTerritory.Text = "Update";
    }
    protected void DrpZone_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadTerritory(); 
    }
    protected void btnSaveTerritory_Click(object sender, EventArgs e)
    {
        if (btnSaveTerritory.Text == "Save")
        {
            string InsertValue = GControler.InsertHierarchy(int.Parse(DrpZone.SelectedValue.ToString()), txtTerritoryCode.Text, txtTerritoryName.Text, true, true, Constants.IntNullValue, int.Parse(this.Session["CompanyId"].ToString()), Constants.Territory, int.Parse(this.Session["UserId"].ToString()), SAMS.Common.Classes.Configuration.DistributorId, null);
        }
        else
        {
            GControler.UpdateHierarchy(TerritoryId, int.Parse(DrpZone.SelectedValue.ToString()), txtTerritoryCode.Text, txtTerritoryName.Text, true, chbIsTerritoryActive.Checked, Constants.IntNullValue, int.Parse(this.Session["CompanyId"].ToString()), Constants.Territory, int.Parse(this.Session["UserId"].ToString()), SAMS.Common.Classes.Configuration.DistributorId, null);
        }
        this.LoadTerritory();
        this.LoadTownTerritory();     
        txtTerritoryCode.Text = "";
        txtTerritoryName.Text = "";
        btnSaveTerritory.Text = "Save"; 
    }
    protected void btnSaveTown_Click(object sender, EventArgs e)
    {
        if (btnSaveTown.Text == "Save")
        {
            string InsertValue = GControler.InsertHierarchy(int.Parse(DrpTerritory.SelectedValue.ToString()), txtTownCode.Text, txtTownName.Text, true, true, Constants.IntNullValue, int.Parse(this.Session["CompanyId"].ToString()), Constants.Town, int.Parse(this.Session["UserId"].ToString()), SAMS.Common.Classes.Configuration.DistributorId, null);
        }
        else
        {
            GControler.UpdateHierarchy(TownId, int.Parse(DrpTerritory.SelectedValue.ToString()), txtTownCode.Text, txtTownName.Text, true, chbIsTownActive.Checked, Constants.IntNullValue, int.Parse(this.Session["CompanyId"].ToString()), Constants.Town, int.Parse(this.Session["UserId"].ToString()), SAMS.Common.Classes.Configuration.DistributorId, null);
        }
        this.LoadTown();
        txtTownCode.Text = "";
        txtTownName.Text = "";
        btnSaveTown.Text = "Save"; 
    }
    protected void DrpTerritory_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadTown();  
    }
    protected void grdTownData_RowEditing(object sender, GridViewEditEventArgs e)
    {
        TownId = int.Parse(grdTownData.Rows[e.NewEditIndex].Cells[1].Text);
        txtTownCode.Text = grdTownData.Rows[e.NewEditIndex].Cells[2].Text;
        txtTownName.Text = grdTownData.Rows[e.NewEditIndex].Cells[3].Text;
        chbIsTownActive.Checked = bool.Parse(grdTownData.Rows[e.NewEditIndex].Cells[4].Text);
        btnSaveTown.Text = "Update";
    }
    protected void drpRegionTerritory_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadTerritoryZone();
        this.LoadTerritory(); 
    }
    protected void DrpTownRegion_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadTownZone();
        this.LoadTownTerritory();
        this.LoadTown(); 
    }
    protected void DrpTownZone_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadTownTerritory();
        this.LoadTown(); 
    }
    protected void grdTownData_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdTownData.PageIndex = e.NewPageIndex;
        this.LoadTown(); 
    }
    protected void grdTerritoryData_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdTerritoryData.PageIndex = e.NewPageIndex;
        this.LoadTerritory(); 
    }
}
