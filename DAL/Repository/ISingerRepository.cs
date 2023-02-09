using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface ISingerRepository:IDisposable
    {
        bool Add(Singer singer);
        bool Update(Singer singer);
        bool Delete(Singer singer);
        bool Delete(int id);
        void Save();
        IEnumerable<Singer> GetAll();
        IEnumerable<ViewSinger> GetAllToShow();
        Singer GetById(int id);
        Singer GetByName(string Name);
    }
}
