using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DAL;
using DAL.Context;
using DAL.Repository;
using DAL.Services;
using static System.Net.WebRequestMethods;

namespace MusicSite.Areas.Admin.Controllers
{
    public class PadcastsController : Controller
    {
        private DbContexts db = new DbContexts();
        IPadcastRepository padcastRepository;
        ICountryRepository countryRepository;

        public PadcastsController()
        {
            padcastRepository = new PadcastRepository(db);
            countryRepository = new CountryRepository(db);
        }

        // GET: Admin/Padcasts
        public ActionResult Index()
        {
            var padcasts = padcastRepository.GetAll();
            return View(padcasts.ToList());
        }

        // GET: Admin/Padcasts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Padcast padcast = padcastRepository.GetById(id.Value);
            if (padcast == null)
            {
                return HttpNotFound();
            }
            return PartialView(padcast);
        }

        // GET: Admin/Padcasts/Create
        public ActionResult Create()
        {
            ViewBag.CountryId = new SelectList(countryRepository.GetAll(), "CountryId", "CountryName");
            return View();
        }

        // POST: Admin/Padcasts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PadcastId,CountryId,PadcastName,Score,Visit,Type,AddressFile,Picture,CreateDate")] Padcast padcast,HttpPostedFileBase photo,HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (photo != null)
                {
                    padcast.Picture = Guid.NewGuid() + Path.GetExtension(photo.FileName);
                    photo.SaveAs(Server.MapPath("/Files/Photos/" + padcast.Picture));
                }
                if (file != null)
                {
                    padcast.AddressFile = Guid.NewGuid() + Path.GetExtension(file.FileName);
                    file.SaveAs(Server.MapPath("/Files/Musics/" + padcast.AddressFile));
                }
                padcastRepository.Add(padcast);
                padcastRepository.Save();
                return RedirectToAction("Index");
            }

            ViewBag.CountryId = new SelectList(countryRepository.GetAll(), "CountryId", "CountryName", padcast.CountryId);
            return View(padcast);
        }

        // GET: Admin/Padcasts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Padcast padcast = padcastRepository.GetById(id.Value);
            if (padcast == null)
            {
                return HttpNotFound();
            }
            ViewBag.CountryId = new SelectList(countryRepository.GetAll(), "CountryId", "CountryName", padcast.CountryId); ;
            return View(padcast);
        }

        // POST: Admin/Padcasts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PadcastId,CountryId,PadcastName,Score,Visit,Type,AddressFile,Picture,CreateDate")] Padcast padcast, HttpPostedFileBase photo, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {                
                if (photo != null)
                {
                    if (padcast.Picture != null)
                    {
                        System.IO.File.Delete(Server.MapPath("/Files/Photos/" + padcast.Picture));
                    }
                    padcast.Picture = Guid.NewGuid() + Path.GetExtension(photo.FileName);
                    photo.SaveAs(Server.MapPath("/Files/Photos/" + padcast.Picture));
                }
                
                if (file != null)
                {
                    if (padcast.AddressFile != null)
                    {
                        System.IO.File.Delete(Server.MapPath("/Files/Musics/" + padcast.AddressFile));
                    }
                    padcast.AddressFile = Guid.NewGuid() + Path.GetExtension(file.FileName);
                    file.SaveAs(Server.MapPath("/Files/Musics/" + padcast.AddressFile));
                }

                padcastRepository.Update(padcast);
                padcastRepository.Save();
                return RedirectToAction("Index");
            }
            ViewBag.CountryId = new SelectList(countryRepository.GetAll(), "CountryId", "CountryName", padcast.CountryId);
            return View(padcast);
        }

        // GET: Admin/Padcasts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Padcast padcast = padcastRepository.GetById(id.Value);
            if (padcast == null)
            {
                return HttpNotFound();
            }
            return PartialView(padcast);
        }

        // POST: Admin/Padcasts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Padcast padcast = padcastRepository.GetById(id);
            padcastRepository.Delete(padcast);
            padcastRepository.Save();
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
