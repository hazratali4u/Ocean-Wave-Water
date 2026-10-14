using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SAMS.BusinessLayer.Classes;
using System.Data;
using SAMS.Common.Classes;

public partial class Forms_frmStockIssueReturn : System.Web.UI.Page
{

    DataTable PurchaseSKU;
    DataTable dtFreeSKU;
    private static int UnitType;
    private static int RowId;
    private void LoadSKUDetail()
    {
        SKUPriceDetailController PController = new SKUPriceDetailController();
        if (int.Parse(DrpPrincipal.SelectedValue) > 0)
        {
            DataTable Dtsku_Price = PController.SelectDataPrice(int.Parse(DrpPrincipal.SelectedValue), Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, int.Parse(drpDistributor.SelectedValue), int.Parse(this.Session["UserId"].ToString()), Constants.IntNullValue, 1, DateTime.Parse(this.Session["CurrentWorkDate"].ToString()));
            clsWebFormUtil.FillListBox(this.lstCode, Dtsku_Price, 10, 10, true);
            this.Session.Add("Dtsku_Price", Dtsku_Price);
        }
    }
    private void LoadDistributor()
    {
        DistributorController DController = new DistributorController();
        DataTable dt = DController.SelectDistributorInfo(Constants.IntNullValue, int.Parse(this.Session["UserId"].ToString()), int.Parse(this.Session["CompanyId"].ToString()));
        clsWebFormUtil.FillDropDownList(this.drpDistributor, dt, 0, 2, true);
    }
    private void LoadArea()
    {
        if (drpDistributor.Items.Count > 0)
        {
            DistributorAreaController mController = new DistributorAreaController();
            DataTable dt = mController.SelectDist_Area(Constants.LongNullValue, Constants.DateNullValue, Constants.DateNullValue, int.Parse(drpDistributor.SelectedValue.ToString()), Constants.IntNullValue, null, null);
            clsWebFormUtil.FillDropDownList(DrpRoute, dt, 0, 6, true);
        }
        else
        {
            DrpRoute.Items.Clear();
        }
    }
    //private void LoadPendingOrder()
    //{
    //    OrderEntryController or = new OrderEntryController();
    //    DataTable dtOrder = or.SelectPendingOrder(int.Parse(drpDistributor.SelectedValue.ToString()), int.Parse(DrpRoute.SelectedValue.ToString()),
    //        int.Parse(DrpPrincipal.SelectedValue.ToString()), int.Parse(DrpOrderBooker.SelectedValue.ToString()), int.Parse(DrpDeliveryMan.SelectedValue.ToString()),
    //        Constants.Order_Pending_Id, int.Parse(ddSearchType.SelectedValue.ToString()), int.Parse(this.Session["UserId"].ToString()), Convert.ToDateTime(txtToDate.Text));
    //    GrdOrder.DataSource = dtOrder;
    //    GrdOrder.DataBind();
    //}

    //private void LoadOrderBooker()
    //{
    //    if (drpDistributor.Items.Count > 0 && DrpRoute.Items.Count > 0)
    //    {
    //        Distributor_UserController mDController = new Distributor_UserController();
    //        DataTable m_dt = mDController.SelectSaleForceAssignedArea(Constants.SALES_FORCE_ORDERBOOKER, int.Parse(drpDistributor.SelectedValue.ToString()), int.Parse(DrpRoute.SelectedValue.ToString()), int.Parse(this.Session["CompanyId"].ToString()));
    //        clsWebFormUtil.FillDropDownList(this.DrpOrderBooker, m_dt, 0, 3, true);
    //    }
    //    else
    //    {
    //        DrpOrderBooker.Items.Clear();
    //    }
    //}
    private void LoadPrincipal()
    {
        SKUPriceDetailController PController = new SKUPriceDetailController();
        DataTable m_dt = PController.SelectDataPrice(Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, int.Parse(this.Session["UserId"].ToString()), Constants.IntNullValue, 0, DateTime.Parse(this.Session["CurrentWorkDate"].ToString()));
        clsWebFormUtil.FillDropDownList(this.DrpPrincipal, m_dt, 0, 1, true);
    }
   
    private void LoadDeliveryman()
    {
        if (drpDistributor.Items.Count > 0 && DrpRoute.Items.Count > 0)
        {
            Distributor_UserController mDController = new Distributor_UserController();
            DataTable m_dt = mDController.SelectSaleForceAssignedArea(int.Parse(drpDistributor.SelectedValue.ToString()), int.Parse(DrpRoute.SelectedValue.ToString()), int.Parse(this.Session["CompanyId"].ToString()));
            clsWebFormUtil.FillDropDownList(this.DrpDeliveryMan, m_dt, 0, 3, true);
        }
        else
        {
            DrpDeliveryMan.Items.Clear();
        }
    }
    
    private void LoadSalePerson()
    {
        if (drpDistributor.Items.Count > 0 && DrpRoute.Items.Count > 0)
        {
            Distributor_UserController mDController = new Distributor_UserController();
            DataTable m_dt = mDController.SelectSaleForceAssignedArea(Constants.SALES_FORCE_SALESPERSON, int.Parse(drpDistributor.SelectedValue.ToString()), int.Parse(DrpRoute.SelectedValue.ToString()));
            clsWebFormUtil.FillDropDownList(this.DrpDeliveryMan, m_dt, 0, 3, true);
        }
        else
        {
            DrpDeliveryMan.Items.Clear();
        }
    }

    private void CreatTable()
    {
        PurchaseSKU = new DataTable();
        PurchaseSKU.Columns.Add("SKU_ID", typeof(int));
        PurchaseSKU.Columns.Add("SKU_Code", typeof(string));
        PurchaseSKU.Columns.Add("SKU_Name", typeof(string));
        PurchaseSKU.Columns.Add("SED_AMOUNT", typeof(decimal));
        PurchaseSKU.Columns.Add("QUANTITY_UNIT", typeof(int));
        PurchaseSKU.Columns.Add("AMOUNT", typeof(decimal));
        PurchaseSKU.Columns.Add("QUANTITY_CTN", typeof(decimal));
        PurchaseSKU.Columns.Add("IS_DELETED", typeof(bool));
        this.Session.Add("PurchaseSKU", PurchaseSKU);

        #region extra rows
        //PurchaseSKU.Columns.Add("SALE_ORDER_DETAIL_ID", typeof(long));
        //PurchaseSKU.Columns.Add("DistributorId", typeof(int));
        //PurchaseSKU.Columns.Add("SALE_ORDER_ID", typeof(int));
        //PurchaseSKU.Columns.Add("STANDARD_DISCOUNT", typeof(decimal));
        //PurchaseSKU.Columns.Add("STANDARD_DISCOUNT_PER", typeof(decimal));
        //PurchaseSKU.Columns.Add("EXTRA_DISCOUNT", typeof(decimal));
        //PurchaseSKU.Columns.Add("GST_RATE", typeof(decimal));
        //PurchaseSKU.Columns.Add("GST_AMOUNT", typeof(decimal));
        //PurchaseSKU.Columns.Add("NET_AMOUNT", typeof(decimal));
        //PurchaseSKU.Columns.Add("BATCH_NO", typeof(string));
        #endregion

    }
    private void CreateFreeSKU()
    {
        dtFreeSKU = new DataTable();
        dtFreeSKU.Columns.Add("SKU_ID", typeof(int));
        dtFreeSKU.Columns.Add("SKU_Code", typeof(string));
        dtFreeSKU.Columns.Add("SKU_Name", typeof(string));
        dtFreeSKU.Columns.Add("UNIT_PRICE", typeof(decimal));
        dtFreeSKU.Columns.Add("Quantity", typeof(int));
        dtFreeSKU.Columns.Add("AMOUNT", typeof(decimal));
        dtFreeSKU.Columns.Add("GST_RATE", typeof(decimal));
        dtFreeSKU.Columns.Add("GST_AMOUNT", typeof(decimal));
        dtFreeSKU.Columns.Add("PROMOTION_ID", typeof(int));
        dtFreeSKU.Columns.Add("BASKET_ID", typeof(int));
        dtFreeSKU.Columns.Add("BASKET_DETAIL_ID", typeof(int));
        dtFreeSKU.Columns.Add("PROMOTION_OFFER_ID", typeof(int));
        this.Session.Add("dtFreeSKU", dtFreeSKU);
    }
    private void EnableDisableController(bool CValue)
    {

        if (CValue == true)
        {
            //if (decimal.Parse(txtGrossAmount.Text) > 0)
            //{

            //    txtOutletCode.Enabled = true;
            //    txtOutletName.Enabled = true;

            //}
        }
        else
        {

            //txtOutletCode.Enabled = false;
            //txtOutletName.Enabled = false;

        }
    }
    private bool CheckDublicateSKU()
    {
        DataControl dc = new DataControl();
        DataTable Dtsku_Price = (DataTable)this.Session["Dtsku_Price"];
        PurchaseSKU = (DataTable)this.Session["PurchaseSKU"];
        DataRow[] foundRows = PurchaseSKU.Select("SKU_CODE  = '" + txtskuCode.Text + "'");
        if (foundRows.Length == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.LoadDistributor();
            this.LoadArea();
            this.LoadDeliveryman();
            this.LoadPrincipal();
            this.LoadSKUDetail();
            this.CreatTable();
            drpDocumentNo.Enabled = true;
            drpDocumentNo.Items.Add(new clsListItems("New", Constants.LongNullValue.ToString()));
            DateTime pOrderDate = DateTime.Parse(this.Session["CurrentWorkDate"].ToString()).AddDays(1);
            drpDocumentNo.SelectedIndex = 0;
            

            //txtToDate.Text = pOrderDate.ToString("dd-MMM-yyyy");
        }
        #region check
        //int OrderNo = (int)this.Session["OrderNo"];

            //if (OrderNo == -2)
            //{
            //    RblPayMode.Items.Add(new ListItem("Sale Return", "10"));
            //    //RblPayMode.Items.Add(new ListItem("Demaged", "6"));
            //    btnSaveOrder.Text = "Sale Return";
            //    txtBillNo.Visible = false;
            //    lblBillNo.Visible = false;
            //    ScriptManager.GetCurrent(Page).SetFocus(txtOutletCode);
            //}
            //else if (OrderNo == -1)
            //{
            //    txtGrossAmount.Enabled = false;
            //    numtxtTotalExtraDiscnt.Enabled = false;
            //    numTxtTotalStndrdDiscnt.Enabled = false;
            //    numTxtTotalGST.Enabled = false;
            //    numTxtTotlAmnt.Enabled = false;
            //    txtCashReceived.Enabled = false;
            //    RblPayMode.Items.Add(new ListItem("Empty In", "11"));
            //    btnSaveOrder.Text = "Save Empty In";
            //    this.LoadPendingOrder(Constants.Order_EmptyIn);
            //}
            //else if (OrderNo == 0)
            //{
            //    RblPayMode.Items.Add(new ListItem("Cash", "214"));
            //    RblPayMode.Items.Add(new ListItem("Credit", "215"));
            //    this.LoadPendingOrder(Constants.Order_Pending_Id);
            //}
            //else
            //{
            //    RblPayMode.Items.Add(new ListItem("Cash", "214"));
            //    RblPayMode.Items.Add(new ListItem("Credit", "215"));
            //    }

            //RblPayMode.SelectedIndex = 0;

            //this.LoadCustomerData();
            //this.LoadSKUDetail();
            //this.CreatTable();
            //this.LoadPromotion();
            //this.CreateFreeSKU();
            //this.LoadFreeGrid();

        //ScriptManager.GetCurrent(Page).SetFocus(txtBillNo);
        #endregion
        btnSave.Attributes.Add("onclick", "return ValidateForm();");

        
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {

        DataControl dc = new DataControl();
        DataTable Dtsku_Price = (DataTable)this.Session["Dtsku_Price"];
        PurchaseSKU = (DataTable)this.Session["PurchaseSKU"];
        DataRow[] foundRows = Dtsku_Price.Select("SKU_CODE  = '" + txtskuCode.Text + "'");

        int mPackSize = int.Parse(dc.chkNull_0(foundRows[0]["UNITS_IN_CASE"].ToString()));

        if (btnSave.Text == "Add Sku")
        {
            if (CheckDublicateSKU())
            {
                DataRow dr = PurchaseSKU.NewRow();
                dr["SKU_ID"] = foundRows[0]["SKU_ID"];
                dr["SKU_Code"] = foundRows[0]["SKU_CODE"];
                dr["SKU_Name"] = foundRows[0]["SKU_NAME"];

                dr["QUANTITY_UNIT"] = int.Parse(dc.chkNull_0(txtQuantity.Text));
                dr["QUANTITY_CTN"] = 0;

                dr["SED_AMOUNT"] = Convert.ToInt32(dc.chkNull_0(txtReturn.Text));
                dr["Amount"] = Convert.ToInt32(dc.chkNull_0(txtSold.Text));
                PurchaseSKU.Rows.Add(dr);
                txtSold.Text = "";
                drpDocumentNo.Enabled = true;
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('SKU Already Exists')", true);
            }
        }
        else
        {
            DataRow dr = PurchaseSKU.Rows[RowId];
            dr["SKU_ID"] = foundRows[0]["SKU_ID"];
            dr["SKU_Code"] = foundRows[0]["SKU_CODE"];
            dr["SKU_Name"] = foundRows[0]["SKU_NAME"];
            dr["SED_AMOUNT"] = Convert.ToInt32(dc.chkNull_0(txtReturn.Text));
            dr["QUANTITY_UNIT"] = int.Parse(dc.chkNull_0(txtQuantity.Text));
            dr["Amount"] = int.Parse(dc.chkNull_0(txtSold.Text));
            //dr["UNIT_PRICE"] = mTradePrice.ToString();
            //dr["AMOUNT"] = mTradePrice * decimal.Parse(dr["QUANTITY_UNIT"].ToString());

            txtSold.Text = "";
            drpDocumentNo.Enabled = true;

        }

        this.Session.Add("PurchaseSKU", PurchaseSKU);
        this.EnableDisableController(false);
        this.LoadGird();
        this.ClearAll();
        ScriptManager.GetCurrent(Page).SetFocus(txtskuCode);

        decimal ObjGrossSales = 0;
        decimal ObjTaxableAmount = 0;
        foreach (DataRow dr in PurchaseSKU.Rows)
        {
            ObjGrossSales += decimal.Parse(dc.chkNull_0(dr["AMOUNT"].ToString()));
            
        }
    }
    private void LoadGird()
    {
        PurchaseSKU = (DataTable)this.Session["PurchaseSKU"];
        GrdPurchase.DataSource = PurchaseSKU;
        GrdPurchase.DataBind();
    }
    private void ClearAll()
    {
        txtskuCode.Text = "";
        txtskuName.Text = "";
        txtQuantity.Text = "";
        txtReturn.Text = "";
        txtskuCode.Enabled = true;
        btnSave.Text = "Add Sku";
        btnSaveOrder.Enabled = true;
    }
    private void ClearMasterALL()
    {

        this.Session.Remove("PurchaseSKU");
        this.Session.Remove("dtFreeSKU");
        this.CreatTable();
        this.CreateFreeSKU(); 
        this.LoadGird();
        RowId = 0;

        //txtGrossAmount.Text = "";
        //numtxtTotalExtraDiscnt.Text = "";
        //numTxtTotalStndrdDiscnt.Text = "";
        //numTxtTotalHalfScheme.Text = "0.0000";
        //numTxtTotalGST.Text = "";
        //numTxtTotlAmnt.Text = "";
        //mCustomerTypeId = 0;
        //mCustomerVolClassId = 0;
        //txtBillNo.Text = string.Empty;
        //txtCashReceived.Text = "";
    }
    protected void drpDistributor_SelectedIndexChanged(object sender, EventArgs e)
    {

        this.LoadArea();
        this.LoadDeliveryman();
        
    }
   
    protected void GrdPurchase_RowEditing(object sender, GridViewEditEventArgs e)
    {
        RowId = e.NewEditIndex; 
        txtskuCode.Text   = GrdPurchase.Rows[e.NewEditIndex].Cells[1].Text;
        txtskuName.Text   = GrdPurchase.Rows[e.NewEditIndex].Cells[2].Text;
        txtQuantity.Text = GrdPurchase.Rows[e.NewEditIndex].Cells[3].Text;
        txtReturn.Text = GrdPurchase.Rows[e.NewEditIndex].Cells[4].Text;
        txtSold.Text = GrdPurchase.Rows[e.NewEditIndex].Cells[5].Text;
        
        txtskuCode.Enabled = false;
        btnSave.Text = "Update SKU"; 

    }
   

    protected void GrdPurchase_RowDeleting1(object sender, GridViewDeleteEventArgs e)
    {
        DataControl dc = new DataControl();
        PurchaseSKU = (DataTable)this.Session["PurchaseSKU"];
        PurchaseSKU.Rows.RemoveAt(e.RowIndex);

        decimal ObjGrossSales = 0;
        decimal StdDiscount = 0;
        decimal GSTAmount = 0;
        decimal NetAmount = 0;

        foreach (DataRow dr in PurchaseSKU.Rows)
        {
            ObjGrossSales += decimal.Parse(dc.chkNull_0(dr["AMOUNT"].ToString()));
            StdDiscount += decimal.Parse(dc.chkNull_0(dr["STANDARD_DISCOUNT"].ToString()));
            GSTAmount += decimal.Parse(dc.chkNull_0(dr["GST_AMOUNT"].ToString()));
            NetAmount += decimal.Parse(dc.chkNull_0(dr["NET_AMOUNT"].ToString()));
        }

        //txtGrossAmount.Text = Convert.ToString(Math.Round(ObjGrossSales, 2));
        //numTxtTotalStndrdDiscnt.Text = Convert.ToString(Math.Round(StdDiscount, 2));
        //numTxtTotalGST.Text = Convert.ToString(Math.Round(GSTAmount, 2));
        //numTxtTotlAmnt.Text = Convert.ToString(Math.Round(NetAmount, 2));

        this.Session.Add("PurchaseSKU", PurchaseSKU);
        this.LoadGird();

    }
    protected void txtQuantity_TextChanged(object sender, EventArgs e)
    {

    }
    protected void txtReturn_TextChanged(object sender, EventArgs e)
    {
        int issued = Convert.ToInt32(txtQuantity.Text);
        int retrn = Convert.ToInt32(txtReturn.Text);
        txtSold.Text = Convert.ToString(issued-retrn);
    }
    protected void DrpPrincipal_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void drpDocumentNo_SelectedIndexChanged(object sender, EventArgs e)
    {

        {
            if (long.Parse(drpDocumentNo.SelectedValue.ToString()) != Constants.LongNullValue)
            {

                DataTable dt = (DataTable)this.Session["dtOrder"];
                DataRow[] foundRows = dt.Select("SALE_ORDER_ID  = '" + drpDocumentNo.SelectedValue + "'");
                if (foundRows.Length > 0)
                {
                    this.ClearAll();
                    ScriptManager.GetCurrent(Page).SetFocus(txtskuCode);
                }

            }
            else
            {

                this.CreateFreeSKU();
                this.CreatTable();
                this.LoadGird();
                ClearMasterALL();
                this.Session.Remove("hfBillBookNo");

            }
        }
    }
    protected void btnSaveOrder_Click(object sender, EventArgs e)

    {
            DataControl DC = new DataControl();
            PurchaseSKU = (DataTable)this.Session["PurchaseSKU"];
            dtFreeSKU = (DataTable)this.Session["dtFreeSKU"];
            OrderEntryController mOrderController = new OrderEntryController();

            if (btnSaveOrder.Text == "Save Order")
            {
                
                    bool IsValidInsert = mOrderController.IssueReturn(int.Parse(this.Session["DistributorId"].ToString()), int.Parse(this.Session["PrincipalId"].ToString()), (long)this.Session["AreaId"],int.Parse(this.Session["DeliveryManId"].ToString()), PurchaseSKU, int.Parse(this.Session["UserId"].ToString()), DateTime.Parse(this.Session["OrderDate"].ToString()));
                    if (IsValidInsert)
                    {
                        //this.LoadPendingOrder(Constants.Order_Pending_Id);
                        //ScriptManager.GetCurrent(Page).SetFocus(txtOutletCode);
                        this.ClearMasterALL();
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('This Bill No already exist,Kindly enter different Bill No');", true);
                }
            }
            
        

    }
