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
        public CommentsController()
        {
            commentRepository = new CommentRepository(db);
            songRepository = new SongRepository(db);
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
        
        public ActionResult AddComment(string username,string email,string commentT,int Id,string type)
        {
            Comment comment = new Comment();
            comment.Song = songRepository.GetById(Id);
            comment.FullName = username;
            comment.Email = email;
            comment.CommentText = commentT;
            comment.CreateDate = DateTime.Now;
            commentRepository.Add(comment);
            return PartialView("ShowSongComments", commentRepository.GetAllComments().Where(c => c.Song.SongId == Id));
        }
    }
}
