using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using SAMS.BusinessLayer.Classes;
using SAMS.BusinessLayer.Reports;
using SAMS.Common.Classes;  

public partial class Forms_frmLedgerViewData : System.Web.UI.Page
{
    private void LoadDistributor()
    {
        DistributorController DController = new DistributorController();
        DataTable dt = DController.SelectDistributorInfo(Constants.IntNullValue, int.Parse(this.Session["UserId"].ToString()), int.Parse(this.Session["CompanyId"].ToString()));
        clsWebFormUtil.FillDropDownList(this.drpDistributor, dt, 0, 2,true);
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.LoadDistributor();
            btnView.Attributes.Add("onclick", "return ValidateForm();");
            SAMS.Common.Classes.Configuration.SystemCurrentDateTime = (DateTime)this.Session["CurrentWorkDate"];
            txtStartDate.Text = SAMS.Common.Classes.Configuration.SystemCurrentDateTime.ToString("dd-MMM-yyyy");
            txtEndDate.Text = SAMS.Common.Classes.Configuration.SystemCurrentDateTime.ToString("dd-MMM-yyyy");
        }
    }
    protected void btnView_Click(object sender, EventArgs e)
    {
        LedgerController mController = new LedgerController();
        DataTable dt = mController.SelectUnPostVoucherNo(int.Parse(DrpVoucherType.SelectedValue.ToString()), int.Parse(drpDistributor.SelectedValue.ToString()), bool.Parse(RbdList.SelectedValue.ToString()), DateTime.Parse(txtStartDate.Text + " 00:00:00"), DateTime.Parse(txtEndDate.Text + " 23:59:59"));
        GrdLedger.DataSource = dt;
        GrdLedger.DataBind();  
    }
    protected void ChbSelect_CheckedChanged(object sender, EventArgs e)
    {
        foreach (GridViewRow dr in GrdLedger.Rows)
        {
            CheckBox ChbSelect = (CheckBox)dr.Cells[0].FindControl("ChbSelect");
            ChbSelect.Checked = true;
        }
    }
    protected void btnPost_Click(object sender, EventArgs e)
    {
        LedgerController lController = new LedgerController();
        foreach (GridViewRow dr in GrdLedger.Rows)
        {
            CheckBox ChbSelect = (CheckBox)dr.Cells[0].FindControl("ChbSelect");
            if (ChbSelect.Checked == true)
            {
                lController.PostSelectVoucher(int.Parse(drpDistributor.SelectedValue.ToString()), dr.Cells[1].Text, int.Parse(dr.Cells[4].Text), 0, DateTime.Parse(dr.Cells[5].Text));
            }
        }
        DataTable dt = lController.SelectUnPostVoucherNo(int.Parse(DrpVoucherType.SelectedValue.ToString()), int.Parse(drpDistributor.SelectedValue.ToString()), bool.Parse(RbdList.SelectedValue.ToString()), DateTime.Parse(txtStartDate.Text + " 00:00:00"), DateTime.Parse(txtEndDate.Text + " 23:59:59"));
        GrdLedger.DataSource = dt;
        GrdLedger.DataBind();
    }
    protected void GrdLedger_RowEditing(object sender, GridViewEditEventArgs e)
    {
        DocumentPrintController DPrint = new DocumentPrintController();
        crpVoucherView CrpReport = new crpVoucherView(); 

        DataSet ds = null;
        DataTable dt = DPrint.SelectReportTitle(int.Parse(drpDistributor.SelectedValue.ToString()));
        ds = DPrint.SelectUnpostVoucherForPrint(int.Parse(drpDistributor.SelectedValue.ToString()), GrdLedger.Rows[e.NewEditIndex].Cells[1].Text, int.Parse(DrpVoucherType.SelectedValue.ToString()));
        CrpReport.SetDataSource(ds);
        CrpReport.Refresh();

        CrpReport.SetParameterValue("Company_Name", dt.Rows[0]["COMPANY_NAME"].ToString());
        CrpReport.SetParameterValue("DISTRIBUTOR_NAME", dt.Rows[0]["DISTRIBUTOR_NAME"].ToString());
        this.Session.Add("CrpReport", CrpReport);
        this.Session.Add("ReportType", 0); 
        string url = "'Default.aspx'";
        string script = "<script language='JavaScript' type='text/javascript'> window.open(" + url + ",\"Link\",\"toolbar=0,location=0,directories=0,status=0,menubar=0,scrollbars=1,resizable=1,width=800,height=600,left=10,top=10\");</script>";
        Type cstype = this.GetType();
        ClientScriptManager cs = Page.ClientScript;
        cs.RegisterStartupScript(cstype, "OpenWindow", script);

                
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        LedgerController lController = new LedgerController();
        foreach (GridViewRow dr in GrdLedger.Rows)
        {
            CheckBox ChbSelect = (CheckBox)dr.Cells[0].FindControl("ChbSelect");
            if (ChbSelect.Checked == true)
            {
                lController.PostSelectVoucher(int.Parse(drpDistributor.SelectedValue.ToString()), dr.Cells[1].Text, int.Parse(dr.Cells[4].Text), 1, DateTime.Parse(dr.Cells[5].Text));
            }
        }
        DataTable dt = lController.SelectUnPostVoucherNo(int.Parse(DrpVoucherType.SelectedValue.ToString()), int.Parse(drpDistributor.SelectedValue.ToString()), bool.Parse(RbdList.SelectedValue.ToString()), DateTime.Parse(txtStartDate.Text + " 00:00:00"), DateTime.Parse(txtEndDate.Text + " 23:59:59"));
        GrdLedger.DataSource = dt;
        GrdLedger.DataBind();
    }
    protected void RbdList_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RbdList.SelectedIndex == 1)
        {
            btnDelete.Enabled = false;
            btnPost.Enabled = false;
        }
        else
        {
            btnDelete.Enabled = true;
            btnPost.Enabled = true;
        }
    }
    protected void GrdLedger_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        this.Session.Add("VoucherNo", GrdLedger.Rows[e.RowIndex].Cells[1].Text);
        this.Session.Add("DistributorId", drpDistributor.SelectedValue.ToString());
        this.Session.Add("VoucherTypeId", DrpVoucherType.SelectedValue.ToString());
        Response.Redirect("~/Forms/frmVoucherEditing.aspx?Status=" + false);


    }
}
