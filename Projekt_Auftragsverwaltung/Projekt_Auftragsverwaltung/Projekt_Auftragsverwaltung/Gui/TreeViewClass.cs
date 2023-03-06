﻿using Microsoft.Data.SqlClient;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Projekt_Auftragsverwaltung.Gui
{
    public partial class TreeViewClass : Form
    {
        public string connectionString;

        public TreeViewClass(string connectionstring1)
        {
            InitializeComponent();

            // Set connection string
            connectionString = connectionstring1;
        }

        private void CmdTreeViewShow_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "WITH CTE_ArticleGroups (ArticleGroupId, Name, ParentId, Level) AS " +
                               "(SELECT ArticleGroupId, Name, ParentId, 0 AS Level FROM dbo.ArticleGroups " +
                               "WHERE ParentId IS NULL " +
                               "UNION ALL " +
                               "SELECT ag.ArticleGroupId, ag.Name, ag.ParentId, ag.Level + 1 " +
                               "FROM dbo.ArticleGroups AS ag " +
                               "INNER JOIN CTE_ArticleGroups AS p " +
                               "ON ag.ParentId = p.ArticleGroupId) " +
                               "SELECT ArticleGroupId, Name, ParentId, Level " +
                               "FROM CTE_ArticleGroups " +
                               "ORDER BY ArticleGroupId;";
                // command Objekt erzeugen
                SqlCommand command = new SqlCommand(query, connection);

                // dataAdapter Objekt erzeugen
                SqlDataAdapter adapter = new SqlDataAdapter(command);

                // Datentabelle für Ergebnisse
                DataTable table = new DataTable();

                // Füllt die Datentabelle mit den Ergebnissen der Abfrage
                adapter.Fill(table);

                // Bindet die Daten an die TreeView
                treeView.Nodes.Clear();
                AddNode(null, table);
            }
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
