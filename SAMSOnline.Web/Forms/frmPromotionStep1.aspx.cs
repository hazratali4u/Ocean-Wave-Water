using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using SAMS.BusinessLayer.Classes;
using SAMS.Common.Classes;    

public partial class Forms_frmPromotionStep1 : System.Web.UI.Page
{
    public void FillScheme()
    {

        SchemeController mSchemController = new SchemeController();
        DataTable dtScheme = mSchemController.SelectScheme(Constants.IntNullValue, SAMS.Common.Classes.Configuration.DistributorId, null, null, Constants.DateNullValue);
        drpScheme.Items.Clear();
        drpScheme.Items.Add(new clsListItems("ALL", "0"));
        drpScheme.DataSource = dtScheme;
        clsWebFormUtil.FillDropDownList(this.drpScheme, dtScheme, "SCHEME_ID", "SCHEME_CODE");
    }
    private void LoadGrid()
    {
        DataTable dt = (DataTable)this.Session["dt"];
        switch (ddSearchType.SelectedIndex)
        {

            case 1:
                dt.DefaultView.RowFilter = ddSearchType.SelectedValue.ToString() + " like '%" + txtSeach.Text + "%'";
                break;
            case 2:
                dt.DefaultView.RowFilter = ddSearchType.SelectedValue.ToString() + " =" + txtSeach.Text;
                break;
            case 3:
                dt.DefaultView.RowFilter = ddSearchType.SelectedValue.ToString() + " like '%" + txtSeach.Text + "%'";
                break;
            case 4:
                dt.DefaultView.RowFilter = ddSearchType.SelectedValue.ToString() + " like '%" + txtSeach.Text + "%'";
                break;
            case 5:
                dt.DefaultView.RowFilter = ddSearchType.SelectedValue.ToString() + " like '%" + txtSeach.Text + "%'";
                break;
           default:
               dt.DefaultView.RowFilter = "PROMOTION_CODE" + " like '%" + "" + "%'";
                break;
        }
        Grid_pricedetails.DataSource = dt;
        Grid_pricedetails.DataBind();  
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            FillScheme();
            btnPromotion.Attributes.Add("onclick", "return ValidateForm()");
        }
    }
    protected void drpScheme_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void btnPromotion_Click(object sender, EventArgs e)
    {
        SchemeController mController = new SchemeController();
        
        
        if (btnPromotion.Text == "Get Promotion")
        {
            string FromDate = txtFromdate.Text + " 00:00:00";
            string ToDate = txttoDate.Text + " 23:59:59";

            DataTable dt = mController.SelectPromotion(FromDate, ToDate,int.Parse(this.Session["UserId"].ToString()),ChbActive.Checked);
            this.Session.Add("dt", dt);  
            Grid_pricedetails.DataSource = dt;
            Grid_pricedetails.DataBind();  
        }
    }
    protected void Grid_pricedetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        Grid_pricedetails.PageIndex = e.NewPageIndex;
        LoadGrid();
        
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        LoadGrid();
    }
    protected void Grid_pricedetails_RowEditing(object sender, GridViewEditEventArgs e)
    {
       bool IsEditing = true;
       string flow = "f";
       string PromotionId =  Grid_pricedetails.Rows[e.NewEditIndex].Cells[1].Text;
       this.Session.Add("PromotionId", PromotionId);
       this.Session.Add("IsEdit", IsEditing);
       this.Session.Add("Flow", flow);
       Response.Redirect("frmPromotionStep2.aspx?LevelType=3&LevelID=" + Request.QueryString["LevelID"].ToString(), true);
    }
    protected void ImgBntFromCalc_Click(object sender, ImageClickEventArgs e)
    {
        
        txtFromdate.Text = null;
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        this.Session.Add("IsEdit", false);
        Response.Redirect("frmPromotionStep2.aspx?LevelType=3&LevelID=" + Request.QueryString["LevelID"].ToString(), true);
    }
    protected void Grid_pricedetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        PromotionController mController = new PromotionController();
        SchemeController SController = new SchemeController();

        int PromotionId = int.Parse(Grid_pricedetails.Rows[e.RowIndex].Cells[1].Text);
        int SchemeId = int.Parse(Grid_pricedetails.Rows[e.RowIndex].Cells[0].Text);
        
        mController.UpdatePromotion(PromotionId,SchemeId,int.Parse(this.Session["DISTRIBUTOR_ID"].ToString()), null, null, Constants.DateNullValue, false, Constants.DateNullValue, Constants.DateNullValue, false, Constants.IntNullValue, Constants.IntNullValue);

        string FromDate = txtFromdate.Text + " 00:00:00";
        string ToDate = txttoDate.Text + " 23:59:59";

        DataTable dt = SController.SelectPromotion(FromDate, ToDate,int.Parse(this.Session["UserId"].ToString()),ChbActive.Checked);
        this.Session.Add("dt", dt);
        Grid_pricedetails.DataSource = dt;
        Grid_pricedetails.DataBind();  
    }

}
