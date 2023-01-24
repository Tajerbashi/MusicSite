using DAL.Services;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL.Context;
using DAL.Repository;
using DAL.ViewModels;

namespace MusicSite.Controllers
{
    public class HomeController : Controller
    {
        DbContexts DB = new DbContexts();
        ISongRepository songRepository;
        IGroupRepository groupRepository;
        IAlbumRepository albumRepository;
        public HomeController()
        {
            songRepository =new SongRepository(DB);
            groupRepository =new GroupRepository(DB);
            albumRepository =new AlbumRepository(DB);
        }
        public ActionResult Index()
        {
            ViewBag.List=songRepository.GetAllSongView().OrderByDescending(c => c.Visit).Take(30);
            return View();
        }

        public ActionResult UserPanel()
        {
            return PartialView();
        }

        public ActionResult NavPanel()
        {
            return PartialView();
        }

        public ActionResult MostTopSongs()
        {
            ViewBag.List = songRepository.GetAllSongView().OrderByDescending(c => c.Score).Take(30);
            return PartialView();
        }
        public ActionResult PlayListGroup()
        {
            return View();
        }
        public ActionResult Player()
        {
            return PartialView();
        }
        public ActionResult PlayLastSingleSong()
        {
            ViewBag.List = songRepository.GetAllSongView().Take(30);
            return PartialView();
        }
        public ActionResult MostTopAlbums()
        {
            ViewBag.List = albumRepository.GetAllModelAlbum().Take(30);
            return PartialView();
        }
        public ActionResult Footer()
        {
            return PartialView();
        }
    }
}