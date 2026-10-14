using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using SAMS.BusinessLayer.Classes;
using SAMS.BusinessLayer.Reports;
using SAMS.Common.Classes;

public partial class Forms_RptPhysicalStockTaking : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LoadPrincipal();
            LoadLocation();
            this.txtFromDate.Text = Convert.ToDateTime(Session["CurrentWorkDate"]).ToString("dd-MMM-yyyy");           
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        try
        {
            if (RblType.SelectedIndex == 0)
            {
                SAMS.BusinessLayer.Classes.DocumentPrintController DPrint = new SAMS.BusinessLayer.Classes.DocumentPrintController();

                string FromDate = null;

                CrpPhysicalStockTaking CrpReport = new CrpPhysicalStockTaking();
                DataSet ds = null;

                DateTime parsed_date_fromdate = DateTime.Parse(this.txtFromDate.Text);

                FromDate = parsed_date_fromdate.ToShortDateString();


                ds = DPrint.PhysicalStockTaking(int.Parse(drpPrincipal.SelectedValue.ToString()), int.Parse(DrpLocation.SelectedValue.ToString()), Convert.ToDateTime(FromDate + " 00:00:00"));

                CrpReport.SetDataSource(ds);
                CrpReport.Refresh();

                CrpReport.SetParameterValue("Principal", this.drpPrincipal.SelectedItem.Text.ToString());
                CrpReport.SetParameterValue("Branch", this.DrpLocation.SelectedItem.Text.ToString());
                CrpReport.SetParameterValue("FromDate", this.txtFromDate.Text);


                this.Session.Add("CrpReport", CrpReport);
                this.Session.Add("ReportType", 0);
                string url = "'Default.aspx'";
                string script = "<script language='JavaScript' type='text/javascript'> window.open(" + url + ",\"Link\",\"toolbar=0,location=0,directories=0,status=0,menubar=0,scrollbars=1,resizable=1,width=800,height=600,left=10,top=10\");</script>";
                Type cstype = this.GetType();
                ClientScriptManager cs = Page.ClientScript;
                cs.RegisterStartupScript(cstype, "OpenWindow", script);
            }
            else
            {
                SAMS.BusinessLayer.Classes.DocumentPrintController DPrint = new SAMS.BusinessLayer.Classes.DocumentPrintController();

                string FromDate = null;

                RptPhysicalStockSummary CrpReport = new RptPhysicalStockSummary();
                DataSet ds = null;

                DateTime parsed_date_fromdate = DateTime.Parse(this.txtFromDate.Text);

                FromDate = parsed_date_fromdate.ToShortDateString();


                ds = DPrint.PhysicalStockTakingValueWise(int.Parse(drpPrincipal.SelectedValue.ToString()), int.Parse(DrpLocation.SelectedValue.ToString()), Convert.ToDateTime(FromDate + " 00:00:00"), int.Parse(this.Session["UserId"].ToString()));

                CrpReport.SetDataSource(ds);
                CrpReport.Refresh();

              
                CrpReport.SetParameterValue("FromDate", this.txtFromDate.Text);


                this.Session.Add("CrpReport", CrpReport);
                this.Session.Add("ReportType", 0);
                string url = "'Default.aspx'";
                string script = "<script language='JavaScript' type='text/javascript'> window.open(" + url + ",\"Link\",\"toolbar=0,location=0,directories=0,status=0,menubar=0,scrollbars=1,resizable=1,width=800,height=600,left=10,top=10\");</script>";
                Type cstype = this.GetType();
                ClientScriptManager cs = Page.ClientScript;
                cs.RegisterStartupScript(cstype, "OpenWindow", script);
            }
        }
        catch (Exception ex)
        {
            ex.ToString();
        }
    }
    protected void LoadPrincipal()
    {
        try
        {
            drpPrincipal.Items.Clear();
   
            if (RblType.SelectedIndex == 0)
            {
                SKUPriceDetailController PController = new SKUPriceDetailController();
                DataTable m_dt = PController.SelectDataPrice(Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, int.Parse(this.Session["UserId"].ToString()), Constants.IntNullValue, 0, DateTime.Parse(this.Session["CurrentWorkDate"].ToString()));
                //this.drpPrincipal.Items.Add(new ListItem("All", "0"));
                clsWebFormUtil.FillDropDownList(this.drpPrincipal, m_dt, "Company_Id", "Company_Name");
            }
            else
            {
                SKUPriceDetailController PController = new SKUPriceDetailController();
                DataTable m_dt = PController.SelectDataPrice(Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, int.Parse(this.Session["UserId"].ToString()), Constants.IntNullValue, 0, DateTime.Parse(this.Session["CurrentWorkDate"].ToString()));
                this.drpPrincipal.Items.Add(new ListItem("All", Constants.IntNullValue.ToString()));
                clsWebFormUtil.FillDropDownList(this.drpPrincipal, m_dt, "Company_Id", "Company_Name");
            }
        }
        catch (Exception ex)
        {
            ex.ToString();
        }
    }
    protected void LoadLocation()
    {
        try
        {
            DrpLocation.Items.Clear();
   
            if (RblType.SelectedIndex == 0)
            {
                DistributorController DController = new DistributorController();
                DataTable dt = DController.SelectDistributorInfo(Constants.IntNullValue, int.Parse(this.Session["UserId"].ToString()), int.Parse(this.Session["CompanyId"].ToString()));
                clsWebFormUtil.FillDropDownList(this.DrpLocation, dt, "DISTRIBUTOR_ID", "DISTRIBUTOR_NAME");

            }
            else
            {
                DistributorController DController = new DistributorController();
                DataTable dt = DController.SelectDistributorInfo(Constants.IntNullValue, int.Parse(this.Session["UserId"].ToString()), int.Parse(this.Session["CompanyId"].ToString()));
                this.DrpLocation.Items.Add(new ListItem("All", Constants.IntNullValue.ToString()));
                clsWebFormUtil.FillDropDownList(this.DrpLocation, dt, "DISTRIBUTOR_ID", "DISTRIBUTOR_NAME");
            }
            
        }
        catch (Exception ex)
        {
            ex.ToString();
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            SAMS.BusinessLayer.Classes.DocumentPrintController DPrint = new SAMS.BusinessLayer.Classes.DocumentPrintController();

            string FromDate = null;

            CrpPhysicalStockTaking CrpReport = new CrpPhysicalStockTaking();
            DataSet ds = null;

            DateTime parsed_date_fromdate = DateTime.Parse(this.txtFromDate.Text);

            FromDate = parsed_date_fromdate.ToShortDateString();


            ds = DPrint.PhysicalStockTaking(int.Parse(drpPrincipal.SelectedValue.ToString()), int.Parse(DrpLocation.SelectedValue.ToString()), Convert.ToDateTime(FromDate + " 00:00:00"));

            CrpReport.SetDataSource(ds);
            CrpReport.Refresh();

            CrpReport.SetParameterValue("Principal", this.drpPrincipal.SelectedItem.Text.ToString());
            CrpReport.SetParameterValue("Branch", this.DrpLocation.SelectedItem.Text.ToString());
            CrpReport.SetParameterValue("FromDate", this.txtFromDate.Text);


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
    protected void RblType_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadPrincipal();
        LoadLocation();
    }
}
