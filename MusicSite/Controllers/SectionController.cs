using DAL;
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
        IAlbumRepository albumRepository;
        IPadcastRepository padcastRepository;
        // GET: Section
        public SectionController()
        {
            groupRepository = new GroupRepository(DB);
            songRepository = new SongRepository(DB);
            playListRepository = new PlayListRepository(DB);
            albumRepository= new AlbumRepository(DB);
            padcastRepository= new PadcastRepository(DB);
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
        public ActionResult PlayListsShowSongs(int id)
        {
            return PartialView(playListRepository.GetAllToShow().Where(c => c.PlayListId==id).ToList());
        }
        public ActionResult PlayListsPlay(int id)
        {
            PlayList playList = playListRepository.GetById(id);
            playList.Visit += 1;
            playListRepository.Save();
            ViewBag.Name = playList.PlayListName;
            return View(playListRepository.GetAllToShow().Where(c => c.PlayListId == id).ToList());
        }
        public ActionResult Albums()
        {
            return PartialView(albumRepository.GetAllModelAlbum());
        }
        public ActionResult ShowAlbumSongs(int id)
        {
            return PartialView(songRepository.GetAllSongView().Where(c => c.Album.AlbumId == id).ToList());
        }
        public ActionResult AlbumPlay(int id)
        {
            Album album = albumRepository.GetById(id);
            album.Visit += 1;
            albumRepository.Save();
            ViewBag.Name = album.AlbumName;
            return View(songRepository.GetAllSongView().Where(c => c.Album.AlbumId == id).ToList());
        }
        public ActionResult Padcasts()
        {
            return PartialView(padcastRepository.GetAllToShow());
        }
        public ActionResult PadcastPlay(int id)
        {
            Padcast padcast = padcastRepository.GetById(id);
            padcast.Visit += 1;
            padcastRepository.Save();
            return View(padcastRepository.GetAllToShow().Where(c => c.PadcastId == id).Single());
        }
    }
}