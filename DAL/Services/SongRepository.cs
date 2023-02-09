using DAL.Context;
using DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class SongRepository : ISongRepository
    {
        DbContexts DB;
        public SongRepository(DbContexts DB) 
        {
            this.DB = DB;
        }
        public bool Add(Song song)
        {
            try
            {
                DB.Songs.Add(song);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(Song song)
        {
            try
            {
                DB.Entry(song).State=EntityState.Deleted;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            Song song=this.GetById(id);
            return Delete(song);
        }

        public void Dispose()
        {
            DB.Dispose();
        }

        public IEnumerable<Song> GetAll()
        {
            return DB.Songs.Include(c => c.Album).Include(c => c.Album.Singer).OrderByDescending(c => c.CreateDate).ToList();
        }

        public IEnumerable<SongSearch> GetAllSearchView()
        {
            return DB.Songs.OrderByDescending(c => c.CreateDate).Select(song => new SongSearch
            {
                SongId = song.SongId,
                GroupId = song.GroupId,
                SongName = song.SongName,
                SingerName = song.Album.Singer.SingerName,
                AlbumName = song.Album.AlbumName,
                CountryId = song.Album.Singer.CountryId,
                Picture= song.Picture
            });
        }

        public IEnumerable<ViewSong> GetAllSongView()
        {
            return DB.Songs.OrderByDescending(c => c.CreateDate).Select(song => new ViewSong
            {
                SongId = song.SongId,
                GroupId = song.GroupId,
                SongName = song.SongName,
                SingerName = song.Album.Singer.SingerName,
                Album = song.Album,
                Score = song.Score,
                Visit = song.Visit,
                Picture = song.Picture,
                AddressFile = song.AddressFile,
                Remix = song.Remix,
                SongType = song.TypeSong,
                CountryId = song.Album.Singer.CountryId
            });
        }

        public Song GetById(int id)
        {
            return DB.Songs.Find(id);
        }

        public Song GetByName(string Name)
        {
            return DB.Songs.Where(c => c.SongName==Name).SingleOrDefault();
        }

        public void Save()
        {
            DB.SaveChanges();
        }

        public bool Update(Song song)
        {
            try
            {
                DB.Entry(song).State= EntityState.Modified;
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
