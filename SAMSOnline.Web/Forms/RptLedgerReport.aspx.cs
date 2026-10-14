using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using SAMS.BusinessLayer.Classes;
using SAMS.Common.Classes;
using SAMS.BusinessLayer.Reports;
  
public partial class Forms_RptLedgerReport : System.Web.UI.Page
{
    private void LoadPrincipal()
    {
        SKUPriceDetailController PController = new SKUPriceDetailController();
        DataTable m_dt = PController.SelectDataPrice(Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, Constants.IntNullValue, int.Parse(this.Session["UserId"].ToString()), Constants.IntNullValue, 0, DateTime.Parse(this.Session["CurrentWorkDate"].ToString()));
        this.DrpPrincipal.Items.Add(new ListItem("All", Constants.IntNullValue.ToString()));
        clsWebFormUtil.FillDropDownList(this.DrpPrincipal, m_dt, 0, 1);
    }
    private void LoadDistributor()
    {
        DistributorController DController = new DistributorController();
        DataTable dt = DController.SelectDistributorInfo(Constants.IntNullValue, int.Parse(this.Session["UserId"].ToString()), int.Parse(this.Session["CompanyId"].ToString()));
        this.drpDistributor.Items.Add(new ListItem("All", Constants.IntNullValue.ToString()));
        clsWebFormUtil.FillDropDownList(this.drpDistributor, dt, 0, 2);
    }
    private void LoadAccountDetail()
    {
        AccountHeadController mAccountController = new AccountHeadController();
        DataTable dtHead = mAccountController.SelectAccountHead(Constants.AC_AccountHeadId, Constants.LongNullValue);
        clsWebFormUtil.FillListBox(this.LstAccountHead, dtHead, "ACCOUNT_HEAD", "ACCOUNT_HEAD", true);
        this.Session.Add("dtHead", dtHead);

    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.LoadPrincipal();
            this.LoadDistributor();
            this.LoadTreeView();
            this.LoadAccountDetail();
            AppMaster master = new AppMaster();
            master = (AppMaster)this.Master;
            Panel panel = new Panel();
            panel = master.FindControl("searchpanel") as Panel;
            panel.Visible = true;

            SAMS.Common.Classes.Configuration.SystemCurrentDateTime = (DateTime)this.Session["CurrentWorkDate"];
            txtStartDate.Text = SAMS.Common.Classes.Configuration.SystemCurrentDateTime.ToString("dd-MMM-yyyy");
            txtEndDate.Text = SAMS.Common.Classes.Configuration.SystemCurrentDateTime.ToString("dd-MMM-yyyy");
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {

    }
    protected void Button2_Click1(object sender, EventArgs e)
    {
        DataTable dtHead = (DataTable)this.Session["dtHead"]; 
        DataRow[] foundRows = dtHead.Select("ACCOUNT_CODE  = '" + txtAccountCode.Text + "'");
        DocumentPrintController DPrint = new DocumentPrintController();

        DataSet ds = null;

         if (foundRows.Length > 0)
         {
             long AccountHeadID = long.Parse(foundRows[0]["ACCOUNT_HEAD_ID"].ToString());
             
             DataControl dc = new DataControl();

             ds = DPrint.GeneralLedger_View(int.Parse(DrpPrincipal.SelectedValue.ToString()),AccountHeadID,int.Parse(drpDistributor.SelectedValue.ToString()),
                       DateTime.Parse(txtStartDate.Text + " 00:00:00"), DateTime.Parse(txtEndDate.Text + " 23:59:59"), rbPosted.SelectedIndex);

             CrpLedgerView CrpReport = new CrpLedgerView();
             CrpReport.SetDataSource(ds);
             CrpReport.Refresh();

             CrpReport.SetParameterValue("CompanyName","Friends Distribution Management");
             CrpReport.SetParameterValue("FromDate", DateTime.Parse(txtStartDate.Text));
             CrpReport.SetParameterValue("To_date", DateTime.Parse(txtEndDate.Text));
             CrpReport.SetParameterValue("Location", drpDistributor.SelectedItem.Text);
             CrpReport.SetParameterValue("Principal", DrpPrincipal.SelectedItem.Text);
            
             this.Session.Add("CrpReport", CrpReport);
             this.Session.Add("ReportType", 0);
             string url = "'Default.aspx'";
             string script = "<script language='JavaScript' type='text/javascript'> window.open(" + url + ",\"Link\",\"toolbar=0,location=0,directories=0,status=0,menubar=0,scrollbars=1,resizable=1,width=800,height=600,left=10,top=10\");</script>";
             Type cstype = this.GetType();
             ClientScriptManager cs = Page.ClientScript;
             cs.RegisterStartupScript(cstype, "OpenWindow", script);
         }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {

    }

    private void LoadTreeView()
    {
        AppMaster myMaster;
        TreeView tr;
        Label lblUserId;
        Label lblCurrentWorkDate;

        myMaster = (AppMaster)this.Master;
        tr = myMaster.FindControl("tr") as TreeView;
        lblUserId = myMaster.FindControl("Label1") as Label;
        lblUserId.Text = this.Session["UserName"].ToString();
        lblCurrentWorkDate = myMaster.FindControl("lblCurrentWorkDate") as Label;
        lblCurrentWorkDate.Text = ((DateTime)this.Session["CurrentWorkDate"]).ToShortDateString();
        tr.Nodes.Clear();
        TreeNode trMaster = (TreeNode)this.Session["trMaster"];
        tr.Nodes.Add(trMaster);
        tr.CollapseAll();
        if (Session["TreeViewState"] == null)
        {
            // Record the TreeView's current expand/collapse state.
            Dictionary<string, bool> SelectedNode = new Dictionary<string, bool>();
            SaveTreeViewState(tr.Nodes, SelectedNode);
            Session["TreeViewState"] = SelectedNode;
        }
        else
        {
            // Apply the recorded expand/collapse state to the TreeView.
            Dictionary<string, bool> SelectedNode = (Dictionary<string, bool>)Session["TreeViewState"];
            RestoreTreeViewState(tr.Nodes, SelectedNode);
        }

    }
    private void SaveTreeViewState(TreeNodeCollection nodes, Dictionary<string, bool> SelectedNode)
    {
        // Recursivley record all expanded nodes in the List.
        foreach (TreeNode node in nodes)
        {
            if (node.ChildNodes != null && node.ChildNodes.Count != 0)
            {
                if (node.Expanded.HasValue && node.Expanded == true && !String.IsNullOrEmpty(node.Text))
                    SelectedNode.Add(node.Text, true);
                else
                    SelectedNode.Add(node.Text, false);
                SaveTreeViewState(node.ChildNodes, SelectedNode);
            }
        }
    }
    private void RestoreTreeViewState(TreeNodeCollection nodes, Dictionary<string, bool> SelectedNode)
    {
        foreach (TreeNode node in nodes)
        {
            if (Session["SelectedNode"].ToString() == node.ValuePath)
            {
                node.ImageUrl = "~/App_Themes/Granite/Images/Entry_down.gif";
                node.Selected = true;
            }
            else
            {
                node.ImageUrl = "~/App_Themes/Granite/Images/Entry.gif";
            }

            // Restore the state of one node.
            foreach (KeyValuePair<string, bool> pair in SelectedNode)
            {
                if (pair.Key == node.Text && pair.Value == true)
                {
                    node.Expand();
                }
                else if (pair.Key == node.Text && pair.Value == false)
                {
                    node.Collapse();
                }
                if (node.ChildNodes != null && node.ChildNodes.Count != 0)
                    RestoreTreeViewState(node.ChildNodes, SelectedNode);
            }
        }
    }
}
