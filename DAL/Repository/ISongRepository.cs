using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface ISongRepository:IDisposable
    {
        bool Add(Song song);
        bool Update(Song song);
        bool Delete(Song song);
        bool Delete(int id);
        void Save();
        IEnumerable<Song> GetAll();
        IEnumerable<ViewSong> GetAllSongView();
        IEnumerable<SongSearch> GetAllSearchView();
        Song GetById(int id);
        Song GetByName(string Name);
    }
}
