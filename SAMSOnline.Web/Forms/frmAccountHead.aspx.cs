using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using SAMS.BusinessLayer.Classes;
using SAMS.Common.Classes;    

public partial class Forms_frmAccountHead : System.Web.UI.Page
{
    AccountHeadController MController = new AccountHeadController();
    private static long AccountTypeId;
    private static long AccountSubTypeId;
    private static long AccountDetailTypeId;
    private static long AccountHeadId;
    private static string strCode;
    private void GetAccountType()
    {
        DataTable dt  =  MController.SelectAccountHead(Constants.AC_MainTypeId,Constants.LongNullValue);
        clsWebFormUtil.FillDropDownList(ddAccountType, dt, 0, 10,true);   
    }
    private void GetSubAccountType()
    {
        if (ddAccountType.Items.Count > 0)
        {
            DataTable dt = MController.SelectAccountHead(Constants.AC_SubTypeId, int.Parse(ddAccountType.SelectedValue.ToString()));
            clsWebFormUtil.FillDropDownList(ddAccountSubType, dt, 0, 10, true);
        }
        else
        {
            ddAccountSubType.Items.Clear();   
        }
    }
    private void GetDetailAccountType()
    {
        if (ddAccountSubType.Items.Count > 0)
        {
            DataTable dt = MController.SelectAccountHead(Constants.AC_DetailTypeId, int.Parse(ddAccountSubType.SelectedValue.ToString()));
            clsWebFormUtil.FillDropDownList(drpAccountTypeDetail, dt, 0, 10, true);
        }
        else
        {
            drpAccountTypeDetail.Items.Clear();   
        }
    }
    private void GetAccountHead()
    {
        if (drpAccountTypeDetail.Items.Count > 0)
        {
            DataTable dt = MController.SelectAccountHead(int.Parse(this.Session["CompanyId"].ToString()), Constants.IntNullValue, Constants.AC_AccountHeadId, int.Parse(drpAccountTypeDetail.SelectedValue.ToString()));
            GridAccountHead.DataSource = dt;
            GridAccountHead.DataBind();
        }
        else
        {
            GridAccountHead.DataSource = null;
            GridAccountHead.DataBind();
        }
    }
    private void ClearAll()
    {
        btnAccountType.Text = "New Account Type";
        btnAccountSubType.Text = "New Sub Type";
        btnAccountDetailType.Text = "New Detail Type";
        
        btnSave.Text = "New"; 
        txtAtypeName.Text = "";
        txtAtypeCode.Text = "";
        txtASubTypeCode.Text = "";
        txtSubTypeName.Text = "";
        txtADetailTypeCode.Text = ""; 
        txtDetailTypeName.Text = "";
        txtAccountHead.Text = "";
        txtADetailTypeCode.Text = "";
        txtAccountCode.Text = "";

        ddAccountType.Visible = true;
        ddAccountSubType.Visible = true;
        drpAccountTypeDetail.Visible = true; 

        btnSave.Enabled = true;
        btnAccountType.Enabled = true;
        btnAccountSubType.Enabled = true;
        btnAccountDetailType.Enabled = true;

        txtAtypeCode.Visible = false;
        txtAtypeName.Visible = false;
        txtASubTypeCode.Visible = false;
        txtSubTypeName.Visible = false;
        txtADetailTypeCode.Visible = false;  
        txtDetailTypeName.Visible = false;
        ChbIsactive.Checked = true;                  
    }
    private string GetAutoCode(int CodeType, long CValue)
    {
        DataTable dt = MController.SelectAccountHead(CodeType, CValue);
        DataView dv = new DataView(dt);
        dv.Sort = "ACCOUNT_CODE";
        dt = dv.ToTable();
        if (CodeType != Constants.AC_AccountHeadId)
        {
            if (dt.Rows.Count > 0)
            {
                int AccountCode = Convert.ToInt16(dt.Rows[dt.Rows.Count - 1]["ACCOUNT_CODE"].ToString()) + 1;
                if (AccountCode.ToString().Length == 1)
                {
                    return "0" + AccountCode.ToString();

                }
                else
                {
                    return AccountCode.ToString();
                }
            }
            else
            {
                return "01";
            }
        }
        else
        {
            if (dt.Rows.Count > 0)
            {
                int AccountCode = Convert.ToInt32(dt.Rows[dt.Rows.Count - 1]["ACCOUNT_CODE"].ToString().Substring(6,4)) + 1;
                if (AccountCode.ToString().Length == 1)
                {
                    return "000" + AccountCode.ToString();
                }
                else if (AccountCode.ToString().Length == 2)  
                {
                    return "00" + AccountCode.ToString();
                }
                else if (AccountCode.ToString().Length == 3)
                {
                    return "0" + AccountCode.ToString();
                }
                else
                {
                    return  AccountCode.ToString();
                }

            }
            else
            {
                return "0001";
            }
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            SAMS.Common.Classes.Configuration.DistributorId = 1;
            this.GetAccountType();
            this.GetSubAccountType();
            this.GetDetailAccountType(); 
            this.GetAccountHead();
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (ddAccountType.Items.Count == 0)
        {
            lblErrorMsg.Text = "Select Account Type";
            return;
        }
        if (ddAccountSubType.Items.Count == 0)
        {
            lblErrorMsg.Text = "Select Account Sub Type";
            return;
        }
        if (btnSave.Text == "New")
        {
            btnSave.Text = "Save";
            txtAccountCode.Text = this.GetAutoCode(Constants.AC_AccountHeadId, int.Parse(drpAccountTypeDetail.SelectedValue.ToString()));
            ScriptManager.GetCurrent(Page).SetFocus(txtAccountCode); 
        }
        else if (btnSave.Text == "Save")
        {
            MController.InsertAccountHead(int.Parse(this.Session["CompanyId"].ToString()), true, DateTime.Now, int.Parse(this.Session["DISTRIBUTOR_ID"].ToString()), Constants.AC_AccountHeadId, long.Parse(drpAccountTypeDetail.SelectedValue.ToString()), txtAccountHead.Text, ddAccountType.SelectedItem.Text.Substring(0, 2) + ddAccountSubType.SelectedItem.Text.Substring(0, 2) + drpAccountTypeDetail.SelectedItem.Text.Substring(0, 2) + txtAccountCode.Text);
            this.ClearAll();
            this.GetAccountHead(); 
        }
        else
        {
            MController.UpdateAccountHead(AccountHeadId, int.Parse(this.Session["CompanyId"].ToString()), ChbIsactive.Checked, System.DateTime.Now, int.Parse(this.Session["DISTRIBUTOR_ID"].ToString()), Constants.AC_AccountHeadId, int.Parse(drpAccountTypeDetail.SelectedValue.ToString()), txtAccountHead.Text, ddAccountType.SelectedItem.Text.Substring(0, 2) + ddAccountSubType.SelectedItem.Text.Substring(0, 2) + drpAccountTypeDetail.SelectedItem.Text.Substring(0, 2) + txtAccountCode.Text);
            this.ClearAll();
            this.GetAccountHead(); 
        }
        
    }
    protected void btnAccountType_Click(object sender, EventArgs e)
    {
        if (btnAccountType.Text == "New Account Type")
        {
            btnAccountType.Text = "Save Account Type";

            btnAccountSubType.Enabled = false;
            btnSave.Enabled = false;
            txtAtypeName.Visible = true;
            txtAtypeCode.Visible = true;  
            ddAccountType.Visible = false;
            btnAccountDetailType.Enabled = false;
            txtAtypeCode.Text = this.GetAutoCode(Constants.AC_MainTypeId, Constants.LongNullValue);      
            ScriptManager.GetCurrent(Page).SetFocus(txtAtypeCode);    
        }
        else if (btnAccountType.Text == "Save Account Type") 
        {
            MController.InsertAccountHead(1, true, DateTime.Now, SAMS.Common.Classes.Configuration.DistributorId, Constants.AC_MainTypeId, Constants.LongNullValue, txtAtypeName.Text,txtAtypeCode.Text);
            this.ClearAll();
            this.GetAccountType();
            this.GetAccountHead(); 
            
        }
        else if (btnAccountType.Text == "Edit")
        {
            btnAccountType.Text = "Update";
            txtAtypeCode.Text = ddAccountType.SelectedItem.Text.Substring(0,2);  
            txtAtypeName.Text = ddAccountType.SelectedItem.Text.Substring(3);  
            AccountTypeId = long.Parse(ddAccountType.SelectedValue.ToString());
            btnAccountSubType.Enabled = false;
            btnSave.Enabled = false;
            btnAccountDetailType.Enabled = false; 
            txtAtypeName.Visible = true;
            txtAtypeCode.Visible = true; 
            ddAccountType.Visible = false;
            ScriptManager.GetCurrent(Page).SetFocus(txtAtypeCode);
        }
        else if (btnAccountType.Text == "Update")
        {
            MController.UpdateAccountHead(AccountTypeId, 1, true, DateTime.Now, SAMS.Common.Classes.Configuration.DistributorId, Constants.AC_MainTypeId, Constants.LongNullValue, txtAtypeName.Text,txtAtypeCode.Text);
            this.ClearAll();
            this.GetAccountType();
            this.GetAccountHead();
        }
                                   
    }
    protected void ddAccountType_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.GetSubAccountType();
        this.GetDetailAccountType();
        this.GetAccountHead();
    }
    protected void btnAccountSubType_Click(object sender, EventArgs e)
    {
        if (btnAccountSubType.Text == "New Sub Type")
        {
            btnAccountSubType.Text = "Save Sub Type";
            ddAccountSubType.Visible  = false;
            btnSave.Enabled = false;
            btnAccountType.Enabled = false;
            btnAccountDetailType.Enabled = false; 
            txtSubTypeName.Visible = true;
            txtASubTypeCode.Visible = true;
            txtASubTypeCode.Text = this.GetAutoCode(Constants.AC_SubTypeId, long.Parse(ddAccountType.SelectedValue.ToString()));       
            ScriptManager.GetCurrent(Page).SetFocus(txtASubTypeCode);     
        }
        else if (btnAccountSubType.Text == "Save Sub Type")
        {
            if (ddAccountType.Items.Count > 0)
            {
                MController.InsertAccountHead(1, true, DateTime.Now, SAMS.Common.Classes.Configuration.DistributorId, Constants.AC_SubTypeId, long.Parse(ddAccountType.SelectedValue.ToString()), txtSubTypeName.Text,txtASubTypeCode.Text);
                this.ClearAll();
                this.GetSubAccountType(); 
            }

        }
        else if (btnAccountSubType.Text == "Edit")
        {
            btnAccountSubType.Text = "Update";
            txtASubTypeCode.Text = ddAccountSubType.SelectedItem.Text.Substring(0,2);
            txtSubTypeName.Text = ddAccountSubType.SelectedItem.Text.Substring(3);
            AccountSubTypeId = long.Parse(ddAccountSubType.SelectedValue.ToString());
            btnAccountType.Enabled = false;
            
            btnSave.Enabled = false;
            txtSubTypeName .Visible = true;
            txtASubTypeCode.Visible = true;
            ddAccountSubType.Visible = false;
            ScriptManager.GetCurrent(Page).SetFocus(txtASubTypeCode);
        }
        else if (btnAccountSubType.Text == "Update")
        {
            MController.UpdateAccountHead(AccountSubTypeId, 1, true, DateTime.Now, SAMS.Common.Classes.Configuration.DistributorId, Constants.AC_SubTypeId, Constants.LongNullValue, txtSubTypeName.Text, txtASubTypeCode.Text);
            this.ClearAll();
            this.GetAccountType();
            this.GetAccountHead();
        }
    }
    protected void ddAccountSubType_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.GetDetailAccountType();
        this.GetAccountHead();
    }
    protected void GridAccountHead_RowEditing(object sender, GridViewEditEventArgs e)
    {
        ddAccountType.SelectedValue = GridAccountHead.Rows[e.NewEditIndex].Cells[0].Text;
        AccountTypeId = long.Parse(GridAccountHead.Rows[e.NewEditIndex].Cells[0].Text);
        AccountSubTypeId = long.Parse(GridAccountHead.Rows[e.NewEditIndex].Cells[1].Text);
        AccountDetailTypeId = long.Parse(GridAccountHead.Rows[e.NewEditIndex].Cells[2].Text);
        AccountHeadId = long.Parse(GridAccountHead.Rows[e.NewEditIndex].Cells[3].Text);

        this.GetSubAccountType();
        ddAccountSubType.SelectedValue = GridAccountHead.Rows[e.NewEditIndex].Cells[1].Text;
        this.GetDetailAccountType();
        drpAccountTypeDetail.SelectedValue = GridAccountHead.Rows[e.NewEditIndex].Cells[2].Text;
        txtAccountCode.Text = GridAccountHead.Rows[e.NewEditIndex].Cells[7].Text.Substring(6, 4);
        txtAccountHead.Text = GridAccountHead.Rows[e.NewEditIndex].Cells[7].Text.Substring(11);
        btnAccountSubType.Text = "Edit";
        btnAccountType.Text = "Edit";
        btnAccountDetailType.Text = "Edit"; 
        btnSave.Text = "Update"; 

    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        this.ClearAll(); 
    }
    protected void btnAccountDetailType_Click(object sender, EventArgs e)
    {
        if (btnAccountDetailType.Text == "New Detail Type")
        {
            btnAccountDetailType.Text = "Save Detail Type";
            drpAccountTypeDetail.Visible = false;
            btnSave.Enabled = false;
            btnAccountType.Enabled = false;
            btnAccountSubType.Enabled = false;  
            txtADetailTypeCode.Visible = true;
            txtDetailTypeName.Visible = true; 
            drpAccountTypeDetail.Visible = false;
            txtADetailTypeCode.Text = this.GetAutoCode(Constants.AC_DetailTypeId, long.Parse(ddAccountSubType.SelectedValue.ToString()));       
            ScriptManager.GetCurrent(Page).SetFocus(txtADetailTypeCode);
        }
        else if (btnAccountDetailType.Text == "Save Detail Type")
        {
            if (ddAccountType.Items.Count > 0 && ddAccountSubType.Items.Count > 0)
            {
                MController.InsertAccountHead(int.Parse(this.Session["CompanyId"].ToString()) , true, DateTime.Now, SAMS.Common.Classes.Configuration.DistributorId, Constants.AC_DetailTypeId,long.Parse(ddAccountSubType.SelectedValue.ToString()), txtDetailTypeName.Text,txtADetailTypeCode.Text);
                this.ClearAll();
                this.GetDetailAccountType(); 
            }

        }
        else if (btnAccountDetailType.Text == "Edit")
        {
            btnAccountDetailType.Text = "Update";
            txtADetailTypeCode.Text = drpAccountTypeDetail.SelectedItem.Text.Substring(0,2);
            txtDetailTypeName.Text = drpAccountTypeDetail.SelectedItem.Text.Substring(3);
            AccountDetailTypeId = long.Parse(drpAccountTypeDetail.SelectedValue.ToString());
            btnAccountType.Enabled = false;
            btnAccountSubType.Enabled = false;  
            btnSave.Enabled = false;
            txtADetailTypeCode.Visible = true;
            txtDetailTypeName.Visible = true; 
            drpAccountTypeDetail.Visible = false;
            ScriptManager.GetCurrent(Page).SetFocus(txtADetailTypeCode);
        }
        else if (btnAccountDetailType.Text == "Update")
        {
            MController.UpdateAccountHead(AccountDetailTypeId,int.Parse(this.Session["CompanyId"].ToString()) , true, DateTime.Now, SAMS.Common.Classes.Configuration.DistributorId, Constants.AC_DetailTypeId, Constants.LongNullValue, txtDetailTypeName.Text,txtADetailTypeCode.Text);
            this.ClearAll();
            this.GetDetailAccountType(); 
            this.GetAccountHead();
        }
    }
    protected void drpAccountTypeDetail_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.GetAccountHead();
    }
    protected void txtASubTypeCode_TextChanged(object sender, EventArgs e)
    {

    }
}
