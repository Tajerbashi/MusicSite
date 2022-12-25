using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public interface ISingerRepository:IDisposable
    {
        bool Add(Singer singer);
        bool Update(Singer singer);
        bool Delete(Singer singer);
        bool Delete(int id);
        void Save();
        IEnumerable<Singer> GetAll();
        Singer GetById(int id);
        Singer GetByName(string Name);
    }
}
