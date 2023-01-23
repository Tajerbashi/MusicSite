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
    public class HeaderController : Controller
    {
        DbContexts DB=new DbContexts();
        ISongRepository songRepository;
        IAlbumRepository albumRepository;
        public HeaderController()
        {
            songRepository = new SongRepository(DB);
            albumRepository = new AlbumRepository(DB);
        }
        // GET: Header
        public ActionResult LoginPanelUser()
        {
            return PartialView();
        }
        public ActionResult SearchPanel()
        {
            return PartialView();
        }
        public ActionResult ShowMostSongsScore()
        {
            return PartialView(songRepository.GetAllSongView().OrderByDescending(c => c.Visit));
        }
        public ActionResult ShowMostSongsDate()
        {
            return PartialView(songRepository.GetAllSongView());
        }
        public ActionResult ShowMostAlbums()
        {
            return PartialView(albumRepository.GetAllModelAlbum());
        }
    }
}