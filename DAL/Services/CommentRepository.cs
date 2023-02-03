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
        public bool Add(Comment comment, string type)
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

        public bool Delete(Comment comment, string type)
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

        public bool Delete(int id, string type)
        {
            try
            {
                Comment comment = DB.Comments.Find(id);
                this.Delete(comment,type);
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
        
        public IEnumerable<Comment> GetAllComments(int id, string type)
        {
            if (type == "song")
            {
                return DB.Comments.Where(c => c.Song.SongId == id).ToList();
            }
            else
            {
                return DB.Comments.Where(c => c.Padcast.PadcastId == id).ToList();
            }
        }

        public Comment GetById(int id, string type)
        {
            return DB.Comments.Find(id);
        }
        public void Save()
        {
            DB.SaveChanges();
        }

        public bool Update(Comment comment, string type)
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
