using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using SAMS.BusinessLayer.Classes;
using SAMS.Common.Classes;

public partial class Forms_RptCustomerInvoiceReport : System.Web.UI.Page
{
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
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.LoadPrincipal();
            this.LoadDistributor();
            this.LoadSKUDetail();
            this.txtStartDate.Text = System.DateTime.Today.ToString("MMM-yyyy");
        }
    }
    protected void btnFilter_Click(object sender, EventArgs e)
    {
        CustomerDataController mController = new CustomerDataController();
        DataTable dt = mController.RptSelectCustomer(int.Parse(this.Session["UserId"].ToString()), int.Parse(drpDistributor.SelectedValue.ToString()), ddSearchType.SelectedValue.ToString(), txtSeach.Text);
        this.Grid_users.DataSource = dt;
        this.Grid_users.DataBind();
    }
    protected void BtnViewPdf_Click(object sender, EventArgs e)
    {
        DateTime dtFrom = new DateTime();
        DateTime dtTo = new DateTime();
        DateTime dtMonth = DateTime.Parse(txtStartDate.Text);
        dtFrom = new DateTime(dtMonth.Year, dtMonth.Month, 1);

        dtTo = new DateTime(dtMonth.Year, dtMonth.Month, 1);
        dtTo = dtTo.AddMonths(1).AddDays(-1);

        string CustomerId = "0";
        string DistributorId = "0";

        if (RblCustomer.SelectedIndex == 0)
        {            
            DocumentPrintController mDocumentPrntControl = new DocumentPrintController();

            DataTable dt = mDocumentPrntControl.SelectReportTitle(int.Parse(drpDistributor.SelectedValue.ToString()));
            DataSet ds = mDocumentPrntControl.SelectBillCustomerDetail(int.Parse(DrpPrincipal.SelectedValue.ToString()), CustomerId, Convert.ToInt32(ddlSKU.SelectedValue), drpDistributor.SelectedValue.ToString(), dtFrom, dtTo, 0);
            SAMS.BusinessLayer.Reports.CrpCustomerMonthlyReport CrpReport = new SAMS.BusinessLayer.Reports.CrpCustomerMonthlyReport();
            CrpReport.SetDataSource(ds);
            CrpReport.Refresh();

            CrpReport.SetParameterValue("PRINCIPAL", dt.Rows[0]["ADDRESS1"].ToString());
            CrpReport.SetParameterValue("Month", txtStartDate.Text);
            CrpReport.SetParameterValue("CompanyName", dt.Rows[0]["COMPANY_NAME"].ToString());
            CrpReport.SetParameterValue("NTN", dt.Rows[0]["NTN_NO"].ToString());
            CrpReport.SetParameterValue("Designation1", dt.Rows[0]["DESIGNATION1"].ToString());
            CrpReport.SetParameterValue("Designation2", dt.Rows[0]["DESIGNATION2"].ToString());
            CrpReport.SetParameterValue("Note", dt.Rows[0]["NOTE"].ToString());

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

            foreach (GridViewRow dr in Grid_users.Rows)
            {
                CheckBox chbSelect = (CheckBox)(dr.Cells[0].FindControl("ChbCustomer"));
                if (chbSelect.Checked)
                {
                    CustomerId = CustomerId + "," + dr.Cells[1].Text;
                    DistributorId = DistributorId + "," + dr.Cells[2].Text;
                }
            }

            DocumentPrintController mDocumentPrntControl = new DocumentPrintController();
            DataTable dt = mDocumentPrntControl.SelectReportTitle(int.Parse(drpDistributor.SelectedValue.ToString()));

            DataSet ds = mDocumentPrntControl.SelectBillCustomerDetail(int.Parse(DrpPrincipal.SelectedValue.ToString()), CustomerId, Convert.ToInt32(ddlSKU.SelectedValue), DistributorId, dtFrom, dtTo, 1);
            SAMS.BusinessLayer.Reports.CrpCustomerMonthlyReport CrpReport = new SAMS.BusinessLayer.Reports.CrpCustomerMonthlyReport();
            CrpReport.SetDataSource(ds);
            CrpReport.Refresh();

            CrpReport.SetParameterValue("PRINCIPAL", DrpPrincipal.SelectedItem.Text);
            CrpReport.SetParameterValue("Month", txtStartDate.Text);
            CrpReport.SetParameterValue("CompanyName", dt.Rows[0]["COMPANY_NAME"].ToString());
            CrpReport.SetParameterValue("NTN", dt.Rows[0]["NTN_NO"].ToString());
            CrpReport.SetParameterValue("Designation1", dt.Rows[0]["DESIGNATION1"].ToString());
            CrpReport.SetParameterValue("Designation2", dt.Rows[0]["DESIGNATION2"].ToString());
            CrpReport.SetParameterValue("Note", dt.Rows[0]["NOTE"].ToString());

            this.Session.Add("CrpReport", CrpReport);
            this.Session.Add("ReportType", 0);
            string url = "'Default.aspx'";
            string script = "<script language='JavaScript' type='text/javascript'> window.open(" + url + ",\"Link\",\"toolbar=0,location=0,directories=0,status=0,menubar=0,scrollbars=1,resizable=1,width=800,height=600,left=10,top=10\");</script>";
            Type cstype = this.GetType();
            ClientScriptManager cs = Page.ClientScript;
            cs.RegisterStartupScript(cstype, "OpenWindow", script);
        }
    }
    protected void btnViewExcel_Click(object sender, EventArgs e)
    {
        DateTime dtFrom = new DateTime();
        DateTime dtTo = new DateTime();
        DateTime dtMonth = DateTime.Parse(txtStartDate.Text);
        dtFrom = new DateTime(dtMonth.Year, dtMonth.Month, 1);

        dtTo = new DateTime(dtMonth.Year, dtMonth.Month, 1);
        dtTo = dtTo.AddMonths(1).AddDays(-1);

        string CustomerId = "0";
        string DistributorId = "0";
        DataSet ds;
        foreach (GridViewRow dr in Grid_users.Rows)
        {
            CheckBox chbSelect = (CheckBox)(dr.Cells[0].FindControl("ChbCustomer"));
            if (chbSelect.Checked)
            {
                CustomerId = CustomerId + "," + dr.Cells[1].Text;
                DistributorId = DistributorId + "," + dr.Cells[2].Text;
            }
        }

        DataSetToExcel dsexcel = new DataSetToExcel();

        DocumentPrintController mController = new DocumentPrintController();
        if (RblCustomer.SelectedIndex == 0)
        {
            ds = mController.SelectBillCustomerDetail(int.Parse(DrpPrincipal.SelectedValue.ToString()), CustomerId, Convert.ToInt32(ddlSKU.SelectedValue), drpDistributor.SelectedValue.ToString(), dtFrom, dtTo, 0);
        }
        else
        {
            ds = mController.SelectBillCustomerDetail(int.Parse(DrpPrincipal.SelectedValue.ToString()), CustomerId, Convert.ToInt32(ddlSKU.SelectedValue), DistributorId, dtFrom, dtTo, 1);
        }
        string path = SAMS.Common.Classes.Configuration.GetAppInstallationPath() + "\\CustomerBillWiseSale.xls";

        DataSetToExcel.exportToExcel(ds, path, "RptBillCustomerReport");

        System.IO.FileInfo file = new System.IO.FileInfo(path);

        if (file.Exists)
        {

            Response.Clear();

            Response.AddHeader("Content-Disposition", "attachment; filename=" + file.Name);

            Response.AddHeader("Content-Length", file.Length.ToString());

            Response.ContentType = "application/octet-stream";

            Response.WriteFile(file.FullName);

            Response.End();

        }

        else
        {

            Response.Write("This file does not exist.");

        }
    }    
    private void LoadSKUDetail()
    {
        SKUPriceDetailController PController = new SKUPriceDetailController();
        if (DrpPrincipal.Items.Count > 0)
        {
            DataTable Dtsku_Price = PController.SelectDataPrice(int.Parse(DrpPrincipal.SelectedValue), Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, int.Parse(drpDistributor.SelectedValue), int.Parse(this.Session["UserId"].ToString()), Constants.IntNullValue, 1, DateTime.Parse(this.Session["CurrentWorkDate"].ToString()));
            ddlSKU.Items.Add(new ListItem("All", Constants.IntNullValue.ToString()));
            clsWebFormUtil.FillDropDownList(this.ddlSKU, Dtsku_Price, "SKU_ID", "SkuDetail");
        }
    }

    protected void RblCustomer_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RblCustomer.SelectedIndex == 0)
        {
            btnFilter.Enabled = false;
            Grid_users.DataSource = null;
            Grid_users.DataBind();
        }
        else
        {
            btnFilter.Enabled = true;
        }
    }
}
