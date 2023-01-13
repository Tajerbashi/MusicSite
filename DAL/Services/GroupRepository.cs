using DAL.Context;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DAL.Services
{
    public class GroupRepository : IGroupRepository
    {
        DbContexts DB;
        public GroupRepository(DbContexts DB) 
        {
            this.DB = DB;
        }
        public bool Add(Group group)
        {
            try
            {
                DB.GrouptTypes.Add(group);
                return true;
            }
            catch 
            {
                return false;
            }
        }

        public bool Delete(Group group)
        {
            try
            {
                DB.Entry(group).State = EntityState.Deleted;
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
                Group group = DB.GrouptTypes.Find(id);
                this.Delete(group);
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

        public IEnumerable<Group> GetAll()
        {
            return DB.GrouptTypes.OrderByDescending(c => c.CreateDate).ToList();
        }

        public Group GetById(int id)
        {
            return DB.GrouptTypes.Find(id);
        }

        public Group GetByName(string Name)
        {
            return DB.GrouptTypes.Where(c => c.GroupName == Name).SingleOrDefault();
        }

        public void Save()
        {
            DB.SaveChanges();
        }

        public bool Update(Group group)
        {
            try
            {
                DB.Entry(group).State= EntityState.Modified;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
