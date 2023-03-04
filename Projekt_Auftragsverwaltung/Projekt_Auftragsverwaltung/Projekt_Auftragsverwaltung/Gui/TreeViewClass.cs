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

namespace Projekt_Auftragsverwaltung.Gui
{
    public partial class TreeViewClass : Form
    {
        public string connectionString;

        public TreeViewClass(string connectionstring1)
        {
            InitializeComponent();
            connectionString = connectionstring1;
        }

        private void CmdTreeViewShow_Click(object sender, EventArgs e)
        {

        }
    }
}
