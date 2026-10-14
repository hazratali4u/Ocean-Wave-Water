using System;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using SAMS.Common.Classes;
using SAMS.BusinessLayer.Classes;  


public partial class AppMaster : System.Web.UI.MasterPage
{
       
    
    protected void Page_Load(object sender, EventArgs e)
    {
    }
    protected void tr_SelectedNodeChanged(object sender, EventArgs e)
    {
        if (tr.SelectedNode.Depth == 0)
        {
            tr.CollapseAll();  //Collapse all nodes
            tr.SelectedNode.Expand();//Expand the selected node
        }
        //Save the state of the treeview
        if (IsPostBack)
        {
            Dictionary<string, bool> SelectedNode = new Dictionary<string, bool>();
            SaveTreeViewState(tr.Nodes, SelectedNode);
            Session["TreeViewState"] = SelectedNode;
        }
        //All done, lets redirect to the new page
        if (IsPostBack)
        {
            // Here i use the "value" attribute of the treeview node, this must be used instead of the NavigateURL attribute whitch makes the
            //OnSelectedNodeChange event break in the first place   
            if (!tr.SelectedValue.ToString().Equals("N/A") && tr.SelectedValue.Length > 2)
            {
                Session.Add("SelectedNode", tr.SelectedNode.ValuePath);
                string url = tr.SelectedValue.ToString();
                Response.Redirect("~/" + url);
            }
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
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        this.Session.Clear();  
        Response.Redirect("~/Login.aspx?Status=" + false);
    }
  
}
