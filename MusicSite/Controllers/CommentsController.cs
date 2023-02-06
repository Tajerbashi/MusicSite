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
        public ActionResult AllComment(int id)
        {
            ViewBag.Id = id;
            ViewBag.CommentCount = commentRepository.GetAllComments(id).Count();
            return PartialView();
        }
        public ActionResult ShowComment(int id)
        {
            return PartialView(commentRepository.GetAllComments(id));
        }
        public ActionResult AddComment(int id,string name,string email,string comment)
        {
            Comment commentT = new Comment();
            commentT.Song = songRepository.GetById(id);
            commentT.FullName = name;
            commentT.Email = email;
            commentT.CommentText = comment;
            commentT.CreateDate = DateTime.Now;
            commentRepository.Add(commentT);
            commentRepository.Save();
            return PartialView("ShowComment", commentRepository.GetAllComments(id));
        }
    }
}
