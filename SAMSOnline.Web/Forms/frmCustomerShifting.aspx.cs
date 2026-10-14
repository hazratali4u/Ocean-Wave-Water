using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using SAMS.BusinessLayer.Classes;
using SAMS.Common.Classes;
    
public partial class Forms_frmCustomerShifting : System.Web.UI.Page
{
    private void LoadDistributor()
    {
        DistributorController DController = new DistributorController();
        DataTable dt = DController.SelectDistributorInfo(Constants.IntNullValue, int.Parse(this.Session["UserId"].ToString()), int.Parse(this.Session["CompanyId"].ToString()));
        clsWebFormUtil.FillDropDownList(this.drpfromDistributor, dt, 0, 2, true);
        clsWebFormUtil.FillDropDownList(this.DrptoDistributor, dt, 0, 2, true);
    }
    private void LoadfromArea()
    {
        if (drpfromDistributor.Items.Count > 0)
        {
            DistributorAreaController mController = new DistributorAreaController();
            DataTable dt = mController.SelectDist_Area(Constants.LongNullValue, Constants.DateNullValue, Constants.DateNullValue, int.Parse(drpfromDistributor.SelectedValue.ToString()), Constants.IntNullValue, null, null);
            clsWebFormUtil.FillDropDownList(DrpfromRoute, dt, 0, 6, true);
        }
        else
        {
            DrpfromRoute.Items.Clear();
        }
    }
    private void LoadtoArea()
    {
        if (DrptoDistributor.Items.Count > 0)
        {
            DistributorAreaController mController = new DistributorAreaController();
            DataTable dt = mController.SelectDist_Area(Constants.LongNullValue, Constants.DateNullValue, Constants.DateNullValue, int.Parse(DrptoDistributor.SelectedValue.ToString()), Constants.IntNullValue, null, null);
            clsWebFormUtil.FillDropDownList(drptoRoute, dt, 0, 6, true);
        }
        else
        {
            drptoRoute.Items.Clear();
        }
    }
    private void LoadRoute()
    {
        if (drpfromDistributor.Items.Count > 0 && DrpfromRoute.Items.Count > 0)
        {
            DistributorRouteController gController = new DistributorRouteController();
            DataTable dt = gController.SelectDistributorRoute(Constants.LongNullValue, int.Parse(drpfromDistributor.SelectedValue.ToString()), Constants.IntNullValue , long.Parse(DrpfromRoute.SelectedValue.ToString()));
            clsWebFormUtil.FillListBox(ChbAreaList, dt, 0, 8, true);

        }
        else
        {
            ChbAreaList.Items.Clear();
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.LoadDistributor();
            this.LoadfromArea();
            this.LoadtoArea();
            this.LoadRoute();
        }
    }
    protected void drpfromDistributor_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadfromArea();
        this.LoadRoute();
    }
    protected void DrptoDistributor_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadtoArea(); 
    }
    protected void DrpfromRoute_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadRoute();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        CustomerDataController cd = new CustomerDataController();
        foreach (ListItem item in ChbAreaList.Items)
        {
            if (item.Selected == true)
            {
                cd.CustomerShifting(int.Parse(drpfromDistributor.SelectedValue.ToString()), int.Parse(DrptoDistributor.SelectedValue.ToString()),
                    int.Parse(DrpfromRoute.SelectedValue.ToString()), int.Parse(drptoRoute.SelectedValue.ToString()), int.Parse(item.Value)); 
            }
        }
        this.LoadRoute();
    }

}
