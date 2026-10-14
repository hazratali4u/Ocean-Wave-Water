using System;
using System.Data;
using System.IO;
using System.Web.UI;
using SAMS.BusinessLayer.Classes;
using SAMS.Common.Classes;  

public partial class Forms_frmImportData : System.Web.UI.Page
{
    CustomerDataController mCustomer = new CustomerDataController();
    private void LoadTown()
    {
        GeoHierarchyController GControler = new GeoHierarchyController();
        DataTable dt = GControler.SelectGeoHierarchy(Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, null, null, true, Constants.IntNullValue, Constants.Town, Constants.IntNullValue, Constants.DateNullValue, Constants.DateNullValue, int.Parse(this.Session["CompanyId"].ToString()));
        clsWebFormUtil.FillDropDownList(DrpTown, dt, 0, 4, true);
    }
    private void LoadDistributor()
    {
        DistributorController mController = new DistributorController();
        DataTable dt = mController.SelectDistributorInfo(Constants.IntNullValue, int.Parse(this.Session["UserId"].ToString()), int.Parse(this.Session["CompanyId"].ToString()));
        clsWebFormUtil.FillDropDownList(DrpDistributor, dt, 0, 2, true);

    }
    private void LoadPrincipal()
    {
        SKUPriceDetailController PController = new SKUPriceDetailController();
        DataTable m_dt = PController.SelectDataPrice(Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, int.Parse(this.Session["UserId"].ToString()), Constants.IntNullValue, 0, DateTime.Parse(this.Session["CurrentWorkDate"].ToString()));
        clsWebFormUtil.FillDropDownList(this.DrpPrincipal, m_dt, 0, 1, true);
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.LoadTown();
            this.LoadDistributor();
            this.LoadPrincipal(); 
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        #region FileValidation
        if (txtFile.PostedFile.ContentLength == 0)
        {
            lblErrorMessage.Text = "Please select a file and then upload";
            return;
        }
        else if (txtFile.PostedFile.ContentType != "text/plain")
        {
            lblErrorMessage.Text = "Only text file are supported";
            return;
        }
        #endregion

        try
        {

            if (!Directory.Exists(Constants.fldOtherDataFolder))
            {
                Directory.CreateDirectory(Constants.fldOtherDataFolder);
            }

            string path = System.IO.Path.GetFullPath(txtFile.PostedFile.FileName);
            string filename = path.Substring(path.LastIndexOf('\\'), path.Length - path.LastIndexOf('\\'));
            if (File.Exists(Constants.fldOtherDataFolder + filename))
            {
                lblErrorMessage.Text = "File already Exist in folder. Save file with other name";
                cboFileTypes.SelectedIndex = 0;
                return;
            }
            else
            {
                txtFile.PostedFile.SaveAs(Constants.fldOtherDataFolder + filename);
                path = Constants.fldOtherDataFolder + filename;
                int index = cboFileTypes.SelectedIndex;
                this.lblErrorMessage.Text = "";
                if (cboFileTypes.SelectedIndex == 0)
                {
                    mCustomer.ImportRoute(int.Parse(DrpTown.SelectedValue.ToString()), int.Parse(DrpDistributor.SelectedValue.ToString()), path, int.Parse(this.Session["UserId"].ToString()));
                }
                else if (cboFileTypes.SelectedIndex == 1)
                {
                    mCustomer.ImportMarket(int.Parse(DrpTown.SelectedValue.ToString()), int.Parse(DrpDistributor.SelectedValue.ToString()), path, int.Parse(this.Session["UserId"].ToString()));
                }
                else if (cboFileTypes.SelectedIndex == 2)
                {
                    mCustomer.ImportCustomer(int.Parse(DrpTown.SelectedValue.ToString()), int.Parse(DrpDistributor.SelectedValue.ToString()), path);
                }
                else if (cboFileTypes.SelectedIndex == 4)
                {
                    mCustomer.ImportSKUPrices(int.Parse(DrpDistributor.SelectedValue.ToString()), path, int.Parse(DrpPrincipal.SelectedValue.ToString()));
                }

            }
        }
        catch (Exception excp)
        {
            lblErrorMessage.Text = excp.ToString();
            cboFileTypes.SelectedIndex = 0;
            return;
        }
    }

}
