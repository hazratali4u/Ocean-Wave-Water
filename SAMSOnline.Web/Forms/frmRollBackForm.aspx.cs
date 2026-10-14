using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using SAMS.BusinessLayer.Classes;
using SAMS.Common.Classes;
    

public partial class Forms_frmRollBackForm : System.Web.UI.Page
{
    private void LoadDistributor()
    {
        DistributorController DController = new DistributorController();
        DataTable dt = DController.SelectDistributorInfo(Constants.IntNullValue, int.Parse(this.Session["UserId"].ToString()), int.Parse(this.Session["CompanyId"].ToString()));
        clsWebFormUtil.FillDropDownList(this.drpDistributor, dt, 0, 2, true);
    }
    private void LoadPrincipal()
    {
        SKUPriceDetailController PController = new SKUPriceDetailController();
        DataTable m_dt = PController.SelectDataPrice(Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, int.Parse(this.Session["UserId"].ToString()), Constants.IntNullValue, 0, DateTime.Parse(this.Session["CurrentWorkDate"].ToString()));
        clsWebFormUtil.FillDropDownList(this.DrpPrincipal, m_dt, 0, 1, true);
    }
    private void LoadLegend()
    {
        OrderEntryController or = new OrderEntryController();
        DataTable m_dt = or.SelectLegend(); 
        clsWebFormUtil.FillDropDownList(this.DrpLenged, m_dt, 0, 2, true);
    }
    private void LoadOrderBooker()
    {
        if (drpDistributor.Items.Count > 0)
        {
            Distributor_UserController mDController = new Distributor_UserController();
            DataTable m_dt = mDController.SelectRollBackInvoiceSaleForce(int.Parse(DrpDocumentType.SelectedValue.ToString()),int.Parse(DrpPrincipal.SelectedValue.ToString()),int.Parse(drpDistributor.SelectedValue.ToString()));
            clsWebFormUtil.FillDropDownList(this.DrpOrderBooker, m_dt, 0, 1, true);
        }
        else
        {
            DrpOrderBooker.Items.Clear();
        }
    }
    private void LoadRollbackDocument()
    {
        OrderEntryController or = new OrderEntryController();
        DataTable dtOrder = or.SelectRollBackDocument(int.Parse(drpDistributor.SelectedValue.ToString()),int.Parse(DrpPrincipal.SelectedValue.ToString()),
            int.Parse(DrpOrderBooker.SelectedValue.ToString()), int.Parse(DrpDocumentType.SelectedValue.ToString()), DateTime.Parse(this.Session["CurrentWorkDate"].ToString()));
        GrdOrder.DataSource = dtOrder;
        GrdOrder.DataBind();
    }
    private void LoadRollbackCheque()
    {
        ChequeEntryController CController = new ChequeEntryController();
        DataTable dt = CController.SelectChequeEntry(Constants.Cheque_Clear , DateTime.Parse(this.Session["CurrentWorkDate"].ToString()), int.Parse(drpDistributor.SelectedValue.ToString()), int.Parse(DrpPrincipal.SelectedValue.ToString()),0);
        GrdCheque.DataSource = dt;
        GrdCheque.DataBind();

       
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.LoadDistributor();
            this.LoadPrincipal(); 
            this.LoadOrderBooker();
            this.LoadLegend(); 
        }
    }
    protected void DrpDocumentType_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadOrderBooker();
    }
    protected void drpDistributor_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadPrincipal();
        this.LoadOrderBooker();
         
    }
    protected void btnPost_Click(object sender, EventArgs e)
    {
        if (DrpDocumentType.SelectedIndex == 3)
        {
            foreach (GridViewRow dr in GrdCheque.Rows)
            {
                CheckBox ChbInvoice = (CheckBox)dr.FindControl("ChbInvoice");
                if (ChbInvoice.Checked == true)
                {
                    ChequeEntryController CController = new ChequeEntryController();
                    DataControl dc = new DataControl();
                    CController.RollbackChequeEntry(int.Parse(DrpPrincipal.SelectedValue.ToString()), int.Parse(drpDistributor.SelectedValue.ToString()), dr.Cells[6].Text, long.Parse(dr.Cells[0].Text),long.Parse(dr.Cells[5].Text));
                }
            }
            LoadRollbackCheque();
        }
        else
        {
            foreach (GridViewRow dr in GrdOrder.Rows)
            {
                CheckBox ChbInvoice = (CheckBox)dr.FindControl("ChbInvoice");
                if (ChbInvoice.Checked == true)
                {
                    OrderEntryController ORD = new OrderEntryController();
                    DataControl dc = new DataControl();
                    ORD.UpdateRollBackDocument(long.Parse(dr.Cells[11].Text), int.Parse(DrpDocumentType.SelectedValue.ToString()), int.Parse(DrpLenged.SelectedValue.ToString()));
                }
            }
            this.LoadRollbackDocument();
        }
    }
    protected void btnGetOrder_Click(object sender, EventArgs e)
    {
        if (DrpDocumentType.SelectedIndex == 3)
        {
            this.LoadRollbackCheque();
            GrdOrder.Visible = false;
            GrdCheque.Visible = true;  
        }
        else
        {
            GrdOrder.Visible = true;
            GrdCheque.Visible = false;  
            this.LoadRollbackDocument();

        }
    }
    protected void DrpPrincipal_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadOrderBooker();
    }

}
