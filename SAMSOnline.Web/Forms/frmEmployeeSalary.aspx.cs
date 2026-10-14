using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SAMS.BusinessLayer.Classes;
using SAMS.Common.Classes;
using System.Threading;
using System.Data;


public partial class Forms_frmEmployeeSalary : Page
{
    readonly Distributor_UserController _duCtrl = new Distributor_UserController();
    readonly CompanyConfigrationController _cmpCtrl = new CompanyConfigrationController();
    readonly  EmployeeSalary_Controller _empsalCtrl = new EmployeeSalary_Controller();
    readonly SLASHCodesController mController = new SLASHCodesController();

    private static int _allowanceId;
    private static int _deductionId;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            btnSave.Attributes.Add("onclick", "return ValidateForm();");
          //  SAMSCommonLayer.Classes.Configuration.SystemCurrentDateTime = (DateTime)this.Session["CurrentWorkDate"];
           // txtSalaryMonth.Text = SAMSCommonLayer.Classes.Configuration.SystemCurrentDateTime.ToString("MMM-yyyy");

             Configuration.SystemCurrentDateTime = (DateTime)this.Session["CurrentWorkDate"];
             txtDeuductionDate.Text = Configuration.SystemCurrentDateTime.ToString("dd-MMM-yyyy");

            LoadDistributor();
            LoadDesignation();
            LoadEmployee();

            LoadAllowanceType();
            LoadAllowances();
            CreateAllowances();

            LoadDeductionType();
            LoadDeductions();
            CreateDeductions();
            
            GetEmployeeSalary();

        }
    }

    #region DataTable Creation

    public void CreateAllowances()
    {
        DataTable dtAllowances = new DataTable();

        dtAllowances.Columns.Add("ALLOWANCE_TYPE_ID", typeof(int));
        dtAllowances.Columns.Add("ALLOWANCE_ID", typeof(int));
        dtAllowances.Columns.Add("ALLOWANCE_DESC", typeof(string));
        dtAllowances.Columns.Add("ALLOWANCE_AMOUNT", typeof(decimal));

        Session.Add("dtAllowances", dtAllowances);
    }
    public void CreateDeductions()
    {
        DataTable dtDeductions = new DataTable();

        dtDeductions.Columns.Add("DEDUCTION_TYPE_ID", typeof(int));
        dtDeductions.Columns.Add("DEDUCTION_ID", typeof(int));
        dtDeductions.Columns.Add("DEDUCTION_DESC", typeof(string));
        dtDeductions.Columns.Add("DEDUCTION_DATE", typeof(DateTime));
        dtDeductions.Columns.Add("DEDUCTION_AMOUNT", typeof(decimal));

        Session.Add("dtDeductions", dtDeductions);
    }

    #endregion

    #region Load 

    private void LoadDistributor()
    {
        DistributorController mController = new DistributorController();
        DataTable dtDistributor = mController.SelectDistributor(Constants.IntNullValue, Constants.IntNullValue, int.Parse(this.Session["CompanyId"].ToString()));
        if (dtDistributor.Rows.Count <= 0) return;
        DrpDistributor.DataSource = dtDistributor;
        DrpDistributor.DataTextField = "DISTRIBUTOR_NAME";
        DrpDistributor.DataValueField = "DISTRIBUTOR_ID";
        DrpDistributor.DataBind();
    }
    private void LoadDesignation()
    {
        DataTable dt = _duCtrl.SelectDistributorUser(Constants.IntNullValue, int.Parse(DrpDistributor.SelectedValue), int.Parse(Session["CompanyId"].ToString()));
        if (dt.Rows.Count <= 0) return;
        DrpDesignation.DataSource = dt;
        DrpDesignation.DataTextField = "SLASH_DESC";
        DrpDesignation.DataValueField = "USER_TYPE_ID";
        DrpDesignation.DataBind();
    }
    private void LoadEmployee()
    {

        if (DrpDistributor.Items.Count > 0)
        {
            DataTable dtEmployee = _duCtrl.SelectDistributorSalesForceType(int.Parse(DrpDistributor.SelectedValue), int.Parse(DrpDesignation.SelectedValue));
            if (dtEmployee.Rows.Count <= 0) return;
            DrpEmployee.DataSource = dtEmployee;
            DrpEmployee.DataTextField = "USER_NAME";
            DrpEmployee.DataValueField = "USER_ID";
            DrpEmployee.DataBind();
        }
    }

    private void LoadAllowanceType()
    {
        DataTable dt = mController.SelectSlashCodes(Constants.IntNullValue, null, Constants.Allowance_Type, null, Constants.IntNullValue, bool.Parse("True"));
        if (dt.Rows.Count <= 0) return;
        clsWebFormUtil.FillDropDownList(DrpAllowanceType, dt, 0, 2, true);
    }
    private void LoadAllowances()
    {
        DataTable dt = _cmpCtrl.SelectAllowances(Constants.IntNullValue, int.Parse(DrpAllowanceType.SelectedValue), Int32.Parse(Session["CompanyId"].ToString()));
        if (dt.Rows.Count > 0)
        {
            clsWebFormUtil.FillDropDownList(DrpAllowance, dt, 0, 2, true);

            DataRow[] foundRows = dt.Select("AllowanceID = '" + DrpAllowance.SelectedValue + "'");
            txtAllowanceAmount.Text = foundRows[0]["AllowanceRatio"].ToString();
        }
        else
        {
            clsWebFormUtil.FillDropDownList(DrpAllowance, dt, 0, 2, true);
            txtAllowanceAmount.Text = "";
        }     
    }
    private void LoadAllowancesOnEdit()
    {
        DataTable dt = _cmpCtrl.SelectAllowances(Constants.IntNullValue, int.Parse(DrpAllowanceType.SelectedValue), Int32.Parse(Session["CompanyId"].ToString()));
        if (dt.Rows.Count > 0)
        {
            clsWebFormUtil.FillDropDownList(DrpAllowance, dt, 0, 2, true);
        }
    }
    private void LoadDeductionType()
    {
        DataTable dt = mController.SelectSlashCodes(Constants.IntNullValue, null, Constants.Deduction_Type, null, Constants.IntNullValue, bool.Parse("True"));
        if (dt.Rows.Count <= 0) return;
        clsWebFormUtil.FillDropDownList(DrpDeductionType, dt, 0, 2, true);

    }
    private void LoadDeductions()
    {
            DataTable dt = _cmpCtrl.SelectDeductions(Constants.IntNullValue,int.Parse(DrpDeductionType.SelectedValue), Int32.Parse(Session["CompanyId"].ToString()));
           
            if (dt.Rows.Count > 0)
            {
                clsWebFormUtil.FillDropDownList(DrpDeduction, dt, 0, 2, true);

                DataRow[] foundRows = dt.Select("DeductionId = '" + DrpDeduction.SelectedValue + "'");
                txtDeductionAmount.Text = foundRows[0]["DeductionRatio"].ToString();

            }
            else
            {
                clsWebFormUtil.FillDropDownList(DrpDeduction, dt, 0, 2, true);
                txtDeductionAmount.Text = "";
            }
    }
    private void LoadDeductionsOnEdit()
    {
        DataTable dt = _cmpCtrl.SelectDeductions(Constants.IntNullValue, int.Parse(DrpDeductionType.SelectedValue), Int32.Parse(Session["CompanyId"].ToString()));

        if (dt.Rows.Count > 0)
        {
            clsWebFormUtil.FillDropDownList(DrpDeduction, dt, 0, 2, true);
        }     

    }
   
    public void LoadGirdAllowances()
    {
        DataTable dtAllowances = (DataTable)this.Session["dtAllowances"];
        Grid_Allowances.DataSource = dtAllowances;
        Grid_Allowances.DataBind();
    }
    public void LoadGirdDeductions()
    {
        DataTable dtDeductions = (DataTable)Session["dtDeductions"];
        Grid_Deductions.DataSource = dtDeductions;
        Grid_Deductions.DataBind();
    }

    private void GetEmployeeSalary()
    {
        txtSalaryDays.Text = "";
        txtBasicSalary.Text = "";
        txtSalaryDays.Text = "";
        Grid_Allowances.DataSource = null;
        Grid_Allowances.DataBind();
        Grid_Deductions.DataSource = null;
        Grid_Deductions.DataBind();
        Session.Remove("dtAllowances");
        Session.Remove("dtDeductions");
        CreateAllowances();
        CreateDeductions();

        DataTable dt = _cmpCtrl.SelectEmployeeSalary(int.Parse(DrpDistributor.SelectedValue), int.Parse(DrpEmployee.SelectedValue), DateTime.Parse(Session["CurrentWorkDate"].ToString()));
        if (dt != null)
        {
        Session.Add("dtEmployeeSalary", dt);
        DataRow[] foundRows = dt.Select("EMPLOYEE_ID = '" + DrpEmployee.SelectedValue + "'");

            if (dt.Rows.Count > 0)
            {

                DataTable dtAllowances =_cmpCtrl.SelectEmployeeAllowances(int.Parse(foundRows[0]["SALARY_ID"].ToString()));
                if (dtAllowances.Rows.Count > 0)
                {
                    Session.Add("dtAllowances", dtAllowances);
                    LoadGirdAllowances();
                }


                DataTable dtDeduction =_cmpCtrl.SelectEmployeeDeductions(int.Parse(foundRows[0]["SALARY_ID"].ToString()));
                if (dtDeduction.Rows.Count > 0)
                {
                    Session.Add("dtDeductions", dtDeduction);
                    LoadGirdDeductions();
                }
                txtBasicSalary.Text = foundRows[0]["SALARY_AMOUNT"].ToString();
                txtSalaryDays.Text = foundRows[0]["SALARY_DAYS"].ToString();
                hdnSalaryID.Value = foundRows[0]["salary_id"].ToString();
                btnSave.Text = "Update";
            }
        }
        else
        {
            txtBasicSalary.Text = "";
            txtSalaryDays.Text = "";
            Grid_Allowances.DataSource = null;
            Grid_Allowances.DataBind();
            Grid_Deductions.DataSource = null;
            Grid_Deductions.DataBind();
            Session.Remove("dtAllowances");
            Session.Remove("dtDeductions");
            CreateAllowances();
            CreateDeductions();
        }

    }

    #endregion

    #region Sel/Index Change

    protected void DrpDistributor_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtBasicSalary.Text = "";

        btnSave.Text = "Save";
        Grid_Allowances.DataSource = null;
        Grid_Allowances.DataBind();
        Grid_Deductions.DataSource = null;
        Grid_Deductions.DataBind();
        Session.Remove("dtAllowances");
        Session.Remove("dtDeductions");
        CreateAllowances();
        CreateDeductions();
        LoadEmployee();
        if (DrpEmployee.Items.Count > 0)
        {
            GetEmployeeSalary();
        }
     
    }
    protected void DrpDesignation_SelectedIndexChanged(object sender, EventArgs e)
    {
        btnSave.Text = "Save";
        LoadEmployee();
        GetEmployeeSalary();
    }
   
    protected void DrpEmployee_SelectedIndexChanged(object sender, EventArgs e)
    {
        btnSave.Text = "Save";
        GetEmployeeSalary();
    }

    protected void DrpAllowanceType_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadAllowances();

    }
    protected void DrpAllowance_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataTable dt = _cmpCtrl.SelectAllowances(Constants.IntNullValue,int.Parse(DrpAllowanceType.SelectedValue), Int32.Parse(Session["CompanyId"].ToString()));
       
        DataRow[] foundRows = dt.Select("AllowanceID = '" + DrpAllowance.SelectedValue + "'");
        txtAllowanceAmount.Text = foundRows[0]["AllowanceRatio"].ToString();

    }

    protected void DrpDeductionType_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadDeductions();
    }
    protected void DrpDeduction_SelectedIndexChanged(object sender, EventArgs e)
    {
       DataTable dt = _cmpCtrl.SelectDeductions(Constants.IntNullValue,int.Parse(DrpDeductionType.SelectedValue), Int32.Parse(Session["CompanyId"].ToString()));
       
        DataRow[] foundRows = dt.Select("DeductionId = '" + DrpDeduction.SelectedValue + "'");
        txtDeductionAmount.Text = foundRows[0]["DeductionRatio"].ToString();
        
       
    }

    #endregion

    #region Click OPerations
    private bool CheckDublicateAllowance()
    {
       
      DataTable  dtAllowances = (DataTable)Session["dtAllowances"];
        DataRow[] foundRows = dtAllowances.Select("ALLOWANCE_ID  = '" + DrpAllowance.SelectedItem.Value  + "'");
        if (foundRows.Length == 0)
        {
            return true;
        }
       
            return false;
    }
    private bool CheckDublicatededuction()
    {

        DataTable dtdeuction = (DataTable)Session["dtDeductions"];
        DataRow[] foundRows = dtdeuction.Select("DEDUCTION_ID  = '" + DrpDeduction.SelectedItem.Value + "'");
        if (foundRows.Length == 0)
        {
            return true;
        }
     
            return false;
     
    }
    protected void btnAdd_Allowance_Click(object sender, EventArgs e)
    {
        DataTable dtAllowances = (DataTable)Session["dtAllowances"];

        if (btnAdd_Allowance.Text == "Add")
        {
            if (DrpAllowance.Items.Count > 0)
            {
                if (CheckDublicateAllowance())
                {

                    DataRow dr = dtAllowances.NewRow();

                    dr["ALLOWANCE_DESC"] = DrpAllowance.SelectedItem.Text;
                    dr["ALLOWANCE_TYPE_ID"] = DrpAllowanceType.SelectedItem.Value;
                    dr["ALLOWANCE_ID"] = DrpAllowance.SelectedItem.Value;
                    dr["ALLOWANCE_AMOUNT"] = txtAllowanceAmount.Text;

                    dtAllowances.Rows.Add(dr);

                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('Allowance Already Exists!')", true);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('Plz Select Allowance!')", true);
            }
        }

        else
        {
            DataRow dr = dtAllowances.Rows[_allowanceId];

            dr["ALLOWANCE_DESC"] = DrpAllowance.SelectedItem.Text;
            dr["ALLOWANCE_TYPE_ID"] = DrpAllowanceType.SelectedItem.Value;
            dr["ALLOWANCE_ID"] = DrpAllowance.SelectedItem.Value;
            dr["ALLOWANCE_AMOUNT"] = txtAllowanceAmount.Text;

        }

        Session.Add("dtAllowances", dtAllowances);

        LoadGirdAllowances();
        ClearAllowanceDetail();

        var scriptManager = ScriptManager.GetCurrent(Page);
        if (scriptManager != null) scriptManager.SetFocus(DrpAllowance);
    }
    protected void btnAdd_Deduction_Click(object sender, EventArgs e)
    {
        DataTable dtDeductions = (DataTable)Session["dtDeductions"];

        if (btnAdd_Deduction.Text == "Add")
        {
            if (DrpAllowance.Items.Count > 0)
            {
                if (CheckDublicatededuction())
                {
                    DataRow dr = dtDeductions.NewRow();

                    dr["DEDUCTION_DESC"] = DrpDeduction.SelectedItem.Text;
                    dr["DEDUCTION_DATE"] = txtDeuductionDate.Text;
                    dr["DEDUCTION_TYPE_ID"] = DrpDeductionType.SelectedItem.Value;
                    dr["DEDUCTION_ID"] = DrpDeduction.SelectedItem.Value;
                    dr["DEDUCTION_AMOUNT"] = txtDeductionAmount.Text;

                    dtDeductions.Rows.Add(dr);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('Deduction Already Exists!')", true);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('Plz Select Deduction!')", true);
            }
        }
     

        else
        {
            DataRow dr = dtDeductions.Rows[_deductionId];

            dr["DEDUCTION_DESC"] = DrpDeduction.SelectedItem.Text;
            dr["DEDUCTION_DATE"] = txtDeuductionDate.Text;
            dr["DEDUCTION_TYPE_ID"] = DrpDeductionType.SelectedItem.Value;
            dr["DEDUCTION_ID"] = DrpDeduction.SelectedItem.Value;
            dr["DEDUCTION_AMOUNT"] = txtDeductionAmount.Text;
        }

        Session.Add("dtDeductions", dtDeductions);

        LoadGirdDeductions();

        ClearDeductionDetail();

        var scriptManager = ScriptManager.GetCurrent(Page);
        if (scriptManager != null) scriptManager.SetFocus(DrpDeduction);
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (IsValid)
        {
            bool flag = true;

            var dtAllowances = (DataTable)Session["dtAllowances"];
            var dtDeductions = (DataTable)Session["dtDeductions"];

            switch (btnSave.Text)
            {
                case "Save":
                    flag = _empsalCtrl.Add_Salary(int.Parse(DrpDistributor.SelectedValue), int.Parse(DrpDesignation.SelectedValue), int.Parse(DrpEmployee.SelectedValue)
                        , decimal.Parse(txtBasicSalary.Text), int.Parse(txtSalaryDays.Text), DateTime.Parse(Session["CurrentWorkDate"].ToString()), int.Parse(Session["Userid"].ToString()), DateTime.Parse(Session["CurrentWorkDate"].ToString()), dtAllowances, dtDeductions);
                    break;
                case "Update":
                    flag = _empsalCtrl.Update_Salary(int.Parse(hdnSalaryID.Value), int.Parse(DrpDistributor.SelectedValue), int.Parse(DrpDesignation.SelectedValue), int.Parse(DrpEmployee.SelectedValue)
                        , decimal.Parse(txtBasicSalary.Text), int.Parse(txtSalaryDays.Text), DateTime.Parse(Session["CurrentWorkDate"].ToString()), int.Parse(Session["Userid"].ToString()), DateTime.Parse(Session["CurrentWorkDate"].ToString()), dtAllowances, dtDeductions);
                    break;
            }
            if (flag)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "msg", "alert('Record Updated!')", true);
                ClearMasterAll();
            }
        }

    }

    #endregion

    #region Grid Operations

    protected void Grid_Allowances_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            _allowanceId = e.NewEditIndex;
            DrpAllowanceType.SelectedValue = Grid_Allowances.Rows[e.NewEditIndex].Cells[3].Text;
            LoadAllowancesOnEdit();
            DrpAllowance.SelectedValue = Grid_Allowances.Rows[e.NewEditIndex].Cells[0].Text;
            txtAllowanceAmount.Text = Grid_Allowances.Rows[e.NewEditIndex].Cells[2].Text;
            
            btnAdd_Allowance.Text = "Update";
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }

    }
    protected void Grid_Deductions_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            _deductionId = e.NewEditIndex;
            DrpDeductionType.SelectedValue = Grid_Deductions.Rows[e.NewEditIndex].Cells[4].Text;
            LoadDeductionsOnEdit();
            DrpDeduction.SelectedValue = Grid_Deductions.Rows[e.NewEditIndex].Cells[0].Text;
            txtDeuductionDate.Text = Grid_Deductions.Rows[e.NewEditIndex].Cells[2].Text;
            txtDeductionAmount.Text = Grid_Deductions.Rows[e.NewEditIndex].Cells[3].Text;
           

            btnAdd_Deduction.Text= "Update";
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }

    }
    protected void Grid_Allowances_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        DataTable dtAllowances = (DataTable)Session["dtAllowances"];
        dtAllowances.Rows.RemoveAt(e.RowIndex);
        Session.Add("dtAllowances", dtAllowances);

        LoadGirdAllowances();


    }
    protected void Grid_Deductions_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        DataTable dtDeductions = (DataTable)Session["dtDeductions"];
        dtDeductions.Rows.RemoveAt(e.RowIndex);
        Session.Add("dtDeductions", dtDeductions);

        LoadGirdDeductions();


    }

    #endregion

    #region Clear

    private void ClearAllowanceDetail()
    {
        txtAllowanceAmount.Text = "";
        btnAdd_Allowance.Text = "Add";
        LoadAllowances();
    }
    private void ClearDeductionDetail()
    {
        txtDeductionAmount.Text = "";
        btnAdd_Deduction.Text = "Add";
        LoadDeductions();
    }
    private void ClearMasterAll()
    {
        txtBasicSalary.Text = "";
        txtSalaryDays.Text = "";
        Grid_Allowances.DataSource = null;
        Grid_Allowances.DataBind();
        Grid_Deductions.DataSource = null;
        Grid_Deductions.DataBind();
        Session.Remove("dtAllowances");
        Session.Remove("dtDeductions");
        btnSave.Text = "Save";
        LoadDistributor();
        LoadDesignation();
        LoadEmployee();
        LoadAllowanceType();
        LoadAllowances();

        LoadDeductionsOnEdit();
        LoadDeductions();
        CreateAllowances();
        CreateDeductions();
        
        GetEmployeeSalary();

    }

    #endregion
   
}