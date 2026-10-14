using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using SAMS.BusinessLayer.Classes;
using SAMS.Common.Classes;    

public partial class Forms_frmPurchaseEntry : System.Web.UI.Page
{
    SKUPriceDetailController PController = new SKUPriceDetailController();
    DataControl dc = new DataControl();
    private static int RowNo;
    private static int PrivouseQty, FreePrivousQty;
    DataTable PurchaseSKU;
    private void CreatTable()
    {
        PurchaseSKU = new DataTable();
        PurchaseSKU.Columns.Add("PURCHASE_DETAIL_ID", typeof(long));
        PurchaseSKU.Columns.Add("SKU_ID", typeof(int));
        PurchaseSKU.Columns.Add("SKU_Code", typeof(string));
        PurchaseSKU.Columns.Add("SKU_Name", typeof(string));
        PurchaseSKU.Columns.Add("BATCH_NO", typeof(string));
        PurchaseSKU.Columns.Add("PRICE", typeof(decimal));
        PurchaseSKU.Columns.Add("Quantity", typeof(int));
        PurchaseSKU.Columns.Add("FREE_SKU", typeof(int));
        PurchaseSKU.Columns.Add("AMOUNT", typeof(decimal));
        this.Session.Add("PurchaseSKU", PurchaseSKU);  
    
    }
    private void GetDocumentNo()
    {
        drpDocumentNo.Items.Clear();   
        DateTime MWorkDate = System.DateTime.Now;
        PurchaseController mPurchase = new PurchaseController();
        DataTable dt = mPurchase.SelectPurchaseDocumentNo(int.Parse(DrpDocumentType.SelectedValue.ToString()),Constants.IntNullValue,Constants.LongNullValue,int.Parse(this.Session["UserId"].ToString()),0);
        drpDocumentNo.Items.Add(new clsListItems("New", Constants.LongNullValue.ToString()));          
        clsWebFormUtil.FillDropDownList(this.drpDocumentNo, dt, 0, 0);
    }
    private void LoadPrincipal()
    {
        DataTable m_dt = PController.SelectDataPrice(Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, int.Parse(this.Session["UserId"].ToString()), Constants.IntNullValue, 0, DateTime.Parse(this.Session["CurrentWorkDate"].ToString()));
        clsWebFormUtil.FillDropDownList(this.drpPrincipal, m_dt, 0, 1,true);
    }
    private void LoadDistributor()
    {
        DistributorController DController = new DistributorController();
        DataTable dt = DController.SelectDistributorInfo(Constants.IntNullValue, int.Parse(this.Session["UserId"].ToString()), int.Parse(this.Session["CompanyId"].ToString()));
        clsWebFormUtil.FillDropDownList(this.drpDistributor, dt, 0, 2,true);
    }
    private void LoadToDistributor()
    {
        DistributorController DController = new DistributorController();
        DataTable dt = DController.SelectDistributorInfo(Constants.IntNullValue, Constants.IntNullValue, int.Parse(this.Session["CompanyId"].ToString()));
        clsWebFormUtil.FillDropDownList(this.DrpTransferFor, dt, 0, 2, true);
    }
    private void ClearAll()
    {
        txtskuCode.Text = "";
        txtskuName.Text = "";
        txtQuantity.Text = "";
        txtFreeSKU.Text = "0";
        txtBatchNo.Text = "N/A";
        txtskuCode.Enabled = true;
        btnSave.Text = "Add Sku";
        PrivouseQty = 0;
        FreePrivousQty = 0;
    }
    private void LoadGird()
    {
        int TotalValue = 0;
        PurchaseSKU = (DataTable)this.Session["PurchaseSKU"];
        GrdPurchase.DataSource = PurchaseSKU;
        GrdPurchase.DataBind();
        foreach (DataRow dr in PurchaseSKU.Rows)
        {
            TotalValue += int.Parse(dr["Quantity"].ToString());

        }
        txtTotalQuantity.Text = TotalValue.ToString(); 
    }
    private void DisAbaleOption(bool IsDisable)
    {
        if (IsDisable == true)
        {
            DrpDocumentType.Enabled = false;
            drpPrincipal.Enabled = false;
            drpDistributor.Enabled = false;
            drpDocumentNo.Enabled = false;
            
        }
        else
        {
            
            DrpDocumentType.Enabled = true;
            drpPrincipal.Enabled = true;
            drpDistributor.Enabled = true;
            drpDocumentNo.Enabled = true;
            drpDocumentNo.SelectedIndex = 0;
        }
    }
    private int CheckStockStatus(int SKU_ID)
    {
        if (DrpDocumentType.SelectedIndex == 0 || DrpDocumentType.SelectedIndex == 3 || DrpDocumentType.SelectedIndex == 5)
        {
            return -1;
        }
        else
        {
            PurchaseController mController = new PurchaseController();
            DataTable dt = mController.SelectSKUClosingStock(int.Parse(drpDistributor.SelectedValue.ToString()), SKU_ID,txtBatchNo.Text);
            if (dt.Rows.Count > 0)
            {
                if (int.Parse(dt.Rows[0][0].ToString()) + PrivouseQty + FreePrivousQty >= int.Parse(txtQuantity.Text))
                {
                    return -1;
                }
                else
                {
                    return int.Parse(dt.Rows[0][0].ToString()) + PrivouseQty + FreePrivousQty;
                }
            }
        }
              
        return 0; 
    }
    private bool CalculatePurchase(DateTime MWorkDate)
    {
        decimal mTotalAmount = 0;
           
        PurchaseController mController = new PurchaseController();
        DataTable  dtPurchaseDetail = (DataTable)this.Session["PurchaseSKU"];
        foreach (DataRow dr in dtPurchaseDetail.Rows)
        {
            mTotalAmount += decimal.Parse(dr["AMOUNT"].ToString());
                    
        }
        if (DrpDocumentType.SelectedIndex == 0 || DrpDocumentType.SelectedIndex == 5)//Raw Material Purchase and Production In
        {
            if (drpDocumentNo.SelectedValue.ToString() == Constants.LongNullValue.ToString())
            {
                bool mResult = mController.InsertPurchaseDocument(int.Parse(drpDistributor.SelectedValue.ToString()), txtDocumentNo.Text, int.Parse(DrpDocumentType.SelectedValue.ToString())
                , MWorkDate, int.Parse(drpDistributor.SelectedValue.ToString()), int.Parse(drpPrincipal.SelectedValue.ToString()), mTotalAmount, false, dtPurchaseDetail, 0, txtBuiltyNo.Text, int.Parse(this.Session["UserId"].ToString()),int.Parse(drpPrincipal.SelectedValue.ToString()));
                return mResult;
            }
            else
            {
                bool mResult = mController.UpdatePurchaseDocument(int.Parse(drpDocumentNo.SelectedValue.ToString()), int.Parse(drpDistributor.SelectedValue.ToString()), txtDocumentNo.Text, int.Parse(DrpDocumentType.SelectedValue.ToString())
                , MWorkDate, int.Parse(drpDistributor.SelectedValue.ToString()), int.Parse(drpPrincipal.SelectedValue.ToString()), mTotalAmount, false, dtPurchaseDetail, 0, txtBuiltyNo.Text, int.Parse(this.Session["UserId"].ToString()), int.Parse(drpPrincipal.SelectedValue.ToString()));
                return mResult;
            }
        }
        else if (DrpDocumentType.SelectedIndex == 1) 
        {
            if (drpDocumentNo.SelectedValue.ToString() == Constants.LongNullValue.ToString())
            {
                bool mResult = mController.InsertPurchaseDocument(int.Parse(drpDistributor.SelectedValue.ToString()), txtDocumentNo.Text, int.Parse(DrpDocumentType.SelectedValue.ToString())
                , MWorkDate, int.Parse(DrpTransferFor.SelectedValue.ToString()), int.Parse(drpDistributor.SelectedValue.ToString())
                , mTotalAmount, false, dtPurchaseDetail, 0, txtBuiltyNo.Text, int.Parse(this.Session["UserId"].ToString()), int.Parse(drpPrincipal.SelectedValue.ToString()));
                return mResult;
            }
            else
            {
                bool mResult = mController.UpdatePurchaseDocument(int.Parse(drpDocumentNo.SelectedValue.ToString()), int.Parse(drpDistributor.SelectedValue.ToString()), txtDocumentNo.Text, int.Parse(DrpDocumentType.SelectedValue.ToString())
                , MWorkDate, int.Parse(DrpTransferFor.SelectedValue.ToString()), int.Parse(drpDistributor.SelectedValue.ToString())
                , mTotalAmount, false, dtPurchaseDetail, 0, txtBuiltyNo.Text, int.Parse(this.Session["UserId"].ToString()), int.Parse(drpPrincipal.SelectedValue.ToString()));
                return mResult;
            }
        }
        else if (DrpDocumentType.SelectedIndex == 2)
        {
            if (drpDocumentNo.SelectedValue.ToString() == Constants.LongNullValue.ToString())
            {
                bool mResult = mController.InsertPurchaseDocument(int.Parse(drpDistributor.SelectedValue.ToString()), txtDocumentNo.Text, int.Parse(DrpDocumentType.SelectedValue.ToString())
                , MWorkDate, int.Parse(drpPrincipal.SelectedValue.ToString()), int.Parse(drpDistributor.SelectedValue.ToString())
                , mTotalAmount, false, dtPurchaseDetail, 0, txtBuiltyNo.Text, int.Parse(this.Session["UserId"].ToString()), int.Parse(drpPrincipal.SelectedValue.ToString()));
                return mResult;
            }
            else
            {
                bool mResult = mController.UpdatePurchaseDocument(int.Parse(drpDocumentNo.SelectedValue.ToString()), int.Parse(drpDistributor.SelectedValue.ToString()), txtDocumentNo.Text, int.Parse(DrpDocumentType.SelectedValue.ToString())
                , MWorkDate, int.Parse(drpPrincipal.SelectedValue.ToString()), int.Parse(drpDistributor.SelectedValue.ToString())
                , mTotalAmount, false, dtPurchaseDetail, 0, txtBuiltyNo.Text, int.Parse(this.Session["UserId"].ToString()), int.Parse(drpPrincipal.SelectedValue.ToString()));
                return mResult;
            }
        }
        else if (DrpDocumentType.SelectedIndex == 3)
        {
            if (drpDocumentNo.SelectedValue.ToString() == Constants.LongNullValue.ToString())
            {
                bool mResult = mController.InsertPurchaseDocument(int.Parse(drpDistributor.SelectedValue.ToString()), txtDocumentNo.Text, int.Parse(DrpDocumentType.SelectedValue.ToString())
                , MWorkDate, int.Parse(drpDistributor.SelectedValue.ToString()), int.Parse(DrpTransferFor.SelectedValue.ToString())
                , mTotalAmount, false, dtPurchaseDetail, 0, txtBuiltyNo.Text, int.Parse(this.Session["UserId"].ToString()), int.Parse(drpPrincipal.SelectedValue.ToString()));
                return mResult;
            }
            else
            {
                bool mResult = mController.UpdatePurchaseDocument(int.Parse(drpDocumentNo.SelectedValue.ToString()), int.Parse(drpDistributor.SelectedValue.ToString()), txtDocumentNo.Text, int.Parse(DrpDocumentType.SelectedValue.ToString())
                , MWorkDate, int.Parse(drpDistributor.SelectedValue.ToString()), int.Parse(DrpTransferFor.SelectedValue.ToString())
                , mTotalAmount, false, dtPurchaseDetail, 0, txtBuiltyNo.Text, int.Parse(this.Session["UserId"].ToString()), int.Parse(drpPrincipal.SelectedValue.ToString()));
                return mResult;
            }
        }
        else
        {
            if (drpDocumentNo.SelectedValue.ToString() == Constants.LongNullValue.ToString())
            {
                bool mResult = mController.InsertPurchaseDocument(int.Parse(drpDistributor.SelectedValue.ToString()), txtDocumentNo.Text, int.Parse(DrpDocumentType.SelectedValue.ToString())
                , MWorkDate, int.Parse(drpDistributor.SelectedValue.ToString()), int.Parse(drpPrincipal.SelectedValue.ToString())
                , mTotalAmount, false, dtPurchaseDetail, 0, txtBuiltyNo.Text, int.Parse(this.Session["UserId"].ToString()), int.Parse(drpPrincipal.SelectedValue.ToString()));
                return mResult;
            }
            else
            {
                bool mResult = mController.UpdatePurchaseDocument(int.Parse(drpDocumentNo.SelectedValue.ToString()), int.Parse(drpDistributor.SelectedValue.ToString()), txtDocumentNo.Text, int.Parse(DrpDocumentType.SelectedValue.ToString())
                , MWorkDate, int.Parse(drpDistributor.SelectedValue.ToString()), int.Parse(drpPrincipal.SelectedValue.ToString())
                , mTotalAmount, false, dtPurchaseDetail, 0, txtBuiltyNo.Text, int.Parse(this.Session["UserId"].ToString()), int.Parse(drpPrincipal.SelectedValue.ToString()));
                return mResult;
            }
        }
    }
    private void LoadSKUDetail(int CategoryID)
    {
        if (drpPrincipal.Items.Count > 0)
        {
            DataTable Dtsku_Price = PController.SelectDataPrice2(int.Parse(drpPrincipal.SelectedValue.ToString()), Constants.IntNullValue, CategoryID, Constants.IntNullValue, int.Parse(drpDistributor.SelectedValue.ToString()), int.Parse(this.Session["UserId"].ToString()), Constants.IntNullValue, 1, DateTime.Parse(this.Session["CurrentWorkDate"].ToString()));
            clsWebFormUtil.FillListBox(lstCode, Dtsku_Price, 9, 9, true);
            this.Session.Add("Dtsku_Price", Dtsku_Price);
        }
    }
    private void LoadDocumentDetail()
    {
            DateTime MWorkDate = System.DateTime.Now;
            PurchaseController mPurchase = new PurchaseController();
            DataTable dt = mPurchase.SelectPurchaseDocumentNo(Constants.IntNullValue,Constants.IntNullValue,long.Parse(drpDocumentNo.SelectedValue.ToString()),Constants.IntNullValue,Constants.IntNullValue);
            if (dt.Rows.Count > 0)
            {
                if (DrpDocumentType.SelectedIndex == 0 || DrpDocumentType.SelectedIndex == 4)
                {
                    drpDistributor.SelectedValue = dt.Rows[0]["SOLD_TO"].ToString();
                    drpPrincipal.SelectedValue = dt.Rows[0]["SOLD_FROM"].ToString();
                    txtDocumentNo.Text = dt.Rows[0][2].ToString();
                    txtBuiltyNo.Text = dt.Rows[0]["BUILTY_NO"].ToString();
                }
                else if (DrpDocumentType.SelectedIndex == 1)
                {
                    drpDistributor.SelectedValue = dt.Rows[0]["SOLD_FROM"].ToString();
                    DrpTransferFor.SelectedValue = dt.Rows[0]["SOLD_TO"].ToString();
                    txtDocumentNo.Text = dt.Rows[0][2].ToString();
                    txtBuiltyNo.Text = dt.Rows[0]["BUILTY_NO"].ToString();
                }
                else if (DrpDocumentType.SelectedIndex == 2)
                {
                    drpPrincipal.SelectedValue = dt.Rows[0]["SOLD_TO"].ToString();
                    drpDistributor.SelectedValue = dt.Rows[0]["SOLD_FROM"].ToString();
                    txtDocumentNo.Text = dt.Rows[0][2].ToString();
                    txtBuiltyNo.Text = dt.Rows[0]["BUILTY_NO"].ToString();
                }
                else
                {
                    DrpTransferFor.SelectedValue = dt.Rows[0]["SOLD_FROM"].ToString();
                    drpDistributor.SelectedValue = dt.Rows[0]["SOLD_TO"].ToString();
                    txtDocumentNo.Text = dt.Rows[0][2].ToString();
                    txtBuiltyNo.Text = dt.Rows[0]["BUILTY_NO"].ToString();
                }
                PurchaseSKU = mPurchase.SelectPurchaseDetail(Constants.IntNullValue, long.Parse(dt.Rows[0][0].ToString()));
                this.Session.Add("PurchaseSKU", PurchaseSKU);
                LoadGird();

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
            this.LoadPrincipal();
            this.LoadDistributor();
            this.LoadSKUDetail(Constants.Raw_Material_Category);
            this.CreatTable();
            this.GetDocumentNo();
            btnSave.Attributes.Add("onclick", "return ValidateForm();");            
            SAMS.Common.Classes.Configuration.SystemCurrentDateTime = (DateTime)this.Session["CurrentWorkDate"];             
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        
        DataTable Dtsku_Price = (DataTable)this.Session["Dtsku_Price"];
        PurchaseSKU = (DataTable)this.Session["PurchaseSKU"];
        DataRow[] foundRows = Dtsku_Price.Select("SKU_CODE  = '" + txtskuCode.Text + "'");
        if (foundRows.Length > 0)
        {
            decimal mStdDiscount = decimal.Parse(dc.chkNull_0(foundRows[0]["DISTRIBUTOR_DISCOUNT"].ToString()));
            decimal mGSTRate = decimal.Parse(dc.chkNull_0(foundRows[0]["GST_RATE_TP"].ToString()));
            int CurrentStock  = CheckStockStatus(int.Parse(dc.chkNull_0(foundRows[0]["SKU_ID"].ToString())));
           
                if (btnSave.Text == "Add Sku")
                {
                    if (CheckDublicateSKU())
                    {
                        if (CurrentStock == -1)
                        {
                            DataRow dr = PurchaseSKU.NewRow();
                            dr["SKU_ID"] = foundRows[0]["SKU_ID"];
                            dr["SKU_Code"] = foundRows[0]["SKU_CODE"];
                            dr["SKU_Name"] = foundRows[0]["SKU_NAME"];
                            dr["BATCH_NO"] = txtBatchNo.Text;
                            dr["FREE_SKU"] = int.Parse(dc.chkNull_0(txtFreeSKU.Text));
                            dr["PRICE"] = foundRows[0]["TRADE_PRICE"];
                            dr["Quantity"] = int.Parse(dc.chkNull_0(txtQuantity.Text));
                            dr["AMOUNT"] = decimal.Parse(foundRows[0]["TRADE_PRICE"].ToString()) * decimal.Parse(dc.chkNull_0(txtQuantity.Text));
                            PurchaseSKU.Rows.Add(dr);
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('  " + txtskuCode.Text + " Current closing Stock is " + CurrentStock.ToString() + "');", true);
                            txtskuName.Text = foundRows[0]["SKU_NAME"].ToString();
                            return;
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('  " + txtskuCode.Text + " Already Exists ');", true);
                        txtskuName.Text = foundRows[0]["SKU_NAME"].ToString();
                        return;
                    }
                }
                else if (btnSave.Text == "Update Sku")
                {
                    if (CurrentStock == -1)
                    {
                        DataRow dr = PurchaseSKU.Rows[RowNo];
                        dr["SKU_ID"] = foundRows[0]["SKU_ID"];
                        dr["SKU_Code"] = foundRows[0]["SKU_CODE"];
                        dr["SKU_Name"] = foundRows[0]["SKU_NAME"];
                        dr["BATCH_NO"] = txtBatchNo.Text;
                        dr["PRICE"] = foundRows[0]["TRADE_PRICE"];
                        dr["Quantity"] = int.Parse(txtQuantity.Text);
                        dr["FREE_SKU"] = int.Parse(dc.chkNull_0(txtFreeSKU.Text));
                        dr["AMOUNT"] = decimal.Parse(foundRows[0]["TRADE_PRICE"].ToString()) * decimal.Parse(dc.chkNull_0(txtQuantity.Text));
                        
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('  " + txtskuCode.Text + "Current closing Stock is " + CurrentStock.ToString() + "');", true); 
                        txtskuName.Text = foundRows[0]["SKU_NAME"].ToString();
                        return; 
                    }
                  
                }
                
                this.Session.Add("PurchaseSKU", PurchaseSKU);
                this.ClearAll();
                this.LoadGird();
                DisAbaleOption(true);
                ScriptManager.GetCurrent(Page).SetFocus(txtskuCode);
                   
            }
        
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('Wrong SKU Select');", true); 
        }       
     }
    protected void GrdPurchase_RowEditing(object sender, GridViewEditEventArgs e)
    {
        RowNo = e.NewEditIndex;
        txtskuCode.Text = GrdPurchase.Rows[e.NewEditIndex].Cells[1].Text;
        txtskuName.Text = GrdPurchase.Rows[e.NewEditIndex].Cells[2].Text;
        txtQuantity.Text = GrdPurchase.Rows[e.NewEditIndex].Cells[3].Text;
        PrivouseQty = int.Parse(GrdPurchase.Rows[e.NewEditIndex].Cells[3].Text);
        FreePrivousQty = int.Parse(GrdPurchase.Rows[e.NewEditIndex].Cells[4].Text);
        txtFreeSKU.Text = GrdPurchase.Rows[e.NewEditIndex].Cells[4].Text;
        txtBatchNo.Text = GrdPurchase.Rows[e.NewEditIndex].Cells[5].Text;
        txtskuCode.Enabled = false;
        txtQuantity.Focus();  
        btnSave.Text = "Update Sku"; 
      
    }
    protected void GrdPurchase_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        PurchaseSKU = (DataTable)this.Session["PurchaseSKU"];
        if (PurchaseSKU.Rows.Count > 0)
        {
            PurchaseSKU.Rows.RemoveAt(e.RowIndex);     
            this.Session.Add("PurchaseSKU", PurchaseSKU);
            this.LoadGird(); 
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        SAMS.Common.Classes.Configuration.SystemCurrentDateTime = (DateTime)this.Session["CurrentWorkDate"];     
        if (DrpDocumentType.SelectedIndex == 2)
        {
            if (drpDistributor.SelectedValue.ToString() == DrpTransferFor.SelectedValue.ToString())
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert(' Transfer to Location must be different ');", true); 
                return; 
            }
        }
        PurchaseSKU = (DataTable)this.Session["PurchaseSKU"];
        if (PurchaseSKU.Rows.Count > 0)
        {
               SAMSUserController mDayClose = new SAMSUserController();
               DataTable dt = mDayClose.SelectMaxDayClose(Constants.IntNullValue,int.Parse(drpDistributor.SelectedValue.ToString()));
               if (dt.Rows.Count > 0)
               {
                   if (CalculatePurchase(DateTime.Parse(dt.Rows[0]["CLOSING_DATE"].ToString())))
                   {
                       PurchaseSKU = (DataTable)this.Session["PurchaseSKU"];
                       PurchaseSKU.Rows.Clear();
                       this.Session.Add("PurchaseSKU", PurchaseSKU);
                       this.LoadGird();
                       this.GetDocumentNo();
                       drpDistributor.Enabled = true;
                       drpPrincipal.Enabled = true;
                       DrpDocumentType.Enabled = true;
                       this.ClearAll();
                       txtBuiltyNo.Text = "";
                       txtDocumentNo.Text = ""; 
                       txtDocumentNo.Text = "";
                       DisAbaleOption(false);
                   }
               }
               else
               {
                   ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('Wrong Location');", true);  
               }
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert(' At least one SKU must enter');", true);  
            
        }

    }
    protected void DrpDocumentType_SelectedIndexChanged(object sender, EventArgs e)
    {        
        if (DrpDocumentType.SelectedIndex == 0)
        {
            LoadSKUDetail(Constants.Raw_Material_Category);
            lbltoLocation.Text = "Principal";
            lblfromLocation.Text = "Purchase For";
            drpDistributor.Enabled = true;
            drpPrincipal.Enabled = true;
            this.DrpTransferFor.Visible = false;
            Label4.Visible = false;
            this.GetDocumentNo();
        }
        else if (DrpDocumentType.SelectedIndex == 1)
        {
            LoadSKUDetail(Constants.IntNullValue);
            lblfromLocation.Text = "Transfer From";
            drpDistributor.Enabled = true;
            drpPrincipal.Enabled = true;
            LoadToDistributor();
            this.DrpTransferFor.Visible = true;
            Label4.Visible = true;
            Label4.Text = "Transfer To";
            this.GetDocumentNo();
        }
        else if (DrpDocumentType.SelectedIndex == 2)
        {
            LoadSKUDetail(Constants.IntNullValue);
            lbltoLocation.Text = "Principal";
            lblfromLocation.Text = "Return From";
            drpDistributor.Enabled = true;
            drpPrincipal.Enabled = true;
            this.DrpTransferFor.Visible = false;
            Label4.Visible = false;
            this.GetDocumentNo();
        }
        else if (DrpDocumentType.SelectedIndex == 3)
        {
            LoadSKUDetail(Constants.IntNullValue);
            lblfromLocation.Text = "Transfer to";
            drpDistributor.Enabled = true;
            drpPrincipal.Enabled = true;
            LoadToDistributor();
            this.DrpTransferFor.Visible = true;
            Label4.Visible = true;
            Label4.Text = "Transfer From";
            this.GetDocumentNo();
        }
        else
        {
            LoadSKUDetail(Constants.IntNullValue);
            lbltoLocation.Text = "Principal";
            lblfromLocation.Text = "Location";
            drpDistributor.Enabled = true;
            drpPrincipal.Enabled = true;
            this.DrpTransferFor.Visible = false;
            Label4.Visible = false;
            this.GetDocumentNo();
        }
       
        
    }
    protected void drpDocumentNo_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (drpDocumentNo.SelectedValue.ToString() == Constants.LongNullValue.ToString())
        {
            this.CreatTable(); 
            this.Session.Add("PurchaseSKU", PurchaseSKU);
            LoadGird();
            this.ClearAll(); 
            drpPrincipal.Enabled = true;
            drpDistributor.Enabled = true;
            DrpDocumentType.Enabled = true;            
        }
        else 
        {
            txtBuiltyNo.Text = "";
            txtDocumentNo.Text = ""; 
            drpPrincipal.Enabled = false;
            drpDistributor.Enabled = false;
            DrpDocumentType.Enabled = false;
            this.LoadDocumentDetail();
            this.LoadSKUDetail(Constants.Raw_Material_Category); 
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {

            DisAbaleOption(false);    
            this.CreatTable(); 
            this.LoadGird();
            this.ClearAll(); 
            txtDocumentNo.Text = ""; 
            txtBuiltyNo.Text = "";
            txtDocumentNo.Text = ""; 
         
    }
    protected void drpPrincipal_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DrpDocumentType.SelectedIndex == 0)
        {
            this.LoadSKUDetail(Constants.Raw_Material_Category);
        }
        else
        {
            this.LoadSKUDetail(Constants.IntNullValue);
        }
    }
    protected void ChbBatchNo_CheckedChanged(object sender, EventArgs e)
    {
        if (ChbBatchNo.Checked == true)
        {
            lblBatchNo.Enabled = true;
            txtBatchNo.Enabled = true;
        }
        else
        {
            txtBatchNo.Text = "N/A"; 
            lblBatchNo.Enabled = false;
            txtBatchNo.Enabled = false;
        }
    }
    protected void ChbFreeSKU_CheckedChanged(object sender, EventArgs e)
    {
        if (ChbFreeSKU.Checked == true)
        {
            lblFreeSKU.Enabled = true;
            txtFreeSKU.Enabled = true;
        }
        else
        {
            txtFreeSKU.Text = "0";
            lblFreeSKU.Enabled = false;
            txtFreeSKU.Enabled = false;
        }
    }
    protected void DrpTransferFor_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
