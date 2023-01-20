using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DAL;
using DAL.Context;
using DAL.Repository;
using DAL.Services;

namespace MusicSite.Areas.Admin.Controllers
{
    public class PlayListsController : Controller
    {
        IPlayListRepository PlayList;
        ISongRepository Songs;
        ICountryRepository country;
        private DbContexts DB=new DbContexts();
        public PlayListsController()
        {
            PlayList= new PlayListRepository(DB);
            Songs = new SongRepository(DB);
            country = new CountryRepository(DB);
        }

        // GET: Admin/PlayLists
        public ActionResult Index()
        {
            return View(PlayList.GetAll());
        }

        // GET: Admin/PlayLists/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewBag.CountryId = new SelectList(country.GetAll(), "CountryId", "CountryName");
            PlayList playList = PlayList.GetById(id.Value);
            if (playList == null)
            {
                return HttpNotFound();
            }
            return PartialView(playList);
        }

        // GET: Admin/PlayLists/Create
        public ActionResult Create()
        {
            ViewBag.CountryId = new SelectList(country.GetAll(), "CountryId", "CountryName");
            return PartialView();
        }

        // POST: Admin/PlayLists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CountryId,playListId,PlayListName,PlayCount,CreateDate,Type")] PlayList playList,HttpPostedFileBase photo)
        {
            if (ModelState.IsValid)
            {
                if (photo != null)
                {
                    playList.Picture = Guid.NewGuid() + Path.GetExtension(photo.FileName);
                    photo.SaveAs(Server.MapPath("/Files/Photos/" + playList.Picture));
                }
                playList.CreateDate= DateTime.Now;
                PlayList.Add(playList);
                PlayList.Save();
                return RedirectToAction("Index");
            }

            return PartialView(playList);
        }

        // GET: Admin/PlayLists/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewBag.CountryId = new SelectList(country.GetAll(), "CountryId", "CountryName");
            PlayList playList = PlayList.GetById(id.Value);
            if (playList == null)
            {
                return HttpNotFound();
            }
            return PartialView(playList);
        }

        // POST: Admin/PlayLists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CountryId,playListId,PlayListName,PlayCount,CreateDate,Type,Picture")] PlayList playList,HttpPostedFileBase photo)
        {
            if (ModelState.IsValid)
            {
                if (photo != null)
                {
                    if (playList.Picture != null)
                    {
                        System.IO.File.Delete(Server.MapPath("/Files/Photos/" + playList.Picture));
                    }
                    playList.Picture = Guid.NewGuid() + Path.GetExtension(photo.FileName);
                    photo.SaveAs(Server.MapPath("/Files/Photos/" + playList.Picture));
                }
                playList.CreateDate = DateTime.Now;
                PlayList.Update(playList);
                PlayList.Save();
                return RedirectToAction("Index");
            }
            return PartialView(playList);
        }

        // GET: Admin/PlayLists/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlayList playList =PlayList.GetById(id.Value);
            if (playList == null)
            {
                return HttpNotFound();
            }
            return PartialView(playList);
        }

        // POST: Admin/PlayLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PlayList playList = PlayList.GetById(id);
            if (playList.Picture != null)
            {
                System.IO.File.Delete(Server.MapPath("/Files/Photos/" + playList.Picture));
            }
            PlayList.Delete(playList);
            PlayList.Save();
            return RedirectToAction("Index");
        }
        
        // PlayListSong PKFK
        public ActionResult CreatePlayListSongs()
        {
            ViewBag.Songs = Songs.GetAll();
            ViewBag.Playlists = new SelectList(PlayList.GetAll(), "playListId", "PlayListName");
            return View();
        }
        public ActionResult ShowPlayListSongs()
        {
            ViewBag.Playlists = PlayList.GetAllPlayListSongPKFK();
            return View();
        }

        [HttpPost]
        public void CreatePlayListSongs(string PlayListId, List<string> SongIdList)
        {
            PlayList playList = PlayList.GetById(Int32.Parse(PlayListId));
            foreach (var i in SongIdList)
            {
                PlayListSongPKFK PKFK= new PlayListSongPKFK();
                Song song = Songs.GetById(Convert.ToInt32(i));

                PKFK.PlayList = playList;
                PKFK.Song = song;
                playList.PlayListSongPKFK.Add(PKFK);
                song.PlayListSongPKFK.Add(PKFK);
            }
            Songs.Save();
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                DB.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
