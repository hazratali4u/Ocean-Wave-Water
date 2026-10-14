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

public partial class Forms_frmTransferIn : System.Web.UI.Page
{

    private void LoadDocumentNo()
    {
        if (DrpDistributor.Items.Count > 0 )
        {
            
            OrderEntryController OR = new OrderEntryController();
            DataControl dc = new DataControl(); 
            DataTable  dt = OR.SelectTranspoterInvoice(int.Parse(DrpDistributor.SelectedValue.ToString()), long.Parse(ListCustomer.SelectedValue.ToString()),1);
            GrdCreditLimit.DataSource = dt;
            GrdCreditLimit.DataBind();
            for(int i = 0;i<GrdCreditLimit.Rows.Count;i++)
            {
                DropDownList DrpTranspoter = (DropDownList)GrdCreditLimit.Rows[i].Cells[0].FindControl("DrpTranspoter");
                TextBox txtDCNo = (TextBox)GrdCreditLimit.Rows[i].Cells[0].FindControl("txtDCno");
                TextBox txtBiltyNo = (TextBox)GrdCreditLimit.Rows[i].Cells[0].FindControl("txtBiltyNo");
                TextBox txtExp = (TextBox)GrdCreditLimit.Rows[i].Cells[0].FindControl("txtFreight");

                DataTable dtTranspoter = OR.SelectTranspoter(); 
                clsWebFormUtil.FillDropDownList(DrpTranspoter, dtTranspoter, 0, 1, true);
                if (int.Parse(dc.chkNull_0(dt.Rows[i]["TRANSPOTER_NO"].ToString())) > 0)
                {
                    DrpTranspoter.SelectedValue = dt.Rows[i]["TRANSPOTER_NO"].ToString();
                }
                if (dt.Rows[i]["BILTY_NO"].ToString().Length > 0)
                {
                    txtBiltyNo.Text  = dt.Rows[i]["BILTY_NO"].ToString();
                }
                if (dt.Rows[i]["DELIVERY_CHALLAN_NO"].ToString().Length > 0)
                {
                    txtDCNo.Text = dt.Rows[i]["DELIVERY_CHALLAN_NO"].ToString();
                }
                if (dt.Rows[i]["TOTAL_EXPENCESS"].ToString().Length > 0)
                {
                    txtExp.Text = dt.Rows[i]["TOTAL_EXPENCESS"].ToString();
                }
            }  
        }
    }
    private void LoadCustomer()
    {
        if (DrpDistributor.Items.Count > 0)
        {
            OrderEntryController OR = new OrderEntryController();
            DataTable dt = OR.SelectTranspoterInvoice(int.Parse(DrpDistributor.SelectedValue.ToString()),Constants.LongNullValue,0);
            clsWebFormUtil.FillListBox(this.ListCustomer, dt, "SOLD_TO", "CUSTOMER");   
        }
    }
    private void LoadDistributor()
    {
        DistributorController DController = new DistributorController();
        DataTable dt = DController.SelectDistributorInfo(Constants.IntNullValue, int.Parse(this.Session["UserId"].ToString()), int.Parse(this.Session["CompanyId"].ToString()));
        clsWebFormUtil.FillDropDownList(this.DrpDistributor, dt, 0, 2, true);
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.LoadDistributor();
            this.LoadCustomer(); 
            //this.LoadDocumentNo();
            //this.LoadTreeView();
            //AppMaster master = new AppMaster();
            //master = (AppMaster)this.Master;
            //Panel panel = new Panel();
            //panel = master.FindControl("searchpanel") as Panel;
            //panel.Visible = true;
        }
    }
    protected void drpDistributor_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadCustomer(); 
        //this.LoadDocumentNo();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < GrdCreditLimit.Rows.Count; i++)
        {
            DropDownList DrpTranspoter = (DropDownList)GrdCreditLimit.Rows[i].Cells[0].FindControl("DrpTranspoter");
            TextBox txtDCNo = (TextBox)GrdCreditLimit.Rows[i].Cells[0].FindControl("txtDCno");
            TextBox txtBiltyNo = (TextBox)GrdCreditLimit.Rows[i].Cells[0].FindControl("txtBiltyNo");
            TextBox txtExp = (TextBox)GrdCreditLimit.Rows[i].Cells[0].FindControl("txtFreight");

            if (txtBiltyNo.Text.Length > 0)
            {
                OrderEntryController or = new OrderEntryController();
                or.PostTranspoterExp(int.Parse(DrpDistributor.SelectedValue.ToString()), long.Parse(GrdCreditLimit.Rows[i].Cells[0].Text), int.Parse(DrpTranspoter.SelectedValue.ToString()), txtBiltyNo.Text, txtDCNo.Text, decimal.Parse(txtExp.Text));                   
            }
        }
    }
    protected void ListCustomer_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadDocumentNo();
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
