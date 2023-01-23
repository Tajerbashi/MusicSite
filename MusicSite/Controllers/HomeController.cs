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
        public ActionResult Index(int id = 0, string Section = "")
        {

            ViewBag.SectionName = Section;
            ViewBag.id = id;

            if (Section == "")
            {
                ViewBag.List = songRepository.GetAllSongView().OrderByDescending(c => c.Score).FirstOrDefault();
            }
            else if (Section == "Group")
            {
                ViewBag.Group = groupRepository.GetAllGroupToShow().Where(c => c.GroupId == id).First();
            }
            else if (Section == "PlayList")
            {
                ViewBag.List = playListRepository.GetAll().Where(c => c.playListId == id).OrderByDescending(c => c.CreateDate).FirstOrDefault();
            }
            else if (Section == "Padcast")
            {
                ViewBag.List = padcastRepository.GetAll().Where(c => c.PadcastId == id).FirstOrDefault();
            }
            else if (Section == "Album")
            {
                ViewBag.List = albumRepository.GetAllModelAlbum().Where(c => c.AlbumId == id).FirstOrDefault();
            }
            else if (Section == "Song")
            {
                ViewBag.Song = songRepository.GetAllSongView().Where(c=> c.SongId==id).FirstOrDefault();
            }
            else if (Section == "Singer")
            {

            }
            else if (Section == "Country")
            {

            }
            return View();
        }
        public ActionResult PlayList(int id=0)
        {
            if ( id != 0 )
            {
                ViewBag.Group = groupRepository.GetAllGroupToShow().Where(c => c.GroupId == id).First();
            }
            else
            {
                ViewBag.Group = groupRepository.GetAllGroupToShow().OrderByDescending(c => c.Score).FirstOrDefault();
            }
            return PartialView();
        }
    }
}