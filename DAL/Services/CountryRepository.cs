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

        public IEnumerable<ViewCountry> GetAllToShow()
        {
            return DB.Countries
                .Include(c => c.PlayLists)
                .Include(c => c.Singers)
                .Select(country => new ViewCountry
                {
                    CountryId = country.CountryId,
                    CountryName = country.CountryName,
                    PlayLists = country.PlayLists,
                    Singers = country.Singers,
                });
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
                DB.Entry(country).State = System.Data.Entity.EntityState.Modified;
                return true;
            }
            catch
            {

                throw;
            }
        }
    }
}
