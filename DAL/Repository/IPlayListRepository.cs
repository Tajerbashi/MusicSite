using DAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public interface IPlayListRepository:IDisposable
    {
        bool Add(PlayList playList);
        bool Update(PlayList playList);
        bool Delete(PlayList playList);
        bool Delete(int id);
        bool CheckPlayList(PlayList list);
        void Save();
        IEnumerable<PlayList> GetAll();
        IEnumerable<ViewPlayList> GetAllToShow();
        IEnumerable<PlayList> GetAllPlayListPKFK();
        IEnumerable<PlayListSongPKFK> GetAllPlayListSongPKFK();
        PlayList GetById(int id);
        PlayList GetByName(string Name);
    }
}
