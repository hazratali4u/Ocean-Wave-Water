using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using SAMS.BusinessLayer.Classes;
using SAMS.Common.Classes; 
public partial class Forms_RptPrincipalWiseExp : System.Web.UI.Page
{
    private void LoadPrincipal()
    {
        SKUPriceDetailController PController = new SKUPriceDetailController();
        DataTable m_dt = PController.SelectDataPrice(Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, int.Parse(this.Session["UserId"].ToString()), Constants.IntNullValue, 0, DateTime.Parse(this.Session["CurrentWorkDate"].ToString()));
        drpPrincipal.Items.Add(new ListItem("All", Constants.IntNullValue.ToString()));
        drpPrincipal.Items.Add(new ListItem("General Expense", "0"));
        clsWebFormUtil.FillDropDownList(this.drpPrincipal, m_dt, 0, 1);
    }
    private void LoadDistributor()
    {
        DrpLocation.Items.Clear();
        DistributorController DController = new DistributorController();
        DataTable dt = DController.SelectDistributorInfo(Constants.IntNullValue, int.Parse(this.Session["UserId"].ToString()), int.Parse(this.Session["CompanyId"].ToString()));
        DrpLocation.Items.Add(new ListItem("All", Constants.IntNullValue.ToString()));
        clsWebFormUtil.FillDropDownList(this.DrpLocation, dt, 0, 2);

        
        
    }
    private void LoadAccountHead()
    {
        SAMS.Common.Classes.Configuration.GetAccountHead();
        AccountHeadController mAccountController = new AccountHeadController();
        DataTable dt = mAccountController.SelectAccountHead(Constants.AC_AccountHeadId, long.Parse(SAMS.Common.Classes.Configuration.ExpensDefaultType));
        //clsWebFormUtil.FillDropDownList(DrpAccountHead, dt, 0, 4, true);
        clsWebFormUtil.FillListBox(this.LstAccountHead, dt, 0, 4);
    }
    protected void CheckAll()
    {
        if (this.ChbAllAccountHead.Checked == true)
        {
            for (int i = 0; i < this.LstAccountHead.Items.Count; i++)
            {
                this.LstAccountHead.Items[i].Selected = true;
            }
        }
        else
        {
            for (int i = 0; i < this.LstAccountHead.Items.Count; i++)
            {
                this.LstAccountHead.Items[i].Selected = false;
            }
        }

    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.LoadDistributor();
            this.LoadPrincipal();
            this.LoadAccountHead();
            SAMS.Common.Classes.Configuration.SystemCurrentDateTime = (DateTime)this.Session["CurrentWorkDate"];
            txtFromDate.Text = SAMS.Common.Classes.Configuration.SystemCurrentDateTime.ToString("dd-MMM-yyyy");
            txtToDate.Text = SAMS.Common.Classes.Configuration.SystemCurrentDateTime.ToString("dd-MMM-yyyy");            
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        try
        {
            SAMS.BusinessLayer.Classes.DocumentPrintController DPrint = new SAMS.BusinessLayer.Classes.DocumentPrintController();

            DateTime parsed_date_fromdate = DateTime.Parse(this.txtFromDate.Text);
            DateTime parsed_date_todate = DateTime.Parse(this.txtToDate.Text);
            string FromDate = parsed_date_fromdate.ToShortDateString();
            string ToDate = parsed_date_todate.ToShortDateString();
            string Catagories_IDs = null;
            
            SAMS.BusinessLayer.Reports.CrpPrincipalWiseExp CrpReport = new SAMS.BusinessLayer.Reports.CrpPrincipalWiseExp();
            
            DataSet ds = null;
            
            for (int i = 0; i < this.LstAccountHead.Items.Count; i++)
            {
                if (this.LstAccountHead.Items[i].Selected == true)
                {
                    Catagories_IDs += this.LstAccountHead.Items[i].Value.ToString() + ",";
                }
            }

            ds = DPrint.PrincipalWiseSale(int.Parse(drpPrincipal.SelectedValue.ToString()), Convert.ToInt32(this.DrpLocation.SelectedValue.ToString()), Convert.ToDateTime(FromDate + " 00:00:00"), Convert.ToDateTime(ToDate + " 00:00:00"), Catagories_IDs, RadioButtonList1.SelectedIndex);



            CrpReport.SetDataSource(ds);
            CrpReport.Refresh();

            CrpReport.SetParameterValue("Principal", this.drpPrincipal.SelectedItem.Text.ToString());
            CrpReport.SetParameterValue("Distributor", this.DrpLocation.SelectedItem.Text.ToString());

            CrpReport.SetParameterValue("From_date", this.txtFromDate.Text);
            CrpReport.SetParameterValue("To_Date", this.txtToDate.Text);
            CrpReport.SetParameterValue("ReportTitle", "Principal Wise Petty Report");

            
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
    protected void ChbAllLocationType_CheckedChanged(object sender, EventArgs e)
    {
        this.CheckAll();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {

    }
}
