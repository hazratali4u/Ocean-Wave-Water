using System;
using System.Data;
using System.Web.UI;
using SAMS.BusinessLayer.Classes;
using SAMS.BusinessLayer.Reports;
using SAMS.Common.Classes;

public partial class Forms_rptOutletWiseSale : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LoadPrincipal();
            LoadCatagory();
            LoadLocation();
            DateTime dt = (DateTime)this.Session["CurrentWorkDate"]; 
            this.txtFromDate.Text = dt.ToString("dd-MMM-yyyy");
            this.txtToDate.Text   = dt.ToString("dd-MMM-yyyy");
        }
    }
    protected void LoadCatagory()
    {
        SkuHierarchyController Hierarchy = new SkuHierarchyController();
        DataTable dtCatagory = Hierarchy.SelectSkuHierarchyView(5, int.Parse(this.Session["CompanyId"].ToString()));
        DataView dv = new DataView(dtCatagory);
        dv.RowFilter = "Company_id = " + Convert.ToInt32(drpPrincipal.SelectedValue.ToString());
        dtCatagory = dv.ToTable();
        //this.ListCatagory.Items.Add(new ListItem("All", "0"));
        //clsWebFormUtil.FillDropDownList(this.ListCatagory , dtCatagory, "Category_Id", "Category_Name");
        clsWebFormUtil.FillListBox(this.ListCatagory, dtCatagory , 4, 6);
        //this.ListCatagory.DataSource = dtCatagory;
        //this.ListCatagory.DataTextField  = "Category_Name";
        //this.ListCatagory.DataValueField = "Category_Id";
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
    protected void drpPrincipal_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.ListCatagory.Items.Clear();
        LoadCatagory();
    }
    protected void CheckAll()
    {
        if (this.ChbAllCatagories.Checked == true)
        {
            for (int i = 0; i < this.ListCatagory.Items.Count; i++)
            {
                this.ListCatagory.Items[i].Selected = true;
            }
        }
        else
        {
            for (int i = 0; i < this.ListCatagory.Items.Count; i++)
            {
                this.ListCatagory.Items[i].Selected = false;
            }
        }
    
    }
    protected void ChbAllLocationType_CheckedChanged(object sender, EventArgs e)
    {
        CheckAll();
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        try
        {
            SAMS.BusinessLayer.Classes.DocumentPrintController DPrint = new SAMS.BusinessLayer.Classes.DocumentPrintController();

            DateTime parsed_date_fromdate = DateTime.Parse(this.txtFromDate.Text);
            DateTime parsed_date_todate   = DateTime.Parse(this.txtToDate.Text);
            string   FromDate             = parsed_date_fromdate.ToShortDateString();
            string   ToDate               = parsed_date_todate.ToShortDateString();
            string Catagories_IDs = null;
            CrpOutletwiseSale CrpReport = new CrpOutletwiseSale();
            DataSet ds = null;
            for (int i = 0; i < this.ListCatagory.Items.Count; i++)
            {
                if (this.ListCatagory.Items[i].Selected == true)
                {
                    Catagories_IDs += this.ListCatagory.Items[i].Value.ToString() + ",";
                }
            }

            ds = DPrint.OutletWiseSale(int.Parse(drpPrincipal.SelectedValue.ToString()), Convert.ToInt32(this.DrpLocation.SelectedValue.ToString()),Convert.ToDateTime(FromDate + " 00:00:00"), Convert.ToDateTime(ToDate + " 00:00:00"), Catagories_IDs);
            
           

            CrpReport.SetDataSource(ds);
            CrpReport.Refresh();

            CrpReport.SetParameterValue("Principal", this.drpPrincipal.SelectedItem.Text.ToString());
            CrpReport.SetParameterValue("Branch", this.DrpLocation.SelectedItem.Text.ToString());

            CrpReport.SetParameterValue("FromDate", this.txtFromDate.Text);
            CrpReport.SetParameterValue("ToDate", this.txtToDate.Text);

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

            DateTime parsed_date_fromdate = DateTime.Parse(this.txtFromDate.Text);
            DateTime parsed_date_todate = DateTime.Parse(this.txtToDate.Text);
            string FromDate = parsed_date_fromdate.ToShortDateString();
            string ToDate = parsed_date_todate.ToShortDateString();

            string Catagories_IDs = null;
            CrpOutletwiseSale CrpReport = new CrpOutletwiseSale();
            DataSet ds = null;
            for (int i = 0; i < this.ListCatagory.Items.Count; i++)
            {
                if (this.ListCatagory.Items[i].Selected == true)
                {
                    Catagories_IDs += this.ListCatagory.Items[i].Value.ToString() + ",";
                }
            }

            ds = DPrint.OutletWiseSale(int.Parse(drpPrincipal.SelectedValue.ToString()), Convert.ToInt32(this.DrpLocation.SelectedValue.ToString()), Convert.ToDateTime(FromDate + " 00:00:00"), Convert.ToDateTime(ToDate + " 00:00:00"), Catagories_IDs);
            
           
            CrpReport.SetDataSource(ds);
            CrpReport.Refresh();

            CrpReport.SetParameterValue("Principal", this.drpPrincipal.SelectedItem.Text.ToString());
            CrpReport.SetParameterValue("Branch", this.DrpLocation.SelectedItem.Text.ToString());

            CrpReport.SetParameterValue("FromDate", this.txtFromDate.Text);
            CrpReport.SetParameterValue("ToDate", this.txtToDate.Text);

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
}
