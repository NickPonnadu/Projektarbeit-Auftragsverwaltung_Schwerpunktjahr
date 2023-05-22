using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_Auftragsverwaltung.Controllers
{
    public interface IDataControllerAddressEntities
    {
       
        public void DeleteEntity(int entityPK);

        public object GetSingleEntity(int entityPK);
    }
}
