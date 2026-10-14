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
using SAMS.Common.Classes;    
public partial class Forms_SamsLogin : System.Web.UI.Page
{
    SAMSUserController mController = new SAMSUserController(); 
    Panel panel = new Panel();
    public void ValidateUser()
    {

        if (txtLogin.Text == "" && txtPassword.Text == "")
        {
            return;
        }
        else
        {
            DataTable dt = mController.SelectSlashUser(txtLogin.Text, txtPassword.Text);
            this.Session.Clear();  
            if (dt.Rows.Count > 0)
            {
                            
                this.Session.Add("UserID",Convert.ToInt32(dt.Rows[0]["USER_ID"].ToString()));
                this.Session.Add("UserName",dt.Rows[0]["USER_NAME"].ToString());
                this.Session.Add("DISTRIBUTOR_ID", Convert.ToInt32(dt.Rows[0]["DISTRIBUTOR_ID"].ToString()));
                this.Session.Add("CompanyId", Convert.ToInt32(dt.Rows[0]["COMPANY_ID"].ToString()));  
                LastClosedDay(Convert.ToInt32(dt.Rows[0]["USER_ID"].ToString()), int.Parse(dt.Rows[0]["DISTRIBUTOR_ID"].ToString()));
                LoadTreeView(int.Parse(dt.Rows[0]["ROLE_ID"].ToString()), dt.Rows[0]["User_Name"].ToString());

                this.Panel1.Visible = false;
                Label1.Text = "Distributor Status";
                AppMaster master = new AppMaster();
                master = (AppMaster)this.Master;
                panel = master.FindControl("searchpanel") as Panel;
                panel.Visible = true;
                //DisplayTreeViw();
                
            }
            else
            {
                lblErrorMsg.Visible = true;
                lblErrorMsg.Text = "Wrong User Id/Password";
                return;
            }
        }

    }
    private void LoadTreeView(int RoleId, string UserName)
    {

        AppMaster myMaster;
        TreeView tr;
        Label lblUserId;
        Label lblCurrentWorkDate;
        myMaster = (AppMaster)this.Master;
        tr = myMaster.FindControl("tr") as TreeView;
        lblUserId = myMaster.FindControl("Label1") as Label;
        lblCurrentWorkDate = myMaster.FindControl("lblCurrentWorkDate") as Label;
        lblCurrentWorkDate.Text = "Working Date " + ((DateTime)this.Session["CurrentWorkDate"]).ToString("dd-MMM-yyyy"); 
        lblUserId.Text = UserName;
        tr.Nodes.Clear();
        TreeNode trMaster;
        TreeNode trChaild;
        TreeNode SubChaild;
        TreeNode DetailChaild;
        RoleManagementController ObjSelect = new RoleManagementController();
        #region Parent Node

        DataTable dtChaild = ObjSelect.SelectRoleWiseModule(RoleId, 1, Constants.IntNullValue);

        for (int j = 0; j < dtChaild.Rows.Count; j++)
        {
            trMaster = new TreeNode(dtChaild.Rows[j]["MODULE_DESCRIPTION"].ToString(), dtChaild.Rows[j]["MODULE_ID"].ToString());

            DataTable dtSubChaild = ObjSelect.SelectRoleWiseModule(RoleId, 2, int.Parse(dtChaild.Rows[j]["MODULE_ID"].ToString()));

            for (int k = 0; k < dtSubChaild.Rows.Count; k++)
            {
                trChaild = new TreeNode(dtSubChaild.Rows[k]["MODULE_DESCRIPTION"].ToString(), dtSubChaild.Rows[k]["MODULE_ID"].ToString());


                DataTable dtDetailChaild = ObjSelect.SelectRoleWiseModule(RoleId, 3, int.Parse(dtSubChaild.Rows[k]["MODULE_ID"].ToString()));

                for (int l = 0; l < dtDetailChaild.Rows.Count; l++)
                {
                    SubChaild = new TreeNode(dtDetailChaild.Rows[l]["MODULE_DESCRIPTION"].ToString(), dtDetailChaild.Rows[l]["MODULE_ID"].ToString());

                    DataTable dt = ObjSelect.SelectRoleWiseModule(RoleId, 4, int.Parse(dtDetailChaild.Rows[l]["MODULE_ID"].ToString()));

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        DetailChaild = new TreeNode(dt.Rows[i]["MODULE_DESCRIPTION"].ToString(), dt.Rows[i]["MODULE_ID"].ToString());
                        SubChaild.ChildNodes.Add(DetailChaild);    
                    }
                    trChaild.ChildNodes.Add(SubChaild);
               }
               trMaster.ChildNodes.Add(trChaild);
            }
            tr.Nodes.Add(trMaster);
            this.Session.Add("trMaster", trMaster);
        }
       
        
        #endregion
    }
    private void LastClosedDay(int UserId,int p_Distributor)
    {
        SAMSUserController mDayClose = new SAMSUserController();
        DataTable dt = mDayClose.SelectMaxDayClose(UserId, p_Distributor);
        if (dt.Rows.Count > 0)
        {
            this.Session.Add("CurrentWorkDate", DateTime.Parse(dt.Rows[0]["CLOSING_DATE"].ToString()));
            
        }
        else
        {
            this.Session.Add("CurrentWorkDate", DateTime.Now);

            
            
        }
        AppMaster myMaster;
        myMaster = (AppMaster)this.Master;
        Label lblCurrentWorkDate;
        lblCurrentWorkDate = myMaster.FindControl("lblCurrentWorkDate") as Label;
        lblCurrentWorkDate.Text = "Working Date " + ((DateTime)this.Session["CurrentWorkDate"]).ToString("dd-MMM-yyyy"); 

    }
    protected void btnSignin02_Click(object sender, ImageClickEventArgs e)
    {
        ValidateUser();
    }
   
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!Page.IsPostBack)
        {
            this.ValidateUser();
            txtLogin.Focus();
            //Button1.Attributes.Add("onclick", "return ConfirmCancel()");
        }
    }
  
    
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        return;
    }
    protected void Grid_Brand_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        //if (Button1.Visible == true)
        //{
        //    SAMSUserController mDayClose = new SAMSUserController();
        //    bool dt = mDayClose.UspDayClose(DateTime.Parse(this.Session["CurrentWorkDate"].ToString()), int.Parse(this.Session["DISTRIBUTOR_ID"].ToString()), int.Parse(this.Session["UserID"].ToString()));
        //    if (dt == false)
        //    {
        //        ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert(' Some error in day Close Contact System Administrator');", true);
        //    }
        //    else
        //    {
        //        LastClosedDay(int.Parse(this.Session["UserId"].ToString()), int.Parse(this.Session["DISTRIBUTOR_ID"].ToString()));
        //        Button1.Visible = false;
        //        ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('Day Close Sucessfully');", true);
        //    }
        //}
    }
}
