using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using SAMS.BusinessLayer.Classes;
using SAMS.BusinessLayer.Reports;
using SAMS.Common.Classes;

public partial class Forms_RptDailySaleUpdate : System.Web.UI.Page
{
    GeoHierarchyController GControler = new GeoHierarchyController();

    protected void LoadRegion()
    {
        DataTable dt = GControler.SelectGeoHierarchy(Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, null, null, true, Constants.IntNullValue, Constants.Region, Constants.IntNullValue, Constants.DateNullValue, Constants.DateNullValue, int.Parse(this.Session["CompanyId"].ToString()));
        DrpRegion.Items.Add(new ListItem("All", Constants.IntNullValue.ToString()));       
        clsWebFormUtil.FillDropDownList(this.DrpRegion, dt, 0, 4);
        
    }
    protected void LoadZone()
    {
        DrpZone.Items.Clear();

        if (DrpRegion.Items.Count > 0)
        {
            DataTable dt = GControler.SelectGeoHierarchy(Constants.IntNullValue, Constants.IntNullValue, int.Parse(DrpRegion.SelectedValue.ToString()), null, null, true, Constants.IntNullValue, Constants.Zone, Constants.IntNullValue, Constants.DateNullValue, Constants.DateNullValue, int.Parse(this.Session["CompanyId"].ToString()));
            DrpZone.Items.Add(new ListItem("All", Constants.IntNullValue.ToString()));
            clsWebFormUtil.FillDropDownList(this.DrpZone, dt, 0, 4);
        }
    }
    private void LoadTerritory()
    {
        DrpTerritory.Items.Clear();
   
        if (DrpZone.Items.Count > 0)
        {
            DataTable dt = GControler.SelectGeoHierarchy(Constants.IntNullValue, Constants.IntNullValue, int.Parse(DrpZone.SelectedValue.ToString()), null, null, true, Constants.IntNullValue, Constants.Territory, Constants.IntNullValue, Constants.DateNullValue, Constants.DateNullValue, int.Parse(this.Session["CompanyId"].ToString()));
            DrpTerritory.Items.Add(new ListItem("All", Constants.IntNullValue.ToString()));
            clsWebFormUtil.FillDropDownList(this.DrpTerritory, dt, 0, 4);

        }
    }
    private void LoadPrincipal()
    {
        SKUPriceDetailController PController = new SKUPriceDetailController();
        DataTable m_dt = PController.SelectDataPrice(Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, int.Parse(this.Session["UserId"].ToString()), Constants.IntNullValue, 0, DateTime.Parse(this.Session["CurrentWorkDate"].ToString()));
        clsWebFormUtil.FillDropDownList(this.drpPrincipal, m_dt, 0, 1, true);
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.LoadPrincipal();
            this.LoadRegion();
            this.LoadZone();
            this.LoadTerritory();
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        DocumentPrintController DPrint = new DocumentPrintController();

        DataControl dc = new DataControl();
        DataSet ds = DPrint.SelectDailyUpdateSales(int.Parse(drpPrincipal.SelectedValue.ToString()), Constants.IntNullValue,
            DateTime.Parse(txtDate.Text + " 23:59:59"),int.Parse(DrpRegion.SelectedValue.ToString()),int.Parse(DrpZone.SelectedValue.ToString()),int.Parse(DrpTerritory.SelectedValue.ToString()),RbUnitType.SelectedIndex);

        CrpDSUView CrpReport = new CrpDSUView();
        CrpReport.SetDataSource(ds);
        CrpReport.Refresh();

        CrpReport.SetParameterValue("Principal", drpPrincipal.SelectedItem.Text);
        CrpReport.SetParameterValue("Location", "All");
        CrpReport.SetParameterValue("Date", DateTime.Parse(txtDate.Text));
       


        this.Session.Add("CrpReport", CrpReport);
        this.Session.Add("ReportType", 0);
        string url = "'Default.aspx'";
        string script = "<script language='JavaScript' type='text/javascript'> window.open(" + url + ",\"Link\",\"toolbar=0,location=0,directories=0,status=0,menubar=0,scrollbars=1,resizable=1,width=800,height=600,left=10,top=10\");</script>";
        Type cstype = this.GetType();
        ClientScriptManager cs = Page.ClientScript;
        cs.RegisterStartupScript(cstype, "OpenWindow", script);

    }
    protected void DrpRegion_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadZone();
        this.LoadTerritory(); 
    }
    protected void DrpZone_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadTerritory();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        DocumentPrintController DPrint = new DocumentPrintController();

        DataControl dc = new DataControl();
        DataSet ds = DPrint.SelectDailyUpdateSales(int.Parse(drpPrincipal.SelectedValue.ToString()), Constants.IntNullValue,
            DateTime.Parse(txtDate.Text + " 23:59:59"), int.Parse(DrpRegion.SelectedValue.ToString()), int.Parse(DrpZone.SelectedValue.ToString()), int.Parse(DrpTerritory.SelectedValue.ToString()), RbUnitType.SelectedIndex);

        CrpDSUView CrpReport = new CrpDSUView();
        CrpReport.SetDataSource(ds);
        CrpReport.Refresh();

        CrpReport.SetParameterValue("Principal", drpPrincipal.SelectedItem.Text);
        CrpReport.SetParameterValue("Location", "All");
        CrpReport.SetParameterValue("Date", DateTime.Parse(txtDate.Text));



        this.Session.Add("CrpReport", CrpReport);
        this.Session.Add("ReportType", 1);
        string url = "'Default.aspx'";
        string script = "<script language='JavaScript' type='text/javascript'> window.open(" + url + ",\"Link\",\"toolbar=0,location=0,directories=0,status=0,menubar=0,scrollbars=1,resizable=1,width=800,height=600,left=10,top=10\");</script>";
        Type cstype = this.GetType();
        ClientScriptManager cs = Page.ClientScript;
        cs.RegisterStartupScript(cstype, "OpenWindow", script);
    }
}
