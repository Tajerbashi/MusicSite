using DAL.Services;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL.Context;
using DAL.Repository;

namespace MusicSite.Controllers
{
    public class HomeController : Controller
    {
        DbContexts DB = new DbContexts();
        ISongRepository songRepository;
        public HomeController()
        {
            songRepository = new SongRepository(DB);
        }

        public ActionResult Index(int id=0)
        {
            Song song = songRepository.GetById(id);
            if (song == null)
            {
                song = songRepository.GetAll().OrderByDescending(c =>c.Score).FirstOrDefault();
            }
            return View(song);
        }
    }
}