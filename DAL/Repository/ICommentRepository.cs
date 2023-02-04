using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public interface ICommentRepository:IDisposable
    {
        bool Add(Comment comment);
        bool Update(Comment comment);
        bool Delete(Comment comment);
        bool Delete(int id);
        void Save();
        IEnumerable<Comment> GetAllComments();
        Comment GetById(int id);
    }
}
