using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using SAMS.Common.Classes;
using SAMS.BusinessLayer.Classes;

public partial class frmRoleManagement : System.Web.UI.Page
{

    #region Private Variable
    RoleManagementController mController = new RoleManagementController();
    DataControl dc = new DataControl();

    #endregion

    #region Private Method

    private void LoadMod1stLayer()
    {
        DataTable dt = mController.SelectModule(Constants.IntNullValue, null, Constants.IntNullValue, Constants.Mod_1st_Layer, Constants.DateNullValue, true);
        dt.DefaultView.Sort = "MODULE_DESCRIPTION";
        DrpModule1stLayer.DataSource = dt.DefaultView;
        DrpModule1stLayer.DataTextField = "MODULE_DESCRIPTION";
        DrpModule1stLayer.DataValueField = "MODULE_ID";
        DrpModule1stLayer.DataBind();
    }
    private void LoadMod2ndtLayer()
    {
        DataTable dt = mController.SelectModule(Constants.IntNullValue, null, int.Parse(dc.chkNull(DrpModule1stLayer.SelectedValue.ToString())), Constants.Mod_2nd_Layer, Constants.DateNullValue, true);
        dt.DefaultView.Sort = "MODULE_DESCRIPTION";
        DrpModule2ndLayer.DataSource = dt.DefaultView;
        DrpModule2ndLayer.DataTextField = "MODULE_DESCRIPTION";
        DrpModule2ndLayer.DataValueField = "MODULE_ID";
        DrpModule2ndLayer.DataBind();
    }
    private void LoadMod3rdtLayer()
    {
        DataTable dt = mController.SelectModule(Constants.IntNullValue, null, int.Parse(dc.chkNull(DrpModule2ndLayer.SelectedValue.ToString())), Constants.Mod_3rd_Layer, Constants.DateNullValue, true);
        dt.DefaultView.Sort = "MODULE_DESCRIPTION";
        DrpModule3rdLayer.DataSource = dt.DefaultView;
        DrpModule3rdLayer.DataTextField = "MODULE_DESCRIPTION";
        DrpModule3rdLayer.DataValueField = "MODULE_ID";
        DrpModule3rdLayer.DataBind();
    }
    private void GetUnAssingModule(int RoleID)
    {
        DataTable dt = mController.GetAssignUnAssignModule(RoleID, int.Parse(dc.chkNull(DrpModule3rdLayer.SelectedValue.ToString())), Constants.IntNullValue, 0);
        dt.DefaultView.Sort = "MODULE_DESCRIPTION";
        lstUnAssignModule.DataSource = dt.DefaultView;
        lstUnAssignModule.DataTextField = "MODULE_DESCRIPTION";
        lstUnAssignModule.DataValueField = "MODULE_ID";
        lstUnAssignModule.DataBind();
    }
    private void GetAssingModule(int RoleID)
    {
        DataTable dt = mController.GetAssignUnAssignModule(RoleID, int.Parse(dc.chkNull(DrpModule3rdLayer.SelectedValue.ToString())), Constants.IntNullValue, 1);
        dt.DefaultView.Sort = "MODULE_DESCRIPTION";
        lstAssignModule.DataSource = dt.DefaultView;
        lstAssignModule.DataTextField = "MODULE_DESCRIPTION";
        lstAssignModule.DataValueField = "MODULE_ID";
        lstAssignModule.DataBind();
    }
    
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!Page.IsPostBack)
        {
            this.LoadRole();
            this.LoadMod1stLayer();
            this.LoadMod2ndtLayer();
            this.LoadMod3rdtLayer();
            int Role_Id = Convert.ToInt32(ddRole.SelectedValue.ToString());
            this.GetUnAssingModule(Role_Id);
            this.GetAssingModule(Role_Id);
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        int Role_Id = Convert.ToInt32(this.ddRole.SelectedValue.ToString());
        string Module_Id = lstAssignModule.SelectedValue.ToString();
        if (this.lstAssignModule.Items.Count > 0)
        {
            for (int i = 0; i < lstAssignModule.Items.Count; i++)
            {
                if (lstAssignModule.Items[i].Selected == true)
                {

                    mController.InsertRoleDetail(int.Parse(ddRole.SelectedValue.ToString()), Convert.ToInt32(lstAssignModule.SelectedValue.ToString()), 0);

                }
            }
            this.GetUnAssingModule(int.Parse(ddRole.SelectedValue.ToString()));
            this.GetAssingModule(int.Parse(ddRole.SelectedValue.ToString()));  
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (lstUnAssignModule.Items.Count > 0)
        {
            for (int i = 0; i < lstUnAssignModule.Items.Count; i++)
            {

                if (lstUnAssignModule.Items[i].Selected == true)
                {
                    mController.InsertRoleDetail(int.Parse(ddRole.SelectedValue.ToString()), Convert.ToInt32(lstUnAssignModule.SelectedValue.ToString()), 1);
                                     
                }
            }
            this.GetUnAssingModule(int.Parse(ddRole.SelectedValue.ToString()));
            this.GetAssingModule(int.Parse(ddRole.SelectedValue.ToString()));  
        }

    }
    protected void DrpModule1stLayer_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadMod2ndtLayer();
        this.LoadMod3rdtLayer();
        this.GetUnAssingModule(int.Parse(ddRole.SelectedValue.ToString()));
        this.GetAssingModule(int.Parse(ddRole.SelectedValue.ToString()));  
    }
    protected void DrpModule2ndLayer_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadMod3rdtLayer();
        this.GetUnAssingModule(int.Parse(ddRole.SelectedValue.ToString()));
        this.GetAssingModule(int.Parse(ddRole.SelectedValue.ToString()));  
    }
    private void LoadRole()
    {
        DataTable dt = mController.SelectRoleMaster(0, null, System.DateTime.Today, System.DateTime.Today, true);
        ddRole.DataSource = dt;
        ddRole.DataTextField = "ROLE_NAME";
        ddRole.DataValueField = "ROLE_ID";
        ddRole.DataBind();
    }
    protected void btnNew_Click(object sender, EventArgs e)
    {
        if (this.btnNew.Text == "New")
        {
            this.ddRole.Visible = false;
            this.TextBox1.Text = null;
            this.TextBox1.Visible = true;
            this.TextBox1.Enabled = true;
            this.btnNew.Text = "Save";
        }
        else
        {
            if (this.TextBox1.Text == "")
            {
                lblmsg.Visible = true;
                lblmsg.Text = "Enter Role.";
            }
            else
            {
                lblmsg.Visible = false;
                mController.InsertRoleMaster(this.TextBox1.Text, System.DateTime.Today, System.DateTime.Today,true);
                LoadRole();
                this.lblmsg.Visible = false;
            }
            this.btnNew.Text = "New";
            this.ddRole.Visible = true;
            this.TextBox1.Visible = false;
        }

        //if (this.TextBox1.Enabled == false)
        //{
        //    this.ddRole.Visible = false;
        //    this.TextBox1.Visible = true;
        //    this.TextBox1.Enabled = true;
        //    return;
        //}
        //else
        //{
        //    this.ddRole.Visible = true;
        //    LoadRole();
        //    this.TextBox1.Visible = false;
        //    this.TextBox1.Enabled = false;
        //}   
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        //int Unassign = 0;
        //int Role_Id = 0;
        //string Module_Id = null;
        //string ROLE_NAME = null;
        //bool IsActive;
        //Role_Id = Convert.ToInt32(this.ddRole.SelectedValue.ToString());
        //for (int i = 0; i < lstAssignModule.Items.Count; i++)
        //{
        //    Module_Id = lstAssignModule.Items[i].Value.ToString();
        //    Unassign = 1;
        //   
        //}
   
        //System.Threading.Thread.Sleep(2000);
    }
    protected void DrpModule3rdLayer_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.GetUnAssingModule(int.Parse(ddRole.SelectedValue.ToString()));
        this.GetAssingModule(int.Parse(ddRole.SelectedValue.ToString()));  
    }
    protected void Button3_Click(object sender, EventArgs e)
    {

    }
    protected void ddRole_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.GetUnAssingModule(int.Parse(ddRole.SelectedValue.ToString()));
        this.GetAssingModule(int.Parse(ddRole.SelectedValue.ToString()));  
    }

}
