using Projekt_Auftragsverwaltung.Gui;
using System.Text;
using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Reflection.Metadata;

namespace Projekt_Auftragsverwaltung
{

    public partial class MainEditOrder : FormController

    {
        DataController dataController;
        public string ConnectionString;
        public MainEditOrder(string connectionString)
        {
            InitializeComponent();
            ConnectionString = connectionString;
            dataController = new DataController(ConnectionString);

        }



        private void CmdCreateOrderSave_Click(object sender, EventArgs e)
        {
            if (DGWChooseCustomer.SelectedRows.Count > 0)
            {
                var rows = DGWChooseCustomer.SelectedRows[0];
                string customerId = rows.Cells[0].Value.ToString();


                dataController.CreateOrder(DtpOrderDate.Value, customerId);
                CloseForm();
            }
            else
            { throw new Exception("Bitte Kunde auswählen"); }
        }

        private void CmdCreateOrderCancel_Click(object sender, EventArgs e)
        {
            CloseForm();
        }

        private void UpdateCustomerList(object sender, EventArgs e)
        {
            if (dataController != null)
            {
                var data = dataController.ReturnCustomers();
                DGWChooseCustomer.DataSource = data;
            }

        }


    }
}
