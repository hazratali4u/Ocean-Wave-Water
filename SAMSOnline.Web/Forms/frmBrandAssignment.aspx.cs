using System;
using System.Data;
using System.Web.UI;
using SAMS.BusinessLayer.Classes;
using SAMS.Common.Classes;    

public partial class Forms_frmBrandAssignment : System.Web.UI.Page
{
    
    private void LoadUser()
    {
        SAMSUserController mUserController = new SAMSUserController();
        DataTable dt = mUserController.SelectSlashUser(null, null); 
        clsWebFormUtil.FillDropDownList(ddRole, dt, 0, 4, true);  
    }
    private void UnAssignBrand()
    {
       
            SkuHierarchyController sController = new SkuHierarchyController();
            DataTable dt = sController.SelectBrandAssignment(0, int.Parse(ddRole.SelectedValue.ToString()));
            clsWebFormUtil.FillListBox(lstUnAssignBrand, dt, 0, 1, true);
        
    }
    private void AssignBrand()
    {
        
            SkuHierarchyController sController = new SkuHierarchyController();
            DataTable dt = sController.SelectBrandAssignment(1, int.Parse(ddRole.SelectedValue.ToString()));
            clsWebFormUtil.FillListBox(lstAssignBrand, dt, 0, 1, true);
        
    }    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.LoadUser(); 
            this.UnAssignBrand();
            this.AssignBrand();            
        }
    }
    protected void ddUser_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.UnAssignBrand();
        this.AssignBrand(); 
    }    
    protected void Button3_Click(object sender, EventArgs e)
    {
        SkuHierarchyController sController = new SkuHierarchyController();
        for (int i = 0; i < lstUnAssignBrand.Items.Count; i++)
        {
            if (lstUnAssignBrand.Items[i].Selected == true && ddRole.Items.Count > 0)
            {
                sController.InsertAssignBrand(int.Parse(lstUnAssignBrand.SelectedValue.ToString()), int.Parse(ddRole.SelectedValue.ToString()));           
            }
        }
        this.UnAssignBrand();
        this.AssignBrand(); 
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        SkuHierarchyController sController = new SkuHierarchyController();
        for (int i = 0; i < lstUnAssignBrand.Items.Count; i++)
        {
            if (ddRole.Items.Count > 0)
            {
                sController.InsertAssignBrand(int.Parse(lstUnAssignBrand.Items[i].Value.ToString()),int.Parse(ddRole.SelectedValue.ToString()));           
                    
            }
        }
        this.UnAssignBrand();
        this.AssignBrand(); 
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        SkuHierarchyController sController = new SkuHierarchyController();
        for (int i = 0; i < lstAssignBrand.Items.Count; i++)
        {
            if (ddRole.Items.Count > 0)
            {
                sController.DeleteAssignBrand(int.Parse(lstAssignBrand.Items[i].Value.ToString()), int.Parse(ddRole.SelectedValue.ToString()));

            }
        }
        this.UnAssignBrand();
        this.AssignBrand(); 
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        SkuHierarchyController sController = new SkuHierarchyController();
        for (int i = 0; i < lstAssignBrand.Items.Count; i++)
        {
            if (lstAssignBrand.Items[i].Selected == true && ddRole.Items.Count > 0)
            {
                sController.DeleteAssignBrand(int.Parse(lstAssignBrand.Items[i].Value.ToString()), int.Parse(ddRole.SelectedValue.ToString()));
            }
        }
        this.UnAssignBrand();
        this.AssignBrand(); 
    }
}
