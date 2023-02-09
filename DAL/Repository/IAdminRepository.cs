using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IAdminRepository:IDisposable
    {
        bool Add(Admin admin);
        bool Update(Admin admin);
        bool Delete(Admin admin);
        bool Delete(int id);
        void Save();
        bool IsAdmin(Admin admin);
        IEnumerable<Admin> GetAll();
        Admin GetById(int id);
        Admin GetByName(string Name);
    }
}
