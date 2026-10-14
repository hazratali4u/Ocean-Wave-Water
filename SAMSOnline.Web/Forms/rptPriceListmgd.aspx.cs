using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using SAMS.BusinessLayer.Classes;
using SAMS.BusinessLayer.Reports;
using SAMS.Common.Classes;

public partial class Forms_rptPriceListmgd : System.Web.UI.Page
{
    private void LoadDistributor()
    {
        DistributorController DController = new DistributorController();
        DataTable dt = DController.SelectDistributorInfo(Constants.IntNullValue, int.Parse(this.Session["UserId"].ToString()), int.Parse(this.Session["CompanyId"].ToString()));
        clsWebFormUtil.FillDropDownList(this.DrpDistributor, dt, 0, 2, true);
    }
    protected void LoadCatagory()
    {
        SkuHierarchyController Hierarchy = new SkuHierarchyController();
        DataTable dtCatagory = Hierarchy.SelectSkuHierarchyView(5, int.Parse(this.Session["CompanyId"].ToString()));
        DataView dv = new DataView(dtCatagory);
        dv.RowFilter = "Company_id = " + Convert.ToInt32(drpPrincipal.SelectedValue.ToString());
        dtCatagory = dv.ToTable();
        this.DrpCatagory.Items.Add(new ListItem("All", Constants.IntNullValue.ToString()));
        clsWebFormUtil.FillDropDownList(this.DrpCatagory, dtCatagory, "Category_Id", "Category_Name");
    }
    protected void LoadPrincipal()
    {
        try
        {
            SKUPriceDetailController PController = new SKUPriceDetailController();
            DataTable m_dt = PController.SelectDataPrice(Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, int.Parse(this.Session["UserId"].ToString()), Constants.IntNullValue, 0, DateTime.Parse(this.Session["CurrentWorkDate"].ToString()));
            //this.drpPrincipal.Items.Add(new ListItem("All", "0"));
            clsWebFormUtil.FillDropDownList(this.drpPrincipal, m_dt, "Company_Id", "Company_Name");
        }
        catch (Exception ex)
        {
            ex.ToString();
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.LoadDistributor();
            LoadPrincipal();
            LoadCatagory();
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        try
        {
            SAMS.BusinessLayer.Classes.DocumentPrintController DPrint = new SAMS.BusinessLayer.Classes.DocumentPrintController();

            CrpPriceListmgd CrpReport = new CrpPriceListmgd();
            DataSet ds = null;
            DataTable dt = DPrint.SelectReportTitle(int.Parse(DrpDistributor.SelectedValue.ToString()));
            ds = DPrint.PriceList(int.Parse(drpPrincipal.SelectedValue.ToString()), int.Parse(this.DrpCatagory.SelectedValue.ToString()), int.Parse(DrpDistributor.SelectedValue.ToString()));

            CrpReport.SetDataSource(ds);
            CrpReport.Refresh();

            CrpReport.SetParameterValue("Principal", this.drpPrincipal.SelectedItem.Text.ToString());
            CrpReport.SetParameterValue("Branch", this.DrpDistributor.SelectedItem.Text.ToString());
            CrpReport.SetParameterValue("CompanyName", dt.Rows[0]["COMPANY_NAME"].ToString());

            //CrpReport.SetParameterValue("FromDate", this.txtFromDate.Text);
            //CrpReport.SetParameterValue("ToDate", this.txtToDate.Text);

            this.Session.Add("CrpReport", CrpReport);
            this.Session.Add("ReportType", 0);
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
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            SAMS.BusinessLayer.Classes.DocumentPrintController DPrint = new SAMS.BusinessLayer.Classes.DocumentPrintController();

            CrpPriceList CrpReport = new CrpPriceList();
            DataSet ds = null;
            DataTable dt = DPrint.SelectReportTitle(int.Parse(DrpDistributor.SelectedValue.ToString()));
            ds = DPrint.PriceList(int.Parse(drpPrincipal.SelectedValue.ToString()), int.Parse(this.DrpCatagory.SelectedValue.ToString()), int.Parse(DrpDistributor.SelectedValue.ToString()));

            CrpReport.SetDataSource(ds);
            CrpReport.Refresh();

            CrpReport.SetParameterValue("Principal", this.drpPrincipal.SelectedItem.Text.ToString());
            CrpReport.SetParameterValue("Branch", this.DrpDistributor.SelectedItem.Text.ToString());
            CrpReport.SetParameterValue("CompanyName", dt.Rows[0]["COMPANY_NAME"].ToString());

            //CrpReport.SetParameterValue("FromDate", this.txtFromDate.Text);
            //CrpReport.SetParameterValue("ToDate", this.txtToDate.Text);

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
    protected void drpPrincipal_SelectedIndexChanged(object sender, EventArgs e)
    {
        DrpCatagory.Items.Clear();
        LoadCatagory();
    }
}
