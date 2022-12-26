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
    public class PlayListsController : Controller
    {
        private DbContexts db = new DbContexts();

        // GET: Admin/PlayLists
        public ActionResult Index()
        {
            var playLists = db.PlayLists.Include(p => p.GrouptType);
            return View(playLists.ToList());
        }

        // GET: Admin/PlayLists/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlayList playList = db.PlayLists.Find(id);
            if (playList == null)
            {
                return HttpNotFound();
            }
            return PartialView(playList);
        }

        // GET: Admin/PlayLists/Create
        public ActionResult Create()
        {
            ViewBag.GroupId = new SelectList(db.GrouptTypes, "GroupId", "groupName");
            return PartialView();
        }

        // POST: Admin/PlayLists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "playListId,GroupId,Name,Description,PlayCount,CreateDate,Type")] PlayList playList)
        {
            if (ModelState.IsValid)
            {
                playList.CreateDate= DateTime.Now;
                playList.PlayCount= 0;

                db.PlayLists.Add(playList);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GroupId = new SelectList(db.GrouptTypes, "GroupId", "groupName", playList.GroupId);
            return PartialView(playList);
        }

        // GET: Admin/PlayLists/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlayList playList = db.PlayLists.Find(id);
            if (playList == null)
            {
                return HttpNotFound();
            }
            ViewBag.GroupId = new SelectList(db.GrouptTypes, "GroupId", "groupName", playList.GroupId);
            return PartialView(playList);
        }

        // POST: Admin/PlayLists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "playListId,GroupId,Name,Description,PlayCount,CreateDate,Type")] PlayList playList)
        {
            if (ModelState.IsValid)
            {
                playList.CreateDate = DateTime.Now;
                playList.PlayCount = 0;
                db.Entry(playList).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GroupId = new SelectList(db.GrouptTypes, "GroupId", "groupName", playList.GroupId);
            return PartialView(playList);
        }

        // GET: Admin/PlayLists/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlayList playList = db.PlayLists.Find(id);
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
            PlayList playList = db.PlayLists.Find(id);
            db.PlayLists.Remove(playList);
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
