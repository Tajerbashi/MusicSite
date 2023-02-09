using DAL.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UserRepository : IUserRepository
    {
        DbContexts DB;
        public UserRepository(DbContexts DB)
        {
            this.DB = DB;
        }

        public bool Add(User user)
        {
            try
            {
                DB.Users.Add(user);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void Delete(User user)
        {
            DB.Users.Remove(user);
        }

        public void Delete(int id)
        {
            this.Delete(GetById(id));
        }

        public void Dispose()
        {
            DB.Dispose();
        }

        public IEnumerable<User> GetAll()
        {
            return DB.Users.ToList();
        }

        public User GetById(int id)
        {
            return DB.Users.Find(id);
        }

        public User GetByUsername(string Name)
        {
            return DB.Users.Where(c => c.Username==Name).FirstOrDefault();
        }

        public User GetUserById(int id)
        {
            return DB.Users.Find(id);
        }

        public bool GetUserByUsernamePassword(string username, string password)
        {
            return DB.Users.Any(c => c.Username == username && c.Password == password);
        }

        public bool IsUser(User user)
        {
            return DB.Users.Any(
                c => 
                (c.Username == user.Username && c.Password == user.Password)
                  ||
                c.Email== user.Email
                  ||
                c.Phone== user.Phone
                  );
        }

        public void Save()
        {
            DB.SaveChanges();
        }

        public bool Update(User user)
        {
            try
            {
                DB.Entry(user).State = EntityState.Modified;
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
