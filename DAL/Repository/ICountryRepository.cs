using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface ICountryRepository:IDisposable
    {
        bool Add(Country country);
        bool Update(Country country);
        bool Delete(Country country);
        bool Delete(int id);
        void Save();
        IEnumerable<Country> GetAll();
        IEnumerable<ViewCountry> GetAllToShow();
        Country GetById(int id);
        Country GetByName(string Name);
    }
}
