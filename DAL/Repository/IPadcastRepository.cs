using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public interface IPadcastRepository:IDisposable
    {
        bool Add(Padcast padcast);
        bool Update(Padcast padcast);
        bool Delete(Padcast padcast);
        bool Delete(int id);
        void Save();
        IEnumerable<Padcast> GetAll();
        Padcast GetById(int id);
        Padcast GetByName(string Name);
    }
}
