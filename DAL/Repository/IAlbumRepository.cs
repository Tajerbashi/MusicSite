using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public interface IAlbumRepository:IDisposable
    {
        bool Add(Album album);
        bool Update(Album album);
        bool Delete(Album album);
        bool Delete(int id);
        void Save();
        IEnumerable<Album> GetAll();
        Album GetById(int id);
        Album GetByName(string Name);
    }
}
