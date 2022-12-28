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
    public class SingerRepository:ISingerRepository
    {
        private DbContexts DB;
        public SingerRepository(DbContexts DB) 
        {
            this.DB = DB;
        }

        public bool Add(Singer singer)
        {
            try
            {
                singer.CreateDate= DateTime.Now;
                if (DB.Singers.Any(c => c.Name==singer.Name))
                {
                    return false;
                }
                else
                {
                    DB.Singers.Add(singer);
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(Singer singer)
        {
            try
            {
                DB.Entry(singer).State=EntityState.Deleted;
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
                Singer singer=DB.Singers.Find(id);
                this.Delete(singer);
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

        public IEnumerable<Singer> GetAll()
        {
            return DB.Singers.OrderByDescending(c => c.CreateDate).ToList();
        }

        public Singer GetById(int id)
        {
            return DB.Singers.Find(id);
        }

        public Singer GetByName(string Name)
        {
            return DB.Singers.Where(c => c.Name==Name).SingleOrDefault();
        }

        public void Save()
        {
            DB.SaveChanges();
        }

        public bool Update(Singer singer)
        {
            try
            {
                if (DB.Singers.Any(c => c.Name == singer.Name && c.SingerId != singer.SingerId))
                {
                    return false;
                }
                else
                {
                    singer.CreateDate = DateTime.Now;
                    DB.Entry(singer).State = EntityState.Modified;
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
