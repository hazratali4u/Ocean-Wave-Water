using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using SAMS.BusinessLayer.Classes;
using SAMS.Common.Classes;
    
public partial class Forms_frmOrderEntryStep1 : System.Web.UI.Page
{    
    private void LoadDistributor()
    {
        DistributorController DController = new DistributorController();
        DataTable dt = DController.SelectDistributorInfo(Constants.IntNullValue, int.Parse( Session["UserId"].ToString()), int.Parse( Session["CompanyId"].ToString()));
        clsWebFormUtil.FillDropDownList( drpDistributor, dt, 0, 2, true);
    }
    private void LoadArea()
    {
        if (drpDistributor.Items.Count > 0)
        {
            var mController = new DistributorAreaController();
            DataTable dt = mController.SelectDist_Area(Constants.LongNullValue, Constants.DateNullValue, Constants.DateNullValue, int.Parse(drpDistributor.SelectedValue.ToString()),Constants.IntNullValue, null, null);
            clsWebFormUtil.FillDropDownList(DrpRoute, dt, 0, 6, true);
        }
        else
        {
            DrpRoute.Items.Clear();
        }
    }
    private void LoadPendingOrder()
    {
        OrderEntryController or = new OrderEntryController();
        DataTable dtOrder = or.SelectPendingOrder(int.Parse(drpDistributor.SelectedValue.ToString()), Constants .IntNullValue,
            int.Parse(DrpPrincipal.SelectedValue.ToString()), Constants .IntNullValue , int.Parse(DrpDeliveryMan.SelectedValue.ToString()),
            Constants.Order_Pending_Id, int.Parse(ddSearchType.SelectedValue.ToString()), int.Parse( Session["UserId"].ToString()), Convert.ToDateTime(txtToDate.Text));
        GrdOrder.DataSource = dtOrder;
        GrdOrder.DataBind(); 
    }
    private void LoadPrincipal()
    {
        var PController = new SKUPriceDetailController();
        DataTable m_dt = PController.SelectDataPrice(Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, int.Parse( Session["UserId"].ToString()), Constants.IntNullValue, 0, DateTime.Parse( Session["CurrentWorkDate"].ToString()));
        clsWebFormUtil.FillDropDownList( DrpPrincipal, m_dt, 0, 1, true);
    }
    private void LoadOrderBooker()
    {
        if (drpDistributor.Items.Count > 0 && DrpRoute.Items.Count > 0)
        {
            var mDController = new Distributor_UserController();
         //  DataTable m_dt = mDController.SelectSaleForceAssignedArea(Constants.SALES_FORCE_ORDERBOOKER, int.Parse(drpDistributor.SelectedValue.ToString()), int.Parse(DrpRoute.SelectedValue.ToString()), int.Parse( Session["CompanyId"].ToString()));
          //  DataTable m_dt = mDController.SelectSaleForceAssignedAreaCustomer(Constants.SALES_FORCE_ORDERBOOKER, int.Parse(drpDistributor.SelectedValue.ToString()), int.Parse(DrpRoute.SelectedValue.ToString()), int.Parse( Session["CompanyId"].ToString()));
            DataTable m_dt = mDController.SelectSaleForceAssignedArea(Constants.SALES_FORCE_ORDERBOOKER, int.Parse(drpDistributor.SelectedValue.ToString()), Constants .IntNullValue , int.Parse( Session["CompanyId"].ToString()));
         
            clsWebFormUtil.FillDropDownList( DrpOrderBooker, m_dt, 0, 3, true);
        }
        else
        {
            DrpOrderBooker.Items.Clear();
        }
    }
    private void LoadDeliveryman()
    {
        if (drpDistributor.Items.Count > 0 && drpDayofWeak .Items.Count > 0)
        {
            Distributor_UserController mDController = new Distributor_UserController();
         //   DataTable m_dt = mDController.SelectSaleForceAssignedArea(int.Parse(drpDistributor.SelectedValue.ToString()), int.Parse(DrpRoute.SelectedValue.ToString()), int.Parse( Session["CompanyId"].ToString()));
            DataTable m_dt = mDController.SelectSaleForceAssignedAreaCustomer2(int.Parse(drpDistributor.SelectedValue.ToString()), Constants.IntNullValue, int.Parse( Session["CompanyId"].ToString()),int.Parse (drpDayofWeak .SelectedValue ));
          
            
            clsWebFormUtil.FillDropDownList( DrpDeliveryMan, m_dt, 0, 3, true);
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
            DataTable m_dt = mDController.SelectSaleForceAssignedAreaCustomer(Constants.SALES_FORCE_SALESPERSON, int.Parse(drpDistributor.SelectedValue.ToString()), int.Parse(DrpRoute.SelectedValue.ToString()), int.Parse( Session["CompanyId"].ToString()));
            clsWebFormUtil.FillDropDownList( DrpDeliveryMan, m_dt, 0, 3, true);
            clsWebFormUtil.FillDropDownList( DrpOrderBooker, m_dt, 0, 3, true);
        }
        else
        {
            DrpDeliveryMan.Items.Clear();
            DrpOrderBooker.Items.Clear();   
        }
    }
    private void LoadDay_OF_Weak()
    {
        DistributorController mController = new DistributorController();
        DataTable dt = mController.SelectDayOf_Weak();
        clsWebFormUtil.FillDropDownList(drpDayofWeak, dt, 0, 1, true);

    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            DateTime pOrderDate = (DateTime)Session["CurrentWorkDate"];
            txtToDate.Text = pOrderDate.ToString("dd-MMM-yyyy");
        //  if (DrpDocumentType.SelectedIndex == 1)
        //{
            txtToDate.Enabled = false;
            ImgBntToDate.Visible = false;
            
       // }
        //else
        //{
            
            
        //    txtToDate.Enabled = true;
        //    ImgBntToDate.Visible = true;
        //}
             LoadDay_OF_Weak();
             LoadDistributor();
             LoadArea();
          //   LoadOrderBooker();
             LoadDeliveryman();
             LoadPrincipal();
            
           // DateTime pOrderDate = DateTime.Parse( Session["CurrentWorkDate"].ToString()).AddDays(1);
         //   txtToDate.Text = pOrderDate.ToString("dd-MMM-yyyy");   
        }
    }
    protected void btnNext_Click(object sender, EventArgs e)
    {
        if (drpDistributor.Items.Count > 0 && DrpPrincipal.Items.Count > 0 && drpDayofWeak .Items.Count > 0 && DrpDeliveryMan.Items.Count > 0)
        {
             Session.Add("DistributorId", int.Parse(drpDistributor.SelectedValue.ToString()));
             Session.Add("PrincipalId", int.Parse(DrpPrincipal.SelectedValue.ToString()));
             Session.Add("Principal", DrpPrincipal.SelectedItem .Text );
             Session.Add("DayId", long.Parse(drpDayofWeak .SelectedValue.ToString()));
       //      Session.Add("Route", DrpRoute.SelectedItem.Text);
             Session.Add("SaleMan", DrpDeliveryMan.SelectedItem.Text);
             Session.Add("OrderDate", Convert.ToDateTime(txtToDate.Text).ToString("dd-MMM-yyyy"));
             Session.Add("UnitType", RbUnitType.SelectedIndex);
        //     Session.Add("OrderBookerId", "");
             Session.Add("DeliveryManId", int.Parse(DrpDeliveryMan.SelectedValue.ToString()));

         //   if (DrpDocumentType.SelectedIndex == 0)
            //{
          //       Session.Add("OrderNo", 0);
         //   }
            if (DrpDocumentType.SelectedIndex == 0)
            {
                 Session.Add("OrderNo", -2);
            }
           
            else
            {
                 Session.Add("OrderNo", -3);
            }

            Response.Redirect("~/Forms/frmOrderEntry.aspx?Status=" + false + "&LevelType=3&LevelID=" + Request.QueryString["LevelID"].ToString());
        }
    }
    protected void drpDistributor_SelectedIndexChanged(object sender, EventArgs e)
    {
         LoadArea();
         LoadOrderBooker();
         LoadDeliveryman();
        
    }
    protected void DrpRoute_SelectedIndexChanged(object sender, EventArgs e)
    {
         LoadOrderBooker();
         LoadDeliveryman();
    }
    protected void DrpDocumentType_SelectedIndexChanged(object sender, EventArgs e)
    {
        //if (DrpDocumentType.SelectedIndex == 0)
        //{
        //    DateTime pOrderDate = DateTime.Parse( Session["CurrentWorkDate"].ToString()).AddDays(1);
        //    txtToDate.Text = pOrderDate.ToString("dd-MMM-yyyy");
        //    txtToDate.Enabled = true;
        //    ImgBntToDate.Visible = true;
        //}
        DateTime pOrderDate = (DateTime)Session["CurrentWorkDate"];
        txtToDate.Text = pOrderDate.ToString("dd-MMM-yyyy");
        //if (DrpDocumentType.SelectedIndex == 1)
        //{
           
            txtToDate.Enabled = false;
            ImgBntToDate.Visible = false;
            
        //}
        //else
        //{
           
        //    txtToDate.Enabled = true;
        //    ImgBntToDate.Visible = true;
        //}
    }
    protected void btnGetOrder_Click(object sender, EventArgs e)
    {
         LoadPendingOrder(); 
    }
    protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
    {
        if (CheckBox1.Checked == true)
        {
            foreach (GridViewRow dr in GrdOrder.Rows)
            {
                CheckBox ChbInvoice = (CheckBox)dr.FindControl("ChbInvoice");
                ChbInvoice.Checked = true;
            }
        }
        else
        {
            foreach (GridViewRow dr in GrdOrder.Rows)
            {
                CheckBox ChbInvoice = (CheckBox)dr.FindControl("ChbInvoice");
                ChbInvoice.Checked = false;
            }
        }
    }
    protected void btnPost_Click(object sender, EventArgs e)
    {
        CustomerDataController CDC = new CustomerDataController();
        OrderEntryController ORD = new OrderEntryController(); 
        DataControl dc = new DataControl();
        DataTable dtStock;
        GrdFreeSKU.Visible = false;
        foreach (GridViewRow dr in GrdOrder.Rows)
         {
            CheckBox ChbInvoice = (CheckBox)dr.FindControl("ChbInvoice");
            if (ChbInvoice.Checked == true)
            {
                if (Convert.ToDateTime( Session["CurrentWorkDate"]) >= Convert.ToDateTime(ConvertDate.British_To_American2(dr.Cells[5].Text)))
                {
                    if (int.Parse(ddSearchType.SelectedValue.ToString()) == Constants.Cash_Order_Id)
                    {
                        dtStock = ORD.ConvertOrder_to_Invoice(int.Parse(drpDistributor.SelectedValue.ToString()), long.Parse(dr.Cells[0].Text), int.Parse(DrpPrincipal.SelectedValue.ToString()),
                        long.Parse(dr.Cells[4].Text), DateTime.Parse( Session["CurrentWorkDate"].ToString()), decimal.Parse(dc.chkNull_0(dr.Cells[6].Text)), decimal.Parse(dc.chkNull_0(dr.Cells[7].Text)),
                        decimal.Parse(dc.chkNull_0(dr.Cells[8].Text)), decimal.Parse(dc.chkNull_0(dr.Cells[9].Text)), decimal.Parse(dc.chkNull_0(dr.Cells[10].Text)), Constants.Order_Posted_Id, Constants.Cash_Order_Id, int.Parse( Session["UserId"].ToString()), dr.Cells[11].Text);

                        if (dtStock.Columns.Count > 1)
                        {
                            GrdFreeSKU.DataSource = dtStock;
                            GrdFreeSKU.DataBind();
                            GrdFreeSKU.Visible = true;
                             LoadPendingOrder();
                            return;
                        }

                    }
                    else
                    {
                        DataTable dt = CDC.SelectCustomerCreditBalance(long.Parse(dr.Cells[0].Text), int.Parse(DrpPrincipal.SelectedValue.ToString()), int.Parse(drpDistributor.SelectedValue.ToString()));
                        if (decimal.Parse(dc.chkNull_0(dt.Rows[0][0].ToString())) >= decimal.Parse(dr.Cells[10].Text))
                        {
                            dtStock = ORD.ConvertOrder_to_Invoice(int.Parse(drpDistributor.SelectedValue.ToString()), long.Parse(dr.Cells[0].Text), int.Parse(DrpPrincipal.SelectedValue.ToString()),
                               long.Parse(dr.Cells[4].Text), DateTime.Parse( Session["CurrentWorkDate"].ToString()), decimal.Parse(dc.chkNull_0(dr.Cells[6].Text)), decimal.Parse(dc.chkNull_0(dr.Cells[7].Text)),
                               decimal.Parse(dc.chkNull_0(dr.Cells[8].Text)), decimal.Parse(dc.chkNull_0(dr.Cells[9].Text)), decimal.Parse(dc.chkNull_0(dr.Cells[10].Text)), Constants.Order_Posted_Id, Constants.Credit_Order_Id, int.Parse( Session["UserId"].ToString()), dr.Cells[11].Text);

                            if (dtStock.Columns.Count > 1)
                            {
                                GrdFreeSKU.DataSource = dtStock;
                                GrdFreeSKU.DataBind();
                                GrdFreeSKU.Visible = true;
                                 LoadPendingOrder();
                                return;
                            }
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this,  GetType(), "msg", "alert('Error in Order#  " + dr.Cells[4].Text + " Customer Credit Limit " + dc.chkNull_0(dt.Rows[0][0].ToString()) + "');", true);
                        }
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this,  GetType(), "msg", "alert('Order Date Can not be greater than current working date');", true);
                    break;
                }
            }                
         }
          LoadPendingOrder();

    }
    protected void drpDayofWeak_SelectedIndexChanged(object sender, EventArgs e)
    {
         LoadDeliveryman();
    }
}
