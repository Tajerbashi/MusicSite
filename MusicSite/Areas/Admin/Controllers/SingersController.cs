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
    public class SingersController : Controller
    {
        private DbContexts db = new DbContexts();
        private ISingerRepository singerRep;
        private ICountryRepository countryRepository;
        public SingersController()
        {
            singerRep = new SingerRepository(db);
            countryRepository = new CountryRepository(db);
        }
        // GET: Admin/Singers
        public ActionResult Index()
        {
            return View(singerRep.GetAll());
        }

        // GET: Admin/Singers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Singer singer = singerRep.GetById(id.Value);
            if (singer == null)
            {
                return HttpNotFound();
            }
            return PartialView(singer);
        }

        // GET: Admin/Singers/Create
        public ActionResult Create()
        {
            ViewBag.CountryId = new SelectList(countryRepository.GetAll(), "CountryId", "CountryName");
            return PartialView();
        }

        // POST: Admin/Singers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CountryId,SingerId,SingerName,CreateDate")] Singer singer)
        {
            if (ModelState.IsValid)
            {
                singerRep.Add(singer);
                singerRep.Save();
                return RedirectToAction("Index");
            }

            return PartialView(singer);
        }

        // GET: Admin/Singers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewBag.CountryId = new SelectList(countryRepository.GetAll(), "CountryId", "CountryName");
            Singer singer = singerRep.GetById(id.Value);
            if (singer == null)
            {
                return HttpNotFound();
            }
            return PartialView(singer);
        }

        // POST: Admin/Singers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CountryId,SingerId,SingerName,CreateDate")] Singer singer)
        {
            if (ModelState.IsValid)
            {
                singerRep.Update(singer);
                singerRep.Save();
                return RedirectToAction("Index");
            }
            return PartialView(singer);
        }

        // GET: Admin/Singers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Singer singer = singerRep.GetById(id.Value);
            if (singer == null)
            {
                return HttpNotFound();
            }
            return PartialView(singer);
        }

        // POST: Admin/Singers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Singer singer = singerRep.GetById(id);
            singerRep.Delete(singer);
            singerRep.Save();
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
