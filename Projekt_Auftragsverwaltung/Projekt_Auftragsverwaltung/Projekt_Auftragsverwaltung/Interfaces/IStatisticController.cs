using System.Data;

namespace Projekt_Auftragsverwaltung.Interfaces
{
    public interface IStatisticController
    {
        DataTable ReturnStatistic();
        DataTable GetDataTableTreeView();

    }
}
