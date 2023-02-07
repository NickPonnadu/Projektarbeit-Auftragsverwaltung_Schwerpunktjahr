using Microsoft.Data.SqlClient;
using Projekt_Auftragsverwaltung.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_Auftragsverwaltung
{
    public class FormController : Form
    {
        public void ClearTextBoxes()
        {
            foreach (Control c in this.Controls)
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




    }

}
