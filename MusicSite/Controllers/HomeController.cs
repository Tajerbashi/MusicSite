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

        public ActionResult Index(int id=0)
        {
            if (id==0)
            {
                ViewBag.List = songRepository
                .GetAllSongView()
                .OrderByDescending(c => c.Visit)
                .Take(30);
            }
            else
            {
                ViewBag.List = songRepository.GetAllSongView().Where(c => c.SongId == id).ToList();
            }
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
            ViewBag.List = songRepository.GetAllSongView().OrderByDescending(c => c.Visit).Take(30);
            return PartialView();
        }

        public ActionResult PlayListGroup(int id)
        {
            ViewGroup viewGroup=groupRepository.GetAllGroupToShow().Where(c => c.GroupId==id).FirstOrDefault();
            Group group = groupRepository.GetById(id);
            group.Visit += 1;
            groupRepository.Save();
            return View(viewGroup);
        }

        public ActionResult Player(int id=0)
        {
            ViewSong song;
            if (id == 0)
            {
                song = new ViewSong
                {
                    SingerName = "",
                    SongName = "",
                    Picture = "../../Photos/FirstLoad.jpg",
                    AddressFile = "",
                    Score = 5,
                    Visit = 1,
                };
            }
            else
            {
                song = songRepository.GetAllSongView().Where(c => c.SongId == id).FirstOrDefault();
                if (song != null)
                {
                    song.Visit += 1;
                    songRepository.Save();
                }
                else
                {
                    song = new ViewSong
                    {
                        SingerName = "",
                        SongName = "",
                        Picture = "../../Photos/11.jpg",
                        AddressFile = "",
                        Score = 5,
                        Visit = 1,
                    };
                }
            }
            return PartialView(song);
        }
        public ActionResult PlayLastSingleSong()
        {
            ViewBag.List = songRepository.GetAllSongView().Where(c=> !c.Remix).Take(30);
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