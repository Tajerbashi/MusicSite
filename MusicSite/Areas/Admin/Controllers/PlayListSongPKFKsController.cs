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

namespace MusicSite.Areas.Admin.Controllers
{
    public class PlayListSongPKFKsController : Controller
    {
        private DbContexts db = new DbContexts();

        // GET: Admin/PlayListSongPKFKs
        public ActionResult Index()
        {
            return View(db.PlayListSongPKFKs.Include(c => c.PlayList).ToList());
        }

        // GET: Admin/PlayListSongPKFKs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlayListSongPKFK playListSongPKFK = db.PlayListSongPKFKs.Find(id);
            if (playListSongPKFK == null)
            {
                return HttpNotFound();
            }
            return View(playListSongPKFK);
        }

        // GET: Admin/PlayListSongPKFKs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/PlayListSongPKFKs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDPlayListSongPKFK")] PlayListSongPKFK playListSongPKFK)
        {
            if (ModelState.IsValid)
            {
                db.PlayListSongPKFKs.Add(playListSongPKFK);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(playListSongPKFK);
        }

        // GET: Admin/PlayListSongPKFKs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlayListSongPKFK playListSongPKFK = db.PlayListSongPKFKs.Find(id);
            if (playListSongPKFK == null)
            {
                return HttpNotFound();
            }
            return View(playListSongPKFK);
        }

        // POST: Admin/PlayListSongPKFKs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDPlayListSongPKFK")] PlayListSongPKFK playListSongPKFK)
        {
            if (ModelState.IsValid)
            {
                db.Entry(playListSongPKFK).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(playListSongPKFK);
        }

        // GET: Admin/PlayListSongPKFKs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlayListSongPKFK playListSongPKFK = db.PlayListSongPKFKs.Find(id);
            if (playListSongPKFK == null)
            {
                return HttpNotFound();
            }
            return View(playListSongPKFK);
        }

        // POST: Admin/PlayListSongPKFKs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PlayListSongPKFK playListSongPKFK = db.PlayListSongPKFKs.Find(id);
            db.PlayListSongPKFKs.Remove(playListSongPKFK);
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
