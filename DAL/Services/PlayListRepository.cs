using DAL.Context;
using DAL.Repository;
using DAL.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DAL.Services
{
    public class PlayListRepository : IPlayListRepository
    {
        DbContexts DB;
        public PlayListRepository(DbContexts db) 
        {
            this.DB=db;
        }
        public bool Add(PlayList playList)
        {
            try
            {
                DB.PlayLists.Add(playList);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool CheckPlayList(PlayList list)
        {
            try
            {
                var query1 = DB.PlayListSongPKFKs.Where(c => c.PlayList.playListId == list.playListId).ToList();
                if (query1.Count > 0)
                {
                    return false;
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(PlayList playList)
        {
            try
            {
                List<PlayListSongPKFK> play = DB.PlayListSongPKFKs.Where(c => c.PlayList.playListId == playList.playListId).ToList();
                foreach (var item in play)
                {
                    DB.PlayListSongPKFKs.Remove(item);
                }
                DB.Entry(playList).State=EntityState.Deleted;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                PlayList play=DB.PlayLists.Find(id);
                this.Delete(play);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void Dispose()
        {
            DB.Dispose();
        }

        public IEnumerable<PlayList> GetAll()
        {
            return DB.PlayLists.OrderByDescending(c => c.CreateDate).ToList();
        }

        public IEnumerable<PlayList> GetAllPlayListPKFK()
        {
            return DB
                .PlayLists
                .Include(c => c.PlayListSongPKFK)
                .ToList();
        }

        public IEnumerable<PlayListSongPKFK> GetAllPlayListSongPKFK()
        {
            return DB
                .PlayListSongPKFKs
                .Include(c => c.PlayList)
                .Include(c => c.Song)
                .Include(c => c.Song.Album)
                .ToList();
        }

        public IEnumerable<ViewPlayList> GetAllToShow()
        {
            return DB
                .PlayListSongPKFKs
                .OrderByDescending(c => c.PlayList.CreateDate)
                .Select(c => new ViewPlayList
                {
                    PlayListName = c.PlayList.PlayListName,
                    SongName = c.Song.SongName,
                    SingerName = c.Song.Album.Singer.SingerName,
                    AlbumName = c.Song.Album.AlbumName,
                    CountryName = c.PlayList.Country.CountryName,
                    Picture = c.PlayList.Picture,
                    Visit = c.PlayList.Visit,
                    Score = c.PlayList.Score,
                    Type = c.PlayList.Type,
                    PlayListId=c.PlayList.playListId,
                    SongId=c.Song.SongId,
                });
        }

        public PlayList GetById(int id)
        {
            return DB.PlayLists.Find(id);
        }

        public PlayList GetByName(string Name)
        {
            return DB.PlayLists.Where(c => c.PlayListName==Name).FirstOrDefault();
        }

        public void Save()
        {
            DB.SaveChanges();
        }

        public bool Update(PlayList playList)
        {
            try
            {
                DB.Entry(playList).State= EntityState.Modified;
                return true;
            }
            catch
            {
                return false;
            }
        }
       
    }
}
