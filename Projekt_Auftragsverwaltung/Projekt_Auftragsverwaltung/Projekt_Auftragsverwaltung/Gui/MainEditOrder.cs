using Projekt_Auftragsverwaltung.Gui;
using System.Text;
using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Reflection.Metadata;
using Projekt_Auftragsverwaltung.Tables;
using Projekt_Auftragsverwaltung.Controllers;
using Projekt_Auftragsverwaltung.Interfaces;

namespace Projekt_Auftragsverwaltung
{

    public partial class MainEditOrder : FormController

    {
        private readonly ICustomerController _customerController;
        private readonly IOrderController _orderController;
        

        Order? Order { get; set; }

        public bool EditMode;

        public MainEditOrder(ICustomerController customerController, IOrderController orderController, Order order = null)
        {
            InitializeComponent();
            _customerController = customerController;
            _orderController = orderController;
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


                    _orderController.CreateOrder(DtpOrderDate.Value, customerId);
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


                    _orderController.EditOrder(Order.OrderId, DtpOrderDate.Value, customerId);
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

        private void UpdateCustomerList(object sender = null, EventArgs e = null)
        {
            if (_orderController != null)
            {
                var data = _customerController.ReturnCustomers();
                DGWChooseCustomer.DataSource = data;
            }
        }


    }
}
