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
        public HomeController()
        {
            songRepository =new SongRepository(DB);
            groupRepository =new GroupRepository(DB);
        }
        public ActionResult Index()
        {
            return View();
        }
    }
}