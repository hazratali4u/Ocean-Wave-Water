using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SAMS.BusinessLayer.Classes;
using SAMS.Common.Classes;
using CrystalDecisions.CrystalReports.Engine;
using SAMS.BusinessLayer.Reports;
using System.Data;
using CrystalDecisions.Shared;

public partial class Forms_RptCashSale_Recovery : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    DataTable dt = new DataTable();
    int value;
    private void LoadPrincipal()
    {
        SKUPriceDetailController PController = new SKUPriceDetailController();
        DataTable m_dt = PController.SelectDataPrice(Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, int.Parse(this.Session["UserId"].ToString()), Constants.IntNullValue, 0, DateTime.Parse(this.Session["CurrentWorkDate"].ToString()));
        DrpPrincipal.Items.Add(new ListItem("All", Constants.IntNullValue.ToString()));
        clsWebFormUtil.FillDropDownList(this.DrpPrincipal, m_dt, 0, 1, true);
    }
    private void LoadDistributor()
    {
        DistributorController DController = new DistributorController();
        dt = DController.SelectDistributorInfo(Constants.IntNullValue, int.Parse(this.Session["UserId"].ToString()), int.Parse(this.Session["CompanyId"].ToString()));
        clsWebFormUtil.FillDropDownList(this.drpDistributor, dt, 0, 2, true);
    }
   
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LoadPrincipal();
            LoadDistributor();
           
            SAMS.Common.Classes.Configuration.SystemCurrentDateTime = (DateTime)this.Session["CurrentWorkDate"];
            txtStartDate.Text = SAMS.Common.Classes.Configuration.SystemCurrentDateTime.ToString("dd-MMM-yyyy");
            txtEndDate.Text = SAMS.Common.Classes.Configuration.SystemCurrentDateTime.ToString("dd-MMM-yyyy");
        }
      
    }
    protected void btn_ViewReport_Click(object sender, EventArgs e)
    {
        DocumentPrintController DPrint = new DocumentPrintController();

        DataControl dc = new DataControl();
      
            ds = DPrint.SelectCashSaleRecovery(int.Parse(drpDistributor.SelectedValue.ToString()), int.Parse(DrpPrincipal.SelectedValue.ToString()), DateTime.Parse(txtStartDate.Text + " 00:00:00"), DateTime.Parse(txtEndDate.Text + " 23:59:59"));

            CrpCashSale_Recovery CrpReport = new CrpCashSale_Recovery();
            CrpReport.SetDataSource(ds);

            CrpReport.Refresh();

            CrpReport.SetParameterValue("DISTRIBUTOR_ID", Convert.ToString(drpDistributor.SelectedItem.Text));
            CrpReport.SetParameterValue("PRINCIPAL_ID", Convert.ToString(DrpPrincipal.SelectedItem.Text));

            CrpReport.SetParameterValue("FROM_DATE", DateTime.Parse(txtStartDate.Text));
            CrpReport.SetParameterValue("TO_DATE", DateTime.Parse(txtEndDate.Text));

            this.Session.Add("CrpReport", CrpReport);
            this.Session.Add("ReportType", 0);
            string url = "'Default.aspx'";
            string script = "<script language='JavaScript' type='text/javascript'> window.open(" + url + ",\"Link\",\"toolbar=0,location=0,directories=0,status=0,menubar=0,scrollbars=1,resizable=1,width=800,height=600,left=10,top=10\");</script>";
            Type cstype = this.GetType();
            ClientScriptManager cs = Page.ClientScript;
            cs.RegisterStartupScript(cstype, "OpenWindow", script);
        
      
    }
    protected void btn_ViewExcel_Click(object sender, EventArgs e)
    {
        DocumentPrintController DPrint = new DocumentPrintController();


        DataSetToExcel dsexcel = new DataSetToExcel();

       

            ds = DPrint.SelectCashSaleRecovery(int.Parse(drpDistributor.SelectedValue.ToString()), int.Parse(DrpPrincipal.SelectedValue.ToString()), DateTime.Parse(txtStartDate.Text + " 00:00:00"), DateTime.Parse(txtStartDate.Text + " 23:59:59"));

            CrpCashSale_Recovery CrpReport = new CrpCashSale_Recovery();
            CrpReport.SetDataSource(ds);

            CrpReport.Refresh();

            CrpReport.SetParameterValue("DISTRIBUTOR_ID", Convert.ToString(drpDistributor.SelectedItem.Text));
            CrpReport.SetParameterValue("PRINCIPAL_ID", Convert.ToString(DrpPrincipal.SelectedItem.Text));

            CrpReport.SetParameterValue("FROM_DATE", DateTime.Parse(txtStartDate.Text));
            CrpReport.SetParameterValue("TO_DATE", DateTime.Parse(txtEndDate.Text));

            string path = SAMS.Common.Classes.Configuration.GetAppInstallationPath() + "\\CashSale&Recovery.xls";
            CrpReport.ExportToDisk(ExportFormatType.Excel, path);
            // DataSetToExcel.exportToExcel(ds, path, "DEL-MAN_TRANSCTIONDETAIL");

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
   
   
}