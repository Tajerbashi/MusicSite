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
        IGroupRepository groupRepository;
        IPlayListRepository playListRepository;
        IPadcastRepository padcastRepository;
        IAlbumRepository albumRepository;
        ICountryRepository countryRepository;
        public HomeController()
        {
            songRepository = new SongRepository(DB);
            groupRepository = new GroupRepository(DB);
        }

        public ActionResult Index(int id=0,string Section="")
        {
            ViewBag.SectionName = Section;
            ViewBag.List = songRepository.GetAllSongView().OrderByDescending(c => c.Score).FirstOrDefault();
            return View();
        }
        public ActionResult EmptySection()
        {
            ViewBag.List = songRepository.GetAllSongView().OrderByDescending(c => c.Score).FirstOrDefault();
            return View();
        }
        public ActionResult GroupSection(int id)
        {
            ViewBag.List = groupRepository.GetAllGroupToShow().Where(c => c.GroupId == id);
            return View();
        }
        public ActionResult SongSection(int id)
        {
            ViewBag.List = songRepository.GetById(id);
            return View();
        }
        public ActionResult AlbumSection(int id)
        {
            ViewBag.List = albumRepository.GetAllModelAlbum().Where(c => c.AlbumId == id);
            return View();
        }
        public ActionResult PlayListSection(int id)
        {
            ViewBag.List = playListRepository.GetAll().OrderByDescending(c => c.CreateDate).FirstOrDefault();
            return View();
        }
        public ActionResult PadcastSection(int id)
        {
            ViewBag.List = padcastRepository.GetAll().Where(c => c.PadcastId == id);
            return View();
        }
    }
}