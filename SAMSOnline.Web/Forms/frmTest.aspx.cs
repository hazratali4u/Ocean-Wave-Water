using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using SAMS.BusinessLayer.Classes;
using System.Text;   
public partial class Forms_frmTest : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            CustomerDataController mController = new CustomerDataController();
            DataTable dt = mController.RptSelectCustomer(1, 1222, "Customer_name","");
            this.Grid_users.DataSource = dt;
            this.Grid_users.DataBind();
        }                      
        
    
    }

    private void LoadGrid()
    {
        CustomerDataController mController = new CustomerDataController();
        DataTable dt = mController.RptSelectCustomer(1, 1222, "Customer_name", txtSeach.Text);
        this.Grid_users.DataSource = dt;
        this.Grid_users.DataBind();
    }
    protected void txtSeach_TextChanged(object sender, EventArgs e)
    {
        this.LoadGrid(); 
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
      this.LoadGrid(); 
    }
}
