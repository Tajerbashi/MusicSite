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
    public class AdminsController : Controller
    {
        private IAdminRepository adminRep;
        private DbContexts db=new DbContexts();

        public AdminsController()
        {
            adminRep = new AdminRepository(db);
        }

        // GET: Admin/Admins
        public ActionResult Index()
        {
            return View(adminRep.GetAll());
        }

        // GET: Admin/Admins/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DAL.Admin admin = adminRep.GetById(id.Value);
            if (admin == null)
            {
                return HttpNotFound();
            }
            return PartialView(admin);
        }

        // GET: Admin/Admins/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Admins/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "adminId,Name,Family,Email,Phone,Username,Password,CreateDate")] DAL.Admin admin)
        {
            if (ModelState.IsValid)
            {
                admin.CreateDate= DateTime.Now;
                adminRep.Add(admin);
                adminRep.Save();
                return RedirectToAction("Index");
            }

            return View(admin);
        }

        // GET: Admin/Admins/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DAL.Admin admin = adminRep.GetById(id.Value);
            if (admin == null)
            {
                return HttpNotFound();
            }
            return View(admin);
        }

        // POST: Admin/Admins/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "adminId,Name,Family,Email,Phone,Username,Password,CreateDate")] DAL.Admin admin)
        {
            if (ModelState.IsValid)
            {
                adminRep.Update(admin);
                adminRep.Save();
                return RedirectToAction("Index");
            }
            return View(admin);
        }

        // GET: Admin/Admins/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DAL.Admin admin = adminRep.GetById(id.Value);
            if (admin == null)
            {
                return HttpNotFound();
            }
            return PartialView(admin);
        }

        // POST: Admin/Admins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DAL.Admin admin = adminRep.GetById(id);
            adminRep.Delete(admin);
            adminRep.Save();
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
