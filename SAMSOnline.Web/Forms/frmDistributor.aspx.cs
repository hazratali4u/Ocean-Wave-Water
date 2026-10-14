using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using SAMS.BusinessLayer.Classes;
using SAMS.Common.Classes;    

public partial class Forms_frmDistributor : System.Web.UI.Page
{
    DistributorController mController = new DistributorController();
    private static int DistributorId;
    private static int CompanyId;
    private void GetDistributorType()
    {
        DataTable dt  = mController.SelectDistributorTypeInfo(Constants.IntNullValue);
        clsWebFormUtil.FillDropDownList(ddDistributorType, dt, 0, 2);   
    }
    private void LoadGird()
    {
        if (ddDistributorType.Items.Count > 0)
        {
            DataTable dtDistributor = mController.SelectDistributor(Constants.IntNullValue,Constants.IntNullValue, Constants.IntNullValue);

            switch (ddSearchType.SelectedIndex)
            {
                case 1:
                    dtDistributor.DefaultView.RowFilter = ddSearchType.SelectedValue.ToString() + " like '%" + txtSeach.Text + "%'";
                    break;
                case 2:
                    dtDistributor.DefaultView.RowFilter = ddSearchType.SelectedValue.ToString() + " like '%" + txtSeach.Text + "%'";
                    break;
                case 3:
                    dtDistributor.DefaultView.RowFilter = ddSearchType.SelectedValue.ToString() + " like '%" + txtSeach.Text + "%'";
                    break;
                case 4:
                    dtDistributor.DefaultView.RowFilter = ddSearchType.SelectedValue.ToString() + " like '%" + txtSeach.Text + "%'";
                    break;
                case 5:
                    dtDistributor.DefaultView.RowFilter = ddSearchType.SelectedValue.ToString() + " like '%" + txtSeach.Text + "%'";
                    break;
                default:
                    dtDistributor.DefaultView.RowFilter = "Distributor_name" + " like '%" + "" + "%'";
                    break;
            }

            GridDistributor.DataSource = dtDistributor;
            GridDistributor.Columns[0].Visible = true;
            GridDistributor.Columns[1].Visible = true;
            GridDistributor.Columns[2].Visible = true;
            GridDistributor.Columns[3].Visible = true;
            GridDistributor.Columns[11].Visible = true;
            GridDistributor.DataBind();
            GridDistributor.Columns[0].Visible = false;
            GridDistributor.Columns[1].Visible = false;
            GridDistributor.Columns[2].Visible = false;
            GridDistributor.Columns[3].Visible = false;
            GridDistributor.Columns[11].Visible = false;
        }
        
    }
    private void ClearAll()
    {
        txtDistributorName.Text = "";
        txtDistributorCode.Text = "";
        txtAddress1.Text = "";
        txtAddress2.Text = "";
        txtcontactperson.Text = "";
        txtPhoneNo.Text = "";
        txtpassword.Text = "";
        txtgstno.Text = ""; 
        btnSave.Text = "Save";
        CheckBox1.Checked = false;  
    }
    private void LoadCompany()
    {
        CompanyController mCompany = new CompanyController();
        DataTable dt = mCompany.SelectCompany(Constants.IntNullValue, Constants.IntNullValue);
        clsWebFormUtil.FillDropDownList(DrpCompanyName, dt, 0, 1,true);   
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.GetDistributorType();
            this.LoadGird();
            this.LoadCompany(); 
            btnSave.Attributes.Add("onclick", "return ValidateForm()");            
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (btnSave.Text == "Save")
        {
            mController.InsertDistributor(int.Parse(DrpCompanyName.SelectedValue.ToString()),Constants.IntNullValue, false, System.DateTime.Now, System.DateTime.Now, Constants.IntNullValue, Constants.IntNullValue
                , Constants.IntNullValue, Constants.IntNullValue, int.Parse(ddDistributorType.SelectedValue.ToString()), txtcontactperson.Text , txtPhoneNo.Text, txtgstno.Text,
                txtpassword.Text, txtAddress1.Text, txtAddress2.Text, txtDistributorCode.Text, txtDistributorName.Text, null, CheckBox1.Checked, 1, int.Parse(this.Session["UserId"].ToString()));

        }
        else
        {
            mController.UpdateDistributor(int.Parse(DrpCompanyName.SelectedValue.ToString()),Constants.IntNullValue, false, Constants.DateNullValue, System.DateTime.Now, Constants.IntNullValue, Constants.IntNullValue
            ,Constants.IntNullValue, Constants.IntNullValue, int.Parse(ddDistributorType.SelectedValue.ToString()),txtcontactperson.Text ,txtPhoneNo.Text,txtgstno.Text,
            txtpassword.Text, txtAddress1.Text, txtAddress2.Text, DistributorId, txtDistributorCode.Text, txtDistributorName.Text, null, CheckBox1.Checked, 1, int.Parse(this.Session["UserId"].ToString()));
        }
       lblErrorMsg.Text = "";
       ClearAll();
       this.LoadGird(); 
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        ClearAll();
    }
    protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
    {
        if (CheckBox1.Checked == true)
        {
            txtgstno.Enabled = true;
            txtgstno.Focus();  
        }
        else
        {
            txtgstno.Text = "";
            txtgstno.Enabled = false;  
        }
    }
    protected void GridDistributor_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        this.GridDistributor.PageIndex = e.NewPageIndex;
        this.LoadGird(); 
    }
    protected void ddDistributorType_SelectedIndexChanged(object sender, EventArgs e)
    {
        //this.LoadGird(); 
    }
    protected void GridDistributor_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        DistributorId = int.Parse(GridDistributor.Rows[e.RowIndex].Cells[0].Text);
        CompanyId = int.Parse(GridDistributor.Rows[e.RowIndex].Cells[11].Text); 
        bool IsRegister = bool.Parse(GridDistributor.Rows[e.RowIndex].Cells[1].Text); 
        mController.UpdateDistributor(CompanyId,Constants.IntNullValue, true, Constants.DateNullValue, System.DateTime.Now, Constants.IntNullValue, Constants.IntNullValue
               ,Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue,null,null,null,null,null,null,DistributorId,null,
               null, null, true, 1, int.Parse(this.Session["UserId"].ToString()));
        this.LoadGird();   
    }
    protected void GridDistributor_RowEditing(object sender, GridViewEditEventArgs e)
    {
        DistributorId = int.Parse(GridDistributor.Rows[e.NewEditIndex].Cells[0].Text);
        DrpCompanyName.SelectedValue =GridDistributor.Rows[e.NewEditIndex].Cells[11].Text; 
        CheckBox1.Checked = bool.Parse(GridDistributor.Rows[e.NewEditIndex].Cells[1].Text);
        ddDistributorType.SelectedValue = GridDistributor.Rows[e.NewEditIndex].Cells[2].Text;
        txtAddress2.Text = GridDistributor.Rows[e.NewEditIndex].Cells[3].Text;
        txtDistributorCode.Text = GridDistributor.Rows[e.NewEditIndex].Cells[4].Text;
        txtDistributorName.Text = GridDistributor.Rows[e.NewEditIndex].Cells[5].Text;
        txtAddress1.Text = GridDistributor.Rows[e.NewEditIndex].Cells[7].Text;
        txtcontactperson.Text = GridDistributor.Rows[e.NewEditIndex].Cells[8].Text;
        txtPhoneNo.Text = GridDistributor.Rows[e.NewEditIndex].Cells[9].Text;
        if (GridDistributor.Rows[e.NewEditIndex].Cells[10].Text == "&nbsp;")
        {
            txtgstno.Text = "";
        }
        else
        {
            txtgstno.Text = GridDistributor.Rows[e.NewEditIndex].Cells[10].Text;
        }
        btnSave.Text = "Update"; 
        
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        this.LoadGird(); 
    }
}
