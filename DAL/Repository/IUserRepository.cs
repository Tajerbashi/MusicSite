using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public interface IUserRepository:IDisposable
    {
        bool Add(User user);
        bool Update(User user);
        bool Delete(User user);
        bool Delete(int id);
        void Save();
        IEnumerable<User> GetAll();
        User GetById(int id);
        User GetByName(string Name);
    }
}
