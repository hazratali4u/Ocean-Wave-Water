using System;
using System.Data;
using System.Web.UI;
using SAMS.BusinessLayer.Classes;

public partial class Forms_frmDayCloseStatus : System.Web.UI.Page
{
    DistributorController mController = new DistributorController();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LastClosedDay(int.Parse(this.Session["UserId"].ToString()), int.Parse(this.Session["Distributor_Id"].ToString()));           
        }
    }
    private void LastClosedDay(int UserId, int p_Distributor)
    {
        SAMSUserController mDayClose = new SAMSUserController();
        DataTable dt = mDayClose.SelectMaxDayClose(UserId, p_Distributor);
        if (dt.Rows.Count > 0)
        {
            this.Session.Add("CurrentWorkDate", DateTime.Parse(dt.Rows[0]["CLOSING_DATE"].ToString()));
            Button1.Visible = true;
        }
        else
        {
           this.Session.Add("CurrentWorkDate", DateTime.Now);
        }
        
        DataTable dtable = mController.MaxDayClose(int.Parse(this.Session["UserId"].ToString()));
        Grid_Hierarchy.DataSource = dtable;
        Grid_Hierarchy.DataBind();

       
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (Button1.Visible == true)
        {
            SAMSUserController mDayClose = new SAMSUserController();
            bool dt = mDayClose.UspDayClose(DateTime.Parse(this.Session["CurrentWorkDate"].ToString()), int.Parse(this.Session["DISTRIBUTOR_ID"].ToString()), int.Parse(this.Session["UserID"].ToString()));
            if (dt == false)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert(' Some error in day Close Contact System Administrator');", true);
            }
            else
            {
                this.Session.Clear();
                Response.Redirect("~/Login.aspx?Status=" + false); 

            }

           
        }
    }
}
