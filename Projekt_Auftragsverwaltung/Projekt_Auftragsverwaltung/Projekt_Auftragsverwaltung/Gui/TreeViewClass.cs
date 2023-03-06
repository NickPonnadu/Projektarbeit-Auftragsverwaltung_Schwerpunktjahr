using Microsoft.Data.SqlClient;
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
            // Clear existing nodes
            treeView.Nodes.Clear();

            using (var connection = new SqlConnection(connectionString))
            {
                // Open the connection
                connection.Open();

                // Create a command for the recursive CTE
                var command = new SqlCommand(@"
                    WITH RecursiveTree AS (
                        -- Anchor query: get root nodes (ArticleGroups without parents)
                        SELECT ArticleGroupId, Name, NULL AS ParentId
                        FROM ArticleGroup
                        WHERE ParentId IS NULL

                        UNION ALL

                        -- Recursive query: get child nodes (Articles and ArticleGroups)
                        SELECT 
                            CASE 
                                WHEN ag.ParentId IS NULL THEN a.ArticleId
                                ELSE ag.ArticleGroupId
                            END AS ArticleGroupId,
                            CASE 
                                WHEN ag.ParentId IS NULL THEN a.ArticleName
                                ELSE ag.Name
                            END AS Name,
                            ag.ParentId
                        FROM RecursiveTree rt
                        JOIN ArticleGroup ag ON rt.ArticleGroupId = ag.ParentId
                        JOIN Article a ON ag.ArticleGroupId = a.ArticleGroupId
                    )
                    SELECT ArticleGroupId, Name, ParentId
                    FROM RecursiveTree
                ", connection);

                // Execute the command and get the results
                var adapter = new SqlDataAdapter(command);
                var dataTable = new DataTable();
                adapter.Fill(dataTable);

                // Group the results by parent node
                var nodeGroups = dataTable.AsEnumerable().GroupBy(row => row.Field<int?>("ParentId"));

                // Add root nodes to the treeview
                foreach (var rootNode in nodeGroups.FirstOrDefault(g => !g.Key.HasValue))
                {
                    var treeNode = new TreeNode(rootNode.Field<string>("Name"), GetChildNodes(rootNode, nodeGroups).ToArray());
                    treeView.Nodes.Add(treeNode);
                }
            }
        }
        private IEnumerable<TreeNode> GetChildNodes(DataRow parentRow, IEnumerable<IGrouping<int?, DataRow>> nodeGroups)
        {
            // Recursively get child nodes for the given parent node
            foreach (var childNode in nodeGroups.FirstOrDefault(g => g.Key == parentRow.Field<int?>("ArticleGroupId")))
            {
                var treeNode = new TreeNode(childNode.Field<string>("Name"), GetChildNodes(childNode, nodeGroups).ToArray());
                yield return treeNode;
            }
        }
    }
}
