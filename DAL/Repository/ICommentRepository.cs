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
        void Save();
        IEnumerable<Comment> GetAllComments(int id);
    }
}
