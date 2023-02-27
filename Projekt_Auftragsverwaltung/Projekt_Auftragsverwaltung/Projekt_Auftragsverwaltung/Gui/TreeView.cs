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

namespace Projekt_Auftragsverwaltung.Gui
{
    public partial class TreeView : Form
    {
        

        string connectionString = "Data Source=myServerAddress;Initial Catalog=myDataBase;User ID=myUsername;Password=myPassword;";

        public TreeView()
        {
            InitializeComponent();

            LoadTreeView();
        }

        private void LoadTreeView()
        {
            // SQL-Abfrage für die rekursive CTE
            string query = @"
            WITH recursiveCTE AS (
                SELECT ArticleGroupId, Name, CAST(NULL AS INT) AS ParentId
                FROM ArticleGroup
                WHERE ParentId IS NULL
                UNION ALL
                SELECT g.ArticleGroupId, g.Name, r.ArticleGroupId AS ParentId
                FROM ArticleGroup g
                INNER JOIN recursiveCTE r ON g.ParentId = r.ArticleGroupId
            )
            SELECT ArticleGroupId, Name, ParentId
            FROM recursiveCTE
            ORDER BY ParentId, ArticleGroupId;
            ";

            // Verbindung zur Datenbank herstellen und Abfrage ausführen
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // TreeView-Objekt erstellen
                        TreeView treeView = new TreeView();

                        // Dictionary, um die TreeNodes zu speichern
                        Dictionary<int, TreeNode> nodeDictionary = new Dictionary<int, TreeNode>();

                        while (reader.Read())
                        {
                            int articleGroupId = reader.GetInt32(0);
                            string name = reader.GetString(1);
                            int? parentId = reader.IsDBNull(2) ? null : (int?)reader.GetInt32(2);

                            // TreeNode-Objekt erstellen
                            TreeNode node = new TreeNode(name);

                            // TreeNode zum TreeView hinzufügen oder als untergeordnetes Element hinzufügen
                            if (parentId == null)
                            {
                                treeView1.Nodes.Add(node);
                            }
                            else
                            {
                                nodeDictionary[(int)parentId].Nodes.Add(node);
                            }

                            // TreeNode-Objekt zum Dictionary hinzufügen
                            nodeDictionary.Add(articleGroupId, node);
                        }

                        // TreeView zur Verfügung stellen
                        treeView.Dock = DockStyle.Fill;
                        this.Controls.Add(treeView);
                    }
                }
            }
        }
    }
}
