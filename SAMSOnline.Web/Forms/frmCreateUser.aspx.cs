using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using SAMS.BusinessLayer.Classes;
using SAMS.Common.Classes;  

public partial class Forms_frmCreateUser : System.Web.UI.Page
{
    RoleManagementController mController = new RoleManagementController();
    SAMSUserController UController = new SAMSUserController(); 
    
    protected void Page_Load(object sender, EventArgs e)
    {
                 
        if (!Page.IsPostBack)
        {
            this.LoadDISTRIBUTOR();
            this.LoadUser();
            this.LoadRole();
            this.LoadGrid();
            btnSave.Attributes.Add("onclick", "return ValidateForm()");
        }
        
        Response.Expires = 0;
        Response.Cache.SetNoStore();

    }
    private void LoadDISTRIBUTOR()
    {
        DistributorController mController = new DistributorController();
        DataTable dtDistributor = mController.SelectDistributor(Constants.IntNullValue,Constants.IntNullValue,Constants.IntNullValue);
        ddDistributorId.DataSource = dtDistributor;
        ddDistributorId.DataTextField = "DISTRIBUTOR_NAME";
        ddDistributorId.DataValueField = "DISTRIBUTOR_ID";
        ddDistributorId.DataBind();
    }
    private void LoadUser()
    {
        if (ddDistributorId.Items.Count > 0)
        {
            Distributor_UserController du = new Distributor_UserController();
            DataTable dt = du.SelectDistributorUser(Constants.IntNullValue, int.Parse(ddDistributorId.SelectedValue.ToString()), int.Parse(this.Session["CompanyId"].ToString()));
            clsWebFormUtil.FillDropDownList(this.DrpUser, dt, 0, 6, true);
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        
        try
        {
           
            if (btnSave.Text == "Save")
            {
                DataTable dt =  UController.SelectSlashUser(txtLoginId.Text, txtpassword.Text);
                if (dt.Rows.Count > 0)
                {
                    lblErrorMsg.Text = "LoginId Already Exist";
                    return; 
                }

                UController.InsertSlashUser(int.Parse(DrpUser.SelectedValue.ToString()), int.Parse(this.Session["CompanyId"].ToString()), int.Parse(ddDistributorId.SelectedValue.ToString()), txtLoginId.Text, SAMS.Common.Classes.Cryptography.Encrypt(txtpassword.Text, "b0tin@74"), int.Parse(ddRole.SelectedValue.ToString()));
                
                
            }
            else if (btnSave.Text == "Update")
            {
                
                UController.UpdateSlashUser(int.Parse(DrpUser.SelectedValue.ToString()) ,int.Parse(this.Session["CompanyId"].ToString()),txtLoginId.Text,SAMS.Common.Classes.Cryptography.Encrypt(txtpassword.Text,"b0tin@74"),int.Parse(ddRole.SelectedValue.ToString()),chkIsActive.Checked,int.Parse(ddDistributorId.SelectedValue.ToString()));

                                
            }
            LoadGrid();
            ClearControls();
            btnSave.Text = "Save";
        }

        catch (Exception ex)
        {

        }
    }
    protected void ClearControls()
    {
        try
        {
            txtLoginId.Text = null;
            txtpassword.Text = null;
            lblErrorMsg.Text = null;
            btnSave.Text = "Save"; 

        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    }
    protected void LoadGrid()
    {
        if (ddDistributorId.Items.Count > 0)
        {
            DataTable dt = UController.SelectSlashUser(null,null);
            switch (ddSearchType.SelectedIndex)
            {

                case 1:
                    dt.DefaultView.RowFilter = ddSearchType.SelectedValue.ToString() + " like '%" + txtSeach.Text + "%'";
                    break;
                case 2:
                    dt.DefaultView.RowFilter = ddSearchType.SelectedValue.ToString() + " like '%" + txtSeach.Text + "%'";
                    break;
                case 3:
                    dt.DefaultView.RowFilter = ddSearchType.SelectedValue.ToString() + " like '%" + txtSeach.Text + "%'";
                    break;
                default:
                    dt.DefaultView.RowFilter = "USER_NAME" + " like '%" + "" + "%'";
                    break;
            }
            this.Grid_users.DataSource = dt;
            this.Grid_users.DataBind();
        }
    }
    protected void LoadRole()
    {
        DataTable dt  = mController.SelectRoleMaster(Constants.IntNullValue, null, Constants.DateNullValue, Constants.DateNullValue, true);
        ddRole.DataSource = dt;
        ddRole.DataTextField = "ROLE_NAME";
        ddRole.DataValueField = "ROLE_ID";
        ddRole.DataBind();
    }
    protected void Grid_users_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            GridViewRow gvr = this.Grid_users.Rows[e.NewEditIndex];
            ddDistributorId.SelectedValue = gvr.Cells[1].Text;
            this.LoadUser();
            DrpUser.SelectedValue = gvr.Cells[0].Text;
            this.txtLoginId.Text = gvr.Cells[4].Text;
            this.txtpassword.Text = gvr.Cells[5].Text;
            this.chkIsActive.Checked  = bool.Parse(gvr.Cells[7].Text);
            ddRole.SelectedValue   = gvr.Cells[8].Text;
            btnSave.Text = "Update";


        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    }
    protected void Grid_users_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        this.Grid_users.PageIndex = e.NewPageIndex;
        LoadGrid();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        ClearControls();
    }
    protected void ddDistributorId_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadUser();

    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        LoadGrid();
    }

}
