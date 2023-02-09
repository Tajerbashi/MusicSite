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

namespace MusicSite.Areas.Admin.Controllers
{
    public class UsersController : Controller
    {
        IUserRepository userRepository;
        private DbContexts db = new DbContexts();
        public UsersController()
        {
            userRepository = new UserRepository(db);
        }
        // GET: Admin/Users
        public ActionResult Index()
        {
            return View(userRepository.GetAll().ToList());
        }

        // GET: Admin/Users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = userRepository.GetById(id.Value);
            if (user == null)
            {
                return HttpNotFound();
            }
            return PartialView(user);
        }

        // GET: Admin/Users/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "userId,Name,Family,Phone,Email,Username,Password,Photo,Type,Total,CreateDate")] User user,HttpPostedFileBase userPhoto)
        {
            if (ModelState.IsValid)
            {
                if (userPhoto != null)
                {
                    user.Photo = Guid.NewGuid() + Path.GetExtension(userPhoto.FileName);
                    userPhoto.SaveAs(Server.MapPath("/Files/User/" + user.Photo));
                }
                userRepository.Add(user);
                userRepository.Save();
                return RedirectToAction("Index");
            }

            return View(user);
        }

        // GET: Admin/Users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = userRepository.GetById(id.Value);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Admin/Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "userId,Name,Family,Phone,Email,Username,Password,Photo,Type,Total,CreateDate")] User user,HttpPostedFileBase userPhoto)
        {
            if (ModelState.IsValid)
            {
                if (userPhoto != null)
                {
                    if (user.Photo != null)
                    {
                        System.IO.File.Delete(Server.MapPath("/Files/User/" + user.Photo));
                    }
                    user.Photo = Guid.NewGuid() + Path.GetExtension(userPhoto.FileName);
                    userPhoto.SaveAs(Server.MapPath("/Files/User/" + user.Photo));
                }
                userRepository.Update(user);
                userRepository.Save();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        // GET: Admin/Users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = userRepository.GetById(id.Value);
            if (user == null)
            {
                return HttpNotFound();
            }
            return PartialView(user);
        }

        // POST: Admin/Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = userRepository.GetById(id);
            if (user.Photo != null)
            {
                System.IO.File.Delete(Server.MapPath("/Files/User/" + user.Photo));
            }
            userRepository.Delete(user);
            userRepository.Save();
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
