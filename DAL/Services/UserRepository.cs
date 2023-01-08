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

        public bool Delete(User user)
        {
            try
            {
                DB.Entry(user).State = EntityState.Deleted;
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
                User usr= this.GetById(id);
                this.Delete(usr);
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

        public IEnumerable<User> GetAll()
        {
            return DB.Users.OrderByDescending(c => c.CreateDate).ToList();
        }

        public User GetById(int id)
        {
            return this.DB.Users.Find(id);
        }

        public User GetByName(string Name)
        {
            return this.DB.Users.Where(c => c.Name == Name).FirstOrDefault();
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
