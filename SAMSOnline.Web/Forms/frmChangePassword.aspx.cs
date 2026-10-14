using System;
using System.Data;
using System.Web.UI;
using SAMS.BusinessLayer.Classes;
using SAMS.Common.Classes; 

public partial class Forms_fmChangePassword : System.Web.UI.Page
{
    SAMSUserController UserInfo = new SAMSUserController();
    DataTable dtLogin_ID = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!Page.IsPostBack)
        {
            btnSave.Attributes.Add("onclick", "return ValidatePassword();");   
        }
    }
    protected bool UpdatePassword()
    {
        try
        {
            dtLogin_ID = UserInfo.SelectSlashUser(Convert.ToInt32(Session["UserID"].ToString()));
            if (SAMS.Common.Classes.Cryptography.Encrypt(this.txtCurrentPassword.Text,"b0tin@74") == dtLogin_ID.Rows[0]["PASSWORD"].ToString())
            {
                UserInfo.UpdateSlashUser(Convert.ToInt32(Session["UserID"].ToString()), Convert.ToInt32(Session["CompanyId"]), dtLogin_ID.Rows[0]["LOGIN_ID"].ToString(), SAMS.Common.Classes.Cryptography.Encrypt(this.txtConfirmNewPassword.Text, "b0tin@74"), Constants.IntNullValue, true, Convert.ToInt32(Session["DISTRIBUTOR_ID"].ToString()));
                return true;
            }
            else 
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('Current Password is wrong ');", true); 
                return false;
            }
        }
        catch(Exception ex)
        {
            ex.ToString();
            return false;
        }
    }
    protected void btnSave_Click1(object sender, EventArgs e)
    {
        bool status = UpdatePassword();
        if (status == true)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('Password has changed successfully ');", true); 
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        this.txtCurrentPassword.Text    = null;
        this.txtNewPassword.Text        = null;
        this.txtConfirmNewPassword.Text = null;
    }
}
