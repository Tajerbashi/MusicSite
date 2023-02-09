using DAL.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class AdminRepository : IAdminRepository
    {
        private DbContexts DB;
        public AdminRepository(DbContexts DB)
        {
            this.DB = DB;
        }
        public bool Add(Admin admin)
        {
            try
            {
                DB.Admins.Add(admin);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(Admin admin)
        {
            try
            {
                DB.Entry(admin).State=EntityState.Deleted;
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
                Admin admin = DB.Admins.Find(id);
                this.Delete(admin);
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

        public IEnumerable<Admin> GetAll()
        {
            return DB.Admins.OrderByDescending(c=>c.CreateDate).ToList();
        }

        public Admin GetById(int id)
        {
            return DB.Admins.Find(id);
        }

        public Admin GetByName(string Name)
        {
            return DB.Admins.Where(c=> c.Name==Name).SingleOrDefault();
        }

        public bool IsAdmin(Admin admin)
        {
            return DB.Admins.Any(c => c.Username==admin.Username && c.Password==admin.Password);
        }

        public void Save()
        {
            DB.SaveChanges();
        }

        public bool Update(Admin admin)
        {
            try
            {
                DB.Entry(admin).State = EntityState.Modified;
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
