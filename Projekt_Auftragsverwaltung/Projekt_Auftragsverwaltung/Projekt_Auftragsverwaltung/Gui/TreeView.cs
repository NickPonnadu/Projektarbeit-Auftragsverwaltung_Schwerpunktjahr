using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Projekt_Auftragsverwaltung.Gui
{
    public partial class TreeView : Form
    {
        //private const string connectionString = "your_connection_string_here";

        private string connectionString = DatabaseManager.BuildConnectionString(Login.server, Login.name);

        public TreeView()
        {
            InitializeComponent();
            LoadTreeView();
        }



        private void LoadTreeView()
        {
            // create connection to database
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // define query using recursive CTE
                string query = @"WITH ArticleGroupHierarchy AS (
                              SELECT ArticleGroupId, Name, CAST(NULL AS INT) AS ParentArticleGroupId, 0 AS Depth
                              FROM ArticleGroup
                              WHERE ParentArticleGroupId IS NULL
                              UNION ALL
                              SELECT ag.ArticleGroupId, ag.Name, ag.ParentArticleGroupId, ah.Depth + 1
                              FROM ArticleGroup AS ag
                              JOIN ArticleGroupHierarchy AS ah ON ag.ParentArticleGroupId = ah.ArticleGroupId
                            )
                            SELECT ArticleGroupId, Name, ParentArticleGroupId, Depth
                            FROM ArticleGroupHierarchy
                            ORDER BY Depth, Name;

                       ";

                // create command and data adapter to execute query
                using (SqlCommand command = new SqlCommand(query, connection))
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    // create dataset to store query results
                    DataSet dataSet = new DataSet();
                    adapter.Fill(dataSet);

                    // create dictionary to index nodes by ArticleGroupId
                    Dictionary<int, TreeNode> nodeIndex = new Dictionary<int, TreeNode>();

                    // loop through results and add each node to the treeview
                    foreach (DataRow row in dataSet.Tables[0].Rows)
                    {
                        // create a new tree node for this row
                        TreeNode node = new TreeNode(row["Name"].ToString());
                        node.Tag = row["ArticleGroupId"];

                        // get parent node from the dictionary using ParentArticleGroupId and Depth
                        int parentGroupId = Convert.ToInt32(row["ParentArticleGroupId"]);
                        int depth = Convert.ToInt32(row["Depth"]);
                        if (depth > 0)
                        {
                            int parentDepth = depth - 1;
                            if (nodeIndex.ContainsKey(parentGroupId) && nodeIndex[parentGroupId].Level == parentDepth)
                            {
                                nodeIndex[parentGroupId].Nodes.Add(node);
                            }
                            else
                            {
                                // if parent node not found, skip this node
                                continue;
                            }
                        }

                        // add node to dictionary and treeview
                        nodeIndex.Add(Convert.ToInt32(row["ArticleGroupId"]), node);
                        treeView1.Nodes.Add(node);
                    }
                }
            }
        }
    }
}
