using DAL.Context;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Services
{
    public class PadcastRepository:IPadcastRepository
    {
        DbContexts DB;
        public PadcastRepository(DbContexts DB)
        {
            this.DB = DB;
        }

        public bool Add(Padcast padcast)
        {
            try
            {
                DB.Padcasts.Add(padcast);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(Padcast padcast)
        {
            try
            {
                DB.Padcasts.Remove(padcast);
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
                return this.Delete(this.GetById(id));
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

        public IEnumerable<Padcast> GetAll()
        {
            return DB.Padcasts.ToList();
        }

        public Padcast GetById(int id)
        {
            return DB.Padcasts.Find(id);
        }

        public Padcast GetByName(string Name)
        {
            return DB.Padcasts.Where(c => c.PadcastName == Name).FirstOrDefault();
        }

        public void Save()
        {
            DB.SaveChanges();
        }

        public bool Update(Padcast padcast)
        {
            try
            {
                DB.Entry(padcast).State=System.Data.Entity.EntityState.Modified;
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
