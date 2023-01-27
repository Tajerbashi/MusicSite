using DAL.Context;
using DAL.Repository;
using DAL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicSite.Controllers
{
    public class SectionController : Controller
    {
        DbContexts DB=new DbContexts();
        IGroupRepository groupRepository;
        ISongRepository songRepository;
        IPlayListRepository playListRepository;
        // GET: Section
        public SectionController()
        {
            groupRepository = new GroupRepository(DB);
            songRepository = new SongRepository(DB);
            playListRepository = new PlayListRepository(DB);
        }
        public ActionResult Group()
        {
            return PartialView(groupRepository.GetAllGroupToShow());
        }
        public ActionResult Songs()
        {
            ViewBag.List=songRepository.GetAllSongView();
            return PartialView();
        }
        public ActionResult PlaySong(int id)
        {
            ViewBag.List = songRepository.GetAllSongView().Where(c => c.SongId==id).ToList();
            return PartialView();
        }
        public ActionResult PlayLists()
        {
            return PartialView(playListRepository.GetAllToShow());
        }
    }
}