using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;
using SAMS.BusinessLayer.Classes;
using SAMS.BusinessLayer.Reports;
using SAMS.Common.Classes;  
    
public partial class Forms_frmDocumentPrinting : System.Web.UI.Page
{
    private void LoadPrincipal()
    {
        SKUPriceDetailController PController = new SKUPriceDetailController();
        DataTable m_dt = PController.SelectDataPrice(Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, int.Parse( Session["UserId"].ToString()), Constants.IntNullValue, 0, DateTime.Parse( Session["CurrentWorkDate"].ToString()));
        clsWebFormUtil.FillDropDownList( DrpPrincipal, m_dt, 0, 1, true);
    }
    private void LoadDistributor()
    {
        DistributorController DController = new DistributorController();
        DataTable dt = DController.SelectDistributorInfo(Constants.IntNullValue, int.Parse( Session["UserId"].ToString()), int.Parse( Session["CompanyId"].ToString()));
        clsWebFormUtil.FillDropDownList( drpDistributor, dt, 0, 2,true);
    }
    private void LoadSaleForce()
    {
        DrpArea.Items.Clear();   
        Distributor_UserController mDController = new Distributor_UserController();
        DataTable m_dt = mDController.SelectRollBackInvoiceSaleForce(int.Parse(DrpLedgerType.SelectedValue.ToString()), int.Parse(DrpPrincipal.SelectedValue.ToString()), int.Parse(drpDistributor.SelectedValue.ToString()));
        DrpArea.Items.Add(new ListItem("All", Constants.IntNullValue.ToString()));       
        clsWebFormUtil.FillDropDownList( DrpArea, m_dt, 0, 1);
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
             LoadDistributor();
             LoadPrincipal();
             LoadSaleForce();
            SAMS.Common.Classes.Configuration.SystemCurrentDateTime = (DateTime) Session["CurrentWorkDate"];     
            txtStartDate.Text = SAMS.Common.Classes.Configuration.SystemCurrentDateTime.ToString("dd-MMM-yyyy");
            txtEndDate.Text = SAMS.Common.Classes.Configuration.SystemCurrentDateTime.ToString("dd-MMM-yyyy");
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {

        DocumentPrintController DPrint = new DocumentPrintController();
                
        DataSet ds = null;
        DataTable dt = DPrint.SelectReportTitle(int.Parse(drpDistributor.SelectedValue.ToString()));

        if (dt.Rows.Count > 0)
        {
           
            if (DrpLedgerType.SelectedIndex == 3)
            {
                DataControl dc = new DataControl();
                ds = DPrint.SelectDocumentforPrint(int.Parse(drpDistributor.SelectedValue.ToString()), int.Parse(DrpArea.SelectedValue.ToString()), int.Parse(DrpPrincipal.SelectedValue.ToString()),
                    DateTime.Parse(txtStartDate.Text + " 00:00:00"), DateTime.Parse(txtEndDate.Text + " 23:59:59"), 1,Constants.LongNullValue,Convert.ToInt32(DrpPrintType.SelectedValue));
                
                ReportDocument SubReport = new ReportDocument();
                CrpDeliveryChallan CrpReport = new CrpDeliveryChallan();

                SubReport = CrpReport.OpenSubreport("Subreport1");
                CrpReport.SetDataSource(ds);
                SubReport.SetDataSource(ds);
                CrpReport.Refresh();
                CrpReport.SetParameterValue("COMPANY_NAME",dt.Rows[0]["COMPANY_NAME"].ToString());
                CrpReport.SetParameterValue("CompanyAddress", "Branch Address: " + dt.Rows[0]["ADDRESS1"].ToString());
                 Session.Add("CrpReport", CrpReport);
                 Session.Add("ReportType", 0);  
                string url = "'Default.aspx'";
                string script = "<script language='JavaScript' type='text/javascript'> window.open(" + url + ",\"Link\",\"toolbar=0,location=0,directories=0,status=0,menubar=0,scrollbars=1,resizable=1,width=800,height=600,left=10,top=10\");</script>";
                Type cstype =  GetType();
                ClientScriptManager cs = Page.ClientScript;
                cs.RegisterStartupScript(cstype, "OpenWindow", script);

            }
            else if (DrpLedgerType.SelectedIndex == 4)
            {
                
                    DataControl dc = new DataControl();
                    ds = DPrint.SelectDocumentforPrint(int.Parse(drpDistributor.SelectedValue.ToString()), int.Parse(DrpArea.SelectedValue.ToString()), int.Parse(DrpPrincipal.SelectedValue.ToString()),
                        DateTime.Parse(txtStartDate.Text + " 00:00:00"), DateTime.Parse(txtEndDate.Text + " 23:59:59"), 1, Constants.LongNullValue, Convert.ToInt32(DrpPrintType.SelectedValue));

                    CrpPrintUSDInvoice CrpReport = new CrpPrintUSDInvoice(); 
                    CrpReport.SetDataSource(ds);
                    CrpReport.Refresh();

                    CrpReport.SetParameterValue("COMPANY_NAME", dt.Rows[0]["COMPANY_NAME"].ToString());
                    CrpReport.SetParameterValue("CompanyAddress", "Branch Address: " +  dt.Rows[0]["ADDRESS1"].ToString());
                    CrpReport.SetParameterValue("TAXREGISTERATION_NO", dt.Rows[0]["GST_NUMBER"].ToString());
                    CrpReport.SetParameterValue("DISTRIBUTOR_NAME", dt.Rows[0]["DISTRIBUTOR_NAME"].ToString());
                     Session.Add("CrpReport", CrpReport);
                     Session.Add("ReportType", 0);
                    string url = "'Default.aspx'";
                    string script = "<script language='JavaScript' type='text/javascript'> window.open(" + url + ",\"Link\",\"toolbar=0,location=0,directories=0,status=0,menubar=0,scrollbars=1,resizable=1,width=800,height=600,left=10,top=10\");</script>";
                    Type cstype =  GetType();
                    ClientScriptManager cs = Page.ClientScript;
                    cs.RegisterStartupScript(cstype, "OpenWindow", script);

                
            }
            else
            {
                DataControl dc = new DataControl();
                ds = DPrint.SelectDocumentforPrint(int.Parse(drpDistributor.SelectedValue.ToString()), int.Parse(DrpArea.SelectedValue.ToString()), int.Parse(DrpPrincipal.SelectedValue.ToString()),
                    DateTime.Parse(txtStartDate.Text + " 00:00:00"), DateTime.Parse(txtEndDate.Text + " 23:59:59"), int.Parse(DrpLedgerType.SelectedValue.ToString()), Constants.LongNullValue, Convert.ToInt32(DrpPrintType.SelectedValue));

                ReportDocument SubReport = new ReportDocument();
                CrpPrintDocument CrpReport = new CrpPrintDocument();

                SubReport = CrpReport.OpenSubreport("SUBREPORT1");
                CrpReport.SetDataSource(ds);
                SubReport.SetDataSource(ds);
                CrpReport.Refresh();

                CrpReport.SetParameterValue("COMPANY_NAME", dt.Rows[0]["COMPANY_NAME"].ToString());
                CrpReport.SetParameterValue("DISTRIBUTOR_NAME", dt.Rows[0]["DISTRIBUTOR_NAME"].ToString());
                CrpReport.SetParameterValue("Address", "Address: " + dt.Rows[0]["ADDRESS1"].ToString());
                CrpReport.SetParameterValue("EmailTo", dt.Rows[0]["ADDRESS2"].ToString());                
                CrpReport.SetParameterValue("CONTACT_NUMBER", dt.Rows[0]["CONTACT_NUMBER"].ToString());
                CrpReport.SetParameterValue("NTN", "NTN #:" + dt.Rows[0]["NTN_NO"].ToString());
                CrpReport.SetParameterValue("PrintType", DrpPrintType.SelectedValue);

                 Session.Add("CrpReport", CrpReport);
                 Session.Add("ReportType", 0);
                const string url = "'Default.aspx'";
                const string script = "<script language='JavaScript' type='text/javascript'> window.open(" + url + ",\"Link\",\"toolbar=0,location=0,directories=0,status=0,menubar=0,scrollbars=1,resizable=1,width=800,height=600,left=10,top=10\");</script>";
                Type cstype =  GetType();
                ClientScriptManager cs = Page.ClientScript;
                cs.RegisterStartupScript(cstype, "OpenWindow", script);
            }
                       
        }
    }
    protected void drpDistributor_SelectedIndexChanged(object sender, EventArgs e)
    {
         LoadSaleForce();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        DataTable  ds = null;
        DocumentPrintController DPrint = new DocumentPrintController();
        if (DrpLedgerType.SelectedIndex == 3)
        {
            ds = DPrint.SelectDocumentforView(int.Parse(drpDistributor.SelectedValue.ToString()), int.Parse(DrpArea.SelectedValue.ToString()), int.Parse(DrpPrincipal.SelectedValue.ToString()),
                   DateTime.Parse(txtStartDate.Text + " 00:00:00"), DateTime.Parse(txtEndDate.Text + " 23:59:59"),1);
        }
        else
        {
            ds = DPrint.SelectDocumentforView(int.Parse(drpDistributor.SelectedValue.ToString()), int.Parse(DrpArea.SelectedValue.ToString()), int.Parse(DrpPrincipal.SelectedValue.ToString()),
                       DateTime.Parse(txtStartDate.Text + " 00:00:00"), DateTime.Parse(txtEndDate.Text + " 23:59:59"), int.Parse(DrpLedgerType.SelectedValue.ToString()));
        }

        GrdOrder.DataSource = ds;
        GrdOrder.DataBind();      
    }
    protected void GrdOrder_RowEditing(object sender, GridViewEditEventArgs e)
    {
        DocumentPrintController DPrint = new DocumentPrintController();
        DataSet ds = null;
        DataTable dt = DPrint.SelectReportTitle(int.Parse(drpDistributor.SelectedValue.ToString()));

        if (dt.Rows.Count > 0)
        {
            if (DrpLedgerType.SelectedIndex == 3)
            {
                DataControl dc = new DataControl();
                ds = DPrint.SelectDocumentforPrint(int.Parse(drpDistributor.SelectedValue.ToString()), int.Parse(DrpArea.SelectedValue.ToString()), int.Parse(DrpPrincipal.SelectedValue.ToString()),
                    DateTime.Parse(txtStartDate.Text + " 00:00:00"), DateTime.Parse(txtEndDate.Text + " 23:59:59"), 1, long.Parse(GrdOrder.Rows[e.NewEditIndex].Cells[3].Text), Convert.ToInt32(DrpPrintType.SelectedValue));

                CrpDeliveryChallan CrpReport = new CrpDeliveryChallan();
                CrpReport.SetDataSource(ds);
                CrpReport.Refresh();
                CrpReport.SetParameterValue("CompanyAddress", "Branch Address: " + dt.Rows[0]["ADDRESS1"].ToString());
                 Session.Add("CrpReport", CrpReport);
                 Session.Add("ReportType", 0);
                 const string url = "'Default.aspx'";
                 const string script = "<script language='JavaScript' type='text/javascript'> window.open(" + url + ",\"Link\",\"toolbar=0,location=0,directories=0,status=0,menubar=0,scrollbars=1,resizable=1,width=800,height=600,left=10,top=10\");</script>";
                Type cstype =  GetType();
                ClientScriptManager cs = Page.ClientScript;
                cs.RegisterStartupScript(cstype, "OpenWindow", script);

            }
            else
            {
                DataControl dc = new DataControl();
                ds = DPrint.SelectDocumentforPrint(int.Parse(drpDistributor.SelectedValue.ToString()), int.Parse(DrpArea.SelectedValue.ToString()), int.Parse(DrpPrincipal.SelectedValue.ToString()),
                    DateTime.Parse(txtStartDate.Text + " 00:00:00"), DateTime.Parse(txtEndDate.Text + " 23:59:59"), int.Parse(DrpLedgerType.SelectedValue.ToString()), long.Parse(GrdOrder.Rows[e.NewEditIndex].Cells[3].Text), Convert.ToInt32(DrpPrintType.SelectedValue));

                ReportDocument SubReport = new ReportDocument();
                CrpPrintDocument CrpReport = new CrpPrintDocument();

                SubReport = CrpReport.OpenSubreport("SUBREPORT1");
                CrpReport.SetDataSource(ds);
                SubReport.SetDataSource(ds);
                CrpReport.Refresh();

                CrpReport.SetParameterValue("COMPANY_NAME", dt.Rows[0]["COMPANY_NAME"].ToString());
                CrpReport.SetParameterValue("DISTRIBUTOR_NAME", dt.Rows[0]["DISTRIBUTOR_NAME"].ToString());

                //CrpReport.SetParameterValue("NtnNumber", "NTN :" + dt.Rows[0]["NTN_NO"].ToString());
                //CrpReport.SetParameterValue("DTYPE", int.Parse(dt.Rows[0]["SUBZONE_ID"].ToString()));
                //CrpReport.SetParameterValue("CompanyAddress", "Branch Address: " + dt.Rows[0]["ADDRESS1"].ToString());
                //CrpReport.SetParameterValue("TAXREGISTERATION_NO", dt.Rows[0]["GST_NUMBER"].ToString());
                
                //CrpReport.SetParameterValue("CONTACT_NUMBER", dt.Rows[0]["CONTACT_NUMBER"].ToString());

                 Session.Add("CrpReport", CrpReport);
                 Session.Add("ReportType", 0);  
                string url = "'Default.aspx'";
                string script = "<script language='JavaScript' type='text/javascript'> window.open(" + url + ",\"Link\",\"toolbar=0,location=0,directories=0,status=0,menubar=0,scrollbars=1,resizable=1,width=800,height=600,left=10,top=10\");</script>";
                Type cstype =  GetType();
                ClientScriptManager cs = Page.ClientScript;
                cs.RegisterStartupScript(cstype, "OpenWindow", script);
            }
        }
    }
    protected void DrpPrincipal_SelectedIndexChanged(object sender, EventArgs e)
    {
         LoadSaleForce();
    }
    protected void DrpLedgerType_SelectedIndexChanged(object sender, EventArgs e)
    {
         LoadSaleForce();
    }

    protected void btnViewExcel_Click(object sender, EventArgs e)
    {
        DocumentPrintController DPrint = new DocumentPrintController();

        DataSet ds = null;
        DataTable dt = DPrint.SelectReportTitle(int.Parse(drpDistributor.SelectedValue.ToString()));

        if (dt.Rows.Count > 0)
        {

            if (DrpLedgerType.SelectedIndex == 3)
            {
                DataControl dc = new DataControl();
                ds = DPrint.SelectDocumentforPrint(int.Parse(drpDistributor.SelectedValue.ToString()), int.Parse(DrpArea.SelectedValue.ToString()), int.Parse(DrpPrincipal.SelectedValue.ToString()),
                    DateTime.Parse(txtStartDate.Text + " 00:00:00"), DateTime.Parse(txtEndDate.Text + " 23:59:59"), 1, Constants.LongNullValue, Convert.ToInt32(DrpPrintType.SelectedValue));

                ReportDocument SubReport = new ReportDocument();
                CrpDeliveryChallan CrpReport = new CrpDeliveryChallan();

                SubReport = CrpReport.OpenSubreport("Subreport1");
                CrpReport.SetDataSource(ds);
                SubReport.SetDataSource(ds);
                CrpReport.Refresh();
                CrpReport.SetParameterValue("COMPANY_NAME", dt.Rows[0]["COMPANY_NAME"].ToString());
                CrpReport.SetParameterValue("CompanyAddress", "Branch Address: " + dt.Rows[0]["ADDRESS1"].ToString());
                 Session.Add("CrpReport", CrpReport);
                 Session.Add("ReportType", 1);
                string url = "'Default.aspx'";
                string script = "<script language='JavaScript' type='text/javascript'> window.open(" + url + ",\"Link\",\"toolbar=0,location=0,directories=0,status=0,menubar=0,scrollbars=1,resizable=1,width=800,height=600,left=10,top=10\");</script>";
                Type cstype =  GetType();
                ClientScriptManager cs = Page.ClientScript;
                cs.RegisterStartupScript(cstype, "OpenWindow", script);

            }
            else if (DrpLedgerType.SelectedIndex == 4)
            {

                DataControl dc = new DataControl();
                ds = DPrint.SelectDocumentforPrint(int.Parse(drpDistributor.SelectedValue.ToString()), int.Parse(DrpArea.SelectedValue.ToString()), int.Parse(DrpPrincipal.SelectedValue.ToString()),
                    DateTime.Parse(txtStartDate.Text + " 00:00:00"), DateTime.Parse(txtEndDate.Text + " 23:59:59"), 1, Constants.LongNullValue, Convert.ToInt32(DrpPrintType.SelectedValue));

                CrpPrintUSDInvoice CrpReport = new CrpPrintUSDInvoice();
                CrpReport.SetDataSource(ds);
                CrpReport.Refresh();

                CrpReport.SetParameterValue("COMPANY_NAME", dt.Rows[0]["COMPANY_NAME"].ToString());
                CrpReport.SetParameterValue("CompanyAddress", "Branch Address: " + dt.Rows[0]["ADDRESS1"].ToString());
                CrpReport.SetParameterValue("TAXREGISTERATION_NO", dt.Rows[0]["GST_NUMBER"].ToString());
                CrpReport.SetParameterValue("DISTRIBUTOR_NAME", dt.Rows[0]["DISTRIBUTOR_NAME"].ToString());
                 Session.Add("CrpReport", CrpReport);
                 Session.Add("ReportType", 1);
                string url = "'Default.aspx'";
                string script = "<script language='JavaScript' type='text/javascript'> window.open(" + url + ",\"Link\",\"toolbar=0,location=0,directories=0,status=0,menubar=0,scrollbars=1,resizable=1,width=800,height=600,left=10,top=10\");</script>";
                Type cstype =  GetType();
                ClientScriptManager cs = Page.ClientScript;
                cs.RegisterStartupScript(cstype, "OpenWindow", script);


            }
            else
            {
                DataControl dc = new DataControl();
                ds = DPrint.SelectDocumentforPrint(int.Parse(drpDistributor.SelectedValue.ToString()), int.Parse(DrpArea.SelectedValue.ToString()), int.Parse(DrpPrincipal.SelectedValue.ToString()),
                    DateTime.Parse(txtStartDate.Text + " 00:00:00"), DateTime.Parse(txtEndDate.Text + " 23:59:59"), int.Parse(DrpLedgerType.SelectedValue.ToString()), Constants.LongNullValue, Convert.ToInt32(DrpPrintType.SelectedValue));

                ReportDocument SubReport = new ReportDocument();
                CrpPrintDocument CrpReport = new CrpPrintDocument();

                SubReport = CrpReport.OpenSubreport("SUBREPORT1");
                CrpReport.SetDataSource(ds);
                SubReport.SetDataSource(ds);
                CrpReport.Refresh();

                CrpReport.SetParameterValue("COMPANY_NAME", dt.Rows[0]["COMPANY_NAME"].ToString());
                CrpReport.SetParameterValue("DISTRIBUTOR_NAME", dt.Rows[0]["DISTRIBUTOR_NAME"].ToString());
                CrpReport.SetParameterValue("Address", "Address: " + dt.Rows[0]["ADDRESS1"].ToString());
                CrpReport.SetParameterValue("EmailTo", dt.Rows[0]["ADDRESS2"].ToString());
                CrpReport.SetParameterValue("CONTACT_NUMBER", dt.Rows[0]["CONTACT_NUMBER"].ToString());
                CrpReport.SetParameterValue("NTN", "NTN #:" + dt.Rows[0]["NTN_NO"].ToString());
                CrpReport.SetParameterValue("PrintType", DrpPrintType.SelectedValue);

                 Session.Add("CrpReport", CrpReport);
                 Session.Add("ReportType", 1);
                string url = "'Default.aspx'";
                string script = "<script language='JavaScript' type='text/javascript'> window.open(" + url + ",\"Link\",\"toolbar=0,location=0,directories=0,status=0,menubar=0,scrollbars=1,resizable=1,width=800,height=600,left=10,top=10\");</script>";
                Type cstype =  GetType();
                ClientScriptManager cs = Page.ClientScript;
                cs.RegisterStartupScript(cstype, "OpenWindow", script);
            }

        }
    }
}
