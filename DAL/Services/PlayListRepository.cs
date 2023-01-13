using DAL.Context;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public bool Delete(PlayList playList)
        {
            try
            {
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
