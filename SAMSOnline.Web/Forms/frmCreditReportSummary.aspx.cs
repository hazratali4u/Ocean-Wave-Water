using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using SAMS.BusinessLayer.Classes;
using SAMS.Common.Classes;    

public partial class Forms_frmCreditReportSummary : System.Web.UI.Page
{
    private void LoadPrincipal()
    {
        SKUPriceDetailController PController = new SKUPriceDetailController();
        DataTable m_dt = PController.SelectDataPrice(Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, int.Parse(this.Session["UserId"].ToString()), Constants.IntNullValue, 0, DateTime.Parse(this.Session["CurrentWorkDate"].ToString()));
        DrpPrincipal.Items.Add(new ListItem("All", Constants.IntNullValue.ToString()));
        clsWebFormUtil.FillDropDownList(this.DrpPrincipal, m_dt, 0, 1);
    }
    private void LoadDistributor()
    {
        DistributorController DController = new DistributorController();
        DataTable dt = DController.SelectDistributorInfo(Constants.IntNullValue, int.Parse(this.Session["UserId"].ToString()), int.Parse(this.Session["CompanyId"].ToString()));
        clsWebFormUtil.FillDropDownList(this.drpDistributor, dt, 0, 2, true);
    }
    private void LoadDeliveryman()
    {
        if (drpDistributor.Items.Count > 0)
        {
            Distributor_UserController mDController = new Distributor_UserController();
            DataTable m_dt = mDController.SelectSaleForceAssignedArea(int.Parse(drpDistributor.SelectedValue.ToString()), Constants.IntNullValue, int.Parse(this.Session["CompanyId"].ToString()));
            DrpDeliveryMan.Items.Add(new ListItem("All", Constants.IntNullValue.ToString()));       
            clsWebFormUtil.FillDropDownList(this.DrpDeliveryMan, m_dt, 0, 3);
        }

    }
    private void LoadOrderBooker()
    {
        if (drpDistributor.Items.Count > 0)
        {
            DrpOrderBooker.Items.Clear();   
            Distributor_UserController mDController = new Distributor_UserController();
            DataTable m_dt = mDController.SelectDistributorUser(Constants.SALES_FORCE_ORDERBOOKER, int.Parse(drpDistributor.SelectedValue.ToString()),int.Parse(this.Session["CompanyId"].ToString()));
            DrpOrderBooker.Items.Add(new ListItem("All",Constants.IntNullValue.ToString()));       
            clsWebFormUtil.FillDropDownList(this.DrpOrderBooker, m_dt, 0, 6);
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.LoadDistributor();
            this.LoadPrincipal();
            this.LoadOrderBooker();
            this.LoadDeliveryman(); 
            SAMS.Common.Classes.Configuration.SystemCurrentDateTime = (DateTime)this.Session["CurrentWorkDate"];
            txtStartDate.Text = SAMS.Common.Classes.Configuration.SystemCurrentDateTime.ToString("dd-MMM-yyyy");
            txtEndDate.Text = SAMS.Common.Classes.Configuration.SystemCurrentDateTime.ToString("dd-MMM-yyyy");
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        if (rbtSotBy.SelectedIndex == 0)
        {
            DocumentPrintController mController = new DocumentPrintController();
            SAMS.BusinessLayer.Reports.CrpCustomerCreditSummary CrpReport = new SAMS.BusinessLayer.Reports.CrpCustomerCreditSummary();

            DataSet ds = mController.SelectPrincipalCreditDetail(int.Parse(drpDistributor.SelectedValue.ToString()), int.Parse(DrpPrincipal.SelectedValue.ToString()), DateTime.Parse(txtStartDate.Text), DateTime.Parse(txtEndDate.Text), int.Parse(this.Session["UserId"].ToString()), 0,int.Parse(DrpOrderBooker.SelectedValue.ToString()),int.Parse(DrpDeliveryMan.SelectedValue.ToString()));
            CrpReport.SetDataSource(ds);
            CrpReport.Refresh();


            CrpReport.SetParameterValue("Distributor", drpDistributor.SelectedItem.Text);
            CrpReport.SetParameterValue("Principal", DrpPrincipal.SelectedItem.Text);
            CrpReport.SetParameterValue("From_date", txtStartDate.Text);
            CrpReport.SetParameterValue("To_Date", txtEndDate.Text);
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
            DocumentPrintController mController = new DocumentPrintController();
            SAMS.BusinessLayer.Reports.CrpCustomerWiseSelling CrpReport = new SAMS.BusinessLayer.Reports.CrpCustomerWiseSelling();

            DataSet ds = mController.SelectCustomerCreditCeiling(int.Parse(drpDistributor.SelectedValue.ToString()), int.Parse(DrpPrincipal.SelectedValue.ToString()), int.Parse(this.Session["UserId"].ToString()));
            CrpReport.SetDataSource(ds);
            CrpReport.Refresh();
            CrpReport.SetParameterValue("Distributor", drpDistributor.SelectedItem.Text);
            CrpReport.SetParameterValue("Principal", DrpPrincipal.SelectedItem.Text);
            this.Session.Add("CrpReport", CrpReport);
            this.Session.Add("ReportType", 0);
            string url = "'Default.aspx'";
            string script = "<script language='JavaScript' type='text/javascript'> window.open(" + url + ",\"Link\",\"toolbar=0,location=0,directories=0,status=0,menubar=0,scrollbars=1,resizable=1,width=800,height=600,left=10,top=10\");</script>";
            Type cstype = this.GetType();
            ClientScriptManager cs = Page.ClientScript;
            cs.RegisterStartupScript(cstype, "OpenWindow", script);
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        DataSetToExcel dsexcel = new DataSetToExcel();
        DataControl dc = new DataControl();
        DocumentPrintController mController = new DocumentPrintController();
        DataSet ds = mController.SelectPrincipalCreditDetail(int.Parse(drpDistributor.SelectedValue.ToString()), int.Parse(DrpPrincipal.SelectedValue.ToString()), DateTime.Parse(txtStartDate.Text), DateTime.Parse(txtEndDate.Text), int.Parse(this.Session["UserId"].ToString()),0,int.Parse(DrpOrderBooker.SelectedValue.ToString()),int.Parse(DrpDeliveryMan.SelectedValue.ToString()));
        string path = SAMS.Common.Classes.Configuration.GetAppInstallationPath() + "\\CustomerDSR.xls";
        DataSetToExcel.exportToExcel(ds, path, "RptCreditSummary");

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
    protected void drpDistributor_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadOrderBooker(); 
    }
}
