using Microsoft.Data.SqlClient;
using Projekt_Auftragsverwaltung.Controllers;
using Projekt_Auftragsverwaltung.Tables;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using Projekt_Auftragsverwaltung.Interfaces;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Projekt_Auftragsverwaltung.Gui
{
    public partial class TreeViewClass : Form
    {
        private readonly IStatisticController _statisticController;

        public TreeViewClass(IStatisticController statisticController)
        {
            _statisticController = statisticController;
            InitializeComponent();
        }

        private void CmdTreeViewShow_Click(object sender, EventArgs e)
        {
            var table = _statisticController.GetDataTableTreeView();
            treeView.Nodes.Clear();
            AddNode(null, table);
        }

        private void AddNode(TreeNode parentNode, DataTable table)
        {
            string filter = "ParentId" + (parentNode == null ? " IS NULL" : " = " + parentNode.Tag);
            DataRow[] rows = table.Select(filter);
            foreach (DataRow row in rows)
            {
                TreeNode node = new TreeNode(row["Name"].ToString());
                node.Tag = row["ArticleGroupId"].ToString();
                if (parentNode == null)
                {
                    treeView.Nodes.Add(node);
                }
                else
                {
                    parentNode.Nodes.Add(node);
                }
                AddNode(node, table);
            }
        }
    }
}

