using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace DAL
{
    public interface IUserRepository:IDisposable
    {
        bool Add(User user);
        bool Update(User user);
        bool IsUser(string username, string password);
        void Save();
        User GetUserById(int id);
        User GetUserByUsernamePassword(string username, string password);
        void Delete(User user);
        void Delete(int id);
        IEnumerable<User> GetAll();
        User GetById(int id);
        User GetByName(string Name);
    }
}
