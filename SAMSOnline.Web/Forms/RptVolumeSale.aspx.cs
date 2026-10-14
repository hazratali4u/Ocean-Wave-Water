using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using SAMS.BusinessLayer.Classes;
using SAMS.BusinessLayer.Reports;
using SAMS.Common.Classes; 

public partial class Forms_RptVolumeSale : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!Page.IsPostBack)
        {
            LoadPrincipal();
            LoadLocation();
            LoadSalesForce();
            DateTime dt = (DateTime)this.Session["CurrentWorkDate"]; 
            this.txtDate.Text = dt.ToString("dd-MMM-yyyy");
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        try
        {
            
            SAMS.BusinessLayer.Classes.DocumentPrintController DPrint = new SAMS.BusinessLayer.Classes.DocumentPrintController();
           
            string date = null;

            CrpVolumeSalesDetail CrpReport = new CrpVolumeSalesDetail();
          
            DataSet ds = null;

            DateTime parsed_date = DateTime.Parse(this.txtDate.Text);
            date = parsed_date.ToShortDateString();
            
            ds = DPrint.SelectVolumeSale(int.Parse(drpPrincipal.SelectedValue.ToString()), int.Parse(DrpLocation.SelectedValue.ToString()), Convert.ToDateTime(date + " 00:00:00") ,Convert.ToInt32(drpSaleForce.SelectedValue.ToString()));
            CrpReport.SetDataSource(ds);
            CrpReport.Refresh();

            CrpReport.SetParameterValue("BranchName",this.DrpLocation.SelectedItem.Text.ToString());
            date  = this.txtDate.Text;
            CrpReport.SetParameterValue("Date", date);
            CrpReport.SetParameterValue("TargetFor",this.drpSaleForce.SelectedItem.Text.ToString());

            this.Session.Add("CrpReport", CrpReport);
            this.Session.Add("ReportType", 0);
            string url = "'Default.aspx'";
            string script = "<script language='JavaScript' type='text/javascript'> window.open(" + url + ",\"Link\",\"toolbar=0,location=0,directories=0,status=0,menubar=0,scrollbars=1,resizable=1,width=800,height=600,left=10,top=10\");</script>";
            Type cstype = this.GetType();
            ClientScriptManager cs = Page.ClientScript;
            cs.RegisterStartupScript(cstype, "OpenWindow", script);
        }
        catch(Exception ex)
        {
            ex.ToString();
        }
    }
    protected void LoadPrincipal()
    {
        try
        {
            SKUPriceDetailController PController = new SKUPriceDetailController();
            DataTable m_dt = PController.SelectDataPrice(Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, int.Parse(this.Session["UserId"].ToString()), Constants.IntNullValue, 0, DateTime.Parse(this.Session["CurrentWorkDate"].ToString()));
            this.drpPrincipal.DataSource = m_dt;
            this.drpPrincipal.DataTextField = "Company_Name";
            this.drpPrincipal.DataValueField = "Company_Id";
            this.drpPrincipal.DataBind();
        }
        catch(Exception ex)
        {
            ex.ToString();
        }
    }
    protected void LoadLocation()
    {
        try
        {
            DistributorController DController = new DistributorController();
            DataTable dt = DController.SelectDistributorInfo(Constants.IntNullValue, int.Parse(this.Session["UserId"].ToString()), int.Parse(this.Session["CompanyId"].ToString()));
            this.DrpLocation.DataSource = dt;
            this.DrpLocation.DataTextField = "DISTRIBUTOR_NAME";
            this.DrpLocation.DataValueField = "DISTRIBUTOR_ID";
            this.DrpLocation.DataBind();
        }
        catch(Exception ex)
        {
            ex.ToString();
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            SAMS.BusinessLayer.Classes.DocumentPrintController DPrint = new SAMS.BusinessLayer.Classes.DocumentPrintController();

            string date = null;

            CrpVolumeSalesDetail CrpReport = new CrpVolumeSalesDetail();
            DataSet ds = null;

            DateTime parsed_date = DateTime.Parse(this.txtDate.Text);
            date = parsed_date.ToShortDateString();
            ds = DPrint.SelectVolumeSale(int.Parse(drpPrincipal.SelectedValue.ToString()), int.Parse(DrpLocation.SelectedValue.ToString()), Convert.ToDateTime(date + " 00:00:00"), Convert.ToInt32(this.drpSaleForce.SelectedValue.ToString()));
            CrpReport.SetDataSource(ds);
            CrpReport.Refresh();

            CrpReport.SetParameterValue("BranchName", this.DrpLocation.SelectedItem.Text.ToString());
            date = this.txtDate.Text;

            CrpReport.SetParameterValue("Date", date);
            CrpReport.SetParameterValue("TargetFor", this.drpSaleForce.SelectedItem.Text.ToString());

            this.Session.Add("CrpReport", CrpReport);
            this.Session.Add("ReportType", 1);
            string url = "'Default.aspx'";
            string script = "<script language='JavaScript' type='text/javascript'> window.open(" + url + ",\"Link\",\"toolbar=0,location=0,directories=0,status=0,menubar=0,scrollbars=1,resizable=1,width=800,height=600,left=10,top=10\");</script>";
            Type cstype = this.GetType();
            ClientScriptManager cs = Page.ClientScript;
            cs.RegisterStartupScript(cstype, "OpenWindow", script);
        }
        catch (Exception ex)
        {
            ex.ToString();
        }
    }
    protected void LoadSalesForce()
    {
        Distributor_UserController Du = new Distributor_UserController();
        DataTable dt = Du.SelectDistributorUser(Constants.SALES_FORCE_DELIVERYMAN, int.Parse(DrpLocation.SelectedValue.ToString()), int.Parse(this.Session["CompanyId"].ToString()));        

        if(dt.Rows.Count > 0)
        {          
          this.drpSaleForce.Items.Add(new ListItem("All", "0"));
          clsWebFormUtil.FillDropDownList(drpSaleForce, dt, 0, 6);
        }
    }
    protected void DrpLocation_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.drpSaleForce.Items.Clear();
        LoadSalesForce();
    }
}