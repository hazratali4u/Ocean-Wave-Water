using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using SAMS.BusinessLayer.Classes;

public partial class _Login : System.Web.UI.Page
{
    SAMSUserController mController = new SAMSUserController();
    DistributorController mDist = new DistributorController();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            try
            {
                if (Convert.ToInt32(Session["UserID"]) > 0)
                {
                    Response.Redirect("Forms/Home.aspx");
                }
            }
            catch (Exception ex)
            {
                txtLogin.Focus();
            }

          //  DataTable dtLicenseData = mDist.GetLicenseData();
            //if (dtLicenseData.Rows.Count > 0)
            //{
            //    if (Convert.ToInt32(dtLicenseData.Rows[0]["DAYS"]) >= 90)
            //    {
            //        Response.Redirect("License.aspx");
            //    }
            //    else
            //    {
            //        txtLogin.Focus();
            //    }
            //}
            txtLogin.Focus();
        }
    }

    protected void btnSignIn_Click(object sender, EventArgs e)
    {
        try
        {
            //if (System.Configuration.ConfigurationManager.AppSettings["ComputerInfo"].ToString() == SAMS.Common.Classes.Cryptography.Encrypt(SAMS.Common.Classes.ComputerInfo.Value(), "b0tin@74"))
            //{
            //    ValidateUser();
            //}
            //else
            //{
            //    lblErrorMsg.Visible = true;
            //    lblErrorMsg.Text = "Invalid Key. Contact to Administrator.";
            //}
            ValidateUser();
        }
        catch (Exception ex)
        {

        }   
    }

    public void ValidateUser()
    {

        if (txtLogin.Text == "" && txtPassword.Text == "")
        {
            return;
        }
        else
        {
            DataTable dt = mController.SelectSlashUser(txtLogin.Text, SAMS.Common.Classes.Cryptography.Encrypt(txtPassword.Text,"b0tin@74"));
            this.Session.Clear();
            if (dt.Rows.Count > 0)
            {
                this.Session.Add("UserID", Convert.ToInt32(dt.Rows[0]["USER_ID"].ToString()));
                this.Session.Add("UserName", dt.Rows[0]["USER_DETAIL"].ToString());
                this.Session.Add("DISTRIBUTOR_ID", Convert.ToInt32(dt.Rows[0]["DISTRIBUTOR_ID"]));
                this.Session.Add("CompanyId", Convert.ToInt32(dt.Rows[0]["COMPANY_ID"].ToString()));
                this.Session.Add("RoleID", Convert.ToInt32(dt.Rows[0]["ROLE_ID"]));
                LastClosedDay(Convert.ToInt32(dt.Rows[0]["USER_ID"]), Convert.ToInt32(dt.Rows[0]["DISTRIBUTOR_ID"]));
                this.Session.Add("UserName2", dt.Rows[0]["USER_NAME"].ToString());
                this.Session.Add("UserName", dt.Rows[0]["USER_DETAIL"].ToString());
                Response.Redirect("Forms/Home.aspx");
            }
            else
            {
                lblErrorMsg.Visible = true;
                lblErrorMsg.Text = "Wrong User Id/Password";
                return;
            }
        }
    }

    private void LastClosedDay(int UserId, int p_Distributor)
    {
        SAMSUserController mDayClose = new SAMSUserController();
        DataTable dt = mDayClose.SelectMaxDayClose(UserId, p_Distributor);
        if (dt.Rows.Count > 0)
        {
            this.Session.Add("CurrentWorkDate", DateTime.Parse(dt.Rows[0]["CLOSING_DATE"].ToString()));

        }
        else
        {
            this.Session.Add("CurrentWorkDate", Convert.ToDateTime(DateTime.Now.ToString("dd-MMM-yyyy")));
        }        
    }
}