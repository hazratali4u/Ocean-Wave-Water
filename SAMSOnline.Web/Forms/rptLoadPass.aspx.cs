using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using SAMS.BusinessLayer.Classes;
using SAMS.BusinessLayer.Reports;
using SAMS.Common.Classes;

public partial class Forms_rptLoadPass : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LoadPrincipal();
            LoadLocation();
            this.LoadOrderBooker();
            SAMS.Common.Classes.Configuration.SystemCurrentDateTime = (DateTime)this.Session["CurrentWorkDate"];
            this.txtFromDate.Text = SAMS.Common.Classes.Configuration.SystemCurrentDateTime.ToString("dd-MMM-yyyy");
           
        }
    }
    protected void LoadPrincipal()
    {
        try
        {
            SKUPriceDetailController PController = new SKUPriceDetailController();
            DataTable m_dt = PController.SelectDataPrice(Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, int.Parse(this.Session["UserId"].ToString()), Constants.IntNullValue, 0, DateTime.Parse(this.Session["CurrentWorkDate"].ToString()));
            this.drpPrincipal.Items.Add(new ListItem("All", Constants.IntNullValue.ToString()));
            clsWebFormUtil.FillDropDownList(this.drpPrincipal, m_dt, "Company_Id", "Company_Name");
        }
        catch (Exception ex)
        {
            ex.ToString();
        }
    }
    private void LoadOrderBooker()
    {
        DrpOrderBooker.Items.Clear();

        if (DrpLocation.Items.Count > 0)
        {

            Distributor_UserController mDController = new Distributor_UserController();
            DataTable m_dt = mDController.SelectSaleForceAssignedArea(int.Parse(DrpLocation.SelectedValue.ToString()), Constants.IntNullValue, int.Parse(this.Session["CompanyId"].ToString()));
            this.DrpOrderBooker.Items.Add(new ListItem("All", Constants.IntNullValue.ToString()));
            clsWebFormUtil.FillDropDownList(this.DrpOrderBooker, m_dt, 0, 3, true);
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
        catch (Exception ex)
        {
            ex.ToString();
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {

        try
        {
            if (rblReport.SelectedIndex == 0)
            {
                SAMS.BusinessLayer.Classes.DocumentPrintController DPrint = new SAMS.BusinessLayer.Classes.DocumentPrintController();
                DataTable dt = DPrint.SelectReportTitle(Convert.ToInt32(DrpLocation.SelectedValue));

                DataSet ds = null;
                ds = DPrint.LoadPass(int.Parse(drpPrincipal.SelectedValue.ToString()), DateTime.Parse(txtFromDate.Text + " 00:00:00"), int.Parse(DrpOrderBooker.SelectedValue.ToString()));
                CrpPrintDSR CrpReport = new CrpPrintDSR();
                CrpReport.SetDataSource(ds);
                CrpReport.Refresh();

                CrpReport.SetParameterValue("SalemanName", this.DrpOrderBooker.SelectedItem.Text.ToString());
                CrpReport.SetParameterValue("Date", this.txtFromDate.Text);
                CrpReport.SetParameterValue("CompanyName", dt.Rows[0]["COMPANY_NAME"].ToString());

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
                DataTable dt = DPrint.SelectReportTitle(Convert.ToInt32(DrpLocation.SelectedValue));

                DataSet ds = null;
                ds = DPrint.LoadPass(int.Parse(drpPrincipal.SelectedValue.ToString()), DateTime.Parse(txtFromDate.Text + " 00:00:00"), Constants.IntNullValue);
                CrpLoadPassDM CrpReport = new CrpLoadPassDM();
                CrpReport.SetDataSource(ds);
                CrpReport.Refresh();

                CrpReport.SetParameterValue("Principal", this.drpPrincipal.SelectedItem.Text.ToString());
                CrpReport.SetParameterValue("Date", this.txtFromDate.Text);
                CrpReport.SetParameterValue("CompanyName", dt.Rows[0]["COMPANY_NAME"].ToString());

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
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            if (rblReport.SelectedIndex == 0)
            {
                SAMS.BusinessLayer.Classes.DocumentPrintController DPrint = new SAMS.BusinessLayer.Classes.DocumentPrintController();
                DataSet ds = null;

                ds = DPrint.LoadPass(int.Parse(drpPrincipal.SelectedValue.ToString()), DateTime.Parse(txtFromDate.Text), int.Parse(DrpOrderBooker.SelectedValue.ToString()));
                CrpLoadPass CrpReport = new CrpLoadPass();
                CrpReport.SetDataSource(ds);
                CrpReport.Refresh();

                CrpReport.SetParameterValue("DeliveryManName", this.DrpOrderBooker.SelectedItem.Text.ToString());
                CrpReport.SetParameterValue("Date", this.txtFromDate.Text);

                this.Session.Add("CrpReport", CrpReport);
                this.Session.Add("ReportType", 1);
                string url = "'Default.aspx'";
                string script = "<script language='JavaScript' type='text/javascript'> window.open(" + url + ",\"Link\",\"toolbar=0,location=0,directories=0,status=0,menubar=0,scrollbars=1,resizable=1,width=800,height=600,left=10,top=10\");</script>";
                Type cstype = this.GetType();
                ClientScriptManager cs = Page.ClientScript;
                cs.RegisterStartupScript(cstype, "OpenWindow", script);
            }
            else
            {
                SAMS.BusinessLayer.Classes.DocumentPrintController DPrint = new SAMS.BusinessLayer.Classes.DocumentPrintController();
                DataSet ds = null;

                ds = DPrint.LoadPass(int.Parse(drpPrincipal.SelectedValue.ToString()), DateTime.Parse(txtFromDate.Text), int.Parse(drpPrincipal.SelectedValue.ToString()));
                CrpLoadPassDM CrpReport = new CrpLoadPassDM();
                CrpReport.SetDataSource(ds);
                CrpReport.Refresh();

                CrpReport.SetParameterValue("Principal", this.DrpOrderBooker.SelectedItem.Text.ToString());
                CrpReport.SetParameterValue("Date", this.txtFromDate.Text);

                this.Session.Add("CrpReport", CrpReport);
                this.Session.Add("ReportType", 1);
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
    protected void DrpLocation_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadOrderBooker();
    }

    protected void rblReport_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rblReport.SelectedIndex == 0)
        {
            DrpOrderBooker.Visible = true;
            lblSalesMan.Visible = true;
        }
        else
        {
            DrpOrderBooker.Visible = false;
            lblSalesMan.Visible = false;
        }
    }
}
