using Microsoft.Data.SqlClient;
using Projekt_Auftragsverwaltung.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_Auftragsverwaltung.Gui
{
    public class FormController : Form
    {
        public string ConnectionString;

        public void ClearTextBoxes()
        {
            foreach (Control c in Controls)
            {
                if (c is TextBox)
                {
                    ((TextBox)c).Clear();
                }
            }
        }

        public void CloseForm()
        {
            Hide();
            ClearTextBoxes();
        }

        private void InitializeComponent()
        {
            SuspendLayout();
            // 
            // FormController
            // 
            ClientSize = new Size(278, 244);
            Name = "FormController";
            ResumeLayout(false);

        }
    }

}
