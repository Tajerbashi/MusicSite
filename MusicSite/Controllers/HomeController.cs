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
        IAlbumRepository albumRepository;
        IGroupRepository groupRepository;
        public HomeController()
        {
            songRepository =new SongRepository(DB);
            albumRepository =new AlbumRepository(DB);
            groupRepository =new GroupRepository(DB);
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
        public ActionResult PlayListGroup(int id)
        {
            ViewGroup viewGroup=groupRepository.GetAllGroupToShow().Where(c => c.GroupId==id).FirstOrDefault();
            return View();
        }
        public ActionResult Player(int id=0)
        {
            ViewSong song;
            if (id==0)
            {
                song=songRepository.GetAllSongView().OrderByDescending(c => c.Visit).FirstOrDefault();
            }
            else
            {
                song = songRepository.GetAllSongView().Where(c => c.SongId==id).FirstOrDefault();
            }
            return PartialView(song);
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