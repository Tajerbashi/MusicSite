using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public interface ICommentRepository:IDisposable
    {
        bool Add(Comment comment,string type);
        bool Update(Comment comment, string type);
        bool Delete(Comment comment, string type);
        bool Delete(int id, string type);
        void Save();
        IEnumerable<Comment> GetAllComments(int id, string type);
        Comment GetById(int id, string type);
    }
}
