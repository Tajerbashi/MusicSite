using DAL.Models;
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
        IEnumerable<Comment> GetAllCommentForPlayList(int id);
        IEnumerable<Comment> GetAllCommentForGroup(int id);
        IEnumerable<Comment> GetAllCommentForPadcast(int id);
        IEnumerable<Comment> GetAllCommentForSong(int id);
        IEnumerable<Comment> GetAllCommentForAlbum(int id);
        Comment GetById(int id);
    }
}
