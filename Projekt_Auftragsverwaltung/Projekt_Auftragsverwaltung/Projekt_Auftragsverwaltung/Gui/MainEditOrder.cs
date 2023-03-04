using Projekt_Auftragsverwaltung.Gui;
using System.Text;
using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Reflection.Metadata;
using Projekt_Auftragsverwaltung.Tables;

namespace Projekt_Auftragsverwaltung
{

    public partial class MainEditOrder : FormController

    {
        DataController dataController;
        public string ConnectionString;


        Order? Order { get; set; }

        public bool EditMode;

        public MainEditOrder(string connectionString, Order order = null)
        {
            InitializeComponent();
            ConnectionString = connectionString;
            dataController = new DataController(ConnectionString);
            Order = order;
            UpdateCustomerList();
            if (Order != null)
            {
                SetEditModeOn();
            }
            else SetEditModeOff();

        }

        private void SetEditModeOn()
        {

            EditMode = true;
            DtpOrderDate.Value = Order.Date;
            
            CmdCreateOrderSave.Text = "Änderungen speichern";
        }

       
        private void SetEditModeOff()
        {
            EditMode = false;
            DtpOrderDate.Value = DateTime.Today;
            
            CmdCreateOrderSave.Text = "Auftrag anlegen";
        }

        private void CmdCreateOrderSave_Click(object sender, EventArgs e)
        {
            if (EditMode == false)
            {
                if (DGWChooseCustomer.SelectedRows.Count > 0)
                {
                    var rows = DGWChooseCustomer.SelectedRows[0];
                    int customerId = Convert.ToInt32(rows.Cells[0].Value);


                    dataController.CreateOrder(DtpOrderDate.Value, customerId);
                    CloseForm();
                }
                else
                { throw new Exception("Bitte Kunde auswählen"); }
            }
            if (EditMode == true && Order != null)
            {
                if (DGWChooseCustomer.SelectedRows.Count > 0)
                {
                    var rows = DGWChooseCustomer.SelectedRows[0];
                    int customerId = Convert.ToInt32(rows.Cells[0].Value);


                    dataController.EditOrder(Order.OrderId, DtpOrderDate.Value, customerId);
                    SetEditModeOff();
                    CloseForm();
                }
                else if (EditMode == true && Order == null)
                {
                    MessageBox.Show("Falscher EditMode");
                }
            }
            
            SetEditModeOff();
            CloseForm();

        }

        private void CmdCreateOrderCancel_Click(object sender, EventArgs e)
        {
            SetEditModeOff();
            CloseForm();
        }

        private void UpdateCustomerList(object sender = null, EventArgs e=null)
        {
            if (dataController != null)
            {
                var data = dataController.ReturnCustomers();
                DGWChooseCustomer.DataSource = data;
            }
        }


    }
}
