using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Routing;
using System.Xml.Linq;
using DAL;
using DAL.Context;
using DAL.Repository;
using DAL.Services;

namespace MusicSite.Controllers
{
    public class CommentsController : Controller
    {
        private DbContexts db = new DbContexts();
        ICommentRepository commentRepository;
        ISongRepository songRepository;
        IPadcastRepository padcastRepository;
        public CommentsController()
        {
            commentRepository = new CommentRepository(db);
            songRepository = new SongRepository(db);
            padcastRepository = new PadcastRepository(db);
        }
        // GET: Comments

        public ActionResult AddComment()
        {
            return View();
        }
        
        [Route("Comments/ShowSongComments/{id}")]
        public ActionResult ShowSongComments(int id)
        {
            return PartialView(commentRepository.GetAllComments().Where(c => c.Song.SongId==id).ToList());
        }
        [Route("Comments/ShowPadcastComments/{id}")]
        public ActionResult ShowPadcastComments(int id)
        {
            return PartialView(commentRepository.GetAllComments().Where(c => c.Padcast.PadcastId == id).ToList());
        }
        public ActionResult AddComment(string username,string email,string commentT,int Id,string type)
        {
            Comment comment = new Comment();

            if (type == "song")
            {
                comment.Song = songRepository.GetById(Id);
            }
            else
            {
                comment.Padcast = padcastRepository.GetById(Id);
            }
            comment.FullName = username;
            comment.Email = email;
            comment.CommentText = commentT;
            comment.CreateDate = DateTime.Now;
            commentRepository.Add(comment);
            if (type == "song")
            {
                return PartialView("ShowSongComments", commentRepository.GetAllComments().Where(c => c.Song.SongId == Id));
            }
            else
            {
                return PartialView("ShowPadcastComments", commentRepository.GetAllComments().Where(c => c.Padcast.PadcastId == Id));
            }
        }
    }
}
