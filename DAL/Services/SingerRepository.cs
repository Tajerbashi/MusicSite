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
                if (DB.Singers.Any(c => c.SingerName==singer.SingerName))
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
            return DB.Singers.OrderBy(c => c.SingerName).ToList();
        }

        public IEnumerable<ViewSinger> GetAllToShow()
        {
            return DB.Singers
                .OrderByDescending(c => c.CreateDate)
                .Select(c => new ViewSinger
                {
                    SingerName = c.SingerName,
                    CountryId = c.CountryId,
                    SingerId = c.SingerId,
                    Picture=c.Albums.OrderByDescending(e => e.CreateDate).FirstOrDefault().Picture,
                    SongCount=c.Albums.Count                    
                });
        }

        public Singer GetById(int id)
        {
            return DB.Singers.Find(id);
        }

        public Singer GetByName(string Name)
        {
            return DB.Singers.Where(c => c.SingerName==Name).SingleOrDefault();
        }

        public void Save()
        {
            DB.SaveChanges();
        }

        public bool Update(Singer singer)
        {
            try
            {
                if (DB.Singers.Any(c => c.SingerName == singer.SingerName && c.SingerId != singer.SingerId))
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
