using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_Auftragsverwaltung.Controllers
{
    public interface IDataController
    {
        public DataTable ReturnData();
        public DataTable ReturnDataSearch();

        public void CreateEntity();

        public DataTable CreateDataTable();
    }
}
