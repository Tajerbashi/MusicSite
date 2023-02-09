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
    public class CountriesController : Controller
    {
        private DbContexts db = new DbContexts();
        ICountryRepository countryRepository;
        
        public CountriesController()
        {
            countryRepository = new CountryRepository(db);
        }

        // GET: Admin/Countries
        public ActionResult Index()
        {
            return View(countryRepository.GetAll());
        }

        // GET: Admin/Countries/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Country country = countryRepository.GetById(id.Value);
            if (country == null)
            {
                return HttpNotFound();
            }
            return PartialView(country);
        }

        // GET: Admin/Countries/Create
        public ActionResult Create()
        {
            return PartialView();
        }

        // POST: Admin/Countries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CountryId,CountryName")] Country country)
        {
            if (ModelState.IsValid)
            {
                countryRepository.Add(country);
                countryRepository.Save();
                return RedirectToAction("Index");
            }

            return View(country);
        }

        // GET: Admin/Countries/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Country country = countryRepository.GetById(id.Value);
            if (country == null)
            {
                return HttpNotFound();
            }
            return PartialView(country);
        }

        // POST: Admin/Countries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CountryId,CountryName")] Country country)
        {
            if (ModelState.IsValid)
            {
                countryRepository.Update(country);
                countryRepository.Save();
                return RedirectToAction("Index");
            }
            return PartialView(country);
        }

        // GET: Admin/Countries/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Country country = countryRepository.GetById(id.Value);
            if (country == null)
            {
                return HttpNotFound();
            }
            return PartialView(country);
        }

        // POST: Admin/Countries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Country country = countryRepository.GetById(id);
            countryRepository.Delete(country);
            countryRepository.Save();
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
