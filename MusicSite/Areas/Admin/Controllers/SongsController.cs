using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using DAL;
using DAL.Context;
using DAL.Repository;
using DAL.Services;

namespace MusicSite.Areas.Admin.Controllers
{
    public class SongsController : Controller
    {
        private DbContexts db = new DbContexts();
        ISongRepository songRep;
        IGroupRepository groupRep;
        IAlbumRepository albumRep;
        IPlayListRepository PlayRep;

        public SongsController()
        {
            songRep = new SongRepository(db);
            groupRep = new GroupRepository(db);
            albumRep = new AlbumRepository(db);
            PlayRep = new PlayListRepository(db);
        }
        // GET: Admin/Songs
        public ActionResult Index()
        {
            return View(songRep.GetAll());
        }

        // GET: Admin/Songs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Song song = songRep.GetById(id.Value);
            if (song == null)
            {
                return HttpNotFound();
            }
            return PartialView(song);
        }

        // GET: Admin/Songs/Create
        public ActionResult Create()
        {
            ViewBag.GroupId = new SelectList(groupRep.GetAll(), "GroupId", "GroupName");
            ViewBag.AlbumId = new SelectList(albumRep.GetAll(), "AlbumId", "AlbumName");
            return View();
        }

        // POST: Admin/Songs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SongId,SongName,TypeSong,GroupId,AlbumId,Title,CreateDate,Type,AddressFile,Picture,Score,Remix,Visit")] Song song,HttpPostedFileBase photoUp,HttpPostedFileBase fileUp)
        {
            if (ModelState.IsValid)
            {
                song.CreateDate = DateTime.Now;
                if (photoUp != null)
                {
                    song.Picture = Guid.NewGuid() + Path.GetExtension(photoUp.FileName);
                    song.AddressFile = Guid.NewGuid() + Path.GetExtension(fileUp.FileName);
                    photoUp.SaveAs(Server.MapPath("/Files/Photos/" + song.Picture));
                    fileUp.SaveAs(Server.MapPath("/Files/Musics/" + song.AddressFile));
                }
                songRep.Add(song);
                song.Score= 5;
                song.Visit= 1;
                songRep.Save();
                return RedirectToAction("Index");
            }

            //ViewBag.GroupId = new SelectList(groupRep.GetAll(), "GroupId", "Name", song.GroupId);
            ViewBag.AlbumId = new SelectList(albumRep.GetAll(), "AlbumId", "AlbumName");
            ViewBag.GroupId = new SelectList(groupRep.GetAll(), "GroupId", "GroupName");
            return View(song);
        }

        // GET: Admin/Songs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Song song = songRep.GetById(id.Value);
            if (song == null)
            {
                return HttpNotFound();
            }
            //ViewBag.GroupId = new SelectList(groupRep.GetAll(), "GroupId", "Name", song.GroupId);
            ViewBag.AlbumId = new SelectList(albumRep.GetAll(), "AlbumId", "AlbumName");
            ViewBag.GroupId = new SelectList(groupRep.GetAll(), "GroupId", "GroupName");
            return View(song);
        }

        // POST: Admin/Songs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SongId,SongName,GroupId,AlbumId,Title,CreateDate,Type,TypeSong,AddressFile,Picture,Score,Remix,Visit")] Song song, HttpPostedFileBase photoUp, HttpPostedFileBase fileUp)
        {
            if (ModelState.IsValid)
            {
                if (photoUp != null)
                {
                    if (song.Picture != null)
                    {
                        System.IO.File.Delete(Server.MapPath("/Files/Photos/" + song.Picture));
                    }
                    song.Picture = Guid.NewGuid() + Path.GetExtension(photoUp.FileName);
                    photoUp.SaveAs(Server.MapPath("/Files/Photos/" + song.Picture));
                }
                if (fileUp != null)
                {
                    if (song.AddressFile != null)
                    {
                        System.IO.File.Delete(Server.MapPath("/Files/Musics/" + song.AddressFile));
                    }
                    song.AddressFile = Guid.NewGuid() + Path.GetExtension(fileUp.FileName);
                    fileUp.SaveAs(Server.MapPath("/Files/Musics/" + song.AddressFile));
                }
                songRep.Update(song);
                songRep.Save();
                return RedirectToAction("Index");
            }
            //ViewBag.GroupId = new SelectList(groupRep.GetAll(), "GroupId", "groupName", song.GroupId);
            ViewBag.AlbumId = new SelectList(albumRep.GetAll(), "AlbumId", "AlbumName");
            ViewBag.GroupId = new SelectList(groupRep.GetAll(), "GroupId", "GroupName");
            return View(song);
        }

        // GET: Admin/Songs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Song song = songRep.GetById(id.Value);
            if (song == null)
            {
                return HttpNotFound();
            }
            return PartialView(song);
        }

        // POST: Admin/Songs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Song song = songRep.GetById(id);
            if (song.Picture != null)
            {
                System.IO.File.Delete(Server.MapPath("/Files/Photos/" + song.Picture));
            }
            if (song.AddressFile != null)
            {
                System.IO.File.Delete(Server.MapPath("/Files/Musics/" + song.AddressFile));
            }
            songRep.Delete(song);
            songRep.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
