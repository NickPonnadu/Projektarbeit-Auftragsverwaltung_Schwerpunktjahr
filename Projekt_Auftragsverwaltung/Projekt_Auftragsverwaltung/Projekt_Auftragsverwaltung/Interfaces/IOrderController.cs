using Projekt_Auftragsverwaltung.Tables;
using System;
using System.Data;

namespace Projekt_Auftragsverwaltung.Controllers
{
    public interface IOrderController
    {
        DataTable ReturnOrders();
        DataTable ReturnOrdersSearch(string column, string value);
        void CreateOrder(DateTime date, int customerId);
        void DeleteOrder(int orderId);
        void EditOrder(int orderId, DateTime date, int customerId);
        Order GetSingleOrder(int orderId);
    }
}