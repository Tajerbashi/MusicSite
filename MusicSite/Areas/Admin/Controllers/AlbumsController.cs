using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
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
    public class AlbumsController : Controller
    {
        private DbContexts db = new DbContexts();
        IAlbumRepository albumRepository;
        public AlbumsController()
        {
            albumRepository = new AlbumRepository(db);
        }
        // GET: Admin/Albums
        public ActionResult Index()
        {
            return View(albumRepository.GetAll());
        }

        // GET: Admin/Albums/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Album album = albumRepository.GetById(id.Value);
            if (album == null)
            {
                return HttpNotFound();
            }
            return PartialView(album);
        }

        // GET: Admin/Albums/Create
        public ActionResult Create()
        {
            ViewBag.SingerId = new SelectList(albumRepository.GetAll(), "SingerId", "SingerName");
            return PartialView();
        }

        // POST: Admin/Albums/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AlbumId,SingerId,AlbumName,Visit,Score,Type,CreateDate")] Album album)
        {
            if (ModelState.IsValid)
            {
                albumRepository.Add(album);
                albumRepository.Save();
                return RedirectToAction("Index");
            }

            ViewBag.SingerId = new SelectList(albumRepository.GetAll(), "SingerId", "SingerName", album.SingerId);
            return PartialView(album);
        }

        // GET: Admin/Albums/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Album album = albumRepository.GetById(id.Value);
            if (album == null)
            {
                return HttpNotFound();
            }
            ViewBag.SingerId = new SelectList(albumRepository.GetAll(), "SingerId", "SingerName", album.SingerId);
            return PartialView(album);
        }

        // POST: Admin/Albums/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AlbumId,SingerId,AlbumName,Visit,Score,Type,CreateDate")] Album album)
        {
            if (ModelState.IsValid)
            {
                albumRepository.Update(album);
                albumRepository.Save();
                return RedirectToAction("Index");
            }
            ViewBag.SingerId = new SelectList(albumRepository.GetAll(), "SingerId", "SingerName", album.SingerId);
            return PartialView(album);
        }

        // GET: Admin/Albums/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Album album = albumRepository.GetById(id.Value);
            if (album == null)
            {
                return HttpNotFound();
            }
            return PartialView(album);
        }

        // POST: Admin/Albums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Album album = albumRepository.GetById(id);
            db.Albums.Remove(album);
            db.SaveChanges();
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
