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
    public class CommentRepository:ICommentRepository
    {
        DbContexts DB;
        public CommentRepository(DbContexts DB)
        {
            this.DB = DB;

        }
        public bool Add(Comment comment)
        {
            try
            {
                DB.Comments.Add(comment);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(Comment comment)
        {
            try
            {
                DB.Comments.Remove(comment);
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
                Comment comment = DB.Comments.Find(id);
                this.Delete(comment);
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
        
        public IEnumerable<Comment> GetAllComments()
        {
            return DB.Comments.Include(c => c.Song).ToList();
        }

        public Comment GetById(int id)
        {
            return DB.Comments.Find(id);
        }
        public void Save()
        {
            DB.SaveChanges();
        }

        public bool Update(Comment comment)
        {
            try
            {
                DB.Entry(comment).State = EntityState.Modified;
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
