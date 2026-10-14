using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using SAMS.BusinessLayer.Classes;
using SAMS.Common.Classes;

public partial class Forms_frmSaleForceAreaAssignment2 : System.Web.UI.Page
{

    Distributor_UserController UController = new Distributor_UserController();



    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.LoadDay_OF_Weak();
            this.LoadDISTRIBUTOR();
            this.LoadDesignation();
            this.LoadGrid();
            this.LoadArea();
            this.LoadAssisgnedArea();



        }
        ChbAreaList2.SelectedIndexChanged += new EventHandler(ChbAreaList2_SelectedIndexChanged);
        ChbAreaList2.Attributes.Add("onclick", "radioMe(event);");

    }


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
   
    private void LoadArea()
    {// from Old table structures
        if (drpDistributor.Items.Count > 0)
        {
            var gController = new DistributorAreaController();
            DataTable dt = gController.SelectDist_Area(Constants.LongNullValue, Constants.DateNullValue, Constants.DateNullValue, int.Parse(drpDistributor.SelectedValue.ToString()), Constants.IntNullValue, null, null);
            clsWebFormUtil.FillListBox(ChbAreaList, dt, 0, 6, true);
        }
    }
    private void LoadAssisgnedArea()
    {
        for (int nInner = 0; nInner < this.ChbAreaList.Items.Count; nInner++)
        {
            ChbAreaList.Items[nInner].Selected = false;
        }

        ChbAreaList2.Items.Clear();
        if (DrpSaleForce.Items.Count > 0)
        {
            #region Select Assign Area

            DataTable dtArea = UController.SelectSalesForceArea(int.Parse(drpDistributor.SelectedValue.ToString()), int.Parse(DrpSaleForce.SelectedValue.ToString()), Constants.LongNullValue);

            for (int nOuter = 0; nOuter < dtArea.Rows.Count; nOuter++)
            {
                int AreaId = int.Parse(dtArea.Rows[nOuter]["Area_Id"].ToString());

                for (int nInner = 0; nInner < this.ChbAreaList.Items.Count; nInner++)
                {
                    if (int.Parse(ChbAreaList.Items[nInner].Value) == AreaId)
                    {
                        ChbAreaList2.Items.Add(ChbAreaList.Items[nInner]);
                      //  ChbAreaList.Items[nInner].Selected = true;
                        break;
                    }
                }
            }
            #endregion

        }
    }
    private void LoadCustomer()
    {
        var mController = new CustomerDataController();
        DataTable dt = mController.SelectPrincipalCustomer(int.Parse(drpDistributor.SelectedValue), int.Parse(ChbAreaList2.SelectedItem.Value), Constants.IntNullValue, Constants.IntNullValue);
        clsWebFormUtil.FillListBox(this.ChbCustomer, dt, 0, 3, true);
    }

  


    private void ChbAreaList2_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        ChbCustomer.Items.Clear();
        ChbCustomer2.Items.Clear();
        foreach (ListItem lstItem in ChbAreaList2.Items)
        {


            if (lstItem.Selected == true)
            {
                LoadCustomer();
                this.LoadAssisgnedCustomer();
            }
        }

    }
    protected void drpDistributor_SelectedIndexChanged(object sender, EventArgs e)
    {
        ChbAreaList2.Items.Clear();
        ChbCustomer.Items.Clear();
        ChbCustomer2.Items.Clear();
        this.LoadGrid();
        this.LoadArea();
        this.LoadAssisgnedArea() ;
    }
    protected void DrpDesignation_SelectedIndexChanged(object sender, EventArgs e)
    {
        ChbAreaList2.Items.Clear();
        ChbCustomer.Items.Clear();
        ChbCustomer2.Items.Clear();
        this.LoadGrid();
        this.LoadArea();
        this.LoadAssisgnedArea();

    }
    protected void btnSave_Click(object sender, EventArgs e)
    {

        //UController.UpdateSalesForceAreaCustomer(int.Parse(drpDistributor.SelectedValue.ToString()), int.Parse(DrpSaleForce.SelectedValue.ToString()),Constants .IntNullValue );

        //for (int i = 0; i < ChbAreaList.Items.Count; i++)
        //{
        //    if (ChbAreaList.Items[i].Selected == true)
        //    {
        //        UController.InsertSalesForceAreaCustomer(int.Parse(drpDistributor.SelectedValue.ToString()), int.Parse(DrpSaleForce.SelectedValue.ToString()), int.Parse(ChbAreaList.Items[i].Value.ToString()), int.Parse(drpDayofWeak.SelectedValue), int.Parse(ChbCustomer2.Items[i].Value.ToString()));
        //    }
        //}

        //UController.UpdateSalesForcePrincipal(int.Parse(drpDistributor.SelectedValue.ToString()), int.Parse(DrpSaleForce.SelectedValue.ToString()));

        //for (int i = 0; i < ChbCustomer.Items.Count; i++)
        //{
        //    if (ChbCustomer.Items[i].Selected == true)
        //    {
        //        UController.InsertSalesForcePrincipal(int.Parse(drpDistributor.SelectedValue.ToString()), int.Parse(DrpSaleForce.SelectedValue.ToString()), int.Parse(ChbCustomer.Items[i].Value.ToString()));
        //    }
        //}
    }
    protected void DrpSaleForce_SelectedIndexChanged(object sender, EventArgs e)
    {
        ChbAreaList2.Items.Clear();
        ChbCustomer.Items.Clear();
        ChbCustomer2.Items.Clear();
        LoadArea();
        this.LoadAssisgnedArea() ;
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        // Button >

        //  UController.UpdateSalesForceAreaCustomer(int.Parse(drpDistributor.SelectedValue.ToString()), int.Parse(DrpSaleForce.SelectedValue.ToString()));

        for (int i = 0; i < ChbAreaList.Items.Count; i++)
        {
            if (ChbAreaList.Items[i].Selected == true)
            {
                UController.InsertSalesForceAreaCustomer(int.Parse(drpDistributor.SelectedValue.ToString()), int.Parse(DrpSaleForce.SelectedValue.ToString()), int.Parse(ChbAreaList.Items[i].Value.ToString()), int.Parse(drpDayofWeak.SelectedValue), Constants.LongNullValue);
            }
        }

     //   this.LoadAssisgned();


        //for (int i = 0; i < ChbAreaList.Items.Count; i++)
        //{
        //    if (ChbAreaList.Items[i].Selected == true)
        //    {
        //        ChbAreaList2.Items.Add (ChbAreaList.SelectedItem);
        //        ChbAreaList.Items.Remove(ChbAreaList.SelectedItem);
        //    }
        //}
        //for (int i = 0; i < ChbAreaList2.Items.Count; i++)
        //{

        //    ChbAreaList2.Items[i].Selected = false;

        //}

      //  ChbCustomer.Items.Clear();
      //  ChbCustomer2.Items.Clear();

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        // Button >>

        //    UController.UpdateSalesForceAreaCustomer(int.Parse(drpDistributor.SelectedValue.ToString()), int.Parse(DrpSaleForce.SelectedValue.ToString()));

        for (int i = 0; i < ChbAreaList.Items.Count; i++)
        {

            UController.InsertSalesForceAreaCustomer(int.Parse(drpDistributor.SelectedValue.ToString()), int.Parse(DrpSaleForce.SelectedValue.ToString()), int.Parse(ChbAreaList.Items[i].Value.ToString()), int.Parse(drpDayofWeak.SelectedValue), Constants.LongNullValue);

        }

        this.LoadAssisgnedArea() ;

        for (int i = 0; i < ChbAreaList2.Items.Count; i++)
        {

            ChbAreaList2.Items[i].Selected = false;

        }

        ChbCustomer.Items.Clear();
        ChbCustomer2.Items.Clear();
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        // Button <<
        UController.UpdateSalesForceAreaRootCustomer(int.Parse(drpDistributor.SelectedValue.ToString()), int.Parse(DrpSaleForce.SelectedValue.ToString()), Constants .LongNullValue, Constants.LongNullValue);
        this.LoadUnAssisgned();
        ChbCustomer.Items.Clear();
        ChbCustomer2.Items.Clear();
        




        UController.UpdateSalesForceAreaCustomer(int.Parse(drpDistributor.SelectedValue.ToString()), int.Parse(DrpSaleForce.SelectedValue.ToString()), Constants .LongNullValue, int .Parse (drpDayofWeak .SelectedValue ) );
        this.LoadUnAssisgned();

       


    }
    protected void Button4_Click(object sender, EventArgs e)
    {

        // button <





        if (ChbAreaList2.Items.Count > 0 )
        {

            for (int i = 0; i < ChbAreaList2.Items.Count; i++)
            {
                if (ChbAreaList2.Items[i].Selected == true)
                {
                    UController.UpdateSalesForceAreaRootCustomer(int.Parse(drpDistributor.SelectedValue.ToString()), int.Parse(DrpSaleForce.SelectedValue.ToString()), long.Parse(ChbAreaList2.SelectedItem.Value.ToString()), Constants.LongNullValue);
                    this.LoadUnAssisgned();
                    ChbCustomer2.Items.Clear();
                 



                    UController.UpdateSalesForceAreaCustomer(int.Parse(drpDistributor.SelectedValue.ToString()), int.Parse(DrpSaleForce.SelectedValue.ToString()), long.Parse(ChbAreaList2.SelectedItem.Value.ToString()), int .Parse (drpDayofWeak .SelectedValue ));

                    ChbAreaList.Items.Add(ChbAreaList2.SelectedItem);
                    ChbAreaList2.Items.Remove(ChbAreaList2.SelectedItem);

                }

            }
        }
        for (int i = 0; i < ChbAreaList.Items.Count; i++)
        {

            ChbAreaList.Items[i].Selected = false;

        }
        ChbCustomer.Items.Clear();
        ChbCustomer2.Items.Clear();
    }
    protected void Button9_Click(object sender, EventArgs e)
    {
        // Button > Customer

     
        for (int i = 0; i < ChbCustomer.Items.Count; i++)
        {
            if (ChbCustomer.Items[i].Selected == true)
            {
                UController.InsertSalesForceAreaRootCustomer(int.Parse(drpDistributor.SelectedValue.ToString()), int.Parse(DrpSaleForce.SelectedValue.ToString()), long.Parse(ChbAreaList2.SelectedItem.Value.ToString()), int.Parse(drpDayofWeak.SelectedValue), long.Parse(ChbCustomer.SelectedItem.Value.ToString()));
            }
        }
    
        this.LoadAssisgnedCustomer();

        for (int i = 0; i < ChbCustomer2 .Items.Count; i++)
        {

            ChbCustomer2.Items[i].Selected = false;

        }


    }
    protected void Button10_Click(object sender, EventArgs e)
    {
        // Button >> Customer


        for (int i = 0; i < ChbCustomer.Items.Count; i++)
        {
            UController.InsertSalesForceAreaRootCustomer(int.Parse(drpDistributor.SelectedValue.ToString()), int.Parse(DrpSaleForce.SelectedValue.ToString()), long.Parse(ChbAreaList2.SelectedItem.Value.ToString()), int.Parse(drpDayofWeak.SelectedValue), long.Parse(ChbCustomer.Items[i].Value.ToString()));
           
        }
     
        this.LoadAssisgnedCustomer();

        for (int i = 0; i < ChbCustomer2.Items.Count; i++)
        {

            ChbCustomer2.Items[i].Selected = false;

        }
        
    
    }
    protected void Button11_Click(object sender, EventArgs e)
    {

        // Button << Customeer
        UController.UpdateSalesForceAreaRootCustomer(int.Parse(drpDistributor.SelectedValue.ToString()), int.Parse(DrpSaleForce.SelectedValue.ToString()), long .Parse (ChbAreaList2 .SelectedItem .Value .ToString ()),Constants .LongNullValue );
        
        ChbCustomer2.Items.Clear();
        LoadCustomer();
        LoadAssisgnedCustomer();
        for (int i = 0; i < ChbCustomer.Items.Count; i++)
        {

            ChbCustomer.Items[i].Selected = false;

        }
    
    }
    protected void Button12_Click(object sender, EventArgs e)
    {
        // button < Customer

        if (ChbCustomer2 .Items.Count > 0)
        {

            for (int i = 0; i < ChbCustomer2.Items.Count; i++)
            {
                if (ChbCustomer2.Items[i].Selected == true)
                {
                    UController.UpdateSalesForceAreaRootCustomer(int.Parse(drpDistributor.SelectedValue.ToString()), int.Parse(DrpSaleForce.SelectedValue.ToString()), long.Parse(ChbAreaList2.SelectedItem.Value.ToString()),long .Parse (ChbCustomer2 .SelectedItem .Value .ToString ()));
                    ChbCustomer2.Items.Remove(ChbCustomer2.SelectedItem);
                    
                }
                LoadCustomer();
                LoadAssisgnedCustomer();

            }
        }
        for (int i = 0; i < ChbCustomer.Items.Count; i++)
        {

            ChbCustomer.Items[i].Selected = false;

        }

    }
    protected void drpDayofWeak_SelectedIndexChanged(object sender, EventArgs e)
    {
        ChbAreaList2.Items.Clear();
        ChbCustomer.Items.Clear();
        ChbCustomer2.Items.Clear();
        LoadArea();
        this.LoadAssisgnedArea() ;
    }




    private void LoadUnAssisgned()
    {

        //for (int nInner = 0; nInner < this.ChbAreaList2.Items.Count; nInner++)
        //{
        //    ChbAreaList2.Items[nInner].Selected = false;
        //}
        //for (int nInner = 0; nInner < this.ChbCustomer.Items.Count; nInner++)
        //{
        //    ChbCustomer.Items[nInner].Selected = false;
        //}



        if (DrpSaleForce.Items.Count > 0)
        {
            #region Select Assign Area

            DataTable dtArea = UController.SelectSalesForceAreaCustomer(int.Parse(drpDistributor.SelectedValue.ToString()), int.Parse(DrpSaleForce.SelectedValue.ToString()), Constants.LongNullValue, int.Parse (drpDayofWeak .SelectedValue ));

            if (dtArea.Rows.Count > 0)
            {
            
            }
            else
            {
                ChbAreaList2.Items.Clear();
                LoadArea();
            }
            #endregion

            #region Select Assign Principal

            //DataTable dtPrincipal = UController.SelectSalesForcePrincipal(int.Parse(drpDistributor.SelectedValue.ToString()), int.Parse(DrpSaleForce.SelectedValue.ToString()), Constants.IntNullValue);

            //for (int nOuter = 0; nOuter < dtPrincipal.Rows.Count; nOuter++)
            //{
            //    int PrincipalId = int.Parse(dtPrincipal.Rows[nOuter]["PRINCIPAL_ID"].ToString());

            //    for (int nInner = 0; nInner < this.ChbPrincipal.Items.Count; nInner++)
            //    {
            //        if (int.Parse(ChbPrincipal.Items[nInner].Value) == PrincipalId)
            //        {
            //            ChbPrincipal.Items[nInner].Selected = true;
            //            break;
            //        }
            //    }
            //}
            #endregion

        }
    }


    private void LoadAssisgnedCustomer()
    {
       
        if (DrpSaleForce.Items.Count > 0)
        {
            #region Select Assign Customer

            DataTable dtArea = UController.SelectSalesForceAreaRootCustomer(int.Parse(drpDistributor.SelectedValue.ToString()), int.Parse(DrpSaleForce.SelectedValue.ToString()), long.Parse(ChbAreaList2.SelectedItem.Value.ToString()),int.Parse( (drpDayofWeak .SelectedValue)));


            for (int nOuter = 0; nOuter < dtArea.Rows.Count; nOuter++)
            {
                int CustomerId = int.Parse(dtArea.Rows[nOuter]["Customer_Id"].ToString());

                for (int nInner = 0; nInner < this.ChbCustomer.Items.Count; nInner++)
                {
                    if (int.Parse(ChbCustomer.Items[nInner].Value) == CustomerId)
                    {
                        ChbCustomer2.Items.Add(ChbCustomer.Items[nInner]);
                        ChbCustomer.Items.Remove(ChbCustomer.Items[nInner]);

                    }
                }
            }
            #endregion




            //ChbCustomer.Items.Clear();
            //ChbCustomer2.Items.Clear();
            //foreach (ListItem lstItem in ChbAreaList2.Items)
            //{


            //    if (lstItem.Selected == true)
            //    {
            //        LoadCustomer();
            //        this.LoadAssisgnedCustomer();
            //    }
            //}
        }
    }

}
