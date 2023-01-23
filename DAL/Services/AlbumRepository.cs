using DAL.Context;
using DAL.Repository;
using DAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Services
{
    public class AlbumRepository : IAlbumRepository
    {
        DbContexts DB;
        public AlbumRepository(DbContexts DB)
        {
            this.DB = DB;

        }
        public bool Add(Album album)
        {
            try
            {
                DB.Albums.Add(album);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(Album album)
        {
            try
            {
                DB.Albums.Remove(album);
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
                Album album = DB.Albums.Find(id);
                this.Delete(album);
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

        public IEnumerable<Album> GetAll()
        {
            return DB.Albums.OrderByDescending(c => c.AlbumName).Include(c=>c.Singer).ToList();
        }

        public IEnumerable<ViewAlbum> GetAllModelAlbum()
        {
            return DB.Albums.OrderByDescending(c => c.Visit).Select(c => new ViewAlbum
            {
                AlbumId=c.AlbumId,
                AlbumName= c.AlbumName,
                SingerName=c.Singer.SingerName,
                Visit=c.Visit,
                Score=c.Score,
                Picture=c.Picture
            });
        }

        public Album GetById(int id)
        {
            return DB.Albums.Find(id);
        }

        public Album GetByName(string Name)
        {
            return DB.Albums.Where(c => c.AlbumName == Name).FirstOrDefault();
        }

        public void Save()
        {
            DB.SaveChanges();
        }

        public bool Update(Album album)
        {
            try
            {
                DB.Entry(album).State=EntityState.Modified;
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
