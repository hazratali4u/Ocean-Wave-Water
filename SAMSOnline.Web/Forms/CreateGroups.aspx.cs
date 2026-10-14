using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using SAMS.BusinessLayer.Classes;
using SAMS.Common.Classes;

public partial class Groups_CreateGroups : System.Web.UI.Page
{
    RoleManagementController rolemanagementController = new RoleManagementController();
    CreateGroupController gController = new CreateGroupController();
    DataView dv ;
    private static int SKUGroupID = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LoadPrincipal();
            LoadDivision();
            LoadCategory(); 
            GetBrand();
            GetSKUName();
            LoadGrid();
        }
    }
    private void LoadPrincipal()
    {
        SkuHierarchyController sController = new SkuHierarchyController();
        DataTable dt = sController.SelectSkuHierarchy(Constants.SKUPrincipal, Constants.IntNullValue);
        clsWebFormUtil.FillDropDownList(ddPrincipal, dt, 0, 3, true);
    }
    private void LoadDivision()
    {
        if (ddPrincipal.Items.Count > 0)
        {
            SkuHierarchyController sController = new SkuHierarchyController();
            DataTable dt = sController.SelectSkuHierarchy(Constants.SKUDivision, int.Parse(ddPrincipal.SelectedValue.ToString()), int.Parse(this.Session["CompanyId"].ToString()));
            clsWebFormUtil.FillDropDownList(ddDivision, dt, 0, 3, true);
        }
    }
    private void LoadCategory()
    {
        if (ddDivision.Items.Count > 0)
        {
            SkuHierarchyController sController = new SkuHierarchyController();
            DataTable dt = sController.SelectSkuHierarchy(Constants.SKUCategory, int.Parse(ddDivision.SelectedValue.ToString()), int.Parse(this.Session["CompanyId"].ToString()));
            clsWebFormUtil.FillDropDownList(ddCatagory , dt, 0, 3, true);
        }
    }
    protected void GetBrand()
    {
        if (ddCatagory.Items.Count > 0)
        {

            SkuHierarchyController sController = new SkuHierarchyController();
            DataTable dt = sController.SelectSkuHierarchy(Constants.SKUBrand, int.Parse(ddCatagory.SelectedValue.ToString()), int.Parse(this.Session["CompanyId"].ToString()));
            clsWebFormUtil.FillDropDownList(ddBrand, dt, 0, 3, true);
        }
    }
    protected void ddPrincipal_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadDivision();
        LoadCategory();
        GetBrand();
        GetSKUName();
    }
    protected void ddDivision_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadCategory();
        GetBrand();
        GetSKUName();
    }
    protected void ddCatagory_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetBrand();
        GetSKUName();
    }
    protected void GetSKUName()
    {
        if (ddBrand.Items.Count > 0)
        {
            SkuController mContoller  = new SkuController();
            DataTable dt = mContoller.SelectSkuInfo(Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, int.Parse(ddBrand.SelectedValue.ToString()), Constants.IntNullValue);              
            lstUnAssignSKU.DataSource = dt;
            lstUnAssignSKU.DataTextField = "SKUDETAIL";
            lstUnAssignSKU.DataValueField = "SKU_ID";
            lstUnAssignSKU.DataBind();
        }
    }
    protected void ddBrand_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetSKUName();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {

        if (lstUnAssignSKU.Items.Count > 0)
        {
            this.lstAssignSKU.Items.Add(new clsListItems(lstUnAssignSKU.SelectedItem.Text, lstUnAssignSKU.SelectedValue.ToString()));
            lstUnAssignSKU.Items.RemoveAt(lstUnAssignSKU.SelectedIndex);
        }

       
    }
    protected void Button2_Click(object sender, EventArgs e)
    {

        if (lstAssignSKU.Items.Count > 0)
        {
            this.lstUnAssignSKU.Items.Add(new clsListItems(lstAssignSKU.SelectedItem.Text, lstAssignSKU.SelectedValue.ToString()));
            lstAssignSKU.Items.RemoveAt(lstAssignSKU.SelectedIndex);
        }
        //int count = 0;
        //if (this.lstAssignSKU.Items.Count > 0)
        //{
        //    for (int i = 0; i < lstAssignSKU.Items.Count; i++)
        //    {
        //        if (lstAssignSKU.Items[i].Selected == true)
        //        {
        //            for (int j = 0; j < lstUnAssignSKU.Items.Count; j++)
        //            {
        //                if (lstAssignSKU.Items[i].Text == lstUnAssignSKU.Items[j].Text)
        //                {
        //                    count = 1;
        //                }
        //            }
        //            if (count == 1)
        //            {
                       
        //                lstAssignSKU.Items.RemoveAt(lstAssignSKU.SelectedIndex);
                     
        //            }
        //            else
        //            {
                       
        //            }
        //        }
        //    }
        //}
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (txtGroupName.Text.Length == 0)
        {
            lblErrormsg.Text = "Must Enter Group Name";
            return; 
        }
        if (btnSave.Text == "Save")
        {
            DataTable dt_uniqueGroupName = GetUnique_GroupName();
            if (dt_uniqueGroupName.Rows.Count > 0)
            {
                lblErrormsg.Text = "Group Name already exists.";
                return;
            }
            lblErrormsg.Text = null;
            string ID = gController.Insert_SKUGroup(txtGroupName.Text, System.DateTime.Today, chIsActive.Checked, int.Parse(this.Session["UserId"].ToString()), int.Parse(ddPrincipal.SelectedValue.ToString()), int.Parse(this.Session["CompanyId"].ToString()));
            
            for (int i = 0; i < lstAssignSKU.Items.Count; i++)
            {
                int SKU_ID = Convert.ToInt32(lstAssignSKU.Items[i].Value.ToString());
                gController.Insert_SKU_GroupDetail(int.Parse(ID), SKU_ID);
            }
        }
        if (btnSave.Text == "Update")
        {
            lblErrormsg.Text = null;
            Update();
        }
        LoadGrid();
        lstAssignSKU.Items.Clear();
        lstUnAssignSKU.Items.Clear();
        txtGroupName.Text = ""; 
        btnSave.Text = "Save"; 
    }
    protected DataTable LoadGrid()
    {
        DataTable dt = gController.GET_SKUGroupDetail(int.Parse(this.Session["CompanyId"].ToString()));
        dv = new DataView(dt);

        DataTable dt1 = gController.GET_Group_ID(int.Parse(this.Session["CompanyId"].ToString()));
        this.SKUGroup_Grid.DataSource = dt1;
        this.SKUGroup_Grid.DataBind();
        for (int i = 0; i < SKUGroup_Grid.Rows.Count; i++)
        {
            dv.RowFilter = "SKU_GROUP_ID = " + dt1.Rows[i]["SKU_GROUP_ID"].ToString();

            ListBox list = (ListBox)SKUGroup_Grid.Rows[i].Cells[2].FindControl("listbox1");
            list.DataSource = dv;
            list.DataTextField = "SKUDETAIL";
            list.DataValueField = "SKU_ID";
            list.DataBind();
        }
        return dt;
    }
    protected void SKUGroup_Grid_RowEditing(object sender, GridViewEditEventArgs e)
    {
       lstAssignSKU.Items.Clear();
       GridViewRow gvr = (GridViewRow)this.SKUGroup_Grid.Rows[e.NewEditIndex];
       SKUGroupID = int.Parse(gvr.Cells[0].Text);
       this.txtGroupName.Text = gvr.Cells[1].Text;
       ListBox list = (ListBox)gvr.Cells[2].FindControl("listbox1");
       for (int i = 0; i < list.Items.Count; i++)
       {
          
           lstAssignSKU.DataSource = list.DataSource;
           lstAssignSKU.Items.Add(list.Items[i].Text);
           lstAssignSKU.Items[i].Value = list.Items[i].Value;
           lstAssignSKU.DataBind();
       }
       
        btnSave.Text = "Update";
    }
    protected void SKUGroup_Grid_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void Update()
    {
              
        if (lstAssignSKU.Items.Count == 0)
        {
            gController.UpdateSKUinGroup(SKUGroupID, 0,txtGroupName.Text,chIsActive.Checked,int.Parse(ddPrincipal.SelectedValue.ToString()));
        }
        else
        {
            gController.UpdateSKUinGroup(SKUGroupID, 0, txtGroupName.Text, chIsActive.Checked,int.Parse(ddPrincipal.SelectedValue.ToString()));
            for (int i = 0; i < lstAssignSKU.Items.Count; i++)
            {
                gController.UpdateSKUinGroup(SKUGroupID, Convert.ToInt32(lstAssignSKU.Items[i].Value), txtGroupName.Text, chIsActive.Checked,int.Parse(ddPrincipal.SelectedValue.ToString()));
            }
        }
    }
    protected DataTable GetUnique_GroupName()
    {
        DataTable dt = gController.GET_UniqueGroupName(Constants.IntNullValue, txtGroupName.Text, Constants.DateNullValue, true, int.Parse(this.Session["UserId"].ToString()), int.Parse(this.Session["CompanyId"].ToString()));
        return dt;
       
    }
    protected void SKUGroup_Grid_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        SKUGroup_Grid.PageIndex = e.NewPageIndex;
        LoadGrid();
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        int ItemCount = lstUnAssignSKU.Items.Count;

        for (int i = 0; i < ItemCount; i++)
        {
            this.lstAssignSKU.Items.Add(new clsListItems(lstUnAssignSKU.Items[i].Text, lstUnAssignSKU.Items[i].Value.ToString()));
            //lstUnAssignSKU.Items.RemoveAt(i);
                            
        }
        lstUnAssignSKU.Items.Clear();   
        
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        int ItemCount = lstAssignSKU.Items.Count;

        for (int i = 0; i < ItemCount; i++)
        {
            this.lstUnAssignSKU.Items.Add(new clsListItems(lstAssignSKU.Items[i].Text, lstAssignSKU.Items[i].Value.ToString()));
            //lstUnAssignSKU.Items.RemoveAt(i);

        }
        lstAssignSKU.Items.Clear(); 
    }
}
