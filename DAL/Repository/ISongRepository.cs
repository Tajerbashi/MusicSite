using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public interface ISongRepository:IDisposable
    {
        bool Add(Song song);
        bool Update(Song song);
        bool Delete(Song song);
        bool Save();
        IEnumerable<Song> GetAll();
        Song GetById(int id);
        Song GetByName(string Name);
    }
}
