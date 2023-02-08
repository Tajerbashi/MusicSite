using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using DAL;
using DAL.Context;
using DAL.Repository;
using DAL.ViewModels;
using DAL.Services;

namespace MusicSite.Controllers
{
    public class HomeController : Controller
    {
        DbContexts DB = new DbContexts();

        ISongRepository songRepository;
        IAlbumRepository albumRepository;
        IGroupRepository groupRepository;
        IUserRepository userRepository;

        public HomeController()
        {
            songRepository =new SongRepository(DB);
            albumRepository =new AlbumRepository(DB);
            groupRepository =new GroupRepository(DB);
            userRepository =new UserRepository(DB);
        }

        public ActionResult Index()
        {
            return View(songRepository.GetAllSongView().OrderByDescending(c => c.Album.CreateDate));
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
                        Picture = "../../Photos/FirstLoad.jpg",
                        AddressFile = "",
                        Score = 5,
                        Visit = 1,
                    };
                }
            }
            songRepository.Save();
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
        public ActionResult AddScore(int id,int score)
        {
            Song song=songRepository.GetById(id);
            song.Score += score;
            song.Visit += 1;
            songRepository.Save();
            return PartialView("Player",id);
        }
        [Route("SearchHome/{word}")]
        public ActionResult SearchHome(string word)
        {
            return PartialView(songRepository.GetAllSearchView().Where(c => c.SongName.Contains(word) || c.AlbumName.Contains(word) || c.SingerName.Contains(word)).ToList());
        }
        public ActionResult RegUser(User nUser)
        {
            User user = new User();
            user.Name = nUser.Name;
            user.Family= nUser.Family;
            user.Phone= nUser.Phone;
            user.Email = nUser.Email;
            user.Username= nUser.Username;
            user.Password = nUser.Password;
            user.Total= 0;
            user.Type = false;
            user.CreateDate = DateTime.Now;
            userRepository.Add(user);
            //userRepository.Save();
            return View(songRepository.GetAllSongView().OrderByDescending(c => c.Album.CreateDate));
        }
    }
}