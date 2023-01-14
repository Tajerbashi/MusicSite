using DAL.Context;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Services
{
    public class CountryRepository : ICountryRepository
    {
        DbContexts DB;
        public CountryRepository(DbContexts DB)
        {
            this.DB = DB;
        }
        public bool Add(Country country)
        {
            try
            {
                DB.Countries.Add(country);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(Country country)
        {
            try
            {
                DB.Countries.Remove(country);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            return this.Delete(this.GetById(id));
        }

        public void Dispose()
        {
            DB.Dispose();
        }

        public IEnumerable<Country> GetAll()
        {
            return DB.Countries.ToList();
        }

        public Country GetById(int id)
        {
            return DB.Countries.Find(id);
        }

        public Country GetByName(string Name)
        {
            return DB.Countries.Where(c => c.CountryName==Name).FirstOrDefault();
        }

        public void Save()
        {
            DB.SaveChanges();
        }

        public bool Update(Country country)
        {
            try
            {
                DB.Entry(country).State = System.Data.Entity.EntityState.Deleted;
                return true;
            }
            catch
            {

                throw;
            }
        }
    }
}
