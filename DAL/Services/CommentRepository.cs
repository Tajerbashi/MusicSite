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
            DB.Comments.Add(comment);
            return true;
        }

        public void Dispose()
        {
            DB.Dispose();
        }
        
        public IEnumerable<Comment> GetAllComments(int id)
        {
            return DB.Comments.Include(c => c.Song).Where(c => c.Song.SongId==id).ToList();
        }
        public void Save()
        {
            DB.SaveChanges();
        }

    }
}
