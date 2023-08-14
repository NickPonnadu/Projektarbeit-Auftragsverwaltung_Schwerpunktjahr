using System;
using System.Data;
using Projekt_Auftragsverwaltung.Tables;

namespace Projekt_Auftragsverwaltung.Controllers
{
    public interface IOrderPositionController
    {
        DataTable ReturnOrderPositions();
        DataTable ReturnOrderPositionsSearch(string columnName, string searchValue);
        void CreateOrderPosition(int amount, int orderId, int articleId);
        void DeleteOrderPosition(int orderPositionId);
        void EditOrderPosition(int orderPositionId, int amount, int orderId);
        OrderPosition GetSingleOrderPosition(int orderPositionId);
    }
}