using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using SAMS.BusinessLayer.Classes;
using SAMS.Common.Classes;

public partial class Forms_RptSaleForceAreaSaleReport : System.Web.UI.Page
{



    Distributor_UserController UController = new Distributor_UserController();

    private void LoadDesignation()
    {
        SLASHCodesController mController = new SLASHCodesController();
        DataTable m_dt = mController.SelectSlashCodes(Constants.IntNullValue, null, Constants.SaleForce, null, Constants.IntNullValue, true);
        for (int i = 0; i < m_dt.Rows.Count; i++)
        {
            if (int.Parse(m_dt.Rows[i]["REF_ID"].ToString()) == Constants.SALES_FORCE_ORDERBOOKER || int.Parse(m_dt.Rows[i]["REF_ID"].ToString()) == Constants.SALES_FORCE_DELIVERYMAN || int.Parse(m_dt.Rows[i]["REF_ID"].ToString()) == Constants.SALES_FORCE_SALESPERSON)
            {
                DrpDesignation.Items.Add(new ListItem(m_dt.Rows[i]["SLASH_DESC"].ToString(), m_dt.Rows[i]["REF_ID"].ToString()));
            }
        }

    }
    private void LoadDISTRIBUTOR()
    {
        DistributorController mController = new DistributorController();
        DataTable dtDistributor = mController.SelectDistributorInfo(Constants.IntNullValue, int.Parse(this.Session["UserId"].ToString()), int.Parse(this.Session["CompanyId"].ToString()));
        clsWebFormUtil.FillDropDownList(drpDistributor, dtDistributor, 0, 2, true);

    }
    private void LoadDay_OF_Weak()
    {
        DistributorController mController = new DistributorController();
        DataTable dt = mController.SelectDayOf_Weak();
        clsWebFormUtil.FillDropDownList(drpDayofWeak, dt, 0, 1, true);

    }
    protected void LoadGrid()
    {
        if (drpDistributor.Items.Count > 0 && DrpDesignation.Items.Count > 0)
        {
            DataTable dt = UController.SelectDistributorUser(int.Parse(DrpDesignation.SelectedValue.ToString()), int.Parse(drpDistributor.SelectedValue.ToString()), int.Parse(this.Session["CompanyId"].ToString()));
            clsWebFormUtil.FillDropDownList(this.DrpSaleForce, dt, 0, 6, true);
        }
    }
    private void LoadSKUDetail()
    {
        SKUPriceDetailController PController = new SKUPriceDetailController();
        if (DrpSaleForce .Items .Count  > 0)
        {

            DataTable Dtsku_Price = PController.SelectDataPrice2(Constants .IntNullValue , Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, int.Parse(drpDistributor .SelectedValue ), int.Parse(this.Session["UserId"].ToString()), Constants.IntNullValue, 1, DateTime.Parse(this.Session["CurrentWorkDate"].ToString()), Constants .IntNullValue );


            clsWebFormUtil.FillDropDownList(this.DrpSku, Dtsku_Price, 0, 4, true);

          //  this.Session.Add("Dtsku_Price", Dtsku_Price);

        }
    }
 
protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.LoadDay_OF_Weak();
            this.LoadDISTRIBUTOR();
            this.LoadDesignation();
            this.LoadGrid();
           this. LoadSKUDetail();
           DateTime pOrderDate = DateTime.Parse(this.Session["CurrentWorkDate"].ToString());
           txtToDate.Text = pOrderDate.ToString("dd-MMM-yyyy"); 
       }
        
    }

    protected void drpDistributor_SelectedIndexChanged(object sender, EventArgs e)
    {
      
        this.LoadGrid();
        this.LoadSKUDetail();
       
    }
    protected void DrpDesignation_SelectedIndexChanged(object sender, EventArgs e)
    {
       
        this.LoadGrid();
      

    }
    protected void btnSave_Click(object sender, EventArgs e)
    {

        var mController = new DocumentPrintController();
        SAMS.BusinessLayer.Reports.CrpSaleForce_AreaDailySales CrpReport = new SAMS.BusinessLayer.Reports.CrpSaleForce_AreaDailySales();
        DataTable dt = mController.SelectReportTitle(int.Parse(drpDistributor.SelectedValue.ToString()));
        DataSet ds = mController.SALEFORCE_AREA_Sale_report(int.Parse(drpDistributor.SelectedValue.ToString()),
            int.Parse(DrpSaleForce.SelectedValue.ToString()), Constants.LongNullValue,
            int.Parse(drpDayofWeak.SelectedValue), int.Parse(DrpSku.SelectedValue), DateTime.Parse(txtToDate.Text));
        CrpReport.SetDataSource(ds);
        CrpReport.Refresh();


        //CrpReport.SetParameterValue("Distributor", drpDistributor.SelectedItem.Text);
        CrpReport.SetParameterValue("SaleForce", "("+ DrpSaleForce.SelectedItem.Text+")");
        CrpReport.SetParameterValue("Date", DateTime .Parse (txtToDate .Text));
        CrpReport.SetParameterValue("CompanyName", dt.Rows[0]["COMPANY_NAME"].ToString());

        this.Session.Add("CrpReport", CrpReport);
        this.Session.Add("ReportType", 0);
        string url = "'Default.aspx'";
        string script = "<script language='JavaScript' type='text/javascript'> window.open(" + url + ",\"Link\",\"toolbar=0,location=0,directories=0,status=0,menubar=0,scrollbars=1,resizable=1,width=800,height=600,left=10,top=10\");</script>";
        Type cstype = this.GetType();
        ClientScriptManager cs = Page.ClientScript;
        cs.RegisterStartupScript(cstype, "OpenWindow", script);  
       
    }
    protected void DrpSaleForce_SelectedIndexChanged(object sender, EventArgs e)
    {
     
    }

   
    protected void drpDayofWeak_SelectedIndexChanged(object sender, EventArgs e)
    {
        
    }



   

}
